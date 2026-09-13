using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using System.Xml;
using ns10;
using ns13;
using ns16;
using ns17;
using ns2;
using ns6;
using ns8;
using Package;
using Package.Sims3Files;
using Package.Sims3Files.InternalRCOL;
using Sims3WorkshopSDK;
using Sims3WorkshopSDK.Interfaces;
using SlimDX;
using SlimDX.Direct3D9;

namespace ns7
{
	// Token: 0x02000119 RID: 281
	internal sealed class Class106 : Class102
	{
		// Token: 0x17000284 RID: 644
		// (get) Token: 0x06000C95 RID: 3221 RVA: 0x0009E2A8 File Offset: 0x0009C4A8
		// (set) Token: 0x06000C96 RID: 3222 RVA: 0x000071D9 File Offset: 0x000053D9
		private Texture _diffuseTexture { get; set; }

		// Token: 0x17000285 RID: 645
		// (get) Token: 0x06000C97 RID: 3223 RVA: 0x0009E2C0 File Offset: 0x0009C4C0
		// (set) Token: 0x06000C98 RID: 3224 RVA: 0x000071E4 File Offset: 0x000053E4
		private Texture _specularTexture { get; set; }

		// Token: 0x17000286 RID: 646
		// (get) Token: 0x06000C99 RID: 3225 RVA: 0x0009E2D8 File Offset: 0x0009C4D8
		// (set) Token: 0x06000C9A RID: 3226 RVA: 0x000071EF File Offset: 0x000053EF
		private Texture _noiseTexture { get; set; }

		// Token: 0x17000287 RID: 647
		// (get) Token: 0x06000C9B RID: 3227 RVA: 0x0009E2F0 File Offset: 0x0009C4F0
		// (set) Token: 0x06000C9C RID: 3228 RVA: 0x000071FA File Offset: 0x000053FA
		private VertexBuffer _roofVertexBuffer { get; set; }

		// Token: 0x17000288 RID: 648
		// (get) Token: 0x06000C9D RID: 3229 RVA: 0x0009E308 File Offset: 0x0009C508
		// (set) Token: 0x06000C9E RID: 3230 RVA: 0x00007205 File Offset: 0x00005405
		private IndexBuffer _roofIndexBuffer { get; set; }

		// Token: 0x17000289 RID: 649
		// (get) Token: 0x06000C9F RID: 3231 RVA: 0x0009E320 File Offset: 0x0009C520
		// (set) Token: 0x06000CA0 RID: 3232 RVA: 0x00007210 File Offset: 0x00005410
		private int _roofVertexCount { get; set; }

		// Token: 0x1700028A RID: 650
		// (get) Token: 0x06000CA1 RID: 3233 RVA: 0x0009E338 File Offset: 0x0009C538
		// (set) Token: 0x06000CA2 RID: 3234 RVA: 0x0000721B File Offset: 0x0000541B
		private int _roofFaceCount { get; set; }

		// Token: 0x1700028B RID: 651
		// (get) Token: 0x06000CA3 RID: 3235 RVA: 0x0009E350 File Offset: 0x0009C550
		public List<Lod> LodLevels
		{
			get
			{
				return this.list_10;
			}
		}

		// Token: 0x06000CA4 RID: 3236 RVA: 0x0009E368 File Offset: 0x0009C568
		public Class106(BuildItem buildItem)
		{
			this.list_10 = new List<Lod>();
			this.lod_0 = Lod.High;
			this.buildItem = buildItem;
			this.matrix_0 = new Matrix[60];
			for (int i = 0; i < 60; i++)
			{
				this.matrix_0[i] = Matrix.Identity;
			}
		}

