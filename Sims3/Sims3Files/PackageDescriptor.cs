using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using System.Xml;
using Package.Helper;
using Sims3WorkshopSDK;

namespace Package.Sims3Files
{
	// Token: 0x0200003B RID: 59
	public class PackageDescriptor : XML
	{
		// Token: 0x17000105 RID: 261
		// (get) Token: 0x06000324 RID: 804 RVA: 0x0000484D File Offset: 0x00002A4D
		// (set) Token: 0x06000325 RID: 805 RVA: 0x00004855 File Offset: 0x00002A55
		public string GameVersion { get; set; }

		// Token: 0x17000106 RID: 262
		// (get) Token: 0x06000326 RID: 806 RVA: 0x0000485E File Offset: 0x00002A5E
		// (set) Token: 0x06000327 RID: 807 RVA: 0x00004866 File Offset: 0x00002A66
		public DateTime Date { get; set; }

		// Token: 0x17000107 RID: 263
		// (get) Token: 0x06000328 RID: 808 RVA: 0x0000486F File Offset: 0x00002A6F
		// (set) Token: 0x06000329 RID: 809 RVA: 0x00004877 File Offset: 0x00002A77
		public string Id { get; set; }

		// Token: 0x17000108 RID: 264
		// (get) Token: 0x0600032A RID: 810 RVA: 0x00004880 File Offset: 0x00002A80
		// (set) Token: 0x0600032B RID: 811 RVA: 0x00004888 File Offset: 0x00002A88
		public string Title
		{
			get
			{
				return this._title;
			}
			set
			{
				this._title = value;
				this.LocalizedNames.Clear();
				this.LocalizedNames.Add(new LocalizedString(value));
			}
		}

		// Token: 0x17000109 RID: 265
		// (get) Token: 0x0600032C RID: 812 RVA: 0x000048AD File Offset: 0x00002AAD
		// (set) Token: 0x0600032D RID: 813 RVA: 0x000048B5 File Offset: 0x00002AB5
		public string Description
		{
			get
			{
				return this._description;
			}
			set
			{
				this._description = value;
				this.LocalizedDescriptions.Clear();
				this.LocalizedDescriptions.Add(new LocalizedString(value));
			}
		}

		// Token: 0x1700010A RID: 266
		// (get) Token: 0x0600032E RID: 814 RVA: 0x000048DA File Offset: 0x00002ADA
		// (set) Token: 0x0600032F RID: 815 RVA: 0x000048E2 File Offset: 0x00002AE2
		public int AssetVersion { get; set; }

		// Token: 0x1700010B RID: 267
		// (get) Token: 0x06000330 RID: 816 RVA: 0x000048EB File Offset: 0x00002AEB
		// (set) Token: 0x06000331 RID: 817 RVA: 0x000048F3 File Offset: 0x00002AF3
		public string MinGameVersion { get; set; }

		// Token: 0x1700010C RID: 268
		// (get) Token: 0x06000332 RID: 818 RVA: 0x000048FC File Offset: 0x00002AFC
		// (set) Token: 0x06000333 RID: 819 RVA: 0x00004904 File Offset: 0x00002B04
		public List<LocalizedString> LocalizedNames { get; set; }

		// Token: 0x1700010D RID: 269
		// (get) Token: 0x06000334 RID: 820 RVA: 0x0000490D File Offset: 0x00002B0D
		// (set) Token: 0x06000335 RID: 821 RVA: 0x00004915 File Offset: 0x00002B15
		public List<LocalizedString> LocalizedDescriptions { get; set; }

		// Token: 0x1700010E RID: 270
		// (get) Token: 0x06000336 RID: 822 RVA: 0x0000491E File Offset: 0x00002B1E
		// (set) Token: 0x06000337 RID: 823 RVA: 0x00004926 File Offset: 0x00002B26
		public List<string> DependencyList { get; set; }

