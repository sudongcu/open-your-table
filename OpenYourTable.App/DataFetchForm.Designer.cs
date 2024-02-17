namespace OpenYourTable.App
{
	partial class DataFetchForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			splitContainer1 = new SplitContainer();
			treeView = new TreeView();
			panel1 = new Panel();
			((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
			splitContainer1.Panel1.SuspendLayout();
			splitContainer1.Panel2.SuspendLayout();
			splitContainer1.SuspendLayout();
			SuspendLayout();
			// 
			// splitContainer1
			// 
			splitContainer1.Location = new Point(9, 10);
			splitContainer1.Name = "splitContainer1";
			// 
			// splitContainer1.Panel1
			// 
			splitContainer1.Panel1.Controls.Add(treeView);
			// 
			// splitContainer1.Panel2
			// 
			splitContainer1.Panel2.Controls.Add(panel1);
			splitContainer1.Size = new Size(1180, 820);
			splitContainer1.SplitterDistance = 494;
			splitContainer1.TabIndex = 0;
			// 
			// treeView
			// 
			treeView.BackColor = Color.White;
			treeView.BorderStyle = BorderStyle.FixedSingle;
			treeView.Dock = DockStyle.Fill;
			treeView.LineColor = Color.DodgerBlue;
			treeView.Location = new Point(0, 0);
			treeView.Name = "treeView";
			treeView.Size = new Size(494, 820);
			treeView.TabIndex = 0;
			// 
			// panel1
			// 
			panel1.BackColor = Color.White;
			panel1.BorderStyle = BorderStyle.FixedSingle;
			panel1.Dock = DockStyle.Fill;
			panel1.Location = new Point(0, 0);
			panel1.Name = "panel1";
			panel1.Size = new Size(682, 820);
			panel1.TabIndex = 0;
			// 
			// DataFetchForm
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			BackColor = Color.White;
			ClientSize = new Size(1201, 842);
			Controls.Add(splitContainer1);
			Name = "DataFetchForm";
			StartPosition = FormStartPosition.CenterScreen;
			Text = "Open Your Table";
			Load += DataFetchForm_Load;
			splitContainer1.Panel1.ResumeLayout(false);
			splitContainer1.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
			splitContainer1.ResumeLayout(false);
			ResumeLayout(false);
		}

		#endregion

		private SplitContainer splitContainer1;
		private TreeView treeView;
		private Panel panel1;
	}
}