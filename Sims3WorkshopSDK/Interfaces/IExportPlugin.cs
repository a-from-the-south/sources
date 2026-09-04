using System;

namespace Sims3WorkshopSDK.Interfaces
{
	// Token: 0x02000019 RID: 25
	public interface IExportPlugin
	{
		// Token: 0x1700001C RID: 28
		// (get) Token: 0x06000086 RID: 134
		ExportLocation Location { get; }

		// Token: 0x1700001D RID: 29
		// (get) Token: 0x06000087 RID: 135
		string MenuItemText { get; }

		// Token: 0x06000088 RID: 136
		bool IsValidForGame(GameVersion game);

		// Token: 0x06000089 RID: 137
		void Export();
	}
}
