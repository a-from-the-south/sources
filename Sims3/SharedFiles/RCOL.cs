using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using Package.SharedFiles.InternalRCOL;
using Package.Sims3Files;
using Package.Sims4Files;
using Package.Sims4Files.InternalRCOL;
using Sims3WorkshopSDK;

namespace Package.SharedFiles
{
	// Token: 0x020000AD RID: 173
	public class RCOL : DBPFEntry
	{
		// Token: 0x170002E7 RID: 743
		// (get) Token: 0x060008AD RID: 2221 RVA: 0x00006FAF File Offset: 0x000051AF
		// (set) Token: 0x060008AE RID: 2222 RVA: 0x00006FB7 File Offset: 0x000051B7
		[TypeConverter(typeof(IntTypeConverter))]
		public int Version { get; set; }

		// Token: 0x170002E8 RID: 744
		// (get) Token: 0x060008AF RID: 2223 RVA: 0x00006FC0 File Offset: 0x000051C0
		// (set) Token: 0x060008B0 RID: 2224 RVA: 0x00006FC8 File Offset: 0x000051C8
		[TypeConverter(typeof(IntTypeConverter))]
		public int DataType { get; set; }

		// Token: 0x170002E9 RID: 745
		// (get) Token: 0x060008B1 RID: 2225 RVA: 0x00006FD1 File Offset: 0x000051D1
		// (set) Token: 0x060008B2 RID: 2226 RVA: 0x00006FD9 File Offset: 0x000051D9
		public int Index3count { get; set; }

		// Token: 0x170002EA RID: 746
		// (get) Token: 0x060008B3 RID: 2227 RVA: 0x00006FE2 File Offset: 0x000051E2
		public List<RCOLItem> Entries
		{
			get
			{
				return this.entries;
			}
		}

		// Token: 0x170002EB RID: 747
		// (get) Token: 0x060008B4 RID: 2228 RVA: 0x00006FEA File Offset: 0x000051EA
		public List<RCOLFileEntry> ExternalResources
		{
			get
			{
				return this.externalIndex;
			}
		}

		// Token: 0x170002EC RID: 748
		// (get) Token: 0x060008B5 RID: 2229 RVA: 0x00006FF2 File Offset: 0x000051F2
		[Browsable(false)]
		public List<RCOLFileEntry> InternalResources
		{
			get
			{
				return this.internalIndex;
			}
		}

		// Token: 0x060008B6 RID: 2230 RVA: 0x00006FFA File Offset: 0x000051FA
		public RCOL(DBPFType type)
		{
			this.typeId = type;
			this.entries = new List<RCOLItem>();
		}

		// Token: 0x060008B7 RID: 2231 RVA: 0x0002B50C File Offset: 0x0002970C
		public int AddEntry(RCOLItemType type, RCOLItem item)
		{
			Random random = new Random((int)DateTime.Now.Ticks);
			int instanceId = random.Next();
			int secondInstanceId = random.Next();
			return this.AddEntry(type, item, instanceId, secondInstanceId);
		}

		// Token: 0x060008B8 RID: 2232 RVA: 0x0002B544 File Offset: 0x00029744
		public int AddEntry(RCOLItemType type, RCOLItem item, int instanceId, int secondInstanceId)
		{
			RCOLFileEntry item2 = new RCOLFileEntry(type, instanceId, secondInstanceId, 0);
			this.internalIndex.Add(item2);
			this.entries.Add(item);
			return this.entries.Count - 1 - ((this.DataType == 2) ? 1 : 0);
		}

		// Token: 0x060008B9 RID: 2233 RVA: 0x0002B590 File Offset: 0x00029790
		public void RemoveEntry(RCOLItem item)
		{
			int index = this.entries.IndexOf(item);
			this.entries.RemoveAt(index);
			this.internalIndex.RemoveAt(index);
		}

		// Token: 0x060008BA RID: 2234 RVA: 0x00007014 File Offset: 0x00005214
		public RCOLItem GetItem(int index)
		{
			return this.entries[index];
		}

		// Token: 0x060008BB RID: 2235 RVA: 0x00007022 File Offset: 0x00005222
		public override void Dispose()
		{
			base.Dispose();
		}

