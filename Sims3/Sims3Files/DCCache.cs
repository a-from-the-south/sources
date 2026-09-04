using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using Package.Helper;
using Sims3WorkshopSDK;

namespace Package.Sims3Files
{
	// Token: 0x02000037 RID: 55
	public class DCCache : DBPFEntry
	{
		// Token: 0x06000308 RID: 776 RVA: 0x0000476D File Offset: 0x0000296D
		public DCCache()
		{
			this.items = new List<DCCache.DCCacheItem>();
			this.typeId = 1987244229U;
		}

		// Token: 0x06000309 RID: 777 RVA: 0x000038FA File Offset: 0x00001AFA
		public override int ReplaceReferences(ResKey from, ResKey to)
		{
			throw new NotImplementedException();
		}

		// Token: 0x0600030A RID: 778 RVA: 0x00016824 File Offset: 0x00014A24
		public override void UnSerialize()
		{
			this.items.Clear();
			MemoryStream memoryStream = new MemoryStream(this.data);
			BinaryReader binaryReader = new BinaryReader(memoryStream);
			uint num = NumberHelpers.Swap(binaryReader.ReadUInt32());
			int num2 = 0;
			while ((long)num2 < (long)((ulong)num))
			{
				DCCache.DCCacheItem dccacheItem = new DCCache.DCCacheItem("");
				dccacheItem.UnSerialize(binaryReader);
				this.items.Add(dccacheItem);
				num2++;
			}
			binaryReader.Close();
			memoryStream.Dispose();
		}

		// Token: 0x17000101 RID: 257
		// (get) Token: 0x0600030B RID: 779 RVA: 0x0000478B File Offset: 0x0000298B
		public List<DCCache.DCCacheItem> Items
		{
			get
			{
				return this.items;
			}
		}

		// Token: 0x0600030C RID: 780 RVA: 0x00016898 File Offset: 0x00014A98
		private bool alreadyInstalled(string packageId)
		{
			using (List<DCCache.DCCacheItem>.Enumerator enumerator = this.items.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					if (enumerator.Current.PackageID.ToLower().Equals(packageId.ToLower()))
					{
						return true;
					}
				}
			}
			return false;
		}

		// Token: 0x0600030D RID: 781 RVA: 0x00016904 File Offset: 0x00014B04
		public int AddPackage(PackageDescriptor packageDescription)
		{
			int result = -2;
			XmlDocument xmlDocument = packageDescription.Documents[0];
			XmlElement xmlElement = xmlDocument.GetElementsByTagName("manifest")[0] as XmlElement;
			if (xmlElement.GetAttribute("packagetype") == "pattern")
			{
				string name = "noname";
				foreach (object obj in (xmlElement.GetElementsByTagName("localizednames")[0] as XmlElement).GetElementsByTagName("localizedname"))
				{
					XmlElement xmlElement2 = (XmlElement)obj;
					if (xmlElement2.GetAttribute("language").ToLower().Equals("en-us"))
					{
						name = xmlElement2.FirstChild.Value;
					}
				}
				DCCache.DCCacheItem dccacheItem = new DCCache.DCCacheItem(name);
				string innerText = xmlElement.GetElementsByTagName("packageid").Item(0).InnerText;
				if (this.alreadyInstalled(innerText))
				{
					return -1;
				}
				dccacheItem.SetPackageId(innerText);
				foreach (object obj2 in (xmlDocument.GetElementsByTagName("keylist")[0] as XmlElement).GetElementsByTagName("reskey"))
				{
					XmlElement xmlElement3 = (XmlElement)obj2;
					string text = "key:" + xmlElement3.InnerText.Substring(2);
					DBPFEntry entry = (packageDescription.Package as DBPF).GetEntry(new ResKey(text));
					if (entry == null)
					{
						entry = (base.Package as DBPF).GetEntry(new ResKey(text));
					}
					if (entry == null)
					{
						return -3;
					}
					(base.Package as DBPF).AddEntry(entry);
					string text2 = text.Substring(4).Replace(":", "");
					string value = text2.Substring(0, 8);
					string value2 = text2.Substring(8, 8);
					string value3 = text2.Substring(16, 8);
					string value4 = text2.Substring(24, 8);
					dccacheItem.AddFile(Convert.ToUInt32(value, 16), Convert.ToUInt32(value2, 16), Convert.ToUInt32(value3, 16), Convert.ToUInt32(value4, 16));
				}
				foreach (object obj3 in (xmlDocument.GetElementsByTagName("dependencylist")[0] as XmlElement).GetElementsByTagName("packageid"))
				{
					XmlElement xmlElement4 = (XmlElement)obj3;
					dccacheItem.AddDep(xmlElement4.InnerText);
				}
				string text3 = xmlElement.GetElementsByTagName("thumbnail").Item(0).InnerText.Replace(":", "");
				string value5 = text3.Substring(0, 8);
				string value6 = text3.Substring(8, 8);
				string value7 = text3.Substring(16, 8);
				string value8 = text3.Substring(24, 8);
				dccacheItem.SetThumb(Convert.ToUInt32(value5, 16), Convert.ToUInt32(value6, 16), Convert.ToUInt32(value7, 16), Convert.ToUInt32(value8, 16));
				this.items.Add(dccacheItem);
				return 0;
			}
			return result;
		}

