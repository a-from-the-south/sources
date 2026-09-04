using System;
using Sims3WorkshopSDK;

namespace Package
{
	// Token: 0x0200000B RID: 11
	public class PackagedFileFactory
	{
		// Token: 0x0600008A RID: 138 RVA: 0x00003325 File Offset: 0x00001525
		public static PackagedFile CreateInstance(string name, byte[] data, GameVersion gameVersion)
		{
			if (!PackageUtil.StringMatch("DBPF", data, 4) && !PackageUtil.StringMatch("DBPP", data, 4))
			{
				name.EndsWith(".png");
				return new DataFile(name, data);
			}
			return new DBPF(name, data, gameVersion);
		}
	}
}
