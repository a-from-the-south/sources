using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Sims3WorkshopSDK;
using Sims3WorkshopSDK.Classes;

namespace Package.Sims3Files
{
	// Token: 0x02000016 RID: 22
	public class BONE : DBPFEntry
	{
		// Token: 0x17000036 RID: 54
		// (get) Token: 0x06000115 RID: 277 RVA: 0x000037FD File Offset: 0x000019FD
		// (set) Token: 0x06000116 RID: 278 RVA: 0x00003805 File Offset: 0x00001A05
		public List<BONE.BoneEntry> Bones { get; set; }

		// Token: 0x17000037 RID: 55
		// (get) Token: 0x06000117 RID: 279 RVA: 0x0000380E File Offset: 0x00001A0E
		// (set) Token: 0x06000118 RID: 280 RVA: 0x00003816 File Offset: 0x00001A16
		public Hashtable HashedBoneNames { get; set; }

		// Token: 0x06000119 RID: 281 RVA: 0x0000381F File Offset: 0x00001A1F
		public BONE()
		{
			this.typeId = 11431015U;
		}

		// Token: 0x0600011A RID: 282 RVA: 0x000120E0 File Offset: 0x000102E0
		public override void UnSerialize()
		{
			this.Bones = new List<BONE.BoneEntry>();
			this.HashedBoneNames = new Hashtable();
			MemoryStream memoryStream = new MemoryStream(this.data);
			BinaryReader binaryReader = new BinaryReader(memoryStream);
			this._Version = binaryReader.ReadUInt32();
			UnicodeEncoding unicodeEncoding = new UnicodeEncoding();
			uint num = binaryReader.ReadUInt32();
			int num2 = 0;
			while ((long)num2 < (long)((ulong)num))
			{
				byte[] array = new byte[(int)binaryReader.ReadByte()];
				for (int i = 0; i < array.Length; i += 2)
				{
					array[i + 1] = binaryReader.ReadByte();
					array[i] = binaryReader.ReadByte();
				}
				string @string = unicodeEncoding.GetString(array);
				BONE.BoneEntry boneEntry = new BONE.BoneEntry();
				boneEntry.Name = @string;
				this.HashedBoneNames.Add(FNV32.GetHash(boneEntry.Name), boneEntry);
				this.Bones.Add(boneEntry);
				num2++;
			}
			num = binaryReader.ReadUInt32();
			int num3 = 0;
			while ((long)num3 < (long)((ulong)num))
			{
				BONE.BoneEntry boneEntry2 = this.Bones[num3];
				boneEntry2.x1 = binaryReader.ReadSingle();
				boneEntry2.x2 = binaryReader.ReadSingle();
				boneEntry2.x3 = binaryReader.ReadSingle();
				boneEntry2.y1 = binaryReader.ReadSingle();
				boneEntry2.y2 = binaryReader.ReadSingle();
				boneEntry2.y3 = binaryReader.ReadSingle();
				boneEntry2.z1 = binaryReader.ReadSingle();
				boneEntry2.z2 = binaryReader.ReadSingle();
				boneEntry2.z3 = binaryReader.ReadSingle();
				boneEntry2.o1 = binaryReader.ReadSingle();
				boneEntry2.o2 = binaryReader.ReadSingle();
				boneEntry2.o3 = binaryReader.ReadSingle();
				num3++;
			}
			binaryReader.Close();
			memoryStream.Dispose();
		}

		// Token: 0x0600011B RID: 283 RVA: 0x0000330C File Offset: 0x0000150C
		public override byte[] Serialize()
		{
			return this.data;
		}

		// Token: 0x0600011C RID: 284 RVA: 0x00003309 File Offset: 0x00001509
		public override int ReplaceReferences(ResKey from, ResKey to)
		{
			return 0;
		}

		// Token: 0x04000063 RID: 99
		private uint _Version;

		// Token: 0x020000FE RID: 254
		public class BoneEntry
		{
			// Token: 0x170003F0 RID: 1008
			// (get) Token: 0x06000C97 RID: 3223 RVA: 0x00008EA8 File Offset: 0x000070A8
			// (set) Token: 0x06000C98 RID: 3224 RVA: 0x00008EB0 File Offset: 0x000070B0
			public string Name { get; set; }

