using System;
using System.Reflection;

namespace ns3
{
	// Token: 0x02000154 RID: 340
	internal sealed class Class151
	{
		// Token: 0x0600100E RID: 4110 RVA: 0x00002BA3 File Offset: 0x00000DA3
		private Class151()
		{
		}

		// Token: 0x0600100F RID: 4111 RVA: 0x000B85D0 File Offset: 0x000B67D0
		static Class151()
		{
			if (Environment.Version.Major >= 2)
			{
				Class151.type_0 = Assembly.LoadWithPartialName("System.Windows.Forms").GetType("System.Windows.Forms.ToolStrip", false);
				Class151.type_1 = Assembly.LoadWithPartialName("System.Windows.Forms").GetType("System.Windows.Forms.ToolStripItem", false);
			}
		}

		// Token: 0x04000B7E RID: 2942
		public static readonly Type type_0;

		// Token: 0x04000B7F RID: 2943
		public static readonly Type type_1;
	}
}
