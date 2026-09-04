using System;

namespace Sims3WorkshopSDK.Interfaces
{
	// Token: 0x0200001E RID: 30
	public interface IImportPlugin
	{
		// Token: 0x17000021 RID: 33
		// (get) Token: 0x06000098 RID: 152
		ImportLocation Location { get; }

		// Token: 0x17000022 RID: 34
		// (get) Token: 0x06000099 RID: 153
		string MenuItemText { get; }

		// Token: 0x0600009A RID: 154
		void Import();

		// Token: 0x0600009B RID: 155
		void SetDefaultFile(string file);
	}
}
