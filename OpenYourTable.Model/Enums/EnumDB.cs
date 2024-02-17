using System.ComponentModel;

namespace OpenYourTable.Model.Enums
{
	public enum DB_TYPE
	{
		[Description("MySQL or MariaDB")]
		MySQL = 0,

		[Description("Microsoft SQL Server")]
		MSSQL = 1
	}
}
