using System.Diagnostics;

namespace OpenYourTable.App.Events
{
	public class ExceptionEvent
	{
		public static void CustomThreadException(object sender, ThreadExceptionEventArgs e)
		{
			MessageBox.Show($"An error occurred: {e.Exception.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
		}

		public static void CustomExceptionHandler(object sender, UnhandledExceptionEventArgs args)
		{
			Exception ex = (Exception)args.ExceptionObject;
			Trace.WriteLine($"CustomExceptionHandler[{ex.Source}] : {ex.Message}");
			MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
		}
	}
}
