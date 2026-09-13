using System;
using System.Collections.Specialized;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using Sims3Workshop.Control;

namespace ns8
{
	// Token: 0x02000098 RID: 152
	internal sealed class Class65 : RichTextBox
	{
		// Token: 0x17000104 RID: 260
		// (get) Token: 0x06000612 RID: 1554 RVA: 0x0005D3B0 File Offset: 0x0005B5B0
		protected CreateParams CreateParams
		{
			get
			{
				CreateParams createParams = base.CreateParams;
				createParams.ExStyle |= 32;
				return createParams;
			}
		}

		// Token: 0x06000613 RID: 1555 RVA: 0x00002A71 File Offset: 0x00000C71
		protected void OnPaintBackground(PaintEventArgs pevent)
		{
		}

		// Token: 0x17000105 RID: 261
		// (get) Token: 0x06000614 RID: 1556 RVA: 0x0005D3D8 File Offset: 0x0005B5D8
		// (set) Token: 0x06000615 RID: 1557 RVA: 0x000051EE File Offset: 0x000033EE
		public new string Rtf
		{
			get
			{
				return this.method_16(base.Rtf);
			}
			set
			{
				base.Rtf = value;
			}
		}

		// Token: 0x17000106 RID: 262
		// (get) Token: 0x06000616 RID: 1558 RVA: 0x0005D3F8 File Offset: 0x0005B5F8
		// (set) Token: 0x06000617 RID: 1559 RVA: 0x000051F9 File Offset: 0x000033F9
		public RtfColor TextColor
		{
			get
			{
				return this._textColor;
			}
			set
			{
				this._textColor = value;
			}
		}

		// Token: 0x17000107 RID: 263
		// (get) Token: 0x06000618 RID: 1560 RVA: 0x0005D410 File Offset: 0x0005B610
		// (set) Token: 0x06000619 RID: 1561 RVA: 0x00005204 File Offset: 0x00003404
		public RtfColor HiglightColor
		{
			get
			{
				return this._highlightColor;
			}
			set
			{
				this._highlightColor = value;
			}
		}

		// Token: 0x0600061A RID: 1562 RVA: 0x0005D428 File Offset: 0x0005B628
		public Class65()
		{
			this._textColor = RtfColor.Black;
			this._highlightColor = RtfColor.White;
			this.hybridDictionary_0 = new HybridDictionary();
			this.hybridDictionary_0.Add(RtfColor.Aqua, "\\red0\\green255\\blue255");
			this.hybridDictionary_0.Add(RtfColor.Black, "\\red0\\green0\\blue0");
			this.hybridDictionary_0.Add(RtfColor.Blue, "\\red0\\green0\\blue255");
			this.hybridDictionary_0.Add(RtfColor.Fuchsia, "\\red255\\green0\\blue255");
			this.hybridDictionary_0.Add(RtfColor.Gray, "\\red128\\green128\\blue128");
			this.hybridDictionary_0.Add(RtfColor.Green, "\\red0\\green128\\blue0");
			this.hybridDictionary_0.Add(RtfColor.Lime, "\\red0\\green255\\blue0");
			this.hybridDictionary_0.Add(RtfColor.Maroon, "\\red128\\green0\\blue0");
			this.hybridDictionary_0.Add(RtfColor.Navy, "\\red0\\green0\\blue128");
			this.hybridDictionary_0.Add(RtfColor.Olive, "\\red128\\green128\\blue0");
			this.hybridDictionary_0.Add(RtfColor.Purple, "\\red128\\green0\\blue128");
			this.hybridDictionary_0.Add(RtfColor.Red, "\\red255\\green0\\blue0");
			this.hybridDictionary_0.Add(RtfColor.Silver, "\\red192\\green192\\blue192");
			this.hybridDictionary_0.Add(RtfColor.Teal, "\\red0\\green128\\blue128");
			this.hybridDictionary_0.Add(RtfColor.White, "\\red255\\green255\\blue255");
			this.hybridDictionary_0.Add(RtfColor.Yellow, "\\red255\\green255\\blue0");
			this.hybridDictionary_1 = new HybridDictionary();
			this.hybridDictionary_1.Add(FontFamily.GenericMonospace.Name, "\\fmodern");
			this.hybridDictionary_1.Add(FontFamily.GenericSansSerif, "\\fswiss");
			this.hybridDictionary_1.Add(FontFamily.GenericSerif, "\\froman");
			this.hybridDictionary_1.Add("UNKNOWN", "\\fnil");
			using (Graphics graphics = base.CreateGraphics())
			{
				this.float_0 = graphics.DpiX;
				this.float_1 = graphics.DpiY;
			}
		}

