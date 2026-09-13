using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace ns9
{
	// Token: 0x0200003B RID: 59
	internal sealed partial class BuildToolWindow : Form
	{
		// Token: 0x1700005E RID: 94
		// (get) Token: 0x0600022C RID: 556 RVA: 0x0002AC78 File Offset: 0x00028E78
		// (set) Token: 0x0600022D RID: 557 RVA: 0x000035B3 File Offset: 0x000017B3
		public int Mode { get; set; }

		// Token: 0x0600022E RID: 558 RVA: 0x000035BE File Offset: 0x000017BE
		public BuildToolWindow()
		{
			this.InitializeComponent();
		}

		// Token: 0x0600022F RID: 559 RVA: 0x0002AC90 File Offset: 0x00028E90
		private void checkBox3_CheckedChanged(object sender, EventArgs e)
		{
			CheckBox checkBox = this.checkBox1;
			this.checkBox2.Checked = false;
			checkBox.Checked = false;
			this.checkBox3.Checked = true;
			this.Mode = 0;
		}

		// Token: 0x06000230 RID: 560 RVA: 0x0002ACCC File Offset: 0x00028ECC
		private void checkBox1_CheckedChanged(object sender, EventArgs e)
		{
			CheckBox checkBox = this.checkBox2;
			this.checkBox2.Checked = false;
			checkBox.Checked = false;
			this.checkBox1.Checked = true;
			this.Mode = 1;
		}

		// Token: 0x06000231 RID: 561 RVA: 0x0002AD08 File Offset: 0x00028F08
		private void checkBox2_CheckedChanged(object sender, EventArgs e)
		{
			CheckBox checkBox = this.checkBox3;
			this.checkBox1.Checked = false;
			checkBox.Checked = false;
			this.checkBox2.Checked = true;
			this.Mode = 2;
		}

		// Token: 0x06000232 RID: 562 RVA: 0x000035CE File Offset: 0x000017CE
		protected void Dispose(bool disposing)
		{
			if (disposing && this.icontainer_0 != null)
			{
				this.icontainer_0.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x040001DB RID: 475
		private IContainer icontainer_0;

		// Token: 0x040001E0 RID: 480
		[CompilerGenerated]
		private int int_0;
	}
}
