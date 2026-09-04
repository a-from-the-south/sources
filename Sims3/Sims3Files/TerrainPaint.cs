using System;
using System.IO;
using System.Text;
using Package.SharedFiles;
using Sims3WorkshopSDK;

namespace Package.Sims3Files
{
	// Token: 0x0200004B RID: 75
	public class TerrainPaint : Sims3BuildItem
	{
		// Token: 0x17000138 RID: 312
		// (get) Token: 0x060003CB RID: 971 RVA: 0x00004D6D File Offset: 0x00002F6D
		// (set) Token: 0x060003CC RID: 972 RVA: 0x00004D75 File Offset: 0x00002F75
		public uint BrushCommonVersion { get; set; }

		// Token: 0x17000139 RID: 313
		// (get) Token: 0x060003CD RID: 973 RVA: 0x00004D7E File Offset: 0x00002F7E
		// (set) Token: 0x060003CE RID: 974 RVA: 0x00004D86 File Offset: 0x00002F86
		public TerrainPaint.BrushOperation NormalOperation { get; set; }

		// Token: 0x1700013A RID: 314
		// (get) Token: 0x060003CF RID: 975 RVA: 0x00004D8F File Offset: 0x00002F8F
		// (set) Token: 0x060003D0 RID: 976 RVA: 0x00004D97 File Offset: 0x00002F97
		public TerrainPaint.BrushOperation OppositeOperation { get; set; }

		// Token: 0x1700013B RID: 315
		// (get) Token: 0x060003D1 RID: 977 RVA: 0x00004DA0 File Offset: 0x00002FA0
		// (set) Token: 0x060003D2 RID: 978 RVA: 0x00004DA8 File Offset: 0x00002FA8
		public TerrainPaint.BrushOrientation Orientation { get; set; }

		// Token: 0x1700013C RID: 316
		// (get) Token: 0x060003D3 RID: 979 RVA: 0x00004DB1 File Offset: 0x00002FB1
		// (set) Token: 0x060003D4 RID: 980 RVA: 0x00004DB9 File Offset: 0x00002FB9
		public float BrushWidth { get; set; }

		// Token: 0x1700013D RID: 317
		// (get) Token: 0x060003D5 RID: 981 RVA: 0x00004DC2 File Offset: 0x00002FC2
		// (set) Token: 0x060003D6 RID: 982 RVA: 0x00004DCA File Offset: 0x00002FCA
		public float BrushStrength { get; set; }

		// Token: 0x1700013E RID: 318
		// (get) Token: 0x060003D7 RID: 983 RVA: 0x00004DD3 File Offset: 0x00002FD3
		// (set) Token: 0x060003D8 RID: 984 RVA: 0x00004DDB File Offset: 0x00002FDB
		public byte BaseTextureValue { get; set; }

		// Token: 0x1700013F RID: 319
		// (get) Token: 0x060003D9 RID: 985 RVA: 0x00004DE4 File Offset: 0x00002FE4
		// (set) Token: 0x060003DA RID: 986 RVA: 0x00004DEC File Offset: 0x00002FEC
		public float WiggleAmount { get; set; }

		// Token: 0x17000140 RID: 320
		// (get) Token: 0x060003DB RID: 987 RVA: 0x00004DF5 File Offset: 0x00002FF5
		// (set) Token: 0x060003DC RID: 988 RVA: 0x00004DFD File Offset: 0x00002FFD
		public WALL.TerrainType TerrainType { get; set; }

		// Token: 0x17000141 RID: 321
		// (get) Token: 0x060003DD RID: 989 RVA: 0x00004E06 File Offset: 0x00003006
		// (set) Token: 0x060003DE RID: 990 RVA: 0x00004E0E File Offset: 0x0000300E
		public TerrainPaint.TerrainPaintCategory Category { get; set; }

		// Token: 0x17000142 RID: 322
		// (get) Token: 0x060003DF RID: 991 RVA: 0x00004E17 File Offset: 0x00003017
		// (set) Token: 0x060003E0 RID: 992 RVA: 0x00004E1F File Offset: 0x0000301F
		public TGIIndex BrushTGI { get; set; }

		// Token: 0x17000143 RID: 323
		// (get) Token: 0x060003E1 RID: 993 RVA: 0x00004E28 File Offset: 0x00003028
		// (set) Token: 0x060003E2 RID: 994 RVA: 0x00004E30 File Offset: 0x00003030
		public TGIIndex ProfilePicture { get; set; }

		// Token: 0x17000144 RID: 324
		// (get) Token: 0x060003E3 RID: 995 RVA: 0x00003C99 File Offset: 0x00001E99
		// (set) Token: 0x060003E4 RID: 996 RVA: 0x000032EA File Offset: 0x000014EA
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

		// Token: 0x17000145 RID: 325
		// (get) Token: 0x060003E5 RID: 997 RVA: 0x00003C99 File Offset: 0x00001E99
		// (set) Token: 0x060003E6 RID: 998 RVA: 0x000032EA File Offset: 0x000014EA
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

