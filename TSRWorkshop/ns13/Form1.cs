using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using ns1;
using ns11;
using ns17;
using ns18;
using ns20;
using ns6;
using ns9;
using Skybound.VisualTips;

namespace ns13
{
	// Token: 0x0200017A RID: 378
	internal sealed partial class Form1 : Form
	{
		// Token: 0x0600118F RID: 4495
		[DllImport("user32")]
		private static extern int ShowWindow(IntPtr intptr_1, int int_7);

		// Token: 0x06001190 RID: 4496
		[DllImport("user32")]
		private static extern IntPtr GetDC(IntPtr intptr_1);

		// Token: 0x06001191 RID: 4497
		[DllImport("gdi32")]
		private static extern IntPtr CreateCompatibleDC(IntPtr intptr_1);

		// Token: 0x06001192 RID: 4498
		[DllImport("user32")]
		private static extern int ReleaseDC(IntPtr intptr_1, IntPtr intptr_2);

		// Token: 0x06001193 RID: 4499
		[DllImport("gdi32")]
		private static extern int DeleteDC(IntPtr intptr_1);

		// Token: 0x06001194 RID: 4500
		[DllImport("gdi32")]
		private static extern int DeleteObject(IntPtr intptr_1);

		// Token: 0x06001195 RID: 4501
		[DllImport("gdi32")]
		private static extern IntPtr SelectObject(IntPtr intptr_1, IntPtr intptr_2);

		// Token: 0x06001196 RID: 4502
		[DllImport("user32")]
		private static extern IntPtr UpdateLayeredWindow(IntPtr intptr_1, IntPtr intptr_2, ref Form1.Struct15 struct15_0, ref Form1.Struct16 struct16_0, IntPtr intptr_3, ref Form1.Struct15 struct15_1, int int_7, ref Form1.Struct17 struct17_0, int int_8);

		// Token: 0x06001197 RID: 4503
		[DllImport("user32")]
		private static extern int SetWindowPos(IntPtr intptr_1, IntPtr intptr_2, int int_7, int int_8, int int_9, int int_10, int int_11);

		// Token: 0x06001198 RID: 4504 RVA: 0x000BCB40 File Offset: 0x000BAD40
		public Form1()
		{
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.DoubleBuffer, true);
			base.StartPosition = FormStartPosition.Manual;
			base.FormBorderStyle = FormBorderStyle.None;
			base.ShowInTaskbar = false;
			this.class173_0 = new Class173(Enum30.const_2, 200);
			this.class173_0.xf61701b848da9540 += this.method_5;
			this.class173_0.x061479d2a6161ad7 = this;
		}

		// Token: 0x06001199 RID: 4505 RVA: 0x0000954F File Offset: 0x0000774F
		protected void Dispose(bool disposing)
		{
			this.method_8();
			base.Dispose(disposing);
		}

		// Token: 0x170003D7 RID: 983
		// (get) Token: 0x0600119A RID: 4506 RVA: 0x000BCBB8 File Offset: 0x000BADB8
		private bool x08799943903cd34a
		{
			get
			{
				return Class154.x9843c083bd22e3f5;
			}
		}

		// Token: 0x170003D8 RID: 984
		// (get) Token: 0x0600119B RID: 4507 RVA: 0x000BCBD0 File Offset: 0x000BADD0
		protected CreateParams CreateParams
		{
			get
			{
				CreateParams createParams = base.CreateParams;
				if (this.x08799943903cd34a)
				{
					createParams.ExStyle |= 524288;
				}
				return createParams;
			}
		}

		// Token: 0x0600119C RID: 4508 RVA: 0x00009560 File Offset: 0x00007760
		public void method_0(Rectangle rectangle_0, Enum29 enum29_1)
		{
			base.Location = this.method_1(rectangle_0, base.Size, enum29_1);
			this.enum29_0 = enum29_1;
		}

