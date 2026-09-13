using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Xml;
using ns10;
using ns16;
using ns6;
using Package;
using Package.Geometry;
using Package.Sims3Files;
using Package.Sims3Files.InternalRCOL;
using Sims3WorkshopSDK;
using Sims3WorkshopSDK.Classes;
using Sims3WorkshopSDK.Interfaces;
using SlimDX;
using SlimDX.Direct3D9;

namespace ns8
{
	// Token: 0x02000109 RID: 265
	internal sealed class Class115
	{
		// Token: 0x17000212 RID: 530
		// (get) Token: 0x06000B4B RID: 2891 RVA: 0x0008F910 File Offset: 0x0008DB10
		// (set) Token: 0x06000B4C RID: 2892 RVA: 0x00006B4F File Offset: 0x00004D4F
		public SlimDX.Vector3 Position
		{
			get
			{
				return this.vector3_0;
			}
			set
			{
				this.vector3_0 = value;
				this.method_4();
			}
		}

		// Token: 0x17000213 RID: 531
		// (get) Token: 0x06000B4D RID: 2893 RVA: 0x0008F928 File Offset: 0x0008DB28
		// (set) Token: 0x06000B4E RID: 2894 RVA: 0x00006B60 File Offset: 0x00004D60
		public float RotationAngle
		{
			get
			{
				return this.facing;
			}
			set
			{
				this.facing = value;
				this.method_4();
			}
		}

		// Token: 0x17000214 RID: 532
		// (get) Token: 0x06000B4F RID: 2895 RVA: 0x0008F940 File Offset: 0x0008DB40
		// (set) Token: 0x06000B50 RID: 2896 RVA: 0x00006B71 File Offset: 0x00004D71
		public bool IsHighlighted { get; set; }

