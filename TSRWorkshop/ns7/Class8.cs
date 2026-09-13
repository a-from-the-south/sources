using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using System.Xml;
using ns16;
using ns18;
using ns3;
using ns4;
using ns6;
using ns8;
using Package;
using Package.Sims3Files;
using Package.Sims3Files.InternalRCOL;
using Sims3WorkshopSDK;
using Sims3WorkshopSDK.Classes;
using Sims3WorkshopSDK.Interfaces;
using VisualHint.SmartPropertyGrid;

namespace ns7
{
	// Token: 0x0200006C RID: 108
	internal sealed class Class8 : Class2
	{
		// Token: 0x170000A5 RID: 165
		// (get) Token: 0x06000426 RID: 1062 RVA: 0x000481A0 File Offset: 0x000463A0
		// (set) Token: 0x06000427 RID: 1063 RVA: 0x0000444A File Offset: 0x0000264A
		public Dictionary<string, PropertyEnumerator> Categories { get; private set; }

		// Token: 0x170000A6 RID: 166
		// (get) Token: 0x06000428 RID: 1064 RVA: 0x000481B8 File Offset: 0x000463B8
		// (set) Token: 0x06000429 RID: 1065 RVA: 0x00004455 File Offset: 0x00002655
		public XmlDocument Preset
		{
			get
			{
				return this.xmlDocument_0;
			}
			set
			{
				this.xmlDocument_0 = value;
				this.method_9();
			}
		}

		// Token: 0x170000A7 RID: 167
		// (get) Token: 0x0600042A RID: 1066 RVA: 0x000481D0 File Offset: 0x000463D0
		public XmlDocument Complate
		{
			get
			{
				return this.xmlDocument_1;
			}
		}

		// Token: 0x170000A8 RID: 168
		// (get) Token: 0x0600042B RID: 1067 RVA: 0x000481E8 File Offset: 0x000463E8
		// (set) Token: 0x0600042C RID: 1068 RVA: 0x00048200 File Offset: 0x00046400
		public WALL.WallCategory WallCategory
		{
			get
			{
				return (WALL.WallCategory)this.uint_0;
			}
			set
			{
				this.uint_0 = (uint)value;
				if (this.xmlDocument_0 != null)
				{
					XmlElement xmlElement = this.xmlDocument_0.SelectSingleNode("/preset") as XmlElement;
					XmlElement xmlElement2 = xmlElement;
					string name = "unk1";
					uint num = (uint)value;
					xmlElement2.SetAttribute(name, num.ToString());
				}
			}
		}

		// Token: 0x170000A9 RID: 169
		// (get) Token: 0x0600042D RID: 1069 RVA: 0x00048248 File Offset: 0x00046448
		// (set) Token: 0x0600042E RID: 1070 RVA: 0x00048260 File Offset: 0x00046460
		public WALL.FloorCategory FloorCategory
		{
			get
			{
				return (WALL.FloorCategory)this.uint_1;
			}
			set
			{
				this.uint_1 = (uint)value;
				if (this.xmlDocument_0 != null)
				{
					XmlElement xmlElement = this.xmlDocument_0.SelectSingleNode("/preset") as XmlElement;
					XmlElement xmlElement2 = xmlElement;
					string name = "unk1";
					uint num = (uint)value;
					xmlElement2.SetAttribute(name, num.ToString());
				}
			}
		}

