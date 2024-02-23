using OpenYourTable.Core.Services;
using OpenYourTable.Obj;
using OpenYourTable.Obj.Enums;
using System.Reflection;

namespace OpenYourTable.App
{
	public partial class SettingsForm : Form
	{
		private readonly DataFetchService _dataFetchService;

		public SettingsForm(DataFetchService dataFetchService)
		{
			InitializeComponent();

			_dataFetchService = dataFetchService;
		}

		private void SettingsForm_Load(object sender, EventArgs e)
		{
			Init();

			Version version = Assembly.GetEntryAssembly().GetName().Version;
			this.Text += $" {version}";
		}

		#region Initialize

		private void Init()
		{
			InitUI();
		}

		private void InitUI()
		{
			InitUITextBox();
			InItUIComboBox();
		}

		private void InitUITextBox()
		{
			tb_host.Text = string.Empty;
			tb_id.Text = string.Empty;
			tb_password.Text = string.Empty;
			tb_schema.Text = string.Empty;
			tb_port.Text = "3306";
		}

		private void InItUIComboBox()
		{
			var dbType = GetDBTypeDictionary();
			
			cb_type.DisplayMember = "Value";
			cb_type.ValueMember = "Key";
			cb_type.DataSource = new BindingSource(dbType, null);
		}


		#endregion / Initialize

		private Dictionary<string, string> GetDBTypeDictionary()
		{
			var dbTypeDic = new Dictionary<string, string>
			{
				{ nameof(DB_TYPE.MySQL), DB_TYPE.MySQL.GetDescription() },
				{ nameof(DB_TYPE.MSSQL), DB_TYPE.MSSQL.GetDescription() }
			};

			return dbTypeDic;
		}

		private bool IsTextBoxEmpty()
		{
			TextBox[] textBoxes = [tb_host, tb_id, tb_password, tb_schema, tb_port];

			foreach (TextBox textBox in textBoxes)
			{
				if (string.IsNullOrWhiteSpace(textBox.Text))
					return false;
			}

			return true;
		}

		private void ShowOPEN()
		{
			var dataFetchForm = new DataFetchForm(_dataFetchService);
			this.Hide();
			dataFetchForm.ShowDialog();
			this.Close();
		}

		private void btn_open_Click(object sender, EventArgs e)
		{
			if (IsTextBoxEmpty() == false)
			{
				MessageBox.Show("Please fill in all input fields...", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			var connectionInfo = new ConnectionInfo()
			{
				host = tb_host.Text,
				port = tb_port.Text,
				id = tb_id.Text,
				password = tb_password.Text,
				schema = tb_schema.Text
			};

			DBConnectionInfo.connectionString = connectionInfo.ToString();
			DBConnectionInfo.dbType = (DB_TYPE)Enum.Parse(typeof(DB_TYPE), cb_type.SelectedValue.ToString());
			DBConnectionInfo.schema = connectionInfo.schema;

			// Check Available Connection
			_dataFetchService.CheckDBConnection();
			
			ShowOPEN();
		}

		private void cb_type_Click(object sender, EventArgs e)
		{
			cb_type.DroppedDown = true;
		}
	}
}