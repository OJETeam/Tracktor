using System.Collections.Generic;
using System.Linq;
using Tracktor.Logic;

namespace Tracktor
{
    public static class TestLogic
    {
        public static List<Task> TestTasks;

        static void Main(string[] args)
        {
            InitGUI();

            TestTasks = new List<Task>
            {
                new Task("OJ is pidor", TaskType.Bug, TaskPriority.Blocker, TaskStatus.InProgress),
                new Task("Eugen is pidor", TaskType.Bug, TaskPriority.Trivial, TaskStatus.InProgress),
                new Task("OJ is fat AF", TaskType.Bug, TaskPriority.Blocker, TaskStatus.Done)
            };

            XmlSettingsSave settingsLoad = new XmlSettingsSave("TEST_SETTINGS.xml");
            Settings testLoadSettings = settingsLoad.ReadSettings();

            Settings currentSettings = new Settings(); //TODO move somewhere
            currentSettings.SaveFolder = "";
            currentSettings.SaveFilename = "MainTasks.task";

            XmlSettingsSave settingsSave = new XmlSettingsSave("TEST_SETTINGS.xml");
            settingsSave.SaveSettings(currentSettings);

            //SaveTest(currentSettings.GetSaveFilePath());
            LoadTest(currentSettings.GetSaveFilePath());
        }

        private static void InitGUI()
        {
            SpaceVIL.Common.CommonService.InitSpaceVILComponents();

            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
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