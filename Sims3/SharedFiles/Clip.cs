using System;
using System.Collections.Generic;
using System.IO;
using Package.SharedFiles.S_CLIP;
using Sims3WorkshopSDK;

namespace Package.SharedFiles
{
	// Token: 0x020000B0 RID: 176
	public class Clip : DBPFEntry
	{
		// Token: 0x170002F7 RID: 759
		// (get) Token: 0x060008E2 RID: 2274 RVA: 0x00007141 File Offset: 0x00005341
		// (set) Token: 0x060008E3 RID: 2275 RVA: 0x00007149 File Offset: 0x00005349
		public string Name { get; set; }

		// Token: 0x170002F8 RID: 760
		// (get) Token: 0x060008E4 RID: 2276 RVA: 0x00007152 File Offset: 0x00005352
		// (set) Token: 0x060008E5 RID: 2277 RVA: 0x0000715A File Offset: 0x0000535A
		public string SourceName { get; set; }

		// Token: 0x170002F9 RID: 761
		// (get) Token: 0x060008E6 RID: 2278 RVA: 0x00007163 File Offset: 0x00005363
		// (set) Token: 0x060008E7 RID: 2279 RVA: 0x0000716B File Offset: 0x0000536B
		public List<Rule> JointMovementRules { get; set; }

		// Token: 0x170002FA RID: 762
		// (get) Token: 0x060008E8 RID: 2280 RVA: 0x00007174 File Offset: 0x00005374
		// (set) Token: 0x060008E9 RID: 2281 RVA: 0x0000717C File Offset: 0x0000537C
		public string ActorName { get; set; }

		// Token: 0x060008EA RID: 2282 RVA: 0x0002C804 File Offset: 0x0002AA04
		public Clip()
		{
			this.typeId = 1797309683U;
			this.JointMovementRules = new List<Rule>();
			this.ActorSlotEntries = new List<ActorSlotEntry>();
			this.ActorSlotOffsets = new List<int>();
			this.clipEvents = new ClipEvent();
		}

		// Token: 0x060008EB RID: 2283 RVA: 0x00003309 File Offset: 0x00001509
		public override int ReplaceReferences(ResKey from, ResKey to)
		{
			return 0;
		}

