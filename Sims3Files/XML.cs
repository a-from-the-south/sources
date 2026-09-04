using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;
using Sims3WorkshopSDK;

namespace Package.Sims3Files
{
	// Token: 0x02000051 RID: 81
	public class XML : DBPFEntry
	{
		// Token: 0x0600041B RID: 1051 RVA: 0x00004FA4 File Offset: 0x000031A4
		public XML()
		{
			this.xmlDocuments = new List<XmlDocument>();
			this.typeId = 39620774U;
			this.fileExtension = ".xml";
		}

		// Token: 0x0600041C RID: 1052 RVA: 0x00004FCD File Offset: 0x000031CD
		public XML(uint typeId)
		{
			this.xmlDocuments = new List<XmlDocument>();
			this.typeId = typeId;
			this.fileExtension = ".xml";
		}

		// Token: 0x17000155 RID: 341
		// (get) Token: 0x0600041D RID: 1053 RVA: 0x00004FF2 File Offset: 0x000031F2
		public List<XmlDocument> Documents
		{
			get
			{
				return this.xmlDocuments;
			}
		}

		// Token: 0x0600041E RID: 1054 RVA: 0x0001B184 File Offset: 0x00019384
		public override int ReplaceReferences(ResKey from, ResKey to)
		{
			int num = 0;
			Regex regex = new Regex(from.AsString(), RegexOptions.Multiline);
			foreach (XmlDocument xmlDocument in this.xmlDocuments)
			{
				string innerXml = xmlDocument.InnerXml;
				MatchCollection matchCollection = regex.Matches(innerXml);
				num += matchCollection.Count;
				if (matchCollection.Count > 0)
				{
					string innerXml2 = regex.Replace(innerXml, to.AsString());
					xmlDocument.InnerXml = innerXml2;
				}
			}
			return num;
		}

		// Token: 0x0600041F RID: 1055 RVA: 0x0001B220 File Offset: 0x00019420
		public override void UnSerialize()
		{
			this.xmlDocuments.Clear();
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.Load(new MemoryStream(this.data));
			this.xmlDocuments.Add(xmlDocument);
		}

		// Token: 0x06000420 RID: 1056 RVA: 0x0001B25C File Offset: 0x0001945C
		public static byte[] XmlToBytes(XmlDocument doc)
		{
			MemoryStream memoryStream = new MemoryStream();
			UTF8Encoding encoding = new UTF8Encoding(false);
			new XmlTextWriter(memoryStream, encoding);
			doc.Save(memoryStream);
			byte[] result = memoryStream.ToArray();
			memoryStream.Dispose();
			return result;
		}

		// Token: 0x06000421 RID: 1057 RVA: 0x0001B294 File Offset: 0x00019494
		public override byte[] Serialize()
		{
			if (this.Documents.Count == 0 && this.data.Length != 0)
			{
				return this.data;
			}
			MemoryStream memoryStream = new MemoryStream();
			UTF8Encoding encoding = new UTF8Encoding(false);
			new XmlTextWriter(memoryStream, encoding);
			foreach (XmlDocument xmlDocument in this.xmlDocuments)
			{
				xmlDocument.Save(memoryStream);
			}
			return memoryStream.ToArray();
		}

		// Token: 0x06000422 RID: 1058 RVA: 0x00004FFA File Offset: 0x000031FA
		public override string ToString()
		{
			return "XML | " + base.ToString();
		}

		// Token: 0x06000423 RID: 1059 RVA: 0x0000500C File Offset: 0x0000320C
		public static XmlAttribute CreateAttribute(XmlDocument doc, string name, string value)
		{
			XmlAttribute xmlAttribute = doc.CreateAttribute(name);
			xmlAttribute.Value = value;
			return xmlAttribute;
		}

		// Token: 0x06000424 RID: 1060 RVA: 0x0000501C File Offset: 0x0000321C
		public static XmlNode CreateValueNode(XmlDocument doc, string name, string value)
		{
			XmlElement xmlElement = doc.CreateElement(name);
			xmlElement.AppendChild(doc.CreateTextNode(value));
			return xmlElement;
		}

		// Token: 0x06000425 RID: 1061 RVA: 0x00005033 File Offset: 0x00003233
		public static XmlNode CreateCdataValueNode(XmlDocument doc, string name, string value)
		{
			XmlElement xmlElement = doc.CreateElement(name);
			xmlElement.AppendChild(doc.CreateCDataSection(value));
			return xmlElement;
		}

		// Token: 0x0400020D RID: 525
		protected List<XmlDocument> xmlDocuments;
	}
}