			// Token: 0x170003F1 RID: 1009
			// (get) Token: 0x06000C99 RID: 3225 RVA: 0x00008EB9 File Offset: 0x000070B9
			// (set) Token: 0x06000C9A RID: 3226 RVA: 0x00008EC1 File Offset: 0x000070C1
			public float x1 { get; set; }

			// Token: 0x170003F2 RID: 1010
			// (get) Token: 0x06000C9B RID: 3227 RVA: 0x00008ECA File Offset: 0x000070CA
			// (set) Token: 0x06000C9C RID: 3228 RVA: 0x00008ED2 File Offset: 0x000070D2
			public float x2 { get; set; }

			// Token: 0x170003F3 RID: 1011
			// (get) Token: 0x06000C9D RID: 3229 RVA: 0x00008EDB File Offset: 0x000070DB
			// (set) Token: 0x06000C9E RID: 3230 RVA: 0x00008EE3 File Offset: 0x000070E3
			public float x3 { get; set; }

			// Token: 0x170003F4 RID: 1012
			// (get) Token: 0x06000C9F RID: 3231 RVA: 0x00008EEC File Offset: 0x000070EC
			// (set) Token: 0x06000CA0 RID: 3232 RVA: 0x00008EF4 File Offset: 0x000070F4
			public float y1 { get; set; }

			// Token: 0x170003F5 RID: 1013
			// (get) Token: 0x06000CA1 RID: 3233 RVA: 0x00008EFD File Offset: 0x000070FD
			// (set) Token: 0x06000CA2 RID: 3234 RVA: 0x00008F05 File Offset: 0x00007105
			public float y2 { get; set; }

			// Token: 0x170003F6 RID: 1014
			// (get) Token: 0x06000CA3 RID: 3235 RVA: 0x00008F0E File Offset: 0x0000710E
			// (set) Token: 0x06000CA4 RID: 3236 RVA: 0x00008F16 File Offset: 0x00007116
			public float y3 { get; set; }

			// Token: 0x170003F7 RID: 1015
			// (get) Token: 0x06000CA5 RID: 3237 RVA: 0x00008F1F File Offset: 0x0000711F
			// (set) Token: 0x06000CA6 RID: 3238 RVA: 0x00008F27 File Offset: 0x00007127
			public float z1 { get; set; }

			// Token: 0x170003F8 RID: 1016
			// (get) Token: 0x06000CA7 RID: 3239 RVA: 0x00008F30 File Offset: 0x00007130
			// (set) Token: 0x06000CA8 RID: 3240 RVA: 0x00008F38 File Offset: 0x00007138
			public float z2 { get; set; }

			// Token: 0x170003F9 RID: 1017
			// (get) Token: 0x06000CA9 RID: 3241 RVA: 0x00008F41 File Offset: 0x00007141
			// (set) Token: 0x06000CAA RID: 3242 RVA: 0x00008F49 File Offset: 0x00007149
			public float z3 { get; set; }

			// Token: 0x170003FA RID: 1018
			// (get) Token: 0x06000CAB RID: 3243 RVA: 0x00008F52 File Offset: 0x00007152
			// (set) Token: 0x06000CAC RID: 3244 RVA: 0x00008F5A File Offset: 0x0000715A
			public float o1 { get; set; }

			// Token: 0x170003FB RID: 1019
			// (get) Token: 0x06000CAD RID: 3245 RVA: 0x00008F63 File Offset: 0x00007163
			// (set) Token: 0x06000CAE RID: 3246 RVA: 0x00008F6B File Offset: 0x0000716B
			public float o2 { get; set; }

			// Token: 0x170003FC RID: 1020
			// (get) Token: 0x06000CAF RID: 3247 RVA: 0x00008F74 File Offset: 0x00007174
			// (set) Token: 0x06000CB0 RID: 3248 RVA: 0x00008F7C File Offset: 0x0000717C
			public float o3 { get; set; }
		}
	}
}
