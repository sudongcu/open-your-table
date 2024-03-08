using NUnit.Framework;
using OpenYourTable.Core.Services;
using OpenYourTable.Obj;
using OpenYourTable.Obj.Enums;
using System.Reflection;
using System.Text;

namespace OpenYourTable.App
{
	public partial class DataFetchForm : Form
	{
		private readonly DataFetchService _dataFetchService;
		private bool isLoaded = false;
		private bool isCheckProcessing = false;
		private bool isCopyProcessing = false;

		private List<Control> filterControls;
		private int filterControlLimit = 13;

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
			filterControls = [];
			InitFilterToolTip();
		}

		private void InitFilterToolTip()
		{
			tip_filter.SetToolTip(lb_tab, "Sheet name in Excel.");

			StringBuilder sbCondition = new();
			sbCondition.AppendLine("You can filter the table by tab using various conditions.");
			sbCondition.AppendLine("If you want to use multiple conditions, separate them with ','.");
			sbCondition.AppendLine();
			sbCondition.AppendLine("Allowed words:");
			sbCondition.AppendLine();
			sbCondition.AppendLine("- 'text': Plain text. (e.g., tablename)");
			sbCondition.AppendLine("- '*': Filters to add character by prefix or suffix. (e.g., table*, *name)");
			sbCondition.AppendLine("- '!': Filters to remove character by prefix. (e.g., !tablename, !*name)");
			sbCondition.AppendLine("- Empty: All tables, but if the conditions are set above, the remaining tables.");
			tip_filter.SetToolTip(lb_condition, sbCondition.ToString());
		}

		#endregion / Initialize

		private void BindTableTree()
		{
			var tables = _dataFetchService.GetTableSchemas();

			TreeNode parentNode = tree_view.Nodes.Add(DBConnectionInfo.schema);
			parentNode.Checked = true;

			TreeNode[] childNodes = new TreeNode[tables.Count];

			int idx = 0;
			foreach (var table in tables)
			{
				childNodes[idx++] = new TreeNode(table)
				{
					Checked = true
				};
			}

			parentNode.Nodes.AddRange(childNodes);
			parentNode.Expand();
		}

		private void AssignNodesToList(TreeNodeCollection nodeCollection, ref List<string> nodes)
		{
			foreach (TreeNode node in nodeCollection)
			{
				if (node.Checked && node.Text != DBConnectionInfo.schema)
				{
					nodes.Add(node.Text);
				}

				if (node.Nodes.Count > 0)
					AssignNodesToList(node.Nodes, ref nodes);
			}
		}

		private void AssignFilterToDictionary(ref Dictionary<string, string[]> filterDic)
		{
			filterDic.Add(tb_tab.Text, [.. tb_condition.Text.Replace(" ", "").Split(',').OrderByDescending(o => o)]);

			foreach (var controlGroup in filterControls.GroupBy(g => g.Tag).Select(s => s))
			{
				if (filterDic.ContainsKey(controlGroup.ElementAt((int)FILTER.TAB).Text))
					throw new Exception($"Duplicate tabs exist. {controlGroup.ElementAt((int)FILTER.TAB).Text}");

				filterDic.Add(controlGroup.ElementAt((int)FILTER.TAB).Text, [.. controlGroup.ElementAt((int)FILTER.CONDITION).Text.Replace(" ", "").Split(',').OrderByDescending(o => o)]);
			}
		}

		private void AddFilter()
		{
			int addY = 43;
			int buttonY = btn_plus.Location.Y + addY;
			int tabY = tb_tab.Location.Y + addY;
			int conditionY = tb_condition.Location.Y + addY;

			if (filterControls.Count >= (int)FILTER.CONDITION + 1)
			{
				buttonY = filterControls[filterControls.Count - 3].Location.Y + addY;
				tabY = filterControls[filterControls.Count - 2].Location.Y + addY;
				conditionY = filterControls[filterControls.Count - 1].Location.Y + addY;
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

			TextBox tb_new_tab = new();
			tb_new_tab.AccessibleName = "tab";
			tb_new_tab.Font = tb_tab.Font;
			tb_new_tab.ForeColor = tb_tab.ForeColor;
			tb_new_tab.Size = tb_tab.Size;
			tb_new_tab.Tag = tagGuid;
			tb_new_tab.Location = new Point(tb_tab.Location.X, tabY);

			TextBox tb_new_condition = new();
			tb_new_condition.AccessibleName = "condition";
			tb_new_condition.Anchor = tb_condition.Anchor;
			tb_new_condition.Font = tb_condition.Font;
			tb_new_condition.ForeColor = tb_condition.ForeColor;
			tb_new_condition.Size = tb_condition.Size;
			tb_new_condition.Tag = tagGuid;
			tb_new_condition.Location = new Point(tb_condition.Location.X, conditionY);

			panel_filter.Controls.Add(btn_minus);
			panel_filter.Controls.Add(tb_new_tab);
			panel_filter.Controls.Add(tb_new_condition);

			filterControls.Add(btn_minus);
			filterControls.Add(tb_new_tab);
			filterControls.Add(tb_new_condition);
		}

		private void RemoveFilter(Control clickedControl)
		{
			var clickedControls = filterControls.FindAll(f => f.Tag.Equals(clickedControl.Tag));

			if (filterControls.Count > 3)
			{
				int indexOfLastClickedControl = filterControls.IndexOf(clickedControls[2]);

				for (int i = filterControls.Count - 1; i > indexOfLastClickedControl; i--)
				{
					int repositionY = filterControls[i - 3].Location.Y;
					filterControls[i].Location = new Point(filterControls[i].Location.X, repositionY);
					panel_filter.Controls.OfType<Control>().FirstOrDefault(ctrl => ctrl == filterControls[i]).Location = new Point(filterControls[i].Location.X, repositionY);
				}
			}

			foreach (Control control in clickedControls)
			{
				panel_filter.Controls.Remove(control);
				filterControls.Remove(control);
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

		private void tree_view_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.Control && e.KeyCode == Keys.C)
			{
				if (tree_view.SelectedNode is not null)
				{
					Clipboard.SetText(tree_view.SelectedNode.Text);
					e.Handled = true;
					e.SuppressKeyPress = true;
				}
			}
		}

		private void btn_plus_Click(object sender, EventArgs e)
		{
			if (filterControls.Count >= (filterControlLimit - 1) * 3)
			{
				MessageBox.Show($"The maximum number of filters is {filterControlLimit}.", "Filter", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			AddFilter();
		}

		private void btn_minius_Click(object sender, EventArgs e)
		{
			RemoveFilter((Control)sender);
		}

		private void btn_execute_Click(object sender, EventArgs e)
		{
			List<string> tables = [];

			AssignNodesToList(tree_view.Nodes, ref tables);

			if (tables.Count == 0)
				return;

			Dictionary<string, string[]> filterDic = [];

			AssignFilterToDictionary(ref filterDic);

			var tableSpecifications = _dataFetchService.GenerateSpecifications(tables, filterDic);

			SaveFileDialog saveFileDialog = new()
			{
				FileName = $"{DBConnectionInfo.schema}_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx",
				Filter = "Excel Files (*.xlsx)|*.xlsx|All files (*.*)|*.*",
			};

			if (saveFileDialog.ShowDialog() == DialogResult.OK)
			{
				File.WriteAllBytes(saveFileDialog.FileName, tableSpecifications);

				MessageBox.Show("Specification File is downloaded.", "Downloaded", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
		}
	}
}