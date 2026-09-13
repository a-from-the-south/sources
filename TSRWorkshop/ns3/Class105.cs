using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using System.Xml;
using ns10;
using ns12;
using ns13;
using ns15;
using ns16;
using ns17;
using ns2;
using ns6;
using ns7;
using ns8;
using Package;
using Package.Sims3Files;
using Package.Sims3Files.InternalRCOL;
using Package.Squish;
using Sims3WorkshopSDK;
using Sims3WorkshopSDK.Classes;
using Sims3WorkshopSDK.Interfaces;
using SlimDX;
using SlimDX.Direct3D9;

namespace ns3
{
	// Token: 0x02000112 RID: 274
	internal sealed class Class105 : Class102
	{
		// Token: 0x1700025C RID: 604
		// (get) Token: 0x06000C09 RID: 3081 RVA: 0x00098A24 File Offset: 0x00096C24
		public OBJD Objd
		{
			get
			{
				return this.objd;
			}
		}

		// Token: 0x1700025D RID: 605
		// (get) Token: 0x06000C0A RID: 3082 RVA: 0x00098A3C File Offset: 0x00096C3C
		// (set) Token: 0x06000C0B RID: 3083 RVA: 0x00006EE4 File Offset: 0x000050E4
		private Texture _diffuseTexture { get; set; }

		// Token: 0x1700025E RID: 606
		// (get) Token: 0x06000C0C RID: 3084 RVA: 0x00098A54 File Offset: 0x00096C54
		// (set) Token: 0x06000C0D RID: 3085 RVA: 0x00006EEF File Offset: 0x000050EF
		private Texture _specularTexture { get; set; }

		// Token: 0x1700025F RID: 607
		// (get) Token: 0x06000C0E RID: 3086 RVA: 0x00098A6C File Offset: 0x00096C6C
		public Texture DiffuseTexture
		{
			get
			{
				return this._diffuseTexture;
			}
		}

		// Token: 0x17000260 RID: 608
		// (get) Token: 0x06000C0F RID: 3087 RVA: 0x00098A84 File Offset: 0x00096C84
		public Lod CurrentLodLevel
		{
			get
			{
				return this.lodLevel;
			}
		}

		// Token: 0x17000261 RID: 609
		// (get) Token: 0x06000C10 RID: 3088 RVA: 0x00098A9C File Offset: 0x00096C9C
		// (set) Token: 0x06000C11 RID: 3089 RVA: 0x00006EFA File Offset: 0x000050FA
		public bool IsDiagonal { get; set; }

		// Token: 0x17000262 RID: 610
		// (get) Token: 0x06000C12 RID: 3090 RVA: 0x00098AB4 File Offset: 0x00096CB4
		// (set) Token: 0x06000C13 RID: 3091 RVA: 0x00006F05 File Offset: 0x00005105
		public bool WallDirty
		{
			get
			{
				return this.bool_7;
			}
			set
			{
				this.bool_7 = value;
			}
		}

		// Token: 0x17000263 RID: 611
		// (get) Token: 0x06000C14 RID: 3092 RVA: 0x00098ACC File Offset: 0x00096CCC
		// (set) Token: 0x06000C15 RID: 3093 RVA: 0x00006F10 File Offset: 0x00005110
		public Color WallColor
		{
			get
			{
				return this.color_0;
			}
			set
			{
				this.color_0 = value;
				this.bool_7 = true;
			}
		}

		// Token: 0x17000264 RID: 612
		// (get) Token: 0x06000C16 RID: 3094 RVA: 0x00098AE4 File Offset: 0x00096CE4
		// (set) Token: 0x06000C17 RID: 3095 RVA: 0x00006F22 File Offset: 0x00005122
		public List<DDS> TempWallmasks { get; set; }

		// Token: 0x17000265 RID: 613
		// (get) Token: 0x06000C18 RID: 3096 RVA: 0x00098AFC File Offset: 0x00096CFC
		// (set) Token: 0x06000C19 RID: 3097 RVA: 0x00006F2D File Offset: 0x0000512D
		public bool UseTempWallmask { get; set; }

		// Token: 0x17000266 RID: 614
		// (get) Token: 0x06000C1A RID: 3098 RVA: 0x00098B14 File Offset: 0x00096D14
		public Class28 GrannyInfo
		{
			get
			{
				return this.class28_0;
			}
		}

		// Token: 0x17000267 RID: 615
		// (get) Token: 0x06000C1B RID: 3099 RVA: 0x00098B2C File Offset: 0x00096D2C
		public ResKey GrannyKey
		{
			get
			{
				return this.resKey_0;
			}
		}

		// Token: 0x06000C1C RID: 3100 RVA: 0x00098B44 File Offset: 0x00096D44
		public Class105(OBJD objd, Lod lodLevel)
		{
			this.lodLevel = lodLevel;
			this.lod_0 = ((this.lodLevel == Lod.High) ? Lod.ShadowHigh : ((this.lodLevel == Lod.Medium) ? Lod.ShadowMedium : ((this.lodLevel == Lod.Low) ? Lod.ShadowLow : this.lodLevel)));
			this.int_0 = -1;
			this.bool_5 = false;
			this.bool_6 = true;
			this.objd = objd;
			this.float_0 = 10f;
			this.float_1 = 3f;
			this.bool_8 = (this.objd.WallMaskCount > 0);
			base.DisplayWall = true;
			base.DisplayFloorMask = true;
			this.method_4(objd);
		}

		// Token: 0x06000C1D RID: 3101 RVA: 0x00098C04 File Offset: 0x00096E04
		public List<Class121> method_3()
		{
			List<Class121> list = new List<Class121>();
			foreach (Interface9 @interface in base.Objects.Values)
			{
				Class121 @class = (Class121)@interface;
				MATD.MATDShader shader = @class.Matd.Shader;
				if (shader <= MATD.MATDShader.GlassForObjects)
				{
					if (shader != MATD.MATDShader.GlassForRabbitHoles && shader != MATD.MATDShader.GlassForObjects)
					{
						continue;
					}
				}
				else if (shader != MATD.MATDShader.GlassForFences && shader != (MATD.MATDShader)2178752589U && shader != (MATD.MATDShader)2224877601U)
				{
					continue;
				}
				list.Add(@class);
			}
			return list;
		}

		// Token: 0x06000C1E RID: 3102 RVA: 0x00098CB0 File Offset: 0x00096EB0
		public override void imethod_12(S_CLIP s_CLIP_1)
		{
			if (this.class28_0 != null)
			{
				this.s_CLIP_0 = s_CLIP_1;
				foreach (Class33 @class in this.class28_0.Skeletons[0].Bones)
				{
					@class.Rotation = Quaternion.Identity;
					@class.TranslationMatrix = Matrix.Identity;
				}
			}
		}

		// Token: 0x06000C1F RID: 3103 RVA: 0x00098D0C File Offset: 0x00096F0C
		private void method_4(OBJD objd_0)
		{
			try
			{
				OBJK objk = Class132.mainForm.CurrentProject.Package.GetEntry(new ResKey(objd_0.OBJK.Reskey)) as OBJK;
				if (objk != null)
				{
					OBJK.KeyEntry keyEntry = objk.GetKeyEntry("modelKey");
					TGIIndex tgiindex = objk.TGIIndex[keyEntry.TgiIndex];
					if (tgiindex == null)
					{
						throw new Exception("No model key found");
					}
					if (!tgiindex.IsType(DBPFType.SPTR))
					{
						VisualProxy visualProxy = Class132.mainForm.CurrentProject.Package.GetEntry(new ResKey(tgiindex.Reskey)) as VisualProxy;
						foreach (RCOLItem rcolitem in visualProxy.Entries)
						{
							if (rcolitem is VPXY)
							{
								foreach (TGIIndex tgiindex2 in (rcolitem as VPXY).TGIIndex)
								{
									if (tgiindex2.IsType((DBPFType)2393838558U))
									{
										this.resKey_0 = new ResKey(tgiindex2.AsString());
										if (Class132.mainForm.RIGEditor != null)
										{
											RIG rig = Class132.mainForm.GetGamedataInstance().GetResource(this.resKey_0) as RIG;
											if (rig != null)
											{
												if (!rig.Encrypted)
												{
													Class28 @class = this.class28_0 = new Class28();
													@class.Skeletons = new Class34[]
													{
														new Class34()
													};
													Class34 class2 = @class.Skeletons[0];
													class2.Bones = new Class33[rig.Bones.Count];
													for (int i = 0; i < rig.Bones.Count; i++)
													{
														RIG.Bone bone = rig.Bones[i];
														Class33 class3 = new Class33();
														class2.Bones[i] = class3;
														class3.Sims3WorkshopSDK.Interfaces.IBone.Name = bone.BoneName;
														class3.NameHash = bone.BoneHash;
														class3.Sims3WorkshopSDK.Interfaces.IBone.ParentIndex = bone.ParentIndex;
														class3.InverseMatrix = new float[16];
														class3.Transformation = new Class32();
														class3.Transformation.Sims3WorkshopSDK.Interfaces.ITransform.Origin = new float[]
														{
															bone.Position[0],
															bone.Position[1],
															bone.Position[2]
														};
														class3.Transformation.Sims3WorkshopSDK.Interfaces.ITransform.Quat = new float[]
														{
															bone.Quaternion[0],
															bone.Quaternion[1],
															bone.Quaternion[2],
															bone.Quaternion[3]
														};
														class3.Transformation.Sims3WorkshopSDK.Interfaces.ITransform.Scale = new float[]
														{
															bone.Scaling[0],
															bone.Scaling[1],
															bone.Scaling[2]
														};
														class2.HashedBones.Add(bone.BoneHash, class3);
													}
													for (int j = 0; j < class2.Bones.Length; j++)
													{
														Class33 class4 = class2.Bones[j];
														for (int k = 0; k < class2.Bones.Length; k++)
														{
															Class33 class5 = class2.Bones[k];
															if (class5.Sims3WorkshopSDK.Interfaces.IBone.ParentIndex == j)
															{
																class4.ChildBones.Add(class5);
																class5.ParentBone = class4;
															}
														}
													}
													class2.Sims3WorkshopSDK.Interfaces.ISkeleton.Name = rig.SkeletonName;
												}
												else if (Class132.mainForm.RIGEditor.CanHandleEncrypted)
												{
													this.class28_0 = new Class28();
													Class132.mainForm.RIGEditor.GetGranny2Info(Class132.mainForm.GetGamedataInstance(), this.resKey_0, this.class28_0);
												}
											}
										}
										break;
									}
								}
							}
						}
					}
				}
			}
			catch (Exception)
			{
				this.class28_0 = null;
			}
		}

