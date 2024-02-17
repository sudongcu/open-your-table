using OpenYourTable.Core.Services;
using OpenYourTable.Model;

namespace OpenYourTable.App
{
	public partial class DataFetchForm : Form
	{
		private readonly DataFetchService _dataFetchService;
		private readonly ConnectionInfo _connectionInfo;

		public DataFetchForm(DataFetchService dataFetchService, ConnectionInfo connectionInfo)
		{
			InitializeComponent();

			_dataFetchService = dataFetchService;
			_connectionInfo = connectionInfo;
		}

		private void DataFetchForm_Load(object sender, EventArgs e)
		{
			string test = "";


		}
	}
}