using System;
using System.IO;
using ns17;
using Sims3WorkshopSDK.Interfaces;

namespace ns4
{
	// Token: 0x02000031 RID: 49
	internal sealed class Class30 : IArtToolInfo
	{
		// Token: 0x060001C1 RID: 449 RVA: 0x00027A64 File Offset: 0x00025C64
		public void method_0(BinaryReader binaryReader_0)
		{
			uint num = binaryReader_0.ReadUInt32();
			this.uint_0 = binaryReader_0.ReadUInt32();
			this.uint_1 = binaryReader_0.ReadUInt32();
			this.float_0 = binaryReader_0.ReadSingle();
			this.float_1 = new float[3];
			this.float_1[0] = binaryReader_0.ReadSingle();
			this.float_1[1] = binaryReader_0.ReadSingle();
			this.float_1[2] = binaryReader_0.ReadSingle();
			this.float_2 = new float[9];
			for (int i = 0; i < 9; i++)
			{
				this.float_2[i] = binaryReader_0.ReadSingle();
			}
			binaryReader_0.BaseStream.Position = (long)((ulong)num);
			this.string_0 = Class28.smethod_0(binaryReader_0);
		}

		// Token: 0x04000182 RID: 386
		private string string_0;

		// Token: 0x04000183 RID: 387
		private uint uint_0;

		// Token: 0x04000184 RID: 388
		private uint uint_1;

		// Token: 0x04000185 RID: 389
		private float float_0;

		// Token: 0x04000186 RID: 390
		private float[] float_1;

		// Token: 0x04000187 RID: 391
		private float[] float_2;
	}
}
