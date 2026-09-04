using System;

namespace Sims3WorkshopSDK.Interfaces
{
	// Token: 0x02000026 RID: 38
	public interface ICASPExport
	{
		// Token: 0x060000AA RID: 170
		PluginResult ExportCASP(string fileName, object casp, object vpxy, object vpxyEntry, Lod lodLevel);

		// Token: 0x060000AB RID: 171
		PluginResult ExportGeom(string fileName, object casp, object geom, Lod lodLevel);
	}
}
