using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using Package.Sims3Files;

namespace Package
{
	// Token: 0x02000010 RID: 16
	public class TsrPack
	{
		// Token: 0x17000029 RID: 41
		// (get) Token: 0x060000D9 RID: 217 RVA: 0x0000360D File Offset: 0x0000180D
		// (set) Token: 0x060000DA RID: 218 RVA: 0x00003615 File Offset: 0x00001815
		public string Type { get; set; }

		// Token: 0x1700002A RID: 42
		// (get) Token: 0x060000DB RID: 219 RVA: 0x0000361E File Offset: 0x0000181E
		// (set) Token: 0x060000DC RID: 220 RVA: 0x00003626 File Offset: 0x00001826
		public int Version { get; set; }

		// Token: 0x1700002B RID: 43
		// (get) Token: 0x060000DD RID: 221 RVA: 0x0000362F File Offset: 0x0000182F
		// (set) Token: 0x060000DE RID: 222 RVA: 0x00003637 File Offset: 0x00001837
		public string Title { get; set; }

		// Token: 0x1700002C RID: 44
		// (get) Token: 0x060000DF RID: 223 RVA: 0x00003640 File Offset: 0x00001840
		// (set) Token: 0x060000E0 RID: 224 RVA: 0x00003648 File Offset: 0x00001848
		public string Description { get; set; }

		// Token: 0x1700002D RID: 45
		// (get) Token: 0x060000E1 RID: 225 RVA: 0x00003651 File Offset: 0x00001851
		// (set) Token: 0x060000E2 RID: 226 RVA: 0x00003659 File Offset: 0x00001859
		public Hashtable Attributes { get; set; }

		// Token: 0x1700002E RID: 46
		// (get) Token: 0x060000E3 RID: 227 RVA: 0x00003662 File Offset: 0x00001862
		// (set) Token: 0x060000E4 RID: 228 RVA: 0x0000366A File Offset: 0x0000186A
		public List<TsrPackFile> Files { get; set; }

		// Token: 0x060000E5 RID: 229 RVA: 0x00003673 File Offset: 0x00001873
		public TsrPack(string type, string title, string description)
		{
			this.Type = type;
			this.Title = title;
			this.Description = description;
			this.Attributes = new Hashtable();
			this.Files = new List<TsrPackFile>();
		}

		// Token: 0x060000E6 RID: 230 RVA: 0x0000FC3C File Offset: 0x0000DE3C
		public byte[] Serialize()
		{
			XmlDocument xmlDocument = new XmlDocument();
			XmlDeclaration newChild = xmlDocument.CreateXmlDeclaration("1.0", "utf-8", "");
			xmlDocument.AppendChild(newChild);
			XmlElement xmlElement = xmlDocument.CreateElement("s3wpack");
			xmlDocument.AppendChild(xmlElement);
			xmlElement.AppendChild(XML.CreateValueNode(xmlDocument, "type", this.Type));
			xmlElement.AppendChild(XML.CreateValueNode(xmlDocument, "version", this.Version.ToString() ?? ""));
			xmlElement.AppendChild(XML.CreateValueNode(xmlDocument, "s3wpackversion", "1.0.0"));
			xmlElement.AppendChild(XML.CreateValueNode(xmlDocument, "title", this.Title));
			xmlElement.AppendChild(XML.CreateValueNode(xmlDocument, "description", this.Description));
			if (this.Attributes.Count > 0)
			{
				XmlElement xmlElement2 = xmlDocument.CreateElement("attributes");
				foreach (object obj in this.Attributes)
				{
					DictionaryEntry dictionaryEntry = (DictionaryEntry)obj;
					XmlDocument doc = xmlDocument;
					string name = "attribute";
					object value = dictionaryEntry.Value;
					if (value == null)
					{
						goto IL_119;
					}
					string value2;
					if ((value2 = value.ToString()) == null)
					{
						goto IL_119;
					}
					IL_11F:
					XmlNode xmlNode = XML.CreateValueNode(doc, name, value2);
					XmlAttributeCollection attributes = xmlNode.Attributes;
					XmlDocument doc2 = xmlDocument;
					string name2 = "name";
					object key = dictionaryEntry.Key;
					if (key == null)
					{
						goto IL_149;
					}
					string value3;
					if ((value3 = key.ToString()) == null)
					{
						goto IL_149;
					}
					IL_14F:
					attributes.Append(XML.CreateAttribute(doc2, name2, value3));
					xmlElement2.AppendChild(xmlNode);
					continue;
					IL_149:
					value3 = "";
					goto IL_14F;
					IL_119:
					value2 = "";
					goto IL_11F;
				}
				xmlElement.AppendChild(xmlElement2);
			}
			if (this.Files.Count > 0)
			{
				XmlElement xmlElement3 = xmlDocument.CreateElement("files");
				int num = 0;
				foreach (TsrPackFile tsrPackFile in this.Files)
				{
					XmlElement xmlElement4 = xmlDocument.CreateElement("file");
					xmlElement4.AppendChild(XML.CreateValueNode(xmlDocument, "name", tsrPackFile.Name));
					xmlElement4.AppendChild(XML.CreateValueNode(xmlDocument, "type", tsrPackFile.Type));
					xmlElement4.AppendChild(XML.CreateValueNode(xmlDocument, "offset", num.ToString() ?? ""));
					xmlElement4.AppendChild(XML.CreateValueNode(xmlDocument, "length", tsrPackFile.Data.Length.ToString() ?? ""));
					num += tsrPackFile.Data.Length;
					xmlElement3.AppendChild(xmlElement4);
				}
				xmlElement.AppendChild(xmlElement3);
			}
			UTF8Encoding encoding = new UTF8Encoding(false);
			MemoryStream memoryStream = new MemoryStream();
			XmlTextWriter xmlTextWriter = new XmlTextWriter(memoryStream, encoding);
			xmlTextWriter.Flush();
			xmlDocument.WriteTo(xmlTextWriter);
			xmlTextWriter.Flush();
			MemoryStream memoryStream2 = new MemoryStream();
			BinaryWriter binaryWriter = new BinaryWriter(memoryStream2);
			binaryWriter.Write((int)memoryStream.Length);
			binaryWriter.Write(memoryStream.GetBuffer());
			foreach (TsrPackFile tsrPackFile2 in this.Files)
			{
				binaryWriter.Write(tsrPackFile2.Data);
			}
			binaryWriter.Close();
			return memoryStream2.GetBuffer();
		}
	}
}
