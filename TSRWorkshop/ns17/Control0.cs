using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using ns11;
using ns21;

namespace ns17
{
	// Token: 0x02000065 RID: 101
	internal sealed class Control0 : UserControl
	{
		// Token: 0x17000092 RID: 146
		// (get) Token: 0x060003D8 RID: 984 RVA: 0x000464EC File Offset: 0x000446EC
		// (set) Token: 0x060003D9 RID: 985 RVA: 0x00004184 File Offset: 0x00002384
		public Image Image
		{
			get
			{
				return this.image_0;
			}
			set
			{
				this.image_0 = value;
				this.method_6();
				this.method_4();
			}
		}

		// Token: 0x17000093 RID: 147
		// (get) Token: 0x060003DA RID: 986 RVA: 0x00046504 File Offset: 0x00044704
		// (set) Token: 0x060003DB RID: 987 RVA: 0x0000419B File Offset: 0x0000239B
		public Control0.Enum3 DefaultClickAction { get; set; }

		// Token: 0x17000094 RID: 148
		// (get) Token: 0x060003DC RID: 988 RVA: 0x0004651C File Offset: 0x0004471C
		// (set) Token: 0x060003DD RID: 989 RVA: 0x000041A6 File Offset: 0x000023A6
		public Control0.Enum4 DefaultDragAction { get; set; }

		// Token: 0x17000095 RID: 149
		// (get) Token: 0x060003DE RID: 990 RVA: 0x00046534 File Offset: 0x00044734
		// (set) Token: 0x060003DF RID: 991 RVA: 0x000041B1 File Offset: 0x000023B1
		public bool FitToView { get; set; }

		// Token: 0x17000096 RID: 150
		// (get) Token: 0x060003E0 RID: 992 RVA: 0x0004654C File Offset: 0x0004474C
		// (set) Token: 0x060003E1 RID: 993 RVA: 0x000041BC File Offset: 0x000023BC
		public float Brightness { get; set; }

		// Token: 0x17000097 RID: 151
		// (get) Token: 0x060003E2 RID: 994 RVA: 0x00046564 File Offset: 0x00044764
		// (set) Token: 0x060003E3 RID: 995 RVA: 0x000041C7 File Offset: 0x000023C7
		public float RedMult { get; set; }

		// Token: 0x17000098 RID: 152
		// (get) Token: 0x060003E4 RID: 996 RVA: 0x0004657C File Offset: 0x0004477C
		// (set) Token: 0x060003E5 RID: 997 RVA: 0x000041D2 File Offset: 0x000023D2
		public float GreenMult { get; set; }

		// Token: 0x17000099 RID: 153
		// (get) Token: 0x060003E6 RID: 998 RVA: 0x00046594 File Offset: 0x00044794
		// (set) Token: 0x060003E7 RID: 999 RVA: 0x000041DD File Offset: 0x000023DD
		public float BlueMult { get; set; }

		// Token: 0x1700009A RID: 154
		// (get) Token: 0x060003E8 RID: 1000 RVA: 0x000465AC File Offset: 0x000447AC
		// (set) Token: 0x060003E9 RID: 1001 RVA: 0x000041E8 File Offset: 0x000023E8
		public bool UseAlpha
		{
			get
			{
				return this.bool_0;
			}
			set
			{
				this.bool_0 = value;
				this.method_4();
				base.Invalidate(base.ClientRectangle, false);
			}
		}

		// Token: 0x1700009B RID: 155
		// (get) Token: 0x060003EA RID: 1002 RVA: 0x000465C4 File Offset: 0x000447C4
		// (set) Token: 0x060003EB RID: 1003 RVA: 0x00004206 File Offset: 0x00002406
		public bool UseRed
		{
			get
			{
				return this.bool_1;
			}
			set
			{
				this.bool_1 = value;
				this.method_4();
				base.Invalidate(base.ClientRectangle, false);
			}
		}

		// Token: 0x1700009C RID: 156
		// (get) Token: 0x060003EC RID: 1004 RVA: 0x000465DC File Offset: 0x000447DC
		// (set) Token: 0x060003ED RID: 1005 RVA: 0x00004224 File Offset: 0x00002424
		public bool UseGreen
		{
			get
			{
				return this.bool_2;
			}
			set
			{
				this.bool_2 = value;
				this.method_4();
				base.Invalidate(base.ClientRectangle, false);
			}
		}

