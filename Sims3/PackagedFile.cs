using System;
using System.Collections;

namespace Package
{
	// Token: 0x0200000A RID: 10
	public interface PackagedFile
	{
		// Token: 0x06000081 RID: 129
		string GetName();

		// Token: 0x06000082 RID: 130
		byte[] GetData();

		// Token: 0x06000083 RID: 131
		long GetLenght();

		// Token: 0x06000084 RID: 132
		string GetCrc();

		// Token: 0x06000085 RID: 133
		string GetGuid();

		// Token: 0x06000086 RID: 134
		string GetContentType();

		// Token: 0x06000087 RID: 135
		Hashtable GetMetaTags();

		// Token: 0x06000088 RID: 136
		void Serialize(bool compress);

		// Token: 0x06000089 RID: 137
		void SaveToFile(string fileName);
	}
}
