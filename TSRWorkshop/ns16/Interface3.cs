using System;
using System.Drawing;
using System.Xml;
using SlimDX.Direct3D9;

namespace ns16
{
	// Token: 0x0200002B RID: 43
	internal interface Interface3
	{
		// Token: 0x0600019E RID: 414
		bool imethod_0(Device device_0, XmlDocument xmlDocument_0, XmlElement xmlElement_0, string string_0, string string_1, Texture texture_0);

		// Token: 0x0600019F RID: 415
		void imethod_1(Size size_0);

		// Token: 0x17000039 RID: 57
		// (get) Token: 0x060001A0 RID: 416
		string Errors { get; }

		// Token: 0x060001A1 RID: 417
		void imethod_2(bool bool_0);
	}
}
