using System;
using System.Collections;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Xml;
using ns16;
using ns17;
using ns6;
using ns8;
using Package;
using Package.Sims3Files;
using Sims3Workshop.Properties;
using Sims3WorkshopSDK;
using SlimDX;
using SlimDX.Direct3D9;

namespace ns15
{
	// Token: 0x0200002C RID: 44
	internal sealed class Class27 : Interface3
	{
		// Token: 0x1700003A RID: 58
		// (get) Token: 0x060001A2 RID: 418 RVA: 0x00024C64 File Offset: 0x00022E64
		public string Errors
		{
			get
			{
				return this.string_0;
			}
		}

		// Token: 0x060001A3 RID: 419 RVA: 0x000032F4 File Offset: 0x000014F4
		public Class27(Size size)
		{
			this.cultureInfo_0 = new CultureInfo("en-US");
			this.cultureInfo_0.NumberFormat.NumberDecimalSeparator = ".";
			this.size = size;
		}

		// Token: 0x060001A4 RID: 420 RVA: 0x00024C7C File Offset: 0x00022E7C
		private void method_0(Device device_0)
		{
			if (this.texture_6 == null)
			{
				this.texture_6 = new Texture(device_0, this.size.Width, this.size.Height, 1, Usage.RenderTarget, Format.A8R8G8B8, Pool.Default);
				this.surface_0 = this.texture_6.GetSurfaceLevel(0);
			}
			if (this.texture_7 == null)
			{
				this.texture_7 = new Texture(device_0, this.size.Width, this.size.Height, 1, Usage.RenderTarget, Format.A8R8G8B8, Pool.Default);
				this.surface_1 = this.texture_7.GetSurfaceLevel(0);
			}
			if (this.texture_10 == null)
			{
				this.texture_10 = new Texture(device_0, this.size.Width, this.size.Height, 1, Usage.RenderTarget, Format.A8R8G8B8, Pool.Default);
				this.surface_4 = this.texture_10.GetSurfaceLevel(0);
			}
			if (this.texture_11 == null)
			{
				this.texture_11 = new Texture(device_0, this.size.Width, this.size.Height, 1, Usage.RenderTarget, Format.A8R8G8B8, Pool.Default);
				this.surface_5 = this.texture_11.GetSurfaceLevel(0);
			}
			if (this.texture_8 == null)
			{
				this.texture_8 = new Texture(device_0, 256, 256, 1, Usage.RenderTarget, Format.A8R8G8B8, Pool.Default);
				this.surface_2 = this.texture_8.GetSurfaceLevel(0);
			}
			if (this.texture_9 == null)
			{
				this.texture_9 = new Texture(device_0, 256, 256, 1, Usage.RenderTarget, Format.A8R8G8B8, Pool.Default);
				this.surface_3 = this.texture_9.GetSurfaceLevel(0);
			}
			if (this.surface_6 == null)
			{
				this.surface_6 = Surface.CreateDepthStencil(device_0, this.size.Width, this.size.Height, Format.D16, this.surface_0.Description.MultisampleType, this.surface_0.Description.MultisampleQuality, true);
			}
			if (this.surface_7 == null)
			{
				this.surface_7 = Surface.CreateDepthStencil(device_0, 256, 256, Format.D16, this.surface_2.Description.MultisampleType, this.surface_2.Description.MultisampleQuality, true);
			}
		}

		// Token: 0x060001A5 RID: 421 RVA: 0x0000332A File Offset: 0x0000152A
		public void imethod_1(Size size_0)
		{
			this.size = size_0;
			this.imethod_2(false);
		}

		// Token: 0x060001A6 RID: 422 RVA: 0x00024E94 File Offset: 0x00023094
		public bool imethod_0(Device device_0, XmlDocument xmlDocument_0, XmlElement xmlElement_0, string string_6, string string_7, Texture texture_12)
		{
			if (this.effect_0 == null)
			{
				MemoryStream stream = new MemoryStream(Class143.complateshadernew);
				try
				{
					this.effect_0 = Effect.FromStream(device_0, stream, null, null, null, ShaderFlags.None, null, out this.string_0);
				}
				catch (Exception)
				{
				}
			}
			this.method_0(Class132.smethod_0().Device);
			this.bool_1 = false;
			this.bool_0 = false;
			this.bool_2 = false;
			this.int_0 = 0;
			Surface surfaceLevel = texture_12.GetSurfaceLevel(0);
			Surface renderTarget = device_0.GetRenderTarget(0);
			Surface depthStencilSurface = device_0.DepthStencilSurface;
			device_0.SetRenderState(RenderState.ZEnable, false);
			device_0.SetRenderState(RenderState.StencilEnable, false);
			device_0.SetRenderState(RenderState.PointSpriteEnable, true);
			device_0.SetRenderState(RenderState.PointScaleEnable, false);
			device_0.SetRenderState(RenderState.AlphaBlendEnable, false);
			device_0.SetRenderState(RenderState.ZEnable, false);
			device_0.SetRenderState(RenderState.AlphaTestEnable, false);
			device_0.SetRenderState(RenderState.Lighting, true);
			Class140.smethod_0().method_10();
			Surface[] array = new Surface[]
			{
				this.surface_0,
				this.surface_1,
				this.surface_4,
				this.surface_5
			};
			foreach (Surface target in array)
			{
				device_0.SetRenderTarget(0, target);
				device_0.DepthStencilSurface = this.surface_6;
				device_0.BeginScene();
				Sprite sprite = new Sprite(device_0);
				sprite.Begin(SpriteFlags.None);
				sprite.Draw(texture_12, new Vector3?(new Vector3(0f, 0f, 0f)), new Vector3?(Vector3.Zero), new Color4(Color.White.ToArgb()));
				sprite.End();
				sprite.Dispose();
				device_0.EndScene();
			}
			try
			{
				this.method_1(device_0, xmlDocument_0, xmlElement_0, string_6, string_7);
			}
			catch (Exception)
			{
			}
			device_0.SetRenderTarget(0, surfaceLevel);
			device_0.DepthStencilSurface = this.surface_6;
			device_0.BeginScene();
			Sprite sprite2 = new Sprite(device_0);
			sprite2.Begin(SpriteFlags.None);
			sprite2.Draw((this.int_0 == 1) ? (this.bool_1 ? this.texture_10 : this.texture_11) : (this.bool_0 ? this.texture_6 : this.texture_7), new Vector3?(new Vector3(0f, 0f, 0f)), new Vector3?(Vector3.Zero), new Color4(Color.White.ToArgb()));
			sprite2.End();
			sprite2.Dispose();
			device_0.EndScene();
			device_0.SetRenderTarget(0, renderTarget);
			device_0.DepthStencilSurface = depthStencilSurface;
			device_0.SetRenderState(RenderState.ZEnable, true);
			device_0.SetRenderState(RenderState.StencilEnable, true);
			return true;
		}

