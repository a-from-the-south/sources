using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Xml;
using Package.SharedFiles;
using Sims3WorkshopSDK;

namespace Package.Sims3Files
{
	// Token: 0x0200003E RID: 62
	public class TXTC : DBPFEntry
	{
		// Token: 0x17000114 RID: 276
		// (get) Token: 0x0600034C RID: 844 RVA: 0x000049E0 File Offset: 0x00002BE0
		// (set) Token: 0x0600034D RID: 845 RVA: 0x000049E8 File Offset: 0x00002BE8
		public List<IGTIndex> IGTIndex { get; set; }

		// Token: 0x17000115 RID: 277
		// (get) Token: 0x0600034E RID: 846 RVA: 0x000049F1 File Offset: 0x00002BF1
		// (set) Token: 0x0600034F RID: 847 RVA: 0x000049F9 File Offset: 0x00002BF9
		public List<TXTC.FABC> SuperBlocks { get; set; }

		// Token: 0x17000116 RID: 278
		// (get) Token: 0x06000350 RID: 848 RVA: 0x00004A02 File Offset: 0x00002C02
		// (set) Token: 0x06000351 RID: 849 RVA: 0x00004A0A File Offset: 0x00002C0A
		public List<TXTC.PropertySet> PropertySets { get; set; }

		// Token: 0x17000117 RID: 279
		// (get) Token: 0x06000352 RID: 850 RVA: 0x00004A13 File Offset: 0x00002C13
		// (set) Token: 0x06000353 RID: 851 RVA: 0x00004A1B File Offset: 0x00002C1B
		public string Xml { get; set; }

		// Token: 0x06000354 RID: 852 RVA: 0x00004A24 File Offset: 0x00002C24
		public TXTC(uint typeId)
		{
			this.typeId = typeId;
			this.IGTIndex = new List<IGTIndex>();
			this.SuperBlocks = new List<TXTC.FABC>();
			this.PropertySets = new List<TXTC.PropertySet>();
		}

		// Token: 0x06000355 RID: 853 RVA: 0x000181B8 File Offset: 0x000163B8
		public static TXTC.StepType StepFromText(string txt)
		{
			string text = txt.ToLower();
			uint num = <PrivateImplementationDetails>.ComputeStringHash(text);
			if (num <= 1918877446U)
			{
				if (num <= 861097640U)
				{
					if (num != 162255580U)
					{
						if (num == 861097640U)
						{
							if (text == "drawimage")
							{
								return (TXTC.StepType)2706505905U;
							}
						}
					}
					else if (text == "channelselect")
					{
						return TXTC.StepType.ChannelSelect;
					}
				}
				else if (num != 1562173687U)
				{
					if (num == 1918877446U)
					{
						if (text == "settarget")
						{
							return (TXTC.StepType)3602744981U;
						}
					}
				}
				else if (text == "caspickdata")
				{
					return (TXTC.StepType)3333860383U;
				}
			}
			else if (num <= 2370924777U)
			{
				if (num != 2287226274U)
				{
					if (num == 2370924777U)
					{
						if (text == "colorfill")
						{
							return (TXTC.StepType)2630952605U;
						}
					}
				}
				else if (text == "drawfabric")
				{
					return TXTC.StepType.DrawFabric;
				}
			}
			else if (num != 2624864536U)
			{
				if (num != 4026702094U)
				{
					if (num == 4164748501U)
					{
						if (text == "hairtone")
						{
							return TXTC.StepType.HairTone;
						}
					}
				}
				else if (text == "hsvshift")
				{
					return (TXTC.StepType)3691611321U;
				}
			}
			else if (text == "skintone")
			{
				return TXTC.StepType.SkinTone;
			}
			throw new Exception("Unknown steptype" + txt);
		}

		// Token: 0x06000356 RID: 854 RVA: 0x0001830C File Offset: 0x0001650C
		public override int ReplaceReferences(ResKey from, ResKey to)
		{
			int num = 0;
			foreach (IGTIndex igtindex in this.IGTIndex)
			{
				if (igtindex.Equals(from))
				{
					igtindex.SetFromResKey(to);
					num++;
				}
			}
			return num;
		}

		// Token: 0x06000357 RID: 855 RVA: 0x00018370 File Offset: 0x00016570
		public override void UnSerialize()
		{
			this.IGTIndex = new List<IGTIndex>();
			this.SuperBlocks = new List<TXTC.FABC>();
			this.PropertySets = new List<TXTC.PropertySet>();
			MemoryStream memoryStream = new MemoryStream(this.data);
			BinaryReader binaryReader = new BinaryReader(memoryStream);
			this.version = binaryReader.ReadUInt32();
			this.tgiOffset = binaryReader.ReadUInt32();
			if (this.version >= 7U)
			{
				byte b = binaryReader.ReadByte();
				for (int i = 0; i < (int)b; i++)
				{
					TXTC.FABC fabc = new TXTC.FABC(this);
					fabc.Unserialize(binaryReader);
					this.SuperBlocks.Add(fabc);
				}
			}
			this.PatternSize = (TXTC.Size)binaryReader.ReadUInt32();
			this.PartType = (CASP.Type)binaryReader.ReadUInt32();
			this.nullByte1 = binaryReader.ReadByte();
			uint num = binaryReader.ReadUInt32();
			if (this.version >= 8U)
			{
				this.nullByte2 = binaryReader.ReadByte();
			}
			int num2 = 0;
			while ((long)num2 < (long)((ulong)num))
			{
				TXTC.PropertySet propertySet = new TXTC.PropertySet();
				propertySet.Unserialize(binaryReader);
				this.PropertySets.Add(propertySet);
				num2++;
			}
			byte b2 = binaryReader.ReadByte();
			for (int j = 0; j < (int)b2; j++)
			{
				IGTIndex igtindex = new IGTIndex();
				igtindex.UnSerialize(binaryReader);
				this.IGTIndex.Add(igtindex);
			}
			memoryStream.Dispose();
			binaryReader.Close();
		}

