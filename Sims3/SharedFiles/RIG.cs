using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using Sims3WorkshopSDK;
using Sims3WorkshopSDK.Classes;

namespace Package.SharedFiles
{
	// Token: 0x020000AE RID: 174
	public class RIG : DBPFEntry
	{
		// Token: 0x170002EF RID: 751
		// (get) Token: 0x060008C7 RID: 2247 RVA: 0x00007042 File Offset: 0x00005242
		// (set) Token: 0x060008C8 RID: 2248 RVA: 0x0000704A File Offset: 0x0000524A
		[TypeConverter(typeof(IntTypeConverter))]
		private uint Type { get; set; }

		// Token: 0x170002F0 RID: 752
		// (get) Token: 0x060008C9 RID: 2249 RVA: 0x00007053 File Offset: 0x00005253
		// (set) Token: 0x060008CA RID: 2250 RVA: 0x0000705B File Offset: 0x0000525B
		[TypeConverter(typeof(IntTypeConverter))]
		public uint MajorVersion { get; set; }

		// Token: 0x170002F1 RID: 753
		// (get) Token: 0x060008CB RID: 2251 RVA: 0x00007064 File Offset: 0x00005264
		// (set) Token: 0x060008CC RID: 2252 RVA: 0x0000706C File Offset: 0x0000526C
		[TypeConverter(typeof(IntTypeConverter))]
		private uint MinorVersion { get; set; }

		// Token: 0x170002F2 RID: 754
		// (get) Token: 0x060008CD RID: 2253 RVA: 0x00007075 File Offset: 0x00005275
		// (set) Token: 0x060008CE RID: 2254 RVA: 0x0000707D File Offset: 0x0000527D
		[Browsable(false)]
		public bool Encrypted { get; set; }

		// Token: 0x170002F3 RID: 755
		// (get) Token: 0x060008CF RID: 2255 RVA: 0x00007086 File Offset: 0x00005286
		// (set) Token: 0x060008D0 RID: 2256 RVA: 0x0000708E File Offset: 0x0000528E
		[Browsable(false)]
		public bool HasIKInfo { get; set; }

		// Token: 0x170002F4 RID: 756
		// (get) Token: 0x060008D1 RID: 2257 RVA: 0x00007097 File Offset: 0x00005297
		// (set) Token: 0x060008D2 RID: 2258 RVA: 0x0000709F File Offset: 0x0000529F
		public List<RIG.IkChainEntry> IkChainEntries { get; set; }

		// Token: 0x170002F5 RID: 757
		// (get) Token: 0x060008D3 RID: 2259 RVA: 0x000070A8 File Offset: 0x000052A8
		// (set) Token: 0x060008D4 RID: 2260 RVA: 0x000070B0 File Offset: 0x000052B0
		public List<RIG.Bone> Bones { get; set; }

		// Token: 0x170002F6 RID: 758
		// (get) Token: 0x060008D5 RID: 2261 RVA: 0x000070B9 File Offset: 0x000052B9
		// (set) Token: 0x060008D6 RID: 2262 RVA: 0x000070C1 File Offset: 0x000052C1
		public string SkeletonName { get; set; }

		// Token: 0x060008D7 RID: 2263 RVA: 0x000070CA File Offset: 0x000052CA
		public RIG()
		{
			this.typeId = 2393838558U;
			this.Encrypted = true;
			this.Bones = new List<RIG.Bone>();
			this.IkChainEntries = new List<RIG.IkChainEntry>();
		}

		// Token: 0x060008D8 RID: 2264 RVA: 0x00003309 File Offset: 0x00001509
		public override int ReplaceReferences(ResKey from, ResKey to)
		{
			return 0;
		}

