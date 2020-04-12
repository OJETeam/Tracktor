using System.Collections.Generic;
using System.Collections.ObjectModel;
using Avalonia.Controls;
using Tracktor.Logic;

namespace GUI.Windows.MainWindow
{
	public class MainWindowViewModel
	{
		public ObservableCollection<Task> Tasks { get; }
		public GridLength ColumnSize0 { get; set; }
		public GridLength ColumnSize1 { get; set; }

		public MainWindowViewModel(IEnumerable<Task> tasks)
		{
			Tasks = new ObservableCollection<Task>(tasks);
		}
	}
}