		// Token: 0x0600030E RID: 782 RVA: 0x00016C68 File Offset: 0x00014E68
		public override byte[] Serialize()
		{
			MemoryStream memoryStream = new MemoryStream();
			BinaryWriter binaryWriter = new BinaryWriter(memoryStream);
			binaryWriter.Write(NumberHelpers.Swap(this.items.Count));
			foreach (DCCache.DCCacheItem dccacheItem in this.items)
			{
				dccacheItem.Serialize(binaryWriter);
			}
			memoryStream.Position = 0L;
			byte[] array = new byte[memoryStream.Length];
			memoryStream.Read(array, 0, array.Length);
			binaryWriter.Close();
			memoryStream.Dispose();
			return array;
		}

		// Token: 0x0400018D RID: 397
		public List<DCCache.DCCacheItem> items;

		// Token: 0x02000109 RID: 265
		public class DCCacheItem
		{
			// Token: 0x06000D08 RID: 3336 RVA: 0x0003EB70 File Offset: 0x0003CD70
			public DCCacheItem(string name)
			{
				this.typeId = 8U;
				this.packageName = name;
				this.internalFiles = new List<DCCache.DCCacheInternalFile>();
				this.deps = new List<DCCache.DCCacheDep>();
				this.files = new List<DCCache.DCCacheFile>();
				this.unkByte = 1;
				this.unknownByte10 = new byte[]
				{
					3,
					65,
					172,
					201,
					0,
					0,
					0,
					0,
					0,
					0
				};
			}

			// Token: 0x1700041D RID: 1053
			// (get) Token: 0x06000D09 RID: 3337 RVA: 0x00009237 File Offset: 0x00007437
			public List<DCCache.DCCacheFile> Files
			{
				get
				{
					return this.files;
				}
			}

			// Token: 0x1700041E RID: 1054
			// (get) Token: 0x06000D0A RID: 3338 RVA: 0x0000923F File Offset: 0x0000743F
			public string Name
			{
				get
				{
					return this.packageName;
				}
			}

			// Token: 0x1700041F RID: 1055
			// (get) Token: 0x06000D0B RID: 3339 RVA: 0x0003EBE0 File Offset: 0x0003CDE0
			public string Thumbnail
			{
				get
				{
					return string.Concat(new string[]
					{
						"key:",
						this.thumb_typeId.ToString("X8"),
						":",
						this.thumb_groupId.ToString("X8"),
						":",
						this.thumb_instanceId.ToString("X8"),
						this.thumb_secondInstanceId.ToString("X8")
					});
				}
			}

