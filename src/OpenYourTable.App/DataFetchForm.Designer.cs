﻿namespace OpenYourTable.App
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
			components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DataFetchForm));
			splitContainer1 = new SplitContainer();
			tree_view = new TreeView();
			panel2 = new Panel();
			toolStrip = new ToolStrip();
			btn_refresh = new ToolStripButton();
			panel1 = new Panel();
			filter_group = new GroupBox();
			panel_filter = new Panel();
			tb_tab = new TextBox();
			tb_condition = new TextBox();
			btn_plus = new Button();
			lb_tab = new Label();
			lb_condition = new Label();
			btn_execute = new Button();
			tip_filter = new ToolTip(components);
			mySqlCommand1 = new MySql.Data.MySqlClient.MySqlCommand();
			((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
			splitContainer1.Panel1.SuspendLayout();
			splitContainer1.Panel2.SuspendLayout();
			splitContainer1.SuspendLayout();
			panel2.SuspendLayout();
			toolStrip.SuspendLayout();
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
			splitContainer1.Panel1.Controls.Add(panel2);
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
			tree_view.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			tree_view.BackColor = Color.White;
			tree_view.BorderStyle = BorderStyle.None;
			tree_view.CheckBoxes = true;
			tree_view.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
			tree_view.ForeColor = Color.DodgerBlue;
			tree_view.LineColor = Color.DodgerBlue;
			tree_view.Location = new Point(4, 34);
			tree_view.Name = "tree_view";
			tree_view.Size = new Size(486, 782);
			tree_view.TabIndex = 0;
			tree_view.AfterCheck += tree_view_AfterCheck;
			tree_view.KeyDown += tree_view_KeyDown;
			// 
			// panel2
			// 
			panel2.BackColor = Color.White;
			panel2.BorderStyle = BorderStyle.FixedSingle;
			panel2.Controls.Add(toolStrip);
			panel2.Dock = DockStyle.Fill;
			panel2.Location = new Point(0, 0);
			panel2.Name = "panel2";
			panel2.Size = new Size(494, 820);
			panel2.TabIndex = 1;
			// 
			// toolStrip
			// 
			toolStrip.BackColor = Color.White;
			toolStrip.GripStyle = ToolStripGripStyle.Hidden;
			toolStrip.ImeMode = ImeMode.NoControl;
			toolStrip.Items.AddRange(new ToolStripItem[] { btn_refresh });
			toolStrip.Location = new Point(0, 0);
			toolStrip.Name = "toolStrip";
			toolStrip.Size = new Size(492, 25);
			toolStrip.TabIndex = 1;
			// 
			// btn_refresh
			// 
			btn_refresh.DisplayStyle = ToolStripItemDisplayStyle.Image;
			btn_refresh.Image = (Image)resources.GetObject("btn_refresh.Image");
			btn_refresh.ImageTransparentColor = Color.DodgerBlue;
			btn_refresh.Margin = new Padding(2, 1, 0, 2);
			btn_refresh.Name = "btn_refresh";
			btn_refresh.Size = new Size(23, 22);
			btn_refresh.Text = "toolStripButton1";
			btn_refresh.ToolTipText = "Refresh Tables";
			btn_refresh.Click += btn_refresh_Click;
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
			panel_filter.Controls.Add(tb_tab);
			panel_filter.Controls.Add(tb_condition);
			panel_filter.Controls.Add(btn_plus);
			panel_filter.Controls.Add(lb_tab);
			panel_filter.Controls.Add(lb_condition);
			panel_filter.Location = new Point(7, 30);
			panel_filter.Name = "panel_filter";
			panel_filter.Size = new Size(659, 597);
			panel_filter.TabIndex = 5;
			// 
			// tb_tab
			// 
			tb_tab.AccessibleName = "tab";
			tb_tab.Font = new Font("Calibri", 12F);
			tb_tab.ForeColor = Color.DodgerBlue;
			tb_tab.Location = new Point(47, 33);
			tb_tab.Name = "tb_tab";
			tb_tab.Size = new Size(159, 27);
			tb_tab.TabIndex = 3;
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
			// lb_tab
			// 
			lb_tab.AutoSize = true;
			lb_tab.Location = new Point(47, 6);
			lb_tab.Name = "lb_tab";
			lb_tab.Size = new Size(110, 24);
			lb_tab.TabIndex = 1;
			lb_tab.Text = "Tab Name";
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
			// tip_filter
			// 
			tip_filter.AutomaticDelay = 100;
			tip_filter.AutoPopDelay = 5000;
			tip_filter.BackColor = Color.Azure;
			tip_filter.ForeColor = Color.DodgerBlue;
			tip_filter.InitialDelay = 100;
			tip_filter.ReshowDelay = 20;
			tip_filter.ToolTipIcon = ToolTipIcon.Info;
			tip_filter.ToolTipTitle = "Filter Rule";
			// 
			// mySqlCommand1
			// 
			mySqlCommand1.CacheAge = 0;
			mySqlCommand1.Connection = null;
			mySqlCommand1.EnableCaching = false;
			mySqlCommand1.Transaction = null;
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
			panel2.ResumeLayout(false);
			panel2.PerformLayout();
			toolStrip.ResumeLayout(false);
			toolStrip.PerformLayout();
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
		private Label lb_tab;
		private TextBox tb_condition;
		private TextBox tb_tab;
		private Panel panel_filter;
		private ToolTip tip_filter;
		private Panel panel2;
		private MySql.Data.MySqlClient.MySqlCommand mySqlCommand1;
		private ToolStrip toolStrip;
		private ToolStripButton btn_refresh;
	}
}