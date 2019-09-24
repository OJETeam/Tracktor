using System.Collections.Generic;

namespace Tracktor
{
    public abstract class TaskListSave
    {
        public abstract IEnumerable<Task> LoadTasks();
        public abstract void SaveTasks(IEnumerable<Task> tasks);
    }
}