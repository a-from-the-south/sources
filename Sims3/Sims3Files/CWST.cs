using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Package.SharedFiles;
using Sims3WorkshopSDK;

namespace Package.Sims3Files
{
	// Token: 0x02000025 RID: 37
	public class CWST : Sims3BuildItem
	{
		// Token: 0x17000073 RID: 115
		// (get) Token: 0x060001B1 RID: 433 RVA: 0x00003C99 File Offset: 0x00001E99
		// (set) Token: 0x060001B2 RID: 434 RVA: 0x000032EA File Offset: 0x000014EA
		public override int VPXYIndex
		{
			get
			{
				return -1;
			}
			set
			{
			}
		}

		// Token: 0x17000074 RID: 116
		// (get) Token: 0x060001B3 RID: 435 RVA: 0x00003C99 File Offset: 0x00001E99
		// (set) Token: 0x060001B4 RID: 436 RVA: 0x000032EA File Offset: 0x000014EA
		public override int DiagonalModelIndex
		{
			get
			{
				return -1;
			}
			set
			{
			}
		}

		// Token: 0x17000075 RID: 117
		// (get) Token: 0x060001B5 RID: 437 RVA: 0x00003C99 File Offset: 0x00001E99
		// (set) Token: 0x060001B6 RID: 438 RVA: 0x000032EA File Offset: 0x000014EA
		public override int PostModel
		{
			get
			{
				return -1;
			}
			set
			{
			}
		}

		// Token: 0x17000076 RID: 118
		// (get) Token: 0x060001B7 RID: 439 RVA: 0x00003C9C File Offset: 0x00001E9C
		// (set) Token: 0x060001B8 RID: 440 RVA: 0x00003CA4 File Offset: 0x00001EA4
		public WallStyle WallStyle { get; set; }

		// Token: 0x17000077 RID: 119
		// (get) Token: 0x060001B9 RID: 441 RVA: 0x00003CAD File Offset: 0x00001EAD
		// (set) Token: 0x060001BA RID: 442 RVA: 0x00003CB5 File Offset: 0x00001EB5
		public PartitionType PartitionType { get; set; }

		// Token: 0x17000078 RID: 120
		// (get) Token: 0x060001BB RID: 443 RVA: 0x00003CBE File Offset: 0x00001EBE
		// (set) Token: 0x060001BC RID: 444 RVA: 0x00003CC6 File Offset: 0x00001EC6
		public PartitionFlags PartitionFlags { get; set; }

		// Token: 0x17000079 RID: 121
		// (get) Token: 0x060001BD RID: 445 RVA: 0x00003CCF File Offset: 0x00001ECF
		// (set) Token: 0x060001BE RID: 446 RVA: 0x00003CD7 File Offset: 0x00001ED7
		public VerticalSpanType VerticalSpanType { get; set; }

		// Token: 0x1700007A RID: 122
		// (get) Token: 0x060001BF RID: 447 RVA: 0x00003CE0 File Offset: 0x00001EE0
		// (set) Token: 0x060001C0 RID: 448 RVA: 0x00003CE8 File Offset: 0x00001EE8
		public PartitionBlockedFlags PartitionBlockedFlags { get; set; }

		// Token: 0x1700007B RID: 123
		// (get) Token: 0x060001C1 RID: 449 RVA: 0x00003CF1 File Offset: 0x00001EF1
		// (set) Token: 0x060001C2 RID: 450 RVA: 0x00003CF9 File Offset: 0x00001EF9
		public PartitionBlockedFlags AdjacentPartitionsBlockedFlags { get; set; }

		// Token: 0x1700007C RID: 124
		// (get) Token: 0x060001C3 RID: 451 RVA: 0x00003D02 File Offset: 0x00001F02
		// (set) Token: 0x060001C4 RID: 452 RVA: 0x00003D0A File Offset: 0x00001F0A
		public PartitionToolModes PartitionToolModes { get; set; }

		// Token: 0x1700007D RID: 125
		// (get) Token: 0x060001C5 RID: 453 RVA: 0x00003D13 File Offset: 0x00001F13
		// (set) Token: 0x060001C6 RID: 454 RVA: 0x00003D1B File Offset: 0x00001F1B
		public UserToolFlags DeletionTools { get; set; }

		// Token: 0x1700007E RID: 126
		// (get) Token: 0x060001C7 RID: 455 RVA: 0x00003D24 File Offset: 0x00001F24
		// (set) Token: 0x060001C8 RID: 456 RVA: 0x00003D2C File Offset: 0x00001F2C
		public uint DefaultPatternIndex { get; set; }

