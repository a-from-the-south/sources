using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using ns0;

namespace ns15
{
	// Token: 0x020001DE RID: 478
	[DesignerCategory("Code")]
	internal sealed class Control13 : Control
	{
		// Token: 0x0600135C RID: 4956 RVA: 0x0000A2B7 File Offset: 0x000084B7
		protected void OnResize(EventArgs e)
		{
			base.Size = new Size(Convert.ToInt32(112f * this.float_0), Convert.ToInt32(32f * this.float_1));
			base.OnResize(e);
		}

		// Token: 0x0600135D RID: 4957 RVA: 0x0000A2ED File Offset: 0x000084ED
		protected void ScaleCore(float dx, float dy)
		{
			this.float_0 = dx;
			this.float_1 = dy;
			base.ScaleCore(dx, dy);
			this.OnResize(EventArgs.Empty);
		}

		// Token: 0x0600135E RID: 4958 RVA: 0x0000A310 File Offset: 0x00008510
		protected void Dispose(bool disposing)
		{
			if (disposing)
			{
				if (this.toolTip_0 != null)
				{
					this.toolTip_0.Dispose();
				}
				if (this.pictureBox_0 != null)
				{
					this.pictureBox_0.Dispose();
				}
			}
			base.Dispose(disposing);
		}

		// Token: 0x0600135F RID: 4959 RVA: 0x000C6F70 File Offset: 0x000C5170
		private void Control13_Click(object sender, EventArgs e)
		{
			try
			{
				Process.Start("http://www.red-gate.com/products/dotnet-development/smartassembly/?utm_source=smartassemblyui&utm_medium=supportlink&utm_content=aerdialogbox&utm_campaign=smartassembly");
			}
			catch
			{
			}
		}

		// Token: 0x06001360 RID: 4960 RVA: 0x000C6FA0 File Offset: 0x000C51A0
		public Control13()
		{
			base.SuspendLayout();
			this.label_0.FlatStyle = FlatStyle.System;
			this.label_0.Location = new Point(0, 10);
			this.label_0.Size = new Size(62, 24);
			this.label_0.Text = "Powered by";
			this.pictureBox_0.Image = Class206.smethod_0("{logo}");
			this.pictureBox_0.Location = new Point(72, 0);
			this.pictureBox_0.Size = new Size(32, 32);
			this.pictureBox_0.SizeMode = PictureBoxSizeMode.StretchImage;
			this.label_0.Click += this.Control13_Click;
			this.pictureBox_0.Click += this.Control13_Click;
			base.Click += this.Control13_Click;
			this.Cursor = Cursors.Hand;
			base.TabStop = false;
			base.Size = new Size(112, 32);
			base.Controls.AddRange(new Control[]
			{
				this.pictureBox_0,
				this.label_0
			});
			this.toolTip_0.SetToolTip(this, "Powered by SmartAssembly");
			this.toolTip_0.SetToolTip(this.label_0, "Powered by SmartAssembly");
			this.toolTip_0.SetToolTip(this.pictureBox_0, "Powered by SmartAssembly");
			base.ResumeLayout(true);
		}

		// Token: 0x04000DA6 RID: 3494
		private const string string_0 = "Powered by SmartAssembly";

		// Token: 0x04000DA7 RID: 3495
		private const string string_1 = "http://www.red-gate.com/products/dotnet-development/smartassembly/?utm_source=smartassemblyui&utm_medium=supportlink&utm_content=aerdialogbox&utm_campaign=smartassembly";

		// Token: 0x04000DA8 RID: 3496
		private Label label_0 = new Label();

		// Token: 0x04000DA9 RID: 3497
		private PictureBox pictureBox_0 = new PictureBox();

		// Token: 0x04000DAA RID: 3498
		private ToolTip toolTip_0 = new ToolTip();

		// Token: 0x04000DAB RID: 3499
		private float float_0 = 1f;

		// Token: 0x04000DAC RID: 3500
		private float float_1 = 1f;
	}
}
