namespace ns19
{
	// Token: 0x0200003F RID: 63
	internal sealed partial class GeostateSelector : global::System.Windows.Forms.Form, global::ns14.Interface2
	{
		// Token: 0x06000264 RID: 612 RVA: 0x0002DF8C File Offset: 0x0002C18C
		private void InitializeComponent()
		{
			this.icontainer_0 = new global::System.ComponentModel.Container();
			this.doneButton = new global::System.Windows.Forms.Button();
			this.button2 = new global::System.Windows.Forms.Button();
			this.groupBox1 = new global::System.Windows.Forms.GroupBox();
			this.facesSelectedLabel = new global::System.Windows.Forms.Label();
			this.label1 = new global::System.Windows.Forms.Label();
			this.groupBox2 = new global::System.Windows.Forms.GroupBox();
			this.basicSquare = new global::System.Windows.Forms.RadioButton();
			this.freehandRadio = new global::System.Windows.Forms.RadioButton();
			this.picknclickRadio = new global::System.Windows.Forms.RadioButton();
			this.groupBox3 = new global::System.Windows.Forms.GroupBox();
			this.ignorebackfaces = new global::System.Windows.Forms.CheckBox();
			this.fullyContained = new global::System.Windows.Forms.CheckBox();
			this.editGroup = new global::System.Windows.Forms.GroupBox();
			this.moveRadio = new global::System.Windows.Forms.RadioButton();
			this.rotateRadio = new global::System.Windows.Forms.RadioButton();
			this.splitButton1 = new global::SplitButtonDemo.SplitButton();
			this.contextMenuStrip1 = new global::System.Windows.Forms.ContextMenuStrip(this.icontainer_0);
			this.selectAllToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.editGroup.SuspendLayout();
			this.contextMenuStrip1.SuspendLayout();
			base.SuspendLayout();
			this.doneButton.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Right);
			this.doneButton.Location = new global::System.Drawing.Point(123, 246);
			this.doneButton.Name = "doneButton";
			this.doneButton.Size = new global::System.Drawing.Size(75, 23);
			this.doneButton.TabIndex = 0;
			this.doneButton.Text = "Done";
			this.doneButton.UseVisualStyleBackColor = true;
			this.doneButton.Click += new global::System.EventHandler(this.doneButton_Click);
			this.button2.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Right);
			this.button2.Location = new global::System.Drawing.Point(204, 246);
			this.button2.Name = "button2";
			this.button2.Size = new global::System.Drawing.Size(75, 23);
			this.button2.TabIndex = 1;
			this.button2.Text = "Cancel";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new global::System.EventHandler(this.button2_Click);
			this.groupBox1.Controls.Add(this.facesSelectedLabel);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Location = new global::System.Drawing.Point(5, 3);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new global::System.Drawing.Size(274, 60);
			this.groupBox1.TabIndex = 2;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Information";
			this.facesSelectedLabel.AutoSize = true;
			this.facesSelectedLabel.Location = new global::System.Drawing.Point(86, 27);
			this.facesSelectedLabel.Name = "facesSelectedLabel";
			this.facesSelectedLabel.Size = new global::System.Drawing.Size(13, 13);
			this.facesSelectedLabel.TabIndex = 1;
			this.facesSelectedLabel.Text = "0";
			this.label1.AutoSize = true;
			this.label1.Location = new global::System.Drawing.Point(7, 27);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(82, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Faces selected:";
			this.groupBox2.Controls.Add(this.basicSquare);
			this.groupBox2.Controls.Add(this.freehandRadio);
			this.groupBox2.Controls.Add(this.picknclickRadio);
			this.groupBox2.Location = new global::System.Drawing.Point(5, 69);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new global::System.Drawing.Size(274, 56);
			this.groupBox2.TabIndex = 3;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Tools";
			this.basicSquare.AutoSize = true;
			this.basicSquare.Location = new global::System.Drawing.Point(172, 26);
			this.basicSquare.Name = "basicSquare";
			this.basicSquare.Size = new global::System.Drawing.Size(86, 17);
			this.basicSquare.TabIndex = 2;
			this.basicSquare.Text = "Basic square";
			this.basicSquare.UseVisualStyleBackColor = true;
			this.basicSquare.Click += new global::System.EventHandler(this.basicSquare_Click);
			this.freehandRadio.AutoSize = true;
			this.freehandRadio.Location = new global::System.Drawing.Point(96, 26);
			this.freehandRadio.Name = "freehandRadio";
			this.freehandRadio.Size = new global::System.Drawing.Size(70, 17);
			this.freehandRadio.TabIndex = 1;
			this.freehandRadio.Text = "Freehand";
			this.freehandRadio.UseVisualStyleBackColor = true;
			this.freehandRadio.Click += new global::System.EventHandler(this.freehandRadio_Click);
			this.picknclickRadio.AutoSize = true;
			this.picknclickRadio.Checked = true;
			this.picknclickRadio.Location = new global::System.Drawing.Point(10, 26);
			this.picknclickRadio.Name = "picknclickRadio";
			this.picknclickRadio.Size = new global::System.Drawing.Size(80, 17);
			this.picknclickRadio.TabIndex = 0;
			this.picknclickRadio.TabStop = true;
			this.picknclickRadio.Text = "Click´n´pick";
			this.picknclickRadio.UseVisualStyleBackColor = true;
			this.picknclickRadio.Click += new global::System.EventHandler(this.picknclickRadio_Click);
			this.groupBox3.Controls.Add(this.ignorebackfaces);
			this.groupBox3.Controls.Add(this.fullyContained);
			this.groupBox3.Location = new global::System.Drawing.Point(5, 131);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new global::System.Drawing.Size(274, 56);
			this.groupBox3.TabIndex = 4;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Settings";
			this.ignorebackfaces.AutoSize = true;
			this.ignorebackfaces.Checked = true;
			this.ignorebackfaces.CheckState = global::System.Windows.Forms.CheckState.Checked;
			this.ignorebackfaces.Enabled = false;
			this.ignorebackfaces.Location = new global::System.Drawing.Point(118, 27);
			this.ignorebackfaces.Name = "ignorebackfaces";
			this.ignorebackfaces.Size = new global::System.Drawing.Size(109, 17);
			this.ignorebackfaces.TabIndex = 2;
			this.ignorebackfaces.Text = "Ignore backfaces";
			this.ignorebackfaces.UseVisualStyleBackColor = true;
			this.ignorebackfaces.Click += new global::System.EventHandler(this.ignorebackfaces_Click);
			this.fullyContained.AutoSize = true;
			this.fullyContained.Checked = true;
			this.fullyContained.CheckState = global::System.Windows.Forms.CheckState.Checked;
			this.fullyContained.Enabled = false;
			this.fullyContained.Location = new global::System.Drawing.Point(10, 27);
			this.fullyContained.Name = "fullyContained";
			this.fullyContained.Size = new global::System.Drawing.Size(97, 17);
			this.fullyContained.TabIndex = 1;
			this.fullyContained.Text = "Fully contained";
			this.fullyContained.UseVisualStyleBackColor = true;
			this.fullyContained.Click += new global::System.EventHandler(this.fullyContained_Click);
			this.editGroup.Controls.Add(this.rotateRadio);
			this.editGroup.Controls.Add(this.moveRadio);
			this.editGroup.Location = new global::System.Drawing.Point(5, 193);
			this.editGroup.Name = "editGroup";
			this.editGroup.Size = new global::System.Drawing.Size(274, 47);
			this.editGroup.TabIndex = 5;
			this.editGroup.TabStop = false;
			this.editGroup.Text = "Edit";
			this.moveRadio.AutoSize = true;
			this.moveRadio.Checked = true;
			this.moveRadio.Location = new global::System.Drawing.Point(10, 19);
			this.moveRadio.Name = "moveRadio";
			this.moveRadio.Size = new global::System.Drawing.Size(52, 17);
			this.moveRadio.TabIndex = 0;
			this.moveRadio.TabStop = true;
			this.moveRadio.Text = "Move";
			this.moveRadio.UseVisualStyleBackColor = true;
			this.rotateRadio.AutoSize = true;
			this.rotateRadio.Location = new global::System.Drawing.Point(68, 19);
			this.rotateRadio.Name = "rotateRadio";
			this.rotateRadio.Size = new global::System.Drawing.Size(57, 17);
			this.rotateRadio.TabIndex = 1;
			this.rotateRadio.Text = "Rotate";
			this.rotateRadio.UseVisualStyleBackColor = true;
			this.splitButton1.ClickedImage = "Clicked";
			this.splitButton1.ContextMenuStrip = this.contextMenuStrip1;
			this.splitButton1.DisabledImage = "Disabled";
			this.splitButton1.FocusedImage = "Focused";
			this.splitButton1.HoverImage = "Hover";
			this.splitButton1.ImageAlign = global::System.Drawing.ContentAlignment.MiddleRight;
			this.splitButton1.ImageKey = "Normal";
			this.splitButton1.Location = new global::System.Drawing.Point(5, 246);
			this.splitButton1.Name = "splitButton1";
			this.splitButton1.NormalImage = "Normal";
			this.splitButton1.Size = new global::System.Drawing.Size(62, 23);
			this.splitButton1.TabIndex = 6;
			this.splitButton1.Text = "Clear";
			this.splitButton1.TextAlign = global::System.Drawing.ContentAlignment.MiddleLeft;
			this.splitButton1.UseVisualStyleBackColor = true;
			this.splitButton1.ButtonClick += new global::System.EventHandler(this.method_2);
			this.contextMenuStrip1.Items.AddRange(new global::System.Windows.Forms.ToolStripItem[]
			{
				this.selectAllToolStripMenuItem
			});
			this.contextMenuStrip1.Name = "contextMenuStrip1";
			this.contextMenuStrip1.Size = new global::System.Drawing.Size(153, 48);
			this.selectAllToolStripMenuItem.Name = "selectAllToolStripMenuItem";
			this.selectAllToolStripMenuItem.Size = new global::System.Drawing.Size(152, 22);
			this.selectAllToolStripMenuItem.Text = "Select All";
			this.selectAllToolStripMenuItem.Click += new global::System.EventHandler(this.selectAllToolStripMenuItem_Click);
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new global::System.Drawing.Size(284, 274);
			base.ControlBox = false;
			base.Controls.Add(this.splitButton1);
			base.Controls.Add(this.editGroup);
			base.Controls.Add(this.groupBox3);
			base.Controls.Add(this.groupBox2);
			base.Controls.Add(this.groupBox1);
			base.Controls.Add(this.button2);
			base.Controls.Add(this.doneButton);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.SizableToolWindow;
			base.Name = "GeostateSelector";
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Face Selector";
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			this.editGroup.ResumeLayout(false);
			this.editGroup.PerformLayout();
			this.contextMenuStrip1.ResumeLayout(false);
			base.ResumeLayout(false);
		}

