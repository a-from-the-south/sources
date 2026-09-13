using System;
using ns4;

namespace ns16
{
	// Token: 0x020000A6 RID: 166
	internal sealed class Class69
	{
		// Token: 0x060006A3 RID: 1699 RVA: 0x00065A84 File Offset: 0x00063C84
		public static int smethod_0(ref byte[] byte_0, out byte[] byte_1)
		{
			int result;
			if (Class70.smethod_0(ref byte_0, out byte_1))
			{
				result = byte_1.Length;
			}
			else
			{
				result = -1;
			}
			return result;
		}
	}
}
