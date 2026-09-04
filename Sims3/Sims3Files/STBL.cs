using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Text;
using Package.Helper;
using Sims3WorkshopSDK;

namespace Package.Sims3Files
{
	// Token: 0x0200004A RID: 74
	public class STBL : DBPFEntry
	{
		// Token: 0x060003B0 RID: 944 RVA: 0x0001A07C File Offset: 0x0001827C
		public static void SaveStrings(DBPF package, Dictionary<ulong, string> entries, ResKey id)
		{
			byte b = 0;
			while ((int)b < STBL.Locales.Count)
			{
				int num = (int)(0 | b) << 24;
				List<ResKey> list = package.SearchEntries(new ResKey(570775514, 0, num, id.SecondInstanceId));
				STBL stbl;
				if (list.Count > 0)
				{
					stbl = (STBL)package.GetEntry(list[0]);
				}
				else
				{
					stbl = new STBL();
					stbl.instanceId = num;
					stbl.SecondInstanceID = id.SecondInstanceId;
					stbl.GroupID = id.GroupId;
				}
				foreach (KeyValuePair<ulong, string> keyValuePair in entries)
				{
					if (!stbl.HasEntry(keyValuePair.Key))
					{
						stbl.SetEntry(keyValuePair.Key, keyValuePair.Value);
					}
				}
				b += 1;
			}
		}

		// Token: 0x060003B1 RID: 945 RVA: 0x0001A168 File Offset: 0x00018368
		public static string[] GetLocalizedStrings(DBPF package, ulong guid, int instanceId)
		{
			string[] array = new string[23];
			uint[] array2 = new uint[]
			{
				0U,
				2147483648U
			};
			byte b = 0;
			while ((int)b < STBL.Locales.Count)
			{
				string text = null;
				int num = (int)(0 | b) << 24;
				foreach (uint num2 in array2)
				{
					List<ResKey> list = package.SearchEntries(new ResKey(570775514, (int)num2, num, instanceId), 1, true);
					if (list.Count > 0)
					{
						STBL stbl = (STBL)package.GetEntry(list[0]);
						foreach (KeyValuePair<ulong, STBL.STBLEntry> keyValuePair in stbl.Entries)
						{
							if (stbl.Version >= 5)
							{
								if ((keyValuePair.Value.Id & 4294967295UL) == guid)
								{
									text = keyValuePair.Value.Text;
								}
								else if (keyValuePair.Value.Id == guid)
								{
									text = keyValuePair.Value.Text;
								}
							}
						}
					}
					array[(int)b] = text;
					if (text != null)
					{
						break;
					}
				}
				b += 1;
			}
			return array;
		}

		// Token: 0x060003B2 RID: 946 RVA: 0x0001A2AC File Offset: 0x000184AC
		public static void RemoveStrings(DBPF package, ulong key, ResKey id)
		{
			foreach (ResKey key2 in package.SearchEntries(new ResKey(570775514, 0, 0, id.SecondInstanceId)))
			{
				STBL stbl = (STBL)package.GetEntry(key2);
				stbl.DeleteEntry(key);
				package.RemoveEntry(stbl);
			}
		}

		// Token: 0x060003B3 RID: 947 RVA: 0x00004CC1 File Offset: 0x00002EC1
		public void DeleteEntry(ulong key)
		{
			if (this.Entries.ContainsKey(key))
			{
				this.Entries.Remove(key);
			}
		}

		// Token: 0x060003B4 RID: 948 RVA: 0x00004CDE File Offset: 0x00002EDE
		public bool HasEntry(ulong key)
		{
			return this.Entries.ContainsKey(key) && this.Entries[key] != null;
		}

		// Token: 0x060003B5 RID: 949 RVA: 0x0001A328 File Offset: 0x00018528
		public void ChangeKey(ulong from, ulong to)
		{
			if (this.Entries.ContainsKey(from))
			{
				STBL.STBLEntry stblentry = this.Entries[from];
				this.Entries.Remove(from);
				this.Entries.Add(to, stblentry);
				stblentry.Id = to;
			}
		}

