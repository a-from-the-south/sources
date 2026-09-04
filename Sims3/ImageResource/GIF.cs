using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using Sims3WorkshopSDK;

namespace Package.ImageResource
{
	// Token: 0x020000E8 RID: 232
	public class GIF : DBPFEntry
	{
		// Token: 0x170003C9 RID: 969
		// (get) Token: 0x06000BF4 RID: 3060 RVA: 0x00008A1C File Offset: 0x00006C1C
		// (set) Token: 0x06000BF5 RID: 3061 RVA: 0x00008A24 File Offset: 0x00006C24
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
			}
		}

		// Token: 0x06000BF6 RID: 3062 RVA: 0x00007022 File Offset: 0x00005222
		public override void Dispose()
		{
			base.Dispose();
		}

		// Token: 0x06000BF7 RID: 3063 RVA: 0x00008A34 File Offset: 0x00006C34
		public GIF()
		{
			this.typeId = 1065771754U;
			this.fileExtension = ".gif";
		}

		// Token: 0x06000BF8 RID: 3064 RVA: 0x00008A52 File Offset: 0x00006C52
		public GIF(DBPFType typeId)
		{
			this.typeId = typeId;
			this.fileExtension = ".gif";
		}

		// Token: 0x06000BF9 RID: 3065 RVA: 0x00003309 File Offset: 0x00001509
		public override int ReplaceReferences(ResKey from, ResKey to)
		{
			return 0;
		}

		// Token: 0x06000BFA RID: 3066 RVA: 0x0003AA28 File Offset: 0x00038C28
		public override void UnSerialize()
		{
			MemoryStream memoryStream = new MemoryStream(this.data);
			this.Image = (System.Drawing.Image.FromStream(memoryStream) as Bitmap);
			memoryStream.Dispose();
		}

		// Token: 0x06000BFB RID: 3067 RVA: 0x0003AA58 File Offset: 0x00038C58
		public override byte[] Serialize()
		{
			if (this.Image != null)
			{
				MemoryStream memoryStream = new MemoryStream();
				this.Image.Save(memoryStream, ImageFormat.Gif);
				this.data = memoryStream.ToArray();
				memoryStream.Dispose();
			}
			return this.data;
		}

		// Token: 0x06000BFC RID: 3068 RVA: 0x00008A6C File Offset: 0x00006C6C
		public override string ToString()
		{
			return "JPG | " + base.ToString();
		}

		// Token: 0x040005A7 RID: 1447
		private Bitmap _image;
	}
}