		// Token: 0x06000358 RID: 856 RVA: 0x000184B8 File Offset: 0x000166B8
		public override byte[] Serialize()
		{
			MemoryStream memoryStream = new MemoryStream();
			BinaryWriter binaryWriter = new BinaryWriter(memoryStream);
			if (this.version >= 7U)
			{
				binaryWriter.Write((byte)this.SuperBlocks.Count);
				foreach (TXTC.FABC fabc in this.SuperBlocks)
				{
					fabc.Serialize(binaryWriter);
				}
			}
			binaryWriter.Write((uint)this.PatternSize);
			binaryWriter.Write((uint)this.PartType);
			binaryWriter.Write(this.nullByte1);
			binaryWriter.Write(this.PropertySets.Count);
			if (this.version >= 8U)
			{
				binaryWriter.Write(this.nullByte2);
			}
			foreach (TXTC.PropertySet propertySet in this.PropertySets)
			{
				propertySet.Serialize(binaryWriter);
			}
			MemoryStream memoryStream2 = new MemoryStream();
			BinaryWriter binaryWriter2 = new BinaryWriter(memoryStream2);
			binaryWriter2.Write(this.version);
			binaryWriter2.Write((int)memoryStream.Length);
			binaryWriter2.Write(memoryStream.GetBuffer(), 0, (int)memoryStream.Length);
			binaryWriter2.Write((byte)this.IGTIndex.Count);
			foreach (IGTIndex igtindex in this.IGTIndex)
			{
				igtindex.Serialize(binaryWriter2);
			}
			byte[] result = memoryStream2.ToArray();
			binaryWriter.Close();
			memoryStream.Dispose();
			binaryWriter2.Close();
			memoryStream2.Dispose();
			return result;
		}

		// Token: 0x06000359 RID: 857 RVA: 0x00018670 File Offset: 0x00016870
		public XmlDocument ToPreset()
		{
			XmlDocument xmlDocument = new XmlDocument();
			XmlElement xmlElement = xmlDocument.CreateElement("preset");
			XmlElement xmlElement2 = xmlDocument.CreateElement("complate");
			xmlElement.AppendChild(xmlElement2);
			xmlElement2.SetAttribute("reskey", base.GenerateResKey());
			XmlElement xmlElement3 = xmlDocument.CreateElement("value");
			xmlElement2.AppendChild(xmlElement3);
			xmlElement3.SetAttribute("key", "partType");
			xmlElement3.SetAttribute("value", "");
			XmlElement xmlElement4 = xmlDocument.CreateElement("value");
			xmlElement2.AppendChild(xmlElement4);
			xmlElement4.SetAttribute("key", "daeFileName");
			xmlElement4.SetAttribute("value", "createdFromPropset");
			string[] array = new string[]
			{
				"Pattern A",
				"Pattern B",
				"Pattern C",
				"Pattern D",
				"Logo"
			};
			int num = 0;
			foreach (TXTC.FABC fabc in this.SuperBlocks)
			{
				XmlElement xmlElement5 = xmlDocument.CreateElement("pattern");
				xmlElement2.AppendChild(xmlElement5);
				xmlElement5.SetAttribute("name", "Pattern " + array[num]);
				xmlElement5.SetAttribute("reskey", fabc.IGTIndex.Reskey);
				xmlElement5.SetAttribute("variable", array[num]);
				num++;
			}
			xmlDocument.AppendChild(xmlElement);
			return xmlDocument;
		}