		// Token: 0x06000B51 RID: 2897 RVA: 0x0008F958 File Offset: 0x0008DB58
		public Class115(XmlElement node, float x, float y, float z, float facing, string resourceKey, ref List<Class131> walls, int isDiagonalShifted, int presetId, int customPresetIndex, int slotId, string presetStr)
		{
			this.list_2 = new List<Class115>();
			this.isDiagonalShifted = isDiagonalShifted;
			this.customPresetIndex = customPresetIndex;
			this.slotId = slotId;
			this.presetId = presetId;
			this.boundingBox_0.Maximum = new SlimDX.Vector3(float.MinValue, float.MinValue, float.MinValue);
			this.boundingBox_0.Minimum = new SlimDX.Vector3(float.MaxValue, float.MaxValue, float.MaxValue);
			this.list_1 = walls;
			this.facing = facing;
			this.presetStr = presetStr;
			this.list_0 = new List<Class115.Class116>();
			string[] array = resourceKey.Split(new char[]
			{
				','
			});
			int typeId = int.Parse(array[0]);
			int groupId = int.Parse(array[1]);
			int secondInstanceId = int.Parse(array[2]);
			int instanceId = int.Parse(array[3]);
			ResKey resKey_ = new ResKey((DBPFType)typeId, groupId, instanceId, secondInstanceId);
			DBPFEntry dbpfentry = Class76.smethod_26(resKey_);
			if (dbpfentry is OBJD)
			{
				this.objd_0 = (dbpfentry as OBJD);
				if (customPresetIndex == -1)
				{
					foreach (OBJD.Material material in this.objd_0.Materials)
					{
						if ((ulong)material.MaterialIndex == (ulong)((long)presetId))
						{
							TGIIndex tgiindex = material.TGIIndex[0];
							foreach (OBJD.Material.MaterialBlock materialBlock in material.Blocks)
							{
								presetStr = string.Concat(new string[]
								{
									"<preset><complate name=\"",
									materialBlock.Ref1Name,
									"\" reskey=\"",
									tgiindex.Reskey,
									"\">"
								});
								foreach (OBJD.Material.ComplateVariable complateVariable in materialBlock.Variables)
								{
									string text = complateVariable.GetValue();
									if (complateVariable.ValueTypeCode == 3)
									{
										text = material.TGIIndex[Convert.ToInt32(text)].Reskey;
									}
									object obj = presetStr;
									presetStr = string.Concat(new object[]
									{
										obj,
										"<value key=\"",
										complateVariable.VariableName,
										"\" value=\"",
										text,
										"\" type=\"",
										complateVariable.ValueTypeCode,
										"\" />"
									});
								}
								int num = 0;
								foreach (OBJD.Material.MaterialBlock materialBlock2 in materialBlock.Patterns)
								{
									string text2 = presetStr;
									presetStr = string.Concat(new string[]
									{
										text2,
										"<pattern name=\"",
										materialBlock2.Ref1Name,
										"\" reskey=\"",
										material.TGIIndex[(int)materialBlock2.XMLIndex].Reskey,
										"\" variable=\"",
										materialBlock2.Ref2Name,
										"\">"
									});
									foreach (OBJD.Material.ComplateVariable complateVariable2 in materialBlock2.Variables)
									{
										string text3 = complateVariable2.GetValue();
										if (complateVariable2.ValueTypeCode == 3)
										{
											text3 = material.TGIIndex[Convert.ToInt32(text3)].Reskey;
										}
										object obj2 = presetStr;
										presetStr = string.Concat(new object[]
										{
											obj2,
											"<value key=\"",
											complateVariable2.VariableName,
											"\" value=\"",
											text3,
											"\" type=\"",
											complateVariable2.ValueTypeCode,
											"\" />"
										});
									}
									presetStr += "</pattern>";
									num++;
								}
								presetStr += "</complate></preset>";
							}
						}
					}
				}
				this.method_0(this.objd_0);
				XmlNodeList xmlNodeList = node.SelectNodes("SlottedObject");
				foreach (object obj3 in xmlNodeList)
				{
					XmlElement xmlElement = (XmlElement)obj3;
					CultureInfo provider = new CultureInfo("en-US");
					try
					{
						int index = int.Parse(xmlElement.GetAttribute("SlotID"));
						float num2 = float.Parse(xmlElement.GetAttribute("Facing"), provider);
						int num3 = int.Parse(xmlElement.HasAttribute("PresetId") ? xmlElement.GetAttribute("PresetId") : "-1");
						int num4 = int.Parse(xmlElement.HasAttribute("CustomPresetIndex") ? xmlElement.GetAttribute("CustomPresetIndex") : "-1");
						string attribute = xmlElement.GetAttribute("ResourceKey");
						string text4 = "";
						if (num4 > -1)
						{
							XmlNodeList xmlNodeList2 = node.OwnerDocument.SelectNodes("/Blueprint/Presets/Preset");
							XmlElement xmlElement2 = xmlNodeList2.Item(num4) as XmlElement;
							text4 = xmlElement2.GetAttribute("PresetXML");
						}
						Class115 @class = new Class115(xmlElement, 0f, 0f, 0f, num2, attribute, ref walls, 0, num3, num4, index, text4);
						@class.entry_0 = this.rslt_0.ContainerEntries[index];
						@class.class115_0 = this;
						this.list_2.Add(@class);
					}
					catch (Exception)
					{
					}
				}
			}
			float num5 = (float)Math.Ceiling((double)Vector2.Distance(new Vector2(this.boundingBox_0.Minimum.X, 0f), new Vector2(this.boundingBox_0.Maximum.X, 0f)));
			float num6 = (float)Math.Ceiling((double)Vector2.Distance(new Vector2(this.boundingBox_0.Minimum.Z, 0f), new Vector2(this.boundingBox_0.Maximum.Z, 0f)));
			float x2 = -(num5 / 2f);
			float x3 = num5 / 2f;
			float z2 = -(num6 / 2f);
			float z3 = num6 / 2f;
			Class112.Struct7[] array2 = new Class112.Struct7[]
			{
				new Class112.Struct7(new SlimDX.Vector3(x2, 0f, z3), new SlimDX.Vector3(0f, 0f, 1f), new Vector2(0f, 0.5f)),
				new Class112.Struct7(new SlimDX.Vector3(x2, 0f, z2), new SlimDX.Vector3(0f, 0f, 1f), new Vector2(0f, 0.5f)),
				new Class112.Struct7(new SlimDX.Vector3(x3, 0f, z2), new SlimDX.Vector3(0f, 0f, 1f), new Vector2(0f, 0.5f)),
				new Class112.Struct7(new SlimDX.Vector3(x2, 0f, z3), new SlimDX.Vector3(0f, 0f, 1f), new Vector2(0f, 0.5f)),
				new Class112.Struct7(new SlimDX.Vector3(x3, 0f, z2), new SlimDX.Vector3(0f, 0f, 1f), new Vector2(0f, 0.5f)),
				new Class112.Struct7(new SlimDX.Vector3(x3, 0f, z3), new SlimDX.Vector3(0f, 0f, 1f), new Vector2(0f, 0.5f))
			};
			this.vertexBuffer_0 = new VertexBuffer(Class140.smethod_0().Device, 6 * Class112.Struct7.SizeInBytes, Usage.None, Class112.Struct7.vertexFormat_0, Pool.Managed);
			DataStream dataStream = this.vertexBuffer_0.Lock(0, 0, LockFlags.None);
			dataStream.WriteRange<Class112.Struct7>(array2, 0, array2.Length);
			this.vertexBuffer_0.Unlock();
			this.bool_1 = true;
			this.Position = new SlimDX.Vector3(x, y, z);
			if (!string.IsNullOrEmpty(this.presetStr))
			{
				int hashCode = this.presetStr.GetHashCode();
				if (Class115.hashtable_0.ContainsKey(hashCode))
				{
					this.texture_0 = (Class115.hashtable_0[hashCode] as Texture);
					using (List<Class115.Class116>.Enumerator enumerator7 = this.list_0.GetEnumerator())
					{
						while (enumerator7.MoveNext())
						{
							Class115.Class116 class2 = enumerator7.Current;
							class2.method_3();
							if (class2.texture_0 != null)
							{
								class2.texture_0.Dispose();
							}
							class2.texture_0 = this.texture_0;
						}
						return;
					}
				}
				MATD matd = null;
				using (List<Class115.Class116>.Enumerator enumerator7 = this.list_0.GetEnumerator())
				{
					if (enumerator7.MoveNext())
					{
						Class115.Class116 class3 = enumerator7.Current;
						matd = class3.method_4(782826392)[0];
					}
				}
				int width = 1024;
				int height = 1024;
				foreach (MATD.MATDEntry matdentry in matd.Entries)
				{
					if (matdentry.Type == MATD.MATDEntryType.MaskWidth)
					{
						width = (int)matdentry.Values[0];
					}
					if (matdentry.Type == (MATD.MATDEntryType)2224872156U)
					{
						height = (int)matdentry.Values[0];
					}
				}
				Texture texture = Class132.smethod_0().method_4(new Size(width, height));
				Interface3 @interface = Class132.smethod_0().method_8(new Size(width, height));
				XmlDocument xmlDocument = new XmlDocument();
				xmlDocument.LoadXml(this.presetStr);
				Class132.smethod_0().method_15(@interface, xmlDocument, "DiffuseMap", "Face", texture);
				@interface.imethod_2(true);
				DataStream dataStream2 = BaseTexture.ToStream(texture, ImageFileFormat.Png);
				this.texture_0 = Texture.FromStream(Class140.smethod_0().Device, dataStream2);
				dataStream2.Dispose();
				texture.Dispose();
				foreach (Class115.Class116 class4 in this.list_0)
				{
					class4.method_3();
					if (class4.texture_0 != null)
					{
						class4.texture_0.Dispose();
					}
					class4.texture_0 = this.texture_0;
				}
				Class115.hashtable_0.Add(hashCode, this.texture_0);
			}
			else
			{
				foreach (Class115.Class116 class5 in this.list_0)
				{
					class5.method_3();
				}
			}
		}

