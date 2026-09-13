using System;
using System.Runtime.InteropServices;

namespace ns9
{
	// Token: 0x02000181 RID: 385
	internal sealed class Class174
	{
		// Token: 0x060011BB RID: 4539
		[DllImport("user32")]
		private static extern int SystemParametersInfo(int int_2, int int_3, out int int_4, int int_5);

		// Token: 0x060011BC RID: 4540 RVA: 0x00002BA3 File Offset: 0x00000DA3
		private Class174()
		{
		}

		// Token: 0x170003E1 RID: 993
		// (get) Token: 0x060011BD RID: 4541 RVA: 0x000BD500 File Offset: 0x000BB700
		public static bool x6b254b18d1dfb65f
		{
			get
			{
				int num;
				Class174.SystemParametersInfo(4118, 0, out num, 0);
				return num != 0;
			}
		}

		// Token: 0x170003E2 RID: 994
		// (get) Token: 0x060011BE RID: 4542 RVA: 0x000BD528 File Offset: 0x000BB728
		public static bool xe9b7df98d555f9fe
		{
			get
			{
				int num;
				Class174.SystemParametersInfo(4120, 0, out num, 0);
				return num != 0;
			}
		}

		// Token: 0x170003E3 RID: 995
		// (get) Token: 0x060011BF RID: 4543 RVA: 0x00037B84 File Offset: 0x00035D84
		public static bool x003e94eb365fa7c9
		{
			get
			{
				return true;
			}
		}

		// Token: 0x04000C4E RID: 3150
		private const int int_0 = 4118;

		// Token: 0x04000C4F RID: 3151
		private const int int_1 = 4120;
	}
}