		// Token: 0x170002ED RID: 749
		// (get) Token: 0x060008BC RID: 2236 RVA: 0x0000702A File Offset: 0x0000522A
		// (set) Token: 0x060008BD RID: 2237 RVA: 0x0002B5C4 File Offset: 0x000297C4
		public override int SecondInstanceID
		{
			get
			{
				return base.SecondInstanceID;
			}
			set
			{
				if (this.internalIndex != null)
				{
					foreach (RCOLFileEntry rcolfileEntry in this.internalIndex)
					{
						if ((this.InstanceID != 0 || this.secondInstanceId != 0) && rcolfileEntry.ResKey.InstanceId == this.InstanceID && rcolfileEntry.ResKey.SecondInstanceId == this.SecondInstanceID)
						{
							rcolfileEntry.ResKey.SecondInstanceId = value;
						}
					}
				}
				base.SecondInstanceID = value;
				if (this.internalIndex != null && this.internalIndex[0].TypeID == (RCOLItemType)this.typeId)
				{
					this.internalIndex[0].ResKey.SecondInstanceId = this.secondInstanceId;
				}
			}
		}

		// Token: 0x060008BE RID: 2238 RVA: 0x0002B6A0 File Offset: 0x000298A0
		public override int ReplaceReferences(ResKey from, ResKey to)
		{
			int num = 0;
			foreach (RCOLFileEntry rcolfileEntry in this.externalIndex)
			{
				if (rcolfileEntry.ResKey.Equals(from))
				{
					rcolfileEntry.ResKey.SetFromResKey(to);
					num++;
				}
			}
			foreach (RCOLFileEntry rcolfileEntry2 in this.internalIndex)
			{
				if (rcolfileEntry2.ResKey.Equals(from))
				{
					rcolfileEntry2.ResKey.SetFromResKey(to);
					num++;
				}
			}
			foreach (RCOLItem rcolitem in this.Entries)
			{
				num += rcolitem.ReplaceReferences(from, to);
			}
			return num;
		}

		// Token: 0x060008BF RID: 2239 RVA: 0x0002B7B4 File Offset: 0x000299B4
		public override List<ResKey> GetAllReferences()
		{
			List<ResKey> list = new List<ResKey>();
			foreach (RCOLFileEntry rcolfileEntry in this.externalIndex)
			{
				list.Add(rcolfileEntry.ResKey);
			}
			foreach (RCOLFileEntry rcolfileEntry2 in this.internalIndex)
			{
				list.Add(rcolfileEntry2.ResKey);
			}
			foreach (RCOLItem rcolitem in this.Entries)
			{
				if (rcolitem is VPXY)
				{
					using (List<TGIIndex>.Enumerator enumerator3 = ((VPXY)rcolitem).TGIIndex.GetEnumerator())
					{
						while (enumerator3.MoveNext())
						{
							TGIIndex item = enumerator3.Current;
							list.Add(item);
						}
						continue;
					}
				}
				if (rcolitem is MATD)
				{
					foreach (MATD.MATDEntry matdentry in ((MATD)rcolitem).Entries)
					{
					}
				}
			}
			return list;
		}

		// Token: 0x170002EE RID: 750
		// (get) Token: 0x060008C0 RID: 2240 RVA: 0x00007032 File Offset: 0x00005232
		// (set) Token: 0x060008C1 RID: 2241 RVA: 0x0002B944 File Offset: 0x00029B44
		public override int InstanceID
		{
			get
			{
				return base.InstanceID;
			}
			set
			{
				if (this.internalIndex != null)
				{
					foreach (RCOLFileEntry rcolfileEntry in this.internalIndex)
					{
						if ((this.InstanceID != 0 || this.secondInstanceId != 0) && rcolfileEntry.ResKey.InstanceId == this.InstanceID && rcolfileEntry.ResKey.SecondInstanceId == this.SecondInstanceID)
						{
							rcolfileEntry.ResKey.InstanceId = value;
						}
					}
				}
				base.InstanceID = value;
				if (this.internalIndex != null && this.internalIndex[0].TypeID == (RCOLItemType)this.typeId)
				{
					this.internalIndex[0].ResKey.InstanceId = this.instanceId;
				}
			}
		}

