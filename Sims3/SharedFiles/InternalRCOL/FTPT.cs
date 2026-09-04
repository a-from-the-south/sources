using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using Sims3WorkshopSDK;

namespace Package.SharedFiles.InternalRCOL
{
	// Token: 0x020000B5 RID: 181
	public class FTPT : RCOLItem
	{
		// Token: 0x17000303 RID: 771
		// (get) Token: 0x06000914 RID: 2324 RVA: 0x0000737C File Offset: 0x0000557C
		// (set) Token: 0x06000915 RID: 2325 RVA: 0x00007384 File Offset: 0x00005584
		[TypeConverter(typeof(IntTypeConverter))]
		public uint Type { get; set; }

		// Token: 0x17000304 RID: 772
		// (get) Token: 0x06000916 RID: 2326 RVA: 0x0000738D File Offset: 0x0000558D
		// (set) Token: 0x06000917 RID: 2327 RVA: 0x00007395 File Offset: 0x00005595
		[TypeConverter(typeof(IntTypeConverter))]
		public uint Version { get; set; }

		// Token: 0x17000305 RID: 773
		// (get) Token: 0x06000918 RID: 2328 RVA: 0x0000739E File Offset: 0x0000559E
		// (set) Token: 0x06000919 RID: 2329 RVA: 0x000073A6 File Offset: 0x000055A6
		public ITGIndex TemplateKey { get; set; }

		// Token: 0x17000306 RID: 774
		// (get) Token: 0x0600091A RID: 2330 RVA: 0x000073AF File Offset: 0x000055AF
		// (set) Token: 0x0600091B RID: 2331 RVA: 0x000073B7 File Offset: 0x000055B7
		public List<FTPT.Polygon> ObjectFootprintPolygonList { get; set; }

		// Token: 0x17000307 RID: 775
		// (get) Token: 0x0600091C RID: 2332 RVA: 0x000073C0 File Offset: 0x000055C0
		// (set) Token: 0x0600091D RID: 2333 RVA: 0x000073C8 File Offset: 0x000055C8
		public List<FTPT.Polygon> RoutingSlotFootprintPolygonList { get; set; }

		// Token: 0x17000308 RID: 776
		// (get) Token: 0x0600091E RID: 2334 RVA: 0x000073D1 File Offset: 0x000055D1
		// (set) Token: 0x0600091F RID: 2335 RVA: 0x000073D9 File Offset: 0x000055D9
		public List<FTPT.PolygonHeightOverride> MinHeightOverride { get; set; }

		// Token: 0x17000309 RID: 777
		// (get) Token: 0x06000920 RID: 2336 RVA: 0x000073E2 File Offset: 0x000055E2
		// (set) Token: 0x06000921 RID: 2337 RVA: 0x000073EA File Offset: 0x000055EA
		public List<FTPT.PolygonHeightOverride> MaxHeightOverride { get; set; }

		// Token: 0x1700030A RID: 778
		// (get) Token: 0x06000922 RID: 2338 RVA: 0x000073F3 File Offset: 0x000055F3
		// (set) Token: 0x06000923 RID: 2339 RVA: 0x000073FB File Offset: 0x000055FB
		public float MaxHeight { get; set; }

		// Token: 0x1700030B RID: 779
		// (get) Token: 0x06000924 RID: 2340 RVA: 0x00007404 File Offset: 0x00005604
		// (set) Token: 0x06000925 RID: 2341 RVA: 0x0000740C File Offset: 0x0000560C
		public float MinHeight { get; set; }

		// Token: 0x06000926 RID: 2342 RVA: 0x0002D2D0 File Offset: 0x0002B4D0
		public FTPT(RCOL parent)
		{
			this.Parent = parent;
			this.ObjectFootprintPolygonList = new List<FTPT.Polygon>();
			this.RoutingSlotFootprintPolygonList = new List<FTPT.Polygon>();
			this.MinHeightOverride = new List<FTPT.PolygonHeightOverride>();
			this.MaxHeightOverride = new List<FTPT.PolygonHeightOverride>();
			this.TemplateKey = new ITGIndex();
			this.TemplateKey.Game = 4;
		}

