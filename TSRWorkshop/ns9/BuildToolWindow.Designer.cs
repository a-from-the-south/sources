namespace ns9
{
	// Token: 0x0200003B RID: 59
	internal sealed partial class BuildToolWindow : global::System.Windows.Forms.Form
	{
		// Token: 0x06000233 RID: 563 RVA: 0x0002AD44 File Offset: 0x00028F44
		private void InitializeComponent()
		{
			this.tableLayoutPanel1 = new global::System.Windows.Forms.TableLayoutPanel();
			this.checkBox3 = new global::System.Windows.Forms.CheckBox();
			this.checkBox1 = new global::System.Windows.Forms.CheckBox();
			this.checkBox2 = new global::System.Windows.Forms.CheckBox();
			this.tableLayoutPanel1.SuspendLayout();
			base.SuspendLayout();
			this.tableLayoutPanel1.ColumnCount = 1;
			this.tableLayoutPanel1.ColumnStyles.Add(new global::System.Windows.Forms.ColumnStyle(global::System.Windows.Forms.SizeType.Percent, 100f));
			this.tableLayoutPanel1.Controls.Add(this.checkBox2, 0, 2);
			this.tableLayoutPanel1.Controls.Add(this.checkBox1, 0, 1);
			this.tableLayoutPanel1.Controls.Add(this.checkBox3, 0, 0);
			this.tableLayoutPanel1.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new global::System.Drawing.Point(0, 0);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 3;
			this.tableLayoutPanel1.RowStyles.Add(new global::System.Windows.Forms.RowStyle(global::System.Windows.Forms.SizeType.Percent, 33.33333f));
			this.tableLayoutPanel1.RowStyles.Add(new global::System.Windows.Forms.RowStyle(global::System.Windows.Forms.SizeType.Percent, 33.33333f));
			this.tableLayoutPanel1.RowStyles.Add(new global::System.Windows.Forms.RowStyle(global::System.Windows.Forms.SizeType.Percent, 33.33333f));
			this.tableLayoutPanel1.Size = new global::System.Drawing.Size(127, 194);
			this.tableLayoutPanel1.TabIndex = 0;
			this.checkBox3.Appearance = global::System.Windows.Forms.Appearance.Button;
			this.checkBox3.AutoSize = true;
			this.checkBox3.Checked = true;
			this.checkBox3.CheckState = global::System.Windows.Forms.CheckState.Checked;
			this.checkBox3.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.checkBox3.Location = new global::System.Drawing.Point(3, 3);
			this.checkBox3.Name = "checkBox3";
			this.checkBox3.Size = new global::System.Drawing.Size(121, 58);
			this.checkBox3.TabIndex = 6;
			this.checkBox3.Text = "Draw wall";
			this.checkBox3.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
			this.checkBox3.UseVisualStyleBackColor = true;
			this.checkBox3.CheckedChanged += new global::System.EventHandler(this.checkBox3_CheckedChanged);
			this.checkBox1.Appearance = global::System.Windows.Forms.Appearance.Button;
			this.checkBox1.AutoSize = true;
			this.checkBox1.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.checkBox1.Location = new global::System.Drawing.Point(3, 67);
			this.checkBox1.Name = "checkBox1";
			this.checkBox1.Size = new global::System.Drawing.Size(121, 58);
			this.checkBox1.TabIndex = 7;
			this.checkBox1.Text = "Adjust wall";
			this.checkBox1.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
			this.checkBox1.UseVisualStyleBackColor = true;
			this.checkBox1.CheckedChanged += new global::System.EventHandler(this.checkBox1_CheckedChanged);
			this.checkBox2.Appearance = global::System.Windows.Forms.Appearance.Button;
			this.checkBox2.AutoSize = true;
			this.checkBox2.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.checkBox2.Location = new global::System.Drawing.Point(3, 131);
			this.checkBox2.Name = "checkBox2";
			this.checkBox2.Size = new global::System.Drawing.Size(121, 60);
			this.checkBox2.TabIndex = 8;
			this.checkBox2.Text = "Remove wall";
			this.checkBox2.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
			this.checkBox2.UseVisualStyleBackColor = true;
			this.checkBox2.CheckedChanged += new global::System.EventHandler(this.checkBox2_CheckedChanged);
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new global::System.Drawing.Size(127, 194);
			base.Controls.Add(this.tableLayoutPanel1);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			base.Name = "BuildToolWindow";
			base.ShowIcon = false;
			base.ShowInTaskbar = false;
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "BuildToolWindow";
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			base.ResumeLayout(false);
		}

		// Token: 0x040001DC RID: 476
		private global::System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;

		// Token: 0x040001DD RID: 477
		private global::System.Windows.Forms.CheckBox checkBox2;

		// Token: 0x040001DE RID: 478
		private global::System.Windows.Forms.CheckBox checkBox1;

		// Token: 0x040001DF RID: 479
		private global::System.Windows.Forms.CheckBox checkBox3;
	}
}
