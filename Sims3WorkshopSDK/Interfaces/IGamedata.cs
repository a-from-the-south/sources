using System;
using System.Collections.Generic;

namespace Sims3WorkshopSDK.Interfaces
{
	// Token: 0x0200001C RID: 28
	public interface IGamedata
	{
		// Token: 0x06000093 RID: 147
		ResKey FindResource(ResKey search);

		// Token: 0x06000094 RID: 148
		List<ResKey> FindResources(ResKey search);

		// Token: 0x06000095 RID: 149
		List<ResKey> FindResources(ResKey search, int limit, bool exact);

		// Token: 0x06000096 RID: 150
		List<object> GetResources(ResKey search);

		// Token: 0x06000097 RID: 151
		object GetResource(ResKey key);
	}
}
