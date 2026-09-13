using System;
using System.Collections;
using System.IO;
using System.Runtime.CompilerServices;
using ns15;
using ns17;
using Sims3WorkshopSDK.Classes;
using Sims3WorkshopSDK.Interfaces;

namespace ns10
{
	// Token: 0x02000035 RID: 53
	internal sealed class Class34 : ISkeleton
	{
		// Token: 0x17000051 RID: 81
		// (get) Token: 0x060001F4 RID: 500 RVA: 0x00027F58 File Offset: 0x00026158
		// (set) Token: 0x060001F5 RID: 501 RVA: 0x0000343C File Offset: 0x0000163C
		public Class33[] Bones { get; set; }

		// Token: 0x17000052 RID: 82
		// (get) Token: 0x060001F6 RID: 502 RVA: 0x00027F70 File Offset: 0x00026170
		// (set) Token: 0x060001F7 RID: 503 RVA: 0x00003447 File Offset: 0x00001647
		public string Name { get; set; }

		// Token: 0x17000053 RID: 83
		// (get) Token: 0x060001F8 RID: 504 RVA: 0x00027F88 File Offset: 0x00026188
		// (set) Token: 0x060001F9 RID: 505 RVA: 0x00003452 File Offset: 0x00001652
		public Hashtable HashedBones { get; set; }

		// Token: 0x060001FA RID: 506 RVA: 0x00027FA0 File Offset: 0x000261A0
		public IBone[] GetBones()
		{
			return this.Bones;
		}

		// Token: 0x060001FB RID: 507 RVA: 0x0000345D File Offset: 0x0000165D
		public Class34()
		{
			this.HashedBones = new Hashtable();
		}

		// Token: 0x060001FC RID: 508 RVA: 0x00027FB8 File Offset: 0x000261B8
		public void method_0(BinaryReader binaryReader_0)
		{
			long position = binaryReader_0.BaseStream.Position;
			int num = binaryReader_0.ReadInt32();
			binaryReader_0.BaseStream.Position = (long)num;
			int num2 = binaryReader_0.ReadInt32();
			int num3 = binaryReader_0.ReadInt32();
			int num4 = binaryReader_0.ReadInt32();
			binaryReader_0.BaseStream.Position = (long)num2;
			this.Sims3WorkshopSDK.Interfaces.ISkeleton.Name = Class28.smethod_0(binaryReader_0);
			binaryReader_0.BaseStream.Position = (long)num4;
			this.Bones = new Class33[num3];
			for (int i = 0; i < num3; i++)
			{
				this.Bones[i] = new Class33();
				this.Bones[i].method_1(binaryReader_0);
				this.HashedBones.Add(FNV32.GetHash(this.Bones[i].Sims3WorkshopSDK.Interfaces.IBone.Name), this.Bones[i]);
			}
			for (int j = 0; j < this.Bones.Length; j++)
			{
				Class33 @class = this.Bones[j];
				for (int k = 0; k < this.Bones.Length; k++)
				{
					Class33 class2 = this.Bones[k];
					if (class2.Sims3WorkshopSDK.Interfaces.IBone.ParentIndex == j)
					{
						@class.ChildBones.Add(class2);
						class2.ParentBone = @class;
					}
				}
			}
			binaryReader_0.BaseStream.Position = position;
		}

		// Token: 0x0400019C RID: 412
		[CompilerGenerated]
		private Class33[] class33_0;

		// Token: 0x0400019D RID: 413
		[CompilerGenerated]
		private string string_0;

		// Token: 0x0400019E RID: 414
		[CompilerGenerated]
		private Hashtable hashtable_0;
	}
}
