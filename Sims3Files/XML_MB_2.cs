using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;
using Sims3WorkshopSDK;

namespace Package.Sims3Files
{
	// Token: 0x02000053 RID: 83
	public class XML_MB_2 : DBPFEntry
	{
		// Token: 0x0600042D RID: 1069 RVA: 0x0000508D File Offset: 0x0000328D
		public XML_MB_2()
		{
			this.xmlDocuments = new List<XML_MB_2.XML_Document>();
			this.typeId = 72016144U;
			this.fileExtension = ".xml";
		}

		// Token: 0x0600042E RID: 1070 RVA: 0x000050B6 File Offset: 0x000032B6
		public XML_MB_2(uint typeId)
		{
			this.xmlDocuments = new List<XML_MB_2.XML_Document>();
			this.typeId = typeId;
			this.fileExtension = ".xml";
		}

		// Token: 0x0600042F RID: 1071 RVA: 0x0001B578 File Offset: 0x00019778
		public override void UnSerialize()
		{
			this.xmlDocuments.Clear();
			BinaryReader binaryReader = new BinaryReader(new MemoryStream(this.data));
			int num = binaryReader.ReadInt32();
			int num2;
			int num3;
			if (num == 18)
			{
				num2 = binaryReader.ReadInt32();
				num3 = binaryReader.ReadInt32();
			}
			else
			{
				num2 = binaryReader.ReadInt32();
				num3 = (int)binaryReader.ReadByte();
				binaryReader.ReadUInt32();
			}
			for (int i = 0; i < num3; i++)
			{
				int num4 = binaryReader.ReadInt32();
				byte[] bytes = binaryReader.ReadBytes(num4 * 2);
				if (i < num3 - 1)
				{
					if (num != 18)
					{
						binaryReader.ReadByte();
					}
					else
					{
						binaryReader.ReadInt32();
					}
				}
				XML_MB_2.XML_Document xml_Document = new XML_MB_2.XML_Document();
				xml_Document.Size = num4;
				if (num4 > 0)
				{
					string @string = new UnicodeEncoding().GetString(bytes);
					xml_Document.Document = new XmlDocument();
					xml_Document.Document.LoadXml(@string);
				}
				this.xmlDocuments.Add(xml_Document);
			}
			binaryReader.BaseStream.Position = (long)(num2 + 8);
			byte b = binaryReader.ReadByte();
			this.properties = new uint[(int)b][];
			for (int j = 0; j < (int)b; j++)
			{
				this.properties[j] = new uint[4];
				this.properties[j][0] = binaryReader.ReadUInt32();
				this.properties[j][1] = binaryReader.ReadUInt32();
				this.properties[j][2] = binaryReader.ReadUInt32();
				this.properties[j][3] = binaryReader.ReadUInt32();
			}
		}

		// Token: 0x06000430 RID: 1072 RVA: 0x000038FA File Offset: 0x00001AFA
		public override byte[] Serialize()
		{
			throw new NotImplementedException();
		}

		// Token: 0x17000157 RID: 343
		// (get) Token: 0x06000431 RID: 1073 RVA: 0x000050DB File Offset: 0x000032DB
		public XML_MB_2.XML_Document[] XMLDocuments
		{
			get
			{
				return this.xmlDocuments.ToArray();
			}
		}

		// Token: 0x17000158 RID: 344
		// (get) Token: 0x06000432 RID: 1074 RVA: 0x000050E8 File Offset: 0x000032E8
		public uint[][] Values
		{
			get
			{
				return this.values;
			}
		}

		// Token: 0x17000159 RID: 345
		// (get) Token: 0x06000433 RID: 1075 RVA: 0x000050F0 File Offset: 0x000032F0
		public byte[][] CharacterTable
		{
			get
			{
				return this.chars;
			}
		}

		// Token: 0x1700015A RID: 346
		// (get) Token: 0x06000434 RID: 1076 RVA: 0x000050F8 File Offset: 0x000032F8
		public uint[][] Properties
		{
			get
			{
				return this.properties;
			}
		}

		// Token: 0x06000435 RID: 1077 RVA: 0x0001B6EC File Offset: 0x000198EC
		public override int ReplaceReferences(ResKey from, ResKey to)
		{
			int num = 0;
			Regex regex = new Regex(from.AsString(), RegexOptions.Multiline);
			foreach (XML_MB_2.XML_Document xml_Document in this.xmlDocuments)
			{
				string innerXml = xml_Document.Document.InnerXml;
				MatchCollection matchCollection = regex.Matches(innerXml);
				num += matchCollection.Count;
				if (matchCollection.Count > 0)
				{
					string innerXml2 = regex.Replace(innerXml, to.AsString());
					xml_Document.Document.InnerXml = innerXml2;
				}
			}
			return num;
		}

		// Token: 0x06000436 RID: 1078 RVA: 0x00005100 File Offset: 0x00003300
		public override void SaveToFile(string fileName)
		{
			FileStream fileStream = new FileStream(fileName, FileMode.OpenOrCreate);
			fileStream.Write(this.data, 0, this.data.Length);
			fileStream.Close();
		}

		// Token: 0x06000437 RID: 1079 RVA: 0x00005123 File Offset: 0x00003323
		public override string ToString()
		{
			return "XML_MB_2 | " + base.ToString();
		}

		// Token: 0x0400020F RID: 527
		protected List<XML_MB_2.XML_Document> xmlDocuments;

		// Token: 0x04000210 RID: 528
		private uint[][] values;

		// Token: 0x04000211 RID: 529
		private byte[][] chars;

		// Token: 0x04000212 RID: 530
		private uint[][] properties;

		// Token: 0x02000122 RID: 290
		public class XML_Document
		{
			// Token: 0x17000435 RID: 1077
			// (get) Token: 0x06000D58 RID: 3416 RVA: 0x00009547 File Offset: 0x00007747
			// (set) Token: 0x06000D59 RID: 3417 RVA: 0x0000954F File Offset: 0x0000774F
			public int Size
			{
				get
				{
					return this.dataLength;
				}
				set
				{
					this.dataLength = value;
				}
			}

			// Token: 0x17000436 RID: 1078
			// (get) Token: 0x06000D5A RID: 3418 RVA: 0x00009558 File Offset: 0x00007758
			// (set) Token: 0x06000D5B RID: 3419 RVA: 0x00009560 File Offset: 0x00007760
			public XmlDocument Document
			{
				get
				{
					return this.document;
				}
				set
				{
					this.document = value;
				}
			}

			// Token: 0x04000791 RID: 1937
			private int dataLength;

			// Token: 0x04000792 RID: 1938
			private XmlDocument document;
		}
	}
}