		// Token: 0x0600035A RID: 858 RVA: 0x00018800 File Offset: 0x00016A00
		public static XmlDocument CreateComplate(TXTC txtc, List<TXTC.PropertySet> propertySets, string complateName, TXTC.ComplateType complateType)
		{
			if (propertySets.Count == 0)
			{
				return null;
			}
			int num = 1;
			int num2 = 1;
			CultureInfo cultureInfo = new CultureInfo("en-US");
			cultureInfo.NumberFormat.NumberDecimalSeparator = ".";
			XmlDocument xmlDocument = new XmlDocument();
			XmlElement xmlElement = xmlDocument.CreateElement("complate");
			xmlElement.SetAttribute("name", complateName);
			xmlElement.SetAttribute("typeConverter", "Medator.ComplateConverter, Medator");
			xmlDocument.AppendChild(xmlElement);
			XmlElement xmlElement2 = xmlDocument.CreateElement("variables");
			xmlElement.AppendChild(xmlElement2);
			XmlElement xmlElement3 = xmlDocument.CreateElement("texturePart");
			xmlElement3.SetAttribute("part", "($partType)");
			XmlElement xmlElement4 = xmlDocument.CreateElement("destination");
			xmlElement4.SetAttribute("textureName", "DiffuseMap");
			xmlElement3.AppendChild(xmlElement4);
			xmlElement.AppendChild(xmlElement3);
			foreach (TXTC.PropertySet propertySet in propertySets)
			{
				XmlElement xmlElement5 = xmlDocument.CreateElement("step");
				xmlElement5.SetAttribute("srcBlend", "Zero");
				xmlElement5.SetAttribute("color", "0,0,0,0");
				xmlElement4.AppendChild(xmlElement5);
				foreach (TXTC.PROPEntry propentry in propertySet.Properties)
				{
					if (propentry.guid == (TXTC.EntryType)3643427979U)
					{
						xmlElement5.SetAttribute("uiVisible", ((byte)propentry.data == 1) ? "true" : "false");
					}
					if (propentry.guid == TXTC.EntryType.Description)
					{
						xmlElement5.SetAttribute("description", (string)propentry.data);
					}
					if (propentry.guid == TXTC.EntryType.ID)
					{
						uint uintData = propentry.GetUIntData();
						if (uintData == 3602744981U)
						{
							xmlElement5.SetAttribute("type", "SetTarget");
						}
						else if (uintData == 2630952605U)
						{
							xmlElement5.SetAttribute("type", "ColorFill");
						}
						else if (uintData == 54661285U)
						{
							xmlElement5.SetAttribute("type", "DrawFabric");
						}
						else if (uintData == 506870683U)
						{
							xmlElement5.SetAttribute("type", "ChannelSelect");
						}
						else if (uintData == 1135957219U)
						{
							xmlElement5.SetAttribute("type", "SkinTone");
						}
						else if (uintData == 1568441812U)
						{
							xmlElement5.SetAttribute("type", "HairTone");
						}
						else if (uintData == 2706505905U)
						{
							xmlElement5.SetAttribute("type", "DrawImage");
						}
						else if (uintData == 3333860383U)
						{
							xmlElement5.SetAttribute("type", "CASPickData");
						}
						else if (uintData == 3691611321U)
						{
							xmlElement5.SetAttribute("type", "HSVShift");
						}
					}
					if (propentry.guid == TXTC.EntryType.MaskBias)
					{
						byte[] array = (byte[])propentry.data;
						xmlElement5.SetAttribute("maskBias", BitConverter.ToSingle(new byte[]
						{
							array[0],
							array[1],
							array[2],
							array[3]
						}, 0).ToString(cultureInfo));
					}
					if (propentry.guid == (TXTC.EntryType)3061591800U)
					{
						float num3 = BitConverter.ToSingle(new byte[]
						{
							((byte[])propentry.data)[0],
							((byte[])propentry.data)[1],
							((byte[])propentry.data)[2],
							((byte[])propentry.data)[3]
						}, 0);
						float num4 = BitConverter.ToSingle(new byte[]
						{
							((byte[])propentry.data)[4],
							((byte[])propentry.data)[5],
							((byte[])propentry.data)[6],
							((byte[])propentry.data)[7]
						}, 0);
						float num5 = BitConverter.ToSingle(new byte[]
						{
							((byte[])propentry.data)[8],
							((byte[])propentry.data)[9],
							((byte[])propentry.data)[10],
							((byte[])propentry.data)[11]
						}, 0);
						xmlElement5.SetAttribute("hsvShift", string.Concat(new string[]
						{
							num3.ToString(cultureInfo),
							",",
							num4.ToString(cultureInfo),
							",",
							num5.ToString(cultureInfo)
						}));
					}
					if (propentry.guid == (TXTC.EntryType)3763727926U)
					{
						uint uintData2 = propentry.GetUIntData();
						string value = "One";
						if (uintData2 == 0U)
						{
							value = "Zero";
						}
						if (uintData2 == 1U)
						{
							value = "One";
						}
						if (uintData2 == 2U)
						{
							value = "SrcColor";
						}
						if (uintData2 == 3U)
						{
							value = "InvSrcColor";
						}
						if (uintData2 == 4U)
						{
							value = "SrcAlpha";
						}
						if (uintData2 == 5U)
						{
							value = "InvSrcAlpha";
						}
						if (uintData2 == 6U)
						{
							value = "DestAlpha";
						}
						if (uintData2 == 7U)
						{
							value = "InvDestAlpha";
						}
						if (uintData2 == 8U)
						{
							value = "DestColor";
						}
						if (uintData2 == 9U)
						{
							value = "InvDestColor";
						}
						xmlElement5.SetAttribute("srcBlend", value);
					}
					if (propentry.guid == TXTC.EntryType.DestinationBlend)
					{
						uint uintData3 = propentry.GetUIntData();
						string value2 = "One";
						if (uintData3 == 0U)
						{
							value2 = "Zero";
						}
						if (uintData3 == 1U)
						{
							value2 = "One";
						}
						if (uintData3 == 2U)
						{
							value2 = "SrcColor";
						}
						if (uintData3 == 3U)
						{
							value2 = "InvSrcColor";
						}
						if (uintData3 == 4U)
						{
							value2 = "SrcAlpha";
						}
						if (uintData3 == 5U)
						{
							value2 = "InvSrcAlpha";
						}
						if (uintData3 == 6U)
						{
							value2 = "DestAlpha";
						}
						if (uintData3 == 7U)
						{
							value2 = "InvDestAlpha";
						}
						if (uintData3 == 8U)
						{
							value2 = "DestColor";
						}
						if (uintData3 == 9U)
						{
							value2 = "InvDestColor";
						}
						xmlElement5.SetAttribute("dstBlend", value2);
					}
					if (propentry.guid == (TXTC.EntryType)2960866195U)
					{
						uint uintData4 = propentry.GetUIntData();
						if (uintData4 == 7U)
						{
							xmlElement5.SetAttribute("colorWrite", "RGB");
						}
						else if (uintData4 == 8U)
						{
							xmlElement5.SetAttribute("colorWrite", "Alpha");
						}
						else if (uintData4 == 15U)
						{
							xmlElement5.SetAttribute("colorWrite", "Color");
						}
						else if (uintData4 == 4U)
						{
							xmlElement5.SetAttribute("colorWrite", "Blue");
						}
						else if (uintData4 == 2U)
						{
							xmlElement5.SetAttribute("colorWrite", "Green");
						}
						else if (uintData4 == 1U)
						{
							xmlElement5.SetAttribute("colorWrite", "Red");
						}
						else
						{
							xmlElement5.SetAttribute("colorWrite", uintData4.ToString("X8"));
						}
					}
					if (propentry.guid == (TXTC.EntryType)4227010759U)
					{
						xmlElement5.SetAttribute("enableBlending", ((byte)propentry.data == 0) ? "false" : "true");
					}
					if (propentry.guid == (TXTC.EntryType)2954315994U)
					{
						byte[] array2 = (byte[])propentry.data;
						float num6 = (float)array2[2] / 255f;
						float num7 = (float)array2[1] / 255f;
						float num8 = (float)array2[0] / 255f;
						float num9 = (float)array2[3] / 255f;
						string text = "Color " + num++.ToString();
						if (complateType == TXTC.ComplateType.Hair)
						{
							switch (num)
							{
							case 2:
								text = "Diffuse Color";
								break;
							case 3:
								text = "Root Color";
								break;
							case 4:
								text = "Highlight Color";
								break;
							case 5:
								text = "Tip Color";
								break;
							}
						}
						xmlElement5.SetAttribute("color", "($" + text + ")");
						XmlElement xmlElement6 = xmlDocument.CreateElement("param");
						xmlElement6.SetAttribute("type", "color");
						xmlElement6.SetAttribute("name", text);
						xmlElement6.SetAttribute("default", string.Concat(new string[]
						{
							num6.ToString(cultureInfo),
							",",
							num7.ToString(cultureInfo),
							",",
							num8.ToString(cultureInfo),
							",",
							num9.ToString(cultureInfo)
						}));
						xmlElement6.SetAttribute("uiEditor", "Medator.Color4TypeEditor, Medator");
						xmlElement6.SetAttribute("uiCategory", "Misc");
						xmlElement2.AppendChild(xmlElement6);
					}
					if (propentry.guid == (TXTC.EntryType)2322597595U)
					{
						if (propentry.GetUIntData() == 35560661U)
						{
							xmlElement5.SetAttribute("texture", "RenderTexture_B");
						}
						else
						{
							xmlElement5.SetAttribute("texture", "RenderTexture_A");
						}
					}
					if (propentry.guid == (TXTC.EntryType)2731086642U)
					{
						if (propentry.GetUIntData() == 35560660U)
						{
							xmlElement5.SetAttribute("renderTarget", "RenderTarget_B");
						}
						else
						{
							xmlElement5.SetAttribute("renderTarget", "RenderTarget_A");
						}
					}
					if (propentry.guid == TXTC.EntryType.MaskSelect)
					{
						byte[] array3 = (byte[])propentry.data;
						float num10 = BitConverter.ToSingle(new byte[]
						{
							array3[0],
							array3[1],
							array3[2],
							array3[3]
						}, 0);
						float num11 = BitConverter.ToSingle(new byte[]
						{
							array3[4],
							array3[5],
							array3[6],
							array3[7]
						}, 0);
						float num12 = BitConverter.ToSingle(new byte[]
						{
							array3[8],
							array3[9],
							array3[10],
							array3[11]
						}, 0);
						float num13 = BitConverter.ToSingle(new byte[]
						{
							array3[12],
							array3[13],
							array3[14],
							array3[15]
						}, 0);
						xmlElement5.SetAttribute("maskSelect", string.Concat(new string[]
						{
							num10.ToString(cultureInfo),
							",",
							num11.ToString(cultureInfo),
							",",
							num12.ToString(cultureInfo),
							",",
							num13.ToString(cultureInfo)
						}));
					}
					if (propentry.guid == (TXTC.EntryType)3504771074U)
					{
						byte[] array4 = (byte[])propentry.data;
						float num14 = BitConverter.ToSingle(new byte[]
						{
							array4[0],
							array4[1],
							array4[2],
							array4[3]
						}, 0);
						float num15 = BitConverter.ToSingle(new byte[]
						{
							array4[4],
							array4[5],
							array4[6],
							array4[7]
						}, 0);
						float num16 = BitConverter.ToSingle(new byte[]
						{
							array4[8],
							array4[9],
							array4[10],
							array4[11]
						}, 0);
						float num17 = BitConverter.ToSingle(new byte[]
						{
							array4[12],
							array4[13],
							array4[14],
							array4[15]
						}, 0);
						xmlElement5.SetAttribute("select", string.Concat(new string[]
						{
							num14.ToString(cultureInfo),
							",",
							num15.ToString(cultureInfo),
							",",
							num16.ToString(cultureInfo),
							",",
							num17.ToString(cultureInfo)
						}));
					}
					if (propentry.guid == (TXTC.EntryType)4140598385U)
					{
						byte index = (byte)propentry.data;
						IGTIndex igtindex = txtc.IGTIndex[(int)index];
						string text2 = "Texture " + num2++.ToString();
						xmlElement5.SetAttribute("texture", "($" + text2 + ")");
						XmlElement xmlElement7 = xmlDocument.CreateElement("param");
						xmlElement7.SetAttribute("type", "texture");
						xmlElement7.SetAttribute("name", text2);
						xmlElement7.SetAttribute("uiCategory", "Textures");
						xmlElement7.SetAttribute("default", igtindex.Reskey);
						xmlElement2.AppendChild(xmlElement7);
					}
					if (propentry.guid == TXTC.EntryType.MaskKey)
					{
						byte index2 = (byte)propentry.data;
						IGTIndex igtindex2 = txtc.IGTIndex[(int)index2];
						xmlElement5.SetAttribute("mask", igtindex2.Reskey);
					}
					if (propentry.guid == (TXTC.EntryType)3707727227U)
					{
						xmlElement5.SetAttribute("texture", txtc.IGTIndex[(int)((byte)propentry.data)].Reskey);
					}
				}
			}
			return xmlDocument;
		}

