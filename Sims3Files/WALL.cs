using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Package.SharedFiles;
using Sims3WorkshopSDK;

namespace Package.Sims3Files
{
	// Token: 0x02000050 RID: 80
	public class WALL : Sims3BuildItem
	{
		// Token: 0x1700014C RID: 332
		// (get) Token: 0x06000405 RID: 1029 RVA: 0x00004F0F File Offset: 0x0000310F
		// (set) Token: 0x06000406 RID: 1030 RVA: 0x00004F17 File Offset: 0x00003117
		public WALL.PatternType Type { get; set; }

		// Token: 0x1700014D RID: 333
		// (get) Token: 0x06000407 RID: 1031 RVA: 0x00004F20 File Offset: 0x00003120
		// (set) Token: 0x06000408 RID: 1032 RVA: 0x00004F28 File Offset: 0x00003128
		public uint SortFlags { get; set; }

		// Token: 0x1700014E RID: 334
		// (get) Token: 0x06000409 RID: 1033 RVA: 0x00004F31 File Offset: 0x00003131
		// (set) Token: 0x0600040A RID: 1034 RVA: 0x00004F39 File Offset: 0x00003139
		public WALL.TerrainType Terrain { get; set; }

		// Token: 0x1700014F RID: 335
		// (get) Token: 0x0600040B RID: 1035 RVA: 0x00004F42 File Offset: 0x00003142
		// (set) Token: 0x0600040C RID: 1036 RVA: 0x00004F4A File Offset: 0x0000314A
		public int SurfaceColor { get; set; }

		// Token: 0x17000150 RID: 336
		// (get) Token: 0x0600040D RID: 1037 RVA: 0x00004F53 File Offset: 0x00003153
		// (set) Token: 0x0600040E RID: 1038 RVA: 0x00004F5B File Offset: 0x0000315B
		public int MaterialIndex { get; set; }

		// Token: 0x17000151 RID: 337
		// (get) Token: 0x0600040F RID: 1039 RVA: 0x00004F64 File Offset: 0x00003164
		// (set) Token: 0x06000410 RID: 1040 RVA: 0x00004F6C File Offset: 0x0000316C
		public override int VPXYIndex
		{
			get
			{
				return this.MaterialIndex;
			}
			set
			{
				this.MaterialIndex = value;
			}
		}

		// Token: 0x17000152 RID: 338
		// (get) Token: 0x06000411 RID: 1041 RVA: 0x00003C99 File Offset: 0x00001E99
		// (set) Token: 0x06000412 RID: 1042 RVA: 0x000032EA File Offset: 0x000014EA
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

		// Token: 0x17000153 RID: 339
		// (get) Token: 0x06000413 RID: 1043 RVA: 0x00003C99 File Offset: 0x00001E99
		// (set) Token: 0x06000414 RID: 1044 RVA: 0x000032EA File Offset: 0x000014EA
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

		// Token: 0x17000154 RID: 340
		// (get) Token: 0x06000415 RID: 1045 RVA: 0x00004F75 File Offset: 0x00003175
		// (set) Token: 0x06000416 RID: 1046 RVA: 0x00004F7D File Offset: 0x0000317D
		public string _7bitString { get; set; }

		// Token: 0x06000417 RID: 1047 RVA: 0x00004F86 File Offset: 0x00003186
		public WALL()
		{
			base.TGIIndex = new List<TGIIndex>();
			this.typeId = 1365025997U;
		}

		// Token: 0x06000418 RID: 1048 RVA: 0x00013C0C File Offset: 0x00011E0C
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