		// Token: 0x1700007F RID: 127
		// (get) Token: 0x060001C9 RID: 457 RVA: 0x00003D35 File Offset: 0x00001F35
		// (set) Token: 0x060001CA RID: 458 RVA: 0x00003D3D File Offset: 0x00001F3D
		public WallThickness WallThickness { get; set; }

		// Token: 0x060001CB RID: 459 RVA: 0x00003D46 File Offset: 0x00001F46
		public CWST()
		{
			base.TGIIndex = new List<TGIIndex>();
			this.typeId = 2438063804U;
		}

		// Token: 0x060001CC RID: 460 RVA: 0x00003309 File Offset: 0x00001509
		public override int ReplaceReferences(ResKey from, ResKey to)
		{
			return 0;
		}

		// Token: 0x060001CD RID: 461 RVA: 0x000136E0 File Offset: 0x000118E0
		public override void UnSerialize()
		{
			MemoryStream memoryStream = new MemoryStream(this.data);
			BinaryReader binaryReader = new BinaryReader(memoryStream);
			base.Version = binaryReader.ReadUInt32();
			this.tgiOffset = binaryReader.ReadUInt32();
			this.tgiSize = binaryReader.ReadUInt32();
			this._dword = binaryReader.ReadUInt32();
			base._readCommonSection(binaryReader);
			binaryReader.ReadUInt32();
			binaryReader.ReadUInt32();
			binaryReader.ReadUInt32();
			binaryReader.ReadUInt32();
			binaryReader.ReadUInt32();
			binaryReader.ReadUInt32();
			binaryReader.ReadUInt32();
			binaryReader.ReadUInt32();
			this.DefaultPatternIndex = binaryReader.ReadUInt32();
			binaryReader.ReadUInt32();
			uint num = binaryReader.ReadUInt32();
			int num2 = 0;
			while ((long)num2 < (long)((ulong)num))
			{
				TGIIndex tgiindex = new TGIIndex();
				tgiindex.UnSerialize(binaryReader);
				base.TGIIndex.Add(tgiindex);
				num2++;
			}
			memoryStream.Dispose();
			binaryReader.Close();
		}

		// Token: 0x060001CE RID: 462 RVA: 0x000137C0 File Offset: 0x000119C0
		public override byte[] Serialize()
		{
			MemoryStream memoryStream = new MemoryStream();
			BinaryWriter binaryWriter = new BinaryWriter(memoryStream, Encoding.BigEndianUnicode);
			MemoryStream memoryStream2 = new MemoryStream();
			BinaryWriter binaryWriter2 = new BinaryWriter(memoryStream2, Encoding.BigEndianUnicode);
			binaryWriter2.Write(this._dword);
			base._writeCommon(binaryWriter2);
			binaryWriter2.Write((uint)this.WallStyle);
			binaryWriter2.Write((uint)this.PartitionType);
			binaryWriter2.Write((uint)this.PartitionFlags);
			binaryWriter2.Write((uint)this.VerticalSpanType);
			binaryWriter2.Write((uint)this.PartitionBlockedFlags);
			binaryWriter2.Write((uint)this.AdjacentPartitionsBlockedFlags);
			binaryWriter2.Write((uint)this.PartitionToolModes);
			binaryWriter2.Write((uint)this.DeletionTools);
			binaryWriter2.Write(this.DefaultPatternIndex);
			binaryWriter2.Write((uint)this.WallThickness);
			this.tgiOffset = (uint)binaryWriter2.BaseStream.Position;
			binaryWriter2.Write(base.TGIIndex.Count);
			foreach (TGIIndex tgiindex in base.TGIIndex)
			{
				tgiindex.Serialize(binaryWriter2);
			}
			this.tgiSize = (uint)binaryWriter2.BaseStream.Position - this.tgiOffset;
			binaryWriter.Write(base.Version);
			binaryWriter.Write(this.tgiOffset + 4U);
			binaryWriter.Write(this.tgiSize);
			binaryWriter.Write(memoryStream2.ToArray());
			byte[] result = memoryStream.ToArray();
			memoryStream2.Dispose();
			memoryStream.Dispose();
			return result;
		}

		// Token: 0x040000F3 RID: 243
		private uint tgiOffset;

		// Token: 0x040000F4 RID: 244
		private uint tgiSize;

		// Token: 0x040000F5 RID: 245
		private uint _dword;
	}
}
