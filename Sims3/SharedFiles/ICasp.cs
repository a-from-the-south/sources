using System;
using System.Collections.Generic;

namespace Package.SharedFiles
{
	// Token: 0x020000A8 RID: 168
	public interface ICasp
	{
		// Token: 0x170002BA RID: 698
		// (get) Token: 0x06000832 RID: 2098
		// (set) Token: 0x06000833 RID: 2099
		uint ageFlags { get; set; }

		// Token: 0x170002BB RID: 699
		// (get) Token: 0x06000834 RID: 2100
		// (set) Token: 0x06000835 RID: 2101
		uint clothingCategoryFlags { get; set; }

		// Token: 0x170002BC RID: 700
		// (get) Token: 0x06000836 RID: 2102
		// (set) Token: 0x06000837 RID: 2103
		uint typeFlags { get; set; }

		// Token: 0x170002BD RID: 701
		// (get) Token: 0x06000838 RID: 2104
		// (set) Token: 0x06000839 RID: 2105
		uint version { get; set; }

		// Token: 0x170002BE RID: 702
		// (get) Token: 0x0600083A RID: 2106
		// (set) Token: 0x0600083B RID: 2107
		string str1 { get; set; }

		// Token: 0x0600083C RID: 2108
		List<CASP.AgeGender> GetAges();

		// Token: 0x0600083D RID: 2109
		List<CASP.AgeGender> GetGendres();

		// Token: 0x0600083E RID: 2110
		List<CASP.Species> GetSpecies();

		// Token: 0x0600083F RID: 2111
		List<CASP.Type> GetTypes();

		// Token: 0x06000840 RID: 2112
		List<uint> GetCategories();
	}
}
