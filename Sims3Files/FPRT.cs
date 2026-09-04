using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Package.SharedFiles;
using Sims3WorkshopSDK;

namespace Package.Sims3Files
{
	// Token: 0x0200002D RID: 45
	public class FPRT : DBPFEntry
	{
		// Token: 0x170000AB RID: 171
		// (get) Token: 0x0600023B RID: 571 RVA: 0x00004082 File Offset: 0x00002282
		// (set) Token: 0x0600023C RID: 572 RVA: 0x0000408A File Offset: 0x0000228A
		public uint Version { get; set; }

		// Token: 0x170000AC RID: 172
		// (get) Token: 0x0600023D RID: 573 RVA: 0x00004093 File Offset: 0x00002293
		// (set) Token: 0x0600023E RID: 574 RVA: 0x0000409B File Offset: 0x0000229B
		public string Name { get; set; }

		// Token: 0x170000AD RID: 173
		// (get) Token: 0x0600023F RID: 575 RVA: 0x000040A4 File Offset: 0x000022A4
		// (set) Token: 0x06000240 RID: 576 RVA: 0x000040AC File Offset: 0x000022AC
		public uint unkDWord { get; set; }

		// Token: 0x170000AE RID: 174
		// (get) Token: 0x06000241 RID: 577 RVA: 0x000040B5 File Offset: 0x000022B5
		// (set) Token: 0x06000242 RID: 578 RVA: 0x000040BD File Offset: 0x000022BD
		public DBPFType blendTypeId { get; set; }

		// Token: 0x170000AF RID: 175
		// (get) Token: 0x06000243 RID: 579 RVA: 0x000040C6 File Offset: 0x000022C6
		// (set) Token: 0x06000244 RID: 580 RVA: 0x000040CE File Offset: 0x000022CE
		public int blendGroupId { get; set; }

		// Token: 0x170000B0 RID: 176
		// (get) Token: 0x06000245 RID: 581 RVA: 0x000040D7 File Offset: 0x000022D7
		// (set) Token: 0x06000246 RID: 582 RVA: 0x000040DF File Offset: 0x000022DF
		public int blendSecondInstanceId { get; set; }

		// Token: 0x170000B1 RID: 177
		// (get) Token: 0x06000247 RID: 583 RVA: 0x000040E8 File Offset: 0x000022E8
		// (set) Token: 0x06000248 RID: 584 RVA: 0x000040F0 File Offset: 0x000022F0
		public int blendInstanceId { get; set; }

		// Token: 0x170000B2 RID: 178
		// (get) Token: 0x06000249 RID: 585 RVA: 0x000040F9 File Offset: 0x000022F9
		// (set) Token: 0x0600024A RID: 586 RVA: 0x00004101 File Offset: 0x00002301
		public List<FPRT.FPRTEntry> FPRTEntries { get; set; }

		// Token: 0x170000B3 RID: 179
		// (get) Token: 0x0600024B RID: 587 RVA: 0x0000410A File Offset: 0x0000230A
		// (set) Token: 0x0600024C RID: 588 RVA: 0x00004112 File Offset: 0x00002312
		public List<TGIIndex> TGIIndex { get; set; }

		// Token: 0x170000B4 RID: 180
		// (get) Token: 0x0600024D RID: 589 RVA: 0x00014658 File Offset: 0x00012858
		public string BlendResKey
		{
			get
			{
				return string.Concat(new string[]
				{
					"key:",
					this.blendTypeId.ToString("X8"),
					":",
					this.blendGroupId.ToString("X8"),
					":",
					this.blendInstanceId.ToString("X8"),
					this.blendSecondInstanceId.ToString("X8")
				});
			}
		}

		// Token: 0x0600024E RID: 590 RVA: 0x0000411B File Offset: 0x0000231B
		public FPRT(DBPFType type)
		{
			this.typeId = type;
			this.FPRTEntries = new List<FPRT.FPRTEntry>();
			this.TGIIndex = new List<TGIIndex>();
		}

		// Token: 0x170000B5 RID: 181
		// (get) Token: 0x0600024F RID: 591 RVA: 0x00004140 File Offset: 0x00002340
		public string BGEO_Reskey
		{
			get
			{
				return new ResKey(this.blendTypeId, this.blendGroupId, this.blendInstanceId, this.blendSecondInstanceId).AsString();
			}
		}