		// Token: 0x060001A7 RID: 423 RVA: 0x00025168 File Offset: 0x00023368
		public void imethod_2(bool bool_3)
		{
			if (this.effect_0 != null)
			{
				this.effect_0.Dispose();
			}
			if (this.surface_6 != null)
			{
				this.surface_6.Dispose();
			}
			if (this.surface_7 != null)
			{
				this.surface_7.Dispose();
			}
			if (this.texture_6 != null)
			{
				this.surface_0.Dispose();
				this.texture_6.Dispose();
			}
			if (this.texture_7 != null)
			{
				this.surface_1.Dispose();
				this.texture_7.Dispose();
			}
			if (this.texture_10 != null)
			{
				this.surface_4.Dispose();
				this.texture_10.Dispose();
			}
			if (this.texture_11 != null)
			{
				this.surface_5.Dispose();
				this.texture_11.Dispose();
			}
			if (this.texture_8 != null)
			{
				this.texture_8.Dispose();
				this.surface_2.Dispose();
			}
			if (this.texture_9 != null)
			{
				this.texture_9.Dispose();
				this.surface_3.Dispose();
			}
			if (this.texture_5 != null)
			{
				this.texture_5.Dispose();
			}
			if (this.texture_0 != null)
			{
				this.texture_0.Dispose();
			}
			if (this.texture_1 != null)
			{
				this.texture_1.Dispose();
			}
			if (this.texture_2 != null)
			{
				this.texture_2.Dispose();
			}
			if (this.texture_3 != null)
			{
				this.texture_3.Dispose();
			}
			if (this.texture_4 != null)
			{
				this.texture_4.Dispose();
			}
			this.surface_6 = (this.surface_7 = null);
			this.texture_9 = (this.texture_8 = (this.texture_6 = (this.texture_7 = (this.texture_10 = (this.texture_11 = null)))));
			this.texture_5 = (this.texture_0 = (this.texture_1 = (this.texture_2 = (this.texture_3 = (this.texture_4 = null)))));
			this.effect_0 = null;
		}

