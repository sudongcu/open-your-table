using NUnit.Framework;
using OpenYourTable.Core.Services;
using OpenYourTable.Obj;
using System.Linq;
using System.Reflection;

namespace OpenYourTable.App
{
	public partial class DataFetchForm : Form
	{
		private readonly DataFetchService _dataFetchService;
		private bool isLoaded = false;
		private bool isCheckProcessing = false;

		private List<Control> filterControlList;
		
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
			InitFilterGroup();
		}

		private void InitTreeView()
		{
			BindTableTree();
		}

		private void InitFilterGroup()
		{
			filterControlList = [];
		}

		#endregion / Initialize

		private void BindTableTree()
		{
			var tables = _dataFetchService.GetTableSchemas();

			TreeNode parentNode = tree_view.Nodes.Add(DBConnectionInfo.schema);
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

		private void tree_view_AfterCheck(object sender, TreeViewEventArgs e)
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

		private void AddFilter()
		{
			int addY = 43;
			int buttonY = btn_plus.Location.Y + addY;
			int titleY = tb_title.Location.Y + addY;
			int conditionY = tb_condition.Location.Y + addY;

			if (filterControlList.Count >= 3)
			{
				buttonY = filterControlList[filterControlList.Count - 3].Location.Y + addY;
				titleY = filterControlList[filterControlList.Count - 2].Location.Y + addY;
				conditionY = filterControlList[filterControlList.Count - 1].Location.Y + addY;
			}

			Guid tagGuid = Guid.NewGuid();

			Button btn_minus = new();
			btn_minus.AccessibleName = "minus";
			btn_minus.FlatAppearance.BorderSize = btn_plus.FlatAppearance.BorderSize;
			btn_minus.FlatStyle = btn_plus.FlatStyle;
			btn_minus.Font = btn_plus.Font;
			btn_minus.Size = btn_plus.Size;
			btn_minus.UseVisualStyleBackColor = btn_plus.UseVisualStyleBackColor;
			btn_minus.ForeColor = Color.Salmon;
			btn_minus.Tag = tagGuid;
			btn_minus.Text = "-";
			btn_minus.Click += btn_minius_Click;
			btn_minus.Location = new Point(btn_plus.Location.X, buttonY);

			TextBox tb_new_title = new();
			tb_new_title.AccessibleName = "title";
			tb_new_title.Font = tb_title.Font;
			tb_new_title.ForeColor = tb_title.ForeColor;
			tb_new_title.Size = tb_title.Size;
			tb_new_title.Tag = tagGuid;
			tb_new_title.Location = new Point(tb_title.Location.X, titleY);

			TextBox tb_new_condition = new();
			tb_new_condition.AccessibleName = "condition";
			tb_new_condition.Anchor = tb_condition.Anchor;
			tb_new_condition.Font = tb_condition.Font;
			tb_new_condition.ForeColor = tb_condition.ForeColor;
			tb_new_condition.Size = tb_condition.Size;
			tb_new_condition.Tag = tagGuid;
			tb_new_condition.Location = new Point(tb_condition.Location.X, conditionY);

			panel_filter.Controls.Add(btn_minus);
			panel_filter.Controls.Add(tb_new_title);
			panel_filter.Controls.Add(tb_new_condition);

			filterControlList.Add(btn_minus);
			filterControlList.Add(tb_new_title);
			filterControlList.Add(tb_new_condition);
		}

		private void RemoveFilter(Control clickedControl)
		{
			var clickedGroup = filterControlList.FindAll(f => f.Tag.Equals(clickedControl.Tag));
			if (filterControlList.Count > 3)
			{
				var repositionGroup = filterControlList[(filterControlList.IndexOf(clickedGroup[2]) + 1)..];

			}

			foreach (Control control in clickedGroup)
			{
				panel_filter.Controls.Remove(control);
				filterControlList.Remove(control);
			}
		}

		private void btn_plus_Click(object sender, EventArgs e)
		{
			AddFilter();
		}

		private void btn_minius_Click(object sender, EventArgs e)
		{
			RemoveFilter((Control)sender);
		}

		private void btn_execute_Click(object sender, EventArgs e)
		{
			List<string> tableList = [];

			AssignNodesToList(tree_view.Nodes, ref tableList);

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