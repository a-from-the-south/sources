using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using System.Threading;
using System.Windows.Forms;
using VisualHint.SmartPropertyGrid;

namespace ns15
{
	// Token: 0x0200007E RID: 126
	[ToolboxItem(false)]
	internal sealed class Control4 : Control
	{
		// Token: 0x060004C0 RID: 1216 RVA: 0x0000482B File Offset: 0x00002A2B
		public Control4()
		{
			base.SetStyle(ControlStyles.Opaque | ControlStyles.OptimizedDoubleBuffer, true);
			base.UpdateStyles();
		}

		// Token: 0x14000018 RID: 24
		// (add) Token: 0x060004C1 RID: 1217 RVA: 0x0004BF28 File Offset: 0x0004A128
		// (remove) Token: 0x060004C2 RID: 1218 RVA: 0x0004BF60 File Offset: 0x0004A160
		public event EventHandler ValueChanged
		{
			add
			{
				EventHandler eventHandler = this.eventHandler_0;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange<EventHandler>(ref this.eventHandler_0, value2, eventHandler2);
				}
				while (eventHandler != eventHandler2);
			}
			remove
			{
				EventHandler eventHandler = this.eventHandler_0;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange<EventHandler>(ref this.eventHandler_0, value2, eventHandler2);
				}
				while (eventHandler != eventHandler2);
			}
		}

		// Token: 0x170000C7 RID: 199
		// (set) Token: 0x060004C3 RID: 1219 RVA: 0x0004BF98 File Offset: 0x0004A198
		public double Hue
		{
			set
			{
				this.double_0 = value;
				this.color_0 = Color.FromArgb((int)this.color_0.A, ColorUtils.HsbToRgb(this.double_0, this.double_1, this.double_2));
				this.bool_1 = true;
				base.Invalidate();
			}
		}

		// Token: 0x170000C8 RID: 200
		// (get) Token: 0x060004C5 RID: 1221 RVA: 0x0004C044 File Offset: 0x0004A244
		// (set) Token: 0x060004C4 RID: 1220 RVA: 0x0004BFE8 File Offset: 0x0004A1E8
		public Color Color
		{
			get
			{
				return this.color_0;
			}
			set
			{
				if (this.color_0 == Color.Empty)
				{
					this.color_0 = value;
					ColorUtils.RgbToHsb(this.color_0, out this.double_0, out this.double_1, out this.double_2);
				}
				else
				{
					this.color_0 = value;
				}
				this.bool_1 = true;
				base.Invalidate();
			}
		}

		// Token: 0x060004C6 RID: 1222 RVA: 0x00004859 File Offset: 0x00002A59
		public void ResetColor()
		{
			this.color_0 = Color.Empty;
		}

		// Token: 0x060004C7 RID: 1223 RVA: 0x0004C05C File Offset: 0x0004A25C
		protected void OnPaint(PaintEventArgs e)
		{
			Rectangle clientRectangle = base.ClientRectangle;
			if (this.bool_1)
			{
				this.image_0 = new Bitmap(clientRectangle.Width, clientRectangle.Height, e.Graphics);
				this.bool_1 = false;
				Graphics graphics = Graphics.FromImage(this.image_0);
				Color color = ColorUtils.HsbToRgb(this.double_0, 100.0, 100.0);
				double num = (double)(byte.MaxValue - color.R) / (double)clientRectangle.Width;
				double num2 = (double)(byte.MaxValue - color.G) / (double)clientRectangle.Width;
				double num3 = (double)(byte.MaxValue - color.B) / (double)clientRectangle.Width;
				double num4 = 255.0;
				double num5 = 255.0;
				double num6 = 255.0;
				for (int i = clientRectangle.Left; i <= clientRectangle.Right; i++)
				{
					using (LinearGradientBrush linearGradientBrush = new LinearGradientBrush(new Rectangle(i, clientRectangle.Top, 1, clientRectangle.Height + 1), Color.FromArgb((int)Math.Round(num4), (int)Math.Round(num5), (int)Math.Round(num6)), Color.FromArgb(0, 0, 0), 90f, false))
					{
						graphics.FillRectangle(linearGradientBrush, new Rectangle(i, clientRectangle.Top, 1, clientRectangle.Height + 1));
					}
					num4 -= num;
					num5 -= num2;
					num6 -= num3;
				}
				graphics.Dispose();
			}
			e.Graphics.DrawImage(this.image_0, 0, 0);
			int num7 = (int)Math.Round(this.double_1 / 100.0 * (double)clientRectangle.Width);
			int num8 = clientRectangle.Height - (int)Math.Round(this.double_2 / 100.0 * (double)clientRectangle.Height);
			Rectangle rect = new Rectangle(num7 - 5, num8 - 5, 10, 10);
			using (Pen pen = new Pen(Color.White))
			{
				e.Graphics.DrawEllipse(pen, rect);
			}
			rect.Inflate(1, 1);
			using (Pen pen2 = new Pen(Color.Black))
			{
				e.Graphics.DrawEllipse(pen2, rect);
			}
		}

		// Token: 0x060004C8 RID: 1224 RVA: 0x0004C2E0 File Offset: 0x0004A4E0
		[SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.UnmanagedCode)]
		protected void WndProc(ref Message m)
		{
			if (m.Msg == 131)
			{
				Win32Calls.NCCALCSIZE_PARAMS nccalcsize_PARAMS = (Win32Calls.NCCALCSIZE_PARAMS)Marshal.PtrToStructure(m.LParam, typeof(Win32Calls.NCCALCSIZE_PARAMS));
				nccalcsize_PARAMS.rgrc0.Left = nccalcsize_PARAMS.rgrc0.Left + 2;
				nccalcsize_PARAMS.rgrc0.Right = nccalcsize_PARAMS.rgrc0.Right - 2;
				nccalcsize_PARAMS.rgrc0.Top = nccalcsize_PARAMS.rgrc0.Top + 2;
				nccalcsize_PARAMS.rgrc0.Bottom = nccalcsize_PARAMS.rgrc0.Bottom - 2;
				Marshal.StructureToPtr(nccalcsize_PARAMS, m.LParam, false);
			}
			else if (m.Msg == 133)
			{
				IntPtr windowDC = Win32Calls.GetWindowDC(m.HWnd);
				Graphics graphics = Graphics.FromHdc(windowDC);
				Win32Calls.RECT rect = default(Win32Calls.RECT);
				Win32Calls.GetWindowRect(m.HWnd, ref rect);
				Rectangle rectangle = new Rectangle(0, 0, rect.Right - rect.Left, rect.Bottom - rect.Top);
				if (this.Focused)
				{
					ControlPaint.DrawFocusRectangle(graphics, rectangle);
				}
				else
				{
					Rectangle rect2 = rectangle;
					rect2.Width--;
					rect2.Height--;
					using (Pen pen = new Pen(base.Parent.BackColor))
					{
						graphics.DrawRectangle(pen, rect2);
					}
				}
				rectangle.Inflate(-1, -1);
				rectangle.Width--;
				rectangle.Height--;
				graphics.DrawLine(SystemPens.ControlDarkDark, new Point(rectangle.Left, rectangle.Bottom), rectangle.Location);
				graphics.DrawLine(SystemPens.ControlDarkDark, rectangle.Location, new Point(rectangle.Right, rectangle.Top));
				graphics.DrawLine(SystemPens.ControlLightLight, new Point(rectangle.Left, rectangle.Bottom), new Point(rectangle.Right, rectangle.Bottom));
				graphics.DrawLine(SystemPens.ControlLightLight, new Point(rectangle.Right, rectangle.Bottom), new Point(rectangle.Right, rectangle.Top));
				Win32Calls.ReleaseDC(m.HWnd, windowDC);
				graphics.Dispose();
				return;
			}
			base.WndProc(ref m);
		}

		// Token: 0x060004C9 RID: 1225 RVA: 0x00004868 File Offset: 0x00002A68
		protected void OnGotFocus(EventArgs e)
		{
			Win32Calls.RedrawWindow(base.Handle, IntPtr.Zero, IntPtr.Zero, 1025);
			base.OnGotFocus(e);
		}

		// Token: 0x060004CA RID: 1226 RVA: 0x0000488E File Offset: 0x00002A8E
		protected void OnLostFocus(EventArgs e)
		{
			Win32Calls.RedrawWindow(base.Handle, IntPtr.Zero, IntPtr.Zero, 1025);
			base.OnLostFocus(e);
		}

		// Token: 0x060004CB RID: 1227 RVA: 0x000048B4 File Offset: 0x00002AB4
		protected void OnMouseDown(MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				base.Focus();
				this.method_0(new Point(e.X, e.Y));
				this.bool_0 = true;
			}
			base.OnMouseDown(e);
		}

		// Token: 0x060004CC RID: 1228 RVA: 0x000048F1 File Offset: 0x00002AF1
		protected void OnMouseMove(MouseEventArgs e)
		{
			if (this.bool_0)
			{
				this.method_0(new Point(e.X, e.Y));
			}
			base.OnMouseMove(e);
		}

		// Token: 0x060004CD RID: 1229 RVA: 0x0004C540 File Offset: 0x0004A740
		protected void method_0(Point point_0)
		{
			Rectangle clientRectangle = base.ClientRectangle;
			if (point_0.X < 0)
			{
				point_0.X = 0;
			}
			if (point_0.Y < 0)
			{
				point_0.Y = 0;
			}
			if (point_0.X > clientRectangle.Right - 1)
			{
				point_0.X = clientRectangle.Right - 1;
			}
			if (point_0.Y > clientRectangle.Bottom - 1)
			{
				point_0.Y = clientRectangle.Bottom - 1;
			}
			Rectangle clientRectangle2 = base.ClientRectangle;
			this.double_1 = (double)point_0.X * 100.0 / (double)clientRectangle2.Width;
			this.double_2 = (double)(clientRectangle2.Height - point_0.Y) * 100.0 / (double)clientRectangle2.Height;
			Color left = Color.FromArgb((int)this.color_0.A, ColorUtils.HsbToRgb(this.double_0, this.double_1, this.double_2));
			base.Invalidate();
			if (left != this.color_0)
			{
				this.color_0 = left;
				if (this.eventHandler_0 != null)
				{
					this.eventHandler_0(this, EventArgs.Empty);
				}
			}
		}

		// Token: 0x060004CE RID: 1230 RVA: 0x0000491B File Offset: 0x00002B1B
		protected void OnMouseUp(MouseEventArgs e)
		{
			if (this.bool_0)
			{
				this.bool_0 = false;
			}
			base.OnMouseUp(e);
		}

		// Token: 0x060004CF RID: 1231 RVA: 0x0004C66C File Offset: 0x0004A86C
		protected bool ProcessDialogKey(Keys keyData)
		{
			Keys keys = keyData & Keys.KeyCode;
			bool result;
			if (keys == Keys.Down)
			{
				Rectangle clientRectangle = base.ClientRectangle;
				int x = (int)Math.Round(this.double_1 / 100.0 * (double)clientRectangle.Width);
				int y = clientRectangle.Height - (int)Math.Round(this.double_2 / 100.0 * (double)clientRectangle.Height) + 1;
				this.method_0(new Point(x, y));
				result = true;
			}
			else if (keys == Keys.Up)
			{
				Rectangle clientRectangle2 = base.ClientRectangle;
				int x2 = (int)Math.Round(this.double_1 / 100.0 * (double)clientRectangle2.Width);
				int y2 = clientRectangle2.Height - (int)Math.Round(this.double_2 / 100.0 * (double)clientRectangle2.Height) - 1;
				this.method_0(new Point(x2, y2));
				result = true;
			}
			else if (keys == Keys.Right)
			{
				Rectangle clientRectangle3 = base.ClientRectangle;
				int x3 = (int)Math.Round(this.double_1 / 100.0 * (double)clientRectangle3.Width) + 1;
				int y3 = clientRectangle3.Height - (int)Math.Round(this.double_2 / 100.0 * (double)clientRectangle3.Height);
				this.method_0(new Point(x3, y3));
				result = true;
			}
			else if (keys == Keys.Left)
			{
				Rectangle clientRectangle4 = base.ClientRectangle;
				int x4 = (int)Math.Round(this.double_1 / 100.0 * (double)clientRectangle4.Width) - 1;
				int y4 = clientRectangle4.Height - (int)Math.Round(this.double_2 / 100.0 * (double)clientRectangle4.Height);
				this.method_0(new Point(x4, y4));
				result = true;
			}
			else
			{
				result = base.ProcessDialogKey(keyData);
			}
			return result;
		}

		// Token: 0x0400043C RID: 1084
		private EventHandler eventHandler_0;

		// Token: 0x0400043D RID: 1085
		private double double_0;

		// Token: 0x0400043E RID: 1086
		private double double_1;

		// Token: 0x0400043F RID: 1087
		private double double_2;

		// Token: 0x04000440 RID: 1088
		private Color color_0 = Color.Empty;

		// Token: 0x04000441 RID: 1089
		private bool bool_0;

		// Token: 0x04000442 RID: 1090
		private bool bool_1 = true;

		// Token: 0x04000443 RID: 1091
		private Image image_0;
	}
}