		// Token: 0x060001A8 RID: 424 RVA: 0x00025364 File Offset: 0x00023564
		private void method_1(Device device_0, XmlDocument xmlDocument_0, XmlElement xmlElement_0, string string_6, string string_7)
		{
			this.string_5 = string_6;
			XmlNodeList xmlNodeList = xmlDocument_0.SelectNodes("/preset/complate/pattern");
			foreach (object obj in xmlNodeList)
			{
				XmlElement xmlElement = (XmlElement)obj;
				string attribute = xmlElement.GetAttribute("variable");
				if (xmlDocument_0.SelectSingleNode("/preset/complate/value[@key='" + attribute + " Enabled' and @value='False']") == null)
				{
					ResKey resKey = new ResKey(xmlElement.GetAttribute("reskey"));
					DBPFEntry dbpfentry = Class76.smethod_26(resKey);
					XmlDocument xmlDocument = null;
					if (dbpfentry == null)
					{
						if (resKey.TypeId == 54635721U)
						{
							string attribute2 = (xmlDocument_0.SelectSingleNode("/preset/complate") as XmlElement).GetAttribute("reskey");
							TXTC txtc = Class76.smethod_26(new ResKey(attribute2)) as TXTC;
							if (txtc == null)
							{
								throw new Exception("Could not locate main complate");
							}
							foreach (TXTC.FABC fabc in txtc.SuperBlocks)
							{
								string reskey = fabc.IGTIndex.Reskey;
								string b = resKey.AsString();
								if (reskey == b)
								{
									xmlDocument = fabc.ToComplate("somepattern", TXTC.ComplateType.Other);
									if (attribute.Contains("Pattern A"))
									{
										this.string_1 = b;
									}
									else if (attribute.Contains("Pattern B"))
									{
										this.string_2 = b;
									}
									else if (attribute.Contains("Pattern C"))
									{
										this.string_3 = b;
									}
									else if (attribute.Contains("Pattern D"))
									{
										this.string_4 = b;
									}
								}
							}
						}
						if (xmlDocument == null)
						{
							throw new Exception("Could not locate pattern complate");
						}
					}
					else if (dbpfentry is XML)
					{
						xmlDocument = (dbpfentry as XML).Documents[0];
					}
					string text = xmlDocument.InnerXml;
					XmlNodeList xmlNodeList2 = xmlElement.SelectNodes("./value");
					foreach (object obj2 in xmlNodeList2)
					{
						XmlElement xmlElement2 = (XmlElement)obj2;
						text = text.Replace("($" + xmlElement2.GetAttribute("key") + ")", xmlElement2.GetAttribute("value"));
					}
					XmlNodeList xmlNodeList3 = xmlDocument.SelectNodes("/complate/variables/param");
					foreach (object obj3 in xmlNodeList3)
					{
						XmlElement xmlElement3 = (XmlElement)obj3;
						text = text.Replace("($" + xmlElement3.GetAttribute("name") + ")", xmlElement3.GetAttribute("default"));
					}
					xmlDocument = new XmlDocument();
					xmlDocument.LoadXml(text);
					device_0.SetRenderTarget(0, this.surface_2);
					this.bool_2 = false;
					device_0.DepthStencilSurface = this.surface_7;
					device_0.Clear(ClearFlags.Target, new Color4(1f, 1f, 1f, 1f), 1f, 0);
					XmlNodeList xmlNodeList4 = xmlDocument.SelectNodes("/complate/texturePart");
					string text3;
					foreach (object obj4 in xmlNodeList4)
					{
						XmlElement xmlElement4 = (XmlElement)obj4;
						XmlNodeList xmlNodeList5 = xmlElement4.SelectNodes("./destination");
						foreach (object obj5 in xmlNodeList5)
						{
							XmlElement xmlElement5 = (XmlElement)obj5;
							XmlNodeList xmlNodeList6 = xmlElement5.SelectNodes("./step");
							foreach (object obj6 in xmlNodeList6)
							{
								XmlElement xmlElement6 = (XmlElement)obj6;
								string text2 = xmlElement6.GetAttribute("type").ToLower();
								if ((text3 = text2) != null)
								{
									if (text3 == "settarget")
									{
										throw new NotImplementedException("SetTarget on patterns not implemented.");
									}
									if (!(text3 == "colorfill"))
									{
										if (!(text3 == "channelselect"))
										{
											if (!(text3 == "drawimage"))
											{
												if (text3 == "hsvshift")
												{
													this.method_7(device_0, xmlElement6, true);
												}
											}
											else
											{
												this.method_3(device_0, xmlElement6, true);
											}
										}
										else
										{
											this.method_5(device_0, xmlElement6, true);
										}
									}
									else
									{
										this.method_2(device_0, xmlElement6, true);
									}
								}
							}
						}
					}
					long ticks = DateTime.Now.Ticks;
					float num = 1f;
					float num2 = 1f;
					XmlNodeList xmlNodeList7 = xmlDocument_0.SelectNodes("/preset/complate/value[@key='" + xmlElement.GetAttribute("variable") + " Tiling']");
					if (xmlNodeList7.Count > 0)
					{
						string[] array = (xmlNodeList7.Item(0) as XmlElement).GetAttribute("value").Split(new char[]
						{
							','
						});
						num = Convert.ToSingle(array[0], this.cultureInfo_0);
						num2 = Convert.ToSingle(array[1], this.cultureInfo_0);
					}
					XmlNode xmlNode = xmlDocument_0.SelectSingleNode("/preset/complate/value[@key='" + xmlElement.GetAttribute("variable") + " Rotation']");
					if (xmlNode != null)
					{
						Class76.smethod_34(xmlNode.Attributes["value"].Value);
					}
					Texture texture = null;
					if ((text3 = attribute.ToLower()) != null)
					{
						if (!(text3 == "pattern a"))
						{
							if (!(text3 == "pattern b"))
							{
								if (!(text3 == "pattern c"))
								{
									if (!(text3 == "pattern d"))
									{
										if (text3 == "logo")
										{
											texture = this.texture_4;
										}
									}
									else
									{
										texture = this.texture_3;
									}
								}
								else
								{
									texture = this.texture_2;
								}
							}
							else
							{
								texture = this.texture_1;
							}
						}
						else
						{
							texture = this.texture_0;
						}
					}
					if (texture == null)
					{
						texture = new Texture(device_0, this.size.Width, this.size.Height, 1, Usage.RenderTarget, this.surface_2.Description.Format, Pool.Default);
						if ((text3 = attribute.ToLower()) != null)
						{
							if (!(text3 == "pattern a"))
							{
								if (!(text3 == "pattern b"))
								{
									if (!(text3 == "pattern c"))
									{
										if (!(text3 == "pattern d"))
										{
											if (text3 == "logo")
											{
												this.texture_4 = texture;
											}
										}
										else
										{
											this.texture_3 = texture;
										}
									}
									else
									{
										this.texture_2 = texture;
									}
								}
								else
								{
									this.texture_1 = texture;
								}
							}
							else
							{
								this.texture_0 = texture;
							}
						}
					}
					Surface surfaceLevel = texture.GetSurfaceLevel(0);
					Surface surface = Surface.CreateDepthStencil(device_0, surfaceLevel.Description.Width, surfaceLevel.Description.Height, Format.D16, surfaceLevel.Description.MultisampleType, surfaceLevel.Description.MultisampleQuality, true);
					device_0.SetRenderTarget(0, surfaceLevel);
					device_0.DepthStencilSurface = surface;
					float num3 = (float)surfaceLevel.Description.Width / num;
					float num4 = (float)surfaceLevel.Description.Height / num2;
					device_0.BeginScene();
					device_0.Clear(ClearFlags.ZBuffer | ClearFlags.Target, new Color4(0f, 0f, 0f, 0f), 1f, 0);
					Sprite sprite = new Sprite(device_0);
					sprite.Begin(SpriteFlags.None);
					sprite.Transform = Matrix.Scaling(new Vector3(num3 / (float)this.surface_2.Description.Width, num4 / (float)this.surface_2.Description.Height, 0f));
					int num5 = 0;
					while ((float)num5 < num)
					{
						int num6 = 0;
						while ((float)num6 < num2)
						{
							Vector3 value = new Vector3((float)(num5 * this.surface_2.Description.Width), (float)(num6 * this.surface_2.Description.Height), 0f);
							sprite.Draw(this.bool_2 ? this.texture_8 : this.texture_9, new Vector3?(Vector3.Zero), new Vector3?(value), new Color4(1f, 1f, 1f, 1f));
							num6++;
						}
						num5++;
					}
					sprite.End();
					device_0.EndScene();
					surfaceLevel.Dispose();
					surface.Dispose();
					sprite.Dispose();
				}
			}
			device_0.SetRenderTarget(0, this.surface_0);
			device_0.DepthStencilSurface = this.surface_6;
			device_0.Clear(ClearFlags.ZBuffer | ClearFlags.Target, new Color4(0f, 0f, 0f, 0f), 1f, 0);
			XmlNodeList xmlNodeList8 = xmlDocument_0.SelectNodes("/preset/complate");
			foreach (object obj7 in xmlNodeList8)
			{
				XmlElement xmlElement7 = (XmlElement)obj7;
				xmlElement7.GetAttribute("name");
				ResKey resKey2 = new ResKey(xmlElement7.GetAttribute("reskey"));
				DBPFEntry dbpfentry2 = Class76.smethod_26(resKey2);
				if (dbpfentry2 == null)
				{
					throw new Exception("Complate not found");
				}
				if (xmlElement_0 != null)
				{
					xmlElement_0.SetAttribute("break", "true");
				}
				XmlDocument xmlDocument2 = null;
				if (resKey2.TypeId == 54137909U)
				{
					xmlDocument2 = (dbpfentry2 as TXTC).ToComplate("shitthesame", TXTC.ComplateType.Other);
				}
				else
				{
					xmlDocument2 = (dbpfentry2 as XML).Documents[0];
				}
				if (xmlDocument2 == null)
				{
					throw new Exception("Complate/PROP not found");
				}
				string text4 = xmlDocument2.OuterXml;
				if (xmlElement_0 != null)
				{
					xmlElement_0.RemoveAttribute("break");
				}
				XmlNodeList xmlNodeList9 = xmlDocument_0.SelectNodes("/preset/complate/value");
				foreach (object obj8 in xmlNodeList9)
				{
					XmlElement xmlElement8 = (XmlElement)obj8;
					text4 = text4.Replace("($" + xmlElement8.GetAttribute("key") + ")", xmlElement8.GetAttribute("value"));
				}
				XmlNodeList xmlNodeList10 = xmlDocument2.SelectNodes("/complate/variables/param");
				foreach (object obj9 in xmlNodeList10)
				{
					XmlElement xmlElement9 = (XmlElement)obj9;
					text4 = text4.Replace("($" + xmlElement9.GetAttribute("name") + ")", xmlElement9.GetAttribute("default"));
				}
				xmlDocument2 = new XmlDocument();
				xmlDocument2.LoadXml(text4);
				XmlNodeList xmlNodeList11 = xmlDocument2.SelectNodes("/complate/texturePart");
				foreach (object obj10 in xmlNodeList11)
				{
					XmlElement xmlElement10 = (XmlElement)obj10;
					if (xmlElement10.GetAttribute("part").ToLower().Equals(string_7.ToLower()))
					{
						XmlNodeList xmlNodeList12 = xmlElement10.SelectNodes("./destination");
						foreach (object obj11 in xmlNodeList12)
						{
							XmlElement xmlElement11 = (XmlElement)obj11;
							if (xmlElement11.GetAttribute("textureName").ToLower().Contains(string_6.ToLower()))
							{
								XmlNodeList xmlNodeList13 = xmlElement11.SelectNodes("./step");
								foreach (object obj12 in xmlNodeList13)
								{
									XmlElement xmlElement12 = (XmlElement)obj12;
									string text5 = xmlElement12.GetAttribute("type").ToLower();
									string text3;
									switch (text3 = text5)
									{
									case "skintone":
										this.method_4(device_0, xmlElement12);
										break;
									case "settarget":
										this.int_0 = (xmlElement12.GetAttribute("renderTarget").Equals("RenderTarget_B") ? 1 : 0);
										device_0.SetRenderTarget(0, (this.int_0 == 1) ? (this.bool_1 ? this.surface_5 : this.surface_4) : (this.bool_0 ? this.surface_1 : this.surface_0));
										break;
									case "colorfill":
										this.method_2(device_0, xmlElement12, false);
										break;
									case "channelselect":
										this.method_5(device_0, xmlElement12, false);
										break;
									case "drawimage":
										this.method_3(device_0, xmlElement12, false);
										break;
									case "drawfabric":
										this.method_6(device_0, xmlElement12, xmlDocument_0, false);
										break;
									case "hsvshift":
										this.method_7(device_0, xmlElement12, false);
										break;
									}
									if (xmlElement12.GetAttribute("break").Equals("true"))
									{
										break;
									}
									this.string_5.Equals("DiffuseMap");
								}
							}
						}
					}
				}
			}
		}

