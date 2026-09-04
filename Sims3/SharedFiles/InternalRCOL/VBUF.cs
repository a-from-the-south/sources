using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using Sims3WorkshopSDK;

namespace Package.SharedFiles.InternalRCOL
{
	// Token: 0x020000C3 RID: 195
	public class VBUF : RCOLItem, ICloneable
	{
		// Token: 0x17000364 RID: 868
		// (get) Token: 0x06000A20 RID: 2592 RVA: 0x00007B43 File Offset: 0x00005D43
		// (set) Token: 0x06000A21 RID: 2593 RVA: 0x00007B4B File Offset: 0x00005D4B
		[TypeConverter(typeof(IntTypeConverter))]
		public uint Type { get; set; }

		// Token: 0x17000365 RID: 869
		// (get) Token: 0x06000A22 RID: 2594 RVA: 0x00007B54 File Offset: 0x00005D54
		// (set) Token: 0x06000A23 RID: 2595 RVA: 0x00007B5C File Offset: 0x00005D5C
		[TypeConverter(typeof(IntTypeConverter))]
		public uint Unk1 { get; set; }

		// Token: 0x17000366 RID: 870
		// (get) Token: 0x06000A24 RID: 2596 RVA: 0x00007B65 File Offset: 0x00005D65
		// (set) Token: 0x06000A25 RID: 2597 RVA: 0x00007B6D File Offset: 0x00005D6D
		[TypeConverter(typeof(IntTypeConverter))]
		public uint Unk2 { get; set; }

		// Token: 0x17000367 RID: 871
		// (get) Token: 0x06000A26 RID: 2598 RVA: 0x00007B76 File Offset: 0x00005D76
		// (set) Token: 0x06000A27 RID: 2599 RVA: 0x00007B7E File Offset: 0x00005D7E
		[TypeConverter(typeof(IntTypeConverter))]
		public int SwiffleInfoIndex { get; set; }

		// Token: 0x17000368 RID: 872
		// (get) Token: 0x06000A28 RID: 2600 RVA: 0x00007B87 File Offset: 0x00005D87
		// (set) Token: 0x06000A29 RID: 2601 RVA: 0x00007B8F File Offset: 0x00005D8F
		[Browsable(false)]
		public int BufferLength { get; private set; }

		// Token: 0x17000369 RID: 873
		// (get) Token: 0x06000A2A RID: 2602 RVA: 0x00007B98 File Offset: 0x00005D98
		// (set) Token: 0x06000A2B RID: 2603 RVA: 0x00007BA0 File Offset: 0x00005DA0
		[Browsable(false)]
		public bool HasChanged { get; set; }

		// Token: 0x06000A2C RID: 2604 RVA: 0x00007BA9 File Offset: 0x00005DA9
		public VBUF(RCOL parent)
		{
			this.parent = parent;
		}

		// Token: 0x1700036A RID: 874
		// (get) Token: 0x06000A2D RID: 2605 RVA: 0x00007BB8 File Offset: 0x00005DB8
		// (set) Token: 0x06000A2E RID: 2606 RVA: 0x00007BC0 File Offset: 0x00005DC0
		public byte[] Buffer
		{
			get
			{
				return this.data;
			}
			set
			{
				this.data = value;
				if (this._ms != null)
				{
					this._ms.Dispose();
					this._ms = null;
				}
			}
		}

		// Token: 0x06000A2F RID: 2607 RVA: 0x0002FBA8 File Offset: 0x0002DDA8
		public override string ToString()
		{
			return "Vertex Buffer " + this.BufferLength.ToString() + " bytes";
		}

		// Token: 0x06000A30 RID: 2608 RVA: 0x00007BE3 File Offset: 0x00005DE3
		private void SetData(byte[] data)
		{
			this.data = data;
			if (this._ms != null)
			{
				this._br.Close();
				this._ms.Dispose();
				this._ms = null;
				this._br = null;
			}
		}

		// Token: 0x06000A31 RID: 2609 RVA: 0x00007C18 File Offset: 0x00005E18
		private BinaryReader _getReader()
		{
			if (this._ms == null)
			{
				this._ms = new MemoryStream(this.data);
				this._br = new BinaryReader(this._ms);
			}
			return this._br;
		}

		// Token: 0x06000A32 RID: 2610 RVA: 0x0002FBD4 File Offset: 0x0002DDD4
		public List<object> GetData(int index, VRTF format, VertexFormatEntry entry, long offset)
		{
			List<object> list = new List<object>();
			BinaryReader binaryReader = this._getReader();
			binaryReader.BaseStream.Position = offset + (long)(format.Length * index) + (long)entry.Offset;
			switch (entry.Type)
			{
			case 1:
				list.Add(binaryReader.ReadSingle());
				list.Add(binaryReader.ReadSingle());
				break;
			case 4:
			case 5:
			case 8:
				list.Add(binaryReader.ReadByte());
				list.Add(binaryReader.ReadByte());
				list.Add(binaryReader.ReadByte());
				list.Add(binaryReader.ReadByte());
				break;
			case 6:
			case 9:
				list.Add(binaryReader.ReadInt16());
				list.Add(binaryReader.ReadInt16());
				break;
			case 7:
			case 10:
			case 12:
				list.Add(binaryReader.ReadInt16());
				list.Add(binaryReader.ReadInt16());
				list.Add(binaryReader.ReadInt16());
				list.Add(binaryReader.ReadInt16());
				break;
			}
			return list;
		}

