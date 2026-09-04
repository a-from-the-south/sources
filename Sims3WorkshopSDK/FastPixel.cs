using System;
using System.Drawing;
using System.Drawing.Imaging;

namespace Sims3WorkshopSDK
{
	// Token: 0x02000002 RID: 2
	public class FastPixel
	{
		// Token: 0x17000001 RID: 1
		// (get) Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00000250
		public int Width
		{
			get
			{
				return this._width;
			}
		}

		// Token: 0x17000002 RID: 2
		// (get) Token: 0x06000002 RID: 2 RVA: 0x00002058 File Offset: 0x00000258
		public int Height
		{
			get
			{
				return this._height;
			}
		}

		// Token: 0x17000003 RID: 3
		// (get) Token: 0x06000003 RID: 3 RVA: 0x00002060 File Offset: 0x00000260
		public bool IsAlphaBitmap
		{
			get
			{
				return this._isAlpha;
			}
		}

		// Token: 0x17000004 RID: 4
		// (get) Token: 0x06000004 RID: 4 RVA: 0x00002068 File Offset: 0x00000268
		public Bitmap Bitmap
		{
			get
			{
				return this._bitmap;
			}
		}

		// Token: 0x06000005 RID: 5 RVA: 0x00002C84 File Offset: 0x00000E84
		public FastPixel(Bitmap bitmap)
		{
			if (bitmap.PixelFormat == (bitmap.PixelFormat | PixelFormat.Indexed))
			{
				throw new Exception("Cannot lock an Indexed image.");
			}
			this._bitmap = bitmap;
			this._isAlpha = (this.Bitmap.PixelFormat == (this.Bitmap.PixelFormat | PixelFormat.Alpha));
			this._width = bitmap.Width;
			this._height = bitmap.Height;
			this._bytesPerPixel = (this._isAlpha ? 4 : 3);
		}

		// Token: 0x06000006 RID: 6 RVA: 0x00002D0C File Offset: 0x00000F0C
		public unsafe void Lock()
		{
			if (this._locked)
			{
				throw new Exception("Bitmap already locked.");
			}
			Rectangle rect = new Rectangle(0, 0, this.Width, this.Height);
			this._bmpData = this.Bitmap.LockBits(rect, ImageLockMode.ReadWrite, this.Bitmap.PixelFormat);
			this._rgbValues = new byte[this.Width * this.Height * this._bytesPerPixel];
			byte* ptr = (byte*)((void*)this._bmpData.Scan0);
			int num = this._bmpData.Stride - this._bmpData.Width * this._bytesPerPixel;
			int i = 0;
			while (i < this.Height)
			{
				int j = 0;
				while (j < this.Width)
				{
					int num2 = (i * this.Width + j) * this._bytesPerPixel;
					this._rgbValues[num2] = *ptr;
					this._rgbValues[num2 + 1] = ptr[1];
					this._rgbValues[num2 + 2] = ptr[2];
					if (this._bytesPerPixel == 4)
					{
						this._rgbValues[num2 + 3] = ptr[3];
					}
					j++;
					ptr += this._bytesPerPixel;
				}
				i++;
				ptr += num;
			}
			this._locked = true;
		}

		// Token: 0x06000007 RID: 7 RVA: 0x00002E40 File Offset: 0x00001040
		public unsafe void Unlock(bool setPixels)
		{
			if (!this._locked)
			{
				throw new Exception("Bitmap not locked.");
			}
			if (setPixels)
			{
				byte* ptr = (byte*)((void*)this._bmpData.Scan0);
				int num = this._bmpData.Stride - this._bmpData.Width * this._bytesPerPixel;
				int i = 0;
				while (i < this.Height)
				{
					int j = 0;
					while (j < this.Width)
					{
						int num2 = (i * this.Width + j) * this._bytesPerPixel;
						*ptr = this._rgbValues[num2];
						ptr[1] = this._rgbValues[num2 + 1];
						ptr[2] = this._rgbValues[num2 + 2];
						if (this._bytesPerPixel == 4)
						{
							ptr[3] = this._rgbValues[num2 + 3];
						}
						j++;
						ptr += this._bytesPerPixel;
					}
					i++;
					ptr += num;
				}
			}
			this.Bitmap.UnlockBits(this._bmpData);
			this._locked = false;
		}

		// Token: 0x06000008 RID: 8 RVA: 0x00002F34 File Offset: 0x00001134
		public void Clear(Color colour)
		{
			if (!this._locked)
			{
				throw new Exception("Bitmap not locked.");
			}
			for (int i = 0; i < this._rgbValues.Length; i += this._bytesPerPixel)
			{
				this._rgbValues[i] = colour.B;
				this._rgbValues[i + 1] = colour.G;
				this._rgbValues[i + 2] = colour.R;
				if (this._bytesPerPixel == 4)
				{
					this._rgbValues[i + 3] = colour.A;
				}
			}
		}

		// Token: 0x06000009 RID: 9 RVA: 0x00002070 File Offset: 0x00000270
		public void SetPixel(Point location, Color colour)
		{
			this.SetPixel(location.X, location.Y, colour);
		}

		// Token: 0x0600000A RID: 10 RVA: 0x00002FB8 File Offset: 0x000011B8
		public void SetPixel(int x, int y, Color colour)
		{
			if (!this._locked)
			{
				throw new Exception("Bitmap not locked.");
			}
			int num = (y * this.Width + x) * this._bytesPerPixel;
			this._rgbValues[num] = colour.B;
			this._rgbValues[num + 1] = colour.G;
			this._rgbValues[num + 2] = colour.R;
			if (this._bytesPerPixel == 4)
			{
				this._rgbValues[num + 3] = colour.A;
			}
		}

		// Token: 0x0600000B RID: 11 RVA: 0x00002087 File Offset: 0x00000287
		public Color GetPixel(Point location)
		{
			return this.GetPixel(location.X, location.Y);
		}

		// Token: 0x0600000C RID: 12 RVA: 0x00003038 File Offset: 0x00001238
		public Color GetPixel(int x, int y)
		{
			if (!this._locked)
			{
				throw new Exception("Bitmap not locked.");
			}
			int num = (y * this.Width + x) * this._bytesPerPixel;
			int blue = (int)this._rgbValues[num];
			int green = (int)this._rgbValues[num + 1];
			int red = (int)this._rgbValues[num + 2];
			if (this._bytesPerPixel == 4)
			{
				return Color.FromArgb((int)this._rgbValues[num + 3], red, green, blue);
			}
			return Color.FromArgb(red, green, blue);
		}

		// Token: 0x04000001 RID: 1
		private byte[] _rgbValues;

		// Token: 0x04000002 RID: 2
		private BitmapData _bmpData;

		// Token: 0x04000003 RID: 3
		private bool _locked;

		// Token: 0x04000004 RID: 4
		private readonly bool _isAlpha;

		// Token: 0x04000005 RID: 5
		private readonly Bitmap _bitmap;

		// Token: 0x04000006 RID: 6
		private readonly int _width;

		// Token: 0x04000007 RID: 7
		private readonly int _height;

		// Token: 0x04000008 RID: 8
		private readonly int _bytesPerPixel;
	}
}
