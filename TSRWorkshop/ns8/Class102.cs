using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Xml;
using ns10;
using ns12;
using ns13;
using ns15;
using ns17;
using ns2;
using ns6;
using Package.Sims3Files;
using Package.Sims3Files.InternalRCOL;
using SlimDX;
using SlimDX.Direct3D9;

namespace ns8
{
	// Token: 0x020000F6 RID: 246
	internal abstract class Class102 : Interface8
	{
		// Token: 0x17000191 RID: 401
		// (get) Token: 0x060009D6 RID: 2518 RVA: 0x000855D4 File Offset: 0x000837D4
		// (set) Token: 0x060009D7 RID: 2519 RVA: 0x000855EC File Offset: 0x000837EC
		public bool DisplaySlots
		{
			get
			{
				return this.bool_0;
			}
			set
			{
				this.bool_0 = value;
				foreach (Class129 @class in this.Footprints)
				{
					@class.Visible = this.bool_0;
				}
				foreach (Class129 class2 in this.Slots)
				{
					class2.Visible = this.bool_0;
				}
				foreach (Interface10 @interface in this.ContainerEntries)
				{
					@interface.Visible = this.bool_0;
				}
				foreach (Interface10 interface2 in this.RouteEntries)
				{
					interface2.Visible = this.bool_0;
				}
				foreach (Interface10 interface3 in this.EffectEntries)
				{
					interface3.Visible = this.bool_0;
				}
				foreach (Interface10 interface4 in this.KinematicEntries)
				{
					interface4.Visible = this.bool_0;
				}
			}
		}

		// Token: 0x17000192 RID: 402
		// (get) Token: 0x060009D8 RID: 2520 RVA: 0x000857C0 File Offset: 0x000839C0
		// (set) Token: 0x060009D9 RID: 2521 RVA: 0x000065BB File Offset: 0x000047BB
		public bool DisplayWall { get; set; }

		// Token: 0x17000193 RID: 403
		// (get) Token: 0x060009DA RID: 2522 RVA: 0x000857D8 File Offset: 0x000839D8
		// (set) Token: 0x060009DB RID: 2523 RVA: 0x000065C6 File Offset: 0x000047C6
		public bool DisplayFloorMask { get; set; }

		// Token: 0x17000194 RID: 404
		// (get) Token: 0x060009DC RID: 2524 RVA: 0x000857F0 File Offset: 0x000839F0
		// (set) Token: 0x060009DD RID: 2525 RVA: 0x000065D1 File Offset: 0x000047D1
		public bool HasFloorMask
		{
			get
			{
				return this.bool_1;
			}
			set
			{
				this.bool_1 = value;
			}
		}

		// Token: 0x17000195 RID: 405
		// (get) Token: 0x060009DE RID: 2526 RVA: 0x00085808 File Offset: 0x00083A08
		// (set) Token: 0x060009DF RID: 2527 RVA: 0x00085820 File Offset: 0x00083A20
		public bool DisplayRig
		{
			get
			{
				return this.bool_2;
			}
			set
			{
				this.bool_2 = value;
				foreach (Interface10 @interface in this.JointEntries)
				{
					@interface.Visible = this.bool_2;
				}
				foreach (Interface10 interface2 in this.SkinEntries)
				{
					interface2.Visible = this.bool_2;
				}
			}
		}

		// Token: 0x17000196 RID: 406
		// (get) Token: 0x060009E0 RID: 2528 RVA: 0x000858CC File Offset: 0x00083ACC
		// (set) Token: 0x060009E1 RID: 2529 RVA: 0x000065DC File Offset: 0x000047DC
		public List<Class120> Lites { get; set; }

		// Token: 0x17000197 RID: 407
		// (get) Token: 0x060009E2 RID: 2530 RVA: 0x000858E4 File Offset: 0x00083AE4
		// (set) Token: 0x060009E3 RID: 2531 RVA: 0x000065E7 File Offset: 0x000047E7
		public List<Class129> Slots { get; set; }

		// Token: 0x17000198 RID: 408
		// (get) Token: 0x060009E4 RID: 2532 RVA: 0x000858FC File Offset: 0x00083AFC
		// (set) Token: 0x060009E5 RID: 2533 RVA: 0x000065F2 File Offset: 0x000047F2
		public List<Class129> Footprints { get; set; }

