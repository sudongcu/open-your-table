using NUnit.Framework;
using OpenYourTable.Core.Services;
using OpenYourTable.Obj;
using System.Reflection;

namespace OpenYourTable.App
{
	public partial class DataFetchForm : Form
	{
		private readonly DataFetchService _dataFetchService;
		private bool isLoaded = false;
		private bool isCheckProcessing = false;

		public DataFetchForm(DataFetchService dataFetchService)
		{
			InitializeComponent();

			_dataFetchService = dataFetchService;
		}

		private void DataFetchForm_Load(object sender, EventArgs e)
		{
			Init();
			
			isLoaded = true;

			Version version = Assembly.GetEntryAssembly().GetName().Version;
			this.Text += $" {version}";
		}

		#region Initialize

		private void Init()
		{
			InitTreeView();
		}

		private void InitTreeView()
		{
			BindTableTree();
		}

		#endregion / Initialize

		private void BindTableTree()
		{
			var tables = _dataFetchService.GetTableSchemas();

			TreeNode parentNode = treeView.Nodes.Add(DBConnectionInfo.schema);
			parentNode.Checked = true;

			TreeNode[] childNodes = new TreeNode[tables.Count];

			int idx = 0;
			foreach (var tableName in tables)
			{
				childNodes[idx++] = new TreeNode(tableName)
				{
					Checked = true
				};
			}

			parentNode.Nodes.AddRange(childNodes);
			parentNode.Expand();
		}

		private void AssignNodesToList(TreeNodeCollection nodes, ref List<string> nodeList)
		{
			foreach (TreeNode node in nodes)
			{
				if (node.Checked)
					nodeList.Add(node.Text);

				if (node.Nodes.Count > 0)
					AssignNodesToList(node.Nodes, ref nodeList);
			}
		}

		private void treeView_AfterCheck(object sender, TreeViewEventArgs e)
		{
			if (isLoaded == false)
				return;

			if (isCheckProcessing)
				return;

			try
			{
				isCheckProcessing = true;

				if (e.Node.Parent == null)
				{
					foreach (TreeNode childNode in e.Node.Nodes)
					{
						childNode.Checked = e.Node.Checked;
					}
				}
				else
				{
					TreeNode parentNode = e.Node.Parent;

					if (e.Node.Checked == false)
					{
						parentNode.Checked = false;
					}
					else
					{
						bool allChildrenChecked = true;

						foreach (TreeNode childNode in parentNode.Nodes)
						{
							if (childNode.Checked == false)
							{
								allChildrenChecked = false;
								break;
							}
						}

						parentNode.Checked = allChildrenChecked;
					}
				}
			}
			catch (Exception ex)
			{
				Assert.Fail(ex.Message);
			}
			finally
			{
				isCheckProcessing = false;
			}
		}

		private void btn_execute_Click(object sender, EventArgs e)
		{
			List<string> tableList = [];

			AssignNodesToList(treeView.Nodes, ref tableList);

			if (tableList.Count == 0)
				return;

			var tableSpecificationsBytes = _dataFetchService.GenerateSpecifications(tableList);
			
			SaveFileDialog saveFileDialog = new SaveFileDialog
			{
				FileName = $"{DBConnectionInfo.schema}_{DateTime.Now.ToString("yyyyMMdd_HHmmss")}.xlsx",
				Filter = "Excel Files (*.xlsx)|*.xlsx|All files (*.*)|*.*",
			};

			if (saveFileDialog.ShowDialog() == DialogResult.OK)
			{
				File.WriteAllBytes(saveFileDialog.FileName, tableSpecificationsBytes);

				MessageBox.Show("Specification File is downloaded.", "Downloaded", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
		}
	}
}