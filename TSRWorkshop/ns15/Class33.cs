using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using ns10;
using ns17;
using Sims3WorkshopSDK.Classes;
using Sims3WorkshopSDK.Interfaces;
using SlimDX;

namespace ns15
{
	// Token: 0x02000034 RID: 52
	internal sealed class Class33 : IBone
	{
		// Token: 0x17000041 RID: 65
		// (get) Token: 0x060001CF RID: 463 RVA: 0x00027C60 File Offset: 0x00025E60
		// (set) Token: 0x060001D0 RID: 464 RVA: 0x0000338C File Offset: 0x0000158C
		public string Name { get; set; }

		// Token: 0x17000042 RID: 66
		// (get) Token: 0x060001D1 RID: 465 RVA: 0x00027C78 File Offset: 0x00025E78
		// (set) Token: 0x060001D2 RID: 466 RVA: 0x00003397 File Offset: 0x00001597
		public uint NameHash { get; set; }

		// Token: 0x17000043 RID: 67
		// (get) Token: 0x060001D3 RID: 467 RVA: 0x00027C90 File Offset: 0x00025E90
		// (set) Token: 0x060001D4 RID: 468 RVA: 0x000033A2 File Offset: 0x000015A2
		public int ParentIndex { get; set; }

		// Token: 0x17000044 RID: 68
		// (get) Token: 0x060001D5 RID: 469 RVA: 0x00027CA8 File Offset: 0x00025EA8
		// (set) Token: 0x060001D6 RID: 470 RVA: 0x000033AD File Offset: 0x000015AD
		public Matrix TransformationMatrix { get; set; }

		// Token: 0x17000045 RID: 69
		// (get) Token: 0x060001D7 RID: 471 RVA: 0x00027CC0 File Offset: 0x00025EC0
		// (set) Token: 0x060001D8 RID: 472 RVA: 0x000033B8 File Offset: 0x000015B8
		public Quaternion Rotation { get; set; }

		// Token: 0x17000046 RID: 70
		// (get) Token: 0x060001D9 RID: 473 RVA: 0x00027CD8 File Offset: 0x00025ED8
		// (set) Token: 0x060001DA RID: 474 RVA: 0x000033C3 File Offset: 0x000015C3
		public Matrix TranslationMatrix { get; set; }

		// Token: 0x17000047 RID: 71
		// (get) Token: 0x060001DB RID: 475 RVA: 0x00027CF0 File Offset: 0x00025EF0
		// (set) Token: 0x060001DC RID: 476 RVA: 0x000033CE File Offset: 0x000015CE
		public Matrix CombinedTransformationMatrix { get; set; }

		// Token: 0x17000048 RID: 72
		// (get) Token: 0x060001DD RID: 477 RVA: 0x00027D08 File Offset: 0x00025F08
		// (set) Token: 0x060001DE RID: 478 RVA: 0x000033D9 File Offset: 0x000015D9
		public Matrix CombinedBoneTransformationMatrix { get; set; }

		// Token: 0x17000049 RID: 73
		// (get) Token: 0x060001DF RID: 479 RVA: 0x00027D20 File Offset: 0x00025F20
		// (set) Token: 0x060001E0 RID: 480 RVA: 0x000033E4 File Offset: 0x000015E4
		public Matrix OffsetMatrix { get; set; }

		// Token: 0x1700004A RID: 74
		// (get) Token: 0x060001E1 RID: 481 RVA: 0x00027D38 File Offset: 0x00025F38
		// (set) Token: 0x060001E2 RID: 482 RVA: 0x000033EF File Offset: 0x000015EF
		public Matrix ParentMatrix { get; set; }

		// Token: 0x1700004B RID: 75
		// (get) Token: 0x060001E3 RID: 483 RVA: 0x00027D50 File Offset: 0x00025F50
		// (set) Token: 0x060001E4 RID: 484 RVA: 0x000033FA File Offset: 0x000015FA
		public Class32 Transformation { get; set; }

		// Token: 0x1700004C RID: 76
		// (get) Token: 0x060001E5 RID: 485 RVA: 0x00027D68 File Offset: 0x00025F68
		// (set) Token: 0x060001E6 RID: 486 RVA: 0x00003405 File Offset: 0x00001605
		public float[] InverseMatrix { get; set; }

		// Token: 0x1700004D RID: 77
		// (get) Token: 0x060001E7 RID: 487 RVA: 0x00027D80 File Offset: 0x00025F80
		// (set) Token: 0x060001E8 RID: 488 RVA: 0x00003410 File Offset: 0x00001610
		public float LodError { get; set; }

		// Token: 0x1700004E RID: 78
		// (get) Token: 0x060001E9 RID: 489 RVA: 0x00027D98 File Offset: 0x00025F98
		// (set) Token: 0x060001EA RID: 490 RVA: 0x0000341B File Offset: 0x0000161B
		public int Unknown1 { get; set; }