		// Token: 0x1700010F RID: 271
		// (get) Token: 0x06000338 RID: 824 RVA: 0x0000492F File Offset: 0x00002B2F
		// (set) Token: 0x06000339 RID: 825 RVA: 0x00004937 File Offset: 0x00002B37
		public List<string> KeyyList { get; set; }

		// Token: 0x17000110 RID: 272
		// (get) Token: 0x0600033A RID: 826 RVA: 0x00004940 File Offset: 0x00002B40
		// (set) Token: 0x0600033B RID: 827 RVA: 0x00004948 File Offset: 0x00002B48
		public List<ResKey> StringTables { get; set; }

		// Token: 0x17000111 RID: 273
		// (get) Token: 0x0600033C RID: 828 RVA: 0x00004951 File Offset: 0x00002B51
		// (set) Token: 0x0600033D RID: 829 RVA: 0x00004959 File Offset: 0x00002B59
		public Hashtable MetaTags { get; set; }

		// Token: 0x17000112 RID: 274
		// (get) Token: 0x0600033E RID: 830 RVA: 0x00004962 File Offset: 0x00002B62
		// (set) Token: 0x0600033F RID: 831 RVA: 0x0000496A File Offset: 0x00002B6A
		public Hashtable Manifest { get; set; }

		// Token: 0x17000113 RID: 275
		// (get) Token: 0x06000340 RID: 832 RVA: 0x00004973 File Offset: 0x00002B73
		// (set) Token: 0x06000341 RID: 833 RVA: 0x0000497B File Offset: 0x00002B7B
		public string Thumbnail { get; set; }

		// Token: 0x06000342 RID: 834 RVA: 0x00017768 File Offset: 0x00015968
		public PackageDescriptor()
		{
			this.GameVersion = "0.0.0.51";
			this.Date = DateTime.Now;
			this.MinGameVersion = "1.0.0.0";
			this.AssetVersion = 1;
			this.typeId = 1944665835U;
			this.LocalizedNames = new List<LocalizedString>();
			this.LocalizedDescriptions = new List<LocalizedString>();
			this.StringTables = new List<ResKey>();
			this.Manifest = new Hashtable();
			this.MetaTags = new Hashtable();
			this.DependencyList = new List<string>();
			this.KeyyList = new List<string>();
		}

		// Token: 0x06000343 RID: 835 RVA: 0x00004984 File Offset: 0x00002B84
		public override string ToString()
		{
			return "PACKDESC | " + base.ToString();
		}

