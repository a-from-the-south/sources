using System;

namespace ns14
{
	// Token: 0x0200019B RID: 411
	internal sealed class Class182
	{
		// Token: 0x17000404 RID: 1028
		// (get) Token: 0x06001246 RID: 4678 RVA: 0x00009A12 File Offset: 0x00007C12
		public static string AppName
		{
			get
			{
				return Class182.AppNameMinusVersion + " " + Class182.MajorVersion;
			}
		}

		// Token: 0x17000405 RID: 1029
		// (get) Token: 0x06001247 RID: 4679 RVA: 0x000C0484 File Offset: 0x000BE684
		public static int MajorVersion
		{
			get
			{
				Version version = new Version("6.7.0.239");
				return version.Major;
			}
		}

		// Token: 0x17000406 RID: 1030
		// (get) Token: 0x06001248 RID: 4680 RVA: 0x00009A2D File Offset: 0x00007C2D
		public static string AppNameMinusVersion
		{
			get
			{
				return "SmartAssembly";
			}
		}

		// Token: 0x06001249 RID: 4681 RVA: 0x00002BA3 File Offset: 0x00000DA3
		private Class182()
		{
		}
	}
}