		// Token: 0x060008EC RID: 2284 RVA: 0x0002C858 File Offset: 0x0002AA58
		public override void UnSerialize()
		{
			this.JointMovementRules.Clear();
			this.ActorSlotEntries.Clear();
			this.ActorSlotOffsets.Clear();
			MemoryStream memoryStream = new MemoryStream(this.data);
			BinaryReader binaryReader = new BinaryReader(memoryStream);
			byte[] array = new byte[0];
			this.tid = binaryReader.ReadUInt32();
			if (this.tid != 1797309683U)
			{
				binaryReader.ReadUInt32();
				binaryReader.ReadSingle();
				float[] array2 = new float[8];
				for (int i = 0; i < array2.Length; i++)
				{
					array2[i] = binaryReader.ReadSingle();
				}
				uint[] array3 = new uint[3];
				for (int j = 0; j < array3.Length; j++)
				{
					array3[j] = binaryReader.ReadUInt32();
				}
				PackageUtil.ReadString(binaryReader, binaryReader.ReadInt32());
				PackageUtil.ReadString(binaryReader, binaryReader.ReadInt32());
				int num = binaryReader.ReadInt32();
				string[] array4 = new string[num];
				for (int k = 0; k < num; k++)
				{
					array4[k] = PackageUtil.ReadString(binaryReader, binaryReader.ReadInt32());
				}
				int num2 = binaryReader.ReadInt32();
				binaryReader.ReadInt32();
				for (int l = 0; l < num2; l++)
				{
					PackageUtil.ReadString(binaryReader, binaryReader.ReadInt32());
					PackageUtil.ReadString(binaryReader, binaryReader.ReadInt32());
					binaryReader.ReadUInt16();
					binaryReader.ReadUInt16();
				}
				uint num3 = binaryReader.ReadUInt32();
				while (binaryReader.BaseStream.Position + (long)((ulong)num3) != binaryReader.BaseStream.Length)
				{
					long position = (long)binaryReader.ReadInt32() + binaryReader.BaseStream.Position;
					binaryReader.ReadUInt32();
					binaryReader.ReadUInt32();
					binaryReader.ReadSingle();
					binaryReader.BaseStream.Position = position;
					num3 = binaryReader.ReadUInt32();
				}
				array = new byte[num3];
				binaryReader.Read(array, 0, array.Length);
			}
			else
			{
				this.offset = binaryReader.ReadUInt32();
				this.sizeOfClip = binaryReader.ReadUInt32();
				this.clipOffset = binaryReader.ReadUInt32();
				this.slotOffset = binaryReader.ReadUInt32();
				this.actorOffset = binaryReader.ReadUInt32();
				this.eventOffset = binaryReader.ReadUInt32();
				this.unk1 = binaryReader.ReadUInt32();
				this.unk2 = binaryReader.ReadUInt32();
				this.endOffset = binaryReader.ReadUInt32();
				this.blankBytes = binaryReader.ReadBytes(16);
				binaryReader.BaseStream.Position = (long)((ulong)this.clipOffset + 12UL);
				array = new byte[this.sizeOfClip];
				binaryReader.Read(array, 0, array.Length);
			}
			BinaryReader binaryReader2 = new BinaryReader(new MemoryStream(array));
			this._s3clip_ = binaryReader2.ReadUInt64();
			this.version = binaryReader2.ReadUInt32();
			this.blank = binaryReader2.ReadUInt32();
			this.frameDuration = binaryReader2.ReadSingle();
			this.frameCount = binaryReader2.ReadUInt16();
			this.unk3 = binaryReader2.ReadUInt16();
			this.numRules = binaryReader2.ReadUInt32();
			this.indexedFloatCount = binaryReader2.ReadUInt32();
			this.ruleDataOffset = binaryReader2.ReadUInt32();
			this.frameDataOffset = binaryReader2.ReadUInt32();
			this.animationNameOffset = binaryReader2.ReadUInt32();
			this.offsetToTerminatedSourceFile = binaryReader2.ReadUInt32();
			if (binaryReader2.BaseStream.Position != (long)((ulong)this.ruleDataOffset))
			{
				throw new InvalidDataException("Bad Curve Data Offset");
			}
			binaryReader2.BaseStream.Position = (long)((ulong)this.ruleDataOffset);
			int num4 = 0;
			while ((long)num4 < (long)((ulong)this.numRules))
			{
				Rule rule = new Rule();
				rule.Unserialize(binaryReader2);
				this.JointMovementRules.Add(rule);
				num4++;
			}
			if (binaryReader2.BaseStream.Position != (long)((ulong)this.animationNameOffset))
			{
				throw new InvalidDataException("Bad Name Offset");
			}
			binaryReader2.BaseStream.Position = (long)((ulong)this.animationNameOffset);
			this.Name = PackageUtil.ReadString(binaryReader2);
			if (binaryReader2.BaseStream.Position != (long)((ulong)this.offsetToTerminatedSourceFile))
			{
				throw new InvalidDataException("Bad SourceName Offset");
			}
			binaryReader2.BaseStream.Position = (long)((ulong)this.offsetToTerminatedSourceFile);
			this.SourceName = PackageUtil.ReadString(binaryReader2);
			if (binaryReader2.BaseStream.Position != (long)((ulong)this.frameDataOffset))
			{
				throw new InvalidDataException("Bad Indexed Floats Offset");
			}
			List<float> list = new List<float>();
			int num5 = 0;
			while ((long)num5 < (long)((ulong)this.indexedFloatCount))
			{
				list.Add(binaryReader2.ReadSingle());
				num5++;
			}
			try
			{
				int num6 = 0;
				foreach (Rule rule2 in this.JointMovementRules)
				{
					binaryReader2.BaseStream.Position = (long)((ulong)rule2.frameDataOffset);
					for (int m = 0; m < (int)rule2.numFrames; m++)
					{
						try
						{
							Frame frame = new Frame(rule2, rule2.jointName, list);
							frame.UnSerialize(binaryReader2);
							rule2.Frames.Add(frame);
							rule2.IndexedFrames.Add((int)frame.FrameIndex, frame);
						}
						catch (Exception ex)
						{
							throw ex;
						}
					}
					num6++;
				}
			}
			catch (Exception ex2)
			{
				throw ex2;
			}
			binaryReader.Close();
			memoryStream.Dispose();
		}

