using System;
using System.IO;
using Sims3WorkshopSDK;

namespace Package.SharedFiles
{
	// Token: 0x020000B1 RID: 177
	public class TGIIndex : ResKey
	{
		// Token: 0x060008EE RID: 2286 RVA: 0x00007185 File Offset: 0x00005385
		public TGIIndex()
		{
		}

		// Token: 0x060008EF RID: 2287 RVA: 0x0000718D File Offset: 0x0000538D
		public TGIIndex(string key) : base(key)
		{
		}

		// Token: 0x060008F0 RID: 2288 RVA: 0x00007196 File Offset: 0x00005396
		public TGIIndex(ResKey reskey)
		{
			base.SetFromResKey(reskey);
		}

		// Token: 0x060008F1 RID: 2289 RVA: 0x000071A5 File Offset: 0x000053A5
		public void UnSerialize(BinaryReader r)
		{
			base.TypeId = (uint)r.ReadInt32();
			base.GroupId = r.ReadInt32();
			base.SecondInstanceId = r.ReadInt32();
			base.InstanceId = r.ReadInt32();
		}

		// Token: 0x060008F2 RID: 2290 RVA: 0x000071D7 File Offset: 0x000053D7
		public void Serialize(BinaryWriter w)
		{
			w.Write(base.TypeId);
			w.Write(base.GroupId);
			w.Write(base.SecondInstanceId);
			w.Write((uint)base.InstanceId);
		}

		// Token: 0x170002FB RID: 763
		// (get) Token: 0x060008F3 RID: 2291 RVA: 0x00007209 File Offset: 0x00005409
		// (set) Token: 0x060008F4 RID: 2292 RVA: 0x00007211 File Offset: 0x00005411
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

		// Token: 0x060008F5 RID: 2293 RVA: 0x0000721A File Offset: 0x0000541A
		public override bool Equals(object obj)
		{
			return obj != null && (this == obj || ((obj is ResKey || obj is TGIIndex) && base.Equals((ResKey)obj)));
		}

		// Token: 0x060008F6 RID: 2294 RVA: 0x00007245 File Offset: 0x00005445
		public override int GetHashCode()
		{
			return base.GetHashCode();
		}
	}
}
