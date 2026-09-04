using System;
using System.Collections.Generic;
using System.IO;
using Sims3WorkshopSDK;

namespace Package.Sims3Files
{
	// Token: 0x02000035 RID: 53
	public class NameMap : DBPFEntry
	{
		// Token: 0x170000BD RID: 189
		// (get) Token: 0x06000270 RID: 624 RVA: 0x00004289 File Offset: 0x00002489
		// (set) Token: 0x06000271 RID: 625 RVA: 0x00004291 File Offset: 0x00002491
		public uint Version { get; private set; }

		// Token: 0x170000BE RID: 190
		// (get) Token: 0x06000272 RID: 626 RVA: 0x0000429A File Offset: 0x0000249A
		// (set) Token: 0x06000273 RID: 627 RVA: 0x000042A2 File Offset: 0x000024A2
		public List<NameMap.MapEntry> Map { get; set; }

		// Token: 0x06000274 RID: 628 RVA: 0x000042AB File Offset: 0x000024AB
		public NameMap()
		{
			this.typeId = 23462796U;
			this.Map = new List<NameMap.MapEntry>();
		}

		// Token: 0x06000275 RID: 629 RVA: 0x00003309 File Offset: 0x00001509
		public override int ReplaceReferences(ResKey from, ResKey to)
		{
			return 0;
		}

		// Token: 0x06000276 RID: 630 RVA: 0x000152B4 File Offset: 0x000134B4
		public override void UnSerialize()
		{
			this.Map.Clear();
			BinaryReader binaryReader = new BinaryReader(new MemoryStream(this.data));
			this.Version = binaryReader.ReadUInt32();
			uint num = binaryReader.ReadUInt32();
			int num2 = 0;
			while ((long)num2 < (long)((ulong)num))
			{
				try
				{
					NameMap.MapEntry mapEntry = new NameMap.MapEntry();
					mapEntry.Instance = binaryReader.ReadInt64();
					uint count = binaryReader.ReadUInt32();
					char[] value = binaryReader.ReadChars((int)count);
					mapEntry.Name = new string(value);
					if (mapEntry.Name.ToLower().StartsWith("coastal"))
					{
						Console.WriteLine(string.Concat(new string[]
						{
							mapEntry.Name,
							" ",
							mapEntry.Instance.ToString("X16"),
							" => ",
							base.ResKey.AsString()
						}));
					}
					this.Map.Add(mapEntry);
				}
				catch (Exception)
				{
				}
				num2++;
			}
			foreach (NameMap.MapEntry mapEntry2 in this.Map)
			{
				if (mapEntry2.Name.ToLower().Contains("fat"))
				{
					Console.WriteLine(mapEntry2.Name + " = 0x" + mapEntry2.Instance.ToString("X16"));
				}
			}
		}

		// Token: 0x06000277 RID: 631 RVA: 0x00015440 File Offset: 0x00013640
		public override byte[] Serialize()
		{
			MemoryStream memoryStream = new MemoryStream();
			BinaryWriter binaryWriter = new BinaryWriter(memoryStream);
			binaryWriter.Write(this.Version);
			binaryWriter.Write((uint)this.Map.Count);
			foreach (NameMap.MapEntry mapEntry in this.Map)
			{
				binaryWriter.Write(mapEntry.Instance);
				binaryWriter.Write((uint)mapEntry.Name.Length);
				for (int i = 0; i < mapEntry.Name.Length; i++)
				{
					binaryWriter.Write((byte)mapEntry.Name[i]);
				}
			}
			byte[] result = memoryStream.ToArray();
			memoryStream.Dispose();
			binaryWriter.Close();
			return result;
		}

		// Token: 0x02000105 RID: 261
		public class MapEntry
		{
			// Token: 0x17000410 RID: 1040
			// (get) Token: 0x06000CE3 RID: 3299 RVA: 0x0000910B File Offset: 0x0000730B
			// (set) Token: 0x06000CE4 RID: 3300 RVA: 0x00009113 File Offset: 0x00007313
			public string Name { get; set; }

			// Token: 0x17000411 RID: 1041
			// (get) Token: 0x06000CE5 RID: 3301 RVA: 0x0000911C File Offset: 0x0000731C
			// (set) Token: 0x06000CE6 RID: 3302 RVA: 0x00009124 File Offset: 0x00007324
			public long Instance { get; set; }
		}
	}
}
