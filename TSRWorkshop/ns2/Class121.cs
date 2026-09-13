using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Xml;
using ns10;
using ns12;
using ns13;
using ns16;
using ns18;
using ns19;
using ns6;
using ns7;
using ns8;
using Package;
using Package.Geometry;
using Package.Sims3Files;
using Package.Sims3Files.InternalRCOL;
using Sims3WorkshopSDK;
using Sims3WorkshopSDK.Interfaces;
using SlimDX;
using SlimDX.Direct3D9;

namespace ns2
{
	// Token: 0x02000110 RID: 272
	internal sealed class Class121 : Interface9
	{
		// Token: 0x1700022E RID: 558
		// (get) Token: 0x06000BAA RID: 2986 RVA: 0x000955E4 File Offset: 0x000937E4
		// (set) Token: 0x06000BAB RID: 2987 RVA: 0x00006D23 File Offset: 0x00004F23
		public object Tag { get; set; }

		// Token: 0x1700022F RID: 559
		// (get) Token: 0x06000BAC RID: 2988 RVA: 0x000955FC File Offset: 0x000937FC
		// (set) Token: 0x06000BAD RID: 2989 RVA: 0x00006D2E File Offset: 0x00004F2E
		public object UndoData { get; set; }

		// Token: 0x17000230 RID: 560
		// (get) Token: 0x06000BAE RID: 2990 RVA: 0x00095614 File Offset: 0x00093814
		public MLOD.MLODEntry MLODEntry
		{
			get
			{
				return this.mlodEntry;
			}
		}

		// Token: 0x17000231 RID: 561
		// (get) Token: 0x06000BAF RID: 2991 RVA: 0x0009562C File Offset: 0x0009382C
		// (set) Token: 0x06000BB0 RID: 2992 RVA: 0x00006D39 File Offset: 0x00004F39
		public VertexBuffer VertexBuffer { get; set; }

		// Token: 0x17000232 RID: 562
		// (get) Token: 0x06000BB1 RID: 2993 RVA: 0x00095644 File Offset: 0x00093844
		// (set) Token: 0x06000BB2 RID: 2994 RVA: 0x00006D44 File Offset: 0x00004F44
		public VertexBuffer VertexBufferTransformed { get; set; }

		// Token: 0x17000233 RID: 563
		// (get) Token: 0x06000BB3 RID: 2995 RVA: 0x0009565C File Offset: 0x0009385C
		// (set) Token: 0x06000BB4 RID: 2996 RVA: 0x00006D4F File Offset: 0x00004F4F
		public IndexBuffer IndexBuffer { get; set; }

		// Token: 0x17000234 RID: 564
		// (get) Token: 0x06000BB5 RID: 2997 RVA: 0x00095674 File Offset: 0x00093874
		// (set) Token: 0x06000BB6 RID: 2998 RVA: 0x00006D5A File Offset: 0x00004F5A
		public IndexBuffer SelectedIndexBuffer { get; set; }

		// Token: 0x17000235 RID: 565
		// (get) Token: 0x06000BB7 RID: 2999 RVA: 0x0009568C File Offset: 0x0009388C
		public int IBUFOffset
		{
			get
			{
				return (int)this.mlodEntry.IBUFOffset;
			}
		}

		// Token: 0x17000236 RID: 566
		// (get) Token: 0x06000BB8 RID: 3000 RVA: 0x000956AC File Offset: 0x000938AC
		public int VBUFOffset
		{
			get
			{
				return (int)this.mlodEntry.VBUFOffset;
			}
		}

		// Token: 0x17000237 RID: 567
		// (get) Token: 0x06000BB9 RID: 3001 RVA: 0x000956CC File Offset: 0x000938CC
		// (set) Token: 0x06000BBA RID: 3002 RVA: 0x00006D65 File Offset: 0x00004F65
		public List<Class102.Class107> CurrentSelectionIndex { get; set; }

		// Token: 0x17000238 RID: 568
		// (get) Token: 0x06000BBB RID: 3003 RVA: 0x000956E4 File Offset: 0x000938E4
		public int VertexCount
		{
			get
			{
				return this.mlodEntry.VertexCount;
			}
		}

		// Token: 0x17000239 RID: 569
		// (get) Token: 0x06000BBC RID: 3004 RVA: 0x00095700 File Offset: 0x00093900
		// (set) Token: 0x06000BBD RID: 3005 RVA: 0x00006D70 File Offset: 0x00004F70
		public bool Visible
		{
			get
			{
				bool result;
				if (this.mlodEntry == null)
				{
					result = true;
				}
				else
				{
					result = this.mlodEntry.Visible;
				}
				return result;
			}
			set
			{
				if (this.mlodEntry != null)
				{
					this.mlodEntry.Visible = value;
				}
			}
		}

		// Token: 0x1700023A RID: 570
		// (get) Token: 0x06000BBE RID: 3006 RVA: 0x00095728 File Offset: 0x00093928
		// (set) Token: 0x06000BBF RID: 3007 RVA: 0x00006D88 File Offset: 0x00004F88
		public bool Selected { get; set; }

		// Token: 0x1700023B RID: 571
		// (get) Token: 0x06000BC0 RID: 3008 RVA: 0x00095740 File Offset: 0x00093940
		// (set) Token: 0x06000BC1 RID: 3009 RVA: 0x00006D93 File Offset: 0x00004F93
		public Lod LOD { get; set; }

		// Token: 0x1700023C RID: 572
		// (get) Token: 0x06000BC2 RID: 3010 RVA: 0x00095758 File Offset: 0x00093958
		// (set) Token: 0x06000BC3 RID: 3011 RVA: 0x00006D9E File Offset: 0x00004F9E
		public bool Skinned { get; set; }

		// Token: 0x1700023D RID: 573
		// (get) Token: 0x06000BC4 RID: 3012 RVA: 0x00095770 File Offset: 0x00093970
		public short[] FaceData
		{
			get
			{
				return this.short_0;
			}
		}

		// Token: 0x1700023E RID: 574
		// (get) Token: 0x06000BC5 RID: 3013 RVA: 0x00095788 File Offset: 0x00093988
		// (set) Token: 0x06000BC6 RID: 3014 RVA: 0x00006DA9 File Offset: 0x00004FA9
		public int GeoStateIndex
		{
			get
			{
				return this.int_0;
			}
			set
			{
				this.int_0 = value;
			}
		}

		// Token: 0x1700023F RID: 575
		// (get) Token: 0x06000BC7 RID: 3015 RVA: 0x000957A0 File Offset: 0x000939A0
		public int GeoStateCount
		{
			get
			{
				return this.mlodEntry.GeoStateEntries.Count;
			}
		}

		// Token: 0x17000240 RID: 576
		// (get) Token: 0x06000BC8 RID: 3016 RVA: 0x000957C4 File Offset: 0x000939C4
		// (set) Token: 0x06000BC9 RID: 3017 RVA: 0x00006DB4 File Offset: 0x00004FB4
		public bool DiffuseMapIsDDS { get; set; }

		// Token: 0x17000241 RID: 577
		// (get) Token: 0x06000BCA RID: 3018 RVA: 0x000957DC File Offset: 0x000939DC
		public Texture DiffuseMap
		{
			get
			{
				return this.texture_0;
			}
		}