			// Token: 0x17000420 RID: 1056
			// (get) Token: 0x06000D0C RID: 3340 RVA: 0x0003EC5C File Offset: 0x0003CE5C
			public string PackageID
			{
				get
				{
					return string.Concat(new string[]
					{
						"0x",
						this.packId1.ToString("X8"),
						this.packId2.ToString("X8"),
						this.packId3.ToString("X8"),
						this.packId4.ToString("X8")
					});
				}
			}

			// Token: 0x06000D0D RID: 3341 RVA: 0x0003ECC8 File Offset: 0x0003CEC8
			public void SetPackageId(string packageId)
			{
				packageId = packageId.Substring(2);
				string value = packageId.Substring(0, 8);
				string value2 = packageId.Substring(8, 8);
				string value3 = packageId.Substring(16, 8);
				string value4 = packageId.Substring(24, 8);
				this.packId3 = Convert.ToUInt32(value3, 16);
				this.packId4 = Convert.ToUInt32(value4, 16);
				this.packId1 = Convert.ToUInt32(value, 16);
				this.packId2 = Convert.ToUInt32(value2, 16);
			}

			// Token: 0x06000D0E RID: 3342 RVA: 0x0003ED3C File Offset: 0x0003CF3C
			public void AddDep(string packageId)
			{
				DCCache.DCCacheDep dccacheDep = new DCCache.DCCacheDep();
				packageId = packageId.Substring(2);
				string value = packageId.Substring(0, 8);
				string value2 = packageId.Substring(8, 8);
				string value3 = packageId.Substring(16, 8);
				string value4 = packageId.Substring(24, 8);
				dccacheDep.packId3 = Convert.ToUInt32(value3, 16);
				dccacheDep.packId4 = Convert.ToUInt32(value4, 16);
				dccacheDep.packId1 = Convert.ToUInt32(value, 16);
				dccacheDep.packId2 = Convert.ToUInt32(value2, 16);
				this.deps.Add(dccacheDep);
			}

			// Token: 0x06000D0F RID: 3343 RVA: 0x0003EDC4 File Offset: 0x0003CFC4
			public void AddFile(uint typeId, uint groupId, uint instanceId, uint secondInstanceId)
			{
				DCCache.DCCacheFile dccacheFile = new DCCache.DCCacheFile();
				DCCache.DCCacheFile dccacheFile2 = dccacheFile;
				dccacheFile.typeId2 = typeId;
				dccacheFile2.typeId = typeId;
				DCCache.DCCacheFile dccacheFile3 = dccacheFile;
				dccacheFile.groupId2 = groupId;
				dccacheFile3.groupId = groupId;
				DCCache.DCCacheFile dccacheFile4 = dccacheFile;
				dccacheFile.instanceId2 = instanceId;
				dccacheFile4.instanceId = instanceId;
				DCCache.DCCacheFile dccacheFile5 = dccacheFile;
				dccacheFile.secondInstanceId2 = secondInstanceId;
				dccacheFile5.secondInstanceId = secondInstanceId;
				this.files.Add(dccacheFile);
			}

			// Token: 0x06000D10 RID: 3344 RVA: 0x00009247 File Offset: 0x00007447
			public void SetThumb(uint typeId, uint groupId, uint instanceId, uint secondInstanceId)
			{
				this.thumb_typeId = typeId;
				this.thumb_groupId = groupId;
				this.thumb_instanceId = instanceId;
				this.thumb_secondInstanceId = secondInstanceId;
			}

