using System;
using Microsoft.Win32;
using ns14;

namespace ns13
{
	// Token: 0x0200019D RID: 413
	internal sealed class Class184
	{
		// Token: 0x17000407 RID: 1031
		// (get) Token: 0x0600124C RID: 4684 RVA: 0x00009A34 File Offset: 0x00007C34
		public static string SubkeyApplication
		{
			get
			{
				return "Software\\Red Gate\\" + Class182.AppName;
			}
		}

		// Token: 0x17000408 RID: 1032
		// (get) Token: 0x0600124D RID: 4685 RVA: 0x00009A45 File Offset: 0x00007C45
		public static string WowSubkeyApplication
		{
			get
			{
				return "Software\\Wow6432Node\\Red Gate\\" + Class182.AppName;
			}
		}

		// Token: 0x0600124E RID: 4686 RVA: 0x000C0510 File Offset: 0x000BE710
		public static object smethod_0(string string_0, object object_0)
		{
			object value;
			using (RegistryKey registryKey = Registry.LocalMachine.OpenSubKey(Class184.SubkeyApplication))
			{
				if (registryKey == null)
				{
					return object_0;
				}
				value = registryKey.GetValue(string_0, object_0);
			}
			return value;
		}

		// Token: 0x0600124F RID: 4687 RVA: 0x00002BA3 File Offset: 0x00000DA3
		private Class184()
		{
		}
	}
}
