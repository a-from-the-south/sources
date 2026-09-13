using System;
using System.Drawing;
using System.Runtime.InteropServices;

namespace ns18
{
	// Token: 0x02000163 RID: 355
	internal sealed class Class164 : IDisposable
	{
		// Token: 0x060010CB RID: 4299
		[DllImport("gdi32")]
		private static extern IntPtr CreateDC(string string_0, IntPtr intptr_3, IntPtr intptr_4, IntPtr intptr_5);

		// Token: 0x060010CC RID: 4300
		[DllImport("gdi32")]
		private static extern IntPtr CreateCompatibleBitmap(IntPtr intptr_3, int int_0, int int_1);

		// Token: 0x060010CD RID: 4301
		[DllImport("gdi32")]
		private static extern IntPtr CreateCompatibleDC(IntPtr intptr_3);

		// Token: 0x060010CE RID: 4302
		[DllImport("gdi32")]
		private static extern int DeleteObject(IntPtr intptr_3);

		// Token: 0x060010CF RID: 4303
		[DllImport("gdi32")]
		private static extern int DeleteDC(IntPtr intptr_3);

		// Token: 0x060010D0 RID: 4304
		[DllImport("gdi32")]
		private static extern int BitBlt(IntPtr intptr_3, int int_0, int int_1, int int_2, int int_3, IntPtr intptr_4, int int_4, int int_5, int int_6);

		// Token: 0x060010D1 RID: 4305
		[DllImport("gdi32")]
		private static extern IntPtr SelectObject(IntPtr intptr_3, IntPtr intptr_4);

		// Token: 0x060010D3 RID: 4307 RVA: 0x000BA65C File Offset: 0x000B885C
		~Class164()
		{
			this.method_2();
		}

		// Token: 0x060010D4 RID: 4308 RVA: 0x00008E24 File Offset: 0x00007024
		public void Dispose()
		{
			this.method_2();
			GC.SuppressFinalize(this);
		}

		// Token: 0x060010D5 RID: 4309 RVA: 0x000BA68C File Offset: 0x000B888C
		public void method_0(Graphics graphics_2, Rectangle rectangle_1)
		{
			if (graphics_2 == null)
			{
				throw new ArgumentException("graphics");
			}
			if (this.size_0.Width < rectangle_1.Width || this.size_0.Height < rectangle_1.Height)
			{
				this.method_2();
				this.method_1(rectangle_1.Size.Width + rectangle_1.Size.Width % 16, rectangle_1.Size.Height + rectangle_1.Size.Height % 16);
			}
			this.graphics_0 = graphics_2;
			this.rectangle_0 = rectangle_1;
		}

		// Token: 0x060010D6 RID: 4310 RVA: 0x000BA730 File Offset: 0x000B8930
		private void method_1(int int_0, int int_1)
		{
			IntPtr intptr_ = Class164.CreateDC("DISPLAY", IntPtr.Zero, IntPtr.Zero, IntPtr.Zero);
			try
			{
				this.intptr_0 = Class164.CreateCompatibleBitmap(intptr_, int_0, int_1);
				this.intptr_1 = Class164.CreateCompatibleDC(intptr_);
				this.intptr_2 = Class164.SelectObject(this.intptr_1, this.intptr_0);
				this.graphics_1 = Graphics.FromHdc(this.intptr_1);
				this.size_0 = new Size(int_0, int_1);
			}
			finally
			{
				Class164.DeleteDC(intptr_);
			}
			GC.KeepAlive(this);
		}

		// Token: 0x060010D7 RID: 4311 RVA: 0x000BA7C8 File Offset: 0x000B89C8
		private void method_2()
		{
			if (this.intptr_0 != IntPtr.Zero)
			{
				if (this.graphics_1 != null)
				{
					this.graphics_1.Dispose();
				}
				Class164.SelectObject(this.intptr_1, this.intptr_2);
				Class164.DeleteObject(this.intptr_0);
				Class164.DeleteDC(this.intptr_1);
				this.intptr_0 = IntPtr.Zero;
				this.intptr_1 = IntPtr.Zero;
				this.size_0 = Size.Empty;
				GC.KeepAlive(this);
			}
		}

		// Token: 0x170003B3 RID: 947
		// (get) Token: 0x060010D8 RID: 4312 RVA: 0x000BA850 File Offset: 0x000B8A50
		public Graphics xbc626ed723e04991
		{
			get
			{
				if (this.graphics_1 == null)
				{
					throw new InvalidOperationException("No target has been defined.");
				}
				return this.graphics_1;
			}
		}

		// Token: 0x060010D9 RID: 4313 RVA: 0x000BA87C File Offset: 0x000B8A7C
		public void method_3()
		{
			if (this.graphics_0 == null)
			{
				throw new InvalidOperationException("No target has been defined.");
			}
			IntPtr hdc = this.graphics_0.GetHdc();
			IntPtr hdc2 = this.xbc626ed723e04991.GetHdc();
			try
			{
				Class164.BitBlt(hdc, this.rectangle_0.X, this.rectangle_0.Y, this.rectangle_0.Width, this.rectangle_0.Height, hdc2, 0, 0, 13369376);
			}
			finally
			{
				this.xbc626ed723e04991.ReleaseHdc(hdc2);
				this.graphics_0.ReleaseHdc(hdc);
			}
		}

		// Token: 0x04000BAC RID: 2988
		private Graphics graphics_0;

		// Token: 0x04000BAD RID: 2989
		private Rectangle rectangle_0;

		// Token: 0x04000BAE RID: 2990
		private Size size_0;

		// Token: 0x04000BAF RID: 2991
		private IntPtr intptr_0;

		// Token: 0x04000BB0 RID: 2992
		private IntPtr intptr_1;

		// Token: 0x04000BB1 RID: 2993
		private IntPtr intptr_2;

		// Token: 0x04000BB2 RID: 2994
		private Graphics graphics_1;
	}
}
