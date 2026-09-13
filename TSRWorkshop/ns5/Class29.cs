using System;
using System.IO;
using System.Runtime.CompilerServices;
using ns17;

namespace ns5
{
	// Token: 0x02000030 RID: 48
	internal sealed class Class29
	{
		// Token: 0x1700003C RID: 60
		// (get) Token: 0x060001BD RID: 445 RVA: 0x00027A08 File Offset: 0x00025C08
		// (set) Token: 0x060001BE RID: 446 RVA: 0x00003355 File Offset: 0x00001555
		public string ModelName { get; set; }

		// Token: 0x060001BF RID: 447 RVA: 0x00027A20 File Offset: 0x00025C20
		public void method_0(BinaryReader binaryReader_0)
		{
			int num = binaryReader_0.ReadInt32();
			binaryReader_0.BaseStream.Position = (long)num;
			int num2 = binaryReader_0.ReadInt32();
			binaryReader_0.BaseStream.Position = (long)num2;
			this.ModelName = Class28.smethod_0(binaryReader_0);
		}

		// Token: 0x04000181 RID: 385
		[CompilerGenerated]
		private string string_0;
	}
}
