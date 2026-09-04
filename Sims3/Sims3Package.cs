using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using Package.Helper;
using Package.Sims3Files;
using Sims3WorkshopSDK;

namespace Package
{
	// Token: 0x0200000E RID: 14
	public class Sims3Package
	{
		// Token: 0x17000016 RID: 22
		// (get) Token: 0x060000A9 RID: 169 RVA: 0x00003472 File Offset: 0x00001672
		// (set) Token: 0x060000AA RID: 170 RVA: 0x0000347A File Offset: 0x0000167A
		public string Identifier { get; set; }

		// Token: 0x17000017 RID: 23
		// (get) Token: 0x060000AB RID: 171 RVA: 0x00003483 File Offset: 0x00001683
		// (set) Token: 0x060000AC RID: 172 RVA: 0x0000348B File Offset: 0x0000168B
		public byte MajorVersion { get; set; }

		// Token: 0x17000018 RID: 24
		// (get) Token: 0x060000AD RID: 173 RVA: 0x00003494 File Offset: 0x00001694
		// (set) Token: 0x060000AE RID: 174 RVA: 0x0000349C File Offset: 0x0000169C
		public byte MinorVersion { get; set; }

		// Token: 0x17000019 RID: 25
		// (get) Token: 0x060000AF RID: 175 RVA: 0x000034A5 File Offset: 0x000016A5
		// (set) Token: 0x060000B0 RID: 176 RVA: 0x000034AD File Offset: 0x000016AD
		public string Type { get; set; }

		// Token: 0x1700001A RID: 26
		// (get) Token: 0x060000B1 RID: 177 RVA: 0x000034B6 File Offset: 0x000016B6
		// (set) Token: 0x060000B2 RID: 178 RVA: 0x000034BE File Offset: 0x000016BE
		public string SubType { get; set; }

		// Token: 0x1700001B RID: 27
		// (get) Token: 0x060000B3 RID: 179 RVA: 0x000034C7 File Offset: 0x000016C7
		// (set) Token: 0x060000B4 RID: 180 RVA: 0x000034CF File Offset: 0x000016CF
		public string ArchiveVersion { get; set; }

		// Token: 0x1700001C RID: 28
		// (get) Token: 0x060000B5 RID: 181 RVA: 0x000034D8 File Offset: 0x000016D8
		// (set) Token: 0x060000B6 RID: 182 RVA: 0x000034E0 File Offset: 0x000016E0
		public string CodeVersion { get; set; }

		// Token: 0x1700001D RID: 29
		// (get) Token: 0x060000B7 RID: 183 RVA: 0x000034E9 File Offset: 0x000016E9
		// (set) Token: 0x060000B8 RID: 184 RVA: 0x000034F1 File Offset: 0x000016F1
		public string GameVersion { get; set; }

		// Token: 0x1700001E RID: 30
		// (get) Token: 0x060000B9 RID: 185 RVA: 0x000034FA File Offset: 0x000016FA
		// (set) Token: 0x060000BA RID: 186 RVA: 0x00003502 File Offset: 0x00001702
		public string AssetVersion { get; set; }

		// Token: 0x1700001F RID: 31
		// (get) Token: 0x060000BB RID: 187 RVA: 0x0000350B File Offset: 0x0000170B
		// (set) Token: 0x060000BC RID: 188 RVA: 0x00003513 File Offset: 0x00001713
		public string PackageId { get; set; }

		// Token: 0x17000020 RID: 32
		// (get) Token: 0x060000BD RID: 189 RVA: 0x0000351C File Offset: 0x0000171C
		// (set) Token: 0x060000BE RID: 190 RVA: 0x00003524 File Offset: 0x00001724
		public string MinReqVersion { get; set; }

		// Token: 0x17000021 RID: 33
		// (get) Token: 0x060000BF RID: 191 RVA: 0x0000352D File Offset: 0x0000172D
		// (set) Token: 0x060000C0 RID: 192 RVA: 0x00003535 File Offset: 0x00001735
		public string DisplayName { get; set; }

		// Token: 0x17000022 RID: 34
		// (get) Token: 0x060000C1 RID: 193 RVA: 0x0000353E File Offset: 0x0000173E
		// (set) Token: 0x060000C2 RID: 194 RVA: 0x00003546 File Offset: 0x00001746
		public string Description { get; set; }

		// Token: 0x17000023 RID: 35
		// (get) Token: 0x060000C3 RID: 195 RVA: 0x0000354F File Offset: 0x0000174F
		// (set) Token: 0x060000C4 RID: 196 RVA: 0x00003557 File Offset: 0x00001757
		public List<string> Dependencies { get; set; }

