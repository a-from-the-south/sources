using System;
using System.Collections;
using System.Drawing;
using System.Xml;
using ns10;
using ns16;
using ns6;
using ns8;
using Package.Sims3Files;
using Sims3WorkshopSDK;
using SlimDX;
using SlimDX.Direct3D9;

namespace ns13
{
	// Token: 0x02000107 RID: 263
	internal sealed class Class113
	{
		// Token: 0x06000B40 RID: 2880 RVA: 0x0008E840 File Offset: 0x0008CA40
		public Class113(float x, float z, float rotation, int quad, string presetProductKey, string presetIndex, string presetXml)
		{
			this.x = x;
			this.z = z;
			this.rotation = rotation;
			this.float_0 = (float)quad;
			this.matrix_0 = Matrix.Translation(this.x, 0f, this.z);
			Matrix right = Matrix.Identity;
			switch (quad)
			{
			case 1:
				right = Matrix.Identity;
				break;
			case 2:
				right = Matrix.Translation(0.5f, 0f, 0f);
				break;
			case 3:
				break;
			case 4:
				right = Matrix.Translation(0.5f, 0f, 0.5f);
				break;
			default:
				if (quad == 8)
				{
					right = Matrix.Translation(0f, 0f, 0.5f);
				}
				break;
			}
			this.matrix_0 *= right;
			this.matrix_1 = Matrix.RotationY(0f);
			Device device = Class140.smethod_0().Device;
			this.vertexBuffer_0 = new VertexBuffer(device, 6 * Class112.Struct7.SizeInBytes, Usage.None, Class112.Struct7.vertexFormat_0, Pool.Managed);
			Class112.Struct7[] array = new Class112.Struct7[12];
			float num = 0.5f;
			array[0] = new Class112.Struct7(new Vector3(0f, 0f, 0f), new Vector3(0f, 1f, 0f), new Vector2(0f, 0f));
			array[1] = new Class112.Struct7(new Vector3(0f, 0f, num), new Vector3(0f, 1f, 0f), new Vector2(0f, 1f));
			array[2] = new Class112.Struct7(new Vector3(num, 0f, num), new Vector3(0f, 1f, 0f), new Vector2(1f, 1f));
			array[3] = new Class112.Struct7(new Vector3(0f, 0f, 0f), new Vector3(0f, 1f, 0f), new Vector2(0f, 0f));
			array[4] = new Class112.Struct7(new Vector3(num, 0f, num), new Vector3(0f, 1f, 0f), new Vector2(1f, 1f));
			array[5] = new Class112.Struct7(new Vector3(num, 0f, 0f), new Vector3(0f, 1f, 0f), new Vector2(1f, 0f));
			DataStream dataStream = this.vertexBuffer_0.Lock(0, 0, LockFlags.None);
			dataStream.WriteRange<Class112.Struct7>(array, 0, 6);
			this.vertexBuffer_0.Unlock();
			string[] array2 = presetProductKey.Split(new char[]
			{
				','
			});
			int typeId = int.Parse(array2[0]);
			int groupId = int.Parse(array2[1]);
			uint secondInstanceId = uint.Parse(array2[2]);
			uint instanceId = uint.Parse(array2[3]);
			this.resKey_0 = new ResKey((DBPFType)typeId, groupId, (int)instanceId, (int)secondInstanceId);
			if (!string.IsNullOrEmpty(presetIndex))
			{
				this.int_0 = int.Parse(presetIndex);
			}
			else
			{
				this.int_0 = -1;
			}
			this.presetXml = presetXml;
			this.method_0();
		}

