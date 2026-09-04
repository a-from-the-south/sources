using System;
using System.IO;
using Sims3WorkshopSDK;

namespace Package.SharedFiles.InternalRCOL
{
	// Token: 0x020000BB RID: 187
	public class S_SM : RCOLItem
	{
		// Token: 0x17000332 RID: 818
		// (get) Token: 0x06000991 RID: 2449 RVA: 0x000076FC File Offset: 0x000058FC
		// (set) Token: 0x06000992 RID: 2450 RVA: 0x00007704 File Offset: 0x00005904
		public uint identifier { get; private set; }

		// Token: 0x17000333 RID: 819
		// (get) Token: 0x06000993 RID: 2451 RVA: 0x0000770D File Offset: 0x0000590D
		// (set) Token: 0x06000994 RID: 2452 RVA: 0x00007715 File Offset: 0x00005915
		public uint version { get; private set; }

		// Token: 0x17000334 RID: 820
		// (get) Token: 0x06000995 RID: 2453 RVA: 0x0000771E File Offset: 0x0000591E
		// (set) Token: 0x06000996 RID: 2454 RVA: 0x00007726 File Offset: 0x00005926
		public uint hashedName { get; private set; }

		// Token: 0x17000335 RID: 821
		// (get) Token: 0x06000997 RID: 2455 RVA: 0x0000772F File Offset: 0x0000592F
		// (set) Token: 0x06000998 RID: 2456 RVA: 0x00007737 File Offset: 0x00005937
		public int[] sadIndex { get; private set; }

		// Token: 0x17000336 RID: 822
		// (get) Token: 0x06000999 RID: 2457 RVA: 0x00007740 File Offset: 0x00005940
		// (set) Token: 0x0600099A RID: 2458 RVA: 0x00007748 File Offset: 0x00005948
		public int[] spdIndex { get; private set; }

		// Token: 0x17000337 RID: 823
		// (get) Token: 0x0600099B RID: 2459 RVA: 0x00007751 File Offset: 0x00005951
		// (set) Token: 0x0600099C RID: 2460 RVA: 0x00007759 File Offset: 0x00005959
		public int[] sstIndex { get; private set; }

		// Token: 0x17000338 RID: 824
		// (get) Token: 0x0600099D RID: 2461 RVA: 0x00007762 File Offset: 0x00005962
		// (set) Token: 0x0600099E RID: 2462 RVA: 0x0000776A File Offset: 0x0000596A
		public int[,] someIndex { get; private set; }

		// Token: 0x17000339 RID: 825
		// (get) Token: 0x0600099F RID: 2463 RVA: 0x00007773 File Offset: 0x00005973
		// (set) Token: 0x060009A0 RID: 2464 RVA: 0x0000777B File Offset: 0x0000597B
		public int unknown { get; private set; }

		// Token: 0x1700033A RID: 826
		// (get) Token: 0x060009A1 RID: 2465 RVA: 0x00007784 File Offset: 0x00005984
		// (set) Token: 0x060009A2 RID: 2466 RVA: 0x0000778C File Offset: 0x0000598C
		public int properties { get; private set; }

		// Token: 0x1700033B RID: 827
		// (get) Token: 0x060009A3 RID: 2467 RVA: 0x00007795 File Offset: 0x00005995
		// (set) Token: 0x060009A4 RID: 2468 RVA: 0x0000779D File Offset: 0x0000599D
		public int priority { get; private set; }

		// Token: 0x1700033C RID: 828
		// (get) Token: 0x060009A5 RID: 2469 RVA: 0x000077A6 File Offset: 0x000059A6
		// (set) Token: 0x060009A6 RID: 2470 RVA: 0x000077AE File Offset: 0x000059AE
		public int unknown2 { get; private set; }

		// Token: 0x1700033D RID: 829
		// (get) Token: 0x060009A7 RID: 2471 RVA: 0x000077B7 File Offset: 0x000059B7
		// (set) Token: 0x060009A8 RID: 2472 RVA: 0x000077BF File Offset: 0x000059BF
		public int empty1 { get; private set; }

		// Token: 0x1700033E RID: 830
		// (get) Token: 0x060009A9 RID: 2473 RVA: 0x000077C8 File Offset: 0x000059C8
		// (set) Token: 0x060009AA RID: 2474 RVA: 0x000077D0 File Offset: 0x000059D0
		public int empty2 { get; private set; }

		// Token: 0x1700033F RID: 831
		// (get) Token: 0x060009AB RID: 2475 RVA: 0x000077D9 File Offset: 0x000059D9
		// (set) Token: 0x060009AC RID: 2476 RVA: 0x000077E1 File Offset: 0x000059E1
		public int empty3 { get; private set; }

		// Token: 0x17000340 RID: 832
		// (get) Token: 0x060009AD RID: 2477 RVA: 0x000077EA File Offset: 0x000059EA
		// (set) Token: 0x060009AE RID: 2478 RVA: 0x000077F2 File Offset: 0x000059F2
		public int empty4 { get; private set; }

		// Token: 0x060009AF RID: 2479 RVA: 0x0002EE80 File Offset: 0x0002D080
		public override void UnSerialize(BinaryReader r)
		{
			this.identifier = r.ReadUInt32();
			this.version = r.ReadUInt32();
			this.hashedName = r.ReadUInt32();
			int num = r.ReadInt32();
			this.sadIndex = new int[num];
			for (int i = 0; i < num; i++)
			{
				this.sadIndex[i] = r.ReadInt32();
			}
			num = r.ReadInt32();
			this.spdIndex = new int[num];
			for (int j = 0; j < num; j++)
			{
				this.spdIndex[j] = r.ReadInt32();
			}
			num = r.ReadInt32();
			this.sstIndex = new int[num];
			for (int k = 0; k < num; k++)
			{
				this.sstIndex[k] = r.ReadInt32();
			}
			num = r.ReadInt32();
			this.someIndex = new int[num, 3];
			for (int l = 0; l < num; l++)
			{
				this.someIndex[l, 0] = r.ReadInt32();
				this.someIndex[l, 1] = r.ReadInt32();
				this.someIndex[l, 2] = r.ReadInt32();
			}
			r.ReadInt32();
			r.ReadInt32();
			r.ReadInt32();
			r.ReadInt32();
			r.ReadInt32();
			r.ReadInt32();
			r.ReadInt32();
			r.ReadInt32();
		}

		// Token: 0x060009B0 RID: 2480 RVA: 0x000032EA File Offset: 0x000014EA
		public override void Serialize(BinaryWriter writer)
		{
		}

		// Token: 0x060009B1 RID: 2481 RVA: 0x00003309 File Offset: 0x00001509
		public override int ReplaceReferences(ResKey from, ResKey to)
		{
			return 0;
		}
	}
}
