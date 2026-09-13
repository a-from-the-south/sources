using System;
using System.Runtime.InteropServices;
using SlimDX;
using SlimDX.Direct3D9;

namespace ns10
{
	// Token: 0x02000102 RID: 258
	internal sealed class Class112
	{
		// Token: 0x02000103 RID: 259
		public struct Struct5
		{
			// Token: 0x06000B2F RID: 2863 RVA: 0x00006AE8 File Offset: 0x00004CE8
			public Struct5(Vector3 position, Vector3 normal, float u, float v)
			{
				this = default(Class112.Struct5);
				this.position = position;
				this.normal = normal;
				this.vector2_0 = new Vector2(u, v);
			}

			// Token: 0x1700020C RID: 524
			// (get) Token: 0x06000B30 RID: 2864 RVA: 0x0008E1FC File Offset: 0x0008C3FC
			public static int SizeInBytes
			{
				get
				{
					return Marshal.SizeOf(typeof(Class112.Struct5));
				}
			}

			// Token: 0x0400089B RID: 2203
			public Vector3 position;

			// Token: 0x0400089C RID: 2204
			public Vector3 normal;

			// Token: 0x0400089D RID: 2205
			public Vector2 vector2_0;

			// Token: 0x0400089E RID: 2206
			public static readonly VertexFormat vertexFormat_0 = VertexFormat.Texture1 | VertexFormat.PositionNormal;
		}

		// Token: 0x02000104 RID: 260
		public struct Struct6
		{
			// Token: 0x06000B32 RID: 2866 RVA: 0x00006B1D File Offset: 0x00004D1D
			public Struct6(Vector3 position, int color)
			{
				this = default(Class112.Struct6);
				this.position = position;
				this.color = color;
			}

			// Token: 0x1700020D RID: 525
			// (get) Token: 0x06000B33 RID: 2867 RVA: 0x0008E21C File Offset: 0x0008C41C
			public static int SizeInBytes
			{
				get
				{
					return Marshal.SizeOf(typeof(Class112.Struct6));
				}
			}

			// Token: 0x0400089F RID: 2207
			public Vector3 position;

			// Token: 0x040008A0 RID: 2208
			public int color;

			// Token: 0x040008A1 RID: 2209
			public static readonly VertexFormat vertexFormat_0 = VertexFormat.Diffuse | VertexFormat.PositionRhw;
		}

		// Token: 0x02000105 RID: 261
		public struct Struct7
		{
			// Token: 0x06000B35 RID: 2869 RVA: 0x0008E23C File Offset: 0x0008C43C
			public Struct7(Vector3 position)
			{
				this.position = position;
				this.float_0 = 0f;
				this.float_1 = 0f;
				this.float_2 = 0f;
				this.float_3 = 0f;
				this.uint_0 = 0U;
				this.vector2_0 = (this.vector2_1 = Vector2.Zero);
				this.normal = Vector3.Zero;
				this.int_0 = 0;
				this.vector3_0 = Vector3.Zero;
				this.color = 0;
				this.int_1 = 0;
				this.pointSize = 0f;
			}

			// Token: 0x06000B36 RID: 2870 RVA: 0x0008E2D0 File Offset: 0x0008C4D0
			public Struct7(Vector3 position, float pointSize, int color)
			{
				this.position = position;
				this.float_0 = 0f;
				this.float_1 = 0f;
				this.float_2 = 0f;
				this.float_3 = 0f;
				this.uint_0 = 0U;
				this.vector2_0 = (this.vector2_1 = Vector2.Zero);
				this.normal = Vector3.Zero;
				this.int_0 = 0;
				this.vector3_0 = Vector3.Zero;
				this.color = color;
				this.int_1 = 0;
				this.pointSize = 0f;
				this.pointSize = pointSize;
			}

			// Token: 0x06000B37 RID: 2871 RVA: 0x0008E36C File Offset: 0x0008C56C
			public Struct7(Vector3 position, Vector3 normal, Vector2 texCoord)
			{
				this.position = position;
				this.float_0 = 0f;
				this.float_1 = 0f;
				this.float_2 = 0f;
				this.float_3 = 0f;
				this.uint_0 = 0U;
				this.vector2_1 = texCoord;
				this.vector2_0 = texCoord;
				this.normal = normal;
				this.int_0 = 0;
				this.vector3_0 = Vector3.Zero;
				this.color = 0;
				this.int_1 = 0;
				this.pointSize = 0f;
			}

