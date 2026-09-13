using System;
using System.Drawing;
using System.Xml;
using ns16;
using ns8;
using Package.Sims3Files;
using Sims3WorkshopSDK;
using SlimDX.Direct3D9;
using VisualHint.SmartPropertyGrid;

namespace ns14
{
	// Token: 0x02000093 RID: 147
	internal sealed class Class62 : Class61
	{
		// Token: 0x060005D9 RID: 1497 RVA: 0x00004F9B File Offset: 0x0000319B
		public Class62()
		{
			this.bool_3 = false;
			this.bool_1 = false;
			this.bool_2 = false;
		}

		// Token: 0x060005DA RID: 1498 RVA: 0x00004FBA File Offset: 0x000031BA
		public Class62(bool hideValue)
		{
			this.bool_3 = false;
			this.bool_1 = false;
		}

		// Token: 0x060005DB RID: 1499 RVA: 0x0005C4F0 File Offset: 0x0005A6F0
		protected override void vmethod_0(PropertyEnumerator propertyEnumerator_0, string string_0)
		{
			PropResKey propResKey = null;
			try
			{
				if (!propertyEnumerator_0.Property.Value.HasMultipleTexts())
				{
					propResKey = (PropResKey)base.Value.ConvertDisplayedStringToValue(string_0);
				}
			}
			catch (Exception)
			{
				propResKey = (PropResKey)base.Value.GetValue();
			}
			if (propResKey != this.propResKey_0 || this.bitmap_0 == null || this.bool_4)
			{
				this.bool_4 = false;
				if (propResKey != null)
				{
					TXTC txtc = Class76.smethod_26(propResKey) as TXTC;
					if (txtc == null)
					{
						return;
					}
					this.xmlDocument_0 = txtc.ToPreset();
					Texture texture = Class132.smethod_0().method_4(new Size(64, 64));
					Interface3 @interface = Class132.smethod_0().method_8(new Size(64, 64));
					this.bitmap_0 = (Class132.smethod_0().method_12(this.xmlDocument_0, new Size(64, 64), "DiffuseMap", "") as Bitmap);
					texture.Dispose();
					@interface.imethod_2(true);
				}
				this.propResKey_0 = propResKey;
			}
			this.bool_0 = false;
		}

		// Token: 0x060005DC RID: 1500 RVA: 0x00004FD2 File Offset: 0x000031D2
		public override void ControlHeightMultiplier()
		{
			base.Value.OwnerEnumerator.Property.HeightMultiplier = 4;
		}

		// Token: 0x0400053B RID: 1339
		private PropResKey propResKey_0;

		// Token: 0x0400053C RID: 1340
		private XmlDocument xmlDocument_0;
	}
}