		// Token: 0x06000CA5 RID: 3237 RVA: 0x0009E3C8 File Offset: 0x0009C5C8
		public unsafe override void imethod_6(Device device_0)
		{
			this.method_3();
			this.method_4();
			if (this.buildItem is ROOF)
			{
				MemoryStream memoryStream = new MemoryStream(Class143.roof);
				Mesh mesh = Mesh.FromStream(device_0, memoryStream, MeshFlags.Managed);
				Class112.Struct7[] array = new Class112.Struct7[mesh.VertexCount];
				short[] array2 = new short[mesh.FaceCount * 3];
				DataStream dataStream = mesh.LockVertexBuffer(LockFlags.None);
				Class112.Struct5* ptr = (Class112.Struct5*)((void*)dataStream.DataPointer);
				for (int i = 0; i < mesh.VertexCount; i++)
				{
					Class112.Struct5 @struct = ptr[i];
					Class112.Struct7 struct2 = default(Class112.Struct7);
					struct2.normal = @struct.normal;
					struct2.position = @struct.position;
					struct2.vector2_0.X = @struct.vector2_0.X / 3.051851E-05f;
					struct2.vector2_0.Y = @struct.vector2_0.Y / 3.051851E-05f;
					array[i] = struct2;
				}
				mesh.UnlockVertexBuffer();
				dataStream = mesh.LockIndexBuffer(LockFlags.None);
				short* ptr2 = (short*)((void*)dataStream.DataPointer);
				for (int j = 0; j < mesh.FaceCount * 3; j++)
				{
					array2[j] = ptr2[j];
				}
				mesh.UnlockIndexBuffer();
				this._roofVertexBuffer = new VertexBuffer(device_0, array.Length * Class112.Struct7.SizeInBytes, Usage.None, Class112.Struct7.vertexFormat_0, Pool.Managed);
				DataStream dataStream2 = this._roofVertexBuffer.Lock(0, 0, LockFlags.None);
				dataStream2.WriteRange<Class112.Struct7>(array, 0, array.Length);
				this._roofVertexBuffer.Unlock();
				this._roofVertexCount = mesh.VertexCount;
				this._roofIndexBuffer = new IndexBuffer(device_0, array2.Length * 2, Usage.None, Pool.Managed, true);
				DataStream dataStream3 = this._roofIndexBuffer.Lock(0, array2.Length * 2, LockFlags.None);
				dataStream3.WriteRange<short>(array2, 0, array2.Length);
				this._roofIndexBuffer.Unlock();
				this._roofFaceCount = mesh.FaceCount;
				mesh.Dispose();
				memoryStream.Dispose();
			}
			this.imethod_7(device_0);
		}

		// Token: 0x06000CA6 RID: 3238 RVA: 0x00007226 File Offset: 0x00005426
		private void method_3()
		{
			this.interface3_0 = Class132.smethod_0().method_8(new Size(1024, 1024));
		}

		// Token: 0x06000CA7 RID: 3239 RVA: 0x0009E5D4 File Offset: 0x0009C7D4
		private void method_4()
		{
			this.texture_0 = Class132.smethod_0().method_4(new Size(1024, 1024));
			this._diffuseTexture = Class132.smethod_0().method_4(new Size(1024, 1024));
			this._specularTexture = Class132.smethod_0().method_4(new Size(1024, 1024));
		}

		// Token: 0x06000CA8 RID: 3240 RVA: 0x0009E640 File Offset: 0x0009C840
		public override void imethod_5(Device device_0)
		{
			this.imethod_8(false);
			foreach (Interface9 @interface in base.Objects.Values)
			{
				Class121 @class = (Class121)@interface;
				@class.method_13(device_0);
			}
		}

		// Token: 0x06000CA9 RID: 3241 RVA: 0x0009E6A8 File Offset: 0x0009C8A8
		public override void vmethod_7(Device device_0)
		{
			this.method_4();
			this.method_3();
			if (this.buildItem is TerrainPaint)
			{
				TerrainPaint terrainPaint = this.buildItem as TerrainPaint;
				DBPFEntry dbpfentry = Class76.smethod_26(new ResKey(terrainPaint.BrushTGI.AsString())
				{
					GroupId = this.buildItem.GroupID
				});
				this.texture_1 = Texture.FromMemory(device_0, dbpfentry.GetData());
			}
			foreach (Interface9 @interface in base.Objects.Values)
			{
				Class121 @class = (Class121)@interface;
				@class.method_14(device_0);
			}
			this.vmethod_3(this.CurrentPreset);
		}