		// Token: 0x06000250 RID: 592 RVA: 0x000146E0 File Offset: 0x000128E0
		public override int ReplaceReferences(ResKey from, ResKey to)
		{
			int num = 0;
			foreach (TGIIndex tgiindex in this.TGIIndex)
			{
				if (tgiindex.Equals(from))
				{
					tgiindex.SetFromResKey(to);
					num++;
				}
			}
			return num;
		}

		// Token: 0x06000251 RID: 593 RVA: 0x00014744 File Offset: 0x00012944
		public override void UnSerialize()
		{
			this.FPRTEntries.Clear();
			this.TGIIndex.Clear();
			MemoryStream memoryStream = new MemoryStream(this.data);
			BinaryReader binaryReader = new BinaryReader(memoryStream);
			this.Version = binaryReader.ReadUInt32();
			this.tgiOffset = binaryReader.ReadUInt32();
			this.keyTableSize = binaryReader.ReadInt32();
			UnicodeEncoding unicodeEncoding = new UnicodeEncoding();
			byte[] array = new byte[(int)binaryReader.ReadByte()];
			for (int i = 0; i < array.Length; i += 2)
			{
				array[i + 1] = binaryReader.ReadByte();
				array[i] = binaryReader.ReadByte();
			}
			this.Name = unicodeEncoding.GetString(array);
			this.unkDWord = binaryReader.ReadUInt32();
			if (this.Version > 7U)
			{
				this.blendTypeId = binaryReader.ReadUInt32();
				this.blendGroupId = binaryReader.ReadInt32();
				this.blendSecondInstanceId = binaryReader.ReadInt32();
				this.blendInstanceId = binaryReader.ReadInt32();
			}
			uint num = binaryReader.ReadUInt32();
			int num2 = 0;
			while ((long)num2 < (long)((ulong)num))
			{
				FPRT.FPRTEntry fprtentry = new FPRT.FPRTEntry();
				fprtentry.UnSerilize(binaryReader);
				this.FPRTEntries.Add(fprtentry);
				num2++;
			}
			uint num3 = binaryReader.ReadUInt32();
			int num4 = 0;
			while ((long)num4 < (long)((ulong)num3))
			{
				TGIIndex tgiindex = new TGIIndex();
				tgiindex.UnSerialize(binaryReader);
				this.TGIIndex.Add(tgiindex);
				num4++;
			}
			memoryStream.Dispose();
			binaryReader.Close();
		}

		// Token: 0x06000252 RID: 594 RVA: 0x000148A4 File Offset: 0x00012AA4
		public override byte[] Serialize()
		{
			MemoryStream memoryStream = new MemoryStream();
			BinaryWriter binaryWriter = new BinaryWriter(memoryStream);
			MemoryStream memoryStream2 = new MemoryStream();
			BinaryWriter binaryWriter2 = new BinaryWriter(memoryStream2);
			binaryWriter2.Write((byte)(this.Name.Length * 2));
			byte[] bytes = new UnicodeEncoding().GetBytes(this.Name);
			for (int i = 0; i < bytes.Length; i += 2)
			{
				binaryWriter2.Write(bytes[i + 1]);
				binaryWriter2.Write(bytes[i]);
			}
			binaryWriter2.Write(this.unkDWord);
			if (this.Version > 7U)
			{
				binaryWriter2.Write(this.blendTypeId);
				binaryWriter2.Write(this.blendGroupId);
				binaryWriter2.Write(this.blendSecondInstanceId);
				binaryWriter2.Write(this.blendInstanceId);
			}
			binaryWriter2.Write(this.FPRTEntries.Count);
			foreach (FPRT.FPRTEntry fprtentry in this.FPRTEntries)
			{
				fprtentry.Serialize(binaryWriter2);
			}
			binaryWriter2.Write(this.TGIIndex.Count);
			foreach (TGIIndex tgiindex in this.TGIIndex)
			{
				tgiindex.Serialize(binaryWriter2);
			}
			binaryWriter.Write(this.Version);
			binaryWriter.Write((int)this.tgiOffset);
			binaryWriter.Write(this.keyTableSize);
			binaryWriter.Write(memoryStream2.ToArray());
			byte[] result = memoryStream.ToArray();
			memoryStream2.Dispose();
			binaryWriter2.Close();
			memoryStream.Dispose();
			binaryWriter.Close();
			return result;
		}

