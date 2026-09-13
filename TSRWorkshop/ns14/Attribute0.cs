using System;

namespace ns14
{
	// Token: 0x02000152 RID: 338
	[AttributeUsage(AttributeTargets.Property)]
	internal sealed class Attribute0 : Attribute
	{
		// Token: 0x06001002 RID: 4098 RVA: 0x0000867F File Offset: 0x0000687F
		public Attribute0()
		{
		}

		// Token: 0x06001003 RID: 4099 RVA: 0x00008687 File Offset: 0x00006887
		public Attribute0(string name)
		{
			this.name = name;
		}

		// Token: 0x04000B7C RID: 2940
		public string name;
	}
}
