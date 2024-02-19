namespace OpenYourTable.Model.DataFetch
{
	public class ColumnSpecification
	{
		public string name { get; set; }

		public string dataType { get; set; }

		public string maxLength { get; set; }

		public string nullable { get; set; }

		public string index { get; set; }

		public string defaultValue { get; set; }

		public string comment { get; set; }		
	}
}
