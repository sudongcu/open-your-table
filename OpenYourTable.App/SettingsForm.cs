using Microsoft.Extensions.DependencyInjection;
using OpenYourTable.App.Configs;
using OpenYourTable.Core.Services;
using OpenYourTable.Obj;
using OpenYourTable.Obj.Enums;
using System.Reflection;

namespace OpenYourTable.App
{
	public partial class SettingsForm : Form
	{
		public SettingsForm()
		{
			InitializeComponent();
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
			Dictionary<string, string> dbTypeDic = new()
			{
				{ nameof(DB_TYPE.MySql), DB_TYPE.MySql.GetDescription() },
				{ nameof(DB_TYPE.MSSQL), DB_TYPE.MSSQL.GetDescription() }
			};

			return dbTypeDic;
		}

		private bool IsTextBoxEmpty(out string field)
		{
			field = string.Empty;
			
			TextBox[] textBoxes = [tb_host, tb_id, tb_password, tb_schema];
			foreach (TextBox textBox in textBoxes)
			{
				if (string.IsNullOrWhiteSpace(textBox.Text))
				{
					field = textBox.AccessibleName ?? string.Empty;
					return false;
				}
			}

			return true;
		}

		private void OPEN(ConnectionInfo conn)
		{
			// Set Connection
			DBConnectionInfo.connectionString = conn.ToString();
			DBConnectionInfo.schema = conn.schema;

			// Dependency Injection
			var services = new ServiceCollection()
								.ConfigureDI()
								.ConfigureConnectionDI(conn.dbType);
			var serviceProvider = services.BuildServiceProvider();

			var dataFetchService = serviceProvider.GetRequiredService<DataFetchService>();

			// Check Available Connection
			dataFetchService.CheckDBConnection();

			// Switch to DataFetchForm
			DataFetchForm dataFetchForm = new(dataFetchService);
			this.Hide();
			dataFetchForm.ShowDialog();
			this.Close();
		}

		private void btn_open_Click(object sender, EventArgs e)
		{
			if (IsTextBoxEmpty(out string field) == false)
			{
				MessageBox.Show($"Please fill in input field {field}.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			ConnectionInfo conn = new()
			{
				host = tb_host.Text,
				port = tb_port.Text,
				id = tb_id.Text,
				password = tb_password.Text,
				schema = tb_schema.Text,
				dbType = (DB_TYPE)Enum.Parse(typeof(DB_TYPE), cb_type.SelectedValue.ToString())
			};

			OPEN(conn);
		}

		private void cb_type_Click(object sender, EventArgs e)
		{
			cb_type.DroppedDown = true;
		}

		private void cb_type_SelectedIndexChanged(object sender, EventArgs e)
		{
			var comboBox = (ComboBox)sender;
			
			KeyValuePair<string, string> item = (KeyValuePair<string, string>)comboBox.SelectedItem;
			if (item.Key == nameof(DB_TYPE.MySql))
				tb_port.Text = $"{3306}";
			else if (item.Key == nameof(DB_TYPE.MSSQL))
				tb_port.Text = $"{1433}";
		}
	}
}