		// Token: 0x04000208 RID: 520
		private global::System.ComponentModel.IContainer icontainer_0;

		// Token: 0x04000209 RID: 521
		private global::System.Windows.Forms.Button doneButton;

		// Token: 0x0400020A RID: 522
		private global::System.Windows.Forms.Button button2;

		// Token: 0x0400020B RID: 523
		private global::System.Windows.Forms.GroupBox groupBox1;

		// Token: 0x0400020C RID: 524
		private global::System.Windows.Forms.GroupBox groupBox2;

		// Token: 0x0400020D RID: 525
		private global::System.Windows.Forms.Label facesSelectedLabel;

		// Token: 0x0400020E RID: 526
		private global::System.Windows.Forms.Label label1;

		// Token: 0x0400020F RID: 527
		private global::System.Windows.Forms.RadioButton picknclickRadio;

		// Token: 0x04000210 RID: 528
		private global::System.Windows.Forms.RadioButton freehandRadio;

		// Token: 0x04000211 RID: 529
		private global::System.Windows.Forms.RadioButton basicSquare;

		// Token: 0x04000212 RID: 530
		private global::System.Windows.Forms.GroupBox groupBox3;

		// Token: 0x04000213 RID: 531
		private global::System.Windows.Forms.CheckBox fullyContained;

		// Token: 0x04000214 RID: 532
		private global::System.Windows.Forms.CheckBox ignorebackfaces;

		// Token: 0x04000215 RID: 533
		private global::System.Windows.Forms.GroupBox editGroup;

		// Token: 0x04000216 RID: 534
		private global::System.Windows.Forms.RadioButton rotateRadio;

		// Token: 0x04000217 RID: 535
		private global::System.Windows.Forms.RadioButton moveRadio;

		// Token: 0x04000218 RID: 536
		private global::SplitButtonDemo.SplitButton splitButton1;

		// Token: 0x04000219 RID: 537
		private global::System.Windows.Forms.ContextMenuStrip contextMenuStrip1;

		// Token: 0x0400021A RID: 538
		private global::System.Windows.Forms.ToolStripMenuItem selectAllToolStripMenuItem;
	}
}
