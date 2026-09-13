using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using System.Xml;
using ns1;
using ns10;
using ns12;
using ns13;
using ns14;
using ns15;
using ns17;
using ns2;
using ns3;
using ns6;
using ns7;
using ns8;
using Package.Sims3Files;
using Package.Sims3Files.InternalRCOL;
using Sims3Workshop.Properties;
using Sims3WorkshopSDK;
using Sims3WorkshopSDK.Interfaces;
using SlimDX;
using SlimDX.Direct3D9;

namespace ns16
{
	// Token: 0x02000085 RID: 133
	internal sealed class MeshEditor : UserControl, IMeshEditor
	{
		// Token: 0x170000D1 RID: 209
		// (get) Token: 0x06000518 RID: 1304 RVA: 0x00050544 File Offset: 0x0004E744
		// (set) Token: 0x06000519 RID: 1305 RVA: 0x0005055C File Offset: 0x0004E75C
		public Interface2 SelectionDialog
		{
			get
			{
				return this.interface2_0;
			}
			set
			{
				Interface2 @interface = this.interface2_0;
				this.interface2_0 = value;
				if (@interface != null)
				{
					@interface.imethod_5();
				}
			}
		}

		// Token: 0x170000D2 RID: 210
		// (get) Token: 0x0600051A RID: 1306 RVA: 0x00050584 File Offset: 0x0004E784
		public Device Device
		{
			get
			{
				return this.device_0;
			}
		}

		// Token: 0x170000D3 RID: 211
		// (get) Token: 0x0600051B RID: 1307 RVA: 0x0005059C File Offset: 0x0004E79C
		public Panel RenderPanel
		{
			get
			{
				return this.panel_0;
			}
		}

		// Token: 0x170000D4 RID: 212
		// (get) Token: 0x0600051C RID: 1308 RVA: 0x000505B4 File Offset: 0x0004E7B4
		// (set) Token: 0x0600051D RID: 1309 RVA: 0x00004B36 File Offset: 0x00002D36
		public bool GroundEnabled { get; set; }

		// Token: 0x170000D5 RID: 213
		// (get) Token: 0x0600051E RID: 1310 RVA: 0x000505CC File Offset: 0x0004E7CC
		// (set) Token: 0x0600051F RID: 1311 RVA: 0x00004B41 File Offset: 0x00002D41
		public bool BumpMapEnabled { get; set; }

		// Token: 0x170000D6 RID: 214
		// (get) Token: 0x06000520 RID: 1312 RVA: 0x000505E4 File Offset: 0x0004E7E4
		// (set) Token: 0x06000521 RID: 1313 RVA: 0x00004B4C File Offset: 0x00002D4C
		public bool GridEnabled { get; set; }

		// Token: 0x170000D7 RID: 215
		// (get) Token: 0x06000522 RID: 1314 RVA: 0x000505FC File Offset: 0x0004E7FC
		// (set) Token: 0x06000523 RID: 1315 RVA: 0x00004B57 File Offset: 0x00002D57
		public bool NormalsEnabled { get; set; }

		// Token: 0x170000D8 RID: 216
		// (get) Token: 0x06000524 RID: 1316 RVA: 0x00050614 File Offset: 0x0004E814
		// (set) Token: 0x06000525 RID: 1317 RVA: 0x00004B62 File Offset: 0x00002D62
		public bool Wireframe { get; set; }

		// Token: 0x170000D9 RID: 217
		// (get) Token: 0x06000526 RID: 1318 RVA: 0x0005062C File Offset: 0x0004E82C
		// (set) Token: 0x06000527 RID: 1319 RVA: 0x00004B6D File Offset: 0x00002D6D
		public bool EffectsDisabled { get; set; }

		// Token: 0x170000DA RID: 218
		// (get) Token: 0x06000528 RID: 1320 RVA: 0x00050644 File Offset: 0x0004E844
		public int Fps
		{
			get
			{
				return this.int_0;
			}
		}

		// Token: 0x170000DB RID: 219
		// (get) Token: 0x06000529 RID: 1321 RVA: 0x0005065C File Offset: 0x0004E85C
		public Texture BlankTexture
		{
			get
			{
				return this.texture_2;
			}
		}

		// Token: 0x170000DC RID: 220
		// (get) Token: 0x0600052A RID: 1322 RVA: 0x00050674 File Offset: 0x0004E874
		public List<Class102> Renderables
		{
			get
			{
				return this.list_0;
			}
		}

		// Token: 0x170000DD RID: 221
		// (get) Token: 0x0600052B RID: 1323 RVA: 0x0005068C File Offset: 0x0004E88C
		// (set) Token: 0x0600052C RID: 1324 RVA: 0x00004B78 File Offset: 0x00002D78
		public float Yaw
		{
			get
			{
				return this.float_0;
			}
			set
			{
				this.float_0 = value;
			}
		}

		// Token: 0x170000DE RID: 222
		// (get) Token: 0x0600052D RID: 1325 RVA: 0x000506A4 File Offset: 0x0004E8A4
		// (set) Token: 0x0600052E RID: 1326 RVA: 0x00004B83 File Offset: 0x00002D83
		public float Pitch
		{
			get
			{
				return this.float_1;
			}
			set
			{
				this.float_1 = value;
			}
		}

		// Token: 0x170000DF RID: 223
		// (set) Token: 0x0600052F RID: 1327 RVA: 0x00004B8E File Offset: 0x00002D8E
		public MeshEditor.Enum8 GroundEffect
		{
			set
			{
				this.string_0 = ((value == MeshEditor.Enum8.const_0) ? "Ground" : "Terrain");
			}
		}

		// Token: 0x170000E0 RID: 224
		// (get) Token: 0x06000530 RID: 1328 RVA: 0x000506BC File Offset: 0x0004E8BC
		public Image SelectionOverlay
		{
			get
			{
				return this.image_0;
			}
		}

		// Token: 0x06000531 RID: 1329 RVA: 0x000506D4 File Offset: 0x0004E8D4
		public MeshEditor()
		{
			this.InitializeComponent();
			this.EffectsDisabled = false;
			this.list_0 = new List<Class102>();
			this.class100_0 = new Class100();
			this.GridEnabled = false;
			this.method_0();
			this.bool_0 = true;
			this.mesh_0 = new Mesh[6];
			this.matrix_3 = new Matrix[18];
		}

		// Token: 0x06000532 RID: 1330 RVA: 0x00050804 File Offset: 0x0004EA04
		public void method_0()
		{
			this.vector3_0 = new Vector3(0f, 3f, -6f);
			this.float_0 = 0f;
			this.float_1 = 0f;
			this.class100_0.TranslationMatrix = Matrix.Identity;
			this.class100_0.CurrentQuaternion = Quaternion.RotationMatrix(Matrix.Identity);
		}

		// Token: 0x06000533 RID: 1331 RVA: 0x00050868 File Offset: 0x0004EA68
		protected void Dispose(bool disposing)
		{
			this.texture_2.Dispose();
			this.texture_0.Dispose();
			this.texture_1.Dispose();
			this.surface_1.Dispose();
			this.surface_3.Dispose();
			this.surface_0.Dispose();
			this.surface_2.Dispose();
			EditorToolBox.smethod_1(disposing);
			if (disposing)
			{
				this.texture_3.Dispose();
				this.vertexBuffer_1.Dispose();
				this._boundingBoxBuffer.Dispose();
				this.vertexBuffer_0.Dispose();
				this.font_0.Dispose();
				foreach (Mesh mesh in this.mesh_0)
				{
					mesh.Dispose();
				}
				base.Dispose(disposing);
			}
			foreach (object obj in Class27.hashtable_0.Values)
			{
				Texture texture = (Texture)obj;
				texture.Dispose();
			}
			Class27.hashtable_0.Clear();
		}

		// Token: 0x06000534 RID: 1332 RVA: 0x0005098C File Offset: 0x0004EB8C
		public void method_1(XmlDocument xmlDocument_0)
		{
			foreach (Class102 @class in this.list_0)
			{
				@class.vmethod_3(xmlDocument_0);
			}
		}

		// Token: 0x06000535 RID: 1333 RVA: 0x00004BA8 File Offset: 0x00002DA8
		public void method_2(Class102 class102_0)
		{
			class102_0.imethod_6(this.device_0);
			class102_0.imethod_12(this.s_CLIP_0);
			this.list_0.Add(class102_0);
		}

		// Token: 0x06000536 RID: 1334 RVA: 0x00004BD0 File Offset: 0x00002DD0
		public void method_3(Class102 class102_0)
		{
			class102_0.imethod_7(this.device_0);
		}

		// Token: 0x06000537 RID: 1335 RVA: 0x000509E4 File Offset: 0x0004EBE4
		public Texture method_4(Size size_0)
		{
			return this.method_5(this.device_0, size_0);
		}

		// Token: 0x06000538 RID: 1336 RVA: 0x00050A04 File Offset: 0x0004EC04
		public Texture method_5(Device device_1, Size size_0)
		{
			return new Texture(device_1, Math.Abs(size_0.Width), Math.Abs(size_0.Height), 1, Usage.RenderTarget, Format.A8R8G8B8, Pool.Default);
		}

		// Token: 0x06000539 RID: 1337 RVA: 0x00050A38 File Offset: 0x0004EC38
		public Surface method_6(Device device_1, Surface surface_4)
		{
			return Surface.CreateDepthStencil(device_1, surface_4.Description.Width, surface_4.Description.Height, Format.D16, surface_4.Description.MultisampleType, surface_4.Description.MultisampleQuality, true);
		}

		// Token: 0x0600053A RID: 1338 RVA: 0x00050A8C File Offset: 0x0004EC8C
		public Interface3 method_7()
		{
			return new Class27(new Size(this.class140_0.DefaultRenderTarget.Description.Width, this.class140_0.DefaultRenderTarget.Description.Height));
		}

		// Token: 0x0600053B RID: 1339 RVA: 0x00050AD8 File Offset: 0x0004ECD8
		public Interface3 method_8(Size size_0)
		{
			return new Class27(size_0);
		}

		// Token: 0x0600053C RID: 1340 RVA: 0x00050AF0 File Offset: 0x0004ECF0
		public void method_9(ref Bitmap bitmap_0, Interface3 interface3_0, Texture texture_4, string string_2, Size size_0, XmlElement xmlElement_0, XmlElement xmlElement_1, string string_3, string string_4)
		{
			this.method_10(ref bitmap_0, interface3_0, texture_4, string_2, size_0, xmlElement_0, xmlElement_1, string_3, string_4, null);
		}

		// Token: 0x0600053D RID: 1341 RVA: 0x00050B18 File Offset: 0x0004ED18
		public void method_10(ref Bitmap bitmap_0, Interface3 interface3_0, Texture texture_4, string string_2, Size size_0, XmlElement xmlElement_0, XmlElement xmlElement_1, string string_3, string string_4, ResKey resKey_0)
		{
			XmlDocument xmlDocument = new XmlDocument();
			XmlElement xmlElement = xmlDocument.CreateElement("preset");
			XmlElement xmlElement2 = xmlDocument.CreateElement("complate");
			if (resKey_0 == null)
			{
				resKey_0 = new ResKey("key:0333406c:00000000:c6781323ce337c54");
			}
			xmlElement2.Attributes.Append(XML.CreateAttribute(xmlDocument, "reskey", resKey_0.AsString()));
			xmlElement.AppendChild(xmlElement2);
			XmlElement xmlElement3 = xmlDocument.CreateElement("pattern");
			xmlElement3.Attributes.Append(XML.CreateAttribute(xmlDocument, "name", "solidColor_1"));
			xmlElement3.Attributes.Append(XML.CreateAttribute(xmlDocument, "reskey", string_2));
			xmlElement3.Attributes.Append(XML.CreateAttribute(xmlDocument, "variable", "Pattern A"));
			XmlElement xmlElement4 = xmlDocument.CreateElement("value");
			xmlElement4.Attributes.Append(XML.CreateAttribute(xmlDocument, "key", "Pattern A Enabled"));
			xmlElement4.Attributes.Append(XML.CreateAttribute(xmlDocument, "value", "true"));
			xmlElement2.AppendChild(xmlElement4);
			XmlElement xmlElement5 = xmlDocument.CreateElement("pattern");
			xmlElement5.Attributes.Append(XML.CreateAttribute(xmlDocument, "name", "solidColor_1"));
			xmlElement5.Attributes.Append(XML.CreateAttribute(xmlDocument, "reskey", string_2));
			xmlElement5.Attributes.Append(XML.CreateAttribute(xmlDocument, "variable", "Pattern B"));
			XmlElement xmlElement6 = xmlDocument.CreateElement("value");
			xmlElement6.Attributes.Append(XML.CreateAttribute(xmlDocument, "key", "Pattern B Enabled"));
			xmlElement6.Attributes.Append(XML.CreateAttribute(xmlDocument, "value", "true"));
			if (xmlElement_0 != null)
			{
				XmlNodeList xmlNodeList = xmlElement_0.SelectNodes("value");
				foreach (object obj in xmlNodeList)
				{
					XmlNode xmlNode = (XmlNode)obj;
					XmlElement xmlElement7 = xmlDocument.CreateElement("value");
					xmlElement7.Attributes.Append(XML.CreateAttribute(xmlDocument, "key", xmlNode.Attributes["key"].Value));
					xmlElement7.Attributes.Append(XML.CreateAttribute(xmlDocument, "value", xmlNode.Attributes["value"].Value));
					xmlElement3.AppendChild(xmlElement7);
				}
			}
			xmlElement2.AppendChild(xmlElement6);
			xmlElement2.AppendChild(xmlElement3);
			xmlElement2.AppendChild(xmlElement5);
			xmlDocument.AppendChild(xmlElement);
			interface3_0.imethod_0(this.device_0, xmlDocument, xmlElement_1, string_3, string_4, texture_4);
			DataStream dataStream = BaseTexture.ToStream(texture_4, ImageFileFormat.Png);
			bitmap_0 = (Image.FromStream(dataStream) as Bitmap);
			dataStream.Dispose();
			xmlDocument = null;
		}

		// Token: 0x0600053E RID: 1342 RVA: 0x00050E00 File Offset: 0x0004F000
		public void method_11(string string_2, ImageFileFormat imageFileFormat_0, XmlDocument xmlDocument_0, Size size_0, string string_3, string string_4)
		{
			Texture texture = new Texture(this.device_0, size_0.Width, size_0.Height, 1, Usage.RenderTarget, Format.A8R8G8B8, Pool.Default);
			Class27 @class = new Class27(size_0);
			@class.imethod_0(this.device_0, xmlDocument_0, null, string_3, string_4, texture);
			BaseTexture.ToFile(texture, string_2, imageFileFormat_0);
			texture.Dispose();
			@class.imethod_2(true);
		}

		// Token: 0x0600053F RID: 1343 RVA: 0x00050E60 File Offset: 0x0004F060
		public Image method_12(XmlDocument xmlDocument_0, Size size_0, string string_2, string string_3)
		{
			Texture texture = new Texture(this.device_0, size_0.Width, size_0.Height, 1, Usage.RenderTarget, Format.A8R8G8B8, Pool.Default);
			Class27 @class = new Class27(new Size(this.class140_0.DefaultRenderTarget.Description.Width, this.class140_0.DefaultRenderTarget.Description.Height));
			@class.imethod_0(this.device_0, xmlDocument_0, null, string_2, string_3, texture);
			DataStream dataStream = BaseTexture.ToStream(texture, ImageFileFormat.Png);
			Image result = Image.FromStream(dataStream);
			dataStream.Dispose();
			texture.Dispose();
			@class.imethod_2(true);
			return result;
		}

		// Token: 0x06000540 RID: 1344 RVA: 0x00050F08 File Offset: 0x0004F108
		public Image method_13(string string_2, Size size_0, XmlElement xmlElement_0, XmlElement xmlElement_1, string string_3, string string_4)
		{
			string xml = string.Concat(new string[]
			{
				"<preset><complate name=\"pattern\" reskey=\"",
				string_2,
				"\">",
				(xmlElement_0 != null) ? xmlElement_0.InnerXml : "",
				"</complate></preset>"
			});
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.LoadXml(xml);
			Texture texture = new Texture(this.device_0, size_0.Width, size_0.Height, 1, Usage.RenderTarget, Format.A8R8G8B8, Pool.Default);
			Class27 @class = new Class27(new Size(this.class140_0.DefaultRenderTarget.Description.Width, this.class140_0.DefaultRenderTarget.Description.Height));
			@class.imethod_0(this.device_0, xmlDocument, xmlElement_1, string_3, string_4, texture);
			DataStream dataStream = BaseTexture.ToStream(texture, ImageFileFormat.Png);
			Image result = Image.FromStream(dataStream);
			dataStream.Dispose();
			texture.Dispose();
			@class.imethod_2(true);
			return result;
		}

