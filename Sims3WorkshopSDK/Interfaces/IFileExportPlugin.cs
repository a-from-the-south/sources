using System;
using System.Collections.Generic;

namespace Sims3WorkshopSDK.Interfaces
{
	// Token: 0x02000025 RID: 37
	public interface IFileExportPlugin
	{
		// Token: 0x17000025 RID: 37
		// (get) Token: 0x060000A6 RID: 166
		List<DBPFType> SupportedTypes { get; }

		// Token: 0x060000A7 RID: 167
		string GetExtensionNameForType(DBPFType type);

		// Token: 0x060000A8 RID: 168
		string GetExtensionForType(DBPFType type);

		// Token: 0x060000A9 RID: 169
		PluginResult Export(DBPFType type, string fileName, IDBPFEntry file, ExportArgument[] args);
	}
}