		// Token: 0x0600035B RID: 859 RVA: 0x00004A54 File Offset: 0x00002C54
		public XmlDocument ToComplate(string complateName, TXTC.ComplateType complateType)
		{
			return TXTC.CreateComplate(this, this.PropertySets, complateName, complateType);
		}

		// Token: 0x040001A4 RID: 420
		public TXTC.Size PatternSize;

		// Token: 0x040001A5 RID: 421
		public CASP.Type PartType;

		// Token: 0x040001A6 RID: 422
		private uint version;

		// Token: 0x040001A7 RID: 423
		private uint tgiOffset;

		// Token: 0x040001A8 RID: 424
		private byte nullByte1;

		// Token: 0x040001A9 RID: 425
		private byte nullByte2;

		// Token: 0x0200010F RID: 271
		public enum BlendFactor
		{
			// Token: 0x040006D8 RID: 1752
			Zero,
			// Token: 0x040006D9 RID: 1753
			One,
			// Token: 0x040006DA RID: 1754
			SourceColour,
			// Token: 0x040006DB RID: 1755
			InverseSourceColour,
			// Token: 0x040006DC RID: 1756
			SourceAlpha,
			// Token: 0x040006DD RID: 1757
			InverseSourceAlpha,
			// Token: 0x040006DE RID: 1758
			DestinationAlpha,
			// Token: 0x040006DF RID: 1759
			InverseDestinationAlpha,
			// Token: 0x040006E0 RID: 1760
			DestinationColour,
			// Token: 0x040006E1 RID: 1761
			InverseDestinationColour,
			// Token: 0x040006E2 RID: 1762
			SourceAlphaSaturation,
			// Token: 0x040006E3 RID: 1763
			BlendFactor,
			// Token: 0x040006E4 RID: 1764
			InverseBlendFactor
		}

