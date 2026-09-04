using System;
using System.Collections.Generic;
using System.IO;
using Package.SharedFiles;
using Sims3WorkshopSDK;

namespace Package.Sims3Files
{
	// Token: 0x02000028 RID: 40
	public class CWALL : DBPFEntry
	{
		// Token: 0x060001E8 RID: 488 RVA: 0x00003E19 File Offset: 0x00002019
		public CWALL()
		{
			this.typeId = 1365025997U;
		}

		// Token: 0x060001E9 RID: 489 RVA: 0x000038FA File Offset: 0x00001AFA
		public override int ReplaceReferences(ResKey from, ResKey to)
		{
			throw new NotImplementedException();
		}

		// Token: 0x060001EA RID: 490 RVA: 0x00013B70 File Offset: 0x00011D70
		public override void UnSerialize()
		{
			this.materials = new List<CWALL.Material>();
			this.tgiIndex = new List<TGIIndex>();
			MemoryStream memoryStream = new MemoryStream(this.data);
			BinaryReader binaryReader = new BinaryReader(memoryStream);
			binaryReader.ReadUInt32();
			uint num = binaryReader.ReadUInt32();
			binaryReader.ReadInt32();
			binaryReader.BaseStream.Position = (long)((ulong)(num + 8U));
			uint num2 = binaryReader.ReadUInt32();
			int num3 = 0;
			while ((long)num3 < (long)((ulong)num2))
			{
				TGIIndex tgiindex = new TGIIndex();
				tgiindex.UnSerialize(binaryReader);
				this.tgiIndex.Add(tgiindex);
				num3++;
			}
			memoryStream.Dispose();
			binaryReader.Close();
		}

		// Token: 0x060001EB RID: 491 RVA: 0x000038FA File Offset: 0x00001AFA
		public override byte[] Serialize()
		{
			throw new NotImplementedException();
		}

		// Token: 0x0400010B RID: 267
		private List<TGIIndex> tgiIndex;

		// Token: 0x0400010C RID: 268
		private List<CWALL.Material> materials;

		// Token: 0x02000101 RID: 257
		public class Material
		{
			// Token: 0x17000400 RID: 1024
			// (get) Token: 0x06000CBB RID: 3259 RVA: 0x00008FB8 File Offset: 0x000071B8
			public List<TGIIndex> TGIIndex
			{
				get
				{
					return this.tgiIndex;
				}
			}

			// Token: 0x06000CBC RID: 3260 RVA: 0x0003DB3C File Offset: 0x0003BD3C
			public void Unserialize(BinaryReader r)
			{
				this.tgiIndex = new List<TGIIndex>();
				if (r.ReadByte() != 1)
				{
					r.ReadUInt32();
				}
				r.ReadUInt32();
				r.ReadUInt16();
				r.ReadUInt32();
				r.ReadInt32();
				this.readMaterialBlock(r);
				uint num = r.ReadUInt32();
				int num2 = 0;
				while ((long)num2 < (long)((ulong)num))
				{
					TGIIndex tgiindex = new TGIIndex();
					tgiindex.UnSerialize(r);
					this.tgiIndex.Add(tgiindex);
					num2++;
				}
				r.ReadUInt32();
			}

			// Token: 0x06000CBD RID: 3261 RVA: 0x0003DBBC File Offset: 0x0003BDBC
			private void readMaterialBlock(BinaryReader r)
			{
				r.ReadByte();
				byte b = r.ReadByte();
				if ((b & 128) == 128)
				{
					int length = (int)(b & 63);
					PackageUtil.ReadString(r, length);
				}
				else if ((b & 64) == 64)
				{
					r.ReadByte();
				}
				byte b2 = r.ReadByte();
				if ((b2 & 128) == 128)
				{
					int length2 = (int)(b2 & 63);
					PackageUtil.ReadString(r, length2);
				}
				else if ((b2 & 64) == 64)
				{
					r.ReadByte();
				}
				uint num = r.ReadUInt32();
				int num2 = 0;
				while ((long)num2 < (long)((ulong)num))
				{
					byte b3 = r.ReadByte();
					if (b3 != 47)
					{
						if (b3 == 64)
						{
							num2--;
						}
						else
						{
							byte b4 = r.ReadByte();
							switch (b4)
							{
							case 1:
							{
								byte b5 = r.ReadByte();
								if ((b5 & 128) == 128)
								{
									int length3 = (int)(b5 & 63);
									PackageUtil.ReadString(r, length3);
								}
								else if ((b4 & 64) == 64)
								{
									r.ReadByte();
								}
								break;
							}
							case 2:
								r.ReadBytes(4);
								break;
							case 3:
								r.ReadByte();
								break;
							case 4:
								r.ReadSingle();
								break;
							case 5:
								r.ReadSingle();
								r.ReadSingle();
								break;
							case 6:
								r.ReadSingle();
								r.ReadSingle();
								r.ReadSingle();
								break;
							case 7:
								r.ReadByte();
								break;
							}
						}
					}
					else
					{
						r.ReadByte();
						r.ReadUInt32();
					}
					num2++;
				}
				uint num3 = r.ReadUInt32();
				num2 = 0;
				while ((long)num2 < (long)((ulong)num3))
				{
					this.readMaterialBlock(r);
					num2++;
				}
			}

			// Token: 0x04000612 RID: 1554
			private List<TGIIndex> tgiIndex;
		}
	}
}