		// Token: 0x0600061B RID: 1563 RVA: 0x0000520F File Offset: 0x0000340F
		public Class65(RtfColor _textColor) : this()
		{
			this._textColor = _textColor;
		}

		// Token: 0x0600061C RID: 1564 RVA: 0x00005220 File Offset: 0x00003420
		public Class65(RtfColor _textColor, RtfColor _highlightColor) : this()
		{
			this._textColor = _textColor;
			this._highlightColor = _highlightColor;
		}

		// Token: 0x0600061D RID: 1565 RVA: 0x00005238 File Offset: 0x00003438
		public void method_0(string string_5)
		{
			base.Select(this.TextLength, 0);
			base.SelectedRtf = string_5;
		}

		// Token: 0x0600061E RID: 1566 RVA: 0x00005250 File Offset: 0x00003450
		public void method_1(string string_5)
		{
			base.SelectedRtf = string_5;
		}

		// Token: 0x0600061F RID: 1567 RVA: 0x0000525B File Offset: 0x0000345B
		public void method_2(string string_5)
		{
			this.method_3(string_5, this.Font);
		}

		// Token: 0x06000620 RID: 1568 RVA: 0x0000526C File Offset: 0x0000346C
		public void method_3(string string_5, Font font_0)
		{
			this.method_4(string_5, font_0, this._textColor);
		}

		// Token: 0x06000621 RID: 1569 RVA: 0x0000527E File Offset: 0x0000347E
		public void method_4(string string_5, Font font_0, RtfColor rtfColor_0)
		{
			this.method_5(string_5, font_0, rtfColor_0, this._highlightColor);
		}

		// Token: 0x06000622 RID: 1570 RVA: 0x00005291 File Offset: 0x00003491
		public void method_5(string string_5, Font font_0, RtfColor rtfColor_0, RtfColor rtfColor_1)
		{
			base.Select(this.TextLength, 0);
			this.method_9(string_5, font_0, rtfColor_0, rtfColor_1);
		}

		// Token: 0x06000623 RID: 1571 RVA: 0x000052AD File Offset: 0x000034AD
		public void method_6(string string_5)
		{
			this.method_7(string_5, this.Font);
		}

		// Token: 0x06000624 RID: 1572 RVA: 0x000052BE File Offset: 0x000034BE
		public void method_7(string string_5, Font font_0)
		{
			this.method_8(string_5, font_0, this._textColor);
		}

		// Token: 0x06000625 RID: 1573 RVA: 0x000052D0 File Offset: 0x000034D0
		public void method_8(string string_5, Font font_0, RtfColor rtfColor_0)
		{
			this.method_9(string_5, font_0, rtfColor_0, this._highlightColor);
		}

		// Token: 0x06000626 RID: 1574 RVA: 0x0005D668 File Offset: 0x0005B868
		public void method_9(string string_5, Font font_0, RtfColor rtfColor_0, RtfColor rtfColor_1)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("{\\rtf1\\ansi\\ansicpg1252\\deff0\\deflang1033");
			stringBuilder.Append(this.method_14(font_0));
			stringBuilder.Append(this.method_15(rtfColor_0, rtfColor_1));
			stringBuilder.Append(this.method_10(string_5, font_0));
			base.SelectedRtf = stringBuilder.ToString();
		}