		// Token: 0x06000419 RID: 1049 RVA: 0x0001AE80 File Offset: 0x00019080
		public override void UnSerialize()
		{
			base.Materials.Clear();
			base.TGIIndex.Clear();
			MemoryStream memoryStream = new MemoryStream(this.data);
			BinaryReader binaryReader = new BinaryReader(memoryStream);
			base.Version = binaryReader.ReadUInt32();
			this.tgiOffset = binaryReader.ReadUInt32();
			this.tgiSize = binaryReader.ReadUInt32();
			uint num = binaryReader.ReadUInt32();
			int num2 = 0;
			while ((long)num2 < (long)((ulong)num))
			{
				OBJD.Material material = new OBJD.Material();
				material.IsFloorOrWall = true;
				material.Unserialize(binaryReader);
				base.Materials.Add(material);
				num2++;
			}
			base._readCommonSection(binaryReader);
			this.Type = (WALL.PatternType)binaryReader.ReadUInt32();
			this.MaterialIndex = binaryReader.ReadInt32();
			this.SortFlags = binaryReader.ReadUInt32();
			this._7bitString = PackageUtil.ReadString(binaryReader, (int)binaryReader.ReadByte());
			this.Terrain = (WALL.TerrainType)binaryReader.ReadUInt32();
			this.SurfaceColor = binaryReader.ReadInt32();
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

		// Token: 0x0600041A RID: 1050 RVA: 0x0001AFB0 File Offset: 0x000191B0
		public override byte[] Serialize()
		{
			MemoryStream memoryStream = new MemoryStream();
			BinaryWriter binaryWriter = new BinaryWriter(memoryStream, Encoding.BigEndianUnicode);
			MemoryStream memoryStream2 = new MemoryStream();
			BinaryWriter binaryWriter2 = new BinaryWriter(memoryStream2, Encoding.BigEndianUnicode);
			binaryWriter2.Write(base.Materials.Count);
			foreach (OBJD.Material material in base.Materials)
			{
				material.Serialize(binaryWriter2);
			}
			base._writeCommon(binaryWriter2);
			binaryWriter2.Write((uint)this.Type);
			binaryWriter2.Write(this.MaterialIndex);
			binaryWriter2.Write(this.SortFlags);
			binaryWriter2.Write((byte)this._7bitString.Length);
			for (int i = 0; i < this._7bitString.Length; i++)
			{
				binaryWriter2.Write((byte)this._7bitString[i]);
			}
			binaryWriter2.Write((uint)this.Terrain);
			binaryWriter2.Write(this.SurfaceColor);
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

		// Token: 0x0400020B RID: 523
		private uint tgiOffset;

		// Token: 0x0400020C RID: 524
		private uint tgiSize;

		// Token: 0x0200011E RID: 286
		public enum PatternType : uint
		{
			// Token: 0x0400074D RID: 1869
			Floor = 1U,
			// Token: 0x0400074E RID: 1870
			Wall,
			// Token: 0x0400074F RID: 1871
			Ceiling,
			// Token: 0x04000750 RID: 1872
			FloorEdge
		}

		// Token: 0x0200011F RID: 287
		public enum WallCategory : uint
		{
			// Token: 0x04000752 RID: 1874
			Unknown,
			// Token: 0x04000753 RID: 1875
			Miscellaneous = 2U,
			// Token: 0x04000754 RID: 1876
			Masonry = 4U,
			// Token: 0x04000755 RID: 1877
			Paint = 8U,
			// Token: 0x04000756 RID: 1878
			Paneling = 16U,
			// Token: 0x04000757 RID: 1879
			RockAndStone = 32U,
			// Token: 0x04000758 RID: 1880
			Siding = 64U,
			// Token: 0x04000759 RID: 1881
			Tile = 128U,
			// Token: 0x0400075A RID: 1882
			Wallpaper = 256U,
			// Token: 0x0400075B RID: 1883
			WallSet = 512U
		}

		// Token: 0x02000120 RID: 288
		public enum FloorCategory : uint
		{
			// Token: 0x0400075D RID: 1885
			Unknown,
			// Token: 0x0400075E RID: 1886
			Miscellaneous = 2U,
			// Token: 0x0400075F RID: 1887
			Carpet = 4U,
			// Token: 0x04000760 RID: 1888
			Linoleum = 8U,
			// Token: 0x04000761 RID: 1889
			Masonry = 16U,
			// Token: 0x04000762 RID: 1890
			Metal = 32U,
			// Token: 0x04000763 RID: 1891
			RockAndStone = 64U,
			// Token: 0x04000764 RID: 1892
			Tile = 128U,
			// Token: 0x04000765 RID: 1893
			Wood = 256U,
			// Token: 0x04000766 RID: 1894
			CeilingTile = 512U
		}

		// Token: 0x02000121 RID: 289
		public enum TerrainType : uint
		{
			// Token: 0x04000768 RID: 1896
			Default,
			// Token: 0x04000769 RID: 1897
			Asphalt01,
			// Token: 0x0400076A RID: 1898
			Cement01,
			// Token: 0x0400076B RID: 1899
			Cobblestone01,
			// Token: 0x0400076C RID: 1900
			Concrete01,
			// Token: 0x0400076D RID: 1901
			Concrete02,
			// Token: 0x0400076E RID: 1902
			Carpet01,
			// Token: 0x0400076F RID: 1903
			Dirt01,
			// Token: 0x04000770 RID: 1904
			Dirt02,
			// Token: 0x04000771 RID: 1905
			Flagstone01,
			// Token: 0x04000772 RID: 1906
			Footpath,
			// Token: 0x04000773 RID: 1907
			Glass01,
			// Token: 0x04000774 RID: 1908
			Grass01,
			// Token: 0x04000775 RID: 1909
			Grass02,
			// Token: 0x04000776 RID: 1910
			Gravel01,
			// Token: 0x04000777 RID: 1911
			Gravel02,
			// Token: 0x04000778 RID: 1912
			Ice01,
			// Token: 0x04000779 RID: 1913
			Linoleum01,
			// Token: 0x0400077A RID: 1914
			Mud01,
			// Token: 0x0400077B RID: 1915
			Mulch01,
			// Token: 0x0400077C RID: 1916
			Rock01,
			// Token: 0x0400077D RID: 1917
			Rock02,
			// Token: 0x0400077E RID: 1918
			Sand01,
			// Token: 0x0400077F RID: 1919
			Sand02,
			// Token: 0x04000780 RID: 1920
			Wood01,
			// Token: 0x04000781 RID: 1921
			Wood02,
			// Token: 0x04000782 RID: 1922
			Wood03,
			// Token: 0x04000783 RID: 1923
			Marble01,
			// Token: 0x04000784 RID: 1924
			Masonry01,
			// Token: 0x04000785 RID: 1925
			Metal01,
			// Token: 0x04000786 RID: 1926
			Plastic01,
			// Token: 0x04000787 RID: 1927
			Road01,
			// Token: 0x04000788 RID: 1928
			Road01_Sidewalk,
			// Token: 0x04000789 RID: 1929
			Snow01,
			// Token: 0x0400078A RID: 1930
			Tile01,
			// Token: 0x0400078B RID: 1931
			Water_Deep,
			// Token: 0x0400078C RID: 1932
			Water_Knees,
			// Token: 0x0400078D RID: 1933
			Water_PondOrPool,
			// Token: 0x0400078E RID: 1934
			Water_Puddle,
			// Token: 0x0400078F RID: 1935
			Water_Waist,
			// Token: 0x04000790 RID: 1936
			LotCenter
		}
	}
}
