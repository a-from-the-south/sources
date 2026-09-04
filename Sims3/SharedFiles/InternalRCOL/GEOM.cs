using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using Sims3WorkshopSDK;

namespace Package.SharedFiles.InternalRCOL
{
	// Token: 0x020000C8 RID: 200
	public class GEOM : RCOLItem
	{
		// Token: 0x1700037D RID: 893
		// (get) Token: 0x06000A7F RID: 2687 RVA: 0x00007DF8 File Offset: 0x00005FF8
		// (set) Token: 0x06000A80 RID: 2688 RVA: 0x00007E00 File Offset: 0x00006000
		public List<GEOM.VertexFormat> Format { get; set; }

		// Token: 0x1700037E RID: 894
		// (get) Token: 0x06000A81 RID: 2689 RVA: 0x00007E09 File Offset: 0x00006009
		// (set) Token: 0x06000A82 RID: 2690 RVA: 0x00007E11 File Offset: 0x00006011
		public List<GEOM.GEOMVertex> Vertices { get; set; }

		// Token: 0x1700037F RID: 895
		// (get) Token: 0x06000A83 RID: 2691 RVA: 0x00007E1A File Offset: 0x0000601A
		// (set) Token: 0x06000A84 RID: 2692 RVA: 0x00007E22 File Offset: 0x00006022
		public List<object> Faces { get; set; }

		// Token: 0x17000380 RID: 896
		// (get) Token: 0x06000A85 RID: 2693 RVA: 0x00007E2B File Offset: 0x0000602B
		// (set) Token: 0x06000A86 RID: 2694 RVA: 0x00007E33 File Offset: 0x00006033
		public List<uint> BoneHashes { get; set; }

		// Token: 0x17000381 RID: 897
		// (get) Token: 0x06000A87 RID: 2695 RVA: 0x00007E3C File Offset: 0x0000603C
		// (set) Token: 0x06000A88 RID: 2696 RVA: 0x00007E44 File Offset: 0x00006044
		public List<TGIIndex> TGIIndex { get; set; }

		// Token: 0x17000382 RID: 898
		// (get) Token: 0x06000A89 RID: 2697 RVA: 0x00007E4D File Offset: 0x0000604D
		// (set) Token: 0x06000A8A RID: 2698 RVA: 0x00007E55 File Offset: 0x00006055
		[TypeConverter(typeof(IntTypeConverter))]
		public MATD.MATDShader Shader { get; set; }

		// Token: 0x17000383 RID: 899
		// (get) Token: 0x06000A8B RID: 2699 RVA: 0x00007E5E File Offset: 0x0000605E
		// (set) Token: 0x06000A8C RID: 2700 RVA: 0x00007E66 File Offset: 0x00006066
		private byte[] dataChunk { get; set; }

		// Token: 0x17000384 RID: 900
		// (get) Token: 0x06000A8D RID: 2701 RVA: 0x00007E6F File Offset: 0x0000606F
		// (set) Token: 0x06000A8E RID: 2702 RVA: 0x00007E77 File Offset: 0x00006077
		[TypeConverter(typeof(IntTypeConverter))]
		public uint typeId { get; set; }

		// Token: 0x17000385 RID: 901
		// (get) Token: 0x06000A8F RID: 2703 RVA: 0x00007E80 File Offset: 0x00006080
		// (set) Token: 0x06000A90 RID: 2704 RVA: 0x00007E88 File Offset: 0x00006088
		[TypeConverter(typeof(IntTypeConverter))]
		public uint version { get; set; }

		// Token: 0x17000386 RID: 902
		// (get) Token: 0x06000A91 RID: 2705 RVA: 0x00007E91 File Offset: 0x00006091
		// (set) Token: 0x06000A92 RID: 2706 RVA: 0x00007E99 File Offset: 0x00006099
		[TypeConverter(typeof(IntTypeConverter))]
		public uint tailOffset { get; set; }

		// Token: 0x17000387 RID: 903
		// (get) Token: 0x06000A93 RID: 2707 RVA: 0x00007EA2 File Offset: 0x000060A2
		// (set) Token: 0x06000A94 RID: 2708 RVA: 0x00007EAA File Offset: 0x000060AA
		[TypeConverter(typeof(IntTypeConverter))]
		public uint tailSectionSize { get; set; }

		// Token: 0x17000388 RID: 904
		// (get) Token: 0x06000A95 RID: 2709 RVA: 0x00007EB3 File Offset: 0x000060B3
		// (set) Token: 0x06000A96 RID: 2710 RVA: 0x00007EBB File Offset: 0x000060BB
		[TypeConverter(typeof(IntTypeConverter))]
		public uint mergeGroup { get; set; }

		// Token: 0x17000389 RID: 905
		// (get) Token: 0x06000A97 RID: 2711 RVA: 0x00007EC4 File Offset: 0x000060C4
		// (set) Token: 0x06000A98 RID: 2712 RVA: 0x00007ECC File Offset: 0x000060CC
		[TypeConverter(typeof(IntTypeConverter))]
		public uint sortOrder { get; set; }

