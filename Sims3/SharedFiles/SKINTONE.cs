using System;
using System.IO;
using Sims3WorkshopSDK;

namespace Package.SharedFiles
{
	// Token: 0x020000AC RID: 172
	public class SKINTONE : DBPFEntry
	{
		// Token: 0x170002E1 RID: 737
		// (get) Token: 0x0600089D RID: 2205 RVA: 0x00006F36 File Offset: 0x00005136
		// (set) Token: 0x0600089E RID: 2206 RVA: 0x00006F3E File Offset: 0x0000513E
		public uint Version
		{
			get
			{
				return this.version;
			}
			set
			{
				this.version = value;
			}
		}

		// Token: 0x170002E2 RID: 738
		// (get) Token: 0x0600089F RID: 2207 RVA: 0x00006F47 File Offset: 0x00005147
		// (set) Token: 0x060008A0 RID: 2208 RVA: 0x00006F4F File Offset: 0x0000514F
		public byte Unk2
		{
			get
			{
				return this.unk2;
			}
			set
			{
				this.unk2 = value;
			}
		}

		// Token: 0x170002E3 RID: 739
		// (get) Token: 0x060008A1 RID: 2209 RVA: 0x00006F58 File Offset: 0x00005158
		// (set) Token: 0x060008A2 RID: 2210 RVA: 0x00006F60 File Offset: 0x00005160
		public byte Unk3
		{
			get
			{
				return this.unk3;
			}
			set
			{
				this.unk3 = value;
			}
		}

		// Token: 0x170002E4 RID: 740
		// (get) Token: 0x060008A3 RID: 2211 RVA: 0x00006F69 File Offset: 0x00005169
		// (set) Token: 0x060008A4 RID: 2212 RVA: 0x00006F71 File Offset: 0x00005171
		public float Unk4
		{
			get
			{
				return this.unk4;
			}
			set
			{
				this.unk4 = value;
			}
		}

		// Token: 0x170002E5 RID: 741
		// (get) Token: 0x060008A5 RID: 2213 RVA: 0x00006F7A File Offset: 0x0000517A
		// (set) Token: 0x060008A6 RID: 2214 RVA: 0x00006F82 File Offset: 0x00005182
		public float Unk5
		{
			get
			{
				return this.unk5;
			}
			set
			{
				this.unk5 = value;
			}
		}

		// Token: 0x170002E6 RID: 742
		// (get) Token: 0x060008A7 RID: 2215 RVA: 0x00006F8B File Offset: 0x0000518B
		// (set) Token: 0x060008A8 RID: 2216 RVA: 0x00006F93 File Offset: 0x00005193
		public float Unk6
		{
			get
			{
				return this.unk6;
			}
			set
			{
				this.unk6 = value;
			}
		}

		// Token: 0x060008A9 RID: 2217 RVA: 0x00006F9C File Offset: 0x0000519C
		public SKINTONE()
		{
			this.typeId = 55867754U;
		}

		// Token: 0x060008AA RID: 2218 RVA: 0x000038FA File Offset: 0x00001AFA
		public override int ReplaceReferences(ResKey from, ResKey to)
		{
			throw new NotImplementedException();
		}