		// Token: 0x0600042F RID: 1071 RVA: 0x000482A8 File Offset: 0x000464A8
		public void method_9()
		{
			if (this.xmlDocument_0 != null)
			{
				XmlNode xmlNode = this.xmlDocument_0.SelectSingleNode("/preset/complate");
				ResKey resKey = new ResKey(xmlNode.Attributes["reskey"].Value);
				DBPFEntry dbpfentry = Class76.smethod_26(resKey);
				if (dbpfentry != null)
				{
					if (dbpfentry is TXTC)
					{
						this.xmlDocument_1 = (dbpfentry as TXTC).ToComplate("DiffuseMap", TXTC.ComplateType.Other);
					}
					else
					{
						XML xml = dbpfentry as XML;
						this.xmlDocument_1 = xml.Documents[0];
					}
					base.BeginUpdate();
					base.Clear();
					this.imageList_0 = new ImageList();
					this.imageList_0.ColorDepth = ColorDepth.Depth32Bit;
					this.imageList_0.ImageSize = new Size(64, 64);
					this.int_1 = 0;
					XmlNodeList xmlNodeList = this.xmlDocument_1.SelectNodes("/complate/variables/param");
					if (xmlNodeList == null)
					{
						throw new Exception("No variables found in base complate " + resKey);
					}
					int num = 0;
					this.Categories = new Dictionary<string, PropertyEnumerator>();
					PropertyEnumerator value = base.AppendRootCategory(9031, "Textures");
					PropertyEnumerator value2 = base.AppendRootCategory(9032, "Patterns");
					PropertyEnumerator value3 = base.AppendRootCategory(9033, "Stencils");
					PropertyEnumerator value4 = base.AppendRootCategory(9034, "Misc");
					this.Categories.Add("default", value);
					this.Categories.Add("Textures", value);
					this.Categories.Add("Patterns", value2);
					this.Categories.Add("Misc", value4);
					this.Categories.Add("Stencils", value3);
					int i;
					for (i = 0; i < xmlNodeList.Count; i++)
					{
						base.method_8(xmlNodeList[i], null, num, this.Categories, this.xmlDocument_0.SelectSingleNode("/preset/complate"));
					}
					XmlElement xmlElement = this.xmlDocument_0.SelectSingleNode("/preset") as XmlElement;
					if (xmlElement.GetAttribute("isWall").Equals("true"))
					{
						PropertyEnumerator underCategory = base.AppendRootCategory(9034, "Categories");
						uint num2 = Convert.ToUInt32(xmlElement.GetAttribute("unk1"));
						Convert.ToUInt32(xmlElement.GetAttribute("unk2"));
						Convert.ToUInt32(xmlElement.GetAttribute("unk3"));
						this.uint_0 = (this.uint_1 = num2);
						base.AppendProperty(underCategory, i++, "Wall Category", this, "WallCategory", "Wall category");
						base.AppendProperty(underCategory, i++, "Floor Category", this, "FloorCategory", "Floor category");
					}
					this.int_1++;
					base.AdjustLabelColumn();
					base.ShowAdditionalIndentation = false;
					if (this.Categories["Textures"].Children.Count == 0)
					{
						base.DeleteProperty(this.Categories["Textures"]);
					}
					if (this.Categories["Misc"].Children.Count == 0)
					{
						base.DeleteProperty(this.Categories["Misc"]);
					}
					base.ExpandAllProperties(this.Categories["Stencils"], false);
					base.EndUpdate();
				}
			}
		}