		// Token: 0x060001A9 RID: 425 RVA: 0x00026280 File Offset: 0x00024480
		private void method_2(Device device_0, XmlElement xmlElement_0, bool bool_3)
		{
			if (this.method_8(xmlElement_0))
			{
				this.method_9(xmlElement_0);
				this.method_11(xmlElement_0);
				string[] array = xmlElement_0.GetAttribute("color").Split(new char[]
				{
					','
				});
				int value = Color.FromArgb((int)((byte)(Convert.ToSingle(array[3], this.cultureInfo_0) * 255f)), (int)((byte)(Convert.ToSingle(array[0], this.cultureInfo_0) * 255f)), (int)((byte)(Convert.ToSingle(array[1], this.cultureInfo_0) * 255f)), (int)((byte)(Convert.ToSingle(array[2], this.cultureInfo_0) * 255f))).ToArgb();
				this.effect_0.Technique = this.effect_0.GetTechnique("ColorFill");
				this.effect_0.SetValue<int>(this.effect_0.GetParameter(null, "fillColor"), value);
				this.effect_0.CommitChanges();
				if (bool_3)
				{
					this.method_14(device_0);
				}
				else
				{
					this.method_13(device_0);
				}
			}
		}

		// Token: 0x060001AA RID: 426 RVA: 0x00026384 File Offset: 0x00024584
		private void method_3(Device device_0, XmlElement xmlElement_0, bool bool_3)
		{
			if (this.method_8(xmlElement_0))
			{
				this.method_9(xmlElement_0);
				this.method_11(xmlElement_0);
				this.method_12(device_0, xmlElement_0);
				Texture texture = null;
				string attribute = xmlElement_0.GetAttribute("texture");
				bool flag = false;
				if (attribute.Equals("RenderTexture_B"))
				{
					texture = (this.bool_1 ? this.texture_10 : this.texture_11);
					flag = true;
				}
				else
				{
					if (!attribute.Equals("RenderTexture_A"))
					{
						if (attribute.StartsWith("key:"))
						{
							try
							{
								ResKey resKey = new ResKey(attribute);
								if (Class27.hashtable_0.ContainsKey(resKey))
								{
									texture = (Class27.hashtable_0[resKey] as Texture);
								}
								else
								{
									DDS dds = Class76.smethod_30(resKey, false, false) as DDS;
									if (dds == null)
									{
										goto IL_115;
									}
									texture = Texture.FromMemory(device_0, dds.GetData());
								}
								goto IL_160;
							}
							catch (Exception ex)
							{
								this.string_0 = this.string_0 + ex.Message + "\n\n";
								goto IL_160;
							}
						}
						ResKey resKey2 = Class76.smethod_2(attribute, DBPFType.DDS);
						if (resKey2 != null)
						{
							if (Class27.hashtable_0.ContainsKey(resKey2))
							{
								texture = (Class27.hashtable_0[resKey2] as Texture);
								goto IL_160;
							}
							DDS dds2 = Class76.smethod_30(resKey2, false, false) as DDS;
							if (dds2 != null)
							{
								texture = Texture.FromMemory(device_0, dds2.GetData());
								goto IL_160;
							}
						}
						IL_115:
						return;
					}
					texture = (this.bool_0 ? this.texture_6 : this.texture_7);
					flag = true;
				}
				IL_160:
				this.effect_0.Technique = this.effect_0.GetTechnique("DrawImage");
				this.effect_0.SetTexture(this.effect_0.GetParameter(null, "srcTexture"), texture);
				this.effect_0.CommitChanges();
				if (bool_3)
				{
					this.method_14(device_0);
				}
				else
				{
					this.method_13(device_0);
				}
				if (!flag)
				{
					texture.Dispose();
				}
			}
		}

