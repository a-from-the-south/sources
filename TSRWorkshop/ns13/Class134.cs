using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using ns10;
using ns12;
using ns15;
using ns16;
using ns18;
using ns2;
using ns21;
using ns3;
using ns6;
using ns7;
using ns8;
using Package.Sims3Files;
using Package.Sims3Files.InternalRCOL;
using Sims3WorkshopSDK.Classes;
using Sims3WorkshopSDK.Interfaces;
using SlimDX;
using SlimDX.Direct3D9;

namespace ns13
{
	// Token: 0x0200011F RID: 287
	internal sealed class Class134 : Class133, EditorToolBox.Interface0
	{
		// Token: 0x06000CEA RID: 3306 RVA: 0x000A0FE8 File Offset: 0x0009F1E8
		private Class134(Device device)
		{
			bool[] array = new bool[3];
			this.bool_0 = array;
			base..ctor();
			this.point_0 = default(Point);
			Bitmap bitmap = new Bitmap(32, 32);
			Graphics graphics = Graphics.FromImage(bitmap);
			graphics.DrawArc(Pens.Red, new Rectangle(0, 0, 32, 32), 0f, 360f);
			MemoryStream memoryStream = new MemoryStream();
			bitmap.Save(memoryStream, ImageFormat.Bmp);
			memoryStream.Position = 0L;
			this.texture_1 = Texture.FromStream(device, memoryStream, Usage.None, Pool.Managed);
			memoryStream.Dispose();
			bitmap.Dispose();
			graphics.Dispose();
		}

		// Token: 0x06000CEB RID: 3307 RVA: 0x000A108C File Offset: 0x0009F28C
		public static Class134 smethod_0()
		{
			if (Class134.class134_0 == null)
			{
				Class134.class134_0 = new Class134(Class132.smethod_0().Device);
				Class134.boneWeightControl_0 = new BoneWeightControl();
			}
			return Class134.class134_0;
		}

		// Token: 0x06000CEC RID: 3308 RVA: 0x000A10C8 File Offset: 0x0009F2C8
		public override void imethod_4()
		{
			Class134.boneWeightControl_0.Parent = EditorToolBox.smethod_0().Container;
			Class134.boneWeightControl_0.Dock = DockStyle.Fill;
			Class134.boneWeightControl_0.SendToBack();
			Class134.boneWeightControl_0.method_3();
			Class134.boneWeightControl_0.Visible = true;
		}

		// Token: 0x06000CED RID: 3309 RVA: 0x0000735E File Offset: 0x0000555E
		public override void imethod_5()
		{
			Class134.boneWeightControl_0.Visible = false;
		}