			// Token: 0x06000D11 RID: 3345 RVA: 0x0003EE24 File Offset: 0x0003D024
			public void UnSerialize(BinaryReader r)
			{
				this.typeId = NumberHelpers.Swap(r.ReadUInt32());
				this.unkByte = r.ReadByte();
				uint num = NumberHelpers.Swap(r.ReadUInt32());
				uint num2 = NumberHelpers.Swap(r.ReadUInt32());
				this.packId3 = NumberHelpers.Swap(r.ReadUInt32());
				this.packId4 = NumberHelpers.Swap(r.ReadUInt32());
				this.packId1 = NumberHelpers.Swap(r.ReadUInt32());
				this.packId2 = NumberHelpers.Swap(r.ReadUInt32());
				while (num-- > 0U)
				{
					DCCache.DCCacheDep dccacheDep = new DCCache.DCCacheDep();
					dccacheDep.packId3 = NumberHelpers.Swap(r.ReadUInt32());
					dccacheDep.packId4 = NumberHelpers.Swap(r.ReadUInt32());
					dccacheDep.packId1 = NumberHelpers.Swap(r.ReadUInt32());
					dccacheDep.packId2 = NumberHelpers.Swap(r.ReadUInt32());
					this.deps.Add(dccacheDep);
				}
				this.unknownByte10 = r.ReadBytes(10);
				while (num2-- > 0U)
				{
					DCCache.DCCacheFile dccacheFile = new DCCache.DCCacheFile();
					dccacheFile.typeId = NumberHelpers.Swap(r.ReadUInt32());
					dccacheFile.groupId = NumberHelpers.Swap(r.ReadUInt32());
					dccacheFile.secondInstanceId = NumberHelpers.Swap(r.ReadUInt32());
					dccacheFile.instanceId = NumberHelpers.Swap(r.ReadUInt32());
					dccacheFile.typeId2 = NumberHelpers.Swap(r.ReadUInt32());
					dccacheFile.groupId2 = NumberHelpers.Swap(r.ReadUInt32());
					dccacheFile.secondInstanceId2 = NumberHelpers.Swap(r.ReadUInt32());
					dccacheFile.instanceId2 = NumberHelpers.Swap(r.ReadUInt32());
					this.files.Add(dccacheFile);
				}
				int num3 = NumberHelpers.Swap(r.ReadInt32());
				UnicodeEncoding unicodeEncoding = new UnicodeEncoding();
				while (num3-- > 0)
				{
					byte b = r.ReadByte();
					byte b2 = r.ReadByte();
					this.packageName += unicodeEncoding.GetString(new byte[]
					{
						b2,
						b
					});
				}
				this.unknownInt = r.ReadUInt32();
				this.thumb_typeId = NumberHelpers.Swap(r.ReadUInt32());
				this.thumb_groupId = NumberHelpers.Swap(r.ReadUInt32());
				this.thumb_secondInstanceId = NumberHelpers.Swap(r.ReadUInt32());
				this.thumb_instanceId = NumberHelpers.Swap(r.ReadUInt32());
				byte b3 = r.ReadByte();
				for (;;)
				{
					byte b4 = b3;
					b3 = b4 - 1;
					if (b4 <= 0)
					{
						break;
					}
					DCCache.DCCacheInternalFile dccacheInternalFile = new DCCache.DCCacheInternalFile();
					int count = NumberHelpers.Swap(r.ReadInt32());
					dccacheInternalFile.data = r.ReadBytes(count);
					this.internalFiles.Add(dccacheInternalFile);
				}
			}

