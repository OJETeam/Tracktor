namespace Tracktor.Logic
{
    public class Task
    {
        public string Name;
        public TaskType Type;
        public TaskPriority Priority;
        public TaskStatus Status;

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