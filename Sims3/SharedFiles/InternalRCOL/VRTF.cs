using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using Sims3WorkshopSDK;

namespace Package.SharedFiles.InternalRCOL
{
	// Token: 0x020000C7 RID: 199
	public class VRTF : RCOLItem, ICloneable
	{
		// Token: 0x17000373 RID: 883
		// (get) Token: 0x06000A65 RID: 2661 RVA: 0x00007D5B File Offset: 0x00005F5B
		// (set) Token: 0x06000A66 RID: 2662 RVA: 0x00007D63 File Offset: 0x00005F63
		[TypeConverter(typeof(IntTypeConverter))]
		public uint Type { get; set; }

		// Token: 0x17000374 RID: 884
		// (get) Token: 0x06000A67 RID: 2663 RVA: 0x00007D6C File Offset: 0x00005F6C
		// (set) Token: 0x06000A68 RID: 2664 RVA: 0x00007D74 File Offset: 0x00005F74
		[TypeConverter(typeof(IntTypeConverter))]
		public uint BytesPerVertex { get; set; }

		// Token: 0x17000375 RID: 885
		// (get) Token: 0x06000A69 RID: 2665 RVA: 0x00007D7D File Offset: 0x00005F7D
		[Browsable(false)]
		public int DeclarationCount
		{
			get
			{
				return this.Entries.Count;
			}
		}

		// Token: 0x17000376 RID: 886
		// (get) Token: 0x06000A6A RID: 2666 RVA: 0x00007D8A File Offset: 0x00005F8A
		// (set) Token: 0x06000A6B RID: 2667 RVA: 0x00007D92 File Offset: 0x00005F92
		public List<VertexFormatEntry> Entries { get; set; }

		// Token: 0x17000377 RID: 887
		// (get) Token: 0x06000A6C RID: 2668 RVA: 0x00007D9B File Offset: 0x00005F9B
		// (set) Token: 0x06000A6D RID: 2669 RVA: 0x00007DA3 File Offset: 0x00005FA3
		[TypeConverter(typeof(IntTypeConverter))]
		public uint Unknown { get; set; }

		// Token: 0x17000378 RID: 888
		// (get) Token: 0x06000A6E RID: 2670 RVA: 0x00007DAC File Offset: 0x00005FAC
		// (set) Token: 0x06000A6F RID: 2671 RVA: 0x00007DB4 File Offset: 0x00005FB4
		private string typeString { get; set; }

		// Token: 0x17000379 RID: 889
		// (get) Token: 0x06000A70 RID: 2672 RVA: 0x00007DBD File Offset: 0x00005FBD
		// (set) Token: 0x06000A71 RID: 2673 RVA: 0x00007DC5 File Offset: 0x00005FC5
		[TypeConverter(typeof(IntTypeConverter))]
		private uint Int2 { get; set; }

		// Token: 0x06000A72 RID: 2674 RVA: 0x00007DCE File Offset: 0x00005FCE
		public VRTF()
		{
			this.Entries = new List<VertexFormatEntry>();
		}

		// Token: 0x1700037A RID: 890
		// (get) Token: 0x06000A73 RID: 2675 RVA: 0x00007DE1 File Offset: 0x00005FE1
		[Browsable(false)]
		public byte[] Data
		{
			get
			{
				return this.data;
			}
		}

		// Token: 0x1700037B RID: 891
		// (get) Token: 0x06000A74 RID: 2676 RVA: 0x00007DE9 File Offset: 0x00005FE9
		[Browsable(false)]
		public int Length
		{
			get
			{
				return (int)this.BytesPerVertex;
			}
		}

		// Token: 0x1700037C RID: 892
		// (get) Token: 0x06000A75 RID: 2677 RVA: 0x00032664 File Offset: 0x00030864
		[Browsable(false)]
		public bool HasNormals
		{
			get
			{
				using (List<VertexFormatEntry>.Enumerator enumerator = this.Entries.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						if (enumerator.Current.Usage == VertexEntryUsage.NORMAL)
						{
							return true;
						}
					}
				}
				return false;
			}
		}

