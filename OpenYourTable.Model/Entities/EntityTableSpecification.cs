namespace OpenYourTable.Model.Entities
{
	public class EntityTableSpecification
	{
		public string table_name { get; set; }

		public string column_name { get; set; }

		public string data_type { get; set; }

		public string? column_key { get; set; }

		public bool is_nullable { get; set; }

		public string? index_name { get; set; }

		public int? seq_in_index { get; set; }

		public int? non_unique { get; set; }
	}
}
