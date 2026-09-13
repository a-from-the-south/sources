namespace ns6
{
	// Token: 0x020000D9 RID: 217
	internal sealed partial class MaterialEditor : global::System.Windows.Forms.Form
	{
		// Token: 0x06000903 RID: 2307 RVA: 0x0007DA98 File Offset: 0x0007BC98
		private void InitializeComponent()
		{
			global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::ns6.MaterialEditor));
			this.doneBtn = new global::System.Windows.Forms.Button();
			this.cancelBtn = new global::System.Windows.Forms.Button();
			this.panel1 = new global::System.Windows.Forms.Panel();
			this.panel2 = new global::System.Windows.Forms.Panel();
			this.preview = new global::System.Windows.Forms.PictureBox();
			this.groupBox1 = new global::System.Windows.Forms.GroupBox();
			this.shader = new global::System.Windows.Forms.ComboBox();
			this.panel3 = new global::System.Windows.Forms.Panel();
			this.panel4 = new global::System.Windows.Forms.Panel();
			this.groupBox2 = new global::System.Windows.Forms.GroupBox();
			this.panel5 = new global::System.Windows.Forms.Panel();
			this.addLink = new global::System.Windows.Forms.LinkLabel();
			this.groupBox3 = new global::System.Windows.Forms.GroupBox();
			this.nameBox = new global::System.Windows.Forms.TextBox();
			this.materialPropertyGrid = new global::ns4.Class6();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.preview).BeginInit();
			this.groupBox1.SuspendLayout();
			this.panel3.SuspendLayout();
			this.panel4.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.panel5.SuspendLayout();
			this.groupBox3.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.materialPropertyGrid).BeginInit();
			base.SuspendLayout();
			this.doneBtn.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Right);
			this.doneBtn.DialogResult = global::System.Windows.Forms.DialogResult.OK;
			this.doneBtn.Location = new global::System.Drawing.Point(388, 2);
			this.doneBtn.Name = "doneBtn";
			this.doneBtn.Size = new global::System.Drawing.Size(75, 23);
			this.doneBtn.TabIndex = 2;
			this.doneBtn.Text = "Done";
			this.doneBtn.UseVisualStyleBackColor = true;
			this.doneBtn.Click += new global::System.EventHandler(this.doneBtn_Click);
			this.cancelBtn.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Right);
			this.cancelBtn.DialogResult = global::System.Windows.Forms.DialogResult.Cancel;
			this.cancelBtn.Location = new global::System.Drawing.Point(467, 2);
			this.cancelBtn.Name = "cancelBtn";
			this.cancelBtn.Size = new global::System.Drawing.Size(75, 23);
			this.cancelBtn.TabIndex = 3;
			this.cancelBtn.Text = "Cancel";
			this.cancelBtn.UseVisualStyleBackColor = true;
			this.cancelBtn.Click += new global::System.EventHandler(this.cancelBtn_Click);
			this.panel1.Controls.Add(this.doneBtn);
			this.panel1.Controls.Add(this.cancelBtn);
			this.panel1.Dock = global::System.Windows.Forms.DockStyle.Bottom;
			this.panel1.Location = new global::System.Drawing.Point(0, 468);
			this.panel1.Name = "panel1";
			this.panel1.Size = new global::System.Drawing.Size(548, 29);
			this.panel1.TabIndex = 5;
			this.panel2.Controls.Add(this.groupBox3);
			this.panel2.Controls.Add(this.preview);
			this.panel2.Controls.Add(this.groupBox1);
			this.panel2.Dock = global::System.Windows.Forms.DockStyle.Left;
			this.panel2.Location = new global::System.Drawing.Point(0, 0);
			this.panel2.Name = "panel2";
			this.panel2.Padding = new global::System.Windows.Forms.Padding(4, 4, 4, 0);
			this.panel2.Size = new global::System.Drawing.Size(155, 468);
			this.panel2.TabIndex = 6;
			this.preview.BackgroundImage = global::ns17.Class143.checker;
			this.preview.BackgroundImageLayout = global::System.Windows.Forms.ImageLayout.Zoom;
			this.preview.BorderStyle = global::System.Windows.Forms.BorderStyle.FixedSingle;
			this.preview.Location = new global::System.Drawing.Point(13, 110);
			this.preview.Name = "preview";
			this.preview.Size = new global::System.Drawing.Size(128, 128);
			this.preview.TabIndex = 6;
			this.preview.TabStop = false;
			this.groupBox1.Controls.Add(this.shader);
			this.groupBox1.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.groupBox1.Location = new global::System.Drawing.Point(4, 4);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new global::System.Drawing.Size(147, 50);
			this.groupBox1.TabIndex = 5;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Shader";
			this.shader.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.shader.FormattingEnabled = true;
			this.shader.Location = new global::System.Drawing.Point(9, 19);
			this.shader.Name = "shader";
			this.shader.Size = new global::System.Drawing.Size(128, 21);
			this.shader.TabIndex = 5;
			this.shader.SelectedIndexChanged += new global::System.EventHandler(this.shader_SelectedIndexChanged);
			this.panel3.Controls.Add(this.panel4);
			this.panel3.Controls.Add(this.panel2);
			this.panel3.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.panel3.Location = new global::System.Drawing.Point(0, 0);
			this.panel3.Name = "panel3";
			this.panel3.Size = new global::System.Drawing.Size(548, 468);
			this.panel3.TabIndex = 7;
			this.panel4.Controls.Add(this.groupBox2);
			this.panel4.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.panel4.Location = new global::System.Drawing.Point(155, 0);
			this.panel4.Name = "panel4";
			this.panel4.Padding = new global::System.Windows.Forms.Padding(0, 4, 4, 0);
			this.panel4.Size = new global::System.Drawing.Size(393, 468);
			this.panel4.TabIndex = 7;
			this.groupBox2.Controls.Add(this.materialPropertyGrid);
			this.groupBox2.Controls.Add(this.panel5);
			this.groupBox2.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.groupBox2.Location = new global::System.Drawing.Point(0, 4);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new global::System.Drawing.Size(389, 464);
			this.groupBox2.TabIndex = 8;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Properties";
			this.panel5.Controls.Add(this.addLink);
			this.panel5.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.panel5.Location = new global::System.Drawing.Point(3, 16);
			this.panel5.Name = "panel5";
			this.panel5.Size = new global::System.Drawing.Size(383, 26);
			this.panel5.TabIndex = 9;
			this.addLink.AutoSize = true;
			this.addLink.Location = new global::System.Drawing.Point(343, 7);
			this.addLink.Name = "addLink";
			this.addLink.Size = new global::System.Drawing.Size(35, 13);
			this.addLink.TabIndex = 0;
			this.addLink.TabStop = true;
			this.addLink.Text = "+ Add";
			this.addLink.LinkClicked += new global::System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.addLink_LinkClicked);
			this.groupBox3.Controls.Add(this.nameBox);
			this.groupBox3.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.groupBox3.Location = new global::System.Drawing.Point(4, 54);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new global::System.Drawing.Size(147, 50);
			this.groupBox3.TabIndex = 7;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Name";
			this.nameBox.Location = new global::System.Drawing.Point(12, 20);
			this.nameBox.Name = "nameBox";
			this.nameBox.Size = new global::System.Drawing.Size(125, 20);
			this.nameBox.TabIndex = 0;
			this.materialPropertyGrid.AdvancedMode = false;
			this.materialPropertyGrid.BorderStyle = global::System.Windows.Forms.BorderStyle.None;
			this.materialPropertyGrid.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.materialPropertyGrid.DrawingManager = global::VisualHint.SmartPropertyGrid.PropertyGrid.DrawManagers.CustomDrawManager;
			this.materialPropertyGrid.GridColor = global::System.Drawing.Color.FromArgb(199, 221, 167);
			this.materialPropertyGrid.Location = new global::System.Drawing.Point(3, 42);
			this.materialPropertyGrid.Matd = null;
			this.materialPropertyGrid.Name = "materialPropertyGrid";
			this.materialPropertyGrid.ParentRCOL = null;
			this.materialPropertyGrid.PropertyLabelBackColor = global::System.Drawing.SystemColors.Window;
			this.materialPropertyGrid.PropertyValueBackColor = global::System.Drawing.SystemColors.Window;
			this.materialPropertyGrid.SelectedBackColor = global::System.Drawing.Color.FromArgb(74, 88, 43);
			this.materialPropertyGrid.SelectedNotFocusedBackColor = global::System.Drawing.Color.FromArgb(199, 221, 167);
			this.materialPropertyGrid.Size = new global::System.Drawing.Size(383, 419);
			this.materialPropertyGrid.TabIndex = 8;
			this.materialPropertyGrid.Text = "materialPropertyGrid1";
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new global::System.Drawing.Size(548, 497);
			base.Controls.Add(this.panel3);
			base.Controls.Add(this.panel1);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.SizableToolWindow;
			base.Icon = (global::System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
			this.MinimumSize = new global::System.Drawing.Size(366, 264);
			base.Name = "MaterialEditor";
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Material Editor";
			base.SizeChanged += new global::System.EventHandler(this.MaterialEditor_SizeChanged);
			base.LocationChanged += new global::System.EventHandler(this.MaterialEditor_LocationChanged);
			this.panel1.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.preview).EndInit();
			this.groupBox1.ResumeLayout(false);
			this.panel3.ResumeLayout(false);
			this.panel4.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.panel5.ResumeLayout(false);
			this.panel5.PerformLayout();
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			((global::System.ComponentModel.ISupportInitialize)this.materialPropertyGrid).EndInit();
			base.ResumeLayout(false);
		}

		// Token: 0x0400072C RID: 1836
		private global::System.Windows.Forms.Button doneBtn;

		// Token: 0x0400072D RID: 1837
		private global::System.Windows.Forms.Button cancelBtn;

		// Token: 0x0400072E RID: 1838
		private global::System.Windows.Forms.Panel panel1;

		// Token: 0x0400072F RID: 1839
		private global::System.Windows.Forms.Panel panel2;

		// Token: 0x04000730 RID: 1840
		private global::System.Windows.Forms.Panel panel3;

		// Token: 0x04000731 RID: 1841
		private global::System.Windows.Forms.PictureBox preview;

		// Token: 0x04000732 RID: 1842
		private global::System.Windows.Forms.GroupBox groupBox1;

		// Token: 0x04000733 RID: 1843
		private global::System.Windows.Forms.ComboBox shader;

		// Token: 0x04000734 RID: 1844
		private global::System.Windows.Forms.Panel panel4;

		// Token: 0x04000735 RID: 1845
		private global::System.Windows.Forms.GroupBox groupBox2;

		// Token: 0x04000736 RID: 1846
		private global::ns4.Class6 materialPropertyGrid;

		// Token: 0x04000737 RID: 1847
		private global::System.Windows.Forms.Panel panel5;

		// Token: 0x04000738 RID: 1848
		private global::System.Windows.Forms.LinkLabel addLink;

		// Token: 0x04000739 RID: 1849
		private global::System.Windows.Forms.GroupBox groupBox3;

		// Token: 0x0400073A RID: 1850
		private global::System.Windows.Forms.TextBox nameBox;
	}
}