		// Token: 0x17000242 RID: 578
		// (get) Token: 0x06000BCB RID: 3019 RVA: 0x000957F4 File Offset: 0x000939F4
		// (set) Token: 0x06000BCC RID: 3020 RVA: 0x00006DBF File Offset: 0x00004FBF
		public bool SpecularMapIsDDS { get; set; }

		// Token: 0x17000243 RID: 579
		// (get) Token: 0x06000BCD RID: 3021 RVA: 0x0009580C File Offset: 0x00093A0C
		public Texture SpecularMap
		{
			get
			{
				return this.texture_2;
			}
		}

		// Token: 0x17000244 RID: 580
		// (get) Token: 0x06000BCE RID: 3022 RVA: 0x00095824 File Offset: 0x00093A24
		// (set) Token: 0x06000BCF RID: 3023 RVA: 0x00006DCA File Offset: 0x00004FCA
		public bool NormalMapIsDDS { get; set; }

		// Token: 0x17000245 RID: 581
		// (get) Token: 0x06000BD0 RID: 3024 RVA: 0x0009583C File Offset: 0x00093A3C
		public Texture NormalMap
		{
			get
			{
				return this.texture_3;
			}
		}

		// Token: 0x17000246 RID: 582
		// (get) Token: 0x06000BD1 RID: 3025 RVA: 0x00095854 File Offset: 0x00093A54
		// (set) Token: 0x06000BD2 RID: 3026 RVA: 0x00006DD5 File Offset: 0x00004FD5
		public Matrix[] Palette { get; set; }

		// Token: 0x17000247 RID: 583
		// (get) Token: 0x06000BD3 RID: 3027 RVA: 0x0009586C File Offset: 0x00093A6C
		// (set) Token: 0x06000BD4 RID: 3028 RVA: 0x00006DE0 File Offset: 0x00004FE0
		public Matrix[] ColorPalette { get; set; }

		// Token: 0x17000248 RID: 584
		// (get) Token: 0x06000BD5 RID: 3029 RVA: 0x00095884 File Offset: 0x00093A84
		public MATD Matd
		{
			get
			{
				if (this.matd_0 == null)
				{
					List<MATD> list = this.method_12(782826392);
					if (list.Count > 0)
					{
						return list[0];
					}
				}
				return this.matd_0;
			}
		}

		// Token: 0x06000BD6 RID: 3030 RVA: 0x00006DEB File Offset: 0x00004FEB
		public void imethod_2(Device device_0, MATD matd_1)
		{
			this.matd_0 = matd_1;
			this.method_8(device_0);
		}

		// Token: 0x17000249 RID: 585
		// (get) Token: 0x06000BD7 RID: 3031 RVA: 0x000958C4 File Offset: 0x00093AC4
		public MATD DefaultMaterial
		{
			get
			{
				List<MATD> list = this.method_12(782826392);
				MATD result;
				if (list.Count > 0)
				{
					result = list[0];
				}
				else
				{
					result = null;
				}
				return result;
			}
		}

		// Token: 0x1700024A RID: 586
		// (get) Token: 0x06000BD8 RID: 3032 RVA: 0x000958F8 File Offset: 0x00093AF8
		// (set) Token: 0x06000BD9 RID: 3033 RVA: 0x00006DFD File Offset: 0x00004FFD
		public int FaceCount
		{
			get
			{
				return this.mlodEntry.FaceCount;
			}
			set
			{
				this.mlodEntry.FaceCount = value;
			}
		}

		// Token: 0x1700024B RID: 587
		// (get) Token: 0x06000BDA RID: 3034 RVA: 0x00095914 File Offset: 0x00093B14
		// (set) Token: 0x06000BDB RID: 3035 RVA: 0x00006E0D File Offset: 0x0000500D
		public Bitmap PartMaskImage { get; set; }