		// Token: 0x17000146 RID: 326
		// (get) Token: 0x060003E7 RID: 999 RVA: 0x00003C99 File Offset: 0x00001E99
		// (set) Token: 0x060003E8 RID: 1000 RVA: 0x000032EA File Offset: 0x000014EA
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

		// Token: 0x060003E9 RID: 1001 RVA: 0x00004E39 File Offset: 0x00003039
		public TerrainPaint()
		{
			this.typeId = 82660274U;
		}

		// Token: 0x060003EA RID: 1002 RVA: 0x0001A888 File Offset: 0x00018A88
		public override byte[] Serialize()
		{
			MemoryStream memoryStream = new MemoryStream();
			BinaryWriter binaryWriter = new BinaryWriter(memoryStream, Encoding.BigEndianUnicode);
			binaryWriter.Write(base.Version);
			binaryWriter.Write(this.BrushCommonVersion);
			base._writeCommon(binaryWriter);
			binaryWriter.Write((uint)this.NormalOperation);
			binaryWriter.Write((uint)this.OppositeOperation);
			this.ProfilePicture.Serialize(binaryWriter);
			binaryWriter.Write((uint)this.Orientation);
			binaryWriter.Write(this.BrushWidth);
			binaryWriter.Write(this.BrushStrength);
			binaryWriter.Write(this.BaseTextureValue);
			binaryWriter.Write(this.WiggleAmount);
			this.BrushTGI.Serialize(binaryWriter);
			if (base.Version >= 4U)
			{
				binaryWriter.Write((uint)this.TerrainType);
				binaryWriter.Write((uint)this.Category);
			}
			this.data = memoryStream.ToArray();
			memoryStream.Dispose();
			binaryWriter.Close();
			return this.data;
		}

		// Token: 0x060003EB RID: 1003 RVA: 0x0001A974 File Offset: 0x00018B74
		public override int ReplaceReferences(ResKey from, ResKey to)
		{
			int num = 0;
			if (this.BrushTGI.Equals(from))
			{
				this.BrushTGI.SetFromResKey(to);
				num++;
			}
			if (this.ProfilePicture.Equals(from))
			{
				this.ProfilePicture.SetFromResKey(to);
				num++;
			}
			return num;
		}

		// Token: 0x060003EC RID: 1004 RVA: 0x0001A9C0 File Offset: 0x00018BC0
		public override void UnSerialize()
		{
			MemoryStream memoryStream = new MemoryStream(this.data);
			BinaryReader binaryReader = new BinaryReader(memoryStream);
			base.Version = binaryReader.ReadUInt32();
			this.BrushCommonVersion = binaryReader.ReadUInt32();
			base._readCommonSection(binaryReader);
			this.NormalOperation = (TerrainPaint.BrushOperation)binaryReader.ReadUInt32();
			this.OppositeOperation = (TerrainPaint.BrushOperation)binaryReader.ReadUInt32();
			this.ProfilePicture = new TGIIndex();
			this.ProfilePicture.UnSerialize(binaryReader);
			this.Orientation = (TerrainPaint.BrushOrientation)binaryReader.ReadUInt32();
			this.BrushWidth = binaryReader.ReadSingle();
			this.BrushStrength = binaryReader.ReadSingle();
			this.BaseTextureValue = binaryReader.ReadByte();
			this.WiggleAmount = binaryReader.ReadSingle();
			this.BrushTGI = new TGIIndex();
			this.BrushTGI.UnSerialize(binaryReader);
			if (base.Version >= 4U)
			{
				this.TerrainType = (WALL.TerrainType)binaryReader.ReadUInt32();
				this.Category = (TerrainPaint.TerrainPaintCategory)binaryReader.ReadUInt32();
			}
			memoryStream.Dispose();
			binaryReader.Close();
		}

		// Token: 0x0200011A RID: 282
		public enum BrushOperation : uint
		{
			// Token: 0x04000732 RID: 1842
			None,
			// Token: 0x04000733 RID: 1843
			Raise,
			// Token: 0x04000734 RID: 1844
			Lower,
			// Token: 0x04000735 RID: 1845
			Smoothen,
			// Token: 0x04000736 RID: 1846
			Level,
			// Token: 0x04000737 RID: 1847
			AddPaint,
			// Token: 0x04000738 RID: 1848
			ErasePaint,
			// Token: 0x04000739 RID: 1849
			AddWater
		}

		// Token: 0x0200011B RID: 283
		public enum BrushOrientation : uint
		{
			// Token: 0x0400073B RID: 1851
			Fixed,
			// Token: 0x0400073C RID: 1852
			AlignWithMouseMoveDirection,
			// Token: 0x0400073D RID: 1853
			RandomWiggle
		}

		// Token: 0x0200011C RID: 284
		public enum TerrainPaintCategory : uint
		{
			// Token: 0x0400073F RID: 1855
			Grass = 1U,
			// Token: 0x04000740 RID: 1856
			Flowers,
			// Token: 0x04000741 RID: 1857
			Rock,
			// Token: 0x04000742 RID: 1858
			Dirt,
			// Token: 0x04000743 RID: 1859
			Other
		}
	}
}
