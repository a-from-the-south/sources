using System;
using System.ComponentModel;
using System.Drawing;
using Microsoft.Win32;
using ns14;

namespace ns20
{
	// Token: 0x02000190 RID: 400
	[TypeConverter(typeof(Class180.Class150))]
	internal sealed class Class180
	{
		// Token: 0x06001217 RID: 4631 RVA: 0x00002BA3 File Offset: 0x00000DA3
		private Class180()
		{
		}

		// Token: 0x06001218 RID: 4632 RVA: 0x00009926 File Offset: 0x00007B26
		private Class180(Color backColor, Color backColorGradient, Color borderColor, Color textColor)
		{
			this.backColor = backColor;
			this.backColorGradient = backColorGradient;
			this.borderColor = borderColor;
			this.textColor = textColor;
		}

		// Token: 0x06001219 RID: 4633 RVA: 0x000BF784 File Offset: 0x000BD984
		static Class180()
		{
			SystemEvents.UserPreferenceChanged += Class180.smethod_0;
			Class180.smethod_1();
		}

		// Token: 0x170003ED RID: 1005
		// (get) Token: 0x0600121A RID: 4634 RVA: 0x000BFB40 File Offset: 0x000BDD40
		[Attribute0]
		public static Class180 AutoSelect
		{
			get
			{
				return Class180.class180_0;
			}
		}

		// Token: 0x170003EE RID: 1006
		// (get) Token: 0x0600121B RID: 4635 RVA: 0x000BFB58 File Offset: 0x000BDD58
		[Attribute0]
		public static Class180 XPBlue
		{
			get
			{
				return Class180.class180_1;
			}
		}

		// Token: 0x170003EF RID: 1007
		// (get) Token: 0x0600121C RID: 4636 RVA: 0x000BFB70 File Offset: 0x000BDD70
		[Attribute0]
		public static Class180 XPGreen
		{
			get
			{
				return Class180.class180_2;
			}
		}

		// Token: 0x170003F0 RID: 1008
		// (get) Token: 0x0600121D RID: 4637 RVA: 0x000BFB88 File Offset: 0x000BDD88
		[Attribute0]
		public static Class180 XPSilver
		{
			get
			{
				return Class180.class180_3;
			}
		}

		// Token: 0x170003F1 RID: 1009
		// (get) Token: 0x0600121E RID: 4638 RVA: 0x000BFBA0 File Offset: 0x000BDDA0
		[Attribute0]
		public static Class180 Control
		{
			get
			{
				return Class180.class180_4;
			}
		}

		// Token: 0x170003F2 RID: 1010
		// (get) Token: 0x0600121F RID: 4639 RVA: 0x000BFBB8 File Offset: 0x000BDDB8
		[Attribute0]
		public static Class180 Brown
		{
			get
			{
				return Class180.class180_5;
			}
		}

		// Token: 0x170003F3 RID: 1011
		// (get) Token: 0x06001220 RID: 4640 RVA: 0x000BFBD0 File Offset: 0x000BDDD0
		[Attribute0]
		public static Class180 Hazel
		{
			get
			{
				return Class180.class180_6;
			}
		}

		// Token: 0x170003F4 RID: 1012
		// (get) Token: 0x06001221 RID: 4641 RVA: 0x000BFBE8 File Offset: 0x000BDDE8
		[Attribute0]
		public static Class180 Cyan
		{
			get
			{
				return Class180.class180_7;
			}
		}

		// Token: 0x170003F5 RID: 1013
		// (get) Token: 0x06001222 RID: 4642 RVA: 0x000BFC00 File Offset: 0x000BDE00
		[Attribute0]
		public static Class180 Pink
		{
			get
			{
				return Class180.class180_8;
			}
		}

		// Token: 0x170003F6 RID: 1014
		// (get) Token: 0x06001223 RID: 4643 RVA: 0x000BFC18 File Offset: 0x000BDE18
		[Attribute0]
		public static Class180 Violet
		{
			get
			{
				return Class180.class180_9;
			}
		}

		// Token: 0x170003F7 RID: 1015
		// (get) Token: 0x06001224 RID: 4644 RVA: 0x000BFC30 File Offset: 0x000BDE30
		[Attribute0]
		public static Class180 Red
		{
			get
			{
				return Class180.class180_10;
			}
		}

		// Token: 0x170003F8 RID: 1016
		// (get) Token: 0x06001225 RID: 4645 RVA: 0x000BFC48 File Offset: 0x000BDE48
		[Attribute0]
		public static Class180 ToolTip
		{
			get
			{
				return Class180.class180_11;
			}
		}

		// Token: 0x170003F9 RID: 1017
		// (get) Token: 0x06001226 RID: 4646 RVA: 0x000BFC60 File Offset: 0x000BDE60
		[Attribute0]
		public static Class180 DeepBlue
		{
			get
			{
				return Class180.class180_12;
			}
		}

		// Token: 0x170003FA RID: 1018
		// (get) Token: 0x06001227 RID: 4647 RVA: 0x000BFC78 File Offset: 0x000BDE78
		[Attribute0]
		public static Class180 Smoke
		{
			get
			{
				return Class180.class180_13;
			}
		}

		// Token: 0x170003FB RID: 1019
		// (get) Token: 0x06001228 RID: 4648 RVA: 0x000BFC90 File Offset: 0x000BDE90
		[Attribute0]
		public static Class180 Midnight
		{
			get
			{
				return Class180.class180_14;
			}
		}

