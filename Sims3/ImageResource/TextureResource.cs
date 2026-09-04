using System;

namespace Package.ImageResource
{
	// Token: 0x020000EA RID: 234
	public interface TextureResource
	{
		// Token: 0x06000C01 RID: 3073
		DDS ToDDS();

		// Token: 0x06000C02 RID: 3074
		void FromDDS(DDS source);
	}
}
