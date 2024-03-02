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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DataFetchForm));
			splitContainer1 = new SplitContainer();
			tree_view = new TreeView();
			panel1 = new Panel();
			filter_group = new GroupBox();
			panel_filter = new Panel();
			tb_title = new TextBox();
			tb_condition = new TextBox();
			btn_plus = new Button();
			lb_title = new Label();
			lb_condition = new Label();
			btn_execute = new Button();
			((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
			splitContainer1.Panel1.SuspendLayout();
			splitContainer1.Panel2.SuspendLayout();
			splitContainer1.SuspendLayout();
			panel1.SuspendLayout();
			filter_group.SuspendLayout();
			panel_filter.SuspendLayout();
			SuspendLayout();
			// 
			// splitContainer1
			// 
			splitContainer1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			splitContainer1.Location = new Point(9, 10);
			splitContainer1.Name = "splitContainer1";
			// 
			// splitContainer1.Panel1
			// 
			splitContainer1.Panel1.Controls.Add(tree_view);
			// 
			// splitContainer1.Panel2
			// 
			splitContainer1.Panel2.Controls.Add(panel1);
			splitContainer1.Size = new Size(1180, 820);
			splitContainer1.SplitterDistance = 494;
			splitContainer1.TabIndex = 0;
			// 
			// tree_view
			// 
			tree_view.BackColor = Color.White;
			tree_view.BorderStyle = BorderStyle.FixedSingle;
			tree_view.CheckBoxes = true;
			tree_view.Dock = DockStyle.Fill;
			tree_view.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
			tree_view.ForeColor = Color.DodgerBlue;
			tree_view.LineColor = Color.DodgerBlue;
			tree_view.Location = new Point(0, 0);
			tree_view.Name = "tree_view";
			tree_view.Size = new Size(494, 820);
			tree_view.TabIndex = 0;
			tree_view.AfterCheck += tree_view_AfterCheck;
			tree_view.KeyDown += tree_view_KeyDown;
			// 
			// panel1
			// 
			panel1.BackColor = Color.White;
			panel1.BorderStyle = BorderStyle.FixedSingle;
			panel1.Controls.Add(filter_group);
			panel1.Controls.Add(btn_execute);
			panel1.Dock = DockStyle.Fill;
			panel1.Location = new Point(0, 0);
			panel1.Name = "panel1";
			panel1.Size = new Size(682, 820);
			panel1.TabIndex = 0;
			// 
			// filter_group
			// 
			filter_group.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			filter_group.BackColor = Color.White;
			filter_group.Controls.Add(panel_filter);
			filter_group.FlatStyle = FlatStyle.Flat;
			filter_group.Font = new Font("Imprint MT Shadow", 15F, FontStyle.Bold);
			filter_group.ForeColor = Color.DodgerBlue;
			filter_group.Location = new Point(3, 3);
			filter_group.Name = "filter_group";
			filter_group.Size = new Size(672, 633);
			filter_group.TabIndex = 12;
			filter_group.TabStop = false;
			filter_group.Text = "Filter";
			// 
			// panel_filter
			// 
			panel_filter.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			panel_filter.AutoScroll = true;
			panel_filter.Controls.Add(tb_title);
			panel_filter.Controls.Add(tb_condition);
			panel_filter.Controls.Add(btn_plus);
			panel_filter.Controls.Add(lb_title);
			panel_filter.Controls.Add(lb_condition);
			panel_filter.Location = new Point(7, 30);
			panel_filter.Name = "panel_filter";
			panel_filter.Size = new Size(659, 597);
			panel_filter.TabIndex = 5;
			// 
			// tb_title
			// 
			tb_title.AccessibleName = "title";
			tb_title.Font = new Font("Calibri", 12F);
			tb_title.ForeColor = Color.DodgerBlue;
			tb_title.Location = new Point(47, 33);
			tb_title.Name = "tb_title";
			tb_title.Size = new Size(159, 27);
			tb_title.TabIndex = 3;
			// 
			// tb_condition
			// 
			tb_condition.AccessibleName = "condition";
			tb_condition.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			tb_condition.Font = new Font("Calibri", 12F);
			tb_condition.ForeColor = Color.DodgerBlue;
			tb_condition.Location = new Point(212, 33);
			tb_condition.Name = "tb_condition";
			tb_condition.Size = new Size(434, 27);
			tb_condition.TabIndex = 4;
			// 
			// btn_plus
			// 
			btn_plus.AccessibleName = "plus";
			btn_plus.FlatAppearance.BorderSize = 0;
			btn_plus.FlatStyle = FlatStyle.Flat;
			btn_plus.Font = new Font("Impact", 15F, FontStyle.Regular, GraphicsUnit.Point, 0);
			btn_plus.ForeColor = Color.DarkSeaGreen;
			btn_plus.Location = new Point(6, 28);
			btn_plus.Name = "btn_plus";
			btn_plus.Size = new Size(35, 37);
			btn_plus.TabIndex = 0;
			btn_plus.Text = "+";
			btn_plus.UseVisualStyleBackColor = true;
			btn_plus.Click += btn_plus_Click;
			// 
			// lb_title
			// 
			lb_title.AutoSize = true;
			lb_title.Location = new Point(47, 6);
			lb_title.Name = "lb_title";
			lb_title.Size = new Size(55, 24);
			lb_title.TabIndex = 1;
			lb_title.Text = "Title";
			// 
			// lb_condition
			// 
			lb_condition.AutoSize = true;
			lb_condition.Location = new Point(212, 6);
			lb_condition.Name = "lb_condition";
			lb_condition.Size = new Size(103, 24);
			lb_condition.TabIndex = 2;
			lb_condition.Text = "Condition";
			// 
			// btn_execute
			// 
			btn_execute.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			btn_execute.BackColor = Color.Azure;
			btn_execute.FlatAppearance.BorderSize = 5;
			btn_execute.FlatStyle = FlatStyle.Flat;
			btn_execute.Font = new Font("Impact", 60F, FontStyle.Regular, GraphicsUnit.Point, 0);
			btn_execute.ForeColor = SystemColors.MenuHighlight;
			btn_execute.Location = new Point(32, 656);
			btn_execute.Name = "btn_execute";
			btn_execute.Size = new Size(619, 140);
			btn_execute.TabIndex = 11;
			btn_execute.Text = "E X E C U T E";
			btn_execute.UseVisualStyleBackColor = false;
			btn_execute.Click += btn_execute_Click;
			// 
			// DataFetchForm
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			BackColor = Color.White;
			ClientSize = new Size(1201, 842);
			Controls.Add(splitContainer1);
			Icon = (Icon)resources.GetObject("$this.Icon");
			Name = "DataFetchForm";
			StartPosition = FormStartPosition.CenterScreen;
			Text = "Open Your Table";
			Load += DataFetchForm_Load;
			splitContainer1.Panel1.ResumeLayout(false);
			splitContainer1.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
			splitContainer1.ResumeLayout(false);
			panel1.ResumeLayout(false);
			filter_group.ResumeLayout(false);
			panel_filter.ResumeLayout(false);
			panel_filter.PerformLayout();
			ResumeLayout(false);
		}

		#endregion

		private SplitContainer splitContainer1;
		private TreeView tree_view;
		private Panel panel1;
		private Button btn_execute;
		private GroupBox filter_group;
		private Button btn_plus;
		private Label lb_condition;
		private Label lb_title;
		private TextBox tb_condition;
		private TextBox tb_title;
		private Panel panel_filter;
	}
}