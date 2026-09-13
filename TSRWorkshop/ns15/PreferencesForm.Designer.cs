namespace ns15
{
	// Token: 0x02000136 RID: 310
	internal sealed partial class PreferencesForm : global::System.Windows.Forms.Form
	{
		// Token: 0x06000E5A RID: 3674 RVA: 0x000B4408 File Offset: 0x000B2608
		private void InitializeComponent()
		{
			this.panel3 = new global::System.Windows.Forms.Panel();
			this.cancelButton = new global::System.Windows.Forms.Button();
			this.applyButton = new global::System.Windows.Forms.Button();
			this.panel1 = new global::System.Windows.Forms.Panel();
			this.detailsPanel = new global::System.Windows.Forms.Panel();
			this.treeView1 = new global::System.Windows.Forms.TreeView();
			this.panel3.SuspendLayout();
			this.panel1.SuspendLayout();
			base.SuspendLayout();
			this.panel3.Controls.Add(this.cancelButton);
			this.panel3.Controls.Add(this.applyButton);
			this.panel3.Dock = global::System.Windows.Forms.DockStyle.Bottom;
			this.panel3.Location = new global::System.Drawing.Point(0, 298);
			this.panel3.Name = "panel3";
			this.panel3.Size = new global::System.Drawing.Size(599, 33);
			this.panel3.TabIndex = 2;
			this.cancelButton.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Right);
			this.cancelButton.Location = new global::System.Drawing.Point(518, 5);
			this.cancelButton.Name = "cancelButton";
			this.cancelButton.Size = new global::System.Drawing.Size(75, 23);
			this.cancelButton.TabIndex = 1;
			this.cancelButton.Text = "Cancel";
			this.cancelButton.UseVisualStyleBackColor = true;
			this.cancelButton.Click += new global::System.EventHandler(this.cancelButton_Click);
			this.applyButton.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Right);
			this.applyButton.Location = new global::System.Drawing.Point(440, 5);
			this.applyButton.Name = "applyButton";
			this.applyButton.Size = new global::System.Drawing.Size(75, 23);
			this.applyButton.TabIndex = 0;
			this.applyButton.Text = "Apply";
			this.applyButton.UseVisualStyleBackColor = true;
			this.applyButton.Click += new global::System.EventHandler(this.applyButton_Click);
			this.panel1.Controls.Add(this.treeView1);
			this.panel1.Dock = global::System.Windows.Forms.DockStyle.Left;
			this.panel1.Location = new global::System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Padding = new global::System.Windows.Forms.Padding(4);
			this.panel1.Size = new global::System.Drawing.Size(200, 298);
			this.panel1.TabIndex = 3;
			this.detailsPanel.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.detailsPanel.Location = new global::System.Drawing.Point(200, 0);
			this.detailsPanel.Name = "detailsPanel";
			this.detailsPanel.Size = new global::System.Drawing.Size(399, 298);
			this.detailsPanel.TabIndex = 4;
			this.treeView1.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.treeView1.Location = new global::System.Drawing.Point(4, 4);
			this.treeView1.Name = "treeView1";
			this.treeView1.Size = new global::System.Drawing.Size(192, 290);
			this.treeView1.TabIndex = 0;
			this.treeView1.AfterSelect += new global::System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new global::System.Drawing.Size(599, 331);
			base.ControlBox = false;
			base.Controls.Add(this.detailsPanel);
			base.Controls.Add(this.panel1);
			base.Controls.Add(this.panel3);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedSingle;
			base.Name = "PreferencesForm";
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Preferences";
			base.Load += new global::System.EventHandler(this.PreferencesForm_Load);
			this.panel3.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			base.ResumeLayout(false);
		}

		// Token: 0x04000B0A RID: 2826
		private global::System.Windows.Forms.Panel panel3;

		// Token: 0x04000B0B RID: 2827
		private global::System.Windows.Forms.Panel panel1;

		// Token: 0x04000B0C RID: 2828
		private global::System.Windows.Forms.Panel detailsPanel;

		// Token: 0x04000B0D RID: 2829
		private global::System.Windows.Forms.Button cancelButton;

		// Token: 0x04000B0E RID: 2830
		private global::System.Windows.Forms.Button applyButton;

		// Token: 0x04000B0F RID: 2831
		private global::System.Windows.Forms.TreeView treeView1;
	}
}
