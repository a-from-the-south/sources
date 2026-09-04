using System;
using System.ComponentModel;
using System.Text.RegularExpressions;

namespace Sims3WorkshopSDK
{
	// Token: 0x02000006 RID: 6
	public class ResKey
	{
		// Token: 0x17000005 RID: 5
		// (get) Token: 0x06000017 RID: 23 RVA: 0x000020E1 File Offset: 0x000002E1
		// (set) Token: 0x06000018 RID: 24 RVA: 0x000020E9 File Offset: 0x000002E9
		public uint TypeId
		{
			get
			{
				return this._typeId;
			}
			set
			{
				this._typeId = value;
				this.regenerateHashCode();
			}
		}

		// Token: 0x17000006 RID: 6
		// (get) Token: 0x06000019 RID: 25 RVA: 0x000020F8 File Offset: 0x000002F8
		// (set) Token: 0x0600001A RID: 26 RVA: 0x00002100 File Offset: 0x00000300
		public int GroupId
		{
			get
			{
				return this._groupId;
			}
			set
			{
				this._groupId = value;
				this.regenerateHashCode();
			}
		}

		// Token: 0x17000007 RID: 7
		// (get) Token: 0x0600001B RID: 27 RVA: 0x0000210F File Offset: 0x0000030F
		// (set) Token: 0x0600001C RID: 28 RVA: 0x00002117 File Offset: 0x00000317
		public int InstanceId
		{
			get
			{
				return this._instanceId;
			}
			set
			{
				this._instanceId = value;
				this.regenerateHashCode();
			}
		}

		// Token: 0x17000008 RID: 8
		// (get) Token: 0x0600001D RID: 29 RVA: 0x00002126 File Offset: 0x00000326
		// (set) Token: 0x0600001E RID: 30 RVA: 0x0000212E File Offset: 0x0000032E
		public int SecondInstanceId
		{
			get
			{
				return this._secondInstanceId;
			}
			set
			{
				this._secondInstanceId = value;
				this.regenerateHashCode();
			}
		}

		// Token: 0x17000009 RID: 9
		// (get) Token: 0x0600001F RID: 31 RVA: 0x0000213D File Offset: 0x0000033D
		// (set) Token: 0x06000020 RID: 32 RVA: 0x00002145 File Offset: 0x00000345
		public string FileName { get; set; }

		// Token: 0x1700000A RID: 10
		// (get) Token: 0x06000021 RID: 33 RVA: 0x0000214E File Offset: 0x0000034E
		// (set) Token: 0x06000022 RID: 34 RVA: 0x00002156 File Offset: 0x00000356
		public GameVersion Game { get; set; }

		// Token: 0x1700000B RID: 11
		// (get) Token: 0x06000023 RID: 35 RVA: 0x0000215F File Offset: 0x0000035F
		// (set) Token: 0x06000024 RID: 36 RVA: 0x00002167 File Offset: 0x00000367
		public DBPFType Type
		{
			get
			{
				return (DBPFType)this.TypeId;
			}
			set
			{
				this.TypeId = (uint)value;
			}
		}

		// Token: 0x06000025 RID: 37 RVA: 0x00002170 File Offset: 0x00000370
		public ResKey(GameVersion game)
		{
			this.Game = game;
		}

		// Token: 0x06000026 RID: 38 RVA: 0x0000217F File Offset: 0x0000037F
		public ResKey() : this(GameVersion.Sims3)
		{
		}

		// Token: 0x06000027 RID: 39 RVA: 0x00002188 File Offset: 0x00000388
		public ResKey(string key) : this()
		{
			this.SetFromString(key);
		}

		// Token: 0x06000028 RID: 40 RVA: 0x00002197 File Offset: 0x00000397
		public ResKey(string key, GameVersion gameVersion) : this()
		{
			this.Game = gameVersion;
			this.SetFromString(key);
		}

		// Token: 0x06000029 RID: 41 RVA: 0x000021AD File Offset: 0x000003AD
		public ResKey(uint typeId) : this((DBPFType)typeId, 0, 0, 0, null)
		{
		}

		// Token: 0x0600002A RID: 42 RVA: 0x000021AD File Offset: 0x000003AD
		public ResKey(DBPFType typeId) : this(typeId, 0, 0, 0, null)
		{
		}

