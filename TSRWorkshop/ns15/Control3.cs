using System;
using System.ComponentModel;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using ns0;
using ns16;
using ns2;
using VisualHint.SmartPropertyGrid;

namespace ns15
{
	// Token: 0x0200007C RID: 124
	[ToolboxItem(false)]
	internal sealed class Control3 : Control
	{
		// Token: 0x14000017 RID: 23
		// (add) Token: 0x0600049F RID: 1183 RVA: 0x0004B3EC File Offset: 0x000495EC
		// (remove) Token: 0x060004A0 RID: 1184 RVA: 0x0004B424 File Offset: 0x00049624
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

		// Token: 0x170000BC RID: 188
		// (get) Token: 0x060004A1 RID: 1185 RVA: 0x0004B45C File Offset: 0x0004965C
		// (set) Token: 0x060004A2 RID: 1186 RVA: 0x00004757 File Offset: 0x00002957
		public Orientation Orientation
		{
			get
			{
				return this.orientation_0;
			}
			set
			{
				this.orientation_0 = value;
			}
		}

		// Token: 0x170000BD RID: 189
		// (get) Token: 0x060004A3 RID: 1187 RVA: 0x0004B474 File Offset: 0x00049674
		// (set) Token: 0x060004A4 RID: 1188 RVA: 0x00004762 File Offset: 0x00002962
		public string Label
		{
			get
			{
				return this.string_0;
			}
			set
			{
				this.string_0 = value;
			}
		}

		// Token: 0x170000BE RID: 190
		// (get) Token: 0x060004A6 RID: 1190 RVA: 0x0004B48C File Offset: 0x0004968C
		// (set) Token: 0x060004A5 RID: 1189 RVA: 0x0000476D File Offset: 0x0000296D
		public Interface6 Tracker
		{
			get
			{
				return this.interface6_0;
			}
			set
			{
				if (value == null && value.GetType() != typeof(Class54))
				{
					this.interface6_0 = new Class54();
				}
				else if (this.interface6_0.GetType() != value.GetType())
				{
					this.interface6_0 = value;
				}
			}
		}

		// Token: 0x170000BF RID: 191
		// (get) Token: 0x060004A8 RID: 1192 RVA: 0x0004B4A4 File Offset: 0x000496A4
		// (set) Token: 0x060004A7 RID: 1191 RVA: 0x000047AD File Offset: 0x000029AD
		public int Minimum
		{
			get
			{
				return this.int_0;
			}
			set
			{
				this.int_0 = value;
			}
		}

		// Token: 0x170000C0 RID: 192
		// (get) Token: 0x060004AA RID: 1194 RVA: 0x0004B4BC File Offset: 0x000496BC
		// (set) Token: 0x060004A9 RID: 1193 RVA: 0x000047B8 File Offset: 0x000029B8
		public int Maximum
		{
			get
			{
				return this.int_1;
			}
			set
			{
				this.int_1 = value;
			}
		}

		// Token: 0x170000C1 RID: 193
		// (set) Token: 0x060004AB RID: 1195 RVA: 0x000047C3 File Offset: 0x000029C3
		public bool ReversedOrigin
		{
			set
			{
				this.bool_1 = value;
			}
		}

		// Token: 0x170000C2 RID: 194
		// (get) Token: 0x060004AD RID: 1197 RVA: 0x0004B550 File Offset: 0x00049750
		// (set) Token: 0x060004AC RID: 1196 RVA: 0x0004B4D4 File Offset: 0x000496D4
		public int Value
		{
			get
			{
				return this.int_2;
			}
			set
			{
				int num = this.int_2;
				if (value >= this.int_0 && value <= this.int_1)
				{
					this.int_2 = value;
				}
				else if (value < this.int_0)
				{
					this.int_2 = this.int_0;
				}
				else
				{
					this.int_2 = this.int_1;
				}
				if (this.eventHandler_0 != null && num != this.int_2)
				{
					this.eventHandler_0(this, EventArgs.Empty);
				}
				base.Invalidate();
			}
		}

