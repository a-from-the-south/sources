using System;
using System.Collections.Generic;
using System.IO;
using Sims3WorkshopSDK;

namespace Package.Sims3Files
{
	// Token: 0x0200001B RID: 27
	public class COLL : DBPFEntry
	{
		// Token: 0x060001A9 RID: 425 RVA: 0x000133B0 File Offset: 0x000115B0
		public COLL()
		{
			this.typeId = 201803117U;
			this.Version = 1;
			this.Flags = 1;
			this.IconKey = new ResKey();
			this.items = new List<KeyValuePair<int, ResKey>>();
			this.CollectionName = "m\0i\0c\0k\0e\0s\0";
		}

		// Token: 0x060001AA RID: 426 RVA: 0x00003309 File Offset: 0x00001509
		public override int ReplaceReferences(ResKey from, ResKey to)
		{
			return 0;
		}

		// Token: 0x060001AB RID: 427 RVA: 0x00013400 File Offset: 0x00011600
		public override void UnSerialize()
		{
			this.items = new List<KeyValuePair<int, ResKey>>();
			BinaryReader binaryReader = new BinaryReader(new MemoryStream(this.data));
			this.Version = binaryReader.ReadInt32();
			this.CollectionName = PackageUtil.ReadString(binaryReader, binaryReader.ReadInt32() * 2);
			int num = 0;
			try
			{
				this.Flags = binaryReader.ReadInt32();
				int num2 = binaryReader.ReadInt32();
				int num3 = binaryReader.ReadInt32();
				int num4 = binaryReader.ReadInt32();
				int num5 = binaryReader.ReadInt32();
				this.IconKey = new ResKey((uint)num2, num3, num5, num4);
				int num6 = binaryReader.ReadInt32();
				for (int i = 0; i < num6; i++)
				{
					uint num7 = (uint)binaryReader.ReadInt32();
					int num8 = binaryReader.ReadInt32();
					int num9 = binaryReader.ReadInt32();
					int num10 = binaryReader.ReadInt32();
					ResKey value = new ResKey(num7, num8, num10, num9);
					int key = binaryReader.ReadInt32();
					this.items.Add(new KeyValuePair<int, ResKey>(key, value));
					num++;
				}
			}
			catch (Exception)
			{
			}
		}

		// Token: 0x060001AC RID: 428 RVA: 0x00013500 File Offset: 0x00011700
		public override byte[] Serialize()
		{
			MemoryStream memoryStream = new MemoryStream();
			BinaryWriter binaryWriter = new BinaryWriter(memoryStream);
			binaryWriter.Write(this.Version);
			binaryWriter.Write((uint)(this.CollectionName.Length / 2));
			for (int i = 0; i < this.CollectionName.Length; i++)
			{
				binaryWriter.Write((byte)this.CollectionName[i]);
			}
			binaryWriter.Write(this.Flags);
			binaryWriter.Write(this.IconKey.TypeId);
			binaryWriter.Write((uint)this.IconKey.GroupId);
			binaryWriter.Write((uint)this.IconKey.SecondInstanceId);
			binaryWriter.Write((uint)this.IconKey.InstanceId);
			binaryWriter.Write(this.items.Count);
			foreach (KeyValuePair<int, ResKey> keyValuePair in this.items)
			{
				binaryWriter.Write(keyValuePair.Value.TypeId);
				binaryWriter.Write((uint)keyValuePair.Value.GroupId);
				binaryWriter.Write((uint)keyValuePair.Value.SecondInstanceId);
				binaryWriter.Write((uint)keyValuePair.Value.InstanceId);
				binaryWriter.Write((uint)keyValuePair.Key);
			}
			byte[] result = memoryStream.ToArray();
			binaryWriter.Close();
			memoryStream.Dispose();
			return result;
		}

		// Token: 0x040000A9 RID: 169
		public int Version;

		// Token: 0x040000AA RID: 170
		public string CollectionName;

		// Token: 0x040000AB RID: 171
		public ResKey IconKey;

		// Token: 0x040000AC RID: 172
		public int Flags;

		// Token: 0x040000AD RID: 173
		public List<KeyValuePair<int, ResKey>> items;
	}
}
