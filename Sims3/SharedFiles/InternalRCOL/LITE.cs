using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using Sims3WorkshopSDK;

namespace Package.SharedFiles.InternalRCOL
{
	// Token: 0x020000BD RID: 189
	public class LITE : RCOLItem
	{
		// Token: 0x17000353 RID: 851
		// (get) Token: 0x060009DA RID: 2522 RVA: 0x00007981 File Offset: 0x00005B81
		// (set) Token: 0x060009DB RID: 2523 RVA: 0x00007989 File Offset: 0x00005B89
		[TypeConverter(typeof(IntTypeConverter))]
		public uint DWord { get; set; }

		// Token: 0x17000354 RID: 852
		// (get) Token: 0x060009DC RID: 2524 RVA: 0x00007992 File Offset: 0x00005B92
		// (set) Token: 0x060009DD RID: 2525 RVA: 0x0000799A File Offset: 0x00005B9A
		[TypeConverter(typeof(IntTypeConverter))]
		public uint Version { get; set; }

		// Token: 0x17000355 RID: 853
		// (get) Token: 0x060009DE RID: 2526 RVA: 0x000079A3 File Offset: 0x00005BA3
		// (set) Token: 0x060009DF RID: 2527 RVA: 0x000079AB File Offset: 0x00005BAB
		[TypeConverter(typeof(IntTypeConverter))]
		public uint DWord2 { get; set; }

		// Token: 0x17000356 RID: 854
		// (get) Token: 0x060009E0 RID: 2528 RVA: 0x000079B4 File Offset: 0x00005BB4
		// (set) Token: 0x060009E1 RID: 2529 RVA: 0x000079BC File Offset: 0x00005BBC
		[TypeConverter(typeof(IntTypeConverter))]
		public ushort Unknown { get; set; }

		// Token: 0x17000357 RID: 855
		// (get) Token: 0x060009E2 RID: 2530 RVA: 0x000079C5 File Offset: 0x00005BC5
		// (set) Token: 0x060009E3 RID: 2531 RVA: 0x000079CD File Offset: 0x00005BCD
		public List<LITE.LightEntry> Entries128 { get; set; }

		// Token: 0x17000358 RID: 856
		// (get) Token: 0x060009E4 RID: 2532 RVA: 0x000079D6 File Offset: 0x00005BD6
		// (set) Token: 0x060009E5 RID: 2533 RVA: 0x000079DE File Offset: 0x00005BDE
		public List<LITE.LightEntry> Entries56 { get; set; }

		// Token: 0x060009E6 RID: 2534 RVA: 0x000079E7 File Offset: 0x00005BE7
		public LITE()
		{
			this.Entries128 = new List<LITE.LightEntry>();
			this.Entries56 = new List<LITE.LightEntry>();
		}

		// Token: 0x060009E7 RID: 2535 RVA: 0x0002F4D0 File Offset: 0x0002D6D0
		public static LITE CreatePointLight()
		{
			LITE lite = new LITE();
			lite.DWord = 1163151692U;
			lite.Version = 4U;
			lite.DWord2 = 132U;
			lite.Unknown = 0;
			float[] array = new float[31];
			array[0] = 0f;
			array[1] = 0.40601f;
			array[2] = 0f;
			array[3] = 1f;
			array[4] = 0.9417815f;
			array[5] = 0.9120818f;
			array[6] = 45f;
			lite.Entries128.Add(new LITE.LightEntry(LITE.LightType.Point, array));
			return lite;
		}

		// Token: 0x060009E8 RID: 2536 RVA: 0x00007A05 File Offset: 0x00005C05
		public override string ToString()
		{
			return "LITE";
		}

