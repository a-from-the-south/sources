using System;
using System.Collections.Generic;
using System.IO;
using Sims3WorkshopSDK;

namespace Package.SharedFiles.InternalRCOL
{
	// Token: 0x020000BA RID: 186
	public class BONDEntry : RCOLItem
	{
		// Token: 0x17000331 RID: 817
		// (get) Token: 0x0600098B RID: 2443 RVA: 0x000076EB File Offset: 0x000058EB
		// (set) Token: 0x0600098C RID: 2444 RVA: 0x000076F3 File Offset: 0x000058F3
		public Dictionary<uint, BONDEntry.Bone> Bones { get; set; }

		// Token: 0x0600098D RID: 2445 RVA: 0x0002EC9C File Offset: 0x0002CE9C
		public override void UnSerialize(BinaryReader reader)
		{
			this.Bones = new Dictionary<uint, BONDEntry.Bone>();
			this.Version = reader.ReadUInt32();
			this.BoneCount = reader.ReadUInt32();
			int num = 0;
			while ((long)num < (long)((ulong)this.BoneCount))
			{
				BONDEntry.Bone bone = new BONDEntry.Bone();
				bone.BoneName = reader.ReadUInt32();
				bone.o1 = reader.ReadSingle();
				bone.o2 = reader.ReadSingle();
				bone.o3 = reader.ReadSingle();
				bone.s1 = reader.ReadSingle();
				bone.s2 = reader.ReadSingle();
				bone.s3 = reader.ReadSingle();
				bone.r1 = reader.ReadSingle();
				bone.r2 = reader.ReadSingle();
				bone.r3 = reader.ReadSingle();
				bone.r4 = reader.ReadSingle();
				this.Bones.Add(bone.BoneName, bone);
				num++;
			}
		}

		// Token: 0x0600098E RID: 2446 RVA: 0x0002ED84 File Offset: 0x0002CF84
		public override void Serialize(BinaryWriter writer)
		{
			writer.Write(this.Version);
			writer.Write((uint)this.Bones.Count);
			foreach (BONDEntry.Bone bone in this.Bones.Values)
			{
				writer.Write(bone.BoneName);
				writer.Write(bone.o1);
				writer.Write(bone.o2);
				writer.Write(bone.o3);
				writer.Write(bone.s1);
				writer.Write(bone.s2);
				writer.Write(bone.s3);
				writer.Write(bone.r1);
				writer.Write(bone.r2);
				writer.Write(bone.r3);
				writer.Write(bone.r4);
			}
		}

		// Token: 0x0600098F RID: 2447 RVA: 0x00003309 File Offset: 0x00001509
		public override int ReplaceReferences(ResKey from, ResKey to)
		{
			return 0;
		}

		// Token: 0x040004A1 RID: 1185
		public uint Version;

		// Token: 0x040004A2 RID: 1186
		public uint BoneCount;

		// Token: 0x020001AB RID: 427
		public class Bone
		{
			// Token: 0x170004FC RID: 1276
			// (get) Token: 0x06000FEE RID: 4078 RVA: 0x0000B04E File Offset: 0x0000924E
			// (set) Token: 0x06000FEF RID: 4079 RVA: 0x0000B056 File Offset: 0x00009256
			public uint BoneName { get; set; }

			// Token: 0x170004FD RID: 1277
			// (get) Token: 0x06000FF0 RID: 4080 RVA: 0x0000B05F File Offset: 0x0000925F
			// (set) Token: 0x06000FF1 RID: 4081 RVA: 0x0000B067 File Offset: 0x00009267
			public float o1 { get; set; }

			// Token: 0x170004FE RID: 1278
			// (get) Token: 0x06000FF2 RID: 4082 RVA: 0x0000B070 File Offset: 0x00009270
			// (set) Token: 0x06000FF3 RID: 4083 RVA: 0x0000B078 File Offset: 0x00009278
			public float o2 { get; set; }

			// Token: 0x170004FF RID: 1279
			// (get) Token: 0x06000FF4 RID: 4084 RVA: 0x0000B081 File Offset: 0x00009281
			// (set) Token: 0x06000FF5 RID: 4085 RVA: 0x0000B089 File Offset: 0x00009289
			public float o3 { get; set; }

			// Token: 0x17000500 RID: 1280
			// (get) Token: 0x06000FF6 RID: 4086 RVA: 0x0000B092 File Offset: 0x00009292
			// (set) Token: 0x06000FF7 RID: 4087 RVA: 0x0000B09A File Offset: 0x0000929A
			public float s1 { get; set; }

			// Token: 0x17000501 RID: 1281
			// (get) Token: 0x06000FF8 RID: 4088 RVA: 0x0000B0A3 File Offset: 0x000092A3
			// (set) Token: 0x06000FF9 RID: 4089 RVA: 0x0000B0AB File Offset: 0x000092AB
			public float s2 { get; set; }

			// Token: 0x17000502 RID: 1282
			// (get) Token: 0x06000FFA RID: 4090 RVA: 0x0000B0B4 File Offset: 0x000092B4
			// (set) Token: 0x06000FFB RID: 4091 RVA: 0x0000B0BC File Offset: 0x000092BC
			public float s3 { get; set; }

			// Token: 0x17000503 RID: 1283
			// (get) Token: 0x06000FFC RID: 4092 RVA: 0x0000B0C5 File Offset: 0x000092C5
			// (set) Token: 0x06000FFD RID: 4093 RVA: 0x0000B0CD File Offset: 0x000092CD
			public float r1 { get; set; }

			// Token: 0x17000504 RID: 1284
			// (get) Token: 0x06000FFE RID: 4094 RVA: 0x0000B0D6 File Offset: 0x000092D6
			// (set) Token: 0x06000FFF RID: 4095 RVA: 0x0000B0DE File Offset: 0x000092DE
			public float r2 { get; set; }

			// Token: 0x17000505 RID: 1285
			// (get) Token: 0x06001000 RID: 4096 RVA: 0x0000B0E7 File Offset: 0x000092E7
			// (set) Token: 0x06001001 RID: 4097 RVA: 0x0000B0EF File Offset: 0x000092EF
			public float r3 { get; set; }

			// Token: 0x17000506 RID: 1286
			// (get) Token: 0x06001002 RID: 4098 RVA: 0x0000B0F8 File Offset: 0x000092F8
			// (set) Token: 0x06001003 RID: 4099 RVA: 0x0000B100 File Offset: 0x00009300
			public float r4 { get; set; }
		}
	}
}