		// Token: 0x02000110 RID: 272
		public enum ComplateType : uint
		{
			// Token: 0x040006E6 RID: 1766
			Hair,
			// Token: 0x040006E7 RID: 1767
			Other
		}

		// Token: 0x02000111 RID: 273
		public enum Size : uint
		{
			// Token: 0x040006E9 RID: 1769
			Default,
			// Token: 0x040006EA RID: 1770
			Large
		}

		// Token: 0x02000112 RID: 274
		public enum StepType : uint
		{
			// Token: 0x040006EC RID: 1772
			DrawFabric = 54661285U,
			// Token: 0x040006ED RID: 1773
			ChannelSelect = 506870683U,
			// Token: 0x040006EE RID: 1774
			SkinTone = 1135957219U,
			// Token: 0x040006EF RID: 1775
			HairTone = 1568441812U,
			// Token: 0x040006F0 RID: 1776
			ColourFill = 2630952605U,
			// Token: 0x040006F1 RID: 1777
			DrawImage = 2706505905U,
			// Token: 0x040006F2 RID: 1778
			CASPickData = 3333860383U,
			// Token: 0x040006F3 RID: 1779
			SetTarget = 3602744981U,
			// Token: 0x040006F4 RID: 1780
			HSVtoRGB = 3691611321U
		}

		// Token: 0x02000113 RID: 275
		public enum EntryType : uint
		{
			// Token: 0x040006F6 RID: 1782
			DestinationBlend = 76510567U,
			// Token: 0x040006F7 RID: 1783
			SkipShaderModel = 111637966U,
			// Token: 0x040006F8 RID: 1784
			MaskSource = 282725226U,
			// Token: 0x040006F9 RID: 1785
			Width = 405693675U,
			// Token: 0x040006FA RID: 1786
			MaskSelect = 520688217U,
			// Token: 0x040006FB RID: 1787
			MinShaderModel = 786390867U,
			// Token: 0x040006FC RID: 1788
			SkipDetailLevel = 856783071U,
			// Token: 0x040006FD RID: 1789
			MaskBias = 976380134U,
			// Token: 0x040006FE RID: 1790
			MaskKey = 1239300886U,
			// Token: 0x040006FF RID: 1791
			Rotation = 1241093851U,
			// Token: 0x04000700 RID: 1792
			Height = 1279776192U,
			// Token: 0x04000701 RID: 1793
			DefaultColour = 1681497797U,
			// Token: 0x04000702 RID: 1794
			ID = 1752637606U,
			// Token: 0x04000703 RID: 1795
			Description = 1802574273U,
			// Token: 0x04000704 RID: 1796
			ImageSource = 2322597595U,
			// Token: 0x04000705 RID: 1797
			RenderTarget = 2731086642U,
			// Token: 0x04000706 RID: 1798
			SourceRectangle = 2745891992U,
			// Token: 0x04000707 RID: 1799
			MinDetailLevel = 2925520938U,
			// Token: 0x04000708 RID: 1800
			Colour = 2954315994U,
			// Token: 0x04000709 RID: 1801
			ColourWrite = 2960866195U,
			// Token: 0x0400070A RID: 1802
			HSVShift = 3061591800U,
			// Token: 0x0400070B RID: 1803
			ChannelSelect = 3504771074U,
			// Token: 0x0400070C RID: 1804
			UIVisible = 3643427979U,
			// Token: 0x0400070D RID: 1805
			DefaultFabric = 3707727227U,
			// Token: 0x0400070E RID: 1806
			SourceBlend = 3763727926U,
			// Token: 0x0400070F RID: 1807
			DestinationRectangl = 3788951583U,
			// Token: 0x04000710 RID: 1808
			EnableFiltering = 3800033634U,
			// Token: 0x04000711 RID: 1809
			ImageKey = 4140598385U,
			// Token: 0x04000712 RID: 1810
			EnableBlending = 4227010759U,
			// Token: 0x04000713 RID: 1811
			NULL = 0U
		}

