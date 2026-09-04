using System;

namespace Sims3WorkshopSDK.Interfaces
{
	// Token: 0x02000032 RID: 50
	public interface IRIGEditor
	{
		// Token: 0x060000D6 RID: 214
		void UpdateRIGFromGranny2Info(IDBPFEntry rig, IRIG info);

		// Token: 0x060000D7 RID: 215
		void GetGranny2Info(IGamedata gameDataUtil, ResKey key, IRIG info);

		// Token: 0x1700002D RID: 45
		// (get) Token: 0x060000D8 RID: 216
		// (set) Token: 0x060000D9 RID: 217
		bool CanHandleEncrypted { get; set; }
	}
}
