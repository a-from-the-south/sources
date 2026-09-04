using System;

namespace Package.Helper
{
	// Token: 0x020000E4 RID: 228
	public static class NumberHelpers
	{
		// Token: 0x06000BBA RID: 3002 RVA: 0x000087FA File Offset: 0x000069FA
		public static short Swap(short value)
		{
			return (short)((ushort)((255 & value >> 8) | (65280 & (int)value << 8)));
		}

		// Token: 0x06000BBB RID: 3003 RVA: 0x00008811 File Offset: 0x00006A11
		public static ushort Swap(ushort value)
		{
			return (ushort)((255 & value >> 8) | (65280 & (int)value << 8));
		}

		// Token: 0x06000BBC RID: 3004 RVA: 0x0003A0D8 File Offset: 0x000382D8
		public static int Swap(int value)
		{
			return (int)((255U & (uint)value >> 24) | (65280U & (uint)value >> 8) | (uint)(16711680 & value << 8) | (uint)(-16777216 & value << 24));
		}

		// Token: 0x06000BBD RID: 3005 RVA: 0x00008827 File Offset: 0x00006A27
		public static int Swap24(int value)
		{
			return (255 & value >> 16) | (65280 & value) | (16711680 & value << 16);
		}

		// Token: 0x06000BBE RID: 3006 RVA: 0x00008846 File Offset: 0x00006A46
		public static uint Swap(uint value)
		{
			return (255U & value >> 24) | (65280U & value >> 8) | (16711680U & value << 8) | (4278190080U & value << 24);
		}

		// Token: 0x06000BBF RID: 3007 RVA: 0x00008871 File Offset: 0x00006A71
		public static uint Swap24(uint value)
		{
			return (255U & value >> 16) | (65280U & value) | (16711680U & value << 16);
		}

		// Token: 0x06000BC0 RID: 3008 RVA: 0x0003A110 File Offset: 0x00038310
		public static long Swap(long value)
		{
			return (long)((255UL & (ulong)value >> 56) | (65280UL & (ulong)value >> 40) | (16711680UL & (ulong)value >> 24) | (4278190080UL & (ulong)value >> 8) | (ulong)(1095216660480L & value << 8) | (ulong)(280375465082880L & value << 24) | (ulong)(71776119061217280L & value << 40) | (ulong)(-72057594037927936L & value << 56));
		}

		// Token: 0x06000BC1 RID: 3009 RVA: 0x0003A194 File Offset: 0x00038394
		public static ulong Swap(ulong value)
		{
			return (255UL & value >> 56) | (65280UL & value >> 40) | (16711680UL & value >> 24) | (4278190080UL & value >> 8) | (1095216660480UL & value << 8) | (280375465082880UL & value << 24) | (71776119061217280UL & value << 40) | (18374686479671623680UL & value << 56);
		}

		// Token: 0x06000BC2 RID: 3010 RVA: 0x0003A218 File Offset: 0x00038418
		public static sbyte Swap(sbyte value)
		{
			byte b = (byte)(value >> 7 & 1);
			byte b2 = (byte)(value >> 6 & 1);
			byte b3 = (byte)(value >> 5 & 1);
			byte b4 = (byte)(value >> 4 & 1);
			byte b5 = (byte)(value >> 3 & 1);
			byte b6 = (byte)(value >> 2 & 1);
			byte b7 = (byte)(value >> 1 & 1);
			return (sbyte)(((int)((byte)(value & 1)) << 7) + ((int)b7 << 6) + ((int)b6 << 5) + ((int)b5 << 4) + ((int)b4 << 3) + ((int)b3 << 2) + ((int)b2 << 1) + (int)b);
		}

		// Token: 0x06000BC3 RID: 3011 RVA: 0x0003A280 File Offset: 0x00038480
		public static int CountSetBits(int n)
		{
			int num = 0;
			while (n != 0)
			{
				num++;
				n &= n - 1;
			}
			return num;
		}
	}
}