		// Token: 0x06000430 RID: 1072 RVA: 0x000485F8 File Offset: 0x000467F8
		protected override void OnPropertyButtonClicked(PropertyButtonClickedEventArgs e)
		{
			object previousValue = e.PropertyEnum.Property.Value.PreviousValue;
			if (previousValue.GetType() == typeof(PatternResKey))
			{
				PatternEditor patternEditor = new PatternEditor();
				patternEditor.Pattern = (PatternResKey)previousValue;
				XmlAttribute xmlAttribute = (XmlAttribute)e.PropertyEnum.Property.Value.Tag;
				XmlElement xmlElement = (XmlElement)xmlAttribute.OwnerDocument.SelectSingleNode("/preset/complate/pattern[@variable='" + xmlAttribute.OwnerElement.Attributes["key"].Value + "']");
				patternEditor.Preset = xmlElement;
				patternEditor.OnPatternChanged += this.method_13;
				if (patternEditor.ShowDialog(Class132.mainForm) == DialogResult.OK)
				{
					e.PropertyEnum.Property.Value.SetValue(patternEditor.Pattern);
					xmlElement.SetAttribute("name", patternEditor.PatternName);
					IProjectModel currentProjectModel = Class132.mainForm.CurrentProjectModel;
					if (currentProjectModel is Class80)
					{
						Class80 @class = currentProjectModel as Class80;
						ObjdModelControl control = @class.Control;
						XmlDocument ownerDocument = xmlAttribute.OwnerDocument;
						if (control.presetCombo.SelectedIndex == 0)
						{
							Class3.Class22 currentWrapper = control.MLODPropertyGrid.CurrentWrapper;
							if (currentWrapper is Class3.Class24)
							{
								Class3.Class24 class2 = currentWrapper as Class3.Class24;
								MLOD mlod = class2.MLOD;
								foreach (MLOD.MLODEntry mlodentry_ in mlod.Entries)
								{
									List<MATD> list = this.method_12(782826392, mlod, mlodentry_);
									using (List<MATD>.Enumerator enumerator2 = list.GetEnumerator())
									{
										if (enumerator2.MoveNext())
										{
											MATD matd = enumerator2.Current;
											foreach (MATD.MATDEntry matdentry in matd.Entries)
											{
												if (matdentry.Type == MATD.MATDEntryType.DiffuseMap)
												{
													int num = matdentry.GetIntValue()[0] & 16777215;
													if (((int)matdentry.Values[0] & 805306368) != 0)
													{
														try
														{
															RCOLFileEntry rcolfileEntry = mlod.Parent.ExternalResources[num - 1];
															DBPFEntry dbpfentry = Class76.smethod_26(rcolfileEntry.ResKey);
															if (dbpfentry is TXTC)
															{
																this.method_10(ownerDocument, dbpfentry as TXTC);
															}
														}
														catch (Exception ex)
														{
															MessageBox.Show("Could not update base material from complate\n\"" + ex.Message);
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
					base.NotifyPropertyChanged(new PropertyChangedEventArgs(e.PropertyEnum));
				}
				patternEditor.method_1();
			}
			base.OnPropertyButtonClicked(e);
		}

		// Token: 0x06000431 RID: 1073 RVA: 0x00048924 File Offset: 0x00046B24
		public void method_10(XmlDocument xmlDocument_2, TXTC txtc_0)
		{
			XmlNodeList xmlNodeList = xmlDocument_2.SelectNodes("/preset/complate");
			if (xmlNodeList.Count < 0)
			{
				throw new Exception("no complate node");
			}
			XmlElement xmlElement = xmlNodeList.Item(0) as XmlElement;
			string attribute = xmlElement.GetAttribute("reskey");
			XML xml = Class76.smethod_26(new ResKey(attribute)) as XML;
			if (xml == null)
			{
				throw new Exception("Could not locate complate");
			}
			XmlDocument xmlDocument_3 = xml.Documents[0];
			string text = "";
			XmlNodeList xmlNodeList2 = xmlDocument_2.SelectNodes("/preset/complate/value[@key=\"daeFileName\"]");
			if (xmlNodeList2.Count > 0)
			{
				text = (xmlNodeList2.Item(0) as XmlElement).GetAttribute("value");
			}
			TXTC txtc = txtc_0.Clone() as TXTC;
			txtc.IGTIndex.Clear();
			txtc.SuperBlocks.Clear();
			txtc.PropertySets.Clear();
			XmlNodeList xmlNodeList3 = xmlDocument_2.SelectNodes("/preset/complate/pattern");
			foreach (object obj in xmlNodeList3)
			{
				XmlElement xmlElement2 = (XmlElement)obj;
				xmlElement2.SelectNodes("value");
				string attribute2 = xmlElement2.GetAttribute("reskey");
				XML xml2 = Class76.smethod_26(new ResKey(attribute2)) as XML;
				this.method_11(xml2.Documents[0], xmlElement2, txtc, true, text + xmlElement2.GetAttribute("variable"));
			}
			this.method_11(xmlDocument_3, xmlElement, txtc, false, text);
			txtc_0.PropertySets = txtc.PropertySets;
			txtc_0.SuperBlocks = txtc.SuperBlocks;
			txtc_0.IGTIndex = txtc.IGTIndex;
		}

		// Token: 0x06000432 RID: 1074 RVA: 0x00048AE8 File Offset: 0x00046CE8
		private void method_11(XmlDocument xmlDocument_2, XmlElement xmlElement_0, TXTC txtc_0, bool bool_1, string string_2)
		{
			CultureInfo cultureInfo = new CultureInfo("en-US");
			cultureInfo.NumberFormat.NumberDecimalSeparator = ".";
			XmlDocument xmlDocument = xmlDocument_2;
			string text = xmlDocument.InnerXml;
			XmlNodeList xmlNodeList = xmlElement_0.SelectNodes("value");
			foreach (object obj in xmlNodeList)
			{
				XmlElement xmlElement = (XmlElement)obj;
				text = text.Replace("($" + xmlElement.GetAttribute("key") + ")", xmlElement.GetAttribute("value"));
			}
			XmlNodeList xmlNodeList2 = xmlDocument.SelectNodes("/complate/variables/param");
			foreach (object obj2 in xmlNodeList2)
			{
				XmlElement xmlElement2 = (XmlElement)obj2;
				text = text.Replace("($" + xmlElement2.GetAttribute("name") + ")", xmlElement2.GetAttribute("default"));
			}
			xmlDocument = new XmlDocument();
			xmlDocument.LoadXml(text);
			XmlNodeList xmlNodeList3 = xmlDocument.SelectNodes("/complate/texturePart/destination[@textureName=\"DiffuseMap\"]/step");
			if (xmlNodeList3.Count == 0)
			{
				xmlNodeList3 = xmlDocument.SelectNodes("/complate/texturePart/destination/step");
			}
			List<TXTC.PropertySet> propertySets = txtc_0.PropertySets;
			if (bool_1)
			{
				ulong hash = FNV64.GetHash(string_2);
				ResKey reskey = new ResKey("key:" + 54635721U.ToString("X8") + ":00000000:" + hash.ToString("X16"));
				IGTIndex item = new IGTIndex(reskey);
				if (txtc_0.IGTIndex.IndexOf(item) == -1)
				{
					txtc_0.IGTIndex.Add(item);
				}
				TXTC.FABC fabc = new TXTC.FABC(txtc_0);
				fabc.index = (byte)txtc_0.IGTIndex.IndexOf(item);
				txtc_0.SuperBlocks.Add(fabc);
				propertySets = fabc.txtc.PropertySets;
			}
			foreach (object obj3 in xmlNodeList3)
			{
				XmlElement xmlElement3 = (XmlElement)obj3;
				TXTC.PropertySet propertySet = new TXTC.PropertySet();
				if (bool_1)
				{
					propertySet.Properties.Add(new TXTC.PROPEntry((TXTC.EntryType)3788951583U, TXTC.EntryTypeCode.RectFloat, new float[]
					{
						0f,
						0f,
						1f,
						1f
					}));
					propertySet.Properties.Add(new TXTC.PROPEntry((TXTC.EntryType)2745891992U, TXTC.EntryTypeCode.RectFloat, new float[]
					{
						0f,
						0f,
						1f,
						1f
					}));
				}
				if (xmlElement3.GetAttribute("enabledBlending") == "")
				{
					propertySet.Properties.Add(new TXTC.PROPEntry((TXTC.EntryType)4227010759U, TXTC.EntryTypeCode.Boolean, false));
				}
				if (xmlElement3.GetAttribute("description") == "")
				{
					propertySet.Properties.Add(new TXTC.PROPEntry(TXTC.EntryType.Description, TXTC.EntryTypeCode.String, "Texture Step"));
				}
				if (xmlElement3.GetAttribute("uiVisible") == "")
				{
					propertySet.Properties.Add(new TXTC.PROPEntry((TXTC.EntryType)3643427979U, TXTC.EntryTypeCode.Boolean, false));
				}
				foreach (object obj4 in xmlElement3.Attributes)
				{
					XmlAttribute xmlAttribute = (XmlAttribute)obj4;
					string name;
					switch (name = xmlAttribute.Name)
					{
					case "mask":
						throw new Exception("Unhandled attribute, mask");
					case "maskBias":
						throw new Exception("Unhandled attribute, maskBias");
					case "type":
						propertySet.Properties.Add(new TXTC.PROPEntry(TXTC.EntryType.ID, TXTC.EntryTypeCode.UnsignedInt, (uint)TXTC.StepFromText(xmlAttribute.Value)));
						continue;
					case "uiVisible":
						propertySet.Properties.Add(new TXTC.PROPEntry((TXTC.EntryType)3643427979U, TXTC.EntryTypeCode.Boolean, xmlAttribute.Value.ToLower().Equals("true")));
						continue;
					case "description":
						propertySet.Properties.Add(new TXTC.PROPEntry(TXTC.EntryType.Description, TXTC.EntryTypeCode.String, xmlAttribute.Value));
						continue;
					case "color":
					{
						string[] array = xmlAttribute.Value.Split(new char[]
						{
							','
						});
						byte[] array2 = new byte[4];
						for (int i = 0; i < array.Length; i++)
						{
							float num2 = Convert.ToSingle(array[i], cultureInfo);
							array2[i] = (byte)(num2 * 255f);
						}
						propertySet.Properties.Add(new TXTC.PROPEntry((TXTC.EntryType)2954315994U, TXTC.EntryTypeCode.UnsignedInt, (uint)(((int)array2[3] << 24) + ((int)array2[0] << 16) + ((int)array2[1] << 8) + (int)array2[2])));
						continue;
					}
					case "colorWrite":
						if (xmlAttribute.Value.ToLower() == "alpha")
						{
							propertySet.Properties.Add(new TXTC.PROPEntry((TXTC.EntryType)2960866195U, TXTC.EntryTypeCode.SignedInt, 8));
							continue;
						}
						if (xmlAttribute.Value.ToLower() == "color")
						{
							propertySet.Properties.Add(new TXTC.PROPEntry((TXTC.EntryType)2960866195U, TXTC.EntryTypeCode.SignedInt, 7));
							continue;
						}
						if (xmlAttribute.Value.ToLower() == "red")
						{
							propertySet.Properties.Add(new TXTC.PROPEntry((TXTC.EntryType)2960866195U, TXTC.EntryTypeCode.SignedInt, 1));
							continue;
						}
						if (xmlAttribute.Value.ToLower() == "green")
						{
							propertySet.Properties.Add(new TXTC.PROPEntry((TXTC.EntryType)2960866195U, TXTC.EntryTypeCode.SignedInt, 2));
							continue;
						}
						if (xmlAttribute.Value.ToLower() == "blue")
						{
							propertySet.Properties.Add(new TXTC.PROPEntry((TXTC.EntryType)2960866195U, TXTC.EntryTypeCode.SignedInt, 4));
							continue;
						}
						throw new Exception("Unknown colorwrite value " + xmlAttribute.Value);
					case "renderTarget":
						if (xmlAttribute.Value.ToLower() == "rendertarget_a")
						{
							propertySet.Properties.Add(new TXTC.PROPEntry((TXTC.EntryType)2731086642U, TXTC.EntryTypeCode.UnsignedInt, 35560658U));
							continue;
						}
						if (xmlAttribute.Value.ToLower() == "rendertarget_b")
						{
							propertySet.Properties.Add(new TXTC.PROPEntry((TXTC.EntryType)2731086642U, TXTC.EntryTypeCode.UnsignedInt, 35560660U));
							continue;
						}
						throw new Exception("Unknown rendertarget: " + xmlAttribute.Value);
					case "texture":
					case "pattern":
						if (xmlAttribute.Value.ToLower().Contains("rendertexture"))
						{
							if (xmlAttribute.Value.ToLower().Equals("rendertexture_a"))
							{
								propertySet.Properties.Add(new TXTC.PROPEntry((TXTC.EntryType)2322597595U, TXTC.EntryTypeCode.UnsignedInt, 35560659U));
								continue;
							}
							if (xmlAttribute.Value.ToLower().Equals("rendertexture_b"))
							{
								propertySet.Properties.Add(new TXTC.PROPEntry((TXTC.EntryType)2322597595U, TXTC.EntryTypeCode.UnsignedInt, 35560661U));
								continue;
							}
							throw new Exception("Unknown imagesource: " + xmlAttribute.Value);
						}
						else
						{
							if (xmlAttribute.Name == "pattern")
							{
								propertySet.Properties.Add(new TXTC.PROPEntry(TXTC.EntryType.Width, TXTC.EntryTypeCode.UnsignedInt, 256U));
								propertySet.Properties.Add(new TXTC.PROPEntry(TXTC.EntryType.Height, TXTC.EntryTypeCode.UnsignedInt, 256U));
							}
							IGTIndex igtindex = null;
							if (xmlAttribute.Value.Contains("key:"))
							{
								igtindex = new IGTIndex(new ResKey(xmlAttribute.Value));
								if (!txtc_0.IGTIndex.Contains(igtindex))
								{
									txtc_0.IGTIndex.Add(igtindex);
								}
							}
							else if (xmlAttribute.Name == "pattern")
							{
								ulong hash2 = FNV64.GetHash(xmlAttribute.Value);
								ResKey resKey = new ResKey("key:" + 54635721U.ToString("X8") + ":00000000:" + hash2.ToString("X16"));
								igtindex = new IGTIndex(resKey);
								if (!txtc_0.IGTIndex.Contains(igtindex))
								{
									throw new Exception("Could not locate pattern reskey in TXTC: " + resKey);
								}
							}
							else
							{
								DDS dds = Class76.smethod_1(xmlAttribute.Value);
								if (dds != null)
								{
									igtindex = new IGTIndex(dds.GenerateResKey());
									if (!txtc_0.IGTIndex.Contains(igtindex))
									{
										txtc_0.IGTIndex.Add(igtindex);
									}
								}
							}
							if (igtindex == null)
							{
								throw new Exception("Could not locate IGTindex for " + xmlAttribute.Name + "/" + xmlAttribute.Value);
							}
							if (xmlAttribute.Name == "texture")
							{
								propertySet.Properties.Add(new TXTC.PROPEntry((TXTC.EntryType)4140598385U, TXTC.EntryTypeCode.TGIIndex, (byte)txtc_0.IGTIndex.IndexOf(igtindex)));
								continue;
							}
							propertySet.Properties.Add(new TXTC.PROPEntry((TXTC.EntryType)3707727227U, TXTC.EntryTypeCode.TGIIndex, (byte)txtc_0.IGTIndex.IndexOf(igtindex)));
							continue;
						}
						break;
					case "enableBlending":
						propertySet.Properties.Add(new TXTC.PROPEntry((TXTC.EntryType)4227010759U, TXTC.EntryTypeCode.Boolean, xmlAttribute.Value.ToLower().Equals("true")));
						continue;
					case "srcBlend":
					case "dstBlend":
					{
						string key;
						if ((key = xmlAttribute.Value.ToLower()) != null)
						{
							if (Class145.dictionary_3 == null)
							{
								Class145.dictionary_3 = new Dictionary<string, int>(8)
								{
									{
										"destalpha",
										0
									},
									{
										"srcalpha",
										1
									},
									{
										"invdestalpha",
										2
									},
									{
										"invsrcalpha",
										3
									},
									{
										"one",
										4
									},
									{
										"zero",
										5
									},
									{
										"destcolor",
										6
									},
									{
										"srccolor",
										7
									}
								};
							}
							int num3;
							if (Class145.dictionary_3.TryGetValue(key, out num3))
							{
								TXTC.BlendFactor blendFactor;
								switch (num3)
								{
								case 0:
									blendFactor = TXTC.BlendFactor.DestinationAlpha;
									break;
								case 1:
									blendFactor = TXTC.BlendFactor.SourceAlpha;
									break;
								case 2:
									blendFactor = TXTC.BlendFactor.InverseDestinationAlpha;
									break;
								case 3:
									blendFactor = TXTC.BlendFactor.InverseSourceAlpha;
									break;
								case 4:
									blendFactor = TXTC.BlendFactor.One;
									break;
								case 5:
									blendFactor = TXTC.BlendFactor.Zero;
									break;
								case 6:
									blendFactor = TXTC.BlendFactor.DestinationColour;
									break;
								case 7:
									blendFactor = TXTC.BlendFactor.SourceColour;
									break;
								default:
									goto IL_E72;
								}
								propertySet.Properties.Add(new TXTC.PROPEntry((xmlAttribute.Name == "srcBlend") ? ((TXTC.EntryType)3763727926U) : TXTC.EntryType.DestinationBlend, TXTC.EntryTypeCode.SignedInt, (int)blendFactor));
								continue;
							}
						}
						IL_E72:
						throw new Exception("Unknown blendtype: " + xmlAttribute.Value);
					}
					case "select":
					case "hsvShift":
					{
						string[] array3 = xmlAttribute.Value.Split(new char[]
						{
							','
						});
						float[] array4 = new float[4];
						for (int j = 0; j < array3.Length; j++)
						{
							array4[j] = Convert.ToSingle(array3[j], cultureInfo);
						}
						propertySet.Properties.Add(new TXTC.PROPEntry((xmlAttribute.Name == "select") ? ((TXTC.EntryType)3504771074U) : ((TXTC.EntryType)3061591800U), TXTC.EntryTypeCode.Vector4, array4));
						continue;
					}
					case "width":
					case "height":
					{
						uint num4 = Convert.ToUInt32(xmlAttribute.Value);
						propertySet.Properties.Add(new TXTC.PROPEntry((xmlAttribute.Name == "width") ? TXTC.EntryType.Width : TXTC.EntryType.Height, TXTC.EntryTypeCode.UnsignedInt, num4));
						continue;
					}
					case "rotation":
					{
						double num5 = xmlAttribute.Value.Contains("{") ? Class8.smethod_0(xmlAttribute.Value.Replace("{", "").Replace("}", "")) : ((double)Convert.ToSingle(xmlAttribute.Value, cultureInfo));
						propertySet.Properties.Add(new TXTC.PROPEntry(TXTC.EntryType.Rotation, TXTC.EntryTypeCode.Float, (float)num5));
						continue;
					}
					case "defaultColor":
					{
						uint num6 = Convert.ToUInt32(xmlAttribute.Value);
						propertySet.Properties.Add(new TXTC.PROPEntry(TXTC.EntryType.DefaultColour, TXTC.EntryTypeCode.UnsignedInt, num6));
						continue;
					}
					case "sourceRect":
					{
						string[] array5 = xmlAttribute.Value.Split(new char[]
						{
							','
						});
						float[] array6 = new float[4];
						for (int k = 0; k < array5.Length; k++)
						{
							array6[k] = Convert.ToSingle(array5[k], cultureInfo);
						}
						propertySet.Properties.Add(new TXTC.PROPEntry((TXTC.EntryType)2745891992U, TXTC.EntryTypeCode.RectFloat, array6));
						continue;
					}
					case "destRect":
					{
						string[] array7 = xmlAttribute.Value.Split(new char[]
						{
							','
						});
						float[] array8 = new float[4];
						for (int l = 0; l < array7.Length; l++)
						{
							array8[l] = Convert.ToSingle(array7[l], cultureInfo);
						}
						propertySet.Properties.Add(new TXTC.PROPEntry((TXTC.EntryType)3788951583U, TXTC.EntryTypeCode.RectFloat, array8));
						continue;
					}
					}
					Console.WriteLine("Unhandled attribute " + xmlAttribute.Name + " = " + xmlAttribute.Value);
				}
				propertySet.Properties.Add(new TXTC.PROPEntry());
				propertySets.Add(propertySet);
			}
		}

		// Token: 0x06000433 RID: 1075 RVA: 0x00049A38 File Offset: 0x00047C38
		private static double smethod_0(string string_2)
		{
			DataTable dataTable = new DataTable();
			DataColumn column = new DataColumn("Eval", typeof(double), string_2);
			dataTable.Columns.Add(column);
			dataTable.Rows.Add(new object[]
			{
				0
			});
			return (double)dataTable.Rows[0]["Eval"];
		}

		// Token: 0x06000434 RID: 1076 RVA: 0x00049AAC File Offset: 0x00047CAC
		public List<MATD> method_12(int int_2, MLOD mlod_0, MLOD.MLODEntry mlodentry_0)
		{
			RCOL parent = mlod_0.Parent;
			List<MATD> list = new List<MATD>();
			RCOLItem rcolitem = parent.Entries[mlodentry_0.MATDIndex + ((parent.dataType == 2) ? 1 : 0)];
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
					if (int_2 == 0 || (long)int_2 == (long)((ulong)mtstentry.Hash))
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
			rcolitem = parent.Entries[mlodentry_0.GEOStateIndex + ((parent.dataType == 2) ? 1 : 0)];
			if (rcolitem is MATD)
			{
				MATD item3 = rcolitem as MATD;
				list.Add(item3);
			}
			return list;
		}

		// Token: 0x06000435 RID: 1077 RVA: 0x00004466 File Offset: 0x00002666
		private void method_13(object object_0, Class55 class55_0)
		{
			base.method_1(new Class48());
		}

		// Token: 0x06000436 RID: 1078 RVA: 0x00049C74 File Offset: 0x00047E74
		protected override void OnPropertyChanged(PropertyChangedEventArgs e)
		{
			e.PropertyEnum.Property.Value.GetValue();
			Class132.mainForm.CurrentProject.Sims3WorkshopSDK.Interfaces.IWorkshopProject.HasChanges = true;
			if (e.PropertyEnum.Property.Value.TargetInstance is PropertyValueManaged && e.PropertyEnum.Property.Value.GetValue() is PatternResKey)
			{
				((Class63)e.PropertyEnum.Property.Look).NeedsUpdate = true;
			}
			base.OnPropertyChanged(e);
		}

		// Token: 0x040003FC RID: 1020
		private XmlDocument xmlDocument_0;

		// Token: 0x040003FD RID: 1021
		private int int_1;

		// Token: 0x040003FE RID: 1022
		private XmlDocument xmlDocument_1;

		// Token: 0x040003FF RID: 1023
		private ImageList imageList_0;

		// Token: 0x04000400 RID: 1024
		[PropertyLook(typeof(PropertyCheckboxLook))]
		[PropertyFeel("checkbox")]
		private uint uint_0;

		// Token: 0x04000401 RID: 1025
		[PropertyLook(typeof(PropertyCheckboxLook))]
		[PropertyFeel("checkbox")]
		private uint uint_1;

		// Token: 0x04000402 RID: 1026
		[CompilerGenerated]
		private Dictionary<string, PropertyEnumerator> dictionary_0;
	}
}