		// Token: 0x060001AB RID: 427 RVA: 0x00026564 File Offset: 0x00024764
		private void method_4(Device device_0, XmlElement xmlElement_0)
		{
			if (this.method_8(xmlElement_0))
			{
				this.method_9(xmlElement_0);
				this.method_11(xmlElement_0);
				xmlElement_0.GetAttribute("color").Split(new char[]
				{
					','
				});
				int value = Settings.Default.SkinColor.ToArgb();
				this.effect_0.Technique = this.effect_0.GetTechnique("ColorFill");
				this.effect_0.SetValue<int>(this.effect_0.GetParameter(null, "fillColor"), value);
				this.effect_0.CommitChanges();
				this.method_13(device_0);
			}
		}

		// Token: 0x060001AC RID: 428 RVA: 0x0002660C File Offset: 0x0002480C
		private void method_5(Device device_0, XmlElement xmlElement_0, bool bool_3)
		{
			if (this.method_8(xmlElement_0))
			{
				this.method_9(xmlElement_0);
				this.method_11(xmlElement_0);
				this.method_12(device_0, xmlElement_0);
				string[] array = xmlElement_0.GetAttribute("select").Split(new char[]
				{
					','
				});
				float num = Convert.ToSingle(array[0], this.cultureInfo_0);
				float num2 = Convert.ToSingle(array[1], this.cultureInfo_0);
				float num3 = Convert.ToSingle(array[2], this.cultureInfo_0);
				float num4 = Convert.ToSingle(array[3], this.cultureInfo_0);
				this.effect_0.SetValue<int>(this.effect_0.GetParameter(null, "rChannel"), (int)num);
				this.effect_0.SetValue<int>(this.effect_0.GetParameter(null, "gChannel"), (int)num2);
				this.effect_0.SetValue<int>(this.effect_0.GetParameter(null, "bChannel"), (int)num3);
				this.effect_0.SetValue<int>(this.effect_0.GetParameter(null, "aChannel"), (int)num4);
				string attribute = xmlElement_0.GetAttribute("texture");
				Texture texture = null;
				bool flag = false;
				if (attribute.Equals("RenderTexture_B"))
				{
					texture = (this.bool_1 ? this.texture_10 : this.texture_11);
					flag = true;
				}
				else
				{
					if (!attribute.Equals("RenderTexture_A"))
					{
						if (attribute.StartsWith("key:"))
						{
							try
							{
								ResKey resKey = new ResKey(attribute);
								if (Class27.hashtable_0.ContainsKey(resKey))
								{
									texture = (Class27.hashtable_0[resKey] as Texture);
								}
								else
								{
									DDS dds = Class76.smethod_30(resKey, false, false) as DDS;
									if (dds == null)
									{
										goto IL_205;
									}
									texture = Texture.FromMemory(device_0, dds.GetData());
								}
								goto IL_252;
							}
							catch (Exception ex)
							{
								this.string_0 = this.string_0 + ex.Message + "\n\n";
								goto IL_252;
							}
						}
						ResKey resKey2 = Class76.smethod_2(attribute, DBPFType.DDS);
						if (resKey2 != null)
						{
							if (Class27.hashtable_0.ContainsKey(resKey2))
							{
								texture = (Class27.hashtable_0[resKey2] as Texture);
								goto IL_252;
							}
							DDS dds2 = Class76.smethod_30(resKey2, false, false) as DDS;
							if (dds2 != null)
							{
								texture = Texture.FromMemory(device_0, dds2.GetData());
								goto IL_252;
							}
						}
						IL_205:
						return;
					}
					texture = (this.bool_0 ? this.texture_6 : this.texture_7);
					flag = true;
				}
				IL_252:
				this.effect_0.Technique = this.effect_0.GetTechnique("ChannelSelect");
				this.effect_0.SetTexture(this.effect_0.GetParameter(null, "srcTexture"), texture);
				this.effect_0.CommitChanges();
				if (bool_3)
				{
					this.method_14(device_0);
				}
				else
				{
					this.method_13(device_0);
				}
				if (!flag)
				{
					texture.Dispose();
				}
			}
		}

		// Token: 0x060001AD RID: 429 RVA: 0x000268E4 File Offset: 0x00024AE4
		private void method_6(Device device_0, XmlElement xmlElement_0, XmlDocument xmlDocument_0, bool bool_3)
		{
			if (this.method_8(xmlElement_0))
			{
				xmlElement_0.GetAttribute("pattern").ToLower();
				xmlDocument_0.SelectNodes("/preset/complate/pattern");
				string attribute = xmlElement_0.GetAttribute("pattern");
				Texture texture = null;
				if (attribute.ToLower().Contains("pattern a"))
				{
					texture = this.texture_0;
				}
				else if (attribute.ToLower().Contains("pattern b"))
				{
					texture = this.texture_1;
				}
				else if (attribute.ToLower().Contains("pattern c"))
				{
					texture = this.texture_2;
				}
				else if (attribute.ToLower().Contains("pattern d"))
				{
					texture = this.texture_3;
				}
				else if (attribute.ToLower().Contains("logo"))
				{
					texture = this.texture_4;
				}
				if (texture == null)
				{
					attribute = xmlElement_0.GetAttribute("texture");
					if (attribute == this.string_1)
					{
						texture = this.texture_0;
					}
					else if (attribute == this.string_2)
					{
						texture = this.texture_1;
					}
					else if (attribute == this.string_3)
					{
						texture = this.texture_2;
					}
					else
					{
						if (!(attribute == this.string_4))
						{
							if (attribute.StartsWith("key:"))
							{
								try
								{
									ResKey resKey = new ResKey(attribute);
									if (Class27.hashtable_0.ContainsKey(resKey))
									{
										texture = (Class27.hashtable_0[resKey] as Texture);
									}
									else
									{
										DDS dds = Class76.smethod_30(resKey, false, false) as DDS;
										if (dds == null)
										{
											goto IL_1C2;
										}
										texture = Texture.FromMemory(device_0, dds.GetData());
									}
									goto IL_20A;
								}
								catch (Exception ex)
								{
									this.string_0 = this.string_0 + ex.Message + "\n\n";
									goto IL_20A;
								}
							}
							ResKey resKey2 = Class76.smethod_2(attribute, DBPFType.DDS);
							if (resKey2 != null)
							{
								if (Class27.hashtable_0.ContainsKey(resKey2))
								{
									texture = (Class27.hashtable_0[resKey2] as Texture);
									goto IL_20A;
								}
								DDS dds = Class76.smethod_30(resKey2, false, false) as DDS;
								if (dds != null)
								{
									texture = Texture.FromMemory(device_0, dds.GetData());
									goto IL_20A;
								}
							}
							IL_1C2:
							return;
						}
						texture = this.texture_3;
					}
				}
				IL_20A:
				this.method_9(xmlElement_0);
				this.method_11(xmlElement_0);
				this.method_12(device_0, xmlElement_0);
				this.effect_0.Technique = this.effect_0.GetTechnique("DrawFabric");
				this.effect_0.SetTexture(this.effect_0.GetParameter(null, "srcTexture"), texture);
				this.effect_0.CommitChanges();
				if (bool_3)
				{
					this.method_14(device_0);
				}
				else
				{
					this.method_13(device_0);
				}
			}
		}