		// Token: 0x06000A33 RID: 2611 RVA: 0x0002FD28 File Offset: 0x0002DF28
		public StreamVector4 GetPosition(VRTF format, int index, long offset, int usageIndex, StreamVector3 scalar)
		{
			StreamVector4 streamVector = new StreamVector4();
			BinaryReader binaryReader = this._getReader();
			foreach (VertexFormatEntry vertexFormatEntry in format.Entries)
			{
				if (vertexFormatEntry.Index == usageIndex && vertexFormatEntry.Usage == VertexEntryUsage.POSITION)
				{
					binaryReader.BaseStream.Position = offset + (long)(format.Length * index) + (long)vertexFormatEntry.Offset;
					if (vertexFormatEntry.Type == 13)
					{
						float num = (float)binaryReader.ReadByte();
						float num2 = (float)binaryReader.ReadByte();
						float num3 = (float)binaryReader.ReadByte();
						streamVector.X = num3 / 255f;
						streamVector.Y = num2 / 255f;
						streamVector.Z = num / 255f;
						break;
					}
					if (vertexFormatEntry.Type == 2 && vertexFormatEntry.SizeBytes == 12U)
					{
						streamVector.X = binaryReader.ReadSingle();
						streamVector.Y = binaryReader.ReadSingle();
						streamVector.Z = binaryReader.ReadSingle();
					}
					else
					{
						if (vertexFormatEntry.Type == 2 && vertexFormatEntry.SizeBytes == 3U)
						{
							streamVector.Z = (float)binaryReader.ReadByte();
							streamVector.Y = (float)binaryReader.ReadByte();
							streamVector.X = (float)binaryReader.ReadByte();
							break;
						}
						if (vertexFormatEntry.Type == 2)
						{
							throw new Exception("Expected bytesize does not match VertexEntryType.FLOAT3");
						}
					}
					if (vertexFormatEntry.Type == 3)
					{
						streamVector.Z = (float)binaryReader.ReadByte();
						streamVector.Y = (float)binaryReader.ReadByte();
						streamVector.X = (float)binaryReader.ReadByte();
						streamVector.W = (float)binaryReader.ReadByte();
						streamVector.Normalize();
						break;
					}
					if (vertexFormatEntry.Type == 7)
					{
						float num4 = (float)binaryReader.ReadInt16();
						float num5 = (float)binaryReader.ReadInt16();
						float num6 = (float)binaryReader.ReadInt16();
						float num7 = (float)binaryReader.ReadUInt16();
						if (num7 == 0f)
						{
							num7 = 32768f;
						}
						float num8 = 1f / num7;
						float num9 = 1f / num7;
						float num10 = 1f / num7;
						if (scalar != null)
						{
							num8 = scalar.X;
							num9 = scalar.Y;
							num10 = scalar.Z;
						}
						streamVector.X = num4 * num8;
						streamVector.Y = num5 * num9;
						streamVector.Z = num6 * num10;
						break;
					}
					if (vertexFormatEntry.Type == 12)
					{
						short num11 = binaryReader.ReadInt16();
						short num12 = binaryReader.ReadInt16();
						short num13 = binaryReader.ReadInt16();
						float num14 = (float)binaryReader.ReadUInt16();
						if (num14 == 0f)
						{
							num14 = 512f;
						}
						streamVector.X = (float)num11 / num14;
						streamVector.Y = (float)num12 / num14;
						streamVector.Z = (float)num13 / num14;
						break;
					}
				}
			}
			return streamVector;
		}

		// Token: 0x06000A34 RID: 2612 RVA: 0x00030014 File Offset: 0x0002E214
		public StreamVector4 GetNormal(VRTF format, int index, long offset, int usageIndex)
		{
			StreamVector4 streamVector = new StreamVector4();
			BinaryReader binaryReader = this._getReader();
			foreach (VertexFormatEntry vertexFormatEntry in format.Entries)
			{
				if (vertexFormatEntry.Index == usageIndex && vertexFormatEntry.Usage == VertexEntryUsage.NORMAL)
				{
					binaryReader.BaseStream.Position = offset + (long)(format.Length * index) + (long)vertexFormatEntry.Offset;
					switch (vertexFormatEntry.Type)
					{
					case 2:
						streamVector.X = binaryReader.ReadSingle();
						streamVector.Y = binaryReader.ReadSingle();
						streamVector.Z = binaryReader.ReadSingle();
						break;
					case 3:
						streamVector.X = binaryReader.ReadSingle();
						streamVector.Y = binaryReader.ReadSingle();
						streamVector.Z = binaryReader.ReadSingle();
						streamVector.W = binaryReader.ReadSingle();
						break;
					case 5:
					{
						byte b = binaryReader.ReadByte();
						byte b2 = binaryReader.ReadByte();
						byte b3 = binaryReader.ReadByte();
						byte b4 = binaryReader.ReadByte();
						byte b5 = byte.MaxValue - b4;
						if (b5 == 0)
						{
							b5 = 127;
						}
						streamVector.Z = (float)(b - ((b > 127) ? 128 : 127)) / (float)b5;
						streamVector.Y = (float)(b2 - ((b2 > 127) ? 128 : 127)) / (float)b5;
						streamVector.X = (float)(b3 - ((b3 > 127) ? 128 : 127)) / (float)b5;
						break;
					}
					case 7:
					{
						float num = (float)binaryReader.ReadInt16();
						float num2 = (float)binaryReader.ReadInt16();
						float num3 = (float)binaryReader.ReadInt16();
						float num4 = (float)binaryReader.ReadUInt16();
						if (num4 == 0f)
						{
							num4 = 32768f;
						}
						streamVector.X = num * (1f / num4);
						streamVector.Y = num2 * (1f / num4);
						streamVector.Z = num3 * (1f / num4);
						break;
					}
					case 8:
					{
						sbyte b6 = binaryReader.ReadSByte();
						sbyte b7 = binaryReader.ReadSByte();
						sbyte b8 = binaryReader.ReadSByte();
						sbyte b9 = binaryReader.ReadSByte();
						if (b6 < 0)
						{
							streamVector.X = (float)((int)b6 + 128) / 127f;
						}
						else
						{
							streamVector.X = (float)((int)b6 - 128) / 127f;
						}
						if (b7 < 0)
						{
							streamVector.Y = (float)((int)b7 + 128) / 127f;
						}
						else
						{
							streamVector.Y = (float)((int)b7 - 128) / 127f;
						}
						if (b8 < 0)
						{
							streamVector.Z = (float)((int)b8 + 128) / 127f;
						}
						else
						{
							streamVector.Z = (float)((int)b8 - 128) / 127f;
						}
						if (b9 < 0)
						{
							streamVector.W = (float)((int)b9 + 128) / 127f;
						}
						else
						{
							streamVector.W = (float)((int)b9 - 128) / 127f;
						}
						break;
					}
					case 12:
					{
						float num5 = (float)binaryReader.ReadInt16();
						float num6 = (float)binaryReader.ReadInt16();
						float num7 = (float)binaryReader.ReadInt16();
						float num8 = (float)binaryReader.ReadUInt16();
						if (num8 == 0f)
						{
							num8 = 511f;
						}
						streamVector.X = num5 * (1f / num8);
						streamVector.Y = num6 * (1f / num8);
						streamVector.Z = num7 * (1f / num8);
						break;
					}
					case 14:
					{
						float num9 = (float)binaryReader.ReadByte();
						float num10 = (float)binaryReader.ReadByte();
						float num11 = (float)binaryReader.ReadByte();
						streamVector.X = num9 / 255f;
						streamVector.Y = num10 / 255f;
						streamVector.Z = num11 / 255f;
						break;
					}
					}
				}
			}
			return streamVector;
		}

