using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Text;
using Sims3WorkshopSDK;

namespace Package.ImageResource
{
	// Token: 0x020000F0 RID: 240
	public class JPEG : DBPFEntry
	{
		// Token: 0x170003DB RID: 987
		// (get) Token: 0x06000C4F RID: 3151 RVA: 0x00008CBE File Offset: 0x00006EBE
		// (set) Token: 0x06000C50 RID: 3152 RVA: 0x00008CC6 File Offset: 0x00006EC6
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
				this._changed = true;
			}
		}

		// Token: 0x06000C51 RID: 3153 RVA: 0x00007022 File Offset: 0x00005222
		public override void Dispose()
		{
			base.Dispose();
		}

		// Token: 0x06000C52 RID: 3154 RVA: 0x00008CDD File Offset: 0x00006EDD
		public JPEG()
		{
			this.typeId = 1065771754U;
			this.fileExtension = ".jpg";
		}

		// Token: 0x06000C53 RID: 3155 RVA: 0x00008CFB File Offset: 0x00006EFB
		public JPEG(DBPFType typeId)
		{
			this.typeId = typeId;
			this.fileExtension = ".jpg";
		}

		// Token: 0x06000C54 RID: 3156 RVA: 0x00003309 File Offset: 0x00001509
		public override int ReplaceReferences(ResKey from, ResKey to)
		{
			return 0;
		}

		// Token: 0x06000C55 RID: 3157 RVA: 0x0003D6F8 File Offset: 0x0003B8F8
		public unsafe void readAppData(byte[] appData)
		{
			BinaryReaderBE binaryReaderBE = new BinaryReaderBE(new MemoryStream(appData));
			byte[] bytes = binaryReaderBE.ReadBytes(4);
			if (Encoding.Default.GetString(bytes) == "ALFA")
			{
				int count = binaryReaderBE.ReadInt32();
				Bitmap bitmap = System.Drawing.Image.FromStream(new MemoryStream(binaryReaderBE.ReadBytes(count))) as Bitmap;
				Bitmap bitmap2 = new Bitmap(this._image.Width, this._image.Height, PixelFormat.Format32bppArgb);
				Rectangle rect = new Rectangle(0, 0, this._image.Width, this._image.Height);
				BitmapData bitmapData = bitmap.LockBits(rect, ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
				BitmapData bitmapData2 = this._image.LockBits(rect, ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
				BitmapData bitmapData3 = bitmap2.LockBits(rect, ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);
				for (int i = 0; i < this._image.Height; i++)
				{
					byte* ptr = (byte*)((void*)bitmapData.Scan0) + i * bitmapData.Stride;
					byte* ptr2 = (byte*)((void*)bitmapData2.Scan0) + i * bitmapData2.Stride;
					byte* ptr3 = (byte*)((void*)bitmapData3.Scan0) + i * bitmapData3.Stride;
					for (int j = 0; j < this._image.Width; j++)
					{
						ptr3[4 * j] = ptr2[4 * j];
						ptr3[4 * j + 1] = ptr2[4 * j + 1];
						ptr3[4 * j + 2] = ptr2[4 * j + 2];
						ptr3[4 * j + 3] = ptr[4 * j];
					}
				}
				bitmap.UnlockBits(bitmapData);
				this._image.UnlockBits(bitmapData2);
				bitmap2.UnlockBits(bitmapData3);
				this._image = bitmap2;
			}
		}

		// Token: 0x06000C56 RID: 3158 RVA: 0x0003D8C0 File Offset: 0x0003BAC0
		public override void UnSerialize()
		{
			MemoryStream memoryStream = new MemoryStream(this.data);
			this._image = (System.Drawing.Image.FromStream(memoryStream) as Bitmap);
			memoryStream.Dispose();
			BinaryReaderBE binaryReaderBE = new BinaryReaderBE(new MemoryStream(this.data));
			while (binaryReaderBE.BaseStream.Position < binaryReaderBE.BaseStream.Length)
			{
				ushort num = binaryReaderBE.ReadUInt16();
				if (num != 65496)
				{
					if (num == 65504)
					{
						short num2 = binaryReaderBE.ReadInt16();
						byte[] appData = binaryReaderBE.ReadBytes((int)(num2 - 2));
						this.readAppData(appData);
					}
					else
					{
						binaryReaderBE.BaseStream.Position = binaryReaderBE.BaseStream.Length;
					}
				}
			}
			this._changed = false;
		}

		// Token: 0x06000C57 RID: 3159 RVA: 0x0003D96C File Offset: 0x0003BB6C
		public override byte[] Serialize()
		{
			if (this.Image != null && this._changed)
			{
				MemoryStream memoryStream = new MemoryStream();
				this.Image.Save(memoryStream, ImageFormat.Jpeg);
				this.data = memoryStream.ToArray();
				memoryStream.Dispose();
				this._changed = false;
			}
			return this.data;
		}

		// Token: 0x06000C58 RID: 3160 RVA: 0x00008A6C File Offset: 0x00006C6C
		public override string ToString()
		{
			return "JPG | " + base.ToString();
		}

		// Token: 0x040005C6 RID: 1478
		private Bitmap _image;

		// Token: 0x040005C7 RID: 1479
		private bool _changed;
	}
}