		// Token: 0x060001AE RID: 430 RVA: 0x00026B7C File Offset: 0x00024D7C
		private void method_7(Device device_0, XmlElement xmlElement_0, bool bool_3)
		{
			if (this.method_8(xmlElement_0))
			{
				string attribute = xmlElement_0.GetAttribute("texture");
				Texture texture = null;
				if (attribute.StartsWith("key:"))
				{
					try
					{
						ResKey resKey = new ResKey(attribute);
						if (Class27.hashtable_0.ContainsKey(resKey))
						{
							texture = (Class27.hashtable_0[resKey] as Texture);
						}
						else
						{
							DDS dds = Class76.smethod_30(resKey, false, false) as DDS;
							if (dds == null)
							{
								goto IL_D6;
							}
							byte[] data = dds.GetData();
							texture = Texture.FromMemory(device_0, data, dds.MipMaps[0].width, dds.MipMaps[0].height, 1, Usage.None, Format.A8R8G8B8, Pool.Managed, Filter.None, Filter.None, 0);
						}
						goto IL_14F;
					}
					catch (Exception ex)
					{
						this.string_0 = this.string_0 + ex.Message + "\n\n";
						goto IL_14F;
					}
				}
				ResKey resKey2 = Class76.smethod_2(attribute, DBPFType.DDS);
				if (resKey2 != null)
				{
					if (Class27.hashtable_0.ContainsKey(resKey2))
					{
						texture = (Class27.hashtable_0[resKey2] as Texture);
						goto IL_14F;
					}
					DDS dds2 = Class76.smethod_30(resKey2, false, false) as DDS;
					if (dds2 != null)
					{
						byte[] data2 = dds2.GetData();
						texture = Texture.FromMemory(device_0, data2, dds2.MipMaps[0].width, dds2.MipMaps[0].height, 1, Usage.None, Format.A8R8G8B8, Pool.Managed, Filter.None, Filter.None, 0);
						goto IL_14F;
					}
				}
				IL_D6:
				return;
				IL_14F:
				Surface surfaceLevel = texture.GetSurfaceLevel(0);
				Texture texture2 = new Texture(device_0, surfaceLevel.Description.Width, surfaceLevel.Description.Height, 1, Usage.RenderTarget, surfaceLevel.Description.Format, Pool.Default);
				Texture texture3 = new Texture(device_0, surfaceLevel.Description.Width, surfaceLevel.Description.Height, 1, Usage.RenderTarget, surfaceLevel.Description.Format, Pool.Default);
				Surface surfaceLevel2 = texture2.GetSurfaceLevel(0);
				Surface surfaceLevel3 = texture3.GetSurfaceLevel(0);
				Surface surface = Surface.CreateDepthStencil(device_0, surfaceLevel2.Description.Width, surfaceLevel2.Description.Height, Format.D16, surfaceLevel2.Description.MultisampleType, surfaceLevel2.Description.MultisampleQuality, true);
				string[] array = xmlElement_0.GetAttribute("hsvShift").Split(new char[]
				{
					','
				});
				try
				{
					this.effect_0.SetValue<float>(this.effect_0.GetParameter(null, "hShift"), Convert.ToSingle(array[0], this.cultureInfo_0));
					this.effect_0.SetValue<float>(this.effect_0.GetParameter(null, "sShift"), Convert.ToSingle(array[1], this.cultureInfo_0));
					this.effect_0.SetValue<float>(this.effect_0.GetParameter(null, "vShift"), Convert.ToSingle(array[2], this.cultureInfo_0));
				}
				catch (Exception)
				{
				}
				this.effect_0.CommitChanges();
				Surface renderTarget = device_0.GetRenderTarget(0);
				Surface depthStencilSurface = device_0.DepthStencilSurface;
				device_0.SetRenderTarget(0, surfaceLevel2);
				device_0.DepthStencilSurface = surface;
				device_0.Clear(ClearFlags.ZBuffer | ClearFlags.Target, Color.FromArgb(0, 0, 0, 0).ToArgb(), 1f, 0);
				this.effect_0.Technique = this.effect_0.GetTechnique("HSVShift");
				Sprite sprite = new Sprite(device_0);
				this.effect_0.Begin(FX.None);
				Color4 color = new Color4(Color.Transparent);
				device_0.BeginScene();
				sprite.Begin(SpriteFlags.None);
				this.effect_0.BeginPass(0);
				sprite.Draw(texture, new Vector3?(new Vector3(0f, 0f, 0f)), new Vector3?(new Vector3(0f, 0f, 0f)), color);
				this.effect_0.EndPass();
				sprite.End();
				device_0.EndScene();
				device_0.SetRenderTarget(0, surfaceLevel3);
				device_0.BeginScene();
				sprite.Begin(SpriteFlags.None);
				this.effect_0.BeginPass(1);
				sprite.Draw(texture2, new Vector3?(new Vector3(0f, 0f, 0f)), new Vector3?(new Vector3(0f, 0f, 0f)), color);
				this.effect_0.EndPass();
				sprite.End();
				device_0.EndScene();
				this.effect_0.End();
				sprite.Dispose();
				device_0.SetRenderTarget(0, renderTarget);
				device_0.DepthStencilSurface = depthStencilSurface;
				surface.Dispose();
				this.method_9(xmlElement_0);
				this.method_11(xmlElement_0);
				this.effect_0.Technique = this.effect_0.GetTechnique("DrawImage");
				this.effect_0.SetTexture(this.effect_0.GetParameter(null, "srcTexture"), texture3);
				this.effect_0.CommitChanges();
				if (bool_3)
				{
					this.method_14(device_0);
				}
				else
				{
					this.method_13(device_0);
				}
				texture2.Dispose();
				surfaceLevel2.Dispose();
				texture3.Dispose();
				surfaceLevel3.Dispose();
				texture.Dispose();
				surfaceLevel.Dispose();
			}
		}