		// Token: 0x06000A35 RID: 2613 RVA: 0x00007C4A File Offset: 0x00005E4A
		public StreamVector4 GetUV(VRTF format, int index, long offset, int usageIndex)
		{
			return this.GetUV(format, index, offset, 0f, false, usageIndex);
		}

		// Token: 0x06000A36 RID: 2614 RVA: 0x000303F8 File Offset: 0x0002E5F8
		public StreamVector4 GetUV(VRTF format, int index, long offset, float selector, bool useUVSelector, int usageIndex)
		{
			StreamVector4 streamVector = new StreamVector4();
			BinaryReader binaryReader = this._getReader();
			foreach (VertexFormatEntry vertexFormatEntry in format.Entries)
			{
				if (vertexFormatEntry.Usage == VertexEntryUsage.UV && vertexFormatEntry.Index == usageIndex)
				{
					binaryReader.BaseStream.Position = offset + (long)(format.Length * index) + (long)vertexFormatEntry.Offset;
					VertexEntryType type = vertexFormatEntry.Type;
					switch (type)
					{
					case 1:
						streamVector.X = binaryReader.ReadSingle();
						streamVector.Y = binaryReader.ReadSingle();
						break;
					case 2:
						streamVector.X = binaryReader.ReadSingle();
						streamVector.Y = binaryReader.ReadSingle();
						streamVector.Y = binaryReader.ReadSingle();
						break;
					case 3:
						streamVector.X = binaryReader.ReadSingle();
						streamVector.Y = binaryReader.ReadSingle();
						streamVector.Z = binaryReader.ReadSingle();
						streamVector.W = binaryReader.ReadSingle();
						break;
					case 4:
					case 5:
						break;
					case 6:
					{
						short num = binaryReader.ReadInt16();
						short num2 = binaryReader.ReadInt16();
						streamVector.X = (float)num * (useUVSelector ? selector : 1f);
						streamVector.Y = (float)num2 * (useUVSelector ? selector : 1f);
						break;
					}
					case 7:
					{
						float num3 = (float)binaryReader.ReadInt16();
						float num4 = (float)binaryReader.ReadInt16();
						binaryReader.ReadInt16();
						float num5 = (float)binaryReader.ReadUInt16();
						if (num5 == 0f)
						{
							num5 = 32768f;
						}
						streamVector.X = num3 * (1f / num5);
						streamVector.Y = num4 * (1f / num5);
						break;
					}
					default:
						if (type == 12)
						{
							float num6 = (float)binaryReader.ReadInt16();
							float num7 = (float)binaryReader.ReadInt16();
							binaryReader.ReadInt16();
							binaryReader.ReadUInt16();
							streamVector.X = num6 * (useUVSelector ? selector : 1f);
							streamVector.Y = num7 * (useUVSelector ? selector : 1f);
						}
						break;
					}
				}
			}
			return streamVector;
		}

		// Token: 0x06000A37 RID: 2615 RVA: 0x00030634 File Offset: 0x0002E834
		public sbyte[] GetAssignment(VRTF format, int index, long offset, int usageIndex)
		{
			sbyte[] array = new sbyte[]
			{
				-1,
				-1,
				-1,
				-1
			};
			BinaryReader binaryReader = this._getReader();
			foreach (VertexFormatEntry vertexFormatEntry in format.Entries)
			{
				if (vertexFormatEntry.Index == usageIndex && vertexFormatEntry.Usage == VertexEntryUsage.ASSIGNMENT)
				{
					binaryReader.BaseStream.Position = offset + (long)(format.Length * index) + (long)vertexFormatEntry.Offset;
					if (vertexFormatEntry.Type == 4)
					{
						array[0] = binaryReader.ReadSByte();
						array[1] = binaryReader.ReadSByte();
						array[2] = binaryReader.ReadSByte();
						array[3] = binaryReader.ReadSByte();
					}
				}
			}
			return array;
		}

		// Token: 0x06000A38 RID: 2616 RVA: 0x000306FC File Offset: 0x0002E8FC
		public float[] GetWeights(VRTF format, int index, long offset, int usageIndex)
		{
			float[] array = new float[4];
			BinaryReader binaryReader = this._getReader();
			foreach (VertexFormatEntry vertexFormatEntry in format.Entries)
			{
				if (vertexFormatEntry.Index == usageIndex && vertexFormatEntry.Usage == VertexEntryUsage.SKIN_WEIGHT)
				{
					binaryReader.BaseStream.Position = offset + (long)(format.Length * index) + (long)vertexFormatEntry.Offset;
					VertexEntryType type = vertexFormatEntry.Type;
					if (type != 3)
					{
						if (type != 5)
						{
							if (type == 8)
							{
								byte b = binaryReader.ReadByte();
								byte b2 = binaryReader.ReadByte();
								byte b3 = binaryReader.ReadByte();
								byte b4 = binaryReader.ReadByte();
								if (b != 0 || b2 != 0 || b3 == 0)
								{
								}
								array[0] = (float)b / 255f;
								array[1] = (float)b2 / 255f;
								array[2] = (float)b3 / 255f;
								array[3] = (float)b4 / 255f;
							}
						}
						else
						{
							byte b5 = binaryReader.ReadByte();
							byte b6 = binaryReader.ReadByte();
							byte b7 = binaryReader.ReadByte();
							byte b8 = binaryReader.ReadByte();
							array[2] = (float)b5 / 255f;
							array[1] = (float)b6 / 255f;
							array[0] = (float)b7 / 255f;
							array[3] = (float)b8 / 255f;
						}
					}
					else
					{
						array[0] = binaryReader.ReadSingle();
						array[1] = binaryReader.ReadSingle();
						array[2] = binaryReader.ReadSingle();
						array[3] = binaryReader.ReadSingle();
					}
				}
			}
			return array;
		}

