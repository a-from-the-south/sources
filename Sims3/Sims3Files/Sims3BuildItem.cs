using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Package.SharedFiles;

namespace Package.Sims3Files
{
	// Token: 0x02000017 RID: 23
	public abstract class Sims3BuildItem : DBPFEntry
	{
		// Token: 0x17000038 RID: 56
		// (get) Token: 0x0600011D RID: 285
		// (set) Token: 0x0600011E RID: 286
		public abstract int VPXYIndex { get; set; }

		// Token: 0x17000039 RID: 57
		// (get) Token: 0x0600011F RID: 287
		// (set) Token: 0x06000120 RID: 288
		public abstract int DiagonalModelIndex { get; set; }

		// Token: 0x1700003A RID: 58
		// (get) Token: 0x06000121 RID: 289
		// (set) Token: 0x06000122 RID: 290
		public abstract int PostModel { get; set; }

		// Token: 0x1700003B RID: 59
		// (get) Token: 0x06000123 RID: 291 RVA: 0x00003832 File Offset: 0x00001A32
		// (set) Token: 0x06000124 RID: 292 RVA: 0x0000383A File Offset: 0x00001A3A
		public uint Version { get; set; }

		// Token: 0x1700003C RID: 60
		// (get) Token: 0x06000125 RID: 293 RVA: 0x00003843 File Offset: 0x00001A43
		// (set) Token: 0x06000126 RID: 294 RVA: 0x0000384B File Offset: 0x00001A4B
		public long NameGuid { get; set; }

		// Token: 0x1700003D RID: 61
		// (get) Token: 0x06000127 RID: 295 RVA: 0x00003854 File Offset: 0x00001A54
		// (set) Token: 0x06000128 RID: 296 RVA: 0x0000385C File Offset: 0x00001A5C
		public long DescGuid { get; set; }

		// Token: 0x1700003E RID: 62
		// (get) Token: 0x06000129 RID: 297 RVA: 0x00003865 File Offset: 0x00001A65
		// (set) Token: 0x0600012A RID: 298 RVA: 0x0000386D File Offset: 0x00001A6D
		public string CatalogNameEntry { get; set; }

		// Token: 0x1700003F RID: 63
		// (get) Token: 0x0600012B RID: 299 RVA: 0x00003876 File Offset: 0x00001A76
		// (set) Token: 0x0600012C RID: 300 RVA: 0x0000387E File Offset: 0x00001A7E
		public string CatalogDescEntry { get; set; }

		// Token: 0x17000040 RID: 64
		// (get) Token: 0x0600012D RID: 301 RVA: 0x00003887 File Offset: 0x00001A87
		// (set) Token: 0x0600012E RID: 302 RVA: 0x0000388F File Offset: 0x00001A8F
		public long PngIcon { get; set; }

		// Token: 0x17000041 RID: 65
		// (get) Token: 0x0600012F RID: 303 RVA: 0x00003898 File Offset: 0x00001A98
		// (set) Token: 0x06000130 RID: 304 RVA: 0x000038A0 File Offset: 0x00001AA0
		public float Price { get; set; }

		// Token: 0x17000042 RID: 66
		// (get) Token: 0x06000131 RID: 305 RVA: 0x000038A9 File Offset: 0x00001AA9
		// (set) Token: 0x06000132 RID: 306 RVA: 0x000038B1 File Offset: 0x00001AB1
		public Sims3BuildItem.BuildBuyProductStatusFlags BuildItemType
		{
			get
			{
				return (Sims3BuildItem.BuildBuyProductStatusFlags)this._buildBuyStatusFlags;
			}
			set
			{
				this._buildBuyStatusFlags = (byte)value;
			}
		}

		// Token: 0x17000043 RID: 67
		// (get) Token: 0x06000133 RID: 307 RVA: 0x000038BA File Offset: 0x00001ABA
		// (set) Token: 0x06000134 RID: 308 RVA: 0x000038C2 File Offset: 0x00001AC2
		public List<TGIIndex> TGIIndex { get; set; }

		// Token: 0x17000044 RID: 68
		// (get) Token: 0x06000135 RID: 309 RVA: 0x000038CB File Offset: 0x00001ACB
		// (set) Token: 0x06000136 RID: 310 RVA: 0x000038D3 File Offset: 0x00001AD3
		public List<OBJD.Material> Materials { get; private set; }

		// Token: 0x06000137 RID: 311 RVA: 0x000038DC File Offset: 0x00001ADC
		public Sims3BuildItem()
		{
			this.TGIIndex = new List<TGIIndex>();
			this.Materials = new List<OBJD.Material>();
		}