		// Token: 0x0600119D RID: 4509 RVA: 0x000BCC04 File Offset: 0x000BAE04
		private Point method_1(Rectangle rectangle_0, Size size_1, Enum29 enum29_1)
		{
			Rectangle bounds = Screen.GetBounds(rectangle_0);
			bool flag = this.RightToLeft == RightToLeft.No;
			Rectangle rectangle = new Rectangle(rectangle_0.Location, size_1);
			bool flag2 = (enum29_1 & Enum29.flag_1) == Enum29.flag_4;
			bool flag3 = (enum29_1 & Enum29.flag_1) == Enum29.flag_1;
			if (flag2 || (enum29_1 & Enum29.flag_1) == Enum29.flag_3)
			{
				if (flag && !flag2)
				{
					if (rectangle_0.Right + size_1.Width > bounds.Right && rectangle_0.Left - size_1.Width >= bounds.X)
					{
						rectangle.X -= size_1.Width;
					}
					else
					{
						rectangle.X += rectangle_0.Width;
					}
				}
				else if (rectangle_0.Left - size_1.Width < bounds.X && rectangle_0.Right + size_1.Width <= bounds.Right)
				{
					rectangle.X += rectangle_0.Width;
				}
				else
				{
					rectangle.X -= size_1.Width;
				}
			}
			else
			{
				if (!flag)
				{
					rectangle.X -= size_1.Width - rectangle_0.Width;
				}
				if (flag3)
				{
					if (rectangle_0.Y - size_1.Height < bounds.Y && rectangle_0.Bottom + size_1.Height <= bounds.Bottom)
					{
						rectangle.Y += rectangle_0.Height;
					}
					else
					{
						rectangle.Y -= size_1.Height;
					}
				}
				else if (rectangle_0.Bottom + size_1.Height > bounds.Bottom && rectangle_0.Y - size_1.Height >= bounds.Y)
				{
					rectangle.Y -= size_1.Height;
				}
				else
				{
					rectangle.Y += rectangle_0.Height;
				}
			}
			if (rectangle.Right > bounds.Right)
			{
				rectangle.X = bounds.Right - rectangle.Width;
			}
			if (rectangle.X < bounds.X)
			{
				rectangle.X = bounds.X;
			}
			if (rectangle.Bottom > bounds.Bottom)
			{
				rectangle.Y = bounds.Bottom - rectangle.Height;
			}
			if (rectangle.Y < bounds.Y)
			{
				rectangle.Y = bounds.Y;
			}
			return rectangle.Location;
		}

		// Token: 0x170003D9 RID: 985
		// (get) Token: 0x0600119E RID: 4510 RVA: 0x000BCE98 File Offset: 0x000BB098
		public Class161 x8c3cc20aa74dd99c
		{
			get
			{
				Class161 result;
				if (!this.x7965faace5d79aa4)
				{
					result = null;
				}
				else
				{
					result = this.class161_0;
				}
				return result;
			}
		}

		// Token: 0x170003DA RID: 986
		// (get) Token: 0x0600119F RID: 4511 RVA: 0x000BCEBC File Offset: 0x000BB0BC
		public bool x7965faace5d79aa4
		{
			get
			{
				return this.bool_0;
			}
		}

		// Token: 0x170003DB RID: 987
		// (get) Token: 0x060011A0 RID: 4512 RVA: 0x000BCED4 File Offset: 0x000BB0D4
		public Enum29 x73979cef1002ed01
		{
			get
			{
				return this.enum29_0;
			}
		}

