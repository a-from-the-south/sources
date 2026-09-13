namespace ns7
{
	// Token: 0x0200005B RID: 91
	internal sealed partial class PropEditor : global::System.Windows.Forms.Form
	{
		// Token: 0x06000395 RID: 917 RVA: 0x000409FC File Offset: 0x0003EBFC
		private void InitializeComponent()
		{
			this.icontainer_0 = new global::System.ComponentModel.Container();
			global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::ns7.PropEditor));
			this.doneBtn = new global::System.Windows.Forms.Button();
			this.cancelBtn = new global::System.Windows.Forms.Button();
			this.importBtn = new global::System.Windows.Forms.Button();
			this.exportBtn = new global::System.Windows.Forms.Button();
			this.panel1 = new global::System.Windows.Forms.Panel();
			this.panel6 = new global::System.Windows.Forms.Panel();
			this.pictureBox1 = new global::System.Windows.Forms.PictureBox();
			this.liveUpdate = new global::System.Windows.Forms.CheckBox();
			this.panel2 = new global::System.Windows.Forms.Panel();
			this.panel3 = new global::System.Windows.Forms.Panel();
			this.panel4 = new global::System.Windows.Forms.Panel();
			this.statusStrip = new global::System.Windows.Forms.StatusStrip();
			this.statusLabel = new global::System.Windows.Forms.ToolStripStatusLabel();
			this.panel7 = new global::System.Windows.Forms.Panel();
			this.panel8 = new global::System.Windows.Forms.Panel();
			this.complatePropertyGrid = new global::ns0.Class5();
			this.contextMenuStrip1 = new global::System.Windows.Forms.ContextMenuStrip(this.icontainer_0);
			this.removeStep = new global::System.Windows.Forms.ToolStripMenuItem();
			this.visualTipProvider_0 = new global::Skybound.VisualTips.VisualTipProvider(this.icontainer_0);
			this.panel1.SuspendLayout();
			this.panel6.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox1).BeginInit();
			this.panel2.SuspendLayout();
			this.panel3.SuspendLayout();
			this.panel4.SuspendLayout();
			this.statusStrip.SuspendLayout();
			this.panel7.SuspendLayout();
			this.panel8.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.complatePropertyGrid).BeginInit();
			this.contextMenuStrip1.SuspendLayout();
			base.SuspendLayout();
			this.doneBtn.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Right);
			this.doneBtn.DialogResult = global::System.Windows.Forms.DialogResult.Cancel;
			this.doneBtn.Location = new global::System.Drawing.Point(407, 3);
			this.doneBtn.Name = "doneBtn";
			this.doneBtn.Size = new global::System.Drawing.Size(75, 23);
			this.doneBtn.TabIndex = 2;
			this.doneBtn.Text = "Done";
			this.doneBtn.UseVisualStyleBackColor = true;
			this.doneBtn.Click += new global::System.EventHandler(this.doneBtn_Click);
			this.cancelBtn.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Right);
			this.cancelBtn.DialogResult = global::System.Windows.Forms.DialogResult.Cancel;
			this.cancelBtn.Location = new global::System.Drawing.Point(488, 3);
			this.cancelBtn.Name = "cancelBtn";
			this.cancelBtn.Size = new global::System.Drawing.Size(75, 23);
			this.cancelBtn.TabIndex = 3;
			this.cancelBtn.Text = "Cancel";
			this.cancelBtn.UseVisualStyleBackColor = true;
			this.cancelBtn.Click += new global::System.EventHandler(this.cancelBtn_Click);
			this.importBtn.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 8.5f);
			this.importBtn.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("importBtn.Image");
			this.importBtn.Location = new global::System.Drawing.Point(229, 5);
			this.importBtn.Name = "importBtn";
			this.importBtn.Size = new global::System.Drawing.Size(36, 26);
			this.importBtn.TabIndex = 5;
			this.importBtn.TextImageRelation = global::System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.importBtn.UseVisualStyleBackColor = true;
			this.importBtn.Click += new global::System.EventHandler(this.importBtn_Click);
			this.exportBtn.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 8.5f);
			this.exportBtn.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("exportBtn.Image");
			this.exportBtn.Location = new global::System.Drawing.Point(187, 5);
			this.exportBtn.Name = "exportBtn";
			this.exportBtn.Size = new global::System.Drawing.Size(36, 26);
			this.exportBtn.TabIndex = 6;
			this.exportBtn.TextImageRelation = global::System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.exportBtn.UseVisualStyleBackColor = true;
			this.exportBtn.Click += new global::System.EventHandler(this.exportBtn_Click);
			this.panel1.Controls.Add(this.panel6);
			this.panel1.Controls.Add(this.liveUpdate);
			this.panel1.Controls.Add(this.panel2);
			this.panel1.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new global::System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new global::System.Drawing.Size(279, 333);
			this.panel1.TabIndex = 7;
			this.panel6.BackColor = global::System.Drawing.Color.Black;
			this.panel6.BorderStyle = global::System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel6.Controls.Add(this.pictureBox1);
			this.panel6.Location = new global::System.Drawing.Point(9, 43);
			this.panel6.Name = "panel6";
			this.panel6.Size = new global::System.Drawing.Size(256, 256);
			this.panel6.TabIndex = 5;
			this.pictureBox1.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.pictureBox1.Location = new global::System.Drawing.Point(0, 0);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new global::System.Drawing.Size(254, 254);
			this.pictureBox1.TabIndex = 0;
			this.pictureBox1.TabStop = false;
			this.liveUpdate.AutoSize = true;
			this.liveUpdate.Location = new global::System.Drawing.Point(9, 306);
			this.liveUpdate.Name = "liveUpdate";
			this.liveUpdate.Size = new global::System.Drawing.Size(78, 17);
			this.liveUpdate.TabIndex = 3;
			this.liveUpdate.Text = "3d preview";
			this.liveUpdate.UseVisualStyleBackColor = true;
			this.liveUpdate.Visible = false;
			this.liveUpdate.CheckedChanged += new global::System.EventHandler(this.liveUpdate_CheckedChanged);
			this.panel2.Controls.Add(this.importBtn);
			this.panel2.Controls.Add(this.exportBtn);
			this.panel2.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.panel2.Location = new global::System.Drawing.Point(0, 0);
			this.panel2.Name = "panel2";
			this.panel2.Size = new global::System.Drawing.Size(279, 38);
			this.panel2.TabIndex = 0;
			this.panel3.Controls.Add(this.doneBtn);
			this.panel3.Controls.Add(this.cancelBtn);
			this.panel3.Dock = global::System.Windows.Forms.DockStyle.Bottom;
			this.panel3.Location = new global::System.Drawing.Point(0, 333);
			this.panel3.Name = "panel3";
			this.panel3.Size = new global::System.Drawing.Size(568, 30);
			this.panel3.TabIndex = 1;
			this.panel4.Controls.Add(this.panel1);
			this.panel4.Dock = global::System.Windows.Forms.DockStyle.Left;
			this.panel4.Location = new global::System.Drawing.Point(0, 0);
			this.panel4.Name = "panel4";
			this.panel4.Size = new global::System.Drawing.Size(279, 333);
			this.panel4.TabIndex = 8;
			this.statusStrip.Items.AddRange(new global::System.Windows.Forms.ToolStripItem[]
			{
				this.statusLabel
			});
			this.statusStrip.Location = new global::System.Drawing.Point(0, 363);
			this.statusStrip.Name = "statusStrip";
			this.statusStrip.Size = new global::System.Drawing.Size(568, 22);
			this.statusStrip.TabIndex = 10;
			this.statusStrip.Text = "statusStrip1";
			this.statusLabel.Name = "statusLabel";
			this.statusLabel.Size = new global::System.Drawing.Size(97, 17);
			this.statusLabel.Text = "No preset loaded";
			this.panel7.Controls.Add(this.panel8);
			this.panel7.Controls.Add(this.panel3);
			this.panel7.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.panel7.Location = new global::System.Drawing.Point(0, 0);
			this.panel7.Name = "panel7";
			this.panel7.Size = new global::System.Drawing.Size(568, 363);
			this.panel7.TabIndex = 11;
			this.panel8.Controls.Add(this.complatePropertyGrid);
			this.panel8.Controls.Add(this.panel4);
			this.panel8.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.panel8.Location = new global::System.Drawing.Point(0, 0);
			this.panel8.Name = "panel8";
			this.panel8.Size = new global::System.Drawing.Size(568, 333);
			this.panel8.TabIndex = 0;
			this.complatePropertyGrid.AdvancedMode = false;
			this.complatePropertyGrid.BorderStyle = global::System.Windows.Forms.BorderStyle.None;
			this.complatePropertyGrid.ContextMenuStrip = this.contextMenuStrip1;
			this.complatePropertyGrid.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.complatePropertyGrid.DrawingManager = global::VisualHint.SmartPropertyGrid.PropertyGrid.DrawManagers.CustomDrawManager;
			this.complatePropertyGrid.GridColor = global::System.Drawing.Color.FromArgb(199, 221, 167);
			this.complatePropertyGrid.Location = new global::System.Drawing.Point(279, 0);
			this.complatePropertyGrid.Name = "complatePropertyGrid";
			this.complatePropertyGrid.PROP = null;
			this.complatePropertyGrid.PropertyLabelBackColor = global::System.Drawing.SystemColors.Window;
			this.complatePropertyGrid.PropertyValueBackColor = global::System.Drawing.SystemColors.Window;
			this.complatePropertyGrid.SelectedBackColor = global::System.Drawing.Color.FromArgb(74, 88, 43);
			this.complatePropertyGrid.SelectedNotFocusedBackColor = global::System.Drawing.Color.FromArgb(199, 221, 167);
			this.complatePropertyGrid.Size = new global::System.Drawing.Size(289, 333);
			this.complatePropertyGrid.TabIndex = 9;
			this.complatePropertyGrid.Text = "complatePropertyGrid1";
			this.contextMenuStrip1.Items.AddRange(new global::System.Windows.Forms.ToolStripItem[]
			{
				this.removeStep
			});
			this.contextMenuStrip1.Name = "contextMenuStrip1";
			this.contextMenuStrip1.Size = new global::System.Drawing.Size(165, 26);
			this.removeStep.Name = "removeStep";
			this.removeStep.Size = new global::System.Drawing.Size(164, 22);
			this.removeStep.Text = "Remove this step";
			this.removeStep.Click += new global::System.EventHandler(this.removeStep_Click);
			base.AcceptButton = this.doneBtn;
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.CancelButton = this.doneBtn;
			base.ClientSize = new global::System.Drawing.Size(568, 385);
			base.Controls.Add(this.panel7);
			base.Controls.Add(this.statusStrip);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.SizableToolWindow;
			base.Icon = (global::System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
			this.MinimumSize = new global::System.Drawing.Size(485, 397);
			base.Name = "PropEditor";
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "PROP Editor";
			base.Paint += new global::System.Windows.Forms.PaintEventHandler(this.PropEditor_Paint);
			base.Shown += new global::System.EventHandler(this.PropEditor_Shown);
			base.ResizeEnd += new global::System.EventHandler(this.PropEditor_ResizeEnd);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.panel6.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox1).EndInit();
			this.panel2.ResumeLayout(false);
			this.panel3.ResumeLayout(false);
			this.panel4.ResumeLayout(false);
			this.statusStrip.ResumeLayout(false);
			this.statusStrip.PerformLayout();
			this.panel7.ResumeLayout(false);
			this.panel8.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.complatePropertyGrid).EndInit();
			this.contextMenuStrip1.ResumeLayout(false);
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x0400033E RID: 830
		private global::System.ComponentModel.IContainer icontainer_0;

		// Token: 0x0400033F RID: 831
		private global::System.Windows.Forms.Button doneBtn;

		// Token: 0x04000340 RID: 832
		private global::System.Windows.Forms.Button cancelBtn;

		// Token: 0x04000341 RID: 833
		private global::System.Windows.Forms.Button importBtn;

		// Token: 0x04000342 RID: 834
		private global::System.Windows.Forms.Button exportBtn;

		// Token: 0x04000343 RID: 835
		private global::System.Windows.Forms.Panel panel1;

		// Token: 0x04000344 RID: 836
		private global::System.Windows.Forms.Panel panel3;

		// Token: 0x04000345 RID: 837
		private global::System.Windows.Forms.Panel panel2;

		// Token: 0x04000346 RID: 838
		private global::System.Windows.Forms.Panel panel4;

		// Token: 0x04000347 RID: 839
		private global::System.Windows.Forms.CheckBox liveUpdate;

		// Token: 0x04000348 RID: 840
		private global::System.Windows.Forms.Panel panel6;

		// Token: 0x04000349 RID: 841
		private global::System.Windows.Forms.StatusStrip statusStrip;

		// Token: 0x0400034A RID: 842
		private global::System.Windows.Forms.Panel panel7;

		// Token: 0x0400034B RID: 843
		private global::System.Windows.Forms.Panel panel8;

		// Token: 0x0400034C RID: 844
		private global::System.Windows.Forms.ToolStripStatusLabel statusLabel;

		// Token: 0x0400034D RID: 845
		private global::Skybound.VisualTips.VisualTipProvider visualTipProvider_0;

		// Token: 0x0400034E RID: 846
		private global::ns0.Class5 complatePropertyGrid;

		// Token: 0x0400034F RID: 847
		private global::System.Windows.Forms.ContextMenuStrip contextMenuStrip1;

		// Token: 0x04000350 RID: 848
		private global::System.Windows.Forms.ToolStripMenuItem removeStep;

		// Token: 0x04000351 RID: 849
		private global::System.Windows.Forms.PictureBox pictureBox1;
	}
}
