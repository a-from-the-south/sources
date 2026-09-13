using System;
using System.Collections;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Xml;
using ns10;
using ns16;
using ns6;
using Package.Sims3Files;
using Sims3WorkshopSDK;
using SlimDX;
using SlimDX.Direct3D9;

namespace ns8
{
	// Token: 0x0200011C RID: 284
	internal sealed class Class131
	{
		// Token: 0x17000292 RID: 658
		// (get) Token: 0x06000CCE RID: 3278 RVA: 0x0009F9E0 File Offset: 0x0009DBE0
		// (set) Token: 0x06000CCF RID: 3279 RVA: 0x000072FA File Offset: 0x000054FA
		public Matrix TranslationMatrix { get; private set; }

		// Token: 0x17000293 RID: 659
		// (get) Token: 0x06000CD0 RID: 3280 RVA: 0x0009F9F8 File Offset: 0x0009DBF8
		// (set) Token: 0x06000CD1 RID: 3281 RVA: 0x00007305 File Offset: 0x00005505
		public Matrix RotationMatrix { get; private set; }

		// Token: 0x17000294 RID: 660
		// (get) Token: 0x06000CD2 RID: 3282 RVA: 0x0009FA10 File Offset: 0x0009DC10
		// (set) Token: 0x06000CD3 RID: 3283 RVA: 0x00007310 File Offset: 0x00005510
		public Class112.Struct7[] LineData { get; private set; }

		// Token: 0x06000CD4 RID: 3284 RVA: 0x0009FA28 File Offset: 0x0009DC28
		public Class131(float originX, float originZ, float destinationX, float destinationZ, string lPresetProductKey, string rPresetProductKey, string lIndex, string rIndex, string lPreset, string rPreset)
		{
			this.originX = originX;
			this.originZ = originZ;
			this.destinationX = destinationX;
			this.destinationZ = destinationZ;
			this.TranslationMatrix = Matrix.Translation(this.originX, 0f, this.originZ);
			Vector2 left = new Vector2(1f, 0f);
			Vector2 right = new Vector2(this.destinationX - this.originX, this.destinationZ - this.originZ);
			float x = Vector2.Distance(new Vector2(this.originX, this.originZ), new Vector2(this.destinationX, this.destinationZ));
			float num = Vector2.Dot(left, right);
			Math.Acos((double)num);
			double num2 = Math.Atan2((double)right.Y, (double)right.X) - Math.Atan2((double)left.Y, (double)left.X);
			this.RotationMatrix = Matrix.RotationY((float)(-(float)num2));
			Device device = Class140.smethod_0().Device;
			this.vertexBuffer_0 = new VertexBuffer(device, 12 * Class112.Struct7.SizeInBytes, Usage.None, Class112.Struct7.vertexFormat_0, Pool.Managed);
			this.LineData = new Class112.Struct7[12];
			this.LineData[0] = new Class112.Struct7(new Vector3(0f, 0f, 0.085f), new Vector3(0f, 0f, 1f), new Vector2(0f, 1f));
			this.LineData[1] = new Class112.Struct7(new Vector3(x, 0f, 0.085f), new Vector3(0f, 0f, 1f), new Vector2(1f, 1f));
			this.LineData[2] = new Class112.Struct7(new Vector3(x, 3f, 0.085f), new Vector3(0f, 0f, 1f), new Vector2(1f, 0f));
			this.LineData[3] = new Class112.Struct7(new Vector3(0f, 0f, 0.085f), new Vector3(0f, 0f, 1f), new Vector2(0f, 1f));
			this.LineData[4] = new Class112.Struct7(new Vector3(x, 3f, 0.085f), new Vector3(0f, 0f, 1f), new Vector2(1f, 0f));
			this.LineData[5] = new Class112.Struct7(new Vector3(0f, 3f, 0.085f), new Vector3(0f, 0f, 1f), new Vector2(0f, 0f));
			this.LineData[6] = new Class112.Struct7(new Vector3(0f, 0f, -0.085f), new Vector3(0f, 0f, -1f), new Vector2(0f, 1f));
			this.LineData[7] = new Class112.Struct7(new Vector3(0f, 3f, -0.085f), new Vector3(0f, 0f, -1f), new Vector2(0f, 0f));
			this.LineData[8] = new Class112.Struct7(new Vector3(x, 3f, -0.085f), new Vector3(0f, 0f, -1f), new Vector2(1f, 0f));
			this.LineData[9] = new Class112.Struct7(new Vector3(0f, 0f, -0.085f), new Vector3(0f, 0f, -1f), new Vector2(0f, 1f));
			this.LineData[10] = new Class112.Struct7(new Vector3(x, 3f, -0.085f), new Vector3(0f, 0f, -1f), new Vector2(1f, 0f));
			this.LineData[11] = new Class112.Struct7(new Vector3(x, 0f, -0.085f), new Vector3(0f, 0f, -1f), new Vector2(1f, 1f));
			DataStream dataStream = this.vertexBuffer_0.Lock(0, 0, LockFlags.None);
			dataStream.WriteRange<Class112.Struct7>(this.LineData, 0, 12);
			this.vertexBuffer_0.Unlock();
			string[] array = lPresetProductKey.Split(new char[]
			{
				','
			});
			int typeId = int.Parse(array[0]);
			int groupId = int.Parse(array[1]);
			uint secondInstanceId = uint.Parse(array[2]);
			uint instanceId = uint.Parse(array[3]);
			this.resKey_0 = new ResKey((DBPFType)typeId, groupId, (int)instanceId, (int)secondInstanceId);
			array = rPresetProductKey.Split(new char[]
			{
				','
			});
			typeId = int.Parse(array[0]);
			groupId = int.Parse(array[1]);
			secondInstanceId = uint.Parse(array[2]);
			instanceId = uint.Parse(array[3]);
			this.resKey_1 = new ResKey((DBPFType)typeId, groupId, (int)instanceId, (int)secondInstanceId);
			if (!string.IsNullOrEmpty(lIndex))
			{
				this.int_0 = int.Parse(lIndex);
			}
			else
			{
				this.int_0 = -1;
			}
			if (!string.IsNullOrEmpty(rIndex))
			{
				this.int_1 = int.Parse(rIndex);
			}
			else
			{
				this.int_1 = -1;
			}
			this.lPreset = lPreset;
			this.rPreset = rPreset;
			this.method_3(this.resKey_0, 0);
			this.method_3(this.resKey_1, 1);
		}

