namespace ns3
{
	// Token: 0x02000080 RID: 128
	internal sealed partial class PatternEditor : global::System.Windows.Forms.Form
	{
		// Token: 0x06000503 RID: 1283 RVA: 0x0004EF28 File Offset: 0x0004D128
		private void InitializeComponent()
		{
			this.icontainer_0 = new global::System.ComponentModel.Container();
			global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::ns3.PatternEditor));
			global::ns17.Class161 @class = new global::ns17.Class161();
			global::ns17.Class161 class2 = new global::ns17.Class161();
			global::ns17.Class161 class3 = new global::ns17.Class161();
			global::ns17.Class161 class4 = new global::ns17.Class161();
			global::ns17.Class161 class5 = new global::ns17.Class161();
			global::ns8.Class157 renderer = new global::ns8.Class157();
			this.browseBtn = new global::System.Windows.Forms.Button();
			this.doneBtn = new global::System.Windows.Forms.Button();
			this.cancelBtn = new global::System.Windows.Forms.Button();
			this.newBtn = new global::System.Windows.Forms.Button();
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
			this.patternPropertyGrid1 = new global::ns6.Class7();
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
			((global::System.ComponentModel.ISupportInitialize)this.patternPropertyGrid1).BeginInit();
			base.SuspendLayout();
			this.browseBtn.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 8.5f);
			this.browseBtn.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("browseBtn.Image");
			this.browseBtn.Location = new global::System.Drawing.Point(-1, -1);
			this.browseBtn.Name = "browseBtn";
			this.browseBtn.Size = new global::System.Drawing.Size(36, 26);
			this.browseBtn.TabIndex = 1;
			this.browseBtn.TextImageRelation = global::System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.browseBtn.UseVisualStyleBackColor = true;
			@class.Text = "Browse for a pattern already in your project or for a base game pattern.";
			@class.Title = "Browse";
			this.visualTipProvider_0.method_3(this.browseBtn, @class);
			this.browseBtn.Click += new global::System.EventHandler(this.browseBtn_Click);
			this.doneBtn.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Right);
			this.doneBtn.DialogResult = global::System.Windows.Forms.DialogResult.Cancel;
			this.doneBtn.Location = new global::System.Drawing.Point(397, 4);
			this.doneBtn.Name = "doneBtn";
			this.doneBtn.Size = new global::System.Drawing.Size(75, 23);
			this.doneBtn.TabIndex = 2;
			this.doneBtn.Text = "Done";
			this.doneBtn.UseVisualStyleBackColor = true;
			this.doneBtn.Click += new global::System.EventHandler(this.doneBtn_Click);
			this.cancelBtn.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Right);
			this.cancelBtn.DialogResult = global::System.Windows.Forms.DialogResult.Cancel;
			this.cancelBtn.Location = new global::System.Drawing.Point(478, 4);
			this.cancelBtn.Name = "cancelBtn";
			this.cancelBtn.Size = new global::System.Drawing.Size(75, 23);
			this.cancelBtn.TabIndex = 3;
			this.cancelBtn.Text = "Cancel";
			this.cancelBtn.UseVisualStyleBackColor = true;
			this.cancelBtn.Click += new global::System.EventHandler(this.cancelBtn_Click);
			this.newBtn.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 8.5f);
			this.newBtn.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("newBtn.Image");
			this.newBtn.Location = new global::System.Drawing.Point(41, -1);
			this.newBtn.Name = "newBtn";
			this.newBtn.Size = new global::System.Drawing.Size(36, 26);
			this.newBtn.TabIndex = 4;
			this.newBtn.TextImageRelation = global::System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.newBtn.UseVisualStyleBackColor = true;
			class2.Text = "Create a new pattern from scratch (limited to solid color right now)";
			class2.Title = "New";
			this.visualTipProvider_0.method_3(this.newBtn, class2);
			this.newBtn.Click += new global::System.EventHandler(this.newBtn_Click);
			this.importBtn.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 8.5f);
			this.importBtn.Image = global::ns17.Class143.import;
			this.importBtn.Location = new global::System.Drawing.Point(221, -1);
			this.importBtn.Name = "importBtn";
			this.importBtn.Size = new global::System.Drawing.Size(36, 26);
			this.importBtn.TabIndex = 5;
			this.importBtn.TextImageRelation = global::System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.importBtn.UseVisualStyleBackColor = true;
			class3.Text = "Import a pattern, will replace the current pattern.";
			class3.Title = "Import";
			this.visualTipProvider_0.method_3(this.importBtn, class3);
			this.importBtn.Click += new global::System.EventHandler(this.importBtn_Click);
			this.exportBtn.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 8.5f);
			this.exportBtn.Image = global::ns17.Class143.export;
			this.exportBtn.Location = new global::System.Drawing.Point(179, -1);
			this.exportBtn.Name = "exportBtn";
			this.exportBtn.Size = new global::System.Drawing.Size(36, 26);
			this.exportBtn.TabIndex = 6;
			this.exportBtn.TextImageRelation = global::System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.exportBtn.UseVisualStyleBackColor = true;
			class4.Text = "Export this pattern";
			class4.Title = "Export";
			this.visualTipProvider_0.method_3(this.exportBtn, class4);
			this.exportBtn.Click += new global::System.EventHandler(this.exportBtn_Click);
			this.panel1.Controls.Add(this.panel6);
			this.panel1.Controls.Add(this.liveUpdate);
			this.panel1.Controls.Add(this.panel2);
			this.panel1.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new global::System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new global::System.Drawing.Size(262, 314);
			this.panel1.TabIndex = 7;
			this.panel6.BackColor = global::System.Drawing.Color.White;
			this.panel6.BorderStyle = global::System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel6.Controls.Add(this.pictureBox1);
			this.panel6.Location = new global::System.Drawing.Point(1, 30);
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
			this.liveUpdate.Location = new global::System.Drawing.Point(1, 292);
			this.liveUpdate.Name = "liveUpdate";
			this.liveUpdate.Size = new global::System.Drawing.Size(78, 17);
			this.liveUpdate.TabIndex = 3;
			this.liveUpdate.Text = "3d preview";
			this.liveUpdate.UseVisualStyleBackColor = true;
			class5.Text = "Preview your changes directly in the 3d view (can be a little slower)";
			this.visualTipProvider_0.method_3(this.liveUpdate, class5);
			this.liveUpdate.CheckedChanged += new global::System.EventHandler(this.liveUpdate_CheckedChanged);
			this.panel2.Controls.Add(this.newBtn);
			this.panel2.Controls.Add(this.importBtn);
			this.panel2.Controls.Add(this.browseBtn);
			this.panel2.Controls.Add(this.exportBtn);
			this.panel2.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.panel2.Location = new global::System.Drawing.Point(0, 0);
			this.panel2.Margin = new global::System.Windows.Forms.Padding(0);
			this.panel2.Name = "panel2";
			this.panel2.Size = new global::System.Drawing.Size(262, 28);
			this.panel2.TabIndex = 0;
			this.panel3.Controls.Add(this.doneBtn);
			this.panel3.Controls.Add(this.cancelBtn);
			this.panel3.Dock = global::System.Windows.Forms.DockStyle.Bottom;
			this.panel3.Location = new global::System.Drawing.Point(5, 319);
			this.panel3.Name = "panel3";
			this.panel3.Size = new global::System.Drawing.Size(552, 27);
			this.panel3.TabIndex = 1;
			this.panel4.Controls.Add(this.panel1);
			this.panel4.Dock = global::System.Windows.Forms.DockStyle.Left;
			this.panel4.Location = new global::System.Drawing.Point(0, 0);
			this.panel4.Name = "panel4";
			this.panel4.Size = new global::System.Drawing.Size(262, 314);
			this.panel4.TabIndex = 8;
			this.statusStrip.Items.AddRange(new global::System.Windows.Forms.ToolStripItem[]
			{
				this.statusLabel
			});
			this.statusStrip.Location = new global::System.Drawing.Point(0, 351);
			this.statusStrip.Name = "statusStrip";
			this.statusStrip.Size = new global::System.Drawing.Size(562, 22);
			this.statusStrip.TabIndex = 10;
			this.statusStrip.Text = "statusStrip1";
			this.statusLabel.Name = "statusLabel";
			this.statusLabel.Size = new global::System.Drawing.Size(103, 17);
			this.statusLabel.Text = "No pattern loaded";
			this.panel7.Controls.Add(this.panel8);
			this.panel7.Controls.Add(this.panel3);
			this.panel7.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.panel7.Location = new global::System.Drawing.Point(0, 0);
			this.panel7.Name = "panel7";
			this.panel7.Padding = new global::System.Windows.Forms.Padding(5);
			this.panel7.Size = new global::System.Drawing.Size(562, 351);
			this.panel7.TabIndex = 11;
			this.panel8.Controls.Add(this.patternPropertyGrid1);
			this.panel8.Controls.Add(this.panel4);
			this.panel8.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.panel8.Location = new global::System.Drawing.Point(5, 5);
			this.panel8.Name = "panel8";
			this.panel8.Size = new global::System.Drawing.Size(552, 314);
			this.panel8.TabIndex = 0;
			this.patternPropertyGrid1.AdvancedMode = true;
			this.patternPropertyGrid1.BorderStyle = global::System.Windows.Forms.BorderStyle.None;
			this.patternPropertyGrid1.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.patternPropertyGrid1.DrawingManager = global::VisualHint.SmartPropertyGrid.PropertyGrid.DrawManagers.CustomDrawManager;
			this.patternPropertyGrid1.GridColor = global::System.Drawing.Color.FromArgb(199, 221, 167);
			this.patternPropertyGrid1.Location = new global::System.Drawing.Point(262, 0);
			this.patternPropertyGrid1.Name = "patternPropertyGrid1";
			this.patternPropertyGrid1.PatternNode = null;
			this.patternPropertyGrid1.PropertyLabelBackColor = global::System.Drawing.SystemColors.Window;
			this.patternPropertyGrid1.PropertyValueBackColor = global::System.Drawing.SystemColors.Window;
			this.patternPropertyGrid1.SelectedBackColor = global::System.Drawing.Color.FromArgb(74, 88, 43);
			this.patternPropertyGrid1.SelectedNotFocusedBackColor = global::System.Drawing.Color.FromArgb(199, 221, 167);
			this.patternPropertyGrid1.Size = new global::System.Drawing.Size(290, 314);
			this.patternPropertyGrid1.TabIndex = 0;
			this.patternPropertyGrid1.Text = "s";
			this.visualTipProvider_0.Animation = global::ns20.Enum24.const_2;
			this.visualTipProvider_0.InitialDelay = 750;
			this.visualTipProvider_0.Renderer = renderer;
			this.visualTipProvider_0.Shadow = global::ns1.Enum26.const_2;
			this.visualTipProvider_0.ShowAlways = true;
			base.AcceptButton = this.doneBtn;
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.CancelButton = this.doneBtn;
			base.ClientSize = new global::System.Drawing.Size(562, 373);
			base.Controls.Add(this.panel7);
			base.Controls.Add(this.statusStrip);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.SizableToolWindow;
			base.Icon = (global::System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
			this.MinimumSize = new global::System.Drawing.Size(578, 407);
			base.Name = "PatternEditor";
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Pattern Editor";
			base.Load += new global::System.EventHandler(this.PatternEditor_Load);
			base.Paint += new global::System.Windows.Forms.PaintEventHandler(this.PatternEditor_Paint);
			base.Shown += new global::System.EventHandler(this.PatternEditor_Shown);
			base.ResizeEnd += new global::System.EventHandler(this.PatternEditor_ResizeEnd);
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
			((global::System.ComponentModel.ISupportInitialize)this.patternPropertyGrid1).EndInit();
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x04000473 RID: 1139
		private global::System.ComponentModel.IContainer icontainer_0;

		// Token: 0x04000474 RID: 1140
		private global::System.Windows.Forms.Button browseBtn;

		// Token: 0x04000475 RID: 1141
		private global::System.Windows.Forms.Button doneBtn;

		// Token: 0x04000476 RID: 1142
		private global::System.Windows.Forms.Button cancelBtn;

		// Token: 0x04000477 RID: 1143
		private global::System.Windows.Forms.Button newBtn;

		// Token: 0x04000478 RID: 1144
		private global::System.Windows.Forms.Button importBtn;

		// Token: 0x04000479 RID: 1145
		private global::System.Windows.Forms.Button exportBtn;

		// Token: 0x0400047A RID: 1146
		private global::System.Windows.Forms.Panel panel1;

		// Token: 0x0400047B RID: 1147
		private global::System.Windows.Forms.Panel panel3;

		// Token: 0x0400047C RID: 1148
		private global::System.Windows.Forms.Panel panel2;

		// Token: 0x0400047D RID: 1149
		private global::System.Windows.Forms.Panel panel4;

		// Token: 0x0400047E RID: 1150
		private global::ns6.Class7 patternPropertyGrid1;

		// Token: 0x0400047F RID: 1151
		private global::System.Windows.Forms.CheckBox liveUpdate;

		// Token: 0x04000480 RID: 1152
		private global::System.Windows.Forms.Panel panel6;

		// Token: 0x04000481 RID: 1153
		private global::System.Windows.Forms.StatusStrip statusStrip;

		// Token: 0x04000482 RID: 1154
		private global::System.Windows.Forms.Panel panel7;

		// Token: 0x04000483 RID: 1155
		private global::System.Windows.Forms.Panel panel8;

		// Token: 0x04000484 RID: 1156
		private global::System.Windows.Forms.ToolStripStatusLabel statusLabel;

		// Token: 0x04000485 RID: 1157
		private global::Skybound.VisualTips.VisualTipProvider visualTipProvider_0;

		// Token: 0x04000486 RID: 1158
		private global::System.Windows.Forms.PictureBox pictureBox1;
	}
}
