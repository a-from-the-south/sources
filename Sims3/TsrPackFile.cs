using System;

namespace Package
{
	// Token: 0x02000011 RID: 17
	public class TsrPackFile
	{
		// Token: 0x1700002F RID: 47
		// (get) Token: 0x060000E7 RID: 231 RVA: 0x000036A6 File Offset: 0x000018A6
		// (set) Token: 0x060000E8 RID: 232 RVA: 0x000036AE File Offset: 0x000018AE
		public string Name { get; set; }

		// Token: 0x17000030 RID: 48
		// (get) Token: 0x060000E9 RID: 233 RVA: 0x000036B7 File Offset: 0x000018B7
		// (set) Token: 0x060000EA RID: 234 RVA: 0x000036BF File Offset: 0x000018BF
		public byte[] Data { get; set; }

		// Token: 0x17000031 RID: 49
		// (get) Token: 0x060000EB RID: 235 RVA: 0x000036C8 File Offset: 0x000018C8
		// (set) Token: 0x060000EC RID: 236 RVA: 0x000036D0 File Offset: 0x000018D0
		public string Type { get; set; }

		// Token: 0x060000ED RID: 237 RVA: 0x000036D9 File Offset: 0x000018D9
		public TsrPackFile(string name, string type, byte[] data)
		{
			this.Name = name;
			this.Type = type;
			this.Data = data;
		}
	}
}