		// Token: 0x060008D9 RID: 2265 RVA: 0x0002C3A4 File Offset: 0x0002A5A4
		public override void UnSerialize()
		{
			this.IkChainEntries.Clear();
			this.Bones.Clear();
			this._grannyData = this.data;
			MemoryStream memoryStream = new MemoryStream(this.data);
			BinaryReader binaryReader = new BinaryReader(memoryStream);
			this.Type = binaryReader.ReadUInt32();
			if (this.Type == 2393838558U)
			{
				this.HasIKInfo = true;
				binaryReader.ReadUInt32();
				int count = binaryReader.ReadInt32();
				binaryReader.ReadInt32();
				binaryReader.ReadUInt32();
				for (int i = 0; i < 4; i++)
				{
					binaryReader.ReadInt32();
				}
				for (int j = 0; j < 4; j++)
				{
					binaryReader.ReadInt32();
				}
				this._grannyData = binaryReader.ReadBytes(count);
			}
			else if (this.Type == 4U || this.Type == 3U)
			{
				this.Encrypted = false;
				this.MajorVersion = this.Type;
				this.MinorVersion = binaryReader.ReadUInt32();
				uint num = binaryReader.ReadUInt32();
				int num2 = 0;
				while ((long)num2 < (long)((ulong)num))
				{
					RIG.Bone bone = new RIG.Bone(num2);
					bone.UnSerialize(binaryReader);
					this.Bones.Add(bone);
					num2++;
				}
				if (this.Type >= 4U)
				{
					int length = binaryReader.ReadInt32();
					this.SkeletonName = PackageUtil.ReadString(binaryReader, length);
				}
				uint majorVersion = this.MajorVersion;
				uint num3 = binaryReader.ReadUInt32();
				this.HasIKInfo = (num3 > 0U);
				int num4 = 0;
				while ((long)num4 < (long)((ulong)num3))
				{
					RIG.IkChainEntry ikChainEntry = new RIG.IkChainEntry(this.MajorVersion);
					ikChainEntry.UnSerialize(binaryReader);
					this.IkChainEntries.Add(ikChainEntry);
					num4++;
				}
			}
			memoryStream.Dispose();
			binaryReader.Close();
		}

		// Token: 0x060008DA RID: 2266 RVA: 0x0002C548 File Offset: 0x0002A748
		public override byte[] Serialize()
		{
			if (this.MajorVersion != 3U && this.MajorVersion != 4U && this.Encrypted)
			{
				return this.data;
			}
			MemoryStream memoryStream = new MemoryStream();
			BinaryWriter binaryWriter = new BinaryWriter(memoryStream);
			binaryWriter.Write(this.MajorVersion);
			binaryWriter.Write(this.MinorVersion);
			binaryWriter.Write(this.Bones.Count);
			foreach (RIG.Bone bone in this.Bones)
			{
				bone.Serialize(binaryWriter);
			}
			if (this.Type >= 4U)
			{
				binaryWriter.Write(this.SkeletonName.Length);
				for (int i = 0; i < this.SkeletonName.Length; i++)
				{
					binaryWriter.Write((byte)this.SkeletonName[i]);
				}
			}
			uint majorVersion = this.MajorVersion;
			binaryWriter.Write(this.IkChainEntries.Count);
			foreach (RIG.IkChainEntry ikChainEntry in this.IkChainEntries)
			{
				ikChainEntry.Serialize(binaryWriter);
			}
			memoryStream.Position = 0L;
			byte[] array = new byte[memoryStream.Length];
			memoryStream.Read(array, 0, (int)memoryStream.Length);
			memoryStream.Dispose();
			binaryWriter.Close();
			return array;
		}

		// Token: 0x060008DB RID: 2267 RVA: 0x000070FA File Offset: 0x000052FA
		public byte[] GetGrannyData()
		{
			return this._grannyData;
		}

		// Token: 0x060008DC RID: 2268 RVA: 0x0002C6CC File Offset: 0x0002A8CC
		public bool hasBone(string name)
		{
			using (List<RIG.Bone>.Enumerator enumerator = this.Bones.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					if (enumerator.Current.BoneName.ToLower() == name.ToLower())
					{
						return true;
					}
				}
			}
			return false;
		}

		// Token: 0x060008DD RID: 2269 RVA: 0x0002C738 File Offset: 0x0002A938
		public RIG.Bone getBone(string name)
		{
			foreach (RIG.Bone bone in this.Bones)
			{
				if (bone.BoneName.ToLower() == name.ToLower())
				{
					return bone;
				}
			}
			return null;
		}

		// Token: 0x060008DE RID: 2270 RVA: 0x0002C7A4 File Offset: 0x0002A9A4
		public RIG.Bone getBoneByHash(uint hash)
		{
			foreach (RIG.Bone bone in this.Bones)
			{
				if (bone.BoneHash == hash)
				{
					return bone;
				}
			}
			return null;
		}

		// Token: 0x060008DF RID: 2271 RVA: 0x00007102 File Offset: 0x00005302
		public override string ToString()
		{
			return "RIG";
		}