		// Token: 0x060008C2 RID: 2242 RVA: 0x0002BA20 File Offset: 0x00029C20
		public override object Clone()
		{
			RCOL rcol = base.Clone() as RCOL;
			Random random = new Random((int)DateTime.Now.Ticks);
			foreach (RCOLFileEntry rcolfileEntry in rcol.InternalResources)
			{
				if (rcolfileEntry.TypeID != (RCOLItemType)0U && (rcolfileEntry.ResKey.InstanceId != this.instanceId || rcolfileEntry.ResKey.SecondInstanceId != this.secondInstanceId))
				{
					rcolfileEntry.ResKey.Game = this.gameVersion;
					rcolfileEntry.ResKey.InstanceId = random.Next();
					rcolfileEntry.ResKey.SecondInstanceId = random.Next();
				}
			}
			rcol.gameVersion = this.gameVersion;
			if (rcol is MLODModel)
			{
				MLOD mlod = (this as MLODModel).Entries[0] as MLOD;
				MLOD mlod2 = (rcol as MLODModel).Entries[0] as MLOD;
				for (int i = 0; i < mlod.Entries.Count; i++)
				{
					for (int j = 0; j < mlod.Entries.Count; j++)
					{
						mlod2.Entries[j].Name = mlod.Entries[j].Name;
					}
				}
			}
			else
			{
				for (int k = 0; k < this.Entries.Count; k++)
				{
					RCOLItem rcolitem = this.Entries[k];
					RCOLItem rcolitem2 = rcol.Entries[k];
					if (rcolitem is MLOD)
					{
						MLOD mlod3 = rcolitem as MLOD;
						MLOD mlod4 = rcolitem2 as MLOD;
						for (int l = 0; l < mlod3.Entries.Count; l++)
						{
							mlod4.Entries[l].Name = mlod3.Entries[l].Name;
						}
					}
				}
			}
			return rcol;
		}

		// Token: 0x060008C3 RID: 2243 RVA: 0x0000703A File Offset: 0x0000523A
		public object Clone(bool reInstance)
		{
			return base.Clone();
		}

		// Token: 0x060008C4 RID: 2244 RVA: 0x0002BC38 File Offset: 0x00029E38
		public override byte[] Serialize()
		{
			MemoryStream memoryStream = new MemoryStream();
			BinaryWriter binaryWriter = new BinaryWriter(memoryStream);
			binaryWriter.Write(this.Version);
			binaryWriter.Write(this.DataType);
			binaryWriter.Write(this.Index3count);
			binaryWriter.Write(this.externalIndex.Count);
			binaryWriter.Write(this.internalIndex.Count);
			foreach (RCOLFileEntry rcolfileEntry in this.internalIndex)
			{
				rcolfileEntry.Serialize(binaryWriter);
			}
			foreach (RCOLFileEntry rcolfileEntry2 in this.externalIndex)
			{
				rcolfileEntry2.Serialize(binaryWriter);
			}
			int num = (int)(binaryWriter.BaseStream.Position + (long)(this.entries.Count * 8));
			foreach (RCOLItem rcolitem in this.entries)
			{
				binaryWriter.Write(num);
				MemoryStream memoryStream2 = new MemoryStream();
				BinaryWriter binaryWriter2 = new BinaryWriter(memoryStream2);
				rcolitem.Serialize(binaryWriter2);
				int num2 = (int)binaryWriter2.BaseStream.Length;
				binaryWriter.Write(num2);
				num += num2;
				binaryWriter2.Close();
				memoryStream2.Dispose();
			}
			foreach (RCOLItem rcolitem2 in this.entries)
			{
				long position = binaryWriter.BaseStream.Position;
				rcolitem2.Serialize(binaryWriter);
			}
			byte[] result = memoryStream.ToArray();
			memoryStream.Dispose();
			binaryWriter.Close();
			return result;
		}

