using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;
using Package.SharedFiles;
using Sims3WorkshopSDK;

namespace Package.Sims3Files
{
	// Token: 0x02000018 RID: 24
	public class CASP : CASP
	{
		// Token: 0x17000045 RID: 69
		// (get) Token: 0x0600013C RID: 316 RVA: 0x00003901 File Offset: 0x00001B01
		// (set) Token: 0x0600013D RID: 317 RVA: 0x00003909 File Offset: 0x00001B09
		public uint resourceOffset { get; set; }

		// Token: 0x17000046 RID: 70
		// (get) Token: 0x0600013E RID: 318 RVA: 0x00003912 File Offset: 0x00001B12
		// (set) Token: 0x0600013F RID: 319 RVA: 0x0000391A File Offset: 0x00001B1A
		public List<XmlDocument> documents { get; set; }

		// Token: 0x17000047 RID: 71
		// (get) Token: 0x06000140 RID: 320 RVA: 0x00003923 File Offset: 0x00001B23
		// (set) Token: 0x06000141 RID: 321 RVA: 0x0000392B File Offset: 0x00001B2B
		public override uint ageFlags { get; set; }

		// Token: 0x17000048 RID: 72
		// (get) Token: 0x06000142 RID: 322 RVA: 0x00003934 File Offset: 0x00001B34
		// (set) Token: 0x06000143 RID: 323 RVA: 0x0000393C File Offset: 0x00001B3C
		public override uint clothingCategoryFlags { get; set; }

		// Token: 0x17000049 RID: 73
		// (get) Token: 0x06000144 RID: 324 RVA: 0x00003945 File Offset: 0x00001B45
		// (set) Token: 0x06000145 RID: 325 RVA: 0x0000394D File Offset: 0x00001B4D
		public override uint typeFlags { get; set; }

		// Token: 0x1700004A RID: 74
		// (get) Token: 0x06000146 RID: 326 RVA: 0x00003956 File Offset: 0x00001B56
		// (set) Token: 0x06000147 RID: 327 RVA: 0x0000395E File Offset: 0x00001B5E
		public override uint version { get; set; }

		// Token: 0x1700004B RID: 75
		// (get) Token: 0x06000148 RID: 328 RVA: 0x00003967 File Offset: 0x00001B67
		// (set) Token: 0x06000149 RID: 329 RVA: 0x0000396F File Offset: 0x00001B6F
		public override string str1 { get; set; }

		// Token: 0x1700004C RID: 76
		// (get) Token: 0x0600014A RID: 330 RVA: 0x00003978 File Offset: 0x00001B78
		// (set) Token: 0x0600014B RID: 331 RVA: 0x00003980 File Offset: 0x00001B80
		public uint clothingType { get; set; }

		// Token: 0x1700004D RID: 77
		// (get) Token: 0x0600014C RID: 332 RVA: 0x00003989 File Offset: 0x00001B89
		// (set) Token: 0x0600014D RID: 333 RVA: 0x00003991 File Offset: 0x00001B91
		public uint unkDWord3 { get; set; }

		// Token: 0x1700004E RID: 78
		// (get) Token: 0x0600014E RID: 334 RVA: 0x0000399A File Offset: 0x00001B9A
		// (set) Token: 0x0600014F RID: 335 RVA: 0x000039A2 File Offset: 0x00001BA2
		public byte unkByte1 { get; set; }

		// Token: 0x1700004F RID: 79
		// (get) Token: 0x06000150 RID: 336 RVA: 0x000039AB File Offset: 0x00001BAB
		// (set) Token: 0x06000151 RID: 337 RVA: 0x000039B3 File Offset: 0x00001BB3
		public byte unkByte2 { get; set; }

		// Token: 0x17000050 RID: 80
		// (get) Token: 0x06000152 RID: 338 RVA: 0x000039BC File Offset: 0x00001BBC
		// (set) Token: 0x06000153 RID: 339 RVA: 0x000039C4 File Offset: 0x00001BC4
		public float sortPriority { get; set; }

