using System;
using VisualHint.SmartPropertyGrid;

namespace Sims3Workshop.Data
{
	// Token: 0x0200009E RID: 158
	[Flags]
	[PropertyValueDisplayedAs(new string[]
	{
		"Male",
		"Female"
	})]
	public enum Gender : uint
	{
		// Token: 0x040005B4 RID: 1460
		Male = 4096U,
		// Token: 0x040005B5 RID: 1461
		Female = 8192U
	}
}