		// Token: 0x0400013E RID: 318
		private uint tgiOffset;

		// Token: 0x0400013F RID: 319
		private int keyTableSize;

		// Token: 0x02000102 RID: 258
		public enum FaceRegion : uint
		{
			// Token: 0x04000614 RID: 1556
			Body = 1024U,
			// Token: 0x04000615 RID: 1557
			Brow = 256U,
			// Token: 0x04000616 RID: 1558
			Ears = 16U,
			// Token: 0x04000617 RID: 1559
			Eyelashes = 2048U,
			// Token: 0x04000618 RID: 1560
			Eyes = 1U,
			// Token: 0x04000619 RID: 1561
			Face = 64U,
			// Token: 0x0400061A RID: 1562
			Head = 128U,
			// Token: 0x0400061B RID: 1563
			Jaw = 512U,
			// Token: 0x0400061C RID: 1564
			Mouth = 4U,
			// Token: 0x0400061D RID: 1565
			Nose = 2U,
			// Token: 0x0400061E RID: 1566
			TranslateEyes = 32U,
			// Token: 0x0400061F RID: 1567
			TranslateMouth = 8U
		}

		// Token: 0x02000103 RID: 259
		public class FPRTEntry
		{
			// Token: 0x17000401 RID: 1025
			// (get) Token: 0x06000CBF RID: 3263 RVA: 0x00008FC0 File Offset: 0x000071C0
			// (set) Token: 0x06000CC0 RID: 3264 RVA: 0x00008FC8 File Offset: 0x000071C8
			public FPRT.FaceRegion FacialRegion { get; set; }

			// Token: 0x17000402 RID: 1026
			// (get) Token: 0x06000CC1 RID: 3265 RVA: 0x00008FD1 File Offset: 0x000071D1
			// (set) Token: 0x06000CC2 RID: 3266 RVA: 0x00008FD9 File Offset: 0x000071D9
			public uint mayHaveBone { get; set; }

			// Token: 0x17000403 RID: 1027
			// (get) Token: 0x06000CC3 RID: 3267 RVA: 0x00008FE2 File Offset: 0x000071E2
			// (set) Token: 0x06000CC4 RID: 3268 RVA: 0x00008FEA File Offset: 0x000071EA
			public uint useGeom { get; set; }

			// Token: 0x17000404 RID: 1028
			// (get) Token: 0x06000CC5 RID: 3269 RVA: 0x00008FF3 File Offset: 0x000071F3
			// (set) Token: 0x06000CC6 RID: 3270 RVA: 0x00008FFB File Offset: 0x000071FB
			public List<byte[]> AgeGenderFlags { get; set; }

			// Token: 0x17000405 RID: 1029
			// (get) Token: 0x06000CC7 RID: 3271 RVA: 0x00009004 File Offset: 0x00007204
			// (set) Token: 0x06000CC8 RID: 3272 RVA: 0x0000900C File Offset: 0x0000720C
			public List<float> Amount { get; set; }

			// Token: 0x17000406 RID: 1030
			// (get) Token: 0x06000CC9 RID: 3273 RVA: 0x00009015 File Offset: 0x00007215
			// (set) Token: 0x06000CCA RID: 3274 RVA: 0x0000901D File Offset: 0x0000721D
			public List<uint> GeometryIndex { get; set; }

			// Token: 0x17000407 RID: 1031
			// (get) Token: 0x06000CCB RID: 3275 RVA: 0x00009026 File Offset: 0x00007226
			// (set) Token: 0x06000CCC RID: 3276 RVA: 0x0000902E File Offset: 0x0000722E
			public uint GeometryIndex2 { get; set; }

			// Token: 0x17000408 RID: 1032
			// (get) Token: 0x06000CCD RID: 3277 RVA: 0x00009037 File Offset: 0x00007237
			// (set) Token: 0x06000CCE RID: 3278 RVA: 0x0000903F File Offset: 0x0000723F
			public uint HasBoneEntry { get; set; }