		// Token: 0x17000199 RID: 409
		// (get) Token: 0x060009E6 RID: 2534 RVA: 0x00085914 File Offset: 0x00083B14
		// (set) Token: 0x060009E7 RID: 2535 RVA: 0x000065FD File Offset: 0x000047FD
		public List<Class119> JointEntries { get; set; }

		// Token: 0x1700019A RID: 410
		// (get) Token: 0x060009E8 RID: 2536 RVA: 0x0008592C File Offset: 0x00083B2C
		// (set) Token: 0x060009E9 RID: 2537 RVA: 0x00006608 File Offset: 0x00004808
		public List<Class124> SkinEntries { get; set; }

		// Token: 0x1700019B RID: 411
		// (get) Token: 0x060009EA RID: 2538 RVA: 0x00085944 File Offset: 0x00083B44
		// (set) Token: 0x060009EB RID: 2539 RVA: 0x00006613 File Offset: 0x00004813
		public List<Class111> ContainerEntries { get; set; }

		// Token: 0x1700019C RID: 412
		// (get) Token: 0x060009EC RID: 2540 RVA: 0x0008595C File Offset: 0x00083B5C
		// (set) Token: 0x060009ED RID: 2541 RVA: 0x0000661E File Offset: 0x0000481E
		public List<Class111> RouteEntries { get; set; }

		// Token: 0x1700019D RID: 413
		// (get) Token: 0x060009EE RID: 2542 RVA: 0x00085974 File Offset: 0x00083B74
		// (set) Token: 0x060009EF RID: 2543 RVA: 0x00006629 File Offset: 0x00004829
		public List<Class111> EffectEntries { get; set; }

		// Token: 0x1700019E RID: 414
		// (get) Token: 0x060009F0 RID: 2544 RVA: 0x0008598C File Offset: 0x00083B8C
		// (set) Token: 0x060009F1 RID: 2545 RVA: 0x00006634 File Offset: 0x00004834
		public List<Class111> KinematicEntries { get; set; }

		// Token: 0x1700019F RID: 415
		// (get) Token: 0x060009F2 RID: 2546 RVA: 0x000859A4 File Offset: 0x00083BA4
		// (set) Token: 0x060009F3 RID: 2547 RVA: 0x0000663F File Offset: 0x0000483F
		public List<uint> Bones { get; set; }

		// Token: 0x170001A0 RID: 416
		// (get) Token: 0x060009F4 RID: 2548 RVA: 0x000859BC File Offset: 0x00083BBC
		// (set) Token: 0x060009F5 RID: 2549 RVA: 0x0000664A File Offset: 0x0000484A
		public Dictionary<MLOD.MLODEntry, Interface9> Objects { get; protected set; }

		// Token: 0x060009F6 RID: 2550 RVA: 0x000859D4 File Offset: 0x00083BD4
		public Class102()
		{
			this.Lites = new List<Class120>();
			this.Slots = new List<Class129>();
			this.Footprints = new List<Class129>();
			this.JointEntries = new List<Class119>();
			this.SkinEntries = new List<Class124>();
			this.ContainerEntries = new List<Class111>();
			this.EffectEntries = new List<Class111>();
			this.RouteEntries = new List<Class111>();
			this.KinematicEntries = new List<Class111>();
			this.Bones = new List<uint>();
			this.Objects = new Dictionary<MLOD.MLODEntry, Interface9>();
		}

		// Token: 0x060009F7 RID: 2551 RVA: 0x00002A71 File Offset: 0x00000C71
		public virtual void imethod_14()
		{
		}

		// Token: 0x060009F8 RID: 2552 RVA: 0x00085A64 File Offset: 0x00083C64
		public void method_0(Device device_0, Matrix matrix_0)
		{
			Class140.smethod_0().method_9(RenderState.AlphaBlendEnable, false);
			Class140.smethod_0().method_9(RenderState.ZWriteEnable, true);
			foreach (Class120 @class in this.Lites)
			{
				@class.method_2(device_0, matrix_0);
			}
		}

		// Token: 0x060009F9 RID: 2553 RVA: 0x00002A71 File Offset: 0x00000C71
		public virtual void vmethod_0(Device device_0, Matrix matrix_0)
		{
		}