		// Token: 0x0600002B RID: 43 RVA: 0x000021BA File Offset: 0x000003BA
		public ResKey(DBPFType typeId, GameVersion game) : this((uint)typeId, 0, 0, 0, null, game)
		{
		}

		// Token: 0x0600002C RID: 44 RVA: 0x000021C8 File Offset: 0x000003C8
		public ResKey(uint typeId, int groupId, int instanceId, int secondInstanceId) : this((DBPFType)typeId, groupId, instanceId, secondInstanceId, null)
		{
		}

		// Token: 0x0600002D RID: 45 RVA: 0x000021C8 File Offset: 0x000003C8
		public ResKey(DBPFType typeId, int groupId, int instanceId, int secondInstanceId) : this(typeId, groupId, instanceId, secondInstanceId, null)
		{
		}

		// Token: 0x0600002E RID: 46 RVA: 0x000021D6 File Offset: 0x000003D6
		public ResKey(DBPFType typeId, int groupId, int instanceId, int secondInstanceId, string fileName) : this((uint)typeId, groupId, instanceId, secondInstanceId, fileName, GameVersion.Sims3)
		{
		}

		// Token: 0x0600002F RID: 47 RVA: 0x000021E6 File Offset: 0x000003E6
		public ResKey(uint typeId, int groupId, int instanceId, int secondInstanceId, string fileName, GameVersion game) : this()
		{
			this._typeId = typeId;
			this._groupId = groupId;
			this._instanceId = instanceId;
			this._secondInstanceId = secondInstanceId;
			this.FileName = fileName;
			this.Game = game;
			this.regenerateHashCode();
		}

		// Token: 0x06000030 RID: 48 RVA: 0x00003638 File Offset: 0x00001838
		private void regenerateHashCode()
		{
			int num = this.TypeId.GetHashCode();
			num = (num * 397 ^ this.GroupId);
			num = (num * 397 ^ this.InstanceId);
			num = (num * 397 ^ this.SecondInstanceId);
			this.hashCode = num;
		}

		// Token: 0x06000031 RID: 49 RVA: 0x00003688 File Offset: 0x00001888
		public void SetFromString(string key)
		{
			Match match = new Regex("(key)?:?([a-f0-9A-F]{8}):?([a-f0-9A-F]{8}):?([a-f0-9A-F]{8})([a-f0-9A-F]{8})").Match(key);
			if (!match.Success)
			{
				throw new Exception("Invalid ResKey: " + key);
			}
			this._typeId = Convert.ToUInt32("0x" + match.Groups[2].Value, 16);
			this._groupId = Convert.ToInt32("0x" + match.Groups[3].Value, 16);
			this._instanceId = Convert.ToInt32("0x" + match.Groups[4].Value, 16);
			this._secondInstanceId = Convert.ToInt32("0x" + match.Groups[5].Value, 16);
			this.regenerateHashCode();
		}

		// Token: 0x06000032 RID: 50 RVA: 0x00002221 File Offset: 0x00000421
		public void SetFromResKey(ResKey key)
		{
			this.SetFromResKey(key, false);
		}

		// Token: 0x06000033 RID: 51 RVA: 0x0000222B File Offset: 0x0000042B
		public void SetFromResKey(ResKey key, bool keepType)
		{
			if (!keepType)
			{
				this._typeId = key.TypeId;
			}
			this._groupId = key.GroupId;
			this._instanceId = key.InstanceId;
			this._secondInstanceId = key.SecondInstanceId;
			this.regenerateHashCode();
		}

		// Token: 0x06000034 RID: 52 RVA: 0x00002266 File Offset: 0x00000466
		public static bool IsValid(string key)
		{
			return new Regex("key:([a-f0-9A-F]{8}):([a-f0-9A-F]{8}):([a-f0-9A-F]{8})([a-f0-9A-F]{8})").Match(key).Success;
		}

		// Token: 0x06000035 RID: 53 RVA: 0x00003768 File Offset: 0x00001968
		public ResKey CloneUnique(int seed)
		{
			if (seed < 1)
			{
				seed = (int)DateTime.Now.Ticks;
			}
			ResKey resKey = this.Clone();
			Random random = new Random(seed);
			resKey.InstanceId = random.Next();
			resKey.SecondInstanceId = random.Next();
			return resKey;
		}