		// Token: 0x06000A39 RID: 2617 RVA: 0x00030894 File Offset: 0x0002EA94
		public StreamVector4 GetTangent(VRTF format, int index, long offset, int usageIndex)
		{
			StreamVector4 streamVector = new StreamVector4();
			BinaryReader binaryReader = this._getReader();
			foreach (VertexFormatEntry vertexFormatEntry in format.Entries)
			{
				if (vertexFormatEntry.Index == usageIndex && vertexFormatEntry.Usage == VertexEntryUsage.TANGENT)
				{
					binaryReader.BaseStream.Position = offset + (long)(format.Length * index) + (long)vertexFormatEntry.Offset;
					switch (vertexFormatEntry.Type)
					{
					case 2:
						streamVector.X = binaryReader.ReadSingle();
						streamVector.Y = binaryReader.ReadSingle();
						streamVector.Z = binaryReader.ReadSingle();
						break;
					case 3:
						streamVector.X = binaryReader.ReadSingle();
						streamVector.Y = binaryReader.ReadSingle();
						streamVector.Z = binaryReader.ReadSingle();
						streamVector.W = binaryReader.ReadSingle();
						break;
					case 5:
					{
						byte b = binaryReader.ReadByte();
						byte b2 = binaryReader.ReadByte();
						byte b3 = binaryReader.ReadByte();
						byte b4 = binaryReader.ReadByte();
						b4 = byte.MaxValue - b4;
						if (b4 == 0)
						{
							b4 = 127;
						}
						streamVector.Z = (float)(b - 128) / (float)b4;
						streamVector.Y = (float)(b2 - 128) / (float)b4;
						streamVector.X = (float)(b3 - 128) / (float)b4;
						break;
					}
					case 8:
					{
						sbyte b5 = binaryReader.ReadSByte();
						sbyte b6 = binaryReader.ReadSByte();
						sbyte b7 = binaryReader.ReadSByte();
						sbyte b8 = binaryReader.ReadSByte();
						if (b5 < 0)
						{
							streamVector.X = (float)((int)b5 + 128) / 127f;
						}
						else
						{
							streamVector.X = (float)((int)b5 - 128) / 127f;
						}
						if (b6 < 0)
						{
							streamVector.Y = (float)((int)b6 + 128) / 127f;
						}
						else
						{
							streamVector.Y = (float)((int)b6 - 128) / 127f;
						}
						if (b7 < 0)
						{
							streamVector.Z = (float)((int)b7 + 128) / 127f;
						}
						else
						{
							streamVector.Z = (float)((int)b7 - 128) / 127f;
						}
						if (b8 < 0)
						{
							streamVector.W = (float)((int)b8 + 128) / 127f;
						}
						else
						{
							streamVector.W = (float)((int)b8 - 128) / 127f;
						}
						break;
					}
					}
				}
			}
			return streamVector;
		}

		// Token: 0x06000A3A RID: 2618 RVA: 0x00030B20 File Offset: 0x0002ED20
		public byte[] GetUnknown(VRTF format, int index, long offset, int usageIndex)
		{
			BinaryReader binaryReader = this._getReader();
			byte[] result = new byte[]
			{
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue
			};
			foreach (VertexFormatEntry vertexFormatEntry in format.Entries)
			{
				if (vertexFormatEntry.Index == usageIndex && vertexFormatEntry.Usage == VertexEntryUsage.UNKNOWN)
				{
					binaryReader.BaseStream.Position = offset + (long)(format.Length * index) + (long)vertexFormatEntry.Offset;
					VertexEntryType type = vertexFormatEntry.Type;
					if (type - 4 <= 1 || type == 8)
					{
						result = binaryReader.ReadBytes(4);
					}
				}
			}
			return result;
		}

		// Token: 0x06000A3B RID: 2619 RVA: 0x00030BD4 File Offset: 0x0002EDD4
		public void SetPosition(VRTF format, int index, long offset, StreamVector4 position, StreamVector3 positionScalar)
		{
			long num = offset + (long)(format.Length * index);
			foreach (VertexFormatEntry vertexFormatEntry in format.Entries)
			{
				if (vertexFormatEntry.Usage == VertexEntryUsage.POSITION && vertexFormatEntry.Type == 7)
				{
					num += (long)vertexFormatEntry.Offset;
					float num2 = position.X;
					float num3 = position.Y;
					float num4 = position.Z;
					float num5 = 32767f;
					float num6 = 32767f;
					float num7 = 32767f;
					float num8 = 32767f;
					float num9 = Math.Max(Math.Max(Math.Abs(num2), Math.Abs(num3)), Math.Abs(num4));
					if (num9 > 1f)
					{
						num5 = (num8 = (num6 = (num7 = (float)(32767 / (int)Math.Ceiling((double)num9)))));
					}
					if (positionScalar != null)
					{
						num8 = 0f;
						num5 = 1f / positionScalar.X;
						num6 = 1f / positionScalar.Y;
						num7 = 1f / positionScalar.Z;
					}
					num2 = num5 * num2;
					num3 = num6 * num3;
					num4 = num7 * num4;
					this.data[(int)(checked((IntPtr)(unchecked(num + 1L))))] = (byte)((short)num2 >> 8 & 255);
					this.data[(int)(checked((IntPtr)num))] = (byte)((short)num2 & 255);
					this.data[(int)(checked((IntPtr)(unchecked(num + 3L))))] = (byte)((short)num3 >> 8 & 255);
					this.data[(int)(checked((IntPtr)(unchecked(num + 2L))))] = (byte)((short)num3 & 255);
					this.data[(int)(checked((IntPtr)(unchecked(num + 5L))))] = (byte)((short)num4 >> 8 & 255);
					this.data[(int)(checked((IntPtr)(unchecked(num + 4L))))] = (byte)((short)num4 & 255);
					this.data[(int)(checked((IntPtr)(unchecked(num + 7L))))] = (byte)((short)num8 >> 8 & 255);
					this.data[(int)(checked((IntPtr)(unchecked(num + 6L))))] = (byte)((short)num8 & 255);
					break;
				}
			}
		}