		// Token: 0x06000CAA RID: 3242 RVA: 0x0009E778 File Offset: 0x0009C978
		public override void imethod_8(bool bool_5)
		{
			if (bool_5)
			{
				base.imethod_8(bool_5);
			}
			if (this.interface3_0 != null)
			{
				this.interface3_0.imethod_2(bool_5);
			}
			if (this.texture_0 != null)
			{
				this.texture_0.Dispose();
			}
			if (this.texture_1 != null)
			{
				this.texture_1.Dispose();
			}
			if (this._diffuseTexture != null)
			{
				this._diffuseTexture.Dispose();
			}
			if (this._specularTexture != null)
			{
				this._specularTexture.Dispose();
			}
			if (this._roofIndexBuffer != null && bool_5)
			{
				this._roofIndexBuffer.Dispose();
			}
			if (this._roofVertexBuffer != null && bool_5)
			{
				this._roofVertexBuffer.Dispose();
			}
		}

		// Token: 0x06000CAB RID: 3243 RVA: 0x00007017 File Offset: 0x00005217
		private void method_5()
		{
			base.imethod_8(true);
		}

		// Token: 0x06000CAC RID: 3244 RVA: 0x0009E820 File Offset: 0x0009CA20
		public override void imethod_7(Device device_0)
		{
			this.method_5();
			if (this.buildItem is TerrainPaint)
			{
				TerrainPaint terrainPaint = this.buildItem as TerrainPaint;
				DBPFEntry dbpfentry = Class76.smethod_26(new ResKey(terrainPaint.BrushTGI.AsString())
				{
					GroupId = this.buildItem.GroupID
				});
				this.texture_1 = Texture.FromMemory(device_0, dbpfentry.GetData());
			}
			if (this.buildItem.VPXYIndex != -1)
			{
				VisualProxy visualProxy = Class76.smethod_26(new ResKey(this.buildItem.TGIIndex[this.buildItem.VPXYIndex].AsString())) as VisualProxy;
				if (visualProxy != null)
				{
					this.method_6(device_0, visualProxy);
				}
			}
			if (this.buildItem.DiagonalModelIndex != -1)
			{
				VisualProxy visualProxy2 = Class76.smethod_26(new ResKey(this.buildItem.TGIIndex[this.buildItem.DiagonalModelIndex].AsString())) as VisualProxy;
				if (visualProxy2 != null)
				{
					this.method_6(device_0, visualProxy2);
				}
			}
			if (this.buildItem.PostModel != -1)
			{
				VisualProxy visualProxy3 = Class76.smethod_26(new ResKey(this.buildItem.TGIIndex[this.buildItem.PostModel].AsString())) as VisualProxy;
				if (visualProxy3 != null)
				{
					this.method_6(device_0, visualProxy3);
				}
			}
		}