		// Token: 0x1700009D RID: 157
		// (get) Token: 0x060003EE RID: 1006 RVA: 0x000465F4 File Offset: 0x000447F4
		// (set) Token: 0x060003EF RID: 1007 RVA: 0x00004242 File Offset: 0x00002442
		public bool UseBlue
		{
			get
			{
				return this.bool_3;
			}
			set
			{
				this.bool_3 = value;
				this.method_4();
				base.Invalidate(base.ClientRectangle, false);
			}
		}

		// Token: 0x060003F0 RID: 1008 RVA: 0x00004260 File Offset: 0x00002460
		public void method_0(bool bool_12, bool bool_13, bool bool_14, bool bool_15)
		{
			this.bool_1 = bool_12;
			this.bool_2 = bool_13;
			this.bool_3 = bool_14;
			this.bool_0 = bool_15;
			this.method_4();
			base.Invalidate(base.ClientRectangle, false);
		}

		// Token: 0x1700009E RID: 158
		// (get) Token: 0x060003F1 RID: 1009 RVA: 0x0004660C File Offset: 0x0004480C
		// (set) Token: 0x060003F2 RID: 1010 RVA: 0x00004294 File Offset: 0x00002494
		public Color BackgroundColor
		{
			get
			{
				return this.color_0;
			}
			set
			{
				this.color_0 = value;
				this.brush_0 = new SolidBrush(this.color_0);
			}
		}

		// Token: 0x1700009F RID: 159
		// (get) Token: 0x060003F3 RID: 1011 RVA: 0x00046624 File Offset: 0x00044824
		// (set) Token: 0x060003F4 RID: 1012 RVA: 0x000042B0 File Offset: 0x000024B0
		public float Zoom
		{
			get
			{
				return this.float_0;
			}
			set
			{
				this.float_0 = value;
				if (!this.bool_10)
				{
					this.method_4();
					base.Invalidate(base.ClientRectangle, false);
				}
				this.method_1(new Class51());
			}
		}

		// Token: 0x170000A0 RID: 160
		// (get) Token: 0x060003F5 RID: 1013 RVA: 0x0004663C File Offset: 0x0004483C
		// (set) Token: 0x060003F6 RID: 1014 RVA: 0x000042E1 File Offset: 0x000024E1
		public int DisplayWidth { get; private set; }

		// Token: 0x170000A1 RID: 161
		// (get) Token: 0x060003F7 RID: 1015 RVA: 0x00046654 File Offset: 0x00044854
		// (set) Token: 0x060003F8 RID: 1016 RVA: 0x000042EC File Offset: 0x000024EC
		public int DisplayHeight { get; private set; }