		// Token: 0x06000CEE RID: 3310 RVA: 0x000A1118 File Offset: 0x0009F318
		public unsafe override void vmethod_1()
		{
			foreach (KeyValuePair<Class33, Class134.Class139> keyValuePair in Class134.dictionary_0)
			{
				Class33 key = keyValuePair.Key;
				Vector3 vector = Vector3.Zero;
				Vector3 vector2 = new Vector3(0f, 0.05f, 0f);
				Vector3 vector3 = new Vector3(-0.01f, 0.01f, -0.01f);
				Vector3 vector4 = new Vector3(0.01f, 0.01f, -0.01f);
				Vector3 vector5 = new Vector3(0f, 0.01f, 0.01f);
				key.OffsetMatrix.Invert();
				Matrix combinedBoneTransformationMatrix = key.CombinedBoneTransformationMatrix;
				vector = Vector3.TransformCoordinate(vector, combinedBoneTransformationMatrix);
				keyValuePair.Value.BallOffsetMatrix = combinedBoneTransformationMatrix;
				DataStream dataStream = keyValuePair.Value.VertexBuffer.Lock(0, 0, LockFlags.None);
				Class112.Struct7* ptr = (Class112.Struct7*)((void*)dataStream.DataPointer);
				if (key.ChildBones.Count > 0)
				{
					keyValuePair.Value.ChildBoneCount = 0;
					for (int i = 0; i < key.ChildBones.Count; i++)
					{
						Class33 @class = key.ChildBones[i];
						if (Class134.dictionary_0.ContainsKey(@class))
						{
							vector2 = Vector3.TransformCoordinate(Vector3.Zero, @class.CombinedBoneTransformationMatrix);
							float num = Vector3.Distance(vector, vector2);
							vector4.Z = (vector3.Z = (vector3.X = -1f * (num / 30f)));
							vector5.Z = (vector4.X = 1f * (num / 30f));
							vector5.Y = (vector4.Y = (vector3.Y = 1f * (num / 20f)));
							vector5.X = 0f;
							vector3 = Vector3.TransformCoordinate(vector3, combinedBoneTransformationMatrix);
							vector4 = Vector3.TransformCoordinate(vector4, combinedBoneTransformationMatrix);
							vector5 = Vector3.TransformCoordinate(vector5, combinedBoneTransformationMatrix);
							int num2 = keyValuePair.Value.ChildBoneCount * 21;
							ptr[num2].position = (ptr[(IntPtr)(num2++) * (IntPtr)sizeof(Class112.Struct7)].normal = vector5);
							ptr[num2].position = (ptr[(IntPtr)(num2++) * (IntPtr)sizeof(Class112.Struct7)].normal = vector4);
							ptr[num2].position = (ptr[(IntPtr)(num2++) * (IntPtr)sizeof(Class112.Struct7)].normal = vector3);
							ptr[num2].position = (ptr[(IntPtr)(num2++) * (IntPtr)sizeof(Class112.Struct7)].normal = vector3);
							ptr[num2].position = (ptr[(IntPtr)(num2++) * (IntPtr)sizeof(Class112.Struct7)].normal = vector4);
							ptr[num2].position = (ptr[(IntPtr)(num2++) * (IntPtr)sizeof(Class112.Struct7)].normal = vector2);
							ptr[num2].position = (ptr[(IntPtr)(num2++) * (IntPtr)sizeof(Class112.Struct7)].normal = vector4);
							ptr[num2].position = (ptr[(IntPtr)(num2++) * (IntPtr)sizeof(Class112.Struct7)].normal = vector5);
							ptr[num2].position = (ptr[(IntPtr)(num2++) * (IntPtr)sizeof(Class112.Struct7)].normal = vector2);
							ptr[num2].position = (ptr[(IntPtr)(num2++) * (IntPtr)sizeof(Class112.Struct7)].normal = vector5);
							ptr[num2].position = (ptr[(IntPtr)(num2++) * (IntPtr)sizeof(Class112.Struct7)].normal = vector3);
							ptr[num2].position = (ptr[(IntPtr)(num2++) * (IntPtr)sizeof(Class112.Struct7)].normal = vector2);
							ptr[num2].position = (ptr[(IntPtr)(num2++) * (IntPtr)sizeof(Class112.Struct7)].normal = vector);
							ptr[num2].position = (ptr[(IntPtr)(num2++) * (IntPtr)sizeof(Class112.Struct7)].normal = vector4);
							ptr[num2].position = (ptr[(IntPtr)(num2++) * (IntPtr)sizeof(Class112.Struct7)].normal = vector3);
							ptr[num2].position = (ptr[(IntPtr)(num2++) * (IntPtr)sizeof(Class112.Struct7)].normal = vector);
							ptr[num2].position = (ptr[(IntPtr)(num2++) * (IntPtr)sizeof(Class112.Struct7)].normal = vector3);
							ptr[num2].position = (ptr[(IntPtr)(num2++) * (IntPtr)sizeof(Class112.Struct7)].normal = vector5);
							ptr[num2].position = (ptr[(IntPtr)(num2++) * (IntPtr)sizeof(Class112.Struct7)].normal = vector);
							ptr[num2].position = (ptr[(IntPtr)(num2++) * (IntPtr)sizeof(Class112.Struct7)].normal = vector5);
							ptr[num2].position = (ptr[(IntPtr)(num2++) * (IntPtr)sizeof(Class112.Struct7)].normal = vector4);
							keyValuePair.Value.ChildBoneCount++;
						}
					}
				}
				keyValuePair.Value.VertexBuffer.Unlock();
			}
		}

		// Token: 0x06000CEF RID: 3311 RVA: 0x000A1774 File Offset: 0x0009F974
		public override void vmethod_2(IProjectModel iprojectModel_1)
		{
			foreach (KeyValuePair<Class33, Class134.Class139> keyValuePair in Class134.dictionary_0)
			{
				keyValuePair.Value.method_2();
			}
			Class134.dictionary_0.Clear();
			if (iprojectModel_1 is Class68)
			{
				Class104 renderable = (iprojectModel_1 as Class68).Renderable;
				Interface9[] array = Class132.smethod_0().method_45();
				foreach (Class104.Class109 @class in array)
				{
					foreach (uint num in @class.Geom.boneHashes)
					{
						if (@class.Container.GrannyInfo != null)
						{
							Class34 class2 = @class.Container.GrannyInfo.Skeletons[0];
							if (class2.HashedBones.ContainsKey(num))
							{
								Class33 class3 = class2.HashedBones[num] as Class33;
								if (!Class134.dictionary_0.ContainsKey(class3))
								{
									Class134.dictionary_0.Add(class3, new Class134.Class139(class3, Class140.smethod_0().Device));
								}
							}
						}
					}
				}
			}
			else if (iprojectModel_1 is Class80)
			{
				Class105 renderable2 = (iprojectModel_1 as Class80).Renderable;
				Interface9[] array3 = Class132.smethod_0().method_45();
				Interface9[] array4 = array3;
				for (int j = 0; j < array4.Length; j++)
				{
					if (renderable2.GrannyInfo != null)
					{
						Class34 class4 = renderable2.GrannyInfo.Skeletons[0];
						foreach (object key in class4.HashedBones.Keys)
						{
							if (class4.HashedBones.ContainsKey(key))
							{
								Class33 class5 = class4.HashedBones[key] as Class33;
								if (!Class134.dictionary_0.ContainsKey(class5))
								{
									Class134.dictionary_0.Add(class5, new Class134.Class139(class5, Class140.smethod_0().Device));
								}
							}
						}
					}
				}
			}
			this.iprojectModel_0 = iprojectModel_1;
			Class134.class139_0[0] = null;
			Class134.class139_0[1] = null;
			Class134.class139_0[2] = null;
			Class134.class139_0[3] = null;
			this.vmethod_1();
		}

