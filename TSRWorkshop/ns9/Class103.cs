using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Xml;
using ns13;
using ns2;
using ns6;
using ns8;
using SlimDX;
using SlimDX.Direct3D9;

namespace ns9
{
	// Token: 0x020000F9 RID: 249
	internal sealed class Class103 : Class102
	{
		// Token: 0x170001A3 RID: 419
		// (get) Token: 0x06000A1B RID: 2587 RVA: 0x00086308 File Offset: 0x00084508
		// (set) Token: 0x06000A1C RID: 2588 RVA: 0x00006687 File Offset: 0x00004887
		public bool ShowFootprint { get; set; }

		// Token: 0x170001A4 RID: 420
		// (get) Token: 0x06000A1D RID: 2589 RVA: 0x00086320 File Offset: 0x00084520
		// (set) Token: 0x06000A1E RID: 2590 RVA: 0x00006692 File Offset: 0x00004892
		public bool ShowWalls { get; set; }

		// Token: 0x170001A5 RID: 421
		// (get) Token: 0x06000A1F RID: 2591 RVA: 0x00086338 File Offset: 0x00084538
		// (set) Token: 0x06000A20 RID: 2592 RVA: 0x0000669D File Offset: 0x0000489D
		public bool ShowFloors { get; set; }

		// Token: 0x170001A6 RID: 422
		// (get) Token: 0x06000A21 RID: 2593 RVA: 0x00086350 File Offset: 0x00084550
		// (set) Token: 0x06000A22 RID: 2594 RVA: 0x000066A8 File Offset: 0x000048A8
		public bool ShowObjects { get; set; }

		// Token: 0x170001A7 RID: 423
		// (get) Token: 0x06000A23 RID: 2595 RVA: 0x00086368 File Offset: 0x00084568
		// (set) Token: 0x06000A24 RID: 2596 RVA: 0x000066B3 File Offset: 0x000048B3
		public bool ShowDoorsAndWindows { get; set; }

		// Token: 0x06000A25 RID: 2597 RVA: 0x00086380 File Offset: 0x00084580
		public Class103()
		{
			this.cultureInfo_0 = new CultureInfo("en-US");
			this.cultureInfo_0.NumberFormat.NumberDecimalSeparator = ".";
			this.list_10 = new List<Class131>();
			this.list_11 = new List<Class113>();
			this.list_12 = new List<Class115>();
			this.list_13 = new List<Class115>();
			Class132.smethod_0().method_2(this);
			Class132.smethod_0().method_46();
			this.method_3();
		}

		// Token: 0x06000A26 RID: 2598 RVA: 0x000066BE File Offset: 0x000048BE
		private void method_3()
		{
			this.texture_0 = Class132.smethod_0().method_4(new Size(1024, 1024));
		}

		// Token: 0x06000A27 RID: 2599 RVA: 0x00086404 File Offset: 0x00084604
		public void method_4(XmlElement xmlElement_0)
		{
			float originX = float.Parse(xmlElement_0.GetAttribute("OriginX"), this.cultureInfo_0);
			float originZ = float.Parse(xmlElement_0.GetAttribute("OriginZ"), this.cultureInfo_0);
			float destinationX = float.Parse(xmlElement_0.GetAttribute("DestinationX"), this.cultureInfo_0);
			float destinationZ = float.Parse(xmlElement_0.GetAttribute("DestinationZ"), this.cultureInfo_0);
			string attribute = xmlElement_0.GetAttribute("LSPresetProductKey");
			string attribute2 = xmlElement_0.GetAttribute("RSPresetProductKey");
			string attribute3 = xmlElement_0.GetAttribute("RSCustomPresetIndex");
			string attribute4 = xmlElement_0.GetAttribute("LSCustomPresetIndex");
			string attribute5 = xmlElement_0.GetAttribute("RSPresetId");
			string attribute6 = xmlElement_0.GetAttribute("LSPresetId");
			string lPreset = "";
			string rPreset = "";
			if (!string.IsNullOrEmpty(attribute4))
			{
				XmlNodeList xmlNodeList = xmlElement_0.OwnerDocument.SelectNodes("/Blueprint/Presets/Preset");
				XmlElement xmlElement = xmlNodeList.Item(int.Parse(attribute4)) as XmlElement;
				lPreset = xmlElement.GetAttribute("PresetXML");
			}
			if (!string.IsNullOrEmpty(attribute3))
			{
				XmlNodeList xmlNodeList2 = xmlElement_0.OwnerDocument.SelectNodes("/Blueprint/Presets/Preset");
				XmlElement xmlElement2 = xmlNodeList2.Item(int.Parse(attribute3)) as XmlElement;
				rPreset = xmlElement2.GetAttribute("PresetXML");
			}
			Class131 item = new Class131(originX, originZ, destinationX, destinationZ, attribute, attribute2, attribute6, attribute5, lPreset, rPreset);
			this.list_10.Add(item);
		}