		// Token: 0x060001AF RID: 431 RVA: 0x000270BC File Offset: 0x000252BC
		private bool method_8(XmlElement xmlElement_0)
		{
			bool result;
			if (!xmlElement_0.GetAttribute("enabled").ToLower().Equals("true"))
			{
				result = string.IsNullOrEmpty(xmlElement_0.GetAttribute("enabled"));
			}
			else
			{
				result = true;
			}
			return result;
		}

		// Token: 0x060001B0 RID: 432 RVA: 0x00027100 File Offset: 0x00025300
		private void method_9(XmlElement xmlElement_0)
		{
			string text = xmlElement_0.GetAttribute("colorWrite").ToLower();
			Class27.Enum2 value = Class27.Enum2.const_2;
			string a;
			if ((a = text) != null)
			{
				if (!(a == "alpha"))
				{
					if (!(a == "red"))
					{
						if (!(a == "green"))
						{
							if (!(a == "blue"))
							{
								if (a == "color" || a == "rgb")
								{
									value = Class27.Enum2.const_2;
								}
							}
							else
							{
								value = Class27.Enum2.const_5;
							}
						}
						else
						{
							value = Class27.Enum2.const_4;
						}
					}
					else
					{
						value = Class27.Enum2.const_3;
					}
				}
				else
				{
					value = Class27.Enum2.const_1;
				}
			}
			this.effect_0.SetValue<int>(this.effect_0.GetParameter(null, "cWrite"), (int)value);
		}

		// Token: 0x060001B1 RID: 433 RVA: 0x000271A8 File Offset: 0x000253A8
		private void method_10(string string_6, string string_7)
		{
			string key;
			Class27.Enum1 value;
			switch (key = string_7.ToLower())
			{
			case "srcalpha":
				value = Class27.Enum1.const_2;
				goto IL_E0;
			case "destalpha":
				value = Class27.Enum1.const_1;
				goto IL_E0;
			case "invsrcalpha":
				value = Class27.Enum1.const_4;
				goto IL_E0;
			case "invdestalpha":
				value = Class27.Enum1.const_3;
				goto IL_E0;
			case "one":
				value = Class27.Enum1.const_5;
				goto IL_E0;
			case "srccolor":
				value = Class27.Enum1.const_7;
				goto IL_E0;
			case "destcolor":
				value = Class27.Enum1.const_8;
				goto IL_E0;
			case "zero":
				value = Class27.Enum1.const_6;
				goto IL_E0;
			}
			value = Class27.Enum1.const_5;
			IL_E0:
			this.effect_0.SetValue<int>(this.effect_0.GetParameter(null, string_6), (int)value);
		}

		// Token: 0x060001B2 RID: 434 RVA: 0x000272B4 File Offset: 0x000254B4
		private void method_11(XmlElement xmlElement_0)
		{
			this.effect_0.SetValue<int>(this.effect_0.GetParameter(null, "mask"), 0);
			this.method_10("srcBlend", xmlElement_0.GetAttribute("srcBlend"));
			this.method_10("dstBlend", xmlElement_0.GetAttribute("dstBlend"));
			this.effect_0.SetValue<int>(this.effect_0.GetParameter(null, "blend"), xmlElement_0.GetAttribute("enableBlending").ToLower().Equals("true") ? 1 : 0);
		}

		// Token: 0x060001B3 RID: 435 RVA: 0x0002734C File Offset: 0x0002554C
		private void method_12(Device device_0, XmlElement xmlElement_0)
		{
			if (this.texture_5 != null)
			{
				this.texture_5.Dispose();
				this.texture_5 = null;
			}
			if (!string.IsNullOrEmpty(xmlElement_0.GetAttribute("mask")))
			{
				this.effect_0.SetValue<int>(this.effect_0.GetParameter(null, "mask"), 1);
				this.effect_0.SetValue<float>(this.effect_0.GetParameter(null, "maskBias"), Convert.ToSingle(xmlElement_0.GetAttribute("maskBias"), this.cultureInfo_0));
				string[] array = xmlElement_0.GetAttribute("maskSelect").Split(new char[]
				{
					','
				});
				this.effect_0.SetValue<float>(this.effect_0.GetParameter(null, "rmask"), Convert.ToSingle(array[0], this.cultureInfo_0));
				this.effect_0.SetValue<float>(this.effect_0.GetParameter(null, "gmask"), Convert.ToSingle(array[1], this.cultureInfo_0));
				this.effect_0.SetValue<float>(this.effect_0.GetParameter(null, "bmask"), Convert.ToSingle(array[2], this.cultureInfo_0));
				this.effect_0.SetValue<float>(this.effect_0.GetParameter(null, "amask"), Convert.ToSingle(array[3], this.cultureInfo_0));
				string attribute = xmlElement_0.GetAttribute("mask");
				if (attribute.StartsWith("key:"))
				{
					try
					{
						ResKey resKey = new ResKey(attribute);
						if (Class27.hashtable_0.ContainsKey(resKey))
						{
							this.texture_5 = (Class27.hashtable_0[resKey] as Texture);
						}
						else
						{
							DDS dds = Class76.smethod_30(resKey, false, false) as DDS;
							if (dds == null)
							{
								goto IL_1F0;
							}
							this.texture_5 = Texture.FromMemory(device_0, dds.GetData());
						}
						goto IL_242;
					}
					catch (Exception ex)
					{
						this.string_0 = this.string_0 + ex.Message + "\n\n";
						goto IL_242;
					}
				}
				ResKey resKey2 = Class76.smethod_2(attribute, DBPFType.DDS);
				if (resKey2 != null)
				{
					if (Class27.hashtable_0.ContainsKey(resKey2))
					{
						this.texture_5 = (Class27.hashtable_0[resKey2] as Texture);
						goto IL_242;
					}
					DDS dds2 = Class76.smethod_30(resKey2, false, false) as DDS;
					if (dds2 != null)
					{
						this.texture_5 = Texture.FromMemory(device_0, dds2.GetData());
						goto IL_242;
					}
				}
				IL_1F0:
				return;
				IL_242:
				this.effect_0.SetTexture(this.effect_0.GetParameter(null, "maskTexture"), this.texture_5);
			}
		}