		// Token: 0x060008C5 RID: 2245 RVA: 0x0002BE24 File Offset: 0x0002A024
		public override void UnSerialize()
		{
			this.entries.Clear();
			this.internalIndex = new List<RCOLFileEntry>();
			this.externalIndex = new List<RCOLFileEntry>();
			BinaryReader binaryReader = new BinaryReader(new MemoryStream(this.data));
			this.Version = binaryReader.ReadInt32();
			this.DataType = binaryReader.ReadInt32();
			this.Index3count = binaryReader.ReadInt32();
			int num = binaryReader.ReadInt32();
			int num2 = binaryReader.ReadInt32();
			for (int i = 0; i < num2; i++)
			{
				int secondInstanceId = binaryReader.ReadInt32();
				int instanceId = binaryReader.ReadInt32();
				RCOLItemType typeId = (RCOLItemType)binaryReader.ReadInt32();
				int groupId = binaryReader.ReadInt32();
				RCOLFileEntry item = new RCOLFileEntry(typeId, instanceId, secondInstanceId, groupId);
				this.internalIndex.Add(item);
			}
			for (int j = 0; j < num; j++)
			{
				int secondInstanceId2 = binaryReader.ReadInt32();
				int instanceId2 = binaryReader.ReadInt32();
				RCOLItemType typeId2 = (RCOLItemType)binaryReader.ReadInt32();
				int groupId2 = binaryReader.ReadInt32();
				RCOLFileEntry item2 = new RCOLFileEntry(typeId2, instanceId2, secondInstanceId2, groupId2);
				this.externalIndex.Add(item2);
			}
			foreach (RCOLFileEntry rcolfileEntry in this.internalIndex)
			{
				rcolfileEntry.offsetInFile = binaryReader.ReadUInt32();
				rcolfileEntry.fileSize = binaryReader.ReadInt32();
			}
			if (this.Version == 3)
			{
				this.internalIndex[0].offsetInFile = (uint)binaryReader.BaseStream.Position;
				this.internalIndex[0].fileSize = (int)(binaryReader.BaseStream.Length - (long)((ulong)this.internalIndex[0].offsetInFile));
			}
			foreach (RCOLFileEntry rcolfileEntry2 in this.internalIndex)
			{
				binaryReader.BaseStream.Position = (long)((ulong)rcolfileEntry2.offsetInFile);
				new string(new char[]
				{
					(char)binaryReader.ReadByte(),
					(char)binaryReader.ReadByte(),
					(char)binaryReader.ReadByte(),
					(char)binaryReader.ReadByte()
				});
				binaryReader.BaseStream.Position = (long)((ulong)rcolfileEntry2.offsetInFile);
				RCOLItemType rcolitemType = RCOLItemType.VDEC;
				if (rcolfileEntry2.TypeID == (RCOLItemType)0U)
				{
					uint num3 = binaryReader.ReadUInt32();
					if (num3 == 1297040711U)
					{
						rcolitemType = RCOLItemType.GEOM;
					}
					else if (num3 == 3548561239U)
					{
						rcolitemType = (RCOLItemType)3548561239U;
					}
					else if (num3 == 1414550598U)
					{
						rcolitemType = (RCOLItemType)3548561239U;
					}
				}
				binaryReader.BaseStream.Position = (long)((ulong)rcolfileEntry2.offsetInFile);
				rcolfileEntry2.data = binaryReader.ReadBytes(rcolfileEntry2.fileSize);
				RCOLItem rcolitem = null;
				RCOLItemType rcolitemType2 = (rcolfileEntry2.TypeID != (RCOLItemType)0U) ? rcolfileEntry2.TypeID : rcolitemType;
				if (rcolitemType2 <= RCOLItemType.MTST)
				{
					if (rcolitemType2 <= RCOLItemType.IBUF)
					{
						if (rcolitemType2 <= RCOLItemType.GEOM)
						{
							if (rcolitemType2 != RCOLItemType.VDEC)
							{
								if (rcolitemType2 != RCOLItemType.GEOM)
								{
									goto IL_46B;
								}
								rcolitem = new GEOM(this);
							}
							else
							{
								rcolitem = new VertexDeclaration();
							}
						}
						else if (rcolitemType2 != RCOLItemType.MODL)
						{
							if (rcolitemType2 == RCOLItemType.VBUF)
							{
								goto IL_3BE;
							}
							if (rcolitemType2 != RCOLItemType.IBUF)
							{
								goto IL_46B;
							}
							goto IL_3B2;
						}
						else
						{
							rcolitem = new MODL(this);
						}
					}
					else if (rcolitemType2 <= RCOLItemType.MATD)
					{
						if (rcolitemType2 != RCOLItemType.VRTF)
						{
							if (rcolitemType2 != RCOLItemType.MATD)
							{
								goto IL_46B;
							}
							rcolitem = new MATD(this);
						}
						else
						{
							rcolitem = new VRTF();
						}
					}
					else if (rcolitemType2 != RCOLItemType.SKIN)
					{
						if (rcolitemType2 != RCOLItemType.MLOD)
						{
							if (rcolitemType2 != RCOLItemType.MTST)
							{
								goto IL_46B;
							}
							rcolitem = new MTST();
						}
						else
						{
							rcolitem = new MLOD(this);
						}
					}
					else
					{
						rcolitem = new SKIN();
					}
				}
				else if (rcolitemType2 <= RCOLItemType.BOND)
				{
					if (rcolitemType2 <= RCOLItemType.IBUF2)
					{
						if (rcolitemType2 == RCOLItemType.VBUF2)
						{
							goto IL_3BE;
						}
						if (rcolitemType2 != RCOLItemType.IBUF2)
						{
							goto IL_46B;
						}
						goto IL_3B2;
					}
					else if (rcolitemType2 != RCOLItemType.S_SM)
					{
						if (rcolitemType2 != RCOLItemType.S_PLAY)
						{
							if (rcolitemType2 != RCOLItemType.BOND)
							{
								goto IL_46B;
							}
							rcolitem = new BONDEntry();
						}
						else
						{
							rcolitem = new S_Play();
						}
					}
					else
					{
						rcolitem = new S_SM();
					}
				}
				else if (rcolitemType2 <= (RCOLItemType)2887187436U)
				{
					if (rcolitemType2 != RCOLItemType.LITE)
					{
						if (rcolitemType2 != RCOLItemType.VPXY)
						{
							if (rcolitemType2 != (RCOLItemType)2887187436U)
							{
								goto IL_46B;
							}
							rcolitem = new VPXYTS4();
						}
						else
						{
							rcolitem = new VPXY();
						}
					}
					else
					{
						rcolitem = new LITE();
					}
				}
				else if (rcolitemType2 != (RCOLItemType)3321263678U)
				{
					if (rcolitemType2 != (RCOLItemType)3540272417U)
					{
						if (rcolitemType2 != (RCOLItemType)3548561239U)
						{
							goto IL_46B;
						}
						rcolitem = new FTPT(this);
					}
					else
					{
						rcolitem = new RSLT(this as RSLTResource);
					}
				}
				else
				{
					rcolitem = new SIMMOD();
				}
				IL_49A:
				BinaryReader reader = new BinaryReader(new MemoryStream(rcolfileEntry2.data));
				try
				{
					rcolitem.UnSerialize(reader);
					rcolitem.TypeName = rcolitemType2.ToString();
				}
				catch (Exception)
				{
				}
				this.entries.Add(rcolitem);
				continue;
				IL_3B2:
				rcolitem = new IBUF();
				goto IL_49A;
				IL_3BE:
				rcolitem = new VBUF(this);
				goto IL_49A;
				IL_46B:
				rcolitem = new UNKRCOLItem(this.typeId);
				goto IL_49A;
			}
		}