		// Token: 0x14000012 RID: 18
		// (add) Token: 0x060003F9 RID: 1017 RVA: 0x0004666C File Offset: 0x0004486C
		// (remove) Token: 0x060003FA RID: 1018 RVA: 0x000466A4 File Offset: 0x000448A4
		public event Delegate9 OnZoomChanged
		{
			add
			{
				Delegate9 @delegate = this.delegate9_0;
				Delegate9 delegate2;
				do
				{
					delegate2 = @delegate;
					Delegate9 value2 = (Delegate9)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Delegate9>(ref this.delegate9_0, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			remove
			{
				Delegate9 @delegate = this.delegate9_0;
				Delegate9 delegate2;
				do
				{
					delegate2 = @delegate;
					Delegate9 value2 = (Delegate9)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Delegate9>(ref this.delegate9_0, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		// Token: 0x060003FB RID: 1019 RVA: 0x000466DC File Offset: 0x000448DC
		private void method_1(Class51 class51_0)
		{
			Delegate9 @delegate = this.delegate9_0;
			if (@delegate != null)
			{
				@delegate(this, class51_0);
			}
		}

		// Token: 0x060003FC RID: 1020 RVA: 0x00046700 File Offset: 0x00044900
		public Control0()
		{
			this.method_8();
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint, true);
			base.SetStyle(ControlStyles.SupportsTransparentBackColor, false);
			base.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
			this.bufferedGraphicsContext_0 = BufferedGraphicsManager.Current;
			this.bool_5 = true;
			this.textureBrush_0 = new TextureBrush(Class143.alphacheck);
			this.textureBrush_0.WrapMode = WrapMode.Tile;
			base.MouseEnter += this.Control0_MouseEnter;
			base.MouseLeave += this.Control0_MouseLeave;
			base.MouseDown += this.Control0_MouseDown;
			base.MouseUp += this.Control0_MouseUp;
			base.MouseMove += this.Control0_MouseMove;
			base.KeyUp += this.Control0_KeyUp;
			base.KeyDown += this.Control0_KeyDown;
			this.cursor_1 = this.method_2(Class143.zoomin);
			this.cursor_2 = this.method_2(Class143.zoomout);
			this.cursor_3 = this.method_2(Class143.move);
			this.DefaultClickAction = Control0.Enum3.const_0;
			this.DefaultDragAction = Control0.Enum4.const_0;
			this.method_6();
			this.method_4();
		}

		// Token: 0x060003FD RID: 1021
		[DllImport("user32.dll")]
		private static extern IntPtr LoadCursorFromFile(string string_0);

		// Token: 0x060003FE RID: 1022 RVA: 0x00046880 File Offset: 0x00044A80
		private Cursor method_2(byte[] byte_0)
		{
			MemoryStream memoryStream = new MemoryStream(byte_0);
			Cursor result = new Cursor(memoryStream);
			memoryStream.Dispose();
			return result;
		}

		// Token: 0x060003FF RID: 1023 RVA: 0x000042F7 File Offset: 0x000024F7
		protected void OnPaint(PaintEventArgs e)
		{
			if (!this.bool_6 && this.bufferedGraphics_0 != null)
			{
				this.bufferedGraphics_0.Render(e.Graphics);
			}
		}

		// Token: 0x06000400 RID: 1024 RVA: 0x0000431C File Offset: 0x0000251C
		public void method_3()
		{
			this.method_4();
			base.Invalidate(base.ClientRectangle, false);
		}

		// Token: 0x06000401 RID: 1025 RVA: 0x000468A8 File Offset: 0x00044AA8
		private void method_4()
		{
			if (this.image_0 != null)
			{
				if (!this.FitToView)
				{
					base.Size = new Size((int)((float)this.image_0.Size.Width * this.float_0), (int)((float)this.image_0.Size.Height * this.float_0));
				}
				Rectangle clientRectangle = base.ClientRectangle;
				if (this.brush_0 != null)
				{
					this.bufferedGraphics_0.Graphics.FillRectangle(this.brush_0, clientRectangle);
				}
				int x = 0;
				int y = 0;
				int width = clientRectangle.Width;
				int height = clientRectangle.Height;
				int num = clientRectangle.Width;
				int num2 = clientRectangle.Height;
				if (this.FitToView && width > height)
				{
					if (this.image_0.Height > this.image_0.Width)
					{
						num2 = Math.Min(height, (int)((float)this.image_0.Height * ((float)num2 / (float)this.image_0.Height)));
						num = (int)((float)this.image_0.Width * ((float)num2 / (float)this.image_0.Height));
					}
					else if (this.image_0.Width > this.image_0.Height)
					{
						num = Math.Min(width, (int)((float)this.image_0.Width * ((float)num / (float)this.image_0.Width)));
						num2 = (int)((float)this.Image.Height * ((float)num / (float)this.Image.Width));
					}
					else
					{
						num = Math.Min(width, (int)((float)this.image_0.Width * ((float)num2 / (float)this.image_0.Height)));
						num2 = num;
					}
				}
				else if (this.FitToView && height >= width)
				{
					if (this.image_0.Height > this.image_0.Width)
					{
						num = Math.Min(width, (int)((float)this.image_0.Width * ((float)num2 / (float)this.image_0.Height)));
						num2 = (int)((float)this.image_0.Height * ((float)num / (float)this.image_0.Width));
					}
					else if (this.image_0.Width > this.image_0.Height)
					{
						num2 = Math.Min(height, (int)((float)this.image_0.Height * ((float)num2 / (float)this.image_0.Height)));
						num = (int)((float)num * ((float)this.image_0.Width / (float)this.image_0.Height));
					}
					else
					{
						num = Math.Min(width, (int)((float)this.image_0.Width * ((float)num2 / (float)this.image_0.Height)));
						num2 = num;
					}
				}
				ImageAttributes imageAttributes = null;
				if (!this.bool_0 || !this.bool_1 || !this.bool_2 || !this.bool_3)
				{
					float[][] array = new float[5][];
					float[][] array2 = array;
					int num3 = 0;
					float[] array3 = new float[5];
					array3[0] = (float)(this.bool_1 ? 1 : 0);
					array2[num3] = array3;
					float[][] array4 = array;
					int num4 = 1;
					float[] array5 = new float[5];
					array5[1] = (float)(this.bool_2 ? 1 : 0);
					array4[num4] = array5;
					float[][] array6 = array;
					int num5 = 2;
					float[] array7 = new float[5];
					array7[2] = (float)(this.bool_3 ? 1 : 0);
					array6[num5] = array7;
					float[][] array8 = array;
					int num6 = 3;
					float[] array9 = new float[5];
					array9[3] = 1f;
					array8[num6] = array9;
					array[4] = new float[]
					{
						0f,
						0f,
						0f,
						this.bool_0 ? 0f : 1f,
						1f
					};
					float[][] newColorMatrix = array;
					ColorMatrix newColorMatrix2 = new ColorMatrix(newColorMatrix);
					imageAttributes = new ImageAttributes();
					imageAttributes.SetColorMatrix(newColorMatrix2, ColorMatrixFlag.Default, ColorAdjustType.Default);
				}
				if (this.bool_4 && !this.bool_10)
				{
					this.bufferedGraphics_0.Graphics.FillRectangle(this.textureBrush_0, x, y, num, num2);
				}
				if (this.float_0 < 1f)
				{
					this.bufferedGraphics_0.Graphics.InterpolationMode = InterpolationMode.High;
				}
				else
				{
					this.bufferedGraphics_0.Graphics.InterpolationMode = InterpolationMode.NearestNeighbor;
				}
				this.bufferedGraphics_0.Graphics.DrawImage(this.image_0, new Rectangle(x, y, num, num2), 0, 0, this.image_0.Width, this.image_0.Height, GraphicsUnit.Pixel, imageAttributes);
				this.DisplayWidth = (int)((float)num * this.float_0);
				this.DisplayHeight = (int)((float)num2 * this.float_0);
			}
		}

		// Token: 0x06000402 RID: 1026 RVA: 0x00046D14 File Offset: 0x00044F14
		private float[][] method_5(float[][] float_5, float[][] float_6)
		{
			float[][] array = new float[5][];
			for (int i = 0; i < 5; i++)
			{
				array[i] = new float[5];
			}
			int num = 5;
			float[] array2 = new float[5];
			for (int j = 0; j < 5; j++)
			{
				for (int k = 0; k < 5; k++)
				{
					array2[k] = float_5[k][j];
				}
				for (int l = 0; l < 5; l++)
				{
					float[] array3 = float_6[l];
					float num2 = 0f;
					for (int m = 0; m < num; m++)
					{
						num2 += array3[m] * array2[m];
					}
					array[l][j] = num2;
				}
			}
			return array;
		}

		// Token: 0x06000403 RID: 1027 RVA: 0x00046DC0 File Offset: 0x00044FC0
		private void method_6()
		{
			if (this.bool_5 && !this.bool_6)
			{
				this.bufferedGraphicsContext_0.MaximumBuffer = new Size(base.Width, base.Height);
				if (this.bufferedGraphics_0 != null)
				{
					this.bufferedGraphics_0.Dispose();
				}
				this.bufferedGraphics_0 = this.bufferedGraphicsContext_0.Allocate(base.CreateGraphics(), new Rectangle(0, 0, Math.Max(base.Width, 1), Math.Max(base.Height, 1)));
				base.Invalidate();
			}
		}

		// Token: 0x06000404 RID: 1028 RVA: 0x00004333 File Offset: 0x00002533
		protected void OnResize(EventArgs e)
		{
			base.OnResize(e);
			this.method_6();
			this.method_4();
		}

		// Token: 0x06000405 RID: 1029 RVA: 0x0000434A File Offset: 0x0000254A
		private void Control0_MouseEnter(object sender, EventArgs e)
		{
			this.Cursor = this.cursor_0;
		}

		// Token: 0x06000406 RID: 1030 RVA: 0x0000435A File Offset: 0x0000255A
		private void Control0_MouseLeave(object sender, EventArgs e)
		{
			this.Cursor = Cursors.Arrow;
		}

		// Token: 0x06000407 RID: 1031 RVA: 0x00046E4C File Offset: 0x0004504C
		private void Control0_MouseDown(object sender, MouseEventArgs e)
		{
			this.bool_10 = true;
			this.int_2 = e.X;
			this.int_3 = e.Y;
			if (this.enum3_0 == Control0.Enum3.const_2)
			{
				this.Zoom = Math.Max(1f, this.float_0 -= 0.25f);
			}
			else if (this.enum3_0 == Control0.Enum3.const_1)
			{
				this.Zoom += 0.25f;
			}
		}

		// Token: 0x06000408 RID: 1032 RVA: 0x00046EC8 File Offset: 0x000450C8
		private void Control0_MouseUp(object sender, MouseEventArgs e)
		{
			this.bool_10 = false;
			if (base.Parent is Panel)
			{
				((Panel)base.Parent).AutoScrollPosition = this.point_0;
			}
			this.method_4();
			base.Invalidate(base.ClientRectangle, false);
		}

		// Token: 0x06000409 RID: 1033 RVA: 0x00046F14 File Offset: 0x00045114
		private void Control0_MouseMove(object sender, MouseEventArgs e)
		{
			if (this.enum4_0 == Control0.Enum4.const_1 && this.bool_10)
			{
				this.int_0 = e.X - this.int_2;
				this.int_1 = e.Y - this.int_3;
				this.point_0 = ((Panel)base.Parent).AutoScrollPosition;
				this.point_0.X = this.point_0.X + -this.int_0;
				this.point_0.Y = this.point_0.Y + -this.int_1;
				((Panel)base.Parent).AutoScrollPosition = new Point(-this.int_0, -this.int_1);
				this.int_2 = e.X;
				this.int_3 = e.Y;
			}
		}

		// Token: 0x0600040A RID: 1034 RVA: 0x00004369 File Offset: 0x00002569
		private void Control0_KeyDown(object sender, KeyEventArgs e)
		{
			this.bool_7 = e.Alt;
			this.bool_9 = e.Control;
			if ((e.KeyCode & Keys.Space) == Keys.Space)
			{
				this.bool_8 = true;
			}
			this.method_7();
		}

		// Token: 0x0600040B RID: 1035 RVA: 0x00046FE4 File Offset: 0x000451E4
		private void Control0_KeyUp(object sender, KeyEventArgs e)
		{
			this.bool_7 = e.Alt;
			this.bool_9 = e.Control;
			if ((e.KeyCode & Keys.Space) == Keys.Space)
			{
				this.bool_8 = false;
			}
			this.keys_0 = e.KeyData;
			this.method_7();
		}

		// Token: 0x0600040C RID: 1036 RVA: 0x00047034 File Offset: 0x00045234
		private void method_7()
		{
			if (this.bool_8 && this.bool_9 && this.bool_7)
			{
				this.Cursor = this.cursor_1;
				this.enum3_0 = Control0.Enum3.const_1;
				this.enum4_0 = Control0.Enum4.const_0;
			}
			else if (this.bool_8 && this.bool_9)
			{
				this.Cursor = this.cursor_2;
				this.enum3_0 = Control0.Enum3.const_2;
				this.enum4_0 = Control0.Enum4.const_0;
			}
			else if (this.bool_8)
			{
				this.Cursor = this.cursor_3;
				this.enum3_0 = Control0.Enum3.const_0;
				this.enum4_0 = Control0.Enum4.const_1;
			}
			else
			{
				this.Cursor = Cursors.Arrow;
				this.enum3_0 = this.DefaultClickAction;
				this.enum4_0 = this.DefaultDragAction;
			}
			this.cursor_0 = this.Cursor;
		}

		// Token: 0x0600040D RID: 1037 RVA: 0x0000439F File Offset: 0x0000259F
		protected void Dispose(bool disposing)
		{
			if (disposing && this.icontainer_0 != null)
			{
				this.icontainer_0.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x0600040E RID: 1038 RVA: 0x000043C0 File Offset: 0x000025C0
		private void method_8()
		{
			base.SuspendLayout();
			base.ResumeLayout(false);
		}

		// Token: 0x040003C6 RID: 966
		private Image image_0;

		// Token: 0x040003C7 RID: 967
		private Color color_0;

		// Token: 0x040003C8 RID: 968
		private BufferedGraphicsContext bufferedGraphicsContext_0;

		// Token: 0x040003C9 RID: 969
		private BufferedGraphics bufferedGraphics_0;

		// Token: 0x040003CA RID: 970
		private Control0.Enum3 enum3_0;

		// Token: 0x040003CB RID: 971
		private Control0.Enum4 enum4_0;

		// Token: 0x040003CC RID: 972
		private Cursor cursor_0 = Cursors.Arrow;

		// Token: 0x040003CD RID: 973
		private bool bool_0 = true;

		// Token: 0x040003CE RID: 974
		private bool bool_1 = true;

		// Token: 0x040003CF RID: 975
		private bool bool_2 = true;

		// Token: 0x040003D0 RID: 976
		private bool bool_3 = true;

		// Token: 0x040003D1 RID: 977
		private bool bool_4 = true;

		// Token: 0x040003D2 RID: 978
		private Brush brush_0;

		// Token: 0x040003D3 RID: 979
		private bool bool_5;

		// Token: 0x040003D4 RID: 980
		private TextureBrush textureBrush_0;

		// Token: 0x040003D5 RID: 981
		private float float_0 = 1f;

		// Token: 0x040003D6 RID: 982
		private int int_0;

		// Token: 0x040003D7 RID: 983
		private int int_1;

		// Token: 0x040003D8 RID: 984
		private bool bool_6;

		// Token: 0x040003D9 RID: 985
		private bool bool_7;

		// Token: 0x040003DA RID: 986
		private bool bool_8;

		// Token: 0x040003DB RID: 987
		private bool bool_9;

		// Token: 0x040003DC RID: 988
		private bool bool_10;

		// Token: 0x040003DD RID: 989
		private Cursor cursor_1;

		// Token: 0x040003DE RID: 990
		private Cursor cursor_2;

		// Token: 0x040003DF RID: 991
		private Cursor cursor_3;

		// Token: 0x040003E0 RID: 992
		private Delegate9 delegate9_0;

		// Token: 0x040003E1 RID: 993
		private int int_2;

		// Token: 0x040003E2 RID: 994
		private int int_3;

		// Token: 0x040003E3 RID: 995
		private Point point_0 = new Point(0, 0);

		// Token: 0x040003E4 RID: 996
		private Keys keys_0;

		// Token: 0x040003E5 RID: 997
		private IContainer icontainer_0;

		// Token: 0x040003E6 RID: 998
		[CompilerGenerated]
		private Control0.Enum3 enum3_1;

		// Token: 0x040003E7 RID: 999
		[CompilerGenerated]
		private Control0.Enum4 enum4_1;

		// Token: 0x040003E8 RID: 1000
		[CompilerGenerated]
		private bool bool_11;

		// Token: 0x040003E9 RID: 1001
		[CompilerGenerated]
		private float float_1;

		// Token: 0x040003EA RID: 1002
		[CompilerGenerated]
		private float float_2;

		// Token: 0x040003EB RID: 1003
		[CompilerGenerated]
		private float float_3;

		// Token: 0x040003EC RID: 1004
		[CompilerGenerated]
		private float float_4;

		// Token: 0x040003ED RID: 1005
		[CompilerGenerated]
		private int int_4;

		// Token: 0x040003EE RID: 1006
		[CompilerGenerated]
		private int int_5;

		// Token: 0x02000066 RID: 102
		public enum Enum3
		{
			// Token: 0x040003F0 RID: 1008
			const_0,
			// Token: 0x040003F1 RID: 1009
			const_1,
			// Token: 0x040003F2 RID: 1010
			const_2
		}

		// Token: 0x02000067 RID: 103
		public enum Enum4
		{
			// Token: 0x040003F4 RID: 1012
			const_0,
			// Token: 0x040003F5 RID: 1013
			const_1
		}
	}
}