		// Token: 0x17000051 RID: 81
		// (get) Token: 0x06000154 RID: 340 RVA: 0x000039CD File Offset: 0x00001BCD
		// (set) Token: 0x06000155 RID: 341 RVA: 0x000039D5 File Offset: 0x00001BD5
		public float unkFloat2 { get; set; }

		// Token: 0x17000052 RID: 82
		// (get) Token: 0x06000156 RID: 342 RVA: 0x000039DE File Offset: 0x00001BDE
		// (set) Token: 0x06000157 RID: 343 RVA: 0x000039E6 File Offset: 0x00001BE6
		public byte partDataRef1 { get; set; }

		// Token: 0x17000053 RID: 83
		// (get) Token: 0x06000158 RID: 344 RVA: 0x000039EF File Offset: 0x00001BEF
		// (set) Token: 0x06000159 RID: 345 RVA: 0x000039F7 File Offset: 0x00001BF7
		public byte partDataRef2 { get; set; }

		// Token: 0x17000054 RID: 84
		// (get) Token: 0x0600015A RID: 346 RVA: 0x00003A00 File Offset: 0x00001C00
		// (set) Token: 0x0600015B RID: 347 RVA: 0x00003A08 File Offset: 0x00001C08
		public byte blendFatRef { get; set; }

		// Token: 0x17000055 RID: 85
		// (get) Token: 0x0600015C RID: 348 RVA: 0x00003A11 File Offset: 0x00001C11
		// (set) Token: 0x0600015D RID: 349 RVA: 0x00003A19 File Offset: 0x00001C19
		public byte blendThinRef { get; set; }

		// Token: 0x17000056 RID: 86
		// (get) Token: 0x0600015E RID: 350 RVA: 0x00003A22 File Offset: 0x00001C22
		// (set) Token: 0x0600015F RID: 351 RVA: 0x00003A2A File Offset: 0x00001C2A
		public byte blendFitRef { get; set; }

		// Token: 0x17000057 RID: 87
		// (get) Token: 0x06000160 RID: 352 RVA: 0x00003A33 File Offset: 0x00001C33
		// (set) Token: 0x06000161 RID: 353 RVA: 0x00003A3B File Offset: 0x00001C3B
		public byte blendSpecialRef { get; set; }

		// Token: 0x17000058 RID: 88
		// (get) Token: 0x06000162 RID: 354 RVA: 0x00003A44 File Offset: 0x00001C44
		// (set) Token: 0x06000163 RID: 355 RVA: 0x00003A4C File Offset: 0x00001C4C
		public byte hasVPXY { get; set; }

		// Token: 0x17000059 RID: 89
		// (get) Token: 0x06000164 RID: 356 RVA: 0x00003A55 File Offset: 0x00001C55
		// (set) Token: 0x06000165 RID: 357 RVA: 0x00003A5D File Offset: 0x00001C5D
		public byte vpxyIndex { get; set; }

		// Token: 0x1700005A RID: 90
		// (get) Token: 0x06000166 RID: 358 RVA: 0x00003A66 File Offset: 0x00001C66
		// (set) Token: 0x06000167 RID: 359 RVA: 0x00003A6E File Offset: 0x00001C6E
		public byte hasDiffuse { get; set; }

		// Token: 0x1700005B RID: 91
		// (get) Token: 0x06000168 RID: 360 RVA: 0x00003A77 File Offset: 0x00001C77
		// (set) Token: 0x06000169 RID: 361 RVA: 0x00003A7F File Offset: 0x00001C7F
		public byte diffuseIndex { get; set; }

		// Token: 0x1700005C RID: 92
		// (get) Token: 0x0600016A RID: 362 RVA: 0x00003A88 File Offset: 0x00001C88
		// (set) Token: 0x0600016B RID: 363 RVA: 0x00003A90 File Offset: 0x00001C90
		public byte hasSpecular { get; set; }

