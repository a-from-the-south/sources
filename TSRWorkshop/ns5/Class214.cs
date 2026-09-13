using System;
using System.Xml;

namespace ns5
{
	// Token: 0x020001E8 RID: 488
	internal sealed class Class214 : IDisposable
	{
		// Token: 0x0600139D RID: 5021 RVA: 0x0000A54F File Offset: 0x0000874F
		public Class214(XmlWriter xmlWriter, string name)
		{
			this.xmlWriter = xmlWriter;
			this.xmlWriter.WriteStartElement(name);
		}

		// Token: 0x0600139E RID: 5022 RVA: 0x0000A56A File Offset: 0x0000876A
		public void Dispose()
		{
			this.xmlWriter.WriteEndElement();
		}

		// Token: 0x04000DE1 RID: 3553
		private readonly XmlWriter xmlWriter;
	}
}
