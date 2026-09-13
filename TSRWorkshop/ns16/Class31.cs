using System;
using System.IO;
using ns17;
using Sims3WorkshopSDK.Interfaces;

namespace ns16
{
	// Token: 0x02000032 RID: 50
	internal sealed class Class31 : IExporterInfo
	{
		// Token: 0x060001C3 RID: 451 RVA: 0x00027B18 File Offset: 0x00025D18
		public void method_0(BinaryReader binaryReader_0)
		{
			uint num = binaryReader_0.ReadUInt32();
			binaryReader_0.ReadUInt32();
			binaryReader_0.ReadUInt32();
			binaryReader_0.ReadUInt32();
			binaryReader_0.ReadUInt32();
			binaryReader_0.BaseStream.Position = (long)((ulong)num);
			Class28.smethod_0(binaryReader_0);
		}
	}
}
