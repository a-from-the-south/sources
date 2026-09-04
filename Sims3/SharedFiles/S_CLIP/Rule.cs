using System;
using System.Collections.Generic;
using System.IO;

namespace Package.SharedFiles.S_CLIP
{
	// Token: 0x020000D3 RID: 211
	public class Rule
	{
		// Token: 0x170003AC RID: 940
		// (get) Token: 0x06000AFC RID: 2812 RVA: 0x00008228 File Offset: 0x00006428
		// (set) Token: 0x06000AFD RID: 2813 RVA: 0x00008230 File Offset: 0x00006430
		public uint frameDataOffset { get; set; }

		// Token: 0x170003AD RID: 941
		// (get) Token: 0x06000AFE RID: 2814 RVA: 0x00008239 File Offset: 0x00006439
		// (set) Token: 0x06000AFF RID: 2815 RVA: 0x00008241 File Offset: 0x00006441
		public uint jointName { get; set; }

		// Token: 0x170003AE RID: 942
		// (get) Token: 0x06000B00 RID: 2816 RVA: 0x0000824A File Offset: 0x0000644A
		// (set) Token: 0x06000B01 RID: 2817 RVA: 0x00008252 File Offset: 0x00006452
		public float Offset { get; set; }

		// Token: 0x170003AF RID: 943
		// (get) Token: 0x06000B02 RID: 2818 RVA: 0x0000825B File Offset: 0x0000645B
		// (set) Token: 0x06000B03 RID: 2819 RVA: 0x00008263 File Offset: 0x00006463
		public float Scale { get; set; }

		// Token: 0x170003B0 RID: 944
		// (get) Token: 0x06000B04 RID: 2820 RVA: 0x0000826C File Offset: 0x0000646C
		// (set) Token: 0x06000B05 RID: 2821 RVA: 0x00008274 File Offset: 0x00006474
		public ushort numFrames { get; set; }

		// Token: 0x170003B1 RID: 945
		// (get) Token: 0x06000B06 RID: 2822 RVA: 0x0000827D File Offset: 0x0000647D
		// (set) Token: 0x06000B07 RID: 2823 RVA: 0x00008285 File Offset: 0x00006485
		public FrameDataFlags Flags { get; set; }

		// Token: 0x170003B2 RID: 946
		// (get) Token: 0x06000B08 RID: 2824 RVA: 0x0000828E File Offset: 0x0000648E
		// (set) Token: 0x06000B09 RID: 2825 RVA: 0x00008296 File Offset: 0x00006496
		public FrameType FrameType { get; set; }

		// Token: 0x170003B3 RID: 947
		// (get) Token: 0x06000B0A RID: 2826 RVA: 0x0000829F File Offset: 0x0000649F
		// (set) Token: 0x06000B0B RID: 2827 RVA: 0x000082A7 File Offset: 0x000064A7
		public List<Frame> Frames { get; private set; }

		// Token: 0x170003B4 RID: 948
		// (get) Token: 0x06000B0C RID: 2828 RVA: 0x000082B0 File Offset: 0x000064B0
		// (set) Token: 0x06000B0D RID: 2829 RVA: 0x000082B8 File Offset: 0x000064B8
		public Dictionary<int, Frame> IndexedFrames { get; private set; }

		// Token: 0x06000B0E RID: 2830 RVA: 0x000082C1 File Offset: 0x000064C1
		public static int GetBitsPerFloat(FrameDataType curveType)
		{
			if (curveType == FrameDataType.Float3)
			{
				return 10;
			}
			if (curveType != FrameDataType.Float4)
			{
				throw new NotSupportedException();
			}
			return 12;
		}

		// Token: 0x06000B0F RID: 2831 RVA: 0x000082D6 File Offset: 0x000064D6
		public static int GetPackedCount(FrameDataType curveType)
		{
			if (curveType == FrameDataType.Float3)
			{
				return 1;
			}
			if (curveType != FrameDataType.Float4)
			{
				throw new NotSupportedException();
			}
			return 4;
		}

		// Token: 0x06000B10 RID: 2832 RVA: 0x000082E9 File Offset: 0x000064E9
		public static int GetFloatCount(FrameDataType curveType)
		{
			if (curveType == FrameDataType.Float3)
			{
				return 3;
			}
			if (curveType != FrameDataType.Float4)
			{
				return 1;
			}
			return 4;
		}

		// Token: 0x06000B11 RID: 2833 RVA: 0x000347EC File Offset: 0x000329EC
		public override string ToString()
		{
			return "0x" + this.jointName.ToString("X8");
		}

		// Token: 0x06000B12 RID: 2834 RVA: 0x000082F8 File Offset: 0x000064F8
		public Rule()
		{
			this.Frames = new List<Frame>();
			this.IndexedFrames = new Dictionary<int, Frame>();
		}

		// Token: 0x06000B13 RID: 2835 RVA: 0x00034818 File Offset: 0x00032A18
		public void Unserialize(BinaryReader r)
		{
			this.frameDataOffset = r.ReadUInt32();
			this.jointName = r.ReadUInt32();
			this.Offset = r.ReadSingle();
			this.Scale = r.ReadSingle();
			this.numFrames = r.ReadUInt16();
			this.Flags = new FrameDataFlags(r.ReadByte());
			this.FrameType = (FrameType)r.ReadByte();
		}

		// Token: 0x06000B14 RID: 2836 RVA: 0x000032EA File Offset: 0x000014EA
		public void Serialize(BinaryWriter w)
		{
		}
	}
}
