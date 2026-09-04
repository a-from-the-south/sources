using System;
using System.IO;
using Sims3WorkshopSDK;

namespace Package.SharedFiles.InternalRCOL
{
	// Token: 0x020000C1 RID: 193
	public interface IRCOLItem
	{
		// Token: 0x06000A0B RID: 2571
		void UnSerialize(BinaryReader reader);

		// Token: 0x06000A0C RID: 2572
		void Serialize(BinaryWriter writer);

		// Token: 0x06000A0D RID: 2573
		int ReplaceReferences(ResKey from, ResKey to);
	}
}
