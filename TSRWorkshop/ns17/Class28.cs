using System;
using System.IO;
using System.Runtime.CompilerServices;
using ns10;
using ns16;
using ns4;
using ns5;
using Sims3WorkshopSDK.Interfaces;

namespace ns17
{
	// Token: 0x0200002F RID: 47
	internal sealed class Class28 : IRIG
	{
		// Token: 0x1700003B RID: 59
		// (get) Token: 0x060001B7 RID: 439 RVA: 0x00027824 File Offset: 0x00025A24
		// (set) Token: 0x060001B8 RID: 440 RVA: 0x0000334A File Offset: 0x0000154A
		public Class34[] Skeletons { get; set; }

		// Token: 0x060001B9 RID: 441 RVA: 0x0002783C File Offset: 0x00025A3C
		public ISkeleton[] GetSkeletons()
		{
			return this.Skeletons;
		}

		// Token: 0x060001BA RID: 442 RVA: 0x00027854 File Offset: 0x00025A54
		public void Read(BinaryReader binaryReader_0)
		{
			int num = binaryReader_0.ReadInt32();
			int num2 = binaryReader_0.ReadInt32();
			binaryReader_0.ReadInt32();
			binaryReader_0.ReadInt32();
			binaryReader_0.ReadInt32();
			binaryReader_0.ReadInt32();
			binaryReader_0.ReadInt32();
			int num3 = binaryReader_0.ReadInt32();
			int num4 = binaryReader_0.ReadInt32();
			binaryReader_0.ReadInt32();
			binaryReader_0.ReadInt32();
			binaryReader_0.ReadInt32();
			binaryReader_0.ReadInt32();
			binaryReader_0.ReadInt32();
			binaryReader_0.ReadInt32();
			int num5 = binaryReader_0.ReadInt32();
			int num6 = binaryReader_0.ReadInt32();
			binaryReader_0.ReadInt32();
			binaryReader_0.ReadInt32();
			binaryReader_0.ReadInt32();
			binaryReader_0.ReadInt32();
			binaryReader_0.ReadInt32();
			binaryReader_0.ReadInt32();
			if (num != 0)
			{
				binaryReader_0.BaseStream.Position = (long)num;
				this.class30_0 = new Class30();
				this.class30_0.method_0(binaryReader_0);
			}
			if (num2 != 0)
			{
				binaryReader_0.BaseStream.Position = (long)num2;
				this.class31_0 = new Class31();
				this.class31_0.method_0(binaryReader_0);
			}
			if (num3 != 0)
			{
				binaryReader_0.BaseStream.Position = (long)num4;
				this.Skeletons = new Class34[num3];
				for (int i = 0; i < num3; i++)
				{
					this.Skeletons[i] = new Class34();
					this.Skeletons[i].method_0(binaryReader_0);
				}
			}
			if (num5 != 0)
			{
				binaryReader_0.BaseStream.Position = (long)num6;
				for (int j = 0; j < num5; j++)
				{
					Class29 @class = new Class29();
					@class.method_0(binaryReader_0);
				}
			}
		}

		// Token: 0x060001BB RID: 443 RVA: 0x000279D0 File Offset: 0x00025BD0
		public static string smethod_0(BinaryReader binaryReader_0)
		{
			string text = "";
			byte b = binaryReader_0.ReadByte();
			do
			{
				text += (char)b;
				b = binaryReader_0.ReadByte();
			}
			while (b != 0);
			return text;
		}

		// Token: 0x0400017E RID: 382
		private Class30 class30_0;

		// Token: 0x0400017F RID: 383
		private Class31 class31_0;

		// Token: 0x04000180 RID: 384
		[CompilerGenerated]
		private Class34[] class34_0;
	}
}
