namespace ns13
{
	// Token: 0x020000CC RID: 204
	internal sealed partial class ComplateToImageForm : global::System.Windows.Forms.Form
	{
		// Token: 0x0600089A RID: 2202 RVA: 0x00079A20 File Offset: 0x00077C20
		private void InitializeComponent()
		{
			this.okButton = new global::System.Windows.Forms.Button();
			this.cancelButton = new global::System.Windows.Forms.Button();
			this.comboBox = new global::System.Windows.Forms.ComboBox();
			this.label1 = new global::System.Windows.Forms.Label();
			base.SuspendLayout();
			this.okButton.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Right);
			this.okButton.Location = new global::System.Drawing.Point(143, 77);
			this.okButton.Name = "okButton";
			this.okButton.Size = new global::System.Drawing.Size(75, 23);
			this.okButton.TabIndex = 0;
			this.okButton.Text = "OK";
			this.okButton.UseVisualStyleBackColor = true;
			this.okButton.Click += new global::System.EventHandler(this.okButton_Click);
			this.cancelButton.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Right);
			this.cancelButton.Location = new global::System.Drawing.Point(224, 77);
			this.cancelButton.Name = "cancelButton";
			this.cancelButton.Size = new global::System.Drawing.Size(75, 23);
			this.cancelButton.TabIndex = 1;
			this.cancelButton.Text = "Cancel";
			this.cancelButton.UseVisualStyleBackColor = true;
			this.cancelButton.Click += new global::System.EventHandler(this.cancelButton_Click);
			this.comboBox.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBox.FormattingEnabled = true;
			this.comboBox.Location = new global::System.Drawing.Point(12, 45);
			this.comboBox.Name = "comboBox";
			this.comboBox.Size = new global::System.Drawing.Size(287, 21);
			this.comboBox.TabIndex = 2;
			this.comboBox.SelectedIndexChanged += new global::System.EventHandler(this.comboBox_SelectedIndexChanged);
			this.label1.Location = new global::System.Drawing.Point(9, 9);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(300, 28);
			this.label1.TabIndex = 3;
			this.label1.Text = "There are multiple textures defined in this complate. Choose the texture you want to export in the drop down.";
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new global::System.Drawing.Size(314, 112);
			base.Controls.Add(this.label1);
			base.Controls.Add(this.comboBox);
			base.Controls.Add(this.cancelButton);
			base.Controls.Add(this.okButton);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "ComplateToImageForm";
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Export complate";
			base.ResumeLayout(false);
		}

		// Token: 0x040006E1 RID: 1761
		private global::System.Windows.Forms.Button okButton;

		// Token: 0x040006E2 RID: 1762
		private global::System.Windows.Forms.Button cancelButton;

		// Token: 0x040006E3 RID: 1763
		private global::System.Windows.Forms.ComboBox comboBox;

		// Token: 0x040006E4 RID: 1764
		private global::System.Windows.Forms.Label label1;
	}
}