		// Token: 0x06000BDC RID: 3036 RVA: 0x0009592C File Offset: 0x00093B2C
		public Class121(Device device, Lod lod, MLOD mlod, MLOD.MLODEntry mlodEntry)
		{
			this.Visible = true;
			this.mlod = mlod;
			this.mlodEntry = mlodEntry;
			this.LOD = lod;
			this.list_0 = new List<uint>();
			this.CurrentSelectionIndex = new List<Class102.Class107>();
			RCOL parent = this.mlod.Parent;
			VRTF vrtf = parent.Entries[this.mlodEntry.VRTFIndex + ((parent.dataType == 2) ? 1 : 0)] as VRTF;
			VBUF vbuf = parent.Entries[this.mlodEntry.VBUFIndex + ((parent.dataType == 2) ? 1 : 0)] as VBUF;
			if (vrtf == null)
			{
				vrtf = VRTF.GetDefaultForLength((this.mlodEntry.Type == 20483U) ? 8 : 16);
			}
			this.struct7_0 = new Class112.Struct7[this.mlodEntry.VertexCount];
			this.struct7_1 = new Class112.Struct7[this.struct7_0.Length * 2];
			int color = Color.Yellow.ToArgb();
			int num = 0;
			for (int i = 0; i < this.mlodEntry.VertexCount; i++)
			{
				Class112.Struct7 @struct = default(Class112.Struct7);
				Package.Geometry.Vector4 position = vbuf.GetPosition(vrtf, i, this.mlodEntry.VBUFOffset, 0);
				Package.Geometry.Vector4 normal = vbuf.GetNormal(vrtf, i, this.mlodEntry.VBUFOffset, 0);
				Package.Geometry.Vector4 uv = vbuf.GetUV(vrtf, i, this.mlodEntry.VBUFOffset, 0);
				Package.Geometry.Vector4 uv2 = vbuf.GetUV(vrtf, i, this.mlodEntry.VBUFOffset, 1);
				float[] weights = vbuf.GetWeights(vrtf, i, this.mlodEntry.VBUFOffset, 0);
				vbuf.GetTangent(vrtf, i, this.mlodEntry.VBUFOffset, 0);
				sbyte[] assignment = vbuf.GetAssignment(vrtf, i, this.mlodEntry.VBUFOffset, 0);
				@struct.position = new SlimDX.Vector3(position.X, position.Y, position.Z);
				@struct.normal = new SlimDX.Vector3(normal.X, normal.Y, normal.Z);
				@struct.vector2_0 = new Vector2(uv.X, uv.Y);
				@struct.vector2_1 = new Vector2(uv2.X, uv2.Y);
				float num2 = 1f;
				for (int j = 3; j >= 0; j--)
				{
					if (assignment[j] < -1)
					{
						assignment[j] = -1;
						vbuf.SetAssignment(vrtf, i, this.mlodEntry.VBUFOffset, assignment);
					}
					if (assignment[j] < 0)
					{
						weights[j] = 0f;
					}
					if (assignment[j] != -1)
					{
						uint item = this.mlodEntry.Bones[(int)assignment[j]];
						if (!this.list_0.Contains(item))
						{
							this.list_0.Add(this.mlodEntry.Bones[(int)assignment[j]]);
						}
						assignment[j] = (sbyte)this.list_0.IndexOf(item);
						if (j > 0)
						{
							num2 -= weights[j];
						}
					}
					if (assignment[j] != -1)
					{
						this.Skinned = true;
					}
				}
				weights[0] = num2;
				@struct.float_0 = weights[0];
				@struct.float_1 = weights[1];
				@struct.float_2 = weights[2];
				@struct.float_3 = weights[3];
				@struct.uint_0 = (uint)(((int)assignment[3] << 24) + ((int)assignment[2] << 16) + ((int)assignment[1] << 8) + (int)assignment[0]);
				SlimDX.Vector3 position2 = new SlimDX.Vector3(@struct.position.X + @struct.normal.X, @struct.position.Y + @struct.normal.Y, @struct.position.Z + @struct.normal.Z);
				SlimDX.Vector3 position3 = new SlimDX.Vector3(position.X, position.Y, position.Z);
				this.struct7_1[num++] = new Class112.Struct7(position3, 0.5f, color);
				this.struct7_1[num++] = new Class112.Struct7(position2, 0.5f, color);
				this.struct7_0[i] = @struct;
			}
			this.Palette = new Matrix[60];
			if (this.ColorPalette == null)
			{
				this.ColorPalette = new Matrix[60];
			}
			for (int k = 0; k < this.Palette.Length; k++)
			{
				this.Palette[k] = Matrix.Identity;
			}
			int num3 = this.mlodEntry.FaceCount * 3;
			IBUF ibuf = (IBUF)parent.Entries[this.mlodEntry.IBUFIndex + ((parent.dataType == 2) ? 1 : 0)];
			num3 = ibuf.Index.Length;
			this.short_0 = new short[num3 + 6];
			for (int l = 0; l < num3; l++)
			{
				this.short_0[l] = ibuf.Index[l];
			}
			this.IndexBuffer = new IndexBuffer(device, this.short_0.Length * 2, Usage.None, Pool.Managed, true);
			DataStream dataStream = this.IndexBuffer.Lock(0, this.short_0.Length * 2, LockFlags.None);
			dataStream.WriteRange<short>(this.short_0, 0, this.short_0.Length);
			this.IndexBuffer.Unlock();
			this.SelectedIndexBuffer = new IndexBuffer(device, Math.Max(this.mlodEntry.VertexCount, this.mlodEntry.FaceCount) * 3 * 2, Usage.None, Pool.Managed, true);
			this.imethod_3();
			this.VertexBuffer = new VertexBuffer(device, this.struct7_0.Length * Class112.Struct7.SizeInBytes, Usage.None, Class112.Struct7.vertexFormat_0, Pool.Managed);
			DataStream dataStream2 = this.VertexBuffer.Lock(0, 0, LockFlags.None);
			dataStream2.WriteRange<Class112.Struct7>(this.struct7_0, 0, this.struct7_0.Length);
			this.VertexBuffer.Unlock();
			this.VertexBufferTransformed = new VertexBuffer(device, this.struct7_0.Length * Class112.Struct7.SizeInBytes, Usage.None, Class112.Struct7.vertexFormat_0, Pool.Managed);
			dataStream2 = this.VertexBufferTransformed.Lock(0, 0, LockFlags.None);
			dataStream2.WriteRange<Class112.Struct7>(this.struct7_0, 0, this.struct7_0.Length);
			this.VertexBufferTransformed.Unlock();
			this.vertexBuffer_0 = new VertexBuffer(device, this.mlodEntry.VertexCount * Class112.Struct7.SizeInBytes * 2, Usage.None, VertexFormat.None, Pool.Managed);
			DataStream dataStream3 = this.vertexBuffer_0.Lock(0, 0, LockFlags.None);
			dataStream3.WriteRange<Class112.Struct7>(this.struct7_1, 0, this.mlodEntry.VertexCount * 2);
			this.vertexBuffer_0.Unlock();
			this.material_0 = default(Material);
			this.material_0.Ambient = (this.material_0.Diffuse = (this.material_0.Specular = Color.White));
			this.imethod_2(device, this.method_12(782826392)[0]);
		}

		// Token: 0x06000BDD RID: 3037 RVA: 0x0008AA84 File Offset: 0x00088C84
		public static SlimDX.Vector3 smethod_0(SlimDX.Vector3 vector3_0, SlimDX.Vector3 vector3_1, float float_0)
		{
			return SlimDX.Vector3.Lerp(vector3_0, vector3_1, (float)((double)(float_0 / SlimDX.Vector3.Distance(vector3_0, vector3_1))));
		}