		// Token: 0x06000A3C RID: 2620 RVA: 0x00030E04 File Offset: 0x0002F004
		public void SetNormal(VRTF format, int index, long offset, StreamVector4 normal)
		{
			long num = offset + (long)(format.Length * index);
			foreach (VertexFormatEntry vertexFormatEntry in format.Entries)
			{
				if (vertexFormatEntry.Usage == VertexEntryUsage.NORMAL)
				{
					if (vertexFormatEntry.Type == 8)
					{
						num += (long)vertexFormatEntry.Offset;
						float x = normal.X;
						float y = normal.Y;
						float z = normal.Z;
						float w = normal.W;
						sbyte b;
						if (x >= 0f)
						{
							b = (sbyte)(127f * x - 128f);
						}
						else
						{
							b = (sbyte)(127f * x + 128f);
						}
						sbyte b2;
						if (y >= 0f)
						{
							b2 = (sbyte)(127f * y - 128f);
						}
						else
						{
							b2 = (sbyte)(127f * y + 128f);
						}
						sbyte b3;
						if (z >= 0f)
						{
							b3 = (sbyte)(127f * z - 128f);
						}
						else
						{
							b3 = (sbyte)(127f * z + 128f);
						}
						sbyte b4;
						if (w >= 0f)
						{
							b4 = (sbyte)(127f * w - 128f);
						}
						else
						{
							b4 = (sbyte)(127f * w + 128f);
						}
						sbyte b5 = b;
						sbyte b6 = b2;
						sbyte b7 = b3;
						sbyte b8 = b4;
						this.data[(int)(checked((IntPtr)num))] = (byte)b5;
						this.data[(int)(checked((IntPtr)(unchecked(num + 1L))))] = (byte)b6;
						this.data[(int)(checked((IntPtr)(unchecked(num + 2L))))] = (byte)b7;
						this.data[(int)(checked((IntPtr)(unchecked(num + 3L))))] = (byte)b8;
					}
					else if (vertexFormatEntry.Type == 12)
					{
						num += (long)vertexFormatEntry.Offset;
						float num2 = normal.X;
						float num3 = normal.Y;
						float num4 = normal.Z;
						float num5 = 512f;
						num2 = 512f * num2;
						num3 = 512f * num3;
						num4 = num5 * num4;
						float num6 = num2;
						float num7 = num3;
						float num8 = num4;
						this.data[(int)(checked((IntPtr)(unchecked(num + 1L))))] = (byte)((short)num6 >> 8 & 255);
						this.data[(int)(checked((IntPtr)num))] = (byte)((short)num6 & 255);
						this.data[(int)(checked((IntPtr)(unchecked(num + 3L))))] = (byte)((short)num7 >> 8 & 255);
						this.data[(int)(checked((IntPtr)(unchecked(num + 2L))))] = (byte)((short)num7 & 255);
						this.data[(int)(checked((IntPtr)(unchecked(num + 5L))))] = (byte)((short)num8 >> 8 & 255);
						this.data[(int)(checked((IntPtr)(unchecked(num + 4L))))] = (byte)((short)num8 & 255);
						checked
						{
							this.data[(int)((IntPtr)(unchecked(num + 7L)))] = 0;
							this.data[(int)((IntPtr)(unchecked(num + 6L)))] = 0;
						}
					}
					else if (vertexFormatEntry.Type == 5)
					{
						num += (long)vertexFormatEntry.Offset;
						float x2 = normal.X;
						float num9 = normal.Y;
						float num10 = normal.Z;
						float num11 = (float)Math.Sqrt((double)(x2 * x2 + num9 * num9 + num10 * num10));
						double num12 = Math.Round((double)(127f / num11));
						if (num12 > 255.0)
						{
							num12 = 255.0;
						}
						float num13 = x2 / num11;
						num9 /= num11;
						num10 /= num11;
						float num14 = num10 / 0.007874016f;
						float num15 = num9 / 0.007874016f;
						float num16 = num13 / 0.007874016f;
						num14 = ((num14 == 0f) ? 127f : ((num14 < 0f) ? (num14 + 127f) : (num14 + 128f)));
						num15 = ((num15 == 0f) ? 127f : ((num15 < 0f) ? (num15 + 127f) : (num15 + 128f)));
						num16 = ((num16 == 0f) ? 127f : ((num16 < 0f) ? (num16 + 127f) : (num16 + 128f)));
						this.data[(int)(checked((IntPtr)num))] = (byte)Math.Round((double)num14);
						this.data[(int)(checked((IntPtr)(unchecked(num + 1L))))] = (byte)Math.Round((double)num15);
						this.data[(int)(checked((IntPtr)(unchecked(num + 2L))))] = (byte)Math.Round((double)num16);
						this.data[(int)(checked((IntPtr)(unchecked(num + 3L))))] = (byte)((num12 == 127.0) ? 255.0 : (255.0 - num12));
					}
				}
			}
		}