		// Token: 0x06000B52 RID: 2898 RVA: 0x0009059C File Offset: 0x0008E79C
		private void method_0(OBJD objd_1)
		{
			OBJK objk = Class76.smethod_26(new ResKey(objd_1.OBJK.AsString())) as OBJK;
			OBJK.KeyEntry keyEntry = objk.GetKeyEntry("modelKey");
			TGIIndex tgiindex = objk.TGIIndex[(int)keyEntry.uintvalue];
			VisualProxy visualProxy = Class76.smethod_26(new ResKey(tgiindex.AsString())) as VisualProxy;
			foreach (RCOLItem rcolitem in visualProxy.Entries)
			{
				VPXY vpxy = (VPXY)rcolitem;
				foreach (VPXY.VPXEntryEntry vpxentryEntry in vpxy.entries)
				{
					if (vpxentryEntry.type == 1)
					{
						foreach (int index in vpxentryEntry.index)
						{
							TGIIndex tgiindex2 = vpxy.TGIIndex[index];
							if (tgiindex2.IsType(DBPFType.MODL))
							{
								ResKey resKey_ = new ResKey(tgiindex2.Reskey);
								DBPFEntry dbpfentry = Class76.smethod_26(resKey_);
								this.method_6(Class140.smethod_0().Device, (MODLModel)dbpfentry, 0);
							}
							if (tgiindex2.IsType((DBPFType)3540272417U))
							{
								ResKey resKey_2 = new ResKey(tgiindex2.Reskey);
								DBPFEntry dbpfentry2 = Class76.smethod_26(resKey_2);
								if (dbpfentry2 == null)
								{
									continue;
								}
								this.rslt_0 = ((dbpfentry2 as RSLTResource).Entries[0] as RSLT);
							}
							if (tgiindex2.IsType((DBPFType)3548561239U))
							{
								ResKey resKey_3 = new ResKey(tgiindex2.Reskey);
								DBPFEntry dbpfentry3 = Class76.smethod_26(resKey_3);
								if (dbpfentry3 != null)
								{
									FTPT ftpt = (dbpfentry3 as FTPTResource).Entries[0] as FTPT;
									if (ftpt.FootprintEntries.Count > 0)
									{
										this.ftpt_0 = ftpt;
									}
								}
							}
						}
					}
				}
			}
			this.method_4();
		}

		// Token: 0x06000B53 RID: 2899 RVA: 0x000907F4 File Offset: 0x0008E9F4
		public void method_1(Device device_0)
		{
			foreach (Class115.Class116 @class in this.list_0)
			{
				@class.method_0(device_0);
			}
			foreach (Class115 class2 in this.list_2)
			{
				class2.method_1(device_0);
			}
		}

		// Token: 0x06000B54 RID: 2900 RVA: 0x00090890 File Offset: 0x0008EA90
		public void method_2(Device device_0)
		{
			foreach (Class115.Class116 @class in this.list_0)
			{
				@class.method_1(device_0);
			}
			foreach (Class115 class2 in this.list_2)
			{
				class2.method_2(device_0);
			}
		}

		// Token: 0x06000B55 RID: 2901 RVA: 0x0009092C File Offset: 0x0008EB2C
		public void method_3(bool bool_3)
		{
			if (bool_3)
			{
				this.vertexBuffer_0.Dispose();
			}
			foreach (Class115 @class in this.list_2)
			{
				@class.method_3(bool_3);
			}
			foreach (Class115.Class116 class2 in this.list_0)
			{
				class2.method_2(bool_3);
			}
		}

		// Token: 0x06000B56 RID: 2902 RVA: 0x00006B7C File Offset: 0x00004D7C
		private void method_4()
		{
			this.matrix_0 = Matrix.Translation(this.Position);
			this.matrix_1 = Matrix.RotationY(this.facing);
			this.matrix_2 = this.method_8(this.objd_0);
			this.method_5();
		}

		// Token: 0x06000B57 RID: 2903 RVA: 0x000909D4 File Offset: 0x0008EBD4
		private void method_5()
		{
			foreach (Class115 @class in this.list_2)
			{
				RSLT.Entry entry = @class.entry_0;
				Matrix identity = Matrix.Identity;
				identity.M11 = entry.Transformation[0];
				identity.M12 = entry.Transformation[4];
				identity.M13 = entry.Transformation[8];
				identity.M21 = entry.Transformation[1];
				identity.M22 = entry.Transformation[5];
				identity.M23 = entry.Transformation[9];
				identity.M31 = entry.Transformation[2];
				identity.M32 = entry.Transformation[6];
				identity.M33 = entry.Transformation[10];
				identity.M41 = entry.Transformation[3];
				identity.M42 = entry.Transformation[7];
				identity.M43 = entry.Transformation[11];
				SlimDX.Vector3 vector = SlimDX.Vector3.TransformCoordinate(SlimDX.Vector3.Zero, identity);
				@class.Position = new SlimDX.Vector3(vector.X, vector.Y, vector.Z);
			}
		}

