using System;
using System.ComponentModel;
using System.IO;
using Sims3WorkshopSDK;

namespace Package.SharedFiles.InternalRCOL
{
	// Token: 0x020000C6 RID: 198
	public class VertexFormatEntry
	{
		// Token: 0x1700036D RID: 877
		// (get) Token: 0x06000A53 RID: 2643 RVA: 0x00007CD7 File Offset: 0x00005ED7
		// (set) Token: 0x06000A54 RID: 2644 RVA: 0x00007CDF File Offset: 0x00005EDF
		[TypeConverter(typeof(IntTypeConverter))]
		public int Index { get; set; }

		// Token: 0x1700036E RID: 878
		// (get) Token: 0x06000A55 RID: 2645 RVA: 0x00007CE8 File Offset: 0x00005EE8
		// (set) Token: 0x06000A56 RID: 2646 RVA: 0x00007CF0 File Offset: 0x00005EF0
		public VertexEntryUsage Usage { get; set; }

		// Token: 0x1700036F RID: 879
		// (get) Token: 0x06000A57 RID: 2647 RVA: 0x00007CF9 File Offset: 0x00005EF9
		// (set) Token: 0x06000A58 RID: 2648 RVA: 0x00007D01 File Offset: 0x00005F01
		public VertexEntryType Type { get; set; }

		// Token: 0x17000370 RID: 880
		// (get) Token: 0x06000A59 RID: 2649 RVA: 0x00007D0A File Offset: 0x00005F0A
		// (set) Token: 0x06000A5A RID: 2650 RVA: 0x00007D12 File Offset: 0x00005F12
		public int Offset { get; set; }

		// Token: 0x17000371 RID: 881
		// (get) Token: 0x06000A5B RID: 2651 RVA: 0x00007D1B File Offset: 0x00005F1B
		// (set) Token: 0x06000A5C RID: 2652 RVA: 0x00007D23 File Offset: 0x00005F23
		[Browsable(false)]
		private int Value { get; set; }

		// Token: 0x17000372 RID: 882
		// (get) Token: 0x06000A5D RID: 2653 RVA: 0x00032528 File Offset: 0x00030728
		[Browsable(false)]
		public uint SizeBytes
		{
			get
			{
				switch (this.Type)
				{
				case 0:
					return 4U;
				case 1:
					return 8U;
				case 2:
					return 12U;
				case 3:
					return 16U;
				case 4:
				case 5:
				case 6:
				case 8:
					return 4U;
				case 7:
				case 12:
					return 8U;
				case 13:
					return 3U;
				case 15:
					return 2U;
				}
				return 0U;
			}
		}

		// Token: 0x06000A5E RID: 2654 RVA: 0x00007D2C File Offset: 0x00005F2C
		public void Serialize(BinaryWriter w)
		{
			w.Write(this.Value);
		}

		// Token: 0x06000A5F RID: 2655 RVA: 0x00007D3A File Offset: 0x00005F3A
		public void UnSerialize(BinaryReader r)
		{
			this.SetValue(r.ReadInt32());
		}

		// Token: 0x06000A60 RID: 2656 RVA: 0x00007D48 File Offset: 0x00005F48
		public VertexFormatEntry Clone()
		{
			VertexFormatEntry vertexFormatEntry = new VertexFormatEntry();
			vertexFormatEntry.SetValue(this.Value);
			return vertexFormatEntry;
		}

		// Token: 0x06000A61 RID: 2657 RVA: 0x00032598 File Offset: 0x00030798
		public void SetValue(int value)
		{
			this.Value = value;
			this.Usage = (VertexEntryUsage)(this.Value & 255);
			this.Index = (this.Value >> 8 & 255);
			this.Type = (this.Value >> 16 & 255);
			this.Offset = (this.Value >> 24 & 255);
		}

		// Token: 0x06000A62 RID: 2658 RVA: 0x000325FC File Offset: 0x000307FC
		public void SetOffset(byte offset)
		{
			int num = this.Value;
			num &= 16777215;
			num |= (int)offset << 24;
			this.SetValue(num);
		}

		// Token: 0x06000A63 RID: 2659 RVA: 0x00032628 File Offset: 0x00030828
		public override string ToString()
		{
			return this.Usage.ToString() + ", Index " + this.Index.ToString();
		}
	}
}
