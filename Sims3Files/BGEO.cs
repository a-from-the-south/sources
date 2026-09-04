using System;
using System.Collections.Generic;
using System.IO;
using Sims3WorkshopSDK;

namespace Package.Sims3Files
{
	// Token: 0x02000014 RID: 20
	public class BGEO : DBPFEntry
	{
		// Token: 0x17000032 RID: 50
		// (get) Token: 0x06000107 RID: 263 RVA: 0x0000377C File Offset: 0x0000197C
		// (set) Token: 0x06000108 RID: 264 RVA: 0x00003784 File Offset: 0x00001984
		public uint Version { get; set; }

		// Token: 0x17000033 RID: 51
		// (get) Token: 0x06000109 RID: 265 RVA: 0x0000378D File Offset: 0x0000198D
		// (set) Token: 0x0600010A RID: 266 RVA: 0x00003795 File Offset: 0x00001995
		public List<BGEO.S1Entry> S1Entries { get; set; }

		// Token: 0x17000034 RID: 52
		// (get) Token: 0x0600010B RID: 267 RVA: 0x0000379E File Offset: 0x0000199E
		// (set) Token: 0x0600010C RID: 268 RVA: 0x000037A6 File Offset: 0x000019A6
		public List<ushort> Words { get; set; }

		// Token: 0x17000035 RID: 53
		// (get) Token: 0x0600010D RID: 269 RVA: 0x000037AF File Offset: 0x000019AF
		// (set) Token: 0x0600010E RID: 270 RVA: 0x000037B7 File Offset: 0x000019B7
		private List<short[]> _S3Entries { get; set; }

		// Token: 0x0600010F RID: 271 RVA: 0x000037C0 File Offset: 0x000019C0
		public BGEO()
		{
			this.typeId = 108833297U;
			this.S1Entries = new List<BGEO.S1Entry>();
			this.Words = new List<ushort>();
			this._S3Entries = new List<short[]>();
		}