		// Token: 0x06000B58 RID: 2904 RVA: 0x00090B28 File Offset: 0x0008ED28
		private void method_6(Device device_0, MODLModel modlmodel_0, int int_0)
		{
			foreach (RCOLItem rcolitem in modlmodel_0.Entries)
			{
				if (rcolitem.GetType().Equals(typeof(MODL)))
				{
					MODL modl = rcolitem as MODL;
					foreach (MODL.MODLEntry modlentry in modl.Entries)
					{
						if (modlentry.LOD == 0U)
						{
							if (modlentry.IndexType == 12288)
							{
								RCOLFileEntry rcolfileEntry = modlmodel_0.ExternalResources[modlentry.Index - 1];
								RCOL rcol = Class76.smethod_26(rcolfileEntry.ResKey) as RCOL;
								this.method_7(modlentry, rcol, rcol.Entries[0] as MLOD, (Lod)modlentry.LOD, device_0);
							}
							else
							{
								MLOD mlod_ = modlmodel_0.Entries[modlentry.Index - 1] as MLOD;
								this.method_7(modlentry, modlmodel_0, mlod_, (Lod)modlentry.LOD, device_0);
							}
						}
					}
				}
			}
		}

		// Token: 0x06000B59 RID: 2905 RVA: 0x00090C88 File Offset: 0x0008EE88
		private void method_7(MODL.MODLEntry modlentry_0, RCOL rcol_0, MLOD mlod_0, Lod lod_0, Device device_0)
		{
			foreach (MLOD.MLODEntry mlodentry in mlod_0.Entries)
			{
				this.boundingBox_0.Minimum.X = Math.Min(this.boundingBox_0.Minimum.X, mlodentry.BoundingBox[0]);
				this.boundingBox_0.Minimum.Y = Math.Min(this.boundingBox_0.Minimum.Y, mlodentry.BoundingBox[1]);
				this.boundingBox_0.Minimum.Z = Math.Min(this.boundingBox_0.Minimum.Z, mlodentry.BoundingBox[2]);
				this.boundingBox_0.Maximum.X = Math.Max(this.boundingBox_0.Maximum.X, mlodentry.BoundingBox[3]);
				this.boundingBox_0.Maximum.Y = Math.Max(this.boundingBox_0.Maximum.Y, mlodentry.BoundingBox[4]);
				this.boundingBox_0.Maximum.Z = Math.Max(this.boundingBox_0.Maximum.Z, mlodentry.BoundingBox[5]);
				Class115.Class116 item = new Class115.Class116(mlod_0, mlodentry, device_0);
				this.list_0.Add(item);
			}
		}

		// Token: 0x06000B5A RID: 2906 RVA: 0x00090E10 File Offset: 0x0008F010
		private Matrix method_8(OBJD objd_1)
		{
			Matrix result = Matrix.Identity;
			SlimDX.Vector3 amount = new SlimDX.Vector3((this.boundingBox_0.Minimum.X + this.boundingBox_0.Maximum.X) / 2f, 0f, (this.boundingBox_0.Minimum.Z + this.boundingBox_0.Maximum.Z) / 2f);
			this.matrix_3 = Matrix.Translation(amount);
			this.matrix_3.Invert();
			if ((objd_1.WallPlacement & OBJD.WallPlacementFlags.WFMinZ) != OBJD.WallPlacementFlags.WFAnywhere || (objd_1.WallPlacement & OBJD.WallPlacementFlags.WFMaxZ) != OBJD.WallPlacementFlags.WFAnywhere)
			{
				SlimDX.Vector3 value = new SlimDX.Vector3(this.Position.X, 0f, this.Position.Z);
				SlimDX.Vector3 left = SlimDX.Vector3.Zero;
				float num = float.MaxValue;
				foreach (Class131 @class in this.list_1)
				{
					SlimDX.Vector3 vector = (new SlimDX.Vector3(@class.originX, 0f, @class.originZ) + new SlimDX.Vector3(@class.destinationX, 0f, @class.destinationZ)) / 2f;
					float num2 = SlimDX.Vector3.Distance(vector, value);
					if (num2 < num)
					{
						left = vector;
						num = num2;
					}
				}
				SlimDX.Vector3 coordinate = new SlimDX.Vector3((this.boundingBox_0.Minimum.X + this.boundingBox_0.Maximum.X) / 2f, 0f, this.boundingBox_0.Minimum.Z);
				SlimDX.Vector3 coordinate2 = new SlimDX.Vector3((this.boundingBox_0.Minimum.X + this.boundingBox_0.Maximum.X) / 2f, 0f, (this.boundingBox_0.Minimum.Z + this.boundingBox_0.Maximum.Z) / 2f);
				SlimDX.Vector3 coordinate3 = new SlimDX.Vector3((this.boundingBox_0.Minimum.X + this.boundingBox_0.Maximum.X) / 2f, 0f, this.boundingBox_0.Maximum.Z);
				SlimDX.Vector3 right = SlimDX.Vector3.TransformCoordinate(coordinate, this.matrix_3 * this.matrix_1 * this.matrix_0);
				SlimDX.Vector3 right2 = SlimDX.Vector3.TransformCoordinate(coordinate3, this.matrix_3 * this.matrix_1 * this.matrix_0);
				SlimDX.Vector3.TransformCoordinate(coordinate2, this.matrix_3 * this.matrix_1 * this.matrix_0);
				SlimDX.Vector3 vector2 = left - right;
				if ((objd_1.WallPlacement & OBJD.WallPlacementFlags.WFMaxZ) != OBJD.WallPlacementFlags.WFAnywhere)
				{
					vector2 = left - right2;
				}
				if ((objd_1.WallPlacement & OBJD.WallPlacementFlags.WFOnWall) != OBJD.WallPlacementFlags.WFAnywhere)
				{
					SlimDX.Vector3 right3 = SlimDX.Vector3.TransformCoordinate(new SlimDX.Vector3(0f, 0f, 0.085f), this.matrix_1);
					SlimDX.Vector3 left2 = left + right3;
					if ((objd_1.WallPlacement & OBJD.WallPlacementFlags.WFMaxZ) != OBJD.WallPlacementFlags.WFAnywhere)
					{
						vector2 = left2 - right2;
					}
					else
					{
						vector2 = left2 - right;
					}
				}
				result = Matrix.Translation(new SlimDX.Vector3(vector2.X, 0f, vector2.Z));
			}
			return result;
		}

