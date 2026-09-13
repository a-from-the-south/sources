using System;
using VisualHint.SmartPropertyGrid;

namespace Sims3Workshop.Data
{
	// Token: 0x020000A1 RID: 161
	[PropertyValueDisplayedAs(new string[]
	{
		"Baby",
		"Toddler",
		"Child",
		"Teen",
		"Young Adult",
		"Adult",
		"Elder"
	})]
	[Flags]
	public enum Age : uint
	{
		// Token: 0x040005C6 RID: 1478
		Baby = 1U,
		// Token: 0x040005C7 RID: 1479
		Toddler = 2U,
		// Token: 0x040005C8 RID: 1480
		Child = 4U,
		// Token: 0x040005C9 RID: 1481
		Teen = 8U,
		// Token: 0x040005CA RID: 1482
		YoungAdult = 16U,
		// Token: 0x040005CB RID: 1483
		Adult = 32U,
		// Token: 0x040005CC RID: 1484
		Elder = 64U
	}
}