		// Token: 0x170000C3 RID: 195
		// (get) Token: 0x060004AF RID: 1199 RVA: 0x0004B568 File Offset: 0x00049768
		// (set) Token: 0x060004AE RID: 1198 RVA: 0x000047CE File Offset: 0x000029CE
		public int SmallChange
		{
			get
			{
				return this.int_3;
			}
			set
			{
				this.int_3 = value;
			}
		}

		// Token: 0x170000C4 RID: 196
		// (get) Token: 0x060004B1 RID: 1201 RVA: 0x0004B580 File Offset: 0x00049780
		// (set) Token: 0x060004B0 RID: 1200 RVA: 0x000047D9 File Offset: 0x000029D9
		public int LargeChange
		{
			get
			{
				return this.int_4;
			}
			set
			{
				this.int_4 = value;
			}
		}

		// Token: 0x170000C5 RID: 197
		// (get) Token: 0x060004B3 RID: 1203 RVA: 0x0004B598 File Offset: 0x00049798
		// (set) Token: 0x060004B2 RID: 1202 RVA: 0x000047E4 File Offset: 0x000029E4
		public Win32Calls.RECT Margins
		{
			get
			{
				return this.rect_0;
			}
			set
			{
				this.rect_0 = value;
			}
		}

		// Token: 0x060004B4 RID: 1204 RVA: 0x0004B5B0 File Offset: 0x000497B0
		public Control3(Interface5 implementer)
		{
			this.implementer = implementer;
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.Opaque | ControlStyles.Selectable | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
		}

		// Token: 0x060004B5 RID: 1205 RVA: 0x0004B608 File Offset: 0x00049808
		protected void OnPaint(PaintEventArgs e)
		{
			Rectangle clientRectangle = base.ClientRectangle;
			using (Brush brush = new SolidBrush(this.BackColor))
			{
				e.Graphics.FillRectangle(brush, clientRectangle);
			}
			if (this.orientation_0 == Orientation.Horizontal)
			{
				using (Font font = new Font("Tahoma", 8f))
				{
					Size size = Size.Round(e.Graphics.MeasureString(this.string_0, font));
					Rectangle r = clientRectangle;
					r.Width = size.Width;
					r.Y = (int)((double)(this.ContentRect.Top + this.ContentRect.Bottom - size.Height) / 2.0);
					r.Height = size.Height;
					StringFormat stringFormat = (StringFormat)StringFormat.GenericDefault.Clone();
					stringFormat.LineAlignment = StringAlignment.Center;
					e.Graphics.DrawString(this.string_0, font, SystemBrushes.WindowText, r, stringFormat);
				}
			}
			Rectangle contentRect = this.ContentRect;
			contentRect.Inflate(1, 1);
			e.Graphics.DrawLine(SystemPens.ControlDarkDark, new Point(contentRect.Left, contentRect.Bottom - 2), contentRect.Location);
			e.Graphics.DrawLine(SystemPens.ControlDarkDark, contentRect.Location, new Point(contentRect.Right - 2, contentRect.Top));
			e.Graphics.DrawLine(SystemPens.ControlLightLight, new Point(contentRect.Left, contentRect.Bottom - 1), new Point(contentRect.Right - 1, contentRect.Bottom - 1));
			e.Graphics.DrawLine(SystemPens.ControlLightLight, new Point(contentRect.Right - 1, contentRect.Bottom - 1), new Point(contentRect.Right - 1, contentRect.Top));
			if (this.Focused)
			{
				contentRect.Inflate(1, 1);
				ControlPaint.DrawFocusRectangle(e.Graphics, contentRect);
			}
			this.implementer.imethod_0(this, e.Graphics, this.ContentRect);
			int num;
			int num2;
			int num3;
			this.method_0(out num, out num2, out num3);
			if (this.orientation_0 == Orientation.Horizontal)
			{
				this.interface6_0.imethod_0(e.Graphics, this.int_2, new Point(num3, this.ContentRect.Top), new Point(num3, this.ContentRect.Bottom), clientRectangle);
			}
			else if (this.orientation_0 == Orientation.Vertical)
			{
				this.interface6_0.imethod_0(e.Graphics, this.int_2, new Point(this.ContentRect.Left, num3), new Point(this.ContentRect.Right, num3), clientRectangle);
			}
		}

