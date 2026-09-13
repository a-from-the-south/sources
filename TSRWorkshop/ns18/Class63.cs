using System;
using System.Drawing;
using System.Xml;
using ns16;
using ns8;
using Sims3WorkshopSDK;
using SlimDX.Direct3D9;
using VisualHint.SmartPropertyGrid;

namespace ns18
{
	// Token: 0x02000094 RID: 148
	internal sealed class Class63 : Class61
	{
		// Token: 0x060005DD RID: 1501 RVA: 0x00004F9B File Offset: 0x0000319B
		public Class63()
		{
			this.bool_3 = false;
			this.bool_1 = false;
			this.bool_2 = false;
		}

		// Token: 0x060005DE RID: 1502 RVA: 0x00004FBA File Offset: 0x000031BA
		public Class63(bool hideValue)
		{
			this.bool_3 = false;
			this.bool_1 = false;
		}

		// Token: 0x060005DF RID: 1503 RVA: 0x0005C604 File Offset: 0x0005A804
		protected override void vmethod_0(PropertyEnumerator propertyEnumerator_0, string string_0)
		{
			PatternResKey patternResKey = null;
			try
			{
				if (!propertyEnumerator_0.Property.Value.HasMultipleTexts())
				{
					patternResKey = (PatternResKey)base.Value.ConvertDisplayedStringToValue(string_0);
				}
			}
			catch (Exception)
			{
				patternResKey = (PatternResKey)base.Value.GetValue();
			}
			if (patternResKey != this.patternResKey_0 || this.bitmap_0 == null || this.bool_4)
			{
				this.bool_4 = false;
				if (patternResKey != null)
				{
					XmlAttribute xmlAttribute = ((XmlAttribute)base.Value.Tag).OwnerElement.Attributes["key"];
					XmlNode xmlNode = ((XmlAttribute)base.Value.Tag).OwnerDocument.SelectSingleNode("/preset/complate/pattern[@variable='" + xmlAttribute.Value + "']");
					Texture texture = Class132.smethod_0().method_4(new Size(64, 64));
					Interface3 @interface = Class132.smethod_0().method_8(new Size(64, 64));
					Class132.smethod_0().method_9(ref this.bitmap_0, @interface, texture, patternResKey.AsString(), new Size(64, 64), (XmlElement)xmlNode, null, "DiffuseMap", "($partType)");
					texture.Dispose();
					@interface.imethod_2(true);
				}
				this.patternResKey_0 = patternResKey;
			}
			this.bool_0 = false;
		}

		// Token: 0x060005E0 RID: 1504 RVA: 0x00004FD2 File Offset: 0x000031D2
		public override void ControlHeightMultiplier()
		{
			base.Value.OwnerEnumerator.Property.HeightMultiplier = 4;
		}

		// Token: 0x0400053D RID: 1341
		private PatternResKey patternResKey_0;
	}
}
