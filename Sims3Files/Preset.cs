using System;

namespace Package.Sims3Files
{
	// Token: 0x0200003D RID: 61
	public class Preset : XML
	{
		// Token: 0x06000349 RID: 841 RVA: 0x000049BB File Offset: 0x00002BBB
		public Preset()
		{
			this.typeId = 53690476U;
		}

		// Token: 0x0600034A RID: 842 RVA: 0x00004832 File Offset: 0x00002A32
		public override void SaveToFile(string fileName)
		{
			base.SaveToFile(fileName);
		}

		// Token: 0x0600034B RID: 843 RVA: 0x000049CE File Offset: 0x00002BCE
		public override string ToString()
		{
			return "PRESET | " + base.ToString();
		}
	}
}