		// Token: 0x060009E9 RID: 2537 RVA: 0x0002F558 File Offset: 0x0002D758
		public override void UnSerialize(BinaryReader r)
		{
			this.data = r.ReadBytes((int)r.BaseStream.Length);
			r.BaseStream.Position = 0L;
			this.Entries128.Clear();
			this.Entries56.Clear();
			this.DWord = r.ReadUInt32();
			this.Version = r.ReadUInt32();
			this.DWord2 = r.ReadUInt32();
			byte b = r.ReadByte();
			byte b2 = r.ReadByte();
			this.Unknown = r.ReadUInt16();
			for (int i = 0; i < (int)b; i++)
			{
				LITE.LightType type = (LITE.LightType)r.ReadUInt32();
				float[] array = new float[31];
				for (int j = 0; j < 31; j++)
				{
					array[j] = r.ReadSingle();
				}
				this.Entries128.Add(new LITE.LightEntry(type, array));
			}
			for (int k = 0; k < (int)b2; k++)
			{
				LITE.LightType type2 = (LITE.LightType)r.ReadUInt32();
				float[] array2 = new float[13];
				for (int l = 0; l < 13; l++)
				{
					array2[l] = r.ReadSingle();
				}
				this.Entries56.Add(new LITE.LightEntry(type2, array2));
			}
		}

		// Token: 0x060009EA RID: 2538 RVA: 0x0002F684 File Offset: 0x0002D884
		public override void Serialize(BinaryWriter w)
		{
			w.Write(this.DWord);
			w.Write(this.Version);
			w.Write(this.DWord2);
			w.Write((byte)this.Entries128.Count);
			w.Write((byte)this.Entries56.Count);
			w.Write(this.Unknown);
			foreach (LITE.LightEntry lightEntry in this.Entries128)
			{
				w.Write((uint)lightEntry.Type);
				foreach (float value in lightEntry.Floats)
				{
					w.Write(value);
				}
			}
			foreach (LITE.LightEntry lightEntry2 in this.Entries56)
			{
				w.Write((uint)lightEntry2.Type);
				foreach (float value2 in lightEntry2.Floats)
				{
					w.Write(value2);
				}
			}
		}

		// Token: 0x060009EB RID: 2539 RVA: 0x00003309 File Offset: 0x00001509
		public override int ReplaceReferences(ResKey from, ResKey to)
		{
			return 0;
		}

		// Token: 0x040004CA RID: 1226
		private byte[] data;

		// Token: 0x020001AD RID: 429
		public class LightEntry
		{
			// Token: 0x1700050B RID: 1291
			// (get) Token: 0x0600100E RID: 4110 RVA: 0x0000B160 File Offset: 0x00009360
			// (set) Token: 0x0600100F RID: 4111 RVA: 0x0000B168 File Offset: 0x00009368
			public LITE.LightType Type { get; set; }

			// Token: 0x1700050C RID: 1292
			// (get) Token: 0x06001010 RID: 4112 RVA: 0x0000B171 File Offset: 0x00009371
			// (set) Token: 0x06001011 RID: 4113 RVA: 0x0000B179 File Offset: 0x00009379
			public float[] Floats { get; set; }

			// Token: 0x06001012 RID: 4114 RVA: 0x0000B182 File Offset: 0x00009382
			public LightEntry(LITE.LightType type, float[] floats)
			{
				this.Floats = floats;
				this.Type = type;
			}

			// Token: 0x06001013 RID: 4115 RVA: 0x0000B198 File Offset: 0x00009398
			public override string ToString()
			{
				return "LITE Entry";
			}
		}

		// Token: 0x020001AE RID: 430
		public enum LightType : uint
		{
			// Token: 0x04000D0A RID: 3338
			Regular = 1U,
			// Token: 0x04000D0B RID: 3339
			Point = 3U,
			// Token: 0x04000D0C RID: 3340
			Spot,
			// Token: 0x04000D0D RID: 3341
			Type5,
			// Token: 0x04000D0E RID: 3342
			Window = 7U,
			// Token: 0x04000D0F RID: 3343
			Area = 9U,
			// Token: 0x04000D10 RID: 3344
			Type11 = 17U,
			// Token: 0x04000D11 RID: 3345
			TypeB = 11U
		}
	}
}
