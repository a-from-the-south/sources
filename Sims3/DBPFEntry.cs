using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.IO.Compression;
using Sims3WorkshopSDK;
using Sims3WorkshopSDK.Interfaces;

namespace Package
{
	// Token: 0x02000006 RID: 6
	public abstract class DBPFEntry : ICloneable, IDBPFEntry
	{
		// Token: 0x1700000B RID: 11
		// (get) Token: 0x06000054 RID: 84 RVA: 0x000031A1 File Offset: 0x000013A1
		// (set) Token: 0x06000055 RID: 85 RVA: 0x0000D334 File Offset: 0x0000B534
		[Browsable(false)]
		public ResKey ResKey
		{
			get
			{
				return new ResKey(this.typeId, this.groupId, this.instanceId, this.secondInstanceId);
			}
			set
			{
				this.typeId = value.TypeId;
				this.groupId = value.GroupId;
				this.instanceId = value.InstanceId;
				this.secondInstanceId = value.SecondInstanceId;
			}
		}

		// Token: 0x06000056 RID: 86 RVA: 0x000031C0 File Offset: 0x000013C0
		public DBPFEntry()
		{
			this.IsUnpacked = false;
		}

		// Token: 0x06000057 RID: 87 RVA: 0x000031DA File Offset: 0x000013DA
		public DBPFEntry(uint typeId)
		{
			this.typeId = typeId;
			this.IsUnpacked = false;
		}

		// Token: 0x06000058 RID: 88 RVA: 0x000031FB File Offset: 0x000013FB
		public string GenerateResKey()
		{
			return this.GenerateResKey(false);
		}

		// Token: 0x06000059 RID: 89 RVA: 0x0000D374 File Offset: 0x0000B574
		public ResKey CreateNewResKey(int seed)
		{
			Random random = new Random(seed);
			this.InstanceID = random.Next();
			this.SecondInstanceID = random.Next();
			return this.ResKey;
		}

		// Token: 0x0600005A RID: 90 RVA: 0x0000D3A8 File Offset: 0x0000B5A8
		public string GenerateResKey(bool uppercase)
		{
			string[] array = new string[6];
			int num = 0;
			uint num2 = this.typeId;
			array[num] = num2.ToString("X8");
			array[1] = ":";
			array[2] = this.groupId.ToString("X8");
			array[3] = ":";
			array[4] = this.instanceId.ToString("X8");
			array[5] = this.secondInstanceId.ToString("X8");
			string text = string.Concat(array);
			return "key:" + (uppercase ? text : text.ToLower());
		}

		// Token: 0x0600005B RID: 91 RVA: 0x00003204 File Offset: 0x00001404
		public virtual void Dispose()
		{
			this.data = null;
		}

		// Token: 0x1700000C RID: 12
		// (get) Token: 0x0600005C RID: 92 RVA: 0x0000320D File Offset: 0x0000140D
		// (set) Token: 0x0600005D RID: 93 RVA: 0x00003215 File Offset: 0x00001415
		[Browsable(false)]
		public bool IsUnpacked { get; set; }

		// Token: 0x1700000D RID: 13
		// (get) Token: 0x0600005E RID: 94 RVA: 0x0000321E File Offset: 0x0000141E
		// (set) Token: 0x0600005F RID: 95 RVA: 0x00003226 File Offset: 0x00001426
		[Browsable(false)]
		public bool IsCompressed
		{
			get
			{
				return this.compressed;
			}
			set
			{
				this.compressed = value;
			}
		}

		// Token: 0x1700000E RID: 14
		// (get) Token: 0x06000061 RID: 97 RVA: 0x00003238 File Offset: 0x00001438
		// (set) Token: 0x06000060 RID: 96 RVA: 0x0000322F File Offset: 0x0000142F
		[Browsable(false)]
		public PackagedFile Package
		{
			get
			{
				return this._packagedFile;
			}
			set
			{
				this._packagedFile = value;
			}
		}

		// Token: 0x1700000F RID: 15
		// (get) Token: 0x06000062 RID: 98 RVA: 0x00003240 File Offset: 0x00001440
		// (set) Token: 0x06000063 RID: 99 RVA: 0x00003248 File Offset: 0x00001448
		public virtual DBPFType TypeID
		{
			get
			{
				return this.typeId;
			}
			set
			{
				this.typeId = value;
			}
		}

