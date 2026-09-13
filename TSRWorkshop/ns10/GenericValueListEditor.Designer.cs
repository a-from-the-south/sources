namespace ns10
{
	// Token: 0x02000009 RID: 9
	internal sealed partial class GenericValueListEditor : global::System.Windows.Forms.Form
	{
		// Token: 0x06000032 RID: 50 RVA: 0x0000E994 File Offset: 0x0000CB94
		private void InitializeComponent()
		{
			global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::ns10.GenericValueListEditor));
			this.panel1 = new global::System.Windows.Forms.Panel();
			this.button1 = new global::System.Windows.Forms.Button();
			this.button2 = new global::System.Windows.Forms.Button();
			this.listView1 = new global::System.Windows.Forms.ListView();
			this.panel1.SuspendLayout();
			base.SuspendLayout();
			this.panel1.Controls.Add(this.button2);
			this.panel1.Controls.Add(this.button1);
			this.panel1.Dock = global::System.Windows.Forms.DockStyle.Bottom;
			this.panel1.Location = new global::System.Drawing.Point(0, 429);
			this.panel1.Name = "panel1";
			this.panel1.Size = new global::System.Drawing.Size(629, 46);
			this.panel1.TabIndex = 0;
			this.button1.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Right);
			this.button1.Location = new global::System.Drawing.Point(542, 12);
			this.button1.Name = "button1";
			this.button1.Size = new global::System.Drawing.Size(75, 23);
			this.button1.TabIndex = 0;
			this.button1.Text = "Cancel";
			this.button1.UseVisualStyleBackColor = true;
			this.button2.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Right);
			this.button2.Location = new global::System.Drawing.Point(461, 12);
			this.button2.Name = "button2";
			this.button2.Size = new global::System.Drawing.Size(75, 23);
			this.button2.TabIndex = 1;
			this.button2.Text = "OK";
			this.button2.UseVisualStyleBackColor = true;
			this.listView1.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.listView1.Location = new global::System.Drawing.Point(0, 0);
			this.listView1.Name = "listView1";
			this.listView1.Size = new global::System.Drawing.Size(629, 429);
			this.listView1.TabIndex = 1;
			this.listView1.UseCompatibleStateImageBehavior = false;
			this.listView1.View = global::System.Windows.Forms.View.Details;
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new global::System.Drawing.Size(629, 475);
			base.Controls.Add(this.listView1);
			base.Controls.Add(this.panel1);
			base.Icon = (global::System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
			base.Name = "GenericValueListEditor";
			this.Text = "GenericValueListEditor";
			this.panel1.ResumeLayout(false);
			base.ResumeLayout(false);
		}

		// Token: 0x0400004F RID: 79
		private global::System.Windows.Forms.Panel panel1;

		// Token: 0x04000050 RID: 80
		private global::System.Windows.Forms.Button button1;

		// Token: 0x04000051 RID: 81
		private global::System.Windows.Forms.Button button2;

		// Token: 0x04000052 RID: 82
		private global::System.Windows.Forms.ListView listView1;
	}
}
