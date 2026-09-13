using System;
using System.Collections.Generic;

namespace Sims3Workshop.Preferences
{
	// Token: 0x02000134 RID: 308
	[Serializable]
	public sealed class PluginDirectory
	{
		// Token: 0x06000E4E RID: 3662 RVA: 0x000B40B8 File Offset: 0x000B22B8
		public bool method_0(string string_0)
		{
			bool result;
			foreach (PluginDirectoryEntry pluginDirectoryEntry in this.entries)
			{
				if (pluginDirectoryEntry.name.Equals(string_0))
				{
					result = true;
					goto IL_46;
				}
			}
			return false;
			IL_46:
			return result;
		}

		// Token: 0x06000E4F RID: 3663 RVA: 0x000B4120 File Offset: 0x000B2320
		public PluginDirectoryEntry method_1(string string_0)
		{
			PluginDirectoryEntry pluginDirectoryEntry = new PluginDirectoryEntry();
			pluginDirectoryEntry.name = string_0;
			pluginDirectoryEntry.enabled = true;
			this.entries.Add(pluginDirectoryEntry);
			return pluginDirectoryEntry;
		}

		// Token: 0x06000E50 RID: 3664 RVA: 0x000B4154 File Offset: 0x000B2354
		public PluginDirectoryEntry method_2(string string_0)
		{
			PluginDirectoryEntry result;
			foreach (PluginDirectoryEntry pluginDirectoryEntry in this.entries)
			{
				if (pluginDirectoryEntry.name.Equals(string_0))
				{
					result = pluginDirectoryEntry;
					goto IL_46;
				}
			}
			return null;
			IL_46:
			return result;
		}

		// Token: 0x04000B03 RID: 2819
		public List<PluginDirectoryEntry> entries;
	}
}