		// Token: 0x06000BDE RID: 3038 RVA: 0x00096024 File Offset: 0x00094224
		private void method_8(Device device_0)
		{
			RCOL parent = this.mlod.Parent;
			bool flag = false;
			foreach (MATD.MATDEntry matdentry in this.Matd.Entries)
			{
				parent = this.Matd.Parent;
				if (matdentry.Type == (MATD.MATDEntryType)2224872156U)
				{
					this.int_2 = Convert.ToInt32(matdentry.Values[0]);
				}
				if (matdentry.Type == MATD.MATDEntryType.MaskWidth)
				{
					this.int_1 = Convert.ToInt32(matdentry.Values[0]);
				}
				if (matdentry.Type == MATD.MATDEntryType.DirtOverlay)
				{
					try
					{
						ResKey resKey_;
						if (matdentry.Values.Length == 4)
						{
							int num = matdentry.GetIntValue()[0] & 16777215;
							resKey_ = parent.ExternalResources[num - 1].ResKey;
						}
						else
						{
							int[] intValue = matdentry.GetIntValue();
							resKey_ = new ResKey((DBPFType)intValue[2], intValue[3], intValue[1], intValue[0]);
						}
						DBPFEntry dbpfentry = Class76.smethod_26(resKey_);
						if (dbpfentry != null)
						{
							if (this.texture_1 != null)
							{
								this.texture_1.Dispose();
							}
							this.texture_1 = Texture.FromMemory(device_0, dbpfentry.GetData());
							dbpfentry.Dispose();
						}
					}
					catch (Exception)
					{
					}
				}
				if (matdentry.Type == MATD.MATDEntryType.DiffuseMap)
				{
					try
					{
						ResKey resKey_2;
						if (matdentry.Values.Length == 4)
						{
							int num2 = matdentry.GetIntValue()[0] & 16777215;
							resKey_2 = parent.ExternalResources[num2 - 1].ResKey;
						}
						else
						{
							int[] intValue2 = matdentry.GetIntValue();
							resKey_2 = new ResKey((DBPFType)intValue2[2], intValue2[3], intValue2[1], intValue2[0]);
						}
						DBPFEntry dbpfentry2 = Class76.smethod_26(resKey_2);
						this.DiffuseMapIsDDS = (dbpfentry2 is DDS);
						if (dbpfentry2 is TXTC)
						{
							if (this.texture_0 != null)
							{
								this.texture_0.Dispose();
							}
							TXTC txtc = dbpfentry2 as TXTC;
							Texture texture = Class132.smethod_0().method_4(new Size(this.int_1, this.int_2));
							Interface3 @interface = Class132.smethod_0().method_8(new Size(this.int_1, this.int_2));
							XmlDocument xmlDocument_ = txtc.ToPreset();
							Class132.smethod_0().method_15(@interface, xmlDocument_, "DiffuseMap", "", texture);
							DataStream dataStream = BaseTexture.ToStream(texture, ImageFileFormat.Png);
							texture.Dispose();
							this.texture_0 = Texture.FromStream(Class140.smethod_0().Device, dataStream);
							dataStream.Dispose();
							@interface.imethod_2(true);
						}
						if (dbpfentry2 is DDS)
						{
							if (this.texture_0 != null)
							{
								this.texture_0.Dispose();
							}
							this.texture_0 = Texture.FromMemory(device_0, dbpfentry2.GetData());
							dbpfentry2.Dispose();
						}
					}
					catch (Exception)
					{
					}
				}
				if (matdentry.Type == MATD.MATDEntryType.JetTexture)
				{
					try
					{
						ResKey resKey_3;
						if (matdentry.Values.Length == 4)
						{
							int num3 = matdentry.GetIntValue()[0] & 16777215;
							resKey_3 = parent.ExternalResources[num3 - 1].ResKey;
						}
						else
						{
							int[] intValue3 = matdentry.GetIntValue();
							resKey_3 = new ResKey((DBPFType)intValue3[2], intValue3[3], intValue3[1], intValue3[0]);
						}
						DBPFEntry dbpfentry3 = Class76.smethod_26(resKey_3);
						this.DiffuseMapIsDDS = (dbpfentry3 is DDS);
						if (dbpfentry3 is TXTC)
						{
							if (this.texture_0 != null)
							{
								this.texture_0.Dispose();
							}
							TXTC txtc2 = dbpfentry3 as TXTC;
							Texture texture2 = Class132.smethod_0().method_4(new Size(this.int_1, this.int_2));
							Interface3 interface2 = Class132.smethod_0().method_8(new Size(this.int_1, this.int_2));
							XmlDocument xmlDocument_2 = txtc2.ToPreset();
							Class132.smethod_0().method_15(interface2, xmlDocument_2, "DiffuseMap", "", texture2);
							DataStream dataStream2 = BaseTexture.ToStream(texture2, ImageFileFormat.Png);
							texture2.Dispose();
							this.texture_0 = Texture.FromStream(Class140.smethod_0().Device, dataStream2);
							dataStream2.Dispose();
							interface2.imethod_2(true);
						}
						if (dbpfentry3 is DDS)
						{
							if (this.texture_0 != null)
							{
								this.texture_0.Dispose();
							}
							this.texture_0 = Texture.FromMemory(device_0, dbpfentry3.GetData());
							dbpfentry3.Dispose();
						}
					}
					catch (Exception)
					{
					}
				}
				if (matdentry.Type == MATD.MATDEntryType.DropShadowAtlas)
				{
					try
					{
						ResKey resKey_4;
						if (matdentry.Values.Length == 4)
						{
							int num4 = matdentry.GetIntValue()[0] & 16777215;
							resKey_4 = parent.ExternalResources[num4 - 1].ResKey;
						}
						else
						{
							int[] intValue4 = matdentry.GetIntValue();
							resKey_4 = new ResKey((DBPFType)intValue4[2], intValue4[3], intValue4[1], intValue4[0]);
						}
						DBPFEntry dbpfentry4 = Class76.smethod_26(resKey_4);
						if (dbpfentry4 != null)
						{
							if (this.texture_4 != null)
							{
								this.texture_4.Dispose();
							}
							this.texture_4 = Texture.FromMemory(device_0, dbpfentry4.GetData());
							dbpfentry4.Dispose();
						}
						flag = true;
					}
					catch (Exception)
					{
					}
				}
				if (matdentry.Type == (MATD.MATDEntryType)2907867744U)
				{
					try
					{
						ResKey resKey_5;
						if (matdentry.Values.Length == 4)
						{
							int num5 = matdentry.GetIntValue()[0] & 16777215;
							resKey_5 = parent.ExternalResources[num5 - 1].ResKey;
						}
						else
						{
							int[] intValue5 = matdentry.GetIntValue();
							resKey_5 = new ResKey((DBPFType)intValue5[2], intValue5[3], intValue5[1], intValue5[0]);
						}
						DBPFEntry dbpfentry5 = Class76.smethod_26(resKey_5);
						this.SpecularMapIsDDS = (dbpfentry5 is DDS);
						if (dbpfentry5 is TXTC)
						{
							if (this.texture_2 != null)
							{
								this.texture_2.Dispose();
							}
							TXTC txtc3 = dbpfentry5 as TXTC;
							Texture texture3 = Class132.smethod_0().method_4(new Size(this.int_1, this.int_2));
							Interface3 interface3 = Class132.smethod_0().method_8(new Size(this.int_1, this.int_2));
							XmlDocument xmlDocument_3 = txtc3.ToPreset();
							Class132.smethod_0().method_15(interface3, xmlDocument_3, "DiffuseMap", "", texture3);
							DataStream dataStream3 = BaseTexture.ToStream(texture3, ImageFileFormat.Png);
							texture3.Dispose();
							this.texture_2 = Texture.FromStream(Class140.smethod_0().Device, dataStream3);
							dataStream3.Dispose();
							interface3.imethod_2(true);
						}
						if (dbpfentry5 is DDS)
						{
							if (this.texture_2 != null)
							{
								this.texture_2.Dispose();
							}
							this.texture_2 = Texture.FromMemory(device_0, dbpfentry5.GetData());
							dbpfentry5.Dispose();
						}
					}
					catch (Exception)
					{
					}
				}
				if (matdentry.Type == MATD.MATDEntryType.NormalMap)
				{
					try
					{
						ResKey resKey_6;
						if (matdentry.Values.Length == 4)
						{
							int num6 = matdentry.GetIntValue()[0] & 16777215;
							resKey_6 = parent.ExternalResources[num6 - 1].ResKey;
						}
						else
						{
							int[] intValue6 = matdentry.GetIntValue();
							resKey_6 = new ResKey((DBPFType)intValue6[2], intValue6[3], intValue6[1], intValue6[0]);
						}
						DBPFEntry dbpfentry6 = Class76.smethod_26(resKey_6);
						this.NormalMapIsDDS = (dbpfentry6 is DDS);
						if (dbpfentry6 != null)
						{
							if (this.texture_3 != null)
							{
								this.texture_3.Dispose();
							}
							this.texture_3 = Texture.FromMemory(device_0, dbpfentry6.GetData());
							dbpfentry6.Dispose();
						}
					}
					catch (Exception)
					{
					}
				}
				if (matdentry.Type == (MATD.MATDEntryType)3785348473U)
				{
					try
					{
						ResKey resKey_7;
						if (matdentry.Values.Length == 4)
						{
							int num7 = matdentry.GetIntValue()[0] & 16777215;
							resKey_7 = parent.ExternalResources[num7 - 1].ResKey;
						}
						else
						{
							int[] intValue7 = matdentry.GetIntValue();
							resKey_7 = new ResKey((DBPFType)intValue7[2], intValue7[3], intValue7[1], intValue7[0]);
						}
						DBPFEntry dbpfentry7 = Class76.smethod_26(resKey_7);
						if (dbpfentry7 != null)
						{
							if (this.texture_3 != null)
							{
								this.texture_3.Dispose();
							}
							this.texture_3 = Texture.FromMemory(device_0, dbpfentry7.GetData());
							dbpfentry7.Dispose();
						}
					}
					catch (Exception)
					{
					}
				}
			}
			if (this.Matd.Shader == (MATD.MATDShader)3231479170U && !flag)
			{
				foreach (MATD.MATDEntry matdentry2 in this.Matd.Entries)
				{
					if (matdentry2.Type == MATD.MATDEntryType.DiffuseMap)
					{
						try
						{
							ResKey resKey_8;
							if (matdentry2.Values.Length == 4)
							{
								int num8 = matdentry2.GetIntValue()[0] & 16777215;
								resKey_8 = parent.ExternalResources[num8 - 1].ResKey;
							}
							else
							{
								int[] intValue8 = matdentry2.GetIntValue();
								resKey_8 = new ResKey((DBPFType)intValue8[2], intValue8[3], intValue8[1], intValue8[0]);
							}
							DBPFEntry dbpfentry8 = Class76.smethod_26(resKey_8);
							if (dbpfentry8 != null)
							{
								if (this.texture_4 != null)
								{
									this.texture_4.Dispose();
								}
								this.texture_4 = Texture.FromMemory(device_0, dbpfentry8.GetData());
								dbpfentry8.Dispose();
							}
							flag = true;
						}
						catch (Exception)
						{
						}
					}
				}
			}
		}