		// Token: 0x06000A28 RID: 2600 RVA: 0x0008656C File Offset: 0x0008476C
		public void method_5(XmlElement xmlElement_0)
		{
			float x = float.Parse(xmlElement_0.GetAttribute("X"), this.cultureInfo_0);
			float z = float.Parse(xmlElement_0.GetAttribute("Z"), this.cultureInfo_0);
			float rotation = float.Parse(xmlElement_0.GetAttribute("Rotation"), this.cultureInfo_0);
			int quad = int.Parse(xmlElement_0.GetAttribute("Quadrant"), this.cultureInfo_0);
			string attribute = xmlElement_0.GetAttribute("PresetProductKey");
			string attribute2 = xmlElement_0.GetAttribute("SCustomPresetIndex");
			string attribute3 = xmlElement_0.GetAttribute("PresetId");
			string presetXml = "";
			if (!string.IsNullOrEmpty(attribute2))
			{
				XmlNodeList xmlNodeList = xmlElement_0.OwnerDocument.SelectNodes("/Blueprint/Presets/Preset");
				XmlElement xmlElement = xmlNodeList.Item(int.Parse(attribute2)) as XmlElement;
				presetXml = xmlElement.GetAttribute("PresetXML");
			}
			Class113 item = new Class113(x, z, rotation, quad, attribute, attribute3, presetXml);
			this.list_11.Add(item);
		}

		// Token: 0x06000A29 RID: 2601 RVA: 0x00086664 File Offset: 0x00084864
		public void method_6(XmlElement xmlElement_0)
		{
			float x = float.Parse(xmlElement_0.GetAttribute("X"), this.cultureInfo_0);
			float y = float.Parse(xmlElement_0.GetAttribute("Y"), this.cultureInfo_0);
			float z = float.Parse(xmlElement_0.GetAttribute("Z"), this.cultureInfo_0);
			float facing = float.Parse(xmlElement_0.GetAttribute("Facing"), this.cultureInfo_0);
			int isDiagonalShifted = int.Parse(xmlElement_0.GetAttribute("IsDiagonalShifted"));
			int presetId = int.Parse(xmlElement_0.HasAttribute("PresetId") ? xmlElement_0.GetAttribute("PresetId") : "-1");
			int num = int.Parse(xmlElement_0.HasAttribute("CustomPresetIndex") ? xmlElement_0.GetAttribute("CustomPresetIndex") : "-1");
			string attribute = xmlElement_0.GetAttribute("ResourceKey");
			string presetStr = "";
			if (num > -1)
			{
				XmlNodeList xmlNodeList = xmlElement_0.OwnerDocument.SelectNodes("/Blueprint/Presets/Preset");
				XmlElement xmlElement = xmlNodeList.Item(num) as XmlElement;
				presetStr = xmlElement.GetAttribute("PresetXML");
			}
			Class115 item = new Class115(xmlElement_0, x, y, z, facing, attribute, ref this.list_10, isDiagonalShifted, presetId, num, 0, presetStr);
			this.list_12.Add(item);
		}

