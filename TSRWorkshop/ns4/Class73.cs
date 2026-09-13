using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace ns4
{
	// Token: 0x020000AB RID: 171
	[GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
	[CompilerGenerated]
	[DebuggerNonUserCode]
	internal sealed class Class73
	{
		// Token: 0x060006BC RID: 1724 RVA: 0x00002BA3 File Offset: 0x00000DA3
		internal Class73()
		{
		}

		// Token: 0x1700011B RID: 283
		// (get) Token: 0x060006BD RID: 1725 RVA: 0x000669E0 File Offset: 0x00064BE0
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static ResourceManager ResourceManager
		{
			get
			{
				if (object.ReferenceEquals(Class73.resourceManager_0, null))
				{
					ResourceManager resourceManager = new ResourceManager("ns4.Class73", typeof(Class73).Assembly);
					Class73.resourceManager_0 = resourceManager;
				}
				return Class73.resourceManager_0;
			}
		}

		// Token: 0x1700011C RID: 284
		// (get) Token: 0x060006BE RID: 1726 RVA: 0x00066A24 File Offset: 0x00064C24
		// (set) Token: 0x060006BF RID: 1727 RVA: 0x00005541 File Offset: 0x00003741
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static CultureInfo Culture
		{
			get
			{
				return Class73.cultureInfo_0;
			}
			set
			{
				Class73.cultureInfo_0 = value;
			}
		}

		// Token: 0x1700011D RID: 285
		// (get) Token: 0x060006C0 RID: 1728 RVA: 0x00066A3C File Offset: 0x00064C3C
		internal static string CasSkinOverlayMultitintable
		{
			get
			{
				return Class73.ResourceManager.GetString("CasSkinOverlayMultitintable", Class73.cultureInfo_0);
			}
		}

		// Token: 0x04000624 RID: 1572
		private static ResourceManager resourceManager_0;

		// Token: 0x04000625 RID: 1573
		private static CultureInfo cultureInfo_0;
	}
}