		// Token: 0x06000BDF RID: 3039 RVA: 0x000969C0 File Offset: 0x00094BC0
		public void method_9(Device device_0, Matrix matrix_2)
		{
			device_0.Indices = this.IndexBuffer;
			device_0.SetStreamSource(0, this.VertexBuffer, 0, Class112.Struct7.SizeInBytes);
			Class140.smethod_0().method_40("FlatShade");
			Class140.smethod_0().method_9(RenderState.FillMode, FillMode.Solid);
			Class140.smethod_0().method_9(RenderState.ZEnable, true);
			Class140.smethod_0().method_9(RenderState.ZWriteEnable, true);
			Class140.smethod_0().method_9(RenderState.CullMode, Cull.None);
			Class140.smethod_0().method_28("g_forcedTransparency", 1f);
			Class140.smethod_0().method_30("g_ambient", Color.Gray.ToArgb());
			Class140.smethod_0().method_35();
			int num = Class140.smethod_0().method_36();
			for (int i = 0; i < num; i++)
			{
				Class140.smethod_0().method_38(i);
				device_0.DrawIndexedPrimitives(PrimitiveType.TriangleList, 0, 0, this.mlodEntry.VertexCount, (int)this.mlodEntry.IBUFOffset, this.mlodEntry.FaceCount);
				Class140.smethod_0().method_39();
			}
			Class140.smethod_0().method_37();
			Class140.smethod_0().method_40("Line");
			Class140.smethod_0().method_9(RenderState.FillMode, FillMode.Wireframe);
			num = Class140.smethod_0().method_36();
			for (int j = 0; j < num; j++)
			{
				Class140.smethod_0().method_38(j);
				device_0.DrawIndexedPrimitives(PrimitiveType.TriangleList, 0, 0, this.mlodEntry.VertexCount, (int)this.mlodEntry.IBUFOffset, this.mlodEntry.FaceCount);
				Class140.smethod_0().method_39();
			}
			Class140.smethod_0().method_37();
			Class140.smethod_0().method_9(RenderState.ZWriteEnable, false);
			Class140.smethod_0().method_40("Line");
			Class140.smethod_0().method_30("g_ambient", Color.White.ToArgb());
			Class140.smethod_0().method_9(RenderState.FillMode, FillMode.Point);
			Class140.smethod_0().method_9(RenderState.PointSize, 3f);
			num = Class140.smethod_0().method_36();
			for (int k = 0; k < num; k++)
			{
				Class140.smethod_0().method_38(k);
				device_0.DrawIndexedPrimitives(PrimitiveType.TriangleList, 0, 0, this.mlodEntry.VertexCount, (int)this.mlodEntry.IBUFOffset, this.mlodEntry.FaceCount);
				Class140.smethod_0().method_39();
			}
			Class140.smethod_0().method_37();
			Class140.smethod_0().method_30("g_ambient", Color.Red.ToArgb());
			device_0.Indices = this.SelectedIndexBuffer;
			num = Class140.smethod_0().method_36();
			for (int l = 0; l < num; l++)
			{
				Class140.smethod_0().method_38(l);
				device_0.DrawIndexedPrimitives(PrimitiveType.TriangleList, 0, 0, this.mlodEntry.VertexCount, 0, this.CurrentSelectionIndex.Count);
				Class140.smethod_0().method_39();
			}
			Class140.smethod_0().method_37();
		}

		// Token: 0x06000BE0 RID: 3040 RVA: 0x00006E18 File Offset: 0x00005018
		public void method_10(Device device_0, Matrix matrix_2, Matrix matrix_3, bool bool_5)
		{
			Class140.smethod_0().method_10();
			this.method_11(device_0, matrix_2, matrix_3, bool_5, false);
		}

