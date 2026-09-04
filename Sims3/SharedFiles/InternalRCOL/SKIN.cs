using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using Sims3WorkshopSDK;

namespace Package.SharedFiles.InternalRCOL
{
	// Token: 0x020000B8 RID: 184
	public class SKIN : RCOLItem, ICloneable
	{
		// Token: 0x17000321 RID: 801
		// (get) Token: 0x06000960 RID: 2400 RVA: 0x000075A2 File Offset: 0x000057A2
		// (set) Token: 0x06000961 RID: 2401 RVA: 0x000075AA File Offset: 0x000057AA
		[TypeConverter(typeof(IntTypeConverter))]
		public uint Type { get; set; }

		// Token: 0x17000322 RID: 802
		// (get) Token: 0x06000962 RID: 2402 RVA: 0x000075B3 File Offset: 0x000057B3
		// (set) Token: 0x06000963 RID: 2403 RVA: 0x000075BB File Offset: 0x000057BB
		[TypeConverter(typeof(IntTypeConverter))]
		public uint Version { get; set; }

		// Token: 0x17000323 RID: 803
		// (get) Token: 0x06000964 RID: 2404 RVA: 0x000075C4 File Offset: 0x000057C4
		// (set) Token: 0x06000965 RID: 2405 RVA: 0x000075CC File Offset: 0x000057CC
		[TypeConverter(typeof(IntTypeConverter))]
		public uint Count { get; set; }

		// Token: 0x17000324 RID: 804
		// (get) Token: 0x06000966 RID: 2406 RVA: 0x000075D5 File Offset: 0x000057D5
		// (set) Token: 0x06000967 RID: 2407 RVA: 0x000075DD File Offset: 0x000057DD
		public List<SKIN.SKINEntry> Entries { get; set; }

		// Token: 0x17000325 RID: 805
		// (get) Token: 0x06000968 RID: 2408 RVA: 0x000075E6 File Offset: 0x000057E6
		// (set) Token: 0x06000969 RID: 2409 RVA: 0x000075EE File Offset: 0x000057EE
		[Browsable(false)]
		public Hashtable HashedEntries { get; set; }

		// Token: 0x0600096A RID: 2410 RVA: 0x0002E760 File Offset: 0x0002C960
		public override void UnSerialize(BinaryReader reader)
		{
			this.Entries = new List<SKIN.SKINEntry>();
			this.HashedEntries = new Hashtable();
			this.data = reader.ReadBytes((int)reader.BaseStream.Length);
			reader.BaseStream.Position = 0L;
			this.Type = reader.ReadUInt32();
			this.Version = reader.ReadUInt32();
			this.Count = reader.ReadUInt32();
			int num = 0;
			while ((long)num < (long)((ulong)this.Count))
			{
				SKIN.SKINEntry skinentry = new SKIN.SKINEntry();
				skinentry.BoneHash = reader.ReadUInt32();
				this.Entries.Add(skinentry);
				num++;
			}
			foreach (SKIN.SKINEntry skinentry2 in this.Entries)
			{
				skinentry2.UnSerialize(reader);
				this.HashedEntries.Add(skinentry2.BoneHash, skinentry2);
			}
		}

		// Token: 0x0600096B RID: 2411 RVA: 0x0002E864 File Offset: 0x0002CA64
		public override void Serialize(BinaryWriter w)
		{
			w.Write(this.Type);
			w.Write(this.Version);
			w.Write(this.Entries.Count);
			foreach (SKIN.SKINEntry skinentry in this.Entries)
			{
				w.Write(skinentry.BoneHash);
			}
			foreach (SKIN.SKINEntry skinentry2 in this.Entries)
			{
				skinentry2.Serialize(w);
			}
		}

		// Token: 0x0600096C RID: 2412 RVA: 0x00003309 File Offset: 0x00001509
		public override int ReplaceReferences(ResKey from, ResKey to)
		{
			return 0;
		}

		// Token: 0x0600096D RID: 2413 RVA: 0x0002E928 File Offset: 0x0002CB28
		public object Clone()
		{
			SKIN skin = new SKIN();
			MemoryStream memoryStream = new MemoryStream();
			BinaryWriter binaryWriter = new BinaryWriter(memoryStream);
			this.Serialize(binaryWriter);
			MemoryStream memoryStream2 = new MemoryStream(memoryStream.ToArray());
			BinaryReader binaryReader = new BinaryReader(memoryStream2);
			skin.UnSerialize(binaryReader);
			memoryStream.Dispose();
			memoryStream2.Dispose();
			binaryWriter.Close();
			binaryReader.Close();
			return skin;
		}

		// Token: 0x0600096E RID: 2414 RVA: 0x000075F7 File Offset: 0x000057F7
		public override string ToString()
		{
			return "SKIN";
		}

		// Token: 0x04000495 RID: 1173
		[Browsable(false)]
		private byte[] data;

		// Token: 0x020001A9 RID: 425
		public class SKINEntry
		{
			// Token: 0x170004F1 RID: 1265
			// (get) Token: 0x06000FD3 RID: 4051 RVA: 0x0000AF5F File Offset: 0x0000915F
			// (set) Token: 0x06000FD4 RID: 4052 RVA: 0x0000AF67 File Offset: 0x00009167
			[TypeConverter(typeof(IntTypeConverter))]
			public uint BoneHash { get; set; }

			// Token: 0x170004F2 RID: 1266
			// (get) Token: 0x06000FD5 RID: 4053 RVA: 0x0000AF70 File Offset: 0x00009170
			// (set) Token: 0x06000FD6 RID: 4054 RVA: 0x0000AF78 File Offset: 0x00009178
			public float[] BoneMatrix { get; set; }

			// Token: 0x170004F3 RID: 1267
			// (get) Token: 0x06000FD7 RID: 4055 RVA: 0x0000AF81 File Offset: 0x00009181
			// (set) Token: 0x06000FD8 RID: 4056 RVA: 0x0000AF89 File Offset: 0x00009189
			[Browsable(false)]
			public object Tag { get; set; }

			// Token: 0x06000FD9 RID: 4057 RVA: 0x00043F38 File Offset: 0x00042138
			public void Serialize(BinaryWriter w)
			{
				foreach (float value in this.BoneMatrix)
				{
					w.Write(value);
				}
			}

			// Token: 0x06000FDA RID: 4058 RVA: 0x00043F68 File Offset: 0x00042168
			public void UnSerialize(BinaryReader r)
			{
				this.BoneMatrix = new float[12];
				for (int i = 0; i < this.BoneMatrix.Length; i++)
				{
					this.BoneMatrix[i] = r.ReadSingle();
				}
			}

			// Token: 0x06000FDB RID: 4059 RVA: 0x00043FA4 File Offset: 0x000421A4
			public SKIN.SKINEntry Clone()
			{
				SKIN.SKINEntry skinentry = new SKIN.SKINEntry();
				skinentry.BoneMatrix = new float[12];
				skinentry.BoneHash = this.BoneHash;
				for (int i = 0; i < this.BoneMatrix.Length; i++)
				{
					skinentry.BoneMatrix[i] = this.BoneMatrix[i];
				}
				return skinentry;
			}

			// Token: 0x06000FDC RID: 4060 RVA: 0x00043FF4 File Offset: 0x000421F4
			public override string ToString()
			{
				return "SKIN Entry 0x" + this.BoneHash.ToString("X8");
			}
		}
	}
}
