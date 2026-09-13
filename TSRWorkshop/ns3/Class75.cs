using System;
using System.Collections.Generic;
using ns16;
using Sims3WorkshopSDK;
using Sims3WorkshopSDK.Interfaces;

namespace ns3
{
	// Token: 0x020000AE RID: 174
	internal sealed class Class75 : IGamedata
	{
		// Token: 0x060006C5 RID: 1733 RVA: 0x00066BAC File Offset: 0x00064DAC
		public ResKey FindResource(ResKey resKey_0)
		{
			return Class76.smethod_16(resKey_0);
		}

		// Token: 0x060006C6 RID: 1734 RVA: 0x00066BC4 File Offset: 0x00064DC4
		public ResKey FindResource(ResKey resKey_0, bool bool_0)
		{
			return Class76.smethod_17(resKey_0, bool_0);
		}

		// Token: 0x060006C7 RID: 1735 RVA: 0x00066BDC File Offset: 0x00064DDC
		public List<ResKey> FindResources(ResKey resKey_0)
		{
			return Class76.smethod_19(resKey_0);
		}

		// Token: 0x060006C8 RID: 1736 RVA: 0x00066BF4 File Offset: 0x00064DF4
		public List<ResKey> FindResources(ResKey resKey_0, int int_0, bool bool_0)
		{
			return Class76.smethod_21(resKey_0, int_0, bool_0, false);
		}

		// Token: 0x060006C9 RID: 1737 RVA: 0x00066C10 File Offset: 0x00064E10
		public List<object> GetResources(ResKey resKey_0)
		{
			return new List<object>(Class76.smethod_24(resKey_0).ToArray());
		}

		// Token: 0x060006CA RID: 1738 RVA: 0x00066C34 File Offset: 0x00064E34
		public List<object> GetResources(ResKey resKey_0, bool bool_0)
		{
			return new List<object>(Class76.smethod_25(resKey_0, bool_0).ToArray());
		}

		// Token: 0x060006CB RID: 1739 RVA: 0x00066C58 File Offset: 0x00064E58
		public object GetResource(ResKey resKey_0)
		{
			return Class76.smethod_26(resKey_0);
		}

		// Token: 0x060006CC RID: 1740 RVA: 0x00066C70 File Offset: 0x00064E70
		public object GetResource(ResKey resKey_0, bool bool_0)
		{
			return Class76.smethod_27(resKey_0, bool_0);
		}
	}
}
