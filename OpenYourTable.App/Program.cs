using OpenYourTable.App.Events;

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
			// EPPlus - NonCommercial
			OfficeOpenXml.ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;

			ApplicationConfiguration.Initialize();

			// Exception Handling 
			Application.ThreadException += new ThreadExceptionEventHandler(ExceptionEvent.CustomThreadException);
			AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(ExceptionEvent.CustomExceptionHandler);

			// Create an instance of SettingsForm and inject the SettingService
			Application.Run(new SettingsForm());
		}
	}
}