			// Token: 0x06000D12 RID: 3346 RVA: 0x0003F0BC File Offset: 0x0003D2BC
			public void Serialize(BinaryWriter w)
			{
				w.Write(NumberHelpers.Swap(this.typeId));
				w.Write(this.unkByte);
				w.Write(NumberHelpers.Swap(this.deps.Count));
				w.Write(NumberHelpers.Swap(this.files.Count));
				w.Write(NumberHelpers.Swap(this.packId3));
				w.Write(NumberHelpers.Swap(this.packId4));
				w.Write(NumberHelpers.Swap(this.packId1));
				w.Write(NumberHelpers.Swap(this.packId2));
				foreach (DCCache.DCCacheDep dccacheDep in this.deps)
				{
					w.Write(dccacheDep.packId3 = NumberHelpers.Swap(dccacheDep.packId3));
					w.Write(NumberHelpers.Swap(dccacheDep.packId4));
					w.Write(NumberHelpers.Swap(dccacheDep.packId1));
					w.Write(NumberHelpers.Swap(dccacheDep.packId2));
				}
				w.Write(this.unknownByte10);
				foreach (DCCache.DCCacheFile dccacheFile in this.files)
				{
					w.Write(NumberHelpers.Swap(dccacheFile.typeId));
					w.Write(NumberHelpers.Swap(dccacheFile.groupId));
					w.Write(NumberHelpers.Swap(dccacheFile.secondInstanceId));
					w.Write(NumberHelpers.Swap(dccacheFile.instanceId));
					w.Write(NumberHelpers.Swap(dccacheFile.typeId2));
					w.Write(NumberHelpers.Swap(dccacheFile.groupId2));
					w.Write(NumberHelpers.Swap(dccacheFile.secondInstanceId2));
					w.Write(NumberHelpers.Swap(dccacheFile.instanceId2));
				}
				w.Write(NumberHelpers.Swap(this.packageName.Length));
				char[] array = this.packageName.ToCharArray();
				new UnicodeEncoding();
				foreach (char c in array)
				{
					w.Write(0);
					w.Write((byte)c);
				}
				w.Write(this.unknownInt);
				w.Write(NumberHelpers.Swap(this.thumb_typeId));
				w.Write(NumberHelpers.Swap(this.thumb_groupId));
				w.Write(NumberHelpers.Swap(this.thumb_secondInstanceId));
				w.Write(NumberHelpers.Swap(this.thumb_instanceId));
				w.Write((byte)this.internalFiles.Count);
				foreach (DCCache.DCCacheInternalFile dccacheInternalFile in this.internalFiles)
				{
					w.Write(NumberHelpers.Swap(dccacheInternalFile.data.Length));
					w.Write(dccacheInternalFile.data);
				}
			}

			// Token: 0x040006B2 RID: 1714
			private List<DCCache.DCCacheInternalFile> internalFiles;

			// Token: 0x040006B3 RID: 1715
			private List<DCCache.DCCacheFile> files;

			// Token: 0x040006B4 RID: 1716
			private List<DCCache.DCCacheDep> deps;

			// Token: 0x040006B5 RID: 1717
			private uint typeId;

			// Token: 0x040006B6 RID: 1718
			private byte unkByte;

			// Token: 0x040006B7 RID: 1719
			private uint packId1;

			// Token: 0x040006B8 RID: 1720
			private uint packId2;

			// Token: 0x040006B9 RID: 1721
			private uint packId3;

			// Token: 0x040006BA RID: 1722
			private uint packId4;

			// Token: 0x040006BB RID: 1723
			private byte[] unknownByte10 = new byte[10];

			// Token: 0x040006BC RID: 1724
			private uint unknownInt;

			// Token: 0x040006BD RID: 1725
			private string packageName;

			// Token: 0x040006BE RID: 1726
			private uint thumb_typeId;

			// Token: 0x040006BF RID: 1727
			private uint thumb_instanceId;

			// Token: 0x040006C0 RID: 1728
			private uint thumb_groupId;

			// Token: 0x040006C1 RID: 1729
			private uint thumb_secondInstanceId;
		}

		// Token: 0x0200010A RID: 266
		public class DCCacheDep
		{
			// Token: 0x040006C2 RID: 1730
			public uint packId1;

			// Token: 0x040006C3 RID: 1731
			public uint packId2;

			// Token: 0x040006C4 RID: 1732
			public uint packId3;

			// Token: 0x040006C5 RID: 1733
			public uint packId4;
		}

		// Token: 0x0200010B RID: 267
		public class DCCacheFile
		{
			// Token: 0x040006C6 RID: 1734
			public uint typeId;

			// Token: 0x040006C7 RID: 1735
			public uint groupId;

			// Token: 0x040006C8 RID: 1736
			public uint instanceId;

			// Token: 0x040006C9 RID: 1737
			public uint secondInstanceId;

			// Token: 0x040006CA RID: 1738
			public uint typeId2;

			// Token: 0x040006CB RID: 1739
			public uint groupId2;

			// Token: 0x040006CC RID: 1740
			public uint instanceId2;

			// Token: 0x040006CD RID: 1741
			public uint secondInstanceId2;
		}

		// Token: 0x0200010C RID: 268
		public class DCCacheInternalFile
		{
			// Token: 0x040006CE RID: 1742
			public byte[] data;
		}
	}
}
