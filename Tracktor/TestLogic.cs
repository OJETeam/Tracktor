using System.Collections.Generic;
using System.Linq;

namespace Tracktor
{
    public class TestLogic
    {
        public static List<Task> TestTasks;

        static void Main(string[] args)
        {
            TestTasks = new List<Task>
            {
                new Task("OJ is pidor", TaskType.Bug, TaskPriority.Blocker, TaskStatus.InProgress),
                new Task("Eugen is pidor", TaskType.Bug, TaskPriority.Trivial, TaskStatus.InProgress),
                new Task("OJ is fat AF", TaskType.Bug, TaskPriority.Blocker, TaskStatus.Done)
            };

            Settings currentSettings = new Settings(); //TODO move somewhere
            currentSettings.SaveFolder = "";
            currentSettings.SaveFilename = "MainTasks.task";

            //SaveTest(currentSettings.GetSaveFilePath());
            LoadTest(currentSettings.GetSaveFilePath());
        }

        private static void LoadTest(string filename)
        {
            XmlTaskListSave taskLoader = new XmlTaskListSave(filename);
            List<Task> taskList = taskLoader.LoadTasks().ToList();
        }

        private static void SaveTest(string filename)
        {
            XmlTaskListSave tasksSave = new XmlTaskListSave(filename);
            tasksSave.SaveTasks(TestTasks);
        }
    }
}