		// Token: 0x06000CD5 RID: 3285 RVA: 0x00002A71 File Offset: 0x00000C71
		public void method_0(Device device_0)
		{
		}

		// Token: 0x06000CD6 RID: 3286 RVA: 0x00002A71 File Offset: 0x00000C71
		public void method_1(Device device_0)
		{
		}

		// Token: 0x06000CD7 RID: 3287 RVA: 0x000A001C File Offset: 0x0009E21C
		public void method_2(bool bool_0)
		{
			if (bool_0)
			{
				this.texture_1.Dispose();
				this.texture_0.Dispose();
				foreach (object obj in Class131.hashtable_0.Values)
				{
					Hashtable hashtable = (Hashtable)obj;
					foreach (object obj2 in hashtable.Values)
					{
						Texture texture = (Texture)obj2;
						if (!texture.Disposed)
						{
							texture.Dispose();
						}
					}
					hashtable.Clear();
				}
				Class131.hashtable_0.Clear();
				this.vertexBuffer_0.Dispose();
			}
		}

		// Token: 0x06000CD8 RID: 3288 RVA: 0x000A0104 File Offset: 0x0009E304
		public void method_3(ResKey resKey_2, int int_2)
		{
			if (Class131.hashtable_0.ContainsKey(resKey_2))
			{
				Hashtable hashtable = Class131.hashtable_0[resKey_2] as Hashtable;
				int num = (int_2 == 0) ? this.int_0 : this.int_1;
				if (hashtable.ContainsKey(num) && num > -1)
				{
					if (int_2 == 0)
					{
						this.texture_0 = (hashtable[num] as Texture);
						return;
					}
					if (int_2 == 1)
					{
						this.texture_1 = (Class131.hashtable_0[num] as Texture);
					}
					return;
				}
				else
				{
					string text = (int_2 == 0) ? this.lPreset : this.rPreset;
					int hashCode = text.GetHashCode();
					if (hashtable.ContainsKey(hashCode))
					{
						if (int_2 == 0)
						{
							this.texture_0 = (hashtable[hashCode] as Texture);
							return;
						}
						if (int_2 == 1)
						{
							this.texture_1 = (hashtable[hashCode] as Texture);
						}
						return;
					}
				}
			}
			WALL wall = Class76.smethod_26(resKey_2) as WALL;
			int num2 = (int_2 == 0) ? this.int_0 : this.int_1;
			if (num2 == -1)
			{
				string text2 = (int_2 == 0) ? this.lPreset : this.rPreset;
				int hashCode2 = text2.GetHashCode();
				XmlDocument xmlDocument = new XmlDocument();
				xmlDocument.LoadXml(text2);
				Texture texture = Class132.smethod_0().method_4(new Size(512, 512));
				Interface3 @interface = Class132.smethod_0().method_8(new Size(512, 512));
				Class132.smethod_0().method_15(@interface, xmlDocument, "DiffuseMap", (xmlDocument.SelectNodes("preset/complate/value[@key='partType']").Item(0) as XmlElement).GetAttribute("value"), texture);
				@interface.imethod_2(true);
				DataStream dataStream = BaseTexture.ToStream(texture, ImageFileFormat.Png);
				texture.Dispose();
				Texture value = Texture.FromStream(Class140.smethod_0().Device, dataStream);
				dataStream.Dispose();
				if (int_2 == 0)
				{
					this.texture_0 = value;
				}
				else
				{
					this.texture_1 = value;
				}
				if (Class131.hashtable_0.ContainsKey(resKey_2))
				{
					Hashtable hashtable2 = Class131.hashtable_0[resKey_2] as Hashtable;
					hashtable2.Add(hashCode2, value);
				}
				else
				{
					Hashtable hashtable3 = new Hashtable();
					hashtable3.Add(hashCode2, value);
					Class131.hashtable_0.Add(resKey_2, hashtable3);
				}
			}
			else
			{
				OBJD.Material material = null;
				foreach (OBJD.Material material2 in wall.Materials)
				{
					if ((ulong)material2.MaterialIndex == (ulong)((long)num2))
					{
						material = material2;
					}
				}
				TGIIndex tgiindex = material.TGIIndex[0];
				foreach (OBJD.Material.MaterialBlock materialBlock in material.Blocks)
				{
					string text3 = string.Concat(new string[]
					{
						"<preset><complate name=\"",
						materialBlock.Ref1Name,
						"\" reskey=\"",
						tgiindex.Reskey,
						"\">"
					});
					foreach (OBJD.Material.ComplateVariable complateVariable in materialBlock.Variables)
					{
						string text4 = complateVariable.GetValue();
						if (complateVariable.ValueTypeCode == 3)
						{
							text4 = material.TGIIndex[Convert.ToInt32(text4)].Reskey;
						}
						object obj = text3;
						text3 = string.Concat(new object[]
						{
							obj,
							"<value key=\"",
							complateVariable.VariableName,
							"\" value=\"",
							text4,
							"\" type=\"",
							complateVariable.ValueTypeCode,
							"\" />"
						});
					}
					int num3 = 0;
					foreach (OBJD.Material.MaterialBlock materialBlock2 in materialBlock.Patterns)
					{
						string text5 = text3;
						text3 = string.Concat(new string[]
						{
							text5,
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
							string text6 = complateVariable2.GetValue();
							if (complateVariable2.ValueTypeCode == 3)
							{
								text6 = material.TGIIndex[Convert.ToInt32(text6)].Reskey;
							}
							object obj2 = text3;
							text3 = string.Concat(new object[]
							{
								obj2,
								"<value key=\"",
								complateVariable2.VariableName,
								"\" value=\"",
								text6,
								"\" type=\"",
								complateVariable2.ValueTypeCode,
								"\" />"
							});
						}
						text3 += "</pattern>";
						num3++;
					}
					text3 += "</complate></preset>";
					XmlDocument xmlDocument2 = new XmlDocument();
					xmlDocument2.LoadXml(text3);
					Texture texture2 = Class132.smethod_0().method_4(new Size(512, 512));
					Interface3 interface2 = Class132.smethod_0().method_8(new Size(512, 512));
					Class132.smethod_0().method_15(interface2, xmlDocument2, "DiffuseMap", (xmlDocument2.SelectNodes("preset/complate/value[@key='partType']").Item(0) as XmlElement).GetAttribute("value"), texture2);
					interface2.imethod_2(true);
					DataStream dataStream2 = BaseTexture.ToStream(texture2, ImageFileFormat.Png);
					texture2.Dispose();
					Texture value2 = Texture.FromStream(Class140.smethod_0().Device, dataStream2);
					dataStream2.Dispose();
					if (int_2 == 0)
					{
						this.texture_0 = value2;
					}
					else
					{
						this.texture_1 = value2;
					}
					if (Class131.hashtable_0.ContainsKey(resKey_2))
					{
						Hashtable hashtable4 = Class131.hashtable_0[resKey_2] as Hashtable;
						hashtable4.Add(num2, value2);
					}
					else
					{
						Hashtable hashtable5 = new Hashtable();
						hashtable5.Add(num2, value2);
						Class131.hashtable_0.Add(resKey_2, hashtable5);
					}
				}
			}
		}

		// Token: 0x06000CD9 RID: 3289 RVA: 0x000A082C File Offset: 0x0009EA2C
		public void method_4(Device device_0, Matrix matrix_2)
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
			Matrix matrix = this.RotationMatrix * this.TranslationMatrix * matrix_2;
			Class140.smethod_0().method_32(matrix, Class132.smethod_0().ViewMatrix);
			Class140.smethod_0().method_40("SimpleObject");
			Class140.smethod_0().method_9(RenderState.ZWriteEnable, true);
			Class140.smethod_0().method_34(false);
			Class132.smethod_0().method_29(material_);
			Class140.smethod_0().method_14(this.texture_1);
			int num = Class140.smethod_0().method_36();
			for (int i = 0; i < num; i++)
			{
				Class140.smethod_0().method_38(i);
				device_0.DrawPrimitives(PrimitiveType.TriangleList, 0, 2);
				Class140.smethod_0().method_39();
			}
			Class140.smethod_0().method_37();
			Class140.smethod_0().method_14(this.texture_0);
			num = Class140.smethod_0().method_36();
			for (int j = 0; j < num; j++)
			{
				Class140.smethod_0().method_38(j);
				device_0.DrawPrimitives(PrimitiveType.TriangleList, 6, 2);
				Class140.smethod_0().method_39();
			}
			Class140.smethod_0().method_37();
		}

