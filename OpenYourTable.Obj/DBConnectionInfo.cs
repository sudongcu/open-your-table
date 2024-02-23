using OpenYourTable.Obj.Enums;

namespace OpenYourTable.Obj
{
	public class DBConnectionInfo
	{
		public static string connectionString { get; set; }

		public static DB_TYPE dbType { get; set; }

		public static string schema { get; set; }
	}
}