		// Token: 0x1700005D RID: 93
		// (get) Token: 0x0600016C RID: 364 RVA: 0x00003A99 File Offset: 0x00001C99
		// (set) Token: 0x0600016D RID: 365 RVA: 0x00003AA1 File Offset: 0x00001CA1
		public byte specularIndex { get; set; }

		// Token: 0x1700005E RID: 94
		// (get) Token: 0x0600016E RID: 366 RVA: 0x00003AAA File Offset: 0x00001CAA
		// (set) Token: 0x0600016F RID: 367 RVA: 0x00003AB2 File Offset: 0x00001CB2
		public byte[] propIndex1 { get; set; }

		// Token: 0x1700005F RID: 95
		// (get) Token: 0x06000170 RID: 368 RVA: 0x00003ABB File Offset: 0x00001CBB
		// (set) Token: 0x06000171 RID: 369 RVA: 0x00003AC3 File Offset: 0x00001CC3
		public byte[] propIndex2 { get; set; }

		// Token: 0x17000060 RID: 96
		// (get) Token: 0x06000172 RID: 370 RVA: 0x00003ACC File Offset: 0x00001CCC
		// (set) Token: 0x06000173 RID: 371 RVA: 0x00003AD4 File Offset: 0x00001CD4
		public byte[] boneDeltaIndex { get; set; }

		// Token: 0x17000061 RID: 97
		// (get) Token: 0x06000174 RID: 372 RVA: 0x00003ADD File Offset: 0x00001CDD
		// (set) Token: 0x06000175 RID: 373 RVA: 0x00003AE5 File Offset: 0x00001CE5
		public List<IGTIndex> igtIndex { get; set; }

		// Token: 0x17000062 RID: 98
		// (get) Token: 0x06000176 RID: 374 RVA: 0x00003AEE File Offset: 0x00001CEE
		// (set) Token: 0x06000177 RID: 375 RVA: 0x00003AF6 File Offset: 0x00001CF6
		public string str2 { get; set; }

		// Token: 0x17000063 RID: 99
		// (get) Token: 0x06000178 RID: 376 RVA: 0x00003AFF File Offset: 0x00001CFF
		// (set) Token: 0x06000179 RID: 377 RVA: 0x00003B07 File Offset: 0x00001D07
		public List<CASP.LoopItem> items { get; set; }

		// Token: 0x17000064 RID: 100
		// (get) Token: 0x0600017A RID: 378 RVA: 0x00003B10 File Offset: 0x00001D10
		// (set) Token: 0x0600017B RID: 379 RVA: 0x00003B18 File Offset: 0x00001D18
		public byte[] sims4Indicies { get; set; }

		// Token: 0x17000065 RID: 101
		// (get) Token: 0x0600017C RID: 380 RVA: 0x00003B21 File Offset: 0x00001D21
		// (set) Token: 0x0600017D RID: 381 RVA: 0x00003B29 File Offset: 0x00001D29
		public byte[] sims4Data1 { get; set; }

		// Token: 0x17000066 RID: 102
		// (get) Token: 0x0600017E RID: 382 RVA: 0x00003B32 File Offset: 0x00001D32
		// (set) Token: 0x0600017F RID: 383 RVA: 0x00003B3A File Offset: 0x00001D3A
		public byte[] sims4Data2 { get; set; }

		// Token: 0x17000067 RID: 103
		// (get) Token: 0x06000180 RID: 384 RVA: 0x00003B43 File Offset: 0x00001D43
		// (set) Token: 0x06000181 RID: 385 RVA: 0x00003B4B File Offset: 0x00001D4B
		public byte[] sims4Data3 { get; set; }

		// Token: 0x17000068 RID: 104
		// (get) Token: 0x06000182 RID: 386 RVA: 0x00003B54 File Offset: 0x00001D54
		// (set) Token: 0x06000183 RID: 387 RVA: 0x00003B5C File Offset: 0x00001D5C
		public CASP.Sims4Flag[] Sims4Flags { get; set; }

		// Token: 0x17000069 RID: 105
		// (get) Token: 0x06000184 RID: 388 RVA: 0x00003B65 File Offset: 0x00001D65
		// (set) Token: 0x06000185 RID: 389 RVA: 0x00003B6D File Offset: 0x00001D6D
		public uint[] Sims4OutfitColors { get; set; }

