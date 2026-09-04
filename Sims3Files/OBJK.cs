using System;
using System.Collections.Generic;
using System.IO;
using Package.SharedFiles;
using Sims3WorkshopSDK;
using Sims3WorkshopSDK.Classes;

namespace Package.Sims3Files
{
	// Token: 0x02000039 RID: 57
	public class OBJK : DBPFEntry
	{
		// Token: 0x17000102 RID: 258
		// (get) Token: 0x06000315 RID: 789 RVA: 0x000047D9 File Offset: 0x000029D9
		// (set) Token: 0x06000316 RID: 790 RVA: 0x000047E1 File Offset: 0x000029E1
		public List<OBJK.KeyEntry> Entries { get; set; }

		// Token: 0x17000103 RID: 259
		// (get) Token: 0x06000317 RID: 791 RVA: 0x000047EA File Offset: 0x000029EA
		// (set) Token: 0x06000318 RID: 792 RVA: 0x000047F2 File Offset: 0x000029F2
		public List<TGIIndex> TGIIndex { get; set; }

		// Token: 0x17000104 RID: 260
		// (get) Token: 0x06000319 RID: 793 RVA: 0x000047FB File Offset: 0x000029FB
		// (set) Token: 0x0600031A RID: 794 RVA: 0x00004803 File Offset: 0x00002A03
		public List<int> hashes { get; set; }

		// Token: 0x0600031B RID: 795 RVA: 0x0000480C File Offset: 0x00002A0C
		public OBJK()
		{
			this.typeId = 47985727U;
		}

		// Token: 0x0600031C RID: 796 RVA: 0x000172B4 File Offset: 0x000154B4
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

		// Token: 0x0600031D RID: 797 RVA: 0x00017318 File Offset: 0x00015518
		public override List<ResKey> GetAllReferences()
		{
			List<ResKey> list = new List<ResKey>();
			foreach (TGIIndex item in this.TGIIndex)
			{
				list.Add(item);
			}
			foreach (OBJK.KeyEntry keyEntry in this.Entries)
			{
				if ((keyEntry.Type == 0 || keyEntry.Type == 3) && keyEntry.KeyName.Equals("scriptClass"))
				{
					ulong hash = FNV64.GetHash(keyEntry.StringValue.Substring(keyEntry.StringValue.IndexOf(".") + 1));
					int num = (int)hash;
					int num2 = (int)(hash >> 32);
					ResKey item2 = new ResKey(121612807, 0, num2, num);
					list.Add(item2);
					ulong hash2 = FNV64.GetHash(keyEntry.StringValue);
					num = (int)hash2;
					num2 = (int)(hash2 >> 32);
					item2 = new ResKey(121612807, 0, num2, num);
					list.Add(item2);
				}
			}
			return list;
		}

		// Token: 0x0600031E RID: 798 RVA: 0x00017458 File Offset: 0x00015658
		public override void UnSerialize()
		{
			this.Entries = new List<OBJK.KeyEntry>();
			this.TGIIndex = new List<TGIIndex>();
			this.hashes = new List<int>();
			MemoryStream memoryStream = new MemoryStream(this.data);
			BinaryReader binaryReader = new BinaryReader(memoryStream);
			this.version = binaryReader.ReadUInt32();
			this.tgiOffset = binaryReader.ReadUInt32();
			this.tgiSize = binaryReader.ReadUInt32();
			byte b = binaryReader.ReadByte();
			for (int i = 0; i < (int)b; i++)
			{
				this.hashes.Add(binaryReader.ReadInt32());
			}
			byte b2 = binaryReader.ReadByte();
			for (int j = 0; j < (int)b2; j++)
			{
				OBJK.KeyEntry keyEntry = new OBJK.KeyEntry();
				keyEntry.Unserialize(binaryReader);
				this.Entries.Add(keyEntry);
			}
			this.unkByte = binaryReader.ReadByte();
			int num = binaryReader.ReadInt32();
			for (int k = 0; k < num; k++)
			{
				TGIIndex tgiindex = new TGIIndex();
				tgiindex.UnSerialize(binaryReader);
				this.TGIIndex.Add(tgiindex);
			}
			binaryReader.Close();
			memoryStream.Dispose();
		}

		// Token: 0x0600031F RID: 799 RVA: 0x00017568 File Offset: 0x00015768
		public OBJK.KeyEntry GetKeyEntry(string name)
		{
			foreach (OBJK.KeyEntry keyEntry in this.Entries)
			{
				if (keyEntry.KeyName.Equals(name))
				{
					return keyEntry;
				}
			}
			return null;
		}

