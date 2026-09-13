using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace ns14
{
	// Token: 0x02000027 RID: 39
	internal sealed class SelectionControl : UserControl
	{
		// Token: 0x0600012B RID: 299 RVA: 0x000031C6 File Offset: 0x000013C6
		public SelectionControl()
		{
			this.InitializeComponent();
		}

		// Token: 0x0600012C RID: 300 RVA: 0x000031D6 File Offset: 0x000013D6
		protected void Dispose(bool disposing)
		{
			if (disposing && this.icontainer_0 != null)
			{
				this.icontainer_0.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x0600012D RID: 301 RVA: 0x0001CC2C File Offset: 0x0001AE2C
		private void InitializeComponent()
		{
			this.rectangularSelection = new RadioButton();
			this.brushSelection = new RadioButton();
			base.SuspendLayout();
			this.rectangularSelection.AutoSize = true;
			this.rectangularSelection.Checked = true;
			this.rectangularSelection.Location = new Point(9, 9);
			this.rectangularSelection.Name = "rectangularSelection";
			this.rectangularSelection.Size = new Size(130, 17);
			this.rectangularSelection.TabIndex = 0;
			this.rectangularSelection.TabStop = true;
			this.rectangularSelection.Text = "Rectangular Selection";
			this.rectangularSelection.UseVisualStyleBackColor = true;
			this.brushSelection.AutoSize = true;
			this.brushSelection.Location = new Point(9, 32);
			this.brushSelection.Name = "brushSelection";
			this.brushSelection.Size = new Size(99, 17);
			this.brushSelection.TabIndex = 1;
			this.brushSelection.Text = "Brush Selection\r\n";
			this.brushSelection.UseVisualStyleBackColor = true;
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.Font;
			this.BackColor = Color.FromArgb(182, 225, 131);
			base.Controls.Add(this.brushSelection);
			base.Controls.Add(this.rectangularSelection);
			base.Name = "SelectionControl";
			base.Padding = new Padding(4);
			base.Size = new Size(200, 227);
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x04000123 RID: 291
		private IContainer icontainer_0;

		// Token: 0x04000124 RID: 292
		public RadioButton rectangularSelection;

		// Token: 0x04000125 RID: 293
		public RadioButton brushSelection;
	}
}