		// Token: 0x06000B5B RID: 2907 RVA: 0x00091160 File Offset: 0x0008F360
		public void method_9()
		{
			if ((this.objd_0.ObjectType & OBJD.ObjectTypeFlags.IsDoor) == (OBJD.ObjectTypeFlags)0U && (this.objd_0.ObjectType & OBJD.ObjectTypeFlags.IsWindow) == (OBJD.ObjectTypeFlags)0U)
			{
				this.matrix_4 = this.matrix_3 * this.matrix_1 * Matrix.RotationY(this.float_0) * this.matrix_0 * this.matrix_2;
			}
			else
			{
				this.matrix_4 = this.matrix_1 * Matrix.RotationY(this.float_0) * this.matrix_0;
			}
			Matrix right = this.matrix_1;
			right.Invert();
			foreach (Class115 @class in this.list_2)
			{
				@class.matrix_4 = @class.matrix_1 * right * Matrix.RotationY(@class.float_0) * @class.matrix_0 * @class.matrix_2 * this.matrix_4;
			}
		}

		// Token: 0x06000B5C RID: 2908 RVA: 0x00091288 File Offset: 0x0008F488
		public void method_10(Device device_0, Matrix matrix_5)
		{
			Class140.smethod_0().method_30("IsHighlighted", this.IsHighlighted ? 1 : 0);
			if (this.bool_0 && this.bool_1)
			{
				device_0.SetStreamSource(0, this.vertexBuffer_0, 0, Class112.Struct7.SizeInBytes);
				Class140.smethod_0().method_9(RenderState.Lighting, true);
				Class140.smethod_0().method_9(RenderState.AlphaTestEnable, true);
				Class140.smethod_0().method_9(RenderState.AlphaFunc, Compare.Equal);
				Class140.smethod_0().method_9(RenderState.AlphaRef, 255);
				Class140.smethod_0().method_9(RenderState.CullMode, Cull.None);
				Material material_ = default(Material);
				material_.Diffuse = Color.FromArgb(255, Color.White);
				material_.Specular = Color.FromArgb(127, 127, 127, 127);
				material_.Power = 0f;
				Matrix matrix = this.matrix_1 * Matrix.RotationY(this.float_0) * this.matrix_0 * Matrix.Translation(0f, 0.03f, 0f) * this.matrix_2 * matrix_5;
				Class140.smethod_0().method_32(matrix, Class132.smethod_0().ViewMatrix);
				Class140.smethod_0().method_40("ObjectPlaceholder");
				Class140.smethod_0().method_9(RenderState.ZWriteEnable, true);
				Class140.smethod_0().method_34(false);
				Class132.smethod_0().method_29(material_);
				int num = Class140.smethod_0().method_36();
				for (int i = 0; i < num; i++)
				{
					Class140.smethod_0().method_38(i);
					device_0.DrawPrimitives(PrimitiveType.TriangleList, 0, 2);
					Class140.smethod_0().method_39();
				}
				Class140.smethod_0().method_37();
			}
			foreach (Class115.Class116 @class in this.list_0)
			{
				foreach (Class115 class2 in this.list_2)
				{
					class2.method_10(device_0, matrix_5);
				}
				@class.method_5(device_0, this.matrix_4 * matrix_5);
			}
		}

		// Token: 0x040008D0 RID: 2256
		public static Hashtable hashtable_0 = new Hashtable();

		// Token: 0x040008D1 RID: 2257
		private List<Class115.Class116> list_0;

		// Token: 0x040008D2 RID: 2258
		private List<Class131> list_1;

		// Token: 0x040008D3 RID: 2259
		private RSLT rslt_0;

		// Token: 0x040008D4 RID: 2260
		private FTPT ftpt_0;

		// Token: 0x040008D5 RID: 2261
		private SlimDX.Vector3 vector3_0;

		// Token: 0x040008D6 RID: 2262
		public float float_0;

		// Token: 0x040008D7 RID: 2263
		private float facing;

		// Token: 0x040008D8 RID: 2264
		public RSLT.Entry entry_0;

		// Token: 0x040008D9 RID: 2265
		public bool bool_0;

