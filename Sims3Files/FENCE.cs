using System;
using System.IO;
using System.Text;
using Package.SharedFiles;
using Sims3WorkshopSDK;

namespace Package.Sims3Files
{
	// Token: 0x02000029 RID: 41
	public class FENCE : Sims3BuildItem
	{
		// Token: 0x17000089 RID: 137
		// (get) Token: 0x060001EC RID: 492 RVA: 0x00003E2C File Offset: 0x0000202C
		// (set) Token: 0x060001ED RID: 493 RVA: 0x00003E34 File Offset: 0x00002034
		public int PostTileSpacing { get; set; }

		// Token: 0x1700008A RID: 138
		// (get) Token: 0x060001EE RID: 494 RVA: 0x00003E3D File Offset: 0x0000203D
		// (set) Token: 0x060001EF RID: 495 RVA: 0x00003E45 File Offset: 0x00002045
		public byte CanWalkOver { get; set; }

		// Token: 0x1700008B RID: 139
		// (get) Token: 0x060001F0 RID: 496 RVA: 0x00003E4E File Offset: 0x0000204E
		// (set) Token: 0x060001F1 RID: 497 RVA: 0x00003E56 File Offset: 0x00002056
		public byte RaiseFenceGeometryAboveWall { get; set; }

		// Token: 0x1700008C RID: 140
		// (get) Token: 0x060001F2 RID: 498 RVA: 0x00003E5F File Offset: 0x0000205F
		// (set) Token: 0x060001F3 RID: 499 RVA: 0x00003E67 File Offset: 0x00002067
		public int wallTgiIndex { get; set; }

		// Token: 0x1700008D RID: 141
		// (get) Token: 0x060001F4 RID: 500 RVA: 0x00003E70 File Offset: 0x00002070
		public TGIIndex WallTGI
		{
			get
			{
				return base.TGIIndex[this.wallTgiIndex];
			}
		}

		// Token: 0x1700008E RID: 142
		// (get) Token: 0x060001F5 RID: 501 RVA: 0x00003E83 File Offset: 0x00002083
		// (set) Token: 0x060001F6 RID: 502 RVA: 0x00003E8B File Offset: 0x0000208B
		public override int VPXYIndex { get; set; }

		// Token: 0x1700008F RID: 143
		// (get) Token: 0x060001F7 RID: 503 RVA: 0x00003E94 File Offset: 0x00002094
		// (set) Token: 0x060001F8 RID: 504 RVA: 0x00003E9C File Offset: 0x0000209C
		public override int DiagonalModelIndex { get; set; }

		// Token: 0x17000090 RID: 144
		// (get) Token: 0x060001F9 RID: 505 RVA: 0x00003EA5 File Offset: 0x000020A5
		// (set) Token: 0x060001FA RID: 506 RVA: 0x00003EAD File Offset: 0x000020AD
		public override int PostModel { get; set; }

		// Token: 0x17000091 RID: 145
		// (get) Token: 0x060001FB RID: 507 RVA: 0x00003EB6 File Offset: 0x000020B6
		// (set) Token: 0x060001FC RID: 508 RVA: 0x00003EBE File Offset: 0x000020BE
		public byte HasWall { get; set; }

		// Token: 0x17000092 RID: 146
		// (get) Token: 0x060001FD RID: 509 RVA: 0x00003EC7 File Offset: 0x000020C7
		// (set) Token: 0x060001FE RID: 510 RVA: 0x00003ECF File Offset: 0x000020CF
		public byte ShouldNotGetThickSnow { get; set; }

		// Token: 0x17000093 RID: 147
		// (get) Token: 0x060001FF RID: 511 RVA: 0x00003ED8 File Offset: 0x000020D8
		// (set) Token: 0x06000200 RID: 512 RVA: 0x00003EE0 File Offset: 0x000020E0
		public byte SnowPostShapeIsCircle { get; set; }

		// Token: 0x17000094 RID: 148
		// (get) Token: 0x06000201 RID: 513 RVA: 0x00003EE9 File Offset: 0x000020E9
		// (set) Token: 0x06000202 RID: 514 RVA: 0x00003EF1 File Offset: 0x000020F1
		public float SnowThicknessPostScaleFactor { get; set; }

		// Token: 0x17000095 RID: 149
		// (get) Token: 0x06000203 RID: 515 RVA: 0x00003EFA File Offset: 0x000020FA
		// (set) Token: 0x06000204 RID: 516 RVA: 0x00003F02 File Offset: 0x00002102
		public float SnowThicknessRailScaleFactor { get; set; }

		// Token: 0x17000096 RID: 150
		// (get) Token: 0x06000205 RID: 517 RVA: 0x00003F0B File Offset: 0x0000210B
		// (set) Token: 0x06000206 RID: 518 RVA: 0x00003F13 File Offset: 0x00002113
		public float SnowThicknessPostVerticalOffset { get; set; }

		// Token: 0x17000097 RID: 151
		// (get) Token: 0x06000207 RID: 519 RVA: 0x00003F1C File Offset: 0x0000211C
		// (set) Token: 0x06000208 RID: 520 RVA: 0x00003F24 File Offset: 0x00002124
		public float SnowThicknessRailVerticalOffset { get; set; }

