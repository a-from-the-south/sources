using System;
using System.IO;

namespace Sims3WorkshopSDK
{
	// Token: 0x02000010 RID: 16
	public class VertexStreamWriter
	{
		// Token: 0x0600006C RID: 108 RVA: 0x00003B9C File Offset: 0x00001D9C
		public static void WritePosition(VertexEntryType type, MyVertex vertex, StreamVector3 scalar, BinaryWriter w)
		{
			switch (type)
			{
			case VertexEntryType.FLOAT2:
				w.Write(vertex.posX);
				w.Write(vertex.posY);
				return;
			case VertexEntryType.FLOAT3:
				w.Write(vertex.posX);
				w.Write(vertex.posY);
				w.Write(vertex.posZ);
				return;
			case VertexEntryType.FLOAT4:
				w.Write(vertex.posX);
				w.Write(vertex.posY);
				w.Write(vertex.posZ);
				w.Write(vertex.posW);
				return;
			case VertexEntryType.Byte4:
			case VertexEntryType.Ubyte4:
			case VertexEntryType.Short2:
				break;
			case VertexEntryType.Short4:
			{
				float num = vertex.posX;
				float num2 = vertex.posY;
				float num3 = vertex.posZ;
				float num4 = 32767f;
				float num5 = Math.Max(Math.Max(Math.Abs(num), Math.Abs(num2)), Math.Abs(num3));
				if (num5 > 1f)
				{
					num4 = (float)(32767 / (int)Math.Ceiling((double)num5));
				}
				if (scalar != null)
				{
					num4 = 1f / scalar.X;
					num /= scalar.X;
					num2 /= scalar.Y;
					num3 /= scalar.Z;
				}
				else
				{
					num = num4 * num;
					num2 = num4 * num2;
					num3 = num4 * num3;
				}
				w.Write((short)num);
				w.Write((short)num2);
				w.Write((short)num3);
				w.Write((short)num4);
				break;
			}
			default:
			{
				if (type != VertexEntryType.UShort4N)
				{
					return;
				}
				float num6 = vertex.posX;
				float num7 = vertex.posY;
				float num8 = vertex.posZ;
				float num9 = 512f;
				num6 = num9 * num6;
				num7 = num9 * num7;
				num8 = num9 * num8;
				w.Write((short)num6);
				w.Write((short)num7);
				w.Write((short)num8);
				w.Write(512);
				return;
			}
			}
		}

		// Token: 0x0600006D RID: 109 RVA: 0x00003D58 File Offset: 0x00001F58
		public static void WriteNormal(VertexEntryType type, MyVertex vertex, BinaryWriter w)
		{
			switch (type)
			{
			case VertexEntryType.FLOAT2:
				w.Write(vertex.norX);
				w.Write(vertex.norY);
				return;
			case VertexEntryType.FLOAT3:
				w.Write(vertex.norX);
				w.Write(vertex.norY);
				w.Write(vertex.norZ);
				return;
			case VertexEntryType.FLOAT4:
				w.Write(vertex.norX);
				w.Write(vertex.norY);
				w.Write(vertex.norZ);
				w.Write(vertex.norW);
				return;
			case VertexEntryType.Byte4:
			case VertexEntryType.Short2:
			case VertexEntryType.Short4:
				break;
			case VertexEntryType.Ubyte4:
			{
				float norX = vertex.norX;
				float num = vertex.norY;
				float num2 = vertex.norZ;
				float num3 = (float)Math.Sqrt((double)(norX * norX + num * num + num2 * num2));
				double num4 = Math.Round((double)(127f / num3));
				if (num4 > 255.0)
				{
					num4 = 255.0;
				}
				float num5 = norX / num3;
				num /= num3;
				num2 /= num3;
				float num6 = num2 / 0.007874016f;
				float num7 = num / 0.007874016f;
				float num8 = num5 / 0.007874016f;
				num6 = ((num6 == 0f) ? 127f : ((num6 < 0f) ? (num6 + 127f) : (num6 + 128f)));
				num7 = ((num7 == 0f) ? 127f : ((num7 < 0f) ? (num7 + 127f) : (num7 + 128f)));
				num8 = ((num8 == 0f) ? 127f : ((num8 < 0f) ? (num8 + 127f) : (num8 + 128f)));
				w.Write((byte)Math.Round((double)num6));
				w.Write((byte)Math.Round((double)num7));
				w.Write((byte)Math.Round((double)num8));
				w.Write((byte)((num4 == 127.0) ? 255.0 : (255.0 - num4)));
				break;
			}
			case VertexEntryType.UByte4N:
			{
				float norX2 = vertex.norX;
				float norY = vertex.norY;
				float norZ = vertex.norZ;
				float norW = vertex.norW;
				sbyte b;
				if (norX2 >= 0f)
				{
					b = (sbyte)(127f * norX2 - 128f);
				}
				else
				{
					b = (sbyte)(127f * norX2 + 128f);
				}
				sbyte b2;
				if (norY >= 0f)
				{
					b2 = (sbyte)(127f * norY - 128f);
				}
				else
				{
					b2 = (sbyte)(127f * norY + 128f);
				}
				sbyte b3;
				if (norZ >= 0f)
				{
					b3 = (sbyte)(127f * norZ - 128f);
				}
				else
				{
					b3 = (sbyte)(127f * norZ + 128f);
				}
				sbyte b4;
				if (norW >= 0f)
				{
					b4 = (sbyte)(127f * norW - 128f);
				}
				else
				{
					b4 = (sbyte)(127f * norW + 128f);
				}
				sbyte value = b;
				sbyte value2 = b2;
				sbyte value3 = b3;
				sbyte value4 = b4;
				w.Write(value);
				w.Write(value2);
				w.Write(value3);
				w.Write(value4);
				return;
			}
			default:
			{
				if (type != VertexEntryType.UShort4N)
				{
					return;
				}
				float num9 = vertex.norX;
				float num10 = vertex.norY;
				float num11 = vertex.norZ;
				float num12 = 512f;
				num9 = 512f * num9;
				num10 = 512f * num10;
				num11 = num12 * num11;
				w.Write((short)num9);
				w.Write((short)num10);
				w.Write((short)num11);
				w.Write(0);
				return;
			}
			}
		}

