using System;

namespace Sims3Workshop.Preferences
{
	// Token: 0x02000135 RID: 309
	[Serializable]
	public sealed class PluginDirectoryEntry
	{
		// Token: 0x06000E52 RID: 3666 RVA: 0x000B41BC File Offset: 0x000B23BC
		public string ToString()
		{
			return this.name;
		}

		// Token: 0x04000B04 RID: 2820
		public string name;

		// Token: 0x04000B05 RID: 2821
		public bool enabled;

		// Token: 0x04000B06 RID: 2822
		public string version;

		// Token: 0x04000B07 RID: 2823
		[NonSerialized]
		public bool bool_0;
	}
}
