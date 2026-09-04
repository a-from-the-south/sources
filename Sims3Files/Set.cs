using System;
using System.Collections.Generic;
using System.IO;
using Package.SharedFiles;
using Sims3WorkshopSDK;

namespace Package.Sims3Files
{
	// Token: 0x02000026 RID: 38
	public class Set : DBPFEntry
	{
		// Token: 0x17000080 RID: 128
		// (get) Token: 0x060001CF RID: 463 RVA: 0x00003D64 File Offset: 0x00001F64
		public List<IGTIndex> Packages
		{
			get
			{
				return this._packages;
			}
		}

		// Token: 0x060001D0 RID: 464 RVA: 0x00003D6C File Offset: 0x00001F6C
		public Set()
		{
			this.typeId = 137167721U;
			this._packages = new List<IGTIndex>();
		}

		// Token: 0x060001D1 RID: 465 RVA: 0x00003309 File Offset: 0x00001509
		public override int ReplaceReferences(ResKey from, ResKey to)
		{
			return 0;
		}

		// Token: 0x060001D2 RID: 466 RVA: 0x00013948 File Offset: 0x00011B48
		public override void UnSerialize()
		{
			MemoryStream memoryStream = new MemoryStream(this.data);
			BinaryReader binaryReader = new BinaryReader(memoryStream);
			this._unkn1 = binaryReader.ReadByte();
			this._unkn2 = binaryReader.ReadByte();
			int num = binaryReader.ReadInt32();
			this._packages = new List<IGTIndex>(num);
			for (int i = 0; i < num; i++)
			{
				IGTIndex igtindex = new IGTIndex();
				igtindex.UnSerialize(binaryReader);
				this._packages.Add(igtindex);
			}
			memoryStream.Dispose();
			binaryReader.Close();
		}

		// Token: 0x060001D3 RID: 467 RVA: 0x000139C8 File Offset: 0x00011BC8
		public override byte[] Serialize()
		{
			MemoryStream memoryStream = new MemoryStream();
			BinaryWriter binaryWriter = new BinaryWriter(memoryStream);
			binaryWriter.Write(this._unkn1);
			binaryWriter.Write(this._unkn2);
			binaryWriter.Write(this._packages.Count);
			foreach (IGTIndex igtindex in this.Packages)
			{
				igtindex.Serialize(binaryWriter);
			}
			byte[] array = new byte[binaryWriter.BaseStream.Length];
			binaryWriter.BaseStream.Position = 0L;
			binaryWriter.BaseStream.Read(array, 0, (int)binaryWriter.BaseStream.Length);
			binaryWriter.Close();
			memoryStream.Dispose();
			return array;
		}

		// Token: 0x04000100 RID: 256
		private byte _unkn1 = 1;

		// Token: 0x04000101 RID: 257
		private byte _unkn2;

		// Token: 0x04000102 RID: 258
		private List<IGTIndex> _packages;
	}
}