		// Token: 0x06000C20 RID: 3104 RVA: 0x00099158 File Offset: 0x00097358
		public override void imethod_11(int int_1)
		{
			if (this.class28_0 != null && this.s_CLIP_0 != null)
			{
				foreach (S_CLIP.JointMovementRule jointMovementRule in this.s_CLIP_0.GetJointMovementRules())
				{
					Class33 @class = this.class28_0.Skeletons[0].HashedBones[jointMovementRule.jointName] as Class33;
					if (@class != null)
					{
						S_CLIP.Frame frame = null;
						if (jointMovementRule.IndexedFrames.TryGetValue(int_1, out frame))
						{
							if (jointMovementRule.frameDataType == 274)
							{
								float num = (frame.data[0] & 1023U) / 1023f;
								float num2 = (frame.data[0] >> 10 & 1023U) / 1023f;
								float num3 = (frame.data[0] >> 20 & 1023U) / 1023f;
								if ((frame.signedBits & 1) != 0)
								{
									num = -num;
								}
								if ((frame.signedBits & 2) != 0)
								{
									num2 = -num2;
								}
								if ((frame.signedBits & 4) != 0)
								{
									num3 = -num3;
								}
								num *= jointMovementRule.scale;
								num2 *= jointMovementRule.scale;
								num3 *= jointMovementRule.scale;
								num += jointMovementRule.frameOffset;
								num2 += jointMovementRule.frameOffset;
								num3 += jointMovementRule.frameOffset;
								Matrix translationMatrix = Matrix.Translation(num, num2, num3);
								@class.TranslationMatrix = translationMatrix;
							}
							if (jointMovementRule.frameDataType == 532)
							{
								float num4 = (frame.data[0] & 4095U) / 4095f;
								float num5 = (frame.data[1] & 4095U) / 4095f;
								float num6 = (frame.data[2] & 4095U) / 4095f;
								float num7 = (frame.data[3] & 4095U) / 4095f;
								if ((frame.signedBits & 1) != 0)
								{
									num4 = -num4;
								}
								if ((frame.signedBits & 2) != 0)
								{
									num5 = -num5;
								}
								if ((frame.signedBits & 4) != 0)
								{
									num6 = -num6;
								}
								if ((frame.signedBits & 8) != 0)
								{
									num7 = -num7;
								}
								num4 *= jointMovementRule.scale;
								num5 *= jointMovementRule.scale;
								num6 *= jointMovementRule.scale;
								num7 *= jointMovementRule.scale;
								num4 += jointMovementRule.frameOffset;
								num5 += jointMovementRule.frameOffset;
								num6 += jointMovementRule.frameOffset;
								num7 += jointMovementRule.frameOffset;
								Quaternion rotation = new Quaternion(num4, num5, num6, num7);
								Matrix.RotationQuaternion(rotation);
								@class.Sims3WorkshopSDK.Interfaces.IBone.Name.Equals("__root_trans__");
								@class.Rotation = rotation;
							}
						}
					}
				}
				this.imethod_14();
				Class132.mainForm.Render();
			}
		}

		// Token: 0x06000C21 RID: 3105 RVA: 0x00099444 File Offset: 0x00097644
		public unsafe override void imethod_14()
		{
			if (this.class28_0 != null)
			{
				foreach (Class33 @class in this.class28_0.Skeletons[0].Bones)
				{
					if (@class.Sims3WorkshopSDK.Interfaces.IBone.ParentIndex == -1)
					{
						foreach (Interface9 @interface in base.Objects.Values)
						{
							Class121 class2 = (Class121)@interface;
							if (class2.LOD == this.LODLevel)
							{
								this.method_5(class2, @class, Matrix.Identity, Matrix.Identity);
							}
						}
					}
				}
				foreach (Interface9 interface2 in base.Objects.Values)
				{
					Class121 class3 = (Class121)interface2;
					DataStream dataStream = class3.VertexBuffer.Lock(0, 0, LockFlags.None);
					Class112.Struct7* ptr = (Class112.Struct7*)((void*)dataStream.DataPointer);
					DataStream dataStream2 = class3.VertexBufferTransformed.Lock(0, 0, LockFlags.None);
					Class112.Struct7* ptr2 = (Class112.Struct7*)((void*)dataStream2.DataPointer);
					for (int j = 0; j < class3.VertexCount; j++)
					{
						Vector3 vector = ptr[j].position;
						vector += ptr[j].vector3_0;
						Vector3 vector2 = Vector3.Zero;
						sbyte b = (sbyte)(ptr[j].uint_0 >> 24 & 255U);
						sbyte b2 = (sbyte)(ptr[j].uint_0 >> 16 & 255U);
						sbyte b3 = (sbyte)(ptr[j].uint_0 >> 8 & 255U);
						sbyte b4 = (sbyte)(ptr[j].uint_0 & 255U);
						Matrix transformation = Matrix.Identity;
						Matrix transformation2 = Matrix.Identity;
						Matrix transformation3 = Matrix.Identity;
						Matrix transformation4 = Matrix.Identity;
						if (b4 > -1)
						{
							transformation = class3.Palette[(int)b4];
						}
						if (b3 > -1)
						{
							transformation2 = class3.Palette[(int)b3];
						}
						if (b2 > -1)
						{
							transformation3 = class3.Palette[(int)b2];
						}
						if (b > -1)
						{
							transformation4 = class3.Palette[(int)b];
						}
						if (b4 == -1 && b3 == -1 && b2 == -1 && b == -1)
						{
							vector2 = vector;
						}
						vector2 += Vector3.TransformCoordinate(vector, transformation) * ptr[j].float_0;
						vector2 += Vector3.TransformCoordinate(vector, transformation2) * ptr[j].float_1;
						vector2 += Vector3.TransformCoordinate(vector, transformation3) * ptr[j].float_2;
						vector2 += Vector3.TransformCoordinate(vector, transformation4) * ptr[j].float_3;
						ptr2[j].position = vector2;
					}
					class3.VertexBuffer.Unlock();
					class3.VertexBufferTransformed.Unlock();
				}
				EditorToolBox.smethod_0().method_1();
			}
		}

		// Token: 0x06000C22 RID: 3106 RVA: 0x000997D8 File Offset: 0x000979D8
		private void method_5(Class121 class121_0, Class33 class33_0, Matrix matrix_1, Matrix matrix_2)
		{
			if (this.s_CLIP_0 == null)
			{
				Matrix left = this.method_6(class121_0, FNV32.GetHash(class33_0.Sims3WorkshopSDK.Interfaces.IBone.Name));
				Matrix matrix = Matrix.RotationQuaternion(new Quaternion(class33_0.Transformation.Sims3WorkshopSDK.Interfaces.ITransform.Quat[0], class33_0.Transformation.Sims3WorkshopSDK.Interfaces.ITransform.Quat[1], class33_0.Transformation.Sims3WorkshopSDK.Interfaces.ITransform.Quat[2], class33_0.Transformation.Sims3WorkshopSDK.Interfaces.ITransform.Quat[3]));
				Matrix right = Matrix.Translation(new Vector3(class33_0.Transformation.Sims3WorkshopSDK.Interfaces.ITransform.Origin[0], class33_0.Transformation.Sims3WorkshopSDK.Interfaces.ITransform.Origin[1], class33_0.Transformation.Sims3WorkshopSDK.Interfaces.ITransform.Origin[2]));
				class33_0.CombinedBoneTransformationMatrix = matrix * right * matrix_2;
				class33_0.CombinedTransformationMatrix = left * matrix * right * matrix_2;
				class33_0.CombinedTransformationMatrix = Matrix.Identity;
			}
			else
			{
				Matrix matrix2 = this.method_6(class121_0, FNV32.GetHash(class33_0.Sims3WorkshopSDK.Interfaces.IBone.Name));
				Matrix left2 = Matrix.RotationQuaternion(new Quaternion(class33_0.Transformation.Sims3WorkshopSDK.Interfaces.ITransform.Quat[0], class33_0.Transformation.Sims3WorkshopSDK.Interfaces.ITransform.Quat[1], class33_0.Transformation.Sims3WorkshopSDK.Interfaces.ITransform.Quat[2], class33_0.Transformation.Sims3WorkshopSDK.Interfaces.ITransform.Quat[3]));
				Matrix right2 = Matrix.Translation(new Vector3(class33_0.Transformation.Sims3WorkshopSDK.Interfaces.ITransform.Origin[0], class33_0.Transformation.Sims3WorkshopSDK.Interfaces.ITransform.Origin[1], class33_0.Transformation.Sims3WorkshopSDK.Interfaces.ITransform.Origin[2]));
				class33_0.CombinedBoneTransformationMatrix = left2 * right2 * matrix_2;
				Matrix identity = Matrix.Identity;
				Matrix translationMatrix = class33_0.TranslationMatrix;
				class33_0.OffsetMatrix = matrix2;
				class33_0.CombinedTransformationMatrix = matrix2 * Matrix.RotationQuaternion(class33_0.Rotation) * class33_0.TranslationMatrix * matrix_2;
			}
			int num = class121_0.list_0.IndexOf(class33_0.NameHash);
			if (num != -1)
			{
				class121_0.Palette[num] = class33_0.CombinedTransformationMatrix;
			}
			List<Class33> childBones = class33_0.ChildBones;
			foreach (Class33 class33_ in childBones)
			{
				this.method_5(class121_0, class33_, class33_0.CombinedTransformationMatrix, class33_0.CombinedBoneTransformationMatrix);
			}
		}

