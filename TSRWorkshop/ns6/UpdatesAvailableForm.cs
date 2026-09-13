using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace ns6
{
	// Token: 0x020000EC RID: 236
	internal sealed partial class UpdatesAvailableForm : Form
	{
		// Token: 0x0600099A RID: 2458 RVA: 0x000064B9 File Offset: 0x000046B9
		public UpdatesAvailableForm()
		{
			this.InitializeComponent();
		}

		// Token: 0x0600099B RID: 2459 RVA: 0x00002B20 File Offset: 0x00000D20
		private void button1_Click(object sender, EventArgs e)
		{
			base.Close();
		}

		// Token: 0x0600099C RID: 2460 RVA: 0x000064C9 File Offset: 0x000046C9
		private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			Process.Start("http://www.thesimsresource.com/workshop/");
		}

		// Token: 0x0600099D RID: 2461 RVA: 0x000064D8 File Offset: 0x000046D8
		protected void Dispose(bool disposing)
		{
			if (disposing && this.icontainer_0 != null)
			{
				this.icontainer_0.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x040007C4 RID: 1988
		private IContainer icontainer_0;
	}
}
