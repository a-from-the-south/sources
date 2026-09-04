using System;
using System.Collections.Generic;

namespace Sims3WorkshopSDK.Interfaces
{
	// Token: 0x02000016 RID: 22
	public interface IDBPFEntry
	{
		// Token: 0x0600007D RID: 125
		byte[] GetData();

		// Token: 0x0600007E RID: 126
		void SetData(byte[] data);

		// Token: 0x1700001A RID: 26
		// (get) Token: 0x0600007F RID: 127
		// (set) Token: 0x06000080 RID: 128
		ResKey ResKey { get; set; }

		// Token: 0x06000081 RID: 129
		DBPFType GetTypeID();

		// Token: 0x06000082 RID: 130
		int ReplaceReferences(ResKey from, ResKey to);

		// Token: 0x06000083 RID: 131
		List<ResKey> GetAllReferences();
	}
}
