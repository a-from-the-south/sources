namespace ns3
{
	// Token: 0x020000E8 RID: 232
	internal sealed partial class ResourceSelector : global::System.Windows.Forms.Form
	{
		// Token: 0x0600097D RID: 2429 RVA: 0x00083598 File Offset: 0x00081798
		private void InitializeComponent()
		{
			this.cancelButton = new global::System.Windows.Forms.Button();
			this.selectButton = new global::System.Windows.Forms.Button();
			this.comboBox1 = new global::System.Windows.Forms.ComboBox();
			this.label1 = new global::System.Windows.Forms.Label();
			base.SuspendLayout();
			this.cancelButton.Location = new global::System.Drawing.Point(233, 50);
			this.cancelButton.Name = "cancelButton";
			this.cancelButton.Size = new global::System.Drawing.Size(75, 23);
			this.cancelButton.TabIndex = 0;
			this.cancelButton.Text = "Cancel";
			this.cancelButton.UseVisualStyleBackColor = true;
			this.cancelButton.Click += new global::System.EventHandler(this.cancelButton_Click);
			this.selectButton.Location = new global::System.Drawing.Point(152, 50);
			this.selectButton.Name = "selectButton";
			this.selectButton.Size = new global::System.Drawing.Size(75, 23);
			this.selectButton.TabIndex = 1;
			this.selectButton.Text = "Select";
			this.selectButton.UseVisualStyleBackColor = true;
			this.selectButton.Click += new global::System.EventHandler(this.selectButton_Click);
			this.comboBox1.FormattingEnabled = true;
			this.comboBox1.Location = new global::System.Drawing.Point(8, 21);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new global::System.Drawing.Size(300, 21);
			this.comboBox1.TabIndex = 2;
			this.label1.AutoSize = true;
			this.label1.Location = new global::System.Drawing.Point(5, 5);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(84, 13);
			this.label1.TabIndex = 3;
			this.label1.Text = "Select resource:";
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new global::System.Drawing.Size(314, 79);
			base.ControlBox = false;
			base.Controls.Add(this.label1);
			base.Controls.Add(this.comboBox1);
			base.Controls.Add(this.selectButton);
			base.Controls.Add(this.cancelButton);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.Name = "ResourceSelector";
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Resource Selector";
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x040007A4 RID: 1956
		private global::System.Windows.Forms.Button cancelButton;

		// Token: 0x040007A5 RID: 1957
		private global::System.Windows.Forms.Button selectButton;

		// Token: 0x040007A6 RID: 1958
		private global::System.Windows.Forms.ComboBox comboBox1;

		// Token: 0x040007A7 RID: 1959
		private global::System.Windows.Forms.Label label1;
	}
}
