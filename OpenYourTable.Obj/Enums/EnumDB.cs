using System.ComponentModel;

namespace OpenYourTable.Obj.Enums
{
	public enum DB_TYPE
	{
		[Description("MySql or MariaDB")]
		MySql = 0,

		[Description("Microsoft SQL Server")]
		MSSQL = 1
	}

	public enum COLUMN_DEFAULT_EXTRA
	{
		AUTO_INCREMENT = 0
	}

	public enum INDEX_NAME
	{
		[Description("PK")]
		PRIMARY = 0,

		[Description("UK")]
		UNIQUE = 1,

		[Description("IX")]
		INDEX = 2
	}
}