		// Token: 0x060009FA RID: 2554 RVA: 0x00085AE0 File Offset: 0x00083CE0
		public void method_1(Device device_0, Matrix matrix_0)
		{
			Class140.smethod_0().method_9(RenderState.AlphaBlendEnable, false);
			Class140.smethod_0().method_9(RenderState.ZWriteEnable, true);
			Class140.smethod_0().method_9(RenderState.CullMode, Cull.None);
			Class140.smethod_0().method_28("g_forcedTransparency", 1f);
			foreach (Interface10 @interface in this.SkinEntries)
			{
				if (@interface.Visible)
				{
					@interface.imethod_3(device_0, matrix_0);
				}
			}
			foreach (Interface10 interface2 in this.JointEntries)
			{
				if (interface2.Visible)
				{
					interface2.imethod_3(device_0, matrix_0);
				}
			}
			foreach (Interface10 interface3 in this.ContainerEntries)
			{
				if (interface3.Visible)
				{
					interface3.imethod_3(device_0, matrix_0);
				}
			}
			Class140.smethod_0().method_28("g_forcedTransparency", this.DisplayRig ? 0.8f : 1f);
			foreach (Interface10 interface4 in this.RouteEntries)
			{
				if (interface4.Visible)
				{
					interface4.imethod_3(device_0, matrix_0);
				}
			}
			foreach (Interface10 interface5 in this.EffectEntries)
			{
				if (interface5.Visible)
				{
					interface5.imethod_3(device_0, matrix_0);
				}
			}
			foreach (Interface10 interface6 in this.KinematicEntries)
			{
				if (interface6.Visible)
				{
					interface6.imethod_3(device_0, matrix_0);
				}
			}
			foreach (Class129 @class in this.Slots)
			{
				if (@class.Visible)
				{
					device_0.VertexDeclaration = Class140.smethod_0().VertexDeclaration;
					device_0.SetTexture(0, null);
					device_0.SetTexture(1, null);
					device_0.SetTransform(TransformState.World, matrix_0);
					device_0.SetStreamSource(0, @class.VBUF, 0, Class112.Struct7.SizeInBytes);
					Class140.smethod_0().method_9(RenderState.Lighting, false);
					device_0.DrawPrimitives(PrimitiveType.LineStrip, 0, @class.Slot.Entries.Count);
					Class140.smethod_0().method_9(RenderState.Lighting, true);
				}
			}
			foreach (Class129 class2 in this.Footprints)
			{
				if (class2.Visible)
				{
					device_0.VertexDeclaration = Class140.smethod_0().VertexDeclaration;
					device_0.SetTexture(0, null);
					device_0.SetTexture(1, null);
					device_0.SetTransform(TransformState.World, matrix_0);
					device_0.SetStreamSource(0, class2.VBUF, 0, Class112.Struct7.SizeInBytes);
					Class140.smethod_0().method_9(RenderState.Lighting, false);
					device_0.DrawPrimitives(PrimitiveType.LineStrip, 0, class2.Slot.Entries.Count);
					Class140.smethod_0().method_9(RenderState.Lighting, true);
				}
			}
		}

		// Token: 0x060009FB RID: 2555 RVA: 0x00085EE4 File Offset: 0x000840E4
		public virtual Size vmethod_1()
		{
			return new Size(1024, 1024);
		}

		// Token: 0x060009FC RID: 2556 RVA: 0x00085F04 File Offset: 0x00084104
		public virtual Dictionary<MLOD.MLODEntry, Interface9> vmethod_2()
		{
			return this.Objects;
		}

		// Token: 0x060009FD RID: 2557 RVA: 0x00037B84 File Offset: 0x00035D84
		protected bool method_2()
		{
			return true;
		}

