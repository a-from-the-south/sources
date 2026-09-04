using System;

namespace Sims3WorkshopSDK
{
	// Token: 0x02000008 RID: 8
	public class TextureResKey : ResKey
	{
		// Token: 0x1700000C RID: 12
		// (get) Token: 0x06000044 RID: 68 RVA: 0x0000234E File Offset: 0x0000054E
		// (set) Token: 0x06000045 RID: 69 RVA: 0x00002356 File Offset: 0x00000556
		public string ExportPrefix { get; set; }

		// Token: 0x06000046 RID: 70 RVA: 0x0000235F File Offset: 0x0000055F
		public TextureResKey(GameVersion game) : base(DBPFType.DDS, game)
		{
		}

		// Token: 0x06000047 RID: 71 RVA: 0x0000236D File Offset: 0x0000056D
		public TextureResKey(GameVersion game, string exportPrefix) : base(DBPFType.DDS, game)
		{
			this.ExportPrefix = exportPrefix;
		}

		// Token: 0x06000048 RID: 72 RVA: 0x00002382 File Offset: 0x00000582
		public TextureResKey(string key, GameVersion game) : base(key, game)
		{
		}

		// Token: 0x06000049 RID: 73 RVA: 0x0000238C File Offset: 0x0000058C
		public TextureResKey(string key, GameVersion game, string exportPrefix) : base(key, game)
		{
			this.ExportPrefix = exportPrefix;
		}
	}
}
