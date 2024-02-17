using OpenYourTable.Model.Enums;

namespace OpenYourTable.Model
{
	public class DBConnectionInfo
	{
		public static string connectionString { get; set; }

		public static DB_TYPE dbType { get; set; }

		public static string schema { get; set; }
	}
}
