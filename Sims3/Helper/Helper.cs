using System;
using System.Text;

namespace Package.Helper
{
	// Token: 0x020000E2 RID: 226
	public static class Helper
	{
		// Token: 0x06000BB0 RID: 2992 RVA: 0x00008783 File Offset: 0x00006983
		public static byte[] ToBytes(string str)
		{
			return Helper.ToBytes(str, 0);
		}

		// Token: 0x06000BB1 RID: 2993 RVA: 0x0003A094 File Offset: 0x00038294
		public static byte[] ToBytes(string str, int len)
		{
			byte[] array;
			if (len != 0)
			{
				array = new byte[len];
				Encoding.ASCII.GetBytes(str, 0, Math.Min(len, str.Length), array, 0);
			}
			else
			{
				array = Encoding.ASCII.GetBytes(str);
			}
			return array;
		}

		// Token: 0x06000BB2 RID: 2994 RVA: 0x0000878C File Offset: 0x0000698C
		public static string MinStrLength(string input, int length)
		{
			while (input.Length < length)
			{
				input = "0" + input;
			}
			return input;
		}

		// Token: 0x06000BB3 RID: 2995 RVA: 0x00039E6C File Offset: 0x0003806C
		public static ulong ByteHashToInt(byte[] input)
		{
			ulong num = 0UL;
			foreach (byte b in input)
			{
				num <<= 8;
				num += (ulong)b;
			}
			return num;
		}
	}
}
