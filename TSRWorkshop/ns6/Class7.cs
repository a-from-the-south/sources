using System;
using System.Collections.Generic;
using System.Xml;
using ns16;
using ns3;
using Package.Sims3Files;
using Sims3WorkshopSDK;
using VisualHint.SmartPropertyGrid;

namespace ns6
{
	// Token: 0x0200006B RID: 107
	internal sealed class Class7 : Class2
	{
		// Token: 0x170000A4 RID: 164
		// (get) Token: 0x06000420 RID: 1056 RVA: 0x000480C0 File Offset: 0x000462C0
		// (set) Token: 0x06000421 RID: 1057 RVA: 0x000043ED File Offset: 0x000025ED
		public XmlNode PatternNode
		{
			get
			{
				return this.patternNode;
			}
			set
			{
				this.patternNode = value;
				if (this.patternNode != null)
				{
					this.method_10();
				}
			}
		}

		// Token: 0x06000422 RID: 1058 RVA: 0x00004406 File Offset: 0x00002606
		public Class7()
		{
			base.AdvancedMode = true;
			base.OnPresetChanged += this.method_9;
		}

		// Token: 0x06000423 RID: 1059 RVA: 0x00004429 File Offset: 0x00002629
		private void method_9(object object_0, Class48 class48_0)
		{
			this.method_10();
		}

		// Token: 0x06000424 RID: 1060 RVA: 0x00004433 File Offset: 0x00002633
		public Class7(XmlNode patternNode)
		{
			this.patternNode = patternNode;
			this.method_10();
		}

		// Token: 0x06000425 RID: 1061 RVA: 0x000480D8 File Offset: 0x000462D8
		private void method_10()
		{
			base.Clear();
			PropertyEnumerator value = base.AppendRootCategory(this.int_0++, "Base properties");
			string value2 = this.patternNode.Attributes["reskey"].Value;
			XML xml = (XML)Class76.smethod_26(new ResKey(value2));
			XmlDocument xmlDocument = xml.Documents[0];
			XmlNodeList xmlNodeList = xmlDocument.SelectNodes("/complate/variables/param");
			Dictionary<string, PropertyEnumerator> dictionary_ = new Dictionary<string, PropertyEnumerator>
			{
				{
					"default",
					value
				}
			};
			if (xmlNodeList != null)
			{
				for (int i = 0; i < xmlNodeList.Count; i++)
				{
					base.method_8(xmlNodeList[i], null, 0, dictionary_, this.patternNode);
				}
			}
		}

		// Token: 0x040003FB RID: 1019
		private XmlNode patternNode;
	}
}
