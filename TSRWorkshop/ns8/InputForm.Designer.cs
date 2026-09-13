namespace ns8
{
	// Token: 0x02000040 RID: 64
	internal sealed partial class InputForm : global::System.Windows.Forms.Form
	{
		// Token: 0x0600026F RID: 623 RVA: 0x0002EBB4 File Offset: 0x0002CDB4
		private void InitializeComponent()
		{
			this.panel1 = new global::System.Windows.Forms.Panel();
			this.panel2 = new global::System.Windows.Forms.Panel();
			this.Label = new global::System.Windows.Forms.Label();
			this.textField = new global::System.Windows.Forms.TextBox();
			this.button1 = new global::System.Windows.Forms.Button();
			this.button2 = new global::System.Windows.Forms.Button();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			base.SuspendLayout();
			this.panel1.Controls.Add(this.Label);
			this.panel1.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.panel1.Location = new global::System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new global::System.Drawing.Size(398, 21);
			this.panel1.TabIndex = 0;
			this.panel2.Controls.Add(this.button2);
			this.panel2.Controls.Add(this.button1);
			this.panel2.Controls.Add(this.textField);
			this.panel2.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.panel2.Location = new global::System.Drawing.Point(0, 21);
			this.panel2.Name = "panel2";
			this.panel2.Padding = new global::System.Windows.Forms.Padding(4);
			this.panel2.Size = new global::System.Drawing.Size(398, 65);
			this.panel2.TabIndex = 1;
			this.panel2.Paint += new global::System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
			this.Label.AutoSize = true;
			this.Label.Location = new global::System.Drawing.Point(3, 5);
			this.Label.Name = "Label";
			this.Label.Size = new global::System.Drawing.Size(61, 13);
			this.Label.TabIndex = 0;
			this.Label.Text = "New name:";
			this.textField.Location = new global::System.Drawing.Point(6, 6);
			this.textField.Margin = new global::System.Windows.Forms.Padding(3, 3, 5, 3);
			this.textField.Name = "textField";
			this.textField.Size = new global::System.Drawing.Size(383, 20);
			this.textField.TabIndex = 2;
			this.textField.TextChanged += new global::System.EventHandler(this.textField_TextChanged);
			this.textField.KeyDown += new global::System.Windows.Forms.KeyEventHandler(this.textField_KeyDown);
			this.button1.Location = new global::System.Drawing.Point(314, 32);
			this.button1.Name = "button1";
			this.button1.Size = new global::System.Drawing.Size(75, 23);
			this.button1.TabIndex = 3;
			this.button1.Text = "Cancel";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new global::System.EventHandler(this.button1_Click);
			this.button2.Location = new global::System.Drawing.Point(233, 32);
			this.button2.Name = "button2";
			this.button2.Size = new global::System.Drawing.Size(75, 23);
			this.button2.TabIndex = 4;
			this.button2.Text = "OK";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new global::System.EventHandler(this.button2_Click);
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new global::System.Drawing.Size(398, 86);
			base.Controls.Add(this.panel2);
			base.Controls.Add(this.panel1);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.Name = "InputForm";
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterParent;
			base.Load += new global::System.EventHandler(this.InputForm_Load);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			base.ResumeLayout(false);
		}

		// Token: 0x0400021D RID: 541
		private global::System.Windows.Forms.Panel panel1;

		// Token: 0x0400021E RID: 542
		private global::System.Windows.Forms.Panel panel2;

		// Token: 0x0400021F RID: 543
		public global::System.Windows.Forms.Label Label;

		// Token: 0x04000220 RID: 544
		private global::System.Windows.Forms.Button button2;

		// Token: 0x04000221 RID: 545
		private global::System.Windows.Forms.Button button1;

		// Token: 0x04000222 RID: 546
		public global::System.Windows.Forms.TextBox textField;
	}
}
