using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace ns18
{
	// Token: 0x0200003D RID: 61
	internal sealed partial class SymbolToolWindow : Form
	{
		// Token: 0x0600023C RID: 572 RVA: 0x0000362B File Offset: 0x0000182B
		public SymbolToolWindow()
		{
			this.InitializeComponent();
		}

		// Token: 0x0600023D RID: 573 RVA: 0x0000363B File Offset: 0x0000183B
		protected void Dispose(bool disposing)
		{
			if (disposing && this.icontainer_0 != null)
			{
				this.icontainer_0.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x040001E7 RID: 487
		private IContainer icontainer_0;
	}
}