		// Token: 0x06000A3D RID: 2621 RVA: 0x000312AC File Offset: 0x0002F4AC
		public void SetTangent(VRTF format, int index, long offset, StreamVector4 tangent)
		{
			long num = offset + (long)(format.Length * index);
			foreach (VertexFormatEntry vertexFormatEntry in format.Entries)
			{
				if (vertexFormatEntry.Usage == VertexEntryUsage.TANGENT)
				{
					if (vertexFormatEntry.Type == 8)
					{
						num += (long)vertexFormatEntry.Offset;
						float x = tangent.X;
						float y = tangent.Y;
						float z = tangent.Z;
						float w = tangent.W;
						sbyte b;
						if (x >= 0f)
						{
							b = (sbyte)(127f * x - 128f);
						}
						else
						{
							b = (sbyte)(127f * x + 128f);
						}
						sbyte b2;
						if (y >= 0f)
						{
							b2 = (sbyte)(127f * y - 128f);
						}
						else
						{
							b2 = (sbyte)(127f * y + 128f);
						}
						sbyte b3;
						if (z >= 0f)
						{
							b3 = (sbyte)(127f * z - 128f);
						}
						else
						{
							b3 = (sbyte)(127f * z + 128f);
						}
						sbyte b4;
						if (w >= 0f)
						{
							b4 = (sbyte)(127f * w - 128f);
						}
						else
						{
							b4 = (sbyte)(127f * w + 128f);
						}
						sbyte b5 = b;
						sbyte b6 = b2;
						sbyte b7 = b3;
						sbyte b8 = b4;
						this.data[(int)(checked((IntPtr)num))] = (byte)b5;
						this.data[(int)(checked((IntPtr)(unchecked(num + 1L))))] = (byte)b6;
						this.data[(int)(checked((IntPtr)(unchecked(num + 2L))))] = (byte)b7;
						this.data[(int)(checked((IntPtr)(unchecked(num + 3L))))] = (byte)b8;
					}
					else if (vertexFormatEntry.Type == 12)
					{
						num += (long)vertexFormatEntry.Offset;
						float num2 = tangent.X;
						float num3 = tangent.Y;
						float num4 = tangent.Z;
						float num5 = 512f;
						num2 = 512f * num2;
						num3 = 512f * num3;
						num4 = num5 * num4;
						float num6 = num2;
						float num7 = num3;
						float num8 = num4;
						this.data[(int)(checked((IntPtr)(unchecked(num + 1L))))] = (byte)((short)num6 >> 8 & 255);
						this.data[(int)(checked((IntPtr)num))] = (byte)((short)num6 & 255);
						this.data[(int)(checked((IntPtr)(unchecked(num + 3L))))] = (byte)((short)num7 >> 8 & 255);
						this.data[(int)(checked((IntPtr)(unchecked(num + 2L))))] = (byte)((short)num7 & 255);
						this.data[(int)(checked((IntPtr)(unchecked(num + 5L))))] = (byte)((short)num8 >> 8 & 255);
						this.data[(int)(checked((IntPtr)(unchecked(num + 4L))))] = (byte)((short)num8 & 255);
						checked
						{
							this.data[(int)((IntPtr)(unchecked(num + 7L)))] = 0;
							this.data[(int)((IntPtr)(unchecked(num + 6L)))] = 0;
						}
					}
					else if (vertexFormatEntry.Type == 5)
					{
						num += (long)vertexFormatEntry.Offset;
						float x2 = tangent.X;
						float num9 = tangent.Y;
						float num10 = tangent.Z;
						float num11 = (float)Math.Sqrt((double)(x2 * x2 + num9 * num9 + num10 * num10));
						double num12 = Math.Round((double)(127f / num11));
						if (num12 > 255.0)
						{
							num12 = 255.0;
						}
						float num13 = x2 / num11;
						num9 /= num11;
						num10 /= num11;
						float num14 = num10 / 0.007874016f;
						float num15 = num9 / 0.007874016f;
						float num16 = num13 / 0.007874016f;
						num14 = ((num14 == 0f) ? 127f : ((num14 < 0f) ? (num14 + 127f) : (num14 + 128f)));
						num15 = ((num15 == 0f) ? 127f : ((num15 < 0f) ? (num15 + 127f) : (num15 + 128f)));
						num16 = ((num16 == 0f) ? 127f : ((num16 < 0f) ? (num16 + 127f) : (num16 + 128f)));
						this.data[(int)(checked((IntPtr)num))] = (byte)Math.Round((double)num14);
						this.data[(int)(checked((IntPtr)(unchecked(num + 1L))))] = (byte)Math.Round((double)num15);
						this.data[(int)(checked((IntPtr)(unchecked(num + 2L))))] = (byte)Math.Round((double)num16);
						this.data[(int)(checked((IntPtr)(unchecked(num + 3L))))] = (byte)((num12 == 127.0) ? 255.0 : (255.0 - num12));
					}
				}
			}
		}

		// Token: 0x06000A3E RID: 2622 RVA: 0x00031754 File Offset: 0x0002F954
		public void SetUV(VRTF format, int index, long offset, StreamVector4 uv, int usageIndex, float scalar)
		{
			long num = offset + (long)(format.Length * index);
			foreach (VertexFormatEntry vertexFormatEntry in format.Entries)
			{
				if (vertexFormatEntry.Usage == VertexEntryUsage.UV && vertexFormatEntry.Index == usageIndex)
				{
					if (vertexFormatEntry.Type == 7)
					{
						num += (long)vertexFormatEntry.Offset;
						ushort num2 = (ushort)(uv.X * 32768f);
						ushort num3 = (ushort)(uv.Y * 32768f);
						this.data[(int)(checked((IntPtr)(unchecked(num + 1L))))] = (byte)((short)num2 >> 8 & 255);
						this.data[(int)(checked((IntPtr)num))] = (byte)((short)num2 & 255);
						this.data[(int)(checked((IntPtr)(unchecked(num + 3L))))] = (byte)((short)num3 >> 8 & 255);
						this.data[(int)(checked((IntPtr)(unchecked(num + 2L))))] = (byte)((short)num3 & 255);
						checked
						{
							this.data[(int)((IntPtr)(unchecked(num + 5L)))] = 0;
							this.data[(int)((IntPtr)(unchecked(num + 4L)))] = 0;
							this.data[(int)((IntPtr)(unchecked(num + 7L)))] = 128;
							this.data[(int)((IntPtr)(unchecked(num + 6L)))] = 0;
						}
					}
					else if (vertexFormatEntry.Type == 6)
					{
						num += (long)vertexFormatEntry.Offset;
						short num4 = (short)(uv.X / scalar);
						short num5 = (short)(uv.Y / scalar);
						this.data[(int)(checked((IntPtr)(unchecked(num + 1L))))] = (byte)(num4 >> 8 & 255);
						this.data[(int)(checked((IntPtr)num))] = (byte)(num4 & 255);
						this.data[(int)(checked((IntPtr)(unchecked(num + 3L))))] = (byte)(num5 >> 8 & 255);
						this.data[(int)(checked((IntPtr)(unchecked(num + 2L))))] = (byte)(num5 & 255);
					}
					else if (vertexFormatEntry.Type == 12)
					{
						num += (long)vertexFormatEntry.Offset;
						float num6 = uv.X;
						float num7 = uv.Y;
						num6 = 32768f * num6;
						num7 = 32768f * num7;
						float num8 = num6;
						float num9 = num7;
						this.data[(int)(checked((IntPtr)(unchecked(num + 1L))))] = (byte)((short)num8 >> 8 & 255);
						this.data[(int)(checked((IntPtr)num))] = (byte)((short)num8 & 255);
						this.data[(int)(checked((IntPtr)(unchecked(num + 3L))))] = (byte)((short)num9 >> 8 & 255);
						this.data[(int)(checked((IntPtr)(unchecked(num + 2L))))] = (byte)((short)num9 & 255);
						checked
						{
							this.data[(int)((IntPtr)(unchecked(num + 5L)))] = 0;
							this.data[(int)((IntPtr)(unchecked(num + 4L)))] = 0;
							this.data[(int)((IntPtr)(unchecked(num + 7L)))] = 0;
							this.data[(int)((IntPtr)(unchecked(num + 6L)))] = 0;
						}
					}
				}
			}
		}