		// Token: 0x06000CAD RID: 3245 RVA: 0x0009E96C File Offset: 0x0009CB6C
		private void method_6(Device device_0, VisualProxy visualProxy_0)
		{
			foreach (object obj in visualProxy_0.Entries)
			{
				if (obj is VPXY)
				{
					VPXY vpxy = obj as VPXY;
					foreach (TGIIndex tgiindex in vpxy.TGIIndex)
					{
						if (tgiindex.IsType(DBPFType.MODL))
						{
							MODLModel modlmodel = Class76.smethod_26(new ResKey(tgiindex.AsString())) as MODLModel;
							foreach (RCOLItem rcolitem in modlmodel.Entries)
							{
								if (rcolitem is MODL)
								{
									MODL modl = rcolitem as MODL;
									foreach (MODL.MODLEntry modlentry in modl.Entries)
									{
										if (modlentry.IndexType == 12288)
										{
											RCOLFileEntry rcolfileEntry = modlmodel.ExternalResources[modlentry.Index + ((modlmodel.dataType == 2) ? -1 : 0)];
											MLODModel mlodmodel = Class76.smethod_26(rcolfileEntry.ResKey) as MLODModel;
											using (List<RCOLItem>.Enumerator enumerator5 = mlodmodel.Entries.GetEnumerator())
											{
												while (enumerator5.MoveNext())
												{
													RCOLItem rcolitem2 = enumerator5.Current;
													if (rcolitem2 is MLOD)
													{
														this.method_7(device_0, rcolitem2 as MLOD, (Lod)modlentry.LOD);
													}
												}
												continue;
											}
										}
										RCOLItem rcolitem3 = modlmodel.Entries[modlentry.Index + ((modlmodel.dataType == 2) ? -1 : 0)];
										this.method_7(device_0, rcolitem3 as MLOD, (Lod)modlentry.LOD);
									}
								}
							}
						}
						if (tgiindex.IsType((DBPFType)3548561239U))
						{
							RCOL rcol = Class76.smethod_26(new ResKey(tgiindex.AsString())) as RCOL;
							foreach (RCOLItem rcolitem4 in rcol.Entries)
							{
								if (rcolitem4 is FTPT)
								{
									FTPT ftpt = rcolitem4 as FTPT;
									foreach (FTPT.FootprintEntry slot in ftpt.FootprintEntries)
									{
										base.Footprints.Add(new Class129(device_0, ftpt, slot));
									}
									foreach (FTPT.FootprintEntry slot2 in ftpt.SlotEntries)
									{
										base.Slots.Add(new Class129(device_0, ftpt, slot2));
									}
								}
							}
						}
					}
				}
			}
		}

		// Token: 0x06000CAE RID: 3246 RVA: 0x00007249 File Offset: 0x00005449
		private void method_7(Device device_0, MLOD mlod_0, Lod lod_2)
		{
			this.method_8(device_0, mlod_0, lod_2, true);
			if (!this.list_10.Contains(lod_2))
			{
				this.list_10.Add(lod_2);
			}
		}

		// Token: 0x06000CAF RID: 3247 RVA: 0x0009ED40 File Offset: 0x0009CF40
		private void method_8(Device device_0, MLOD mlod_0, Lod lod_2, bool bool_5)
		{
			foreach (MLOD.MLODEntry mlodentry in mlod_0.Entries)
			{
				Class121 @class = new Class121(device_0, lod_2, mlod_0, mlodentry);
				@class.Visible = bool_5;
				base.Objects.Add(mlodentry, @class);
				Class140.smethod_0().method_27("usePreset", true);
				if ((this.buildItem is FENCE && this.buildItem.Version == 7U && this.buildItem.Materials.Count == 0) || (this.buildItem is FENCE && this.buildItem.Version >= 10U && this.buildItem.Materials.Count == 0) || (this.buildItem is STAIRS && this.buildItem.Version == 3U && this.buildItem.Materials.Count == 0) || (this.buildItem is RAILING && this.buildItem.Version == 3U && this.buildItem.Materials.Count == 0) || (this.buildItem is ROOF && this.buildItem.Version == 3U && this.buildItem.Materials.Count == 0))
				{
					Class140.smethod_0().method_27("usePreset", false);
				}
			}
		}

		// Token: 0x06000CB0 RID: 3248 RVA: 0x0009BD38 File Offset: 0x00099F38
		public override Size vmethod_1()
		{
			Size result = new Size(1024, 1024);
			foreach (Interface9 @interface in base.Objects.Values)
			{
				Class121 @class = (Class121)@interface;
				List<MATD> list = @class.method_12(0);
				foreach (MATD matd in list)
				{
					if (matd.NameHash != 1262059857U)
					{
						foreach (MATD.MATDEntry matdentry in matd.Entries)
						{
							if (matdentry.Type == (MATD.MATDEntryType)2224872156U)
							{
								result.Height = ((result.Height == -1) ? matdentry.GetIntValue()[0] : Math.Min(matdentry.GetIntValue()[0], result.Height));
							}
							if (matdentry.Type == MATD.MATDEntryType.MaskWidth)
							{
								result.Width = ((result.Width == -1) ? matdentry.GetIntValue()[0] : Math.Min(matdentry.GetIntValue()[0], result.Width));
							}
						}
					}
				}
			}
			return result;
		}