		// Token: 0x06000CF0 RID: 3312 RVA: 0x000A1A10 File Offset: 0x0009FC10
		public override void vmethod_0(bool bool_1)
		{
			base.vmethod_0(bool_1);
			if (bool_1)
			{
				foreach (KeyValuePair<Class33, Class134.Class139> keyValuePair in Class134.dictionary_0)
				{
					keyValuePair.Value.method_2();
				}
				Class134.dictionary_0.Clear();
				this.texture_1.Dispose();
			}
		}

		// Token: 0x06000CF1 RID: 3313 RVA: 0x000A1A8C File Offset: 0x0009FC8C
		public static void smethod_1(uint uint_0, int int_0)
		{
			if (Class134.class139_0[int_0] != null)
			{
				Class134.class139_0[int_0].Selected = false;
				Class134.class139_0[int_0].ContainerIndex = -1;
				Class134.class139_0[int_0] = null;
			}
			foreach (Class134.Class139 @class in Class134.dictionary_0.Values)
			{
				if (FNV32.GetHash(@class.Bone.Sims3WorkshopSDK.Interfaces.IBone.Name) == uint_0)
				{
					Class134.class139_0[int_0] = @class;
					Class134.class139_0[int_0].Selected = true;
					Class134.class139_0[int_0].ContainerIndex = int_0;
					int num = 0;
					for (int i = 0; i < Class134.class139_0.Length; i++)
					{
						if (Class134.class139_0[i] != null)
						{
							num++;
						}
					}
					Class134.boneWeightControl_0.method_1(new uint[]
					{
						(Class134.class139_0[0] == null) ? 0U : FNV32.GetHash(Class134.class139_0[0].Bone.Sims3WorkshopSDK.Interfaces.IBone.Name),
						(Class134.class139_0[1] == null) ? 0U : FNV32.GetHash(Class134.class139_0[1].Bone.Sims3WorkshopSDK.Interfaces.IBone.Name),
						(Class134.class139_0[2] == null) ? 0U : FNV32.GetHash(Class134.class139_0[2].Bone.Sims3WorkshopSDK.Interfaces.IBone.Name),
						(Class134.class139_0[3] == null) ? 0U : FNV32.GetHash(Class134.class139_0[3].Bone.Sims3WorkshopSDK.Interfaces.IBone.Name)
					});
				}
			}
		}