		// Token: 0x06000036 RID: 54 RVA: 0x0000227D File Offset: 0x0000047D
		public bool IsType(DBPFType type)
		{
			return this.TypeId == (uint)type;
		}

		// Token: 0x06000037 RID: 55 RVA: 0x000037B0 File Offset: 0x000019B0
		public string AsString()
		{
			return string.Concat(new string[]
			{
				"key:",
				this.TypeId.ToString("X8"),
				":",
				this.GroupId.ToString("X8"),
				":",
				this.InstanceId.ToString("X8"),
				this.SecondInstanceId.ToString("X8")
			}).ToLower();
		}

		// Token: 0x06000038 RID: 56 RVA: 0x00003840 File Offset: 0x00001A40
		public override string ToString()
		{
			return ((DBPFType)this.TypeId).ToString() + " - " + this.AsString();
		}

		// Token: 0x06000039 RID: 57 RVA: 0x00002288 File Offset: 0x00000488
		public override bool Equals(object obj)
		{
			return obj != null && (this == obj || (obj is ResKey && this.Equals((ResKey)obj)));
		}

		// Token: 0x0600003A RID: 58 RVA: 0x00003874 File Offset: 0x00001A74
		public bool Equals(ResKey other)
		{
			return other != null && (this == other || (other.TypeId == this.TypeId && other.GroupId == this.GroupId && other.InstanceId == this.InstanceId && other.SecondInstanceId == this.SecondInstanceId));
		}

		// Token: 0x0600003B RID: 59 RVA: 0x000022AB File Offset: 0x000004AB
		public override int GetHashCode()
		{
			if (this.hashCode == 0 && (this._groupId != 0 || this._typeId != 0U || this._instanceId != 0 || this._secondInstanceId != 0))
			{
				throw new Exception("Hashcode was zero");
			}
			return this.hashCode;
		}

		// Token: 0x0600003C RID: 60 RVA: 0x000022E6 File Offset: 0x000004E6
		public ResKey Clone()
		{
			return (ResKey)base.MemberwiseClone();
		}

		// Token: 0x0600003D RID: 61 RVA: 0x000022F3 File Offset: 0x000004F3
		public ResKey ReplaceType(uint to)
		{
			return this.ReplaceType((DBPFType)to);
		}

		// Token: 0x0600003E RID: 62 RVA: 0x000022FC File Offset: 0x000004FC
		public ResKey ReplaceType(DBPFType to)
		{
			ResKey resKey = this.Clone();
			resKey.TypeId = (uint)to;
			return resKey;
		}

		// Token: 0x0600003F RID: 63 RVA: 0x0000230B File Offset: 0x0000050B
		public ResKey ReplaceInstanceId(int to)
		{
			ResKey resKey = this.Clone();
			resKey.InstanceId = to;
			return resKey;
		}

		// Token: 0x06000040 RID: 64 RVA: 0x0000231A File Offset: 0x0000051A
		public ResKey ReplaceSecondInstanceId(int to)
		{
			ResKey resKey = this.Clone();
			resKey.SecondInstanceId = to;
			return resKey;
		}

		// Token: 0x06000041 RID: 65 RVA: 0x00002329 File Offset: 0x00000529
		public ResKey ReplaceGroup(int to)
		{
			ResKey resKey = this.Clone();
			resKey.GroupId = to;
			return resKey;
		}

		// Token: 0x0400000E RID: 14
		private uint _typeId;

		// Token: 0x0400000F RID: 15
		[TypeConverter(typeof(IntTypeConverter))]
		private int _groupId;

		// Token: 0x04000010 RID: 16
		[TypeConverter(typeof(IntTypeConverter))]
		private int _instanceId;

		// Token: 0x04000011 RID: 17
		[TypeConverter(typeof(IntTypeConverter))]
		private int _secondInstanceId;

		// Token: 0x04000014 RID: 20
		public uint location;

		// Token: 0x04000015 RID: 21
		public uint compressedSize;

		// Token: 0x04000016 RID: 22
		public uint uncompressedSize;

		// Token: 0x04000017 RID: 23
		public int unknownInt;

		// Token: 0x04000018 RID: 24
		private int hashCode;
	}
}