		// Token: 0x1700028C RID: 652
		// (get) Token: 0x06000CB1 RID: 3249 RVA: 0x0009EEC8 File Offset: 0x0009D0C8
		// (set) Token: 0x06000CB2 RID: 3250 RVA: 0x00007271 File Offset: 0x00005471
		public XmlDocument CurrentPreset { get; set; }

		// Token: 0x06000CB3 RID: 3251 RVA: 0x0009EEE0 File Offset: 0x0009D0E0
		public override void vmethod_3(XmlDocument xmlDocument_1)
		{
			if (xmlDocument_1 != null)
			{
				Size size_ = this.vmethod_1();
				if (this._diffuseTexture.GetSurfaceLevel(0).Description.Width != size_.Width || this._diffuseTexture.GetSurfaceLevel(0).Description.Height != size_.Height || this._diffuseTexture == null)
				{
					if (this._diffuseTexture != null)
					{
						this._diffuseTexture.Dispose();
					}
					this._diffuseTexture = Class132.smethod_0().method_4(size_);
					this.interface3_0.imethod_1(size_);
				}
				if (!Class132.smethod_0().method_15(this.interface3_0, xmlDocument_1, "DiffuseMap", (xmlDocument_1.SelectNodes("preset/complate/value[@key='partType']").Item(0) as XmlElement).GetAttribute("value"), this._diffuseTexture))
				{
					MessageBox.Show("Error when rendering complate: " + this.interface3_0.Errors);
				}
				if (this._specularTexture.GetSurfaceLevel(0).Description.Width != size_.Width || this._specularTexture.GetSurfaceLevel(0).Description.Height != size_.Height || this._specularTexture == null)
				{
					if (this._specularTexture != null)
					{
						this._specularTexture.Dispose();
					}
					this._specularTexture = Class132.smethod_0().method_4(size_);
					this.interface3_0.imethod_1(size_);
				}
				if (!Class132.smethod_0().method_15(this.interface3_0, xmlDocument_1, "SpecMap", (xmlDocument_1.SelectNodes("preset/complate/value[@key='partType']").Item(0) as XmlElement).GetAttribute("value"), this._specularTexture))
				{
					MessageBox.Show("Error when rendering complate: " + this.interface3_0.Errors);
				}
				this.CurrentPreset = xmlDocument_1;
			}
		}

		// Token: 0x06000CB4 RID: 3252 RVA: 0x00002A71 File Offset: 0x00000C71
		public override void imethod_10(int int_2)
		{
		}

		// Token: 0x06000CB5 RID: 3253 RVA: 0x0009F0B0 File Offset: 0x0009D2B0
		public override Vector3[] imethod_13()
		{
			return new Vector3[]
			{
				new Vector3(-1f, -1f, -1f),
				new Vector3(1f, 1f, 1f)
			};
		}

		// Token: 0x06000CB6 RID: 3254 RVA: 0x0009F10C File Offset: 0x0009D30C
		public override void vmethod_6(Matrix matrix_2, Matrix matrix_3, Device device_0)
		{
			this.matrix_1 = matrix_2;
			base.method_1(device_0, matrix_2);
			Class140.smethod_0().method_9(RenderState.IndexedVertexBlendEnable, false);
			Class140.smethod_0().method_9(RenderState.VertexBlend, VertexBlend.Disable);
			Class140.smethod_0().method_9(RenderState.ZWriteEnable, true);
			foreach (Interface9 @interface in base.Objects.Values)
			{
				Class121 @class = (Class121)@interface;
				if (@class.LOD == this.lod_1)
				{
					@class.method_10(device_0, matrix_2, matrix_3, false);
				}
			}
		}

		// Token: 0x06000CB7 RID: 3255 RVA: 0x0000727C File Offset: 0x0000547C
		public override void imethod_0(Matrix matrix_2, Matrix matrix_3, Device device_0)
		{
			Class140.smethod_0().method_10();
			this.method_9(matrix_2, matrix_3, device_0, false);
		}