		// Token: 0x06000A2A RID: 2602 RVA: 0x000867A0 File Offset: 0x000849A0
		public void method_7(XmlElement xmlElement_0)
		{
			float x = float.Parse(xmlElement_0.GetAttribute("X"), this.cultureInfo_0);
			float y = float.Parse(xmlElement_0.GetAttribute("Y"), this.cultureInfo_0);
			float z = float.Parse(xmlElement_0.GetAttribute("Z"), this.cultureInfo_0);
			float facing = float.Parse(xmlElement_0.GetAttribute("Facing"), this.cultureInfo_0);
			int isDiagonalShifted = int.Parse(xmlElement_0.GetAttribute("IsDiagonalShifted"));
			int presetId = int.Parse(xmlElement_0.HasAttribute("PresetId") ? xmlElement_0.GetAttribute("PresetId") : "-1");
			int num = int.Parse(xmlElement_0.HasAttribute("CustomPresetIndex") ? xmlElement_0.GetAttribute("CustomPresetIndex") : "-1");
			string attribute = xmlElement_0.GetAttribute("ResourceKey");
			string presetStr = "";
			if (num > -1)
			{
				XmlNodeList xmlNodeList = xmlElement_0.OwnerDocument.SelectNodes("/Blueprint/Presets/Preset");
				XmlElement xmlElement = xmlNodeList.Item(num) as XmlElement;
				presetStr = xmlElement.GetAttribute("PresetXML");
			}
			Class115 item = new Class115(xmlElement_0, x, y, z, facing, attribute, ref this.list_10, isDiagonalShifted, presetId, num, 0, presetStr);
			this.list_13.Add(item);
		}

		// Token: 0x06000A2B RID: 2603 RVA: 0x000867A0 File Offset: 0x000849A0
		public void method_8(XmlElement xmlElement_0)
		{
			float x = float.Parse(xmlElement_0.GetAttribute("X"), this.cultureInfo_0);
			float y = float.Parse(xmlElement_0.GetAttribute("Y"), this.cultureInfo_0);
			float z = float.Parse(xmlElement_0.GetAttribute("Z"), this.cultureInfo_0);
			float facing = float.Parse(xmlElement_0.GetAttribute("Facing"), this.cultureInfo_0);
			int isDiagonalShifted = int.Parse(xmlElement_0.GetAttribute("IsDiagonalShifted"));
			int presetId = int.Parse(xmlElement_0.HasAttribute("PresetId") ? xmlElement_0.GetAttribute("PresetId") : "-1");
			int num = int.Parse(xmlElement_0.HasAttribute("CustomPresetIndex") ? xmlElement_0.GetAttribute("CustomPresetIndex") : "-1");
			string attribute = xmlElement_0.GetAttribute("ResourceKey");
			string presetStr = "";
			if (num > -1)
			{
				XmlNodeList xmlNodeList = xmlElement_0.OwnerDocument.SelectNodes("/Blueprint/Presets/Preset");
				XmlElement xmlElement = xmlNodeList.Item(num) as XmlElement;
				presetStr = xmlElement.GetAttribute("PresetXML");
			}
			Class115 item = new Class115(xmlElement_0, x, y, z, facing, attribute, ref this.list_10, isDiagonalShifted, presetId, num, 0, presetStr);
			this.list_13.Add(item);
		}

		// Token: 0x06000A2C RID: 2604 RVA: 0x000868DC File Offset: 0x00084ADC
		public override void imethod_7(Device device_0)
		{
			foreach (Interface9 @interface in base.Objects.Values)
			{
				Class121 @class = (Class121)@interface;
				@class.method_14(device_0);
			}
			foreach (Class115 class2 in this.list_12)
			{
				class2.method_2(device_0);
			}
			foreach (Class115 class3 in this.list_13)
			{
				class3.method_2(device_0);
			}
			foreach (Class113 class4 in this.list_11)
			{
				class4.method_2(device_0);
			}
			foreach (Class131 class5 in this.list_10)
			{
				class5.method_1(device_0);
			}
			this.method_3();
		}

		// Token: 0x06000A2D RID: 2605 RVA: 0x00086A58 File Offset: 0x00084C58
		public override void imethod_5(Device device_0)
		{
			this.texture_0.Dispose();
			foreach (Interface9 @interface in base.Objects.Values)
			{
				Class121 @class = (Class121)@interface;
				@class.method_13(device_0);
			}
			foreach (Class115 class2 in this.list_12)
			{
				class2.method_1(device_0);
			}
			foreach (Class115 class3 in this.list_13)
			{
				class3.method_1(device_0);
			}
			foreach (Class113 class4 in this.list_11)
			{
				class4.method_1(device_0);
			}
			foreach (Class131 class5 in this.list_10)
			{
				class5.method_0(device_0);
			}
		}