		// Token: 0x06000C23 RID: 3107 RVA: 0x00099A18 File Offset: 0x00097C18
		private Matrix method_6(Class121 class121_0, uint uint_0)
		{
			if (class121_0.MLODEntry.SkinIndex != -1)
			{
				SKIN skin = class121_0.MLODEntry.Parent.Parent.Entries[class121_0.MLODEntry.SkinIndex + ((class121_0.MLODEntry.Parent.Parent.dataType == 2) ? 1 : 0)] as SKIN;
				if (skin != null)
				{
					SKIN.SKINEntry skinentry = skin.HashedEntries[uint_0] as SKIN.SKINEntry;
					if (skinentry != null)
					{
						Matrix identity = Matrix.Identity;
						identity.M11 = skinentry.BoneMatrix[0];
						identity.M12 = skinentry.BoneMatrix[4];
						identity.M13 = skinentry.BoneMatrix[8];
						identity.M21 = skinentry.BoneMatrix[1];
						identity.M22 = skinentry.BoneMatrix[5];
						identity.M23 = skinentry.BoneMatrix[9];
						identity.M31 = skinentry.BoneMatrix[2];
						identity.M32 = skinentry.BoneMatrix[6];
						identity.M33 = skinentry.BoneMatrix[10];
						identity.M41 = skinentry.BoneMatrix[3];
						identity.M42 = skinentry.BoneMatrix[7];
						identity.M43 = skinentry.BoneMatrix[11];
						return identity;
					}
				}
			}
			return Matrix.Identity;
		}

		// Token: 0x06000C24 RID: 3108 RVA: 0x00099B6C File Offset: 0x00097D6C
		private List<Class33> method_7(Class33 class33_0)
		{
			List<Class33> list = new List<Class33>();
			foreach (Class33 @class in this.class28_0.Skeletons[0].Bones)
			{
				if (@class.Sims3WorkshopSDK.Interfaces.IBone.ParentIndex != -1)
				{
					Class33 class2 = this.class28_0.Skeletons[0].Bones[@class.Sims3WorkshopSDK.Interfaces.IBone.ParentIndex];
					if (class2 == class33_0)
					{
						list.Add(@class);
					}
				}
			}
			return list;
		}

		// Token: 0x06000C25 RID: 3109 RVA: 0x00006F38 File Offset: 0x00005138
		public override void imethod_10(int int_1)
		{
			this.int_0 = int_1;
		}

		// Token: 0x06000C26 RID: 3110 RVA: 0x00099BE0 File Offset: 0x00097DE0
		public override void imethod_9(uint uint_0, Matrix matrix_1)
		{
			if (this.class28_0 != null)
			{
				Class33 @class = this.class28_0.Skeletons[0].HashedBones[uint_0] as Class33;
				if (@class != null)
				{
					@class.Rotation = Quaternion.RotationMatrix(matrix_1);
				}
			}
			this.imethod_14();
			Class132.mainForm.Render();
		}

		// Token: 0x06000C27 RID: 3111 RVA: 0x00099C3C File Offset: 0x00097E3C
		private void method_8(Device device_0, LITE.LightEntry lightEntry_0, ResKey resKey_1)
		{
			Class120 item = new Class120(device_0, lightEntry_0, resKey_1);
			base.Lites.Add(item);
		}

		// Token: 0x06000C28 RID: 3112 RVA: 0x00099C60 File Offset: 0x00097E60
		private void method_9(Device device_0, FTPT ftpt_0, FTPT.FootprintEntry footprintEntry_0)
		{
			Class129 item = new Class129(device_0, ftpt_0, footprintEntry_0);
			base.Slots.Add(item);
		}

		// Token: 0x06000C29 RID: 3113 RVA: 0x00099C84 File Offset: 0x00097E84
		private void method_10(Device device_0, FTPT ftpt_0, FTPT.FootprintEntry footprintEntry_0)
		{
			Class129 item = new Class129(device_0, ftpt_0, footprintEntry_0);
			base.Footprints.Add(item);
		}

		// Token: 0x06000C2A RID: 3114 RVA: 0x00099CA8 File Offset: 0x00097EA8
		private Class111 method_11(Device device_0, RSLT rslt_0, RSLT.Entry entry_0, Color color_1)
		{
			Class111 @class = new Class111(device_0, rslt_0, entry_0, color_1, this.class28_0);
			if (this.class28_0 != null)
			{
				foreach (object obj in this.class28_0.Skeletons[0].HashedBones.Keys)
				{
					uint num = (uint)obj;
					if (num == entry_0.BoneHash)
					{
						@class.ReadableName = (this.class28_0.Skeletons[0].HashedBones[num] as Class33).Sims3WorkshopSDK.Interfaces.IBone.Name;
					}
				}
			}
			return @class;
		}

		// Token: 0x17000268 RID: 616
		// (get) Token: 0x06000C2B RID: 3115 RVA: 0x00098A84 File Offset: 0x00096C84
		// (set) Token: 0x06000C2C RID: 3116 RVA: 0x00006F43 File Offset: 0x00005143
		public Lod LODLevel
		{
			get
			{
				return this.lodLevel;
			}
			set
			{
				this.lodLevel = value;
				this.lod_0 = ((value == Lod.High) ? Lod.ShadowHigh : ((value == Lod.Medium) ? Lod.ShadowMedium : ((value == Lod.Low) ? Lod.ShadowLow : value)));
			}
		}

		// Token: 0x06000C2D RID: 3117 RVA: 0x00006F75 File Offset: 0x00005175
		public override void imethod_6(Device device_0)
		{
			this.method_12();
			this.imethod_7(device_0);
		}

		// Token: 0x06000C2E RID: 3118 RVA: 0x00006F86 File Offset: 0x00005186
		private void method_12()
		{
			this.interface3_0 = Class132.smethod_0().method_8(new Size(1024, 1024));
		}

		// Token: 0x06000C2F RID: 3119 RVA: 0x00006FA9 File Offset: 0x000051A9
		private void method_13(Device device_0)
		{
			if (this.bool_8 && this.vertexBuffer_0 == null)
			{
				this.vertexBuffer_0 = new VertexBuffer(device_0, 12 * Class112.Struct7.SizeInBytes, Usage.None, Class112.Struct7.vertexFormat_0, Pool.Managed);
			}
		}

		// Token: 0x06000C30 RID: 3120 RVA: 0x00006FD8 File Offset: 0x000051D8
		private void method_14(Device device_0)
		{
			if (this.Objd.Version >= 1U && this.vertexBuffer_1 == null)
			{
				this.vertexBuffer_1 = new VertexBuffer(device_0, 6 * Class112.Struct7.SizeInBytes, Usage.None, Class112.Struct7.vertexFormat_0, Pool.Managed);
			}
		}

		// Token: 0x06000C31 RID: 3121 RVA: 0x00099D64 File Offset: 0x00097F64
		public override void imethod_5(Device device_0)
		{
			foreach (Interface9 @interface in base.Objects.Values)
			{
				Class121 @class = (Class121)@interface;
				@class.method_13(device_0);
			}
			this.interface3_0.imethod_2(false);
		}

		// Token: 0x06000C32 RID: 3122 RVA: 0x00099DD0 File Offset: 0x00097FD0
		public override void vmethod_7(Device device_0)
		{
			this.method_12();
			foreach (Interface9 @interface in base.Objects.Values)
			{
				Class121 @class = (Class121)@interface;
				@class.method_14(device_0);
			}
		}

		// Token: 0x06000C33 RID: 3123 RVA: 0x00099E38 File Offset: 0x00098038
		public override void imethod_8(bool bool_11)
		{
			base.imethod_8(bool_11);
			if (bool_11)
			{
				if (this.texture_0 != null)
				{
					this.texture_0.Dispose();
				}
				if (this.texture_1 != null)
				{
					this.texture_1.Dispose();
				}
				if (this.vertexBuffer_0 != null)
				{
					this.vertexBuffer_0.Dispose();
				}
				if (this.vertexBuffer_1 != null)
				{
					this.vertexBuffer_1.Dispose();
				}
				if (this._diffuseTexture != null)
				{
					this._diffuseTexture.Dispose();
				}
				if (this._specularTexture != null)
				{
					this._specularTexture.Dispose();
				}
			}
			this.interface3_0.imethod_2(bool_11);
		}

		// Token: 0x17000269 RID: 617
		// (get) Token: 0x06000C34 RID: 3124 RVA: 0x00099ED0 File Offset: 0x000980D0
		// (set) Token: 0x06000C35 RID: 3125 RVA: 0x0000700C File Offset: 0x0000520C
		public Bitmap WallMaskImage { get; set; }