		// Token: 0x060001EB RID: 491 RVA: 0x00027DB0 File Offset: 0x00025FB0
		public ITransform GetTransformation()
		{
			return this.Transformation;
		}

		// Token: 0x060001EC RID: 492 RVA: 0x00027DC8 File Offset: 0x00025FC8
		public object method_0()
		{
			return this.CombinedTransformationMatrix;
		}

		// Token: 0x1700004F RID: 79
		// (get) Token: 0x060001ED RID: 493 RVA: 0x00027DE4 File Offset: 0x00025FE4
		// (set) Token: 0x060001EE RID: 494 RVA: 0x00003426 File Offset: 0x00001626
		public List<Class33> ChildBones { get; set; }

		// Token: 0x17000050 RID: 80
		// (get) Token: 0x060001EF RID: 495 RVA: 0x00027DFC File Offset: 0x00025FFC
		// (set) Token: 0x060001F0 RID: 496 RVA: 0x00003431 File Offset: 0x00001631
		public Class33 ParentBone { get; set; }

		// Token: 0x060001F1 RID: 497 RVA: 0x00027E14 File Offset: 0x00026014
		public Class33()
		{
			this.OffsetMatrix = (this.CombinedTransformationMatrix = Matrix.Identity);
			this.TransformationMatrix = Matrix.Identity;
			this.Rotation = Quaternion.Identity;
			this.TranslationMatrix = Matrix.Identity;
			this.ParentMatrix = Matrix.Identity;
			this.ChildBones = new List<Class33>();
		}

		// Token: 0x060001F2 RID: 498 RVA: 0x00027E74 File Offset: 0x00026074
		public void method_1(BinaryReader binaryReader_0)
		{
			int num = binaryReader_0.ReadInt32();
			this.Sims3WorkshopSDK.Interfaces.IBone.ParentIndex = binaryReader_0.ReadInt32();
			this.Transformation = new Class32();
			this.Transformation.method_0(binaryReader_0);
			this.InverseMatrix = new float[16];
			for (int i = 0; i < 16; i++)
			{
				this.InverseMatrix[i] = binaryReader_0.ReadSingle();
			}
			this.LodError = binaryReader_0.ReadSingle();
			binaryReader_0.ReadInt32();
			binaryReader_0.ReadInt32();
			this.Unknown1 = binaryReader_0.ReadInt32();
			long position = binaryReader_0.BaseStream.Position;
			binaryReader_0.BaseStream.Position = (long)num;
			this.Sims3WorkshopSDK.Interfaces.IBone.Name = Class28.smethod_0(binaryReader_0);
			this.NameHash = FNV32.GetHash(this.Sims3WorkshopSDK.Interfaces.IBone.Name);
			binaryReader_0.BaseStream.Position = position;
		}

		// Token: 0x060001F3 RID: 499 RVA: 0x00027F40 File Offset: 0x00026140
		public string ToString()
		{
			return this.Sims3WorkshopSDK.Interfaces.IBone.Name;
		}

		// Token: 0x0400018C RID: 396
		[CompilerGenerated]
		private string string_0;

		// Token: 0x0400018D RID: 397
		[CompilerGenerated]
		private uint uint_0;

		// Token: 0x0400018E RID: 398
		[CompilerGenerated]
		private int int_0;

		// Token: 0x0400018F RID: 399
		[CompilerGenerated]
		private Matrix matrix_0;

		// Token: 0x04000190 RID: 400
		[CompilerGenerated]
		private Quaternion quaternion_0;

		// Token: 0x04000191 RID: 401
		[CompilerGenerated]
		private Matrix matrix_1;

		// Token: 0x04000192 RID: 402
		[CompilerGenerated]
		private Matrix matrix_2;

		// Token: 0x04000193 RID: 403
		[CompilerGenerated]
		private Matrix matrix_3;

		// Token: 0x04000194 RID: 404
		[CompilerGenerated]
		private Matrix matrix_4;

		// Token: 0x04000195 RID: 405
		[CompilerGenerated]
		private Matrix matrix_5;

		// Token: 0x04000196 RID: 406
		[CompilerGenerated]
		private Class32 class32_0;

		// Token: 0x04000197 RID: 407
		[CompilerGenerated]
		private float[] float_0;

		// Token: 0x04000198 RID: 408
		[CompilerGenerated]
		private float float_1;

		// Token: 0x04000199 RID: 409
		[CompilerGenerated]
		private int int_1;

		// Token: 0x0400019A RID: 410
		[CompilerGenerated]
		private List<Class33> list_0;

		// Token: 0x0400019B RID: 411
		[CompilerGenerated]
		private Class33 class33_0;
	}
}
