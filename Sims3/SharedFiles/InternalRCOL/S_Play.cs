using System;
using System.IO;
using Sims3WorkshopSDK;

namespace Package.SharedFiles.InternalRCOL
{
	// Token: 0x020000B4 RID: 180
	public class S_Play : RCOLItem
	{
		// Token: 0x170002FE RID: 766
		// (get) Token: 0x06000906 RID: 2310 RVA: 0x00007327 File Offset: 0x00005527
		// (set) Token: 0x06000907 RID: 2311 RVA: 0x0000732F File Offset: 0x0000552F
		public int identifier { get; private set; }

		// Token: 0x170002FF RID: 767
		// (get) Token: 0x06000908 RID: 2312 RVA: 0x00007338 File Offset: 0x00005538
		// (set) Token: 0x06000909 RID: 2313 RVA: 0x00007340 File Offset: 0x00005540
		public int version { get; private set; }

		// Token: 0x17000300 RID: 768
		// (get) Token: 0x0600090A RID: 2314 RVA: 0x00007349 File Offset: 0x00005549
		// (set) Token: 0x0600090B RID: 2315 RVA: 0x00007351 File Offset: 0x00005551
		public IGTIndex clip { get; private set; }

		// Token: 0x17000301 RID: 769
		// (get) Token: 0x0600090C RID: 2316 RVA: 0x0000735A File Offset: 0x0000555A
		// (set) Token: 0x0600090D RID: 2317 RVA: 0x00007362 File Offset: 0x00005562
		public IGTIndex tkmk { get; private set; }

		// Token: 0x17000302 RID: 770
		// (get) Token: 0x0600090E RID: 2318 RVA: 0x0000736B File Offset: 0x0000556B
		// (set) Token: 0x0600090F RID: 2319 RVA: 0x00007373 File Offset: 0x00005573
		public string animationName { get; private set; }

		// Token: 0x06000910 RID: 2320 RVA: 0x0002D150 File Offset: 0x0002B350
		public override void UnSerialize(BinaryReader r)
		{
			this.identifier = r.ReadInt32();
			this.version = r.ReadInt32();
			this.clip = new IGTIndex();
			this.clip.SecondInstanceId = r.ReadInt32();
			this.clip.InstanceId = r.ReadInt32();
			this.clip.TypeId = (uint)r.ReadInt32();
			this.clip.GroupId = r.ReadInt32();
			this.tkmk = new IGTIndex();
			this.tkmk.SecondInstanceId = r.ReadInt32();
			this.tkmk.InstanceId = r.ReadInt32();
			this.tkmk.TypeId = (uint)r.ReadInt32();
			this.tkmk.GroupId = r.ReadInt32();
			int num = r.ReadInt32();
			r.ReadBytes(12);
			for (int i = 0; i < num; i++)
			{
				r.ReadInt32();
				r.ReadInt32();
				r.ReadInt32();
				r.ReadInt32();
			}
			int num2 = r.ReadInt32();
			for (int j = 0; j < num2; j++)
			{
				r.ReadInt32();
				r.ReadInt32();
			}
			r.ReadInt32();
			r.ReadBytes(16);
			int num3 = r.ReadInt32();
			if (num3 > 0)
			{
				this.animationName = "";
				for (int k = 0; k < num3; k++)
				{
					this.animationName += ((char)r.ReadByte()).ToString();
					r.ReadByte();
				}
			}
		}

		// Token: 0x06000911 RID: 2321 RVA: 0x000038FA File Offset: 0x00001AFA
		public override void Serialize(BinaryWriter writer)
		{
			throw new NotImplementedException();
		}

		// Token: 0x06000912 RID: 2322 RVA: 0x00003309 File Offset: 0x00001509
		public override int ReplaceReferences(ResKey from, ResKey to)
		{
			return 0;
		}
	}
}
