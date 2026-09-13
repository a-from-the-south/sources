namespace ns20
{
	// Token: 0x02000061 RID: 97
	internal sealed partial class SlotEditor : global::System.Windows.Forms.Form
	{
		// Token: 0x060003C4 RID: 964 RVA: 0x00044B20 File Offset: 0x00042D20
		private void InitializeComponent()
		{
			this.cancelButton = new global::System.Windows.Forms.Button();
			this.okButton = new global::System.Windows.Forms.Button();
			this.flx = new global::System.Windows.Forms.TextBox();
			this.flz = new global::System.Windows.Forms.TextBox();
			this.nlz = new global::System.Windows.Forms.TextBox();
			this.nlx = new global::System.Windows.Forms.TextBox();
			this.nrz = new global::System.Windows.Forms.TextBox();
			this.nrx = new global::System.Windows.Forms.TextBox();
			this.frz = new global::System.Windows.Forms.TextBox();
			this.frx = new global::System.Windows.Forms.TextBox();
			this.label1 = new global::System.Windows.Forms.Label();
			this.label2 = new global::System.Windows.Forms.Label();
			this.label3 = new global::System.Windows.Forms.Label();
			this.label4 = new global::System.Windows.Forms.Label();
			this.label5 = new global::System.Windows.Forms.Label();
			this.asd = new global::System.Windows.Forms.Label();
			this.label7 = new global::System.Windows.Forms.Label();
			this.label8 = new global::System.Windows.Forms.Label();
			this.groupBox1 = new global::System.Windows.Forms.GroupBox();
			this.offsetX = new global::System.Windows.Forms.TextBox();
			this.offsetZ = new global::System.Windows.Forms.TextBox();
			this.label6 = new global::System.Windows.Forms.Label();
			this.label9 = new global::System.Windows.Forms.Label();
			this.groupBox1.SuspendLayout();
			base.SuspendLayout();
			this.cancelButton.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Right);
			this.cancelButton.Location = new global::System.Drawing.Point(248, 293);
			this.cancelButton.Name = "cancelButton";
			this.cancelButton.Size = new global::System.Drawing.Size(75, 23);
			this.cancelButton.TabIndex = 0;
			this.cancelButton.Text = "Cancel";
			this.cancelButton.UseVisualStyleBackColor = true;
			this.cancelButton.Click += new global::System.EventHandler(this.cancelButton_Click);
			this.okButton.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Right);
			this.okButton.Location = new global::System.Drawing.Point(167, 293);
			this.okButton.Name = "okButton";
			this.okButton.Size = new global::System.Drawing.Size(75, 23);
			this.okButton.TabIndex = 1;
			this.okButton.Text = "OK";
			this.okButton.UseVisualStyleBackColor = true;
			this.okButton.Click += new global::System.EventHandler(this.okButton_Click);
			this.flx.Location = new global::System.Drawing.Point(12, 27);
			this.flx.Name = "flx";
			this.flx.Size = new global::System.Drawing.Size(149, 20);
			this.flx.TabIndex = 2;
			this.flx.TextChanged += new global::System.EventHandler(this.flx_TextChanged);
			this.flz.Location = new global::System.Drawing.Point(167, 27);
			this.flz.Name = "flz";
			this.flz.Size = new global::System.Drawing.Size(156, 20);
			this.flz.TabIndex = 3;
			this.nlz.Location = new global::System.Drawing.Point(167, 73);
			this.nlz.Name = "nlz";
			this.nlz.Size = new global::System.Drawing.Size(156, 20);
			this.nlz.TabIndex = 5;
			this.nlx.Location = new global::System.Drawing.Point(12, 73);
			this.nlx.Name = "nlx";
			this.nlx.Size = new global::System.Drawing.Size(149, 20);
			this.nlx.TabIndex = 4;
			this.nrz.Location = new global::System.Drawing.Point(167, 119);
			this.nrz.Name = "nrz";
			this.nrz.Size = new global::System.Drawing.Size(156, 20);
			this.nrz.TabIndex = 7;
			this.nrx.Location = new global::System.Drawing.Point(12, 119);
			this.nrx.Name = "nrx";
			this.nrx.Size = new global::System.Drawing.Size(149, 20);
			this.nrx.TabIndex = 6;
			this.frz.Location = new global::System.Drawing.Point(167, 166);
			this.frz.Name = "frz";
			this.frz.Size = new global::System.Drawing.Size(156, 20);
			this.frz.TabIndex = 9;
			this.frx.Location = new global::System.Drawing.Point(12, 166);
			this.frx.Name = "frx";
			this.frx.Size = new global::System.Drawing.Size(149, 20);
			this.frx.TabIndex = 8;
			this.label1.AutoSize = true;
			this.label1.Location = new global::System.Drawing.Point(12, 11);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(58, 13);
			this.label1.TabIndex = 10;
			this.label1.Text = "Far right X:";
			this.label2.AutoSize = true;
			this.label2.Location = new global::System.Drawing.Point(164, 11);
			this.label2.Name = "label2";
			this.label2.Size = new global::System.Drawing.Size(58, 13);
			this.label2.TabIndex = 11;
			this.label2.Text = "Far right Z:";
			this.label3.AutoSize = true;
			this.label3.Location = new global::System.Drawing.Point(12, 57);
			this.label3.Name = "label3";
			this.label3.Size = new global::System.Drawing.Size(66, 13);
			this.label3.TabIndex = 12;
			this.label3.Text = "Near right X:";
			this.label4.AutoSize = true;
			this.label4.Location = new global::System.Drawing.Point(12, 103);
			this.label4.Name = "label4";
			this.label4.Size = new global::System.Drawing.Size(60, 13);
			this.label4.TabIndex = 13;
			this.label4.Text = "Near left X:";
			this.label5.AutoSize = true;
			this.label5.Location = new global::System.Drawing.Point(12, 150);
			this.label5.Name = "label5";
			this.label5.Size = new global::System.Drawing.Size(52, 13);
			this.label5.TabIndex = 14;
			this.label5.Text = "Far left X:";
			this.asd.AutoSize = true;
			this.asd.Location = new global::System.Drawing.Point(164, 57);
			this.asd.Name = "asd";
			this.asd.Size = new global::System.Drawing.Size(66, 13);
			this.asd.TabIndex = 15;
			this.asd.Text = "Near right Z:";
			this.label7.AutoSize = true;
			this.label7.Location = new global::System.Drawing.Point(164, 103);
			this.label7.Name = "label7";
			this.label7.Size = new global::System.Drawing.Size(60, 13);
			this.label7.TabIndex = 16;
			this.label7.Text = "Near left Z:";
			this.label8.AutoSize = true;
			this.label8.Location = new global::System.Drawing.Point(164, 150);
			this.label8.Name = "label8";
			this.label8.Size = new global::System.Drawing.Size(52, 13);
			this.label8.TabIndex = 17;
			this.label8.Text = "Far left Z:";
			this.groupBox1.Controls.Add(this.label9);
			this.groupBox1.Controls.Add(this.label6);
			this.groupBox1.Controls.Add(this.offsetZ);
			this.groupBox1.Controls.Add(this.offsetX);
			this.groupBox1.Location = new global::System.Drawing.Point(12, 201);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new global::System.Drawing.Size(311, 82);
			this.groupBox1.TabIndex = 18;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Offset";
			this.offsetX.Location = new global::System.Drawing.Point(15, 44);
			this.offsetX.Name = "offsetX";
			this.offsetX.Size = new global::System.Drawing.Size(134, 20);
			this.offsetX.TabIndex = 0;
			this.offsetX.Text = "0";
			this.offsetX.TextChanged += new global::System.EventHandler(this.offsetZ_TextChanged);
			this.offsetZ.Location = new global::System.Drawing.Point(155, 44);
			this.offsetZ.Name = "offsetZ";
			this.offsetZ.Size = new global::System.Drawing.Size(134, 20);
			this.offsetZ.TabIndex = 1;
			this.offsetZ.Text = "0";
			this.offsetZ.TextChanged += new global::System.EventHandler(this.offsetZ_TextChanged);
			this.label6.AutoSize = true;
			this.label6.Location = new global::System.Drawing.Point(14, 28);
			this.label6.Name = "label6";
			this.label6.Size = new global::System.Drawing.Size(17, 13);
			this.label6.TabIndex = 19;
			this.label6.Text = "X:";
			this.label9.AutoSize = true;
			this.label9.Location = new global::System.Drawing.Point(152, 28);
			this.label9.Name = "label9";
			this.label9.Size = new global::System.Drawing.Size(17, 13);
			this.label9.TabIndex = 20;
			this.label9.Text = "Z:";
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new global::System.Drawing.Size(334, 328);
			base.ControlBox = false;
			base.Controls.Add(this.groupBox1);
			base.Controls.Add(this.label8);
			base.Controls.Add(this.label7);
			base.Controls.Add(this.asd);
			base.Controls.Add(this.label5);
			base.Controls.Add(this.label4);
			base.Controls.Add(this.label3);
			base.Controls.Add(this.label2);
			base.Controls.Add(this.label1);
			base.Controls.Add(this.frz);
			base.Controls.Add(this.frx);
			base.Controls.Add(this.nrz);
			base.Controls.Add(this.nrx);
			base.Controls.Add(this.nlz);
			base.Controls.Add(this.nlx);
			base.Controls.Add(this.flz);
			base.Controls.Add(this.flx);
			base.Controls.Add(this.okButton);
			base.Controls.Add(this.cancelButton);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			base.Name = "SlotEditor";
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Slot Editor";
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x0400038C RID: 908
		private global::System.Windows.Forms.Button cancelButton;

		// Token: 0x0400038D RID: 909
		private global::System.Windows.Forms.Button okButton;

		// Token: 0x0400038E RID: 910
		private global::System.Windows.Forms.TextBox flx;

		// Token: 0x0400038F RID: 911
		private global::System.Windows.Forms.TextBox flz;

		// Token: 0x04000390 RID: 912
		private global::System.Windows.Forms.TextBox nlz;

		// Token: 0x04000391 RID: 913
		private global::System.Windows.Forms.TextBox nlx;

		// Token: 0x04000392 RID: 914
		private global::System.Windows.Forms.TextBox nrz;

		// Token: 0x04000393 RID: 915
		private global::System.Windows.Forms.TextBox nrx;

		// Token: 0x04000394 RID: 916
		private global::System.Windows.Forms.TextBox frz;

		// Token: 0x04000395 RID: 917
		private global::System.Windows.Forms.TextBox frx;

		// Token: 0x04000396 RID: 918
		private global::System.Windows.Forms.Label label1;

		// Token: 0x04000397 RID: 919
		private global::System.Windows.Forms.Label label2;

		// Token: 0x04000398 RID: 920
		private global::System.Windows.Forms.Label label3;

		// Token: 0x04000399 RID: 921
		private global::System.Windows.Forms.Label label4;

		// Token: 0x0400039A RID: 922
		private global::System.Windows.Forms.Label label5;

		// Token: 0x0400039B RID: 923
		private global::System.Windows.Forms.Label asd;

		// Token: 0x0400039C RID: 924
		private global::System.Windows.Forms.Label label7;

		// Token: 0x0400039D RID: 925
		private global::System.Windows.Forms.Label label8;

		// Token: 0x0400039E RID: 926
		private global::System.Windows.Forms.GroupBox groupBox1;

		// Token: 0x0400039F RID: 927
		private global::System.Windows.Forms.Label label9;

		// Token: 0x040003A0 RID: 928
		private global::System.Windows.Forms.Label label6;

		// Token: 0x040003A1 RID: 929
		private global::System.Windows.Forms.TextBox offsetZ;

		// Token: 0x040003A2 RID: 930
		private global::System.Windows.Forms.TextBox offsetX;
	}
}
