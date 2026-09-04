using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Package.Helper;
using Package.ImageResource;
using Sims3WorkshopSDK;

namespace Package
{
	// Token: 0x02000005 RID: 5
	[Serializable]
	public class DBPF : PackagedFile
	{
		// Token: 0x17000002 RID: 2
		// (get) Token: 0x0600000A RID: 10 RVA: 0x00002F54 File Offset: 0x00001154
		// (set) Token: 0x0600000B RID: 11 RVA: 0x00002F5C File Offset: 0x0000115C
		public string Guid { get; set; }

		// Token: 0x17000003 RID: 3
		// (get) Token: 0x0600000C RID: 12 RVA: 0x00002F65 File Offset: 0x00001165
		// (set) Token: 0x0600000D RID: 13 RVA: 0x00002F6D File Offset: 0x0000116D
		public string Name { get; set; }

		// Token: 0x17000004 RID: 4
		// (get) Token: 0x0600000E RID: 14 RVA: 0x00002F76 File Offset: 0x00001176
		// (set) Token: 0x0600000F RID: 15 RVA: 0x00002F7E File Offset: 0x0000117E
		public string ContentType { get; set; }

		// Token: 0x17000005 RID: 5
		// (get) Token: 0x06000010 RID: 16 RVA: 0x00002F87 File Offset: 0x00001187
		// (set) Token: 0x06000011 RID: 17 RVA: 0x00002F8F File Offset: 0x0000118F
		public Hashtable MetaTags { get; set; }

		// Token: 0x17000006 RID: 6
		// (get) Token: 0x06000012 RID: 18 RVA: 0x00002F98 File Offset: 0x00001198
		// (set) Token: 0x06000013 RID: 19 RVA: 0x00002FA0 File Offset: 0x000011A0
		public int MajorVersion
		{
			get
			{
				return this.majorVersion;
			}
			set
			{
				this.majorVersion = value;
			}
		}

		// Token: 0x17000007 RID: 7
		// (get) Token: 0x06000014 RID: 20 RVA: 0x00002FA9 File Offset: 0x000011A9
		// (set) Token: 0x06000015 RID: 21 RVA: 0x00002FB1 File Offset: 0x000011B1
		public int MinorVersion
		{
			get
			{
				return this.minorVersion;
			}
			set
			{
				this.minorVersion = value;
			}
		}

		// Token: 0x17000008 RID: 8
		// (get) Token: 0x06000016 RID: 22 RVA: 0x00002FBA File Offset: 0x000011BA
		// (set) Token: 0x06000017 RID: 23 RVA: 0x00002FC2 File Offset: 0x000011C2
		public bool KeepOpen { get; set; }

		// Token: 0x17000009 RID: 9
		// (get) Token: 0x06000018 RID: 24 RVA: 0x00002FCB File Offset: 0x000011CB
		public string FileName
		{
			get
			{
				return this._filename;
			}
		}