		// Token: 0x060011A1 RID: 4513 RVA: 0x000BCEEC File Offset: 0x000BB0EC
		public void method_2(VisualTipProvider visualTipProvider_1, Class161 class161_1, Rectangle rectangle_0, Enum29 enum29_1)
		{
			this.visualTipProvider_0 = visualTipProvider_1;
			this.class161_0 = class161_1;
			this.enum29_0 = enum29_1;
			this.RightToLeft = class161_1.RightToLeft;
			Class163 @class = visualTipProvider_1.Renderer.method_9(class161_1);
			base.Size = @class.method_2();
			base.Location = this.method_1(rectangle_0, base.Size, enum29_1);
			rectangle_0.Location -= new Size(base.Location);
			class161_1.method_5(rectangle_0);
			if (this.x08799943903cd34a)
			{
				this.class173_0.method_2();
				using (Bitmap bitmap = new Bitmap(base.Width, base.Height))
				{
					using (Graphics graphics = Graphics.FromImage(bitmap))
					{
						visualTipProvider_1.Renderer.method_12(new PaintEventArgs(graphics, new Rectangle(0, 0, base.Width, base.Height)), class161_1, @class);
						this.method_6(bitmap, (byte)(this.visualTipProvider_0.Opacity * 255.0));
					}
				}
			}
			this.method_3();
			if (!this.x08799943903cd34a)
			{
				base.Width = @class.WindowBounds.Width;
				base.Region = this.visualTipProvider_0.Renderer.method_13(class161_1, @class);
			}
		}

		// Token: 0x060011A2 RID: 4514 RVA: 0x0000957F File Offset: 0x0000777F
		private void method_3()
		{
			Form1.SetWindowPos(base.Handle, new IntPtr(-1), 0, 0, 0, 0, 83);
			this.bool_0 = true;
			base.Opacity = 1.0;
		}

		// Token: 0x060011A3 RID: 4515 RVA: 0x000BD04C File Offset: 0x000BB24C
		public void method_4()
		{
			if (this.x7965faace5d79aa4)
			{
				this.bool_0 = false;
				this.class161_0 = null;
				if ((this.x08799943903cd34a && this.visualTipProvider_0.Animation == Enum24.const_2) || (this.visualTipProvider_0.Animation == Enum24.const_0 && Class174.x6b254b18d1dfb65f))
				{
					this.double_0 = this.visualTipProvider_0.Opacity;
					this.class173_0.method_0();
				}
				else
				{
					Form1.ShowWindow(base.Handle, 0);
				}
				this.visualTipProvider_0.method_26(this);
			}
		}

		// Token: 0x060011A4 RID: 4516 RVA: 0x000BD0D4 File Offset: 0x000BB2D4
		private void method_5(object sender, EventArgs e)
		{
			if (this.class173_0.xda1d1aa1eef530a1)
			{
				Form1.ShowWindow(base.Handle, 0);
			}
			else
			{
				this.method_7((byte)((1.0 - this.class173_0.xd2f68ee6f47e9dfb) * (this.double_0 * 255.0)));
			}
		}

		// Token: 0x060011A5 RID: 4517 RVA: 0x000095B1 File Offset: 0x000077B1
		private void method_6(Bitmap bitmap_0, byte byte_2)
		{
			this.method_8();
			this.intptr_0 = bitmap_0.GetHbitmap(Color.FromArgb(0));
			this.size_0 = bitmap_0.Size;
			this.method_7(byte_2);
		}

		// Token: 0x060011A6 RID: 4518 RVA: 0x000BD12C File Offset: 0x000BB32C
		private void method_7(byte byte_2)
		{
			IntPtr dc = Form1.GetDC(IntPtr.Zero);
			IntPtr intPtr = Form1.CreateCompatibleDC(dc);
			IntPtr intptr_ = IntPtr.Zero;
			try
			{
				intptr_ = Form1.SelectObject(intPtr, this.intptr_0);
				Form1.Struct15 @struct = new Form1.Struct15(base.Left, base.Top);
				Form1.Struct16 struct2 = new Form1.Struct16(this.size_0.Width, this.size_0.Height);
				Form1.Struct15 struct3 = default(Form1.Struct15);
				Form1.Struct17 struct4 = default(Form1.Struct17);
				struct4.byte_0 = 0;
				struct4.byte_1 = 0;
				struct4.byte_2 = byte_2;
				struct4.byte_3 = 1;
				Form1.UpdateLayeredWindow(base.Handle, dc, ref @struct, ref struct2, intPtr, ref struct3, 0, ref struct4, 2);
			}
			finally
			{
				Form1.ReleaseDC(IntPtr.Zero, dc);
				Form1.SelectObject(intPtr, intptr_);
				Form1.DeleteDC(intPtr);
			}
		}