		// Token: 0x06000CF2 RID: 3314 RVA: 0x000A1C24 File Offset: 0x0009FE24
		public unsafe void method_1()
		{
			foreach (Interface9 @interface in Class132.smethod_0().method_45())
			{
				int[] array2 = new int[]
				{
					-1,
					-1,
					-1,
					-1
				};
				int[] array3 = new int[]
				{
					-1,
					-1,
					-1,
					-1
				};
				float[] weights = Class134.boneWeightControl_0.Weights;
				for (int j = 0; j < Class134.class139_0.Length; j++)
				{
					if (Class134.class139_0[j] != null)
					{
						Class33 bone = Class134.class139_0[j].Bone;
						uint hash = FNV32.GetHash(bone.Sims3WorkshopSDK.Interfaces.IBone.Name);
						if (@interface is Class104.Class109)
						{
							array2[j] = (@interface as Class104.Class109).Geom.boneHashes.IndexOf(hash);
							if (array2[j] == -1)
							{
								(@interface as Class104.Class109).Geom.boneHashes.Add(hash);
								(@interface as Class104.Class109).Palette = new Matrix[(@interface as Class104.Class109).Palette.Length + 1];
							}
							array2[j] = (@interface as Class104.Class109).Geom.boneHashes.IndexOf(hash);
						}
						else if (@interface is Class121)
						{
							array2[j] = (@interface as Class121).list_0.IndexOf(hash);
							if (array2[j] == -1)
							{
								(@interface as Class121).list_0.Add(hash);
								(@interface as Class121).Palette = new Matrix[(@interface as Class121).Palette.Length + 1];
							}
							array2[j] = (@interface as Class121).list_0.IndexOf(hash);
							array3[j] = (@interface as Class121).MLODEntry.Bones.IndexOf(hash);
							if (array3[j] == -1)
							{
								(@interface as Class121).MLODEntry.Bones.Add(hash);
								(@interface as Class121).Palette = new Matrix[(@interface as Class121).Palette.Length + 1];
							}
							array3[j] = (@interface as Class121).MLODEntry.Bones.IndexOf(hash);
						}
					}
				}
				if (@interface is Class121)
				{
					MLOD.MLODEntry mlodentry = (@interface as Class121).MLODEntry;
					RCOL parent = mlodentry.Parent.Parent;
					VRTF vrtf = parent.Entries[mlodentry.VRTFIndex + ((parent.dataType == 2) ? 1 : 0)] as VRTF;
					if (vrtf == null)
					{
						vrtf = VRTF.GetDefaultForLength((mlodentry.Type == 20483U) ? 8 : 16);
					}
					VBUF vbuf = parent.Entries[(@interface as Class121).MLODEntry.VBUFIndex + ((parent.dataType == 2) ? 1 : 0)] as VBUF;
					DataStream dataStream = @interface.VertexBufferTransformed.Lock(0, 0, LockFlags.None);
					Class112.Struct7* ptr = (Class112.Struct7*)((void*)dataStream.DataPointer);
					DataStream dataStream2 = @interface.VertexBuffer.Lock(0, 0, LockFlags.None);
					Class112.Struct7* ptr2 = (Class112.Struct7*)((void*)dataStream2.DataPointer);
					foreach (Class102.Class107 @class in @interface.CurrentSelectionIndex)
					{
						ptr2[@class.short_0].float_0 = (ptr[@class.short_0].float_0 = ((array2[0] != -1) ? weights[0] : 0f));
						ptr2[@class.short_0].float_1 = (ptr[@class.short_0].float_1 = ((array2[1] != -1) ? weights[1] : 0f));
						ptr2[@class.short_0].float_2 = (ptr[@class.short_0].float_2 = ((array2[2] != -1) ? weights[2] : 0f));
						ptr2[@class.short_0].float_3 = (ptr[@class.short_0].float_3 = ((array2[3] != -1) ? weights[3] : 0f));
						ptr2[@class.short_0].uint_0 = (ptr[@class.short_0].uint_0 = (uint)((int)((byte)(array2[3] & 255)) << 24 | (int)((byte)(array2[2] & 255)) << 16 | (int)((byte)(array2[1] & 255)) << 8 | (int)((byte)(array2[0] & 255))));
						if (@interface is Class121)
						{
							vbuf.SetAssignment(vrtf, (int)@class.short_0, mlodentry.VBUFOffset, new sbyte[]
							{
								(sbyte)array3[0],
								(sbyte)array3[1],
								(sbyte)array3[2],
								(sbyte)array3[3]
							});
							vbuf.SetWeights(vrtf, (int)@class.short_0, mlodentry.VBUFOffset, weights);
						}
					}
					@interface.VertexBufferTransformed.Unlock();
					@interface.VertexBuffer.Unlock();
					(@interface as Class121).Skinned = true;
				}
				else if (@interface is Class104.Class109)
				{
					GEOM geom = (@interface as Class104.Class109).Geom;
					DataStream dataStream3 = @interface.VertexBufferTransformed.Lock(0, 0, LockFlags.None);
					Class112.Struct7* ptr3 = (Class112.Struct7*)((void*)dataStream3.DataPointer);
					DataStream dataStream4 = @interface.VertexBuffer.Lock(0, 0, LockFlags.None);
					Class112.Struct7* ptr4 = (Class112.Struct7*)((void*)dataStream4.DataPointer);
					foreach (Class102.Class107 class2 in @interface.CurrentSelectionIndex)
					{
						ptr4[class2.short_0].float_0 = (ptr3[class2.short_0].float_0 = ((array2[0] != -1) ? weights[0] : 0f));
						ptr4[class2.short_0].float_1 = (ptr3[class2.short_0].float_1 = ((array2[1] != -1) ? weights[1] : 0f));
						ptr4[class2.short_0].float_2 = (ptr3[class2.short_0].float_2 = ((array2[2] != -1) ? weights[2] : 0f));
						ptr4[class2.short_0].float_3 = (ptr3[class2.short_0].float_3 = ((array2[3] != -1) ? weights[3] : 0f));
						ptr4[class2.short_0].uint_0 = (ptr3[class2.short_0].uint_0 = (uint)((int)((byte)(array2[3] & 255)) << 24 | (int)((byte)(array2[2] & 255)) << 16 | (int)((byte)(array2[1] & 255)) << 8 | (int)((byte)(array2[0] & 255))));
						geom.vertices[(int)class2.short_0].boneAssignment = new byte[]
						{
							(byte)array3[0],
							(byte)array3[1],
							(byte)array3[2],
							(byte)array3[3]
						};
						geom.vertices[(int)class2.short_0].boneWeights = weights;
					}
					@interface.VertexBufferTransformed.Unlock();
					@interface.VertexBuffer.Unlock();
				}
				@interface.imethod_3();
			}
			foreach (Class102 class3 in Class132.smethod_0().Renderables)
			{
				class3.imethod_14();
			}
		}