		// Token: 0x06000110 RID: 272 RVA: 0x00011500 File Offset: 0x0000F700
		public override void UnSerialize()
		{
			this.S1Entries.Clear();
			MemoryStream memoryStream = new MemoryStream(this.data);
			BinaryReader binaryReader = new BinaryReader(memoryStream);
			this._identifier = binaryReader.ReadUInt32();
			if (this._identifier == 3U)
			{
				binaryReader.BaseStream.Position = 44L;
				this._identifier = binaryReader.ReadUInt32();
			}
			this.Version = binaryReader.ReadUInt32();
			uint num;
			if (this.Version == 1536U)
			{
				num = 1U;
			}
			else
			{
				num = binaryReader.ReadUInt32();
			}
			this.section1SubEntryCount = binaryReader.ReadUInt32();
			uint num2 = binaryReader.ReadUInt32();
			uint num3 = binaryReader.ReadUInt32();
			if (this.Version != 1536U)
			{
				this.section1PreSubEntrySize = binaryReader.ReadUInt32();
				this.section1SubEntrySize = binaryReader.ReadUInt32();
				binaryReader.ReadUInt32();
				binaryReader.ReadUInt32();
				binaryReader.ReadUInt32();
			}
			int num4 = 0;
			while ((long)num4 < (long)((ulong)num))
			{
				BGEO.S1Entry s1Entry = new BGEO.S1Entry();
				if (this.Version != 1536U)
				{
					s1Entry.AgeGenderFlags = binaryReader.ReadUInt32();
					s1Entry.FacialRegion = binaryReader.ReadUInt32();
				}
				int num5 = 0;
				while ((long)num5 < (long)((ulong)this.section1SubEntryCount))
				{
					BGEO.S1SubEntry s1SubEntry = new BGEO.S1SubEntry();
					s1SubEntry.StartVertexId = binaryReader.ReadInt32();
					s1SubEntry.NumWords = binaryReader.ReadUInt32();
					s1SubEntry.NumS3Entries = binaryReader.ReadUInt32();
					s1Entry.SubEntries.Add(s1SubEntry);
					num5++;
				}
				this.S1Entries.Add(s1Entry);
				num4++;
			}
			int num6 = 0;
			while ((long)num6 < (long)((ulong)num2))
			{
				ushort item = binaryReader.ReadUInt16();
				this.Words.Add(item);
				num6++;
			}
			int num7 = 0;
			while ((long)num7 < (long)((ulong)num3))
			{
				short num8 = binaryReader.ReadInt16();
				short num9 = binaryReader.ReadInt16();
				short num10 = binaryReader.ReadInt16();
				this._S3Entries.Add(new short[]
				{
					num8,
					num9,
					num10
				});
				num7++;
			}
			foreach (BGEO.S1Entry s1Entry2 in this.S1Entries)
			{
				uint num11 = 0U;
				int num12 = 0;
				int num13 = 0;
				foreach (BGEO.S1SubEntry s1SubEntry2 in s1Entry2.SubEntries)
				{
					int num14 = s1SubEntry2.StartVertexId;
					int num15 = 0;
					while ((long)num15 < (long)((ulong)s1SubEntry2.NumWords))
					{
						BGEO.BlendVertex blendVertex = new BGEO.BlendVertex();
						s1SubEntry2.Vertices.Add(blendVertex);
						ushort num16 = this.Words[(int)((long)num15 + (long)((ulong)num11))];
						ushort num17 = (ushort)(num16 >> 2);
						num12 += (int)((num17 > 8191) ? (-(int)(8192 - (num17 & 8191))) : num17);
						blendVertex.PositionInList = num12 - num13;
						blendVertex.HasNormal = ((num16 & 2) > 0);
						blendVertex.HasPosition = ((num16 & 1) > 0);
						blendVertex.VertexID = num14;
						int num18 = 0;
						if (blendVertex.HasPosition)
						{
							if (num12 + num18 >= this._S3Entries.Count || num12 < 0)
							{
								throw new Exception("Could not get S3 Blend data, index was " + (num12 + num18).ToString() + " length is " + this._S3Entries.Count.ToString());
							}
							short num19 = this._S3Entries[num12 + num18][0];
							short num20 = this._S3Entries[num12 + num18][1];
							short num21 = this._S3Entries[num12 + num18][2];
							if (((int)num19 & 32768) > 0)
							{
								num19 &= short.MaxValue;
							}
							else
							{
								num19 = (short)((int)num19 | 32768);
							}
							if (((int)num20 & 32768) > 0)
							{
								num20 &= short.MaxValue;
							}
							else
							{
								num20 = (short)((int)num20 | 32768);
							}
							if (((int)num21 & 32768) > 0)
							{
								num21 &= short.MaxValue;
							}
							else
							{
								num21 = (short)((int)num21 | 32768);
							}
							float num22 = (float)num19 / 2000f;
							float num23 = (float)num20 / 2000f;
							float num24 = (float)num21 / 2000f;
							blendVertex.Position = new float[]
							{
								num22,
								num23,
								num24
							};
							num18++;
						}
						if (blendVertex.HasNormal)
						{
							if (num12 + num18 >= this._S3Entries.Count || num12 < 0)
							{
								throw new Exception("Could not get S3 Blend data, index was " + (num12 + num18).ToString() + " length is " + this._S3Entries.Count.ToString());
							}
							short num25 = this._S3Entries[num12 + num18][0];
							short num26 = this._S3Entries[num12 + num18][1];
							short num27 = this._S3Entries[num12 + num18][2];
							if (((int)num25 & 32768) > 0)
							{
								num25 &= short.MaxValue;
							}
							else
							{
								num25 = (short)((int)num25 | 32768);
							}
							if (((int)num26 & 32768) > 0)
							{
								num26 &= short.MaxValue;
							}
							else
							{
								num26 = (short)((int)num26 | 32768);
							}
							if (((int)num27 & 32768) > 0)
							{
								num27 &= short.MaxValue;
							}
							else
							{
								num27 = (short)((int)num27 | 32768);
							}
							float num28 = (float)num25 / 2000f;
							float num29 = (float)num26 / 2000f;
							float num30 = (float)num27 / 2000f;
							blendVertex.Normal = new float[]
							{
								num28,
								num29,
								num30
							};
						}
						num14++;
						num15++;
					}
					num11 += s1SubEntry2.NumWords;
					num12 += (int)s1SubEntry2.NumS3Entries;
					num13 += (int)s1SubEntry2.NumS3Entries;
				}
			}
			memoryStream.Dispose();
			binaryReader.Close();
		}