			// Token: 0x06000B38 RID: 2872 RVA: 0x0008E3F8 File Offset: 0x0008C5F8
			public Struct7(Vector3 position, int color, Vector2 texCoord)
			{
				this.position = position;
				this.float_0 = 0f;
				this.float_1 = 0f;
				this.float_2 = 0f;
				this.float_3 = 0f;
				this.uint_0 = 0U;
				this.vector2_1 = texCoord;
				this.vector2_0 = texCoord;
				this.normal = Vector3.Zero;
				this.int_0 = 0;
				this.vector3_0 = Vector3.Zero;
				this.color = color;
				this.int_1 = 0;
				this.pointSize = 0f;
			}

			// Token: 0x1700020E RID: 526
			// (get) Token: 0x06000B39 RID: 2873 RVA: 0x0008E488 File Offset: 0x0008C688
			public static VertexElement[] VertexElements
			{
				get
				{
					return Class112.Struct7.vertexElement_0;
				}
			}

			// Token: 0x1700020F RID: 527
			// (get) Token: 0x06000B3A RID: 2874 RVA: 0x0008E4A0 File Offset: 0x0008C6A0
			public static int SizeInBytes
			{
				get
				{
					return Marshal.SizeOf(typeof(Class112.Struct7));
				}
			}

			// Token: 0x040008A2 RID: 2210
			public Vector3 position;

			// Token: 0x040008A3 RID: 2211
			public float float_0;

			// Token: 0x040008A4 RID: 2212
			public float float_1;

			// Token: 0x040008A5 RID: 2213
			public float float_2;

			// Token: 0x040008A6 RID: 2214
			public float float_3;

			// Token: 0x040008A7 RID: 2215
			public uint uint_0;

			// Token: 0x040008A8 RID: 2216
			public Vector3 normal;

			// Token: 0x040008A9 RID: 2217
			public Vector2 vector2_0;

			// Token: 0x040008AA RID: 2218
			public int color;

			// Token: 0x040008AB RID: 2219
			public Vector3 vector3_0;

			// Token: 0x040008AC RID: 2220
			public int int_0;

			// Token: 0x040008AD RID: 2221
			public Vector2 vector2_1;

			// Token: 0x040008AE RID: 2222
			public float pointSize;

			// Token: 0x040008AF RID: 2223
			public int int_1;

			// Token: 0x040008B0 RID: 2224
			public static readonly VertexFormat vertexFormat_0 = VertexFormat.LastBetaUByte4 | VertexFormat.TextureCountShift | VertexFormat.Texture1 | VertexFormat.PositionRhw | VertexFormat.Normal;

			// Token: 0x040008B1 RID: 2225
			private static VertexElement[] vertexElement_0 = new VertexElement[]
			{
				new VertexElement(0, 0, DeclarationType.Float3, DeclarationMethod.Default, DeclarationUsage.Position, 0),
				new VertexElement(0, 12, DeclarationType.Float4, DeclarationMethod.Default, DeclarationUsage.BlendWeight, 0),
				new VertexElement(0, 28, DeclarationType.Ubyte4, DeclarationMethod.Default, DeclarationUsage.BlendIndices, 0),
				new VertexElement(0, 32, DeclarationType.Float3, DeclarationMethod.Default, DeclarationUsage.Normal, 0),
				new VertexElement(0, 44, DeclarationType.Float2, DeclarationMethod.Default, DeclarationUsage.TextureCoordinate, 0),
				new VertexElement(0, 52, DeclarationType.Color, DeclarationMethod.Default, DeclarationUsage.Color, 0),
				new VertexElement(0, 56, DeclarationType.Float3, DeclarationMethod.Default, DeclarationUsage.Position, 1),
				new VertexElement(0, 68, DeclarationType.Color, DeclarationMethod.Default, DeclarationUsage.Color, 1),
				new VertexElement(0, 72, DeclarationType.Float2, DeclarationMethod.Default, DeclarationUsage.TextureCoordinate, 1),
				new VertexElement(0, 80, DeclarationType.Float1, DeclarationMethod.Default, DeclarationUsage.PointSize, 0),
				new VertexElement(0, 84, DeclarationType.Ubyte4, DeclarationMethod.Default, DeclarationUsage.Color, 2),
				VertexElement.VertexDeclarationEnd
			};
		}