		// Token: 0x06000BE1 RID: 3041 RVA: 0x00096CB4 File Offset: 0x00094EB4
		public void method_11(Device device_0, Matrix matrix_2, Matrix matrix_3, bool bool_5, bool bool_6)
		{
			if (this.Visible)
			{
				Class121 @class = null;
				if (Class132.mainForm.CurrentProjectModel is Class80)
				{
					@class = (Class132.mainForm.CurrentProjectModel as Class80).Control.MLODPropertyGrid.MLODRenderable;
				}
				else if (Class132.mainForm.CurrentProjectModel is Class86)
				{
					@class = (Class132.mainForm.CurrentProjectModel as Class86).Control.MeshPropertyGrid.MLODRenderable;
				}
				if (Class132.smethod_0().SelectionDialog == null || @class == this || @class == null)
				{
					if (!bool_6 || this.Matd.Shader == MATD.MATDShader.ShadowMap)
					{
						if (bool_6 || this.Matd.Shader != MATD.MATDShader.ShadowMap)
						{
							Class140.smethod_0().method_33(this.Palette);
							Class140.smethod_0().method_9(RenderState.AlphaBlendEnable, true);
							Class140.smethod_0().method_9(RenderState.ZWriteEnable, true);
							Class140.smethod_0().method_9(RenderState.AlphaTestEnable, false);
							Class140.smethod_0().method_9(RenderState.Lighting, false);
							Class140.smethod_0().method_9(RenderState.FillMode, Class132.smethod_0().Wireframe ? FillMode.Wireframe : FillMode.Solid);
							Class140.smethod_0().method_9(RenderState.CullMode, Cull.Clockwise);
							Class140.smethod_0().method_9(RenderState.ZEnable, true);
							Class140.smethod_0().method_9(RenderState.ZFunc, Compare.Less);
							Class140.smethod_0().method_32(matrix_2, matrix_3);
							Class132.smethod_0().method_30(this.Matd);
							Class140.smethod_0().method_34(this.Skinned);
							if (this.Matd.Shader == MATD.MATDShader.ShadowMap)
							{
								SlimDX.Vector4 vector4_ = new SlimDX.Vector4(0f, 0f, 0f, 0f);
								SlimDX.Vector4 vector4_2 = new SlimDX.Vector4(1f, 1f, 1f, 1f);
								RCOL parent = this.mlod.Parent;
								RCOLItem rcolitem = parent.Entries[this.mlodEntry.GEOStateIndex + ((parent.dataType == 2) ? 1 : 0)];
								if (rcolitem is MATD)
								{
									MATD matd = rcolitem as MATD;
									foreach (MATD.MATDEntry matdentry in matd.Entries)
									{
										if (matdentry.Type == MATD.MATDEntryType.PosScale)
										{
											for (int i = 0; i < matdentry.numValues; i++)
											{
												vector4_2[i] = (float)matdentry.Values[i];
											}
											vector4_2[0] = vector4_2[0] / 3.051851E-05f;
											vector4_2[1] = vector4_2[1] / 3.051851E-05f;
											vector4_2[2] = vector4_2[2] / 3.051851E-05f;
											vector4_2[3] = 1f;
										}
										if (matdentry.Type == MATD.MATDEntryType.PosOffset)
										{
											for (int j = 0; j < matdentry.numValues; j++)
											{
												vector4_[j] = (float)matdentry.Values[j];
											}
											vector4_[3] = 0f;
											vector4_[0] = vector4_[0];
										}
									}
								}
								Class140.smethod_0().method_12(vector4_2, vector4_);
							}
							if (Class140.smethod_0().CurrentRenderMode != Class140.Enum20.const_0 || (this.Matd.Shader != MATD.MATDShader.GlassForFences && this.Matd.Shader != MATD.MATDShader.GlassForObjects && this.Matd.Shader != (MATD.MATDShader)2224877601U && this.Matd.Shader != (MATD.MATDShader)2178752589U && this.Matd.Shader != MATD.MATDShader.GlassForRabbitHoles))
							{
								if (this.texture_1 != null)
								{
									Class140.smethod_0().method_16(this.texture_1);
								}
								if (this.texture_0 != null)
								{
									Class140.smethod_0().method_18(this.texture_0);
								}
								if (this.texture_2 != null)
								{
									Class140.smethod_0().method_19(this.texture_2);
								}
								if (this.texture_3 != null)
								{
									Class140.smethod_0().method_20(this.texture_3);
								}
								if (this.texture_4 != null)
								{
									Class140.smethod_0().method_17(this.texture_4);
								}
								Class140.smethod_0().method_27("g_alphaBlend", true);
								Class140.smethod_0().method_27("g_selected", false);
								Class140.smethod_0().method_27("isSkinned", this.Skinned);
								Class140.smethod_0().method_27("g_showBump", Class132.smethod_0().BumpMapEnabled);
								if (bool_6)
								{
									Class140.smethod_0().method_40("ShadowMap");
								}
								Class140.smethod_0().method_9(RenderState.CullMode, Cull.Clockwise);
								if (this.Matd.Shader == (MATD.MATDShader)4284377352U)
								{
									Class140.smethod_0().method_40("Line");
									Class140.smethod_0().method_9(RenderState.CullMode, Cull.None);
									Class140.smethod_0().method_30("g_ambient", Color.White.ToArgb());
									Class140.smethod_0().method_9(RenderState.FillMode, FillMode.Point);
									Class140.smethod_0().method_9(RenderState.PointSize, 3f);
								}
								if (Class132.smethod_0().SelectionDialog != null && !bool_6 && @class != null)
								{
									device_0.Indices = this.IndexBuffer;
									device_0.SetStreamSource(0, this.VertexBuffer, 0, Class112.Struct7.SizeInBytes);
									Class140.smethod_0().method_9(RenderState.Lighting, false);
									Class140.smethod_0().method_9(RenderState.AlphaTestEnable, false);
									Class140.smethod_0().method_9(RenderState.ZWriteEnable, true);
									Class140.smethod_0().method_9(RenderState.ZFunc, Compare.LessEqual);
									Class140.smethod_0().method_9(RenderState.FillMode, FillMode.Solid);
									Class140.smethod_0().method_9(RenderState.CullMode, Cull.None);
									GeostateSelector geostateSelector = Class132.smethod_0().SelectionDialog as GeostateSelector;
									if (geostateSelector != null && geostateSelector.bool_8)
									{
										Class140.smethod_0().method_40("SelectionLine");
										Class140.smethod_0().method_9(RenderState.AlphaBlendEnable, true);
										Class140.smethod_0().method_9(RenderState.FillMode, FillMode.Solid);
										Class140.smethod_0().method_28("g_forcedTransparency", 0.2f);
										short[] indexData = geostateSelector.short_0;
										int num = geostateSelector.int_0;
										int num2 = Class140.smethod_0().method_36();
										for (int k = 0; k < num2; k++)
										{
											Class140.smethod_0().method_38(k);
											Class140.smethod_0().method_39();
										}
										Class140.smethod_0().method_37();
										Class140.smethod_0().method_40("SelectionLine");
										Class140.smethod_0().method_9(RenderState.AlphaBlendEnable, true);
										Class140.smethod_0().method_9(RenderState.FillMode, FillMode.Wireframe);
										Class140.smethod_0().method_28("g_forcedTransparency", 1f);
										num2 = Class140.smethod_0().method_36();
										for (int l = 0; l < num2; l++)
										{
											Class140.smethod_0().method_38(l);
											Class140.smethod_0().method_39();
										}
										Class140.smethod_0().method_37();
										if (num != -1)
										{
											Class132.smethod_0().method_30(this.Matd);
											Class140.smethod_0().method_9(RenderState.AlphaBlendEnable, true);
											Class140.smethod_0().method_9(RenderState.FillMode, FillMode.Solid);
											Class140.smethod_0().method_28("g_forcedTransparency", 1f);
											num2 = Class140.smethod_0().method_36();
											for (int m = 0; m < num2; m++)
											{
												Class140.smethod_0().method_38(m);
												device_0.DrawIndexedUserPrimitives<short, Class112.Struct7>(PrimitiveType.TriangleList, num, 0, this.struct7_0.Length, 1, indexData, Format.Index16, this.struct7_0, Class112.Struct7.SizeInBytes);
												Class140.smethod_0().method_39();
											}
											Class140.smethod_0().method_37();
										}
										device_0.Indices = this.IndexBuffer;
										Class140.smethod_0().method_9(RenderState.FillMode, FillMode.Wireframe);
										Class140.smethod_0().method_9(RenderState.ZEnable, false);
										Class140.smethod_0().method_40("SelectionLine");
										Class140.smethod_0().method_31("g_ambient", Color.White);
										Class140.smethod_0().method_28("g_forcedTransparency", 0.1f);
										num2 = Class140.smethod_0().method_36();
										for (int n = 0; n < num2; n++)
										{
											Class140.smethod_0().method_38(n);
											device_0.SetStreamSource(0, this.VertexBuffer, 0, Class112.Struct7.SizeInBytes);
											device_0.DrawIndexedPrimitives(PrimitiveType.TriangleList, 0, 0, this.mlodEntry.VertexCount, (int)this.mlodEntry.IBUFOffset, this.mlodEntry.FaceCount);
											Class140.smethod_0().method_39();
										}
										Class140.smethod_0().method_37();
										Class140.smethod_0().method_28("g_forcedTransparency", 1f);
									}
									else
									{
										Class140.smethod_0().method_40("Selection");
										int num3 = Class140.smethod_0().method_36();
										for (int num4 = 0; num4 < num3; num4++)
										{
											Class140.smethod_0().method_38(num4);
											device_0.SetStreamSource(0, this.VertexBuffer, 0, Class112.Struct7.SizeInBytes);
											device_0.DrawIndexedPrimitives(PrimitiveType.TriangleList, 0, 0, this.mlodEntry.VertexCount, (int)this.mlodEntry.IBUFOffset, this.mlodEntry.FaceCount);
											Class140.smethod_0().method_39();
										}
										Class140.smethod_0().method_37();
										Class132.smethod_0().method_30(this.Matd);
										device_0.Indices = this.SelectedIndexBuffer;
										num3 = Class140.smethod_0().method_36();
										for (int num5 = 0; num5 < num3; num5++)
										{
											Class140.smethod_0().method_38(num5);
											if (this.CurrentSelectionIndex.Count > 0)
											{
												device_0.DrawIndexedPrimitives(PrimitiveType.TriangleList, 0, 0, this.mlodEntry.VertexCount, 0, this.CurrentSelectionIndex.Count);
											}
											Class140.smethod_0().method_39();
										}
										Class140.smethod_0().method_37();
										device_0.Indices = this.IndexBuffer;
										Class140.smethod_0().method_9(RenderState.FillMode, FillMode.Wireframe);
										Class140.smethod_0().method_40("SelectionGhost");
										num3 = Class140.smethod_0().method_36();
										for (int num6 = 0; num6 < num3; num6++)
										{
											Class140.smethod_0().method_38(num6);
											device_0.SetStreamSource(0, this.VertexBuffer, 0, Class112.Struct7.SizeInBytes);
											device_0.DrawIndexedPrimitives(PrimitiveType.TriangleList, 0, 0, this.mlodEntry.VertexCount, (int)this.mlodEntry.IBUFOffset, this.mlodEntry.FaceCount);
											Class140.smethod_0().method_39();
										}
										Class140.smethod_0().method_37();
									}
								}
								else
								{
									PrimitiveType primitiveType = PrimitiveType.TriangleList;
									switch (this.mlodEntry.PrimitiveType)
									{
									case MLOD.PrimitiveType.PointList:
										primitiveType = PrimitiveType.PointList;
										break;
									case MLOD.PrimitiveType.LineList:
										primitiveType = PrimitiveType.LineList;
										break;
									case MLOD.PrimitiveType.LineStrip:
										primitiveType = PrimitiveType.LineStrip;
										break;
									case MLOD.PrimitiveType.TriangleList:
										primitiveType = PrimitiveType.TriangleList;
										break;
									case MLOD.PrimitiveType.TriangleFan:
										primitiveType = PrimitiveType.TriangleFan;
										break;
									case MLOD.PrimitiveType.TriangleStrip:
										primitiveType = PrimitiveType.TriangleStrip;
										break;
									case MLOD.PrimitiveType.QuadList:
									case MLOD.PrimitiveType.DisplayList:
										throw new Exception("Invalid PrimitiveType");
									}
									device_0.Indices = this.IndexBuffer;
									int num7 = Class140.smethod_0().method_36();
									for (int num8 = 0; num8 < num7; num8++)
									{
										Class140.smethod_0().method_38(num8);
										if (this.int_0 != -1)
										{
											if (this.mlodEntry.GeoStateEntries[this.int_0].VertexCount > 0)
											{
												device_0.Indices = this.IndexBuffer;
												device_0.SetStreamSource(0, this.VertexBuffer, 0, Class112.Struct7.SizeInBytes);
												int vbufoffset = this.mlodEntry.GeoStateEntries[this.int_0].VBUFOffset;
												int vertexCount = this.mlodEntry.GeoStateEntries[this.int_0].VertexCount;
												int ibufoffset = this.mlodEntry.GeoStateEntries[this.int_0].IBUFOffset;
												int faceCount = this.mlodEntry.GeoStateEntries[this.int_0].FaceCount;
												device_0.DrawIndexedPrimitives(primitiveType, 0, vbufoffset, vertexCount, ibufoffset, faceCount);
											}
										}
										else
										{
											device_0.Indices = this.IndexBuffer;
											device_0.SetStreamSource(0, this.VertexBuffer, 0, Class112.Struct7.SizeInBytes);
											device_0.DrawIndexedPrimitives(primitiveType, 0, 0, this.mlodEntry.VertexCount, (int)this.mlodEntry.IBUFOffset, this.mlodEntry.FaceCount);
										}
										Class140.smethod_0().method_39();
									}
									Class140.smethod_0().method_37();
								}
								if (Class132.smethod_0().NormalsEnabled && !bool_5)
								{
									device_0.SetTransform(TransformState.World, matrix_2);
									Class140.smethod_0().method_9(RenderState.Lighting, false);
									device_0.SetStreamSource(0, this.vertexBuffer_0, 0, Class112.Struct7.SizeInBytes);
									device_0.DrawPrimitives(PrimitiveType.LineList, 0, this.mlodEntry.VertexCount);
								}
							}
						}
					}
				}
			}
		}

