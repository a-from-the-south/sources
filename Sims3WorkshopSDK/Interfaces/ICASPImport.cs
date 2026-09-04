using System;

namespace Sims3WorkshopSDK.Interfaces
{
	// Token: 0x02000027 RID: 39
	public interface ICASPImport
	{
		// Token: 0x060000AC RID: 172
		PluginResult ImportCASP(string fileName, object casp, object vpxy, object vpxyEntry, Lod lodLevel);

		// Token: 0x060000AD RID: 173
		PluginResult ImportGeom(string fileName, object casp, object geom, Lod lodLevel, int startVertexId);
	}
}