		// Token: 0x17000010 RID: 16
		// (get) Token: 0x06000064 RID: 100 RVA: 0x00003251 File Offset: 0x00001451
		// (set) Token: 0x06000065 RID: 101 RVA: 0x00003259 File Offset: 0x00001459
		[TypeConverter(typeof(IntTypeConverter))]
		public virtual int GroupID
		{
			get
			{
				return this.groupId;
			}
			set
			{
				this.groupId = value;
			}
		}

		// Token: 0x17000011 RID: 17
		// (get) Token: 0x06000066 RID: 102 RVA: 0x00003262 File Offset: 0x00001462
		// (set) Token: 0x06000067 RID: 103 RVA: 0x0000326A File Offset: 0x0000146A
		[TypeConverter(typeof(IntTypeConverter))]
		public virtual int InstanceID
		{
			get
			{
				return this.instanceId;
			}
			set
			{
				this.instanceId = value;
			}
		}

		// Token: 0x17000012 RID: 18
		// (get) Token: 0x06000068 RID: 104 RVA: 0x00003273 File Offset: 0x00001473
		// (set) Token: 0x06000069 RID: 105 RVA: 0x0000327B File Offset: 0x0000147B
		[TypeConverter(typeof(IntTypeConverter))]
		public virtual int SecondInstanceID
		{
			get
			{
				return this.secondInstanceId;
			}
			set
			{
				this.secondInstanceId = value;
			}
		}

		// Token: 0x0600006A RID: 106 RVA: 0x00003284 File Offset: 0x00001484
		public virtual DBPFType GetTypeID()
		{
			return this.TypeID;
		}

		// Token: 0x0600006B RID: 107
		public abstract int ReplaceReferences(ResKey from, ResKey to);

		// Token: 0x0600006C RID: 108 RVA: 0x0000328C File Offset: 0x0000148C
		public virtual List<ResKey> GetAllReferences()
		{
			return new List<ResKey>();
		}

		// Token: 0x0600006D RID: 109 RVA: 0x00003293 File Offset: 0x00001493
		public virtual byte[] GetData()
		{
			if (this.data == null)
			{
				this.data = this.Serialize();
			}
			return this.data;
		}

		// Token: 0x0600006E RID: 110 RVA: 0x000032AF File Offset: 0x000014AF
		public virtual void SetData(byte[] data)
		{
			this.data = data;
			this.UnSerialize();
		}

		// Token: 0x0600006F RID: 111 RVA: 0x000032BE File Offset: 0x000014BE
		public virtual void SaveToFile(string fileName)
		{
			if (this.data == null)
			{
				return;
			}
			FileStream fileStream = new FileStream(fileName, FileMode.OpenOrCreate);
			fileStream.Write(this.data, 0, this.data.Length);
			fileStream.Close();
		}

		// Token: 0x06000070 RID: 112
		public abstract void UnSerialize();

		// Token: 0x06000071 RID: 113
		public abstract byte[] Serialize();

		// Token: 0x06000072 RID: 114 RVA: 0x000032EA File Offset: 0x000014EA
		public void ReadData()
		{
		}

		// Token: 0x06000073 RID: 115 RVA: 0x0000D438 File Offset: 0x0000B638
		public static void CopyStream(Stream readStream, Stream writeStream, bool fromStart)
		{
			if (fromStart)
			{
				readStream.Seek(0L, SeekOrigin.Begin);
			}
			int count = 256;
			byte[] buffer = new byte[256];
			for (int i = readStream.Read(buffer, 0, 256); i > 0; i = readStream.Read(buffer, 0, count))
			{
				writeStream.Write(buffer, 0, i);
			}
		}

