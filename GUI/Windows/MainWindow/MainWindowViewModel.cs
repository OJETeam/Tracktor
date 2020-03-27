using System.Collections.Generic;
using System.Collections.ObjectModel;
using Tracktor.Logic;

namespace GUI.Windows.MainWindow
{
	public class MainWindowViewModel
	{
		public ObservableCollection<Task> Tasks { get; }

		public MainWindowViewModel(IEnumerable<Task> tasks)
		{
			Tasks = new ObservableCollection<Task>(tasks);
		}
	}
}