		// Token: 0x060009FE RID: 2558 RVA: 0x00085F1C File Offset: 0x0008411C
		public virtual void imethod_8(bool bool_5)
		{
			foreach (Interface9 @interface in this.Objects.Values)
			{
				@interface.imethod_1(bool_5);
			}
			this.Objects.Clear();
			if (bool_5)
			{
				foreach (Class129 @class in this.Footprints)
				{
					@class.method_1();
				}
				foreach (Class120 class2 in this.Lites)
				{
					class2.method_3(bool_5);
				}
				foreach (Class129 class3 in this.Slots)
				{
					class3.method_1();
				}
				foreach (Interface10 interface2 in this.SkinEntries)
				{
					interface2.imethod_1();
				}
				foreach (Interface10 interface3 in this.JointEntries)
				{
					interface3.imethod_1();
				}
				foreach (Interface10 interface4 in this.ContainerEntries)
				{
					interface4.imethod_1();
				}
				foreach (Interface10 interface5 in this.RouteEntries)
				{
					interface5.imethod_1();
				}
				foreach (Interface10 interface6 in this.EffectEntries)
				{
					interface6.imethod_1();
				}
				foreach (Interface10 interface7 in this.KinematicEntries)
				{
					interface7.imethod_1();
				}
				this.Slots.Clear();
				this.Footprints.Clear();
				this.KinematicEntries.Clear();
				this.EffectEntries.Clear();
				this.ContainerEntries.Clear();
				this.SkinEntries.Clear();
				this.JointEntries.Clear();
				this.Lites.Clear();
				this.RouteEntries.Clear();
			}
		}

		// Token: 0x060009FF RID: 2559 RVA: 0x00002A71 File Offset: 0x00000C71
		public virtual void imethod_9(uint uint_0, Matrix matrix_0)
		{
		}

		// Token: 0x06000A00 RID: 2560 RVA: 0x00002A71 File Offset: 0x00000C71
		public virtual void imethod_10(int int_0)
		{
		}

		// Token: 0x06000A01 RID: 2561 RVA: 0x000032ED File Offset: 0x000014ED
		public virtual void imethod_7(Device device_0)
		{
			throw new NotImplementedException();
		}

		// Token: 0x06000A02 RID: 2562 RVA: 0x00086254 File Offset: 0x00084454
		public virtual Vector3[] imethod_13()
		{
			throw new NotImplementedException();
		}

		// Token: 0x06000A03 RID: 2563 RVA: 0x000032ED File Offset: 0x000014ED
		public virtual void imethod_6(Device device_0)
		{
			throw new NotImplementedException();
		}

		// Token: 0x06000A04 RID: 2564 RVA: 0x00002A71 File Offset: 0x00000C71
		public virtual void vmethod_3(XmlDocument xmlDocument_0)
		{
		}

		// Token: 0x06000A05 RID: 2565 RVA: 0x00086268 File Offset: 0x00084468
		public virtual Image vmethod_4(Device device_0, XmlDocument xmlDocument_0, Size size_0)
		{
			throw new NotImplementedException();
		}

		// Token: 0x06000A06 RID: 2566 RVA: 0x00002A71 File Offset: 0x00000C71
		public virtual void vmethod_5(Matrix matrix_0, Device device_0)
		{
		}

		// Token: 0x06000A07 RID: 2567
		public abstract void imethod_0(Matrix matrix_0, Matrix matrix_1, Device device_0);

		// Token: 0x06000A08 RID: 2568
		public abstract void vmethod_6(Matrix matrix_0, Matrix matrix_1, Device device_0);

		// Token: 0x06000A09 RID: 2569
		public abstract void imethod_1(bool bool_5);

		// Token: 0x06000A0A RID: 2570
		public abstract bool imethod_2();

		// Token: 0x06000A0B RID: 2571
		public abstract void imethod_3(bool bool_5);

		// Token: 0x06000A0C RID: 2572
		public abstract bool imethod_4();

		// Token: 0x06000A0D RID: 2573
		public abstract void imethod_5(Device device_0);

		// Token: 0x06000A0E RID: 2574
		public abstract void vmethod_7(Device device_0);

		// Token: 0x06000A0F RID: 2575 RVA: 0x00002A71 File Offset: 0x00000C71
		public virtual void imethod_11(int int_0)
		{
		}

		// Token: 0x06000A10 RID: 2576 RVA: 0x00002A71 File Offset: 0x00000C71
		public virtual void imethod_12(S_CLIP s_CLIP_0)
		{
		}

		// Token: 0x06000A11 RID: 2577 RVA: 0x00002A71 File Offset: 0x00000C71
		public virtual void vmethod_8(List<Class102.Class108> list_10)
		{
		}

		// Token: 0x06000A12 RID: 2578 RVA: 0x00002A71 File Offset: 0x00000C71
		public virtual void vmethod_9(List<Class102.Class108> list_10)
		{
		}

		// Token: 0x04000812 RID: 2066
		private bool bool_0;