		// Token: 0x1700006A RID: 106
		// (get) Token: 0x06000186 RID: 390 RVA: 0x00003B76 File Offset: 0x00001D76
		// (set) Token: 0x06000187 RID: 391 RVA: 0x00003B7E File Offset: 0x00001D7E
		public short unkShort1 { get; set; }

		// Token: 0x1700006B RID: 107
		// (get) Token: 0x06000188 RID: 392 RVA: 0x00003B87 File Offset: 0x00001D87
		// (set) Token: 0x06000189 RID: 393 RVA: 0x00003B8F File Offset: 0x00001D8F
		public byte sims4ColorTextureIndex { get; set; }

		// Token: 0x1700006C RID: 108
		// (get) Token: 0x0600018A RID: 394 RVA: 0x00003B98 File Offset: 0x00001D98
		// (set) Token: 0x0600018B RID: 395 RVA: 0x00003BA0 File Offset: 0x00001DA0
		public byte sims4UnkByte1 { get; set; }

		// Token: 0x1700006D RID: 109
		// (get) Token: 0x0600018C RID: 396 RVA: 0x00003BA9 File Offset: 0x00001DA9
		// (set) Token: 0x0600018D RID: 397 RVA: 0x00003BB1 File Offset: 0x00001DB1
		public uint Sims4OutfitGroup { get; set; }

		// Token: 0x0600018E RID: 398 RVA: 0x00003BBA File Offset: 0x00001DBA
		public CASP()
		{
			this.typeId = 55242443U;
			this.documents = new List<XmlDocument>();
			this.igtIndex = new List<IGTIndex>();
			this.items = new List<CASP.LoopItem>();
		}

		// Token: 0x1700006E RID: 110
		// (get) Token: 0x0600018F RID: 399 RVA: 0x00003BEE File Offset: 0x00001DEE
		public List<XmlDocument> Documents
		{
			get
			{
				return this.documents;
			}
		}

