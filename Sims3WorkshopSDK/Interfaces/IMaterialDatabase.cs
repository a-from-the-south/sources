using System;

namespace Sims3WorkshopSDK.Interfaces
{
	// Token: 0x02000021 RID: 33
	public interface IMaterialDatabase
	{
		// Token: 0x0600009E RID: 158
		MaterialResult AddMaterial(string name);

		// Token: 0x0600009F RID: 159
		IMaterial GetMaterial(string name);
	}
}