		// Token: 0x06000344 RID: 836 RVA: 0x000177FC File Offset: 0x000159FC
		public override void UnSerialize()
		{
			base.UnSerialize();
			XmlDocument xmlDocument = base.Documents[0];
			this.Title = xmlDocument.SelectSingleNode("/manifest/packagetitle").InnerText;
			this.Description = xmlDocument.SelectSingleNode("/manifest/packagedesc").InnerText;
			this.Id = xmlDocument.SelectSingleNode("/manifest/packageid").InnerText;
			this.AssetVersion = Convert.ToInt32(xmlDocument.SelectSingleNode("/manifest/assetversion").InnerText);
			this.MinGameVersion = xmlDocument.SelectSingleNode("/manifest/mingamever").InnerText;
			this.GameVersion = xmlDocument.SelectSingleNode("/manifest/gameversion").InnerText;
			XmlNode xmlNode = xmlDocument.SelectSingleNode("/manifest");
			this.Manifest.Clear();
			foreach (object obj in xmlNode.Attributes)
			{
				XmlAttribute xmlAttribute = (XmlAttribute)obj;
				this.Manifest.Add(xmlAttribute.Name.ToString(), xmlAttribute.Value.ToString());
			}
			if (xmlDocument.GetElementsByTagName("thumbnail").Count > 0)
			{
				this.Thumbnail = xmlDocument.GetElementsByTagName("thumbnail").Item(0).InnerText;
			}
			XmlNodeList xmlNodeList = xmlDocument.SelectNodes("/manifest/localizednames/localizedname");
			if (xmlNodeList != null)
			{
				this.LocalizedNames.Clear();
				foreach (object obj2 in xmlNodeList)
				{
					XmlNode xmlNode2 = (XmlNode)obj2;
					this.LocalizedNames.Add(new LocalizedString(xmlNode2.InnerText, xmlNode2.Attributes["language"].Value));
				}
			}
			XmlNodeList xmlNodeList2 = xmlDocument.SelectNodes("/manifest/localizeddescriptions/localizeddescription");
			if (xmlNodeList2 != null)
			{
				this.LocalizedDescriptions.Clear();
				foreach (object obj3 in xmlNodeList2)
				{
					XmlNode xmlNode3 = (XmlNode)obj3;
					this.LocalizedDescriptions.Add(new LocalizedString(xmlNode3.InnerText, xmlNode3.Attributes["language"].Value));
				}
			}
			XmlNodeList xmlNodeList3 = xmlDocument.SelectNodes("/manifest/dependencylist/packageid");
			if (xmlNodeList3 != null)
			{
				this.DependencyList.Clear();
				foreach (object obj4 in xmlNodeList3)
				{
					XmlNode xmlNode4 = (XmlNode)obj4;
					this.DependencyList.Add(xmlNode4.InnerText);
				}
			}
			XmlNodeList xmlNodeList4 = xmlDocument.SelectNodes("/manifest/keylist/reskey");
			if (xmlNodeList4 != null)
			{
				this.KeyyList.Clear();
				foreach (object obj5 in xmlNodeList4)
				{
					XmlNode xmlNode5 = (XmlNode)obj5;
					this.KeyyList.Add(xmlNode5.InnerText);
				}
			}
			XmlNodeList xmlNodeList5 = xmlDocument.SelectNodes("/manifest/metatags/*");
			if (xmlNodeList5 != null)
			{
				this.MetaTags.Clear();
				foreach (object obj6 in xmlNodeList5)
				{
					XmlNode xmlNode6 = (XmlNode)obj6;
					this.MetaTags.Add(xmlNode6.Name, xmlNode6.InnerText);
				}
			}
		}