		// Token: 0x06000190 RID: 400 RVA: 0x000124C0 File Offset: 0x000106C0
		public override void UnSerialize()
		{
			this.documents.Clear();
			this.igtIndex.Clear();
			this.items.Clear();
			this.clothingCategoryFlags = 0U;
			MemoryStream memoryStream = new MemoryStream(this.data);
			BinaryReader binaryReader = new BinaryReader(memoryStream);
			this.version = binaryReader.ReadUInt32();
			this.resourceOffset = binaryReader.ReadUInt32();
			UnicodeEncoding unicodeEncoding = new UnicodeEncoding();
			uint num = binaryReader.ReadUInt32();
			int num2 = 0;
			while ((long)num2 < (long)((ulong)num))
			{
				int num3 = binaryReader.ReadInt32();
				byte[] bytes = binaryReader.ReadBytes(num3 * 2);
				XmlDocument xmlDocument = new XmlDocument();
				xmlDocument.LoadXml(unicodeEncoding.GetString(bytes));
				binaryReader.ReadInt32();
				this.documents.Add(xmlDocument);
				num2++;
			}
			byte[] array = new byte[(int)binaryReader.ReadByte()];
			for (int i = 0; i < array.Length; i += 2)
			{
				array[i + 1] = binaryReader.ReadByte();
				array[i] = binaryReader.ReadByte();
			}
			this.str1 = unicodeEncoding.GetString(array);
			this.sortPriority = binaryReader.ReadSingle();
			this.unkByte1 = binaryReader.ReadByte();
			this.clothingType = binaryReader.ReadUInt32();
			this.typeFlags = binaryReader.ReadUInt32();
			this.ageFlags = binaryReader.ReadUInt32();
			this.clothingCategoryFlags = binaryReader.ReadUInt32();
			this.partDataRef1 = binaryReader.ReadByte();
			this.partDataRef2 = binaryReader.ReadByte();
			this.blendFatRef = binaryReader.ReadByte();
			this.blendFitRef = binaryReader.ReadByte();
			this.blendThinRef = binaryReader.ReadByte();
			this.blendSpecialRef = binaryReader.ReadByte();
			this.unkDWord3 = binaryReader.ReadUInt32();
			this.hasVPXY = binaryReader.ReadByte();
			if (this.hasVPXY > 0)
			{
				this.vpxyIndex = binaryReader.ReadByte();
			}
			byte b = binaryReader.ReadByte();
			for (int j = 0; j < (int)b; j++)
			{
				CASP.LoopItem loopItem = new CASP.LoopItem();
				loopItem.Unserialize(binaryReader);
				this.items.Add(loopItem);
			}
			this.hasDiffuse = binaryReader.ReadByte();
			if (this.hasDiffuse > 0)
			{
				this.diffuseIndex = binaryReader.ReadByte();
			}
			this.hasSpecular = binaryReader.ReadByte();
			if (this.hasSpecular > 0)
			{
				this.specularIndex = binaryReader.ReadByte();
			}
			this.propIndex1 = new byte[(int)binaryReader.ReadByte()];
			for (int k = 0; k < this.propIndex1.Length; k++)
			{
				this.propIndex1[k] = binaryReader.ReadByte();
			}
			this.propIndex2 = new byte[(int)binaryReader.ReadByte()];
			for (int l = 0; l < this.propIndex2.Length; l++)
			{
				this.propIndex2[l] = binaryReader.ReadByte();
			}
			this.boneDeltaIndex = new byte[(int)binaryReader.ReadByte()];
			for (int m = 0; m < this.boneDeltaIndex.Length; m++)
			{
				this.boneDeltaIndex[m] = binaryReader.ReadByte();
			}
			array = new byte[(int)binaryReader.ReadByte()];
			for (int n = 0; n < array.Length; n += 2)
			{
				array[n + 1] = binaryReader.ReadByte();
				array[n] = binaryReader.ReadByte();
			}
			this.str2 = unicodeEncoding.GetString(array);
			byte b2 = binaryReader.ReadByte();
			for (int num4 = 0; num4 < (int)b2; num4++)
			{
				IGTIndex igtindex = new IGTIndex();
				igtindex.UnSerialize(binaryReader);
				this.igtIndex.Add(igtindex);
			}
			memoryStream.Dispose();
			binaryReader.Close();
		}