		// Token: 0x06000A2E RID: 2606 RVA: 0x00086BD8 File Offset: 0x00084DD8
		public override void imethod_8(bool bool_10)
		{
			base.imethod_8(bool_10);
			if (this.texture_0 != null)
			{
				this.texture_0.Dispose();
			}
			foreach (Interface9 @interface in base.Objects.Values)
			{
				Class121 @class = (Class121)@interface;
				@class.imethod_1(true);
			}
			foreach (Class115 class2 in this.list_12)
			{
				class2.method_3(true);
			}
			foreach (Class115 class3 in this.list_13)
			{
				class3.method_3(true);
			}
			foreach (Class113 class4 in this.list_11)
			{
				class4.method_3(true);
			}
			foreach (Class131 class5 in this.list_10)
			{
				class5.method_2(true);
			}
			foreach (object obj in Class115.hashtable_0.Values)
			{
				Texture texture = (Texture)obj;
				texture.Dispose();
			}
			Class115.hashtable_0.Clear();
		}

		// Token: 0x06000A2F RID: 2607 RVA: 0x000066E1 File Offset: 0x000048E1
		public override void vmethod_7(Device device_0)
		{
			this.imethod_7(device_0);
		}

		// Token: 0x06000A30 RID: 2608 RVA: 0x00086DC4 File Offset: 0x00084FC4
		public override Vector3[] imethod_13()
		{
			Vector3[] array = new Vector3[2];
			array[0].X = -10f;
			array[0].Z = -10f;
			array[0].Y = 0f;
			array[1].X = 10f;
			array[1].Z = 10f;
			array[1].Y = 10f;
			return array;
		}

		// Token: 0x06000A31 RID: 2609 RVA: 0x00002A71 File Offset: 0x00000C71
		public override void imethod_6(Device device_0)
		{
		}

		// Token: 0x06000A32 RID: 2610 RVA: 0x00086E44 File Offset: 0x00085044
		public override Image vmethod_4(Device device_0, XmlDocument xmlDocument_0, Size size_0)
		{
			Vector3 cameraPosition = Class132.smethod_0().CameraPosition;
			Vector3 cameraTarget = Class132.smethod_0().CameraTarget;
			Matrix cameraTranslation = Class132.smethod_0().CameraTranslation;
			Quaternion currentQuaternion = Class132.smethod_0().ArcBall.CurrentQuaternion;
			Surface renderTarget = device_0.GetRenderTarget(0);
			Surface surfaceLevel = this.texture_0.GetSurfaceLevel(0);
			device_0.SetRenderTarget(0, surfaceLevel);
			Surface surface = Surface.CreateDepthStencil(device_0, 1024, 1024, Format.D16, surfaceLevel.Description.MultisampleType, surfaceLevel.Description.MultisampleQuality, true);
			Surface depthStencilSurface = device_0.DepthStencilSurface;
			device_0.DepthStencilSurface = surface;
			device_0.BeginScene();
			Class140.smethod_0().method_9(RenderState.ZEnable, true);
			Class140.smethod_0().method_9(RenderState.AlphaBlendEnable, false);
			Class140.smethod_0().method_9(RenderState.AlphaTestEnable, false);
			Class140.smethod_0().method_9(RenderState.SeparateAlphaBlendEnable, false);
			Class140.smethod_0().method_9(RenderState.SourceBlend, Blend.SourceAlpha);
			Class140.smethod_0().method_9(RenderState.DestinationBlend, Blend.InverseSourceAlpha);
			device_0.Clear(ClearFlags.ZBuffer | ClearFlags.Target, Color.White, 1f, 0);
			Class132.smethod_0().method_26();
			Class132.smethod_0().method_27();
			Class140.smethod_0().method_9(RenderState.FillMode, FillMode.Solid);
			Class140.smethod_0().method_9(RenderState.CullMode, Cull.None);
			device_0.SetTransform(TransformState.World, Matrix.Identity * Matrix.RotationY(-0.2f));
			Class140.smethod_0().method_9(RenderState.Lighting, true);
			this.imethod_0(this.matrix_0, Class132.smethod_0().ViewMatrix, device_0);
			device_0.EndScene();
			device_0.DepthStencilSurface = depthStencilSurface;
			device_0.SetRenderTarget(0, renderTarget);
			surface.Dispose();
			DataStream dataStream = BaseTexture.ToStream(this.texture_0, ImageFileFormat.Bmp);
			Image image = Image.FromStream(dataStream);
			Image thumbnailImage = image.GetThumbnailImage(size_0.Width, size_0.Height, new Image.GetThumbnailImageAbort(base.method_2), IntPtr.Zero);
			image.Dispose();
			dataStream.Dispose();
			Class132.smethod_0().CameraPosition = cameraPosition;
			Class132.smethod_0().CameraTarget = cameraTarget;
			Class132.smethod_0().CameraTranslation = cameraTranslation;
			Class132.smethod_0().ArcBall.CurrentQuaternion = currentQuaternion;
			return thumbnailImage;
		}

