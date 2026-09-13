namespace ns4
{
	// Token: 0x02000039 RID: 57
	internal sealed partial class AutoBoneAssigmentIndexChooser : global::System.Windows.Forms.Form
	{
		// Token: 0x0600021F RID: 543 RVA: 0x00029B38 File Offset: 0x00027D38
		private void InitializeComponent()
		{
			this.panel1 = new global::System.Windows.Forms.Panel();
			this.button2 = new global::System.Windows.Forms.Button();
			this.button1 = new global::System.Windows.Forms.Button();
			this.label1 = new global::System.Windows.Forms.Label();
			this.comboBox1 = new global::System.Windows.Forms.ComboBox();
			this.panel1.SuspendLayout();
			base.SuspendLayout();
			this.panel1.Controls.Add(this.button2);
			this.panel1.Controls.Add(this.button1);
			this.panel1.Dock = global::System.Windows.Forms.DockStyle.Bottom;
			this.panel1.Location = new global::System.Drawing.Point(0, 69);
			this.panel1.Name = "panel1";
			this.panel1.Size = new global::System.Drawing.Size(287, 34);
			this.panel1.TabIndex = 1;
			this.button2.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Right);
			this.button2.Location = new global::System.Drawing.Point(121, 6);
			this.button2.Name = "button2";
			this.button2.Size = new global::System.Drawing.Size(75, 23);
			this.button2.TabIndex = 1;
			this.button2.Text = "OK";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new global::System.EventHandler(this.button2_Click);
			this.button1.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Right);
			this.button1.Location = new global::System.Drawing.Point(202, 6);
			this.button1.Name = "button1";
			this.button1.Size = new global::System.Drawing.Size(75, 23);
			this.button1.TabIndex = 0;
			this.button1.Text = "Cancel";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new global::System.EventHandler(this.button1_Click);
			this.label1.Location = new global::System.Drawing.Point(8, 8);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(294, 38);
			this.label1.TabIndex = 2;
			this.label1.Text = "Your mesh has multiple groups and morphstates, choose which group you want to work with.";
			this.comboBox1.FormattingEnabled = true;
			this.comboBox1.Location = new global::System.Drawing.Point(11, 40);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new global::System.Drawing.Size(265, 21);
			this.comboBox1.TabIndex = 3;
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new global::System.Drawing.Size(287, 103);
			base.ControlBox = false;
			base.Controls.Add(this.comboBox1);
			base.Controls.Add(this.label1);
			base.Controls.Add(this.panel1);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			base.Name = "AutoBoneAssigmentIndexChooser";
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Auto Bone Assigment Group";
			this.panel1.ResumeLayout(false);
			base.ResumeLayout(false);
		}

		// Token: 0x040001C4 RID: 452
		private global::System.Windows.Forms.Panel panel1;

		// Token: 0x040001C5 RID: 453
		private global::System.Windows.Forms.Button button2;

		// Token: 0x040001C6 RID: 454
		private global::System.Windows.Forms.Button button1;

		// Token: 0x040001C7 RID: 455
		private global::System.Windows.Forms.Label label1;

		// Token: 0x040001C8 RID: 456
		private global::System.Windows.Forms.ComboBox comboBox1;
	}
}
