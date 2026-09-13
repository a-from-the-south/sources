using System;
using System.Runtime.CompilerServices;
using System.Xml;
using Package.Sims3Files;

namespace ns7
{
	// Token: 0x020000B6 RID: 182
	internal sealed class Class81
	{
		// Token: 0x1700013C RID: 316
		// (get) Token: 0x06000785 RID: 1925 RVA: 0x00071DE8 File Offset: 0x0006FFE8
		// (set) Token: 0x06000786 RID: 1926 RVA: 0x00005765 File Offset: 0x00003965
		public object Data { get; set; }

		// Token: 0x1700013D RID: 317
		// (get) Token: 0x06000787 RID: 1927 RVA: 0x00071E00 File Offset: 0x00070000
		// (set) Token: 0x06000788 RID: 1928 RVA: 0x00005770 File Offset: 0x00003970
		public bool IsProp { get; set; }

		// Token: 0x06000789 RID: 1929 RVA: 0x0000577B File Offset: 0x0000397B
		public Class81(object data, bool isProp)
		{
			this.Data = data;
			this.IsProp = isProp;
		}

		// Token: 0x0600078A RID: 1930 RVA: 0x00071E18 File Offset: 0x00070018
		public string ToString()
		{
			string result;
			if (this.Data != null && this.Data.GetType().Equals(typeof(XmlDocument)))
			{
				XmlNode xmlNode = (this.Data as XmlDocument).SelectSingleNode("/preset/complate/value[@key='daeFileName']");
				XmlNode xmlNode2 = (xmlNode == null) ? null : xmlNode.Attributes.GetNamedItem("value");
				if (xmlNode2 != null)
				{
					result = xmlNode2.InnerText;
				}
				else
				{
					result = "unknown";
				}
			}
			else if (this.Data != null && this.Data.GetType().Equals(typeof(TXTC)))
			{
				result = "default properties - non recolorable";
			}
			else
			{
				result = "unknown type";
			}
			return result;
		}

		// Token: 0x04000647 RID: 1607
		[CompilerGenerated]
		private object object_0;

		// Token: 0x04000648 RID: 1608
		[CompilerGenerated]
		private bool bool_0;
	}
}