		// Token: 0x17000024 RID: 36
		// (get) Token: 0x060000C5 RID: 197 RVA: 0x00003560 File Offset: 0x00001760
		// (set) Token: 0x060000C6 RID: 198 RVA: 0x00003568 File Offset: 0x00001768
		public List<LocalizedString> LocalizedNames { get; set; }

		// Token: 0x17000025 RID: 37
		// (get) Token: 0x060000C7 RID: 199 RVA: 0x00003571 File Offset: 0x00001771
		// (set) Token: 0x060000C8 RID: 200 RVA: 0x00003579 File Offset: 0x00001779
		public List<LocalizedString> LocalizedDescriptions { get; set; }

		// Token: 0x17000026 RID: 38
		// (get) Token: 0x060000C9 RID: 201 RVA: 0x00003582 File Offset: 0x00001782
		// (set) Token: 0x060000CA RID: 202 RVA: 0x0000358A File Offset: 0x0000178A
		public byte[] Data { get; set; }

		// Token: 0x17000027 RID: 39
		// (get) Token: 0x060000CB RID: 203 RVA: 0x00003593 File Offset: 0x00001793
		// (set) Token: 0x060000CC RID: 204 RVA: 0x0000359B File Offset: 0x0000179B
		public bool SkipSerialization { get; set; }

		// Token: 0x060000CD RID: 205 RVA: 0x0000EC88 File Offset: 0x0000CE88
		public Sims3Package()
		{
			this.Identifier = "TS3Pack";
			this.MajorVersion = 1;
			this.MinorVersion = 1;
			this.ArchiveVersion = "1.4";
			this.CodeVersion = "0.0.0.23";
			this.GameVersion = "0.0.0.0";
			this.AssetVersion = "1";
			this.MinReqVersion = "1.0.0.0";
			this.Dependencies = new List<string>();
			this.LocalizedNames = new List<LocalizedString>();
			this.LocalizedDescriptions = new List<LocalizedString>();
			this.packagedFiles = new List<object>();
			this.SkipSerialization = false;
		}

		// Token: 0x060000CE RID: 206 RVA: 0x0000ED20 File Offset: 0x0000CF20
		public Sims3Package(string fileName, bool onlyPng)
		{
			this.SkipSerialization = false;
			this.packagedFiles = new List<object>();
			if (!File.Exists(fileName))
			{
				throw new Exception("File '" + fileName + "' does not exist or cannot be read");
			}
			FileStream fileStream = new FileStream(fileName, FileMode.OpenOrCreate);
			BinaryReader binaryReader = new BinaryReader(fileStream);
			int length = binaryReader.ReadInt32();
			PackageUtil.ReadString(binaryReader, length);
			binaryReader.ReadByte();
			binaryReader.ReadByte();
			short length2 = binaryReader.ReadInt16();
			binaryReader.ReadInt16();
			string xml = PackageUtil.ReadString(binaryReader, (int)length2);
			XmlDocument xmlDocument = new XmlDocument();
			try
			{
				xmlDocument.LoadXml(xml);
				this.DisplayName = xmlDocument.SelectSingleNode("/Sims3Package/DisplayName").InnerText;
			}
			catch (Exception)
			{
				throw new Exception("Could not open Sims3Package. Invalid xmlHeader.");
			}
			long position = binaryReader.BaseStream.Position;
			foreach (object obj in xmlDocument.GetElementsByTagName("PackagedFile"))
			{
				XmlElement xmlElement = (XmlElement)obj;
				string innerText = xmlElement.GetElementsByTagName("Name").Item(0).InnerText;
				int count = int.Parse(xmlElement.GetElementsByTagName("Length").Item(0).InnerText);
				int num = int.Parse(xmlElement.GetElementsByTagName("Offset").Item(0).InnerText);
				binaryReader.BaseStream.Position = position + (long)num;
				byte[] data = binaryReader.ReadBytes(count);
				if (innerText.EndsWith(".png"))
				{
					PackagedFile packagedFile = PackagedFileFactory.CreateInstance(innerText, data, 3);
					if (packagedFile != null)
					{
						this.packagedFiles.Add(packagedFile);
					}
				}
			}
			binaryReader.Close();
			fileStream.Close();
		}