		// Token: 0x040008DA RID: 2266
		private bool bool_1;

		// Token: 0x040008DB RID: 2267
		public List<Class115> list_2;

		// Token: 0x040008DC RID: 2268
		public Matrix matrix_0;

		// Token: 0x040008DD RID: 2269
		public Matrix matrix_1;

		// Token: 0x040008DE RID: 2270
		public Matrix matrix_2;

		// Token: 0x040008DF RID: 2271
		public Matrix matrix_3;

		// Token: 0x040008E0 RID: 2272
		public BoundingBox boundingBox_0;

		// Token: 0x040008E1 RID: 2273
		public OBJD objd_0;

		// Token: 0x040008E2 RID: 2274
		public Class115 class115_0;

		// Token: 0x040008E3 RID: 2275
		public VertexBuffer vertexBuffer_0;

		// Token: 0x040008E4 RID: 2276
		public int isDiagonalShifted;

		// Token: 0x040008E5 RID: 2277
		public int customPresetIndex;

		// Token: 0x040008E6 RID: 2278
		public int slotId;

		// Token: 0x040008E7 RID: 2279
		public int presetId;

		// Token: 0x040008E8 RID: 2280
		private string presetStr;

		// Token: 0x040008E9 RID: 2281
		private Texture texture_0;

		// Token: 0x040008EA RID: 2282
		public Matrix matrix_4;

		// Token: 0x040008EB RID: 2283
		[CompilerGenerated]
		private bool bool_2;

		// Token: 0x0200010A RID: 266
		private sealed class Class116
		{
			// Token: 0x06000B5E RID: 2910 RVA: 0x000914FC File Offset: 0x0008F6FC
			public Class116(MLOD mlod, MLOD.MLODEntry mlodEntry, Device device)
			{
				RCOL parent = mlod.Parent;
				this.mlodEntry = mlodEntry;
				FNV32.GetHash("transformBone");
				VRTF vrtf = parent.Entries[mlodEntry.VRTFIndex + ((parent.dataType == 2) ? 1 : 0)] as VRTF;
				VBUF vbuf = parent.Entries[mlodEntry.VBUFIndex + ((parent.dataType == 2) ? 1 : 0)] as VBUF;
				if (vrtf == null)
				{
					vrtf = VRTF.GetDefaultForLength((mlodEntry.Type == 20483U) ? 8 : 16);
				}
				Class112.Struct7[] array = new Class112.Struct7[mlodEntry.VertexCount];
				float selector = Class115.Class116.smethod_0(parent, mlodEntry);
				for (int i = 0; i < mlodEntry.VertexCount; i++)
				{
					Class112.Struct7 @struct = default(Class112.Struct7);
					Package.Geometry.Vector4 position = vbuf.GetPosition(vrtf, i, mlodEntry.VBUFOffset, 0);
					Package.Geometry.Vector4 uv = vbuf.GetUV(vrtf, i, mlodEntry.VBUFOffset, selector, true, 0);
					Package.Geometry.Vector4 normal = vbuf.GetNormal(vrtf, i, mlodEntry.VBUFOffset, 0);
					@struct.position = new SlimDX.Vector3(position.X, position.Y, position.Z);
					@struct.normal = new SlimDX.Vector3(normal.X, normal.Y, normal.Z);
					@struct.vector2_0 = new Vector2(uv.X, uv.Y);
					array[i] = @struct;
				}
				int num = mlodEntry.FaceCount * 3;
				IBUF ibuf = (IBUF)parent.Entries[mlodEntry.IBUFIndex + ((parent.dataType == 2) ? 1 : 0)];
				num = ibuf.Index.Length;
				short[] array2 = new short[num + 6];
				for (int j = 0; j < num; j++)
				{
					array2[j] = ibuf.Index[j];
				}
				this.indexBuffer_0 = new IndexBuffer(device, array2.Length * 2, Usage.None, Pool.Managed, true);
				DataStream dataStream = this.indexBuffer_0.Lock(0, array2.Length * 2, LockFlags.None);
				dataStream.WriteRange<short>(array2, 0, array2.Length);
				this.indexBuffer_0.Unlock();
				this.vertexBuffer_0 = new VertexBuffer(device, array.Length * Class112.Struct7.SizeInBytes, Usage.None, Class112.Struct7.vertexFormat_0, Pool.Managed);
				DataStream dataStream2 = this.vertexBuffer_0.Lock(0, 0, LockFlags.None);
				dataStream2.WriteRange<Class112.Struct7>(array, 0, array.Length);
				this.vertexBuffer_0.Unlock();
				this.matd_0 = this.method_4(782826392)[0];
			}

			// Token: 0x06000B5F RID: 2911 RVA: 0x00002A71 File Offset: 0x00000C71
			public void method_0(Device device_0)
			{
			}

			// Token: 0x06000B60 RID: 2912 RVA: 0x00002A71 File Offset: 0x00000C71
			public void method_1(Device device_0)
			{
			}

			// Token: 0x06000B61 RID: 2913 RVA: 0x00006BC8 File Offset: 0x00004DC8
			public void method_2(bool bool_0)
			{
				if (bool_0)
				{
					this.vertexBuffer_0.Dispose();
					this.indexBuffer_0.Dispose();
				}
			}