		// Token: 0x06000138 RID: 312 RVA: 0x000038FA File Offset: 0x00001AFA
		public override void UnSerialize()
		{
			throw new NotImplementedException();
		}

		// Token: 0x06000139 RID: 313 RVA: 0x000038FA File Offset: 0x00001AFA
		public override byte[] Serialize()
		{
			throw new NotImplementedException();
		}

		// Token: 0x0600013A RID: 314 RVA: 0x0001228C File Offset: 0x0001048C
		public void _readCommonSection(BinaryReader r)
		{
			BinaryReader binaryReader = new BinaryReader(r.BaseStream, Encoding.BigEndianUnicode);
			this.CommonBlockVersion = r.ReadUInt32();
			this.NameGuid = r.ReadInt64();
			this.DescGuid = r.ReadInt64();
			this.CatalogNameEntry = binaryReader.ReadString();
			this.CatalogDescEntry = binaryReader.ReadString();
			this.Price = r.ReadSingle();
			this.NicenessMultiplier = r.ReadSingle();
			this.CrapScore = r.ReadBytes(4);
			this._buildBuyStatusFlags = r.ReadByte();
			this.PngIcon = r.ReadInt64();
			this.zeroByte = r.ReadByte();
			this.environmentScore = r.ReadSingle();
			this.firetype = r.ReadUInt32();
			this.isStealable = r.ReadByte();
			this.isReposessable = r.ReadByte();
			this.uiSortIndex = r.ReadUInt32();
			if (this.CommonBlockVersion >= 13U)
			{
				this.isPlaceableOnRoof = r.ReadByte();
				if (this.CommonBlockVersion >= 14U)
				{
					this.isVisibleInWorldbuilder = r.ReadByte();
				}
				if (this.CommonBlockVersion >= 15U)
				{
					this._hashedProductName = r.ReadInt32();
				}
			}
		}

		// Token: 0x0600013B RID: 315 RVA: 0x000123B0 File Offset: 0x000105B0
		public void _writeCommon(BinaryWriter w)
		{
			w.Write(this.CommonBlockVersion);
			w.Write(this.NameGuid);
			w.Write(this.DescGuid);
			w.Write(this.CatalogNameEntry);
			w.Write(this.CatalogDescEntry);
			w.Write(this.Price);
			w.Write(this.NicenessMultiplier);
			w.Write(this.CrapScore);
			w.Write(this._buildBuyStatusFlags);
			w.Write(this.PngIcon);
			w.Write(this.zeroByte);
			w.Write(this.environmentScore);
			w.Write(this.firetype);
			w.Write(this.isStealable);
			w.Write(this.isReposessable);
			w.Write(this.uiSortIndex);
			if (this.CommonBlockVersion >= 13U)
			{
				w.Write(this.isPlaceableOnRoof);
				if (this.CommonBlockVersion >= 14U)
				{
					w.Write(this.isVisibleInWorldbuilder);
				}
				if (this.CommonBlockVersion >= 15U)
				{
					w.Write(this._hashedProductName);
				}
			}
		}

		// Token: 0x0400006C RID: 108
		public byte zeroByte;

		// Token: 0x0400006D RID: 109
		public float environmentScore;

		// Token: 0x0400006E RID: 110
		public uint firetype;

		// Token: 0x0400006F RID: 111
		public byte isStealable;

		// Token: 0x04000070 RID: 112
		public byte isReposessable;

		// Token: 0x04000071 RID: 113
		public uint uiSortIndex;

		// Token: 0x04000073 RID: 115
		protected uint CommonBlockVersion;

		// Token: 0x04000074 RID: 116
		protected byte _buildBuyStatusFlags;

		// Token: 0x04000075 RID: 117
		protected byte[] CrapScore;

		// Token: 0x04000076 RID: 118
		protected float NicenessMultiplier;

		// Token: 0x04000077 RID: 119
		protected byte isPlaceableOnRoof;

		// Token: 0x04000078 RID: 120
		protected byte isVisibleInWorldbuilder;

		// Token: 0x04000079 RID: 121
		protected int _hashedProductName;

		// Token: 0x020000FF RID: 255
		[Flags]
		public enum BuildBuyProductStatusFlags : byte
		{
			// Token: 0x04000609 RID: 1545
			ShowInCatalog = 1,
			// Token: 0x0400060A RID: 1546
			ProductForTesting = 2,
			// Token: 0x0400060B RID: 1547
			ProductInDevelopment = 4,
			// Token: 0x0400060C RID: 1548
			ShippingProduct = 8,
			// Token: 0x0400060D RID: 1549
			DebugProduct = 16,
			// Token: 0x0400060E RID: 1550
			ObjProductMadeUsingNewEntryScheme = 32
		}
	}
}
