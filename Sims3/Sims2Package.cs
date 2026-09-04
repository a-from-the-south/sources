using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;

namespace Package
{
	// Token: 0x02000004 RID: 4
	public class Sims2Package
	{
		// Token: 0x06000008 RID: 8 RVA: 0x0000BD84 File Offset: 0x00009F84
		public Sims2Package(string fileName)
		{
			this.packagedFiles = new List<object>();
			FileStream fileStream = new FileStream(fileName, FileMode.OpenOrCreate);
			BinaryReader binaryReader = new BinaryReader(fileStream);
			PackageUtil.ReadString(binaryReader, 18);
			int length = binaryReader.ReadInt32() - 22;
			string xml = PackageUtil.ReadString(binaryReader, length);
			XmlDocument xmlDocument = new XmlDocument();
			try
			{
				xmlDocument.LoadXml(xml);
			}
			catch (Exception)
			{
				throw new Exception("Could not open Sims2Package. Invalid xmlHeader.");
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
				PackagedFile packagedFile = PackagedFileFactory.CreateInstance(innerText, data, 2);
				if (packagedFile != null)
				{
					this.packagedFiles.Add(packagedFile);
				}
			}
			binaryReader.Close();
			fileStream.Close();
		}

		// Token: 0x17000001 RID: 1
		// (get) Token: 0x06000009 RID: 9 RVA: 0x00002F47 File Offset: 0x00001147
		public object[] PackagedFiles
		{
			get
			{
				return this.packagedFiles.ToArray();
			}
		}

		// Token: 0x04000004 RID: 4
		private List<object> packagedFiles;
	}
}