		// Token: 0x06000019 RID: 25 RVA: 0x0000BEF0 File Offset: 0x0000A0F0
		private BinaryReader GetReader()
		{
			if (this._reader == null && this.data != null)
			{
				this._reader = new BinaryReader(new MemoryStream(this.data));
			}
			else if (this._reader == null || this._reader.BaseStream == null)
			{
				if (string.IsNullOrEmpty(this._filename))
				{
					throw new Exception("Package have no reader and no filename");
				}
				if (this._fileStream != null)
				{
					this._fileStream.Dispose();
				}
				this._fileStream = new FileStream(this._filename, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
				this._reader = new BinaryReader(this._fileStream);
			}
			return this._reader;
		}

		// Token: 0x0600001A RID: 26 RVA: 0x00002FD3 File Offset: 0x000011D3
		private void CleanReader()
		{
			if (!this.KeepOpen)
			{
				this.CloseFiles();
			}
		}

		// Token: 0x0600001B RID: 27 RVA: 0x00002FE3 File Offset: 0x000011E3
		public GameVersion GetGameVersion()
		{
			return this.gameVersion;
		}

		// Token: 0x0600001C RID: 28 RVA: 0x00002FEB File Offset: 0x000011EB
		public void SetGameVersion(GameVersion game)
		{
			this.gameVersion = game;
		}

		// Token: 0x0600001D RID: 29 RVA: 0x0000BF90 File Offset: 0x0000A190
		private DBPF()
		{
			this._entries = new Dictionary<ResKey, DBPFEntry>();
			this._keys = new ResKey[0];
			this.MetaTags = new Hashtable();
			this.majorVersion = 2;
			this.minorVersion = 0;
			this.indexMajorVersion = 0;
			this.indexMinorVersion = 3;
		}

		// Token: 0x0600001E RID: 30 RVA: 0x00002FF4 File Offset: 0x000011F4
		public DBPF(GameVersion gameVersion) : this()
		{
			this.gameVersion = gameVersion;
		}

		// Token: 0x0600001F RID: 31 RVA: 0x00003003 File Offset: 0x00001203
		public DBPF(string name, byte[] data, GameVersion gameVersion) : this(gameVersion)
		{
			this.Name = name;
			this.data = data;
			this.ReadHeader(true);
		}

		// Token: 0x06000020 RID: 32 RVA: 0x00003021 File Offset: 0x00001221
		public DBPF(string filename, GameVersion gameVersion) : this(gameVersion)
		{
			this.Name = Path.GetFileName(filename);
			this._filename = filename;
			this.ReadHeader(false);
		}

		// Token: 0x06000021 RID: 33 RVA: 0x0000BFE4 File Offset: 0x0000A1E4
		~DBPF()
		{
			this.data = null;
		}

		// Token: 0x06000022 RID: 34 RVA: 0x0000C014 File Offset: 0x0000A214
		public void Dispose()
		{
			if (this._entries != null)
			{
				foreach (DBPFEntry dbpfentry in this._entries.Values)
				{
					dbpfentry.Dispose();
				}
			}
			this._entries = null;
			if (this._fileStream != null)
			{
				this._fileStream.Dispose();
			}
		}

		// Token: 0x06000023 RID: 35 RVA: 0x00003044 File Offset: 0x00001244
		public void CloseFiles()
		{
			this.KeepOpen = false;
			if (this._reader != null)
			{
				this._reader.Close();
				this._reader = null;
			}
			if (this._fileStream != null)
			{
				this._fileStream.Close();
			}
		}

		// Token: 0x1700000A RID: 10
		// (get) Token: 0x06000024 RID: 36 RVA: 0x0000307A File Offset: 0x0000127A
		public int EntryCount
		{
			get
			{
				return this._keys.Length;
			}
		}

		// Token: 0x06000025 RID: 37 RVA: 0x0000C08C File Offset: 0x0000A28C
		private void ReadHeader(bool createInstance)
		{
			BinaryReader reader = this.GetReader();
			this.magic = reader.ReadBytes(4);
			if (!PackageUtil.StringMatch("DBPF", this.magic, 4) && !PackageUtil.StringMatch("DBPP", this.magic, 4))
			{
				throw new Exception("Invalid DBPF file. Magic does not match.");
			}
			if (PackageUtil.StringMatch("DBPP", this.magic, 4))
			{
				this.indexOffset = this.data.Length - 1344;
				this.indexEntryCount = 42;
				this.indexMinorVersion = 3;
			}
			else
			{
				this.majorVersion = reader.ReadInt32();
				this.minorVersion = reader.ReadInt32();
				this.unknown1 = reader.ReadInt32();
				this.unknown2 = reader.ReadInt32();
				this.unknown3 = reader.ReadInt32();
				this.dateCreated = reader.ReadInt32();
				this.dateModified = reader.ReadInt32();
				this.indexMajorVersion = reader.ReadInt32();
				this.indexEntryCount = reader.ReadInt32();
				this.indexOffset = reader.ReadInt32();
				this.indexSize = reader.ReadInt32();
				this.holeEntryCount = reader.ReadInt32();
				this.holeOffset = reader.ReadInt32();
				this.holeSize = reader.ReadInt32();
				this.indexMinorVersion = reader.ReadInt32();
				this.indexOffsetV2 = reader.ReadInt32();
				this.unknown4 = reader.ReadInt32();
				this.reserved = reader.ReadBytes(24);
				if (this.majorVersion >= 2)
				{
					this.indexOffset = this.indexOffsetV2;
				}
			}
			reader.BaseStream.Position = (long)this.indexOffset;
			int num;
			if (this.majorVersion >= 2)
			{
				if (this.minorVersion == 0 || this.minorVersion == 1)
				{
					num = reader.ReadInt32();
					goto IL_1A7;
				}
			}
			num = 0;
			IL_1A7:
			this.indexType = num;
			NumberHelpers.CountSetBits(this.indexType);
			uint[] array = new uint[8];
			for (int i = 0; i < 8; i++)
			{
				if ((this.indexType >> i & 1) == 1)
				{
					array[i] = reader.ReadUInt32();
				}
			}
			this._keys = new ResKey[this.indexEntryCount];
			int num2 = 0;
			for (int j = 0; j < this.indexEntryCount; j++)
			{
				for (int k = 0; k < 8; k++)
				{
					if ((this.indexType >> k & 1) == 0)
					{
						array[k] = reader.ReadUInt32();
					}
				}
				uint num3 = array[0];
				int num4 = (int)array[1];
				int num5 = (int)array[2];
				int num6 = (int)array[3];
				uint location = array[4];
				uint compressedSize = array[5] & 2147483647U;
				uint uncompressedSize = array[6];
				int unknownInt = (int)array[7];
				ResKey resKey = new ResKey(num3, num4, num5, num6);
				resKey.Game = this.gameVersion;
				resKey.unknownInt = unknownInt;
				resKey.compressedSize = compressedSize;
				resKey.uncompressedSize = uncompressedSize;
				resKey.location = location;
				resKey.FileName = this._filename;
				this._keys[num2++] = resKey;
			}
			this.CleanReader();
		}

		// Token: 0x06000026 RID: 38 RVA: 0x00003084 File Offset: 0x00001284
		public void SaveToSelf(bool compress)
		{
			this.data = this.Save(compress);
		}

		// Token: 0x06000027 RID: 39 RVA: 0x00003093 File Offset: 0x00001293
		public byte[] Save(bool compress)
		{
			return this.Save(compress, null);
		}

		// Token: 0x06000028 RID: 40 RVA: 0x0000309D File Offset: 0x0000129D
		public byte[] Save(bool compress, bool unopenedFilesNeedsToBeOpened)
		{
			return this.Save(compress, null, unopenedFilesNeedsToBeOpened);
		}

		// Token: 0x06000029 RID: 41 RVA: 0x000030A8 File Offset: 0x000012A8
		public byte[] Save(bool compress, DBPF.ProgressDelegate progressDelegate)
		{
			return this.Save(compress, progressDelegate, true);
		}

		// Token: 0x0600002A RID: 42 RVA: 0x0000C37C File Offset: 0x0000A57C
		public byte[] Save(bool compress, DBPF.ProgressDelegate progressDelegate, bool unopenedFilesNeedsToBeOpened)
		{
			MemoryStream memoryStream = new MemoryStream();
			BinaryWriter binaryWriter = new BinaryWriter(memoryStream);
			this.WriteHeader(binaryWriter, compress, progressDelegate, unopenedFilesNeedsToBeOpened);
			memoryStream.Position = 0L;
			byte[] array = new byte[(int)memoryStream.Length];
			memoryStream.Read(array, 0, array.Length);
			binaryWriter.Close();
			memoryStream.Close();
			return array;
		}

		// Token: 0x0600002B RID: 43 RVA: 0x000030B3 File Offset: 0x000012B3
		private void WriteHeader(BinaryWriter writer, bool compress, DBPF.ProgressDelegate progressDelegate)
		{
			this.WriteHeader(writer, compress, progressDelegate, true);
		}

		// Token: 0x0600002C RID: 44 RVA: 0x0000C3D4 File Offset: 0x0000A5D4
		private void WriteHeader(BinaryWriter writer, bool compress, DBPF.ProgressDelegate progressDelegate, bool unopenedFilesNeedsToBeOpened)
		{
			Dictionary<ResKey, DBPFEntry> entries = this._entries;
			lock (entries)
			{
				MemoryStream memoryStream = new MemoryStream();
				BinaryWriter binaryWriter = new BinaryWriter(memoryStream);
				binaryWriter.Write('D');
				binaryWriter.Write('B');
				binaryWriter.Write('P');
				binaryWriter.Write('F');
				binaryWriter.Write(this.majorVersion);
				binaryWriter.Write(this.minorVersion);
				binaryWriter.Write(this.unknown1);
				binaryWriter.Write(this.unknown2);
				binaryWriter.Write(this.unknown3);
				binaryWriter.Write(this.dateCreated);
				binaryWriter.Write(this.dateModified);
				binaryWriter.Write(this.indexMajorVersion);
				binaryWriter.Write(this._entries.Count);
				binaryWriter.Write(0);
				binaryWriter.Write(this.indexSize);
				binaryWriter.Write(this.holeEntryCount);
				binaryWriter.Write(this.holeOffset);
				binaryWriter.Write(this.holeSize);
				binaryWriter.Write(this.indexMinorVersion);
				binaryWriter.Write(this.indexOffsetV2);
				binaryWriter.Write(this.unknown4);
				binaryWriter.Write(new byte[24]);
				MemoryStream memoryStream2 = new MemoryStream();
				BinaryWriter binaryWriter2 = new BinaryWriter(memoryStream2);
				if (this.majorVersion == 2 && (this.minorVersion == 0 || this.minorVersion == 1))
				{
					using (Dictionary<ResKey, DBPFEntry>.ValueCollection.Enumerator enumerator = this._entries.Values.GetEnumerator())
					{
						while (enumerator.MoveNext())
						{
							if (enumerator.Current.GroupID != 0)
							{
								this.indexType = 0;
								break;
							}
						}
					}
					binaryWriter2.Write(this.indexType);
				}
				if (this.indexType == 2 || this.indexType == 4)
				{
					binaryWriter2.Write(0);
				}
				if (this.indexType == 6)
				{
					binaryWriter2.Write(0);
					binaryWriter2.Write(0);
				}
				if (this.indexType == 7)
				{
					binaryWriter2.Write(0);
					binaryWriter2.Write(0);
					binaryWriter2.Write(0);
				}
				string tempFileName = Path.GetTempFileName();
				FileStream fileStream = new FileStream(tempFileName, FileMode.Create);
				BinaryWriter binaryWriter3 = new BinaryWriter(fileStream);
				uint num = (uint)binaryWriter.BaseStream.Position;
				foreach (DBPFEntry dbpfentry in this._entries.Values)
				{
					uint location = (uint)((ulong)num + (ulong)((long)((int)binaryWriter3.BaseStream.Position)));
					byte[] array = null;
					int num2 = 0;
					try
					{
						if (!dbpfentry.IsUnpacked && unopenedFilesNeedsToBeOpened)
						{
							throw new Exception("DBPFEntry has not been unpacked and openUnOpened flag is set, bail out.");
						}
						if (!dbpfentry.IsUnpacked && !unopenedFilesNeedsToBeOpened)
						{
							BinaryReader reader = this.GetReader();
							reader.BaseStream.Position = (long)((ulong)dbpfentry.location);
							array = reader.ReadBytes((int)dbpfentry.compressedSize);
							num2 = (int)dbpfentry.uncompressedSize;
						}
						else
						{
							array = dbpfentry.Serialize();
							num2 = array.Length;
						}
						byte[] array2;
						if (compress && dbpfentry.IsUnpacked && this.CompressRoutine != null && this.CompressRoutine(ref array, out array2, dbpfentry.TypeID) != -1)
						{
							dbpfentry.IsCompressed = true;
							array = null;
							array = new byte[array2.Length];
							Array.Copy(array2, array, array2.Length);
							array2 = null;
						}
						if (progressDelegate != null)
						{
							progressDelegate(1);
						}
					}
					catch (Exception ex)
					{
						throw ex;
					}
					dbpfentry.location = location;
					if (array == null)
					{
						array = new byte[0];
					}
					binaryWriter3.Write(array);
					binaryWriter2.Write(dbpfentry.TypeID);
					if (this.indexType == 2)
					{
						binaryWriter2.Write(dbpfentry.InstanceID);
						binaryWriter2.Write(dbpfentry.SecondInstanceID);
					}
					else if (this.indexType == 4)
					{
						binaryWriter2.Write(dbpfentry.GroupID);
						binaryWriter2.Write(dbpfentry.SecondInstanceID);
					}
					else if (this.indexType == 6)
					{
						binaryWriter2.Write(dbpfentry.GroupID);
					}
					else if (this.indexType != 7)
					{
						binaryWriter2.Write(dbpfentry.GroupID);
						binaryWriter2.Write(dbpfentry.InstanceID);
						if (this.indexMinorVersion != 0)
						{
							binaryWriter2.Write(dbpfentry.SecondInstanceID);
						}
					}
					binaryWriter2.Write(dbpfentry.location);
					if (this.indexMinorVersion == 3)
					{
						byte[] array3 = new byte[]
						{
							0,
							0,
							(byte)(array.Length >> 16 & 255)
						};
						array3[1] = (byte)(array.Length >> 8 & 255);
						array3[0] = (byte)(array.Length & 255);
						binaryWriter2.Write(array3);
						binaryWriter2.Write(128);
					}
					binaryWriter2.Write(num2);
					if (this.indexMinorVersion == 3)
					{
						if (num2 != array.Length)
						{
							binaryWriter2.Write((this.minorVersion == 1) ? 88642 : 131071);
						}
						else
						{
							binaryWriter2.Write(65536);
						}
					}
					array = null;
				}
				this.indexOffset = (this.indexOffsetV2 = (int)(binaryWriter.BaseStream.Position + binaryWriter3.BaseStream.Position));
				writer.Write('D');
				writer.Write('B');
				writer.Write('P');
				writer.Write('F');
				writer.Write(this.majorVersion);
				writer.Write(this.minorVersion);
				writer.Write(this.unknown1);
				writer.Write(this.unknown2);
				writer.Write(this.unknown3);
				writer.Write(this.dateCreated);
				writer.Write(this.dateModified);
				writer.Write(this.indexMajorVersion);
				writer.Write(this._entries.Count);
				writer.Write(0);
				writer.Write((int)binaryWriter2.BaseStream.Position);
				writer.Write(this.holeEntryCount);
				writer.Write(this.holeOffset);
				writer.Write(this.holeSize);
				writer.Write(this.indexMinorVersion);
				writer.Write((this.majorVersion == 2) ? this.indexOffsetV2 : 0);
				writer.Write(this.unknown4);
				writer.Write(new byte[24]);
				fileStream.Position = 0L;
				byte[] buffer = new byte[(int)fileStream.Length];
				fileStream.Read(buffer, 0, (int)fileStream.Length);
				writer.Write(buffer);
				memoryStream2.Position = 0L;
				byte[] buffer2 = new byte[(int)memoryStream2.Length];
				memoryStream2.Read(buffer2, 0, (int)memoryStream2.Length);
				writer.Write(buffer2);
				memoryStream2.Close();
				memoryStream2.Dispose();
				binaryWriter2.Close();
				memoryStream.Close();
				memoryStream.Dispose();
				binaryWriter.Close();
				fileStream.Close();
				fileStream.Dispose();
				binaryWriter3.Close();
				try
				{
					File.Delete(tempFileName);
				}
				catch (Exception)
				{
				}
			}
		}

		// Token: 0x14000001 RID: 1
		// (add) Token: 0x0600002D RID: 45 RVA: 0x0000CB0C File Offset: 0x0000AD0C
		// (remove) Token: 0x0600002E RID: 46 RVA: 0x0000CB44 File Offset: 0x0000AD44
		public event DBPF.OnEntryAdded EntryAdded;

		// Token: 0x0600002F RID: 47 RVA: 0x0000CB7C File Offset: 0x0000AD7C
		private bool containsKey(ResKey keyToFind)
		{
			foreach (ResKey resKey in this._keys)
			{
				if (resKey != null && resKey.GetHashCode() == keyToFind.GetHashCode())
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x06000030 RID: 48 RVA: 0x0000CBB8 File Offset: 0x0000ADB8
		private ResKey getKey(ResKey keyToFind)
		{
			foreach (ResKey resKey in this._keys)
			{
				if (resKey != null && resKey.GetHashCode() == keyToFind.GetHashCode())
				{
					return resKey;
				}
			}
			return null;
		}

		// Token: 0x06000031 RID: 49 RVA: 0x0000CBF4 File Offset: 0x0000ADF4
		private void removeKey(ResKey keyToRemove)
		{
			ResKey[] array = new ResKey[this._keys.Length - 1];
			int num = 0;
			foreach (ResKey resKey in this._keys)
			{
				if (resKey != null && resKey.GetHashCode() != keyToRemove.GetHashCode())
				{
					array[num++] = resKey;
				}
			}
			this._keys = array;
		}

		// Token: 0x06000032 RID: 50 RVA: 0x0000CC50 File Offset: 0x0000AE50
		private void addKey(ResKey keyToAdd)
		{
			ResKey[] array = new ResKey[this._keys.Length + 1];
			int num = 0;
			foreach (ResKey resKey in this._keys)
			{
				array[num++] = resKey;
			}
			array[num] = keyToAdd;
			this._keys = array;
		}

		// Token: 0x06000033 RID: 51 RVA: 0x0000CCA0 File Offset: 0x0000AEA0
		public void AddEntry(DBPFEntry entry)
		{
			ResKey resKey = new ResKey(entry.GenerateResKey(), this.gameVersion);
			if (this.containsKey(resKey))
			{
				DBPFEntry dbpfentry = this._entries[resKey];
				if (dbpfentry is PNG)
				{
					dbpfentry.Dispose();
				}
				this._entries.Remove(resKey);
				this.removeKey(resKey);
			}
			if (!entry.IsUnpacked)
			{
				entry.IsUnpacked = true;
			}
			this._entries.Add(resKey, entry);
			this.addKey(resKey);
			if (this.EntryAdded != null)
			{
				this.EntryAdded(entry);
			}
		}

		// Token: 0x06000034 RID: 52 RVA: 0x0000CD30 File Offset: 0x0000AF30
		public bool RemoveEntry(DBPFEntry entry)
		{
			if (entry == null)
			{
				return false;
			}
			ResKey resKey = new ResKey(entry.GenerateResKey(), this.gameVersion);
			if (!this.containsKey(resKey))
			{
				return false;
			}
			this._entries.Remove(resKey);
			this.removeKey(resKey);
			return true;
		}

		// Token: 0x06000035 RID: 53 RVA: 0x000030BF File Offset: 0x000012BF
		public void RemoveEntry(ResKey key)
		{
			if (!this.containsKey(key))
			{
				return;
			}
			this._entries.Remove(key);
			this.removeKey(key);
		}

		// Token: 0x06000036 RID: 54 RVA: 0x000030DF File Offset: 0x000012DF
		public void ReadEntries()
		{
			this.GetAllEntries();
		}

		// Token: 0x06000037 RID: 55 RVA: 0x0000CD74 File Offset: 0x0000AF74
		public List<DBPFEntry> GetAllEntries()
		{
			List<DBPFEntry> list = new List<DBPFEntry>();
			foreach (ResKey key in this._keys)
			{
				list.Add(this.GetEntry(key));
			}
			return list;
		}

		// Token: 0x06000038 RID: 56 RVA: 0x000030E8 File Offset: 0x000012E8
		public void ClearEntries()
		{
			this._entries.Clear();
		}

		// Token: 0x06000039 RID: 57 RVA: 0x000030F5 File Offset: 0x000012F5
		public DBPFEntry GetEntry(string key)
		{
			return this.GetEntry(new ResKey(key, this.gameVersion));
		}

		// Token: 0x0600003A RID: 58 RVA: 0x00003109 File Offset: 0x00001309
		public DBPFEntry GetEntry(ResKey key)
		{
			return this.GetEntry(key, false);
		}

		// Token: 0x0600003B RID: 59 RVA: 0x0000CDB0 File Offset: 0x0000AFB0
		public DBPFEntry GetEntry(ResKey key, bool throwException)
		{
			DBPFEntry dbpfentry = null;
			if (!this.containsKey(key))
			{
				return null;
			}
			key = this.getKey(key);
			if (!this._entries.TryGetValue(key, out dbpfentry))
			{
				dbpfentry = DBPFFactory.GetInstance(key.TypeId, this.gameVersion);
				dbpfentry.gameVersion = this.gameVersion;
				dbpfentry.Package = this;
				dbpfentry.GroupID = key.GroupId;
				dbpfentry.InstanceID = key.InstanceId;
				dbpfentry.SecondInstanceID = key.SecondInstanceId;
				dbpfentry.location = key.location;
				dbpfentry.unknown = 0;
				dbpfentry.compressedSize = key.compressedSize;
				dbpfentry.uncompressedSize = key.uncompressedSize;
				dbpfentry.unknownInt = key.unknownInt;
				this._entries.Add(key, dbpfentry);
			}
			if (!dbpfentry.IsUnpacked)
			{
				DBPFEntry result;
				try
				{
					this.ReadEntryData(dbpfentry);
					goto IL_E8;
				}
				catch (Exception ex)
				{
					Console.WriteLine("Could not get entry: " + ex.Message);
					if (throwException)
					{
						throw ex;
					}
					result = null;
				}
				return result;
			}
			IL_E8:
			dbpfentry.Package = this;
			return dbpfentry;
		}

		// Token: 0x0600003C RID: 60 RVA: 0x0000CEC0 File Offset: 0x0000B0C0
		public void ReadEntryData(DBPFEntry entry)
		{
			string text = "";
			try
			{
				BinaryReader reader = this.GetReader();
				reader.BaseStream.Position = (long)((ulong)entry.location);
				int num = (int)((entry.compressedSize > 0U) ? entry.compressedSize : entry.uncompressedSize);
				if (num > 0 && entry.uncompressedSize != 4294967295U)
				{
					MemoryStream memoryStream = new MemoryStream(reader.ReadBytes(num));
					BinaryReader binaryReader = new BinaryReader(memoryStream);
					try
					{
						entry.ReadData(binaryReader);
					}
					catch (Exception ex)
					{
						text = string.Concat(new string[]
						{
							text,
							"Could not read entry data for entry '",
							entry.ResKey.AsString(),
							"'",
							ex.Message,
							"\n",
							ex.StackTrace
						});
					}
					binaryReader.Close();
					memoryStream.Close();
					memoryStream.Dispose();
				}
				this.CleanReader();
			}
			catch (Exception ex2)
			{
				text = string.Concat(new string[]
				{
					text,
					"Error reading from position: ",
					entry.location.ToString(),
					" (",
					((int)((entry.compressedSize > 0U) ? entry.compressedSize : entry.uncompressedSize)).ToString(),
					" bytes)\n\n",
					ex2.Message
				});
			}
			if (!string.IsNullOrEmpty(text))
			{
				throw new Exception(text);
			}
		}

		// Token: 0x0600003D RID: 61 RVA: 0x00003113 File Offset: 0x00001313
		public ArrayList GetResKeys()
		{
			return new ArrayList(this._keys);
		}

		// Token: 0x0600003E RID: 62 RVA: 0x0000D034 File Offset: 0x0000B234
		public void SetInstance(ResKey key, int instanceId, int secondInstanceId)
		{
			DBPFEntry dbpfentry = this._entries[key];
			this._entries.Remove(key);
			key.InstanceId = instanceId;
			key.SecondInstanceId = secondInstanceId;
			dbpfentry.InstanceID = instanceId;
			dbpfentry.SecondInstanceID = secondInstanceId;
			this._entries.Add(key, dbpfentry);
		}

		// Token: 0x0600003F RID: 63 RVA: 0x00003120 File Offset: 0x00001320
		public bool HasEntry(ResKey key)
		{
			return this.containsKey(key);
		}

		// Token: 0x06000040 RID: 64 RVA: 0x0000D084 File Offset: 0x0000B284
		public void ChangeEntryResKey(ResKey oldKey, ResKey newKey, bool updateReferences)
		{
			DBPFEntry entry = this.GetEntry(oldKey);
			entry.ResKey = newKey;
			newKey.Game = this.gameVersion;
			this._entries.Remove(oldKey);
			this._entries.Add(newKey, entry);
			this.removeKey(oldKey);
			this.addKey(newKey);
			if (updateReferences)
			{
				this.ReplaceAllReferences(oldKey, newKey);
			}
		}

		// Token: 0x06000041 RID: 65 RVA: 0x0000D0E0 File Offset: 0x0000B2E0
		public int ReplaceAllReferences(ResKey from, ResKey to)
		{
			int num = 0;
			foreach (ResKey key in this._keys)
			{
				int num2 = this.GetEntry(key).ReplaceReferences(from, to);
				if (num2 > 0)
				{
					Console.WriteLine(string.Concat(new string[]
					{
						"Replaced ",
						num2.ToString(),
						" occurences of ",
						(from != null) ? from.ToString() : null,
						" to ",
						(to != null) ? to.ToString() : null
					}));
				}
				num += num2;
			}
			return num;
		}

		// Token: 0x06000042 RID: 66 RVA: 0x00003129 File Offset: 0x00001329
		public List<ResKey> SearchEntries(ResKey search)
		{
			return this.SearchEntries(search, 0, false);
		}

		// Token: 0x06000043 RID: 67 RVA: 0x0000D178 File Offset: 0x0000B378
		public List<ResKey> SearchEntries(ResKey search, int limit, bool exact)
		{
			List<ResKey> list = new List<ResKey>();
			int num = 0;
			foreach (ResKey resKey in this._keys)
			{
				if (((search.TypeId <= 0U && !exact) || resKey.TypeId == search.TypeId) && ((search.GroupId == 0 && !exact) || resKey.GroupId == search.GroupId) && ((search.InstanceId == 0 && !exact) || resKey.InstanceId == search.InstanceId) && ((search.SecondInstanceId == 0 && !exact) || resKey.SecondInstanceId == search.SecondInstanceId))
				{
					list.Add(resKey);
					num++;
					if (limit > 0 && num == limit)
					{
						break;
					}
				}
			}
			return list;
		}

		// Token: 0x06000044 RID: 68 RVA: 0x00003134 File Offset: 0x00001334
		public string GetName()
		{
			return this.Name;
		}

		// Token: 0x06000045 RID: 69 RVA: 0x0000313C File Offset: 0x0000133C
		public byte[] GetData()
		{
			return this.data;
		}

		// Token: 0x06000046 RID: 70 RVA: 0x00003144 File Offset: 0x00001344
		public long GetLenght()
		{
			return (long)this.data.Length;
		}

		// Token: 0x06000047 RID: 71 RVA: 0x0000D234 File Offset: 0x0000B434
		public string GetCrc()
		{
			return SimsCrc64.Compute(this.data).ToString("X16");
		}

		// Token: 0x06000048 RID: 72 RVA: 0x0000314F File Offset: 0x0000134F
		public string GetGuid()
		{
			return this.Guid;
		}

		// Token: 0x06000049 RID: 73 RVA: 0x00003157 File Offset: 0x00001357
		public string GetContentType()
		{
			return this.ContentType;
		}

		// Token: 0x0600004A RID: 74 RVA: 0x0000315F File Offset: 0x0000135F
		public Hashtable GetMetaTags()
		{
			return this.MetaTags;
		}

		// Token: 0x0600004B RID: 75 RVA: 0x00003167 File Offset: 0x00001367
		public void Serialize(bool compress)
		{
			this.data = this.Save(compress, null);
		}

		// Token: 0x0600004C RID: 76 RVA: 0x00003177 File Offset: 0x00001377
		public void Serialize(bool compress, DBPF.ProgressDelegate progressDelegate)
		{
			this.data = this.Save(compress, progressDelegate, true);
		}

		// Token: 0x0600004D RID: 77 RVA: 0x00003188 File Offset: 0x00001388
		public void Serialize(bool compress, DBPF.ProgressDelegate progressDelegate, bool unopenedFilesNeedsToBeOpened)
		{
			this.data = this.Save(compress, progressDelegate, unopenedFilesNeedsToBeOpened);
		}

		// Token: 0x0600004E RID: 78 RVA: 0x0000D25C File Offset: 0x0000B45C
		public void Serialize(Stream stream)
		{
			BinaryWriter binaryWriter = new BinaryWriter(stream);
			this.WriteHeader(binaryWriter, false, null);
			binaryWriter.Close();
		}

		// Token: 0x0600004F RID: 79 RVA: 0x0000D280 File Offset: 0x0000B480
		public void Serialize(Stream stream, bool compress)
		{
			BinaryWriter binaryWriter = new BinaryWriter(stream);
			this.WriteHeader(binaryWriter, compress, null);
			binaryWriter.Close();
		}

		// Token: 0x06000050 RID: 80 RVA: 0x0000D2A4 File Offset: 0x0000B4A4
		public void SaveToFile(string fileName)
		{
			FileStream fileStream = new FileStream(fileName, FileMode.Create);
			this.Serialize(fileStream);
			fileStream.Close();
			fileStream.Dispose();
		}

		// Token: 0x06000051 RID: 81 RVA: 0x0000D2CC File Offset: 0x0000B4CC
		public void SaveToFile(string fileName, bool compress)
		{
			FileStream fileStream = new FileStream(fileName, FileMode.Create);
			this.Serialize(fileStream, compress);
			fileStream.Close();
			fileStream.Dispose();
		}

		// Token: 0x06000052 RID: 82 RVA: 0x0000D2F8 File Offset: 0x0000B4F8
		public void SaveToFile(string fileName, bool compress, bool unopenedFilesNeedsToBeOpened)
		{
			string tempFileName = Path.GetTempFileName();
			FileStream fileStream = new FileStream(tempFileName, FileMode.Create);
			BinaryWriter binaryWriter = new BinaryWriter(fileStream);
			this.WriteHeader(binaryWriter, compress, null, unopenedFilesNeedsToBeOpened);
			binaryWriter.Close();
			fileStream.Dispose();
			File.Copy(tempFileName, fileName, true);
		}

		// Token: 0x06000053 RID: 83 RVA: 0x00003199 File Offset: 0x00001399
		public override string ToString()
		{
			return this.GetName();
		}

		// Token: 0x04000005 RID: 5
		public DBPF.CompressionDelegate CompressRoutine;

		// Token: 0x04000006 RID: 6
		private Dictionary<ResKey, DBPFEntry> _entries;

		// Token: 0x04000007 RID: 7
		private ResKey[] _keys;

		// Token: 0x0400000D RID: 13
		private byte[] data;

		// Token: 0x0400000E RID: 14
		private byte[] magic;

		// Token: 0x0400000F RID: 15
		private int majorVersion;

		// Token: 0x04000010 RID: 16
		private int minorVersion;

		// Token: 0x04000011 RID: 17
		private int unknown1;

		// Token: 0x04000012 RID: 18
		private int unknown2;

		// Token: 0x04000013 RID: 19
		private int unknown3;

		// Token: 0x04000014 RID: 20
		private int dateCreated;

		// Token: 0x04000015 RID: 21
		private int dateModified;

		// Token: 0x04000016 RID: 22
		private int indexMajorVersion;

		// Token: 0x04000017 RID: 23
		private int indexEntryCount;

		// Token: 0x04000018 RID: 24
		private int indexOffset;

		// Token: 0x04000019 RID: 25
		private int indexSize;

		// Token: 0x0400001A RID: 26
		private int holeEntryCount;

		// Token: 0x0400001B RID: 27
		private int holeOffset;

		// Token: 0x0400001C RID: 28
		private int holeSize;

		// Token: 0x0400001D RID: 29
		private int indexMinorVersion;

		// Token: 0x0400001E RID: 30
		private int indexOffsetV2;

		// Token: 0x0400001F RID: 31
		private int unknown4;

		// Token: 0x04000020 RID: 32
		private byte[] reserved;

		// Token: 0x04000021 RID: 33
		private int indexType;

		// Token: 0x04000022 RID: 34
		private string _filename;

		// Token: 0x04000023 RID: 35
		private BinaryReader _reader;

		// Token: 0x04000024 RID: 36
		private FileStream _fileStream;

		// Token: 0x04000025 RID: 37
		protected GameVersion gameVersion;

		// Token: 0x020000F4 RID: 244
		// (Invoke) Token: 0x06000C68 RID: 3176
		public delegate void ProgressDelegate(int increment);

		// Token: 0x020000F5 RID: 245
		// (Invoke) Token: 0x06000C6C RID: 3180
		public delegate int CompressionDelegate(ref byte[] inData, out byte[] outData, DBPFType type);

		// Token: 0x020000F6 RID: 246
		// (Invoke) Token: 0x06000C70 RID: 3184
		public delegate void OnEntryAdded(DBPFEntry entry);
	}
}
