using System;

namespace Sims3WorkshopSDK.Interfaces
{
	// Token: 0x02000033 RID: 51
	public interface IToolPlugin
	{
		// Token: 0x1700002E RID: 46
		// (get) Token: 0x060000DA RID: 218
		string MenuItemText { get; }

		// Token: 0x1700002F RID: 47
		// (get) Token: 0x060000DB RID: 219
		bool RequiresProject { get; }

		// Token: 0x060000DC RID: 220
		void Open();
	}
}
