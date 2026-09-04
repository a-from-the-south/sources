using System;

namespace Package.Helper
{
	// Token: 0x020000E0 RID: 224
	public class Hashes
	{
		// Token: 0x170003BE RID: 958
		// (get) Token: 0x06000B98 RID: 2968 RVA: 0x0000860E File Offset: 0x0000680E
		public static CRC Crc24
		{
			get
			{
				return Hashes.crc24;
			}
		}

		// Token: 0x170003BF RID: 959
		// (get) Token: 0x06000B99 RID: 2969 RVA: 0x00008615 File Offset: 0x00006815
		public static CRC Crc32
		{
			get
			{
				return Hashes.crc32;
			}
		}

		// Token: 0x06000B9A RID: 2970 RVA: 0x00039E14 File Offset: 0x00038014
		public static long CRC24(uint seed, uint poly, char[] octets)
		{
			long num = (long)((ulong)seed);
			for (int i = 0; i < octets.Length; i++)
			{
				num ^= (long)((long)octets[i] << 16);
				for (int j = 0; j < 8; j++)
				{
					num <<= 1;
					if ((num & 16777216L) != 0L)
					{
						num ^= (long)((ulong)poly);
					}
				}
			}
			return num & 16777215L;
		}

		// Token: 0x06000B9B RID: 2971 RVA: 0x00039E6C File Offset: 0x0003806C
		public static ulong ToLong(byte[] input)
		{
			ulong num = 0UL;
			foreach (byte b in input)
			{
				num <<= 8;
				num += (ulong)b;
			}
			return num;
		}

		// Token: 0x06000B9C RID: 2972 RVA: 0x0000861C File Offset: 0x0000681C
		public static uint FileGroupHash(string filename)
		{
			filename = filename.Trim().ToLower();
			return (uint)(Hashes.ToLong(Hashes.crc24.ComputeHash(Helper.ToBytes(filename, 0))) | 2130706432UL);
		}

		// Token: 0x06000B9D RID: 2973 RVA: 0x0000861C File Offset: 0x0000681C
		public static uint GroupHash(string name)
		{
			name = name.Trim().ToLower();
			return (uint)(Hashes.ToLong(Hashes.crc24.ComputeHash(Helper.ToBytes(name, 0))) | 2130706432UL);
		}

		// Token: 0x06000B9E RID: 2974 RVA: 0x0000864C File Offset: 0x0000684C
		public static uint InstanceHighHash(string filename)
		{
			filename = filename.Trim().ToLower();
			return (uint)Hashes.ToLong(Hashes.crc32.ComputeHash(Helper.ToBytes(filename, 0)));
		}

		// Token: 0x06000B9F RID: 2975 RVA: 0x00008672 File Offset: 0x00006872
		public static uint InstanceHash(string filename)
		{
			filename = filename.Trim().ToLower();
			return (uint)(Hashes.ToLong(Hashes.crc24.ComputeHash(Helper.ToBytes(filename, 0))) | 4278190080UL);
		}

		// Token: 0x06000BA0 RID: 2976 RVA: 0x0000864C File Offset: 0x0000684C
		public static uint SubTypeHash(string filename)
		{
			filename = filename.Trim().ToLower();
			return (uint)Hashes.ToLong(Hashes.crc32.ComputeHash(Helper.ToBytes(filename, 0)));
		}

		// Token: 0x06000BA1 RID: 2977 RVA: 0x000086A2 File Offset: 0x000068A2
		public static uint GetCrc32(string s)
		{
			return (uint)Hashes.ToLong(Hashes.crc32.ComputeHash(Helper.ToBytes(s, 0)));
		}

		// Token: 0x06000BA2 RID: 2978 RVA: 0x000086BB File Offset: 0x000068BB
		public static uint GetCrc24(string s)
		{
			return (uint)Hashes.ToLong(Hashes.crc24.ComputeHash(Helper.ToBytes(s, 0)));
		}

		// Token: 0x06000BA3 RID: 2979 RVA: 0x000086D4 File Offset: 0x000068D4
		public static string StripAllFromName(string filename)
		{
			if (filename == null)
			{
				return "";
			}
			filename = Hashes.StripHashFromName(filename);
			if (filename.IndexOf("]") >= 0)
			{
				return filename.Split("]".ToCharArray(), 2)[1];
			}
			return filename;
		}

		// Token: 0x06000BA4 RID: 2980 RVA: 0x0000870A File Offset: 0x0000690A
		public static string StripHashFromName(string filename)
		{
			if (filename == null)
			{
				return "";
			}
			if (filename.IndexOf("#") == 0 && filename.IndexOf("!") >= 1)
			{
				return filename.Split("!".ToCharArray(), 2)[1];
			}
			return filename;
		}

		// Token: 0x06000BA5 RID: 2981 RVA: 0x00008745 File Offset: 0x00006945
		public static uint GetHashGroupFromName(string filename)
		{
			return Hashes.GetHashGroupFromName(filename, 475004928U);
		}

		// Token: 0x06000BA6 RID: 2982 RVA: 0x00039EA4 File Offset: 0x000380A4
		public static uint GetHashGroupFromName(string filename, uint defGroup)
		{
			if (filename.IndexOf("#") == 0 && filename.IndexOf("!") >= 1)
			{
				string value = filename.Split("!".ToCharArray(), 2)[0].Replace("#", "").Replace("!", "");
				uint result;
				try
				{
					result = Convert.ToUInt32(value, 16);
				}
				catch (Exception)
				{
					result = defGroup;
				}
				return result;
			}
			return defGroup;
		}

		// Token: 0x06000BA7 RID: 2983 RVA: 0x00008752 File Offset: 0x00006952
		public static string AssembleHashedFileName(uint hash, string filename)
		{
			return "#0x" + Helper.MinStrLength(hash.ToString("x"), 8) + "!" + filename;
		}

		// Token: 0x06000BA8 RID: 2984 RVA: 0x00008776 File Offset: 0x00006976
		public static string GenerateFamilyName()
		{
			return Hashes.GenerateFamilyName(5);
		}

		// Token: 0x06000BA9 RID: 2985 RVA: 0x00039F24 File Offset: 0x00038124
		public static string GenerateFamilyName(int maxParts)
		{
			string text = "";
			int[] array = new int[]
			{
				7,
				4,
				4,
				4,
				12
			};
			for (int i = 0; i < maxParts; i++)
			{
				for (int j = 0; j < array[i]; j++)
				{
					text += Hashes.rand.Next(0, 9).ToString();
				}
				if (i < maxParts - 1)
				{
					text += "-";
				}
			}
			return text;
		}

		// Token: 0x04000591 RID: 1425
		private static CRC crc24 = new CRC(CRCParameters.GetParameters(CRCStandard.CRC24));

		// Token: 0x04000592 RID: 1426
		private static CRC crc32 = new CRC(new CRCParameters(32, 79764919L, 4294967295L, 0L, false));

		// Token: 0x04000593 RID: 1427
		public const uint CRC24Seed = 11994318U;

		// Token: 0x04000594 RID: 1428
		public const uint CRC24Poly = 25578747U;

		// Token: 0x04000595 RID: 1429
		public const uint CRC32Seed = 11994318U;

		// Token: 0x04000596 RID: 1430
		public const uint CRC32Poly = 25578747U;

		// Token: 0x04000597 RID: 1431
		private static Random rand = new Random((int)DateTime.Now.Ticks);
	}
}