		// Token: 0x060003B6 RID: 950 RVA: 0x0001A374 File Offset: 0x00018574
		public void SetEntry(ulong key, string value)
		{
			if (this.Entries.ContainsKey(key))
			{
				this.Entries[key].Text = value;
			}
			else
			{
				this.Entries.Add(key, new STBL.STBLEntry((int)this.Version, key, value));
			}
			this.Count = (ulong)this.Entries.Count;
		}

		// Token: 0x17000131 RID: 305
		// (get) Token: 0x060003B7 RID: 951 RVA: 0x00004CFF File Offset: 0x00002EFF
		// (set) Token: 0x060003B8 RID: 952 RVA: 0x00004D07 File Offset: 0x00002F07
		public uint Type { get; set; }

		// Token: 0x17000132 RID: 306
		// (get) Token: 0x060003B9 RID: 953 RVA: 0x00004D10 File Offset: 0x00002F10
		// (set) Token: 0x060003BA RID: 954 RVA: 0x0001A3D0 File Offset: 0x000185D0
		public ushort Version
		{
			get
			{
				return this._version;
			}
			set
			{
				this._version = value;
				if (this.Entries != null)
				{
					foreach (STBL.STBLEntry stblentry in this.Entries.Values)
					{
						stblentry.stblVersion = (int)value;
					}
				}
			}
		}

		// Token: 0x17000133 RID: 307
		// (get) Token: 0x060003BB RID: 955 RVA: 0x00004D18 File Offset: 0x00002F18
		// (set) Token: 0x060003BC RID: 956 RVA: 0x00004D20 File Offset: 0x00002F20
		public byte Compressed { get; set; }

		// Token: 0x17000134 RID: 308
		// (get) Token: 0x060003BD RID: 957 RVA: 0x00004D29 File Offset: 0x00002F29
		// (set) Token: 0x060003BE RID: 958 RVA: 0x00004D31 File Offset: 0x00002F31
		public byte[] Reserved { get; set; }

		// Token: 0x17000135 RID: 309
		// (get) Token: 0x060003BF RID: 959 RVA: 0x00004D3A File Offset: 0x00002F3A
		// (set) Token: 0x060003C0 RID: 960 RVA: 0x00004D42 File Offset: 0x00002F42
		public ulong Count { get; set; }

		// Token: 0x17000136 RID: 310
		// (get) Token: 0x060003C1 RID: 961 RVA: 0x00004D4B File Offset: 0x00002F4B
		// (set) Token: 0x060003C2 RID: 962 RVA: 0x00004D53 File Offset: 0x00002F53
		public uint StrLen { get; set; }

		// Token: 0x17000137 RID: 311
		// (get) Token: 0x060003C3 RID: 963 RVA: 0x00004D5C File Offset: 0x00002F5C
		// (set) Token: 0x060003C4 RID: 964 RVA: 0x00004D64 File Offset: 0x00002F64
		public Dictionary<ulong, STBL.STBLEntry> Entries { get; set; }

		// Token: 0x060003C5 RID: 965 RVA: 0x0001A438 File Offset: 0x00018638
		public STBL()
		{
			this.TypeID = 570775514;
			this.Type = StringHelpers.ToFourCC("STBL");
			this.Version = 2;
			this.Count = 0UL;
			this.Entries = new Dictionary<ulong, STBL.STBLEntry>();
			this.Reserved = new byte[2];
		}

		// Token: 0x060003C6 RID: 966 RVA: 0x0001A494 File Offset: 0x00018694
		public override string ToString()
		{
			return string.Concat(new string[]
			{
				"Locale ",
				((long)this.InstanceID & 4278190080L).ToString(),
				", ",
				this.Count.ToString(),
				" entries"
			});
		}

		// Token: 0x060003C7 RID: 967 RVA: 0x00003309 File Offset: 0x00001509
		public override int ReplaceReferences(ResKey from, ResKey to)
		{
			return 0;
		}

