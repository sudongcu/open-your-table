using System.ComponentModel;

namespace OpenYourTable.Model.Enums
{
	public enum TABLE_CELL
	{
		[Description("Table Name")]
		NAME_FROM = 2,
		[Description("Table Name")]
		NAME_TO = 4, 

		[Description("Table Comment")]
		COMMENT_FROM = 5,
		[Description("Table Comment")]
		COMMENT_TO = 8
	}

	public enum COLUMN_CELL
	{
		[Description("Name")]
		NAME = 2,

		[Description("Data Type")]
		DATA_TYPE = 3,

		[Description("Length")]
		LENGTH = 4,

		[Description("Nullable")]
		NULLABLE = 5,

		[Description("Index")]
		INDEX = 6,

		[Description("Default Value")]
		DEFAULT = 7,

		[Description("Comment")]
		COMMENT = 8
	}
}
