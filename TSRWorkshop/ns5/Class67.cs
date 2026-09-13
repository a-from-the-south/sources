using System;
using System.Runtime.CompilerServices;
using Package.Sims3Files.InternalRCOL;

namespace ns5
{
	// Token: 0x020000A3 RID: 163
	internal sealed class Class67
	{
		// Token: 0x17000108 RID: 264
		// (get) Token: 0x06000641 RID: 1601 RVA: 0x00060164 File Offset: 0x0005E364
		// (set) Token: 0x06000642 RID: 1602 RVA: 0x00005356 File Offset: 0x00003556
		public VPXY.VPXEntryEntry Entry { get; private set; }

		// Token: 0x17000109 RID: 265
		// (get) Token: 0x06000643 RID: 1603 RVA: 0x0006017C File Offset: 0x0005E37C
		// (set) Token: 0x06000644 RID: 1604 RVA: 0x00005361 File Offset: 0x00003561
		public VPXY VPXY { get; private set; }

		// Token: 0x06000645 RID: 1605 RVA: 0x0000536C File Offset: 0x0000356C
		public Class67(VPXY vpxy, VPXY.VPXEntryEntry entry)
		{
			this.Entry = entry;
			this.VPXY = vpxy;
		}

		// Token: 0x06000646 RID: 1606 RVA: 0x00060194 File Offset: 0x0005E394
		public string ToString()
		{
			string result;
			switch (this.Entry.msIndex)
			{
			case 0:
				result = "Very high level of detail";
				break;
			case 1:
				result = "High level of detail";
				break;
			case 2:
				result = "Medium level of detail";
				break;
			default:
				result = "Low level of detail";
				break;
			}
			return result;
		}

		// Token: 0x040005E7 RID: 1511
		[CompilerGenerated]
		private VPXY.VPXEntryEntry vpxentryEntry_0;

		// Token: 0x040005E8 RID: 1512
		[CompilerGenerated]
		private VPXY vpxy_0;
	}
}