		// Token: 0x06001229 RID: 4649 RVA: 0x0000994D File Offset: 0x00007B4D
		private static void smethod_0(object sender, UserPreferenceChangedEventArgs e)
		{
			if (e.Category == UserPreferenceCategory.Color)
			{
				Class180.smethod_1();
			}
		}

		// Token: 0x0600122A RID: 4650 RVA: 0x000BFCA8 File Offset: 0x000BDEA8
		private static void smethod_1()
		{
			float hue = SystemColors.ActiveCaption.GetHue();
			Class180 @class;
			if (hue >= 200f && hue <= 250f)
			{
				@class = Class180.XPBlue;
			}
			else if (hue >= 70f && hue <= 120f)
			{
				@class = Class180.XPGreen;
			}
			else if (hue != 0f && SystemColors.ActiveCaption.GetSaturation() >= 0.1f)
			{
				@class = Class180.Control;
			}
			else
			{
				@class = Class180.XPSilver;
			}
			Class180.class180_0 = (Class180)@class.MemberwiseClone();
		}

		// Token: 0x04000C91 RID: 3217
		internal Color backColor;

		// Token: 0x04000C92 RID: 3218
		internal Color backColorGradient;

		// Token: 0x04000C93 RID: 3219
		internal Color borderColor;

		// Token: 0x04000C94 RID: 3220
		internal Color textColor;

		// Token: 0x04000C95 RID: 3221
		private static Class180 class180_0;

		// Token: 0x04000C96 RID: 3222
		private static Class180 class180_1 = new Class180(Color.FromArgb(255, 255, 255), Color.FromArgb(201, 217, 239), Color.FromArgb(111, 121, 133), Color.FromArgb(64, 64, 64));

		// Token: 0x04000C97 RID: 3223
		private static Class180 class180_2 = new Class180(Color.FromArgb(245, 255, 215), Color.FromArgb(197, 210, 155), Color.FromArgb(123, 140, 119), Color.FromArgb(64, 64, 64));

		// Token: 0x04000C98 RID: 3224
		private static Class180 class180_3 = new Class180(Color.FromArgb(251, 251, 251), Color.FromArgb(220, 220, 220), Color.FromArgb(128, 128, 128), Color.FromArgb(64, 64, 64));

		// Token: 0x04000C99 RID: 3225
		private static Class180 class180_4 = new Class180(SystemColors.ControlLightLight, SystemColors.Control, SystemColors.ControlDark, SystemColors.ControlText);

		// Token: 0x04000C9A RID: 3226
		private static Class180 class180_5 = new Class180(Color.FromArgb(255, 249, 249), Color.FromArgb(233, 222, 208), Color.FromArgb(138, 128, 118), Color.FromArgb(64, 64, 64));

		// Token: 0x04000C9B RID: 3227
		private static Class180 class180_6 = new Class180(Color.FromArgb(255, 252, 249), Color.FromArgb(232, 233, 208), Color.FromArgb(140, 140, 119), Color.FromArgb(64, 64, 64));

		// Token: 0x04000C9C RID: 3228
		private static Class180 class180_7 = new Class180(Color.FromArgb(248, 254, 251), Color.FromArgb(208, 228, 233), Color.FromArgb(118, 135, 138), Color.FromArgb(64, 64, 64));

		// Token: 0x04000C9D RID: 3229
		private static Class180 class180_8 = new Class180(Color.FromArgb(254, 248, 253), Color.FromArgb(233, 208, 212), Color.FromArgb(138, 118, 123), Color.FromArgb(64, 64, 64));

		// Token: 0x04000C9E RID: 3230
		private static Class180 class180_9 = new Class180(Color.FromArgb(248, 248, 254), Color.FromArgb(227, 208, 233), Color.FromArgb(132, 118, 138), Color.FromArgb(64, 64, 64));

		// Token: 0x04000C9F RID: 3231
		private static Class180 class180_10 = new Class180(Color.FromArgb(243, 217, 207), Color.IndianRed, Color.FromArgb(132, 96, 96), Color.FromArgb(48, 32, 32));

		// Token: 0x04000CA0 RID: 3232
		private static Class180 class180_11 = new Class180(SystemColors.Info, SystemColors.Info, SystemColors.WindowFrame, SystemColors.InfoText);

		// Token: 0x04000CA1 RID: 3233
		private static Class180 class180_12 = new Class180(Color.FromArgb(221, 236, 254), Color.FromArgb(129, 169, 226), Color.FromArgb(59, 97, 156), Color.FromArgb(0, 0, 0));

		// Token: 0x04000CA2 RID: 3234
		private static Class180 class180_13 = new Class180(Color.FromArgb(240, 240, 240), Color.FromArgb(224, 224, 224), Color.FromArgb(128, 128, 128), Color.FromArgb(0, 0, 0));

		// Token: 0x04000CA3 RID: 3235
		private static Class180 class180_14 = new Class180(Color.Gray, Color.Black, Color.Silver, Color.White);

		// Token: 0x02000191 RID: 401
		internal sealed class Class150 : Class149
		{
			// Token: 0x0600122B RID: 4651 RVA: 0x0000995F File Offset: 0x00007B5F
			public Class150() : base(typeof(Class180))
			{
			}
		}
	}
}
