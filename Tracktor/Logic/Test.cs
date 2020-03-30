using System;
using System.Collections.Generic;
using System.Text;

namespace Tracktor.Logic
{
	public static class Test
	{
		private static List<Task> _testTasks = new List<Task>
		{
			new Task("Do this", TaskType.Feature, TaskPriority.Minor, TaskStatus.InProgress) { Description = "blablabla bla bla"},
			new Task("Do that", TaskType.Improvement, TaskPriority.Major, TaskStatus.NotViewed),
			new Task("Fixed this", TaskType.Bug, TaskPriority.Blocker, TaskStatus.Done) { Description = "actually, not"},
		};

		public static List<Task> GetTestTasks(int taskCount)
		{
			List<Task> result = new List<Task>();

			for (int i = 0; i < taskCount; i++)
			{
				result.Add(_testTasks[i % _testTasks.Count]);
			}

			return result;
		}
	}
}