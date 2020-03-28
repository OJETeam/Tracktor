using System;
using Avalonia;
using Avalonia.Logging.Serilog;
using GUI;

namespace Launcher
{
	public static class Program
	{
		private static void Main(string[] args)
		{
			GUI.Main.StartGui(args);
		}

		private static AppBuilder BuildAvaloniaApp()
		{
			return GUI.Main.BuildAvaloniaApp();
		}
	}
}