		// Token: 0x1700038A RID: 906
		// (get) Token: 0x06000A99 RID: 2713 RVA: 0x00007ED5 File Offset: 0x000060D5
		// (set) Token: 0x06000A9A RID: 2714 RVA: 0x00007EDD File Offset: 0x000060DD
		[TypeConverter(typeof(IntTypeConverter))]
		public uint itemCount { get; set; }

		// Token: 0x1700038B RID: 907
		// (get) Token: 0x06000A9B RID: 2715 RVA: 0x00007EE6 File Offset: 0x000060E6
		// (set) Token: 0x06000A9C RID: 2716 RVA: 0x00007EEE File Offset: 0x000060EE
		[TypeConverter(typeof(IntTypeConverter))]
		public byte bytesPerFacePoint { get; set; }

		// Token: 0x1700038C RID: 908
		// (get) Token: 0x06000A9D RID: 2717 RVA: 0x00007EF7 File Offset: 0x000060F7
		// (set) Token: 0x06000A9E RID: 2718 RVA: 0x00007EFF File Offset: 0x000060FF
		[TypeConverter(typeof(IntTypeConverter))]
		public uint skinControllerIndex { get; set; }

		// Token: 0x1700038D RID: 909
		// (get) Token: 0x06000A9F RID: 2719 RVA: 0x00007F08 File Offset: 0x00006108
		// (set) Token: 0x06000AA0 RID: 2720 RVA: 0x00007F10 File Offset: 0x00006110
		public RCOL Parent { get; set; }

		// Token: 0x1700038E RID: 910
		// (get) Token: 0x06000AA1 RID: 2721 RVA: 0x00007F19 File Offset: 0x00006119
		// (set) Token: 0x06000AA2 RID: 2722 RVA: 0x00007F21 File Offset: 0x00006121
		[TypeConverter(typeof(ExpandableObjectConverter))]
		public MATD.InternalMATD MATD { get; set; }

		// Token: 0x1700038F RID: 911
		// (get) Token: 0x06000AA3 RID: 2723 RVA: 0x00007F2A File Offset: 0x0000612A
		// (set) Token: 0x06000AA4 RID: 2724 RVA: 0x00007F32 File Offset: 0x00006132
		public List<GEOM.FloatData> FloatDataList { get; set; }

		// Token: 0x17000390 RID: 912
		// (get) Token: 0x06000AA5 RID: 2725 RVA: 0x00007F3B File Offset: 0x0000613B
		// (set) Token: 0x06000AA6 RID: 2726 RVA: 0x00007F43 File Offset: 0x00006143
		public List<GEOM.VertStitch> VertStitchData { get; set; }

		// Token: 0x17000391 RID: 913
		// (get) Token: 0x06000AA7 RID: 2727 RVA: 0x00007F4C File Offset: 0x0000614C
		// (set) Token: 0x06000AA8 RID: 2728 RVA: 0x00007F54 File Offset: 0x00006154
		public List<GEOM.SlotIntersection> Slotintersections { get; set; }

		// Token: 0x06000AA9 RID: 2729 RVA: 0x00007F5D File Offset: 0x0000615D
		public GEOM(RCOL parent)
		{
			this.Parent = parent;
		}

		// Token: 0x17000392 RID: 914
		// (get) Token: 0x06000AAA RID: 2730 RVA: 0x00032D98 File Offset: 0x00030F98
		public bool HasMorphData
		{
			get
			{
				bool result = false;
				using (List<GEOM.VertexFormat>.Enumerator enumerator = this.Format.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						if (enumerator.Current.Usage == GEOM.VertexUsage.VERTEX_ID)
						{
							result = true;
						}
					}
				}
				return result;
			}
		}

