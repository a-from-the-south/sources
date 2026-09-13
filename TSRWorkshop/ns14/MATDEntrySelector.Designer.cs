namespace ns14
{
	// Token: 0x02000044 RID: 68
	internal sealed partial class MATDEntrySelector : global::System.Windows.Forms.Form
	{
		// Token: 0x0600028E RID: 654 RVA: 0x0002F81C File Offset: 0x0002DA1C
		private void InitializeComponent()
		{
			this.button1 = new global::System.Windows.Forms.Button();
			this.button2 = new global::System.Windows.Forms.Button();
			this.DropdownList = new global::System.Windows.Forms.ComboBox();
			base.SuspendLayout();
			this.button1.Location = new global::System.Drawing.Point(150, 47);
			this.button1.Name = "button1";
			this.button1.Size = new global::System.Drawing.Size(75, 23);
			this.button1.TabIndex = 0;
			this.button1.Text = "OK";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new global::System.EventHandler(this.button1_Click);
			this.button2.Location = new global::System.Drawing.Point(231, 47);
			this.button2.Name = "button2";
			this.button2.Size = new global::System.Drawing.Size(75, 23);
			this.button2.TabIndex = 1;
			this.button2.Text = "Cancel";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new global::System.EventHandler(this.button2_Click);
			this.DropdownList.AutoCompleteMode = global::System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.DropdownList.FormattingEnabled = true;
			this.DropdownList.Location = new global::System.Drawing.Point(14, 13);
			this.DropdownList.Name = "DropdownList";
			this.DropdownList.Size = new global::System.Drawing.Size(292, 21);
			this.DropdownList.TabIndex = 2;
			this.DropdownList.KeyDown += new global::System.Windows.Forms.KeyEventHandler(this.DropdownList_KeyDown);
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new global::System.Drawing.Size(318, 82);
			base.Controls.Add(this.DropdownList);
			base.Controls.Add(this.button2);
			base.Controls.Add(this.button1);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			base.Name = "MATDEntrySelector";
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Select property to add";
			base.Shown += new global::System.EventHandler(this.MATDEntrySelector_Shown);
			base.ResumeLayout(false);
		}

		// Token: 0x04000231 RID: 561
		private global::System.Windows.Forms.Button button1;

		// Token: 0x04000232 RID: 562
		private global::System.Windows.Forms.Button button2;

		// Token: 0x04000233 RID: 563
		public global::System.Windows.Forms.ComboBox DropdownList;
	}
}
