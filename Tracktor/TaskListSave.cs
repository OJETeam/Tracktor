using System;
using System.Collections.Generic;
using System.Text;

namespace Tracktor
{
    public abstract class TaskListSave
    {
        public abstract IEnumerable<Task> LoadTasks();

        public abstract void SaveTasks(IEnumerable<Task> tasks);
    }
}