		// Token: 0x06000A33 RID: 2611 RVA: 0x000870A0 File Offset: 0x000852A0
		public override void imethod_0(Matrix matrix_1, Matrix matrix_2, Device device_0)
		{
			this.matrix_0 = matrix_1;
			base.method_1(device_0, matrix_1);
			if (this.ShowFloors)
			{
				foreach (Class113 @class in this.list_11)
				{
					@class.method_4(device_0, matrix_1);
				}
			}
			if (this.ShowWalls)
			{
				foreach (Class131 class2 in this.list_10)
				{
					class2.method_4(device_0, matrix_1);
				}
			}
			if (this.ShowObjects)
			{
				foreach (Class115 class3 in this.list_12)
				{
					class3.method_9();
					class3.method_10(device_0, matrix_1);
				}
			}
			if (this.ShowDoorsAndWindows)
			{
				foreach (Class115 class4 in this.list_13)
				{
					class4.method_9();
					class4.method_10(device_0, matrix_1);
				}
			}
			if (this.ShowFootprint)
			{
				foreach (Interface9 @interface in base.Objects.Values)
				{
					Class121 class5 = (Class121)@interface;
					Class140.smethod_0().method_27("usePreset", false);
					class5.method_10(device_0, matrix_1, matrix_2, false);
				}
			}
		}

		// Token: 0x06000A34 RID: 2612 RVA: 0x00002A71 File Offset: 0x00000C71
		public override void vmethod_6(Matrix matrix_1, Matrix matrix_2, Device device_0)
		{
		}

		// Token: 0x06000A35 RID: 2613 RVA: 0x00002A71 File Offset: 0x00000C71
		public override void imethod_1(bool bool_10)
		{
		}

		// Token: 0x06000A36 RID: 2614 RVA: 0x00024BE0 File Offset: 0x00022DE0
		public override bool imethod_2()
		{
			return false;
		}

		// Token: 0x06000A37 RID: 2615 RVA: 0x00002A71 File Offset: 0x00000C71
		public override void imethod_3(bool bool_10)
		{
		}

		// Token: 0x06000A38 RID: 2616 RVA: 0x00037B84 File Offset: 0x00035D84
		public override bool imethod_4()
		{
			return true;
		}

		// Token: 0x0400082E RID: 2094
		public List<Class131> list_10;

		// Token: 0x0400082F RID: 2095
		public List<Class113> list_11;

		// Token: 0x04000830 RID: 2096
		public List<Class115> list_12;

		// Token: 0x04000831 RID: 2097
		public List<Class115> list_13;

		// Token: 0x04000832 RID: 2098
		private Texture texture_0;

		// Token: 0x04000833 RID: 2099
		private CultureInfo cultureInfo_0;

		// Token: 0x04000834 RID: 2100
		private Matrix matrix_0;

		// Token: 0x04000835 RID: 2101
		[CompilerGenerated]
		private bool bool_5;

		// Token: 0x04000836 RID: 2102
		[CompilerGenerated]
		private bool bool_6;

		// Token: 0x04000837 RID: 2103
		[CompilerGenerated]
		private bool bool_7;

		// Token: 0x04000838 RID: 2104
		[CompilerGenerated]
		private bool bool_8;

		// Token: 0x04000839 RID: 2105
		[CompilerGenerated]
		private bool bool_9;
	}
}
