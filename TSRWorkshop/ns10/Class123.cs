using System;
using System.Collections;
using System.IO;
using SlimDX.Direct3D9;

namespace ns10
{
	// Token: 0x02000113 RID: 275
	internal sealed class Class123
	{
		// Token: 0x06000C4F RID: 3151 RVA: 0x0009D488 File Offset: 0x0009B688
		public static Class123 smethod_0()
		{
			return Class123.class123_0;
		}

		// Token: 0x06000C50 RID: 3152 RVA: 0x0009D4A0 File Offset: 0x0009B6A0
		public Texture method_0(Device device_0, string string_0)
		{
			if (this.hashtable_0[string_0] == null)
			{
				this.hashtable_0[string_0] = Texture.FromStream(device_0, new FileStream(string_0, FileMode.Open), Usage.None, Pool.Managed);
			}
			return this.hashtable_0[string_0] as Texture;
		}

		// Token: 0x0400097D RID: 2429
		private Hashtable hashtable_0 = new Hashtable();

		// Token: 0x0400097E RID: 2430
		private static Class123 class123_0 = new Class123();
	}
}
