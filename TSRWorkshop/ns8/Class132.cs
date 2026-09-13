using System;
using ns16;
using Sims3Workshop;

namespace ns8
{
	// Token: 0x0200011D RID: 285
	internal sealed class Class132
	{
		// Token: 0x17000295 RID: 661
		// (get) Token: 0x06000CDB RID: 3291 RVA: 0x000A0A04 File Offset: 0x0009EC04
		public static Mainform mainForm
		{
			get
			{
				if (Class132.mainform_0 == null)
				{
					Class132.mainform_0 = new Mainform();
				}
				return Class132.mainform_0;
			}
		}

		// Token: 0x06000CDC RID: 3292 RVA: 0x000A0A2C File Offset: 0x0009EC2C
		public static MeshEditor smethod_0()
		{
			if (Class132.meshEditor_0 == null)
			{
				Class132.meshEditor_0 = new MeshEditor();
			}
			return Class132.meshEditor_0;
		}

		// Token: 0x06000CDD RID: 3293 RVA: 0x00007329 File Offset: 0x00005529
		public static void smethod_1(string string_1)
		{
			Class132.string_0 = string_1;
		}

		// Token: 0x06000CDE RID: 3294 RVA: 0x000A0A54 File Offset: 0x0009EC54
		public static string smethod_2()
		{
			return Class132.string_0;
		}

		// Token: 0x040009C3 RID: 2499
		private static Mainform mainform_0;

		// Token: 0x040009C4 RID: 2500
		private static MeshEditor meshEditor_0;

		// Token: 0x040009C5 RID: 2501
		private static string string_0;
	}
}