		// Token: 0x06000CF3 RID: 3315 RVA: 0x000A2444 File Offset: 0x000A0644
		public unsafe bool imethod_0(MeshEditor meshEditor_0, Viewport viewport_0, MouseEventArgs mouseEventArgs_0)
		{
			if ((mouseEventArgs_0.Button == MouseButtons.Left || mouseEventArgs_0.Button == MouseButtons.Right) && (Control.ModifierKeys & Keys.Control) == Keys.None && (Control.ModifierKeys & Keys.Alt) == Keys.None)
			{
				Vector3.Unproject(new Vector3((float)mouseEventArgs_0.X, (float)mouseEventArgs_0.Y, 0f), (float)viewport_0.X, (float)viewport_0.Y, (float)viewport_0.Width, (float)viewport_0.Height, viewport_0.MinZ, viewport_0.MaxZ, meshEditor_0.WorldMatrix * meshEditor_0.ViewMatrix * meshEditor_0.ProjectionMatrix);
				Vector3.Unproject(new Vector3((float)mouseEventArgs_0.X, (float)mouseEventArgs_0.Y, 1f), (float)viewport_0.X, (float)viewport_0.Y, (float)viewport_0.Width, (float)viewport_0.Height, viewport_0.MinZ, viewport_0.MaxZ, meshEditor_0.WorldMatrix * meshEditor_0.ViewMatrix * meshEditor_0.ProjectionMatrix);
				if (Class134.boneWeightControl_0.PickFromVertex.Checked)
				{
					Interface9[] array = meshEditor_0.method_45();
					bool flag = false;
					Interface9[] array2 = array;
					for (int i = 0; i < array2.Length; i++)
					{
						Rectangle rectangle = new Rectangle(mouseEventArgs_0.X - 16, mouseEventArgs_0.Y - 16, 32, 32);
						Interface9[] array3 = meshEditor_0.method_45();
						int j = 0;
						IL_461:
						while (j < array3.Length)
						{
							Interface9 @interface = array3[j];
							DataStream dataStream = @interface.VertexBufferTransformed.Lock(0, 0, LockFlags.None);
							Class112.Struct7* ptr = (Class112.Struct7*)((void*)dataStream.DataPointer);
							int k = 0;
							while (k < @interface.VertexCount)
							{
								Vector3 position = ptr[k].position;
								Vector3 vector = Vector3.Project(position, (float)viewport_0.X, (float)viewport_0.Y, (float)viewport_0.Width, (float)viewport_0.Height, viewport_0.MinZ, viewport_0.MaxZ, meshEditor_0.WorldMatrix * meshEditor_0.ViewMatrix * meshEditor_0.ProjectionMatrix);
								if (!rectangle.Contains(new Point((int)vector.X, (int)vector.Y)))
								{
									k++;
								}
								else
								{
									sbyte b = (sbyte)(ptr[k].uint_0 >> 24 & 255U);
									sbyte b2 = (sbyte)(ptr[k].uint_0 >> 16 & 255U);
									sbyte b3 = (sbyte)(ptr[k].uint_0 >> 8 & 255U);
									sbyte b4 = (sbyte)(ptr[k].uint_0 & 255U);
									uint[] array4 = new uint[4];
									if (@interface is Class104.Class109)
									{
										array4[0] = ((b4 > -1) ? (@interface as Class104.Class109).Geom.boneHashes[(int)b4] : 0U);
										array4[1] = ((b3 > -1) ? (@interface as Class104.Class109).Geom.boneHashes[(int)b3] : 0U);
										array4[2] = ((b2 > -1) ? (@interface as Class104.Class109).Geom.boneHashes[(int)b2] : 0U);
										array4[3] = ((b > -1) ? (@interface as Class104.Class109).Geom.boneHashes[(int)b] : 0U);
									}
									else if (@interface is Class121)
									{
										array4[0] = ((b4 > -1) ? (@interface as Class121).list_0[(int)b4] : 0U);
										array4[1] = ((b3 > -1) ? (@interface as Class121).list_0[(int)b3] : 0U);
										array4[2] = ((b2 > -1) ? (@interface as Class121).list_0[(int)b2] : 0U);
										array4[3] = ((b > -1) ? (@interface as Class121).list_0[(int)b] : 0U);
									}
									float[] float_ = new float[]
									{
										ptr[k].float_0,
										ptr[k].float_1,
										ptr[k].float_2,
										ptr[k].float_3
									};
									Class134.boneWeightControl_0.method_1(array4);
									Class134.boneWeightControl_0.method_0(true);
									Class134.boneWeightControl_0.method_2(float_);
									flag = true;
									IL_44C:
									@interface.VertexBufferTransformed.Unlock();
									if (!flag)
									{
										j++;
										goto IL_461;
									}
									goto IL_46C;
								}
							}
							goto IL_44C;
						}
						IL_46C:;
					}
				}
			}
			return false;
		}