		// Token: 0x060003C8 RID: 968 RVA: 0x0001A4F4 File Offset: 0x000186F4
		public override void UnSerialize()
		{
			if (this.data == null)
			{
				return;
			}
			MemoryStream memoryStream = new MemoryStream(this.data);
			BinaryReader binaryReader = new BinaryReader(memoryStream);
			this.Type = binaryReader.ReadUInt32();
			this.Version = binaryReader.ReadUInt16();
			this.Compressed = binaryReader.ReadByte();
			this.Count = binaryReader.ReadUInt64();
			this.Reserved = binaryReader.ReadBytes(2);
			if (this.Version >= 5)
			{
				this.StrLen = binaryReader.ReadUInt32();
			}
			this.Entries = new Dictionary<ulong, STBL.STBLEntry>((int)this.Count);
			for (ulong num = 0UL; num < this.Count; num += 1UL)
			{
				STBL.STBLEntry stblentry = new STBL.STBLEntry((int)this.Version);
				stblentry.UnSerialize(binaryReader);
				STBL.STBLEntry stblentry2 = null;
				if (this.Entries.TryGetValue(stblentry.Id, out stblentry2))
				{
					this.Entries.Remove(stblentry.Id);
				}
				this.Entries.Add(stblentry.Id, stblentry);
			}
			memoryStream.Dispose();
			binaryReader.Close();
		}

		// Token: 0x060003C9 RID: 969 RVA: 0x0001A600 File Offset: 0x00018800
		public override byte[] Serialize()
		{
			MemoryStream memoryStream = new MemoryStream();
			BinaryWriter binaryWriter = new BinaryWriter(memoryStream);
			binaryWriter.Write(this.Type);
			binaryWriter.Write(this.Version);
			binaryWriter.Write(this.Compressed);
			binaryWriter.Write((ulong)((long)this.Entries.Count));
			binaryWriter.Write(this.Reserved);
			MemoryStream memoryStream2 = new MemoryStream();
			BinaryWriter binaryWriter2 = new BinaryWriter(memoryStream2);
			foreach (STBL.STBLEntry stblentry in this.Entries.Values)
			{
				stblentry.Serialize(binaryWriter2);
			}
			if (this.Version >= 5)
			{
				binaryWriter.Write((int)binaryWriter2.BaseStream.Length);
			}
			byte[] buffer = memoryStream2.ToArray();
			binaryWriter.Write(buffer, 0, (int)memoryStream2.Length);
			byte[] result = memoryStream.ToArray();
			binaryWriter.Close();
			memoryStream.Dispose();
			return result;
		}

		// Token: 0x040001EC RID: 492
		public static OrderedDictionary Locales = new OrderedDictionary
		{
			{
				"en-US",
				"English"
			},
			{
				"zh-CN",
				"Chinese (cn)"
			},
			{
				"zh-TW",
				"Chinese (tw)"
			},
			{
				"cs-CZ",
				"Czech"
			},
			{
				"da-DK",
				"Danish"
			},
			{
				"nl-NL",
				"Dutch"
			},
			{
				"fi-FI",
				"Finnish"
			},
			{
				"fr-FR",
				"French"
			},
			{
				"de-DE",
				"German"
			},
			{
				"el-GR",
				"Greek"
			},
			{
				"hu-HU",
				"Hungarian"
			},
			{
				"it-IT",
				"Italian"
			},
			{
				"ja-JP",
				"Japanese"
			},
			{
				"ko-KR",
				"Korean"
			},
			{
				"no-NO",
				"Norwegian"
			},
			{
				"pl-PL",
				"Polish"
			},
			{
				"pt-PT",
				"Portugese (pt)"
			},
			{
				"pt-BR",
				"Portugese (br)"
			},
			{
				"ru-RU",
				"Russian"
			},
			{
				"es-ES",
				"Spanish (es)"
			},
			{
				"es-MX",
				"Spanish (mx)"
			},
			{
				"sv-SE",
				"Swedish"
			},
			{
				"th-TH",
				"Thai"
			}
		};

		// Token: 0x040001EE RID: 494
		private ushort _version;

		// Token: 0x02000119 RID: 281
		public class STBLEntry
		{
			// Token: 0x06000D4B RID: 3403 RVA: 0x00009451 File Offset: 0x00007651
			public STBLEntry(int version)
			{
				this.stblVersion = version;
			}