		// Token: 0x060001B4 RID: 436 RVA: 0x000275D0 File Offset: 0x000257D0
		private void method_13(Device device_0)
		{
			Sprite sprite = new Sprite(device_0);
			device_0.BeginScene();
			int num = this.effect_0.Begin(FX.None);
			for (int i = 0; i < num; i++)
			{
				sprite.Begin(SpriteFlags.None);
				this.effect_0.BeginPass(i);
				sprite.Draw((this.int_0 == 1) ? (this.bool_1 ? this.texture_10 : this.texture_11) : (this.bool_0 ? this.texture_6 : this.texture_7), new Vector3?(new Vector3(0f, 0f, 0f)), new Vector3?(Vector3.Zero), new Color4(Color.White.ToArgb()));
				this.effect_0.EndPass();
				sprite.End();
			}
			this.effect_0.End();
			sprite.Dispose();
			device_0.EndScene();
			if (this.int_0 == 1)
			{
				this.bool_1 = !this.bool_1;
			}
			else
			{
				this.bool_0 = !this.bool_0;
			}
			device_0.SetRenderTarget(0, (this.int_0 == 1) ? (this.bool_1 ? this.surface_5 : this.surface_4) : (this.bool_0 ? this.surface_1 : this.surface_0));
		}

		// Token: 0x060001B5 RID: 437 RVA: 0x00027728 File Offset: 0x00025928
		private void method_14(Device device_0)
		{
			Sprite sprite = new Sprite(device_0);
			device_0.BeginScene();
			int num = this.effect_0.Begin(FX.None);
			for (int i = 0; i < num; i++)
			{
				sprite.Begin(SpriteFlags.None);
				this.effect_0.BeginPass(i);
				sprite.Draw(this.bool_2 ? this.texture_8 : this.texture_9, new Vector3?(new Vector3(0f, 0f, 0f)), new Vector3?(Vector3.Zero), new Color4(Color.White.ToArgb()));
				this.effect_0.EndPass();
				sprite.End();
			}
			this.effect_0.End();
			sprite.Dispose();
			device_0.EndScene();
			this.bool_2 = !this.bool_2;
			device_0.SetRenderTarget(0, this.bool_2 ? this.surface_3 : this.surface_2);
		}

		// Token: 0x0400014A RID: 330
		public static Hashtable hashtable_0 = new Hashtable();

		// Token: 0x0400014B RID: 331
		private Size size;

		// Token: 0x0400014C RID: 332
		private Effect effect_0;

		// Token: 0x0400014D RID: 333
		private string string_0;

		// Token: 0x0400014E RID: 334
		private Texture texture_0;

		// Token: 0x0400014F RID: 335
		private Texture texture_1;

		// Token: 0x04000150 RID: 336
		private Texture texture_2;

		// Token: 0x04000151 RID: 337
		private Texture texture_3;

		// Token: 0x04000152 RID: 338
		private Texture texture_4;

		// Token: 0x04000153 RID: 339
		private Texture texture_5;

		// Token: 0x04000154 RID: 340
		private Texture texture_6;

		// Token: 0x04000155 RID: 341
		private Texture texture_7;

		// Token: 0x04000156 RID: 342
		private Texture texture_8;

		// Token: 0x04000157 RID: 343
		private Texture texture_9;

		// Token: 0x04000158 RID: 344
		private Surface surface_0;

		// Token: 0x04000159 RID: 345
		private Surface surface_1;

		// Token: 0x0400015A RID: 346
		private Surface surface_2;

		// Token: 0x0400015B RID: 347
		private Surface surface_3;

		// Token: 0x0400015C RID: 348
		private Texture texture_10;

		// Token: 0x0400015D RID: 349
		private Texture texture_11;

		// Token: 0x0400015E RID: 350
		private Surface surface_4;

		// Token: 0x0400015F RID: 351
		private Surface surface_5;

		// Token: 0x04000160 RID: 352
		private Surface surface_6;

		// Token: 0x04000161 RID: 353
		private Surface surface_7;

		// Token: 0x04000162 RID: 354
		private string string_1;

		// Token: 0x04000163 RID: 355
		private string string_2;

		// Token: 0x04000164 RID: 356
		private string string_3;

		// Token: 0x04000165 RID: 357
		private string string_4;

		// Token: 0x04000166 RID: 358
		private bool bool_0;

		// Token: 0x04000167 RID: 359
		private bool bool_1;

		// Token: 0x04000168 RID: 360
		private bool bool_2;

		// Token: 0x04000169 RID: 361
		private int int_0;

		// Token: 0x0400016A RID: 362
		private CultureInfo cultureInfo_0;

		// Token: 0x0400016B RID: 363
		private string string_5;

		// Token: 0x0200002D RID: 45
		public enum Enum1
		{
			// Token: 0x0400016D RID: 365
			const_0 = -1,
			// Token: 0x0400016E RID: 366
			const_1,
			// Token: 0x0400016F RID: 367
			const_2,
			// Token: 0x04000170 RID: 368
			const_3,
			// Token: 0x04000171 RID: 369
			const_4,
			// Token: 0x04000172 RID: 370
			const_5,
			// Token: 0x04000173 RID: 371
			const_6,
			// Token: 0x04000174 RID: 372
			const_7,
			// Token: 0x04000175 RID: 373
			const_8
		}

		// Token: 0x0200002E RID: 46
		public enum Enum2
		{
			// Token: 0x04000177 RID: 375
			const_0 = -1,
			// Token: 0x04000178 RID: 376
			const_1,
			// Token: 0x04000179 RID: 377
			const_2,
			// Token: 0x0400017A RID: 378
			const_3,
			// Token: 0x0400017B RID: 379
			const_4,
			// Token: 0x0400017C RID: 380
			const_5,
			// Token: 0x0400017D RID: 381
			const_6
		}
	}
}