		// Token: 0x060011A7 RID: 4519 RVA: 0x000095E0 File Offset: 0x000077E0
		private void method_8()
		{
			if (this.intptr_0 != IntPtr.Zero)
			{
				Form1.DeleteObject(this.intptr_0);
				this.intptr_0 = IntPtr.Zero;
				this.size_0 = Size.Empty;
			}
		}

		// Token: 0x060011A8 RID: 4520 RVA: 0x000BD208 File Offset: 0x000BB408
		protected void OnPaint(PaintEventArgs e)
		{
			if (!this.x08799943903cd34a)
			{
				this.class164_0.method_0(e.Graphics, base.ClientRectangle);
				this.visualTipProvider_0.Renderer.method_12(new PaintEventArgs(this.class164_0.xbc626ed723e04991, e.ClipRectangle), this.x8c3cc20aa74dd99c, null);
				this.class164_0.method_3();
			}
		}

		// Token: 0x060011A9 RID: 4521 RVA: 0x00009618 File Offset: 0x00007818
		protected void WndProc(ref Message m)
		{
			if (m.Msg == 33)
			{
				this.method_4();
				m.Result = new IntPtr(4);
			}
			else
			{
				base.WndProc(ref m);
			}
		}

		// Token: 0x04000C1A RID: 3098
		private const int int_0 = 0;

		// Token: 0x04000C1B RID: 3099
		private const int int_1 = 1;

		// Token: 0x04000C1C RID: 3100
		private const int int_2 = 5;

		// Token: 0x04000C1D RID: 3101
		private const int int_3 = 4;

		// Token: 0x04000C1E RID: 3102
		private const int int_4 = 1;

		// Token: 0x04000C1F RID: 3103
		private const int int_5 = 2;

		// Token: 0x04000C20 RID: 3104
		private const int int_6 = 4;

		// Token: 0x04000C21 RID: 3105
		private const byte byte_0 = 0;

		// Token: 0x04000C22 RID: 3106
		private const byte byte_1 = 1;

		// Token: 0x04000C23 RID: 3107
		private Class161 class161_0;

		// Token: 0x04000C24 RID: 3108
		private bool bool_0;

		// Token: 0x04000C25 RID: 3109
		private Enum29 enum29_0;

		// Token: 0x04000C26 RID: 3110
		private Class164 class164_0 = new Class164();

		// Token: 0x04000C27 RID: 3111
		private VisualTipProvider visualTipProvider_0;

		// Token: 0x04000C28 RID: 3112
		private Class173 class173_0;

		// Token: 0x04000C29 RID: 3113
		private double double_0;

		// Token: 0x04000C2A RID: 3114
		private IntPtr intptr_0;

		// Token: 0x04000C2B RID: 3115
		private Size size_0;

		// Token: 0x0200017B RID: 379
		private struct Struct15
		{
			// Token: 0x060011AA RID: 4522 RVA: 0x00009641 File Offset: 0x00007841
			public Struct15(int x, int y)
			{
				this.x = x;
				this.y = y;
			}

			// Token: 0x04000C2C RID: 3116
			public int x;

			// Token: 0x04000C2D RID: 3117
			public int y;
		}

		// Token: 0x0200017C RID: 380
		private struct Struct16
		{
			// Token: 0x060011AB RID: 4523 RVA: 0x00009653 File Offset: 0x00007853
			public Struct16(int cx, int cy)
			{
				this.cx = cx;
				this.cy = cy;
			}

			// Token: 0x04000C2E RID: 3118
			public int cx;

			// Token: 0x04000C2F RID: 3119
			public int cy;
		}

		// Token: 0x0200017D RID: 381
		private struct Struct17
		{
			// Token: 0x04000C30 RID: 3120
			public byte byte_0;

			// Token: 0x04000C31 RID: 3121
			public byte byte_1;

			// Token: 0x04000C32 RID: 3122
			public byte byte_2;

			// Token: 0x04000C33 RID: 3123
			public byte byte_3;
		}
	}
}