		// Token: 0x06000A3F RID: 2623 RVA: 0x00031A74 File Offset: 0x0002FC74
		public void SetAssignment(VRTF format, int index, long offset, sbyte[] a)
		{
			long num = offset + (long)(format.Length * index);
			foreach (VertexFormatEntry vertexFormatEntry in format.Entries)
			{
				if (vertexFormatEntry.Usage == VertexEntryUsage.ASSIGNMENT && vertexFormatEntry.Type == 4)
				{
					num += (long)vertexFormatEntry.Offset;
					this.data[(int)(checked((IntPtr)num))] = (byte)a[0];
					this.data[(int)(checked((IntPtr)(unchecked(num + 1L))))] = (byte)a[1];
					this.data[(int)(checked((IntPtr)(unchecked(num + 2L))))] = (byte)a[2];
					this.data[(int)(checked((IntPtr)(unchecked(num + 3L))))] = (byte)a[3];
				}
			}
		}

		// Token: 0x06000A40 RID: 2624 RVA: 0x00031B44 File Offset: 0x0002FD44
		public void SetUnknown(VRTF format, int index, long offset, int usageIndex, byte[] a)
		{
			long num = offset + (long)(format.Length * index);
			foreach (VertexFormatEntry vertexFormatEntry in format.Entries)
			{
				if (vertexFormatEntry.Usage == VertexEntryUsage.UNKNOWN && vertexFormatEntry.Index == usageIndex)
				{
					VertexEntryType type = vertexFormatEntry.Type;
					if (type - 4 <= 1 || type == 8)
					{
						num += (long)vertexFormatEntry.Offset;
						checked
						{
							this.data[(int)((IntPtr)num)] = a[0];
							this.data[(int)((IntPtr)(unchecked(num + 1L)))] = a[1];
							this.data[(int)((IntPtr)(unchecked(num + 2L)))] = a[2];
							this.data[(int)((IntPtr)(unchecked(num + 3L)))] = a[3];
						}
					}
				}
			}
		}

		// Token: 0x06000A41 RID: 2625 RVA: 0x00031C24 File Offset: 0x0002FE24
		public void SetWeights(VRTF format, int index, long offset, float[] a)
		{
			long num = offset + (long)(format.Length * index);
			foreach (VertexFormatEntry vertexFormatEntry in format.Entries)
			{
				if (vertexFormatEntry.Usage == VertexEntryUsage.SKIN_WEIGHT && vertexFormatEntry.Type == 5)
				{
					num += (long)vertexFormatEntry.Offset;
					byte b = (byte)Math.Round((double)(a[2] * 255f));
					byte b2 = (byte)Math.Round((double)(a[1] * 255f));
					byte b3 = (byte)Math.Round((double)(a[0] * 255f));
					byte b4 = (byte)Math.Round((double)(a[3] * 255f));
					checked
					{
						this.data[(int)((IntPtr)num)] = b;
						this.data[(int)((IntPtr)(unchecked(num + 1L)))] = b2;
						this.data[(int)((IntPtr)(unchecked(num + 2L)))] = b3;
						this.data[(int)((IntPtr)(unchecked(num + 3L)))] = b4;
					}
				}
			}
		}

		// Token: 0x06000A42 RID: 2626 RVA: 0x00031D3C File Offset: 0x0002FF3C
		public override void UnSerialize(BinaryReader reader)
		{
			this.Type = reader.ReadUInt32();
			this.Unk1 = reader.ReadUInt32();
			this.Unk2 = reader.ReadUInt32();
			this.SwiffleInfoIndex = reader.ReadInt32();
			this.data = reader.ReadBytes((int)reader.BaseStream.Length - 16);
			this.BufferLength = this.data.Length;
		}

		// Token: 0x06000A43 RID: 2627 RVA: 0x00007C5D File Offset: 0x00005E5D
		public override void Serialize(BinaryWriter writer)
		{
			writer.Write(this.Type);
			writer.Write(this.Unk1);
			writer.Write(this.Unk2);
			writer.Write(this.SwiffleInfoIndex);
			writer.Write(this.data);
		}

		// Token: 0x06000A44 RID: 2628 RVA: 0x00003309 File Offset: 0x00001509
		public override int ReplaceReferences(ResKey from, ResKey to)
		{
			return 0;
		}

		// Token: 0x06000A45 RID: 2629 RVA: 0x00031DA4 File Offset: 0x0002FFA4
		public void RemoveMLODEntryData(MLOD.MLODEntry mlodEntry)
		{
			RCOL rcol = mlodEntry.Parent.Parent;
			VBUF vbuf = rcol.Entries[mlodEntry.VBUFIndex + ((rcol.DataType == 2) ? 1 : 0)] as VBUF;
			VertexDeclaration vertexDeclaration = mlodEntry.Parent.Parent.Entries[(vbuf.SwiffleInfoIndex & 268435455) + ((mlodEntry.Parent.Parent.DataType == 2) ? 1 : 0)] as VertexDeclaration;
			if (vertexDeclaration != null)
			{
				VertexDeclaration.SwiffleInfo swiffleInfo = null;
				foreach (VertexDeclaration.SwiffleInfo swiffleInfo2 in vertexDeclaration.SwiffleInformation)
				{
					if ((ulong)swiffleInfo2.VertexCount == (ulong)((long)mlodEntry.VBUFCount) && (ulong)swiffleInfo2.ByteOffset == (ulong)mlodEntry.VBUFOffset)
					{
						swiffleInfo = swiffleInfo2;
					}
				}
				if (swiffleInfo != null)
				{
					vertexDeclaration.SwiffleInformation.Remove(swiffleInfo);
				}
			}
			int vbufindex = mlodEntry.VBUFIndex;
			List<MLOD.MLODEntry> list = new List<MLOD.MLODEntry>();
			foreach (MLOD.MLODEntry mlodentry in mlodEntry.Parent.Entries)
			{
				if (mlodentry.VBUFIndex == mlodEntry.VBUFIndex)
				{
					list.Add(mlodentry);
				}
			}
			byte[] array = null;
			foreach (MLOD.MLODEntry mlodentry2 in list)
			{
				if (mlodentry2 != mlodEntry)
				{
					RCOL rcol2 = mlodentry2.Parent.Parent;
					VBUF vbuf2 = rcol2.Entries[mlodentry2.VBUFIndex + ((rcol2.DataType == 2) ? 1 : 0)] as VBUF;
					VertexDeclaration vertexDeclaration2 = mlodentry2.Parent.Parent.Entries[(vbuf2.SwiffleInfoIndex & 268435455) + ((mlodentry2.Parent.Parent.DataType == 2) ? 1 : 0)] as VertexDeclaration;
					VertexDeclaration.SwiffleInfo swiffleInfo3 = null;
					if (vertexDeclaration2 != null)
					{
						foreach (VertexDeclaration.SwiffleInfo swiffleInfo4 in vertexDeclaration2.SwiffleInformation)
						{
							if ((ulong)swiffleInfo4.VertexCount == (ulong)((long)mlodentry2.VBUFCount) && (ulong)swiffleInfo4.ByteOffset == (ulong)mlodentry2.VBUFOffset)
							{
								swiffleInfo3 = swiffleInfo4;
							}
						}
					}
					uint byteOffset = 0U;
					if (array == null)
					{
						array = new byte[(long)mlodentry2.VertexCount * (long)((ulong)swiffleInfo3.VertexSize)];
						Array.Copy(vbuf2.data, mlodentry2.VBUFOffset, array, 0L, (long)mlodentry2.VertexCount * (long)((ulong)swiffleInfo3.VertexSize));
					}
					else
					{
						byte[] array2 = new byte[(long)array.Length + (long)mlodentry2.VertexCount * (long)((ulong)swiffleInfo3.VertexSize)];
						Array.Copy(array, 0, array2, 0, array.Length);
						Array.Copy(vbuf2.data, mlodentry2.VBUFOffset, array2, (long)array.Length, (long)mlodentry2.VertexCount * (long)((ulong)swiffleInfo3.VertexSize));
						byteOffset = (uint)array.Length;
						array = array2;
					}
					swiffleInfo3.ByteOffset = byteOffset;
					mlodentry2.SetVertexOffset((long)((ulong)swiffleInfo3.ByteOffset));
				}
			}
			if (array == null)
			{
				array = new byte[0];
			}
			vbuf.SetData(array);
		}

