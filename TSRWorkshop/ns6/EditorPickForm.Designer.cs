namespace ns6
{
	// Token: 0x020000CE RID: 206
	internal sealed partial class EditorPickForm : global::System.Windows.Forms.Form
	{
		// Token: 0x060008A3 RID: 2211 RVA: 0x0007A078 File Offset: 0x00078278
		private void InitializeComponent()
		{
			this.button1 = new global::System.Windows.Forms.Button();
			this.comboBox = new global::System.Windows.Forms.ComboBox();
			base.SuspendLayout();
			this.button1.Location = new global::System.Drawing.Point(257, 11);
			this.button1.Name = "button1";
			this.button1.Size = new global::System.Drawing.Size(75, 23);
			this.button1.TabIndex = 0;
			this.button1.Text = "Open";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new global::System.EventHandler(this.button1_Click);
			this.comboBox.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBox.FormattingEnabled = true;
			this.comboBox.Location = new global::System.Drawing.Point(9, 11);
			this.comboBox.Name = "comboBox";
			this.comboBox.Size = new global::System.Drawing.Size(237, 21);
			this.comboBox.TabIndex = 1;
			this.comboBox.SelectedIndexChanged += new global::System.EventHandler(this.comboBox_SelectedIndexChanged);
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new global::System.Drawing.Size(342, 42);
			base.Controls.Add(this.comboBox);
			base.Controls.Add(this.button1);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			base.Name = "EditorPickForm";
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Choose editor";
			base.ResumeLayout(false);
		}

		// Token: 0x040006EE RID: 1774
		private global::System.Windows.Forms.Button button1;

		// Token: 0x040006EF RID: 1775
		private global::System.Windows.Forms.ComboBox comboBox;
	}
}
