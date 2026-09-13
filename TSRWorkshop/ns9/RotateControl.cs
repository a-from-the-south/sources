using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace ns9
{
	// Token: 0x02000026 RID: 38
	internal sealed class RotateControl : UserControl
	{
		// Token: 0x06000128 RID: 296 RVA: 0x00003195 File Offset: 0x00001395
		public RotateControl()
		{
			this.InitializeComponent();
		}

		// Token: 0x06000129 RID: 297 RVA: 0x000031A5 File Offset: 0x000013A5
		protected void Dispose(bool disposing)
		{
			if (disposing && this.icontainer_0 != null)
			{
				this.icontainer_0.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x0600012A RID: 298 RVA: 0x0001CBB8 File Offset: 0x0001ADB8
		private void InitializeComponent()
		{
			base.SuspendLayout();
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.Font;
			this.BackColor = Color.FromArgb(182, 225, 131);
			base.Name = "RotateControl";
			base.Size = new Size(226, 383);
			base.ResumeLayout(false);
		}

		// Token: 0x04000122 RID: 290
		private IContainer icontainer_0;
	}
}
