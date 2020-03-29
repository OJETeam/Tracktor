namespace Tracktor.Logic
{
	public class Task
	{
		public string Name { get; set; }
		public string Description { get; set; } //TODO description may not be a string. It should have images, fonts, etc. maybe, html?
		public TaskType Type { get; set; }
		public TaskPriority Priority { get; set; }
		public TaskStatus Status { get; set; }

		public Task(string name, TaskType type, TaskPriority priority, TaskStatus status)
		{
			Name = name;
			Type = type;
			Priority = priority;
			Status = status;
		}

		public override string ToString() //TODO implement
		{
			return base.ToString();
		}
	}
}