		// Token: 0x06000111 RID: 273 RVA: 0x00011B0C File Offset: 0x0000FD0C
		public void Update()
		{
			List<ushort> list = new List<ushort>();
			List<short[]> list2 = new List<short[]>();
			foreach (BGEO.S1Entry s1Entry in this.S1Entries)
			{
				BGEO.BlendVertex blendVertex = null;
				foreach (BGEO.S1SubEntry s1SubEntry in s1Entry.SubEntries)
				{
					int num = 0;
					BGEO.BlendVertex blendVertex2 = null;
					foreach (BGEO.BlendVertex blendVertex3 in s1SubEntry.Vertices)
					{
						if (blendVertex3.HasPosition)
						{
							num++;
							double num2 = (double)blendVertex3.Position[0];
							float num3 = blendVertex3.Position[1];
							float num4 = blendVertex3.Position[2];
							short num5 = (short)Math.Round(num2 * (double)2000f);
							short num6 = (short)Math.Round((double)(num3 * 2000f));
							short num7 = (short)Math.Round((double)(num4 * 2000f));
							if (num5 >= 0)
							{
								num5 = (short)((int)num5 | 32768);
							}
							else
							{
								num5 &= short.MaxValue;
							}
							if (num6 >= 0)
							{
								num6 = (short)((int)num6 | 32768);
							}
							else
							{
								num6 &= short.MaxValue;
							}
							if (num7 >= 0)
							{
								num7 = (short)((int)num7 | 32768);
							}
							else
							{
								num7 &= short.MaxValue;
							}
							list2.Add(new short[]
							{
								num5,
								num6,
								num7
							});
						}
						if (blendVertex3.HasNormal)
						{
							num++;
							double num8 = (double)blendVertex3.Normal[0];
							float num9 = blendVertex3.Normal[1];
							float num10 = blendVertex3.Normal[2];
							short num11 = (short)Math.Round(num8 * (double)2000f);
							short num12 = (short)Math.Round((double)(num9 * 2000f));
							short num13 = (short)Math.Round((double)(num10 * 2000f));
							if (num11 >= 0)
							{
								num11 = (short)((int)num11 | 32768);
							}
							else
							{
								num11 &= short.MaxValue;
							}
							if (num12 >= 0)
							{
								num12 = (short)((int)num12 | 32768);
							}
							else
							{
								num12 &= short.MaxValue;
							}
							if (num13 >= 0)
							{
								num13 = (short)((int)num13 | 32768);
							}
							else
							{
								num13 &= short.MaxValue;
							}
							list2.Add(new short[]
							{
								num11,
								num12,
								num13
							});
						}
						int num14 = (blendVertex2 == null) ? 0 : ((blendVertex2.HasNormal ? 1 : 0) + (blendVertex2.HasPosition ? 1 : 0));
						ushort item = (ushort)((blendVertex3.HasNormal ? 2 : 0) + (blendVertex3.HasPosition ? 1 : 0) | num14 << 2);
						list.Add(item);
						blendVertex2 = (blendVertex = blendVertex3);
					}
					s1SubEntry.NumS3Entries = ((blendVertex == null) ? 0U : ((blendVertex.HasNormal ? 1U : 0U) + (blendVertex.HasPosition ? 1U : 0U)));
				}
			}
			this._S3Entries = list2;
			this.Words = list;
		}

