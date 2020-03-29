using System;
using System.Xml.Linq;

namespace Tracktor.Logic
{
	public class XmlTaskSave : TaskSave
	{
		public XElement RootElement;

		public XmlTaskSave(XElement rootElement)
		{
			RootElement = rootElement;
		}

		public XmlTaskSave()
		{
			RootElement = new XElement(XmlElementNames.TaskElementName);
		}

		public override Task ReadTask()
		{
			XElement nameElement = RootElement.Element(XmlElementNames.TaskName);
			XElement descriptionElement = RootElement.Element(XmlElementNames.TaskDescription);
			XElement typeElement = RootElement.Element(XmlElementNames.TaskType);
			XElement priorityElement = RootElement.Element(XmlElementNames.TaskPriority);
			XElement statusElement = RootElement.Element(XmlElementNames.TaskStatus);

			string name = nameElement.Value;
			string description = descriptionElement.Value;
			TaskType type = Enum.Parse<TaskType>(typeElement.Value); //TODO remove enum parsing
			TaskPriority priority = Enum.Parse<TaskPriority>(priorityElement.Value);
			TaskStatus status = Enum.Parse<TaskStatus>(statusElement.Value);

			Task task = new Task(name, type, priority, status);
			task.Description = description;

			return task;
		}

		public override void SaveTask(Task task)
		{
			RootElement = new XElement(XmlElementNames.TaskElementName);

			XElement name = new XElement(XmlElementNames.TaskName) { Value = task.Name };
			XElement descriptionElement = new XElement(XmlElementNames.TaskDescription) { Value = task.Description };
			XElement type = new XElement(XmlElementNames.TaskType) { Value = task.Type.ToString() };
			XElement priority = new XElement(XmlElementNames.TaskPriority) { Value = task.Priority.ToString() };
			XElement status = new XElement(XmlElementNames.TaskStatus) { Value = task.Status.ToString() };

			RootElement.Add(name);
			RootElement.Add(type);
			RootElement.Add(priority);
			RootElement.Add(status);
		}
	}
}