		// Token: 0x0600006E RID: 110 RVA: 0x000040C0 File Offset: 0x000022C0
		public static void WriteUV(VertexEntryType type, MyVertex vertex, BinaryWriter w, float scalar)
		{
			switch (type)
			{
			case VertexEntryType.FLOAT2:
				w.Write(vertex.tx);
				w.Write(vertex.ty);
				return;
			case VertexEntryType.FLOAT3:
				w.Write(vertex.tx);
				w.Write(vertex.ty);
				w.Write(vertex.tx2);
				return;
			case VertexEntryType.FLOAT4:
				w.Write(vertex.tx);
				w.Write(vertex.ty);
				w.Write(vertex.tx2);
				w.Write(vertex.ty2);
				return;
			case VertexEntryType.Byte4:
			case VertexEntryType.Ubyte4:
				break;
			case VertexEntryType.Short2:
				w.Write((short)(vertex.tx / scalar));
				w.Write((short)(vertex.ty / scalar));
				return;
			case VertexEntryType.Short4:
				w.Write((ushort)(vertex.tx * 32768f));
				w.Write((ushort)(vertex.ty * 32768f));
				w.Write(0);
				w.Write(32768);
				return;
			default:
			{
				if (type != VertexEntryType.UShort4N)
				{
					return;
				}
				float num = vertex.tx;
				float num2 = vertex.ty;
				num = 32768f * num;
				num2 = 32768f * num2;
				w.Write((short)num);
				w.Write((short)num2);
				w.Write(0);
				w.Write(0);
				break;
			}
			}
		}

		// Token: 0x0600006F RID: 111 RVA: 0x0000251B File Offset: 0x0000071B
		public static void WriteAssignment(VertexEntryType type, MyVertex vertex, BinaryWriter w)
		{
			if (type == VertexEntryType.Byte4)
			{
				w.Write(vertex.b1);
				w.Write(vertex.b2);
				w.Write(vertex.b3);
				w.Write(vertex.b4);
			}
		}