		// Token: 0x170000C6 RID: 198
		// (get) Token: 0x060004B6 RID: 1206 RVA: 0x0004B8F0 File Offset: 0x00049AF0
		protected Rectangle ContentRect
		{
			get
			{
				if (this.rectangle_0.IsEmpty)
				{
					Rectangle clientRectangle = base.ClientRectangle;
					Rectangle rectangle = default(Rectangle);
					rectangle.X = this.rect_0.Left;
					rectangle.Y = this.rect_0.Top;
					rectangle.Width = clientRectangle.Right - this.rect_0.Right - rectangle.Left;
					rectangle.Height = clientRectangle.Bottom - this.rect_0.Bottom - rectangle.Top;
					this.rectangle_0 = rectangle;
					this.rectangle_0.Inflate(-1, -1);
				}
				return this.rectangle_0;
			}
		}

		// Token: 0x060004B7 RID: 1207 RVA: 0x0004B9A4 File Offset: 0x00049BA4
		protected void method_0(out int int_5, out int int_6, out int int_7)
		{
			int_5 = this.ContentRect.Left;
			int_6 = this.ContentRect.Right;
			if (this.bool_1)
			{
				if (this.orientation_0 == Orientation.Horizontal)
				{
					int_7 = this.ContentRect.Right - (int)Math.Round((double)this.ContentRect.Width * (double)(this.int_2 - this.int_0) / (double)this.int_1);
				}
				else
				{
					int_7 = this.ContentRect.Bottom - (int)Math.Round((double)this.ContentRect.Height * (double)(this.int_2 - this.int_0) / (double)this.int_1);
				}
			}
			else if (this.orientation_0 == Orientation.Horizontal)
			{
				int_7 = this.ContentRect.Left + (int)Math.Round((double)this.ContentRect.Width * (double)(this.int_2 - this.int_0) / (double)this.int_1);
			}
			else
			{
				int_7 = this.ContentRect.Top + (int)Math.Round((double)this.ContentRect.Height * (double)(this.int_2 - this.int_0) / (double)this.int_1);
			}
		}

		// Token: 0x060004B8 RID: 1208 RVA: 0x0004BAF4 File Offset: 0x00049CF4
		protected int method_1(int int_5)
		{
			if (this.bool_1)
			{
				if (this.orientation_0 == Orientation.Horizontal)
				{
					return this.int_0 + (int)Math.Round((double)(this.ContentRect.Right - int_5) / (double)this.ContentRect.Width * (double)this.int_1);
				}
				if (this.orientation_0 == Orientation.Vertical)
				{
					return this.int_0 + (int)Math.Round((double)(this.ContentRect.Bottom - int_5) / (double)this.ContentRect.Height * (double)this.int_1);
				}
			}
			else
			{
				if (this.orientation_0 == Orientation.Horizontal)
				{
					return this.int_0 + (int)Math.Round((double)(int_5 - this.ContentRect.Left) / (double)this.ContentRect.Width * (double)this.int_1);
				}
				if (this.orientation_0 == Orientation.Vertical)
				{
					return this.int_0 + (int)Math.Round((double)(int_5 - this.ContentRect.Top) / (double)this.ContentRect.Height * (double)this.int_1);
				}
			}
			return this.int_0;
		}

		// Token: 0x060004B9 RID: 1209 RVA: 0x0004BC30 File Offset: 0x00049E30
		protected void OnMouseDown(MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				if (this.orientation_0 == Orientation.Horizontal)
				{
					if (e.X >= this.ContentRect.Left && e.X <= this.ContentRect.Right)
					{
						base.Focus();
						this.Value = this.method_1(e.X);
						this.bool_0 = true;
					}
				}
				else if (this.orientation_0 == Orientation.Vertical && e.Y >= this.ContentRect.Top && e.Y <= this.ContentRect.Bottom)
				{
					base.Focus();
					this.Value = this.method_1(e.Y);
					this.bool_0 = true;
				}
			}
			base.OnMouseDown(e);
		}