		// Token: 0x04000448 RID: 1096
		[Browsable(false)]
		protected byte[] _grannyData;

		// Token: 0x0200019C RID: 412
		public class Bone
		{
			// Token: 0x170004BC RID: 1212
			// (get) Token: 0x06000F4E RID: 3918 RVA: 0x0000AA76 File Offset: 0x00008C76
			// (set) Token: 0x06000F4F RID: 3919 RVA: 0x0000AA7E File Offset: 0x00008C7E
			public float[] Position { get; set; }

			// Token: 0x170004BD RID: 1213
			// (get) Token: 0x06000F50 RID: 3920 RVA: 0x0000AA87 File Offset: 0x00008C87
			// (set) Token: 0x06000F51 RID: 3921 RVA: 0x0000AA8F File Offset: 0x00008C8F
			public float[] Quaternion { get; set; }

			// Token: 0x170004BE RID: 1214
			// (get) Token: 0x06000F52 RID: 3922 RVA: 0x0000AA98 File Offset: 0x00008C98
			// (set) Token: 0x06000F53 RID: 3923 RVA: 0x0000AAA0 File Offset: 0x00008CA0
			public float[] Scaling { get; set; }

			// Token: 0x170004BF RID: 1215
			// (get) Token: 0x06000F54 RID: 3924 RVA: 0x0000AAA9 File Offset: 0x00008CA9
			// (set) Token: 0x06000F55 RID: 3925 RVA: 0x0000AAB4 File Offset: 0x00008CB4
			public float PositionY
			{
				get
				{
					return -this.Position[2];
				}
				set
				{
					if (this.PositionY != value)
					{
						this.Position[2] = -value;
					}
				}
			}

			// Token: 0x170004C0 RID: 1216
			// (get) Token: 0x06000F56 RID: 3926 RVA: 0x0000AAC9 File Offset: 0x00008CC9
			// (set) Token: 0x06000F57 RID: 3927 RVA: 0x0000AAD3 File Offset: 0x00008CD3
			public float PositionX
			{
				get
				{
					return this.Position[0];
				}
				set
				{
					if (this.Position[0] != value)
					{
						this.Position[0] = value;
					}
				}
			}

			// Token: 0x170004C1 RID: 1217
			// (get) Token: 0x06000F58 RID: 3928 RVA: 0x0000AAE9 File Offset: 0x00008CE9
			// (set) Token: 0x06000F59 RID: 3929 RVA: 0x0000AAF1 File Offset: 0x00008CF1
			public string BoneName
			{
				get
				{
					return this._name;
				}
				set
				{
					this._name = value;
					this.BoneHash = FNV32.GetHash(this._name);
				}
			}

			// Token: 0x170004C2 RID: 1218
			// (get) Token: 0x06000F5A RID: 3930 RVA: 0x0000AB0B File Offset: 0x00008D0B
			// (set) Token: 0x06000F5B RID: 3931 RVA: 0x0000AB13 File Offset: 0x00008D13
			[TypeConverter(typeof(IntTypeConverter))]
			public uint unknown { get; set; }

			// Token: 0x170004C3 RID: 1219
			// (get) Token: 0x06000F5C RID: 3932 RVA: 0x0000AB1C File Offset: 0x00008D1C
			// (set) Token: 0x06000F5D RID: 3933 RVA: 0x0000AB24 File Offset: 0x00008D24
			[TypeConverter(typeof(IntTypeConverter))]
			public int ParentIndex { get; set; }

			// Token: 0x170004C4 RID: 1220
			// (get) Token: 0x06000F5E RID: 3934 RVA: 0x0000AB2D File Offset: 0x00008D2D
			// (set) Token: 0x06000F5F RID: 3935 RVA: 0x0000AB35 File Offset: 0x00008D35
			[TypeConverter(typeof(IntTypeConverter))]
			public uint BoneHash { get; set; }

			// Token: 0x170004C5 RID: 1221
			// (get) Token: 0x06000F60 RID: 3936 RVA: 0x0000AB3E File Offset: 0x00008D3E
			// (set) Token: 0x06000F61 RID: 3937 RVA: 0x0000AB46 File Offset: 0x00008D46
			[TypeConverter(typeof(IntTypeConverter))]
			public uint Flags { get; set; }