		// Token: 0x06000070 RID: 112 RVA: 0x00004208 File Offset: 0x00002408
		public static void WriteWeight(VertexEntryType type, MyVertex vertex, BinaryWriter w)
		{
			if (type == VertexEntryType.FLOAT4)
			{
				w.Write(vertex.w1);
				w.Write(vertex.w2);
				w.Write(vertex.w3);
				w.Write(vertex.w4);
				return;
			}
			if (type == VertexEntryType.Ubyte4)
			{
				float w2 = vertex.w1;
				float w3 = vertex.w2;
				float w4 = vertex.w3;
				float w5 = vertex.w4;
				byte b = (byte)Math.Max(0f, w4 * 255f);
				byte b2 = (byte)Math.Max(0f, w3 * 255f);
				byte b3 = (byte)Math.Max(0f, w2 * 255f);
				byte b4 = (byte)Math.Max(0f, w5 * 255f);
				int num = (int)(b + b2 + b3 + b4);
				if (num != 255)
				{
					byte b5 = Math.Max(b, Math.Max(b2, Math.Max(b3, b4)));
					if (b5 == b)
					{
						b += (byte)(255 - num);
					}
					else if (b5 == b2)
					{
						b2 += (byte)(255 - num);
					}
					else if (b5 == b3)
					{
						b3 += (byte)(255 - num);
					}
					else if (b5 == b4)
					{
						b4 += (byte)(255 - num);
					}
				}
				w.Write(b);
				w.Write(b2);
				w.Write(b3);
				w.Write(b4);
				return;
			}
			if (type != VertexEntryType.UByte4N)
			{
				return;
			}
			float w6 = vertex.w1;
			float w7 = vertex.w2;
			float w8 = vertex.w3;
			float w9 = vertex.w4;
			byte value = (byte)(255f * w6);
			byte value2 = (byte)(255f * w7);
			byte value3 = (byte)(255f * w8);
			byte value4 = (byte)(255f * w9);
			w.Write(value);
			w.Write(value2);
			w.Write(value3);
			w.Write(value4);
		}

		// Token: 0x06000071 RID: 113 RVA: 0x000043D8 File Offset: 0x000025D8
		public static void WriteTangent(VertexEntryType type, MyVertex vertex, BinaryWriter w)
		{
			if (type != VertexEntryType.Ubyte4)
			{
				if (type == VertexEntryType.UByte4N)
				{
					float tangent = vertex.tangent1;
					float tangent2 = vertex.tangent2;
					float tangent3 = vertex.tangent3;
					float tangent4 = vertex.tangent4;
					sbyte b;
					if (tangent >= 0f)
					{
						b = (sbyte)(127f * tangent - 128f);
					}
					else
					{
						b = (sbyte)(127f * tangent + 128f);
					}
					sbyte b2;
					if (tangent2 >= 0f)
					{
						b2 = (sbyte)(127f * tangent2 - 128f);
					}
					else
					{
						b2 = (sbyte)(127f * tangent2 + 128f);
					}
					sbyte b3;
					if (tangent3 >= 0f)
					{
						b3 = (sbyte)(127f * tangent3 - 128f);
					}
					else
					{
						b3 = (sbyte)(127f * tangent3 + 128f);
					}
					sbyte b4;
					if (tangent4 >= 0f)
					{
						b4 = (sbyte)(127f * tangent4 - 128f);
					}
					else
					{
						b4 = (sbyte)(127f * tangent4 + 128f);
					}
					sbyte value = b;
					sbyte value2 = b2;
					sbyte value3 = b3;
					sbyte value4 = b4;
					w.Write(value);
					w.Write(value2);
					w.Write(value3);
					w.Write(value4);
					return;
				}
			}
			else
			{
				float tangent5 = vertex.tangent1;
				float num = vertex.tangent2;
				float num2 = vertex.tangent3;
				float num3 = (float)Math.Sqrt((double)(tangent5 * tangent5 + num * num + num2 * num2));
				float num4 = tangent5 / num3;
				num /= num3;
				num2 /= num3;
				float num5 = num2 / 0.007874016f;
				float num6 = num / 0.007874016f;
				float num7 = num4 / 0.007874016f;
				num5 = ((num5 < 0f) ? (128f + num5) : (num5 - 128f));
				num6 = ((num6 < 0f) ? (128f + num6) : (num6 - 128f));
				num7 = ((num7 < 0f) ? (128f + num7) : (num7 - 128f));
				w.Write((sbyte)Math.Ceiling((double)num5));
				w.Write((sbyte)Math.Ceiling((double)num6));
				w.Write((sbyte)Math.Ceiling((double)num7));
				w.Write(byte.MaxValue);
			}
		}

		// Token: 0x06000072 RID: 114 RVA: 0x00002551 File Offset: 0x00000751
		public static void WriteUnknown(VertexEntryType type, MyVertex vertex, BinaryWriter w)
		{
			if (type == VertexEntryType.Ubyte4 || type == VertexEntryType.UByte4N)
			{
				w.Write(vertex.ub1);
				w.Write(vertex.ub2);
				w.Write(vertex.ub3);
				w.Write(vertex.ub4);
			}
		}
	}
}
