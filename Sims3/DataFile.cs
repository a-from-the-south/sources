using System;
using System.Collections;
using System.IO;
using Package.Helper;

namespace Package
{
	// Token: 0x0200000C RID: 12
	public class DataFile : PackagedFile
	{
		// Token: 0x17000013 RID: 19
		// (get) Token: 0x0600008C RID: 140 RVA: 0x0000335F File Offset: 0x0000155F
		// (set) Token: 0x0600008D RID: 141 RVA: 0x00003367 File Offset: 0x00001567
		public string Guid { get; set; }

		// Token: 0x17000014 RID: 20
		// (get) Token: 0x0600008E RID: 142 RVA: 0x00003370 File Offset: 0x00001570
		// (set) Token: 0x0600008F RID: 143 RVA: 0x00003378 File Offset: 0x00001578
		public string ContentType { get; set; }

		// Token: 0x17000015 RID: 21
		// (get) Token: 0x06000090 RID: 144 RVA: 0x00003381 File Offset: 0x00001581
		// (set) Token: 0x06000091 RID: 145 RVA: 0x00003389 File Offset: 0x00001589
		public Hashtable MetaTags { get; set; }

		// Token: 0x06000092 RID: 146 RVA: 0x00003392 File Offset: 0x00001592
		public DataFile(string name, byte[] data)
		{
			this.name = name;
			this.data = data;
			this.MetaTags = new Hashtable();
		}

		// Token: 0x06000093 RID: 147 RVA: 0x000033B3 File Offset: 0x000015B3
		public string GetName()
		{
			return this.name;
		}

		// Token: 0x06000094 RID: 148 RVA: 0x000033BB File Offset: 0x000015BB
		public byte[] GetData()
		{
			return this.data;
		}

		// Token: 0x06000095 RID: 149 RVA: 0x000033C3 File Offset: 0x000015C3
		public long GetLenght()
		{
			return (long)this.data.Length;
		}

		// Token: 0x06000096 RID: 150 RVA: 0x0000E4F0 File Offset: 0x0000C6F0
		public string GetCrc()
		{
			return SimsCrc64.Compute(this.data).ToString("X16");
		}

		// Token: 0x06000097 RID: 151 RVA: 0x000033CE File Offset: 0x000015CE
		public string GetGuid()
		{
			return this.Guid;
		}

		// Token: 0x06000098 RID: 152 RVA: 0x000033D6 File Offset: 0x000015D6
		public string GetContentType()
		{
			return this.ContentType;
		}

		// Token: 0x06000099 RID: 153 RVA: 0x000033DE File Offset: 0x000015DE
		public Hashtable GetMetaTags()
		{
			return this.MetaTags;
		}

		// Token: 0x0600009A RID: 154 RVA: 0x000032EA File Offset: 0x000014EA
		public virtual void Serialize(bool compress)
		{
		}

		// Token: 0x0600009B RID: 155 RVA: 0x000033E6 File Offset: 0x000015E6
		public void SaveToFile(string fileName)
		{
			FileStream fileStream = new FileStream(fileName, FileMode.OpenOrCreate);
			fileStream.Write(this.data, 0, this.data.Length);
			fileStream.Close();
		}

		// Token: 0x0400003A RID: 58
		protected byte[] data;

		// Token: 0x0400003B RID: 59
		protected string name;
	}
}