		// Token: 0x02000106 RID: 262
		public struct Struct8
		{
			// Token: 0x06000B3C RID: 2876 RVA: 0x0008E608 File Offset: 0x0008C808
			public Struct8(Vector3 position)
			{
				this.position = position;
				this.float_0 = 0f;
				this.float_1 = 0f;
				this.float_2 = 0f;
				this.float_3 = 0f;
				this.uint_0 = 0U;
				this.vector2_0 = (this.vector2_1 = Vector2.Zero);
				this.vector3_0 = Vector3.Zero;
				this.int_1 = 0;
				this.vector3_1 = Vector3.Zero;
				this.int_0 = 0;
				this.int_2 = 0;
				this.float_4 = 0f;
				this.vector3_2 = (this.vector3_3 = Vector3.Zero);
			}

			// Token: 0x17000210 RID: 528
			// (get) Token: 0x06000B3D RID: 2877 RVA: 0x0008E6B0 File Offset: 0x0008C8B0
			public static VertexElement[] VertexElements
			{
				get
				{
					return Class112.Struct8.vertexElement_0;
				}
			}

			// Token: 0x17000211 RID: 529
			// (get) Token: 0x06000B3E RID: 2878 RVA: 0x0008E4A0 File Offset: 0x0008C6A0
			public static int SizeInBytes
			{
				get
				{
					return Marshal.SizeOf(typeof(Class112.Struct7));
				}
			}

			// Token: 0x040008B2 RID: 2226
			public Vector3 position;

			// Token: 0x040008B3 RID: 2227
			public float float_0;

			// Token: 0x040008B4 RID: 2228
			public float float_1;

			// Token: 0x040008B5 RID: 2229
			public float float_2;

			// Token: 0x040008B6 RID: 2230
			public float float_3;

			// Token: 0x040008B7 RID: 2231
			public uint uint_0;

			// Token: 0x040008B8 RID: 2232
			public Vector3 vector3_0;

			// Token: 0x040008B9 RID: 2233
			public Vector2 vector2_0;

			// Token: 0x040008BA RID: 2234
			public int int_0;

			// Token: 0x040008BB RID: 2235
			public Vector3 vector3_1;

			// Token: 0x040008BC RID: 2236
			public int int_1;

			// Token: 0x040008BD RID: 2237
			public Vector2 vector2_1;

			// Token: 0x040008BE RID: 2238
			public float float_4;

			// Token: 0x040008BF RID: 2239
			public int int_2;

			// Token: 0x040008C0 RID: 2240
			public Vector3 vector3_2;

			// Token: 0x040008C1 RID: 2241
			public Vector3 vector3_3;

			// Token: 0x040008C2 RID: 2242
			public static readonly VertexFormat vertexFormat_0 = VertexFormat.LastBetaUByte4 | VertexFormat.TextureCountShift | VertexFormat.Texture1 | VertexFormat.PositionRhw | VertexFormat.Normal;

			// Token: 0x040008C3 RID: 2243
			private static VertexElement[] vertexElement_0 = new VertexElement[]
			{
				new VertexElement(0, 0, DeclarationType.Float3, DeclarationMethod.Default, DeclarationUsage.Position, 0),
				new VertexElement(0, 12, DeclarationType.Float4, DeclarationMethod.Default, DeclarationUsage.BlendWeight, 0),
				new VertexElement(0, 28, DeclarationType.Ubyte4, DeclarationMethod.Default, DeclarationUsage.BlendIndices, 0),
				new VertexElement(0, 32, DeclarationType.Float3, DeclarationMethod.Default, DeclarationUsage.Normal, 0),
				new VertexElement(0, 44, DeclarationType.Float2, DeclarationMethod.Default, DeclarationUsage.TextureCoordinate, 0),
				new VertexElement(0, 52, DeclarationType.Color, DeclarationMethod.Default, DeclarationUsage.Color, 0),
				new VertexElement(0, 56, DeclarationType.Float3, DeclarationMethod.Default, DeclarationUsage.Position, 1),
				new VertexElement(0, 68, DeclarationType.Color, DeclarationMethod.Default, DeclarationUsage.Color, 1),
				new VertexElement(0, 72, DeclarationType.Float2, DeclarationMethod.Default, DeclarationUsage.TextureCoordinate, 1),
				new VertexElement(0, 80, DeclarationType.Float1, DeclarationMethod.Default, DeclarationUsage.PointSize, 0),
				new VertexElement(0, 84, DeclarationType.Ubyte4, DeclarationMethod.Default, DeclarationUsage.Color, 2),
				new VertexElement(0, 88, DeclarationType.Float3, DeclarationMethod.Default, DeclarationUsage.Tangent, 0),
				new VertexElement(0, 100, DeclarationType.Float3, DeclarationMethod.Default, DeclarationUsage.Binormal, 0),
				VertexElement.VertexDeclarationEnd
			};
		}
	}
}
