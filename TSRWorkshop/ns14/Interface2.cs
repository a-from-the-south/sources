using System;
using System.Windows.Forms;
using ns11;
using ns18;
using SlimDX;
using SlimDX.Direct3D9;

namespace ns14
{
	// Token: 0x02000028 RID: 40
	internal interface Interface2
	{
		// Token: 0x0600012E RID: 302
		bool imethod_0(MouseEventArgs mouseEventArgs_0, Viewport viewport_0, Matrix matrix_0, Matrix matrix_1, Matrix matrix_2);

		// Token: 0x0600012F RID: 303
		bool imethod_1(MouseEventArgs mouseEventArgs_0, Viewport viewport_0, Matrix matrix_0, Matrix matrix_1, Matrix matrix_2);

		// Token: 0x06000130 RID: 304
		bool imethod_2(MouseEventArgs mouseEventArgs_0, Viewport viewport_0, Matrix matrix_0, Matrix matrix_1, Matrix matrix_2);

		// Token: 0x06000131 RID: 305
		void imethod_3(Device device_0);

		// Token: 0x14000006 RID: 6
		// (add) Token: 0x06000132 RID: 306
		// (remove) Token: 0x06000133 RID: 307
		event Delegate4 Done;

		// Token: 0x14000007 RID: 7
		// (add) Token: 0x06000134 RID: 308
		// (remove) Token: 0x06000135 RID: 309
		event Delegate5 OnClear;

		// Token: 0x06000136 RID: 310
		void imethod_4(int int_0);

		// Token: 0x06000137 RID: 311
		void imethod_5();
	}
}
