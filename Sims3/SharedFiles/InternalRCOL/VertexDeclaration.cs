using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using Sims3WorkshopSDK;

namespace Package.SharedFiles.InternalRCOL
{
	// Token: 0x020000C4 RID: 196
	public class VertexDeclaration : RCOLItem
	{
		// Token: 0x1700036B RID: 875
		// (get) Token: 0x06000A49 RID: 2633 RVA: 0x00007C9B File Offset: 0x00005E9B
		// (set) Token: 0x06000A4A RID: 2634 RVA: 0x00007CA3 File Offset: 0x00005EA3
		[TypeConverter(typeof(IntTypeConverter))]
		public uint EntryCount { get; set; }

		// Token: 0x1700036C RID: 876
		// (get) Token: 0x06000A4B RID: 2635 RVA: 0x00007CAC File Offset: 0x00005EAC
		// (set) Token: 0x06000A4C RID: 2636 RVA: 0x00007CB4 File Offset: 0x00005EB4
		public List<VertexDeclaration.SwiffleInfo> SwiffleInformation { get; private set; }

		// Token: 0x06000A4D RID: 2637 RVA: 0x00007CBD File Offset: 0x00005EBD
		public VertexDeclaration()
		{
			this.SwiffleInformation = new List<VertexDeclaration.SwiffleInfo>();
		}

		// Token: 0x06000A4E RID: 2638 RVA: 0x00007CD0 File Offset: 0x00005ED0
		public override string ToString()
		{
			return "Vertex Declaration";
		}

		// Token: 0x06000A4F RID: 2639 RVA: 0x0003241C File Offset: 0x0003061C
		public override void UnSerialize(BinaryReader reader)
		{
			this.SwiffleInformation.Clear();
			this.EntryCount = reader.ReadUInt32();
			int num = 0;
			while ((long)num < (long)((ulong)this.EntryCount))
			{
				VertexDeclaration.SwiffleInfo swiffleInfo = new VertexDeclaration.SwiffleInfo();
				swiffleInfo.UnSerialize(reader);
				this.SwiffleInformation.Add(swiffleInfo);
				num++;
			}
		}

		// Token: 0x06000A50 RID: 2640 RVA: 0x0003246C File Offset: 0x0003066C
		public override void Serialize(BinaryWriter writer)
		{
			writer.Write(this.SwiffleInformation.Count);
			foreach (VertexDeclaration.SwiffleInfo swiffleInfo in this.SwiffleInformation)
			{
				swiffleInfo.Serialize(writer);
			}
		}

		// Token: 0x06000A51 RID: 2641 RVA: 0x00003309 File Offset: 0x00001509
		public override int ReplaceReferences(ResKey from, ResKey to)
		{
			return 0;
		}

		// Token: 0x06000A52 RID: 2642 RVA: 0x000324D0 File Offset: 0x000306D0
		public object Clone()
		{
			VertexDeclaration vertexDeclaration = new VertexDeclaration();
			MemoryStream memoryStream = new MemoryStream();
			BinaryWriter binaryWriter = new BinaryWriter(memoryStream);
			this.Serialize(binaryWriter);
			MemoryStream memoryStream2 = new MemoryStream(memoryStream.ToArray());
			BinaryReader binaryReader = new BinaryReader(memoryStream2);
			vertexDeclaration.UnSerialize(binaryReader);
			memoryStream.Dispose();
			memoryStream2.Dispose();
			binaryWriter.Close();
			binaryReader.Close();
			return vertexDeclaration;
		}

		// Token: 0x020001B4 RID: 436
		public enum SwizzleCommand
		{
			// Token: 0x04000D49 RID: 3401
			None,
			// Token: 0x04000D4A RID: 3402
			Swizzle32,
			// Token: 0x04000D4B RID: 3403
			Swizzle16x2
		}

		// Token: 0x020001B5 RID: 437
		public class SwiffleInfo
		{
			// Token: 0x17000535 RID: 1333
			// (get) Token: 0x06001072 RID: 4210 RVA: 0x0000B4ED File Offset: 0x000096ED
			// (set) Token: 0x06001073 RID: 4211 RVA: 0x0000B4F5 File Offset: 0x000096F5
			[TypeConverter(typeof(IntTypeConverter))]
			public uint VertexSize { get; set; }

			// Token: 0x17000536 RID: 1334
			// (get) Token: 0x06001074 RID: 4212 RVA: 0x0000B4FE File Offset: 0x000096FE
			// (set) Token: 0x06001075 RID: 4213 RVA: 0x0000B506 File Offset: 0x00009706
			[TypeConverter(typeof(IntTypeConverter))]
			public uint VertexCount { get; set; }

			// Token: 0x17000537 RID: 1335
			// (get) Token: 0x06001076 RID: 4214 RVA: 0x0000B50F File Offset: 0x0000970F
			// (set) Token: 0x06001077 RID: 4215 RVA: 0x0000B517 File Offset: 0x00009717
			[TypeConverter(typeof(IntTypeConverter))]
			public uint ByteOffset { get; set; }

			// Token: 0x17000538 RID: 1336
			// (get) Token: 0x06001078 RID: 4216 RVA: 0x0000B520 File Offset: 0x00009720
			// (set) Token: 0x06001079 RID: 4217 RVA: 0x0000B528 File Offset: 0x00009728
			public List<VertexDeclaration.SwizzleCommand> SwizzleCommands { get; set; }

			// Token: 0x0600107A RID: 4218 RVA: 0x00044F54 File Offset: 0x00043154
			public void UnSerialize(BinaryReader reader)
			{
				this.VertexSize = reader.ReadUInt32();
				this.VertexCount = reader.ReadUInt32();
				this.ByteOffset = reader.ReadUInt32();
				this.SwizzleCommands = new List<VertexDeclaration.SwizzleCommand>();
				int num = 0;
				while ((long)num < (long)((ulong)(this.VertexSize / 4U)))
				{
					this.SwizzleCommands.Add((VertexDeclaration.SwizzleCommand)reader.ReadInt32());
					num++;
				}
			}

			// Token: 0x0600107B RID: 4219 RVA: 0x00044FB8 File Offset: 0x000431B8
			public void Serialize(BinaryWriter writer)
			{
				writer.Write(this.VertexSize);
				writer.Write(this.VertexCount);
				writer.Write(this.ByteOffset);
				for (int i = 0; i < this.SwizzleCommands.Count; i++)
				{
					writer.Write((uint)this.SwizzleCommands[i]);
				}
			}

			// Token: 0x0600107C RID: 4220 RVA: 0x00045014 File Offset: 0x00043214
			public override string ToString()
			{
				return string.Concat(new string[]
				{
					"Swiffle info 0x",
					this.VertexSize.ToString("X8"),
					"b per vertex, 0x",
					this.VertexCount.ToString("X8"),
					" vertices"
				});
			}

			// Token: 0x0600107D RID: 4221 RVA: 0x00045070 File Offset: 0x00043270
			public object Clone()
			{
				VertexDeclaration.SwiffleInfo swiffleInfo = new VertexDeclaration.SwiffleInfo();
				MemoryStream memoryStream = new MemoryStream();
				BinaryWriter binaryWriter = new BinaryWriter(memoryStream);
				this.Serialize(binaryWriter);
				MemoryStream memoryStream2 = new MemoryStream(memoryStream.ToArray());
				BinaryReader binaryReader = new BinaryReader(memoryStream2);
				swiffleInfo.UnSerialize(binaryReader);
				memoryStream.Dispose();
				memoryStream2.Dispose();
				binaryWriter.Close();
				binaryReader.Close();
				return swiffleInfo;
			}
		}
	}
}