		// Token: 0x06000CF4 RID: 3316 RVA: 0x00024BE0 File Offset: 0x00022DE0
		public bool imethod_1(MeshEditor meshEditor_0, Viewport viewport_0, MouseEventArgs mouseEventArgs_0)
		{
			return false;
		}

		// Token: 0x06000CF5 RID: 3317 RVA: 0x000A28D8 File Offset: 0x000A0AD8
		public bool imethod_2(MeshEditor meshEditor_0, Viewport viewport_0, MouseEventArgs mouseEventArgs_0)
		{
			this.point_0.X = mouseEventArgs_0.X;
			this.point_0.Y = mouseEventArgs_0.Y;
			bool result;
			if ((Control.ModifierKeys & Keys.Control) == Keys.None && (Control.ModifierKeys & Keys.Alt) == Keys.None)
			{
				result = true;
			}
			else
			{
				result = false;
			}
			return result;
		}

		// Token: 0x06000CF6 RID: 3318 RVA: 0x000A292C File Offset: 0x000A0B2C
		public void imethod_3(MeshEditor meshEditor_0, Device device_0, Matrix matrix_0)
		{
			base.vmethod_5(meshEditor_0, device_0, matrix_0);
			if ((Control.ModifierKeys & Keys.Control) == Keys.None && (Control.ModifierKeys & Keys.Alt) == Keys.None && Class134.boneWeightControl_0.PickFromVertex.Checked)
			{
				Sprite sprite = new Sprite(device_0);
				sprite.Begin(SpriteFlags.AlphaBlend);
				sprite.Draw(this.texture_1, new Vector3?(new Vector3(16f, 16f, 0f)), new Vector3?(new Vector3((float)this.point_0.X, (float)this.point_0.Y, 0f)), new Color4(Color.White));
				sprite.End();
				sprite.Dispose();
			}
		}

		// Token: 0x040009C8 RID: 2504
		protected static Class134 class134_0;

		// Token: 0x040009C9 RID: 2505
		protected Texture texture_1;

		// Token: 0x040009CA RID: 2506
		protected Point point_0;

		// Token: 0x040009CB RID: 2507
		private static BoneWeightControl boneWeightControl_0;

		// Token: 0x040009CC RID: 2508
		private static Class134.Class139[] class139_0 = new Class134.Class139[4];

		// Token: 0x040009CD RID: 2509
		private static Color[] color_0 = new Color[]
		{
			Color.Red,
			Color.Green,
			Color.Blue,
			Color.Magenta
		};

		// Token: 0x040009CE RID: 2510
		private static Dictionary<Class33, Class134.Class139> dictionary_0 = new Dictionary<Class33, Class134.Class139>();

		// Token: 0x040009CF RID: 2511
		private IProjectModel iprojectModel_0;

		// Token: 0x040009D0 RID: 2512
		private bool[] bool_0;

		// Token: 0x02000120 RID: 288
		public sealed class Class139
		{
			// Token: 0x17000296 RID: 662
			// (get) Token: 0x06000CF8 RID: 3320 RVA: 0x000A2A64 File Offset: 0x000A0C64
			// (set) Token: 0x06000CF9 RID: 3321 RVA: 0x0000736D File Offset: 0x0000556D
			public Mesh Ball { get; private set; }

			// Token: 0x17000297 RID: 663
			// (get) Token: 0x06000CFA RID: 3322 RVA: 0x000A2A7C File Offset: 0x000A0C7C
			// (set) Token: 0x06000CFB RID: 3323 RVA: 0x00007378 File Offset: 0x00005578
			public VertexBuffer VertexBuffer { get; private set; }

			// Token: 0x17000298 RID: 664
			// (get) Token: 0x06000CFC RID: 3324 RVA: 0x000A2A94 File Offset: 0x000A0C94
			// (set) Token: 0x06000CFD RID: 3325 RVA: 0x00007383 File Offset: 0x00005583
			public VertexBuffer RotationVertexBuffer { get; private set; }

