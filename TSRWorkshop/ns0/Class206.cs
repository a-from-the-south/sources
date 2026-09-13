using System;
using System.Drawing;
using System.IO;
using System.Reflection;

namespace ns0
{
	// Token: 0x020001D1 RID: 465
	internal sealed class Class206
	{
		// Token: 0x06001310 RID: 4880 RVA: 0x000C62A4 File Offset: 0x000C44A4
		public static Bitmap smethod_0(string string_0)
		{
			Bitmap result;
			try
			{
				Stream manifestResourceStream = Assembly.GetExecutingAssembly().GetManifestResourceStream("SmartAssembly.SmartExceptionsCore.Resources." + string_0 + ".png");
				result = ((manifestResourceStream == null) ? null : new Bitmap(manifestResourceStream));
			}
			catch
			{
				result = null;
			}
			return result;
		}

		// Token: 0x06001311 RID: 4881 RVA: 0x000C62F4 File Offset: 0x000C44F4
		public static Icon smethod_1(string string_0)
		{
			Icon result;
			try
			{
				Stream manifestResourceStream = Assembly.GetExecutingAssembly().GetManifestResourceStream("SmartAssembly.SmartExceptionsCore.Resources." + string_0 + ".ico");
				result = ((manifestResourceStream == null) ? null : new Icon(manifestResourceStream));
			}
			catch
			{
				result = null;
			}
			return result;
		}
	}
}
