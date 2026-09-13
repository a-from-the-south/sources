namespace Sims3Workshop.Dialogs
{
	// Token: 0x020000D6 RID: 214
	public sealed partial class JazzLoader : global::System.Windows.Forms.Form
	{
		// Token: 0x060008EB RID: 2283 RVA: 0x0007C084 File Offset: 0x0007A284
		private void InitializeComponent()
		{
			this.panel1 = new global::System.Windows.Forms.Panel();
			this.loadButton = new global::System.Windows.Forms.Button();
			this.closeButton = new global::System.Windows.Forms.Button();
			this.panel2 = new global::System.Windows.Forms.Panel();
			this.button1 = new global::System.Windows.Forms.Button();
			this.comboBox1 = new global::System.Windows.Forms.ComboBox();
			this.panel3 = new global::System.Windows.Forms.Panel();
			this.listView1 = new global::System.Windows.Forms.ListView();
			this.columnHeader_0 = new global::System.Windows.Forms.ColumnHeader();
			this.columnHeader_1 = new global::System.Windows.Forms.ColumnHeader();
			this.columnHeader_2 = new global::System.Windows.Forms.ColumnHeader();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.panel3.SuspendLayout();
			base.SuspendLayout();
			this.panel1.Controls.Add(this.loadButton);
			this.panel1.Controls.Add(this.closeButton);
			this.panel1.Dock = global::System.Windows.Forms.DockStyle.Bottom;
			this.panel1.Location = new global::System.Drawing.Point(0, 376);
			this.panel1.Name = "panel1";
			this.panel1.Padding = new global::System.Windows.Forms.Padding(4);
			this.panel1.Size = new global::System.Drawing.Size(604, 34);
			this.panel1.TabIndex = 0;
			this.loadButton.Dock = global::System.Windows.Forms.DockStyle.Right;
			this.loadButton.Location = new global::System.Drawing.Point(462, 4);
			this.loadButton.Name = "loadButton";
			this.loadButton.Size = new global::System.Drawing.Size(69, 26);
			this.loadButton.TabIndex = 0;
			this.loadButton.Text = "Load";
			this.loadButton.UseVisualStyleBackColor = true;
			this.loadButton.Click += new global::System.EventHandler(this.loadButton_Click);
			this.closeButton.Dock = global::System.Windows.Forms.DockStyle.Right;
			this.closeButton.Location = new global::System.Drawing.Point(531, 4);
			this.closeButton.Name = "closeButton";
			this.closeButton.Size = new global::System.Drawing.Size(69, 26);
			this.closeButton.TabIndex = 1;
			this.closeButton.Text = "Close";
			this.closeButton.UseVisualStyleBackColor = true;
			this.closeButton.Click += new global::System.EventHandler(this.closeButton_Click);
			this.panel2.Controls.Add(this.button1);
			this.panel2.Controls.Add(this.comboBox1);
			this.panel2.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.panel2.Location = new global::System.Drawing.Point(0, 0);
			this.panel2.Name = "panel2";
			this.panel2.Size = new global::System.Drawing.Size(604, 35);
			this.panel2.TabIndex = 2;
			this.button1.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Right);
			this.button1.Location = new global::System.Drawing.Point(548, 7);
			this.button1.Name = "button1";
			this.button1.Size = new global::System.Drawing.Size(52, 23);
			this.button1.TabIndex = 1;
			this.button1.Text = "Find";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new global::System.EventHandler(this.button1_Click);
			this.comboBox1.AutoCompleteMode = global::System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.comboBox1.FormattingEnabled = true;
			this.comboBox1.Location = new global::System.Drawing.Point(6, 8);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new global::System.Drawing.Size(538, 21);
			this.comboBox1.TabIndex = 0;
			this.comboBox1.SelectionChangeCommitted += new global::System.EventHandler(this.comboBox1_SelectionChangeCommitted);
			this.comboBox1.SelectedIndexChanged += new global::System.EventHandler(this.comboBox1_SelectedIndexChanged);
			this.comboBox1.KeyUp += new global::System.Windows.Forms.KeyEventHandler(this.comboBox1_KeyUp);
			this.comboBox1.TextChanged += new global::System.EventHandler(this.comboBox1_TextChanged);
			this.panel3.Controls.Add(this.listView1);
			this.panel3.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.panel3.Location = new global::System.Drawing.Point(0, 35);
			this.panel3.Name = "panel3";
			this.panel3.Size = new global::System.Drawing.Size(604, 341);
			this.panel3.TabIndex = 3;
			this.listView1.Columns.AddRange(new global::System.Windows.Forms.ColumnHeader[]
			{
				this.columnHeader_0,
				this.columnHeader_1,
				this.columnHeader_2
			});
			this.listView1.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.listView1.FullRowSelect = true;
			this.listView1.GridLines = true;
			this.listView1.Location = new global::System.Drawing.Point(0, 0);
			this.listView1.Name = "listView1";
			this.listView1.Size = new global::System.Drawing.Size(604, 341);
			this.listView1.TabIndex = 2;
			this.listView1.UseCompatibleStateImageBehavior = false;
			this.listView1.View = global::System.Windows.Forms.View.Details;
			this.listView1.DoubleClick += new global::System.EventHandler(this.listView1_DoubleClick);
			this.listView1.ColumnClick += new global::System.Windows.Forms.ColumnClickEventHandler(this.listView1_ColumnClick);
			this.columnHeader_0.Text = "Jazz script name";
			this.columnHeader_0.Width = 235;
			this.columnHeader_1.Text = "clip name";
			this.columnHeader_1.Width = 254;
			this.columnHeader_2.Text = "Actor";
			this.columnHeader_2.Width = 92;
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new global::System.Drawing.Size(604, 410);
			base.Controls.Add(this.panel3);
			base.Controls.Add(this.panel2);
			base.Controls.Add(this.panel1);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.SizableToolWindow;
			base.Name = "JazzLoader";
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Animation Loader";
			base.Load += new global::System.EventHandler(this.JazzLoader_Load);
			base.Shown += new global::System.EventHandler(this.JazzLoader_Shown);
			this.panel1.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.panel3.ResumeLayout(false);
			base.ResumeLayout(false);
		}

		// Token: 0x04000716 RID: 1814
		private global::System.Windows.Forms.Panel panel1;

		// Token: 0x04000717 RID: 1815
		private global::System.Windows.Forms.Button closeButton;

		// Token: 0x04000718 RID: 1816
		private global::System.Windows.Forms.Button loadButton;

		// Token: 0x04000719 RID: 1817
		private global::System.Windows.Forms.Panel panel2;

		// Token: 0x0400071A RID: 1818
		private global::System.Windows.Forms.Panel panel3;

		// Token: 0x0400071B RID: 1819
		private global::System.Windows.Forms.ListView listView1;

		// Token: 0x0400071C RID: 1820
		private global::System.Windows.Forms.ColumnHeader columnHeader_0;

		// Token: 0x0400071D RID: 1821
		private global::System.Windows.Forms.ColumnHeader columnHeader_1;

		// Token: 0x0400071E RID: 1822
		private global::System.Windows.Forms.ColumnHeader columnHeader_2;

		// Token: 0x0400071F RID: 1823
		private global::System.Windows.Forms.ComboBox comboBox1;

		// Token: 0x04000720 RID: 1824
		private global::System.Windows.Forms.Button button1;
	}
}
