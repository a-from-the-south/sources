using System;
using System.Drawing;
using System.Drawing.Imaging;

namespace Sims3WorkshopSDK.Classes
{
	// Token: 0x02000044 RID: 68
	public class WorkshopUtil
	{
		// Token: 0x06000155 RID: 341 RVA: 0x00005998 File Offset: 0x00003B98
		public static ImageCodecInfo GetEncoderInfo(string mimeType)
		{
			ImageCodecInfo[] imageEncoders = ImageCodecInfo.GetImageEncoders();
			for (int i = 0; i < imageEncoders.Length; i++)
			{
				if (imageEncoders[i].MimeType == mimeType)
				{
					return imageEncoders[i];
				}
			}
			return null;
		}

		// Token: 0x06000156 RID: 342 RVA: 0x000059D0 File Offset: 0x00003BD0
		public static Color GetColorfromHex(string hex)
		{
			if (hex.Length != 6)
			{
				throw new Exception("Invalid hex");
			}
			int red = (int)Convert.ToByte(hex.Substring(0, 2), 16);
			int green = (int)Convert.ToByte(hex.Substring(2, 2), 16);
			int blue = (int)Convert.ToByte(hex.Substring(4, 2), 16);
			return Color.FromArgb(255, red, green, blue);
		}

		// Token: 0x06000157 RID: 343 RVA: 0x00005A30 File Offset: 0x00003C30
		public static string ColorToHex(Color color)
		{
			return color.R.ToString("X2") + color.G.ToString("X2") + color.B.ToString("X2");
		}
	}
}