		// Token: 0x060000CF RID: 207 RVA: 0x0000EEF0 File Offset: 0x0000D0F0
		public Sims3Package(string fileName)
		{
			this.SkipSerialization = false;
			this.packagedFiles = new List<object>();
			if (!File.Exists(fileName))
			{
				throw new Exception("File '" + fileName + "' does not exist or cannot be read");
			}
			FileStream fileStream = new FileStream(fileName, FileMode.OpenOrCreate);
			BinaryReader binaryReader = new BinaryReader(fileStream);
			int length = binaryReader.ReadInt32();
			this.Identifier = PackageUtil.ReadString(binaryReader, length);
			this.MajorVersion = binaryReader.ReadByte();
			this.MinorVersion = binaryReader.ReadByte();
			int length2 = binaryReader.ReadInt32();
			string xml = PackageUtil.ReadString(binaryReader, length2);
			XmlDocument xmlDocument = new XmlDocument();
			try
			{
				xmlDocument.LoadXml(xml);
				this.Type = (xmlDocument.SelectSingleNode("/Sims3Package") as XmlElement).GetAttribute("Type");
				this.SubType = (xmlDocument.SelectSingleNode("/Sims3Package") as XmlElement).GetAttribute("SubType");
				this.ArchiveVersion = xmlDocument.SelectSingleNode("/Sims3Package/ArchiveVersion").InnerText;
				this.CodeVersion = xmlDocument.SelectSingleNode("/Sims3Package/CodeVersion").InnerText;
				this.GameVersion = xmlDocument.SelectSingleNode("/Sims3Package/GameVersion").InnerText;
				this.AssetVersion = xmlDocument.SelectSingleNode("/Sims3Package/AssetVersion").InnerText;
				this.MinReqVersion = xmlDocument.SelectSingleNode("/Sims3Package/MinReqVersion").InnerText;
				this.DisplayName = xmlDocument.SelectSingleNode("/Sims3Package/DisplayName").InnerText;
				XmlNode xmlNode = xmlDocument.SelectSingleNode("/Sims3Package/Description");
				this.Description = ((xmlNode != null) ? xmlNode.InnerText : "");
				XmlNode xmlNode2 = xmlDocument.SelectSingleNode("/Sims3Package/PackageId");
				if (xmlNode2 != null)
				{
					this.PackageId = xmlNode2.InnerText;
				}
				XmlNodeList xmlNodeList = xmlDocument.SelectNodes("/Sims3Package/Dependencies/Dependency");
				this.Dependencies = new List<string>();
				foreach (object obj in xmlNodeList)
				{
					XmlElement xmlElement = (XmlElement)obj;
					this.Dependencies.Add(xmlElement.InnerText);
				}
				XmlNodeList xmlNodeList2 = xmlDocument.SelectNodes("/Sims3Package/Dependencies/LocalizedNames");
				this.LocalizedNames = new List<LocalizedString>();
				foreach (object obj2 in xmlNodeList2)
				{
					XmlElement xmlElement2 = (XmlElement)obj2;
					this.LocalizedNames.Add(new LocalizedString(xmlElement2.InnerText));
				}
				xmlDocument.SelectNodes("/Sims3Package/Dependencies/LocalizedDescriptions");
				this.LocalizedDescriptions = new List<LocalizedString>();
				foreach (object obj3 in xmlNodeList2)
				{
					XmlElement xmlElement3 = (XmlElement)obj3;
					this.LocalizedDescriptions.Add(new LocalizedString(xmlElement3.InnerText));
				}
			}
			catch (Exception)
			{
				throw new Exception("Could not open Sims3Package. Invalid xmlHeader.");
			}
			long position = binaryReader.BaseStream.Position;
			foreach (object obj4 in xmlDocument.GetElementsByTagName("PackagedFile"))
			{
				XmlElement xmlElement4 = (XmlElement)obj4;
				string innerText = xmlElement4.GetElementsByTagName("Name").Item(0).InnerText;
				int count = int.Parse(xmlElement4.GetElementsByTagName("Length").Item(0).InnerText);
				int num = int.Parse(xmlElement4.GetElementsByTagName("Offset").Item(0).InnerText);
				binaryReader.BaseStream.Position = position + (long)num;
				byte[] array = binaryReader.ReadBytes(count);
				try
				{
					PackagedFile packagedFile = PackagedFileFactory.CreateInstance(innerText, array, 3);
					if (packagedFile is DBPF)
					{
						DBPF dbpf = packagedFile as DBPF;
						dbpf.Name = xmlElement4.GetElementsByTagName("Name").Item(0).InnerText;
						dbpf.Guid = xmlElement4.GetElementsByTagName("Guid").Item(0).InnerText;
						dbpf.ContentType = xmlElement4.GetElementsByTagName("ContentType").Item(0).InnerText;
					}
					else
					{
						FileStream fileStream2 = new FileStream(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\" + innerText, FileMode.Create);
						fileStream2.Write(array, 0, array.Length);
						fileStream2.Close();
					}
					if (packagedFile != null)
					{
						this.packagedFiles.Add(packagedFile);
					}
				}
				catch (Exception ex)
				{
					Console.WriteLine(ex.ToString());
				}
			}
			binaryReader.Close();
			fileStream.Close();
		}

		// Token: 0x17000028 RID: 40
		// (get) Token: 0x060000D0 RID: 208 RVA: 0x000035A4 File Offset: 0x000017A4
		public List<object> PackagedFiles
		{
			get
			{
				return this.packagedFiles;
			}
		}

		// Token: 0x060000D1 RID: 209 RVA: 0x000035AC File Offset: 0x000017AC
		public void AddFile(PackagedFile file, bool first)
		{
			if (first)
			{
				this.packagedFiles.Insert(0, file);
				return;
			}
			this.packagedFiles.Add(file);
		}

		// Token: 0x060000D2 RID: 210 RVA: 0x000035CB File Offset: 0x000017CB
		public void AddFile(PackagedFile file)
		{
			this.packagedFiles.Add(file);
		}

		// Token: 0x060000D3 RID: 211 RVA: 0x0000F408 File Offset: 0x0000D608
		public int ReplaceAllReferences(ResKey from, ResKey to)
		{
			int num = 0;
			foreach (object obj in this.packagedFiles)
			{
				if (obj is DBPF)
				{
					num += ((DBPF)obj).ReplaceAllReferences(from, to);
				}
			}
			return num;
		}

		// Token: 0x060000D4 RID: 212 RVA: 0x000035D9 File Offset: 0x000017D9
		public void SaveToFile(string filename)
		{
			Stream stream = new MemoryStream();
			this.Serialize(null);
			FileStream fileStream = new FileStream(filename, FileMode.Create);
			fileStream.Write(this.Data, 0, this.Data.Length);
			fileStream.Dispose();
			stream.Dispose();
		}

		// Token: 0x060000D5 RID: 213 RVA: 0x0000F470 File Offset: 0x0000D670
		public void Serialize(DBPF.ProgressDelegate progressDelegate)
		{
			MemoryStream memoryStream = new MemoryStream();
			this.SaveToStream(memoryStream, progressDelegate);
			this.Data = memoryStream.ToArray();
		}

		// Token: 0x060000D6 RID: 214 RVA: 0x0000F498 File Offset: 0x0000D698
		public void SaveToStream(Stream outStream, DBPF.ProgressDelegate progressDelegate)
		{
			BinaryWriter binaryWriter = new BinaryWriter(outStream);
			binaryWriter.Write(this.Identifier.Length);
			binaryWriter.Write(this.Identifier.ToCharArray());
			binaryWriter.Write(this.MajorVersion);
			binaryWriter.Write(this.MinorVersion);
			XmlDocument xmlDocument = new XmlDocument();
			XmlDeclaration newChild = xmlDocument.CreateXmlDeclaration("1.0", "utf-8", "");
			xmlDocument.AppendChild(newChild);
			XmlElement xmlElement = xmlDocument.CreateElement("Sims3Package");
			xmlElement.Attributes.Append(XML.CreateAttribute(xmlDocument, "Type", this.Type));
			xmlElement.Attributes.Append(XML.CreateAttribute(xmlDocument, "SubType", this.SubType));
			xmlElement.AppendChild(XML.CreateValueNode(xmlDocument, "ArchiveVersion", this.ArchiveVersion));
			xmlElement.AppendChild(XML.CreateValueNode(xmlDocument, "CodeVersion", this.CodeVersion));
			xmlElement.AppendChild(XML.CreateValueNode(xmlDocument, "GameVersion", this.GameVersion));
			if (this.PackageId != null)
			{
				xmlElement.AppendChild(XML.CreateValueNode(xmlDocument, "PackageId", this.PackageId));
			}
			xmlElement.AppendChild(XML.CreateValueNode(xmlDocument, "AssetVersion", this.AssetVersion));
			xmlElement.AppendChild(XML.CreateValueNode(xmlDocument, "MinReqVersion", this.MinReqVersion));
			xmlElement.AppendChild(XML.CreateValueNode(xmlDocument, "DisplayName", this.DisplayName));
			xmlElement.AppendChild(XML.CreateValueNode(xmlDocument, "Description", this.Description));
			XmlElement xmlElement2 = xmlDocument.CreateElement("Dependencies");
			foreach (string value in this.Dependencies)
			{
				xmlElement2.AppendChild(XML.CreateValueNode(xmlDocument, "Dependency", value));
			}
			xmlElement.AppendChild(xmlElement2);
			if (this.LocalizedNames.Count == STBL.Locales.Count)
			{
				XmlElement xmlElement3 = xmlDocument.CreateElement("LocalizedNames");
				foreach (LocalizedString localizedString in this.LocalizedNames)
				{
					XmlNode xmlNode = XML.CreateCdataValueNode(xmlDocument, "LocalizedName", localizedString.Text);
					xmlNode.Attributes.Append(XML.CreateAttribute(xmlDocument, "Language", localizedString.Lang));
					xmlElement3.AppendChild(xmlNode);
				}
				xmlElement.AppendChild(xmlElement3);
			}
			if (this.LocalizedDescriptions.Count == STBL.Locales.Count)
			{
				XmlElement xmlElement4 = xmlDocument.CreateElement("LocalizedDescriptions");
				foreach (LocalizedString localizedString2 in this.LocalizedDescriptions)
				{
					XmlNode xmlNode2 = XML.CreateCdataValueNode(xmlDocument, "LocalizedName", localizedString2.Text);
					xmlNode2.Attributes.Append(XML.CreateAttribute(xmlDocument, "Language", localizedString2.Lang));
					xmlElement4.AppendChild(xmlNode2);
				}
				xmlElement.AppendChild(xmlElement4);
			}
			long num = 0L;
			foreach (object obj in this.packagedFiles)
			{
				PackagedFile packagedFile = (PackagedFile)obj;
				if (!this.SkipSerialization)
				{
					if (packagedFile is DBPF)
					{
						(packagedFile as DBPF).Serialize(true, progressDelegate, false);
					}
					else
					{
						packagedFile.Serialize(true);
					}
				}
				XmlElement xmlElement5 = xmlDocument.CreateElement("PackagedFile");
				xmlElement5.AppendChild(XML.CreateValueNode(xmlDocument, "Name", packagedFile.GetName()));
				xmlElement5.AppendChild(XML.CreateValueNode(xmlDocument, "Length", packagedFile.GetLenght().ToString() ?? ""));
				xmlElement5.AppendChild(XML.CreateValueNode(xmlDocument, "Offset", num.ToString() ?? ""));
				xmlElement5.AppendChild(XML.CreateValueNode(xmlDocument, "Crc", packagedFile.GetCrc() ?? ""));
				xmlElement5.AppendChild(XML.CreateValueNode(xmlDocument, "Guid", packagedFile.GetGuid()));
				xmlElement5.AppendChild(XML.CreateValueNode(xmlDocument, "ContentType", packagedFile.GetContentType()));
				XmlElement xmlElement6 = xmlDocument.CreateElement("MetaTags");
				foreach (object obj2 in packagedFile.GetMetaTags())
				{
					DictionaryEntry dictionaryEntry = (DictionaryEntry)obj2;
					xmlElement6.AppendChild(XML.CreateValueNode(xmlDocument, (string)dictionaryEntry.Key, Convert.ToString(dictionaryEntry.Value)));
				}
				xmlElement5.AppendChild(xmlElement6);
				xmlElement.AppendChild(xmlElement5);
				num += packagedFile.GetLenght();
			}
			xmlDocument.AppendChild(xmlElement);
			UTF8Encoding encoding = new UTF8Encoding(false);
			MemoryStream memoryStream = new MemoryStream();
			XmlTextWriter xmlTextWriter = new XmlTextWriter(memoryStream, encoding);
			xmlTextWriter.Flush();
			xmlDocument.WriteTo(xmlTextWriter);
			xmlTextWriter.Flush();
			binaryWriter.Write((short)memoryStream.Length);
			binaryWriter.Write(0);
			binaryWriter.Write(memoryStream.GetBuffer(), 0, (int)memoryStream.Length);
			memoryStream.Dispose();
			foreach (object obj3 in this.packagedFiles)
			{
				PackagedFile packagedFile2 = (PackagedFile)obj3;
				binaryWriter.Write(packagedFile2.GetData());
			}
			binaryWriter.Close();
		}

		// Token: 0x060000D7 RID: 215 RVA: 0x0000FACC File Offset: 0x0000DCCC
		public void Dispose()
		{
			foreach (object obj in this.packagedFiles)
			{
				if (obj is DBPF)
				{
					(obj as DBPF).Dispose();
				}
			}
		}

		// Token: 0x0400004D RID: 77
		private List<object> packagedFiles;
	}
}
