using System;

namespace Sims3WorkshopSDK.Interfaces
{
	// Token: 0x02000036 RID: 54
	public interface IWorkshopExtension
	{
		// Token: 0x17000030 RID: 48
		// (get) Token: 0x060000F0 RID: 240
		string Name { get; }

		// Token: 0x060000F1 RID: 241
		PluginResult Initialize();

		// Token: 0x060000F2 RID: 242
		PluginResult Close();

		// Token: 0x17000031 RID: 49
		// (get) Token: 0x060000F3 RID: 243
		IWorkshop Workshop { get; }
	}
}