		// Token: 0x06000541 RID: 1345 RVA: 0x00051008 File Offset: 0x0004F208
		public void method_14(Texture texture_4)
		{
			Surface renderTarget = this.device_0.GetRenderTarget(0);
			Surface depthStencilSurface = this.device_0.DepthStencilSurface;
			Surface surfaceLevel = texture_4.GetSurfaceLevel(0);
			Surface surface = Surface.CreateDepthStencil(this.device_0, surfaceLevel.Description.Width, surfaceLevel.Description.Height, Format.D16, surfaceLevel.Description.MultisampleType, surfaceLevel.Description.MultisampleQuality, true);
			this.device_0.SetRenderTarget(0, surfaceLevel);
			this.device_0.DepthStencilSurface = surface;
			this.device_0.Clear(ClearFlags.Target, 0, 1f, 0);
			this.device_0.SetRenderTarget(0, renderTarget);
			this.device_0.DepthStencilSurface = depthStencilSurface;
			surface.Dispose();
		}

		// Token: 0x06000542 RID: 1346 RVA: 0x000510D4 File Offset: 0x0004F2D4
		public bool method_15(Interface3 interface3_0, XmlDocument xmlDocument_0, string string_2, string string_3, Texture texture_4)
		{
			return interface3_0.imethod_0(this.device_0, xmlDocument_0, null, string_2, string_3, texture_4);
		}

		// Token: 0x06000543 RID: 1347 RVA: 0x000510F8 File Offset: 0x0004F2F8
		public void method_16(Texture texture_4, Texture[] texture_5)
		{
			Surface renderTarget = this.device_0.GetRenderTarget(0);
			Surface depthStencilSurface = this.device_0.DepthStencilSurface;
			Surface surfaceLevel = texture_4.GetSurfaceLevel(0);
			Surface surface = Surface.CreateDepthStencil(this.device_0, surfaceLevel.Description.Width, surfaceLevel.Description.Height, Format.D16, surfaceLevel.Description.MultisampleType, surfaceLevel.Description.MultisampleQuality, true);
			this.device_0.SetRenderTarget(0, surfaceLevel);
			this.device_0.DepthStencilSurface = surface;
			this.class140_0.method_9(RenderState.ZEnable, false);
			this.class140_0.method_9(RenderState.AlphaBlendEnable, true);
			this.class140_0.method_9(RenderState.AlphaTestEnable, false);
			this.device_0.BeginScene();
			this.device_0.Clear(ClearFlags.Target, 0, 1f, 0);
			foreach (Texture texture in texture_5)
			{
				Sprite sprite = new Sprite(this.device_0);
				sprite.Begin(SpriteFlags.AlphaBlend);
				sprite.Draw(texture, new Vector3?(Vector3.Zero), new Vector3?(Vector3.Zero), new Color4(Color.White));
				sprite.End();
				sprite.Dispose();
			}
			this.device_0.EndScene();
			this.device_0.Present();
			this.device_0.SetRenderTarget(0, renderTarget);
			this.device_0.DepthStencilSurface = depthStencilSurface;
			surface.Dispose();
		}

		// Token: 0x06000544 RID: 1348 RVA: 0x00051288 File Offset: 0x0004F488
		public void method_17(Texture texture_4, Texture texture_5)
		{
			Surface renderTarget = this.device_0.GetRenderTarget(0);
			Surface depthStencilSurface = this.device_0.DepthStencilSurface;
			Surface surfaceLevel = texture_4.GetSurfaceLevel(0);
			Surface surface = Surface.CreateDepthStencil(this.device_0, surfaceLevel.Description.Width, surfaceLevel.Description.Height, Format.D16, surfaceLevel.Description.MultisampleType, surfaceLevel.Description.MultisampleQuality, true);
			this.device_0.SetRenderTarget(0, surfaceLevel);
			this.device_0.DepthStencilSurface = surface;
			this.class140_0.method_9(RenderState.ZEnable, false);
			this.class140_0.method_9(RenderState.AlphaBlendEnable, true);
			this.class140_0.method_9(RenderState.AlphaTestEnable, false);
			this.device_0.BeginScene();
			Sprite sprite = new Sprite(this.device_0);
			sprite.Begin(SpriteFlags.AlphaBlend);
			sprite.Draw(texture_5, new Vector3?(Vector3.Zero), new Vector3?(Vector3.Zero), new Color4(Color.White));
			sprite.End();
			this.device_0.EndScene();
			this.device_0.Present();
			this.device_0.SetRenderTarget(0, renderTarget);
			this.device_0.DepthStencilSurface = depthStencilSurface;
			sprite.Dispose();
			surface.Dispose();
		}

		// Token: 0x06000545 RID: 1349 RVA: 0x000513E8 File Offset: 0x0004F5E8
		public void method_18(Texture texture_4, DDS dds_0)
		{
			byte[] data = dds_0.GetData();
			MemoryStream memoryStream = new MemoryStream(data);
			Texture texture = Texture.FromStream(this.device_0, memoryStream);
			memoryStream.Dispose();
			Surface renderTarget = this.device_0.GetRenderTarget(0);
			Surface depthStencilSurface = this.device_0.DepthStencilSurface;
			Surface surfaceLevel = texture_4.GetSurfaceLevel(0);
			Surface surface = Surface.CreateDepthStencil(this.device_0, surfaceLevel.Description.Width, surfaceLevel.Description.Height, Format.D16, surfaceLevel.Description.MultisampleType, surfaceLevel.Description.MultisampleQuality, true);
			this.device_0.SetRenderTarget(0, surfaceLevel);
			this.device_0.DepthStencilSurface = surface;
			this.class140_0.method_9(RenderState.ZEnable, false);
			this.class140_0.method_9(RenderState.AlphaBlendEnable, true);
			this.class140_0.method_9(RenderState.AlphaTestEnable, false);
			this.device_0.BeginScene();
			Sprite sprite = new Sprite(this.device_0);
			sprite.Transform = Matrix.Scaling(new Vector3(1f, 1f, 0f));
			sprite.Begin(SpriteFlags.AlphaBlend);
			sprite.Draw(texture, new Rectangle?(new Rectangle(0, 0, 1024, 1024)), new Vector3?(Vector3.Zero), new Vector3?(Vector3.Zero), new Color4(Color.White));
			sprite.End();
			this.device_0.EndScene();
			this.device_0.Present();
			this.device_0.SetRenderTarget(0, renderTarget);
			this.device_0.DepthStencilSurface = depthStencilSurface;
			surface.Dispose();
			sprite.Dispose();
			texture.Dispose();
		}

		// Token: 0x06000546 RID: 1350 RVA: 0x000515B0 File Offset: 0x0004F7B0
		public Image method_19(Class102 class102_0, XmlDocument xmlDocument_0, Size size_0)
		{
			return class102_0.vmethod_4(this.device_0, xmlDocument_0, size_0);
		}

		// Token: 0x06000547 RID: 1351 RVA: 0x000515D0 File Offset: 0x0004F7D0
		public void method_20()
		{
			if (Class132.mainForm.CurrentProjectModel is Class80)
			{
				Interface2 @interface = this.interface2_0;
				if (@interface != null)
				{
					(@interface as Form).Dispose();
				}
			}
			foreach (Class102 @class in this.list_0)
			{
				@class.imethod_8(true);
			}
			this.list_0.Clear();
		}

		// Token: 0x170000E1 RID: 225
		// (get) Token: 0x06000548 RID: 1352 RVA: 0x00051658 File Offset: 0x0004F858
		public SlimDX.Direct3D9.Font TextFont
		{
			get
			{
				return this.font_0;
			}
		}

		// Token: 0x170000E2 RID: 226
		// (get) Token: 0x06000549 RID: 1353 RVA: 0x00051670 File Offset: 0x0004F870
		// (set) Token: 0x0600054A RID: 1354 RVA: 0x00004BE0 File Offset: 0x00002DE0
		public string CursorText
		{
			get
			{
				return this.string_1;
			}
			set
			{
				this.string_1 = value;
			}
		}

		// Token: 0x0600054B RID: 1355 RVA: 0x00051688 File Offset: 0x0004F888
		public int method_21()
		{
			this.class140_0 = Class140.smethod_0();
			int result;
			if (this.class140_0 == null)
			{
				result = Class140.InitializeError;
			}
			else
			{
				Device device = this.class140_0.Device;
				System.Drawing.Font font = new System.Drawing.Font("Tahoma", 11f, FontStyle.Regular, GraphicsUnit.Pixel);
				this.font_0 = new SlimDX.Direct3D9.Font(device, font);
				this.class140_0.OnDeviceReset += this.method_23;
				this.class140_0.OnDeviceReseted += this.method_24;
				this.device_0 = this.class140_0.Device;
				this.struct7_0 = new Class112.Struct7[this.int_2];
				for (int i = 0; i < this.int_2; i++)
				{
					this.struct7_0[i] = new Class112.Struct7(new Vector3((float)i, (float)i, (float)i), 0.5f, Color.Gray.ToArgb());
				}
				this.mesh_0[0] = Mesh.CreateCylinder(device, 0.02f, 0f, 0.06f, 24, 24);
				this.mesh_0[1] = Mesh.CreateCylinder(device, 0.02f, 0f, 0.06f, 24, 24);
				this.mesh_0[2] = Mesh.CreateCylinder(device, 0.02f, 0f, 0.06f, 24, 24);
				this.mesh_0[3] = Mesh.CreateCylinder(device, 0.02f, 0f, 0.06f, 24, 24);
				this.mesh_0[4] = Mesh.CreateCylinder(device, 0.02f, 0f, 0.06f, 24, 24);
				this.mesh_0[5] = Mesh.CreateCylinder(device, 0.02f, 0f, 0.06f, 24, 24);
				this._boundingBoxBuffer = new VertexBuffer(this.device_0, this.int_2 * Class112.Struct7.SizeInBytes, Usage.None, Class112.Struct7.vertexFormat_0, Pool.Managed);
				DataStream dataStream = this._boundingBoxBuffer.Lock(0, 0, LockFlags.None);
				dataStream.WriteRange<Class112.Struct7>(this.struct7_0, 0, this.int_2);
				this._boundingBoxBuffer.Unlock();
				dataStream.Dispose();
				float num = 0.25f;
				float num2 = 6f;
				Class112.Struct7[] array = new Class112.Struct7[(int)Math.Ceiling((double)48f) * 4 + 4];
				int num3 = 0;
				int num4 = Settings.Default.GridColor.ToArgb();
				int num5 = Color.Blue.ToArgb();
				float y = 0.01f;
				for (float num6 = -6f; num6 < num2; num6 += num)
				{
					int color = (num6 == 0f) ? num5 : num4;
					array[num3++] = new Class112.Struct7(new Vector3(num6, y, num2), 0.1f, color);
					array[num3++] = new Class112.Struct7(new Vector3(num6, y, -num2), 0.1f, color);
					array[num3++] = new Class112.Struct7(new Vector3(-num2, y, num6), 0.1f, color);
					array[num3++] = new Class112.Struct7(new Vector3(num2, y, num6), 0.1f, color);
					this.int_1 += 2;
				}
				array[num3++] = new Class112.Struct7(new Vector3(num2, y, num2), 0.1f, num4);
				array[num3++] = new Class112.Struct7(new Vector3(num2, y, -num2), 0.1f, num4);
				array[num3++] = new Class112.Struct7(new Vector3(-num2, y, num2), 0.1f, num4);
				array[num3++] = new Class112.Struct7(new Vector3(num2, y, num2), 0.1f, num4);
				this.int_1 += 2;
				this.vertexBuffer_0 = new VertexBuffer(this.device_0, array.Length * Class112.Struct7.SizeInBytes, Usage.None, Class112.Struct7.vertexFormat_0, Pool.Managed);
				DataStream dataStream2 = this.vertexBuffer_0.Lock(0, 0, LockFlags.None);
				dataStream2.WriteRange<Class112.Struct7>(array);
				this.vertexBuffer_0.Unlock();
				this.vertexBuffer_1 = new VertexBuffer(this.device_0, 6 * Class112.Struct7.SizeInBytes, Usage.None, Class112.Struct7.vertexFormat_0, Pool.Managed);
				Class112.Struct7[] data = new Class112.Struct7[]
				{
					new Class112.Struct7(new Vector3(6f, -0.02f, -6f), num4, new Vector2(1f, 0f)),
					new Class112.Struct7(new Vector3(-6f, -0.02f, -6f), num4, new Vector2(0f, 0f)),
					new Class112.Struct7(new Vector3(-6f, -0.02f, 6f), num4, new Vector2(0f, 1f)),
					new Class112.Struct7(new Vector3(-6f, -0.02f, 6f), num4, new Vector2(0f, 1f)),
					new Class112.Struct7(new Vector3(6f, -0.02f, 6f), num4, new Vector2(1f, 1f)),
					new Class112.Struct7(new Vector3(6f, -0.02f, -6f), num4, new Vector2(1f, 0f))
				};
				dataStream2 = this.vertexBuffer_1.Lock(0, 0, LockFlags.None);
				dataStream2.WriteRange<Class112.Struct7>(data);
				this.vertexBuffer_1.Unlock();
				this.material_0 = default(Material);
				this.material_0.Ambient = (this.material_0.Diffuse = (this.material_0.Specular = Color.Red));
				Stream stream = new MemoryStream();
				Class143.checker.Save(stream, ImageFormat.Bmp);
				stream.Position = 0L;
				this.texture_3 = Texture.FromStream(this.device_0, stream);
				this.method_22();
				result = 0;
			}
			return result;
		}