		// Token: 0x06000191 RID: 401 RVA: 0x00012824 File Offset: 0x00010A24
		public override byte[] Serialize()
		{
			MemoryStream memoryStream = new MemoryStream();
			BinaryWriter binaryWriter = new BinaryWriter(memoryStream);
			UnicodeEncoding unicodeEncoding = new UnicodeEncoding();
			binaryWriter.Write(this.version);
			binaryWriter.Write(0U);
			binaryWriter.Write(this.documents.Count);
			int num = 1;
			foreach (XmlNode xmlNode in this.documents)
			{
				MemoryStream memoryStream2 = new MemoryStream();
				XmlTextWriter xmlTextWriter = new XmlTextWriter(memoryStream2, Encoding.Unicode);
				xmlNode.WriteTo(xmlTextWriter);
				xmlTextWriter.Flush();
				byte[] array = memoryStream2.ToArray();
				memoryStream2.Dispose();
				binaryWriter.Write((array.Length - 2) / 2);
				binaryWriter.Write(array, 2, array.Length - 2);
				binaryWriter.Write(num++);
			}
			byte[] bytes = unicodeEncoding.GetBytes(this.str1);
			binaryWriter.Write((byte)bytes.Length);
			for (int i = 0; i < bytes.Length; i += 2)
			{
				binaryWriter.Write(bytes[i + 1]);
				binaryWriter.Write(bytes[i]);
			}
			binaryWriter.Write(this.sortPriority);
			binaryWriter.Write(this.unkByte1);
			binaryWriter.Write(this.clothingType);
			binaryWriter.Write(this.typeFlags);
			binaryWriter.Write(this.ageFlags);
			binaryWriter.Write(this.clothingCategoryFlags);
			binaryWriter.Write(this.partDataRef1);
			binaryWriter.Write(this.partDataRef2);
			binaryWriter.Write(this.blendFatRef);
			binaryWriter.Write(this.blendFitRef);
			binaryWriter.Write(this.blendThinRef);
			binaryWriter.Write(this.blendSpecialRef);
			binaryWriter.Write(this.unkDWord3);
			binaryWriter.Write(this.hasVPXY);
			if (this.hasVPXY > 0)
			{
				binaryWriter.Write(this.vpxyIndex);
			}
			binaryWriter.Write((byte)this.items.Count);
			foreach (CASP.LoopItem loopItem in this.items)
			{
				loopItem.Serialize(binaryWriter);
			}
			binaryWriter.Write(this.hasDiffuse);
			if (this.hasDiffuse > 0)
			{
				binaryWriter.Write(this.diffuseIndex);
			}
			binaryWriter.Write(this.hasSpecular);
			if (this.hasSpecular > 0)
			{
				binaryWriter.Write(this.specularIndex);
			}
			binaryWriter.Write((byte)this.propIndex1.Length);
			for (int j = 0; j < this.propIndex1.Length; j++)
			{
				binaryWriter.Write(this.propIndex1[j]);
			}
			binaryWriter.Write((byte)this.propIndex2.Length);
			for (int k = 0; k < this.propIndex2.Length; k++)
			{
				binaryWriter.Write(this.propIndex2[k]);
			}
			binaryWriter.Write((byte)this.boneDeltaIndex.Length);
			for (int l = 0; l < this.boneDeltaIndex.Length; l++)
			{
				binaryWriter.Write(this.boneDeltaIndex[l]);
			}
			bytes = unicodeEncoding.GetBytes(this.str2);
			binaryWriter.Write((byte)bytes.Length);
			for (int m = 0; m < bytes.Length; m += 2)
			{
				binaryWriter.Write(bytes[m + 1]);
				binaryWriter.Write(bytes[m]);
			}
			int num2 = (int)binaryWriter.BaseStream.Position - 8;
			binaryWriter.Write((byte)this.igtIndex.Count);
			foreach (IGTIndex igtindex in this.igtIndex)
			{
				igtindex.Serialize(binaryWriter);
			}
			byte[] array2 = memoryStream.ToArray();
			array2[4] = (byte)(num2 & 255);
			array2[5] = (byte)(num2 >> 8 & 255);
			array2[6] = (byte)(num2 >> 16 & 255);
			array2[7] = (byte)(num2 >> 24 & 255);
			memoryStream.Dispose();
			binaryWriter.Close();
			return array2;
		}

		// Token: 0x06000192 RID: 402 RVA: 0x00012C30 File Offset: 0x00010E30
		public override List<CASP.AgeGender> GetAges()
		{
			List<CASP.AgeGender> list = new List<CASP.AgeGender>();
			if ((this.ageFlags & 1U) == 1U)
			{
				list.Add(CASP.AgeGender.Baby);
			}
			if ((this.ageFlags & 2U) == 2U)
			{
				list.Add(CASP.AgeGender.Toddler);
			}
			if ((this.ageFlags & 4U) == 4U)
			{
				list.Add(CASP.AgeGender.Child);
			}
			if ((this.ageFlags & 8U) == 8U)
			{
				list.Add(CASP.AgeGender.Teen);
			}
			if ((this.ageFlags & 16U) == 16U)
			{
				list.Add(CASP.AgeGender.YoungAdult);
			}
			if ((this.ageFlags & 32U) == 32U)
			{
				list.Add(CASP.AgeGender.Adult);
			}
			if ((this.ageFlags & 64U) == 64U)
			{
				list.Add(CASP.AgeGender.Elder);
			}
			return list;
		}

