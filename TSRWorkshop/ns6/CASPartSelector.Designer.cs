namespace ns6
{
	// Token: 0x0200003E RID: 62
	internal sealed partial class CASPartSelector : global::System.Windows.Forms.Form
	{
		// Token: 0x06000246 RID: 582 RVA: 0x0002B7AC File Offset: 0x000299AC
		private void InitializeComponent()
		{
			this.icontainer_0 = new global::System.ComponentModel.Container();
			this.panel1 = new global::System.Windows.Forms.Panel();
			this.listView1 = new global::System.Windows.Forms.ListView();
			this.button1 = new global::System.Windows.Forms.Button();
			this.button2 = new global::System.Windows.Forms.Button();
			this.imageList_0 = new global::System.Windows.Forms.ImageList(this.icontainer_0);
			this.panel1.SuspendLayout();
			base.SuspendLayout();
			this.panel1.Controls.Add(this.button2);
			this.panel1.Controls.Add(this.button1);
			this.panel1.Dock = global::System.Windows.Forms.DockStyle.Bottom;
			this.panel1.Location = new global::System.Drawing.Point(8, 348);
			this.panel1.Name = "panel1";
			this.panel1.Size = new global::System.Drawing.Size(318, 30);
			this.panel1.TabIndex = 1;
			this.listView1.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.listView1.LargeImageList = this.imageList_0;
			this.listView1.Location = new global::System.Drawing.Point(8, 8);
			this.listView1.Name = "listView1";
			this.listView1.Size = new global::System.Drawing.Size(318, 340);
			this.listView1.TabIndex = 2;
			this.listView1.UseCompatibleStateImageBehavior = false;
			this.listView1.ItemSelectionChanged += new global::System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.listView1_ItemSelectionChanged);
			this.button1.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Right);
			this.button1.Location = new global::System.Drawing.Point(164, 8);
			this.button1.Name = "button1";
			this.button1.Size = new global::System.Drawing.Size(75, 23);
			this.button1.TabIndex = 0;
			this.button1.Text = "OK";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new global::System.EventHandler(this.button1_Click);
			this.button2.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Right);
			this.button2.Location = new global::System.Drawing.Point(244, 8);
			this.button2.Name = "button2";
			this.button2.Size = new global::System.Drawing.Size(75, 23);
			this.button2.TabIndex = 1;
			this.button2.Text = "Cancel";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new global::System.EventHandler(this.button2_Click);
			this.imageList_0.ColorDepth = global::System.Windows.Forms.ColorDepth.Depth32Bit;
			this.imageList_0.ImageSize = new global::System.Drawing.Size(100, 100);
			this.imageList_0.TransparentColor = global::System.Drawing.Color.Transparent;
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new global::System.Drawing.Size(334, 386);
			base.ControlBox = false;
			base.Controls.Add(this.listView1);
			base.Controls.Add(this.panel1);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.SizableToolWindow;
			this.MinimumSize = new global::System.Drawing.Size(350, 420);
			base.Name = "CASPartSelector";
			base.Padding = new global::System.Windows.Forms.Padding(8);
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = " Select CAS Part";
			this.panel1.ResumeLayout(false);
			base.ResumeLayout(false);
		}

		// Token: 0x040001E8 RID: 488
		private global::System.ComponentModel.IContainer icontainer_0;

		// Token: 0x040001E9 RID: 489
		private global::System.Windows.Forms.Panel panel1;

		// Token: 0x040001EA RID: 490
		private global::System.Windows.Forms.Button button2;

		// Token: 0x040001EB RID: 491
		private global::System.Windows.Forms.Button button1;

		// Token: 0x040001EC RID: 492
		private global::System.Windows.Forms.ListView listView1;

		// Token: 0x040001ED RID: 493
		private global::System.Windows.Forms.ImageList imageList_0;
	}
}
