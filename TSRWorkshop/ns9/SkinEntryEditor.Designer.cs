namespace ns9
{
	// Token: 0x0200000F RID: 15
	internal sealed partial class SkinEntryEditor : global::System.Windows.Forms.Form
	{
		// Token: 0x06000053 RID: 83 RVA: 0x0001234C File Offset: 0x0001054C
		private void InitializeComponent()
		{
			this.m11 = new global::System.Windows.Forms.TextBox();
			this.m12 = new global::System.Windows.Forms.TextBox();
			this.m13 = new global::System.Windows.Forms.TextBox();
			this.m23 = new global::System.Windows.Forms.TextBox();
			this.m22 = new global::System.Windows.Forms.TextBox();
			this.m21 = new global::System.Windows.Forms.TextBox();
			this.m33 = new global::System.Windows.Forms.TextBox();
			this.m32 = new global::System.Windows.Forms.TextBox();
			this.m31 = new global::System.Windows.Forms.TextBox();
			this.m43 = new global::System.Windows.Forms.TextBox();
			this.m42 = new global::System.Windows.Forms.TextBox();
			this.m41 = new global::System.Windows.Forms.TextBox();
			this.button1 = new global::System.Windows.Forms.Button();
			this.button2 = new global::System.Windows.Forms.Button();
			base.SuspendLayout();
			this.m11.Location = new global::System.Drawing.Point(12, 12);
			this.m11.Name = "m11";
			this.m11.Size = new global::System.Drawing.Size(100, 20);
			this.m11.TabIndex = 0;
			this.m12.Location = new global::System.Drawing.Point(118, 12);
			this.m12.Name = "m12";
			this.m12.Size = new global::System.Drawing.Size(100, 20);
			this.m12.TabIndex = 1;
			this.m13.Location = new global::System.Drawing.Point(224, 12);
			this.m13.Name = "m13";
			this.m13.Size = new global::System.Drawing.Size(100, 20);
			this.m13.TabIndex = 2;
			this.m23.Location = new global::System.Drawing.Point(224, 38);
			this.m23.Name = "m23";
			this.m23.Size = new global::System.Drawing.Size(100, 20);
			this.m23.TabIndex = 5;
			this.m22.Location = new global::System.Drawing.Point(118, 38);
			this.m22.Name = "m22";
			this.m22.Size = new global::System.Drawing.Size(100, 20);
			this.m22.TabIndex = 4;
			this.m21.Location = new global::System.Drawing.Point(12, 38);
			this.m21.Name = "m21";
			this.m21.Size = new global::System.Drawing.Size(100, 20);
			this.m21.TabIndex = 3;
			this.m33.Location = new global::System.Drawing.Point(224, 64);
			this.m33.Name = "m33";
			this.m33.Size = new global::System.Drawing.Size(100, 20);
			this.m33.TabIndex = 8;
			this.m32.Location = new global::System.Drawing.Point(118, 64);
			this.m32.Name = "m32";
			this.m32.Size = new global::System.Drawing.Size(100, 20);
			this.m32.TabIndex = 7;
			this.m31.Location = new global::System.Drawing.Point(12, 64);
			this.m31.Name = "m31";
			this.m31.Size = new global::System.Drawing.Size(100, 20);
			this.m31.TabIndex = 6;
			this.m43.Location = new global::System.Drawing.Point(224, 90);
			this.m43.Name = "m43";
			this.m43.Size = new global::System.Drawing.Size(100, 20);
			this.m43.TabIndex = 11;
			this.m42.Location = new global::System.Drawing.Point(118, 90);
			this.m42.Name = "m42";
			this.m42.Size = new global::System.Drawing.Size(100, 20);
			this.m42.TabIndex = 10;
			this.m41.Location = new global::System.Drawing.Point(12, 90);
			this.m41.Name = "m41";
			this.m41.Size = new global::System.Drawing.Size(100, 20);
			this.m41.TabIndex = 9;
			this.button1.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Right);
			this.button1.Location = new global::System.Drawing.Point(249, 120);
			this.button1.Name = "button1";
			this.button1.Size = new global::System.Drawing.Size(75, 23);
			this.button1.TabIndex = 12;
			this.button1.Text = "Cancel";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new global::System.EventHandler(this.button1_Click);
			this.button2.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Right);
			this.button2.Location = new global::System.Drawing.Point(168, 120);
			this.button2.Name = "button2";
			this.button2.Size = new global::System.Drawing.Size(75, 23);
			this.button2.TabIndex = 13;
			this.button2.Text = "OK";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new global::System.EventHandler(this.button2_Click);
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new global::System.Drawing.Size(336, 151);
			base.Controls.Add(this.button2);
			base.Controls.Add(this.button1);
			base.Controls.Add(this.m43);
			base.Controls.Add(this.m42);
			base.Controls.Add(this.m41);
			base.Controls.Add(this.m33);
			base.Controls.Add(this.m32);
			base.Controls.Add(this.m31);
			base.Controls.Add(this.m23);
			base.Controls.Add(this.m22);
			base.Controls.Add(this.m21);
			base.Controls.Add(this.m13);
			base.Controls.Add(this.m12);
			base.Controls.Add(this.m11);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			base.Name = "SkinEntryEditor";
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "SkinEntryEditor";
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x040000A1 RID: 161
		private global::System.Windows.Forms.TextBox m11;

		// Token: 0x040000A2 RID: 162
		private global::System.Windows.Forms.TextBox m12;

		// Token: 0x040000A3 RID: 163
		private global::System.Windows.Forms.TextBox m13;

		// Token: 0x040000A4 RID: 164
		private global::System.Windows.Forms.TextBox m23;

		// Token: 0x040000A5 RID: 165
		private global::System.Windows.Forms.TextBox m22;

		// Token: 0x040000A6 RID: 166
		private global::System.Windows.Forms.TextBox m21;

		// Token: 0x040000A7 RID: 167
		private global::System.Windows.Forms.TextBox m33;

		// Token: 0x040000A8 RID: 168
		private global::System.Windows.Forms.TextBox m32;

		// Token: 0x040000A9 RID: 169
		private global::System.Windows.Forms.TextBox m31;

		// Token: 0x040000AA RID: 170
		private global::System.Windows.Forms.TextBox m43;

		// Token: 0x040000AB RID: 171
		private global::System.Windows.Forms.TextBox m42;

		// Token: 0x040000AC RID: 172
		private global::System.Windows.Forms.TextBox m41;

		// Token: 0x040000AD RID: 173
		private global::System.Windows.Forms.Button button1;

		// Token: 0x040000AE RID: 174
		private global::System.Windows.Forms.Button button2;
	}
}
