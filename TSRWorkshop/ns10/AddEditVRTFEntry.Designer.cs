namespace ns10
{
	// Token: 0x02000036 RID: 54
	internal sealed partial class AddEditVRTFEntry : global::System.Windows.Forms.Form
	{
		// Token: 0x06000202 RID: 514 RVA: 0x000283B4 File Offset: 0x000265B4
		private void InitializeComponent()
		{
			global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::ns10.AddEditVRTFEntry));
			this.button1 = new global::System.Windows.Forms.Button();
			this.button2 = new global::System.Windows.Forms.Button();
			this.typeCombo = new global::System.Windows.Forms.ComboBox();
			this.usageCombo = new global::System.Windows.Forms.ComboBox();
			this.label1 = new global::System.Windows.Forms.Label();
			this.label2 = new global::System.Windows.Forms.Label();
			this.indexTextbox = new global::System.Windows.Forms.TextBox();
			this.offsetTextbox = new global::System.Windows.Forms.TextBox();
			this.label3 = new global::System.Windows.Forms.Label();
			this.label4 = new global::System.Windows.Forms.Label();
			base.SuspendLayout();
			this.button1.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Right);
			this.button1.Location = new global::System.Drawing.Point(225, 118);
			this.button1.Name = "button1";
			this.button1.Size = new global::System.Drawing.Size(75, 23);
			this.button1.TabIndex = 0;
			this.button1.Text = "Cancel";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new global::System.EventHandler(this.button1_Click);
			this.button2.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Right);
			this.button2.Location = new global::System.Drawing.Point(144, 118);
			this.button2.Name = "button2";
			this.button2.Size = new global::System.Drawing.Size(75, 23);
			this.button2.TabIndex = 1;
			this.button2.Text = "OK";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new global::System.EventHandler(this.button2_Click);
			this.typeCombo.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.typeCombo.FormattingEnabled = true;
			this.typeCombo.Location = new global::System.Drawing.Point(156, 27);
			this.typeCombo.Name = "typeCombo";
			this.typeCombo.Size = new global::System.Drawing.Size(144, 21);
			this.typeCombo.TabIndex = 2;
			this.usageCombo.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.usageCombo.FormattingEnabled = true;
			this.usageCombo.Location = new global::System.Drawing.Point(12, 27);
			this.usageCombo.Name = "usageCombo";
			this.usageCombo.Size = new global::System.Drawing.Size(138, 21);
			this.usageCombo.TabIndex = 3;
			this.label1.AutoSize = true;
			this.label1.Location = new global::System.Drawing.Point(12, 11);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(41, 13);
			this.label1.TabIndex = 4;
			this.label1.Text = "Usage:";
			this.label2.AutoSize = true;
			this.label2.Location = new global::System.Drawing.Point(153, 11);
			this.label2.Name = "label2";
			this.label2.Size = new global::System.Drawing.Size(34, 13);
			this.label2.TabIndex = 5;
			this.label2.Text = "Type:";
			this.indexTextbox.Location = new global::System.Drawing.Point(12, 77);
			this.indexTextbox.Name = "indexTextbox";
			this.indexTextbox.Size = new global::System.Drawing.Size(138, 20);
			this.indexTextbox.TabIndex = 6;
			this.offsetTextbox.Location = new global::System.Drawing.Point(156, 77);
			this.offsetTextbox.Name = "offsetTextbox";
			this.offsetTextbox.Size = new global::System.Drawing.Size(142, 20);
			this.offsetTextbox.TabIndex = 7;
			this.label3.AutoSize = true;
			this.label3.Location = new global::System.Drawing.Point(12, 61);
			this.label3.Name = "label3";
			this.label3.Size = new global::System.Drawing.Size(36, 13);
			this.label3.TabIndex = 8;
			this.label3.Text = "Index:";
			this.label4.AutoSize = true;
			this.label4.Location = new global::System.Drawing.Point(156, 61);
			this.label4.Name = "label4";
			this.label4.Size = new global::System.Drawing.Size(38, 13);
			this.label4.TabIndex = 9;
			this.label4.Text = "Offset:";
			this.label4.Click += new global::System.EventHandler(this.label4_Click);
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new global::System.Drawing.Size(310, 149);
			base.Controls.Add(this.label4);
			base.Controls.Add(this.label3);
			base.Controls.Add(this.offsetTextbox);
			base.Controls.Add(this.indexTextbox);
			base.Controls.Add(this.label2);
			base.Controls.Add(this.label1);
			base.Controls.Add(this.usageCombo);
			base.Controls.Add(this.typeCombo);
			base.Controls.Add(this.button2);
			base.Controls.Add(this.button1);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			base.Icon = (global::System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
			base.Name = "AddEditVRTFEntry";
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "VRTF Entry";
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x040001A1 RID: 417
		private global::System.Windows.Forms.Button button1;

		// Token: 0x040001A2 RID: 418
		private global::System.Windows.Forms.Button button2;

		// Token: 0x040001A3 RID: 419
		private global::System.Windows.Forms.ComboBox typeCombo;

		// Token: 0x040001A4 RID: 420
		private global::System.Windows.Forms.ComboBox usageCombo;

		// Token: 0x040001A5 RID: 421
		private global::System.Windows.Forms.Label label1;

		// Token: 0x040001A6 RID: 422
		private global::System.Windows.Forms.Label label2;

		// Token: 0x040001A7 RID: 423
		private global::System.Windows.Forms.TextBox indexTextbox;

		// Token: 0x040001A8 RID: 424
		private global::System.Windows.Forms.TextBox offsetTextbox;

		// Token: 0x040001A9 RID: 425
		private global::System.Windows.Forms.Label label3;

		// Token: 0x040001AA RID: 426
		private global::System.Windows.Forms.Label label4;
	}
}
