using System;
using System.IO;
using Sims3WorkshopSDK;

namespace Package.SharedFiles.InternalRCOL
{
	// Token: 0x020000CA RID: 202
	public class RCOLFileEntry
	{
		// Token: 0x06000AD6 RID: 2774 RVA: 0x0000807C File Offset: 0x0000627C
		public RCOLFileEntry(RCOLItemType typeId, int instanceId, int secondInstanceId, int groupId)
		{
			this._reskey = new ResKey((uint)typeId, groupId, instanceId, secondInstanceId);
		}

		// Token: 0x170003A3 RID: 931
		// (get) Token: 0x06000AD7 RID: 2775 RVA: 0x00008094 File Offset: 0x00006294
		// (set) Token: 0x06000AD8 RID: 2776 RVA: 0x000080A1 File Offset: 0x000062A1
		public RCOLItemType TypeID
		{
			get
			{
				return (RCOLItemType)this._reskey.TypeId;
			}
			set
			{
				this._reskey.Type = value;
			}
		}

		// Token: 0x06000AD9 RID: 2777 RVA: 0x000080AF File Offset: 0x000062AF
		public string GenerateReskey()
		{
			return this._reskey.AsString();
		}

		// Token: 0x170003A4 RID: 932
		// (get) Token: 0x06000ADA RID: 2778 RVA: 0x000080BC File Offset: 0x000062BC
		// (set) Token: 0x06000ADB RID: 2779 RVA: 0x000080C4 File Offset: 0x000062C4
		public ResKey ResKey
		{
			get
			{
				return this._reskey;
			}
			set
			{
				this._reskey = value;
			}
		}

		// Token: 0x06000ADC RID: 2780 RVA: 0x00034218 File Offset: 0x00032418
		public override string ToString()
		{
			if (this.data != null)
			{
				new string(new char[]
				{
					(char)this.data[0],
					(char)this.data[1],
					(char)this.data[2],
					(char)this.data[3]
				});
				return "0x" + ((uint)this.TypeID).ToString("X8");
			}
			return "External resource: " + this.TypeID.ToString();
		}

		// Token: 0x06000ADD RID: 2781 RVA: 0x000342A4 File Offset: 0x000324A4
		public void Serialize(BinaryWriter w)
		{
			w.Write(this._reskey.SecondInstanceId);
			w.Write(this._reskey.InstanceId);
			w.Write(this._reskey.TypeId);
			w.Write(this._reskey.GroupId);
		}

		// Token: 0x06000ADE RID: 2782 RVA: 0x000032EA File Offset: 0x000014EA
		public void Dispose()
		{
		}

		// Token: 0x0400053E RID: 1342
		private ResKey _reskey;

		// Token: 0x0400053F RID: 1343
		public uint offsetInFile;

		// Token: 0x04000540 RID: 1344
		public int fileSize;

		// Token: 0x04000541 RID: 1345
		public byte[] data;
	}
}
