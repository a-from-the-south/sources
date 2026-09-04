using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using Sims3WorkshopSDK;

namespace Package.ImageResource
{
	// Token: 0x020000EC RID: 236
	public class PNG : DBPFEntry
	{
		// Token: 0x170003CA RID: 970
		// (get) Token: 0x06000C03 RID: 3075 RVA: 0x00008A91 File Offset: 0x00006C91
		// (set) Token: 0x06000C04 RID: 3076 RVA: 0x00008A99 File Offset: 0x00006C99
		public Bitmap Image
		{
			get
			{
				return this._image;
			}
			set
			{
				this._image = value;
				base.IsUnpacked = true;
				this.writeImageData(this._image);
			}
		}

		// Token: 0x06000C05 RID: 3077 RVA: 0x00007022 File Offset: 0x00005222
		public override void Dispose()
		{
			base.Dispose();
		}

		// Token: 0x06000C06 RID: 3078 RVA: 0x00008AB5 File Offset: 0x00006CB5
		public void DisposeImage()
		{
			base.IsUnpacked = false;
			this._image.Dispose();
		}

		// Token: 0x06000C07 RID: 3079 RVA: 0x00008AC9 File Offset: 0x00006CC9
		public PNG()
		{
			this.typeId = 1651466445U;
			this.fileExtension = ".png";
		}

		// Token: 0x06000C08 RID: 3080 RVA: 0x00008AE7 File Offset: 0x00006CE7
		public PNG(DBPFType typeId)
		{
			this.typeId = typeId;
			this.fileExtension = ".png";
		}

		// Token: 0x06000C09 RID: 3081 RVA: 0x00003309 File Offset: 0x00001509
		public override int ReplaceReferences(ResKey from, ResKey to)
		{
			return 0;
		}

