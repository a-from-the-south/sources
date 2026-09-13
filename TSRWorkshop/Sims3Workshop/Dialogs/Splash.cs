using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using ns17;

namespace Sims3Workshop.Dialogs
{
	// Token: 0x020000E9 RID: 233
	public sealed partial class Splash : Form
	{
		// Token: 0x0600097E RID: 2430 RVA: 0x000063C1 File Offset: 0x000045C1
		public Splash()
		{
			this.InitializeComponent();
			this.label3.Text = Application.ProductVersion;
		}

		// Token: 0x0600097F RID: 2431 RVA: 0x000063E1 File Offset: 0x000045E1
		public void method_0(string string_0)
		{
			this.label1.Text = string_0;
			this.Refresh();
		}

		// Token: 0x06000980 RID: 2432 RVA: 0x000063F7 File Offset: 0x000045F7
		protected void Dispose(bool disposing)
		{
			if (disposing && this.icontainer_0 != null)
			{
				this.icontainer_0.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x040007A9 RID: 1961
		private IContainer icontainer_0;
	}
}