		// Token: 0x040009B2 RID: 2482
		public static Hashtable hashtable_0 = new Hashtable();

		// Token: 0x040009B3 RID: 2483
		private VertexBuffer vertexBuffer_0;

		// Token: 0x040009B4 RID: 2484
		public Texture texture_0;

		// Token: 0x040009B5 RID: 2485
		public Texture texture_1;

		// Token: 0x040009B6 RID: 2486
		public float originX;

		// Token: 0x040009B7 RID: 2487
		public float originZ;

		// Token: 0x040009B8 RID: 2488
		public float destinationX;

		// Token: 0x040009B9 RID: 2489
		public float destinationZ;

		// Token: 0x040009BA RID: 2490
		private ResKey resKey_0;

		// Token: 0x040009BB RID: 2491
		private ResKey resKey_1;

		// Token: 0x040009BC RID: 2492
		private int int_0;

		// Token: 0x040009BD RID: 2493
		private int int_1;

		// Token: 0x040009BE RID: 2494
		private string lPreset;

		// Token: 0x040009BF RID: 2495
		private string rPreset;

		// Token: 0x040009C0 RID: 2496
		[CompilerGenerated]
		private Matrix matrix_0;

		// Token: 0x040009C1 RID: 2497
		[CompilerGenerated]
		private Matrix matrix_1;

		// Token: 0x040009C2 RID: 2498
		[CompilerGenerated]
		private Class112.Struct7[] struct7_0;
	}
}
