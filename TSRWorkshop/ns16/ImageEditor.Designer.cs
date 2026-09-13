namespace ns16
{
	// Token: 0x0200007F RID: 127
	internal sealed partial class ImageEditor : global::System.Windows.Forms.Form
	{
		// Token: 0x060004E5 RID: 1253 RVA: 0x0004D0A4 File Offset: 0x0004B2A4
		private void InitializeComponent()
		{
			this.icontainer_0 = new global::System.ComponentModel.Container();
			global::ns17.Class161 @class = new global::ns17.Class161();
			global::ns17.Class161 class2 = new global::ns17.Class161();
			global::ns17.Class161 class3 = new global::ns17.Class161();
			global::ns17.Class161 class4 = new global::ns17.Class161();
			global::ns8.Class157 renderer = new global::ns8.Class157();
			global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::ns16.ImageEditor));
			this.statusStrip1 = new global::System.Windows.Forms.StatusStrip();
			this.statusInfo = new global::System.Windows.Forms.ToolStripStatusLabel();
			this.statusSize = new global::System.Windows.Forms.ToolStripStatusLabel();
			this.panel2 = new global::System.Windows.Forms.Panel();
			this.panel4 = new global::System.Windows.Forms.Panel();
			this.panel9 = new global::System.Windows.Forms.Panel();
			this.preview = new global::ns17.Control0();
			this.panel10 = new global::System.Windows.Forms.Panel();
			this.groupBox1 = new global::System.Windows.Forms.GroupBox();
			this.useBlue = new global::System.Windows.Forms.CheckBox();
			this.useGreen = new global::System.Windows.Forms.CheckBox();
			this.useRed = new global::System.Windows.Forms.CheckBox();
			this.fillAlpha = new global::System.Windows.Forms.CheckBox();
			this.panel3 = new global::System.Windows.Forms.Panel();
			this.panel5 = new global::System.Windows.Forms.Panel();
			this.panel8 = new global::System.Windows.Forms.Panel();
			this.textBox1 = new global::System.Windows.Forms.TextBox();
			this.panel6 = new global::System.Windows.Forms.Panel();
			this.button1 = new global::System.Windows.Forms.Button();
			this.panel1 = new global::System.Windows.Forms.Panel();
			this.browse = new global::System.Windows.Forms.Button();
			this.export = new global::System.Windows.Forms.Button();
			this.import = new global::System.Windows.Forms.Button();
			this.panel7 = new global::System.Windows.Forms.Panel();
			this.emptyBtn = new global::System.Windows.Forms.Button();
			this.cancel = new global::System.Windows.Forms.Button();
			this.done = new global::System.Windows.Forms.Button();
			this.visualTipProvider_0 = new global::Skybound.VisualTips.VisualTipProvider(this.icontainer_0);
			this.statusStrip1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.panel4.SuspendLayout();
			this.panel9.SuspendLayout();
			this.panel10.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.panel3.SuspendLayout();
			this.panel5.SuspendLayout();
			this.panel8.SuspendLayout();
			this.panel6.SuspendLayout();
			this.panel1.SuspendLayout();
			this.panel7.SuspendLayout();
			base.SuspendLayout();
			this.statusStrip1.Items.AddRange(new global::System.Windows.Forms.ToolStripItem[]
			{
				this.statusInfo,
				this.statusSize
			});
			this.statusStrip1.Location = new global::System.Drawing.Point(0, 533);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new global::System.Drawing.Size(566, 22);
			this.statusStrip1.TabIndex = 10;
			this.statusStrip1.Text = "statusStrip1";
			this.statusInfo.Name = "statusInfo";
			this.statusInfo.Size = new global::System.Drawing.Size(98, 17);
			this.statusInfo.Text = "No image loaded";
			this.statusSize.Name = "statusSize";
			this.statusSize.Size = new global::System.Drawing.Size(453, 17);
			this.statusSize.Spring = true;
			this.statusSize.TextAlign = global::System.Drawing.ContentAlignment.MiddleRight;
			this.panel2.Controls.Add(this.panel4);
			this.panel2.Controls.Add(this.panel7);
			this.panel2.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.panel2.Location = new global::System.Drawing.Point(0, 0);
			this.panel2.Name = "panel2";
			this.panel2.Size = new global::System.Drawing.Size(566, 533);
			this.panel2.TabIndex = 11;
			this.panel4.Controls.Add(this.panel9);
			this.panel4.Controls.Add(this.panel10);
			this.panel4.Controls.Add(this.panel3);
			this.panel4.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.panel4.Location = new global::System.Drawing.Point(0, 0);
			this.panel4.Name = "panel4";
			this.panel4.Size = new global::System.Drawing.Size(566, 500);
			this.panel4.TabIndex = 9;
			this.panel9.AutoScroll = true;
			this.panel9.AutoScrollMargin = new global::System.Drawing.Size(3, 3);
			this.panel9.AutoScrollMinSize = new global::System.Drawing.Size(10, 10);
			this.panel9.Controls.Add(this.preview);
			this.panel9.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.panel9.Location = new global::System.Drawing.Point(0, 80);
			this.panel9.Name = "panel9";
			this.panel9.Size = new global::System.Drawing.Size(566, 420);
			this.panel9.TabIndex = 18;
			this.preview.BackColor = global::System.Drawing.SystemColors.Control;
			this.preview.BackgroundColor = global::System.Drawing.SystemColors.Control;
			this.preview.BlueMult = 0f;
			this.preview.BorderStyle = global::System.Windows.Forms.BorderStyle.FixedSingle;
			this.preview.Brightness = 0f;
			this.preview.DefaultClickAction = global::ns17.Control0.Enum3.const_0;
			this.preview.DefaultDragAction = global::ns17.Control0.Enum4.const_0;
			this.preview.FitToView = false;
			this.preview.ForeColor = global::System.Drawing.SystemColors.Control;
			this.preview.GreenMult = 0f;
			this.preview.Image = null;
			this.preview.Location = new global::System.Drawing.Point(5, 2);
			this.preview.Margin = new global::System.Windows.Forms.Padding(0);
			this.preview.Name = "preview";
			this.preview.RedMult = 0f;
			this.preview.Size = new global::System.Drawing.Size(256, 256);
			this.preview.TabIndex = 16;
			this.preview.UseAlpha = true;
			this.preview.UseBlue = true;
			this.preview.UseGreen = true;
			this.preview.UseRed = true;
			this.preview.Zoom = 1f;
			this.panel10.Controls.Add(this.groupBox1);
			this.panel10.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.panel10.Location = new global::System.Drawing.Point(0, 34);
			this.panel10.Name = "panel10";
			this.panel10.Padding = new global::System.Windows.Forms.Padding(6, 0, 6, 4);
			this.panel10.Size = new global::System.Drawing.Size(566, 46);
			this.panel10.TabIndex = 22;
			this.groupBox1.Controls.Add(this.useBlue);
			this.groupBox1.Controls.Add(this.useGreen);
			this.groupBox1.Controls.Add(this.useRed);
			this.groupBox1.Controls.Add(this.fillAlpha);
			this.groupBox1.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.groupBox1.Location = new global::System.Drawing.Point(6, 0);
			this.groupBox1.Margin = new global::System.Windows.Forms.Padding(0);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new global::System.Drawing.Size(554, 42);
			this.groupBox1.TabIndex = 18;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Visible channels";
			this.useBlue.AutoSize = true;
			this.useBlue.Checked = true;
			this.useBlue.CheckState = global::System.Windows.Forms.CheckState.Checked;
			this.useBlue.Location = new global::System.Drawing.Point(185, 18);
			this.useBlue.Name = "useBlue";
			this.useBlue.Size = new global::System.Drawing.Size(47, 17);
			this.useBlue.TabIndex = 20;
			this.useBlue.Text = "Blue";
			this.useBlue.UseVisualStyleBackColor = true;
			this.useBlue.CheckedChanged += new global::System.EventHandler(this.fillAlpha_CheckedChanged);
			this.useGreen.AutoSize = true;
			this.useGreen.Checked = true;
			this.useGreen.CheckState = global::System.Windows.Forms.CheckState.Checked;
			this.useGreen.Location = new global::System.Drawing.Point(124, 18);
			this.useGreen.Name = "useGreen";
			this.useGreen.Size = new global::System.Drawing.Size(55, 17);
			this.useGreen.TabIndex = 19;
			this.useGreen.Text = "Green";
			this.useGreen.UseVisualStyleBackColor = true;
			this.useGreen.CheckedChanged += new global::System.EventHandler(this.fillAlpha_CheckedChanged);
			this.useRed.AutoSize = true;
			this.useRed.Checked = true;
			this.useRed.CheckState = global::System.Windows.Forms.CheckState.Checked;
			this.useRed.Location = new global::System.Drawing.Point(72, 18);
			this.useRed.Name = "useRed";
			this.useRed.Size = new global::System.Drawing.Size(46, 17);
			this.useRed.TabIndex = 18;
			this.useRed.Text = "Red";
			this.useRed.UseVisualStyleBackColor = true;
			this.useRed.CheckedChanged += new global::System.EventHandler(this.fillAlpha_CheckedChanged);
			this.fillAlpha.AutoSize = true;
			this.fillAlpha.Checked = true;
			this.fillAlpha.CheckState = global::System.Windows.Forms.CheckState.Checked;
			this.fillAlpha.Location = new global::System.Drawing.Point(13, 18);
			this.fillAlpha.Name = "fillAlpha";
			this.fillAlpha.Size = new global::System.Drawing.Size(53, 17);
			this.fillAlpha.TabIndex = 17;
			this.fillAlpha.Text = "Alpha";
			this.fillAlpha.UseVisualStyleBackColor = true;
			this.fillAlpha.CheckedChanged += new global::System.EventHandler(this.fillAlpha_CheckedChanged);
			this.panel3.Controls.Add(this.panel5);
			this.panel3.Controls.Add(this.panel1);
			this.panel3.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.panel3.Location = new global::System.Drawing.Point(0, 0);
			this.panel3.Name = "panel3";
			this.panel3.Size = new global::System.Drawing.Size(566, 34);
			this.panel3.TabIndex = 15;
			this.panel5.Controls.Add(this.panel8);
			this.panel5.Controls.Add(this.panel6);
			this.panel5.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.panel5.Location = new global::System.Drawing.Point(0, 0);
			this.panel5.Name = "panel5";
			this.panel5.Padding = new global::System.Windows.Forms.Padding(6, 5, 10, 5);
			this.panel5.Size = new global::System.Drawing.Size(362, 34);
			this.panel5.TabIndex = 7;
			this.panel8.Controls.Add(this.textBox1);
			this.panel8.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.panel8.Location = new global::System.Drawing.Point(6, 5);
			this.panel8.Name = "panel8";
			this.panel8.Padding = new global::System.Windows.Forms.Padding(0, 2, 4, 0);
			this.panel8.Size = new global::System.Drawing.Size(300, 24);
			this.panel8.TabIndex = 6;
			this.textBox1.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.textBox1.Location = new global::System.Drawing.Point(0, 2);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new global::System.Drawing.Size(296, 20);
			this.textBox1.TabIndex = 5;
			this.panel6.Controls.Add(this.button1);
			this.panel6.Dock = global::System.Windows.Forms.DockStyle.Right;
			this.panel6.Location = new global::System.Drawing.Point(306, 5);
			this.panel6.Name = "panel6";
			this.panel6.Size = new global::System.Drawing.Size(46, 24);
			this.panel6.TabIndex = 5;
			this.button1.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.button1.Location = new global::System.Drawing.Point(0, 0);
			this.button1.Name = "button1";
			this.button1.Size = new global::System.Drawing.Size(46, 24);
			this.button1.TabIndex = 4;
			this.button1.Text = "Find";
			this.button1.UseVisualStyleBackColor = true;
			@class.Text = "Search for the image resource specified";
			@class.Title = "Find";
			this.visualTipProvider_0.method_3(this.button1, @class);
			this.button1.Click += new global::System.EventHandler(this.button1_Click);
			this.panel1.Controls.Add(this.browse);
			this.panel1.Controls.Add(this.export);
			this.panel1.Controls.Add(this.import);
			this.panel1.Dock = global::System.Windows.Forms.DockStyle.Right;
			this.panel1.Location = new global::System.Drawing.Point(362, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new global::System.Drawing.Size(204, 34);
			this.panel1.TabIndex = 6;
			this.browse.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Right);
			this.browse.Image = global::ns17.Class143.open;
			this.browse.ImageAlign = global::System.Drawing.ContentAlignment.MiddleLeft;
			this.browse.Location = new global::System.Drawing.Point(6, 5);
			this.browse.Name = "browse";
			this.browse.Size = new global::System.Drawing.Size(65, 24);
			this.browse.TabIndex = 6;
			this.browse.Text = "Browse";
			this.browse.TextAlign = global::System.Drawing.ContentAlignment.MiddleRight;
			this.browse.UseVisualStyleBackColor = true;
			class2.Text = "Browse for an image in your project";
			class2.Title = "Browse";
			this.visualTipProvider_0.method_3(this.browse, class2);
			this.browse.Click += new global::System.EventHandler(this.browse_Click);
			this.export.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Right);
			this.export.Image = global::ns17.Class143.export;
			this.export.ImageAlign = global::System.Drawing.ContentAlignment.MiddleLeft;
			this.export.Location = new global::System.Drawing.Point(74, 5);
			this.export.Name = "export";
			this.export.Size = new global::System.Drawing.Size(60, 24);
			this.export.TabIndex = 4;
			this.export.Text = "Export";
			this.export.TextAlign = global::System.Drawing.ContentAlignment.MiddleRight;
			this.export.UseVisualStyleBackColor = true;
			class3.Text = "Export this image";
			class3.Title = "Export";
			this.visualTipProvider_0.method_3(this.export, class3);
			this.export.Click += new global::System.EventHandler(this.export_Click);
			this.import.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Right);
			this.import.Image = global::ns17.Class143.import;
			this.import.ImageAlign = global::System.Drawing.ContentAlignment.MiddleLeft;
			this.import.Location = new global::System.Drawing.Point(137, 5);
			this.import.Name = "import";
			this.import.Size = new global::System.Drawing.Size(60, 24);
			this.import.TabIndex = 5;
			this.import.Text = "Import";
			this.import.TextAlign = global::System.Drawing.ContentAlignment.MiddleRight;
			this.import.UseVisualStyleBackColor = true;
			class4.Text = "Import an image";
			class4.Title = "Import";
			this.visualTipProvider_0.method_3(this.import, class4);
			this.import.Click += new global::System.EventHandler(this.import_Click);
			this.panel7.Controls.Add(this.emptyBtn);
			this.panel7.Controls.Add(this.cancel);
			this.panel7.Controls.Add(this.done);
			this.panel7.Dock = global::System.Windows.Forms.DockStyle.Bottom;
			this.panel7.Location = new global::System.Drawing.Point(0, 500);
			this.panel7.Name = "panel7";
			this.panel7.Size = new global::System.Drawing.Size(566, 33);
			this.panel7.TabIndex = 8;
			this.emptyBtn.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left);
			this.emptyBtn.Location = new global::System.Drawing.Point(6, 5);
			this.emptyBtn.Name = "emptyBtn";
			this.emptyBtn.Size = new global::System.Drawing.Size(75, 23);
			this.emptyBtn.TabIndex = 17;
			this.emptyBtn.Text = "Make empty";
			this.emptyBtn.UseVisualStyleBackColor = true;
			this.emptyBtn.Click += new global::System.EventHandler(this.emptyBtn_Click);
			this.cancel.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Right);
			this.cancel.DialogResult = global::System.Windows.Forms.DialogResult.Cancel;
			this.cancel.Location = new global::System.Drawing.Point(486, 5);
			this.cancel.Name = "cancel";
			this.cancel.Size = new global::System.Drawing.Size(75, 23);
			this.cancel.TabIndex = 16;
			this.cancel.Text = "Cancel";
			this.cancel.UseVisualStyleBackColor = true;
			this.cancel.Click += new global::System.EventHandler(this.cancel_Click);
			this.done.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Right);
			this.done.Enabled = false;
			this.done.Location = new global::System.Drawing.Point(407, 5);
			this.done.Name = "done";
			this.done.Size = new global::System.Drawing.Size(75, 23);
			this.done.TabIndex = 15;
			this.done.Text = "Done";
			this.done.UseVisualStyleBackColor = true;
			this.done.Click += new global::System.EventHandler(this.done_Click);
			this.visualTipProvider_0.Animation = global::ns20.Enum24.const_2;
			this.visualTipProvider_0.InitialDelay = 750;
			this.visualTipProvider_0.Renderer = renderer;
			this.visualTipProvider_0.Shadow = global::ns1.Enum26.const_2;
			this.visualTipProvider_0.ShowAlways = true;
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new global::System.Drawing.Size(566, 555);
			base.Controls.Add(this.panel2);
			base.Controls.Add(this.statusStrip1);
			base.Icon = (global::System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
			base.KeyPreview = true;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			this.MinimumSize = new global::System.Drawing.Size(370, 300);
			base.Name = "ImageEditor";
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Image Editor";
			base.LocationChanged += new global::System.EventHandler(this.ImageEditor_LocationChanged);
			base.SizeChanged += new global::System.EventHandler(this.ImageEditor_SizeChanged);
			base.KeyDown += new global::System.Windows.Forms.KeyEventHandler(this.ImageEditor_KeyDown);
			base.KeyUp += new global::System.Windows.Forms.KeyEventHandler(this.ImageEditor_KeyUp);
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			this.panel2.ResumeLayout(false);
			this.panel4.ResumeLayout(false);
			this.panel9.ResumeLayout(false);
			this.panel10.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.panel3.ResumeLayout(false);
			this.panel5.ResumeLayout(false);
			this.panel8.ResumeLayout(false);
			this.panel8.PerformLayout();
			this.panel6.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			this.panel7.ResumeLayout(false);
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x0400044A RID: 1098
		private global::System.ComponentModel.IContainer icontainer_0;

		// Token: 0x0400044B RID: 1099
		private global::System.Windows.Forms.StatusStrip statusStrip1;

		// Token: 0x0400044C RID: 1100
		private global::System.Windows.Forms.ToolStripStatusLabel statusInfo;

		// Token: 0x0400044D RID: 1101
		private global::System.Windows.Forms.ToolStripStatusLabel statusSize;

		// Token: 0x0400044E RID: 1102
		private global::System.Windows.Forms.Panel panel2;

		// Token: 0x0400044F RID: 1103
		private global::System.Windows.Forms.Panel panel7;

		// Token: 0x04000450 RID: 1104
		private global::System.Windows.Forms.Panel panel4;

		// Token: 0x04000451 RID: 1105
		private global::System.Windows.Forms.Panel panel3;

		// Token: 0x04000452 RID: 1106
		private global::System.Windows.Forms.Button cancel;

		// Token: 0x04000453 RID: 1107
		private global::System.Windows.Forms.Button done;

		// Token: 0x04000454 RID: 1108
		private global::System.Windows.Forms.Panel panel5;

		// Token: 0x04000455 RID: 1109
		private global::System.Windows.Forms.Panel panel8;

		// Token: 0x04000456 RID: 1110
		private global::System.Windows.Forms.TextBox textBox1;

		// Token: 0x04000457 RID: 1111
		private global::System.Windows.Forms.Panel panel6;

		// Token: 0x04000458 RID: 1112
		private global::System.Windows.Forms.Button button1;

		// Token: 0x04000459 RID: 1113
		private global::System.Windows.Forms.Panel panel1;

		// Token: 0x0400045A RID: 1114
		private global::System.Windows.Forms.Button browse;

		// Token: 0x0400045B RID: 1115
		private global::System.Windows.Forms.Button export;

		// Token: 0x0400045C RID: 1116
		private global::System.Windows.Forms.Button import;

		// Token: 0x0400045D RID: 1117
		private global::ns17.Control0 preview;

		// Token: 0x0400045E RID: 1118
		private global::Skybound.VisualTips.VisualTipProvider visualTipProvider_0;

		// Token: 0x0400045F RID: 1119
		private global::System.Windows.Forms.Panel panel9;

		// Token: 0x04000460 RID: 1120
		private global::System.Windows.Forms.Panel panel10;

		// Token: 0x04000461 RID: 1121
		private global::System.Windows.Forms.GroupBox groupBox1;

		// Token: 0x04000462 RID: 1122
		private global::System.Windows.Forms.CheckBox useBlue;

		// Token: 0x04000463 RID: 1123
		private global::System.Windows.Forms.CheckBox useGreen;

		// Token: 0x04000464 RID: 1124
		private global::System.Windows.Forms.CheckBox useRed;

		// Token: 0x04000465 RID: 1125
		private global::System.Windows.Forms.CheckBox fillAlpha;

		// Token: 0x04000466 RID: 1126
		private global::System.Windows.Forms.Button emptyBtn;
	}
}