		// Token: 0x06000C36 RID: 3126 RVA: 0x00099EE8 File Offset: 0x000980E8
		public void method_15(Device device_0)
		{
			if (this.texture_0 != null)
			{
				this.texture_0.Dispose();
			}
			Rectangle rect = new Rectangle(0, 0, (int)(64f * this.float_0), 256);
			if (this.WallMaskImage == null)
			{
				this.WallMaskImage = new Bitmap(rect.Width, rect.Height);
			}
			Bitmap wallMaskImage = this.WallMaskImage;
			Graphics graphics = Graphics.FromImage(wallMaskImage);
			SolidBrush brush = new SolidBrush(this.WallColor);
			graphics.FillRectangle(brush, rect);
			int num = 1;
			foreach (OBJD.WallMask wallMask in this.objd.WallMasks)
			{
				DDS dds;
				if (this.UseTempWallmask)
				{
					dds = this.TempWallmasks[num - 1];
				}
				else
				{
					ResKey resKey = new ResKey(this.objd.TgiIndex[wallMask.DdsIndex].AsString());
					dds = (Class76.smethod_26(resKey) as DDS);
				}
				if (dds != null)
				{
					Image image = ImageLoader.Load(dds.MipMaps[0]);
					Bitmap bitmap = new Bitmap(64, 128);
					for (int i = 0; i < 128; i++)
					{
						for (int j = 0; j < 64; j++)
						{
							float num2 = (float)j / 64f * (float)image.Width;
							float num3 = (float)i / 128f * (float)image.Height;
							Color pixel = (image as Bitmap).GetPixel((int)num2, (int)num3);
							bitmap.SetPixel(j, i, pixel);
						}
					}
					Point point = new Point((int)((float)(rect.Width / 2) + (float)((num % 2 == 0) ? -1 : 1) * (64f * wallMask.F1)), (num % 2 == 0) ? 0 : 128);
					if (num % 2 == 0)
					{
						for (int k = 0; k < bitmap.Height; k++)
						{
							for (int l = 0; l < bitmap.Width; l++)
							{
								Color pixel2 = bitmap.GetPixel(bitmap.Width - (l + 1), k);
								Color pixel3 = wallMaskImage.GetPixel(Math.Min(wallMaskImage.Width - 1, l + point.X), Math.Min(wallMaskImage.Height - 1, k + point.Y));
								wallMaskImage.SetPixel(Math.Min(wallMaskImage.Width - 1, l + point.X), Math.Min(wallMaskImage.Height - 1, k + point.Y), Color.FromArgb((int)((pixel2.A < 1) ? 0 : pixel3.A), pixel3));
							}
						}
					}
					else
					{
						for (int m = 0; m < bitmap.Height; m++)
						{
							for (int n = 0; n < bitmap.Width; n++)
							{
								Color pixel4 = bitmap.GetPixel(n, m);
								Color pixel5 = wallMaskImage.GetPixel(Math.Min(wallMaskImage.Width - 1, n + point.X), Math.Min(wallMaskImage.Height - 1, m + point.Y));
								wallMaskImage.SetPixel(Math.Min(wallMaskImage.Width - 1, n + point.X), Math.Min(wallMaskImage.Height - 1, m + point.Y), Color.FromArgb((int)((pixel4.A < 1) ? 0 : pixel5.A), pixel5));
							}
						}
					}
					num++;
				}
			}
			MemoryStream memoryStream = new MemoryStream();
			wallMaskImage.Save(memoryStream, ImageFormat.Png);
			memoryStream.Position = 0L;
			this.texture_0 = Texture.FromStream(Class140.smethod_0().Device, memoryStream, 640, 256, 1, Usage.None, Format.A8R8G8B8, Pool.Managed, Filter.None, Filter.None, 0);
			memoryStream.Dispose();
		}

		// Token: 0x06000C37 RID: 3127 RVA: 0x00007017 File Offset: 0x00005217
		private void method_16()
		{
			base.imethod_8(true);
		}