		// Token: 0x02000114 RID: 276
		public enum EntryTypeCode : byte
		{
			// Token: 0x04000715 RID: 1813
			Boolean,
			// Token: 0x04000716 RID: 1814
			SignedByte,
			// Token: 0x04000717 RID: 1815
			SignedShort,
			// Token: 0x04000718 RID: 1816
			SignedInt,
			// Token: 0x04000719 RID: 1817
			SignedLong,
			// Token: 0x0400071A RID: 1818
			UnsignedByte,
			// Token: 0x0400071B RID: 1819
			UnsignedShort,
			// Token: 0x0400071C RID: 1820
			UnsignedInt,
			// Token: 0x0400071D RID: 1821
			UnsignedLong,
			// Token: 0x0400071E RID: 1822
			Float,
			// Token: 0x0400071F RID: 1823
			RectFloat,
			// Token: 0x04000720 RID: 1824
			Vector4,
			// Token: 0x04000721 RID: 1825
			TGIIndex,
			// Token: 0x04000722 RID: 1826
			String
		}

		// Token: 0x02000115 RID: 277
		public class PROPEntry
		{
			// Token: 0x06000D2C RID: 3372 RVA: 0x0000331D File Offset: 0x0000151D
			public PROPEntry()
			{
			}

			// Token: 0x06000D2D RID: 3373 RVA: 0x0000933A File Offset: 0x0000753A
			public PROPEntry(TXTC.EntryType guid, TXTC.EntryTypeCode type, object data)
			{
				this.guid = guid;
				this.typeCode = type;
				this.TypedData = data;
			}

			// Token: 0x17000429 RID: 1065
			// (get) Token: 0x06000D2E RID: 3374 RVA: 0x00009357 File Offset: 0x00007557
			// (set) Token: 0x06000D2F RID: 3375 RVA: 0x0000935F File Offset: 0x0000755F
			public object Data
			{
				get
				{
					return this.data;
				}
				set
				{
					this.data = value;
				}
			}

			// Token: 0x1700042A RID: 1066
			// (get) Token: 0x06000D30 RID: 3376 RVA: 0x00009368 File Offset: 0x00007568
			// (set) Token: 0x06000D31 RID: 3377 RVA: 0x00009370 File Offset: 0x00007570
			public TXTC.EntryTypeCode TypeCode
			{
				get
				{
					return this.typeCode;
				}
				set
				{
					this.typeCode = value;
				}
			}

			// Token: 0x1700042B RID: 1067
			// (get) Token: 0x06000D32 RID: 3378 RVA: 0x0003F520 File Offset: 0x0003D720
			// (set) Token: 0x06000D33 RID: 3379 RVA: 0x0003F718 File Offset: 0x0003D918
			public object TypedData
			{
				get
				{
					switch (this.typeCode)
					{
					case TXTC.EntryTypeCode.Boolean:
						return (byte)this.data == 1;
					case TXTC.EntryTypeCode.SignedByte:
						return (sbyte)((byte[])this.data)[0];
					case TXTC.EntryTypeCode.SignedShort:
						return BitConverter.ToInt16((byte[])this.data, 0);
					case TXTC.EntryTypeCode.SignedInt:
						return BitConverter.ToInt32((byte[])this.data, 0);
					case TXTC.EntryTypeCode.SignedLong:
						return BitConverter.ToInt64((byte[])this.data, 0);
					case TXTC.EntryTypeCode.UnsignedByte:
						return ((byte[])this.data)[0];
					case TXTC.EntryTypeCode.UnsignedShort:
						return BitConverter.ToUInt16((byte[])this.data, 0);
					case TXTC.EntryTypeCode.UnsignedInt:
						return BitConverter.ToUInt32((byte[])this.data, 0);
					case TXTC.EntryTypeCode.UnsignedLong:
						return BitConverter.ToUInt64((byte[])this.data, 0);
					case TXTC.EntryTypeCode.Float:
						return BitConverter.ToSingle((byte[])this.data, 0);
					case TXTC.EntryTypeCode.RectFloat:
						return new float[]
						{
							BitConverter.ToSingle((byte[])this.data, 0),
							BitConverter.ToSingle((byte[])this.data, 4),
							BitConverter.ToSingle((byte[])this.data, 8),
							BitConverter.ToSingle((byte[])this.data, 12)
						};
					case TXTC.EntryTypeCode.Vector4:
						return new float[]
						{
							BitConverter.ToSingle((byte[])this.data, 0),
							BitConverter.ToSingle((byte[])this.data, 4),
							BitConverter.ToSingle((byte[])this.data, 8),
							BitConverter.ToSingle((byte[])this.data, 12)
						};
					case TXTC.EntryTypeCode.TGIIndex:
						return (byte)this.data;
					case TXTC.EntryTypeCode.String:
						return this.Data;
					default:
						return null;
					}
				}
				set
				{
					switch (this.typeCode)
					{
					case TXTC.EntryTypeCode.Boolean:
						this.data = (((bool)value) ? 1 : 0);
						return;
					case TXTC.EntryTypeCode.SignedByte:
						this.data = (sbyte)value;
						return;
					case TXTC.EntryTypeCode.SignedShort:
						this.data = BitConverter.GetBytes((short)value);
						return;
					case TXTC.EntryTypeCode.SignedInt:
						this.data = BitConverter.GetBytes((int)value);
						return;
					case TXTC.EntryTypeCode.SignedLong:
						this.data = BitConverter.GetBytes((long)value);
						return;
					case TXTC.EntryTypeCode.UnsignedByte:
						this.data = (byte)this.data;
						return;
					case TXTC.EntryTypeCode.UnsignedShort:
						this.data = BitConverter.GetBytes((ushort)value);
						return;
					case TXTC.EntryTypeCode.UnsignedInt:
						this.data = BitConverter.GetBytes((uint)value);
						return;
					case TXTC.EntryTypeCode.UnsignedLong:
						this.data = BitConverter.GetBytes((ulong)value);
						return;
					case TXTC.EntryTypeCode.Float:
						this.data = BitConverter.GetBytes((float)value);
						return;
					case TXTC.EntryTypeCode.RectFloat:
						this.data = new byte[16];
						Array.Copy(BitConverter.GetBytes(((float[])value)[0]), 0, (byte[])this.data, 0, 4);
						Array.Copy(BitConverter.GetBytes(((float[])value)[1]), 0, (byte[])this.data, 4, 4);
						Array.Copy(BitConverter.GetBytes(((float[])value)[2]), 0, (byte[])this.data, 8, 4);
						Array.Copy(BitConverter.GetBytes(((float[])value)[3]), 0, (byte[])this.data, 12, 4);
						return;
					case TXTC.EntryTypeCode.Vector4:
						this.data = new byte[16];
						Array.Copy(BitConverter.GetBytes(((float[])value)[0]), 0, (byte[])this.data, 0, 4);
						Array.Copy(BitConverter.GetBytes(((float[])value)[1]), 0, (byte[])this.data, 4, 4);
						Array.Copy(BitConverter.GetBytes(((float[])value)[2]), 0, (byte[])this.data, 8, 4);
						Array.Copy(BitConverter.GetBytes(((float[])value)[3]), 0, (byte[])this.data, 12, 4);
						return;
					case TXTC.EntryTypeCode.TGIIndex:
						this.data = (byte)value;
						return;
					case TXTC.EntryTypeCode.String:
						this.data = (string)value;
						return;
					default:
						return;
					}
				}
			}