			// Token: 0x17000409 RID: 1033
			// (get) Token: 0x06000CCF RID: 3279 RVA: 0x00009048 File Offset: 0x00007248
			// (set) Token: 0x06000CD0 RID: 3280 RVA: 0x00009050 File Offset: 0x00007250
			public byte[] AgeGenderFlags2 { get; set; }

			// Token: 0x1700040A RID: 1034
			// (get) Token: 0x06000CD1 RID: 3281 RVA: 0x00009059 File Offset: 0x00007259
			// (set) Token: 0x06000CD2 RID: 3282 RVA: 0x00009061 File Offset: 0x00007261
			public float Amount2 { get; set; }

			// Token: 0x1700040B RID: 1035
			// (get) Token: 0x06000CD3 RID: 3283 RVA: 0x0000906A File Offset: 0x0000726A
			// (set) Token: 0x06000CD4 RID: 3284 RVA: 0x00009072 File Offset: 0x00007272
			public uint BoneIndex { get; set; }

			// Token: 0x1700040C RID: 1036
			// (get) Token: 0x06000CD5 RID: 3285 RVA: 0x0000907B File Offset: 0x0000727B
			// (set) Token: 0x06000CD6 RID: 3286 RVA: 0x00009083 File Offset: 0x00007283
			public uint useBone { get; set; }

			// Token: 0x06000CD7 RID: 3287 RVA: 0x0003DD5C File Offset: 0x0003BF5C
			public void UnSerilize(BinaryReader r)
			{
				this.AgeGenderFlags = new List<byte[]>();
				this.Amount = new List<float>();
				this.GeometryIndex = new List<uint>();
				this.FacialRegion = (FPRT.FaceRegion)r.ReadUInt32();
				this.mayHaveBone = r.ReadUInt32();
				if (this.mayHaveBone == 0U)
				{
					this.useGeom = r.ReadUInt32();
				}
				if (this.useGeom != 0U || this.mayHaveBone != 0U)
				{
					if (this.useGeom > 0U)
					{
						int num = 0;
						while ((long)num < (long)((ulong)this.useGeom))
						{
							this.AgeGenderFlags.Add(r.ReadBytes(4));
							this.Amount.Add(r.ReadSingle());
							this.GeometryIndex.Add(r.ReadUInt32());
							num++;
						}
					}
					else
					{
						this.AgeGenderFlags.Add(r.ReadBytes(4));
						this.Amount.Add(r.ReadSingle());
						this.GeometryIndex.Add(r.ReadUInt32());
					}
				}
				if (this.mayHaveBone != 0U)
				{
					this.useBone = r.ReadUInt32();
					if (this.useBone != 0U)
					{
						this.AgeGenderFlags2 = r.ReadBytes(4);
						this.Amount2 = r.ReadSingle();
						this.GeometryIndex2 = r.ReadUInt32();
					}
				}
			}

			// Token: 0x06000CD8 RID: 3288 RVA: 0x0003DE90 File Offset: 0x0003C090
			public void Serialize(BinaryWriter w)
			{
				w.Write((uint)this.FacialRegion);
				w.Write(this.mayHaveBone);
				if (this.mayHaveBone == 0U)
				{
					w.Write(this.useGeom);
				}
				if (this.useGeom != 0U || this.mayHaveBone != 0U)
				{
					if (this.useGeom > 0U)
					{
						int num = 0;
						while ((long)num < (long)((ulong)this.useGeom))
						{
							w.Write(this.AgeGenderFlags[num]);
							w.Write(this.Amount[num]);
							w.Write(this.GeometryIndex[num]);
							num++;
						}
					}
					else
					{
						w.Write(this.AgeGenderFlags[0]);
						w.Write(this.Amount[0]);
						w.Write(this.GeometryIndex[0]);
					}
				}
				if (this.mayHaveBone != 0U)
				{
					w.Write(this.useBone);
					if (this.useBone != 0U)
					{
						w.Write(this.AgeGenderFlags2);
						w.Write(this.Amount2);
						w.Write(this.GeometryIndex2);
					}
				}
			}
		}
	}
}
