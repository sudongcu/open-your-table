using System.ComponentModel;

namespace OpenYourTable.Model.Enums
{
	public enum TABLE_CELL
	{
		[Description("Schema")]
		SCHEMA = COLUMN_CELL.SEQ,

		[Description("Table Name")]
		NAME_FROM = COLUMN_CELL.NAME,
		[Description("Table Name")]
		NAME_TO = COLUMN_CELL.NULLABLE, 

		[Description("Table Comment")]
		COMMENT_FROM = COLUMN_CELL.INDEX,
		[Description("Table Comment")]
		COMMENT_TO = COLUMN_CELL.COMMENT
	}

	public enum COLUMN_CELL
	{
		[Description("#")]
		SEQ = 2,

		[Description("Name")]
		NAME = 3,

		[Description("Data Type")]
		DATA_TYPE = 4,

		[Description("Length")]
		LENGTH = 5,

		[Description("Nullable")]
		NULLABLE = 6,

		[Description("Index")]
		INDEX = 7,

		[Description("Default Value")]
		DEFAULT = 8,

		[Description("Comment")]
		COMMENT = 9
	}
}