			// Token: 0x06000B62 RID: 2914 RVA: 0x00091770 File Offset: 0x0008F970
			public static float smethod_0(RCOL rcol_0, MLOD.MLODEntry mlodentry_0)
			{
				float result = 3.051851E-05f;
				RCOLItem rcolitem = rcol_0.Entries[mlodentry_0.MATDIndex + ((rcol_0.dataType == 2) ? 1 : 0)];
				if (rcolitem is MATD)
				{
					MATD matd = rcolitem as MATD;
					using (List<MATD.MATDEntry>.Enumerator enumerator = matd.Entries.GetEnumerator())
					{
						while (enumerator.MoveNext())
						{
							MATD.MATDEntry matdentry = enumerator.Current;
							if (matdentry.Type == (MATD.MATDEntryType)2448341759U)
							{
								result = (float)matdentry.Values[0];
							}
						}
						goto IL_1D5;
					}
				}
				if (rcolitem is MTST)
				{
					MTST mtst = rcolitem as MTST;
					foreach (MTST.MTSTEntry mtstentry in mtst.Entries)
					{
						MATD matd2 = null;
						int num = mtstentry.MATDIndex + ((rcol_0.dataType == 2) ? 1 : 0);
						if ((num & 536870912) > 0)
						{
							num = (mtstentry.MATDIndex & 16777215);
							RCOLFileEntry rcolfileEntry = rcol_0.ExternalResources[num - 1];
							RCOL rcol = Class76.smethod_26(rcolfileEntry.ResKey) as RCOL;
							using (List<RCOLItem>.Enumerator enumerator3 = rcol.Entries.GetEnumerator())
							{
								while (enumerator3.MoveNext())
								{
									RCOLItem rcolitem2 = enumerator3.Current;
									if (rcolitem2 is MATD)
									{
										matd2 = (rcolitem2 as MATD);
									}
								}
								goto IL_165;
							}
							goto IL_151;
						}
						goto IL_151;
						IL_165:
						if (matd2 != null)
						{
							foreach (MATD.MATDEntry matdentry2 in matd2.Entries)
							{
								if (matdentry2.Type == (MATD.MATDEntryType)2448341759U)
								{
									result = (float)matdentry2.Values[0];
								}
							}
							continue;
						}
						continue;
						IL_151:
						matd2 = (rcol_0.Entries[num] as MATD);
						goto IL_165;
					}
				}
				IL_1D5:
				return result;
			}

			// Token: 0x06000B63 RID: 2915 RVA: 0x000919C0 File Offset: 0x0008FBC0
			public void method_3()
			{
				RCOL parent = this.mlodEntry.Parent.Parent;
				this.matd_0 = this.method_4(782826392)[0];
				int width = 1024;
				int height = 1024;
				foreach (MATD.MATDEntry matdentry in this.matd_0.Entries)
				{
					if (matdentry.Type == MATD.MATDEntryType.MaskWidth)
					{
						width = (int)matdentry.Values[0];
					}
					if (matdentry.Type == (MATD.MATDEntryType)2224872156U)
					{
						height = (int)matdentry.Values[0];
					}
				}
				foreach (MATD.MATDEntry matdentry2 in this.matd_0.Entries)
				{
					if (matdentry2.Type == MATD.MATDEntryType.DiffuseMap)
					{
						try
						{
							ResKey resKey;
							if (matdentry2.Values.Length == 4)
							{
								int num = matdentry2.GetIntValue()[0] & 16777215;
								resKey = parent.ExternalResources[num - 1].ResKey;
							}
							else
							{
								int[] intValue = matdentry2.GetIntValue();
								resKey = new ResKey((DBPFType)intValue[2], intValue[3], intValue[1], intValue[0]);
							}
							if (Class115.hashtable_0.ContainsKey(resKey))
							{
								this.texture_0 = (Class115.hashtable_0[resKey] as Texture);
							}
							else
							{
								DBPFEntry dbpfentry = Class76.smethod_26(resKey);
								if (dbpfentry is TXTC)
								{
									long ticks = DateTime.Now.Ticks;
									Console.WriteLine("Creating texture from TXTC: " + resKey);
									TXTC txtc = dbpfentry as TXTC;
									Texture texture = Class132.smethod_0().method_4(new Size(width, height));
									Interface3 @interface = Class132.smethod_0().method_8(new Size(width, height));
									XmlDocument xmlDocument_ = txtc.ToPreset();
									Class132.smethod_0().method_15(@interface, xmlDocument_, "DiffuseMap", "", texture);
									@interface.imethod_2(true);
									DataStream dataStream = BaseTexture.ToStream(texture, ImageFileFormat.Png);
									this.texture_0 = Texture.FromStream(Class140.smethod_0().Device, dataStream);
									dataStream.Dispose();
									texture.Dispose();
									long ticks2 = DateTime.Now.Ticks;
									float num2 = (float)(ticks2 - ticks) / 10000000f;
									Console.WriteLine("Took " + num2);
								}
								if (dbpfentry is DDS)
								{
									long ticks3 = DateTime.Now.Ticks;
									Console.WriteLine("Creating texture from resource: " + resKey);
									this.texture_0 = Texture.FromMemory(Class140.smethod_0().Device, dbpfentry.GetData());
									long ticks4 = DateTime.Now.Ticks;
									float num3 = (float)(ticks4 - ticks3) / 10000f;
									Console.WriteLine("Took " + num3);
								}
								Class115.hashtable_0.Add(resKey, this.texture_0);
							}
						}
						catch (Exception)
						{
						}
					}
					if (matdentry2.Type == MATD.MATDEntryType.DropShadowAtlas)
					{
						try
						{
							ResKey resKey2;
							if (matdentry2.Values.Length == 4)
							{
								int num4 = matdentry2.GetIntValue()[0] & 16777215;
								resKey2 = parent.ExternalResources[num4 - 1].ResKey;
							}
							else
							{
								int[] intValue2 = matdentry2.GetIntValue();
								resKey2 = new ResKey((DBPFType)intValue2[2], intValue2[3], intValue2[1], intValue2[0]);
							}
							if (Class115.hashtable_0.ContainsKey(resKey2))
							{
								this.texture_1 = (Class115.hashtable_0[resKey2] as Texture);
							}
							else
							{
								long ticks5 = DateTime.Now.Ticks;
								Console.WriteLine("Creating texture from resource" + resKey2);
								DBPFEntry dbpfentry2 = Class76.smethod_26(resKey2);
								if (dbpfentry2 != null)
								{
									if (this.texture_1 != null)
									{
										this.texture_1.Dispose();
									}
									this.texture_1 = Texture.FromMemory(Class140.smethod_0().Device, dbpfentry2.GetData());
									dbpfentry2.Dispose();
									Class115.hashtable_0.Add(resKey2, this.texture_1);
								}
							}
						}
						catch (Exception)
						{
						}
					}
				}
			}

