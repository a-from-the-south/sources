using System;
using System.IO;
using Sims3WorkshopSDK;

namespace Package.SharedFiles
{
	// Token: 0x020000B3 RID: 179
	public class ITGIndex : ResKey
	{
		// Token: 0x060008FE RID: 2302 RVA: 0x000072B1 File Offset: 0x000054B1
		public void UnSerialize(BinaryReader r)
		{
			base.SecondInstanceId = r.ReadInt32();
			base.InstanceId = r.ReadInt32();
			base.TypeId = (uint)r.ReadInt32();
			base.GroupId = r.ReadInt32();
		}

		// Token: 0x060008FF RID: 2303 RVA: 0x000072E3 File Offset: 0x000054E3
		public void Serialize(BinaryWriter w)
		{
			w.Write(base.SecondInstanceId);
			w.Write(base.InstanceId);
			w.Write(base.TypeId);
			w.Write(base.GroupId);
		}

		// Token: 0x06000900 RID: 2304 RVA: 0x00007315 File Offset: 0x00005515
		public ITGIndex() : base(3)
		{
		}

		// Token: 0x06000901 RID: 2305 RVA: 0x0000731E File Offset: 0x0000551E
		public ITGIndex(GameVersion game) : base(game)
		{
		}

		// Token: 0x06000902 RID: 2306 RVA: 0x0000718D File Offset: 0x0000538D
		public ITGIndex(string key) : base(key)
		{
		}

		// Token: 0x06000903 RID: 2307 RVA: 0x00007196 File Offset: 0x00005396
		public ITGIndex(ResKey reskey)
		{
			base.SetFromResKey(reskey);
		}

		// Token: 0x170002FD RID: 765
		// (get) Token: 0x06000904 RID: 2308 RVA: 0x00007209 File Offset: 0x00005409
		// (set) Token: 0x06000905 RID: 2309 RVA: 0x00007211 File Offset: 0x00005411
		public string Reskey
		{
			get
			{
				return base.AsString();
			}
			set
			{
				base.SetFromString(value);
			}
		}
	}
}