		// Token: 0x17000393 RID: 915
		// (get) Token: 0x06000AAB RID: 2731 RVA: 0x00032DF4 File Offset: 0x00030FF4
		public bool HasTangentData
		{
			get
			{
				bool result = false;
				using (List<GEOM.VertexFormat>.Enumerator enumerator = this.Format.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						if (enumerator.Current.Usage == GEOM.VertexUsage.TANGENT)
						{
							result = true;
						}
					}
				}
				return result;
			}
		}

		// Token: 0x06000AAC RID: 2732 RVA: 0x00032E50 File Offset: 0x00031050
		public override void UnSerialize(BinaryReader reader)
		{
			this.Vertices = new List<GEOM.GEOMVertex>();
			this.Format = new List<GEOM.VertexFormat>();
			this.Faces = new List<object>();
			this.BoneHashes = new List<uint>();
			this.TGIIndex = new List<TGIIndex>();
			this.FloatDataList = new List<GEOM.FloatData>();
			this.Slotintersections = new List<GEOM.SlotIntersection>();
			this.typeId = reader.ReadUInt32();
			this.version = reader.ReadUInt32();
			this.tailOffset = reader.ReadUInt32();
			this.tailSectionSize = reader.ReadUInt32();
			this.Shader = (MATD.MATDShader)reader.ReadUInt32();
			if (this.Shader != Package.SharedFiles.InternalRCOL.MATD.MATDShader.None)
			{
				int count = reader.ReadInt32();
				this.dataChunk = reader.ReadBytes(count);
				this.MATD = new MATD.InternalMATD(this);
				MemoryStream memoryStream = new MemoryStream(this.dataChunk);
				BinaryReader binaryReader = new BinaryReader(memoryStream);
				this.MATD.Unserialize(binaryReader);
				memoryStream.Dispose();
				binaryReader.Close();
			}
			this.mergeGroup = reader.ReadUInt32();
			this.sortOrder = reader.ReadUInt32();
			uint num = reader.ReadUInt32();
			uint num2 = reader.ReadUInt32();
			int num3 = 0;
			while ((long)num3 < (long)((ulong)num2))
			{
				GEOM.VertexFormat vertexFormat = new GEOM.VertexFormat();
				vertexFormat.Unserialize(reader);
				this.Format.Add(vertexFormat);
				num3++;
			}
			int num4 = 0;
			while ((long)num4 < (long)((ulong)num))
			{
				GEOM.GEOMVertex geomvertex = new GEOM.GEOMVertex(this.Format);
				geomvertex.Unserialize(reader);
				this.Vertices.Add(geomvertex);
				num4++;
			}
			this.itemCount = reader.ReadUInt32();
			this.bytesPerFacePoint = reader.ReadByte();
			uint num5 = reader.ReadUInt32();
			int num6 = 0;
			while ((long)num6 < (long)((ulong)num5))
			{
				switch (this.bytesPerFacePoint)
				{
				case 1:
					this.Faces.Add(reader.ReadByte());
					break;
				case 2:
					this.Faces.Add(reader.ReadInt16());
					break;
				case 3:
					this.Faces.Add(reader.ReadInt32());
					break;
				}
				num6++;
			}
			if (this.version >= 12U)
			{
				uint num7 = reader.ReadUInt32();
				int num8 = 0;
				while ((long)num8 < (long)((ulong)num7))
				{
					GEOM.FloatData floatData = new GEOM.FloatData();
					floatData.Unserialize(reader);
					this.FloatDataList.Add(floatData);
					num8++;
				}
				if (this.version >= 13U)
				{
					uint num9 = reader.ReadUInt32();
					this.VertStitchData = new List<GEOM.VertStitch>();
					int num10 = 0;
					while ((long)num10 < (long)((ulong)num9))
					{
						GEOM.VertStitch vertStitch = new GEOM.VertStitch();
						vertStitch.UnSerialize(reader);
						this.VertStitchData.Add(vertStitch);
						num10++;
					}
				}
				uint num11 = reader.ReadUInt32();
				int num12 = 0;
				while ((long)num12 < (long)((ulong)num11))
				{
					GEOM.SlotIntersection slotIntersection = new GEOM.SlotIntersection(this.version);
					slotIntersection.UnSerialize(reader);
					this.Slotintersections.Add(slotIntersection);
					num12++;
				}
			}
			else
			{
				this.skinControllerIndex = reader.ReadUInt32();
			}
			uint num13 = reader.ReadUInt32();
			int num14 = 0;
			while ((long)num14 < (long)((ulong)num13))
			{
				this.BoneHashes.Add(reader.ReadUInt32());
				num14++;
			}
			uint num15 = reader.ReadUInt32();
			int num16 = 0;
			while ((long)num16 < (long)((ulong)num15))
			{
				TGIIndex tgiindex = new TGIIndex();
				tgiindex.UnSerialize(reader);
				this.TGIIndex.Add(tgiindex);
				num16++;
			}
			long position = reader.BaseStream.Position;
			long length = reader.BaseStream.Length;
		}

		// Token: 0x06000AAD RID: 2733 RVA: 0x000331B0 File Offset: 0x000313B0
		public override void Serialize(BinaryWriter wr)
		{
			MemoryStream memoryStream = new MemoryStream();
			BinaryWriter binaryWriter = new BinaryWriter(memoryStream);
			binaryWriter.Write((uint)this.Shader);
			if (this.Shader != Package.SharedFiles.InternalRCOL.MATD.MATDShader.None)
			{
				MemoryStream memoryStream2 = new MemoryStream();
				BinaryWriter binaryWriter2 = new BinaryWriter(memoryStream2);
				this.MATD.Serialize(binaryWriter2);
				binaryWriter.Write((int)memoryStream2.Length);
				binaryWriter.Write(memoryStream2.ToArray());
				memoryStream2.Dispose();
				binaryWriter2.Close();
			}
			binaryWriter.Write(this.mergeGroup);
			binaryWriter.Write(this.sortOrder);
			binaryWriter.Write(this.Vertices.Count);
			binaryWriter.Write(this.Format.Count);
			foreach (GEOM.VertexFormat vertexFormat in this.Format)
			{
				vertexFormat.Serialize(binaryWriter);
			}
			foreach (GEOM.GEOMVertex geomvertex in this.Vertices)
			{
				geomvertex.Serialize(binaryWriter);
			}
			binaryWriter.Write(this.itemCount);
			binaryWriter.Write(this.bytesPerFacePoint);
			binaryWriter.Write(this.Faces.Count);
			foreach (object value in this.Faces)
			{
				switch (this.bytesPerFacePoint)
				{
				case 1:
					binaryWriter.Write(Convert.ToByte(value));
					break;
				case 2:
					binaryWriter.Write(Convert.ToInt16(value));
					break;
				case 3:
					binaryWriter.Write(Convert.ToInt32(value));
					break;
				}
			}
			if (this.version >= 12U)
			{
				binaryWriter.Write(this.FloatDataList.Count);
				foreach (GEOM.FloatData floatData in this.FloatDataList)
				{
					floatData.Serialize(binaryWriter);
				}
				if (this.version >= 13U)
				{
					binaryWriter.Write((uint)this.VertStitchData.Count);
					foreach (GEOM.VertStitch vertStitch in this.VertStitchData)
					{
						vertStitch.Serialize(binaryWriter);
					}
				}
				binaryWriter.Write(this.Slotintersections.Count);
				using (List<GEOM.SlotIntersection>.Enumerator enumerator6 = this.Slotintersections.GetEnumerator())
				{
					while (enumerator6.MoveNext())
					{
						GEOM.SlotIntersection slotIntersection = enumerator6.Current;
						slotIntersection.Serialize(binaryWriter);
					}
					goto IL_2A2;
				}
			}
			binaryWriter.Write(this.skinControllerIndex);
			IL_2A2:
			binaryWriter.Write(this.BoneHashes.Count);
			using (List<uint>.Enumerator enumerator7 = this.BoneHashes.GetEnumerator())
			{
				while (enumerator7.MoveNext())
				{
					int value2 = (int)enumerator7.Current;
					binaryWriter.Write(value2);
				}
			}
			binaryWriter.Write(this.TGIIndex.Count);
			this.tailOffset = (uint)binaryWriter.BaseStream.Position;
			wr.Write(this.typeId);
			wr.Write(this.version);
			wr.Write(this.tailOffset);
			wr.Write(this.tailSectionSize);
			foreach (TGIIndex tgiindex in this.TGIIndex)
			{
				tgiindex.Serialize(binaryWriter);
			}
			wr.Write(memoryStream.ToArray());
			binaryWriter.Close();
			memoryStream.Dispose();
		}

		// Token: 0x06000AAE RID: 2734 RVA: 0x000335B0 File Offset: 0x000317B0
		public override int ReplaceReferences(ResKey from, ResKey to)
		{
			int num = 0;
			foreach (TGIIndex tgiindex in this.TGIIndex)
			{
				if (tgiindex.Equals(from))
				{
					tgiindex.SetFromResKey(to);
					num++;
				}
			}
			return num;
		}

		// Token: 0x06000AAF RID: 2735 RVA: 0x00033614 File Offset: 0x00031814
		public override string ToString()
		{
			return this.Vertices.Count.ToString() + " vertices, " + (this.Faces.Count / 3).ToString() + " faces";
		}

		// Token: 0x020001B6 RID: 438
		public enum VertexUsage : uint
		{
			// Token: 0x04000D51 RID: 3409
			POSITION = 1U,
			// Token: 0x04000D52 RID: 3410
			NORMAL,
			// Token: 0x04000D53 RID: 3411
			UV,
			// Token: 0x04000D54 RID: 3412
			ASSIGNMENT,
			// Token: 0x04000D55 RID: 3413
			SKIN_WEIGHT,
			// Token: 0x04000D56 RID: 3414
			TANGENT,
			// Token: 0x04000D57 RID: 3415
			COLOR,
			// Token: 0x04000D58 RID: 3416
			VERTEX_ID = 10U
		}

		// Token: 0x020001B7 RID: 439
		public class VertexFormat
		{
			// Token: 0x17000539 RID: 1337
			// (get) Token: 0x0600107F RID: 4223 RVA: 0x0000B531 File Offset: 0x00009731
			// (set) Token: 0x06001080 RID: 4224 RVA: 0x0000B539 File Offset: 0x00009739
			[TypeConverter(typeof(IntTypeConverter))]
			public GEOM.VertexUsage Usage { get; set; }

			// Token: 0x1700053A RID: 1338
			// (get) Token: 0x06001081 RID: 4225 RVA: 0x0000B542 File Offset: 0x00009742
			// (set) Token: 0x06001082 RID: 4226 RVA: 0x0000B54A File Offset: 0x0000974A
			[TypeConverter(typeof(IntTypeConverter))]
			public int SubType { get; set; }

			// Token: 0x1700053B RID: 1339
			// (get) Token: 0x06001083 RID: 4227 RVA: 0x0000B553 File Offset: 0x00009753
			// (set) Token: 0x06001084 RID: 4228 RVA: 0x0000B55B File Offset: 0x0000975B
			[TypeConverter(typeof(IntTypeConverter))]
			public byte BytesPerElement { get; set; }

			// Token: 0x06001085 RID: 4229 RVA: 0x0000B564 File Offset: 0x00009764
			public void Unserialize(BinaryReader r)
			{
				this.Usage = (GEOM.VertexUsage)r.ReadInt32();
				this.SubType = r.ReadInt32();
				this.BytesPerElement = r.ReadByte();
			}

			// Token: 0x06001086 RID: 4230 RVA: 0x0000B58A File Offset: 0x0000978A
			public void Serialize(BinaryWriter w)
			{
				w.Write((uint)this.Usage);
				w.Write(this.SubType);
				w.Write(this.BytesPerElement);
			}
		}

		// Token: 0x020001B8 RID: 440
		public class VertStitch
		{
			// Token: 0x1700053C RID: 1340
			// (get) Token: 0x06001088 RID: 4232 RVA: 0x0000B5B0 File Offset: 0x000097B0
			// (set) Token: 0x06001089 RID: 4233 RVA: 0x0000B5B8 File Offset: 0x000097B8
			[TypeConverter(typeof(IntTypeConverter))]
			public uint Index { get; set; }

			// Token: 0x1700053D RID: 1341
			// (get) Token: 0x0600108A RID: 4234 RVA: 0x0000B5C1 File Offset: 0x000097C1
			// (set) Token: 0x0600108B RID: 4235 RVA: 0x0000B5C9 File Offset: 0x000097C9
			[TypeConverter(typeof(IntTypeConverter))]
			public ushort VertexID { get; set; }

			// Token: 0x0600108C RID: 4236 RVA: 0x0000B5D2 File Offset: 0x000097D2
			public void UnSerialize(BinaryReader r)
			{
				this.Index = r.ReadUInt32();
				this.VertexID = r.ReadUInt16();
			}

			// Token: 0x0600108D RID: 4237 RVA: 0x0000B5EC File Offset: 0x000097EC
			public void Serialize(BinaryWriter w)
			{
				w.Write(this.Index);
				w.Write(this.VertexID);
			}
		}

		// Token: 0x020001B9 RID: 441
		public class GEOMVertex : ICloneable
		{
			// Token: 0x1700053E RID: 1342
			// (get) Token: 0x0600108F RID: 4239 RVA: 0x0000B606 File Offset: 0x00009806
			// (set) Token: 0x06001090 RID: 4240 RVA: 0x0000B60E File Offset: 0x0000980E
			public List<GEOM.VertexFormat> format { get; set; }

			// Token: 0x1700053F RID: 1343
			// (get) Token: 0x06001091 RID: 4241 RVA: 0x0000B617 File Offset: 0x00009817
			// (set) Token: 0x06001092 RID: 4242 RVA: 0x0000B61F File Offset: 0x0000981F
			public float posX { get; set; }

			// Token: 0x17000540 RID: 1344
			// (get) Token: 0x06001093 RID: 4243 RVA: 0x0000B628 File Offset: 0x00009828
			// (set) Token: 0x06001094 RID: 4244 RVA: 0x0000B630 File Offset: 0x00009830
			public float posY { get; set; }

			// Token: 0x17000541 RID: 1345
			// (get) Token: 0x06001095 RID: 4245 RVA: 0x0000B639 File Offset: 0x00009839
			// (set) Token: 0x06001096 RID: 4246 RVA: 0x0000B641 File Offset: 0x00009841
			public float posZ { get; set; }

			// Token: 0x17000542 RID: 1346
			// (get) Token: 0x06001097 RID: 4247 RVA: 0x0000B64A File Offset: 0x0000984A
			// (set) Token: 0x06001098 RID: 4248 RVA: 0x0000B652 File Offset: 0x00009852
			public float norX { get; set; }

			// Token: 0x17000543 RID: 1347
			// (get) Token: 0x06001099 RID: 4249 RVA: 0x0000B65B File Offset: 0x0000985B
			// (set) Token: 0x0600109A RID: 4250 RVA: 0x0000B663 File Offset: 0x00009863
			public float norY { get; set; }

			// Token: 0x17000544 RID: 1348
			// (get) Token: 0x0600109B RID: 4251 RVA: 0x0000B66C File Offset: 0x0000986C
			// (set) Token: 0x0600109C RID: 4252 RVA: 0x0000B674 File Offset: 0x00009874
			public float norZ { get; set; }

			// Token: 0x17000545 RID: 1349
			// (get) Token: 0x0600109D RID: 4253 RVA: 0x0000B67D File Offset: 0x0000987D
			// (set) Token: 0x0600109E RID: 4254 RVA: 0x0000B685 File Offset: 0x00009885
			public List<float> tx { get; set; }

			// Token: 0x17000546 RID: 1350
			// (get) Token: 0x0600109F RID: 4255 RVA: 0x0000B68E File Offset: 0x0000988E
			// (set) Token: 0x060010A0 RID: 4256 RVA: 0x0000B696 File Offset: 0x00009896
			public List<float> ty { get; set; }

			// Token: 0x17000547 RID: 1351
			// (get) Token: 0x060010A1 RID: 4257 RVA: 0x0000B69F File Offset: 0x0000989F
			// (set) Token: 0x060010A2 RID: 4258 RVA: 0x0000B6A7 File Offset: 0x000098A7
			public byte[] boneAssignment { get; set; }

			// Token: 0x17000548 RID: 1352
			// (get) Token: 0x060010A3 RID: 4259 RVA: 0x0000B6B0 File Offset: 0x000098B0
			// (set) Token: 0x060010A4 RID: 4260 RVA: 0x0000B6B8 File Offset: 0x000098B8
			public float[] boneWeights { get; set; }

			// Token: 0x17000549 RID: 1353
			// (get) Token: 0x060010A5 RID: 4261 RVA: 0x0000B6C1 File Offset: 0x000098C1
			// (set) Token: 0x060010A6 RID: 4262 RVA: 0x0000B6C9 File Offset: 0x000098C9
			public float[] tangent { get; set; }

			// Token: 0x1700054A RID: 1354
			// (get) Token: 0x060010A7 RID: 4263 RVA: 0x0000B6D2 File Offset: 0x000098D2
			// (set) Token: 0x060010A8 RID: 4264 RVA: 0x0000B6DA File Offset: 0x000098DA
			public byte[] tagVal { get; set; }

			// Token: 0x1700054B RID: 1355
			// (get) Token: 0x060010A9 RID: 4265 RVA: 0x0000B6E3 File Offset: 0x000098E3
			// (set) Token: 0x060010AA RID: 4266 RVA: 0x0000B6EB File Offset: 0x000098EB
			[TypeConverter(typeof(IntTypeConverter))]
			public int vertexId { get; set; }

			// Token: 0x060010AB RID: 4267 RVA: 0x000450C8 File Offset: 0x000432C8
			public GEOMVertex(List<GEOM.VertexFormat> format)
			{
				this.format = format;
				this.tangent = new float[3];
				float[] array = new float[4];
				array[0] = 1f;
				this.boneWeights = array;
				this.boneAssignment = new byte[4];
				this.tagVal = new byte[4];
				this.tx = new List<float>();
				this.ty = new List<float>();
				this.tx.Add(0f);
				this.tx.Add(0f);
				this.ty.Add(0f);
				this.ty.Add(0f);
			}

			// Token: 0x060010AC RID: 4268 RVA: 0x00045170 File Offset: 0x00043370
			public void Serialize(BinaryWriter w)
			{
				int num = 0;
				foreach (GEOM.VertexFormat vertexFormat in this.format)
				{
					switch (vertexFormat.Usage)
					{
					case GEOM.VertexUsage.POSITION:
						w.Write(this.posX);
						w.Write(this.posY);
						w.Write(this.posZ);
						break;
					case GEOM.VertexUsage.NORMAL:
						w.Write(this.norX);
						w.Write(this.norY);
						w.Write(this.norZ);
						break;
					case GEOM.VertexUsage.UV:
						w.Write(this.tx[num]);
						w.Write(this.ty[num]);
						num++;
						break;
					case GEOM.VertexUsage.ASSIGNMENT:
						w.Write(this.boneAssignment);
						break;
					case GEOM.VertexUsage.SKIN_WEIGHT:
						if (vertexFormat.SubType == 2)
						{
							w.Write((byte)(this.boneWeights[0] * 255f));
							w.Write((byte)(this.boneWeights[1] * 255f));
							w.Write((byte)(this.boneWeights[2] * 255f));
							w.Write((byte)(this.boneWeights[3] * 255f));
						}
						else if (vertexFormat.SubType == 1)
						{
							w.Write(this.boneWeights[0]);
							w.Write(this.boneWeights[1]);
							w.Write(this.boneWeights[2]);
							w.Write(this.boneWeights[3]);
						}
						break;
					case GEOM.VertexUsage.TANGENT:
						w.Write(this.tangent[0]);
						w.Write(this.tangent[1]);
						w.Write(this.tangent[2]);
						break;
					case GEOM.VertexUsage.COLOR:
						w.Write(this.tagVal);
						break;
					case GEOM.VertexUsage.VERTEX_ID:
						w.Write(this.vertexId);
						break;
					}
				}
			}

			// Token: 0x060010AD RID: 4269 RVA: 0x0004538C File Offset: 0x0004358C
			public void Unserialize(BinaryReader r)
			{
				int num = 0;
				foreach (GEOM.VertexFormat vertexFormat in this.format)
				{
					switch (vertexFormat.Usage)
					{
					case GEOM.VertexUsage.POSITION:
						this.posX = r.ReadSingle();
						this.posY = r.ReadSingle();
						this.posZ = r.ReadSingle();
						break;
					case GEOM.VertexUsage.NORMAL:
						this.norX = r.ReadSingle();
						this.norY = r.ReadSingle();
						this.norZ = r.ReadSingle();
						break;
					case GEOM.VertexUsage.UV:
						if (this.tx.Count == num)
						{
							this.tx.Add(0f);
							this.ty.Add(0f);
						}
						this.tx[num] = r.ReadSingle();
						this.ty[num] = r.ReadSingle();
						num++;
						break;
					case GEOM.VertexUsage.ASSIGNMENT:
						this.boneAssignment = r.ReadBytes(4);
						break;
					case GEOM.VertexUsage.SKIN_WEIGHT:
						this.boneWeights = new float[4];
						if (vertexFormat.SubType == 2)
						{
							this.boneWeights[0] = (float)r.ReadByte() / 255f;
							this.boneWeights[1] = (float)r.ReadByte() / 255f;
							this.boneWeights[2] = (float)r.ReadByte() / 255f;
							this.boneWeights[3] = (float)r.ReadByte() / 255f;
						}
						if (vertexFormat.SubType == 1)
						{
							this.boneWeights[0] = r.ReadSingle();
							this.boneWeights[1] = r.ReadSingle();
							this.boneWeights[2] = r.ReadSingle();
							this.boneWeights[3] = r.ReadSingle();
						}
						break;
					case GEOM.VertexUsage.TANGENT:
						this.tangent = new float[3];
						this.tangent[0] = r.ReadSingle();
						this.tangent[1] = r.ReadSingle();
						this.tangent[2] = r.ReadSingle();
						break;
					case GEOM.VertexUsage.COLOR:
						this.tagVal = r.ReadBytes(4);
						break;
					case GEOM.VertexUsage.VERTEX_ID:
						this.vertexId = r.ReadInt32();
						break;
					}
				}
			}

			// Token: 0x060010AE RID: 4270 RVA: 0x000455EC File Offset: 0x000437EC
			public object Clone()
			{
				GEOM.GEOMVertex geomvertex = new GEOM.GEOMVertex(this.format);
				geomvertex.posX = this.posX;
				geomvertex.posY = this.posY;
				geomvertex.posZ = this.posZ;
				geomvertex.norX = this.norX;
				geomvertex.norY = this.norY;
				geomvertex.norZ = this.norZ;
				geomvertex.tx = new List<float>(this.tx);
				geomvertex.ty = new List<float>(this.ty);
				this.tagVal.CopyTo(geomvertex.tagVal, 0);
				this.boneWeights.CopyTo(geomvertex.boneWeights, 0);
				this.boneAssignment.CopyTo(geomvertex.boneAssignment, 0);
				geomvertex.vertexId = this.vertexId;
				return geomvertex;
			}

			// Token: 0x060010AF RID: 4271 RVA: 0x000456B4 File Offset: 0x000438B4
			public override bool Equals(object obj)
			{
				GEOM.GEOMVertex geomvertex = obj as GEOM.GEOMVertex;
				return geomvertex.posX == this.posX && geomvertex.posY == this.posY && geomvertex.posZ == this.posZ && geomvertex.norX == this.norX && geomvertex.norY == this.norY && geomvertex.norZ == this.norZ && geomvertex.tx[0] == this.tx[0] && geomvertex.ty[0] == this.ty[0] && geomvertex.tx[1] == this.tx[1] && geomvertex.ty[1] == this.ty[1] && geomvertex.vertexId == this.vertexId && geomvertex.tagVal[0] == this.tagVal[0] && geomvertex.tagVal[1] == this.tagVal[1] && geomvertex.tagVal[2] == this.tagVal[2] && geomvertex.tagVal[3] == this.tagVal[3] && geomvertex.boneAssignment[0] == this.boneAssignment[0] && geomvertex.boneAssignment[1] == this.boneAssignment[1] && geomvertex.boneAssignment[2] == this.boneAssignment[2] && geomvertex.boneAssignment[3] == this.boneAssignment[3] && geomvertex.boneWeights[0] == this.boneWeights[0] && geomvertex.boneWeights[1] == this.boneWeights[1] && geomvertex.boneWeights[2] == this.boneWeights[2] && geomvertex.boneWeights[3] == this.boneWeights[3];
			}

			// Token: 0x060010B0 RID: 4272 RVA: 0x0000B6F4 File Offset: 0x000098F4
			public override int GetHashCode()
			{
				return base.GetHashCode();
			}
		}

		// Token: 0x020001BA RID: 442
		public class FloatData
		{
			// Token: 0x1700054C RID: 1356
			// (get) Token: 0x060010B1 RID: 4273 RVA: 0x0000B6FC File Offset: 0x000098FC
			// (set) Token: 0x060010B2 RID: 4274 RVA: 0x0000B704 File Offset: 0x00009904
			[TypeConverter(typeof(IntTypeConverter))]
			public uint id { get; set; }

			// Token: 0x1700054D RID: 1357
			// (get) Token: 0x060010B3 RID: 4275 RVA: 0x0000B70D File Offset: 0x0000990D
			// (set) Token: 0x060010B4 RID: 4276 RVA: 0x0000B715 File Offset: 0x00009915
			[TypeConverter(typeof(IntTypeConverter))]
			public uint numFloats { get; set; }

			// Token: 0x1700054E RID: 1358
			// (get) Token: 0x060010B5 RID: 4277 RVA: 0x0000B71E File Offset: 0x0000991E
			// (set) Token: 0x060010B6 RID: 4278 RVA: 0x0000B726 File Offset: 0x00009926
			public List<float> data { get; set; }

			// Token: 0x060010B7 RID: 4279 RVA: 0x0004589C File Offset: 0x00043A9C
			public void Unserialize(BinaryReader r)
			{
				this.data = new List<float>();
				this.id = r.ReadUInt32();
				this.numFloats = r.ReadUInt32();
				int num = 0;
				while ((long)num < (long)((ulong)this.numFloats))
				{
					this.data.Add(r.ReadSingle());
					this.data.Add(r.ReadSingle());
					num++;
				}
			}

			// Token: 0x060010B8 RID: 4280 RVA: 0x00045904 File Offset: 0x00043B04
			public void Serialize(BinaryWriter w)
			{
				w.Write(this.id);
				w.Write(this.numFloats);
				int num = 0;
				while ((long)num < (long)((ulong)(this.numFloats * 2U)))
				{
					w.Write(this.data[num]);
					num++;
				}
			}
		}

		// Token: 0x020001BB RID: 443
		public class SlotIntersection
		{
			// Token: 0x1700054F RID: 1359
			// (get) Token: 0x060010BA RID: 4282 RVA: 0x0000B72F File Offset: 0x0000992F
			// (set) Token: 0x060010BB RID: 4283 RVA: 0x0000B737 File Offset: 0x00009937
			[TypeConverter(typeof(IntTypeConverter))]
			public uint slotindex { get; set; }

			// Token: 0x17000550 RID: 1360
			// (get) Token: 0x060010BC RID: 4284 RVA: 0x0000B740 File Offset: 0x00009940
			// (set) Token: 0x060010BD RID: 4285 RVA: 0x0000B748 File Offset: 0x00009948
			public ushort[] indices { get; set; }

			// Token: 0x17000551 RID: 1361
			// (get) Token: 0x060010BE RID: 4286 RVA: 0x0000B751 File Offset: 0x00009951
			// (set) Token: 0x060010BF RID: 4287 RVA: 0x0000B759 File Offset: 0x00009959
			public float[] coordinates { get; set; }

			// Token: 0x17000552 RID: 1362
			// (get) Token: 0x060010C0 RID: 4288 RVA: 0x0000B762 File Offset: 0x00009962
			// (set) Token: 0x060010C1 RID: 4289 RVA: 0x0000B76A File Offset: 0x0000996A
			public float distance { get; set; }

			// Token: 0x17000553 RID: 1363
			// (get) Token: 0x060010C2 RID: 4290 RVA: 0x0000B773 File Offset: 0x00009973
			// (set) Token: 0x060010C3 RID: 4291 RVA: 0x0000B77B File Offset: 0x0000997B
			public StreamVector3 mOffsetFromIntersectionOS { get; set; }

			// Token: 0x17000554 RID: 1364
			// (get) Token: 0x060010C4 RID: 4292 RVA: 0x0000B784 File Offset: 0x00009984
			// (set) Token: 0x060010C5 RID: 4293 RVA: 0x0000B78C File Offset: 0x0000998C
			public StreamVector3 mSlotAveragePosOS { get; set; }

			// Token: 0x17000555 RID: 1365
			// (get) Token: 0x060010C6 RID: 4294 RVA: 0x0000B795 File Offset: 0x00009995
			// (set) Token: 0x060010C7 RID: 4295 RVA: 0x0000B79D File Offset: 0x0000999D
			public StreamVector4 mTransformToLS { get; set; }

			// Token: 0x17000556 RID: 1366
			// (get) Token: 0x060010C8 RID: 4296 RVA: 0x0000B7A6 File Offset: 0x000099A6
			// (set) Token: 0x060010C9 RID: 4297 RVA: 0x0000B7AE File Offset: 0x000099AE
			[TypeConverter(typeof(IntTypeConverter))]
			public byte mPivotBoneIdx { get; set; }

			// Token: 0x060010CA RID: 4298 RVA: 0x0000B7B7 File Offset: 0x000099B7
			public SlotIntersection(uint parentVersion)
			{
				this.indices = new ushort[3];
				this.parentVersion = parentVersion;
			}

			// Token: 0x060010CB RID: 4299 RVA: 0x00045950 File Offset: 0x00043B50
			public void UnSerialize(BinaryReader r)
			{
				this.slotindex = r.ReadUInt32();
				for (int i = 0; i < 3; i++)
				{
					this.indices[i] = r.ReadUInt16();
				}
				this.coordinates = new float[2];
				this.coordinates[0] = r.ReadSingle();
				this.coordinates[1] = r.ReadSingle();
				this.distance = r.ReadSingle();
				this.mOffsetFromIntersectionOS = new StreamVector3(r.ReadSingle(), r.ReadSingle(), r.ReadSingle());
				this.mSlotAveragePosOS = new StreamVector3(r.ReadSingle(), r.ReadSingle(), r.ReadSingle());
				this.mTransformToLS = new StreamVector4(r.ReadSingle(), r.ReadSingle(), r.ReadSingle(), r.ReadSingle());
				this.mPivotBoneIdx = r.ReadByte();
				if (this.parentVersion >= 14U)
				{
					this.unknown = r.ReadBytes(3);
				}
			}

			// Token: 0x060010CC RID: 4300 RVA: 0x00045A38 File Offset: 0x00043C38
			public void Serialize(BinaryWriter w)
			{
				w.Write(this.slotindex);
				for (int i = 0; i < 3; i++)
				{
					w.Write(this.indices[i]);
				}
				w.Write(this.coordinates[0]);
				w.Write(this.coordinates[1]);
				w.Write(this.distance);
				w.Write(this.mOffsetFromIntersectionOS.X);
				w.Write(this.mOffsetFromIntersectionOS.Y);
				w.Write(this.mOffsetFromIntersectionOS.Z);
				w.Write(this.mSlotAveragePosOS.X);
				w.Write(this.mSlotAveragePosOS.Y);
				w.Write(this.mSlotAveragePosOS.Z);
				w.Write(this.mTransformToLS.X);
				w.Write(this.mTransformToLS.Y);
				w.Write(this.mTransformToLS.Z);
				w.Write(this.mTransformToLS.W);
				w.Write(this.mPivotBoneIdx);
				if (this.parentVersion >= 14U)
				{
					w.Write(this.unknown);
				}
			}

			// Token: 0x04000D77 RID: 3447
			private uint parentVersion;

			// Token: 0x04000D78 RID: 3448
			private byte[] unknown;
		}
	}
}
