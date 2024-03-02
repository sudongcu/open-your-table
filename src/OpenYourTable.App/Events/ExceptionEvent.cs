using System.Diagnostics;

namespace OpenYourTable.App.Events
{
	public class ExceptionEvent
	{
		public static void CustomThreadException(object sender, ThreadExceptionEventArgs e)
		{
			MessageBox.Show($"{e.Exception.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
		}

		public static void CustomExceptionHandler(object sender, UnhandledExceptionEventArgs args)
		{
			Exception ex = (Exception)args.ExceptionObject;
			MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
		}
	}
}
