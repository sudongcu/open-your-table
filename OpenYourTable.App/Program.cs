using Microsoft.Extensions.DependencyInjection;
using OpenYourTable.App.Configs;
using OpenYourTable.App.Events;
using OpenYourTable.Core.Services;

namespace OpenYourTable.App
{
	internal static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			ApplicationConfiguration.Initialize();

			// Exception Handling 
			Application.ThreadException += new ThreadExceptionEventHandler(ExceptionEvent.CustomThreadException);
			AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(ExceptionEvent.CustomExceptionHandler);

			// Dependency Injection
			var services = new ServiceCollection().ConfigureDI();
			var serviceProvider = services.BuildServiceProvider();

			var dataFetchService = serviceProvider.GetRequiredService<DataFetchService>();

			// Create an instance of SettingsForm and inject the SettingService
			Application.Run(new SettingsForm(dataFetchService));
		}
	}
}