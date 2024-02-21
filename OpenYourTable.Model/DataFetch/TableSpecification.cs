namespace OpenYourTable.Model.DataFetch
{
	public class TableSpecification
	{
		public string schema { get; set; }

		public string name { get; set; }

		public string comment { get; set; }

		public List<ColumnSpecification> columns { get; set; }
	}
}