		// Token: 0x04000813 RID: 2067
		private bool bool_1;

		// Token: 0x04000814 RID: 2068
		private bool bool_2;

		// Token: 0x04000815 RID: 2069
		[CompilerGenerated]
		private bool bool_3;

		// Token: 0x04000816 RID: 2070
		[CompilerGenerated]
		private bool bool_4;

		// Token: 0x04000817 RID: 2071
		[CompilerGenerated]
		private List<Class120> list_0;

		// Token: 0x04000818 RID: 2072
		[CompilerGenerated]
		private List<Class129> list_1;

		// Token: 0x04000819 RID: 2073
		[CompilerGenerated]
		private List<Class129> list_2;

		// Token: 0x0400081A RID: 2074
		[CompilerGenerated]
		private List<Class119> list_3;

		// Token: 0x0400081B RID: 2075
		[CompilerGenerated]
		private List<Class124> list_4;

		// Token: 0x0400081C RID: 2076
		[CompilerGenerated]
		private List<Class111> list_5;

		// Token: 0x0400081D RID: 2077
		[CompilerGenerated]
		private List<Class111> list_6;

		// Token: 0x0400081E RID: 2078
		[CompilerGenerated]
		private List<Class111> list_7;

		// Token: 0x0400081F RID: 2079
		[CompilerGenerated]
		private List<Class111> list_8;

		// Token: 0x04000820 RID: 2080
		[CompilerGenerated]
		private List<uint> list_9;

		// Token: 0x04000821 RID: 2081
		[CompilerGenerated]
		private Dictionary<MLOD.MLODEntry, Interface9> dictionary_0;

		// Token: 0x020000F7 RID: 247
		public sealed class Class107
		{
			// Token: 0x06000A13 RID: 2579 RVA: 0x0008627C File Offset: 0x0008447C
			public bool Equals(object obj)
			{
				return (obj as Class102.Class107).short_0.Equals(this.short_0) && (obj as Class102.Class107).short_1.Equals(this.short_1) && (obj as Class102.Class107).short_2.Equals(this.short_2);
			}

			// Token: 0x06000A14 RID: 2580 RVA: 0x00037C14 File Offset: 0x00035E14
			public int GetHashCode()
			{
				return base.GetHashCode();
			}

			// Token: 0x04000822 RID: 2082
			public short short_0;

			// Token: 0x04000823 RID: 2083
			public short short_1;

			// Token: 0x04000824 RID: 2084
			public short short_2;

			// Token: 0x04000825 RID: 2085
			public Vector3 vector3_0;

			// Token: 0x04000826 RID: 2086
			public Vector3 vector3_1;

			// Token: 0x04000827 RID: 2087
			public Vector3 vector3_2;

			// Token: 0x04000828 RID: 2088
			public Vector2 vector2_0;

			// Token: 0x04000829 RID: 2089
			public Vector2 vector2_1;

			// Token: 0x0400082A RID: 2090
			public Vector2 vector2_2;

			// Token: 0x0400082B RID: 2091
			public float float_0;
		}

		// Token: 0x020000F8 RID: 248
		public sealed class Class108
		{
			// Token: 0x170001A1 RID: 417
			// (get) Token: 0x06000A16 RID: 2582 RVA: 0x000862D8 File Offset: 0x000844D8
			// (set) Token: 0x06000A17 RID: 2583 RVA: 0x00006655 File Offset: 0x00004855
			public Interface9 RenderableItem { get; private set; }

			// Token: 0x170001A2 RID: 418
			// (get) Token: 0x06000A18 RID: 2584 RVA: 0x000862F0 File Offset: 0x000844F0
			// (set) Token: 0x06000A19 RID: 2585 RVA: 0x00006660 File Offset: 0x00004860
			public List<Class102.Class107> SelectedFaces { get; private set; }

			// Token: 0x06000A1A RID: 2586 RVA: 0x0000666B File Offset: 0x0000486B
			public Class108(Interface9 renderableItem)
			{
				this.RenderableItem = renderableItem;
				this.SelectedFaces = new List<Class102.Class107>();
			}

			// Token: 0x0400082C RID: 2092
			[CompilerGenerated]
			private Interface9 interface9_0;

			// Token: 0x0400082D RID: 2093
			[CompilerGenerated]
			private List<Class102.Class107> list_0;
		}
	}
}
