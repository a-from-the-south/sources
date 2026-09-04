using System;
using System.Collections.Generic;

namespace Sims3WorkshopSDK.Interfaces
{
	// Token: 0x02000031 RID: 49
	public interface IProjectModel
	{
		// Token: 0x060000C2 RID: 194
		void Unload();

		// Token: 0x060000C3 RID: 195
		object ExportPackage();

		// Token: 0x060000C4 RID: 196
		void ImportPackage(object package);

		// Token: 0x060000C5 RID: 197
		object ExportSims3Pack();

		// Token: 0x060000C6 RID: 198
		object GetThumbnail();

		// Token: 0x060000C7 RID: 199
		string GetTitle();

		// Token: 0x060000C8 RID: 200
		string GetDescription();

		// Token: 0x060000C9 RID: 201
		void LodChanged(Lod lod);

		// Token: 0x060000CA RID: 202
		List<Lod> GetLodLevels();

		// Token: 0x060000CB RID: 203
		bool HasSlots();

		// Token: 0x060000CC RID: 204
		bool HasShadows();

		// Token: 0x060000CD RID: 205
		bool HasBumpMap();

		// Token: 0x060000CE RID: 206
		bool HasRig();

		// Token: 0x060000CF RID: 207
		void SetSlotsVisible(bool value);

		// Token: 0x060000D0 RID: 208
		void SetRigVisible(bool value);

		// Token: 0x060000D1 RID: 209
		object GetRenderable();

		// Token: 0x060000D2 RID: 210
		IWorkshopProject GetCurrentProject();

		// Token: 0x060000D3 RID: 211
		List<object> GetModels();

		// Token: 0x060000D4 RID: 212
		List<object> GetGameObjects();

		// Token: 0x060000D5 RID: 213
		object GetCurrentGameObject();
	}
}