		// Token: 0x06000193 RID: 403 RVA: 0x00012CCC File Offset: 0x00010ECC
		public override List<CASP.AgeGender> GetGendres()
		{
			List<CASP.AgeGender> list = new List<CASP.AgeGender>();
			if ((this.ageFlags & 4096U) == 4096U)
			{
				list.Add(CASP.AgeGender.Male);
			}
			if ((this.ageFlags & 8192U) == 8192U)
			{
				list.Add(CASP.AgeGender.Female);
			}
			return list;
		}

		// Token: 0x06000194 RID: 404 RVA: 0x00012D1C File Offset: 0x00010F1C
		public override List<CASP.Species> GetSpecies()
		{
			List<CASP.Species> list = new List<CASP.Species>();
			if ((this.ageFlags & 52992U) == 0U || (this.ageFlags & 256U) == 256U)
			{
				list.Add(CASP.Species.Human);
			}
			if ((this.ageFlags & 768U) == 768U)
			{
				list.Add(CASP.Species.Cat);
			}
			if ((this.ageFlags & 1536U) == 1536U)
			{
				list.Add(CASP.Species.Deer);
			}
			if ((this.ageFlags & 1024U) == 1024U)
			{
				list.Add(CASP.Species.Dog);
			}
			if ((this.ageFlags & 512U) == 512U)
			{
				list.Add(CASP.Species.Horse);
			}
			if ((this.ageFlags & 2048U) == 2048U)
			{
				list.Add(CASP.Species.LargeBird);
			}
			if ((this.ageFlags & 1280U) == 1280U)
			{
				list.Add(CASP.Species.LittleDog);
			}
			if ((this.ageFlags & 1792U) == 1792U)
			{
				list.Add(CASP.Species.Raccoon);
			}
			if ((this.ageFlags & 2816U) == 2816U)
			{
				list.Add(CASP.Species.SimLeadingHorse);
			}
			if ((this.ageFlags & 2304U) == 2304U)
			{
				list.Add(CASP.Species.SimWalkingDog);
			}
			if ((this.ageFlags & 2560U) == 2560U)
			{
				list.Add(CASP.Species.SimWalkingLittleDog);
			}
			return list;
		}

		// Token: 0x06000195 RID: 405 RVA: 0x00012E88 File Offset: 0x00011088
		public override List<CASP.Type> GetTypes()
		{
			List<CASP.Type> list = new List<CASP.Type>();
			if ((this.typeFlags & 1U) == 1U)
			{
				list.Add(CASP.Type.Hair);
			}
			if ((this.typeFlags & 2U) == 2U)
			{
				list.Add(CASP.Type.Scalp);
			}
			if ((this.typeFlags & 4U) == 4U)
			{
				list.Add(CASP.Type.Face);
			}
			if ((this.typeFlags & 8U) == 8U)
			{
				list.Add(CASP.Type.Body);
			}
			if ((this.typeFlags & 16U) == 16U)
			{
				list.Add(CASP.Type.Accessory);
			}
			return list;
		}

		// Token: 0x06000196 RID: 406 RVA: 0x00012EFC File Offset: 0x000110FC
		public override List<uint> GetCategories()
		{
			List<uint> list = new List<uint>();
			if ((this.clothingCategoryFlags & 1U) == 1U)
			{
				list.Add(1U);
			}
			if ((this.clothingCategoryFlags & 2U) == 2U)
			{
				list.Add(2U);
			}
			if ((this.clothingCategoryFlags & 4U) == 4U)
			{
				list.Add(4U);
			}
			if ((this.clothingCategoryFlags & 8U) == 8U)
			{
				list.Add(8U);
			}
			if ((this.clothingCategoryFlags & 16U) == 16U)
			{
				list.Add(16U);
			}
			if ((this.clothingCategoryFlags & 32U) == 32U)
			{
				list.Add(32U);
			}
			if ((this.clothingCategoryFlags & 64U) == 64U)
			{
				list.Add(64U);
			}
			if ((this.clothingCategoryFlags & 256U) == 256U)
			{
				list.Add(256U);
			}
			if ((this.clothingCategoryFlags & 4194304U) == 4194304U)
			{
				list.Add(4194304U);
			}
			if ((this.clothingCategoryFlags & 16384U) == 16384U)
			{
				list.Add(16384U);
			}
			if ((this.clothingCategoryFlags & 65536U) == 65536U)
			{
				list.Add(65536U);
			}
			if ((this.clothingCategoryFlags & 8192U) == 8192U)
			{
				list.Add(8192U);
			}
			uint num = this.clothingCategoryFlags & 128U;
			if ((this.clothingCategoryFlags & 512U) == 512U)
			{
				list.Add(512U);
			}
			if ((this.clothingCategoryFlags & 262144U) == 262144U)
			{
				list.Add(262144U);
			}
			if ((this.clothingCategoryFlags & 4096U) == 4096U)
			{
				list.Add(4096U);
			}
			if ((this.clothingCategoryFlags & 524288U) == 524288U)
			{
				list.Add(524288U);
			}
			return list;
		}