		// Token: 0x06000927 RID: 2343 RVA: 0x0002D330 File Offset: 0x0002B530
		public override void UnSerialize(BinaryReader r)
		{
			this.Type = r.ReadUInt32();
			this.Version = r.ReadUInt32();
			if (this.Version > 12U)
			{
				throw new Exception("Invalid FTPT Version (" + this.Version.ToString() + ")");
			}
			this.ObjectFootprintPolygonList.Clear();
			this.RoutingSlotFootprintPolygonList.Clear();
			if (this.Version >= 12U)
			{
				this.TemplateKey.UnSerialize(r);
			}
			if (this.TemplateKey.Type != null)
			{
				byte b = r.ReadByte();
				for (int i = 0; i < (int)b; i++)
				{
					FTPT.PolygonHeightOverride polygonHeightOverride = new FTPT.PolygonHeightOverride();
					polygonHeightOverride.UnSerialize(r);
					this.MinHeightOverride.Add(polygonHeightOverride);
				}
				byte b2 = r.ReadByte();
				for (int j = 0; j < (int)b2; j++)
				{
					FTPT.PolygonHeightOverride polygonHeightOverride2 = new FTPT.PolygonHeightOverride();
					polygonHeightOverride2.UnSerialize(r);
					this.MaxHeightOverride.Add(polygonHeightOverride2);
				}
				return;
			}
			byte b3 = r.ReadByte();
			if (b3 > 0)
			{
				for (int k = 0; k < (int)b3; k++)
				{
					FTPT.Polygon polygon = new FTPT.Polygon(this.Version, this);
					polygon.UnSerialize(r);
					this.ObjectFootprintPolygonList.Add(polygon);
				}
			}
			byte b4 = r.ReadByte();
			if (b4 > 0)
			{
				for (int l = 0; l < (int)b4; l++)
				{
					FTPT.Polygon polygon2 = new FTPT.Polygon(this.Version, this);
					polygon2.UnSerialize(r);
					this.RoutingSlotFootprintPolygonList.Add(polygon2);
				}
			}
			if (this.Version >= 12U)
			{
				this.MaxHeight = r.ReadSingle();
				this.MinHeight = r.ReadSingle();
			}
			if (r.BaseStream.Position != r.BaseStream.Length)
			{
				throw new Exception("FTPT not read to end");
			}
		}

		// Token: 0x06000928 RID: 2344 RVA: 0x0002D4E8 File Offset: 0x0002B6E8
		public override void Serialize(BinaryWriter w)
		{
			w.Write(this.Type);
			w.Write(this.Version);
			if (this.Version >= 12U)
			{
				this.TemplateKey.Serialize(w);
			}
			if (this.TemplateKey.Type != null)
			{
				w.Write((byte)this.MinHeightOverride.Count);
				foreach (FTPT.PolygonHeightOverride polygonHeightOverride in this.MinHeightOverride)
				{
					polygonHeightOverride.Serialize(w);
				}
				w.Write((byte)this.MaxHeightOverride.Count);
				foreach (FTPT.PolygonHeightOverride polygonHeightOverride2 in this.MaxHeightOverride)
				{
					polygonHeightOverride2.Serialize(w);
				}
				return;
			}
			w.Write((byte)this.ObjectFootprintPolygonList.Count);
			foreach (FTPT.Polygon polygon in this.ObjectFootprintPolygonList)
			{
				polygon.Serialize(w);
			}
			w.Write((byte)this.RoutingSlotFootprintPolygonList.Count);
			foreach (FTPT.Polygon polygon2 in this.RoutingSlotFootprintPolygonList)
			{
				polygon2.Serialize(w);
			}
			if (this.Version >= 12U)
			{
				w.Write(this.MaxHeight);
				w.Write(this.MinHeight);
			}
		}

		// Token: 0x06000929 RID: 2345 RVA: 0x00003309 File Offset: 0x00001509
		public override int ReplaceReferences(ResKey from, ResKey to)
		{
			return 0;
		}

		// Token: 0x0600092A RID: 2346 RVA: 0x00007415 File Offset: 0x00005615
		public override string ToString()
		{
			return "FTPT";
		}

		// Token: 0x04000479 RID: 1145
		public RCOL Parent;

		// Token: 0x0200019E RID: 414
		public class PolygonHeightOverride
		{
			// Token: 0x170004CD RID: 1229
			// (get) Token: 0x06000F79 RID: 3961 RVA: 0x0000AC25 File Offset: 0x00008E25
			// (set) Token: 0x06000F7A RID: 3962 RVA: 0x0000AC2D File Offset: 0x00008E2D
			public uint NameHash { get; set; }