		// Token: 0x06000320 RID: 800 RVA: 0x000175CC File Offset: 0x000157CC
		public override byte[] Serialize()
		{
			MemoryStream memoryStream = new MemoryStream();
			BinaryWriter binaryWriter = new BinaryWriter(memoryStream);
			binaryWriter.Write((byte)this.hashes.Count);
			foreach (int value in this.hashes)
			{
				binaryWriter.Write(value);
			}
			binaryWriter.Write((byte)this.Entries.Count);
			foreach (OBJK.KeyEntry keyEntry in this.Entries)
			{
				keyEntry.Serialize(binaryWriter);
			}
			binaryWriter.Write(this.unkByte);
			int num = (int)binaryWriter.BaseStream.Position;
			binaryWriter.Write(this.TGIIndex.Count);
			foreach (TGIIndex tgiindex in this.TGIIndex)
			{
				tgiindex.Serialize(binaryWriter);
			}
			MemoryStream memoryStream2 = new MemoryStream();
			BinaryWriter binaryWriter2 = new BinaryWriter(memoryStream2);
			binaryWriter2.Write(this.version);
			binaryWriter2.Write(num + 4);
			binaryWriter2.Write((int)(binaryWriter.BaseStream.Position - (long)num));
			binaryWriter2.Write(memoryStream.ToArray());
			byte[] result = memoryStream2.ToArray();
			binaryWriter.Close();
			memoryStream.Dispose();
			binaryWriter2.Close();
			memoryStream2.Dispose();
			return result;
		}

		// Token: 0x04000191 RID: 401
		private uint version;

		// Token: 0x04000192 RID: 402
		private uint tgiOffset;

		// Token: 0x04000193 RID: 403
		private uint tgiSize;

		// Token: 0x04000194 RID: 404
		private byte unkByte;

		// Token: 0x0200010E RID: 270
		public class KeyEntry
		{
			// Token: 0x17000424 RID: 1060
			// (get) Token: 0x06000D1F RID: 3359 RVA: 0x000092E5 File Offset: 0x000074E5
			// (set) Token: 0x06000D20 RID: 3360 RVA: 0x000092ED File Offset: 0x000074ED
			public string KeyName { get; set; }

			// Token: 0x17000425 RID: 1061
			// (get) Token: 0x06000D21 RID: 3361 RVA: 0x000092F6 File Offset: 0x000074F6
			// (set) Token: 0x06000D22 RID: 3362 RVA: 0x000092FE File Offset: 0x000074FE
			public string StringValue { get; set; }

			// Token: 0x17000426 RID: 1062
			// (get) Token: 0x06000D23 RID: 3363 RVA: 0x00009307 File Offset: 0x00007507
			// (set) Token: 0x06000D24 RID: 3364 RVA: 0x0000930F File Offset: 0x0000750F
			public int TgiIndex { get; set; }

			// Token: 0x17000427 RID: 1063
			// (get) Token: 0x06000D25 RID: 3365 RVA: 0x00009318 File Offset: 0x00007518
			// (set) Token: 0x06000D26 RID: 3366 RVA: 0x00009320 File Offset: 0x00007520
			public byte Type { get; set; }

			// Token: 0x17000428 RID: 1064
			// (get) Token: 0x06000D27 RID: 3367 RVA: 0x00009329 File Offset: 0x00007529
			// (set) Token: 0x06000D28 RID: 3368 RVA: 0x00009331 File Offset: 0x00007531
			public uint uintvalue { get; set; }

			// Token: 0x06000D29 RID: 3369 RVA: 0x0003F3D8 File Offset: 0x0003D5D8
			public void Unserialize(BinaryReader r)
			{
				int length = r.ReadInt32();
				this.KeyName = PackageUtil.ReadString(r, length);
				this.Type = r.ReadByte();
				switch (this.Type)
				{
				case 0:
				case 3:
					this.StringValue = PackageUtil.ReadString(r, r.ReadInt32());
					return;
				case 1:
				case 2:
					this.TgiIndex = r.ReadInt32();
					return;
				case 4:
					this.uintvalue = r.ReadUInt32();
					return;
				default:
					return;
				}
			}

			// Token: 0x06000D2A RID: 3370 RVA: 0x0003F454 File Offset: 0x0003D654
			public void Serialize(BinaryWriter w)
			{
				w.Write(this.KeyName.Length);
				for (int i = 0; i < this.KeyName.Length; i++)
				{
					w.Write((byte)this.KeyName[i]);
				}
				w.Write(this.Type);
				switch (this.Type)
				{
				case 0:
				case 3:
					w.Write(this.StringValue.Length);
					for (int j = 0; j < this.StringValue.Length; j++)
					{
						w.Write((byte)this.StringValue[j]);
					}
					return;
				case 1:
				case 2:
					w.Write(this.TgiIndex);
					return;
				case 4:
					w.Write(this.uintvalue);
					return;
				default:
					return;
				}
			}
		}
	}
}