		// Token: 0x06000B41 RID: 2881 RVA: 0x0008EB9C File Offset: 0x0008CD9C
		public void method_0()
		{
			if (Class113.hashtable_0.ContainsKey(this.resKey_0))
			{
				Hashtable hashtable = Class113.hashtable_0[this.resKey_0] as Hashtable;
				int hashCode = this.presetXml.GetHashCode();
				if (hashtable.ContainsKey(this.int_0) && this.int_0 > -1)
				{
					this.texture_0 = (hashtable[this.int_0] as Texture);
					return;
				}
				if (hashtable.ContainsKey(hashCode))
				{
					this.texture_0 = (hashtable[hashCode] as Texture);
					return;
				}
			}
			WALL wall = Class76.smethod_26(this.resKey_0) as WALL;
			if (this.int_0 == -1)
			{
				XmlDocument xmlDocument = new XmlDocument();
				xmlDocument.LoadXml(this.presetXml);
				Texture texture = Class132.smethod_0().method_4(new Size(512, 512));
				Interface3 @interface = Class132.smethod_0().method_8(new Size(512, 512));
				Class132.smethod_0().method_15(@interface, xmlDocument, "DiffuseMap", (xmlDocument.SelectNodes("preset/complate/value[@key='partType']").Item(0) as XmlElement).GetAttribute("value"), texture);
				@interface.imethod_2(true);
				DataStream dataStream = BaseTexture.ToStream(texture, ImageFileFormat.Png);
				texture.Dispose();
				this.texture_0 = Texture.FromStream(Class140.smethod_0().Device, dataStream);
				dataStream.Dispose();
				if (Class131.hashtable_0.ContainsKey(this.resKey_0))
				{
					Hashtable hashtable2 = Class131.hashtable_0[this.resKey_0] as Hashtable;
					hashtable2.Add(this.presetXml.GetHashCode(), this.texture_0);
				}
				else
				{
					Hashtable hashtable3 = new Hashtable();
					hashtable3.Add(this.presetXml.GetHashCode(), this.texture_0);
					Class131.hashtable_0.Add(this.resKey_0, hashtable3);
				}
			}
			else
			{
				OBJD.Material material = null;
				foreach (OBJD.Material material2 in wall.Materials)
				{
					if ((ulong)material2.MaterialIndex == (ulong)((long)this.int_0))
					{
						material = material2;
					}
				}
				TGIIndex tgiindex = material.TGIIndex[0];
				foreach (OBJD.Material.MaterialBlock materialBlock in material.Blocks)
				{
					string text = string.Concat(new string[]
					{
						"<preset><complate name=\"",
						materialBlock.Ref1Name,
						"\" reskey=\"",
						tgiindex.Reskey,
						"\">"
					});
					foreach (OBJD.Material.ComplateVariable complateVariable in materialBlock.Variables)
					{
						string text2 = complateVariable.GetValue();
						if (complateVariable.ValueTypeCode == 3)
						{
							text2 = material.TGIIndex[Convert.ToInt32(text2)].Reskey;
						}
						object obj = text;
						text = string.Concat(new object[]
						{
							obj,
							"<value key=\"",
							complateVariable.VariableName,
							"\" value=\"",
							text2,
							"\" type=\"",
							complateVariable.ValueTypeCode,
							"\" />"
						});
					}
					int num = 0;
					foreach (OBJD.Material.MaterialBlock materialBlock2 in materialBlock.Patterns)
					{
						string text3 = text;
						text = string.Concat(new string[]
						{
							text3,
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
							string text4 = complateVariable2.GetValue();
							if (complateVariable2.ValueTypeCode == 3)
							{
								text4 = material.TGIIndex[Convert.ToInt32(text4)].Reskey;
							}
							object obj2 = text;
							text = string.Concat(new object[]
							{
								obj2,
								"<value key=\"",
								complateVariable2.VariableName,
								"\" value=\"",
								text4,
								"\" type=\"",
								complateVariable2.ValueTypeCode,
								"\" />"
							});
						}
						text += "</pattern>";
						num++;
					}
					text += "</complate></preset>";
					XmlDocument xmlDocument2 = new XmlDocument();
					xmlDocument2.LoadXml(text);
					Texture texture2 = Class132.smethod_0().method_4(new Size(512, 512));
					Interface3 interface2 = Class132.smethod_0().method_8(new Size(512, 512));
					Class132.smethod_0().method_15(interface2, xmlDocument2, "DiffuseMap", (xmlDocument2.SelectNodes("preset/complate/value[@key='partType']").Item(0) as XmlElement).GetAttribute("value"), texture2);
					interface2.imethod_2(true);
					DataStream dataStream2 = BaseTexture.ToStream(texture2, ImageFileFormat.Png);
					texture2.Dispose();
					this.texture_0 = Texture.FromStream(Class140.smethod_0().Device, dataStream2);
					dataStream2.Dispose();
					if (Class113.hashtable_0.ContainsKey(this.resKey_0))
					{
						Hashtable hashtable4 = Class113.hashtable_0[this.resKey_0] as Hashtable;
						hashtable4.Add(this.int_0, this.texture_0);
					}
					else
					{
						Hashtable hashtable5 = new Hashtable();
						hashtable5.Add(this.int_0, this.texture_0);
						Class113.hashtable_0.Add(this.resKey_0, hashtable5);
					}
				}
			}
		}

		// Token: 0x06000B42 RID: 2882 RVA: 0x00002A71 File Offset: 0x00000C71
		public void method_1(Device device_0)
		{
		}

		// Token: 0x06000B43 RID: 2883 RVA: 0x00002A71 File Offset: 0x00000C71
		public void method_2(Device device_0)
		{
		}

		// Token: 0x06000B44 RID: 2884 RVA: 0x0008F274 File Offset: 0x0008D474
		public void method_3(bool bool_0)
		{
			if (bool_0)
			{
				this.texture_0.Dispose();
				foreach (object obj in Class113.hashtable_0.Values)
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
				Class113.hashtable_0.Clear();
				this.vertexBuffer_0.Dispose();
			}
		}

		// Token: 0x06000B45 RID: 2885 RVA: 0x0008F350 File Offset: 0x0008D550
		public void method_4(Device device_0, Matrix matrix_2)
		{
			device_0.SetStreamSource(0, this.vertexBuffer_0, 0, Class112.Struct7.SizeInBytes);
			Class140.smethod_0().method_9(RenderState.Lighting, true);
			Class140.smethod_0().method_9(RenderState.AlphaTestEnable, true);
			Class140.smethod_0().method_9(RenderState.AlphaFunc, Compare.Equal);
			Class140.smethod_0().method_9(RenderState.AlphaRef, 255);
			Material material_ = default(Material);
			material_.Diffuse = Color.FromArgb(255, Color.White);
			material_.Specular = Color.FromArgb(127, 127, 127, 127);
			material_.Power = 0f;
			Matrix matrix = this.matrix_1 * this.matrix_0 * matrix_2;
			Class140.smethod_0().method_32(matrix, Class132.smethod_0().ViewMatrix);
			Class140.smethod_0().method_40("SimpleObject");
			Class140.smethod_0().method_9(RenderState.ZWriteEnable, true);
			Class140.smethod_0().method_34(false);
			Class140.smethod_0().method_14(this.texture_0);
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

		// Token: 0x040008C4 RID: 2244
		public static Hashtable hashtable_0 = new Hashtable();

		// Token: 0x040008C5 RID: 2245
		private VertexBuffer vertexBuffer_0;

		// Token: 0x040008C6 RID: 2246
		public Texture texture_0;

		// Token: 0x040008C7 RID: 2247
		private ResKey resKey_0;

		// Token: 0x040008C8 RID: 2248
		private float x;

		// Token: 0x040008C9 RID: 2249
		private float z;

		// Token: 0x040008CA RID: 2250
		private float rotation;

		// Token: 0x040008CB RID: 2251
		private float float_0;

		// Token: 0x040008CC RID: 2252
		private Matrix matrix_0;

		// Token: 0x040008CD RID: 2253
		private Matrix matrix_1;

		// Token: 0x040008CE RID: 2254
		private int int_0;

		// Token: 0x040008CF RID: 2255
		private string presetXml;
	}
}