			// Token: 0x170004CE RID: 1230
			// (get) Token: 0x06000F7B RID: 3963 RVA: 0x0000AC36 File Offset: 0x00008E36
			// (set) Token: 0x06000F7C RID: 3964 RVA: 0x0000AC3E File Offset: 0x00008E3E
			public float Height { get; set; }

			// Token: 0x06000F7E RID: 3966 RVA: 0x0000AC47 File Offset: 0x00008E47
			public void UnSerialize(BinaryReader r)
			{
				this.NameHash = r.ReadUInt32();
				this.Height = r.ReadSingle();
			}

			// Token: 0x06000F7F RID: 3967 RVA: 0x0000AC61 File Offset: 0x00008E61
			public void Serialize(BinaryWriter w)
			{
				w.Write(this.NameHash);
				w.Write(this.Height);
			}
		}

		// Token: 0x0200019F RID: 415
		public class Point
		{
			// Token: 0x06000F80 RID: 3968 RVA: 0x0000331D File Offset: 0x0000151D
			public Point()
			{
			}

			// Token: 0x06000F81 RID: 3969 RVA: 0x0000AC7B File Offset: 0x00008E7B
			public Point(float x, float z)
			{
				this.x = x;
				this.z = z;
			}

			// Token: 0x04000C93 RID: 3219
			public float x;

			// Token: 0x04000C94 RID: 3220
			public float z;
		}

		// Token: 0x020001A0 RID: 416
		public class Polygon
		{
			// Token: 0x170004CF RID: 1231
			// (get) Token: 0x06000F82 RID: 3970 RVA: 0x0000AC91 File Offset: 0x00008E91
			// (set) Token: 0x06000F83 RID: 3971 RVA: 0x0000AC99 File Offset: 0x00008E99
			public uint NameHash { get; set; }

			// Token: 0x170004D0 RID: 1232
			// (get) Token: 0x06000F84 RID: 3972 RVA: 0x0000ACA2 File Offset: 0x00008EA2
			// (set) Token: 0x06000F85 RID: 3973 RVA: 0x0000ACAA File Offset: 0x00008EAA
			public byte Priority { get; set; }

			// Token: 0x170004D1 RID: 1233
			// (get) Token: 0x06000F86 RID: 3974 RVA: 0x0000ACB3 File Offset: 0x00008EB3
			// (set) Token: 0x06000F87 RID: 3975 RVA: 0x0000ACBB File Offset: 0x00008EBB
			public FTPT.FootprintPolyFlags FootprintPolyFlags { get; set; }

			// Token: 0x170004D2 RID: 1234
			// (get) Token: 0x06000F88 RID: 3976 RVA: 0x0000ACC4 File Offset: 0x00008EC4
			// (set) Token: 0x06000F89 RID: 3977 RVA: 0x0000ACCC File Offset: 0x00008ECC
			public List<FTPT.Point> PointList { get; set; }

			// Token: 0x170004D3 RID: 1235
			// (get) Token: 0x06000F8A RID: 3978 RVA: 0x0000ACD5 File Offset: 0x00008ED5
			// (set) Token: 0x06000F8B RID: 3979 RVA: 0x0000ACDD File Offset: 0x00008EDD
			public FTPT.IntersectionFlags mIntersectionType { get; set; }

			// Token: 0x170004D4 RID: 1236
			// (get) Token: 0x06000F8C RID: 3980 RVA: 0x0000ACE6 File Offset: 0x00008EE6
			// (set) Token: 0x06000F8D RID: 3981 RVA: 0x0000ACEE File Offset: 0x00008EEE
			public FTPT.IntersectionFlags mIntersectionFlags { get; set; }

			// Token: 0x170004D5 RID: 1237
			// (get) Token: 0x06000F8E RID: 3982 RVA: 0x0000ACF7 File Offset: 0x00008EF7
			// (set) Token: 0x06000F8F RID: 3983 RVA: 0x0000ACFF File Offset: 0x00008EFF
			public FTPT.SurfaceTypeFlags mSurfaceTypeFlags { get; set; }

