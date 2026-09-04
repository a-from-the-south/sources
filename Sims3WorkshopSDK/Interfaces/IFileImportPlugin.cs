using System;
using System.Collections.Generic;

namespace Sims3WorkshopSDK.Interfaces
{
	// Token: 0x0200001B RID: 27
	public interface IFileImportPlugin
	{
		// Token: 0x17000020 RID: 32
		// (get) Token: 0x0600008F RID: 143
		List<DBPFType> SupportedTypes { get; }

		// Token: 0x06000090 RID: 144
		string GetExtensionNameForType(DBPFType type);

		// Token: 0x06000091 RID: 145
		string GetExtensionForType(DBPFType type);

		// Token: 0x06000092 RID: 146
		PluginResult Import(DBPFType type, string fileName, IDBPFEntry file, ImportArgument[] args);
	}
}