			// Token: 0x06000B64 RID: 2916 RVA: 0x00091E34 File Offset: 0x00090034
			public List<MATD> method_4(int int_0)
			{
				RCOL parent = this.mlodEntry.Parent.Parent;
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
						if (int_0 == 0 || (long)int_0 == (long)((ulong)mtstentry.Hash))
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

			// Token: 0x06000B65 RID: 2917 RVA: 0x00092010 File Offset: 0x00090210
			public void method_5(Device device_0, Matrix matrix_0)
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
				if (Class140.smethod_0().CurrentRenderMode == Class140.Enum20.const_0)
				{
					MATD.MATDShader shader = this.matd_0.Shader;
					if (this.matd_0.Shader == MATD.MATDShader.GlassForFences || this.matd_0.Shader == MATD.MATDShader.GlassForObjects || this.matd_0.Shader == (MATD.MATDShader)2224877601U || this.matd_0.Shader == (MATD.MATDShader)2178752589U || this.matd_0.Shader == MATD.MATDShader.GlassForRabbitHoles)
					{
						return;
					}
				}
				else if (this.matd_0.Shader != MATD.MATDShader.GlassForFences && this.matd_0.Shader != MATD.MATDShader.GlassForObjects && this.matd_0.Shader != (MATD.MATDShader)2224877601U && this.matd_0.Shader != (MATD.MATDShader)2178752589U && this.matd_0.Shader != MATD.MATDShader.GlassForRabbitHoles)
				{
					return;
				}
				device_0.Indices = this.indexBuffer_0;
				device_0.SetStreamSource(0, this.vertexBuffer_0, 0, Class112.Struct7.SizeInBytes);
				float float_ = (Class140.smethod_0().CurrentRenderMode == Class140.Enum20.const_0) ? 0f : 1f;
				Class140.smethod_0().method_28("simpleObjectTranslucent", float_);
				Class140.smethod_0().method_9(RenderState.CullMode, Cull.Clockwise);
				Class140.smethod_0().method_9(RenderState.Lighting, true);
				Class140.smethod_0().method_9(RenderState.AlphaTestEnable, true);
				Class140.smethod_0().method_9(RenderState.AlphaFunc, Compare.Equal);
				Class140.smethod_0().method_9(RenderState.AlphaRef, 255);
				Class140.smethod_0().method_9(RenderState.ZWriteEnable, true);
				Class132.smethod_0().method_30(this.matd_0);
				if (this.matd_0.Shader == (MATD.MATDShader)3231479170U)
				{
					Class140.smethod_0().method_9(RenderState.ZWriteEnable, false);
					Class140.smethod_0().method_40("SimpleDropShadow");
					Class140.smethod_0().method_14(this.texture_1);
				}
				else
				{
					Class140.smethod_0().method_40("SimpleObject");
					Class140.smethod_0().method_14(this.texture_0);
					Material material = default(Material);
					material.Diffuse = Color.FromArgb(255, Color.White);
					material.Specular = Color.FromArgb(127, 127, 127, 127);
					material.Power = 0f;
					Class140.smethod_0().method_32(matrix_0, Class132.smethod_0().ViewMatrix);
					Class140.smethod_0().method_9(RenderState.AlphaBlendEnable, true);
					Class140.smethod_0().method_34(false);
					Class140.smethod_0().method_10();
					int num = Class140.smethod_0().method_36();
					for (int i = 0; i < num; i++)
					{
						Class140.smethod_0().method_38(i);
						device_0.DrawIndexedPrimitives(primitiveType, 0, 0, this.mlodEntry.VertexCount, (int)this.mlodEntry.IBUFOffset, this.mlodEntry.FaceCount);
						Class140.smethod_0().method_39();
					}
					Class140.smethod_0().method_37();
				}
			}

			// Token: 0x040008EC RID: 2284
			private VertexBuffer vertexBuffer_0;

			// Token: 0x040008ED RID: 2285
			private IndexBuffer indexBuffer_0;

			// Token: 0x040008EE RID: 2286
			public MLOD.MLODEntry mlodEntry;

			// Token: 0x040008EF RID: 2287
			public Texture texture_0;

			// Token: 0x040008F0 RID: 2288
			public Texture texture_1;

			// Token: 0x040008F1 RID: 2289
			public MATD matd_0;
		}
	}
}
