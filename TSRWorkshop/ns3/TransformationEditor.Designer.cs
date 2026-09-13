namespace ns3
{
	// Token: 0x02000062 RID: 98
	internal sealed partial class TransformationEditor : global::System.Windows.Forms.Form
	{
		// Token: 0x060003CF RID: 975 RVA: 0x000459BC File Offset: 0x00043BBC
		private void InitializeComponent()
		{
			this.cancelButton = new global::System.Windows.Forms.Button();
			this.okButton = new global::System.Windows.Forms.Button();
			this.button1 = new global::System.Windows.Forms.Button();
			this.groupBox1 = new global::System.Windows.Forms.GroupBox();
			this.label3 = new global::System.Windows.Forms.Label();
			this.label2 = new global::System.Windows.Forms.Label();
			this.label1 = new global::System.Windows.Forms.Label();
			this.tZ = new global::System.Windows.Forms.TextBox();
			this.tY = new global::System.Windows.Forms.TextBox();
			this.tX = new global::System.Windows.Forms.TextBox();
			this.quatX = new global::System.Windows.Forms.TextBox();
			this.quatY = new global::System.Windows.Forms.TextBox();
			this.quatZ = new global::System.Windows.Forms.TextBox();
			this.label7 = new global::System.Windows.Forms.Label();
			this.label6 = new global::System.Windows.Forms.Label();
			this.label5 = new global::System.Windows.Forms.Label();
			this.groupBox2 = new global::System.Windows.Forms.GroupBox();
			this.label4 = new global::System.Windows.Forms.Label();
			this.quatW = new global::System.Windows.Forms.TextBox();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			base.SuspendLayout();
			this.cancelButton.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Right);
			this.cancelButton.Location = new global::System.Drawing.Point(269, 170);
			this.cancelButton.Name = "cancelButton";
			this.cancelButton.Size = new global::System.Drawing.Size(75, 23);
			this.cancelButton.TabIndex = 6;
			this.cancelButton.Text = "Cancel";
			this.cancelButton.UseVisualStyleBackColor = true;
			this.cancelButton.Click += new global::System.EventHandler(this.cancelButton_Click);
			this.okButton.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Right);
			this.okButton.Location = new global::System.Drawing.Point(188, 170);
			this.okButton.Name = "okButton";
			this.okButton.Size = new global::System.Drawing.Size(75, 23);
			this.okButton.TabIndex = 7;
			this.okButton.Text = "OK";
			this.okButton.UseVisualStyleBackColor = true;
			this.okButton.Click += new global::System.EventHandler(this.okButton_Click);
			this.button1.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left);
			this.button1.Location = new global::System.Drawing.Point(11, 170);
			this.button1.Name = "button1";
			this.button1.Size = new global::System.Drawing.Size(75, 23);
			this.button1.TabIndex = 14;
			this.button1.Text = "Reset";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new global::System.EventHandler(this.button1_Click);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.tZ);
			this.groupBox1.Controls.Add(this.tY);
			this.groupBox1.Controls.Add(this.tX);
			this.groupBox1.Location = new global::System.Drawing.Point(11, 3);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new global::System.Drawing.Size(333, 71);
			this.groupBox1.TabIndex = 15;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Position";
			this.label3.AutoSize = true;
			this.label3.Location = new global::System.Drawing.Point(227, 26);
			this.label3.Name = "label3";
			this.label3.Size = new global::System.Drawing.Size(72, 13);
			this.label3.TabIndex = 22;
			this.label3.Text = "Translation Z:";
			this.label2.AutoSize = true;
			this.label2.Location = new global::System.Drawing.Point(117, 26);
			this.label2.Name = "label2";
			this.label2.Size = new global::System.Drawing.Size(72, 13);
			this.label2.TabIndex = 21;
			this.label2.Text = "Translation Y:";
			this.label1.AutoSize = true;
			this.label1.Location = new global::System.Drawing.Point(8, 26);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(72, 13);
			this.label1.TabIndex = 20;
			this.label1.Text = "Translation X:";
			this.tZ.Location = new global::System.Drawing.Point(229, 40);
			this.tZ.Name = "tZ";
			this.tZ.Size = new global::System.Drawing.Size(93, 20);
			this.tZ.TabIndex = 19;
			this.tZ.Text = "0";
			this.tZ.TextChanged += new global::System.EventHandler(this.quatW_TextChanged);
			this.tY.Location = new global::System.Drawing.Point(120, 40);
			this.tY.Name = "tY";
			this.tY.Size = new global::System.Drawing.Size(93, 20);
			this.tY.TabIndex = 18;
			this.tY.Text = "0";
			this.tY.TextChanged += new global::System.EventHandler(this.quatW_TextChanged);
			this.tX.Location = new global::System.Drawing.Point(11, 40);
			this.tX.Name = "tX";
			this.tX.Size = new global::System.Drawing.Size(93, 20);
			this.tX.TabIndex = 17;
			this.tX.Text = "0";
			this.tX.TextChanged += new global::System.EventHandler(this.quatW_TextChanged);
			this.quatX.Location = new global::System.Drawing.Point(11, 40);
			this.quatX.Name = "quatX";
			this.quatX.Size = new global::System.Drawing.Size(70, 20);
			this.quatX.TabIndex = 17;
			this.quatX.Text = "0";
			this.quatX.TextChanged += new global::System.EventHandler(this.quatW_TextChanged);
			this.quatY.Location = new global::System.Drawing.Point(89, 40);
			this.quatY.Name = "quatY";
			this.quatY.Size = new global::System.Drawing.Size(70, 20);
			this.quatY.TabIndex = 18;
			this.quatY.Text = "0";
			this.quatY.TextChanged += new global::System.EventHandler(this.quatW_TextChanged);
			this.quatZ.Location = new global::System.Drawing.Point(169, 40);
			this.quatZ.Name = "quatZ";
			this.quatZ.Size = new global::System.Drawing.Size(70, 20);
			this.quatZ.TabIndex = 19;
			this.quatZ.Text = "0";
			this.quatZ.TextChanged += new global::System.EventHandler(this.quatW_TextChanged);
			this.label7.AutoSize = true;
			this.label7.Location = new global::System.Drawing.Point(8, 26);
			this.label7.Name = "label7";
			this.label7.Size = new global::System.Drawing.Size(43, 13);
			this.label7.TabIndex = 20;
			this.label7.Text = "Quat X:";
			this.label6.AutoSize = true;
			this.label6.Location = new global::System.Drawing.Point(86, 26);
			this.label6.Name = "label6";
			this.label6.Size = new global::System.Drawing.Size(43, 13);
			this.label6.TabIndex = 21;
			this.label6.Text = "Quat Y:";
			this.label5.AutoSize = true;
			this.label5.Location = new global::System.Drawing.Point(167, 26);
			this.label5.Name = "label5";
			this.label5.Size = new global::System.Drawing.Size(43, 13);
			this.label5.TabIndex = 22;
			this.label5.Text = "Quat Z:";
			this.groupBox2.Controls.Add(this.label4);
			this.groupBox2.Controls.Add(this.quatW);
			this.groupBox2.Controls.Add(this.label5);
			this.groupBox2.Controls.Add(this.label6);
			this.groupBox2.Controls.Add(this.label7);
			this.groupBox2.Controls.Add(this.quatZ);
			this.groupBox2.Controls.Add(this.quatY);
			this.groupBox2.Controls.Add(this.quatX);
			this.groupBox2.Location = new global::System.Drawing.Point(12, 83);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new global::System.Drawing.Size(332, 71);
			this.groupBox2.TabIndex = 23;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Position";
			this.label4.AutoSize = true;
			this.label4.Location = new global::System.Drawing.Point(249, 26);
			this.label4.Name = "label4";
			this.label4.Size = new global::System.Drawing.Size(47, 13);
			this.label4.TabIndex = 24;
			this.label4.Text = "Quat W:";
			this.quatW.Location = new global::System.Drawing.Point(251, 40);
			this.quatW.Name = "quatW";
			this.quatW.Size = new global::System.Drawing.Size(70, 20);
			this.quatW.TabIndex = 23;
			this.quatW.Text = "0";
			this.quatW.TextChanged += new global::System.EventHandler(this.quatW_TextChanged);
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new global::System.Drawing.Size(356, 198);
			base.Controls.Add(this.groupBox2);
			base.Controls.Add(this.groupBox1);
			base.Controls.Add(this.button1);
			base.Controls.Add(this.okButton);
			base.Controls.Add(this.cancelButton);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			base.Name = "TransformationEditor";
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Transformation Editor";
			base.Load += new global::System.EventHandler(this.TransformationEditor_Load);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			base.ResumeLayout(false);
		}

		// Token: 0x040003B3 RID: 947
		private global::System.Windows.Forms.Button cancelButton;

		// Token: 0x040003B4 RID: 948
		private global::System.Windows.Forms.Button okButton;

		// Token: 0x040003B5 RID: 949
		private global::System.Windows.Forms.Button button1;

		// Token: 0x040003B6 RID: 950
		private global::System.Windows.Forms.GroupBox groupBox1;

		// Token: 0x040003B7 RID: 951
		private global::System.Windows.Forms.Label label3;

		// Token: 0x040003B8 RID: 952
		private global::System.Windows.Forms.Label label2;

		// Token: 0x040003B9 RID: 953
		private global::System.Windows.Forms.Label label1;

		// Token: 0x040003BA RID: 954
		private global::System.Windows.Forms.TextBox tZ;

		// Token: 0x040003BB RID: 955
		private global::System.Windows.Forms.TextBox tY;

		// Token: 0x040003BC RID: 956
		private global::System.Windows.Forms.TextBox tX;

		// Token: 0x040003BD RID: 957
		private global::System.Windows.Forms.TextBox quatX;

		// Token: 0x040003BE RID: 958
		private global::System.Windows.Forms.TextBox quatY;

		// Token: 0x040003BF RID: 959
		private global::System.Windows.Forms.TextBox quatZ;

		// Token: 0x040003C0 RID: 960
		private global::System.Windows.Forms.Label label7;

		// Token: 0x040003C1 RID: 961
		private global::System.Windows.Forms.Label label6;

		// Token: 0x040003C2 RID: 962
		private global::System.Windows.Forms.Label label5;

		// Token: 0x040003C3 RID: 963
		private global::System.Windows.Forms.GroupBox groupBox2;

		// Token: 0x040003C4 RID: 964
		private global::System.Windows.Forms.Label label4;

		// Token: 0x040003C5 RID: 965
		private global::System.Windows.Forms.TextBox quatW;
	}
}
