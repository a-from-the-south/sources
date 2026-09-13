using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Security;
using System.Windows.Forms;

namespace ns17
{
	// Token: 0x020000EF RID: 239
	internal sealed class Class101
	{
		// Token: 0x060009B7 RID: 2487
		[SuppressUnmanagedCodeSecurity]
		[DllImport("winmm.dll")]
		public static extern IntPtr timeBeginPeriod(uint uint_0);

		// Token: 0x060009B8 RID: 2488
		[SuppressUnmanagedCodeSecurity]
		[DllImport("kernel32")]
		public static extern bool QueryPerformanceFrequency(ref long long_0);

		// Token: 0x060009B9 RID: 2489
		[SuppressUnmanagedCodeSecurity]
		[DllImport("kernel32")]
		public static extern bool QueryPerformanceCounter(ref long long_0);

		// Token: 0x060009BA RID: 2490
		[SuppressUnmanagedCodeSecurity]
		[DllImport("User32.dll", CharSet = CharSet.Auto)]
		public static extern bool GetMonitorInfo(IntPtr intptr_0, ref Class101.Struct4 struct4_0);

		// Token: 0x060009BB RID: 2491
		[SuppressUnmanagedCodeSecurity]
		[DllImport("User32.dll", CharSet = CharSet.Auto)]
		public static extern IntPtr MonitorFromWindow(IntPtr intptr_0, uint uint_0);

		// Token: 0x060009BC RID: 2492
		[SuppressUnmanagedCodeSecurity]
		[DllImport("User32.dll", CharSet = CharSet.Auto)]
		public static extern short GetAsyncKeyState(uint uint_0);

		// Token: 0x060009BD RID: 2493
		[SuppressUnmanagedCodeSecurity]
		[DllImport("User32.dll", CharSet = CharSet.Auto)]
		public static extern IntPtr SetCapture(IntPtr intptr_0);

		// Token: 0x060009BE RID: 2494
		[SuppressUnmanagedCodeSecurity]
		[DllImport("User32.dll", CharSet = CharSet.Auto)]
		public static extern bool ReleaseCapture();

		// Token: 0x060009BF RID: 2495
		[SuppressUnmanagedCodeSecurity]
		[DllImport("User32.dll", CharSet = CharSet.Auto)]
		public static extern int GetCaretBlinkTime();

		// Token: 0x060009C0 RID: 2496
		[SuppressUnmanagedCodeSecurity]
		[DllImport("User32.dll", CharSet = CharSet.Auto)]
		public static extern bool PeekMessage(out Class101.Struct2 struct2_0, IntPtr intptr_0, uint uint_0, uint uint_1, uint uint_2);

		// Token: 0x060009C1 RID: 2497
		[SuppressUnmanagedCodeSecurity]
		[DllImport("User32.dll", CharSet = CharSet.Auto)]
		public static extern int SendMessage(IntPtr intptr_0, int int_0, int int_1, int int_2);

		// Token: 0x060009C2 RID: 2498 RVA: 0x00002BA3 File Offset: 0x00000DA3
		private Class101()
		{
		}

		// Token: 0x060009C3 RID: 2499 RVA: 0x00085558 File Offset: 0x00083758
		public static short smethod_0(uint uint_0)
		{
			return (short)(uint_0 & 65535U);
		}

		// Token: 0x060009C4 RID: 2500 RVA: 0x00085574 File Offset: 0x00083774
		public static short smethod_1(uint uint_0)
		{
			return (short)(uint_0 >> 16);
		}

		// Token: 0x060009C5 RID: 2501 RVA: 0x0008558C File Offset: 0x0008378C
		public static uint smethod_2(short short_0, short short_1)
		{
			return ((uint)short_0 & 65535U) | ((uint)short_1 & 65535U) << 16;
		}

		// Token: 0x060009C6 RID: 2502 RVA: 0x000855B0 File Offset: 0x000837B0
		public static bool smethod_3(Keys keys_0)
		{
			return ((int)Class101.GetAsyncKeyState(16U) & 32768) != 0;
		}