		// Token: 0x06000627 RID: 1575 RVA: 0x0005D6C4 File Offset: 0x0005B8C4
		private string method_10(string string_5, Font font_0)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("\\viewkind4\\uc1\\pard\\cf1\\f0\\fs20");
			stringBuilder.Append("\\highlight2");
			if (font_0.Bold)
			{
				stringBuilder.Append("\\b");
			}
			if (font_0.Italic)
			{
				stringBuilder.Append("\\i");
			}
			if (font_0.Strikeout)
			{
				stringBuilder.Append("\\strike");
			}
			if (font_0.Underline)
			{
				stringBuilder.Append("\\ul");
			}
			stringBuilder.Append("\\f0");
			stringBuilder.Append("\\fs");
			stringBuilder.Append((int)Math.Round((double)(2f * font_0.SizeInPoints)));
			stringBuilder.Append(" ");
			stringBuilder.Append(string_5.Replace("\n", "\\par "));
			stringBuilder.Append("\\highlight0");
			if (font_0.Bold)
			{
				stringBuilder.Append("\\b0");
			}
			if (font_0.Italic)
			{
				stringBuilder.Append("\\i0");
			}
			if (font_0.Strikeout)
			{
				stringBuilder.Append("\\strike0");
			}
			if (font_0.Underline)
			{
				stringBuilder.Append("\\ulnone");
			}
			stringBuilder.Append("\\f0");
			stringBuilder.Append("\\fs20");
			stringBuilder.Append("\\cf0\\fs17}");
			return stringBuilder.ToString();
		}

		// Token: 0x06000628 RID: 1576 RVA: 0x0005D820 File Offset: 0x0005BA20
		public void method_11(Image image_0)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("{\\rtf1\\ansi\\ansicpg1252\\deff0\\deflang1033");
			stringBuilder.Append(this.method_14(this.Font));
			stringBuilder.Append(this.method_12(image_0));
			stringBuilder.Append(this.method_13(image_0));
			stringBuilder.Append(this.string_4);
			base.SelectedRtf = stringBuilder.ToString();
		}

		// Token: 0x06000629 RID: 1577 RVA: 0x0005D88C File Offset: 0x0005BA8C
		private string method_12(Image image_0)
		{
			StringBuilder stringBuilder = new StringBuilder();
			int value = (int)Math.Round((double)((float)image_0.Width / this.float_0 * 2540f));
			int value2 = (int)Math.Round((double)((float)image_0.Height / this.float_1 * 2540f));
			int value3 = (int)Math.Round((double)((float)image_0.Width / this.float_0 * 1440f));
			int value4 = (int)Math.Round((double)((float)image_0.Height / this.float_1 * 1440f));
			stringBuilder.Append("{\\pict\\wmetafile8");
			stringBuilder.Append("\\picw");
			stringBuilder.Append(value);
			stringBuilder.Append("\\pich");
			stringBuilder.Append(value2);
			stringBuilder.Append("\\picwgoal");
			stringBuilder.Append(value3);
			stringBuilder.Append("\\pichgoal");
			stringBuilder.Append(value4);
			stringBuilder.Append(" ");
			return stringBuilder.ToString();
		}

		// Token: 0x0600062A RID: 1578
		[DllImport("gdiplus.dll")]
		private static extern uint GdipEmfToWmfBits(IntPtr intptr_0, uint uint_0, byte[] byte_0, int int_10, Class65.Enum10 enum10_0);

		// Token: 0x0600062B RID: 1579 RVA: 0x0005D988 File Offset: 0x0005BB88
		private string method_13(Image image_0)
		{
			StringBuilder stringBuilder = null;
			MemoryStream memoryStream = null;
			Graphics graphics = null;
			Metafile metafile = null;
			string result;
			try
			{
				stringBuilder = new StringBuilder();
				memoryStream = new MemoryStream();
				Graphics graphics2;
				graphics = (graphics2 = base.CreateGraphics());
				try
				{
					IntPtr hdc = graphics.GetHdc();
					metafile = new Metafile(memoryStream, hdc);
					graphics.ReleaseHdc(hdc);
				}
				finally
				{
					if (graphics2 != null)
					{
						((IDisposable)graphics2).Dispose();
					}
				}
				Graphics graphics3;
				graphics = (graphics3 = Graphics.FromImage(metafile));
				try
				{
					graphics.DrawImage(image_0, new Rectangle(0, 0, image_0.Width, image_0.Height));
				}
				finally
				{
					if (graphics3 != null)
					{
						((IDisposable)graphics3).Dispose();
					}
				}
				IntPtr henhmetafile = metafile.GetHenhmetafile();
				uint num = Class65.GdipEmfToWmfBits(henhmetafile, 0U, null, 8, Class65.Enum10.const_0);
				byte[] array = new byte[num];
				Class65.GdipEmfToWmfBits(henhmetafile, num, array, 8, Class65.Enum10.const_0);
				for (int i = 0; i < array.Length; i++)
				{
					stringBuilder.Append(string.Format("{0:X2}", array[i]));
				}
				result = stringBuilder.ToString();
			}
			finally
			{
				if (graphics != null)
				{
					graphics.Dispose();
				}
				if (metafile != null)
				{
					metafile.Dispose();
				}
				if (memoryStream != null)
				{
					memoryStream.Close();
				}
			}
			return result;
		}

		// Token: 0x0600062C RID: 1580 RVA: 0x0005DAC0 File Offset: 0x0005BCC0
		private string method_14(Font font_0)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("{\\fonttbl{\\f0");
			stringBuilder.Append("\\");
			if (this.hybridDictionary_1.Contains(font_0.FontFamily.Name))
			{
				stringBuilder.Append(this.hybridDictionary_1[font_0.FontFamily.Name]);
			}
			else
			{
				stringBuilder.Append(this.hybridDictionary_1["UNKNOWN"]);
			}
			stringBuilder.Append("\\fcharset0 ");
			stringBuilder.Append(font_0.Name);
			stringBuilder.Append(";}}");
			return stringBuilder.ToString();
		}

		// Token: 0x0600062D RID: 1581 RVA: 0x0005DB68 File Offset: 0x0005BD68
		private string method_15(RtfColor rtfColor_0, RtfColor rtfColor_1)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("{\\colortbl ;");
			stringBuilder.Append(this.hybridDictionary_0[rtfColor_0]);
			stringBuilder.Append(";");
			stringBuilder.Append(this.hybridDictionary_0[rtfColor_1]);
			stringBuilder.Append(";}\\n");
			return stringBuilder.ToString();
		}

		// Token: 0x0600062E RID: 1582 RVA: 0x0005DBDC File Offset: 0x0005BDDC
		private string method_16(string string_5)
		{
			return string_5.Replace("\0", "");
		}

		// Token: 0x0400055F RID: 1375
		private const int int_0 = 1;

		// Token: 0x04000560 RID: 1376
		private const int int_1 = 2;

		// Token: 0x04000561 RID: 1377
		private const int int_2 = 3;

		// Token: 0x04000562 RID: 1378
		private const int int_3 = 4;

		// Token: 0x04000563 RID: 1379
		private const int int_4 = 5;

		// Token: 0x04000564 RID: 1380
		private const int int_5 = 6;

		// Token: 0x04000565 RID: 1381
		private const int int_6 = 7;

		// Token: 0x04000566 RID: 1382
		private const int int_7 = 8;

		// Token: 0x04000567 RID: 1383
		private const string string_0 = "UNKNOWN";

		// Token: 0x04000568 RID: 1384
		private const int int_8 = 2540;

		// Token: 0x04000569 RID: 1385
		private const int int_9 = 1440;

		// Token: 0x0400056A RID: 1386
		private const string string_1 = "{\\rtf1\\ansi\\ansicpg1252\\deff0\\deflang1033";

		// Token: 0x0400056B RID: 1387
		private const string string_2 = "\\viewkind4\\uc1\\pard\\cf1\\f0\\fs20";

		// Token: 0x0400056C RID: 1388
		private const string string_3 = "\\cf0\\fs17}";

		// Token: 0x0400056D RID: 1389
		private RtfColor _textColor;

		// Token: 0x0400056E RID: 1390
		private RtfColor _highlightColor;

		// Token: 0x0400056F RID: 1391
		private HybridDictionary hybridDictionary_0;

		// Token: 0x04000570 RID: 1392
		private HybridDictionary hybridDictionary_1;

		// Token: 0x04000571 RID: 1393
		private float float_0;

		// Token: 0x04000572 RID: 1394
		private float float_1;

		// Token: 0x04000573 RID: 1395
		private string string_4 = "}";

		// Token: 0x02000099 RID: 153
		private enum Enum10
		{
			// Token: 0x04000575 RID: 1397
			const_0,
			// Token: 0x04000576 RID: 1398
			const_1,
			// Token: 0x04000577 RID: 1399
			const_2,
			// Token: 0x04000578 RID: 1400
			const_3 = 4
		}

		// Token: 0x0200009A RID: 154
		internal struct Struct0
		{
			// Token: 0x04000579 RID: 1401
			public const string string_0 = "\\red0\\green0\\blue0";

			// Token: 0x0400057A RID: 1402
			public const string string_1 = "\\red128\\green0\\blue0";

			// Token: 0x0400057B RID: 1403
			public const string string_2 = "\\red0\\green128\\blue0";

			// Token: 0x0400057C RID: 1404
			public const string string_3 = "\\red128\\green128\\blue0";

			// Token: 0x0400057D RID: 1405
			public const string string_4 = "\\red0\\green0\\blue128";

			// Token: 0x0400057E RID: 1406
			public const string string_5 = "\\red128\\green0\\blue128";

			// Token: 0x0400057F RID: 1407
			public const string string_6 = "\\red0\\green128\\blue128";

			// Token: 0x04000580 RID: 1408
			public const string string_7 = "\\red128\\green128\\blue128";

			// Token: 0x04000581 RID: 1409
			public const string string_8 = "\\red192\\green192\\blue192";

			// Token: 0x04000582 RID: 1410
			public const string string_9 = "\\red255\\green0\\blue0";

			// Token: 0x04000583 RID: 1411
			public const string string_10 = "\\red0\\green255\\blue0";

			// Token: 0x04000584 RID: 1412
			public const string string_11 = "\\red255\\green255\\blue0";

			// Token: 0x04000585 RID: 1413
			public const string string_12 = "\\red0\\green0\\blue255";

			// Token: 0x04000586 RID: 1414
			public const string string_13 = "\\red255\\green0\\blue255";

			// Token: 0x04000587 RID: 1415
			public const string string_14 = "\\red0\\green255\\blue255";

			// Token: 0x04000588 RID: 1416
			public const string string_15 = "\\red255\\green255\\blue255";
		}

		// Token: 0x0200009B RID: 155
		private struct Struct1
		{
			// Token: 0x04000589 RID: 1417
			public const string string_0 = "\\fnil";

			// Token: 0x0400058A RID: 1418
			public const string string_1 = "\\froman";

			// Token: 0x0400058B RID: 1419
			public const string string_2 = "\\fswiss";

			// Token: 0x0400058C RID: 1420
			public const string string_3 = "\\fmodern";

			// Token: 0x0400058D RID: 1421
			public const string string_4 = "\\fscript";

			// Token: 0x0400058E RID: 1422
			public const string string_5 = "\\fdecor";

			// Token: 0x0400058F RID: 1423
			public const string string_6 = "\\ftech";

			// Token: 0x04000590 RID: 1424
			public const string string_7 = "\\fbidi";
		}
	}
}