		// Token: 0x06000C38 RID: 3128 RVA: 0x0009A2E8 File Offset: 0x000984E8
		public override void imethod_7(Device device_0)
		{
			this.method_13(device_0);
			this.method_14(device_0);
			this.method_16();
			if (this.bool_8)
			{
				lock (this.vertexBuffer_0)
				{
					Class112.Struct7[] array = new Class112.Struct7[12];
					array[5] = new Class112.Struct7(new Vector3(this.float_0 / 2f, 0f, 0f), new Vector3(this.float_0 / 2f, 0f, -0.17f), new Vector2(0f, 0.5f));
					array[4] = new Class112.Struct7(new Vector3(-(this.float_0 / 2f), 0f, 0f), new Vector3(-(this.float_0 / 2f), 0f, -0.17f), new Vector2(1f, 0.5f));
					array[3] = new Class112.Struct7(new Vector3(this.float_0 / 2f, this.float_1, 0f), new Vector3(this.float_0 / 2f, this.float_1, -0.17f), new Vector2(0f, 0f));
					array[0] = new Class112.Struct7(new Vector3(this.float_0 / 2f, this.float_1, 0f), new Vector3(this.float_0 / 2f, this.float_1, -0.17f), new Vector2(0f, 0f));
					array[1] = new Class112.Struct7(new Vector3(-(this.float_0 / 2f), this.float_1, 0f), new Vector3(-(this.float_0 / 2f), this.float_1, -0.17f), new Vector2(1f, 0f));
					array[2] = new Class112.Struct7(new Vector3(-(this.float_0 / 2f), 0f, 0f), new Vector3(-(this.float_0 / 2f), 0f, -0.17f), new Vector2(1f, 0.5f));
					array[6] = new Class112.Struct7(new Vector3(this.float_0 / 2f, 0f, 0f), new Vector3(this.float_0 / 2f, 0f, 0.17f), new Vector2(1f, 1f));
					array[7] = new Class112.Struct7(new Vector3(-(this.float_0 / 2f), 0f, 0f), new Vector3(-(this.float_0 / 2f), 0f, 0.17f), new Vector2(0f, 1f));
					array[8] = new Class112.Struct7(new Vector3(this.float_0 / 2f, this.float_1, 0f), new Vector3(this.float_0 / 2f, this.float_1, 0.17f), new Vector2(1f, 0.5f));
					array[11] = new Class112.Struct7(new Vector3(this.float_0 / 2f, this.float_1, 0f), new Vector3(this.float_0 / 2f, this.float_1, 0.17f), new Vector2(1f, 0.5f));
					array[10] = new Class112.Struct7(new Vector3(-(this.float_0 / 2f), this.float_1, 0f), new Vector3(-(this.float_0 / 2f), this.float_1, 0.17f), new Vector2(0f, 0.5f));
					array[9] = new Class112.Struct7(new Vector3(-(this.float_0 / 2f), 0f, 0f), new Vector3(-(this.float_0 / 2f), 0f, 0.17f), new Vector2(0f, 1f));
					if (this.vertexBuffer_0.Disposed)
					{
						this.vertexBuffer_0 = new VertexBuffer(device_0, 12 * Class112.Struct7.SizeInBytes, Usage.None, Class112.Struct7.vertexFormat_0, Pool.Managed);
					}
					DataStream dataStream = this.vertexBuffer_0.Lock(0, 0, LockFlags.None);
					dataStream.WriteRange<Class112.Struct7>(array, 0, 12);
					this.vertexBuffer_0.Unlock();
				}
				this.method_15(device_0);
			}
			if (this.Objd.Version >= 23U)
			{
				lock (this.vertexBuffer_1)
				{
					Class112.Struct7[] array2 = new Class112.Struct7[6];
					float floorCutoutBoundsLength = this.Objd.FloorCutoutBoundsLength;
					float num = (this.Objd.Version >= 32U) ? this.Objd.FloorCutoutBoundsWidth : floorCutoutBoundsLength;
					array2[2] = new Class112.Struct7(new Vector3(num / 2f, 0f, -(floorCutoutBoundsLength / 2f)), new Vector3(num / 2f, 1f, -(floorCutoutBoundsLength / 2f)), new Vector2(1f, 0f));
					array2[1] = new Class112.Struct7(new Vector3(num / 2f, 0f, floorCutoutBoundsLength / 2f), new Vector3(num / 2f, 1f, floorCutoutBoundsLength / 2f), new Vector2(1f, 1f));
					array2[0] = new Class112.Struct7(new Vector3(-(num / 2f), 0f, floorCutoutBoundsLength / 2f), new Vector3(-(num / 2f), 1f, floorCutoutBoundsLength / 2f), new Vector2(0f, 1f));
					array2[5] = new Class112.Struct7(new Vector3(-(num / 2f), 0f, floorCutoutBoundsLength / 2f), new Vector3(-(num / 2f), 1f, floorCutoutBoundsLength / 2f), new Vector2(0f, 1f));
					array2[4] = new Class112.Struct7(new Vector3(-(num / 2f), 0f, -(floorCutoutBoundsLength / 2f)), new Vector3(-(num / 2f), 1f, -(floorCutoutBoundsLength / 2f)), new Vector2(0f, 0f));
					array2[3] = new Class112.Struct7(new Vector3(num / 2f, 0f, -(floorCutoutBoundsLength / 2f)), new Vector3(num / 2f, 1f, -(floorCutoutBoundsLength / 2f)), new Vector2(1f, 0f));
					if (this.vertexBuffer_1.Disposed)
					{
						this.vertexBuffer_0 = new VertexBuffer(device_0, 6 * Class112.Struct7.SizeInBytes, Usage.None, Class112.Struct7.vertexFormat_0, Pool.Managed);
					}
					DataStream dataStream2 = this.vertexBuffer_1.Lock(0, 0, LockFlags.None);
					dataStream2.WriteRange<Class112.Struct7>(array2, 0, 6);
					this.vertexBuffer_1.Unlock();
				}
			}
			try
			{
				this.method_18(device_0, this.objd);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
			if (this.class28_0 != null)
			{
				this.imethod_14();
				for (int i = 0; i < this.class28_0.Skeletons[0].Bones.Length; i++)
				{
					Class33 @class = this.class28_0.Skeletons[0].Bones[i];
					Class33 parentBone = (@class.Sims3WorkshopSDK.Interfaces.IBone.ParentIndex != -1) ? this.class28_0.Skeletons[0].Bones[@class.Sims3WorkshopSDK.Interfaces.IBone.ParentIndex] : null;
					Class119 item = new Class119(Class140.smethod_0().Device, this, this.resKey_0, this.class28_0, @class, parentBone, Color.Plum);
					base.JointEntries.Add(item);
				}
			}
			if (this.Objd.Version >= 23U)
			{
				if (this.texture_1 != null && !this.texture_1.Disposed)
				{
					this.texture_1.Dispose();
				}
				TGIIndex tgiindex = this.Objd.TgiIndex[this.Objd.FloorMaskIndex];
				DDS dds = Class76.smethod_30(tgiindex, false, false) as DDS;
				if (dds != null)
				{
					this.texture_1 = Texture.FromMemory(device_0, dds.GetData());
					base.HasFloorMask = true;
				}
			}
		}

		// Token: 0x06000C39 RID: 3129 RVA: 0x0009ABE8 File Offset: 0x00098DE8
		private Vector3 method_17(Vector3 vector3_0, Class33 class33_0, Class34 class34_0)
		{
			if (class33_0.Sims3WorkshopSDK.Interfaces.IBone.ParentIndex != -1)
			{
				Class33 @class = class34_0.Bones[class33_0.Sims3WorkshopSDK.Interfaces.IBone.ParentIndex];
				Vector3 right = new Vector3(@class.Transformation.Sims3WorkshopSDK.Interfaces.ITransform.Origin[0], @class.Transformation.Sims3WorkshopSDK.Interfaces.ITransform.Origin[1], @class.Transformation.Sims3WorkshopSDK.Interfaces.ITransform.Origin[2]);
				vector3_0 += right;
			}
			return vector3_0;
		}

		// Token: 0x06000C3A RID: 3130 RVA: 0x0009AC48 File Offset: 0x00098E48
		private void method_18(Device device_0, OBJD objd_0)
		{
			OBJK objk = Class132.mainForm.CurrentProject.Package.GetEntry(new ResKey(objd_0.OBJK.Reskey)) as OBJK;
			if (objk != null)
			{
				OBJK.KeyEntry keyEntry = objk.GetKeyEntry("modelKey");
				TGIIndex tgiindex = objk.TGIIndex[keyEntry.TgiIndex];
				if (tgiindex == null)
				{
					throw new Exception("No model key found");
				}
				if (tgiindex.IsType(DBPFType.SPTR))
				{
					OBJK.KeyEntry keyEntry2 = objk.GetKeyEntry("footprintKey");
					TGIIndex tgiindex2 = objk.TGIIndex[keyEntry2.TgiIndex];
					RCOL rcol = Class132.mainForm.CurrentProject.Package.GetEntry(new ResKey(tgiindex2.AsString())) as RCOL;
					foreach (RCOLItem rcolitem in rcol.Entries)
					{
						FTPT ftpt = (FTPT)rcolitem;
						foreach (FTPT.FootprintEntry footprintEntry_ in ftpt.SlotEntries)
						{
							this.method_9(device_0, ftpt, footprintEntry_);
						}
						foreach (FTPT.FootprintEntry footprintEntry_2 in ftpt.FootprintEntries)
						{
							this.method_10(device_0, ftpt, footprintEntry_2);
						}
					}
				}
				VisualProxy visualProxy = Class132.mainForm.CurrentProject.Package.GetEntry(new ResKey(tgiindex.Reskey)) as VisualProxy;
				if (visualProxy == null && tgiindex.IsType(DBPFType.SPTR))
				{
					throw new Exception("Preview rendering of SpeedTree(R) items are not supported.");
				}
				if (visualProxy == null)
				{
					throw new Exception("Model was not supported");
				}
				foreach (RCOLItem rcolitem2 in visualProxy.Entries)
				{
					VPXY vpxy = (VPXY)rcolitem2;
					foreach (VPXY.VPXEntryEntry vpxentryEntry in vpxy.entries)
					{
						if (vpxentryEntry.type == 1)
						{
							foreach (int index in vpxentryEntry.index)
							{
								TGIIndex tgiindex3 = vpxy.TGIIndex[index];
								if (tgiindex3.IsType(DBPFType.MODL))
								{
									ResKey key = new ResKey(tgiindex3.Reskey);
									DBPFEntry entry = Class132.mainForm.CurrentProject.Package.GetEntry(key);
									this.method_19(device_0, (MODLModel)entry, 0);
								}
							}
						}
					}
					foreach (VPXY.VPXEntryEntry vpxentryEntry2 in vpxy.entries)
					{
						if (vpxentryEntry2.type == 1)
						{
							foreach (int index2 in vpxentryEntry2.index)
							{
								TGIIndex tgiindex4 = vpxy.TGIIndex[index2];
								if (tgiindex4.IsType(DBPFType.LITE))
								{
									ResKey resKey = new ResKey(tgiindex4.Reskey);
									LightResource lightResource = Class132.mainForm.CurrentProject.Package.GetEntry(resKey) as LightResource;
									if (lightResource != null)
									{
										using (List<RCOLItem>.Enumerator enumerator9 = lightResource.Entries.GetEnumerator())
										{
											while (enumerator9.MoveNext())
											{
												RCOLItem rcolitem3 = enumerator9.Current;
												LITE lite = (LITE)rcolitem3;
												foreach (LITE.LightEntry lightEntry_ in lite.Entries128)
												{
													this.method_8(device_0, lightEntry_, resKey);
												}
												foreach (LITE.LightEntry lightEntry_2 in lite.Entries56)
												{
													this.method_8(device_0, lightEntry_2, resKey);
												}
											}
											goto IL_41D;
										}
									}
									MessageBox.Show("Resource " + resKey.ToString() + " was not found.");
								}
								IL_41D:
								if (tgiindex4.IsType((DBPFType)3548561239U))
								{
									ResKey resKey2 = new ResKey(tgiindex4.Reskey);
									FTPTResource ftptresource = Class132.mainForm.CurrentProject.Package.GetEntry(resKey2) as FTPTResource;
									if (ftptresource != null)
									{
										using (List<RCOLItem>.Enumerator enumerator12 = ftptresource.Entries.GetEnumerator())
										{
											while (enumerator12.MoveNext())
											{
												RCOLItem rcolitem4 = enumerator12.Current;
												FTPT ftpt2 = (FTPT)rcolitem4;
												foreach (FTPT.FootprintEntry footprintEntry_3 in ftpt2.SlotEntries)
												{
													this.method_9(device_0, ftpt2, footprintEntry_3);
												}
												foreach (FTPT.FootprintEntry footprintEntry_4 in ftpt2.FootprintEntries)
												{
													this.method_10(device_0, ftpt2, footprintEntry_4);
												}
											}
											goto IL_536;
										}
									}
									MessageBox.Show("Resource " + resKey2.ToString() + " was not found.");
								}
								IL_536:
								if (tgiindex4.IsType((DBPFType)3540272417U))
								{
									ResKey key2 = new ResKey(tgiindex4.Reskey);
									RSLTResource rsltresource = Class132.mainForm.CurrentProject.Package.GetEntry(key2) as RSLTResource;
									if (rsltresource != null)
									{
										foreach (RCOLItem rcolitem5 in rsltresource.Entries)
										{
											RSLT rslt = (RSLT)rcolitem5;
											foreach (RSLT.Entry entry_ in rslt.ContainerEntries)
											{
												base.ContainerEntries.Add(this.method_11(device_0, rslt, entry_, Color.Yellow));
											}
											foreach (RSLT.Entry entry_2 in rslt.RouteEntries)
											{
												base.RouteEntries.Add(this.method_11(device_0, rslt, entry_2, Color.Green));
											}
											foreach (RSLT.Entry entry_3 in rslt.EffectEntries)
											{
												base.EffectEntries.Add(this.method_11(device_0, rslt, entry_3, Color.Pink));
											}
											foreach (RSLT.Entry entry_4 in rslt.KinematicEntries)
											{
												base.KinematicEntries.Add(this.method_11(device_0, rslt, entry_4, Color.Olive));
											}
										}
									}
								}
							}
						}
					}
				}
			}
		}

		// Token: 0x06000C3B RID: 3131 RVA: 0x0009B568 File Offset: 0x00099768
		private void method_19(Device device_0, MODLModel modlmodel_0, int int_1)
		{
			if (modlmodel_0 != null)
			{
				foreach (RCOLItem rcolitem in modlmodel_0.Entries)
				{
					if (rcolitem.GetType().Equals(typeof(MODL)))
					{
						MODL modl = rcolitem as MODL;
						foreach (MODL.MODLEntry modlentry in modl.Entries)
						{
							if (modlentry.IndexType == 12288)
							{
								RCOLFileEntry rcolfileEntry = modlmodel_0.ExternalResources[modlentry.Index - 1];
								RCOL rcol = Class132.mainForm.CurrentProject.Package.GetEntry(rcolfileEntry.ResKey) as RCOL;
								this.method_20(modlentry, rcol, rcol.Entries[0] as MLOD, (Lod)modlentry.LOD, device_0);
							}
							else
							{
								MLOD mlod_ = modlmodel_0.Entries[modlentry.Index - 1] as MLOD;
								this.method_20(modlentry, modlmodel_0, mlod_, (Lod)modlentry.LOD, device_0);
							}
						}
					}
				}
			}
		}

		// Token: 0x06000C3C RID: 3132 RVA: 0x0009B6D4 File Offset: 0x000998D4
		private void method_20(MODL.MODLEntry modlentry_0, RCOL rcol_0, MLOD mlod_0, Lod lod_1, Device device_0)
		{
			this.imethod_14();
			foreach (MLOD.MLODEntry mlodentry in mlod_0.Entries)
			{
				Class121 @class = new Class121(device_0, lod_1, mlod_0, mlodentry);
				foreach (uint item in @class.MLODEntry.Bones)
				{
					if (!base.Bones.Contains(item))
					{
						base.Bones.Add(item);
					}
				}
				base.Objects.Add(mlodentry, @class);
			}
		}

		// Token: 0x06000C3D RID: 3133 RVA: 0x0008AA84 File Offset: 0x00088C84
		public static Vector3 smethod_0(Vector3 vector3_0, Vector3 vector3_1, float float_2)
		{
			return Vector3.Lerp(vector3_0, vector3_1, (float)((double)(float_2 / Vector3.Distance(vector3_0, vector3_1))));
		}

		// Token: 0x06000C3E RID: 3134 RVA: 0x0009B7A0 File Offset: 0x000999A0
		public override Vector3[] imethod_13()
		{
			Vector3[] array = new Vector3[]
			{
				new Vector3(float.MaxValue, float.MaxValue, float.MaxValue),
				new Vector3(float.MinValue, float.MinValue, float.MinValue)
			};
			foreach (Interface9 @interface in base.Objects.Values)
			{
				Class121 @class = (Class121)@interface;
				if (@class.LOD == this.LODLevel)
				{
					array[0].X = Math.Min(array[0].X, @class.MLODEntry.BoundingBox[0]);
					array[0].Y = Math.Min(array[0].Y, @class.MLODEntry.BoundingBox[1]);
					array[0].Z = Math.Min(array[0].Z, @class.MLODEntry.BoundingBox[2]);
					array[1].X = Math.Max(array[1].X, @class.MLODEntry.BoundingBox[3]);
					array[1].Y = Math.Max(array[1].Y, @class.MLODEntry.BoundingBox[4]);
					array[1].Z = Math.Max(array[1].Z, @class.MLODEntry.BoundingBox[5]);
				}
			}
			return array;
		}

		// Token: 0x06000C3F RID: 3135 RVA: 0x0009B964 File Offset: 0x00099B64
		public override Image vmethod_4(Device device_0, XmlDocument xmlDocument_1, Size size_0)
		{
			this.vmethod_3(xmlDocument_1);
			Vector3 cameraPosition = Class132.smethod_0().CameraPosition;
			Vector3 cameraTarget = Class132.smethod_0().CameraTarget;
			Matrix cameraTranslation = Class132.smethod_0().CameraTranslation;
			Quaternion currentQuaternion = Class132.smethod_0().ArcBall.CurrentQuaternion;
			Surface renderTarget = device_0.GetRenderTarget(0);
			Texture texture = Class132.smethod_0().method_4(new Size(1024, 1024));
			Surface surfaceLevel = texture.GetSurfaceLevel(0);
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
			this.method_21(this.matrix_0, Class132.smethod_0().ViewMatrix, device_0, true);
			device_0.EndScene();
			device_0.DepthStencilSurface = depthStencilSurface;
			device_0.SetRenderTarget(0, renderTarget);
			surface.Dispose();
			DataStream dataStream = BaseTexture.ToStream(texture, ImageFileFormat.Bmp);
			Image image = Image.FromStream(dataStream);
			Image thumbnailImage = image.GetThumbnailImage(size_0.Width, size_0.Height, new Image.GetThumbnailImageAbort(base.method_2), IntPtr.Zero);
			image.Dispose();
			dataStream.Dispose();
			texture.Dispose();
			Class132.smethod_0().CameraPosition = cameraPosition;
			Class132.smethod_0().CameraTarget = cameraTarget;
			Class132.smethod_0().CameraTranslation = cameraTranslation;
			Class132.smethod_0().ArcBall.CurrentQuaternion = currentQuaternion;
			return thumbnailImage;
		}

		// Token: 0x06000C40 RID: 3136 RVA: 0x0009BBE0 File Offset: 0x00099DE0
		public override void vmethod_6(Matrix matrix_1, Matrix matrix_2, Device device_0)
		{
			this.matrix_0 = matrix_1;
			Class140.smethod_0().method_9(RenderState.ZWriteEnable, true);
			Class140.smethod_0().method_9(RenderState.Lighting, true);
			device_0.SetTransform(TransformState.World, matrix_1);
			Class140.smethod_0().method_13(this.int_0);
			bool displayWall = base.DisplayWall;
			foreach (Interface9 @interface in base.Objects.Values)
			{
				Class121 @class = (Class121)@interface;
				if (@class.LOD == this.lod_0)
				{
					Class140.smethod_0().method_14(this._diffuseTexture);
					Class140.smethod_0().method_19(this._specularTexture);
					@class.method_11(device_0, matrix_1, matrix_2, false, true);
				}
			}
		}

		// Token: 0x06000C41 RID: 3137 RVA: 0x0009BCC8 File Offset: 0x00099EC8
		public override void vmethod_5(Matrix matrix_1, Device device_0)
		{
			foreach (Interface9 @interface in base.Objects.Values)
			{
				Class121 @class = (Class121)@interface;
				if (@class.LOD == this.lodLevel)
				{
					@class.method_9(device_0, matrix_1);
				}
			}
		}

		// Token: 0x06000C42 RID: 3138 RVA: 0x00007022 File Offset: 0x00005222
		public override void imethod_0(Matrix matrix_1, Matrix matrix_2, Device device_0)
		{
			this.method_21(matrix_1, matrix_2, device_0, false);
		}

		// Token: 0x06000C43 RID: 3139 RVA: 0x0009BD38 File Offset: 0x00099F38
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

		// Token: 0x06000C44 RID: 3140 RVA: 0x0009BEEC File Offset: 0x0009A0EC
		public override void vmethod_0(Device device_0, Matrix matrix_1)
		{
			if (this.Objd.Version >= 23U)
			{
				Class140.smethod_0().method_9(RenderState.SpecularEnable, false);
				device_0.SetStreamSource(0, this.vertexBuffer_1, 0, Class112.Struct7.SizeInBytes);
				Class140.smethod_0().method_9(RenderState.Lighting, true);
				Class140.smethod_0().method_9(RenderState.AlphaTestEnable, true);
				Class140.smethod_0().method_9(RenderState.AlphaFunc, Compare.Equal);
				Class140.smethod_0().method_9(RenderState.AlphaRef, 255);
				Material material_ = default(Material);
				material_.Diffuse = Color.FromArgb(255, Color.White);
				material_.Specular = Color.FromArgb(127, 127, 127, 127);
				material_.Power = 0f;
				Class140.smethod_0().method_32(Matrix.Translation(0f, 0f, 0f) * Matrix.RotationY((float)(this.IsDiagonal ? 45 : 0) * 0.017453292f) * matrix_1, Class132.smethod_0().ViewMatrix);
				Class140.smethod_0().method_40("ObjectFloor");
				Class140.smethod_0().method_34(false);
				Class132.smethod_0().method_29(material_);
				Class140.smethod_0().method_14(this.texture_1);
				Class140.smethod_0().method_19(null);
				Class140.smethod_0().method_9(RenderState.ZWriteEnable, false);
				Class140.smethod_0().method_9(RenderState.AlphaBlendEnable, false);
				int num = Class140.smethod_0().method_36();
				for (int i = 0; i < num; i++)
				{
					Class140.smethod_0().method_38(i);
					device_0.DrawPrimitives(PrimitiveType.TriangleList, 0, 2);
					Class140.smethod_0().method_39();
				}
				Class140.smethod_0().method_37();
				Class140.smethod_0().method_32(matrix_1, Class132.smethod_0().ViewMatrix);
			}
		}

		// Token: 0x06000C45 RID: 3141 RVA: 0x0009C0D0 File Offset: 0x0009A2D0
		public void method_21(Matrix matrix_1, Matrix matrix_2, Device device_0, bool bool_11)
		{
			this.matrix_0 = matrix_1;
			if (!bool_11)
			{
				base.method_1(device_0, matrix_1);
			}
			Class140.smethod_0().method_9(RenderState.ZWriteEnable, true);
			Class140.smethod_0().method_9(RenderState.Lighting, true);
			device_0.SetTransform(TransformState.World, matrix_1);
			Class140.smethod_0().method_13(this.int_0);
			if (base.DisplayWall && this.bool_8 && !bool_11)
			{
				if (this.bool_7)
				{
					this.method_15(device_0);
				}
				this.bool_7 = false;
				Class140.smethod_0().method_10();
				Class140.smethod_0().method_9(RenderState.AlphaBlendEnable, true);
				Class140.smethod_0().method_9(RenderState.AlphaTestEnable, false);
				Class140.smethod_0().method_9(RenderState.SpecularEnable, false);
				device_0.SetStreamSource(0, this.vertexBuffer_0, 0, Class112.Struct7.SizeInBytes);
				Class140.smethod_0().method_9(RenderState.Lighting, true);
				Class140.smethod_0().method_9(RenderState.AlphaTestEnable, true);
				Class140.smethod_0().method_9(RenderState.AlphaFunc, Compare.Equal);
				Class140.smethod_0().method_9(RenderState.AlphaRef, 255);
				Material material_ = default(Material);
				material_.Diffuse = Color.FromArgb(255, Color.White);
				material_.Specular = Color.FromArgb(127, 127, 127, 127);
				material_.Power = 0f;
				Class132.smethod_0();
				Class140.smethod_0().method_32(Matrix.Translation(0f, 0f, 0f) * Matrix.RotationY((float)(this.IsDiagonal ? 0 : 0) * 0.017453292f) * Matrix.Translation(0f, 0f, this.IsDiagonal ? 0f : -0.426f) * matrix_1, matrix_2);
				Class140.smethod_0().method_25("g_mObjTrans", Matrix.Translation(0f, 0f, 0f) * Matrix.RotationY((float)(this.IsDiagonal ? 0 : 0) * 0.017453292f) * Matrix.Translation(0f, 0f, this.IsDiagonal ? 0f : -0.426f));
				Class140.smethod_0().method_40("ObjectWall");
				Class140.smethod_0().method_9(RenderState.ZWriteEnable, true);
				Class140.smethod_0().method_34(false);
				Class132.smethod_0().method_29(material_);
				Class140.smethod_0().method_14(this.texture_0);
				Class140.smethod_0().method_19(null);
				Class140.smethod_0().method_9(RenderState.CullMode, Cull.None);
				int num = Class140.smethod_0().method_36();
				for (int i = 0; i < num; i++)
				{
					Class140.smethod_0().method_38(i);
					Class140.smethod_0().method_32(Matrix.Translation(0f, 0f, 0.074f) * Matrix.RotationY((float)(this.IsDiagonal ? 45 : 0) * 0.017453292f) * Matrix.Translation(0f, 0f, this.IsDiagonal ? 0f : -0.5f) * matrix_1, matrix_2);
					Class140.smethod_0().method_25("g_mObjTrans", Matrix.Translation(0f, 0f, 0f) * Matrix.RotationY((float)(this.IsDiagonal ? 45 : 0) * 0.017453292f) * Matrix.Translation(0f, 0f, this.IsDiagonal ? 0f : -0.426f));
					Class140.smethod_0().method_35();
					device_0.DrawPrimitives(PrimitiveType.TriangleList, 0, 2);
					Class140.smethod_0().method_32(Matrix.Translation(0f, 0f, -0.074f) * Matrix.RotationY((float)(this.IsDiagonal ? 45 : 0) * 0.017453292f) * Matrix.Translation(0f, 0f, this.IsDiagonal ? 0f : -0.5f) * matrix_1, matrix_2);
					Class140.smethod_0().method_39();
				}
				Class140.smethod_0().method_37();
			}
			Class140.smethod_0().method_32(matrix_1, matrix_2);
			foreach (Interface9 @interface in base.Objects.Values)
			{
				Class121 @class = (Class121)@interface;
				if (@class.LOD == this.lodLevel || @class.LOD == this.lod_0)
				{
					if (this.objd.Materials.Count == 0 && @class.DiffuseMap == null)
					{
						Class140.smethod_0().method_27("useTexture", false);
					}
					else
					{
						Class140.smethod_0().method_27("useTexture", true);
					}
					Class140.smethod_0().method_14((this.objd.Materials.Count == 0 || @class.DiffuseMapIsDDS) ? @class.DiffuseMap : this._diffuseTexture);
					Class140.smethod_0().method_19((this.objd.Materials.Count == 0 || @class.SpecularMapIsDDS) ? @class.SpecularMap : this._specularTexture);
					@class.method_10(device_0, matrix_1, matrix_2, bool_11);
				}
			}
			if (!bool_11)
			{
				base.method_0(device_0, matrix_1);
			}
		}

		// Token: 0x1700026A RID: 618
		// (get) Token: 0x06000C46 RID: 3142 RVA: 0x0009C654 File Offset: 0x0009A854
		// (set) Token: 0x06000C47 RID: 3143 RVA: 0x00007030 File Offset: 0x00005230
		public XmlDocument CurrentPreset { get; set; }

		// Token: 0x06000C48 RID: 3144 RVA: 0x0009C66C File Offset: 0x0009A86C
		public override void vmethod_3(XmlDocument xmlDocument_1)
		{
			if (xmlDocument_1 != null)
			{
				Size size_ = this.vmethod_1();
				if (this._diffuseTexture != null)
				{
					this._diffuseTexture.Dispose();
				}
				if (this._specularTexture != null)
				{
					this._specularTexture.Dispose();
				}
				Texture texture = Class132.smethod_0().method_4(size_);
				this.interface3_0.imethod_1(size_);
				if (!Class132.smethod_0().method_15(this.interface3_0, xmlDocument_1, "DiffuseMap", (xmlDocument_1.SelectNodes("preset/complate/value[@key='partType']").Item(0) as XmlElement).GetAttribute("value"), texture))
				{
					MessageBox.Show("Error when rendering complate: " + this.interface3_0.Errors);
				}
				else
				{
					DataStream dataStream = BaseTexture.ToStream(texture, ImageFileFormat.Png);
					this._diffuseTexture = Texture.FromStream(Class140.smethod_0().Device, dataStream);
					dataStream.Dispose();
				}
				texture.Dispose();
				Texture texture2 = Class132.smethod_0().method_4(size_);
				if (!Class132.smethod_0().method_15(this.interface3_0, xmlDocument_1, "SpecMap", (xmlDocument_1.SelectNodes("preset/complate/value[@key='partType']").Item(0) as XmlElement).GetAttribute("value"), texture2))
				{
					MessageBox.Show("Error when rendering complate: " + this.interface3_0.Errors);
				}
				else
				{
					DataStream dataStream2 = BaseTexture.ToStream(texture2, ImageFileFormat.Png);
					this._specularTexture = Texture.FromStream(Class140.smethod_0().Device, dataStream2);
					dataStream2.Dispose();
				}
				texture2.Dispose();
				this.CurrentPreset = xmlDocument_1;
			}
		}

		// Token: 0x06000C49 RID: 3145 RVA: 0x0000703B File Offset: 0x0000523B
		public override void imethod_1(bool bool_11)
		{
			this.bool_5 = bool_11;
		}

		// Token: 0x06000C4A RID: 3146 RVA: 0x0009C7E0 File Offset: 0x0009A9E0
		public override bool imethod_2()
		{
			return this.bool_5;
		}

		// Token: 0x06000C4B RID: 3147 RVA: 0x00007046 File Offset: 0x00005246
		public override void imethod_3(bool bool_11)
		{
			this.bool_6 = bool_11;
		}

		// Token: 0x06000C4C RID: 3148 RVA: 0x0009C7F8 File Offset: 0x0009A9F8
		public override bool imethod_4()
		{
			return this.bool_6;
		}

		// Token: 0x06000C4D RID: 3149 RVA: 0x0009C810 File Offset: 0x0009AA10
		public unsafe List<Class102.Class108> method_22(Bitmap bitmap_1, Viewport viewport_0, Matrix matrix_1, Matrix matrix_2, Matrix matrix_3, int int_1, Point[] point_0, int int_2)
		{
			float num = float.MinValue;
			float num2 = float.MaxValue;
			float num3 = float.MinValue;
			float num4 = float.MaxValue;
			foreach (Point point in point_0)
			{
				num = Math.Max(num, (float)point.X);
				num2 = Math.Min(num2, (float)point.X);
				num3 = Math.Max(num3, (float)point.Y);
				num4 = Math.Min(num2, (float)point.Y);
			}
			List<Class102.Class108> list = new List<Class102.Class108>();
			foreach (Interface9 @interface in base.Objects.Values)
			{
				Class121 @class = (Class121)@interface;
				if (@class.Visible)
				{
					DataStream dataStream = @class.IndexBuffer.Lock(0, 0, LockFlags.None);
					DataStream dataStream2 = @class.VertexBuffer.Lock(0, 0, LockFlags.None);
					short* ptr = (short*)((void*)dataStream.DataPointer);
					Class112.Struct7* ptr2 = (Class112.Struct7*)((void*)dataStream2.DataPointer);
					Class102.Class108 class2 = new Class102.Class108(@class);
					for (int j = 0; j < @class.MLODEntry.FaceCount * 3; j += 3)
					{
						short num5 = ptr[((long)j + @class.MLODEntry.IBUFOffset) * 2L / 2L];
						short num6 = ptr[((long)(j + 1) + @class.MLODEntry.IBUFOffset) * 2L / 2L];
						short num7 = ptr[((long)(j + 2) + @class.MLODEntry.IBUFOffset) * 2L / 2L];
						Class112.Struct7 @struct = ptr2[num5];
						Class112.Struct7 struct2 = ptr2[num6];
						Class112.Struct7 struct3 = ptr2[num7];
						Vector3 vector = Vector3.Project(@struct.position, (float)viewport_0.X, (float)viewport_0.Y, (float)viewport_0.Width, (float)viewport_0.Height, viewport_0.MinZ, viewport_0.MaxZ, matrix_3 * matrix_2 * matrix_1);
						Vector3 vector2 = Vector3.Project(struct2.position, (float)viewport_0.X, (float)viewport_0.Y, (float)viewport_0.Width, (float)viewport_0.Height, viewport_0.MinZ, viewport_0.MaxZ, matrix_3 * matrix_2 * matrix_1);
						Vector3 vector3 = Vector3.Project(struct3.position, (float)viewport_0.X, (float)viewport_0.Y, (float)viewport_0.Width, (float)viewport_0.Height, viewport_0.MinZ, viewport_0.MaxZ, matrix_3 * matrix_2 * matrix_1);
						if (int_1 == 2)
						{
							int num8 = -1;
							int num9 = -1;
							int num10 = -1;
							if (vector.X < (float)bitmap_1.Width && vector.Y < (float)bitmap_1.Height && vector.Y >= 0f && vector.X >= 0f)
							{
								num8 = bitmap_1.GetPixel((int)vector.X, (int)vector.Y).ToArgb();
							}
							if (vector2.X < (float)bitmap_1.Width && vector2.Y < (float)bitmap_1.Height && vector2.Y >= 0f && vector2.X >= 0f)
							{
								num9 = bitmap_1.GetPixel((int)vector2.X, (int)vector2.Y).ToArgb();
							}
							if (vector3.X < (float)bitmap_1.Width && vector3.Y < (float)bitmap_1.Height && vector3.Y >= 0f && vector3.X >= 0f)
							{
								num10 = bitmap_1.GetPixel((int)vector3.X, (int)vector3.Y).ToArgb();
							}
							if (num8 != -1 && num9 != -1 && num10 != -1)
							{
								Class102.Class107 class3 = new Class102.Class107();
								class3.short_0 = num5;
								class3.short_1 = num6;
								class3.short_2 = num7;
								class3.vector3_0 = @struct.position;
								class3.vector3_1 = struct2.position;
								class3.vector3_2 = struct3.position;
								class3.vector2_0 = new Vector2(vector.X, vector.Y);
								class3.vector2_1 = new Vector2(vector2.X, vector2.Y);
								class3.vector2_2 = new Vector2(vector3.X, vector3.Y);
								if (int_2 == 0)
								{
									Vector2 vector4 = new Vector2(vector3.X - vector.X, vector3.Y - vector.Y);
									Vector2 vector5 = new Vector2(vector3.X - vector2.X, vector3.Y - vector2.Y);
									float num11 = vector4.X * vector5.Y - vector4.Y * vector5.X;
									if (num11 < 0f)
									{
										class2.SelectedFaces.Add(class3);
										if (!list.Contains(class2))
										{
											list.Add(class2);
										}
									}
								}
								else
								{
									class2.SelectedFaces.Add(class3);
									if (!list.Contains(class2))
									{
										list.Add(class2);
									}
								}
							}
						}
						else if (int_1 == 1)
						{
							Rectangle rectangle = new Rectangle((int)num2, (int)num4, (int)(num - num2), (int)(num3 - num4));
							int k = 0;
							while (k < point_0.Length)
							{
								Point point2 = point_0[k];
								bool flag = rectangle.Contains(new Point((int)vector.X, (int)vector.Y));
								bool flag2 = rectangle.Contains(new Point((int)vector2.X, (int)vector2.Y));
								bool flag3 = rectangle.Contains(new Point((int)vector3.X, (int)vector3.Y));
								if (!flag || !flag2)
								{
								}
								if (Class117.smethod_5(new Vector3((float)point2.X, (float)point2.Y, vector.Z), new Vector3[]
								{
									vector,
									vector2,
									vector3
								}) == 0 && (!flag || !flag2 || !flag3))
								{
									k++;
								}
								else
								{
									Class102.Class107 class4 = new Class102.Class107();
									class4.short_0 = num5;
									class4.short_1 = num6;
									class4.short_2 = num7;
									class4.vector3_0 = @struct.position;
									class4.vector3_1 = struct2.position;
									class4.vector3_2 = struct3.position;
									class4.vector2_0 = new Vector2(vector.X, vector.Y);
									class4.vector2_1 = new Vector2(vector2.X, vector2.Y);
									class4.vector2_2 = new Vector2(vector3.X, vector3.Y);
									if (int_2 == 0)
									{
										Vector2 vector6 = new Vector2(vector3.X - vector.X, vector3.Y - vector.Y);
										Vector2 vector7 = new Vector2(vector3.X - vector2.X, vector3.Y - vector2.Y);
										float num12 = vector6.X * vector7.Y - vector6.Y * vector7.X;
										if (num12 >= 0f)
										{
											break;
										}
										class2.SelectedFaces.Add(class4);
										if (!list.Contains(class2))
										{
											list.Add(class2);
											break;
										}
										break;
									}
									else
									{
										class2.SelectedFaces.Add(class4);
										if (!list.Contains(class2))
										{
											list.Add(class2);
											break;
										}
										break;
									}
								}
							}
						}
					}
					@class.IndexBuffer.Unlock();
					@class.VertexBuffer.Unlock();
				}
			}
			return list;
		}

		// Token: 0x06000C4E RID: 3150 RVA: 0x0009D038 File Offset: 0x0009B238
		public unsafe List<Class102.Class108> method_23(Vector3 vector3_0, Vector3 vector3_1, Viewport viewport_0, Matrix matrix_1, Matrix matrix_2, Matrix matrix_3, int int_1, Point[] point_0, int int_2)
		{
			float num = 0f;
			Ray ray = new Ray(vector3_0, vector3_1);
			List<Class102.Class108> list = new List<Class102.Class108>();
			foreach (Interface9 @interface in base.Objects.Values)
			{
				Class121 @class = (Class121)@interface;
				if (@class.Visible && (Class132.smethod_0().SelectionDialog == null || (Class132.mainForm.CurrentProjectModel as Class80).Control.MLODPropertyGrid.MLODRenderable == @class))
				{
					DataStream dataStream = @class.IndexBuffer.Lock(0, 0, LockFlags.None);
					DataStream dataStream2 = @class.VertexBuffer.Lock(0, 0, LockFlags.None);
					short* ptr = (short*)((void*)dataStream.DataPointer);
					Class112.Struct7* ptr2 = (Class112.Struct7*)((void*)dataStream2.DataPointer);
					Class102.Class108 class2 = new Class102.Class108(@class);
					for (long num2 = 0L; num2 < (long)(@class.MLODEntry.FaceCount * 3); num2 += 3L)
					{
						short num3 = ptr[(num2 + @class.MLODEntry.IBUFOffset) * 2L / 2L];
						short num4 = ptr[(num2 + 1L + @class.MLODEntry.IBUFOffset) * 2L / 2L];
						short num5 = ptr[(num2 + 2L + @class.MLODEntry.IBUFOffset) * 2L / 2L];
						Class112.Struct7 @struct = ptr2[num3];
						Class112.Struct7 struct2 = ptr2[num4];
						Class112.Struct7 struct3 = ptr2[num5];
						if (Ray.Intersects(ray, @struct.position, struct2.position, struct3.position, out num))
						{
							Class102.Class107 class3 = new Class102.Class107();
							Vector3 vector = Vector3.Project(@struct.position, (float)viewport_0.X, (float)viewport_0.Y, (float)viewport_0.Width, (float)viewport_0.Height, viewport_0.MinZ, viewport_0.MaxZ, matrix_3 * matrix_2 * matrix_1);
							Vector3 vector2 = Vector3.Project(struct2.position, (float)viewport_0.X, (float)viewport_0.Y, (float)viewport_0.Width, (float)viewport_0.Height, viewport_0.MinZ, viewport_0.MaxZ, matrix_3 * matrix_2 * matrix_1);
							Vector3 vector3 = Vector3.Project(struct3.position, (float)viewport_0.X, (float)viewport_0.Y, (float)viewport_0.Width, (float)viewport_0.Height, viewport_0.MinZ, viewport_0.MaxZ, matrix_3 * matrix_2 * matrix_1);
							class3.short_0 = num3;
							class3.short_1 = num4;
							class3.short_2 = num5;
							class3.vector3_0 = @struct.position;
							class3.vector3_1 = struct2.position;
							class3.vector3_2 = struct3.position;
							class3.vector2_0 = new Vector2(vector.X, vector.Y);
							class3.vector2_1 = new Vector2(vector2.X, vector2.Y);
							class3.vector2_2 = new Vector2(vector3.X, vector3.Y);
							class3.float_0 = num;
							if (int_2 == 0)
							{
								Vector2 vector4 = new Vector2(vector3.X - vector.X, vector3.Y - vector.Y);
								Vector2 vector5 = new Vector2(vector3.X - vector2.X, vector3.Y - vector2.Y);
								float num6 = vector4.X * vector5.Y - vector4.Y * vector5.X;
								if (num6 > 0f)
								{
									goto IL_3C6;
								}
							}
							if (!class2.SelectedFaces.Contains(class3))
							{
								class2.SelectedFaces.Add(class3);
							}
							if (!list.Contains(class2))
							{
								list.Add(class2);
							}
						}
						IL_3C6:;
					}
					@class.IndexBuffer.Unlock();
					@class.VertexBuffer.Unlock();
				}
			}
			return list;
		}

		// Token: 0x04000962 RID: 2402
		private bool bool_5;

		// Token: 0x04000963 RID: 2403
		private bool bool_6;

		// Token: 0x04000964 RID: 2404
		private OBJD objd;

		// Token: 0x04000965 RID: 2405
		private Interface3 interface3_0;

		// Token: 0x04000966 RID: 2406
		private Lod lodLevel;

		// Token: 0x04000967 RID: 2407
		private Lod lod_0;

		// Token: 0x04000968 RID: 2408
		private Color color_0 = Color.OliveDrab;

		// Token: 0x04000969 RID: 2409
		private bool bool_7;

		// Token: 0x0400096A RID: 2410
		private bool bool_8;

		// Token: 0x0400096B RID: 2411
		public VertexBuffer vertexBuffer_0;

		// Token: 0x0400096C RID: 2412
		public Texture texture_0;

		// Token: 0x0400096D RID: 2413
		private float float_0;

		// Token: 0x0400096E RID: 2414
		private float float_1;

		// Token: 0x0400096F RID: 2415
		public VertexBuffer vertexBuffer_1;

		// Token: 0x04000970 RID: 2416
		public Texture texture_1;

		// Token: 0x04000971 RID: 2417
		private int int_0;

		// Token: 0x04000972 RID: 2418
		private Class28 class28_0;

		// Token: 0x04000973 RID: 2419
		private ResKey resKey_0;

		// Token: 0x04000974 RID: 2420
		private S_CLIP s_CLIP_0;

		// Token: 0x04000975 RID: 2421
		private Matrix matrix_0;

		// Token: 0x04000976 RID: 2422
		[CompilerGenerated]
		private Texture texture_2;

		// Token: 0x04000977 RID: 2423
		[CompilerGenerated]
		private Texture texture_3;

		// Token: 0x04000978 RID: 2424
		[CompilerGenerated]
		private bool bool_9;

		// Token: 0x04000979 RID: 2425
		[CompilerGenerated]
		private List<DDS> list_10;

		// Token: 0x0400097A RID: 2426
		[CompilerGenerated]
		private bool bool_10;

		// Token: 0x0400097B RID: 2427
		[CompilerGenerated]
		private Bitmap bitmap_0;

		// Token: 0x0400097C RID: 2428
		[CompilerGenerated]
		private XmlDocument xmlDocument_0;
	}
}