		// Token: 0x06000197 RID: 407 RVA: 0x000130B4 File Offset: 0x000112B4
		public override int ReplaceReferences(ResKey from, ResKey to)
		{
			int num = 0;
			foreach (IGTIndex igtindex in this.igtIndex)
			{
				if (igtindex.Equals(from))
				{
					igtindex.SetFromResKey(to);
					num++;
				}
			}
			Regex regex = new Regex(from.AsString(), RegexOptions.Multiline);
			foreach (XmlDocument xmlDocument in this.documents)
			{
				string innerXml = xmlDocument.InnerXml;
				MatchCollection matchCollection = regex.Matches(innerXml);
				num += matchCollection.Count;
				if (matchCollection.Count > 0)
				{
					string innerXml2 = regex.Replace(innerXml, to.AsString());
					xmlDocument.InnerXml = innerXml2;
				}
			}
			return num;
		}

		// Token: 0x02000100 RID: 256
		public class LoopItem
		{
			// Token: 0x170003FD RID: 1021
			// (get) Token: 0x06000CB2 RID: 3250 RVA: 0x00008F85 File Offset: 0x00007185
			// (set) Token: 0x06000CB3 RID: 3251 RVA: 0x00008F8D File Offset: 0x0000718D
			public uint unkDWord { get; set; }

			// Token: 0x170003FE RID: 1022
			// (get) Token: 0x06000CB4 RID: 3252 RVA: 0x00008F96 File Offset: 0x00007196
			// (set) Token: 0x06000CB5 RID: 3253 RVA: 0x00008F9E File Offset: 0x0000719E
			public uint[,] items { get; set; }

			// Token: 0x170003FF RID: 1023
			// (get) Token: 0x06000CB6 RID: 3254 RVA: 0x00008FA7 File Offset: 0x000071A7
			// (set) Token: 0x06000CB7 RID: 3255 RVA: 0x00008FAF File Offset: 0x000071AF
			public byte repeatNum { get; set; }

			// Token: 0x06000CB8 RID: 3256 RVA: 0x0003DA2C File Offset: 0x0003BC2C
			public void Unserialize(BinaryReader r)
			{
				this.repeatNum = r.ReadByte();
				this.unkDWord = r.ReadUInt32();
				byte b = r.ReadByte();
				this.items = new uint[(int)b, 3];
				for (int i = 0; i < (int)b; i++)
				{
					this.items[i, 0] = r.ReadUInt32();
					this.items[i, 1] = r.ReadUInt32();
					this.items[i, 2] = r.ReadUInt32();
				}
			}

			// Token: 0x06000CB9 RID: 3257 RVA: 0x0003DAAC File Offset: 0x0003BCAC
			public void Serialize(BinaryWriter w)
			{
				w.Write(this.repeatNum);
				w.Write(this.unkDWord);
				w.Write((byte)(this.items.Length / 3));
				for (int i = 0; i < this.items.Length / 3; i++)
				{
					uint value = this.items[i, 0];
					uint value2 = this.items[i, 1];
					uint value3 = this.items[i, 2];
					w.Write(value);
					w.Write(value2);
					w.Write(value3);
				}
			}
		}
	}
}