		// Token: 0x060008ED RID: 2285 RVA: 0x0002CD7C File Offset: 0x0002AF7C
		public override byte[] Serialize()
		{
			MemoryStream memoryStream = new MemoryStream(this.data);
			BinaryWriter binaryWriter = new BinaryWriter(memoryStream);
			binaryWriter.Write(this.tid);
			binaryWriter.Write(this.offset);
			binaryWriter.Write(this.sizeOfClip);
			binaryWriter.Write(this.clipOffset);
			binaryWriter.Write(this.slotOffset);
			binaryWriter.Write(this.actorOffset);
			binaryWriter.Write(this.eventOffset);
			binaryWriter.Write(this.unk1);
			binaryWriter.Write(this.unk2);
			binaryWriter.Write(this.endOffset);
			binaryWriter.Write(this.blankBytes);
			binaryWriter.Write(this._s3clip_);
			binaryWriter.Write(this.version);
			binaryWriter.Write(this.blank);
			binaryWriter.Write(this.frameDuration);
			binaryWriter.Write(this.frameCount);
			binaryWriter.Write(this.unk3);
			binaryWriter.Write(this.numRules);
			binaryWriter.Write(this.indexedFloatCount);
			binaryWriter.Write(this.ruleDataOffset);
			binaryWriter.Write(this.frameDataOffset);
			binaryWriter.Write(this.animationNameOffset);
			binaryWriter.Write(this.offsetToTerminatedSourceFile);
			foreach (Rule rule in this.JointMovementRules)
			{
				rule.Serialize(binaryWriter);
			}
			for (int i = 0; i < this.Name.Length; i++)
			{
				binaryWriter.Write((byte)this.Name[i]);
			}
			binaryWriter.Write(0);
			for (int j = 0; j < this.SourceName.Length; j++)
			{
				binaryWriter.Write((byte)this.SourceName[j]);
			}
			binaryWriter.Write(0);
			foreach (Rule rule2 in this.JointMovementRules)
			{
				foreach (Frame frame in rule2.Frames)
				{
					frame.Serialize(binaryWriter);
				}
			}
			long num = (long)(Math.Ceiling((double)((float)binaryWriter.BaseStream.Position / 4f)) * 4.0) - binaryWriter.BaseStream.Position;
			int num2 = 0;
			while ((long)num2 < num)
			{
				binaryWriter.Write(126);
				num2++;
			}
			binaryWriter.Write(this.ActorSlotOffsets.Count);
			foreach (int value in this.ActorSlotOffsets)
			{
				binaryWriter.Write(value);
			}
			foreach (ActorSlotEntry actorSlotEntry in this.ActorSlotEntries)
			{
				actorSlotEntry.Serialize(binaryWriter);
			}
			binaryWriter.Write(this.unkShort);
			num = (long)(Math.Ceiling((double)((float)binaryWriter.BaseStream.Position / 4f)) * 4.0) - binaryWriter.BaseStream.Position;
			int num3 = 0;
			while ((long)num3 < num)
			{
				binaryWriter.Write(126);
				num3++;
			}
			this.clipEvents.Serialize(binaryWriter);
			binaryWriter.Write(this.emptyBytes);
			binaryWriter.Write(this.finalFloat);
			memoryStream.ToArray();
			memoryStream.Dispose();
			binaryWriter.Close();
			return this.data;
		}

		// Token: 0x0400044C RID: 1100
		public List<int> ActorSlotOffsets;

		// Token: 0x0400044D RID: 1101
		public List<ActorSlotEntry> ActorSlotEntries;

		// Token: 0x0400044E RID: 1102
		public ClipEvent clipEvents;

		// Token: 0x0400044F RID: 1103
		private uint tid;

		// Token: 0x04000450 RID: 1104
		private uint offset;

		// Token: 0x04000451 RID: 1105
		private uint sizeOfClip;

		// Token: 0x04000452 RID: 1106
		private uint clipOffset;

		// Token: 0x04000453 RID: 1107
		private uint slotOffset;

		// Token: 0x04000454 RID: 1108
		private uint actorOffset;

		// Token: 0x04000455 RID: 1109
		private uint eventOffset;

		// Token: 0x04000456 RID: 1110
		private uint unk1;

		// Token: 0x04000457 RID: 1111
		private uint unk2;

		// Token: 0x04000458 RID: 1112
		private uint endOffset;

		// Token: 0x04000459 RID: 1113
		private byte[] blankBytes;

		// Token: 0x0400045A RID: 1114
		private int headerSize = 56;

		// Token: 0x0400045B RID: 1115
		private ulong _s3clip_;

		// Token: 0x0400045C RID: 1116
		private uint version;

		// Token: 0x0400045D RID: 1117
		private uint blank;

		// Token: 0x0400045E RID: 1118
		private float frameDuration;

		// Token: 0x0400045F RID: 1119
		private ushort frameCount;

		// Token: 0x04000460 RID: 1120
		private ushort unk3;

		// Token: 0x04000461 RID: 1121
		private uint numRules;

		// Token: 0x04000462 RID: 1122
		private uint indexedFloatCount;

		// Token: 0x04000463 RID: 1123
		private uint ruleDataOffset;

		// Token: 0x04000464 RID: 1124
		private uint frameDataOffset;

		// Token: 0x04000465 RID: 1125
		private uint animationNameOffset;

		// Token: 0x04000466 RID: 1126
		private uint offsetToTerminatedSourceFile;

		// Token: 0x04000467 RID: 1127
		private ushort unkShort;

		// Token: 0x04000468 RID: 1128
		private byte[] emptyBytes;

		// Token: 0x04000469 RID: 1129
		private float finalFloat;
	}
}