		// Token: 0x06000112 RID: 274 RVA: 0x00011E50 File Offset: 0x00010050
		public override byte[] Serialize()
		{
			MemoryStream memoryStream = new MemoryStream();
			BinaryWriter binaryWriter = new BinaryWriter(memoryStream);
			MemoryStream memoryStream2 = new MemoryStream();
			BinaryWriter binaryWriter2 = new BinaryWriter(memoryStream2);
			MemoryStream memoryStream3 = new MemoryStream();
			BinaryWriter binaryWriter3 = new BinaryWriter(memoryStream3);
			foreach (BGEO.S1Entry s1Entry in this.S1Entries)
			{
				binaryWriter2.Write(s1Entry.AgeGenderFlags);
				binaryWriter2.Write(s1Entry.FacialRegion);
				foreach (BGEO.S1SubEntry s1SubEntry in s1Entry.SubEntries)
				{
					binaryWriter2.Write(s1SubEntry.StartVertexId);
					binaryWriter2.Write(s1SubEntry.NumWords);
					binaryWriter2.Write(s1SubEntry.NumS3Entries);
				}
			}
			foreach (ushort num in this.Words)
			{
				short value = (short)num;
				binaryWriter3.Write(value);
			}
			binaryWriter.Write(this._identifier);
			binaryWriter.Write(this.Version);
			binaryWriter.Write(this.S1Entries.Count);
			binaryWriter.Write(this.section1SubEntryCount);
			binaryWriter.Write(this.Words.Count);
			binaryWriter.Write(this._S3Entries.Count);
			binaryWriter.Write(this.section1PreSubEntrySize);
			binaryWriter.Write(this.section1SubEntrySize);
			int num2 = (int)memoryStream.Position;
			binaryWriter.Write(num2 + 12);
			binaryWriter.Write((int)((long)num2 + memoryStream2.Position + 12L));
			binaryWriter.Write((int)((long)num2 + memoryStream2.Position + memoryStream3.Position + 12L));
			binaryWriter.Write(memoryStream2.ToArray());
			binaryWriter.Write(memoryStream3.ToArray());
			foreach (short[] array in this._S3Entries)
			{
				binaryWriter.Write(array[0]);
				binaryWriter.Write(array[1]);
				binaryWriter.Write(array[2]);
			}
			byte[] result = memoryStream.ToArray();
			memoryStream.Dispose();
			binaryWriter.Close();
			return result;
		}

		// Token: 0x06000113 RID: 275 RVA: 0x00003309 File Offset: 0x00001509
		public override int ReplaceReferences(ResKey from, ResKey to)
		{
			return 0;
		}

		// Token: 0x0400005B RID: 91
		private uint _identifier;

		// Token: 0x04000060 RID: 96
		private uint section1SubEntryCount;

		// Token: 0x04000061 RID: 97
		private uint section1PreSubEntrySize;

		// Token: 0x04000062 RID: 98
		private uint section1SubEntrySize;

		// Token: 0x020000FB RID: 251
		public class S1Entry
		{
			// Token: 0x170003E3 RID: 995
			// (get) Token: 0x06000C79 RID: 3193 RVA: 0x00008DA5 File Offset: 0x00006FA5
			// (set) Token: 0x06000C7A RID: 3194 RVA: 0x00008DAD File Offset: 0x00006FAD
			public uint AgeGenderFlags { get; set; }

			// Token: 0x170003E4 RID: 996
			// (get) Token: 0x06000C7B RID: 3195 RVA: 0x00008DB6 File Offset: 0x00006FB6
			// (set) Token: 0x06000C7C RID: 3196 RVA: 0x00008DBE File Offset: 0x00006FBE
			public uint FacialRegion { get; set; }

			// Token: 0x170003E5 RID: 997
			// (get) Token: 0x06000C7D RID: 3197 RVA: 0x00008DC7 File Offset: 0x00006FC7
			// (set) Token: 0x06000C7E RID: 3198 RVA: 0x00008DCF File Offset: 0x00006FCF
			public List<BGEO.S1SubEntry> SubEntries { get; set; }

			// Token: 0x06000C7F RID: 3199 RVA: 0x00008DD8 File Offset: 0x00006FD8
			public S1Entry()
			{
				this.SubEntries = new List<BGEO.S1SubEntry>();
			}
		}

