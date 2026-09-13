using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace ns18
{
	// Token: 0x0200003C RID: 60
	internal sealed partial class ObjectToolWindow : Form
	{
		// Token: 0x1700005F RID: 95
		// (get) Token: 0x06000234 RID: 564 RVA: 0x0002B150 File Offset: 0x00029350
		// (set) Token: 0x06000235 RID: 565 RVA: 0x000035EF File Offset: 0x000017EF
		public int Mode { get; set; }

		// Token: 0x06000236 RID: 566 RVA: 0x000035FA File Offset: 0x000017FA
		public ObjectToolWindow()
		{
			this.InitializeComponent();
		}

		// Token: 0x06000237 RID: 567 RVA: 0x0002B168 File Offset: 0x00029368
		private void checkBox3_CheckedChanged(object sender, EventArgs e)
		{
			CheckBox checkBox = this.checkBox1;
			this.checkBox2.Checked = false;
			checkBox.Checked = false;
			this.checkBox3.Checked = true;
			this.Mode = 0;
		}

		// Token: 0x06000238 RID: 568 RVA: 0x0002B1A4 File Offset: 0x000293A4
		private void checkBox1_CheckedChanged(object sender, EventArgs e)
		{
			CheckBox checkBox = this.checkBox2;
			this.checkBox2.Checked = false;
			checkBox.Checked = false;
			this.checkBox1.Checked = true;
			this.Mode = 1;
		}

		// Token: 0x06000239 RID: 569 RVA: 0x0002B1E0 File Offset: 0x000293E0
		private void checkBox2_CheckedChanged(object sender, EventArgs e)
		{
			CheckBox checkBox = this.checkBox3;
			this.checkBox1.Checked = false;
			checkBox.Checked = false;
			this.checkBox2.Checked = true;
			this.Mode = 2;
		}

		// Token: 0x0600023A RID: 570 RVA: 0x0000360A File Offset: 0x0000180A
		protected void Dispose(bool disposing)
		{
			if (disposing && this.icontainer_0 != null)
			{
				this.icontainer_0.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x040001E1 RID: 481
		private IContainer icontainer_0;

		// Token: 0x040001E6 RID: 486
		[CompilerGenerated]
		private int int_0;
	}
}
