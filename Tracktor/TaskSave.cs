using System;
using System.Collections.Generic;
using System.Text;

namespace Tracktor
{
    public abstract class TaskSave
    {
        public abstract void SaveTask(Task task);

        public abstract Task LoadTask();
    }
}