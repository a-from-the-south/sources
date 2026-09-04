using System;

namespace Package.Sims3Files
{
	// Token: 0x0200003C RID: 60
	public class PatternList : XML
	{
		// Token: 0x06000347 RID: 839 RVA: 0x00004996 File Offset: 0x00002B96
		public PatternList()
		{
			this.typeId = 3571055589U;
		}

		// Token: 0x06000348 RID: 840 RVA: 0x000049A9 File Offset: 0x00002BA9
		public override string ToString()
		{
			return "PLIST | " + base.ToString();
		}
	}
}
