using System;
using System.Collections.Generic;
using System.IO;

namespace Package.SharedFiles.S_CLIP
{
	// Token: 0x020000CE RID: 206
	public class Frame
	{
		// Token: 0x170003A6 RID: 934
		// (get) Token: 0x06000AEA RID: 2794 RVA: 0x0000813D File Offset: 0x0000633D
		// (set) Token: 0x06000AEB RID: 2795 RVA: 0x00008145 File Offset: 0x00006345
		public ushort FrameIndex
		{
			get
			{
				return this.mFrameIndex;
			}
			set
			{
				if (this.mFrameIndex != value)
				{
					this.mFrameIndex = value;
				}
			}
		}

		// Token: 0x170003A7 RID: 935
		// (get) Token: 0x06000AEC RID: 2796 RVA: 0x00008157 File Offset: 0x00006357
		// (set) Token: 0x06000AED RID: 2797 RVA: 0x0000815F File Offset: 0x0000635F
		public float[] Data
		{
			get
			{
				return this.mData;
			}
			set
			{
				this.mData = value;
			}
		}

		// Token: 0x06000AEE RID: 2798 RVA: 0x00034568 File Offset: 0x00032768
		public Frame(Rule rule, uint jointHash, List<float> indexedFloats)
		{
			this.Rule = rule;
			this.JointHash = jointHash;
			this.indexedFloats = indexedFloats;
			this.mData = new float[Rule.GetFloatCount(rule.Flags.Type)];
		}

		// Token: 0x06000AEF RID: 2799 RVA: 0x000345B0 File Offset: 0x000327B0
		public void UnSerialize(BinaryReader r)
		{
			this.mFrameIndex = r.ReadUInt16();
			ushort num = r.ReadUInt16();
			this.mFlags = (ushort)(num >> 4);
			FrameDataFormat format = this.Rule.Flags.Format;
			if (format == FrameDataFormat.Indexed)
			{
				for (int i = 0; i < Rule.GetFloatCount(this.Rule.Flags.Type); i++)
				{
					ushort num2 = r.ReadUInt16();
					if ((int)num2 < this.indexedFloats.Count)
					{
						float num3 = this.indexedFloats[(int)num2];
						if (((int)num & 1 << i) != 0)
						{
							num3 *= -1f;
						}
						this.mData[i] = Frame.Unpack(num3, this.Rule.Offset, this.Rule.Scale);
					}
				}
				return;
			}
			if (format != FrameDataFormat.Packed)
			{
				return;
			}
			int j = 0;
			while (j < Rule.GetPackedCount(this.Rule.Flags.Type))
			{
				ulong num4;
				switch (this.Rule.Flags.Type)
				{
				case FrameDataType.Float1:
				case FrameDataType.Float4:
					num4 = (ulong)r.ReadUInt16();
					break;
				case FrameDataType.Float3:
					num4 = (ulong)r.ReadUInt32();
					break;
				case (FrameDataType)3:
					goto IL_7F;
				default:
					goto IL_7F;
				}
				IL_93:
				for (int k = 0; k < Rule.GetFloatCount(this.Rule.Flags.Type) / Rule.GetPackedCount(this.Rule.Flags.Type); k++)
				{
					int num5 = k + j;
					int bitsPerFloat = Rule.GetBitsPerFloat(this.Rule.Flags.Type);
					ulong num6 = (ulong)(Math.Pow(2.0, (double)bitsPerFloat) - 1.0);
					ulong num7 = num6 << k * bitsPerFloat;
					float num8 = ((num4 & num7) >> k * bitsPerFloat) / num6;
					if (((int)num & 1 << num5) != 0)
					{
						num8 *= -1f;
					}
					this.mData[num5] = Frame.Unpack(num8, this.Rule.Offset, this.Rule.Scale);
				}
				j++;
				continue;
				IL_7F:
				num4 = (ulong)r.ReadUInt16();
				goto IL_93;
			}
		}

		// Token: 0x06000AF0 RID: 2800 RVA: 0x00008168 File Offset: 0x00006368
		public static float Unpack(float packed, float offset, float scale)
		{
			return packed * scale + offset;
		}

		// Token: 0x06000AF1 RID: 2801 RVA: 0x0000816F File Offset: 0x0000636F
		public static float Pack(float unpacked, float offset, float scale)
		{
			return (unpacked - offset) / scale;
		}

		// Token: 0x06000AF2 RID: 2802 RVA: 0x000032EA File Offset: 0x000014EA
		public void Serialize(BinaryWriter w)
		{
		}

		// Token: 0x0400054E RID: 1358
		public Rule Rule;

		// Token: 0x0400054F RID: 1359
		public uint JointHash;

		// Token: 0x04000550 RID: 1360
		protected ushort mFlags;

		// Token: 0x04000551 RID: 1361
		protected ushort mFrameIndex;

		// Token: 0x04000552 RID: 1362
		protected float[] mData;

		// Token: 0x04000553 RID: 1363
		protected List<float> indexedFloats;
	}
}
