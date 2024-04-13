namespace OpenYourTable.Obj.Models.Data
{
	public class TableGenerateInfo
	{
		public List<string> tables { get; set; }
	
		public Dictionary<string, string[]> filterDic { get; set; }

		public TableGenerateOption option { get; set; }
	}
}
