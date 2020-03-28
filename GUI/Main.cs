using Avalonia;
using Avalonia.Logging.Serilog;

namespace GUI
{
	public static class Main
	{
		public static void StartGui(string[] args) //TODO do we need to pass args here?
		{
			BuildAvaloniaApp().StartWithClassicDesktopLifetime(args);
		}

		public static AppBuilder BuildAvaloniaApp()
		{
			return AppBuilder.Configure<App>().UsePlatformDetect().LogToDebug();
		}
	}
}
