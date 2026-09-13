using System;
using System.Drawing;
using ns2;

namespace ns16
{
	// Token: 0x0200007B RID: 123
	internal sealed class Class54 : Interface6
	{
		// Token: 0x0600049D RID: 1181 RVA: 0x0004B3A4 File Offset: 0x000495A4
		public void imethod_0(Graphics graphics_0, int int_0, Point point_0, Point point_1, Rectangle rectangle_0)
		{
			using (Pen pen = new Pen(Color.Black, 2f))
			{
				graphics_0.DrawLine(pen, point_0, point_1);
			}
		}
	}
}
