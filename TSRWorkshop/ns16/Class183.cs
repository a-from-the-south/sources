using System;
using Microsoft.Win32;
using ns13;

namespace ns16
{
	// Token: 0x0200019C RID: 412
	internal sealed class Class183
	{
		// Token: 0x0600124A RID: 4682 RVA: 0x000C04A4 File Offset: 0x000BE6A4
		public static string smethod_0()
		{
			string result;
			try
			{
				RegistryKey registryKey = Registry.LocalMachine.OpenSubKey(Class184.SubkeyApplication);
				if (registryKey == null)
				{
					registryKey = Registry.LocalMachine.OpenSubKey(Class184.WowSubkeyApplication);
				}
				if (registryKey == null)
				{
					result = null;
				}
				else
				{
					string text = (string)registryKey.GetValue("Path", null);
					registryKey.Close();
					result = text;
				}
			}
			catch
			{
				result = null;
			}
			return result;
		}
	}
}
