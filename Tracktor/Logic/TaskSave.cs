namespace Tracktor.Logic
{
    public abstract class TaskSave
    {
        public abstract void SaveTask(Task task);
        public abstract Task ReadTask();
    }
}