		// Token: 0x06000A76 RID: 2678 RVA: 0x000326C4 File Offset: 0x000308C4
		public static void SetVertexCountForMlodEntry(MLOD.MLODEntry entry, int newVertexCount)
		{
			VBUF vbuf = entry.Parent.Parent.Entries[entry.VBUFIndex + ((entry.Parent.Parent.DataType == 2) ? 1 : 0)] as VBUF;
			if (vbuf != null)
			{
				int num = vbuf.SwiffleInfoIndex & 268435455;
				VertexDeclaration vertexDeclaration = entry.Parent.Parent.Entries[num + ((entry.Parent.Parent.DataType == 2) ? 1 : 0)] as VertexDeclaration;
				if (vertexDeclaration != null)
				{
					foreach (VertexDeclaration.SwiffleInfo swiffleInfo in vertexDeclaration.SwiffleInformation)
					{
						if ((ulong)swiffleInfo.VertexCount == (ulong)((long)entry.VertexCount) && (ulong)swiffleInfo.ByteOffset == (ulong)entry.VBUFOffset)
						{
							swiffleInfo.VertexCount = (uint)newVertexCount;
							entry.SetVertexCount(newVertexCount);
							return;
						}
					}
				}
			}
			throw new Exception("Could not update swiffleinformation for mlodentry: " + entry.ToString());
		}

		// Token: 0x06000A77 RID: 2679 RVA: 0x000327E0 File Offset: 0x000309E0
		public static void SetVertexBufferOffsetForMlodEntry(MLOD.MLODEntry entry, long newOffset)
		{
			VBUF vbuf = entry.Parent.Parent.Entries[entry.VBUFIndex + ((entry.Parent.Parent.DataType == 2) ? 1 : 0)] as VBUF;
			if (vbuf != null)
			{
				int num = vbuf.SwiffleInfoIndex & 268435455;
				VertexDeclaration vertexDeclaration = entry.Parent.Parent.Entries[num + ((entry.Parent.Parent.DataType == 2) ? 1 : 0)] as VertexDeclaration;
				if (vertexDeclaration != null)
				{
					foreach (VertexDeclaration.SwiffleInfo swiffleInfo in vertexDeclaration.SwiffleInformation)
					{
						if ((ulong)swiffleInfo.VertexCount == (ulong)((long)entry.VertexCount) && (ulong)swiffleInfo.ByteOffset == (ulong)entry.VBUFOffset)
						{
							swiffleInfo.ByteOffset = (uint)newOffset;
							entry.SetVertexOffset(newOffset);
							return;
						}
					}
				}
			}
			throw new Exception("Could not update swiffleinformation for mlodentry: " + entry.ToString());
		}

		// Token: 0x06000A78 RID: 2680 RVA: 0x000328FC File Offset: 0x00030AFC
		public static VRTF GetDefaultForType(MLOD.MLODEntry entry)
		{
			VBUF vbuf = entry.Parent.Parent.Entries[entry.VBUFIndex + ((entry.Parent.Parent.DataType == 2) ? 1 : 0)] as VBUF;
			if (vbuf != null)
			{
				int num = vbuf.SwiffleInfoIndex & 268435455;
				VertexDeclaration vertexDeclaration = entry.Parent.Parent.Entries[num + ((entry.Parent.Parent.DataType == 2) ? 1 : 0)] as VertexDeclaration;
				if (vertexDeclaration != null)
				{
					using (List<VertexDeclaration.SwiffleInfo>.Enumerator enumerator = vertexDeclaration.SwiffleInformation.GetEnumerator())
					{
						while (enumerator.MoveNext())
						{
							VertexDeclaration.SwiffleInfo swiffleInfo = enumerator.Current;
							if ((ulong)swiffleInfo.VertexCount == (ulong)((long)entry.VertexCount))
							{
								return VRTF.GetDefaultForLength((int)swiffleInfo.VertexSize);
							}
						}
						goto IL_DA;
					}
					VRTF result;
					return result;
				}
			}
			IL_DA:
			if (entry.Type == 528387U)
			{
				return VRTF.GetDefaultForLength(8);
			}
			if (entry.Type == 1576963U)
			{
				return VRTF.GetDefaultForLength(8);
			}
			if (entry.Type == 20483U)
			{
				return VRTF.GetDefaultForLength(8);
			}
			if (entry.Type == 1591299U)
			{
				return VRTF.GetDefaultForLength(8);
			}
			return VRTF.GetDefaultForLength(16);
		}