		// Token: 0x06000A46 RID: 2630 RVA: 0x00032148 File Offset: 0x00030348
		public int CopyFromIndexAndVRTF(long offset, int numVertices, VRTF format)
		{
			int num = this.data.Length;
			byte[] destinationArray = new byte[(long)this.data.Length + (long)numVertices * (long)((ulong)format.BytesPerVertex)];
			Array.Copy(this.data, 0, destinationArray, 0, this.data.Length);
			Array.Copy(this.data, offset, destinationArray, (long)num, (long)numVertices * (long)((ulong)format.BytesPerVertex));
			this.SetData(destinationArray);
			int num2 = this.SwiffleInfoIndex & 268435455;
			VertexDeclaration vertexDeclaration = this.parent.Entries[num2 + ((this.parent.DataType == 2) ? 1 : 0)] as VertexDeclaration;
			if (vertexDeclaration != null)
			{
				VertexDeclaration.SwiffleInfo swiffleInfo = null;
				foreach (VertexDeclaration.SwiffleInfo swiffleInfo2 in vertexDeclaration.SwiffleInformation)
				{
					if ((ulong)swiffleInfo2.VertexCount == (ulong)((long)numVertices) && (ulong)swiffleInfo2.ByteOffset == (ulong)offset)
					{
						swiffleInfo = (swiffleInfo2.Clone() as VertexDeclaration.SwiffleInfo);
					}
				}
				if (swiffleInfo != null)
				{
					swiffleInfo.VertexCount = (uint)numVertices;
					swiffleInfo.ByteOffset = (uint)num;
					vertexDeclaration.SwiffleInformation.Add(swiffleInfo);
				}
			}
			return num;
		}

		// Token: 0x06000A47 RID: 2631 RVA: 0x00032278 File Offset: 0x00030478
		public object CloneFromIndexAndVRTF(long offset, int numVertices, VRTF format)
		{
			VBUF vbuf = new VBUF(this.parent);
			vbuf.Type = this.Type;
			vbuf.Unk1 = this.Unk1;
			vbuf.Unk2 = this.Unk2;
			vbuf.SwiffleInfoIndex = this.SwiffleInfoIndex;
			vbuf.data = new byte[(long)numVertices * (long)((ulong)format.BytesPerVertex)];
			Array.Copy(this.data, offset, vbuf.data, 0L, (long)numVertices * (long)((ulong)format.BytesPerVertex));
			int num = this.SwiffleInfoIndex & 268435455;
			VertexDeclaration vertexDeclaration = this.parent.Entries[num + ((this.parent.DataType == 2) ? 1 : 0)] as VertexDeclaration;
			if (vertexDeclaration != null)
			{
				VertexDeclaration.SwiffleInfo swiffleInfo = null;
				foreach (VertexDeclaration.SwiffleInfo swiffleInfo2 in vertexDeclaration.SwiffleInformation)
				{
					if ((ulong)swiffleInfo2.VertexCount == (ulong)((long)numVertices) && (ulong)swiffleInfo2.ByteOffset == (ulong)offset)
					{
						swiffleInfo = (swiffleInfo2.Clone() as VertexDeclaration.SwiffleInfo);
					}
				}
				if (swiffleInfo != null)
				{
					swiffleInfo.VertexCount = (uint)numVertices;
					swiffleInfo.ByteOffset = 0U;
					vertexDeclaration.SwiffleInformation.Add(swiffleInfo);
				}
			}
			return vbuf;
		}

		// Token: 0x06000A48 RID: 2632 RVA: 0x000323BC File Offset: 0x000305BC
		public object Clone()
		{
			VBUF vbuf = new VBUF(this.parent);
			MemoryStream memoryStream = new MemoryStream();
			BinaryWriter binaryWriter = new BinaryWriter(memoryStream);
			this.Serialize(binaryWriter);
			MemoryStream memoryStream2 = new MemoryStream(memoryStream.ToArray());
			BinaryReader binaryReader = new BinaryReader(memoryStream2);
			vbuf.UnSerialize(binaryReader);
			memoryStream.Dispose();
			memoryStream2.Dispose();
			binaryWriter.Close();
			binaryReader.Close();
			return vbuf;
		}

		// Token: 0x040004FF RID: 1279
		[Browsable(false)]
		private byte[] data;

		// Token: 0x04000500 RID: 1280
		[Browsable(false)]
		private MemoryStream _ms;

		// Token: 0x04000501 RID: 1281
		[Browsable(false)]
		private BinaryReader _br;

		// Token: 0x04000504 RID: 1284
		private RCOL parent;
	}
}
