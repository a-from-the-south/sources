namespace ns19
{
	// Token: 0x020000E1 RID: 225
	internal sealed partial class PickMLOD : global::System.Windows.Forms.Form
	{
		// Token: 0x06000948 RID: 2376 RVA: 0x0008046C File Offset: 0x0007E66C
		private void InitializeComponent()
		{
			global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::ns19.PickMLOD));
			this.panel1 = new global::System.Windows.Forms.Panel();
			this.okButton = new global::System.Windows.Forms.Button();
			this.cancelButton = new global::System.Windows.Forms.Button();
			this.panel2 = new global::System.Windows.Forms.Panel();
			this.treeView1 = new global::System.Windows.Forms.TreeView();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			base.SuspendLayout();
			this.panel1.Controls.Add(this.okButton);
			this.panel1.Controls.Add(this.cancelButton);
			this.panel1.Dock = global::System.Windows.Forms.DockStyle.Bottom;
			this.panel1.Location = new global::System.Drawing.Point(0, 177);
			this.panel1.Name = "panel1";
			this.panel1.Size = new global::System.Drawing.Size(360, 33);
			this.panel1.TabIndex = 0;
			this.okButton.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Right);
			this.okButton.Location = new global::System.Drawing.Point(198, 6);
			this.okButton.Name = "okButton";
			this.okButton.Size = new global::System.Drawing.Size(75, 23);
			this.okButton.TabIndex = 1;
			this.okButton.Text = "OK";
			this.okButton.UseVisualStyleBackColor = true;
			this.okButton.Click += new global::System.EventHandler(this.okButton_Click);
			this.cancelButton.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Right);
			this.cancelButton.Location = new global::System.Drawing.Point(279, 6);
			this.cancelButton.Name = "cancelButton";
			this.cancelButton.Size = new global::System.Drawing.Size(75, 23);
			this.cancelButton.TabIndex = 0;
			this.cancelButton.Text = "Cancel";
			this.cancelButton.UseVisualStyleBackColor = true;
			this.cancelButton.Click += new global::System.EventHandler(this.cancelButton_Click);
			this.panel2.Controls.Add(this.treeView1);
			this.panel2.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.panel2.Location = new global::System.Drawing.Point(0, 0);
			this.panel2.Name = "panel2";
			this.panel2.Size = new global::System.Drawing.Size(360, 177);
			this.panel2.TabIndex = 1;
			this.treeView1.CheckBoxes = true;
			this.treeView1.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.treeView1.Location = new global::System.Drawing.Point(0, 0);
			this.treeView1.Name = "treeView1";
			this.treeView1.Size = new global::System.Drawing.Size(360, 177);
			this.treeView1.TabIndex = 0;
			this.treeView1.AfterCheck += new global::System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterCheck);
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new global::System.Drawing.Size(360, 210);
			base.ControlBox = false;
			base.Controls.Add(this.panel2);
			base.Controls.Add(this.panel1);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.SizableToolWindow;
			base.Icon = (global::System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
			base.Name = "PickMLOD";
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Select MLOD";
			this.panel1.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			base.ResumeLayout(false);
		}

		// Token: 0x04000762 RID: 1890
		private global::System.Windows.Forms.Panel panel1;

		// Token: 0x04000763 RID: 1891
		private global::System.Windows.Forms.Panel panel2;

		// Token: 0x04000764 RID: 1892
		private global::System.Windows.Forms.Button okButton;

		// Token: 0x04000765 RID: 1893
		private global::System.Windows.Forms.Button cancelButton;

		// Token: 0x04000766 RID: 1894
		private global::System.Windows.Forms.TreeView treeView1;
	}
}
