using System;
using System.Collections.Generic;
using System.IO;
using Sims3WorkshopSDK;

namespace Package.Sims3Files
{
	// Token: 0x0200004E RID: 78
	public class TSRModel : DBPFEntry
	{
		// Token: 0x17000147 RID: 327
		// (get) Token: 0x060003F6 RID: 1014 RVA: 0x00004E84 File Offset: 0x00003084
		// (set) Token: 0x060003F7 RID: 1015 RVA: 0x00004E8C File Offset: 0x0000308C
		public List<TSRModel.TSRModelVertex> Vertices { get; set; }

		// Token: 0x17000148 RID: 328
		// (get) Token: 0x060003F8 RID: 1016 RVA: 0x00004E95 File Offset: 0x00003095
		// (set) Token: 0x060003F9 RID: 1017 RVA: 0x00004E9D File Offset: 0x0000309D
		public List<ushort> Indicies { get; set; }

		// Token: 0x17000149 RID: 329
		// (get) Token: 0x060003FA RID: 1018 RVA: 0x00004EA6 File Offset: 0x000030A6
		// (set) Token: 0x060003FB RID: 1019 RVA: 0x00004EAE File Offset: 0x000030AE
		public byte[] BitmapData { get; set; }

		// Token: 0x1700014A RID: 330
		// (get) Token: 0x060003FC RID: 1020 RVA: 0x00004EB7 File Offset: 0x000030B7
		// (set) Token: 0x060003FD RID: 1021 RVA: 0x00004EBF File Offset: 0x000030BF
		public int BitmapWidth { get; set; }

		// Token: 0x1700014B RID: 331
		// (get) Token: 0x060003FE RID: 1022 RVA: 0x00004EC8 File Offset: 0x000030C8
		// (set) Token: 0x060003FF RID: 1023 RVA: 0x00004ED0 File Offset: 0x000030D0
		public int BitmapHeight { get; set; }

		// Token: 0x06000400 RID: 1024 RVA: 0x00004ED9 File Offset: 0x000030D9
		public TSRModel()
		{
			this.typeId = 3219205114U;
			this.Vertices = new List<TSRModel.TSRModelVertex>();
			this.Indicies = new List<ushort>();
		}

		// Token: 0x06000401 RID: 1025 RVA: 0x00003309 File Offset: 0x00001509
		public override int ReplaceReferences(ResKey from, ResKey to)
		{
			return 0;
		}

		// Token: 0x06000402 RID: 1026 RVA: 0x0001ABAC File Offset: 0x00018DAC
		public override void UnSerialize()
		{
			this.Indicies.Clear();
			this.Vertices.Clear();
			MemoryStream memoryStream = new MemoryStream(this.data);
			BinaryReader binaryReader = new BinaryReader(memoryStream);
			uint num = binaryReader.ReadUInt32();
			int num2 = 0;
			while ((long)num2 < (long)((ulong)num))
			{
				TSRModel.TSRModelVertex tsrmodelVertex = new TSRModel.TSRModelVertex();
				tsrmodelVertex.PositionX = binaryReader.ReadSingle();
				tsrmodelVertex.PositionY = binaryReader.ReadSingle();
				tsrmodelVertex.PositionZ = binaryReader.ReadSingle();
				tsrmodelVertex.NormalX = binaryReader.ReadSingle();
				tsrmodelVertex.NormalY = binaryReader.ReadSingle();
				tsrmodelVertex.NormalZ = binaryReader.ReadSingle();
				tsrmodelVertex.TextureX = binaryReader.ReadSingle();
				tsrmodelVertex.TextureY = binaryReader.ReadSingle();
				this.Vertices.Add(tsrmodelVertex);
				num2++;
			}
			uint num3 = binaryReader.ReadUInt32();
			int num4 = 0;
			while ((long)num4 < (long)((ulong)num3))
			{
				ushort item = binaryReader.ReadUInt16();
				this.Indicies.Add(item);
				num4++;
			}
			int count = binaryReader.ReadInt32();
			this.BitmapWidth = binaryReader.ReadInt32();
			this.BitmapHeight = binaryReader.ReadInt32();
			this.BitmapData = binaryReader.ReadBytes(count);
			memoryStream.Dispose();
			binaryReader.Close();
		}

		// Token: 0x06000403 RID: 1027 RVA: 0x0001ACE8 File Offset: 0x00018EE8
		public override byte[] Serialize()
		{
			MemoryStream memoryStream = new MemoryStream();
			BinaryWriter binaryWriter = new BinaryWriter(memoryStream);
			binaryWriter.Write(this.Vertices.Count);
			foreach (TSRModel.TSRModelVertex tsrmodelVertex in this.Vertices)
			{
				binaryWriter.Write(tsrmodelVertex.PositionX);
				binaryWriter.Write(tsrmodelVertex.PositionY);
				binaryWriter.Write(tsrmodelVertex.PositionZ);
				binaryWriter.Write(tsrmodelVertex.NormalX);
				binaryWriter.Write(tsrmodelVertex.NormalY);
				binaryWriter.Write(tsrmodelVertex.NormalZ);
				binaryWriter.Write(tsrmodelVertex.TextureX);
				binaryWriter.Write(tsrmodelVertex.TextureY);
			}
			binaryWriter.Write(this.Indicies.Count);
			foreach (ushort value in this.Indicies)
			{
				binaryWriter.Write(value);
			}
			binaryWriter.Write(this.BitmapData.Length);
			binaryWriter.Write(this.BitmapWidth);
			binaryWriter.Write(this.BitmapHeight);
			binaryWriter.Write(this.BitmapData);
			byte[] array = new byte[memoryStream.Length];
			memoryStream.Position = 0L;
			memoryStream.Read(array, 0, (int)memoryStream.Length);
			memoryStream.Dispose();
			binaryWriter.Close();
			return array;
		}

		// Token: 0x0200011D RID: 285
		public class TSRModelVertex
		{
			// Token: 0x04000744 RID: 1860
			public float PositionX;

			// Token: 0x04000745 RID: 1861
			public float PositionY;

			// Token: 0x04000746 RID: 1862
			public float PositionZ;

			// Token: 0x04000747 RID: 1863
			public float NormalX;

			// Token: 0x04000748 RID: 1864
			public float NormalY;

			// Token: 0x04000749 RID: 1865
			public float NormalZ;

			// Token: 0x0400074A RID: 1866
			public float TextureX;

			// Token: 0x0400074B RID: 1867
			public float TextureY;
		}
	}
}