		// Token: 0x020000F0 RID: 240
		public enum Enum15 : uint
		{
			// Token: 0x040007D8 RID: 2008
			const_0 = 2U,
			// Token: 0x040007D9 RID: 2009
			const_1 = 16U,
			// Token: 0x040007DA RID: 2010
			const_2 = 18U,
			// Token: 0x040007DB RID: 2011
			const_3 = 15U,
			// Token: 0x040007DC RID: 2012
			const_4 = 32U,
			// Token: 0x040007DD RID: 2013
			const_5 = 28U,
			// Token: 0x040007DE RID: 2014
			const_6 = 529U,
			// Token: 0x040007DF RID: 2015
			const_7,
			// Token: 0x040007E0 RID: 2016
			const_8 = 132U,
			// Token: 0x040007E1 RID: 2017
			const_9 = 536U,
			// Token: 0x040007E2 RID: 2018
			const_10 = 274U,
			// Token: 0x040007E3 RID: 2019
			const_11 = 36U,
			// Token: 0x040007E4 RID: 2020
			const_12 = 256U,
			// Token: 0x040007E5 RID: 2021
			const_13,
			// Token: 0x040007E6 RID: 2022
			const_14,
			// Token: 0x040007E7 RID: 2023
			const_15 = 260U,
			// Token: 0x040007E8 RID: 2024
			const_16,
			// Token: 0x040007E9 RID: 2025
			const_17,
			// Token: 0x040007EA RID: 2026
			const_18 = 512U,
			// Token: 0x040007EB RID: 2027
			const_19,
			// Token: 0x040007EC RID: 2028
			const_20,
			// Token: 0x040007ED RID: 2029
			const_21,
			// Token: 0x040007EE RID: 2030
			const_22,
			// Token: 0x040007EF RID: 2031
			const_23,
			// Token: 0x040007F0 RID: 2032
			const_24,
			// Token: 0x040007F1 RID: 2033
			const_25,
			// Token: 0x040007F2 RID: 2034
			const_26,
			// Token: 0x040007F3 RID: 2035
			const_27,
			// Token: 0x040007F4 RID: 2036
			const_28,
			// Token: 0x040007F5 RID: 2037
			const_29,
			// Token: 0x040007F6 RID: 2038
			const_30,
			// Token: 0x040007F7 RID: 2039
			const_31,
			// Token: 0x040007F8 RID: 2040
			const_32 = 513U,
			// Token: 0x040007F9 RID: 2041
			const_33 = 525U,
			// Token: 0x040007FA RID: 2042
			const_34 = 561U,
			// Token: 0x040007FB RID: 2043
			const_35,
			// Token: 0x040007FC RID: 2044
			const_36 = 5U
		}

		// Token: 0x020000F1 RID: 241
		public enum Enum16
		{
			// Token: 0x040007FE RID: 2046
			const_0 = 1,
			// Token: 0x040007FF RID: 2047
			const_1,
			// Token: 0x04000800 RID: 2048
			const_2 = 16,
			// Token: 0x04000801 RID: 2049
			const_3 = 32,
			// Token: 0x04000802 RID: 2050
			const_4 = 64
		}

		// Token: 0x020000F2 RID: 242
		public struct Struct2
		{
			// Token: 0x04000803 RID: 2051
			public IntPtr intptr_0;

			// Token: 0x04000804 RID: 2052
			public Class101.Enum15 enum15_0;

			// Token: 0x04000805 RID: 2053
			public IntPtr intptr_1;

			// Token: 0x04000806 RID: 2054
			public IntPtr intptr_2;

			// Token: 0x04000807 RID: 2055
			public uint uint_0;

			// Token: 0x04000808 RID: 2056
			public Point point_0;
		}

		// Token: 0x020000F3 RID: 243
		public struct Struct3
		{
			// Token: 0x04000809 RID: 2057
			public Point point_0;

			// Token: 0x0400080A RID: 2058
			public Point point_1;

			// Token: 0x0400080B RID: 2059
			public Point point_2;

			// Token: 0x0400080C RID: 2060
			public Point point_3;

			// Token: 0x0400080D RID: 2061
			public Point point_4;
		}

		// Token: 0x020000F4 RID: 244
		public struct Struct4
		{
			// Token: 0x0400080E RID: 2062
			public uint uint_0;

			// Token: 0x0400080F RID: 2063
			public Rectangle rectangle_0;

			// Token: 0x04000810 RID: 2064
			public Rectangle rectangle_1;

			// Token: 0x04000811 RID: 2065
			public uint uint_1;
		}
	}
}
