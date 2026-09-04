using System;
using System.IO;

namespace Sims3WorkshopSDK.Interfaces
{
	// Token: 0x0200002A RID: 42
	public interface IRIG
	{
		// Token: 0x060000B0 RID: 176
		ISkeleton[] GetSkeletons();

		// Token: 0x060000B1 RID: 177
		void Read(BinaryReader r);
	}
}