			// Token: 0x17000299 RID: 665
			// (get) Token: 0x06000CFE RID: 3326 RVA: 0x000A2AAC File Offset: 0x000A0CAC
			// (set) Token: 0x06000CFF RID: 3327 RVA: 0x0000738E File Offset: 0x0000558E
			public Class33 Bone { get; private set; }

			// Token: 0x1700029A RID: 666
			// (get) Token: 0x06000D00 RID: 3328 RVA: 0x000A2AC4 File Offset: 0x000A0CC4
			// (set) Token: 0x06000D01 RID: 3329 RVA: 0x00007399 File Offset: 0x00005599
			public Matrix BallOffsetMatrix { get; set; }

			// Token: 0x1700029B RID: 667
			// (get) Token: 0x06000D02 RID: 3330 RVA: 0x000A2ADC File Offset: 0x000A0CDC
			// (set) Token: 0x06000D03 RID: 3331 RVA: 0x000073A4 File Offset: 0x000055A4
			public bool Selected { get; set; }

			// Token: 0x1700029C RID: 668
			// (get) Token: 0x06000D04 RID: 3332 RVA: 0x000A2AF4 File Offset: 0x000A0CF4
			// (set) Token: 0x06000D05 RID: 3333 RVA: 0x000073AF File Offset: 0x000055AF
			public bool Hover { get; set; }

			// Token: 0x1700029D RID: 669
			// (get) Token: 0x06000D06 RID: 3334 RVA: 0x000A2B0C File Offset: 0x000A0D0C
			// (set) Token: 0x06000D07 RID: 3335 RVA: 0x000073BA File Offset: 0x000055BA
			public int ChildBoneCount { get; set; }

			// Token: 0x1700029E RID: 670
			// (get) Token: 0x06000D08 RID: 3336 RVA: 0x000A2B24 File Offset: 0x000A0D24
			// (set) Token: 0x06000D09 RID: 3337 RVA: 0x000073C5 File Offset: 0x000055C5
			public int ContainerIndex { get; set; }

			// Token: 0x06000D0A RID: 3338 RVA: 0x000A2B3C File Offset: 0x000A0D3C
			public Class139(Class33 bone, Device device)
			{
				this.Bone = bone;
				this.int_1 = 360;
				this.VertexBuffer = new VertexBuffer(device, Class112.Struct7.SizeInBytes * this.int_0 * 3 * (bone.ChildBones.Count + 1), Usage.None, Class112.Struct7.vertexFormat_0, Pool.Managed);
				this.RotationVertexBuffer = new VertexBuffer(device, Class112.Struct7.SizeInBytes * this.int_1 * 3, Usage.None, Class112.Struct7.vertexFormat_0, Pool.Managed);
				Class112.Struct7[] array = new Class112.Struct7[3];
				DataStream dataStream = this.VertexBuffer.Lock(0, 0, LockFlags.None);
				dataStream.WriteRange<Class112.Struct7>(array);
				this.VertexBuffer.Unlock();
				this.Ball = Mesh.CreateSphere(device, 0.002f, 12, 12);
				this.ContainerIndex = -1;
				array = new Class112.Struct7[this.int_1 * 3];
				float num = 0f;
				int num2 = 0;
				dataStream = this.RotationVertexBuffer.Lock(0, 0, LockFlags.None);
				for (int i = 1; i <= this.int_1; i++)
				{
					float num3 = 360f / (float)this.int_1 * (float)i;
					double num4 = (double)num3 * 0.017453292519943295;
					double num5 = (double)num * 0.017453292519943295;
					float x = (float)Math.Cos(num5);
					float y = (float)Math.Sin(num5);
					float x2 = (float)Math.Cos(num4);
					float y2 = (float)Math.Sin(num4);
					array[num2++].position = new Vector3(0f, 0f, 0f);
					array[num2++].position = new Vector3(x, y, 0f);
					array[num2++].position = new Vector3(x2, y2, 0f);
					num = num3;
				}
				dataStream.WriteRange<Class112.Struct7>(array);
				this.RotationVertexBuffer.Unlock();
			}

