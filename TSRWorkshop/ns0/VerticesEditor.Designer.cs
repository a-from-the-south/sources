namespace ns0
{
	// Token: 0x02000083 RID: 131
	internal sealed partial class VerticesEditor : global::System.Windows.Forms.Form
	{
		// Token: 0x06000510 RID: 1296 RVA: 0x00050098 File Offset: 0x0004E298
		private void InitializeComponent()
		{
			this.icontainer_0 = new global::System.ComponentModel.Container();
			this.contextMenuStrip1 = new global::System.Windows.Forms.ContextMenuStrip(this.icontainer_0);
			this.fillAllWithThisValueToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.panel2 = new global::System.Windows.Forms.Panel();
			this.okButton = new global::System.Windows.Forms.Button();
			this.cancelButton = new global::System.Windows.Forms.Button();
			this.panel3 = new global::System.Windows.Forms.Panel();
			this.dataGridView1 = new global::System.Windows.Forms.DataGridView();
			this.contextMenuStrip1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.panel3.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.dataGridView1).BeginInit();
			base.SuspendLayout();
			this.contextMenuStrip1.Items.AddRange(new global::System.Windows.Forms.ToolStripItem[]
			{
				this.fillAllWithThisValueToolStripMenuItem
			});
			this.contextMenuStrip1.Name = "contextMenuStrip1";
			this.contextMenuStrip1.Size = new global::System.Drawing.Size(132, 26);
			this.fillAllWithThisValueToolStripMenuItem.Name = "fillAllWithThisValueToolStripMenuItem";
			this.fillAllWithThisValueToolStripMenuItem.Size = new global::System.Drawing.Size(131, 22);
			this.fillAllWithThisValueToolStripMenuItem.Text = "Copy to all";
			this.fillAllWithThisValueToolStripMenuItem.Click += new global::System.EventHandler(this.fillAllWithThisValueToolStripMenuItem_Click);
			this.panel2.Controls.Add(this.okButton);
			this.panel2.Controls.Add(this.cancelButton);
			this.panel2.Dock = global::System.Windows.Forms.DockStyle.Bottom;
			this.panel2.Location = new global::System.Drawing.Point(0, 383);
			this.panel2.Name = "panel2";
			this.panel2.Size = new global::System.Drawing.Size(452, 39);
			this.panel2.TabIndex = 5;
			this.okButton.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Right);
			this.okButton.Location = new global::System.Drawing.Point(285, 9);
			this.okButton.Name = "okButton";
			this.okButton.Size = new global::System.Drawing.Size(77, 23);
			this.okButton.TabIndex = 5;
			this.okButton.Text = "Done";
			this.okButton.UseVisualStyleBackColor = true;
			this.okButton.Click += new global::System.EventHandler(this.okButton_Click);
			this.cancelButton.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Right);
			this.cancelButton.Location = new global::System.Drawing.Point(368, 9);
			this.cancelButton.Name = "cancelButton";
			this.cancelButton.Size = new global::System.Drawing.Size(77, 23);
			this.cancelButton.TabIndex = 4;
			this.cancelButton.Text = "Cancel";
			this.cancelButton.UseVisualStyleBackColor = true;
			this.cancelButton.Click += new global::System.EventHandler(this.cancelButton_Click);
			this.panel3.BackColor = global::System.Drawing.SystemColors.ActiveCaption;
			this.panel3.Controls.Add(this.dataGridView1);
			this.panel3.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.panel3.Location = new global::System.Drawing.Point(0, 0);
			this.panel3.Name = "panel3";
			this.panel3.Size = new global::System.Drawing.Size(452, 383);
			this.panel3.TabIndex = 6;
			this.dataGridView1.ColumnHeadersHeightSizeMode = global::System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.ContextMenuStrip = this.contextMenuStrip1;
			this.dataGridView1.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.dataGridView1.Location = new global::System.Drawing.Point(0, 0);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.Size = new global::System.Drawing.Size(452, 383);
			this.dataGridView1.TabIndex = 1;
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new global::System.Drawing.Size(452, 422);
			base.ControlBox = false;
			base.Controls.Add(this.panel3);
			base.Controls.Add(this.panel2);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.Name = "VerticesEditor";
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Vertices Editor";
			this.contextMenuStrip1.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.panel3.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.dataGridView1).EndInit();
			base.ResumeLayout(false);
		}

		// Token: 0x04000489 RID: 1161
		private global::System.ComponentModel.IContainer icontainer_0;

		// Token: 0x0400048A RID: 1162
		private global::System.Windows.Forms.Panel panel2;

		// Token: 0x0400048B RID: 1163
		private global::System.Windows.Forms.Button okButton;

		// Token: 0x0400048C RID: 1164
		private global::System.Windows.Forms.Button cancelButton;

		// Token: 0x0400048D RID: 1165
		private global::System.Windows.Forms.ContextMenuStrip contextMenuStrip1;

		// Token: 0x0400048E RID: 1166
		private global::System.Windows.Forms.ToolStripMenuItem fillAllWithThisValueToolStripMenuItem;

		// Token: 0x0400048F RID: 1167
		private global::System.Windows.Forms.Panel panel3;

		// Token: 0x04000490 RID: 1168
		private global::System.Windows.Forms.DataGridView dataGridView1;
	}
}