		// Token: 0x06000CB8 RID: 3256 RVA: 0x0009F1C8 File Offset: 0x0009D3C8
		public void method_9(Matrix matrix_2, Matrix matrix_3, Device device_0, bool bool_5)
		{
			this.matrix_1 = matrix_2;
			if (this.texture_1 != null)
			{
				Class140.smethod_0().method_14(this.texture_1);
			}
			base.method_1(device_0, matrix_2);
			Class140.smethod_0().method_9(RenderState.IndexedVertexBlendEnable, false);
			Class140.smethod_0().method_9(RenderState.VertexBlend, VertexBlend.Disable);
			Class140.smethod_0().method_9(RenderState.ZWriteEnable, true);
			foreach (Interface9 @interface in base.Objects.Values)
			{
				Class121 @class = (Class121)@interface;
				if (@class.LOD == this.lod_0)
				{
					Class140.smethod_0().method_14(this._diffuseTexture);
					Class140.smethod_0().method_19(this._specularTexture);
					if (this.buildItem is ROOF)
					{
						if (@class.Visible)
						{
							Class132.smethod_0().method_30(@class.Matd);
							Class140.smethod_0().method_14(@class.DiffuseMap);
							Class140.smethod_0().method_19(@class.SpecularMap);
							Class140.smethod_0().method_20(@class.NormalMap);
							Class140.smethod_0().method_12(new Vector4(-1f, 1f, 1f, 1f), new Vector4(0f, 1f, 0f, 0f));
							Class140.smethod_0().method_27("usePreset", true);
							Class140.smethod_0().method_40("Roof");
							device_0.SetStreamSource(0, this._roofVertexBuffer, 0, Class112.Struct7.SizeInBytes);
							device_0.Indices = this._roofIndexBuffer;
							int num = Class140.smethod_0().method_36();
							for (int i = 0; i < num; i++)
							{
								Class140.smethod_0().method_38(i);
								device_0.DrawIndexedPrimitives(PrimitiveType.TriangleList, 0, 0, this._roofVertexCount, 0, this._roofFaceCount);
								Class140.smethod_0().method_39();
							}
							Class140.smethod_0().method_37();
						}
					}
					else
					{
						Class140.smethod_0().method_27("usePreset", this.buildItem.Materials.Count != 0);
						@class.method_10(device_0, matrix_2, matrix_3, false);
					}
				}
			}
		}

		// Token: 0x06000CB9 RID: 3257 RVA: 0x0009F41C File Offset: 0x0009D61C
		public override Image vmethod_4(Device device_0, XmlDocument xmlDocument_1, Size size_0)
		{
			Vector3 cameraPosition = Class132.smethod_0().CameraPosition;
			Vector3 cameraTarget = Class132.smethod_0().CameraTarget;
			Matrix cameraTranslation = Class132.smethod_0().CameraTranslation;
			Quaternion currentQuaternion = Class132.smethod_0().ArcBall.CurrentQuaternion;
			Surface renderTarget = device_0.GetRenderTarget(0);
			Surface surfaceLevel = this.texture_0.GetSurfaceLevel(0);
			device_0.SetRenderTarget(0, surfaceLevel);
			Surface surface = Surface.CreateDepthStencil(device_0, 1024, 1024, Format.D16, surfaceLevel.Description.MultisampleType, surfaceLevel.Description.MultisampleQuality, true);
			Surface depthStencilSurface = device_0.DepthStencilSurface;
			device_0.DepthStencilSurface = surface;
			device_0.BeginScene();
			Class140.smethod_0().method_9(RenderState.ZEnable, true);
			Class140.smethod_0().method_9(RenderState.AlphaBlendEnable, false);
			Class140.smethod_0().method_9(RenderState.AlphaTestEnable, false);
			Class140.smethod_0().method_9(RenderState.SeparateAlphaBlendEnable, false);
			Class140.smethod_0().method_9(RenderState.SourceBlend, Blend.SourceAlpha);
			Class140.smethod_0().method_9(RenderState.DestinationBlend, Blend.InverseSourceAlpha);
			device_0.Clear(ClearFlags.ZBuffer | ClearFlags.Target, Color.White, 1f, 0);
			Class132.smethod_0().method_26();
			Class132.smethod_0().method_27();
			Class140.smethod_0().method_9(RenderState.FillMode, FillMode.Solid);
			Class140.smethod_0().method_9(RenderState.CullMode, Cull.None);
			device_0.SetTransform(TransformState.World, Matrix.Identity * Matrix.RotationY(-0.2f));
			Class140.smethod_0().method_9(RenderState.Lighting, true);
			this.method_9(this.matrix_1, Class132.smethod_0().ViewMatrix, device_0, true);
			device_0.EndScene();
			device_0.DepthStencilSurface = depthStencilSurface;
			device_0.SetRenderTarget(0, renderTarget);
			surface.Dispose();
			DataStream dataStream = BaseTexture.ToStream(this.texture_0, ImageFileFormat.Bmp);
			Image image = Image.FromStream(dataStream);
			Image thumbnailImage = image.GetThumbnailImage(size_0.Width, size_0.Height, new Image.GetThumbnailImageAbort(base.method_2), IntPtr.Zero);
			image.Dispose();
			dataStream.Dispose();
			Class132.smethod_0().CameraPosition = cameraPosition;
			Class132.smethod_0().CameraTarget = cameraTarget;
			Class132.smethod_0().CameraTranslation = cameraTranslation;
			Class132.smethod_0().ArcBall.CurrentQuaternion = currentQuaternion;
			return thumbnailImage;
		}