		// Token: 0x060008AB RID: 2219 RVA: 0x0002B10C File Offset: 0x0002930C
		public override void UnSerialize()
		{
			BinaryReader binaryReader = new BinaryReader(new MemoryStream(this.data));
			this.version = binaryReader.ReadUInt32();
			if (this.version > 8U)
			{
				this.tanFlags = binaryReader.ReadByte();
				this.noTan = new SKINTONE.TanLevel();
				this.deepTan = new SKINTONE.TanLevel();
				this.sunBurned = new SKINTONE.TanLevel();
				this.noTan.Unserialize(binaryReader);
				this.deepTan.Unserialize(binaryReader);
				this.sunBurned.Unserialize(binaryReader);
			}
			else
			{
				this.textureInstance = binaryReader.ReadUInt64();
			}
			this.overlayTextureCount = binaryReader.ReadUInt32();
			if (this.overlayTextureCount > 0U)
			{
				this.overlayTextures = new SKINTONE.OverlayTexture[this.overlayTextureCount];
				int num = 0;
				while ((long)num < (long)((ulong)this.overlayTextureCount))
				{
					this.overlayTextures[num] = new SKINTONE.OverlayTexture();
					this.overlayTextures[num].Unserialize(binaryReader);
					num++;
				}
			}
			this.colorize = binaryReader.ReadUInt32();
			this.opacity2 = binaryReader.ReadUInt32();
			this.tagCount = binaryReader.ReadUInt32();
			if (this.tagCount > 0U)
			{
				this.tags = new SKINTONE.Tag[this.tagCount];
				int num2 = 0;
				while ((long)num2 < (long)((ulong)this.tagCount))
				{
					this.tags[num2] = new SKINTONE.Tag(this.version);
					this.tags[num2].Unserialize(binaryReader);
					num2++;
				}
			}
			if (this.version <= 8U)
			{
				this.makeupopacity = binaryReader.ReadSingle();
			}
			this.numSwatchColors = binaryReader.ReadByte();
			if (this.numSwatchColors > 0)
			{
				this.swatchColors = new uint[(int)this.numSwatchColors];
				for (int i = 0; i < (int)this.numSwatchColors; i++)
				{
					this.swatchColors[i] = binaryReader.ReadUInt32();
				}
			}
			this.displayIndex = binaryReader.ReadSingle();
			if (this.version <= 8U)
			{
				this.mMakeupOpacity2 = binaryReader.ReadSingle();
			}
			if (this.version > 7U)
			{
				this.occulSkintoneInstance = binaryReader.ReadUInt64();
			}
			if (this.version >= 11U)
			{
				this.unk2 = binaryReader.ReadByte();
				this.unk3 = binaryReader.ReadByte();
				this.unk4 = binaryReader.ReadSingle();
				this.unk5 = binaryReader.ReadSingle();
				this.unk6 = binaryReader.ReadSingle();
			}
		}

		// Token: 0x060008AC RID: 2220 RVA: 0x0002B33C File Offset: 0x0002953C
		public override byte[] Serialize()
		{
			MemoryStream memoryStream = new MemoryStream();
			BinaryWriter binaryWriter = new BinaryWriter(memoryStream);
			binaryWriter.Write(this.version);
			if (this.version > 8U)
			{
				binaryWriter.Write(this.tanFlags);
				this.noTan.Serialize(binaryWriter);
				this.deepTan.Serialize(binaryWriter);
				this.sunBurned.Serialize(binaryWriter);
			}
			else
			{
				binaryWriter.Write(this.textureInstance);
			}
			binaryWriter.Write(this.overlayTextureCount);
			if (this.overlayTextureCount > 0U)
			{
				int num = 0;
				while ((long)num < (long)((ulong)this.overlayTextureCount))
				{
					this.overlayTextures[num].Serialize(binaryWriter);
					num++;
				}
			}
			binaryWriter.Write(this.colorize);
			binaryWriter.Write(this.opacity2);
			binaryWriter.Write(this.tagCount);
			if (this.tagCount > 0U)
			{
				int num2 = 0;
				while ((long)num2 < (long)((ulong)this.tagCount))
				{
					this.tags[num2].Serialize(binaryWriter);
					num2++;
				}
			}
			if (this.version <= 8U)
			{
				binaryWriter.Write(this.makeupopacity);
			}
			binaryWriter.Write(this.numSwatchColors);
			if (this.numSwatchColors > 0)
			{
				for (int i = 0; i < (int)this.numSwatchColors; i++)
				{
					binaryWriter.Write(this.swatchColors[i]);
				}
			}
			binaryWriter.Write(this.displayIndex);
			if (this.version <= 8U)
			{
				binaryWriter.Write(this.mMakeupOpacity2);
			}
			if (this.version > 7U)
			{
				binaryWriter.Write(this.occulSkintoneInstance);
			}
			if (this.version >= 11U)
			{
				binaryWriter.Write(this.unk2);
				binaryWriter.Write(this.unk3);
				binaryWriter.Write(this.unk4);
				binaryWriter.Write(this.unk5);
				binaryWriter.Write(this.unk6);
			}
			byte[] result = memoryStream.ToArray();
			memoryStream.Dispose();
			return result;
		}

		// Token: 0x04000422 RID: 1058
		private uint version;

		// Token: 0x04000423 RID: 1059
		public byte tanFlags;

		// Token: 0x04000424 RID: 1060
		private SKINTONE.Tag[] tags;

		// Token: 0x04000425 RID: 1061
		public SKINTONE.TanLevel noTan;

		// Token: 0x04000426 RID: 1062
		public SKINTONE.TanLevel deepTan;

		// Token: 0x04000427 RID: 1063
		public SKINTONE.TanLevel sunBurned;

		// Token: 0x04000428 RID: 1064
		public ulong textureInstance;

		// Token: 0x04000429 RID: 1065
		private uint overlayTextureCount;

		// Token: 0x0400042A RID: 1066
		private SKINTONE.OverlayTexture[] overlayTextures;