			// Token: 0x06000D0B RID: 3339 RVA: 0x000A2D18 File Offset: 0x000A0F18
			public void method_0(Device device_0, Matrix matrix_1, Matrix matrix_2)
			{
				Class140.smethod_0().method_28("g_forcedTransparency", this.Hover ? 0.6f : 0.7f);
				Class140.smethod_0().method_32(this.BallOffsetMatrix * matrix_1, matrix_2);
				Class140.smethod_0().method_31("g_ambient", this.Selected ? Class134.color_0[this.ContainerIndex] : (this.Hover ? Color.White : Color.Gray));
				Class140.smethod_0().method_35();
				Class140.smethod_0().method_9(RenderState.FillMode, FillMode.Solid);
				this.Ball.DrawSubset(0);
				Class140.smethod_0().method_9(RenderState.FillMode, FillMode.Wireframe);
				Class140.smethod_0().method_31("g_ambient", this.Selected ? Color.Black : (this.Hover ? Color.White : Color.Black));
				Class140.smethod_0().method_35();
				this.Ball.DrawSubset(0);
				device_0.SetStreamSource(0, this.VertexBuffer, 0, Class112.Struct7.SizeInBytes);
				Class140.smethod_0().method_10();
				Class140.smethod_0().method_32(matrix_1, matrix_2);
				Class140.smethod_0().method_28("g_forcedTransparency", this.Hover ? 0.6f : 0.7f);
				Class140.smethod_0().method_31("g_ambient", this.Selected ? Class134.color_0[this.ContainerIndex] : (this.Hover ? Color.White : Color.Gray));
				Class140.smethod_0().method_35();
				Class140.smethod_0().method_9(RenderState.FillMode, FillMode.Solid);
				device_0.DrawPrimitives(PrimitiveType.TriangleList, 0, (this.ChildBoneCount + 1) * this.int_0);
				Class140.smethod_0().method_28("g_forcedTransparency", this.Hover ? 0.6f : 0.3f);
				Class140.smethod_0().method_31("g_ambient", this.Selected ? Color.Black : (this.Hover ? Color.LightGray : Color.Black));
				Class140.smethod_0().method_35();
				Class140.smethod_0().method_9(RenderState.FillMode, FillMode.Wireframe);
				device_0.DrawPrimitives(PrimitiveType.TriangleList, 0, (this.ChildBoneCount + 1) * this.int_0);
				bool selected = this.Selected;
			}

			// Token: 0x06000D0C RID: 3340 RVA: 0x000A2F90 File Offset: 0x000A1190
			public unsafe bool method_1(Vector3 vector3_0, Vector3 vector3_1, Matrix matrix_1, out float float_0)
			{
				bool result = false;
				float_0 = float.MaxValue;
				DataStream dataStream = this.VertexBuffer.Lock(0, 0, LockFlags.None);
				Class112.Struct7* ptr = (Class112.Struct7*)((void*)dataStream.DataPointer);
				for (int i = 0; i < this.int_0 * (this.ChildBoneCount + 1); i++)
				{
					Vector3 vector = Vector3.TransformCoordinate(ptr[i * 3].position, Matrix.Identity);
					Vector3 vector2 = Vector3.TransformCoordinate(ptr[i * 3 + 1].position, Matrix.Identity);
					Vector3 vector3 = Vector3.TransformCoordinate(ptr[i * 3 + 2].position, Matrix.Identity);
					Ray ray = new Ray(vector3_0, vector3_1);
					new Plane(vector, vector2, vector3);
					if (Ray.Intersects(ray, vector, vector2, vector3, out float_0))
					{
						return true;
					}
				}
				this.VertexBuffer.Unlock();
				Matrix ballOffsetMatrix = this.BallOffsetMatrix;
				ballOffsetMatrix.Invert();
				vector3_0 = Vector3.TransformCoordinate(vector3_0, ballOffsetMatrix);
				vector3_1 = Vector3.TransformCoordinate(vector3_1, ballOffsetMatrix);
				Ray ray2 = new Ray(vector3_0, vector3_1);
				if (this.Ball.Intersects(ray2, out float_0))
				{
					result = true;
				}
				return result;
			}

			// Token: 0x06000D0D RID: 3341 RVA: 0x000073D0 File Offset: 0x000055D0
			public void method_2()
			{
				this.RotationVertexBuffer.Dispose();
				this.VertexBuffer.Dispose();
				this.Ball.Dispose();
			}

			// Token: 0x040009D1 RID: 2513
			private int int_0 = 7;

			// Token: 0x040009D2 RID: 2514
			private int int_1 = 12;

			// Token: 0x040009D3 RID: 2515
			[CompilerGenerated]
			private Mesh mesh_0;

			// Token: 0x040009D4 RID: 2516
			[CompilerGenerated]
			private VertexBuffer vertexBuffer_0;

			// Token: 0x040009D5 RID: 2517
			[CompilerGenerated]
			private VertexBuffer vertexBuffer_1;

			// Token: 0x040009D6 RID: 2518
			[CompilerGenerated]
			private Class33 class33_0;

			// Token: 0x040009D7 RID: 2519
			[CompilerGenerated]
			private Matrix matrix_0;

			// Token: 0x040009D8 RID: 2520
			[CompilerGenerated]
			private bool bool_0;

			// Token: 0x040009D9 RID: 2521
			[CompilerGenerated]
			private bool bool_1;

			// Token: 0x040009DA RID: 2522
			[CompilerGenerated]
			private int int_2;

			// Token: 0x040009DB RID: 2523
			[CompilerGenerated]
			private int int_3;
		}
	}
}
