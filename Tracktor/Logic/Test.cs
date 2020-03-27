using System;
using System.Collections.Generic;
using System.Text;

namespace Tracktor.Logic
{
	public static class Test
	{
		public static List<Task> TestTasks = new List<Task>
		{
			new Task("Do this", TaskType.Feature, TaskPriority.Minor, TaskStatus.InProgress),
			new Task("Do that", TaskType.Improvement, TaskPriority.Major, TaskStatus.NotViewed),
			new Task("Fixed this", TaskType.Bug, TaskPriority.Blocker, TaskStatus.Done),
		};
	}
}