		// Token: 0x0400042B RID: 1067
		private uint colorize;

		// Token: 0x0400042C RID: 1068
		private uint opacity2;

		// Token: 0x0400042D RID: 1069
		private uint tagCount;

		// Token: 0x0400042E RID: 1070
		public float makeupopacity;

		// Token: 0x0400042F RID: 1071
		private byte numSwatchColors;

		// Token: 0x04000430 RID: 1072
		private uint[] swatchColors;

		// Token: 0x04000431 RID: 1073
		private float displayIndex;

		// Token: 0x04000432 RID: 1074
		public float mMakeupOpacity2;

		// Token: 0x04000433 RID: 1075
		private ulong occulSkintoneInstance;

		// Token: 0x04000434 RID: 1076
		private byte unk2;

		// Token: 0x04000435 RID: 1077
		private byte unk3;

		// Token: 0x04000436 RID: 1078
		private float unk4;

		// Token: 0x04000437 RID: 1079
		private float unk5;

		// Token: 0x04000438 RID: 1080
		private float unk6;

		// Token: 0x02000198 RID: 408
		private class OverlayTexture
		{
			// Token: 0x06000F3C RID: 3900 RVA: 0x0000A91C File Offset: 0x00008B1C
			public void Unserialize(BinaryReader r)
			{
				this.ageGenderFlags = r.ReadUInt32();
				this.textureInstance = r.ReadUInt64();
			}

			// Token: 0x06000F3D RID: 3901 RVA: 0x0000A936 File Offset: 0x00008B36
			public void Serialize(BinaryWriter w)
			{
				w.Write(this.ageGenderFlags);
				w.Write(this.textureInstance);
			}

			// Token: 0x04000C73 RID: 3187
			private uint ageGenderFlags;

			// Token: 0x04000C74 RID: 3188
			private ulong textureInstance;
		}

		// Token: 0x02000199 RID: 409
		private class Tag
		{
			// Token: 0x06000F3F RID: 3903 RVA: 0x0000A950 File Offset: 0x00008B50
			public Tag(uint parentVersion)
			{
				this.parentVersion = parentVersion;
			}

			// Token: 0x06000F40 RID: 3904 RVA: 0x0000A95F File Offset: 0x00008B5F
			public void Unserialize(BinaryReader r)
			{
				this.category = (CASP.Sims4Flag.FlagCategory)r.ReadUInt16();
				this.value = (CASP.Sims4Flag.FlagValue)((this.parentVersion >= 7U) ? r.ReadInt32() : ((int)r.ReadUInt16()));
			}

			// Token: 0x06000F41 RID: 3905 RVA: 0x0000A98A File Offset: 0x00008B8A
			public void Serialize(BinaryWriter w)
			{
				w.Write((ushort)this.category);
				w.Write((uint)((this.parentVersion >= 7U) ? this.value : ((CASP.Sims4Flag.FlagValue)((ushort)this.value))));
			}

			// Token: 0x04000C75 RID: 3189
			private CASP.Sims4Flag.FlagCategory category;

			// Token: 0x04000C76 RID: 3190
			private CASP.Sims4Flag.FlagValue value;

			// Token: 0x04000C77 RID: 3191
			private uint parentVersion;
		}

		// Token: 0x0200019A RID: 410
		public class TanLevel
		{
			// Token: 0x06000F42 RID: 3906 RVA: 0x0000A9B6 File Offset: 0x00008BB6
			public void Unserialize(BinaryReader r)
			{
				this.OverlayTexture = r.ReadUInt64();
				this.BurnOverlayTexture = r.ReadUInt64();
				this.Unknown = r.ReadSingle();
				this.MakeupOpacity = r.ReadSingle();
				this.MakeupOpacity2 = r.ReadSingle();
			}

			// Token: 0x06000F43 RID: 3907 RVA: 0x0000A9F4 File Offset: 0x00008BF4
			public void Serialize(BinaryWriter w)
			{
				w.Write(this.OverlayTexture);
				w.Write(this.BurnOverlayTexture);
				w.Write(this.Unknown);
				w.Write(this.MakeupOpacity);
				w.Write(this.MakeupOpacity2);
			}

			// Token: 0x04000C78 RID: 3192
			public ulong OverlayTexture;

			// Token: 0x04000C79 RID: 3193
			public ulong BurnOverlayTexture;

			// Token: 0x04000C7A RID: 3194
			public float Unknown;

			// Token: 0x04000C7B RID: 3195
			public float MakeupOpacity;

			// Token: 0x04000C7C RID: 3196
			public float MakeupOpacity2;
		}
	}
}