			// Token: 0x1700042C RID: 1068
			// (get) Token: 0x06000D34 RID: 3380 RVA: 0x00009379 File Offset: 0x00007579
			public string Guid
			{
				get
				{
					return this.guid.ToString();
				}
			}

			// Token: 0x06000D35 RID: 3381 RVA: 0x0003F968 File Offset: 0x0003DB68
			public void Serialize(BinaryWriter w)
			{
				w.Write((uint)this.guid);
				if (this.guid == TXTC.EntryType.NULL)
				{
					return;
				}
				w.Write(0);
				w.Write((byte)this.typeCode);
				switch (this.typeCode)
				{
				case TXTC.EntryTypeCode.Boolean:
				case TXTC.EntryTypeCode.SignedByte:
				case TXTC.EntryTypeCode.UnsignedByte:
					w.Write((byte)this.data);
					return;
				case TXTC.EntryTypeCode.SignedShort:
				case TXTC.EntryTypeCode.UnsignedShort:
					w.Write((byte[])this.data);
					return;
				case TXTC.EntryTypeCode.SignedInt:
				case TXTC.EntryTypeCode.UnsignedInt:
				case TXTC.EntryTypeCode.Float:
					w.Write((byte[])this.data);
					return;
				case TXTC.EntryTypeCode.SignedLong:
				case TXTC.EntryTypeCode.UnsignedLong:
					w.Write((byte[])this.data);
					return;
				case TXTC.EntryTypeCode.RectFloat:
				case TXTC.EntryTypeCode.Vector4:
					w.Write((byte[])this.data);
					return;
				case TXTC.EntryTypeCode.TGIIndex:
					w.Write((byte)this.data);
					return;
				case TXTC.EntryTypeCode.String:
				{
					w.Write((short)((string)this.data).Length);
					char[] array = ((string)this.data).ToCharArray();
					for (int i = 0; i < array.Length; i++)
					{
						w.Write((byte)array[i]);
					}
					return;
				}
				default:
					return;
				}
			}

			// Token: 0x06000D36 RID: 3382 RVA: 0x0003FA90 File Offset: 0x0003DC90
			public void Unserialize(BinaryReader r)
			{
				this.guid = (TXTC.EntryType)r.ReadUInt32();
				if (this.guid == TXTC.EntryType.NULL)
				{
					return;
				}
				r.ReadByte();
				this.typeCode = (TXTC.EntryTypeCode)r.ReadByte();
				switch (this.typeCode)
				{
				case TXTC.EntryTypeCode.Boolean:
				case TXTC.EntryTypeCode.SignedByte:
				case TXTC.EntryTypeCode.UnsignedByte:
					this.data = r.ReadByte();
					return;
				case TXTC.EntryTypeCode.SignedShort:
				case TXTC.EntryTypeCode.UnsignedShort:
					this.data = r.ReadBytes(2);
					return;
				case TXTC.EntryTypeCode.SignedInt:
				case TXTC.EntryTypeCode.UnsignedInt:
				case TXTC.EntryTypeCode.Float:
					this.data = r.ReadBytes(4);
					return;
				case TXTC.EntryTypeCode.SignedLong:
				case TXTC.EntryTypeCode.UnsignedLong:
					this.data = r.ReadBytes(8);
					return;
				case TXTC.EntryTypeCode.RectFloat:
				case TXTC.EntryTypeCode.Vector4:
					this.data = r.ReadBytes(16);
					return;
				case TXTC.EntryTypeCode.TGIIndex:
					this.data = r.ReadByte();
					return;
				case TXTC.EntryTypeCode.String:
				{
					ushort length = r.ReadUInt16();
					this.data = PackageUtil.ReadString(r, (int)length);
					return;
				}
				default:
					return;
				}
			}