			// Token: 0x06000D4C RID: 3404 RVA: 0x00009460 File Offset: 0x00007660
			public STBLEntry(int version, ulong key, string value)
			{
				this.stblVersion = version;
				this.Id = key;
				this.Text = value;
			}

			// Token: 0x17000432 RID: 1074
			// (get) Token: 0x06000D4D RID: 3405 RVA: 0x0000947D File Offset: 0x0000767D
			// (set) Token: 0x06000D4E RID: 3406 RVA: 0x00009485 File Offset: 0x00007685
			public ulong Id { get; set; }

			// Token: 0x17000433 RID: 1075
			// (get) Token: 0x06000D4F RID: 3407 RVA: 0x0000948E File Offset: 0x0000768E
			// (set) Token: 0x06000D50 RID: 3408 RVA: 0x00009496 File Offset: 0x00007696
			public byte Flags { get; set; }

			// Token: 0x17000434 RID: 1076
			// (get) Token: 0x06000D51 RID: 3409 RVA: 0x0000949F File Offset: 0x0000769F
			// (set) Token: 0x06000D52 RID: 3410 RVA: 0x000094D5 File Offset: 0x000076D5
			public string Text
			{
				get
				{
					if (this._text == null)
					{
						return null;
					}
					if (this.stblVersion == 5)
					{
						return Encoding.UTF8.GetString(this._text);
					}
					return Encoding.Unicode.GetString(this._text);
				}
				set
				{
					if (value == null)
					{
						this._text = null;
						return;
					}
					if (this.stblVersion == 5)
					{
						this._text = Encoding.UTF8.GetBytes(value);
						return;
					}
					this._text = Encoding.Unicode.GetBytes(value);
				}
			}

			// Token: 0x06000D53 RID: 3411 RVA: 0x0003FDD0 File Offset: 0x0003DFD0
			public void UnSerialize(BinaryReader r)
			{
				this.Id = (ulong)((this.stblVersion >= 5) ? ((long)r.ReadInt32()) : ((long)r.ReadUInt64()));
				if (this.stblVersion >= 5)
				{
					this.Flags = r.ReadByte();
				}
				uint num = (this.stblVersion >= 5) ? ((uint)r.ReadUInt16()) : r.ReadUInt32();
				if (num == 0U)
				{
					return;
				}
				if (this.stblVersion >= 5)
				{
					this._text = r.ReadBytes((int)num);
					return;
				}
				this._text = r.ReadBytes((int)(num * 2U));
			}

			// Token: 0x06000D54 RID: 3412 RVA: 0x0003FE54 File Offset: 0x0003E054
			public void Serialize(BinaryWriter w)
			{
				if (this.stblVersion >= 5)
				{
					w.Write((uint)this.Id);
				}
				else
				{
					w.Write(this.Id);
				}
				if (this.stblVersion >= 5)
				{
					w.Write(this.Flags);
				}
				if (this._text == null)
				{
					if (this.stblVersion >= 5)
					{
						w.Write(0);
						return;
					}
					w.Write(0U);
					return;
				}
				else
				{
					if (this.stblVersion >= 5)
					{
						w.Write((ushort)this._text.Length);
						w.Write(this._text);
						return;
					}
					w.Write(this._text.Length / 2);
					w.Write(this._text);
					return;
				}
			}

			// Token: 0x06000D55 RID: 3413 RVA: 0x0000950E File Offset: 0x0000770E
			public override string ToString()
			{
				return this.Text;
			}

			// Token: 0x06000D56 RID: 3414 RVA: 0x00009516 File Offset: 0x00007716
			public STBL.STBLEntry Clone()
			{
				return new STBL.STBLEntry(this.stblVersion)
				{
					Id = this.Id,
					Flags = this.Flags,
					Text = this.Text
				};
			}

			// Token: 0x0400072D RID: 1837
			public int stblVersion;

			// Token: 0x04000730 RID: 1840
			private byte[] _text;
		}
	}
}
