namespace ns18
{
	// Token: 0x020000C9 RID: 201
	internal sealed partial class BoneAssigmentEditor : global::System.Windows.Forms.Form
	{
		// Token: 0x0600087C RID: 2172 RVA: 0x00078AFC File Offset: 0x00076CFC
		private void InitializeComponent()
		{
			this.panel1 = new global::System.Windows.Forms.Panel();
			this.cancelButton = new global::System.Windows.Forms.Button();
			this.okButton = new global::System.Windows.Forms.Button();
			this.panel2 = new global::System.Windows.Forms.Panel();
			this.splitContainer1 = new global::System.Windows.Forms.SplitContainer();
			this.dataGridView1 = new global::System.Windows.Forms.DataGridView();
			this.VertexNum = new global::System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Bone1 = new global::System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Weight1 = new global::System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Bone2 = new global::System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Weight2 = new global::System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Bone3 = new global::System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Weight3 = new global::System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Bone4 = new global::System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Weight4 = new global::System.Windows.Forms.DataGridViewTextBoxColumn();
			this.panel3 = new global::System.Windows.Forms.Panel();
			this.button2 = new global::System.Windows.Forms.Button();
			this.listBox1 = new global::System.Windows.Forms.ListBox();
			this.button1 = new global::System.Windows.Forms.Button();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.dataGridView1).BeginInit();
			this.panel3.SuspendLayout();
			base.SuspendLayout();
			this.panel1.Controls.Add(this.cancelButton);
			this.panel1.Controls.Add(this.okButton);
			this.panel1.Dock = global::System.Windows.Forms.DockStyle.Bottom;
			this.panel1.Location = new global::System.Drawing.Point(0, 487);
			this.panel1.Name = "panel1";
			this.panel1.Size = new global::System.Drawing.Size(883, 33);
			this.panel1.TabIndex = 0;
			this.cancelButton.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Right);
			this.cancelButton.Location = new global::System.Drawing.Point(800, 3);
			this.cancelButton.Name = "cancelButton";
			this.cancelButton.Size = new global::System.Drawing.Size(75, 23);
			this.cancelButton.TabIndex = 1;
			this.cancelButton.Text = "Cancel";
			this.cancelButton.UseVisualStyleBackColor = true;
			this.cancelButton.Click += new global::System.EventHandler(this.cancelButton_Click);
			this.okButton.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Right);
			this.okButton.Location = new global::System.Drawing.Point(719, 3);
			this.okButton.Name = "okButton";
			this.okButton.Size = new global::System.Drawing.Size(75, 23);
			this.okButton.TabIndex = 0;
			this.okButton.Text = "Done";
			this.okButton.UseVisualStyleBackColor = true;
			this.okButton.Click += new global::System.EventHandler(this.okButton_Click);
			this.panel2.Controls.Add(this.splitContainer1);
			this.panel2.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.panel2.Location = new global::System.Drawing.Point(0, 0);
			this.panel2.Name = "panel2";
			this.panel2.Size = new global::System.Drawing.Size(883, 487);
			this.panel2.TabIndex = 1;
			this.splitContainer1.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.Location = new global::System.Drawing.Point(0, 0);
			this.splitContainer1.Name = "splitContainer1";
			this.splitContainer1.Panel1.Controls.Add(this.dataGridView1);
			this.splitContainer1.Panel1.Margin = new global::System.Windows.Forms.Padding(0, 5, 5, 5);
			this.splitContainer1.Panel1.Padding = new global::System.Windows.Forms.Padding(8);
			this.splitContainer1.Panel2.Controls.Add(this.panel3);
			this.splitContainer1.Panel2.Padding = new global::System.Windows.Forms.Padding(8);
			this.splitContainer1.Size = new global::System.Drawing.Size(883, 487);
			this.splitContainer1.SplitterDistance = 559;
			this.splitContainer1.TabIndex = 0;
			this.dataGridView1.ColumnHeadersHeightSizeMode = global::System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.Columns.AddRange(new global::System.Windows.Forms.DataGridViewColumn[]
			{
				this.VertexNum,
				this.Bone1,
				this.Weight1,
				this.Bone2,
				this.Weight2,
				this.Bone3,
				this.Weight3,
				this.Bone4,
				this.Weight4
			});
			this.dataGridView1.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.dataGridView1.Location = new global::System.Drawing.Point(8, 8);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.Size = new global::System.Drawing.Size(543, 471);
			this.dataGridView1.TabIndex = 0;
			this.dataGridView1.ColumnHeaderMouseClick += new global::System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_ColumnHeaderMouseClick);
			this.dataGridView1.SelectionChanged += new global::System.EventHandler(this.dataGridView1_SelectionChanged);
			this.VertexNum.DataPropertyName = "VertexNum";
			this.VertexNum.HeaderText = "Vertex #";
			this.VertexNum.Name = "VertexNum";
			this.VertexNum.ReadOnly = true;
			this.Bone1.DataPropertyName = "Bone1";
			this.Bone1.HeaderText = "Bone 1";
			this.Bone1.Name = "Bone1";
			this.Weight1.DataPropertyName = "Weight1";
			this.Weight1.HeaderText = "Weight";
			this.Weight1.Name = "Weight1";
			this.Bone2.DataPropertyName = "Bone2";
			this.Bone2.HeaderText = "Bone 2";
			this.Bone2.Name = "Bone2";
			this.Weight2.DataPropertyName = "Weight2";
			this.Weight2.HeaderText = "Wieght";
			this.Weight2.Name = "Weight2";
			this.Bone3.DataPropertyName = "Bone3";
			this.Bone3.HeaderText = "Bone 3";
			this.Bone3.Name = "Bone3";
			this.Weight3.DataPropertyName = "Weight3";
			this.Weight3.HeaderText = "Weight";
			this.Weight3.Name = "Weight3";
			this.Bone4.DataPropertyName = "Bone4";
			this.Bone4.HeaderText = "Bone 4";
			this.Bone4.Name = "Bone4";
			this.Weight4.DataPropertyName = "Weight4";
			this.Weight4.HeaderText = "Weight";
			this.Weight4.Name = "Weight4";
			this.panel3.Controls.Add(this.button2);
			this.panel3.Controls.Add(this.button1);
			this.panel3.Controls.Add(this.listBox1);
			this.panel3.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.panel3.Location = new global::System.Drawing.Point(8, 8);
			this.panel3.Margin = new global::System.Windows.Forms.Padding(0);
			this.panel3.Name = "panel3";
			this.panel3.Size = new global::System.Drawing.Size(304, 471);
			this.panel3.TabIndex = 4;
			this.button2.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.button2.Location = new global::System.Drawing.Point(0, 274);
			this.button2.Name = "button2";
			this.button2.Size = new global::System.Drawing.Size(304, 23);
			this.button2.TabIndex = 2;
			this.button2.Text = "Set zero weight";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new global::System.EventHandler(this.button2_Click);
			this.listBox1.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.listBox1.FormattingEnabled = true;
			this.listBox1.Location = new global::System.Drawing.Point(0, 0);
			this.listBox1.Name = "listBox1";
			this.listBox1.Size = new global::System.Drawing.Size(304, 251);
			this.listBox1.TabIndex = 0;
			this.button1.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.button1.Location = new global::System.Drawing.Point(0, 251);
			this.button1.Name = "button1";
			this.button1.Size = new global::System.Drawing.Size(304, 23);
			this.button1.TabIndex = 1;
			this.button1.Text = "Unassign";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new global::System.EventHandler(this.button1_Click);
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new global::System.Drawing.Size(883, 520);
			base.Controls.Add(this.panel2);
			base.Controls.Add(this.panel1);
			base.Name = "BoneAssigmentEditor";
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Bone Assigment Editor";
			this.panel1.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			this.splitContainer1.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.dataGridView1).EndInit();
			this.panel3.ResumeLayout(false);
			base.ResumeLayout(false);
		}

		// Token: 0x040006BC RID: 1724
		private global::System.Windows.Forms.Panel panel1;

		// Token: 0x040006BD RID: 1725
		private global::System.Windows.Forms.Button cancelButton;

		// Token: 0x040006BE RID: 1726
		private global::System.Windows.Forms.Button okButton;

		// Token: 0x040006BF RID: 1727
		private global::System.Windows.Forms.Panel panel2;

		// Token: 0x040006C0 RID: 1728
		private global::System.Windows.Forms.SplitContainer splitContainer1;

		// Token: 0x040006C1 RID: 1729
		private global::System.Windows.Forms.DataGridView dataGridView1;

		// Token: 0x040006C2 RID: 1730
		private global::System.Windows.Forms.Panel panel3;

		// Token: 0x040006C3 RID: 1731
		private global::System.Windows.Forms.ListBox listBox1;

		// Token: 0x040006C4 RID: 1732
		private global::System.Windows.Forms.DataGridViewTextBoxColumn VertexNum;

		// Token: 0x040006C5 RID: 1733
		private global::System.Windows.Forms.DataGridViewTextBoxColumn Bone1;

		// Token: 0x040006C6 RID: 1734
		private global::System.Windows.Forms.DataGridViewTextBoxColumn Weight1;

		// Token: 0x040006C7 RID: 1735
		private global::System.Windows.Forms.DataGridViewTextBoxColumn Bone2;

		// Token: 0x040006C8 RID: 1736
		private global::System.Windows.Forms.DataGridViewTextBoxColumn Weight2;

		// Token: 0x040006C9 RID: 1737
		private global::System.Windows.Forms.DataGridViewTextBoxColumn Bone3;

		// Token: 0x040006CA RID: 1738
		private global::System.Windows.Forms.DataGridViewTextBoxColumn Weight3;

		// Token: 0x040006CB RID: 1739
		private global::System.Windows.Forms.DataGridViewTextBoxColumn Bone4;

		// Token: 0x040006CC RID: 1740
		private global::System.Windows.Forms.DataGridViewTextBoxColumn Weight4;

		// Token: 0x040006CD RID: 1741
		private global::System.Windows.Forms.Button button2;

		// Token: 0x040006CE RID: 1742
		private global::System.Windows.Forms.Button button1;
	}
}
