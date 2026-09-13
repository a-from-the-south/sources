namespace ns20
{
	// Token: 0x020000E2 RID: 226
	internal sealed partial class PositionToMatrix : global::System.Windows.Forms.Form
	{
		// Token: 0x06000950 RID: 2384 RVA: 0x00080A20 File Offset: 0x0007EC20
		private void InitializeComponent()
		{
			this.cancelButton = new global::System.Windows.Forms.Button();
			this.okButton = new global::System.Windows.Forms.Button();
			this.groupBox1 = new global::System.Windows.Forms.GroupBox();
			this.zValue = new global::System.Windows.Forms.TextBox();
			this.label3 = new global::System.Windows.Forms.Label();
			this.yValue = new global::System.Windows.Forms.TextBox();
			this.label2 = new global::System.Windows.Forms.Label();
			this.xValue = new global::System.Windows.Forms.TextBox();
			this.label1 = new global::System.Windows.Forms.Label();
			this.groupBox2 = new global::System.Windows.Forms.GroupBox();
			this.rotZ = new global::System.Windows.Forms.TextBox();
			this.label4 = new global::System.Windows.Forms.Label();
			this.rotY = new global::System.Windows.Forms.TextBox();
			this.label5 = new global::System.Windows.Forms.Label();
			this.rotX = new global::System.Windows.Forms.TextBox();
			this.label6 = new global::System.Windows.Forms.Label();
			this.rotW = new global::System.Windows.Forms.TextBox();
			this.label7 = new global::System.Windows.Forms.Label();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			base.SuspendLayout();
			this.cancelButton.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Right);
			this.cancelButton.Location = new global::System.Drawing.Point(351, 183);
			this.cancelButton.Name = "cancelButton";
			this.cancelButton.Size = new global::System.Drawing.Size(75, 23);
			this.cancelButton.TabIndex = 0;
			this.cancelButton.Text = "Cancel";
			this.cancelButton.UseVisualStyleBackColor = true;
			this.cancelButton.Click += new global::System.EventHandler(this.cancelButton_Click);
			this.okButton.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Right);
			this.okButton.Location = new global::System.Drawing.Point(270, 183);
			this.okButton.Name = "okButton";
			this.okButton.Size = new global::System.Drawing.Size(75, 23);
			this.okButton.TabIndex = 1;
			this.okButton.Text = "OK";
			this.okButton.UseVisualStyleBackColor = true;
			this.okButton.Click += new global::System.EventHandler(this.okButton_Click);
			this.groupBox1.Controls.Add(this.zValue);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.yValue);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.xValue);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Location = new global::System.Drawing.Point(14, 15);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new global::System.Drawing.Size(412, 76);
			this.groupBox1.TabIndex = 2;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Translation";
			this.zValue.Location = new global::System.Drawing.Point(264, 42);
			this.zValue.Name = "zValue";
			this.zValue.Size = new global::System.Drawing.Size(115, 20);
			this.zValue.TabIndex = 15;
			this.label3.AutoSize = true;
			this.label3.Location = new global::System.Drawing.Point(264, 26);
			this.label3.Name = "label3";
			this.label3.Size = new global::System.Drawing.Size(17, 13);
			this.label3.TabIndex = 14;
			this.label3.Text = "Z:";
			this.yValue.Location = new global::System.Drawing.Point(143, 42);
			this.yValue.Name = "yValue";
			this.yValue.Size = new global::System.Drawing.Size(115, 20);
			this.yValue.TabIndex = 13;
			this.label2.AutoSize = true;
			this.label2.Location = new global::System.Drawing.Point(143, 26);
			this.label2.Name = "label2";
			this.label2.Size = new global::System.Drawing.Size(17, 13);
			this.label2.TabIndex = 12;
			this.label2.Text = "Y:";
			this.xValue.Location = new global::System.Drawing.Point(22, 42);
			this.xValue.Name = "xValue";
			this.xValue.Size = new global::System.Drawing.Size(115, 20);
			this.xValue.TabIndex = 11;
			this.label1.AutoSize = true;
			this.label1.Location = new global::System.Drawing.Point(22, 26);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(17, 13);
			this.label1.TabIndex = 10;
			this.label1.Text = "X:";
			this.groupBox2.Controls.Add(this.rotW);
			this.groupBox2.Controls.Add(this.label7);
			this.groupBox2.Controls.Add(this.rotZ);
			this.groupBox2.Controls.Add(this.label4);
			this.groupBox2.Controls.Add(this.rotY);
			this.groupBox2.Controls.Add(this.label5);
			this.groupBox2.Controls.Add(this.rotX);
			this.groupBox2.Controls.Add(this.label6);
			this.groupBox2.Location = new global::System.Drawing.Point(14, 97);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new global::System.Drawing.Size(412, 76);
			this.groupBox2.TabIndex = 16;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Rotation";
			this.rotZ.Location = new global::System.Drawing.Point(199, 42);
			this.rotZ.Name = "rotZ";
			this.rotZ.Size = new global::System.Drawing.Size(88, 20);
			this.rotZ.TabIndex = 15;
			this.rotZ.TextChanged += new global::System.EventHandler(this.rotZ_TextChanged);
			this.label4.AutoSize = true;
			this.label4.Location = new global::System.Drawing.Point(199, 26);
			this.label4.Name = "label4";
			this.label4.Size = new global::System.Drawing.Size(17, 13);
			this.label4.TabIndex = 14;
			this.label4.Text = "Z:";
			this.label4.Click += new global::System.EventHandler(this.label4_Click);
			this.rotY.Location = new global::System.Drawing.Point(112, 42);
			this.rotY.Name = "rotY";
			this.rotY.Size = new global::System.Drawing.Size(81, 20);
			this.rotY.TabIndex = 13;
			this.label5.AutoSize = true;
			this.label5.Location = new global::System.Drawing.Point(109, 26);
			this.label5.Name = "label5";
			this.label5.Size = new global::System.Drawing.Size(17, 13);
			this.label5.TabIndex = 12;
			this.label5.Text = "Y:";
			this.label5.Click += new global::System.EventHandler(this.label5_Click);
			this.rotX.Location = new global::System.Drawing.Point(22, 42);
			this.rotX.Name = "rotX";
			this.rotX.Size = new global::System.Drawing.Size(84, 20);
			this.rotX.TabIndex = 11;
			this.label6.AutoSize = true;
			this.label6.Location = new global::System.Drawing.Point(22, 26);
			this.label6.Name = "label6";
			this.label6.Size = new global::System.Drawing.Size(17, 13);
			this.label6.TabIndex = 10;
			this.label6.Text = "X:";
			this.rotW.Location = new global::System.Drawing.Point(293, 42);
			this.rotW.Name = "rotW";
			this.rotW.Size = new global::System.Drawing.Size(86, 20);
			this.rotW.TabIndex = 17;
			this.label7.AutoSize = true;
			this.label7.Location = new global::System.Drawing.Point(290, 26);
			this.label7.Name = "label7";
			this.label7.Size = new global::System.Drawing.Size(21, 13);
			this.label7.TabIndex = 16;
			this.label7.Text = "W:";
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new global::System.Drawing.Size(434, 215);
			base.Controls.Add(this.groupBox2);
			base.Controls.Add(this.groupBox1);
			base.Controls.Add(this.okButton);
			base.Controls.Add(this.cancelButton);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			base.Name = "PositionToMatrix";
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Position => Matrix";
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			base.ResumeLayout(false);
		}

		// Token: 0x0400076A RID: 1898
		private global::System.Windows.Forms.Button cancelButton;

		// Token: 0x0400076B RID: 1899
		private global::System.Windows.Forms.Button okButton;

		// Token: 0x0400076C RID: 1900
		private global::System.Windows.Forms.GroupBox groupBox1;

		// Token: 0x0400076D RID: 1901
		private global::System.Windows.Forms.TextBox zValue;

		// Token: 0x0400076E RID: 1902
		private global::System.Windows.Forms.Label label3;

		// Token: 0x0400076F RID: 1903
		private global::System.Windows.Forms.TextBox yValue;

		// Token: 0x04000770 RID: 1904
		private global::System.Windows.Forms.Label label2;

		// Token: 0x04000771 RID: 1905
		private global::System.Windows.Forms.TextBox xValue;

		// Token: 0x04000772 RID: 1906
		private global::System.Windows.Forms.Label label1;

		// Token: 0x04000773 RID: 1907
		private global::System.Windows.Forms.GroupBox groupBox2;

		// Token: 0x04000774 RID: 1908
		private global::System.Windows.Forms.TextBox rotZ;

		// Token: 0x04000775 RID: 1909
		private global::System.Windows.Forms.Label label4;

		// Token: 0x04000776 RID: 1910
		private global::System.Windows.Forms.TextBox rotY;

		// Token: 0x04000777 RID: 1911
		private global::System.Windows.Forms.Label label5;

		// Token: 0x04000778 RID: 1912
		private global::System.Windows.Forms.TextBox rotX;

		// Token: 0x04000779 RID: 1913
		private global::System.Windows.Forms.Label label6;

		// Token: 0x0400077A RID: 1914
		private global::System.Windows.Forms.TextBox rotW;

		// Token: 0x0400077B RID: 1915
		private global::System.Windows.Forms.Label label7;
	}
}