			// Token: 0x170004D6 RID: 1238
			// (get) Token: 0x06000F90 RID: 3984 RVA: 0x0000AD08 File Offset: 0x00008F08
			// (set) Token: 0x06000F91 RID: 3985 RVA: 0x0000AD10 File Offset: 0x00008F10
			public FTPT.SurfaceAttributeFlags mSurfaceAttributeFlags { get; set; }

			// Token: 0x170004D7 RID: 1239
			// (get) Token: 0x06000F92 RID: 3986 RVA: 0x0000AD19 File Offset: 0x00008F19
			// (set) Token: 0x06000F93 RID: 3987 RVA: 0x0000AD21 File Offset: 0x00008F21
			public byte LevelOffset { get; set; }

			// Token: 0x170004D8 RID: 1240
			// (get) Token: 0x06000F94 RID: 3988 RVA: 0x0000AD2A File Offset: 0x00008F2A
			// (set) Token: 0x06000F95 RID: 3989 RVA: 0x0000AD32 File Offset: 0x00008F32
			public float ElevationOffset { get; set; }

			// Token: 0x170004D9 RID: 1241
			// (get) Token: 0x06000F96 RID: 3990 RVA: 0x0000AD3B File Offset: 0x00008F3B
			// (set) Token: 0x06000F97 RID: 3991 RVA: 0x0000AD43 File Offset: 0x00008F43
			public float[] BoundingBox { get; set; }

			// Token: 0x170004DA RID: 1242
			// (get) Token: 0x06000F98 RID: 3992 RVA: 0x0000AD4C File Offset: 0x00008F4C
			public uint Version
			{
				get
				{
					return this.parentVersion;
				}
			}

			// Token: 0x170004DB RID: 1243
			// (get) Token: 0x06000F99 RID: 3993 RVA: 0x0000AD54 File Offset: 0x00008F54
			// (set) Token: 0x06000F9A RID: 3994 RVA: 0x0000AD5C File Offset: 0x00008F5C
			public FTPT Parent { get; set; }

			// Token: 0x06000F9B RID: 3995 RVA: 0x0000AD65 File Offset: 0x00008F65
			public Polygon(uint parentVersion, FTPT parent)
			{
				this.parentVersion = parentVersion;
				this.Parent = parent;
			}

			// Token: 0x06000F9C RID: 3996 RVA: 0x00043A34 File Offset: 0x00041C34
			public void UnSerialize(BinaryReader r)
			{
				this.NameHash = r.ReadUInt32();
				this.Priority = r.ReadByte();
				this.FootprintPolyFlags = (FTPT.FootprintPolyFlags)r.ReadUInt32();
				byte b = r.ReadByte();
				this.PointList = new List<FTPT.Point>();
				for (int i = 0; i < (int)b; i++)
				{
					FTPT.Point point = new FTPT.Point();
					point.x = r.ReadSingle();
					point.z = r.ReadSingle();
					this.PointList.Add(point);
				}
				this.mIntersectionType = (FTPT.IntersectionFlags)r.ReadUInt32();
				if (this.parentVersion >= 12U)
				{
					this.mIntersectionFlags = (FTPT.IntersectionFlags)r.ReadUInt32();
				}
				this.mSurfaceTypeFlags = (FTPT.SurfaceTypeFlags)r.ReadUInt32();
				this.mSurfaceAttributeFlags = (FTPT.SurfaceAttributeFlags)r.ReadUInt32();
				this.LevelOffset = r.ReadByte();
				if (this.parentVersion > 7U && this.parentVersion < 12U)
				{
					this.ElevationOffset = r.ReadSingle();
				}
				this.BoundingBox = new float[6];
				this.BoundingBox[0] = r.ReadSingle();
				this.BoundingBox[1] = r.ReadSingle();
				this.BoundingBox[2] = r.ReadSingle();
				this.BoundingBox[3] = r.ReadSingle();
				if (this.parentVersion >= 12U)
				{
					this.BoundingBox[4] = r.ReadSingle();
					this.BoundingBox[5] = r.ReadSingle();
				}
			}

