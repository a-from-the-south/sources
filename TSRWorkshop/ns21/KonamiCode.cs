using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using ns17;

namespace ns21
{
	// Token: 0x020000D8 RID: 216
	internal sealed partial class KonamiCode : Form
	{
		// Token: 0x060008F0 RID: 2288 RVA: 0x000060B2 File Offset: 0x000042B2
		public KonamiCode()
		{
			this.InitializeComponent();
		}

		// Token: 0x060008F1 RID: 2289 RVA: 0x000060C2 File Offset: 0x000042C2
		protected void Dispose(bool disposing)
		{
			if (disposing && this.icontainer_0 != null)
			{
				this.icontainer_0.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x04000721 RID: 1825
		private IContainer icontainer_0;
	}
}