		// Token: 0x060004BA RID: 1210 RVA: 0x0004BD04 File Offset: 0x00049F04
		protected void OnMouseMove(MouseEventArgs e)
		{
			if (this.bool_0)
			{
				if (this.orientation_0 == Orientation.Horizontal)
				{
					int num = e.X;
					if (num < this.ContentRect.Left)
					{
						num = this.ContentRect.Left;
					}
					else if (num > this.ContentRect.Right)
					{
						num = this.ContentRect.Right;
					}
					this.Value = this.method_1(num);
				}
				else if (this.orientation_0 == Orientation.Vertical)
				{
					int num2 = e.Y;
					if (num2 < this.ContentRect.Top)
					{
						num2 = this.ContentRect.Top;
					}
					else if (num2 > this.ContentRect.Bottom)
					{
						num2 = this.ContentRect.Bottom;
					}
					this.Value = this.method_1(num2);
				}
			}
			base.OnMouseMove(e);
		}

		// Token: 0x060004BB RID: 1211 RVA: 0x000047EF File Offset: 0x000029EF
		protected void OnMouseUp(MouseEventArgs e)
		{
			if (this.bool_0)
			{
				this.bool_0 = false;
			}
			base.OnMouseUp(e);
		}

		// Token: 0x060004BC RID: 1212 RVA: 0x0004BDEC File Offset: 0x00049FEC
		protected bool IsInputKey(Keys keyData)
		{
			if (keyData != Keys.Left && keyData != Keys.Right && keyData != Keys.Up)
			{
				if (keyData != Keys.Down)
				{
					return base.IsInputKey(keyData);
				}
			}
			return true;
		}

		// Token: 0x060004BD RID: 1213 RVA: 0x0004BE20 File Offset: 0x0004A020
		protected void OnKeyDown(KeyEventArgs e)
		{
			if (e.KeyData == Keys.Left)
			{
				this.Value -= this.SmallChange;
			}
			else if (e.KeyData == Keys.Down)
			{
				this.Value -= this.SmallChange;
			}
			else if (e.KeyData == Keys.Right)
			{
				this.Value += this.SmallChange;
			}
			else if (e.KeyData == Keys.Up)
			{
				this.Value += this.SmallChange;
			}
			else if (e.KeyData == Keys.Home)
			{
				this.Value = this.Minimum;
			}
			else if (e.KeyData == Keys.End)
			{
				this.Value = this.Maximum;
			}
			else if (e.KeyData == Keys.Prior)
			{
				this.Value += this.LargeChange;
			}
			else if (e.KeyData == Keys.Next)
			{
				this.Value -= this.LargeChange;
			}
			base.OnKeyDown(e);
		}

		// Token: 0x060004BE RID: 1214 RVA: 0x00004809 File Offset: 0x00002A09
		protected void OnGotFocus(EventArgs e)
		{
			base.Invalidate();
			base.OnGotFocus(e);
		}

		// Token: 0x060004BF RID: 1215 RVA: 0x0000481A File Offset: 0x00002A1A
		protected void OnLostFocus(EventArgs e)
		{
			base.Invalidate();
			base.OnLostFocus(e);
		}

		// Token: 0x0400042B RID: 1067
		private EventHandler eventHandler_0;

		// Token: 0x0400042C RID: 1068
		private bool bool_0;

		// Token: 0x0400042D RID: 1069
		private Orientation orientation_0;

		// Token: 0x0400042E RID: 1070
		private string string_0;

		// Token: 0x0400042F RID: 1071
		private Interface6 interface6_0 = new Class54();

		// Token: 0x04000430 RID: 1072
		private Interface5 implementer;

		// Token: 0x04000431 RID: 1073
		private int int_0;

		// Token: 0x04000432 RID: 1074
		private int int_1 = 255;

		// Token: 0x04000433 RID: 1075
		private bool bool_1;

		// Token: 0x04000434 RID: 1076
		private int int_2;

		// Token: 0x04000435 RID: 1077
		private int int_3 = 1;

		// Token: 0x04000436 RID: 1078
		private int int_4 = 10;

		// Token: 0x04000437 RID: 1079
		private Rectangle rectangle_0 = Rectangle.Empty;

		// Token: 0x04000438 RID: 1080
		private Win32Calls.RECT rect_0;

		// Token: 0x0200007D RID: 125
		public enum Enum7
		{
			// Token: 0x0400043A RID: 1082
			const_0,
			// Token: 0x0400043B RID: 1083
			const_1
		}
	}
}