		// Token: 0x06000074 RID: 116 RVA: 0x0000D494 File Offset: 0x0000B694
		public void ReadData(BinaryReader reader)
		{
			byte b = reader.ReadByte();
			byte b2 = reader.ReadByte();
			bool flag = false;
			DBPF dbpf = this.Package as DBPF;
			if ((this.unknownInt & 65535) != 0 && dbpf.MajorVersion == 2 && dbpf.MinorVersion == 1 && b != 80 && b2 != 251)
			{
				this.compressed = true;
				DeflateStream deflateStream = new DeflateStream(reader.BaseStream, CompressionMode.Decompress, true);
				this.data = new byte[this.uncompressedSize];
				deflateStream.Read(this.data, 0, this.data.Length);
				deflateStream.Dispose();
				flag = true;
			}
			if (!flag && ((b == 16 && b2 == 251) || (b == 80 && b2 == 251)))
			{
				byte[] array = reader.ReadBytes(3);
				if ((long)(((int)array[0] << 16) + ((int)array[1] << 8) + (int)array[2]) == (long)((ulong)this.uncompressedSize))
				{
					this.compressed = true;
					this.data = PackageUtil.Uncompress(reader, this.uncompressedSize, this.compressedSize);
				}
				else
				{
					reader.BaseStream.Position = 0L;
					this.data = reader.ReadBytes((int)this.uncompressedSize);
				}
			}
			else if (!flag)
			{
				if (reader.BaseStream.Length > 9L)
				{
					reader.BaseStream.Position = 4L;
					b = reader.ReadByte();
					b2 = reader.ReadByte();
					if (b == 16 && b2 == 251)
					{
						reader.BaseStream.Position = 0L;
						uint num = reader.ReadUInt32();
						reader.ReadBytes(2);
						byte[] array2 = reader.ReadBytes(3);
						uint num2 = (uint)(((int)array2[0] << 16) + ((int)array2[1] << 8) + (int)array2[2]);
						if (num < num2)
						{
							this.compressed = true;
							this.uncompressedSize = num2;
							this.compressedSize = num;
							this.data = PackageUtil.Uncompress(reader, this.uncompressedSize, this.compressedSize);
						}
						else
						{
							reader.BaseStream.Position = 0L;
							this.data = reader.ReadBytes((int)this.uncompressedSize);
						}
					}
					else
					{
						reader.BaseStream.Position = 0L;
						this.data = reader.ReadBytes((int)this.uncompressedSize);
					}
				}
				else
				{
					reader.BaseStream.Position = 0L;
					this.data = reader.ReadBytes((int)this.uncompressedSize);
				}
			}
			this.UnSerialize();
			this.IsUnpacked = true;
		}

		// Token: 0x06000075 RID: 117 RVA: 0x000032EC File Offset: 0x000014EC
		public void Write(BinaryWriter writer)
		{
			writer.Write(this.Serialize());
		}

		// Token: 0x06000076 RID: 118 RVA: 0x0000D714 File Offset: 0x0000B914
		public override string ToString()
		{
			return string.Concat(new string[]
			{
				"0x",
				this.typeId.ToString("X"),
				" | ",
				this.groupId.ToString("X8"),
				" | ",
				this.instanceId.ToString("X8"),
				" | ",
				this.secondInstanceId.ToString("X8"),
				" | ",
				this.location.ToString("X8"),
				" | ",
				this.unknown.ToString("X8"),
				" | ",
				this.compressedSize.ToString("X8"),
				" | ",
				this.uncompressedSize.ToString("X8"),
				" | ",
				this.unknownInt.ToString("X8")
			});
		}

		// Token: 0x06000077 RID: 119 RVA: 0x0000D82C File Offset: 0x0000BA2C
		public virtual object Clone()
		{
			byte[] array = this.Serialize();
			DBPFEntry instance = DBPFFactory.GetInstance(this.typeId, this.gameVersion);
			instance.data = array;
			instance.UnSerialize();
			instance.IsUnpacked = true;
			instance.TypeID = this.TypeID;
			instance.GroupID = this.GroupID;
			instance.InstanceID = this.InstanceID;
			instance.SecondInstanceID = this.SecondInstanceID;
			instance.IsCompressed = this.IsCompressed;
			instance.compressedSize = this.compressedSize;
			instance.uncompressedSize = this.uncompressedSize;
			instance.unknown = this.unknown;
			instance.unknownInt = this.unknownInt;
			instance.location = this.location;
			instance.gameVersion = this.gameVersion;
			return instance;
		}

		// Token: 0x04000027 RID: 39
		protected PackagedFile _packagedFile;

		// Token: 0x04000028 RID: 40
		protected uint typeId;

		// Token: 0x04000029 RID: 41
		protected int groupId;

		// Token: 0x0400002A RID: 42
		protected int instanceId;

		// Token: 0x0400002B RID: 43
		protected int secondInstanceId;

		// Token: 0x0400002C RID: 44
		public uint location;

		// Token: 0x0400002D RID: 45
		public byte unknown;

		// Token: 0x0400002E RID: 46
		public uint compressedSize;

		// Token: 0x0400002F RID: 47
		public uint uncompressedSize;

		// Token: 0x04000030 RID: 48
		public int unknownInt;

		// Token: 0x04000031 RID: 49
		protected byte[] data;

		// Token: 0x04000032 RID: 50
		public bool compressed;

		// Token: 0x04000033 RID: 51
		public string fileExtension = ".txt";

		// Token: 0x04000034 RID: 52
		public GameVersion gameVersion;
	}
}