		// Token: 0x0600054C RID: 1356 RVA: 0x00051CF0 File Offset: 0x0004FEF0
		private void method_22()
		{
			try
			{
				Capabilities deviceCaps = this.class140_0.DeviceCaps;
				Format format = Format.R32F;
				if (this.class140_0.method_0(this.class140_0.DefaultRenderTarget.Description.Format, Usage.RenderTarget, ResourceType.Texture, Format.R32F))
				{
					format = Format.R32F;
				}
				else if (this.class140_0.method_0(this.class140_0.DefaultRenderTarget.Description.Format, Usage.RenderTarget, ResourceType.Texture, Format.R16F))
				{
					format = Format.R16F;
				}
				else if (this.class140_0.method_0(this.class140_0.DefaultRenderTarget.Description.Format, Usage.RenderTarget, ResourceType.Texture, Format.A8R8G8B8))
				{
					format = Format.A8R8G8B8;
				}
				Bitmap bitmap = new Bitmap(256, 256);
				Graphics.FromImage(bitmap).FillRectangle(new SolidBrush(Color.FromArgb(180, Color.Yellow)), new Rectangle(0, 0, 256, 256));
				MemoryStream memoryStream = new MemoryStream();
				bitmap.Save(memoryStream, ImageFormat.Bmp);
				memoryStream.Position = 0L;
				this.texture_2 = Texture.FromStream(this.class140_0.Device, memoryStream);
				memoryStream.Dispose();
				bitmap.Dispose();
				this.texture_0 = new Texture(this.device_0, Math.Min(2048, deviceCaps.MaxTextureWidth), Math.Min(2048, deviceCaps.MaxTextureHeight), 1, Usage.RenderTarget, format, Pool.Default);
				this.texture_1 = new Texture(this.device_0, Math.Min(2048, deviceCaps.MaxTextureWidth), Math.Min(2048, deviceCaps.MaxTextureHeight), 1, Usage.RenderTarget, format, Pool.Default);
				this.device_0.GetRenderTarget(0);
				this.surface_2 = this.texture_1.GetSurfaceLevel(0);
				this.surface_3 = Surface.CreateDepthStencil(this.device_0, this.surface_2.Description.Width, this.surface_2.Description.Height, Format.D16, this.surface_2.Description.MultisampleType, this.surface_2.Description.MultisampleQuality, false);
				this.surface_0 = this.texture_0.GetSurfaceLevel(0);
				this.surface_1 = Surface.CreateDepthStencil(this.device_0, this.surface_0.Description.Width, this.surface_0.Description.Height, Format.D16, this.surface_0.Description.MultisampleType, this.surface_0.Description.MultisampleQuality, false);
			}
			catch (Exception ex)
			{
				this.texture_0 = null;
				this.surface_0 = null;
				this.surface_2 = null;
				this.surface_1 = null;
				this.surface_3 = null;
				MessageBox.Show(Class132.mainForm, "Could not create shadowmap texture.\n\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
		}

		// Token: 0x0600054D RID: 1357 RVA: 0x00051FEC File Offset: 0x000501EC
		private void method_23(object sender, EventArgs3 e)
		{
			this.Dispose(false);
			foreach (Class102 @class in this.list_0)
			{
				@class.imethod_5(this.device_0);
			}
		}

		// Token: 0x0600054E RID: 1358 RVA: 0x00052050 File Offset: 0x00050250
		private void method_24(object sender, EventArgs3 e)
		{
			this.method_22();
			EditorToolBox.smethod_2(this.device_0);
			foreach (Class102 @class in this.list_0)
			{
				@class.vmethod_7(this.device_0);
			}
		}

		// Token: 0x0600054F RID: 1359 RVA: 0x000520BC File Offset: 0x000502BC
		public bool method_25(Class102 class102_0)
		{
			if (class102_0 != null)
			{
				List<Class102> list = new List<Class102>();
				foreach (Class102 @class in this.list_0)
				{
					if (@class == class102_0)
					{
						list.Add(class102_0);
					}
				}
				foreach (Class102 class2 in list)
				{
					class2.imethod_8(true);
					this.list_0.Remove(class2);
				}
			}
			return true;
		}

		// Token: 0x170000E3 RID: 227
		// (get) Token: 0x06000550 RID: 1360 RVA: 0x00052174 File Offset: 0x00050374
		public Matrix WorldMatrix
		{
			get
			{
				return this.matrix_4;
			}
		}

		// Token: 0x170000E4 RID: 228
		// (get) Token: 0x06000551 RID: 1361 RVA: 0x0005218C File Offset: 0x0005038C
		public Viewport ViewPort
		{
			get
			{
				return new Viewport(0, 0, this.panel_0.Width, this.panel_0.Height);
			}
		}

		// Token: 0x06000552 RID: 1362 RVA: 0x000521BC File Offset: 0x000503BC
		public void method_26()
		{
			this.matrix_0 = Matrix.PerspectiveFovRH(0.7853982f, (float)this.panel_0.Width / (float)this.panel_0.Height, 0.1f, 500f);
			this.matrix_1 = Matrix.PerspectiveFovRH(0.7853982f, (float)this.panel_0.Width / (float)this.panel_0.Height, 0.1f, 500f);
			Vector3 eye = new Vector3((float)-2.8000000417232513, (float)12.000000178813934, (float)-4.800000071525574);
			this.matrix_6 = Matrix.LookAtRH(eye, new Vector3(0f, 0f, 0f), new Vector3(0f, 1f, 0f));
			if (this.enum9_0 == MeshEditor.Enum9.const_0)
			{
				Vector3 eye2 = Vector3.TransformCoordinate(this.vector3_0, this.class100_0.TranslationMatrix);
				this.matrix_2 = Matrix.LookAtRH(eye2, Vector3.TransformCoordinate(this.vector3_2, this.class100_0.TranslationMatrix), this.vector3_1);
				this.matrix_4 = Matrix.RotationY(this.float_0) * Matrix.RotationX(this.float_1);
				this.matrix_5 = Matrix.Transpose(Matrix.Invert(this.matrix_4));
			}
			else
			{
				this.matrix_2 = Matrix.LookAtRH(this.vector3_0, this.vector3_2, this.vector3_1);
				this.matrix_4 = Matrix.Identity;
			}
			this.device_0.SetTransform(TransformState.Projection, this.matrix_0);
			this.device_0.SetTransform(TransformState.View, this.matrix_2);
			this.device_0.SetTransform(TransformState.World, this.matrix_4);
		}

		// Token: 0x170000E5 RID: 229
		// (get) Token: 0x06000553 RID: 1363 RVA: 0x00052374 File Offset: 0x00050574
		public Matrix ViewMatrix
		{
			get
			{
				return this.matrix_2;
			}
		}

		// Token: 0x170000E6 RID: 230
		// (get) Token: 0x06000554 RID: 1364 RVA: 0x0005238C File Offset: 0x0005058C
		public Matrix ProjectionMatrix
		{
			get
			{
				return this.matrix_0;
			}
		}

		// Token: 0x06000555 RID: 1365 RVA: 0x000523A4 File Offset: 0x000505A4
		public void method_27()
		{
			Light lightData = default(Light);
			lightData.Type = LightType.Point;
			lightData.Diffuse = Color.FromArgb(255, 255, 255, 255);
			lightData.Ambient = Settings.Default.AmbientLighting;
			Vector3 direction = new Vector3(0f, -1f, -1f);
			direction.Normalize();
			lightData.Direction = direction;
			lightData.Range = 10f;
			lightData.Falloff = 0f;
			lightData.Position = new Vector3(0f, 5f, -0.5f);
			lightData.Attenuation0 = 0.8f;
			lightData.Specular = Color.FromArgb(255, 127, 127, 127);
			this.device_0.EnableLight(0, true);
			this.device_0.SetLight(0, lightData);
			Light lightData2 = default(Light);
			lightData2.Type = LightType.Directional;
			lightData2.Diffuse = (lightData2.Ambient = (lightData2.Specular = Color.Red));
			lightData2.Direction = direction;
			lightData2.Position = new Vector3(0f, 5f, -0.5f);
			this.device_0.EnableLight(1, false);
			this.device_0.SetLight(1, lightData2);
		}

		// Token: 0x06000556 RID: 1366 RVA: 0x00004BEB File Offset: 0x00002DEB
		public void method_28(Interface9 interface9_0, MATD matd_0)
		{
			interface9_0.imethod_2(this.device_0, matd_0);
		}

		// Token: 0x06000557 RID: 1367 RVA: 0x00052510 File Offset: 0x00050710
		public void method_29(Material material_1)
		{
			material_1.Ambient = Settings.Default.AmbientLighting;
			this.class140_0.method_31("g_diffuse", material_1.Diffuse);
			this.class140_0.method_31("g_specular", material_1.Specular);
			this.class140_0.method_31("g_ambient", material_1.Ambient);
			this.class140_0.method_28("g_fspecPower", material_1.Power);
			this.class140_0.method_35();
		}

		// Token: 0x06000558 RID: 1368 RVA: 0x00004BFC File Offset: 0x00002DFC
		public void method_30(MATD matd_0)
		{
			this.method_32(matd_0);
		}

		// Token: 0x06000559 RID: 1369 RVA: 0x00004BFC File Offset: 0x00002DFC
		public void method_31(MATD.InternalMATD internalMATD_0)
		{
			this.method_32(internalMATD_0);
		}

		// Token: 0x0600055A RID: 1370 RVA: 0x000525A0 File Offset: 0x000507A0
		private void method_32(object object_0)
		{
			if (!this.EffectsDisabled)
			{
				this.class140_0.method_40("ObjectPhong");
				this.class140_0.method_9(RenderState.AlphaTestEnable, false);
				this.class140_0.method_9(RenderState.ZWriteEnable, true);
				int alpha = 255;
				float[] array = new float[4];
				float[] array2 = array;
				float[] array3 = new float[]
				{
					1f,
					1f,
					1f,
					1f
				};
				if (object_0 is MATD)
				{
					MATD.MATDShader shader = (object_0 as MATD).Shader;
					if (shader <= MATD.MATDShader.StandingWater)
					{
						if (shader <= MATD.MATDShader.Stairs)
						{
							if (shader <= MATD.MATDShader.GlassForRabbitHoles)
							{
								if (shader == MATD.MATDShader.ShadowMap)
								{
									this.class140_0.method_40("SunShadow");
									goto IL_370;
								}
								if (shader != MATD.MATDShader.GlassForRabbitHoles)
								{
									goto IL_370;
								}
							}
							else if (shader != MATD.MATDShader.GlassForObjects)
							{
								if (shader != MATD.MATDShader.Stairs)
								{
									goto IL_370;
								}
								goto IL_1DD;
							}
						}
						else if (shader <= MATD.MATDShader.Fence)
						{
							if (shader != MATD.MATDShader.GlassForFences)
							{
								if (shader != MATD.MATDShader.Fence)
								{
									goto IL_370;
								}
								goto IL_1DD;
							}
						}
						else
						{
							if (shader == MATD.MATDShader.BluePrint)
							{
								this.class140_0.method_40("Blueprint");
								goto IL_370;
							}
							if (shader != MATD.MATDShader.BasinWater && shader != MATD.MATDShader.StandingWater)
							{
								goto IL_370;
							}
							goto IL_360;
						}
					}
					else if (shader <= (MATD.MATDShader)3104856685U)
					{
						if (shader <= (MATD.MATDShader)2178752589U)
						{
							if (shader == MATD.MATDShader.SomeRoofShader)
							{
								goto IL_1DD;
							}
							if (shader != (MATD.MATDShader)2178752589U)
							{
								goto IL_370;
							}
						}
						else
						{
							if (shader == (MATD.MATDShader)2224877601U)
							{
								this.class140_0.method_40("ObjectGlassTranslucent");
								this.class140_0.method_9(RenderState.ZWriteEnable, true);
								alpha = 100;
								goto IL_370;
							}
							if (shader == (MATD.MATDShader)2794298921U)
							{
								this.class140_0.method_40("Mirror");
								goto IL_370;
							}
							if (shader != (MATD.MATDShader)3104856685U)
							{
								goto IL_370;
							}
							this.class140_0.method_9(RenderState.AlphaTestEnable, false);
							this.class140_0.method_9(RenderState.AlphaFunc, Compare.GreaterEqual);
							this.class140_0.method_9(RenderState.AlphaRef, 255);
							goto IL_370;
						}
					}
					else if (shader <= (MATD.MATDShader)3238484239U)
					{
						if (shader == (MATD.MATDShader)3231479170U)
						{
							this.class140_0.method_40("ObjectDropshadow");
							this.class140_0.method_9(RenderState.ZWriteEnable, false);
							goto IL_370;
						}
						if (shader != (MATD.MATDShader)3238484239U)
						{
							goto IL_370;
						}
						goto IL_360;
					}
					else
					{
						if (shader == (MATD.MATDShader)3778569092U)
						{
							goto IL_360;
						}
						if (shader == (MATD.MATDShader)4234134034U)
						{
							this.class140_0.method_9(RenderState.ZWriteEnable, false);
							this.class140_0.method_9(RenderState.AlphaTestEnable, false);
							this.class140_0.method_9(RenderState.AlphaFunc, Compare.GreaterEqual);
							this.class140_0.method_9(RenderState.AlphaRef, 255);
							goto IL_370;
						}
						if (shader != (MATD.MATDShader)4284377352U)
						{
							goto IL_370;
						}
						this.class140_0.method_40("Particle");
						goto IL_370;
					}
					this.class140_0.method_40("ObjectGlass");
					this.class140_0.method_9(RenderState.AlphaTestEnable, false);
					this.class140_0.method_9(RenderState.AlphaFunc, Compare.Less);
					this.class140_0.method_9(RenderState.AlphaRef, 255);
					this.class140_0.method_9(RenderState.ZWriteEnable, false);
					alpha = 100;
					goto IL_370;
					IL_1DD:
					this.class140_0.method_40("BuildItem");
					goto IL_370;
					IL_360:
					this.class140_0.method_40("Water");
				}
				IL_370:
				this.class140_0.method_27("hasNormalMap", false);
				this.class140_0.method_27("hasDirtMap", false);
				this.class140_0.method_27("hasSpecularMap", false);
				float num = 3.051851E-05f;
				Vector2 vector2_ = new Vector2(num, num);
				Vector2 vector2_2 = new Vector2(num, num);
				Vector2 vector2_3 = new Vector2(num, num);
				Vector2 vector2_4 = new Vector2(1f, 1f);
				Vector2 vector2_5 = new Vector2(1f, 1f);
				Vector2 vector2_6 = new Vector2(1f, 1f);
				Material material = default(Material);
				material.Ambient = Settings.Default.AmbientLighting;
				material.Diffuse = Color.White;
				material.Specular = Color.White;
				List<MATD.MATDEntry> list = new List<MATD.MATDEntry>();
				if (object_0 is MATD)
				{
					list.AddRange((object_0 as MATD).Entries.ToArray());
				}
				else
				{
					list.AddRange((object_0 as MATD.InternalMATD).Entries.ToArray());
				}
				foreach (MATD.MATDEntry matdentry in list)
				{
					if (matdentry.Type == MATD.MATDEntryType.PosScale)
					{
						for (int i = 0; i < matdentry.numValues; i++)
						{
							array3[i] = (float)matdentry.Values[i];
						}
					}
					if (matdentry.Type == MATD.MATDEntryType.PosOffset)
					{
						for (int j = 0; j < matdentry.numValues; j++)
						{
							array2[j] = (float)matdentry.Values[j];
						}
						array2[0] = 1f / array2[3] * array2[0];
						array2[1] = 1f / array2[3] * array2[1];
						array2[2] = 1f / array2[3] * array2[2];
						array2[3] = 1f / array2[3] * array2[3];
					}
					if (matdentry.Type == MATD.MATDEntryType.DirtOverlay)
					{
						this.class140_0.method_27("hasDirtMap", true);
					}
					if (matdentry.Type == MATD.MATDEntryType.Specular)
					{
						material.Specular = Color.FromArgb(255, Math.Min(255, (int)(255f * (float)matdentry.Values[0])), Math.Min(255, (int)(255f * (float)matdentry.Values[1])), Math.Min(255, (int)(255f * (float)matdentry.Values[2])));
					}
					if (matdentry.Type == (MATD.MATDEntryType)4149606399U)
					{
						material.Power = (float)matdentry.Values[0];
					}
					if (matdentry.Type == MATD.MATDEntryType.Diffuse)
					{
						if (matdentry.Values.Length == 4)
						{
							material.Diffuse = Color.FromArgb((int)(255f * (float)matdentry.Values[3]), (int)(255f * (float)matdentry.Values[0]), (int)(255f * (float)matdentry.Values[1]), (int)(255f * (float)matdentry.Values[2]));
						}
						else
						{
							material.Diffuse = Color.FromArgb(alpha, (int)(255f * (float)matdentry.Values[0]), (int)(255f * (float)matdentry.Values[1]), (int)(255f * (float)matdentry.Values[2]));
						}
					}
					if (matdentry.Type == (MATD.MATDEntryType)2448341759U)
					{
						vector2_.X = (vector2_.Y = (float)matdentry.Values[0]);
					}
					if (matdentry.Type == (MATD.MATDEntryType)3056944812U)
					{
						vector2_2.X = (vector2_2.Y = (float)matdentry.Values[0]);
					}
					if (matdentry.Type == MATD.MATDEntryType.NormalMapUVSelector)
					{
						vector2_3.X = (vector2_3.Y = (float)(((float)matdentry.Values[0] != 0f) ? matdentry.Values[0] : matdentry.Values[1]));
					}
					if (matdentry.Type == (MATD.MATDEntryType)2907867744U)
					{
						this.class140_0.method_27("hasSpecularMap", true);
					}
					if (matdentry.Type == MATD.MATDEntryType.NormalMap)
					{
						this.class140_0.method_27("hasNormalMap", true);
					}
					if (matdentry.Type == MATD.MATDEntryType.NoiseMapScale || matdentry.Type == MATD.MATDEntryType.DiffuseUVScale || matdentry.Type == (MATD.MATDEntryType)4046333891U || matdentry.Type == (MATD.MATDEntryType)3123518137U)
					{
						Vector2 vector = default(Vector2);
						if (matdentry.numValues == 1)
						{
							vector.X = (vector.Y = (float)matdentry.Values[0]);
						}
						else if (matdentry.numValues == 2)
						{
							vector.X = (float)matdentry.Values[0];
							vector.Y = (float)matdentry.Values[1];
						}
						MATD.MATDEntryType type = matdentry.Type;
						if (type <= MATD.MATDEntryType.NoiseMapScale)
						{
							if (type == MATD.MATDEntryType.DiffuseUVScale)
							{
								vector2_4 = vector;
								continue;
							}
							if (type != MATD.MATDEntryType.NoiseMapScale)
							{
								continue;
							}
						}
						else if (type != (MATD.MATDEntryType)3123518137U)
						{
							if (type != (MATD.MATDEntryType)4046333891U)
							{
								continue;
							}
							vector2_5 = vector;
							continue;
						}
						vector2_6 = vector;
					}
				}
				this.class140_0.method_31("g_diffuse", material.Diffuse);
				this.class140_0.method_31("g_specular", material.Specular);
				this.class140_0.method_31("g_ambient", material.Ambient);
				this.class140_0.method_28("g_fspecPower", material.Power);
				this.class140_0.method_24("diffuseUVSelector", vector2_);
				this.class140_0.method_24("normalMapUVSelector", vector2_3);
				this.class140_0.method_24("specularUVSelector", vector2_2);
				this.class140_0.method_24("diffuseUVScale", vector2_4);
				this.class140_0.method_24("specularUVScale", vector2_5);
				this.class140_0.method_24("normalMapUVScale", vector2_6);
				this.class140_0.method_29("g_PosScale", array3);
				this.class140_0.method_29("g_PosOffset", array2);
				this.class140_0.method_35();
			}
		}

		// Token: 0x0600055B RID: 1371 RVA: 0x00004C07 File Offset: 0x00002E07
		protected void method_33(object sender, CancelEventArgs e)
		{
			e.Cancel = true;
		}

		// Token: 0x170000E7 RID: 231
		// (get) Token: 0x0600055C RID: 1372 RVA: 0x00052F8C File Offset: 0x0005118C
		// (set) Token: 0x0600055D RID: 1373 RVA: 0x00004C12 File Offset: 0x00002E12
		public VertexBuffer _boundingBoxBuffer { get; set; }

		// Token: 0x0600055E RID: 1374 RVA: 0x00052FA4 File Offset: 0x000511A4
		public void method_34(float[] float_10)
		{
			this.float_2 = float_10;
			this.bool_1 = true;
			if (float_10 == null)
			{
				this.bool_1 = false;
			}
			else
			{
				Vector3 vector = new Vector3(float_10[0], float_10[1], float_10[2]);
				Vector3 vector2 = new Vector3(float_10[0], float_10[4], float_10[2]);
				Vector3 vector3 = new Vector3(float_10[0], float_10[4], float_10[5]);
				Vector3 vector4 = new Vector3(float_10[0], float_10[1], float_10[5]);
				Vector3 vector5 = new Vector3(float_10[3], float_10[1], float_10[2]);
				Vector3 vector6 = new Vector3(float_10[3], float_10[4], float_10[2]);
				Vector3 vector7 = new Vector3(float_10[3], float_10[4], float_10[5]);
				Vector3 vector8 = new Vector3(float_10[3], float_10[1], float_10[5]);
				float num = 0.08f;
				this.struct7_0[0].position = vector;
				this.struct7_0[1].position = vector + new Vector3(num, 0f, 0f);
				this.struct7_0[2].position = vector;
				this.struct7_0[3].position = vector + new Vector3(0f, num, 0f);
				this.struct7_0[4].position = vector;
				this.struct7_0[5].position = vector + new Vector3(0f, 0f, num);
				this.struct7_0[6].position = vector2;
				this.struct7_0[7].position = vector2 + new Vector3(num, 0f, 0f);
				this.struct7_0[8].position = vector2;
				this.struct7_0[9].position = vector2 + new Vector3(0f, -0.08f, 0f);
				this.struct7_0[10].position = vector2;
				this.struct7_0[11].position = vector2 + new Vector3(0f, 0f, num);
				this.struct7_0[12].position = vector3;
				this.struct7_0[13].position = vector3 + new Vector3(num, 0f, 0f);
				this.struct7_0[14].position = vector3;
				this.struct7_0[15].position = vector3 + new Vector3(0f, -0.08f, 0f);
				this.struct7_0[16].position = vector3;
				this.struct7_0[17].position = vector3 + new Vector3(0f, 0f, -0.08f);
				this.struct7_0[18].position = vector4;
				this.struct7_0[19].position = vector4 + new Vector3(num, 0f, 0f);
				this.struct7_0[20].position = vector4;
				this.struct7_0[21].position = vector4 + new Vector3(0f, num, 0f);
				this.struct7_0[22].position = vector4;
				this.struct7_0[23].position = vector4 + new Vector3(0f, 0f, -0.08f);
				this.struct7_0[24].position = vector5;
				this.struct7_0[25].position = vector5 + new Vector3(-0.08f, 0f, 0f);
				this.struct7_0[26].position = vector5;
				this.struct7_0[27].position = vector5 + new Vector3(--0f, num, 0f);
				this.struct7_0[28].position = vector5;
				this.struct7_0[29].position = vector5 + new Vector3(--0f, 0f, num);
				this.struct7_0[30].position = vector6;
				this.struct7_0[31].position = vector6 + new Vector3(-0.08f, 0f, 0f);
				this.struct7_0[32].position = vector6;
				this.struct7_0[33].position = vector6 + new Vector3(--0f, -0.08f, 0f);
				this.struct7_0[34].position = vector6;
				this.struct7_0[35].position = vector6 + new Vector3(--0f, 0f, num);
				this.struct7_0[36].position = vector7;
				this.struct7_0[37].position = vector7 + new Vector3(-0.08f, 0f, 0f);
				this.struct7_0[38].position = vector7;
				this.struct7_0[39].position = vector7 + new Vector3(--0f, -0.08f, 0f);
				this.struct7_0[40].position = vector7;
				this.struct7_0[41].position = vector7 + new Vector3(--0f, 0f, -0.08f);
				this.struct7_0[42].position = vector8;
				this.struct7_0[43].position = vector8 + new Vector3(-0.08f, 0f, 0f);
				this.struct7_0[44].position = vector8;
				this.struct7_0[45].position = vector8 + new Vector3(--0f, num, 0f);
				this.struct7_0[46].position = vector8;
				this.struct7_0[47].position = vector8 + new Vector3(--0f, 0f, -0.08f);
				this.struct7_0[48].position = vector;
				this.struct7_0[49].position = vector2;
				this.struct7_0[50].position = vector3;
				this.struct7_0[51].position = vector3;
				this.struct7_0[52].position = vector4;
				this.struct7_0[53].position = vector;
				this.struct7_0[54].position = vector5;
				this.struct7_0[55].position = vector6;
				this.struct7_0[56].position = vector;
				this.struct7_0[57].position = vector6;
				this.struct7_0[58].position = vector2;
				this.struct7_0[59].position = vector;
				this.struct7_0[60].position = vector8;
				this.struct7_0[61].position = vector7;
				this.struct7_0[62].position = vector6;
				this.struct7_0[63].position = vector6;
				this.struct7_0[64].position = vector5;
				this.struct7_0[65].position = vector8;
				this.struct7_0[66].position = vector4;
				this.struct7_0[67].position = vector3;
				this.struct7_0[68].position = vector7;
				this.struct7_0[69].position = vector4;
				this.struct7_0[70].position = vector7;
				this.struct7_0[71].position = vector8;
				this.struct7_0[72].position = vector3;
				this.struct7_0[73].position = vector2;
				this.struct7_0[74].position = vector6;
				this.struct7_0[75].position = vector3;
				this.struct7_0[76].position = vector6;
				this.struct7_0[77].position = vector7;
				this.struct7_0[78].position = vector;
				this.struct7_0[79].position = vector4;
				this.struct7_0[80].position = vector5;
				this.struct7_0[81].position = vector4;
				this.struct7_0[82].position = vector8;
				this.struct7_0[83].position = vector5;
				this.int_2 = 84;
				DataStream dataStream = this._boundingBoxBuffer.Lock(0, 0, LockFlags.None);
				dataStream.WriteRange<Class112.Struct7>(this.struct7_0, 0, this.int_2);
				this._boundingBoxBuffer.Unlock();
				this.matrix_3[0] = Matrix.Translation(new Vector3(float_10[0], (float_10[4] + float_10[1]) / 2f, (float_10[2] + float_10[5]) / 2f));
				this.matrix_3[1] = Matrix.Translation(new Vector3(float_10[3], (float_10[4] + float_10[1]) / 2f, (float_10[2] + float_10[5]) / 2f));
				this.matrix_3[2] = Matrix.Translation(new Vector3(0f, float_10[1], (float_10[2] + float_10[5]) / 2f));
				this.matrix_3[3] = Matrix.Translation(new Vector3(0f, float_10[4], (float_10[2] + float_10[5]) / 2f));
				this.matrix_3[4] = Matrix.Translation(new Vector3(0f, (float_10[4] + float_10[1]) / 2f, float_10[5]));
				this.matrix_3[5] = Matrix.Translation(new Vector3(0f, (float_10[4] + float_10[1]) / 2f, float_10[2]));
				this.matrix_3[6] = Matrix.RotationY(-1.5707964f);
				this.matrix_3[7] = Matrix.RotationY(1.5707964f);
				this.matrix_3[8] = Matrix.RotationX(1.5707964f);
				this.matrix_3[9] = Matrix.RotationX(-1.5707964f);
				this.matrix_3[10] = Matrix.RotationX(0f);
				this.matrix_3[11] = Matrix.RotationY(3.1415927f);
				this.matrix_3[12] = Matrix.Translation(new Vector3(-0.06f, 0f, 0f));
				this.matrix_3[13] = Matrix.Translation(new Vector3(0.03f, 0f, 0f));
				this.matrix_3[14] = Matrix.Translation(new Vector3(0f, -0.02f, 0f));
				this.matrix_3[15] = Matrix.Translation(new Vector3(0f, 0.02f, 0f));
				this.matrix_3[16] = Matrix.Translation(new Vector3(0f, 0f, 0.05f));
				this.matrix_3[17] = Matrix.Translation(new Vector3(0f, 0f, -0.05f));
			}
		}

		// Token: 0x170000E8 RID: 232
		// (set) Token: 0x0600055F RID: 1375 RVA: 0x00004C1D File Offset: 0x00002E1D
		public float ObjectRotation
		{
			set
			{
				this.float_3 = 0.017453292f * value;
				this.bool_0 = true;
			}
		}

		// Token: 0x170000E9 RID: 233
		// (set) Token: 0x06000560 RID: 1376 RVA: 0x00004C35 File Offset: 0x00002E35
		public bool ShadowMapDirty
		{
			set
			{
				this.bool_0 = value;
			}
		}

		// Token: 0x06000561 RID: 1377 RVA: 0x00053D44 File Offset: 0x00051F44
		public void method_35()
		{
			if (this.class140_0.method_1())
			{
				this.class140_0.method_12(new Vector4(1f, 1f, 1f, 1f), new Vector4(0f, 0f, 0f, 0f));
				this.class140_0.method_9(RenderState.ZEnable, true);
				this.class140_0.method_9(RenderState.AlphaBlendEnable, false);
				this.class140_0.method_9(RenderState.AlphaTestEnable, false);
				this.class140_0.method_9(RenderState.SeparateAlphaBlendEnable, false);
				Class140.smethod_0().method_9(RenderState.ZEnable, true);
				Class140.smethod_0().method_9(RenderState.ZWriteEnable, true);
				this.class140_0.method_9(RenderState.SourceBlend, Blend.SourceAlpha);
				this.class140_0.method_9(RenderState.DestinationBlend, Blend.InverseSourceAlpha);
				this.device_0.Clear(ClearFlags.ZBuffer | ClearFlags.Target, Settings.Default.MesheditorBackgroundColor, 1f, 0);
				this.method_26();
				this.method_27();
				this.class140_0.method_9(RenderState.FillMode, FillMode.Solid);
				this.class140_0.method_9(RenderState.CullMode, Cull.Clockwise);
				this.device_0.SetTransform(TransformState.World, Matrix.Identity);
				Matrix matrix = Matrix.RotationY(this.float_3);
				Matrix matrix2 = this.matrix_4 * this.matrix_2;
				Matrix matrix3 = matrix * this.matrix_6;
				Matrix matrix4 = matrix;
				Vector3.TransformCoordinate(this.vector3_0, this.class100_0.TranslationMatrix);
				this.class140_0.method_25("g_mObjTrans", matrix4);
				this.class140_0.method_25("g_mWorldView", matrix2);
				this.class140_0.method_25("g_mLightView_Sun", matrix3);
				this.class140_0.method_25("g_mWorld", this.matrix_4);
				this.class140_0.method_23("g_vEye", this.vector3_0);
				this.class140_0.method_25("g_mProj", this.matrix_1);
				this.class140_0.method_35();
				if (EditorToolBox.smethod_0().Visible)
				{
					if (this.GridEnabled)
					{
						this.device_0.SetRenderState(RenderState.Lighting, false);
						this.device_0.SetTransform(TransformState.World, this.matrix_4);
						this.class140_0.method_25("g_mObjTrans", this.matrix_4);
						this.device_0.SetTexture(0, null);
						this.device_0.SetTexture(1, null);
						this.device_0.VertexFormat = Class112.Struct7.vertexFormat_0;
						this.class140_0.method_10();
						this.device_0.SetStreamSource(0, this.vertexBuffer_0, 0, Class112.Struct7.SizeInBytes);
						this.device_0.DrawPrimitives(PrimitiveType.LineList, 0, this.int_1);
						this.class140_0.method_9(RenderState.Lighting, true);
					}
					EditorToolBox.smethod_0().method_5(this, this.Device, this.matrix_4);
				}
				else
				{
					if (this.GroundEnabled && this.texture_0 != null)
					{
						this.class140_0.method_9(RenderState.Lighting, false);
						this.class140_0.method_9(RenderState.ZEnable, true);
						this.class140_0.method_9(RenderState.StencilEnable, false);
						this.class140_0.method_9(RenderState.ZWriteEnable, true);
						if (this.bool_0)
						{
							this.device_0.SetRenderTarget(0, this.surface_0);
							this.device_0.DepthStencilSurface = this.surface_1;
							this.device_0.Clear(ClearFlags.ZBuffer | ClearFlags.Target, Color.Black, 1f, 1);
							foreach (Class102 @class in this.list_0)
							{
								if (@class.imethod_4())
								{
									@class.vmethod_6(this.matrix_4, this.matrix_2, this.device_0);
								}
							}
							this.device_0.SetRenderTarget(0, this.class140_0.DefaultRenderTarget);
							this.device_0.DepthStencilSurface = this.class140_0.DefaultDepthStencil;
							this.bool_0 = false;
						}
						this.device_0.SetRenderTarget(0, this.surface_2);
						this.device_0.DepthStencilSurface = this.surface_3;
						this.device_0.Clear(ClearFlags.ZBuffer | ClearFlags.Target, Color.Black, 1f, 1);
						this.class140_0.method_9(RenderState.ZEnable, true);
						this.class140_0.method_9(RenderState.AlphaTestEnable, false);
						foreach (Class102 class2 in this.list_0)
						{
							if (class2.imethod_4() && class2.HasFloorMask && class2.DisplayFloorMask)
							{
								class2.vmethod_0(this.device_0, this.matrix_4);
							}
						}
						this.device_0.SetRenderTarget(0, this.class140_0.DefaultRenderTarget);
						this.device_0.DepthStencilSurface = this.class140_0.DefaultDepthStencil;
						this.class140_0.method_9(RenderState.ZEnable, true);
						this.class140_0.method_9(RenderState.ZWriteEnable, true);
						Class140.smethod_0().method_9(RenderState.AlphaTestEnable, false);
						matrix2 = this.matrix_4 * this.matrix_2;
						this.class140_0.method_9(RenderState.AlphaBlendEnable, true);
						this.class140_0.method_9(RenderState.AlphaTestEnable, true);
						this.class140_0.method_9(RenderState.AlphaFunc, Compare.Greater);
						this.class140_0.method_9(RenderState.AlphaRef, 0);
						matrix3 = this.matrix_6;
						this.class140_0.method_25("g_mObjTrans", Matrix.Identity);
						this.class140_0.method_25("g_mWorldView", matrix2);
						this.class140_0.method_25("g_mLightView_Sun", matrix3);
						this.class140_0.method_35();
						this.class140_0.method_21("g_txShadows", this.texture_0);
						this.class140_0.method_21("g_txScene", this.texture_1);
						this.class140_0.method_30("g_cGroundColor", Settings.Default.GroundColor.ToArgb());
						this.class140_0.method_35();
						this.class140_0.method_12(new Vector4(1f, 1f, 1f, 1f), new Vector4(0f, 0f, 0f, 0f));
						this.device_0.VertexDeclaration = Class140.smethod_0().VertexDeclaration;
						this.device_0.SetStreamSource(0, this.vertexBuffer_1, 0, Class112.Struct7.SizeInBytes);
						this.class140_0.method_40(this.string_0);
						int num = this.class140_0.method_36();
						for (int i = 0; i < num; i++)
						{
							this.class140_0.method_38(i);
							this.device_0.DrawPrimitives(PrimitiveType.TriangleList, 0, 2);
							this.class140_0.method_39();
						}
						this.class140_0.method_37();
						this.class140_0.method_9(RenderState.AlphaTestEnable, false);
					}
					this.class140_0.method_9(RenderState.Lighting, true);
					this.class140_0.method_9(RenderState.ZEnable, true);
					this.class140_0.method_9(RenderState.ZWriteEnable, true);
					matrix2 = this.matrix_4 * this.matrix_2;
					this.device_0.SetTransform(TransformState.World, this.matrix_4);
					this.class140_0.method_25("g_mObjTrans", matrix);
					this.class140_0.method_25("g_mWorldView", matrix2);
					this.class140_0.method_22("g_vLightDirView", new Vector4(0f, 0.2f, 20f, 1f));
					this.class140_0.method_28("redAdjust", Settings.Default.redAdjust / 100f);
					this.class140_0.method_28("blueAdjust", Settings.Default.blueAdjust / 100f);
					this.class140_0.method_28("greenAdjust", Settings.Default.greenAdjust / 100f);
					this.class140_0.method_35();
					for (int j = 0; j < 2; j++)
					{
						this.class140_0.CurrentRenderMode = ((j == 0) ? Class140.Enum20.const_0 : Class140.Enum20.const_1);
						foreach (Class102 class3 in this.list_0)
						{
							if (class3.imethod_4())
							{
								Matrix identity = Matrix.Identity;
								class3.imethod_0(matrix * this.matrix_4, this.matrix_2, this.device_0);
							}
						}
					}
					if (this.GridEnabled)
					{
						this.class140_0.method_9(RenderState.ZEnable, true);
						this.device_0.SetRenderState(RenderState.Lighting, false);
						this.device_0.SetTransform(TransformState.World, this.matrix_4);
						this.class140_0.method_25("g_mObjTrans", this.matrix_4);
						this.device_0.SetTexture(0, null);
						this.device_0.SetTexture(1, null);
						this.device_0.VertexFormat = Class112.Struct7.vertexFormat_0;
						this.class140_0.method_10();
						this.device_0.SetStreamSource(0, this.vertexBuffer_0, 0, Class112.Struct7.SizeInBytes);
						this.device_0.DrawPrimitives(PrimitiveType.LineList, 0, this.int_1);
						this.class140_0.method_9(RenderState.Lighting, true);
					}
					if (this.bool_1)
					{
						Class140.smethod_0().method_9(RenderState.AlphaTestEnable, false);
						this.class140_0.method_9(RenderState.FillMode, FillMode.Solid);
						this.class140_0.method_9(RenderState.CullMode, Cull.Clockwise);
						this.class140_0.method_9(RenderState.Lighting, false);
						this.class140_0.method_9(RenderState.ZEnable, true);
						this.class140_0.method_9(RenderState.ZWriteEnable, false);
						this.device_0.SetTransform(TransformState.World, matrix * this.matrix_4);
						this.device_0.SetStreamSource(0, this._boundingBoxBuffer, 0, Class112.Struct7.SizeInBytes);
						Class140.smethod_0().method_22("g_ambient", new Vector4(0f, 0f, 1f, 1f));
						Class140.smethod_0().method_40("Line");
						int num2 = Class140.smethod_0().method_36();
						for (int k = 0; k < num2; k++)
						{
							Class140.smethod_0().method_38(k);
							this.class140_0.method_9(RenderState.AlphaBlendEnable, false);
							this.device_0.DrawPrimitives(PrimitiveType.LineList, 0, (this.int_2 - 36) / 2);
							Class140.smethod_0().method_39();
						}
						Class140.smethod_0().method_37();
						Class140.smethod_0().method_40("Slot");
						num2 = Class140.smethod_0().method_36();
						for (int l = 0; l < num2; l++)
						{
							this.class140_0.Device.VertexDeclaration = this.class140_0.VertexDeclaration;
							this.class140_0.method_9(RenderState.AlphaBlendEnable, true);
							this.class140_0.method_22("g_ambient", new Vector4(0.6f, 0.6f, 0.6f, 0.2f));
							Class140.smethod_0().method_38(l);
							this.device_0.DrawPrimitives(PrimitiveType.TriangleList, 48, 12);
							this.class140_0.method_9(RenderState.ZWriteEnable, true);
							this.class140_0.method_9(RenderState.AlphaBlendEnable, false);
							this.class140_0.method_22("g_ambient", new Vector4(0.6f, 0.6f, 1f, 0.8f));
							for (int m = 0; m < 6; m++)
							{
								Class140.smethod_0().method_32(this.matrix_3[m + 6] * this.matrix_3[m + 12] * this.matrix_3[m] * Matrix.RotationY(this.float_3) * this.matrix_4, Class132.smethod_0().ViewMatrix);
								this.mesh_0[m].DrawSubset(0);
							}
							Class140.smethod_0().method_39();
						}
						Class140.smethod_0().method_37();
						Class140.smethod_0().method_9(RenderState.Lighting, true);
						this.Device.VertexDeclaration = this.class140_0.VertexDeclaration;
					}
					if (this.string_1 != null)
					{
						Class140.smethod_0().method_9(RenderState.ZEnable, false);
						Sprite sprite = new Sprite(this.class140_0.Device);
						sprite.Begin(SpriteFlags.AlphaBlend);
						int width = this.font_0.MeasureString(sprite, this.string_1, DrawTextFormat.Left).Width + 8;
						int height = this.font_0.MeasureString(sprite, this.string_1, DrawTextFormat.Left).Height + 4;
						sprite.Draw(this.texture_2, new Rectangle?(new Rectangle(0, 0, width, height)), new Vector3?(Vector3.Zero), new Vector3?(new Vector3((float)(this.point_1.X + 20), (float)(this.point_1.Y + 3), 0f)), Color.White);
						this.font_0.DrawString(sprite, this.string_1, this.point_1.X + 24, this.point_1.Y + 5, Color.Black);
						sprite.End();
						sprite.Dispose();
					}
					if (this.interface2_0 != null)
					{
						this.interface2_0.imethod_3(this.class140_0.Device);
					}
				}
				this.class140_0.method_2();
				long num3 = DateTime.Now.Ticks / 10000L;
				if (this.long_0 != 0L)
				{
					long num4 = num3 - this.long_0;
					this.int_0 = (int)(1000f / (float)num4);
				}
				this.long_0 = num3;
			}
		}

		// Token: 0x06000562 RID: 1378 RVA: 0x00004C40 File Offset: 0x00002E40
		public void method_36()
		{
			this.method_37(null, null);
		}

		// Token: 0x06000563 RID: 1379 RVA: 0x00054BF0 File Offset: 0x00052DF0
		private void method_37(object sender, EventArgs e)
		{
			if (this.device_0 != null)
			{
				if (Class132.mainForm.WindowState != FormWindowState.Minimized)
				{
					if (this.class140_0 != null && this.class140_0.method_8() == ResultCode.Success)
					{
						this.image_0 = new Bitmap(this.panel_0.Width, this.panel_0.Height, PixelFormat.Format32bppArgb);
						this.class100_0.method_3(this.panel_0.Width, this.panel_0.Height);
						this.bool_0 = true;
					}
				}
			}
		}

		// Token: 0x06000564 RID: 1380 RVA: 0x00054C88 File Offset: 0x00052E88
		public Size method_38()
		{
			return new Size(this.panel_0.Width, this.panel_0.Height);
		}

		// Token: 0x06000565 RID: 1381 RVA: 0x00054CB4 File Offset: 0x00052EB4
		protected void WndProc(ref Message m)
		{
			base.WndProc(ref m);
			this.class100_0.method_7(m.HWnd, (Class101.Enum15)m.Msg, m.WParam, m.LParam);
			if (m.Msg == 522)
			{
				int num = m.WParam.ToInt32() >> 16 & 65535;
				m.WParam.ToInt32();
				m.LParam.ToInt32();
				m.LParam.ToInt32();
				if (num == 120)
				{
					this.vector3_0 = new Vector3(this.vector3_0.X, this.vector3_0.Y, this.vector3_0.Z - 0.1f);
				}
				else
				{
					this.vector3_0 = new Vector3(this.vector3_0.X, this.vector3_0.Y, this.vector3_0.Z + 0.1f);
				}
			}
		}

		// Token: 0x06000566 RID: 1382 RVA: 0x00054DB0 File Offset: 0x00052FB0
		private Vector3[] method_39(Vector3[] vector3_5)
		{
			return new Vector3[]
			{
				new Vector3(vector3_5[0].X, vector3_5[0].Y, vector3_5[0].Z),
				new Vector3(vector3_5[1].X, vector3_5[0].Y, vector3_5[0].Z),
				new Vector3(vector3_5[1].X, vector3_5[0].Y, vector3_5[1].Z),
				new Vector3(vector3_5[0].X, vector3_5[0].Y, vector3_5[1].Z),
				new Vector3(vector3_5[0].X, vector3_5[1].Y, vector3_5[0].Z),
				new Vector3(vector3_5[1].X, vector3_5[1].Y, vector3_5[0].Z),
				new Vector3(vector3_5[1].X, vector3_5[1].Y, vector3_5[1].Z),
				new Vector3(vector3_5[0].X, vector3_5[1].Y, vector3_5[1].Z)
			};
		}

		// Token: 0x06000567 RID: 1383 RVA: 0x00054F74 File Offset: 0x00053174
		private void method_40(Interface10 interface10_1, MouseEventArgs mouseEventArgs_0)
		{
			ContextMenuStrip contextMenuStrip = new ContextMenuStrip();
			if (!(interface10_1 is Class111))
			{
				if (interface10_1 is Class119)
				{
					ToolStripMenuItem toolStripMenuItem = new ToolStripMenuItem("Edit joint");
					toolStripMenuItem.Tag = interface10_1;
					toolStripMenuItem.Click += this.method_41;
					contextMenuStrip.Items.Add(toolStripMenuItem);
					Point point = base.PointToScreen(new Point(mouseEventArgs_0.X, mouseEventArgs_0.Y));
					contextMenuStrip.Show(point.X, point.Y);
				}
			}
		}

		// Token: 0x06000568 RID: 1384 RVA: 0x00054FF8 File Offset: 0x000531F8
		private void method_41(object sender, EventArgs e)
		{
			ToolStripMenuItem toolStripMenuItem = sender as ToolStripMenuItem;
			Interface10 @interface = toolStripMenuItem.Tag as Interface10;
			Matrix transformation = @interface.Transformation;
			Quaternion quaternion = Quaternion.RotationMatrix(transformation);
			float m = transformation.M41;
			float m2 = transformation.M42;
			float m3 = transformation.M43;
			TransformationEditor transformationEditor = new TransformationEditor(m, m2, m3, quaternion.X, quaternion.Y, quaternion.Z, quaternion.W);
			TransformationEditor transformationEditor2 = transformationEditor;
			if (MeshEditor.delegate7_0 == null)
			{
				MeshEditor.delegate7_0 = new TransformationEditor.Delegate7(MeshEditor.smethod_1);
			}
			transformationEditor2.DoUpdate += MeshEditor.delegate7_0;
			if (transformationEditor.ShowDialog() == DialogResult.OK)
			{
				Quaternion rotation = new Quaternion(transformationEditor.float_3, transformationEditor.float_4, transformationEditor.float_5, transformationEditor.float_6);
				Matrix transformation2 = Matrix.RotationQuaternion(rotation) * Matrix.Translation(transformationEditor.float_0, transformationEditor.float_1, transformationEditor.float_2);
				@interface.Transformation = transformation2;
				@interface.imethod_0();
			}
		}

		// Token: 0x06000569 RID: 1385 RVA: 0x000550F4 File Offset: 0x000532F4
		public void method_42(object sender, MouseEventArgs e)
		{
			Viewport viewport_ = new Viewport(0, 0, this.panel_0.Width, this.panel_0.Height);
			if (!(Class132.mainForm.CurrentProjectModel is Interface1) || !(Class132.mainForm.CurrentProjectModel as Interface1).imethod_0(sender, e, viewport_))
			{
				Cursor.Show();
				if (this.bool_4 || this.bool_5 || this.bool_3)
				{
					this.bool_3 = false;
					this.bool_5 = false;
					this.bool_4 = false;
				}
				if (!EditorToolBox.smethod_0().Visible || !EditorToolBox.smethod_0().method_6(this, viewport_, e))
				{
					if (this.interface10_0 != null)
					{
						this.string_1 = null;
						this.interface10_0.imethod_0();
						if (e.Button == MouseButtons.Right && (Control.ModifierKeys & Keys.Control) == Keys.None)
						{
							this.method_40(this.interface10_0, e);
						}
						this.interface10_0 = null;
					}
					if (this.int_5 != -1)
					{
						this.int_5 = -1;
						this.string_1 = null;
					}
					if (this.interface2_0 == null || this.SelectionDialog.imethod_0(e, this.ViewPort, this.ProjectionMatrix, this.ViewMatrix, this.WorldMatrix))
					{
						this.class120_0 = null;
						this.class100_0.method_6();
					}
				}
			}
		}

		// Token: 0x0600056A RID: 1386 RVA: 0x0005524C File Offset: 0x0005344C
		private void method_43(object sender, MouseEventArgs e)
		{
			Viewport viewport_ = new Viewport(0, 0, this.panel_0.Width, this.panel_0.Height);
			if (!(Class132.mainForm.CurrentProjectModel is Interface1) || !(Class132.mainForm.CurrentProjectModel as Interface1).imethod_1(sender, e, viewport_))
			{
				this.point_2 = new Point(e.X, e.Y);
				if (!EditorToolBox.smethod_0().Visible || !EditorToolBox.smethod_0().method_7(this, viewport_, e))
				{
					if (this.interface2_0 == null || this.interface2_0.imethod_2(e, this.ViewPort, this.ProjectionMatrix, this.ViewMatrix, this.WorldMatrix))
					{
						this.class120_0 = null;
						if (e.Button == MouseButtons.Left || e.Button == MouseButtons.Right)
						{
							float num = 0f;
							foreach (Class102 @class in this.list_0)
							{
								foreach (Class120 class2 in @class.Lites)
								{
									Matrix.Translation(class2.vector3_1) * this.matrix_4;
									Vector3 position = Vector3.Unproject(new Vector3((float)e.X, (float)e.Y, 0f), (float)viewport_.X, (float)viewport_.Y, (float)viewport_.Width, (float)viewport_.Height, viewport_.MinZ, viewport_.MaxZ, this.matrix_4 * this.matrix_2 * this.matrix_0);
									Vector3 direction = Vector3.Unproject(new Vector3((float)e.X, (float)e.Y, 1f), (float)viewport_.X, (float)viewport_.Y, (float)viewport_.Width, (float)viewport_.Height, viewport_.MinZ, viewport_.MaxZ, this.matrix_4 * this.matrix_2 * this.matrix_0);
									Ray ray = new Ray(position, direction);
									if (class2.PositionHandle.Intersects(ray, out num))
									{
										this.class120_0 = class2;
										this.vector3_4 = this.class120_0.vector3_1;
										break;
									}
								}
								float num2 = float.MaxValue;
								if (this.bool_1)
								{
									for (int i = 0; i < 6; i++)
									{
										Vector3 position2 = Vector3.Unproject(new Vector3((float)e.X, (float)e.Y, 0f), (float)viewport_.X, (float)viewport_.Y, (float)viewport_.Width, (float)viewport_.Height, viewport_.MinZ, viewport_.MaxZ, this.matrix_3[i + 6] * this.matrix_3[i + 12] * this.matrix_3[i] * Matrix.RotationY(this.float_3) * this.matrix_4 * this.matrix_2 * this.matrix_0);
										Vector3 direction2 = Vector3.Unproject(new Vector3((float)e.X, (float)e.Y, 1f), (float)viewport_.X, (float)viewport_.Y, (float)viewport_.Width, (float)viewport_.Height, viewport_.MinZ, viewport_.MaxZ, this.matrix_3[i + 6] * this.matrix_3[i + 12] * this.matrix_3[i] * Matrix.RotationY(this.float_3) * this.matrix_4 * this.matrix_2 * this.matrix_0);
										Ray ray2 = new Ray(position2, direction2);
										Mesh mesh = this.mesh_0[i];
										if (mesh.Intersects(ray2, out num) && num < num2)
										{
											num2 = num;
											this.int_5 = i;
											if (i == 0)
											{
												goto IL_465;
											}
											if (i == 1)
											{
												goto IL_465;
											}
											if (i != 2)
											{
												if (i != 3)
												{
													if (i == 4 || i == 5)
													{
														this.int_6 = 3;
														goto IL_46C;
													}
													goto IL_46C;
												}
											}
											this.int_6 = 2;
											IL_46C:
											Vector3 vector = Vector3.Project(Vector3.Zero, (float)viewport_.X, (float)viewport_.Y, (float)viewport_.Width, (float)viewport_.Height, viewport_.MinZ, viewport_.MaxZ, this.matrix_3[i + 6] * this.matrix_3[i] * this.matrix_4 * this.matrix_2 * this.matrix_0);
											this.point_0 = new Point(e.X - (int)vector.X, e.Y - (int)vector.Y);
											goto IL_51B;
											IL_465:
											this.int_6 = 1;
											goto IL_46C;
										}
										IL_51B:;
									}
								}
								num2 = float.MaxValue;
								List<Interface10> list = new List<Interface10>();
								list.AddRange(@class.ContainerEntries.ToArray());
								list.AddRange(@class.KinematicEntries.ToArray());
								list.AddRange(@class.RouteEntries.ToArray());
								list.AddRange(@class.EffectEntries.ToArray());
								list.AddRange(@class.JointEntries.ToArray());
								list.AddRange(@class.SkinEntries.ToArray());
								foreach (Interface10 @interface in list)
								{
									if (@interface.Visible)
									{
										Matrix left = @interface.TransformationX * this.matrix_4;
										Matrix left2 = @interface.TransformationY * this.matrix_4;
										Matrix left3 = @interface.TransformationZ * this.matrix_4;
										Vector3 position3 = Vector3.Unproject(new Vector3((float)e.X, (float)e.Y, 0f), (float)viewport_.X, (float)viewport_.Y, (float)viewport_.Width, (float)viewport_.Height, viewport_.MinZ, viewport_.MaxZ, left * this.matrix_2 * this.matrix_0);
										Vector3 direction3 = Vector3.Unproject(new Vector3((float)e.X, (float)e.Y, 1f), (float)viewport_.X, (float)viewport_.Y, (float)viewport_.Width, (float)viewport_.Height, viewport_.MinZ, viewport_.MaxZ, left * this.matrix_2 * this.matrix_0);
										Ray ray3 = new Ray(position3, direction3);
										Vector3 position4 = Vector3.Unproject(new Vector3((float)e.X, (float)e.Y, 0f), (float)viewport_.X, (float)viewport_.Y, (float)viewport_.Width, (float)viewport_.Height, viewport_.MinZ, viewport_.MaxZ, left2 * this.matrix_2 * this.matrix_0);
										Vector3 direction4 = Vector3.Unproject(new Vector3((float)e.X, (float)e.Y, 1f), (float)viewport_.X, (float)viewport_.Y, (float)viewport_.Width, (float)viewport_.Height, viewport_.MinZ, viewport_.MaxZ, left2 * this.matrix_2 * this.matrix_0);
										Ray ray4 = new Ray(position4, direction4);
										Vector3 position5 = Vector3.Unproject(new Vector3((float)e.X, (float)e.Y, 0f), (float)viewport_.X, (float)viewport_.Y, (float)viewport_.Width, (float)viewport_.Height, viewport_.MinZ, viewport_.MaxZ, left3 * this.matrix_2 * this.matrix_0);
										Vector3 direction5 = Vector3.Unproject(new Vector3((float)e.X, (float)e.Y, 1f), (float)viewport_.X, (float)viewport_.Y, (float)viewport_.Width, (float)viewport_.Height, viewport_.MinZ, viewport_.MaxZ, left3 * this.matrix_2 * this.matrix_0);
										Ray ray5 = new Ray(position5, direction5);
										if (@interface.XHandle.Intersects(ray3, out num))
										{
											if (num < num2)
											{
												this.interface10_0 = @interface;
												this.interface10_0.CurrentDragMode = Enum18.const_0;
												Vector3 vector2 = Vector3.Project(Vector3.Zero, (float)viewport_.X, (float)viewport_.Y, (float)viewport_.Width, (float)viewport_.Height, viewport_.MinZ, viewport_.MaxZ, @interface.TransformationX * this.matrix_4 * this.matrix_2 * this.matrix_0);
												this.point_0 = new Point(e.X - (int)vector2.X, e.Y - (int)vector2.Y);
											}
											num2 = num;
										}
										else if (@interface.YHandle.Intersects(ray4, out num))
										{
											if (num < num2)
											{
												this.interface10_0 = @interface;
												this.interface10_0.CurrentDragMode = Enum18.const_1;
												Vector3 vector3 = Vector3.Project(Vector3.Zero, (float)viewport_.X, (float)viewport_.Y, (float)viewport_.Width, (float)viewport_.Height, viewport_.MinZ, viewport_.MaxZ, @interface.TransformationY * this.matrix_4 * this.matrix_2 * this.matrix_0);
												this.point_0 = new Point(e.X - (int)vector3.X, e.Y - (int)vector3.Y);
											}
											num2 = num;
										}
										else if (@interface.ZHandle.Intersects(ray5, out num) && num < num2)
										{
											this.interface10_0 = @interface;
											this.interface10_0.CurrentDragMode = Enum18.const_2;
											Vector3 vector4 = Vector3.Project(Vector3.Zero, (float)viewport_.X, (float)viewport_.Y, (float)viewport_.Width, (float)viewport_.Height, viewport_.MinZ, viewport_.MaxZ, @interface.TransformationZ * this.matrix_4 * this.matrix_2 * this.matrix_0);
											this.point_0 = new Point(e.X - (int)vector4.X, e.Y - (int)vector4.Y);
										}
									}
								}
							}
						}
						if (this.class120_0 == null)
						{
							this.class100_0.method_4(e.X, e.Y);
						}
					}
				}
			}
		}

		// Token: 0x0600056B RID: 1387 RVA: 0x00055DC8 File Offset: 0x00053FC8
		private void method_44(object sender, MouseEventArgs e)
		{
			Viewport viewport_ = new Viewport(0, 0, this.panel_0.Width, this.panel_0.Height);
			if (!(Class132.mainForm.CurrentProjectModel is Interface1) || !(Class132.mainForm.CurrentProjectModel as Interface1).imethod_2(sender, e, viewport_))
			{
				this.point_1 = new Point(e.X, e.Y);
				int num = e.X;
				int num2 = e.Y;
				if (!EditorToolBox.smethod_0().Visible || !EditorToolBox.smethod_0().method_8(this, viewport_, e))
				{
					if (this.int_5 != -1)
					{
						Vector3.Unproject(new Vector3((float)e.X, (float)e.Y, 0f), (float)viewport_.X, (float)viewport_.Y, (float)viewport_.Width, (float)viewport_.Height, viewport_.MinZ, viewport_.MaxZ, Matrix.RotationY(this.float_3) * this.matrix_4 * this.matrix_2 * this.matrix_0);
						Vector3 left = Vector3.Unproject(new Vector3((float)e.X, (float)e.Y, 1f), (float)viewport_.X, (float)viewport_.Y, (float)viewport_.Width, (float)viewport_.Height, viewport_.MinZ, viewport_.MaxZ, Matrix.RotationY(this.float_3) * this.matrix_4 * this.matrix_2 * this.matrix_0);
						Vector3 right = Vector3.Unproject(new Vector3((float)this.int_3, (float)this.int_4, 1f), (float)viewport_.X, (float)viewport_.Y, (float)viewport_.Width, (float)viewport_.Height, viewport_.MinZ, viewport_.MaxZ, this.matrix_4 * this.matrix_2 * this.matrix_0);
						left - right;
						if (e.Button == MouseButtons.Left)
						{
							Matrix matrix = this.matrix_3[this.int_5];
							float num3 = 1E-05f;
							float num4 = num3;
							Vector2 value = new Vector2((float)(e.X - this.point_0.X), (float)(e.Y - this.point_0.Y));
							Vector3 vector = Vector3.TransformCoordinate(Vector3.Zero, matrix);
							Vector3 vector2 = Vector3.Zero;
							switch (this.int_6)
							{
							case 1:
								vector2 = Vector3.TransformCoordinate(Vector3.Zero, Matrix.Translation(new Vector3(num4, 0f, 0f)) * matrix);
								break;
							case 2:
								vector2 = Vector3.TransformCoordinate(Vector3.Zero, Matrix.Translation(new Vector3(0f, num4, 0f)) * matrix);
								break;
							case 3:
								vector2 = Vector3.TransformCoordinate(Vector3.Zero, Matrix.Translation(new Vector3(0f, 0f, num4)) * matrix);
								break;
							}
							Vector3 vector3 = Vector3.Project(vector, (float)viewport_.X, (float)viewport_.Y, (float)viewport_.Width, (float)viewport_.Height, viewport_.MinZ, viewport_.MaxZ, this.matrix_4 * this.matrix_2 * this.matrix_0);
							Vector3 vector4 = Vector3.Project(vector2, (float)viewport_.X, (float)viewport_.Y, (float)viewport_.Width, (float)viewport_.Height, viewport_.MinZ, viewport_.MaxZ, this.matrix_4 * this.matrix_2 * this.matrix_0);
							float num5 = Vector2.Distance(new Vector2(vector3.X, vector3.Y), value);
							float num6 = Vector2.Distance(new Vector2(vector4.X, vector4.Y), value);
							float num7 = num5;
							if (num6 > num5)
							{
								num3 = -num3;
								num4 = num3;
								switch (this.int_6)
								{
								case 1:
									vector2 = Vector3.TransformCoordinate(Vector3.Zero, Matrix.Translation(new Vector3(num4, 0f, 0f)) * matrix);
									break;
								case 2:
									vector2 = Vector3.TransformCoordinate(Vector3.Zero, Matrix.Translation(new Vector3(0f, num4, 0f)) * matrix);
									break;
								case 3:
									vector2 = Vector3.TransformCoordinate(Vector3.Zero, Matrix.Translation(new Vector3(0f, 0f, num4)) * matrix);
									break;
								}
								vector4 = Vector3.Project(vector2, (float)viewport_.X, (float)viewport_.Y, (float)viewport_.Width, (float)viewport_.Height, viewport_.MinZ, viewport_.MaxZ, this.matrix_4 * this.matrix_2 * this.matrix_0);
								num6 = Vector2.Distance(new Vector2(vector4.X, vector4.Y), value);
							}
							while (num6 < num7)
							{
								num7 = num6;
								num4 += num3;
								switch (this.int_6)
								{
								case 1:
									vector2 = Vector3.TransformCoordinate(Vector3.Zero, Matrix.Translation(new Vector3(num4, 0f, 0f)) * matrix);
									break;
								case 2:
									vector2 = Vector3.TransformCoordinate(Vector3.Zero, Matrix.Translation(new Vector3(0f, num4, 0f)) * matrix);
									break;
								case 3:
									vector2 = Vector3.TransformCoordinate(Vector3.Zero, Matrix.Translation(new Vector3(0f, 0f, num4)) * matrix);
									break;
								}
								vector4 = Vector3.Project(vector2, (float)viewport_.X, (float)viewport_.Y, (float)viewport_.Width, (float)viewport_.Height, viewport_.MinZ, viewport_.MaxZ, this.matrix_4 * this.matrix_2 * this.matrix_0);
								num6 = Vector2.Distance(new Vector2(vector4.X, vector4.Y), value);
							}
							switch (this.int_6)
							{
							case 1:
								this.matrix_3[this.int_5] = Matrix.Translation(new Vector3(num4, 0f, 0f)) * matrix;
								if (this.int_5 == 0)
								{
									this.float_2[0] = Vector3.TransformCoordinate(Vector3.Zero, this.matrix_3[this.int_5]).X;
									this.string_1 = this.float_2[0].ToString("0.000");
								}
								else
								{
									this.float_2[3] = Vector3.TransformCoordinate(Vector3.Zero, this.matrix_3[this.int_5]).X;
									this.string_1 = this.float_2[3].ToString("0.000");
								}
								break;
							case 2:
								this.matrix_3[this.int_5] = Matrix.Translation(new Vector3(0f, num4, 0f)) * matrix;
								if (this.int_5 == 2)
								{
									this.float_2[1] = Vector3.TransformCoordinate(Vector3.Zero, this.matrix_3[this.int_5]).Y;
									this.string_1 = this.float_2[1].ToString("0.000");
								}
								else
								{
									this.float_2[4] = Vector3.TransformCoordinate(Vector3.Zero, this.matrix_3[this.int_5]).Y;
									this.string_1 = this.float_2[4].ToString("0.000");
								}
								break;
							case 3:
								this.matrix_3[this.int_5] = Matrix.Translation(new Vector3(0f, 0f, num4)) * matrix;
								if (this.int_5 == 4)
								{
									this.float_2[5] = Vector3.TransformCoordinate(Vector3.Zero, this.matrix_3[this.int_5]).Z;
									this.string_1 = this.float_2[5].ToString("0.000");
								}
								else
								{
									this.float_2[2] = Vector3.TransformCoordinate(Vector3.Zero, this.matrix_3[this.int_5]).Z;
									this.string_1 = this.float_2[2].ToString("0.000");
								}
								break;
							}
							this.method_34(this.float_2);
						}
						this.int_3 = num;
						this.int_4 = num2;
					}
					else if (this.interface10_0 != null)
					{
						Vector3.Unproject(new Vector3((float)e.X, (float)e.Y, 0f), (float)viewport_.X, (float)viewport_.Y, (float)viewport_.Width, (float)viewport_.Height, viewport_.MinZ, viewport_.MaxZ, this.matrix_4 * this.matrix_2 * this.matrix_0);
						Vector3 left2 = Vector3.Unproject(new Vector3((float)e.X, (float)e.Y, 1f), (float)viewport_.X, (float)viewport_.Y, (float)viewport_.Width, (float)viewport_.Height, viewport_.MinZ, viewport_.MaxZ, this.matrix_4 * this.matrix_2 * this.matrix_0);
						Vector3 right2 = Vector3.Unproject(new Vector3((float)this.int_3, (float)this.int_4, 1f), (float)viewport_.X, (float)viewport_.Y, (float)viewport_.Width, (float)viewport_.Height, viewport_.MinZ, viewport_.MaxZ, this.matrix_4 * this.matrix_2 * this.matrix_0);
						left2 - right2;
						this.string_1 = this.interface10_0.Name;
						if (e.Button == MouseButtons.Left)
						{
							float num8 = 0.0001f;
							float num9 = num8;
							Vector2 value2 = new Vector2((float)(e.X - this.point_0.X), (float)(e.Y - this.point_0.Y));
							Vector3 vector5 = Vector3.TransformCoordinate(Vector3.Zero, this.interface10_0.WorldTransformation);
							Vector3 vector6 = Vector3.Zero;
							switch (this.interface10_0.CurrentDragMode)
							{
							case Enum18.const_0:
								vector6 = Vector3.TransformCoordinate(Vector3.Zero, Matrix.Translation(new Vector3(num9, 0f, 0f)) * this.interface10_0.WorldTransformation);
								break;
							case Enum18.const_1:
								vector6 = Vector3.TransformCoordinate(Vector3.Zero, Matrix.Translation(new Vector3(0f, num9, 0f)) * this.interface10_0.WorldTransformation);
								break;
							case Enum18.const_2:
								vector6 = Vector3.TransformCoordinate(Vector3.Zero, Matrix.Translation(new Vector3(0f, 0f, num9)) * this.interface10_0.WorldTransformation);
								break;
							}
							Vector3 vector7 = Vector3.Project(vector5, (float)viewport_.X, (float)viewport_.Y, (float)viewport_.Width, (float)viewport_.Height, viewport_.MinZ, viewport_.MaxZ, this.matrix_4 * this.matrix_2 * this.matrix_0);
							Vector3 vector8 = Vector3.Project(vector6, (float)viewport_.X, (float)viewport_.Y, (float)viewport_.Width, (float)viewport_.Height, viewport_.MinZ, viewport_.MaxZ, this.matrix_4 * this.matrix_2 * this.matrix_0);
							float num10 = Vector2.Distance(new Vector2(vector7.X, vector7.Y), value2);
							float num11 = Vector2.Distance(new Vector2(vector8.X, vector8.Y), value2);
							float num12 = num10;
							if (num11 > num10)
							{
								num8 = -num8;
								num9 = num8;
								switch (this.interface10_0.CurrentDragMode)
								{
								case Enum18.const_0:
									vector6 = Vector3.TransformCoordinate(Vector3.Zero, Matrix.Translation(new Vector3(num9, 0f, 0f)) * this.interface10_0.WorldTransformation);
									break;
								case Enum18.const_1:
									vector6 = Vector3.TransformCoordinate(Vector3.Zero, Matrix.Translation(new Vector3(0f, num9, 0f)) * this.interface10_0.WorldTransformation);
									break;
								case Enum18.const_2:
									vector6 = Vector3.TransformCoordinate(Vector3.Zero, Matrix.Translation(new Vector3(0f, 0f, num9)) * this.interface10_0.WorldTransformation);
									break;
								}
								vector8 = Vector3.Project(vector6, (float)viewport_.X, (float)viewport_.Y, (float)viewport_.Width, (float)viewport_.Height, viewport_.MinZ, viewport_.MaxZ, this.matrix_4 * this.matrix_2 * this.matrix_0);
								num11 = Vector2.Distance(new Vector2(vector8.X, vector8.Y), value2);
							}
							while (num11 < num12)
							{
								num12 = num11;
								num9 += num8;
								switch (this.interface10_0.CurrentDragMode)
								{
								case Enum18.const_0:
									vector6 = Vector3.TransformCoordinate(Vector3.Zero, Matrix.Translation(new Vector3(num9, 0f, 0f)) * this.interface10_0.WorldTransformation);
									break;
								case Enum18.const_1:
									vector6 = Vector3.TransformCoordinate(Vector3.Zero, Matrix.Translation(new Vector3(0f, num9, 0f)) * this.interface10_0.WorldTransformation);
									break;
								case Enum18.const_2:
									vector6 = Vector3.TransformCoordinate(Vector3.Zero, Matrix.Translation(new Vector3(0f, 0f, num9)) * this.interface10_0.WorldTransformation);
									break;
								}
								vector8 = Vector3.Project(vector6, (float)viewport_.X, (float)viewport_.Y, (float)viewport_.Width, (float)viewport_.Height, viewport_.MinZ, viewport_.MaxZ, this.matrix_4 * this.matrix_2 * this.matrix_0);
								num11 = Vector2.Distance(new Vector2(vector8.X, vector8.Y), value2);
							}
							Matrix transformation = Matrix.Identity;
							switch (this.interface10_0.CurrentDragMode)
							{
							case Enum18.const_0:
								transformation = Matrix.Translation(new Vector3(num9 - 0.07f, 0f, 0f)) * this.interface10_0.Transformation;
								this.interface10_0.Transformation = transformation;
								break;
							case Enum18.const_1:
								transformation = Matrix.Translation(new Vector3(0f, num9 - 0.07f, 0f)) * this.interface10_0.Transformation;
								this.interface10_0.Transformation = transformation;
								break;
							case Enum18.const_2:
								transformation = Matrix.Translation(new Vector3(0f, 0f, num9 - 0.07f)) * this.interface10_0.Transformation;
								this.interface10_0.Transformation = transformation;
								break;
							}
						}
						else if (e.Button == MouseButtons.Right && (Control.ModifierKeys & Keys.Control) != Keys.None)
						{
							switch (this.interface10_0.CurrentDragMode)
							{
							case Enum18.const_0:
								this.interface10_0.Transformation = Matrix.RotationX((float)(-(float)(this.int_4 - num2)) * 0.01f) * this.interface10_0.Transformation;
								break;
							case Enum18.const_1:
								this.interface10_0.Transformation = Matrix.RotationY((float)(-(float)(this.int_4 - num2)) * 0.01f) * this.interface10_0.Transformation;
								break;
							case Enum18.const_2:
								this.interface10_0.Transformation = Matrix.RotationZ((float)(-(float)(this.int_4 - num2)) * 0.01f) * this.interface10_0.Transformation;
								break;
							}
						}
						this.int_3 = num;
						this.int_4 = num2;
					}
					else if (this.interface2_0 != null && !this.interface2_0.imethod_1(e, viewport_, this.ProjectionMatrix, this.ViewMatrix, this.WorldMatrix))
					{
						this.int_3 = e.X;
						this.int_4 = e.Y;
					}
					else if (this.class120_0 != null && e.Button == MouseButtons.Right)
					{
						Vector3 value3 = Vector3.Unproject(new Vector3((float)this.int_3, (float)this.int_4, 1f), (float)viewport_.X, (float)viewport_.Y, (float)viewport_.Width, (float)viewport_.Height, viewport_.MinZ, viewport_.MaxZ, this.matrix_4 * this.matrix_2 * this.matrix_0);
						Vector3 value4 = Vector3.Unproject(new Vector3((float)e.X, (float)e.Y, 1f), (float)viewport_.X, (float)viewport_.Y, (float)viewport_.Width, (float)viewport_.Height, viewport_.MinZ, viewport_.MaxZ, this.matrix_4 * this.matrix_2 * this.matrix_0);
						float num13 = Vector3.Distance(value3, value4) * 0.05f;
						this.class120_0.Angle += ((this.int_4 > e.Y) ? num13 : (-num13));
						this.class120_0.method_0();
						this.int_3 = e.X;
						this.int_4 = e.Y;
					}
					else if (this.class120_0 != null && e.Button == MouseButtons.Left)
					{
						Vector3 value5 = Vector3.Unproject(new Vector3((float)e.X, (float)e.Y, 0f), (float)viewport_.X, (float)viewport_.Y, (float)viewport_.Width, (float)viewport_.Height, viewport_.MinZ, viewport_.MaxZ, this.matrix_4 * this.matrix_2 * this.matrix_0);
						Vector3 left3 = Vector3.Unproject(new Vector3((float)e.X, (float)e.Y, 1f), (float)viewport_.X, (float)viewport_.Y, (float)viewport_.Width, (float)viewport_.Height, viewport_.MinZ, viewport_.MaxZ, this.matrix_4 * this.matrix_2 * this.matrix_0);
						Vector3 right3 = Vector3.Unproject(new Vector3((float)this.int_3, (float)this.int_4, 1f), (float)viewport_.X, (float)viewport_.Y, (float)viewport_.Width, (float)viewport_.Height, viewport_.MinZ, viewport_.MaxZ, this.matrix_4 * this.matrix_2 * this.matrix_0);
						left3 - right3;
						if (this.enum9_0 == MeshEditor.Enum9.const_0)
						{
							float num14 = Vector3.Distance(value5, this.vector3_4);
							left3 = Class121.smethod_0(value5, left3, num14);
							this.class120_0.vector3_1 = left3;
						}
						else
						{
							switch (this.enum9_0)
							{
							case MeshEditor.Enum9.const_1:
							{
								Vector3 vector9 = Class121.smethod_0(value5, left3, value5.Y);
								this.class120_0.vector3_1 = new Vector3(vector9.X, this.class120_0.vector3_1.Y, vector9.Z);
								break;
							}
							case MeshEditor.Enum9.const_2:
							{
								Vector3 vector10 = Class121.smethod_0(value5, left3, value5.Y);
								this.class120_0.vector3_1 = new Vector3(-vector10.X, this.class120_0.vector3_1.Y, -vector10.Z);
								break;
							}
							case MeshEditor.Enum9.const_3:
							{
								Vector3 vector11 = Class121.smethod_0(value5, left3, value5.X);
								this.class120_0.vector3_1 = new Vector3(this.class120_0.vector3_1.X, -vector11.Y, -vector11.Z);
								break;
							}
							case MeshEditor.Enum9.const_4:
							{
								Vector3 vector12 = Class121.smethod_0(value5, left3, value5.X);
								this.class120_0.vector3_1 = new Vector3(this.class120_0.vector3_1.X, vector12.Y, vector12.Z);
								break;
							}
							case MeshEditor.Enum9.const_5:
							{
								Vector3 vector13 = Class121.smethod_0(value5, left3, value5.Z);
								this.class120_0.vector3_1 = new Vector3(-vector13.X, -vector13.Y, this.class120_0.vector3_1.Z);
								break;
							}
							case MeshEditor.Enum9.const_6:
							{
								Vector3 vector14 = Class121.smethod_0(value5, left3, value5.Z);
								this.class120_0.vector3_1 = new Vector3(vector14.X, vector14.Y, this.class120_0.vector3_1.Z);
								break;
							}
							}
						}
						this.int_3 = e.X;
						this.int_4 = e.Y;
						this.class120_0.method_0();
					}
					else
					{
						if (this.enum9_0 == MeshEditor.Enum9.const_0)
						{
							if (e.Button == MouseButtons.Left)
							{
								int num15 = 0;
								int num16 = 0;
								if (this.int_3 != -1)
								{
									num16 = e.X - this.int_3;
								}
								if (this.int_4 != -1)
								{
									num15 = e.Y - this.int_4;
								}
								num = base.Width / 2 + num16;
								num2 = base.Height / 2 + num15;
								if (!MeshEditor.bool_2 && !Class132.mainForm.ViewPanButton.Checked && !this.bool_5)
								{
									if (!this.bool_4 && !Class132.mainForm.ViewZoomButton.Checked)
									{
										this.class100_0.method_4(base.Width / 2, base.Height / 2);
										this.class100_0.method_5(num, num2);
										Vector3 coordinate = this.class100_0.method_1((float)e.X, (float)e.Y);
										Vector3.TransformCoordinate(coordinate, Matrix.RotationX(this.float_0));
										if (Math.Abs(num16) > Math.Abs(num15))
										{
											this.float_0 += (float)num16 * 0.005f;
										}
										else
										{
											this.float_1 -= (float)(-(float)num15) * 0.005f;
										}
									}
									else
									{
										this.class100_0.method_9(e.X, e.Y);
									}
								}
								else
								{
									this.class100_0.method_8(e.X, e.Y);
								}
							}
							else if (e.Button == MouseButtons.Right)
							{
								this.class100_0.method_9(num, num2);
							}
							else
							{
								this.class100_0.method_10(num, num2);
							}
						}
						else
						{
							int x = e.X;
							int y = e.Y;
							if (e.Button == MouseButtons.Right)
							{
								Vector3 value6 = Vector3.Unproject(new Vector3((float)this.int_3, (float)this.int_4, 1f), (float)viewport_.X, (float)viewport_.Y, (float)viewport_.Width, (float)viewport_.Height, viewport_.MinZ, viewport_.MaxZ, this.matrix_4 * this.matrix_2 * this.matrix_0);
								Vector3 value7 = Vector3.Unproject(new Vector3((float)e.X, (float)e.Y, 1f), (float)viewport_.X, (float)viewport_.Y, (float)viewport_.Width, (float)viewport_.Height, viewport_.MinZ, viewport_.MaxZ, this.matrix_4 * this.matrix_2 * this.matrix_0);
								float num17 = Vector3.Distance(value6, value7) * 0.01f;
								switch (this.enum9_0)
								{
								case MeshEditor.Enum9.const_1:
									this.CameraPosition = new Vector3(this.CameraPosition.X, this.CameraPosition.Y + ((this.int_4 < e.Y) ? num17 : (-num17)), this.CameraPosition.Z);
									this.CameraTarget = new Vector3(this.CameraTarget.X, this.CameraTarget.Y + ((this.int_4 < e.Y) ? num17 : (-num17)), this.CameraTarget.Z);
									break;
								case MeshEditor.Enum9.const_2:
									this.CameraPosition = new Vector3(this.CameraPosition.X, this.CameraPosition.Y + ((this.int_4 > e.Y) ? num17 : (-num17)), this.CameraPosition.Z);
									this.CameraTarget = new Vector3(this.CameraTarget.X, this.CameraTarget.Y + ((this.int_4 > e.Y) ? num17 : (-num17)), this.CameraTarget.Z);
									break;
								case MeshEditor.Enum9.const_3:
									this.CameraPosition = new Vector3(this.CameraPosition.X + ((this.int_4 > e.Y) ? num17 : (-num17)), this.CameraPosition.Y, this.CameraPosition.Z);
									this.CameraTarget = new Vector3(this.CameraTarget.X + ((this.int_4 > e.Y) ? num17 : (-num17)), this.CameraTarget.Y, this.CameraTarget.Z);
									break;
								case MeshEditor.Enum9.const_4:
									this.CameraPosition = new Vector3(this.CameraPosition.X + ((this.int_4 < e.Y) ? num17 : (-num17)), this.CameraPosition.Y, this.CameraPosition.Z);
									this.CameraTarget = new Vector3(this.CameraTarget.X + ((this.int_4 < e.Y) ? num17 : (-num17)), this.CameraTarget.Y, this.CameraTarget.Z);
									break;
								case MeshEditor.Enum9.const_5:
									this.CameraPosition = new Vector3(this.CameraPosition.X, this.CameraPosition.Y, this.CameraPosition.Z + ((this.int_4 > e.Y) ? (-num17) : num17));
									this.CameraTarget = new Vector3(this.CameraTarget.X, this.CameraTarget.Y, this.CameraTarget.Z + ((this.int_4 > e.Y) ? (-num17) : num17));
									break;
								case MeshEditor.Enum9.const_6:
									this.CameraPosition = new Vector3(this.CameraPosition.X, this.CameraPosition.Y, this.CameraPosition.Z + ((this.int_4 < e.Y) ? (-num17) : num17));
									this.CameraTarget = new Vector3(this.CameraTarget.X, this.CameraTarget.Y, this.CameraTarget.Z + ((this.int_4 < e.Y) ? (-num17) : num17));
									break;
								}
							}
						}
						this.int_3 = e.X;
						this.int_4 = e.Y;
					}
				}
			}
		}

		// Token: 0x0600056C RID: 1388 RVA: 0x000579F0 File Offset: 0x00055BF0
		public Interface9[] method_45()
		{
			List<Interface9> list = new List<Interface9>();
			foreach (Class102 @class in this.Renderables)
			{
				if (@class is Class105)
				{
					using (Dictionary<MLOD.MLODEntry, Interface9>.ValueCollection.Enumerator enumerator2 = (@class as Class105).Objects.Values.GetEnumerator())
					{
						while (enumerator2.MoveNext())
						{
							Interface9 @interface = enumerator2.Current;
							Class121 class2 = (Class121)@interface;
							if (class2.Visible && class2.LOD == (@class as Class105).LODLevel)
							{
								list.Add(class2);
							}
						}
						continue;
					}
				}
				if (@class is Class104)
				{
					foreach (Class104.Class110 class3 in (@class as Class104).Containers)
					{
						if (class3.IsBaseMesh)
						{
							foreach (Class104.Class109 class4 in class3.Items)
							{
								if (class4.Visible && class4.LOD == (@class as Class104).LODLevel)
								{
									list.Add(class4);
								}
							}
						}
					}
				}
			}
			return list.ToArray();
		}

		// Token: 0x0600056D RID: 1389 RVA: 0x00057BB8 File Offset: 0x00055DB8
		public static bool smethod_0(Vector3 vector3_5, Vector3 vector3_6, Vector3 vector3_7, Vector3 vector3_8, Vector3 vector3_9, out float float_10, out float float_11, out float float_12)
		{
			float_10 = 0f;
			float_11 = 0f;
			float_12 = 0f;
			Vector3 vector = vector3_8 - vector3_7;
			Vector3 vector2 = vector3_9 - vector3_7;
			Vector3 right = Vector3.Cross(vector3_6, vector2);
			float num = Vector3.Dot(vector, right);
			bool result;
			if (num > -1E-05f)
			{
				result = false;
			}
			else
			{
				float num2 = 1f / num;
				Vector3 left = vector3_5 - vector3_7;
				float_11 = Vector3.Dot(left, right) * num2;
				if (float_11 >= -0.001f && float_11 <= 1.001f)
				{
					Vector3 right2 = Vector3.Cross(left, vector);
					float_12 = Vector3.Dot(vector3_6, right2) * num2;
					if (float_12 >= -0.001f && float_11 + float_12 <= 1.001f)
					{
						float_10 = Vector3.Dot(vector2, right2) * num2;
						if (float_10 <= 0f)
						{
							result = false;
						}
						else
						{
							result = true;
						}
					}
					else
					{
						result = false;
					}
				}
				else
				{
					result = false;
				}
			}
			return result;
		}

		// Token: 0x170000EA RID: 234
		// (get) Token: 0x0600056E RID: 1390 RVA: 0x00057CA0 File Offset: 0x00055EA0
		public Class100 ArcBall
		{
			get
			{
				return this.class100_0;
			}
		}

		// Token: 0x170000EB RID: 235
		// (get) Token: 0x0600056F RID: 1391 RVA: 0x00057CB8 File Offset: 0x00055EB8
		// (set) Token: 0x06000570 RID: 1392 RVA: 0x00004C4C File Offset: 0x00002E4C
		public Vector3 CameraTarget
		{
			get
			{
				return this.vector3_2;
			}
			set
			{
				this.vector3_2 = value;
			}
		}

		// Token: 0x170000EC RID: 236
		// (get) Token: 0x06000571 RID: 1393 RVA: 0x00057CD0 File Offset: 0x00055ED0
		// (set) Token: 0x06000572 RID: 1394 RVA: 0x00004C57 File Offset: 0x00002E57
		public Vector3 CameraPosition
		{
			get
			{
				return this.vector3_0;
			}
			set
			{
				this.vector3_0 = value;
			}
		}

		// Token: 0x170000ED RID: 237
		// (get) Token: 0x06000573 RID: 1395 RVA: 0x00057CE8 File Offset: 0x00055EE8
		// (set) Token: 0x06000574 RID: 1396 RVA: 0x00004C62 File Offset: 0x00002E62
		public Matrix CameraTranslation
		{
			get
			{
				return this.class100_0.TranslationMatrix;
			}
			set
			{
				this.class100_0.TranslationMatrix = value;
			}
		}

		// Token: 0x06000575 RID: 1397 RVA: 0x00057D04 File Offset: 0x00055F04
		public void method_46()
		{
			foreach (Class102 @class in this.list_0)
			{
				Vector3[] array = @class.imethod_13();
				float x = (array[1].X + array[0].X) / 2f;
				float y = (array[1].Y + array[0].Y) / 2f;
				float z = (array[1].Z + array[0].Z) / 2f;
				this.vector3_0.X = x;
				this.vector3_0.Y = y;
				this.vector3_0.Z = array[1].Z + (array[1].Y - array[0].Y) * 2f;
				this.vector3_2.X = x;
				this.vector3_2.Y = y;
				this.vector3_2.Z = z;
				this.class100_0.CurrentQuaternion = Quaternion.Identity;
				this.class100_0.TranslationMatrix = Matrix.Identity;
				float num = 0f;
				float num2 = 0f;
				this.float_1 = num;
				this.float_0 = num2;
			}
		}

		// Token: 0x06000576 RID: 1398 RVA: 0x00057E7C File Offset: 0x0005607C
		public void method_47()
		{
			foreach (Class102 @class in this.list_0)
			{
				Vector3[] array = @class.imethod_13();
				float x = (array[1].X + array[0].X) / 2f;
				float y = (array[1].Y + array[0].Y) / 2f;
				float z = (array[1].Z + array[0].Z) / 2f;
				this.vector3_2.X = x;
				this.vector3_2.Y = y;
				this.vector3_2.Z = z;
			}
		}

		// Token: 0x06000577 RID: 1399 RVA: 0x00057F60 File Offset: 0x00056160
		private Vector3[] method_48()
		{
			Vector3[] array = new Vector3[2];
			array[0].X = float.MaxValue;
			array[0].Y = float.MaxValue;
			array[0].Z = float.MaxValue;
			array[1].X = float.MinValue;
			array[1].Y = float.MinValue;
			array[1].Z = float.MinValue;
			foreach (Class102 @class in this.list_0)
			{
				Vector3[] array2 = @class.imethod_13();
				array[0].X = Math.Min(array[0].X, array2[0].X);
				array[0].Y = Math.Min(array[0].Y, array2[0].Y);
				array[0].Z = Math.Min(array[0].Z, array2[0].Z);
				array[1].X = Math.Max(array[1].X, array2[1].X);
				array[1].Y = Math.Max(array[1].Y, array2[1].Y);
				array[1].Z = Math.Max(array[1].Z, array2[1].Z);
			}
			return array;
		}

		// Token: 0x170000EE RID: 238
		// (get) Token: 0x06000578 RID: 1400 RVA: 0x00058130 File Offset: 0x00056330
		// (set) Token: 0x06000579 RID: 1401 RVA: 0x00058148 File Offset: 0x00056348
		public MeshEditor.Enum9 ViewMode
		{
			get
			{
				return this.enum9_0;
			}
			set
			{
				if (this.enum9_0 == MeshEditor.Enum9.const_0)
				{
					this.float_4 = this.CameraPosition.X;
					this.float_5 = this.CameraPosition.Y;
					this.float_6 = this.CameraPosition.Z;
					this.float_7 = this.CameraTarget.X;
					this.float_8 = this.CameraTarget.Y;
					this.float_9 = this.CameraTarget.Z;
				}
				Vector3[] array = new Vector3[2];
				foreach (Class102 @class in this.list_0)
				{
					array = @class.imethod_13();
				}
				float y = (array[1].Y - array[0].Y) / 2f;
				this.enum9_0 = value;
				this.method_48();
				switch (this.enum9_0)
				{
				case MeshEditor.Enum9.const_0:
					this.CameraPosition = new Vector3(this.float_4, this.float_5, this.float_6);
					this.CameraTarget = new Vector3(this.float_7, this.float_8, this.float_9);
					this.vector3_1 = Vector3.UnitY;
					break;
				case MeshEditor.Enum9.const_1:
					this.CameraPosition = new Vector3(0f, 6f, 0f);
					this.CameraTarget = new Vector3(0f, 0f, 0f);
					this.vector3_1 = -Vector3.UnitZ;
					break;
				case MeshEditor.Enum9.const_2:
					this.CameraPosition = new Vector3(0f, -6f, 0f);
					this.CameraTarget = new Vector3(0f, 0f, 0f);
					this.vector3_1 = Vector3.UnitZ;
					break;
				case MeshEditor.Enum9.const_3:
					this.CameraPosition = new Vector3(-6f, y, 0f);
					this.CameraTarget = new Vector3(0f, this.CameraPosition.Y, 0f);
					this.vector3_1 = Vector3.UnitY;
					break;
				case MeshEditor.Enum9.const_4:
					this.CameraPosition = new Vector3(6f, y, 0f);
					this.CameraTarget = new Vector3(0f, this.CameraPosition.Y, 0f);
					this.vector3_1 = Vector3.UnitY;
					break;
				case MeshEditor.Enum9.const_5:
					this.CameraPosition = new Vector3(0f, y, 6f);
					this.CameraTarget = new Vector3(0f, this.CameraPosition.Y, 0f);
					this.vector3_1 = Vector3.UnitY;
					break;
				case MeshEditor.Enum9.const_6:
					this.CameraPosition = new Vector3(0f, y, -6f);
					this.CameraTarget = new Vector3(0f, this.CameraPosition.Y, 0f);
					this.vector3_1 = Vector3.UnitY;
					break;
				}
			}
		}

		// Token: 0x0600057A RID: 1402 RVA: 0x00058458 File Offset: 0x00056658
		public void method_49(S_CLIP s_CLIP_1)
		{
			this.s_CLIP_0 = s_CLIP_1;
			if (this.timer_0 == null)
			{
				this.timer_0 = new Timer();
				this.timer_0.Interval = 500;
				this.timer_0.Tick += this.timer_0_Tick;
				this.timer_0.Start();
			}
			this.timer_0.Interval = 45;
			if (s_CLIP_1 == null)
			{
				this.animationPanel.Visible = false;
				this.animationBar.Value = 0;
				this.bool_6 = false;
			}
			else
			{
				int num = 0;
				foreach (S_CLIP.JointMovementRule jointMovementRule in s_CLIP_1.GetJointMovementRules())
				{
					foreach (S_CLIP.Frame frame in jointMovementRule.Frames)
					{
						num = Math.Max(num, (int)frame.frameIndex);
					}
				}
				this.animationBar.Minimum = 0;
				this.animationBar.Maximum = num;
				this.animationBar.Value = 0;
				this.animationPanel.Visible = true;
			}
			foreach (Class102 @class in this.list_0)
			{
				@class.imethod_12(s_CLIP_1);
				@class.imethod_11(0);
			}
		}

		// Token: 0x0600057B RID: 1403 RVA: 0x000585F0 File Offset: 0x000567F0
		private void timer_0_Tick(object sender, EventArgs e)
		{
			if (this.bool_6)
			{
				if (this.animationBar.Value == this.animationBar.Maximum)
				{
					this.animationBar.Value = 0;
				}
				else
				{
					this.animationBar.Value = this.animationBar.Value + 1;
				}
				this.animationBar_Scroll(sender, e);
			}
		}

		// Token: 0x0600057C RID: 1404 RVA: 0x00058650 File Offset: 0x00056850
		private void animationBar_Scroll(object sender, EventArgs e)
		{
			foreach (Class102 @class in this.list_0)
			{
				@class.imethod_11(this.animationBar.Value);
			}
		}

		// Token: 0x0600057D RID: 1405 RVA: 0x00004C72 File Offset: 0x00002E72
		private void playButton_Click(object sender, EventArgs e)
		{
			this.bool_6 = !this.bool_6;
			this.playButton.Text = (this.bool_6 ? "Pause" : "Play");
		}

		// Token: 0x0600057E RID: 1406 RVA: 0x000586B0 File Offset: 0x000568B0
		private void InitializeComponent()
		{
			this.panel_0 = new Panel();
			this.animationPanel = new Panel();
			this.animationBar = new TrackBar();
			this.playButton = new Button();
			this.RenderPanel.SuspendLayout();
			this.animationPanel.SuspendLayout();
			((ISupportInitialize)this.animationBar).BeginInit();
			base.SuspendLayout();
			this.RenderPanel.BackColor = Color.White;
			this.RenderPanel.Controls.Add(this.animationPanel);
			this.RenderPanel.Dock = DockStyle.Fill;
			this.RenderPanel.Location = new Point(0, 0);
			this.RenderPanel.Margin = new Padding(0);
			this.RenderPanel.Name = "RenderPanel";
			this.RenderPanel.Size = new Size(984, 671);
			this.RenderPanel.TabIndex = 0;
			this.RenderPanel.MouseMove += this.method_44;
			this.RenderPanel.MouseDown += this.method_43;
			this.RenderPanel.MouseUp += this.method_42;
			this.animationPanel.Controls.Add(this.animationBar);
			this.animationPanel.Controls.Add(this.playButton);
			this.animationPanel.Dock = DockStyle.Bottom;
			this.animationPanel.Location = new Point(0, 635);
			this.animationPanel.Name = "animationPanel";
			this.animationPanel.Padding = new Padding(3);
			this.animationPanel.Size = new Size(984, 36);
			this.animationPanel.TabIndex = 0;
			this.animationPanel.Visible = false;
			this.animationBar.Dock = DockStyle.Fill;
			this.animationBar.Location = new Point(3, 3);
			this.animationBar.Name = "animationBar";
			this.animationBar.Size = new Size(923, 30);
			this.animationBar.TabIndex = 1;
			this.animationBar.Scroll += this.animationBar_Scroll;
			this.playButton.Dock = DockStyle.Right;
			this.playButton.Location = new Point(926, 3);
			this.playButton.Name = "playButton";
			this.playButton.Size = new Size(55, 30);
			this.playButton.TabIndex = 2;
			this.playButton.Text = "Play";
			this.playButton.UseVisualStyleBackColor = true;
			this.playButton.Click += this.playButton_Click;
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.Font;
			this.BackColor = Color.Black;
			base.BorderStyle = BorderStyle.FixedSingle;
			base.Controls.Add(this.RenderPanel);
			base.Margin = new Padding(0);
			base.Name = "MeshEditor";
			base.Size = new Size(984, 671);
			this.RenderPanel.ResumeLayout(false);
			this.animationPanel.ResumeLayout(false);
			this.animationPanel.PerformLayout();
			((ISupportInitialize)this.animationBar).EndInit();
			base.ResumeLayout(false);
		}

		// Token: 0x0600057F RID: 1407 RVA: 0x00002A71 File Offset: 0x00000C71
		[CompilerGenerated]
		private static void smethod_1(Matrix matrix_8)
		{
		}

		// Token: 0x04000495 RID: 1173
		private Interface2 interface2_0;

		// Token: 0x04000496 RID: 1174
		private Device device_0;

		// Token: 0x04000497 RID: 1175
		private Class140 class140_0;

		// Token: 0x04000498 RID: 1176
		private int int_0;

		// Token: 0x04000499 RID: 1177
		private Surface surface_0;

		// Token: 0x0400049A RID: 1178
		private Surface surface_1;

		// Token: 0x0400049B RID: 1179
		private Surface surface_2;

		// Token: 0x0400049C RID: 1180
		private Surface surface_3;

		// Token: 0x0400049D RID: 1181
		private Texture texture_0;

		// Token: 0x0400049E RID: 1182
		private Texture texture_1;

		// Token: 0x0400049F RID: 1183
		public Texture texture_2;

		// Token: 0x040004A0 RID: 1184
		private static CultureInfo cultureInfo_0 = new CultureInfo("en-US");

		// Token: 0x040004A1 RID: 1185
		private List<Class102> list_0;

		// Token: 0x040004A2 RID: 1186
		private Matrix matrix_0 = Matrix.Identity;

		// Token: 0x040004A3 RID: 1187
		private Matrix matrix_1 = Matrix.Identity;

		// Token: 0x040004A4 RID: 1188
		private Matrix matrix_2 = Matrix.Identity;

		// Token: 0x040004A5 RID: 1189
		private Vector3 vector3_0 = new Vector3(0f, 3f, 6f);

		// Token: 0x040004A6 RID: 1190
		private Vector3 vector3_1 = new Vector3(0f, 1f, 0f);

		// Token: 0x040004A7 RID: 1191
		private Vector3 vector3_2 = new Vector3(0f, 0f, 0f);

		// Token: 0x040004A8 RID: 1192
		private Vector3 vector3_3 = new Vector3(0f, -1.3f, 1.5f);

		// Token: 0x040004A9 RID: 1193
		private Class100 class100_0;

		// Token: 0x040004AA RID: 1194
		private float float_0;

		// Token: 0x040004AB RID: 1195
		private float float_1;

		// Token: 0x040004AC RID: 1196
		private Texture texture_3;

		// Token: 0x040004AD RID: 1197
		private bool bool_0;

		// Token: 0x040004AE RID: 1198
		private Material material_0;

		// Token: 0x040004AF RID: 1199
		private VertexBuffer vertexBuffer_0;

		// Token: 0x040004B0 RID: 1200
		private VertexBuffer vertexBuffer_1;

		// Token: 0x040004B1 RID: 1201
		private int int_1;

		// Token: 0x040004B2 RID: 1202
		private string string_0 = "Ground";

		// Token: 0x040004B3 RID: 1203
		private Mesh[] mesh_0;

		// Token: 0x040004B4 RID: 1204
		private Matrix[] matrix_3;

		// Token: 0x040004B5 RID: 1205
		private Image image_0;

		// Token: 0x040004B6 RID: 1206
		public SlimDX.Direct3D9.Font font_0;

		// Token: 0x040004B7 RID: 1207
		public string string_1;

		// Token: 0x040004B8 RID: 1208
		private Matrix matrix_4 = Matrix.Identity;

		// Token: 0x040004B9 RID: 1209
		private Matrix matrix_5 = Matrix.Identity;

		// Token: 0x040004BA RID: 1210
		private Matrix matrix_6;

		// Token: 0x040004BB RID: 1211
		private Matrix matrix_7 = Matrix.Identity;

		// Token: 0x040004BC RID: 1212
		private Class112.Struct7[] struct7_0;

		// Token: 0x040004BD RID: 1213
		private int int_2 = 84;

		// Token: 0x040004BE RID: 1214
		private bool bool_1;

		// Token: 0x040004BF RID: 1215
		private float[] float_2;

		// Token: 0x040004C0 RID: 1216
		private long long_0;

		// Token: 0x040004C1 RID: 1217
		private float float_3;

		// Token: 0x040004C2 RID: 1218
		public static bool bool_2 = false;

		// Token: 0x040004C3 RID: 1219
		private int int_3 = -1;

		// Token: 0x040004C4 RID: 1220
		private int int_4 = -1;

		// Token: 0x040004C5 RID: 1221
		private Vector3 vector3_4;

		// Token: 0x040004C6 RID: 1222
		private Point point_0;

		// Token: 0x040004C7 RID: 1223
		private int int_5;

		// Token: 0x040004C8 RID: 1224
		private int int_6;

		// Token: 0x040004C9 RID: 1225
		public Point point_1;

		// Token: 0x040004CA RID: 1226
		private Class120 class120_0;

		// Token: 0x040004CB RID: 1227
		private Interface10 interface10_0;

		// Token: 0x040004CC RID: 1228
		private bool bool_3;

		// Token: 0x040004CD RID: 1229
		private bool bool_4;

		// Token: 0x040004CE RID: 1230
		private bool bool_5;

		// Token: 0x040004CF RID: 1231
		private Point point_2;

		// Token: 0x040004D0 RID: 1232
		private MeshEditor.Enum9 enum9_0;

		// Token: 0x040004D1 RID: 1233
		private float float_4;

		// Token: 0x040004D2 RID: 1234
		private float float_5;

		// Token: 0x040004D3 RID: 1235
		private float float_6;

		// Token: 0x040004D4 RID: 1236
		private float float_7;

		// Token: 0x040004D5 RID: 1237
		private float float_8;

		// Token: 0x040004D6 RID: 1238
		private float float_9;

		// Token: 0x040004D7 RID: 1239
		private S_CLIP s_CLIP_0;

		// Token: 0x040004D8 RID: 1240
		private Timer timer_0;

		// Token: 0x040004D9 RID: 1241
		private bool bool_6;

		// Token: 0x040004DA RID: 1242
		private Panel animationPanel;

		// Token: 0x040004DB RID: 1243
		private TrackBar animationBar;

		// Token: 0x040004DC RID: 1244
		private Button playButton;

		// Token: 0x040004DD RID: 1245
		private Panel panel_0;

		// Token: 0x040004DE RID: 1246
		[CompilerGenerated]
		private bool bool_7;

		// Token: 0x040004DF RID: 1247
		[CompilerGenerated]
		private bool bool_8;

		// Token: 0x040004E0 RID: 1248
		[CompilerGenerated]
		private bool bool_9;

		// Token: 0x040004E1 RID: 1249
		[CompilerGenerated]
		private bool bool_10;

		// Token: 0x040004E2 RID: 1250
		[CompilerGenerated]
		private bool bool_11;

		// Token: 0x040004E3 RID: 1251
		[CompilerGenerated]
		private bool bool_12;

		// Token: 0x040004E4 RID: 1252
		[CompilerGenerated]
		private VertexBuffer vertexBuffer_2;

		// Token: 0x040004E5 RID: 1253
		[CompilerGenerated]
		private static TransformationEditor.Delegate7 delegate7_0;

		// Token: 0x02000086 RID: 134
		public enum Enum8 : uint
		{
			// Token: 0x040004E7 RID: 1255
			const_0 = 1U,
			// Token: 0x040004E8 RID: 1256
			const_1
		}

		// Token: 0x02000087 RID: 135
		public sealed class EventArgs1 : EventArgs
		{
			// Token: 0x170000EF RID: 239
			// (get) Token: 0x06000581 RID: 1409 RVA: 0x00058A10 File Offset: 0x00056C10
			// (set) Token: 0x06000582 RID: 1410 RVA: 0x00004CBD File Offset: 0x00002EBD
			public Class102 Renderable { get; set; }

			// Token: 0x06000583 RID: 1411 RVA: 0x00004CC8 File Offset: 0x00002EC8
			public EventArgs1(Class102 model)
			{
				this.Renderable = model;
			}

			// Token: 0x040004E9 RID: 1257
			[CompilerGenerated]
			private Class102 class102_0;
		}

		// Token: 0x02000088 RID: 136
		public enum Enum9
		{
			// Token: 0x040004EB RID: 1259
			const_0,
			// Token: 0x040004EC RID: 1260
			const_1,
			// Token: 0x040004ED RID: 1261
			const_2,
			// Token: 0x040004EE RID: 1262
			const_3,
			// Token: 0x040004EF RID: 1263
			const_4,
			// Token: 0x040004F0 RID: 1264
			const_5,
			// Token: 0x040004F1 RID: 1265
			const_6
		}
	}
}
