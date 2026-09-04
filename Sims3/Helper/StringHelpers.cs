using System;
using System.Globalization;
using System.Text;

namespace Package.Helper
{
	// Token: 0x020000E6 RID: 230
	public static class StringHelpers
	{
		// Token: 0x06000BCF RID: 3023 RVA: 0x0003A3A8 File Offset: 0x000385A8
		public static string UppercaseFirst(string s)
		{
			if (string.IsNullOrEmpty(s))
			{
				return string.Empty;
			}
			char[] array = s.ToCharArray();
			array[0] = char.ToUpper(array[0]);
			return new string(array);
		}

		// Token: 0x06000BD0 RID: 3024 RVA: 0x0003A3DC File Offset: 0x000385DC
		public static string ToCamelCase(string s)
		{
			StringBuilder stringBuilder = new StringBuilder(s.Length);
			bool flag = false;
			foreach (char c in s)
			{
				if (c == ' ')
				{
					flag = true;
				}
				else
				{
					if (flag)
					{
						stringBuilder.Append(char.ToUpper(c));
					}
					else
					{
						stringBuilder.Append(c);
					}
					flag = false;
				}
			}
			return stringBuilder.ToString();
		}

		// Token: 0x06000BD1 RID: 3025 RVA: 0x0003A444 File Offset: 0x00038644
		public static string FromCamelCase(string s)
		{
			StringBuilder stringBuilder = new StringBuilder(s.Length + 10);
			bool flag = true;
			foreach (char c in s)
			{
				if (char.IsUpper(c) && !flag)
				{
					stringBuilder.Append(' ');
					stringBuilder.Append(char.ToLower(c));
				}
				else
				{
					stringBuilder.Append(c);
				}
				flag = false;
			}
			return stringBuilder.ToString();
		}

		// Token: 0x06000BD2 RID: 3026 RVA: 0x00007B2B File Offset: 0x00005D2B
		public static string XmlValue(string str)
		{
			return str;
		}

		// Token: 0x06000BD3 RID: 3027 RVA: 0x0003A4B4 File Offset: 0x000386B4
		public static uint FNV32(string input)
		{
			string text = input.ToLower();
			uint num = 2166136261U;
			for (int i = 0; i < text.Length; i++)
			{
				num *= 16777619U;
				num ^= (uint)text[i];
			}
			return num;
		}

		// Token: 0x06000BD4 RID: 3028 RVA: 0x0003A4F4 File Offset: 0x000386F4
		public static ulong FNV64(string input)
		{
			string text = input.ToLower();
			ulong num = 14695981039346656037UL;
			for (int i = 0; i < text.Length; i++)
			{
				num *= 1099511628211UL;
				num ^= (ulong)text[i];
			}
			return num;
		}

		// Token: 0x06000BD5 RID: 3029 RVA: 0x0003A53C File Offset: 0x0003873C
		public static ulong HashString64(string str)
		{
			string s = str.ToLower();
			ulong num = 14695981039346656037UL;
			byte[] bytes = StringHelpers.gEncoder.GetBytes(s);
			int i = bytes.Length;
			int num2 = 0;
			while (i > 0)
			{
				num = (num * 1099511628211UL ^ (ulong)bytes[num2]);
				num2++;
				i--;
			}
			return num;
		}

		// Token: 0x06000BD6 RID: 3030 RVA: 0x00008926 File Offset: 0x00006B26
		public static uint ParseHex32(string input)
		{
			if (input.StartsWith("0x"))
			{
				return uint.Parse(input.Substring(2), NumberStyles.AllowHexSpecifier);
			}
			return uint.Parse(input);
		}

		// Token: 0x06000BD7 RID: 3031 RVA: 0x0000894D File Offset: 0x00006B4D
		public static ulong ParseHex64(string input)
		{
			if (input.StartsWith("0x"))
			{
				return ulong.Parse(input.Substring(2), NumberStyles.AllowHexSpecifier);
			}
			return ulong.Parse(input);
		}

		// Token: 0x06000BD8 RID: 3032 RVA: 0x00008974 File Offset: 0x00006B74
		public static string RemoveZero(string input)
		{
			return StringHelpers.CleanString(input);
		}

		// Token: 0x06000BD9 RID: 3033 RVA: 0x0003A590 File Offset: 0x00038790
		public static string CleanString(string s)
		{
			if (s != null && s.Length > 0)
			{
				StringBuilder stringBuilder = new StringBuilder(s.Length);
				foreach (char c in s)
				{
					stringBuilder.Append(char.IsControl(c) ? ' ' : c);
				}
				s = stringBuilder.ToString();
			}
			return s;
		}

		// Token: 0x06000BDA RID: 3034 RVA: 0x0003A5F0 File Offset: 0x000387F0
		public static string ReadFourCC(uint value)
		{
			return new string(new char[]
			{
				(char)(value & 255U),
				(char)(value >> 8 & 255U),
				(char)(value >> 16 & 255U),
				(char)(value >> 24 & 255U)
			});
		}

		// Token: 0x06000BDB RID: 3035 RVA: 0x0003A63C File Offset: 0x0003883C
		public static uint ToFourCC(string value)
		{
			byte[] array = new byte[4];
			for (int i = 0; i < 4; i++)
			{
				array[i] = (byte)value[i];
			}
			return BitConverter.ToUInt32(array, 0);
		}

		// Token: 0x0400059E RID: 1438
		private static readonly ASCIIEncoding gEncoder = new ASCIIEncoding();
	}
}
