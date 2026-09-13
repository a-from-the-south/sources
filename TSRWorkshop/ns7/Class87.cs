using System;
using System.Runtime.CompilerServices;
using Package.Sims3Files;
using Sims3WorkshopSDK;
using VisualHint.SmartPropertyGrid;

namespace ns7
{
	// Token: 0x020000C0 RID: 192
	[PropertyFeel("button")]
	internal sealed class Class87
	{
		// Token: 0x17000157 RID: 343
		// (get) Token: 0x06000831 RID: 2097 RVA: 0x00076B8C File Offset: 0x00074D8C
		// (set) Token: 0x06000832 RID: 2098 RVA: 0x00005BD7 File Offset: 0x00003DD7
		public ResKey Reskey { get; set; }

		// Token: 0x17000158 RID: 344
		// (get) Token: 0x06000833 RID: 2099 RVA: 0x00076BA4 File Offset: 0x00074DA4
		// (set) Token: 0x06000834 RID: 2100 RVA: 0x00005BE2 File Offset: 0x00003DE2
		public TGIIndex TGIIndex { get; set; }

		// Token: 0x06000835 RID: 2101 RVA: 0x00005BED File Offset: 0x00003DED
		public Class87(ResKey buildItemReskey, TGIIndex tgiToReplace)
		{
			this.Reskey = buildItemReskey;
			this.TGIIndex = tgiToReplace;
		}

		// Token: 0x06000836 RID: 2102 RVA: 0x00076BBC File Offset: 0x00074DBC
		public string ToString()
		{
			return this.Reskey.AsString();
		}

		// Token: 0x04000666 RID: 1638
		[CompilerGenerated]
		private ResKey resKey_0;

		// Token: 0x04000667 RID: 1639
		[CompilerGenerated]
		private TGIIndex tgiindex_0;
	}
}
