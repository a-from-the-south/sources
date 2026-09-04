using System;

namespace Package.Sims3Files
{
	// Token: 0x0200003A RID: 58
	public class ObjXML : XML
	{
		// Token: 0x06000321 RID: 801 RVA: 0x0000481F File Offset: 0x00002A1F
		public ObjXML()
		{
			this.typeId = 62078431U;
		}

		// Token: 0x06000322 RID: 802 RVA: 0x00004832 File Offset: 0x00002A32
		public override void SaveToFile(string fileName)
		{
			base.SaveToFile(fileName);
		}

		// Token: 0x06000323 RID: 803 RVA: 0x0000483B File Offset: 0x00002A3B
		public override string ToString()
		{
			return "OBJXML | " + base.ToString();
		}
	}
}
