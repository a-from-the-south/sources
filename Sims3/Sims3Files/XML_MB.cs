using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;
using Sims3WorkshopSDK;

namespace Package.Sims3Files
{
	// Token: 0x02000052 RID: 82
	public class XML_MB : DBPFEntry
	{
		// Token: 0x06000426 RID: 1062 RVA: 0x0000504A File Offset: 0x0000324A
		public XML_MB()
		{
			this.xmlDocuments = new List<XmlDocument>();
			this.typeId = 72016144U;
			this.fileExtension = ".xml";
		}

		// Token: 0x17000156 RID: 342
		// (get) Token: 0x06000427 RID: 1063 RVA: 0x00005073 File Offset: 0x00003273
		public List<XmlDocument> Documents
		{
			get
			{
				return this.xmlDocuments;
			}
		}

		// Token: 0x06000428 RID: 1064 RVA: 0x0001B320 File Offset: 0x00019520
		public override void UnSerialize()
		{
			BinaryReader binaryReader = new BinaryReader(new MemoryStream(this.data));
			if (binaryReader.ReadInt32() == 2)
			{
				int num = binaryReader.ReadInt32();
				StreamReader streamReader = new StreamReader(new MemoryStream(binaryReader.ReadBytes(num * 2)), Encoding.Unicode);
				string text = "";
				while (!streamReader.EndOfStream)
				{
					text = text + streamReader.ReadLine() + "\r\n";
				}
				XmlDocument xmlDocument = new XmlDocument();
				try
				{
					xmlDocument.LoadXml(text);
					this.xmlDocuments.Add(xmlDocument);
					return;
				}
				catch (Exception)
				{
					return;
				}
			}
			binaryReader.ReadInt32();
			int num2 = (int)binaryReader.ReadByte();
			binaryReader.ReadInt32();
			for (int i = 0; i < num2; i++)
			{
				try
				{
					int count = binaryReader.ReadInt32() * 2;
					byte[] buffer = binaryReader.ReadBytes(count);
					if (i < num2 - 1)
					{
						binaryReader.ReadByte();
					}
					StreamReader streamReader2 = new StreamReader(new MemoryStream(buffer), Encoding.Unicode);
					string text2 = "";
					while (!streamReader2.EndOfStream)
					{
						text2 = text2 + streamReader2.ReadLine() + "\r\n";
					}
					XmlDocument xmlDocument2 = new XmlDocument();
					try
					{
						xmlDocument2.LoadXml(text2);
						this.xmlDocuments.Add(xmlDocument2);
					}
					catch (Exception)
					{
					}
				}
				catch (Exception)
				{
				}
			}
		}

		// Token: 0x06000429 RID: 1065 RVA: 0x0000330C File Offset: 0x0000150C
		public override byte[] Serialize()
		{
			return this.data;
		}

		// Token: 0x0600042A RID: 1066 RVA: 0x0001B488 File Offset: 0x00019688
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
					regex.Replace(innerXml, to.AsString());
				}
			}
			return num;
		}

		// Token: 0x0600042B RID: 1067 RVA: 0x0001B518 File Offset: 0x00019718
		public override void SaveToFile(string fileName)
		{
			FileStream fileStream = new FileStream(fileName, FileMode.OpenOrCreate);
			foreach (XmlDocument xmlDocument in this.xmlDocuments)
			{
				xmlDocument.Save(fileStream);
			}
			fileStream.Close();
		}

		// Token: 0x0600042C RID: 1068 RVA: 0x0000507B File Offset: 0x0000327B
		public override string ToString()
		{
			return "XML_MB | " + base.ToString();
		}

		// Token: 0x0400020E RID: 526
		protected List<XmlDocument> xmlDocuments;
	}
}