		// Token: 0x06000345 RID: 837 RVA: 0x00017BD4 File Offset: 0x00015DD4
		public XmlDocument GetXml()
		{
			XmlDocument xmlDocument = new XmlDocument();
			XmlDeclaration newChild = xmlDocument.CreateXmlDeclaration("1.0", "UTF-8", "");
			xmlDocument.AppendChild(newChild);
			XmlNode xmlNode = xmlDocument.CreateElement("manifest");
			xmlDocument.AppendChild(xmlNode);
			if (this.Manifest.Count > 0)
			{
				foreach (object obj in this.Manifest)
				{
					DictionaryEntry dictionaryEntry = (DictionaryEntry)obj;
					xmlNode.Attributes.Append(XML.CreateAttribute(xmlDocument, (string)dictionaryEntry.Key, Convert.ToString(dictionaryEntry.Value)));
				}
			}
			xmlNode.AppendChild(XML.CreateValueNode(xmlDocument, "gameversion", this.GameVersion ?? ""));
			CultureInfo provider = new CultureInfo("en-US");
			string value = DateTime.Now.ToString("d", provider);
			xmlNode.AppendChild(XML.CreateValueNode(xmlDocument, "packagedate", value));
			xmlNode.AppendChild(XML.CreateValueNode(xmlDocument, "packageid", this.Id));
			xmlNode.AppendChild(XML.CreateValueNode(xmlDocument, "packagetitle", this.Title));
			xmlNode.AppendChild(XML.CreateValueNode(xmlDocument, "packagedesc", this.Description));
			xmlNode.AppendChild(XML.CreateValueNode(xmlDocument, "assetversion", this.AssetVersion.ToString() ?? ""));
			xmlNode.AppendChild(XML.CreateValueNode(xmlDocument, "mingamever", this.MinGameVersion ?? ""));
			if (this.Thumbnail != null)
			{
				xmlNode.AppendChild(XML.CreateValueNode(xmlDocument, "thumbnail", this.Thumbnail));
			}
			XmlNode xmlNode2 = xmlDocument.CreateElement("localizednames");
			foreach (LocalizedString localizedString in this.LocalizedNames)
			{
				XmlNode xmlNode3 = xmlDocument.CreateElement("localizedname");
				xmlNode3.Attributes.Append(XML.CreateAttribute(xmlDocument, "language", localizedString.Lang));
				xmlNode3.AppendChild(xmlDocument.CreateCDataSection(localizedString.Text));
				xmlNode2.AppendChild(xmlNode3);
			}
			xmlNode.AppendChild(xmlNode2);
			XmlNode xmlNode4 = xmlDocument.CreateElement("localizeddescriptions");
			foreach (LocalizedString localizedString2 in this.LocalizedDescriptions)
			{
				XmlNode xmlNode5 = xmlDocument.CreateElement("localizeddescription");
				xmlNode5.Attributes.Append(XML.CreateAttribute(xmlDocument, "language", localizedString2.Lang));
				xmlNode5.AppendChild(xmlDocument.CreateCDataSection(localizedString2.Text));
				xmlNode4.AppendChild(xmlNode5);
			}
			xmlNode.AppendChild(xmlNode4);
			XmlNode xmlNode6 = xmlDocument.CreateElement("handler");
			foreach (ResKey resKey in this.StringTables)
			{
				XmlNode xmlNode7 = xmlDocument.CreateElement("stringtable");
				xmlNode7.Attributes.Append(XML.CreateAttribute(xmlDocument, "reskey", string.Concat(new string[]
				{
					"0:",
					resKey.TypeId.ToString("X8"),
					":",
					resKey.GroupId.ToString("X8"),
					":",
					resKey.InstanceId.ToString("X8"),
					resKey.SecondInstanceId.ToString("X8")
				})));
				xmlNode6.AppendChild(xmlNode7);
			}
			xmlNode.AppendChild(xmlNode6);
			if (this.DependencyList.Count > 0)
			{
				XmlNode xmlNode8 = xmlDocument.CreateElement("dependencylist");
				foreach (string value2 in this.DependencyList)
				{
					xmlNode8.AppendChild(XML.CreateValueNode(xmlDocument, "packageid", value2));
				}
				xmlNode.AppendChild(xmlNode8);
			}
			if (this.KeyyList.Count > 0)
			{
				XmlNode xmlNode9 = xmlDocument.CreateElement("keylist");
				foreach (string value3 in this.KeyyList)
				{
					xmlNode9.AppendChild(XML.CreateValueNode(xmlDocument, "reskey", value3));
				}
				xmlNode.AppendChild(xmlNode9);
			}
			if (this.MetaTags.Count > 0)
			{
				XmlNode xmlNode10 = xmlDocument.CreateElement("metatags");
				foreach (object obj2 in this.MetaTags)
				{
					DictionaryEntry dictionaryEntry2 = (DictionaryEntry)obj2;
					xmlNode10.AppendChild(XML.CreateValueNode(xmlDocument, (string)dictionaryEntry2.Key, Convert.ToString(dictionaryEntry2.Value)));
				}
				xmlNode.AppendChild(xmlNode10);
			}
			return xmlDocument;
		}

		// Token: 0x06000346 RID: 838 RVA: 0x00018178 File Offset: 0x00016378
		public override byte[] Serialize()
		{
			XmlDocument xml = this.GetXml();
			UTF8Encoding encoding = new UTF8Encoding(false);
			MemoryStream memoryStream = new MemoryStream();
			XmlTextWriter xmlTextWriter = new XmlTextWriter(memoryStream, encoding);
			xmlTextWriter.Flush();
			xml.WriteTo(xmlTextWriter);
			xmlTextWriter.Flush();
			return memoryStream.ToArray();
		}

		// Token: 0x04000198 RID: 408
		private string _title;

		// Token: 0x04000199 RID: 409
		private string _description;
	}
}
