using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Linq;

namespace Tracktor
{
    public class XmlTaskListSave : TaskListSave
    {
        public readonly string Filename;

        public XmlTaskListSave(string xmlDocumentFilename)
        {
            Filename = xmlDocumentFilename;
        }

        public override IEnumerable<Task> LoadTasks()
        {
            if (!File.Exists(Filename))
                yield break;

            using FileStream fileStream = new FileStream(Filename, FileMode.Open, FileAccess.Read);
            XDocument doc = XDocument.Load(fileStream);
            XElement rootElement = doc.Root;

            XElement tasksRoot = rootElement.Element(XmlElementNames.TasksRootElementName);
            foreach (Task readTask in ReadTasksNode(tasksRoot))
            {
                yield return readTask;
            }
        }

        private IEnumerable<Task> ReadTasksNode(XElement rootElement)
        {
            if (rootElement.Name != XmlElementNames.TasksRootElementName)
                throw new XmlException("Wrong root for tasks");

            foreach (XElement element in rootElement.Elements(XmlElementNames.TaskElementName))
            {
                XmlTaskSave loader = new XmlTaskSave { RootElement = element };

                Task task = loader.ReadTask();
                yield return task;
            }
        }

        public override void SaveTasks(IEnumerable<Task> tasks) //TODO move header saving/restoring to separate class or function
        {
            using FileStream fileStream = new FileStream(Filename, FileMode.Create, FileAccess.Write);
            XDocument doc = new XDocument();
            XElement rootElement = new XElement(XmlElementNames.RootElementName);
            doc.Add(rootElement);

            XElement tasksNode = SaveTasksNode(tasks);
            rootElement.Add(tasksNode);

            doc.Save(fileStream);
        }

        private XElement SaveTasksNode(IEnumerable<Task> tasks)
        {
            XElement element = new XElement(XmlElementNames.TasksRootElementName);

            foreach (Task task in tasks)
            {
                XmlTaskSave saver = new XmlTaskSave();
                saver.SaveTask(task);

                element.Add(saver.RootElement);
            }

            return element;
        }
    }
}