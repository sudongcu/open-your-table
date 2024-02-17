using NUnit.Framework;
using OpenYourTable.Core.Services;
using OpenYourTable.Model;

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
		}

		#region Initialize

		private void Init()
		{
			InitTreeView();
			isLoaded = true;
		}

		private void InitTreeView()
		{
			BindTableTree();
		}

		#endregion / Initialize

		private void BindTableTree()
		{
			var tableSchemas = _dataFetchService.GetTableSchemas();

			TreeNode parentNode = treeView.Nodes.Add(DBConnectionInfo.schema);
			parentNode.Checked = true;

			TreeNode[] childNodes = new TreeNode[tableSchemas.Count];

			int idx = 0;
			foreach (var schema in tableSchemas)
			{
				childNodes[idx++] = new TreeNode(schema.name)
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
				// 현재 노드의 텍스트를 리스트에 추가
				nodeList.Add(node.Text);

				// 현재 노드의 자식 노드들에 대해 재귀적으로 조회
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
							if (!childNode.Checked)
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


		}
	}
}