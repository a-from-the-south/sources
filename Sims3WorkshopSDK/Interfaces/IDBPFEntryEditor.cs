using System;
using System.Collections.Generic;

namespace Sims3WorkshopSDK.Interfaces
{
	// Token: 0x02000017 RID: 23
	public interface IDBPFEntryEditor
	{
		// Token: 0x1700001B RID: 27
		// (get) Token: 0x06000084 RID: 132
		List<DBPFType> SupportedTypes { get; }

		// Token: 0x06000085 RID: 133
		PluginResult OpenEditor(IDBPFEntry file);
	}
}
