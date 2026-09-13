using System;
using System.Xml;
using Package.Sims3Files;
using SlimDX.Direct3D9;

namespace ns8
{
	// Token: 0x0200011B RID: 283
	internal sealed class Class130
	{
		// Token: 0x06000CCC RID: 3276 RVA: 0x0009F92C File Offset: 0x0009DB2C
		public static Texture smethod_0(Preset preset_0)
		{
			XmlDocument xmlDocument = preset_0.Documents[0];
			if ((xmlDocument.GetElementsByTagName("complate").Item(0) as XmlElement).GetAttribute("name").Equals("ObjectRgbMask"))
			{
				XmlElement xmlElement = xmlDocument.GetElementsByTagName("texturePart").Item(0) as XmlElement;
				XmlNodeList elementsByTagName = xmlElement.GetElementsByTagName("step");
				foreach (object obj in elementsByTagName)
				{
					XmlElement xmlElement2 = (XmlElement)obj;
				}
			}
			return null;
		}
	}
}
