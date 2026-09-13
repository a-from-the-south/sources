using System;
using System.Drawing;
using System.Runtime.CompilerServices;
using ns10;
using Package.Sims3Files.InternalRCOL;
using SlimDX;
using SlimDX.Direct3D9;

namespace ns13
{
	// Token: 0x0200011A RID: 282
	internal sealed class Class129
	{
		// Token: 0x1700028D RID: 653
		// (get) Token: 0x06000CBF RID: 3263 RVA: 0x0009F6D8 File Offset: 0x0009D8D8
		// (set) Token: 0x06000CC0 RID: 3264 RVA: 0x000072B4 File Offset: 0x000054B4
		public bool Visible { get; set; }

		// Token: 0x1700028E RID: 654
		// (get) Token: 0x06000CC1 RID: 3265 RVA: 0x0009F6F0 File Offset: 0x0009D8F0
		// (set) Token: 0x06000CC2 RID: 3266 RVA: 0x000072BF File Offset: 0x000054BF
		public FTPT.FootprintEntry Slot { get; set; }

		// Token: 0x1700028F RID: 655
		// (get) Token: 0x06000CC3 RID: 3267 RVA: 0x0009F708 File Offset: 0x0009D908
		// (set) Token: 0x06000CC4 RID: 3268 RVA: 0x000072CA File Offset: 0x000054CA
		public VertexBuffer VBUF { get; set; }

		// Token: 0x17000290 RID: 656
		// (get) Token: 0x06000CC5 RID: 3269 RVA: 0x0009F720 File Offset: 0x0009D920
		// (set) Token: 0x06000CC6 RID: 3270 RVA: 0x000072D5 File Offset: 0x000054D5
		public FTPT FTPT { get; set; }

		// Token: 0x17000291 RID: 657
		// (get) Token: 0x06000CC7 RID: 3271 RVA: 0x0009F738 File Offset: 0x0009D938
		// (set) Token: 0x06000CC8 RID: 3272 RVA: 0x000072E0 File Offset: 0x000054E0
		public Matrix Transformation
		{
			get
			{
				return this.matrix_0;
			}
			set
			{
				this.matrix_0 = value;
			}
		}

		// Token: 0x06000CC9 RID: 3273 RVA: 0x0009F750 File Offset: 0x0009D950
		public Class129(Device device, FTPT ftpt, FTPT.FootprintEntry slot)
		{
			this.Transformation = Matrix.Identity;
			this.Slot = slot;
			this.FTPT = ftpt;
			this.VBUF = new VertexBuffer(device, (this.Slot.Entries.Count + 1) * Class112.Struct7.SizeInBytes, Usage.None, Class112.Struct7.vertexFormat_0, Pool.Managed);
			this.method_0();
		}

		// Token: 0x06000CCA RID: 3274 RVA: 0x0009F7B0 File Offset: 0x0009D9B0
		public void method_0()
		{
			lock (this.VBUF)
			{
				Class112.Struct7[] array = new Class112.Struct7[this.Slot.Entries.Count + 1];
				for (int i = 0; i < this.Slot.Entries.Count; i++)
				{
					array[i] = new Class112.Struct7(new Vector3(this.Slot.Entries[i][0], (float)this.Slot.LevelOffset * 3f, this.Slot.Entries[i][1]), 0.5f, Color.Red.ToArgb());
				}
				array[this.Slot.Entries.Count] = new Class112.Struct7(new Vector3(this.Slot.Entries[0][0], (float)this.Slot.LevelOffset * 3f, this.Slot.Entries[0][1]), 0.5f, Color.Red.ToArgb());
				DataStream dataStream = this.VBUF.Lock(0, 0, LockFlags.None);
				dataStream.WriteRange<Class112.Struct7>(array, 0, this.Slot.Entries.Count + 1);
				this.VBUF.Unlock();
			}
		}

		// Token: 0x06000CCB RID: 3275 RVA: 0x000072EB File Offset: 0x000054EB
		public void method_1()
		{
			this.VBUF.Dispose();
		}

		// Token: 0x040009AD RID: 2477
		public Matrix matrix_0;

		// Token: 0x040009AE RID: 2478
		[CompilerGenerated]
		private bool bool_0;

		// Token: 0x040009AF RID: 2479
		[CompilerGenerated]
		private FTPT.FootprintEntry footprintEntry_0;

		// Token: 0x040009B0 RID: 2480
		[CompilerGenerated]
		private VertexBuffer vertexBuffer_0;

		// Token: 0x040009B1 RID: 2481
		[CompilerGenerated]
		private FTPT ftpt_0;
	}
}
