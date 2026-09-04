using System;
using System.IO;
using Package.Sims2Files.RCOLResource;

namespace Package.Geometry
{
	// Token: 0x020000F2 RID: 242
	public class TranslationMatrix : IRCOLResource
	{
		// Token: 0x170003E0 RID: 992
		// (get) Token: 0x06000C60 RID: 3168 RVA: 0x00008D67 File Offset: 0x00006F67
		public float X
		{
			get
			{
				return this.t_floatValue1;
			}
		}

		// Token: 0x170003E1 RID: 993
		// (get) Token: 0x06000C61 RID: 3169 RVA: 0x00008D6F File Offset: 0x00006F6F
		public float Y
		{
			get
			{
				return this.t_floatValue2;
			}
		}

		// Token: 0x170003E2 RID: 994
		// (get) Token: 0x06000C62 RID: 3170 RVA: 0x00008D77 File Offset: 0x00006F77
		public float Z
		{
			get
			{
				return this.t_floatValue3;
			}
		}

		// Token: 0x06000C63 RID: 3171 RVA: 0x00008D7F File Offset: 0x00006F7F
		public void UnSerialize(BinaryReader reader)
		{
			this.t_floatValue1 = reader.ReadSingle();
			this.t_floatValue2 = reader.ReadSingle();
			this.t_floatValue3 = reader.ReadSingle();
		}

		// Token: 0x06000C64 RID: 3172 RVA: 0x000038FA File Offset: 0x00001AFA
		public byte[] Serialize()
		{
			throw new NotImplementedException();
		}

		// Token: 0x040005CC RID: 1484
		private float t_floatValue1;

		// Token: 0x040005CD RID: 1485
		private float t_floatValue2;

		// Token: 0x040005CE RID: 1486
		private float t_floatValue3;
	}
}