		// Token: 0x06000BE2 RID: 3042 RVA: 0x00097988 File Offset: 0x00095B88
		public bool imethod_0(Device device_0, Matrix matrix_2, SlimDX.Vector3 vector3_0, SlimDX.Vector3 vector3_1, out float float_0)
		{
			MeshEditor meshEditor = Class132.smethod_0();
			int num = (int)((float)device_0.Viewport.Width * (vector3_0.X / (float)meshEditor.Width));
			int num2 = (int)((float)device_0.Viewport.Height * (vector3_0.Y / (float)meshEditor.Height));
			vector3_0.X = (vector3_1.X = (float)num);
			vector3_0.Y = (vector3_1.Y = (float)(num2 + 18));
			SlimDX.Vector3 position = SlimDX.Vector3.Unproject(vector3_0, (float)device_0.Viewport.X, (float)device_0.Viewport.Y, (float)device_0.Viewport.Width, (float)device_0.Viewport.Height, device_0.Viewport.MinZ, device_0.Viewport.MaxZ, matrix_2 * Class132.smethod_0().ViewMatrix * Class132.smethod_0().ProjectionMatrix);
			SlimDX.Vector3 direction = SlimDX.Vector3.Unproject(vector3_1, (float)device_0.Viewport.X, (float)device_0.Viewport.Y, (float)device_0.Viewport.Width, (float)device_0.Viewport.Height, device_0.Viewport.MinZ, device_0.Viewport.MaxZ, matrix_2 * Class132.smethod_0().ViewMatrix * Class132.smethod_0().ProjectionMatrix);
			Ray ray = new Ray(position, direction);
			for (int i = 0; i < this.short_0.Length / 3; i += 3)
			{
				SlimDX.Vector3 position2 = this.struct7_0[(int)this.short_0[i]].position;
				SlimDX.Vector3 position3 = this.struct7_0[(int)this.short_0[i + 1]].position;
				SlimDX.Vector3 position4 = this.struct7_0[(int)this.short_0[i + 2]].position;
				if (Ray.Intersects(ray, position2, position3, position4, out float_0))
				{
					return true;
				}
			}
			float_0 = 0f;
			return false;
		}

