using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace ns13
{
	// Token: 0x02000025 RID: 37
	internal sealed class MoveControl : UserControl
	{
		// Token: 0x06000125 RID: 293 RVA: 0x00003164 File Offset: 0x00001364
		public MoveControl()
		{
			this.InitializeComponent();
		}

		// Token: 0x06000126 RID: 294 RVA: 0x00003174 File Offset: 0x00001374
		protected void Dispose(bool disposing)
		{
			if (disposing && this.icontainer_0 != null)
			{
				this.icontainer_0.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000127 RID: 295 RVA: 0x0001C960 File Offset: 0x0001AB60
		private void InitializeComponent()
		{
			this.moveX = new CheckBox();
			this.moveZ = new CheckBox();
			this.moveY = new CheckBox();
			base.SuspendLayout();
			this.moveX.AutoSize = true;
			this.moveX.Checked = true;
			this.moveX.CheckState = CheckState.Checked;
			this.moveX.Location = new Point(14, 16);
			this.moveX.Name = "moveX";
			this.moveX.Size = new Size(123, 17);
			this.moveX.TabIndex = 0;
			this.moveX.Text = "Move in X - direction";
			this.moveX.UseVisualStyleBackColor = true;
			this.moveZ.AutoSize = true;
			this.moveZ.Checked = true;
			this.moveZ.CheckState = CheckState.Checked;
			this.moveZ.Location = new Point(14, 62);
			this.moveZ.Name = "moveZ";
			this.moveZ.Size = new Size(123, 17);
			this.moveZ.TabIndex = 1;
			this.moveZ.Text = "Move in Z - direction";
			this.moveZ.UseVisualStyleBackColor = true;
			this.moveY.AutoSize = true;
			this.moveY.Checked = true;
			this.moveY.CheckState = CheckState.Checked;
			this.moveY.Location = new Point(14, 39);
			this.moveY.Name = "moveY";
			this.moveY.Size = new Size(123, 17);
			this.moveY.TabIndex = 2;
			this.moveY.Text = "Move in Y - direction";
			this.moveY.UseVisualStyleBackColor = true;
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.Font;
			this.BackColor = Color.FromArgb(182, 225, 131);
			base.Controls.Add(this.moveY);
			base.Controls.Add(this.moveZ);
			base.Controls.Add(this.moveX);
			base.Name = "MoveControl";
			base.Size = new Size(216, 370);
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x0400011E RID: 286
		private IContainer icontainer_0;

		// Token: 0x0400011F RID: 287
		public CheckBox moveX;

		// Token: 0x04000120 RID: 288
		public CheckBox moveZ;

		// Token: 0x04000121 RID: 289
		public CheckBox moveY;
	}
}