		// Token: 0x020000FC RID: 252
		public class BlendVertex
		{
			// Token: 0x170003E6 RID: 998
			// (get) Token: 0x06000C80 RID: 3200 RVA: 0x00008DEB File Offset: 0x00006FEB
			// (set) Token: 0x06000C81 RID: 3201 RVA: 0x00008DF3 File Offset: 0x00006FF3
			public int VertexID { get; set; }

			// Token: 0x170003E7 RID: 999
			// (get) Token: 0x06000C82 RID: 3202 RVA: 0x00008DFC File Offset: 0x00006FFC
			// (set) Token: 0x06000C83 RID: 3203 RVA: 0x00008E04 File Offset: 0x00007004
			public bool HasPosition { get; set; }

			// Token: 0x170003E8 RID: 1000
			// (get) Token: 0x06000C84 RID: 3204 RVA: 0x00008E0D File Offset: 0x0000700D
			// (set) Token: 0x06000C85 RID: 3205 RVA: 0x00008E15 File Offset: 0x00007015
			public bool HasNormal { get; set; }

			// Token: 0x170003E9 RID: 1001
			// (get) Token: 0x06000C86 RID: 3206 RVA: 0x00008E1E File Offset: 0x0000701E
			// (set) Token: 0x06000C87 RID: 3207 RVA: 0x00008E26 File Offset: 0x00007026
			public float[] Position { get; set; }

			// Token: 0x170003EA RID: 1002
			// (get) Token: 0x06000C88 RID: 3208 RVA: 0x00008E2F File Offset: 0x0000702F
			// (set) Token: 0x06000C89 RID: 3209 RVA: 0x00008E37 File Offset: 0x00007037
			public float[] Normal { get; set; }

			// Token: 0x170003EB RID: 1003
			// (get) Token: 0x06000C8A RID: 3210 RVA: 0x00008E40 File Offset: 0x00007040
			// (set) Token: 0x06000C8B RID: 3211 RVA: 0x00008E48 File Offset: 0x00007048
			public int PositionInList { get; set; }
		}

		// Token: 0x020000FD RID: 253
		public class S1SubEntry
		{
			// Token: 0x170003EC RID: 1004
			// (get) Token: 0x06000C8D RID: 3213 RVA: 0x00008E51 File Offset: 0x00007051
			// (set) Token: 0x06000C8E RID: 3214 RVA: 0x00008E59 File Offset: 0x00007059
			public int StartVertexId { get; set; }

			// Token: 0x170003ED RID: 1005
			// (get) Token: 0x06000C8F RID: 3215 RVA: 0x00008E62 File Offset: 0x00007062
			// (set) Token: 0x06000C90 RID: 3216 RVA: 0x00008E6A File Offset: 0x0000706A
			public uint NumWords { get; set; }

			// Token: 0x170003EE RID: 1006
			// (get) Token: 0x06000C91 RID: 3217 RVA: 0x00008E73 File Offset: 0x00007073
			// (set) Token: 0x06000C92 RID: 3218 RVA: 0x00008E7B File Offset: 0x0000707B
			public uint NumS3Entries { get; set; }

			// Token: 0x170003EF RID: 1007
			// (get) Token: 0x06000C93 RID: 3219 RVA: 0x00008E84 File Offset: 0x00007084
			// (set) Token: 0x06000C94 RID: 3220 RVA: 0x00008E8C File Offset: 0x0000708C
			public List<BGEO.BlendVertex> Vertices { get; set; }

			// Token: 0x06000C95 RID: 3221 RVA: 0x00008E95 File Offset: 0x00007095
			public S1SubEntry()
			{
				this.Vertices = new List<BGEO.BlendVertex>();
			}

			// Token: 0x06000C96 RID: 3222 RVA: 0x0003D9F8 File Offset: 0x0003BBF8
			public BGEO.BlendVertex GetVertex(int vertexId)
			{
				int num = vertexId - this.StartVertexId;
				if ((long)num < (long)((ulong)this.NumWords) && num >= 0)
				{
					return this.Vertices[num];
				}
				return null;
			}
		}
	}
}
