using System;
using System.IO;
using ns10;
using Package.Sims3Files.InternalRCOL;
using SlimDX;
using SlimDX.Direct3D9;

namespace ns12
{
	// Token: 0x02000108 RID: 264
	internal sealed class Class114
	{
		// Token: 0x06000B47 RID: 2887 RVA: 0x0008F4C0 File Offset: 0x0008D6C0
		public static VertexFormat smethod_0(VRTF vrtf_0)
		{
			VertexFormat vertexFormat = VertexFormat.None;
			foreach (VertexFormatEntry vertexFormatEntry in vrtf_0.Entries)
			{
				switch (vertexFormatEntry.Usage)
				{
				case VertexEntryUsage.POSITION:
					vertexFormat |= VertexFormat.Position;
					break;
				case VertexEntryUsage.NORMAL:
					vertexFormat |= VertexFormat.Normal;
					break;
				case VertexEntryUsage.UV:
					vertexFormat = vertexFormat;
					break;
				case VertexEntryUsage.ASSIGNMENT:
					vertexFormat = vertexFormat;
					break;
				case VertexEntryUsage.SKIN_WEIGHT:
					vertexFormat |= VertexFormat.PositionBlend1;
					break;
				}
			}
			return vertexFormat;
		}

		// Token: 0x06000B48 RID: 2888 RVA: 0x0008F554 File Offset: 0x0008D754
		public static Class112.Struct7[] smethod_1(VRTF vrtf_0, ref byte[] byte_0)
		{
			Class112.Struct7[] array = new Class112.Struct7[(long)byte_0.Length / (long)((ulong)vrtf_0.BytesPerVertex)];
			MemoryStream input = new MemoryStream(byte_0);
			BinaryReader binaryReader = new BinaryReader(input);
			int num = 0;
			for (long num2 = 0L; num2 < byte_0.LongLength; num2 += (long)((ulong)vrtf_0.BytesPerVertex))
			{
				foreach (VertexFormatEntry vertexFormatEntry in vrtf_0.Entries)
				{
					binaryReader.BaseStream.Position = num2 + (long)vertexFormatEntry.Offset;
					switch (vertexFormatEntry.Usage)
					{
					case VertexEntryUsage.POSITION:
					{
						VertexEntryType type = vertexFormatEntry.Type;
						if (type != VertexEntryType.FLOAT3)
						{
							if (type != VertexEntryType.Short4)
							{
								if (type == VertexEntryType.UShort4N)
								{
									short num3 = binaryReader.ReadInt16();
									short num4 = binaryReader.ReadInt16();
									short num5 = binaryReader.ReadInt16();
									short num6 = binaryReader.ReadInt16();
									array[num].position = new Vector3(1f / (float)num3 * (float)num6, 1f / (float)num3 * (float)num5, 1f / (float)num3 * (float)num4);
								}
							}
							else
							{
								short num7 = binaryReader.ReadInt16();
								short num8 = binaryReader.ReadInt16();
								short num9 = binaryReader.ReadInt16();
								short num10 = binaryReader.ReadInt16();
								array[num].position = new Vector3(1f / (float)num10 * (float)num7, 1f / (float)num10 * (float)num8, 1f / (float)num10 * (float)num9);
							}
						}
						else
						{
							array[num].position = new Vector3(binaryReader.ReadSingle(), binaryReader.ReadSingle(), binaryReader.ReadSingle());
						}
						break;
					}
					case VertexEntryUsage.NORMAL:
					{
						VertexEntryType type2 = vertexFormatEntry.Type;
						if (type2 == VertexEntryType.Ubyte4)
						{
							byte b = binaryReader.ReadByte();
							byte b2 = binaryReader.ReadByte();
							byte b3 = binaryReader.ReadByte();
							byte b4 = binaryReader.ReadByte();
							array[num].normal = new Vector3(1f / (float)b4 * (float)b, 1f / (float)b4 * (float)b2, 1f / (float)b4 * (float)b3);
						}
						break;
					}
					}
				}
				num++;
			}
			return array;
		}

		// Token: 0x06000B49 RID: 2889 RVA: 0x0008F7A8 File Offset: 0x0008D9A8
		public static SlimDX.Direct3D9.VertexDeclaration smethod_2(Device device_0, VRTF vrtf_0)
		{
			VertexElement[] array = new VertexElement[vrtf_0.DeclarationCount + 1];
			int num = 0;
			foreach (VertexFormatEntry vertexFormatEntry in vrtf_0.Entries)
			{
				DeclarationUsage declarationUsage = DeclarationUsage.Position;
				switch (vertexFormatEntry.Usage)
				{
				case VertexEntryUsage.POSITION:
					declarationUsage = DeclarationUsage.Position;
					break;
				case VertexEntryUsage.NORMAL:
					declarationUsage = DeclarationUsage.Normal;
					break;
				case VertexEntryUsage.UV:
					declarationUsage = DeclarationUsage.TextureCoordinate;
					break;
				case VertexEntryUsage.ASSIGNMENT:
					declarationUsage = DeclarationUsage.BlendIndices;
					break;
				case VertexEntryUsage.SKIN_WEIGHT:
					declarationUsage = DeclarationUsage.BlendWeight;
					break;
				case VertexEntryUsage.TANGENT:
					declarationUsage = DeclarationUsage.Tangent;
					break;
				}
				DeclarationType declarationType;
				switch (vertexFormatEntry.Type)
				{
				case VertexEntryType.FLOAT2:
					declarationType = DeclarationType.Float2;
					break;
				case VertexEntryType.FLOAT3:
					declarationType = DeclarationType.Float3;
					break;
				case VertexEntryType.FLOAT4:
				case VertexEntryType.UByte4N:
				case VertexEntryType.Short2N:
				case VertexEntryType.Short4N:
				case VertexEntryType.UShort2N:
					goto IL_D2;
				case VertexEntryType.COLOR:
					declarationType = DeclarationType.Short4;
					break;
				case VertexEntryType.Ubyte4:
					declarationType = DeclarationType.UByte4N;
					break;
				case VertexEntryType.Short2:
					declarationType = DeclarationType.Short2;
					break;
				case VertexEntryType.Short4:
					declarationType = DeclarationType.Short4N;
					break;
				case VertexEntryType.UShort4N:
					declarationType = DeclarationType.Short4;
					break;
				default:
					goto IL_D2;
				}
				IL_DB:
				array[num++] = new VertexElement(0, (short)vertexFormatEntry.Offset, declarationType, DeclarationMethod.Default, declarationUsage, Convert.ToByte(vertexFormatEntry.Index));
				continue;
				IL_D2:
				declarationType = DeclarationType.Unused;
				goto IL_DB;
			}
			array[num++] = VertexElement.VertexDeclarationEnd;
			return new SlimDX.Direct3D9.VertexDeclaration(device_0, array);
		}
	}
}
