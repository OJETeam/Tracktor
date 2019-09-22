using System;
using System.Collections.Generic;
using System.Text;

namespace Tracktor
{
    public class XmlTaskListSave : TaskListSave
    {
        public readonly string Filename;

        public XmlTaskListSave(string xmlDocumentFilename, string filename)
        {
            Filename = filename;
        }

        public override IEnumerable<Task> LoadTasks()
        {
            yield break;
        }

        public override void SaveTasks(IEnumerable<Task> tasks)
        {
        }
    }
}