			// Token: 0x06000F9D RID: 3997 RVA: 0x00043B7C File Offset: 0x00041D7C
			public void Serialize(BinaryWriter w)
			{
				w.Write(this.NameHash);
				w.Write(this.Priority);
				w.Write((uint)this.FootprintPolyFlags);
				w.Write((byte)this.PointList.Count);
				foreach (FTPT.Point point in this.PointList)
				{
					w.Write(point.x);
					w.Write(point.z);
				}
				w.Write((uint)this.mIntersectionType);
				if (this.parentVersion >= 12U)
				{
					w.Write((uint)this.mIntersectionFlags);
				}
				w.Write((uint)this.mSurfaceTypeFlags);
				w.Write((uint)this.mSurfaceAttributeFlags);
				w.Write(this.LevelOffset);
				if (this.parentVersion > 7U && this.parentVersion < 12U)
				{
					w.Write(this.ElevationOffset);
				}
				w.Write(this.BoundingBox[0]);
				w.Write(this.BoundingBox[1]);
				w.Write(this.BoundingBox[2]);
				w.Write(this.BoundingBox[3]);
				if (this.parentVersion >= 7U)
				{
					w.Write(this.BoundingBox[4]);
					w.Write(this.BoundingBox[5]);
				}
			}

			// Token: 0x04000CA0 RID: 3232
			private uint parentVersion;
		}

		// Token: 0x020001A1 RID: 417
		[Flags]
		public enum FootprintPolyFlags : uint
		{
			// Token: 0x04000CA3 RID: 3235
			ForPlacement = 1U,
			// Token: 0x04000CA4 RID: 3236
			ForPathing = 2U,
			// Token: 0x04000CA5 RID: 3237
			IsEnabled = 4U,
			// Token: 0x04000CA6 RID: 3238
			IsDiscouraged = 8U,
			// Token: 0x04000CA7 RID: 3239
			ForShell = 16U,
			// Token: 0x04000CA8 RID: 3240
			LandingStrip = 16U,
			// Token: 0x04000CA9 RID: 3241
			NoRaycast = 32U,
			// Token: 0x04000CAA RID: 3242
			PlacementSlotted = 64U,
			// Token: 0x04000CAB RID: 3243
			Encouraged = 128U,
			// Token: 0x04000CAC RID: 3244
			TerrainCutout = 256U
		}

		// Token: 0x020001A2 RID: 418
		[Flags]
		public enum IntersectionFlags : uint
		{
			// Token: 0x04000CAE RID: 3246
			None = 0U,
			// Token: 0x04000CAF RID: 3247
			Walls = 2U,
			// Token: 0x04000CB0 RID: 3248
			Objects = 4U,
			// Token: 0x04000CB1 RID: 3249
			Sims = 8U,
			// Token: 0x04000CB2 RID: 3250
			Roofs = 16U,
			// Token: 0x04000CB3 RID: 3251
			Fences = 32U,
			// Token: 0x04000CB4 RID: 3252
			ModularStairs = 64U,
			// Token: 0x04000CB5 RID: 3253
			ObjectsOfSameType = 128U,
			// Token: 0x04000CB6 RID: 3254
			Columns = 256U,
			// Token: 0x04000CB7 RID: 3255
			ReservedSpace = 512U,
			// Token: 0x04000CB8 RID: 3256
			Foundations = 1024U,
			// Token: 0x04000CB9 RID: 3257
			FenestrationNode = 2048U,
			// Token: 0x04000CBA RID: 3258
			Trim = 4096U
		}

		// Token: 0x020001A3 RID: 419
		[Flags]
		public enum SurfaceTypeFlags : uint
		{
			// Token: 0x04000CBC RID: 3260
			Terrain = 1U,
			// Token: 0x04000CBD RID: 3261
			Floor = 2U,
			// Token: 0x04000CBE RID: 3262
			Pool = 4U,
			// Token: 0x04000CBF RID: 3263
			Pond = 8U,
			// Token: 0x04000CC0 RID: 3264
			Fence = 16U,
			// Token: 0x04000CC1 RID: 3265
			AnySurface = 32U,
			// Token: 0x04000CC2 RID: 3266
			Air = 64U,
			// Token: 0x04000CC3 RID: 3267
			Roof = 128U
		}

		// Token: 0x020001A4 RID: 420
		[Flags]
		public enum SurfaceAttributeFlags : uint
		{
			// Token: 0x04000CC5 RID: 3269
			Inside = 1U,
			// Token: 0x04000CC6 RID: 3270
			Outside = 2U,
			// Token: 0x04000CC7 RID: 3271
			Slope = 4U
		}
	}
}