		// Token: 0x06000209 RID: 521 RVA: 0x00003F2D File Offset: 0x0000212D
		public FENCE()
		{
			this.typeId = 68746794U;
		}

		// Token: 0x0600020A RID: 522 RVA: 0x00013C0C File Offset: 0x00011E0C
		public override int ReplaceReferences(ResKey from, ResKey to)
		{
			int num = 0;
			foreach (TGIIndex tgiindex in base.TGIIndex)
			{
				if (tgiindex.Equals(from))
				{
					tgiindex.SetFromResKey(to);
					num++;
				}
			}
			foreach (OBJD.Material material in base.Materials)
			{
				num += material.ReplaceReferences(from, to);
			}
			return num;
		}

		// Token: 0x0600020B RID: 523 RVA: 0x00013CBC File Offset: 0x00011EBC
		public override void UnSerialize()
		{
			base.TGIIndex.Clear();
			base.Materials.Clear();
			MemoryStream memoryStream = new MemoryStream(this.data);
			BinaryReader binaryReader = new BinaryReader(memoryStream);
			base.Version = binaryReader.ReadUInt32();
			this.tgiOffset = binaryReader.ReadUInt32();
			this.tgiSize = binaryReader.ReadUInt32();
			if (base.Version >= 7U)
			{
				uint num = binaryReader.ReadUInt32();
				int num2 = 0;
				while ((long)num2 < (long)((ulong)num))
				{
					OBJD.Material material = new OBJD.Material();
					material.Unserialize(binaryReader);
					base.Materials.Add(material);
					num2++;
				}
			}
			base._readCommonSection(binaryReader);
			this.VPXYIndex = binaryReader.ReadInt32();
			this.DiagonalModelIndex = binaryReader.ReadInt32();
			this.PostModel = binaryReader.ReadInt32();
			this.PostTileSpacing = binaryReader.ReadInt32();
			this.CanWalkOver = binaryReader.ReadByte();
			if (base.Version >= 8U)
			{
				if (base.Version >= 10U)
				{
					this.ShouldNotGetThickSnow = binaryReader.ReadByte();
					this.SnowPostShapeIsCircle = binaryReader.ReadByte();
					this.SnowThicknessPostScaleFactor = binaryReader.ReadSingle();
					this.SnowThicknessRailScaleFactor = binaryReader.ReadSingle();
					this.SnowThicknessPostVerticalOffset = binaryReader.ReadSingle();
					this.SnowThicknessRailVerticalOffset = binaryReader.ReadSingle();
					this.HasWall = binaryReader.ReadByte();
				}
				if (base.Version < 10U || this.HasWall != 0)
				{
					this.RaiseFenceGeometryAboveWall = binaryReader.ReadByte();
					this.wallTgiIndex = binaryReader.ReadInt32();
				}
			}
			uint num3 = binaryReader.ReadUInt32();
			int num4 = 0;
			while ((long)num4 < (long)((ulong)num3))
			{
				TGIIndex tgiindex = new TGIIndex();
				tgiindex.UnSerialize(binaryReader);
				base.TGIIndex.Add(tgiindex);
				num4++;
			}
			memoryStream.Dispose();
			binaryReader.Close();
		}

		// Token: 0x0600020C RID: 524 RVA: 0x00013E6C File Offset: 0x0001206C
		public override byte[] Serialize()
		{
			MemoryStream memoryStream = new MemoryStream();
			BinaryWriter binaryWriter = new BinaryWriter(memoryStream, Encoding.BigEndianUnicode);
			MemoryStream memoryStream2 = new MemoryStream();
			BinaryWriter binaryWriter2 = new BinaryWriter(memoryStream2, Encoding.BigEndianUnicode);
			if (base.Version >= 7U)
			{
				binaryWriter2.Write(base.Materials.Count);
				foreach (OBJD.Material material in base.Materials)
				{
					material.Serialize(binaryWriter2);
				}
			}
			base._writeCommon(binaryWriter2);
			binaryWriter2.Write(this.VPXYIndex);
			binaryWriter2.Write(this.DiagonalModelIndex);
			binaryWriter2.Write(this.PostModel);
			binaryWriter2.Write(this.PostTileSpacing);
			binaryWriter2.Write(this.CanWalkOver);
			if (base.Version >= 8U)
			{
				if (base.Version >= 10U)
				{
					binaryWriter2.Write(this.ShouldNotGetThickSnow);
					binaryWriter2.Write(this.SnowPostShapeIsCircle);
					binaryWriter2.Write(this.SnowThicknessPostScaleFactor);
					binaryWriter2.Write(this.SnowThicknessRailScaleFactor);
					binaryWriter2.Write(this.SnowThicknessPostVerticalOffset);
					binaryWriter2.Write(this.SnowThicknessRailVerticalOffset);
					binaryWriter2.Write(this.HasWall);
				}
				if (base.Version < 10U || this.HasWall != 0)
				{
					binaryWriter2.Write(this.RaiseFenceGeometryAboveWall);
					binaryWriter2.Write(this.wallTgiIndex);
				}
			}
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

		// Token: 0x04000111 RID: 273
		private uint tgiOffset;

		// Token: 0x04000112 RID: 274
		private uint tgiSize;
	}
}
