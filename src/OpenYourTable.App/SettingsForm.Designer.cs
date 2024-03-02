namespace OpenYourTable.App
{
	partial class SettingsForm
	{
		/// <summary>
		///  Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///  Clean up any resources being used.
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
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
			panel2 = new Panel();
			cb_type = new ComboBox();
			label6 = new Label();
			btn_open = new Button();
			tb_schema = new TextBox();
			label5 = new Label();
			tb_password = new TextBox();
			label4 = new Label();
			tb_id = new TextBox();
			label3 = new Label();
			tb_port = new TextBox();
			label2 = new Label();
			tb_host = new TextBox();
			label1 = new Label();
			panel2.SuspendLayout();
			SuspendLayout();
			// 
			// panel2
			// 
			panel2.BackColor = Color.White;
			panel2.BorderStyle = BorderStyle.FixedSingle;
			panel2.Controls.Add(cb_type);
			panel2.Controls.Add(label6);
			panel2.Controls.Add(btn_open);
			panel2.Controls.Add(tb_schema);
			panel2.Controls.Add(label5);
			panel2.Controls.Add(tb_password);
			panel2.Controls.Add(label4);
			panel2.Controls.Add(tb_id);
			panel2.Controls.Add(label3);
			panel2.Controls.Add(tb_port);
			panel2.Controls.Add(label2);
			panel2.Controls.Add(tb_host);
			panel2.Controls.Add(label1);
			panel2.Font = new Font("Impact", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
			panel2.ForeColor = Color.DodgerBlue;
			panel2.Location = new Point(8, 12);
			panel2.Name = "panel2";
			panel2.Size = new Size(780, 426);
			panel2.TabIndex = 1;
			// 
			// cb_type
			// 
			cb_type.AccessibleName = "Database Type";
			cb_type.BackColor = Color.White;
			cb_type.Font = new Font("Calibri", 12F);
			cb_type.ForeColor = Color.DodgerBlue;
			cb_type.FormattingEnabled = true;
			cb_type.Location = new Point(202, 174);
			cb_type.Name = "cb_type";
			cb_type.Size = new Size(188, 27);
			cb_type.TabIndex = 12;
			cb_type.Tag = "";
			cb_type.SelectedIndexChanged += cb_type_SelectedIndexChanged;
			cb_type.Click += cb_type_Click;
			// 
			// label6
			// 
			label6.AutoSize = true;
			label6.FlatStyle = FlatStyle.Flat;
			label6.Font = new Font("Imprint MT Shadow", 15F, FontStyle.Bold);
			label6.Location = new Point(125, 174);
			label6.Name = "label6";
			label6.Size = new Size(59, 24);
			label6.TabIndex = 11;
			label6.Text = "Type";
			// 
			// btn_open
			// 
			btn_open.BackColor = Color.Azure;
			btn_open.FlatAppearance.BorderSize = 5;
			btn_open.FlatStyle = FlatStyle.Flat;
			btn_open.Font = new Font("Impact", 60F, FontStyle.Regular, GraphicsUnit.Point, 0);
			btn_open.ForeColor = SystemColors.MenuHighlight;
			btn_open.Location = new Point(81, 245);
			btn_open.Name = "btn_open";
			btn_open.Size = new Size(619, 140);
			btn_open.TabIndex = 10;
			btn_open.Text = "O P E N";
			btn_open.UseVisualStyleBackColor = false;
			btn_open.Click += btn_open_Click;
			// 
			// tb_schema
			// 
			tb_schema.AccessibleName = "Schema";
			tb_schema.Font = new Font("Calibri", 12F);
			tb_schema.ForeColor = Color.DodgerBlue;
			tb_schema.Location = new Point(511, 173);
			tb_schema.Name = "tb_schema";
			tb_schema.Size = new Size(189, 27);
			tb_schema.TabIndex = 9;
			tb_schema.Tag = "";
			// 
			// label5
			// 
			label5.AutoSize = true;
			label5.FlatStyle = FlatStyle.Flat;
			label5.Font = new Font("Imprint MT Shadow", 15F, FontStyle.Bold);
			label5.Location = new Point(409, 174);
			label5.Name = "label5";
			label5.Size = new Size(84, 24);
			label5.TabIndex = 8;
			label5.Text = "Schema";
			// 
			// tb_password
			// 
			tb_password.AccessibleName = "Password";
			tb_password.Font = new Font("Calibri", 12F);
			tb_password.ForeColor = Color.DodgerBlue;
			tb_password.Location = new Point(202, 127);
			tb_password.Name = "tb_password";
			tb_password.PasswordChar = '*';
			tb_password.Size = new Size(498, 27);
			tb_password.TabIndex = 7;
			// 
			// label4
			// 
			label4.AutoSize = true;
			label4.FlatStyle = FlatStyle.Flat;
			label4.Font = new Font("Imprint MT Shadow", 15F, FontStyle.Bold);
			label4.Location = new Point(83, 128);
			label4.Name = "label4";
			label4.Size = new Size(101, 24);
			label4.TabIndex = 6;
			label4.Text = "Password";
			// 
			// tb_id
			// 
			tb_id.AccessibleName = "ID";
			tb_id.Font = new Font("Calibri", 12F);
			tb_id.ForeColor = Color.DodgerBlue;
			tb_id.Location = new Point(202, 81);
			tb_id.Name = "tb_id";
			tb_id.Size = new Size(498, 27);
			tb_id.TabIndex = 5;
			// 
			// label3
			// 
			label3.AutoSize = true;
			label3.FlatStyle = FlatStyle.Flat;
			label3.Font = new Font("Imprint MT Shadow", 15F, FontStyle.Bold);
			label3.Location = new Point(147, 82);
			label3.Name = "label3";
			label3.Size = new Size(37, 24);
			label3.TabIndex = 4;
			label3.Text = "ID";
			// 
			// tb_port
			// 
			tb_port.AccessibleName = "Port";
			tb_port.Font = new Font("Calibri", 12F);
			tb_port.ForeColor = Color.DodgerBlue;
			tb_port.Location = new Point(596, 35);
			tb_port.Name = "tb_port";
			tb_port.Size = new Size(104, 27);
			tb_port.TabIndex = 3;
			tb_port.Tag = "";
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.FlatStyle = FlatStyle.Flat;
			label2.Font = new Font("Imprint MT Shadow", 15F, FontStyle.Bold);
			label2.Location = new Point(524, 36);
			label2.Name = "label2";
			label2.Size = new Size(52, 24);
			label2.TabIndex = 2;
			label2.Text = "Port";
			// 
			// tb_host
			// 
			tb_host.AccessibleName = "Host";
			tb_host.Font = new Font("Calibri", 12F);
			tb_host.ForeColor = Color.DodgerBlue;
			tb_host.Location = new Point(202, 35);
			tb_host.Name = "tb_host";
			tb_host.Size = new Size(300, 27);
			tb_host.TabIndex = 1;
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.FlatStyle = FlatStyle.Flat;
			label1.Font = new Font("Imprint MT Shadow", 15F, FontStyle.Bold);
			label1.Location = new Point(129, 36);
			label1.Name = "label1";
			label1.Size = new Size(55, 24);
			label1.TabIndex = 0;
			label1.Text = "Host";
			// 
			// SettingsForm
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			BackColor = Color.White;
			ClientSize = new Size(800, 450);
			Controls.Add(panel2);
			ForeColor = SystemColors.WindowText;
			FormBorderStyle = FormBorderStyle.FixedSingle;
			Icon = (Icon)resources.GetObject("$this.Icon");
			Name = "SettingsForm";
			StartPosition = FormStartPosition.CenterScreen;
			Text = "Open Your Table";
			Load += SettingsForm_Load;
			panel2.ResumeLayout(false);
			panel2.PerformLayout();
			ResumeLayout(false);
		}

		#endregion
		private Panel panel2;
		private Label label1;
		private TextBox tb_host;
		private TextBox tb_port;
		private Label label2;
		private TextBox tb_schema;
		private Label label5;
		private TextBox tb_password;
		private Label label4;
		private TextBox tb_id;
		private Label label3;
		private Button btn_open;
		private ComboBox cb_type;
		private Label label6;
	}
}