		// Token: 0x06000A79 RID: 2681 RVA: 0x00032A4C File Offset: 0x00030C4C
		public static VRTF GetDefaultForLength(int length)
		{
			VRTF vrtf = new VRTF();
			if (length == 8)
			{
				VertexFormatEntry[] collection = new VertexFormatEntry[]
				{
					new VertexFormatEntry
					{
						Index = 0,
						Usage = VertexEntryUsage.POSITION,
						Type = 7
					}
				};
				vrtf.BytesPerVertex = 8U;
				vrtf.Entries = new List<VertexFormatEntry>(collection);
			}
			else if (length == 10)
			{
				vrtf.Entries = new List<VertexFormatEntry>(new VertexFormatEntry[]
				{
					new VertexFormatEntry
					{
						Index = 0,
						Usage = VertexEntryUsage.POSITION,
						Type = 12
					}
				});
			}
			else if (length == 12)
			{
				VertexFormatEntry[] collection2 = new VertexFormatEntry[]
				{
					new VertexFormatEntry
					{
						Index = 0,
						Usage = VertexEntryUsage.POSITION,
						Type = 7
					},
					new VertexFormatEntry
					{
						Index = 0,
						Usage = VertexEntryUsage.NORMAL,
						Type = 7
					},
					new VertexFormatEntry
					{
						Index = 0,
						Usage = VertexEntryUsage.UNKNOWN,
						Type = 8
					}
				};
				vrtf.BytesPerVertex = 12U;
				vrtf.Entries = new List<VertexFormatEntry>(collection2);
			}
			else
			{
				if (length != 16)
				{
					throw new Exception("Unknown vertex size, " + length.ToString());
				}
				VertexFormatEntry[] array = new VertexFormatEntry[2];
				VertexFormatEntry vertexFormatEntry = new VertexFormatEntry();
				vrtf.BytesPerVertex = 16U;
				vertexFormatEntry.Index = 0;
				vertexFormatEntry.Usage = VertexEntryUsage.POSITION;
				vertexFormatEntry.Type = 12;
				array[0] = vertexFormatEntry;
				array[1] = new VertexFormatEntry
				{
					Index = 0,
					Offset = 8,
					Usage = VertexEntryUsage.UV,
					Type = 12
				};
				vrtf.Entries = new List<VertexFormatEntry>(array);
			}
			return vrtf;
		}

		// Token: 0x06000A7A RID: 2682 RVA: 0x00032C0C File Offset: 0x00030E0C
		public override void UnSerialize(BinaryReader reader)
		{
			this.data = reader.ReadBytes((int)reader.BaseStream.Length);
			reader.BaseStream.Position = 0L;
			this.Type = reader.ReadUInt32();
			this.Int2 = reader.ReadUInt32();
			this.BytesPerVertex = reader.ReadUInt32();
			uint num = reader.ReadUInt32();
			this.Unknown = reader.ReadUInt32();
			this.Entries.Clear();
			int num2 = 0;
			while ((long)num2 < (long)((ulong)num))
			{
				VertexFormatEntry vertexFormatEntry = new VertexFormatEntry();
				vertexFormatEntry.UnSerialize(reader);
				this.Entries.Add(vertexFormatEntry);
				num2++;
			}
		}

		// Token: 0x06000A7B RID: 2683 RVA: 0x00032CB0 File Offset: 0x00030EB0
		public override void Serialize(BinaryWriter w)
		{
			w.Write(this.Type);
			w.Write(this.Int2);
			w.Write(this.BytesPerVertex);
			w.Write(this.DeclarationCount);
			w.Write(this.Unknown);
			foreach (VertexFormatEntry vertexFormatEntry in this.Entries)
			{
				vertexFormatEntry.Serialize(w);
			}
		}

		// Token: 0x06000A7C RID: 2684 RVA: 0x00003309 File Offset: 0x00001509
		public override int ReplaceReferences(ResKey from, ResKey to)
		{
			return 0;
		}

		// Token: 0x06000A7D RID: 2685 RVA: 0x00032D40 File Offset: 0x00030F40
		public object Clone()
		{
			VRTF vrtf = new VRTF();
			MemoryStream memoryStream = new MemoryStream();
			BinaryWriter binaryWriter = new BinaryWriter(memoryStream);
			this.Serialize(binaryWriter);
			MemoryStream memoryStream2 = new MemoryStream(memoryStream.ToArray());
			BinaryReader binaryReader = new BinaryReader(memoryStream2);
			vrtf.UnSerialize(binaryReader);
			memoryStream.Dispose();
			memoryStream2.Dispose();
			binaryWriter.Close();
			binaryReader.Close();
			return vrtf;
		}

		// Token: 0x06000A7E RID: 2686 RVA: 0x00007DF1 File Offset: 0x00005FF1
		public override string ToString()
		{
			return "VRTF";
		}

		// Token: 0x04000518 RID: 1304
		[Browsable(false)]
		private byte[] data;
	}
}