		// Token: 0x06000BE3 RID: 3043 RVA: 0x00097BB8 File Offset: 0x00095DB8
		public void imethod_3()
		{
			if (this.CurrentSelectionIndex.Count > 0)
			{
				DataStream dataStream = this.SelectedIndexBuffer.Lock(0, this.CurrentSelectionIndex.Count * 2 * 3, LockFlags.None);
				foreach (Class102.Class107 @class in this.CurrentSelectionIndex)
				{
					dataStream.WriteRange<short>(new short[]
					{
						@class.short_0,
						@class.short_1,
						@class.short_2
					}, 0, 3);
				}
				this.SelectedIndexBuffer.Unlock();
			}
			EditorToolBox.smethod_0().method_4();
		}

		// Token: 0x06000BE4 RID: 3044 RVA: 0x00097C78 File Offset: 0x00095E78
		public List<MATD> method_12(int int_3)
		{
			RCOL parent = this.mlod.Parent;
			List<MATD> list = new List<MATD>();
			RCOLItem rcolitem = parent.Entries[this.mlodEntry.MATDIndex + ((parent.dataType == 2) ? 1 : 0)];
			if (rcolitem is MATD)
			{
				MATD item = rcolitem as MATD;
				list.Add(item);
			}
			else if (rcolitem is MTST)
			{
				MTST mtst = rcolitem as MTST;
				foreach (MTST.MTSTEntry mtstentry in mtst.Entries)
				{
					if (int_3 == 0 || (long)int_3 == (long)((ulong)mtstentry.Hash))
					{
						int num = mtstentry.MATDIndex + ((parent.dataType == 2) ? 1 : 0);
						if ((num & 536870912) > 0)
						{
							num = (mtstentry.MATDIndex & 16777215);
							RCOLFileEntry rcolfileEntry = parent.ExternalResources[num - 1];
							RCOL rcol = Class76.smethod_26(rcolfileEntry.ResKey) as RCOL;
							using (List<RCOLItem>.Enumerator enumerator2 = rcol.Entries.GetEnumerator())
							{
								while (enumerator2.MoveNext())
								{
									RCOLItem rcolitem2 = enumerator2.Current;
									if (rcolitem2 is MATD)
									{
										list.Add(rcolitem2 as MATD);
									}
								}
								continue;
							}
						}
						MATD item2 = parent.Entries[num] as MATD;
						list.Add(item2);
					}
				}
			}
			rcolitem = parent.Entries[this.mlodEntry.GEOStateIndex + ((parent.dataType == 2) ? 1 : 0)];
			if (rcolitem is MATD)
			{
				MATD item3 = rcolitem as MATD;
				list.Add(item3);
			}
			return list;
		}

		// Token: 0x06000BE5 RID: 3045 RVA: 0x00002A71 File Offset: 0x00000C71
		public void method_13(Device device_0)
		{
		}

		// Token: 0x06000BE6 RID: 3046 RVA: 0x00002A71 File Offset: 0x00000C71
		public void method_14(Device device_0)
		{
		}

		// Token: 0x06000BE7 RID: 3047 RVA: 0x00097E50 File Offset: 0x00096050
		public void imethod_1(bool bool_5)
		{
			this.VertexBuffer.Dispose();
			this.IndexBuffer.Dispose();
			this.VertexBuffer.Dispose();
			this.VertexBufferTransformed.Dispose();
			this.SelectedIndexBuffer.Dispose();
			this.vertexBuffer_0.Dispose();
			this.struct7_0 = null;
			this.struct7_1 = null;
			this.short_0 = null;
			if (this.texture_2 != null)
			{
				this.texture_2.Dispose();
			}
			if (this.texture_0 != null)
			{
				this.texture_0.Dispose();
			}
			if (this.texture_3 != null)
			{
				this.texture_3.Dispose();
			}
			if (this.texture_1 != null)
			{
				this.texture_1.Dispose();
			}
			if (this.texture_4 != null)
			{
				this.texture_4.Dispose();
			}
		}

		// Token: 0x04000931 RID: 2353
		private MLOD.MLODEntry mlodEntry;

		// Token: 0x04000932 RID: 2354
		private MLOD mlod;

		// Token: 0x04000933 RID: 2355
		private VertexBuffer vertexBuffer_0;

		// Token: 0x04000934 RID: 2356
		private Material material_0;

		// Token: 0x04000935 RID: 2357
		private Texture texture_0;

		// Token: 0x04000936 RID: 2358
		private Texture texture_1;

		// Token: 0x04000937 RID: 2359
		private Texture texture_2;

		// Token: 0x04000938 RID: 2360
		private Texture texture_3;

		// Token: 0x04000939 RID: 2361
		private Texture texture_4;

		// Token: 0x0400093A RID: 2362
		private Class112.Struct7[] struct7_0;

		// Token: 0x0400093B RID: 2363
		private Class112.Struct7[] struct7_1;

		// Token: 0x0400093C RID: 2364
		private short[] short_0;

		// Token: 0x0400093D RID: 2365
		private int int_0 = -1;

		// Token: 0x0400093E RID: 2366
		private MATD matd_0;

		// Token: 0x0400093F RID: 2367
		public List<uint> list_0;

		// Token: 0x04000940 RID: 2368
		private int int_1 = 1024;

		// Token: 0x04000941 RID: 2369
		private int int_2 = 1024;

		// Token: 0x04000942 RID: 2370
		[CompilerGenerated]
		private object object_0;

		// Token: 0x04000943 RID: 2371
		[CompilerGenerated]
		private object object_1;

		// Token: 0x04000944 RID: 2372
		[CompilerGenerated]
		private VertexBuffer vertexBuffer_1;

		// Token: 0x04000945 RID: 2373
		[CompilerGenerated]
		private VertexBuffer vertexBuffer_2;

		// Token: 0x04000946 RID: 2374
		[CompilerGenerated]
		private IndexBuffer indexBuffer_0;

		// Token: 0x04000947 RID: 2375
		[CompilerGenerated]
		private IndexBuffer indexBuffer_1;

		// Token: 0x04000948 RID: 2376
		[CompilerGenerated]
		private List<Class102.Class107> list_1;

		// Token: 0x04000949 RID: 2377
		[CompilerGenerated]
		private bool bool_0;

		// Token: 0x0400094A RID: 2378
		[CompilerGenerated]
		private Lod lod_0;

		// Token: 0x0400094B RID: 2379
		[CompilerGenerated]
		private bool bool_1;

		// Token: 0x0400094C RID: 2380
		[CompilerGenerated]
		private bool bool_2;

		// Token: 0x0400094D RID: 2381
		[CompilerGenerated]
		private bool bool_3;

		// Token: 0x0400094E RID: 2382
		[CompilerGenerated]
		private bool bool_4;

		// Token: 0x0400094F RID: 2383
		[CompilerGenerated]
		private Matrix[] matrix_0;

		// Token: 0x04000950 RID: 2384
		[CompilerGenerated]
		private Matrix[] matrix_1;

		// Token: 0x04000951 RID: 2385
		[CompilerGenerated]
		private Bitmap bitmap_0;
	}
}
