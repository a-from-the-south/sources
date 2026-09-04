using System;

namespace Package.SharedFiles.S_CLIP
{
	// Token: 0x020000CF RID: 207
	public struct FrameDataFlags
	{
		// Token: 0x06000AF3 RID: 2803 RVA: 0x00008176 File Offset: 0x00006376
		public FrameDataFlags(byte raw)
		{
			this.mRaw = raw;
		}

		// Token: 0x170003A8 RID: 936
		// (get) Token: 0x06000AF4 RID: 2804 RVA: 0x0000817F File Offset: 0x0000637F
		// (set) Token: 0x06000AF5 RID: 2805 RVA: 0x0000818A File Offset: 0x0000638A
		public FrameDataType Type
		{
			get
			{
				return (FrameDataType)(this.mRaw & 7);
			}
			set
			{
				this.mRaw &= 31;
				this.mRaw |= (byte)value;
			}
		}

		// Token: 0x170003A9 RID: 937
		// (get) Token: 0x06000AF6 RID: 2806 RVA: 0x000081AC File Offset: 0x000063AC
		// (set) Token: 0x06000AF7 RID: 2807 RVA: 0x000081BE File Offset: 0x000063BE
		public bool Static
		{
			get
			{
				return (this.mRaw & 8) >> 3 == 1;
			}
			set
			{
				this.mRaw &= 247;
				this.mRaw |= (byte)((value ? 1 : 0) << 3);
			}
		}

		// Token: 0x170003AA RID: 938
		// (get) Token: 0x06000AF8 RID: 2808 RVA: 0x000081EB File Offset: 0x000063EB
		// (set) Token: 0x06000AF9 RID: 2809 RVA: 0x000081FC File Offset: 0x000063FC
		public FrameDataFormat Format
		{
			get
			{
				return (FrameDataFormat)((this.mRaw & 240) >> 4);
			}
			set
			{
				this.mRaw &= 15;
				this.mRaw |= (byte)(value << 4);
			}
		}

		// Token: 0x170003AB RID: 939
		// (get) Token: 0x06000AFA RID: 2810 RVA: 0x00008220 File Offset: 0x00006420
		// (set) Token: 0x06000AFB RID: 2811 RVA: 0x00008176 File Offset: 0x00006376
		public byte Raw
		{
			get
			{
				return this.mRaw;
			}
			set
			{
				this.mRaw = value;
			}
		}

		// Token: 0x04000554 RID: 1364
		private byte mRaw;
	}
}