		// Token: 0x06000CBA RID: 3258 RVA: 0x00002A71 File Offset: 0x00000C71
		public override void imethod_1(bool bool_5)
		{
		}

		// Token: 0x06000CBB RID: 3259 RVA: 0x00024BE0 File Offset: 0x00022DE0
		public override bool imethod_2()
		{
			return false;
		}

		// Token: 0x06000CBC RID: 3260 RVA: 0x0009F678 File Offset: 0x0009D878
		public override void imethod_3(bool bool_5)
		{
			foreach (Interface9 @interface in base.Objects.Values)
			{
				Class121 @class = (Class121)@interface;
				@class.Visible = bool_5;
			}
		}

		// Token: 0x06000CBD RID: 3261 RVA: 0x00037B84 File Offset: 0x00035D84
		public override bool imethod_4()
		{
			return true;
		}

		// Token: 0x06000CBE RID: 3262 RVA: 0x00007294 File Offset: 0x00005494
		public void method_10(Lod lod_2)
		{
			this.lod_0 = lod_2;
			this.lod_1 = ((lod_2 == Lod.High) ? Lod.ShadowHigh : Lod.ShadowLow);
		}

		// Token: 0x0400099C RID: 2460
		private List<Lod> list_10;

		// Token: 0x0400099D RID: 2461
		private BuildItem buildItem;

		// Token: 0x0400099E RID: 2462
		private Lod lod_0;

		// Token: 0x0400099F RID: 2463
		private Lod lod_1;

		// Token: 0x040009A0 RID: 2464
		private Interface3 interface3_0;

		// Token: 0x040009A1 RID: 2465
		private Texture texture_0;

		// Token: 0x040009A2 RID: 2466
		private Texture texture_1;

		// Token: 0x040009A3 RID: 2467
		private Matrix[] matrix_0;

		// Token: 0x040009A4 RID: 2468
		private Matrix matrix_1;

		// Token: 0x040009A5 RID: 2469
		[CompilerGenerated]
		private Texture texture_2;

		// Token: 0x040009A6 RID: 2470
		[CompilerGenerated]
		private Texture texture_3;

		// Token: 0x040009A7 RID: 2471
		[CompilerGenerated]
		private Texture texture_4;

		// Token: 0x040009A8 RID: 2472
		[CompilerGenerated]
		private VertexBuffer vertexBuffer_0;

		// Token: 0x040009A9 RID: 2473
		[CompilerGenerated]
		private IndexBuffer indexBuffer_0;

		// Token: 0x040009AA RID: 2474
		[CompilerGenerated]
		private int int_0;

		// Token: 0x040009AB RID: 2475
		[CompilerGenerated]
		private int int_1;

		// Token: 0x040009AC RID: 2476
		[CompilerGenerated]
		private XmlDocument xmlDocument_0;
	}
}