		// Token: 0x06000C0A RID: 3082 RVA: 0x0003AA9C File Offset: 0x00038C9C
		public unsafe void readAppData(BinaryReader reader)
		{
			long position = reader.BaseStream.Position;
			short num = reader.ReadInt16();
			byte[] bytes = reader.ReadBytes(4);
			if (Encoding.Default.GetString(bytes) == "ALFA")
			{
				int num2 = reader.ReadInt32();
				byte[] buffer = reader.ReadBytes(num2);
				PNG.alphaStream.Seek(0L, SeekOrigin.Begin);
				PNG.alphaStream.Write(buffer, 0, num2);
				PNG.alphaStream.SetLength((long)num2);
				PNG.alphaStream.Seek(0L, SeekOrigin.Begin);
				Bitmap bitmap = System.Drawing.Image.FromStream(PNG.alphaStream) as Bitmap;
				Rectangle rect = new Rectangle(0, 0, this._image.Width, this._image.Height);
				BitmapData bitmapData = bitmap.LockBits(rect, ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
				BitmapData bitmapData2 = this._image.LockBits(rect, ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
				for (int i = 0; i < this._image.Height; i++)
				{
					byte* ptr = (byte*)((void*)bitmapData.Scan0) + i * bitmapData.Stride;
					byte* ptr2 = (byte*)((void*)bitmapData2.Scan0) + i * bitmapData2.Stride;
					byte* ptr3 = (byte*)((void*)bitmapData2.Scan0) + i * bitmapData2.Stride;
					for (int j = 0; j < this._image.Width; j++)
					{
						ptr3[4 * j] = ptr2[4 * j];
						ptr3[4 * j + 1] = ptr2[4 * j + 1];
						ptr3[4 * j + 2] = ptr2[4 * j + 2];
						ptr3[4 * j + 3] = ptr[4 * j];
					}
				}
				bitmap.UnlockBits(bitmapData);
				bitmap.Dispose();
				this._image.UnlockBits(bitmapData2);
			}
			reader.BaseStream.Position = position + (long)num;
		}

		// Token: 0x06000C0B RID: 3083 RVA: 0x0003AC84 File Offset: 0x00038E84
		public override void UnSerialize()
		{
			PNG.imageMemoryStream.Seek(0L, SeekOrigin.Begin);
			PNG.imageMemoryStream.Write(this.data, 0, this.data.Length);
			PNG.imageMemoryStream.SetLength((long)this.data.Length);
			PNG.imageMemoryStream.Seek(0L, SeekOrigin.Begin);
			Bitmap bitmap = System.Drawing.Image.FromStream(PNG.imageMemoryStream) as Bitmap;
			this._image = new Bitmap(bitmap.Width, bitmap.Height, PixelFormat.Format32bppArgb);
			Graphics.FromImage(this._image).DrawImage(bitmap, 0, 0, bitmap.Width, bitmap.Height);
			bitmap.Dispose();
			PNG.imageMemoryStream.Seek(0L, SeekOrigin.Begin);
			BinaryReaderBE binaryReaderBE = new BinaryReaderBE(PNG.imageMemoryStream);
			while (binaryReaderBE.BaseStream.Position < binaryReaderBE.BaseStream.Length)
			{
				ushort num = binaryReaderBE.ReadUInt16();
				if (num != 65496)
				{
					if (num == 65504)
					{
						this.readAppData(binaryReaderBE);
					}
					else
					{
						binaryReaderBE.BaseStream.Position = binaryReaderBE.BaseStream.Length;
					}
				}
			}
		}

		// Token: 0x06000C0C RID: 3084 RVA: 0x00008B01 File Offset: 0x00006D01
		public override byte[] Serialize()
		{
			if (this.data == null)
			{
				this.writeImageData(this._image);
			}
			return this.data;
		}

		// Token: 0x06000C0D RID: 3085 RVA: 0x0003ADA8 File Offset: 0x00038FA8
		private void SplitPngFileIntoRGBandAplha(Bitmap bitmap_original, out Bitmap alphaBitmap)
		{
			Rectangle rect = new Rectangle(0, 0, bitmap_original.Width, bitmap_original.Height);
			Bitmap bitmap = bitmap_original.Clone(rect, PixelFormat.Format32bppRgb);
			BitmapData bitmapData = bitmap.LockBits(rect, ImageLockMode.ReadOnly, bitmap.PixelFormat);
			alphaBitmap = new Bitmap(bitmapData.Width, bitmapData.Height, PixelFormat.Format32bppArgb);
			for (int i = 0; i <= bitmapData.Height - 1; i++)
			{
				for (int j = 0; j <= bitmapData.Width - 1; j++)
				{
					Color color = Color.FromArgb(Marshal.ReadInt32(bitmapData.Scan0, bitmapData.Stride * i + 4 * j));
					if (color.A > 0 & color.A <= 255)
					{
						alphaBitmap.SetPixel(j, i, Color.FromArgb((int)color.A, (int)color.A, (int)color.A, (int)color.A));
					}
					else
					{
						alphaBitmap.SetPixel(j, i, Color.FromArgb(0, 0, 0, 0));
					}
				}
			}
		}

		// Token: 0x06000C0E RID: 3086 RVA: 0x0003AEB4 File Offset: 0x000390B4
		private void writeImageData(Bitmap value)
		{
			if (value != null)
			{
				MemoryStream memoryStream = new MemoryStream();
				if (this.TypeID != 1009419847 && this.TypeID != -497766813 && this.TypeID != 382531400)
				{
					if (this.TypeID != -510873886)
					{
						value.Save(memoryStream, ImageFormat.Png);
						this.data = new byte[memoryStream.Length];
						memoryStream.Position = 0L;
						memoryStream.Read(this.data, 0, this.data.Length);
						memoryStream.Dispose();
						return;
					}
				}
				using (MemoryStream memoryStream2 = new MemoryStream())
				{
					using (MemoryStream memoryStream3 = new MemoryStream())
					{
						using (MemoryStream memoryStream4 = new MemoryStream())
						{
							value.Save(memoryStream3, ImageFormat.Jpeg);
							Bitmap bitmap;
							this.SplitPngFileIntoRGBandAplha(value, out bitmap);
							memoryStream3.Position = 0L;
							BinaryReader binaryReader = new BinaryReader(memoryStream3);
							BinaryWriter binaryWriter = new BinaryWriter(memoryStream2);
							binaryWriter.Write(binaryReader.ReadBytes(12));
							bitmap.Save(memoryStream4, ImageFormat.Png);
							memoryStream4.Position = 0L;
							int num = (int)memoryStream4.Length;
							binaryWriter.Write(16777217U);
							binaryWriter.Write(256U);
							binaryWriter.Write(57599);
							int num2 = (int)(memoryStream4.Length + 10L);
							num2 = (num2 << 8 | num2 >> 8);
							binaryWriter.Write((ushort)num2);
							binaryWriter.Write(1095126081U);
							binaryWriter.Write((byte)(num >> 24 & 255));
							binaryWriter.Write((byte)(num >> 16 & 255));
							binaryWriter.Write((byte)(num >> 8 & 255));
							binaryWriter.Write((byte)(num & 255));
							binaryWriter.Write(memoryStream4.ToArray());
							binaryWriter.Write(binaryReader.ReadBytes((int)memoryStream3.Length - 12));
							binaryWriter.BaseStream.Position = 0L;
							this.data = memoryStream2.ToArray();
						}
					}
				}
			}
		}

		// Token: 0x06000C0F RID: 3087 RVA: 0x00004E72 File Offset: 0x00003072
		public override string ToString()
		{
			return "PNG | " + base.ToString();
		}

		// Token: 0x040005B4 RID: 1460
		private Bitmap _image;

		// Token: 0x040005B5 RID: 1461
		private static MemoryStream alphaStream = new MemoryStream(10000000);

		// Token: 0x040005B6 RID: 1462
		private static MemoryStream imageMemoryStream = new MemoryStream(20000000);
	}
}
