using System;
using System.Windows.Forms;
using Sims3WorkshopSDK.Classes;

namespace Sims3WorkshopSDK.Interfaces
{
	// Token: 0x02000035 RID: 53
	public interface IWorkshop
	{
		// Token: 0x060000DD RID: 221
		IMeshEditor GetMeshEditor();

		// Token: 0x060000DE RID: 222
		Form GetParentForm();

		// Token: 0x060000DF RID: 223
		CreatorDetails GetCreatorDetails();

		// Token: 0x060000E0 RID: 224
		string CreateGuid(string salt);

		// Token: 0x060000E1 RID: 225
		UploadResult UploadFileToStorage(IWin32Window ownerWindow, string name, byte[] data);

		// Token: 0x060000E2 RID: 226
		IProjectModel GetCurrentProjectModel();

		// Token: 0x060000E3 RID: 227
		Lod GetCurrentLOD();

		// Token: 0x060000E4 RID: 228
		void SetCurrentLOD(Lod lod);

		// Token: 0x060000E5 RID: 229
		IGamedata GetGamedataInstance();

		// Token: 0x060000E6 RID: 230
		int CompressData(ref byte[] inData, out byte[] outData, DBPFType type);

		// Token: 0x060000E7 RID: 231
		int ZipCompressData(ref byte[] inData, out byte[] outData, DBPFType type);

		// Token: 0x060000E8 RID: 232
		PluginResult ExportResource(DBPFType type, object file);

		// Token: 0x060000E9 RID: 233
		PluginResult GetPluginResource(string name, out object obj);

		// Token: 0x060000EA RID: 234
		IWorkshopProject LoadProject(string filename);

		// Token: 0x060000EB RID: 235
		string GetGlobalSetting(string settingName);

		// Token: 0x060000EC RID: 236
		void SetGlobalSetting(string settingName, string value);

		// Token: 0x060000ED RID: 237
		void RefreshView();

		// Token: 0x060000EE RID: 238
		void GetAbsoluteTransformation(object bone, object rig, ref float[] arr);

		// Token: 0x060000EF RID: 239
		void ReloadProject();
	}
}
