using System;
using System.IO;
using Sims3WorkshopSDK;

namespace Package.SharedFiles
{
	// Token: 0x020000B2 RID: 178
	public class IGTIndex : ResKey
	{
		// Token: 0x060008F7 RID: 2295 RVA: 0x0000724D File Offset: 0x0000544D
		public void UnSerialize(BinaryReader r)
		{
			base.SecondInstanceId = r.ReadInt32();
			base.InstanceId = r.ReadInt32();
			base.GroupId = r.ReadInt32();
			base.TypeId = (uint)r.ReadInt32();
		}

		// Token: 0x060008F8 RID: 2296 RVA: 0x0000727F File Offset: 0x0000547F
		public void Serialize(BinaryWriter w)
		{
			w.Write(base.SecondInstanceId);
			w.Write(base.InstanceId);
			w.Write(base.GroupId);
			w.Write(base.TypeId);
		}

		// Token: 0x060008F9 RID: 2297 RVA: 0x00007185 File Offset: 0x00005385
		public IGTIndex()
		{
		}

		// Token: 0x060008FA RID: 2298 RVA: 0x0000718D File Offset: 0x0000538D
		public IGTIndex(string key) : base(key)
		{
		}

		// Token: 0x060008FB RID: 2299 RVA: 0x00007196 File Offset: 0x00005396
		public IGTIndex(ResKey reskey)
		{
			base.SetFromResKey(reskey);
		}

		// Token: 0x170002FC RID: 764
		// (get) Token: 0x060008FC RID: 2300 RVA: 0x00007209 File Offset: 0x00005409
		// (set) Token: 0x060008FD RID: 2301 RVA: 0x00007211 File Offset: 0x00005411
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