			// Token: 0x06000D37 RID: 3383 RVA: 0x0003FB7C File Offset: 0x0003DD7C
			public uint GetUIntData()
			{
				byte[] array = (byte[])this.data;
				return (uint)(((int)array[3] << 24) + ((int)array[2] << 16) + ((int)array[1] << 8) + (int)array[0]);
			}

			// Token: 0x04000723 RID: 1827
			public TXTC.EntryType guid;

			// Token: 0x04000724 RID: 1828
			public object data;

			// Token: 0x04000725 RID: 1829
			public TXTC.EntryTypeCode typeCode;
		}

		// Token: 0x02000116 RID: 278
		public class PropertySet
		{
			// Token: 0x1700042D RID: 1069
			// (get) Token: 0x06000D38 RID: 3384 RVA: 0x0000938C File Offset: 0x0000758C
			// (set) Token: 0x06000D39 RID: 3385 RVA: 0x00009394 File Offset: 0x00007594
			public List<TXTC.PROPEntry> Properties { get; set; }

			// Token: 0x06000D3A RID: 3386 RVA: 0x0000939D File Offset: 0x0000759D
			public PropertySet()
			{
				this.Properties = new List<TXTC.PROPEntry>();
			}

			// Token: 0x06000D3B RID: 3387 RVA: 0x0003FBAC File Offset: 0x0003DDAC
			public void Unserialize(BinaryReader r)
			{
				TXTC.PROPEntry propentry;
				do
				{
					propentry = new TXTC.PROPEntry();
					propentry.Unserialize(r);
					this.Properties.Add(propentry);
				}
				while (propentry.guid != TXTC.EntryType.NULL);
			}

			// Token: 0x06000D3C RID: 3388 RVA: 0x0003FBDC File Offset: 0x0003DDDC
			public void Serialize(BinaryWriter w)
			{
				foreach (TXTC.PROPEntry propentry in this.Properties)
				{
					propentry.Serialize(w);
				}
			}

			// Token: 0x06000D3D RID: 3389 RVA: 0x0003FC30 File Offset: 0x0003DE30
			public TXTC.PROPEntry GetEntry(TXTC.EntryType type)
			{
				foreach (TXTC.PROPEntry propentry in this.Properties)
				{
					if (propentry.guid == type)
					{
						return propentry;
					}
				}
				return null;
			}
		}

		// Token: 0x02000117 RID: 279
		public class FABC
		{
			// Token: 0x1700042E RID: 1070
			// (get) Token: 0x06000D3E RID: 3390 RVA: 0x000093B0 File Offset: 0x000075B0
			public IGTIndex IGTIndex
			{
				get
				{
					return this._parent.IGTIndex[(int)this.index];
				}
			}

			// Token: 0x06000D3F RID: 3391 RVA: 0x000093C8 File Offset: 0x000075C8
			public FABC(TXTC parent)
			{
				this._parent = parent;
				this.txtc = new TXTC(54635721U);
				this.txtc.version = parent.version;
				this.txtc.PatternSize = TXTC.Size.Default;
			}

			// Token: 0x06000D40 RID: 3392 RVA: 0x0003FC90 File Offset: 0x0003DE90
			public void Unserialize(BinaryReader r)
			{
				this.index = r.ReadByte();
				int count = r.ReadInt32();
				this.txtc = new TXTC(54635721U);
				this.txtc.SetData(r.ReadBytes(count));
			}

			// Token: 0x06000D41 RID: 3393 RVA: 0x0003FCD4 File Offset: 0x0003DED4
			public void Serialize(BinaryWriter w)
			{
				byte[] array = this.txtc.Serialize();
				w.Write(this.index);
				w.Write(array.Length + 3);
				w.Write(array);
				w.Write(new byte[3]);
			}

			// Token: 0x06000D42 RID: 3394 RVA: 0x0003FD18 File Offset: 0x0003DF18
			public XmlDocument ToPreset()
			{
				XmlDocument xmlDocument = new XmlDocument();
				XmlElement xmlElement = xmlDocument.CreateElement("preset");
				XmlElement xmlElement2 = xmlDocument.CreateElement("complate");
				xmlElement.AppendChild(xmlElement2);
				xmlElement2.SetAttribute("reskey", this.IGTIndex.AsString());
				XmlElement xmlElement3 = xmlDocument.CreateElement("value");
				xmlElement2.AppendChild(xmlElement3);
				xmlElement3.SetAttribute("key", "partType");
				xmlElement3.SetAttribute("value", "");
				XmlElement xmlElement4 = xmlDocument.CreateElement("value");
				xmlElement2.AppendChild(xmlElement4);
				xmlElement4.SetAttribute("key", "daeFileName");
				xmlElement4.SetAttribute("value", "createdFromPropset");
				xmlDocument.AppendChild(xmlElement);
				return xmlDocument;
			}

			// Token: 0x06000D43 RID: 3395 RVA: 0x00009404 File Offset: 0x00007604
			public XmlDocument ToComplate(string complateName, TXTC.ComplateType complateType)
			{
				return TXTC.CreateComplate(this._parent, this.txtc.PropertySets, complateName, complateType);
			}

			// Token: 0x04000727 RID: 1831
			public byte index;

			// Token: 0x04000728 RID: 1832
			public TXTC txtc;

			// Token: 0x04000729 RID: 1833
			private TXTC _parent;
		}
	}
}