			// Token: 0x06000F62 RID: 3938 RVA: 0x0000AB4F File Offset: 0x00008D4F
			public Bone(int boneIndex)
			{
				this.Position = new float[3];
				this.Quaternion = new float[4];
				this.Scaling = new float[3];
				this.boneIndex = boneIndex;
			}

			// Token: 0x06000F63 RID: 3939 RVA: 0x00043558 File Offset: 0x00041758
			public Bone(string name, float[] pos, float[] quat, float[] scale, uint flags, int parent)
			{
				this.Position = new float[]
				{
					pos[0],
					pos[1],
					pos[2]
				};
				this.Quaternion = new float[]
				{
					quat[0],
					quat[1],
					quat[2],
					quat[3]
				};
				this.Scaling = new float[]
				{
					scale[0],
					scale[1],
					scale[2]
				};
				this.Flags = flags;
				this.BoneName = name;
				this.ParentIndex = parent;
			}

			// Token: 0x06000F64 RID: 3940 RVA: 0x000435E8 File Offset: 0x000417E8
			public RIG.Bone Clone()
			{
				RIG.Bone bone = new RIG.Bone(this.boneIndex);
				bone.Position[0] = this.Position[0];
				bone.Position[1] = this.Position[1];
				bone.Position[2] = this.Position[2];
				bone.Quaternion[0] = this.Quaternion[0];
				bone.Quaternion[1] = this.Quaternion[1];
				bone.Quaternion[2] = this.Quaternion[2];
				bone.Quaternion[3] = this.Quaternion[3];
				bone.Scaling[0] = this.Scaling[0];
				bone.Scaling[1] = this.Scaling[1];
				bone.Scaling[2] = this.Scaling[2];
				bone.BoneName = this.BoneName;
				bone.unknown = this.unknown;
				bone.ParentIndex = this.ParentIndex;
				bone.Flags = this.Flags;
				return bone;
			}

			// Token: 0x06000F65 RID: 3941 RVA: 0x000436D0 File Offset: 0x000418D0
			public void UnSerialize(BinaryReader r)
			{
				this.Position[0] = r.ReadSingle();
				this.Position[1] = r.ReadSingle();
				this.Position[2] = r.ReadSingle();
				this.Quaternion[0] = r.ReadSingle();
				this.Quaternion[1] = r.ReadSingle();
				this.Quaternion[2] = r.ReadSingle();
				this.Quaternion[3] = r.ReadSingle();
				this.Scaling[0] = r.ReadSingle();
				this.Scaling[1] = r.ReadSingle();
				this.Scaling[2] = r.ReadSingle();
				int length = r.ReadInt32();
				this.BoneName = PackageUtil.ReadString(r, length);
				this.unknown = r.ReadUInt32();
				this.ParentIndex = r.ReadInt32();
				this.BoneHash = r.ReadUInt32();
				this.Flags = r.ReadUInt32();
			}

			// Token: 0x06000F66 RID: 3942 RVA: 0x000437B0 File Offset: 0x000419B0
			public void Serialize(BinaryWriter w)
			{
				w.Write(this.Position[0]);
				w.Write(this.Position[1]);
				w.Write(this.Position[2]);
				w.Write(this.Quaternion[0]);
				w.Write(this.Quaternion[1]);
				w.Write(this.Quaternion[2]);
				w.Write(this.Quaternion[3]);
				w.Write(this.Scaling[0]);
				w.Write(this.Scaling[1]);
				w.Write(this.Scaling[2]);
				w.Write(this.BoneName.Length);
				for (int i = 0; i < this.BoneName.Length; i++)
				{
					w.Write((byte)this.BoneName[i]);
				}
				w.Write(this.unknown);
				w.Write(this.ParentIndex);
				w.Write(this.BoneHash);
				w.Write(this.Flags);
			}

			// Token: 0x06000F67 RID: 3943 RVA: 0x0000AB82 File Offset: 0x00008D82
			public override string ToString()
			{
				return "Bone entry";
			}

			// Token: 0x04000C84 RID: 3204
			private string _name;

			// Token: 0x04000C89 RID: 3209
			public int boneIndex;
		}

		// Token: 0x0200019D RID: 413
		public class IkChainEntry
		{
			// Token: 0x170004C6 RID: 1222
			// (get) Token: 0x06000F68 RID: 3944 RVA: 0x0000AB89 File Offset: 0x00008D89
			// (set) Token: 0x06000F69 RID: 3945 RVA: 0x0000AB91 File Offset: 0x00008D91
			[TypeConverter(typeof(IntTypeConverter))]
			public List<int> BoneIndicies { get; set; }

