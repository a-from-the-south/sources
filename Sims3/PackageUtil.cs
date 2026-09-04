using System;
using System.Collections;
using System.IO;

namespace Package
{
	// Token: 0x0200000D RID: 13
	public class PackageUtil
	{
		// Token: 0x0600009C RID: 156 RVA: 0x0000E518 File Offset: 0x0000C718
		public static string ReadString(BinaryReader reader)
		{
			string text = "";
			char c = (char)reader.ReadByte();
			do
			{
				text += c.ToString();
				c = (char)reader.ReadByte();
			}
			while (c != '\0');
			return text;
		}

		// Token: 0x0600009D RID: 157 RVA: 0x0000E54C File Offset: 0x0000C74C
		public static string ReadString(BinaryReader reader, int length)
		{
			string text = "";
			for (int i = 0; i < length; i++)
			{
				text += ((char)reader.ReadByte()).ToString();
			}
			return text;
		}

		// Token: 0x0600009E RID: 158 RVA: 0x0000E584 File Offset: 0x0000C784
		public static bool StringMatch(string compareWith, byte[] data, int length)
		{
			for (int i = 0; i < length; i++)
			{
				if ((char)data[i] != compareWith[i])
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x0600009F RID: 159 RVA: 0x00003409 File Offset: 0x00001609
		public static int ReadBigEndianInt(BinaryReader r)
		{
			byte[] array = r.ReadBytes(4);
			Array.Reverse(array);
			return BitConverter.ToInt32(array, 0);
		}

		// Token: 0x060000A0 RID: 160 RVA: 0x0000341E File Offset: 0x0000161E
		public static uint ReadBigEndianUInt(BinaryReader r)
		{
			byte[] array = r.ReadBytes(4);
			Array.Reverse(array);
			return BitConverter.ToUInt32(array, 0);
		}

		// Token: 0x060000A1 RID: 161 RVA: 0x00003433 File Offset: 0x00001633
		public static float ReadBigEndianFloat(BinaryReader r)
		{
			byte[] array = r.ReadBytes(4);
			Array.Reverse(array);
			return BitConverter.ToSingle(array, 0);
		}

		// Token: 0x060000A2 RID: 162 RVA: 0x00003448 File Offset: 0x00001648
		public static short ReadBigEndianShort(BinaryReader r)
		{
			byte[] array = r.ReadBytes(2);
			Array.Reverse(array);
			return BitConverter.ToInt16(array, 0);
		}

		// Token: 0x060000A3 RID: 163 RVA: 0x0000345D File Offset: 0x0000165D
		public static ushort ReadBigEndianUShort(BinaryReader r)
		{
			byte[] array = r.ReadBytes(2);
			Array.Reverse(array);
			return BitConverter.ToUInt16(array, 0);
		}

		// Token: 0x060000A4 RID: 164 RVA: 0x0000E5B0 File Offset: 0x0000C7B0
		public static string ReadBigEndianString(BinaryReader r)
		{
			int length = PackageUtil.ReadBigEndianInt(r);
			return PackageUtil.ReadString(r, length);
		}

		// Token: 0x060000A5 RID: 165 RVA: 0x0000E5CC File Offset: 0x0000C7CC
		public static string ReadBigEndianUnicodeString(BinaryReader r)
		{
			int num = PackageUtil.ReadBigEndianInt(r);
			return PackageUtil.ReadString(r, num * 2);
		}

		// Token: 0x060000A6 RID: 166 RVA: 0x0000E5EC File Offset: 0x0000C7EC
		public static byte[] OldCompress(byte[] data)
		{
			int num = 128;
			ushort value = 64272;
			ArrayList[] array = new ArrayList[16777216];
			byte[] array2 = new byte[data.Length];
			ArrayList arrayList = null;
			int num2 = 0;
			int num3 = 0;
			int i = -1;
			int num4 = 0;
			bool flag = false;
			byte[] result;
			try
			{
				int j;
				while (i < data.Length - 3)
				{
					do
					{
						i++;
						if (i >= data.Length - 2)
						{
							goto Block_4;
						}
						int num5 = (int)data[i] | (int)data[i + 1] << 8 | (int)data[i + 2] << 16;
						arrayList = array[num5];
						if (arrayList == null)
						{
							arrayList = new ArrayList();
							array[num5] = arrayList;
						}
						arrayList.Add(i);
					}
					while (i < num4);
					IL_98:
					if (flag)
					{
						break;
					}
					int num6 = 0;
					int num7 = 1;
					while (num7 < arrayList.Count && num7 < num)
					{
						int num8 = (int)arrayList[arrayList.Count - 1 - num7];
						if (i - num8 >= 131072)
						{
							break;
						}
						num7++;
						j = 3;
						while (data.Length > i + j && data[i + j] == data[num8 + j] && j < 1028)
						{
							j++;
						}
						if (j > num6)
						{
							num6 = j;
							num2 = i - num8;
						}
					}
					if (num6 < 3)
					{
						num6 = 0;
					}
					else if (num6 < 4 && num2 > 1024)
					{
						num6 = 0;
					}
					else if (num6 < 5 && num2 > 16384)
					{
						num6 = 0;
					}
					if (num6 > 0)
					{
						while (i - num4 > 3)
						{
							for (j = i - num4; j > 113; j -= 113)
							{
							}
							j &= 252;
							int num9 = j >> 2;
							array2[num3++] = (byte)(223 + num9);
							for (int k = 0; k < j; k++)
							{
								array2[num3++] = data[num4++];
							}
						}
						j = i - num4;
						num2--;
						if (num6 <= 10 && num2 < 1024)
						{
							array2[num3++] = (byte)((num2 >> 3 & 96) | num6 - 3 << 2 | j);
							array2[num3++] = (byte)(num2 & 255);
						}
						else if (num6 <= 67 && num2 < 16384)
						{
							array2[num3++] = (byte)(128 | num6 - 4);
							array2[num3++] = (byte)(j << 6 | num2 >> 8);
							array2[num3++] = (byte)(num2 & 255);
						}
						else if (num6 <= 1028 && num2 < 131072)
						{
							array2[num3++] = (byte)((192 | (num2 >> 12 & 16)) + (num6 - 5 >> 6 & 12) | j);
							array2[num3++] = (byte)(num2 >> 8 & 255);
							array2[num3++] = (byte)(num2 & 255);
							array2[num3++] = (byte)(num6 - 5 & 255);
						}
						else
						{
							j = 0;
							num6 = 0;
						}
						for (int l = 0; l < j; l++)
						{
							array2[num3++] = data[num4++];
						}
						num4 += num6;
						continue;
					}
					continue;
					Block_4:
					flag = true;
					goto IL_98;
				}
				i = data.Length;
				num4 = Math.Min(i, num4);
				while (i - num4 > 3)
				{
					for (j = i - num4; j > 113; j -= 113)
					{
					}
					j &= 252;
					int num10 = j >> 2;
					array2[num3++] = (byte)(223 + num10);
					for (int m = 0; m < j; m++)
					{
						array2[num3++] = data[num4++];
					}
				}
				j = i - num4;
				array2[num3++] = (byte)(252 + j);
				for (int n = 0; n < j; n++)
				{
					array2[num3++] = data[num4++];
				}
				byte[] array3 = new byte[num3 + 9];
				byte[] bytes = BitConverter.GetBytes((uint)array3.Length);
				for (int num11 = 0; num11 < 4; num11++)
				{
					array3[num11] = bytes[num11];
				}
				bytes = BitConverter.GetBytes(value);
				for (int num12 = 0; num12 < 2; num12++)
				{
					array3[num12 + 4] = bytes[num12];
				}
				bytes = BitConverter.GetBytes((uint)data.Length);
				for (int num13 = 0; num13 < 3; num13++)
				{
					array3[num13 + 6] = bytes[2 - num13];
				}
				for (int num14 = 0; num14 < num3; num14++)
				{
					array3[num14 + 9] = array2[num14];
				}
				result = array3;
			}
			finally
			{
				foreach (ArrayList arrayList2 in array)
				{
					if (arrayList2 != null)
					{
						arrayList2.Clear();
					}
				}
				array = null;
				if (arrayList != null)
				{
					arrayList.Clear();
				}
				arrayList = null;
			}
			return result;
		}

		// Token: 0x060000A7 RID: 167 RVA: 0x0000EAAC File Offset: 0x0000CCAC
		public static byte[] Uncompress(BinaryReader reader, uint uncompressedSize, uint compressedSize)
		{
			byte[] array = new byte[compressedSize];
			array = reader.ReadBytes((int)compressedSize);
			byte[] array2 = new byte[uncompressedSize];
			int num = 0;
			int num2 = 0;
			while (num < array.Length && array[num] < 252)
			{
				byte b = array[num++];
				int num3;
				int num4;
				int num5;
				if ((b & 128) == 0)
				{
					byte b2 = array[num++];
					num3 = (int)(b & 3);
					num4 = ((b & 28) >> 2) + 3;
					num5 = ((int)(b & 96) << 3) + (int)b2 + 1;
				}
				else if ((b & 64) == 0)
				{
					byte b2 = array[num++];
					byte b3 = array[num++];
					num3 = (b2 & 192) >> 6;
					num4 = (int)((b & 63) + 4);
					num5 = ((int)(b2 & 63) << 8) + (int)b3 + 1;
				}
				else if ((b & 32) == 0)
				{
					byte b2 = array[num++];
					byte b3 = array[num++];
					byte b4 = array[num++];
					num3 = (int)(b & 3);
					num4 = ((int)(b & 12) << 6) + (int)b4 + 5;
					num5 = ((int)(b & 16) << 12) + ((int)b2 << 8) + (int)b3 + 1;
				}
				else
				{
					num3 = (int)(b - 223) << 2;
					num4 = 0;
					num5 = 0;
				}
				try
				{
					for (int i = 0; i < num3; i++)
					{
						array2[num2++] = array[num++];
					}
					int num6 = num2 - num5;
					for (int j = 0; j < num4; j++)
					{
						array2[num2++] = array2[num6++];
					}
				}
				catch (Exception ex)
				{
					throw new Exception("Unable to decompress file: " + ex.Message);
				}
			}
			if (num < array.Length)
			{
				int num3 = (int)(array[num++] & 3);
				int num7 = 0;
				while (num7 < num3 && num2 < array2.Length)
				{
					array2[num2++] = array[num++];
					num7++;
				}
			}
			return array2;
		}
	}
}