		// Token: 0x060008C6 RID: 2246 RVA: 0x0002C370 File Offset: 0x0002A570
		public override string ToString()
		{
			DBPFType typeId = this.typeId;
			return typeId.ToString() + " - " + base.ToString();
		}

		// Token: 0x04000439 RID: 1081
		protected List<RCOLItem> entries;

		// Token: 0x0400043A RID: 1082
		protected List<RCOLFileEntry> internalIndex;

		// Token: 0x0400043B RID: 1083
		protected List<RCOLFileEntry> externalIndex;

		// Token: 0x0400043C RID: 1084
		public OBJDDef ObjdDefRef;

		// Token: 0x0200019B RID: 411
		public class ExternalResource
		{
			// Token: 0x170004B8 RID: 1208
			// (get) Token: 0x06000F45 RID: 3909 RVA: 0x0000AA32 File Offset: 0x00008C32
			// (set) Token: 0x06000F46 RID: 3910 RVA: 0x0000AA3A File Offset: 0x00008C3A
			public DBPFType TypeId { get; set; }

			// Token: 0x170004B9 RID: 1209
			// (get) Token: 0x06000F47 RID: 3911 RVA: 0x0000AA43 File Offset: 0x00008C43
			// (set) Token: 0x06000F48 RID: 3912 RVA: 0x0000AA4B File Offset: 0x00008C4B
			[TypeConverter(typeof(IntTypeConverter))]
			public uint GroupId { get; set; }

			// Token: 0x170004BA RID: 1210
			// (get) Token: 0x06000F49 RID: 3913 RVA: 0x0000AA54 File Offset: 0x00008C54
			// (set) Token: 0x06000F4A RID: 3914 RVA: 0x0000AA5C File Offset: 0x00008C5C
			[TypeConverter(typeof(IntTypeConverter))]
			public uint InstanceId { get; set; }

			// Token: 0x170004BB RID: 1211
			// (get) Token: 0x06000F4B RID: 3915 RVA: 0x0000AA65 File Offset: 0x00008C65
			// (set) Token: 0x06000F4C RID: 3916 RVA: 0x0000AA6D File Offset: 0x00008C6D
			[TypeConverter(typeof(IntTypeConverter))]
			public uint SecondInstanceId { get; set; }
		}
	}
}
