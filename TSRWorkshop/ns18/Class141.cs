using System;
using System.Windows.Forms;
using Sims3WorkshopSDK.Interfaces;

namespace ns18
{
	// Token: 0x0200012E RID: 302
	internal sealed class Class141 : ToolStripMenuItem
	{
		// Token: 0x06000E01 RID: 3585 RVA: 0x00007B18 File Offset: 0x00005D18
		public Class141(IWorkshopExtension extension)
		{
			this.extension = extension;
		}

		// Token: 0x170002B2 RID: 690
		// (get) Token: 0x06000E02 RID: 3586 RVA: 0x000AE268 File Offset: 0x000AC468
		public IWorkshopExtension Extension
		{
			get
			{
				return this.extension;
			}
		}

		// Token: 0x04000A88 RID: 2696
		private IWorkshopExtension extension;
	}
}
