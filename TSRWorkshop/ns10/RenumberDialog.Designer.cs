namespace ns10
{
	// Token: 0x0200004C RID: 76
	internal sealed partial class RenumberDialog : global::System.Windows.Forms.Form
	{
		// Token: 0x06000301 RID: 769 RVA: 0x00038D4C File Offset: 0x00036F4C
		private void InitializeComponent()
		{
			this.doGroup = new global::System.Windows.Forms.CheckBox();
			this.group = new global::System.Windows.Forms.TextBox();
			this.iId = new global::System.Windows.Forms.TextBox();
			this.doIId = new global::System.Windows.Forms.CheckBox();
			this.iId2 = new global::System.Windows.Forms.TextBox();
			this.doIId2 = new global::System.Windows.Forms.CheckBox();
			this.btnRandom = new global::System.Windows.Forms.Button();
			this.btnOk = new global::System.Windows.Forms.Button();
			this.btnCancel = new global::System.Windows.Forms.Button();
			this.update = new global::System.Windows.Forms.CheckBox();
			base.SuspendLayout();
			this.doGroup.AutoSize = true;
			this.doGroup.Location = new global::System.Drawing.Point(14, 15);
			this.doGroup.Name = "doGroup";
			this.doGroup.Size = new global::System.Drawing.Size(67, 17);
			this.doGroup.TabIndex = 0;
			this.doGroup.Text = "Group Id";
			this.doGroup.UseVisualStyleBackColor = true;
			this.doGroup.CheckedChanged += new global::System.EventHandler(this.doGroup_CheckedChanged);
			this.group.Enabled = false;
			this.group.Location = new global::System.Drawing.Point(140, 13);
			this.group.Name = "group";
			this.group.Size = new global::System.Drawing.Size(124, 20);
			this.group.TabIndex = 1;
			this.group.Text = "0x00000000";
			this.iId.Enabled = false;
			this.iId.Location = new global::System.Drawing.Point(140, 36);
			this.iId.Name = "iId";
			this.iId.Size = new global::System.Drawing.Size(124, 20);
			this.iId.TabIndex = 3;
			this.iId.Text = "0x00000000";
			this.doIId.AutoSize = true;
			this.doIId.Location = new global::System.Drawing.Point(14, 38);
			this.doIId.Name = "doIId";
			this.doIId.Size = new global::System.Drawing.Size(79, 17);
			this.doIId.TabIndex = 2;
			this.doIId.Text = "Instance Id";
			this.doIId.UseVisualStyleBackColor = true;
			this.doIId.CheckedChanged += new global::System.EventHandler(this.doIId_CheckedChanged);
			this.iId2.Enabled = false;
			this.iId2.Location = new global::System.Drawing.Point(140, 59);
			this.iId2.Name = "iId2";
			this.iId2.Size = new global::System.Drawing.Size(124, 20);
			this.iId2.TabIndex = 5;
			this.iId2.Text = "0x00000000";
			this.doIId2.AutoSize = true;
			this.doIId2.Location = new global::System.Drawing.Point(14, 61);
			this.doIId2.Name = "doIId2";
			this.doIId2.Size = new global::System.Drawing.Size(119, 17);
			this.doIId2.TabIndex = 4;
			this.doIId2.Text = "Second Instance Id";
			this.doIId2.UseVisualStyleBackColor = true;
			this.doIId2.CheckedChanged += new global::System.EventHandler(this.doIId2_CheckedChanged);
			this.btnRandom.Enabled = false;
			this.btnRandom.Location = new global::System.Drawing.Point(172, 85);
			this.btnRandom.Name = "btnRandom";
			this.btnRandom.Size = new global::System.Drawing.Size(92, 23);
			this.btnRandom.TabIndex = 6;
			this.btnRandom.Text = "Make random";
			this.btnRandom.UseVisualStyleBackColor = true;
			this.btnRandom.Click += new global::System.EventHandler(this.btnRandom_Click);
			this.btnOk.Location = new global::System.Drawing.Point(77, 142);
			this.btnOk.Name = "btnOk";
			this.btnOk.Size = new global::System.Drawing.Size(92, 23);
			this.btnOk.TabIndex = 7;
			this.btnOk.Text = "OK";
			this.btnOk.UseVisualStyleBackColor = true;
			this.btnOk.Click += new global::System.EventHandler(this.btnOk_Click);
			this.btnCancel.DialogResult = global::System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new global::System.Drawing.Point(175, 142);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new global::System.Drawing.Size(92, 23);
			this.btnCancel.TabIndex = 8;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new global::System.EventHandler(this.btnCancel_Click);
			this.update.AutoSize = true;
			this.update.Checked = true;
			this.update.CheckState = global::System.Windows.Forms.CheckState.Checked;
			this.update.Location = new global::System.Drawing.Point(14, 90);
			this.update.Name = "update";
			this.update.Size = new global::System.Drawing.Size(114, 17);
			this.update.TabIndex = 9;
			this.update.Text = "Update references";
			this.update.UseVisualStyleBackColor = true;
			base.AcceptButton = this.btnOk;
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.CancelButton = this.btnCancel;
			base.ClientSize = new global::System.Drawing.Size(279, 175);
			base.Controls.Add(this.update);
			base.Controls.Add(this.btnCancel);
			base.Controls.Add(this.btnOk);
			base.Controls.Add(this.btnRandom);
			base.Controls.Add(this.iId2);
			base.Controls.Add(this.doIId2);
			base.Controls.Add(this.iId);
			base.Controls.Add(this.doIId);
			base.Controls.Add(this.group);
			base.Controls.Add(this.doGroup);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			base.Name = "RenumberDialog";
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Renumber";
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x040002A7 RID: 679
		private global::System.Windows.Forms.Button btnRandom;

		// Token: 0x040002A8 RID: 680
		private global::System.Windows.Forms.Button btnOk;

		// Token: 0x040002A9 RID: 681
		private global::System.Windows.Forms.Button btnCancel;

		// Token: 0x040002AA RID: 682
		public global::System.Windows.Forms.CheckBox doGroup;

		// Token: 0x040002AB RID: 683
		public global::System.Windows.Forms.TextBox group;

		// Token: 0x040002AC RID: 684
		public global::System.Windows.Forms.TextBox iId;

		// Token: 0x040002AD RID: 685
		public global::System.Windows.Forms.CheckBox doIId;

		// Token: 0x040002AE RID: 686
		public global::System.Windows.Forms.TextBox iId2;

		// Token: 0x040002AF RID: 687
		public global::System.Windows.Forms.CheckBox doIId2;

		// Token: 0x040002B0 RID: 688
		public global::System.Windows.Forms.CheckBox update;
	}
}
