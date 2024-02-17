namespace OpenYourTable.Model.DataFetch
{
	public class TableSchema
	{
		public string name { get; set; }

		public string comment { get; set; }

		public TableSchema(string name, string comment)
		{
			this.name = name;
			this.comment = comment;
		}

	}
}
