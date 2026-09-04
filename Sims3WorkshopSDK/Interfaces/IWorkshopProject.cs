using System;
using System.Collections.Generic;

namespace Sims3WorkshopSDK.Interfaces
{
	// Token: 0x02000038 RID: 56
	public interface IWorkshopProject
	{
		// Token: 0x17000032 RID: 50
		// (get) Token: 0x060000F4 RID: 244
		object CurrentPackage { get; }

		// Token: 0x17000033 RID: 51
		// (get) Token: 0x060000F5 RID: 245
		Dictionary<string, string> MetaData { get; }

		// Token: 0x17000034 RID: 52
		// (get) Token: 0x060000F6 RID: 246
		Dictionary<string, object> MetaObjects { get; }

		// Token: 0x17000035 RID: 53
		// (get) Token: 0x060000F7 RID: 247
		byte[] ThumbnailData { get; }

		// Token: 0x17000036 RID: 54
		// (get) Token: 0x060000F8 RID: 248
		string Filename { get; }

		// Token: 0x17000037 RID: 55
		// (get) Token: 0x060000F9 RID: 249
		// (set) Token: 0x060000FA RID: 250
		string Name { get; set; }

		// Token: 0x17000038 RID: 56
		// (get) Token: 0x060000FB RID: 251
		// (set) Token: 0x060000FC RID: 252
		bool HasChanges { get; set; }

		// Token: 0x17000039 RID: 57
		// (get) Token: 0x060000FD RID: 253
		// (set) Token: 0x060000FE RID: 254
		byte[] PackageData { get; set; }

		// Token: 0x1700003A RID: 58
		// (get) Token: 0x060000FF RID: 255
		// (set) Token: 0x06000100 RID: 256
		ProjectType ProjectType { get; set; }

		// Token: 0x06000101 RID: 257
		bool Save();
	}
}