			// Token: 0x170004C7 RID: 1223
			// (get) Token: 0x06000F6A RID: 3946 RVA: 0x0000AB9A File Offset: 0x00008D9A
			// (set) Token: 0x06000F6B RID: 3947 RVA: 0x0000ABA2 File Offset: 0x00008DA2
			[TypeConverter(typeof(IntTypeConverter))]
			public List<int> InfoNode { get; set; }

			// Token: 0x170004C8 RID: 1224
			// (get) Token: 0x06000F6C RID: 3948 RVA: 0x0000ABAB File Offset: 0x00008DAB
			// (set) Token: 0x06000F6D RID: 3949 RVA: 0x0000ABB3 File Offset: 0x00008DB3
			[TypeConverter(typeof(IntTypeConverter))]
			public int PoleVector { get; set; }

			// Token: 0x170004C9 RID: 1225
			// (get) Token: 0x06000F6E RID: 3950 RVA: 0x0000ABBC File Offset: 0x00008DBC
			// (set) Token: 0x06000F6F RID: 3951 RVA: 0x0000ABC4 File Offset: 0x00008DC4
			[TypeConverter(typeof(IntTypeConverter))]
			public int SlotInfo { get; set; }

			// Token: 0x170004CA RID: 1226
			// (get) Token: 0x06000F70 RID: 3952 RVA: 0x0000ABCD File Offset: 0x00008DCD
			// (set) Token: 0x06000F71 RID: 3953 RVA: 0x0000ABD5 File Offset: 0x00008DD5
			[TypeConverter(typeof(IntTypeConverter))]
			public int SlotOffset { get; set; }

			// Token: 0x170004CB RID: 1227
			// (get) Token: 0x06000F72 RID: 3954 RVA: 0x0000ABDE File Offset: 0x00008DDE
			// (set) Token: 0x06000F73 RID: 3955 RVA: 0x0000ABE6 File Offset: 0x00008DE6
			[TypeConverter(typeof(IntTypeConverter))]
			public int Root { get; set; }

			// Token: 0x170004CC RID: 1228
			// (get) Token: 0x06000F74 RID: 3956 RVA: 0x0000ABEF File Offset: 0x00008DEF
			// (set) Token: 0x06000F75 RID: 3957 RVA: 0x0000ABF7 File Offset: 0x00008DF7
			[TypeConverter(typeof(IntTypeConverter))]
			private uint MajorVersion { get; set; }

			// Token: 0x06000F76 RID: 3958 RVA: 0x0000AC00 File Offset: 0x00008E00
			public IkChainEntry(uint majorVersion)
			{
				this.BoneIndicies = new List<int>();
				this.InfoNode = new List<int>();
				this.MajorVersion = majorVersion;
			}

			// Token: 0x06000F77 RID: 3959 RVA: 0x000438B4 File Offset: 0x00041AB4
			public void UnSerialize(BinaryReader r)
			{
				this.BoneIndicies.Clear();
				this.InfoNode.Clear();
				int num = r.ReadInt32();
				for (int i = 0; i < num; i++)
				{
					this.BoneIndicies.Add(r.ReadInt32());
				}
				if (this.MajorVersion >= 4U)
				{
					for (int j = 0; j < 11; j++)
					{
						this.InfoNode.Add(r.ReadInt32());
					}
				}
				this.PoleVector = r.ReadInt32();
				if (this.MajorVersion >= 4U)
				{
					this.SlotInfo = r.ReadInt32();
				}
				this.SlotOffset = r.ReadInt32();
				this.Root = r.ReadInt32();
			}

			// Token: 0x06000F78 RID: 3960 RVA: 0x0004395C File Offset: 0x00041B5C
			public void Serialize(BinaryWriter w)
			{
				w.Write(this.BoneIndicies.Count);
				foreach (int value in this.BoneIndicies)
				{
					w.Write(value);
				}
				foreach (int value2 in this.InfoNode)
				{
					w.Write(value2);
				}
				w.Write(this.PoleVector);
				w.Write(this.SlotInfo);
				w.Write(this.SlotOffset);
				w.Write(this.Root);
			}
		}
	}
}
