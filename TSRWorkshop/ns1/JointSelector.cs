using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using ns10;
using ns11;
using ns14;
using ns18;
using ns6;
using SlimDX;
using SlimDX.Direct3D9;

namespace ns1
{
	// Token: 0x02000043 RID: 67
	internal sealed partial class JointSelector : Form, Interface2
	{
		// Token: 0x06000278 RID: 632 RVA: 0x0002EFD0 File Offset: 0x0002D1D0
		public JointSelector()
		{
			this.InitializeComponent();
			Device device = Class140.smethod_0().Device;
			this.struct6_0 = new Class112.Struct6[2048];
			this.vertexBuffer_0 = new VertexBuffer(device, 2048 * Class112.Struct6.SizeInBytes, Usage.None, Class112.Struct6.vertexFormat_0, Pool.Managed);
			DataStream dataStream = this.vertexBuffer_0.Lock(0, 0, LockFlags.None);
			dataStream.WriteRange<Class112.Struct6>(this.struct6_0, 0, 2048);
			this.vertexBuffer_0.Unlock();
			dataStream.Dispose();
		}

		// Token: 0x06000279 RID: 633 RVA: 0x00003878 File Offset: 0x00001A78
		public void method_0()
		{
			this.vertexBuffer_0.Dispose();
		}

		// Token: 0x1400000C RID: 12
		// (add) Token: 0x0600027A RID: 634 RVA: 0x0002F06C File Offset: 0x0002D26C
		// (remove) Token: 0x0600027B RID: 635 RVA: 0x0002F0A4 File Offset: 0x0002D2A4
		public event Delegate4 Done
		{
			add
			{
				Delegate4 @delegate = this.delegate4_0;
				Delegate4 delegate2;
				do
				{
					delegate2 = @delegate;
					Delegate4 value2 = (Delegate4)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Delegate4>(ref this.delegate4_0, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			remove
			{
				Delegate4 @delegate = this.delegate4_0;
				Delegate4 delegate2;
				do
				{
					delegate2 = @delegate;
					Delegate4 value2 = (Delegate4)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Delegate4>(ref this.delegate4_0, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		// Token: 0x1400000D RID: 13
		// (add) Token: 0x0600027C RID: 636 RVA: 0x0002F0DC File Offset: 0x0002D2DC
		// (remove) Token: 0x0600027D RID: 637 RVA: 0x0002F114 File Offset: 0x0002D314
		public event Delegate5 OnClear
		{
			add
			{
				Delegate5 @delegate = this.delegate5_0;
				Delegate5 delegate2;
				do
				{
					delegate2 = @delegate;
					Delegate5 value2 = (Delegate5)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<Delegate5>(ref this.delegate5_0, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			remove
			{
				Delegate5 @delegate = this.delegate5_0;
				Delegate5 delegate2;
				do
				{
					delegate2 = @delegate;
					Delegate5 value2 = (Delegate5)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<Delegate5>(ref this.delegate5_0, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		// Token: 0x0600027E RID: 638 RVA: 0x00002A71 File Offset: 0x00000C71
		public void imethod_4(int int_1)
		{
		}

		// Token: 0x0600027F RID: 639 RVA: 0x00003887 File Offset: 0x00001A87
		public void imethod_5()
		{
			this.button2_Click(this, null);
		}

		// Token: 0x06000280 RID: 640 RVA: 0x0002F14C File Offset: 0x0002D34C
		public bool imethod_0(MouseEventArgs mouseEventArgs_0, Viewport viewport_0, Matrix matrix_0, Matrix matrix_1, Matrix matrix_2)
		{
			this.bool_0 = false;
			return true;
		}

		// Token: 0x06000281 RID: 641 RVA: 0x0002F168 File Offset: 0x0002D368
		public bool imethod_1(MouseEventArgs mouseEventArgs_0, Viewport viewport_0, Matrix matrix_0, Matrix matrix_1, Matrix matrix_2)
		{
			bool result;
			if ((Control.ModifierKeys & Keys.Control) != Keys.None)
			{
				result = true;
			}
			else if ((Control.ModifierKeys & Keys.Alt) != Keys.None)
			{
				result = true;
			}
			else
			{
				this.list_0.Add(new Point(mouseEventArgs_0.X, mouseEventArgs_0.Y));
				int num = Math.Min(this.list_0[0].X, this.list_0[this.list_0.Count - 1].X);
				int num2 = Math.Min(this.list_0[0].Y, this.list_0[this.list_0.Count - 1].Y);
				int num3 = Math.Max(this.list_0[0].X, this.list_0[this.list_0.Count - 1].X);
				int num4 = Math.Max(this.list_0[0].Y, this.list_0[this.list_0.Count - 1].Y);
				this.int_0 = 5;
				this.struct6_0[0].position = new Vector3((float)num, (float)num2, 0f);
				this.struct6_0[1].position = new Vector3((float)num3, (float)num2, 0f);
				this.struct6_0[2].position = new Vector3((float)num3, (float)num4, 0f);
				this.struct6_0[3].position = new Vector3((float)num, (float)num4, 0f);
				this.struct6_0[4].position = new Vector3((float)num, (float)num2, 0f);
				DataStream dataStream = this.vertexBuffer_0.Lock(0, 0, LockFlags.None);
				dataStream.WriteRange<Class112.Struct6>(this.struct6_0, 0, this.int_0);
				this.vertexBuffer_0.Unlock();
				dataStream.Dispose();
				result = false;
			}
			return result;
		}

		// Token: 0x06000282 RID: 642 RVA: 0x0002F38C File Offset: 0x0002D58C
		public bool imethod_2(MouseEventArgs mouseEventArgs_0, Viewport viewport_0, Matrix matrix_0, Matrix matrix_1, Matrix matrix_2)
		{
			this.bool_0 = true;
			this.list_0.Clear();
			this.int_0 = 0;
			this.list_0.Add(new Point(mouseEventArgs_0.X, mouseEventArgs_0.Y));
			return true;
		}

		// Token: 0x06000283 RID: 643 RVA: 0x0002F3D4 File Offset: 0x0002D5D4
		public void imethod_3(Device device_0)
		{
			if (this.bool_0 && this.int_0 > 0)
			{
				VertexDeclaration vertexDeclaration = device_0.VertexDeclaration;
				device_0.VertexFormat = Class112.Struct6.vertexFormat_0;
				device_0.SetStreamSource(0, this.vertexBuffer_0, 0, Class112.Struct6.SizeInBytes);
				Class140.smethod_0().method_40("SelectionLine");
				Class140.smethod_0().method_31("g_ambient", Color.White);
				int num = Class140.smethod_0().method_36();
				for (int i = 0; i < num; i++)
				{
					Class140.smethod_0().method_38(i);
					device_0.DrawPrimitives(PrimitiveType.LineStrip, 0, this.int_0 - 1);
					Class140.smethod_0().method_39();
				}
				Class140.smethod_0().method_37();
				device_0.VertexDeclaration = vertexDeclaration;
			}
		}

		// Token: 0x06000284 RID: 644 RVA: 0x00003893 File Offset: 0x00001A93
		private void button1_Click(object sender, EventArgs e)
		{
			base.DialogResult = DialogResult.OK;
			if (this.delegate4_0 != null)
			{
				this.delegate4_0(base.DialogResult);
			}
			this.method_0();
			base.Close();
		}

		// Token: 0x06000285 RID: 645 RVA: 0x000038C3 File Offset: 0x00001AC3
		private void button2_Click(object sender, EventArgs e)
		{
			base.DialogResult = DialogResult.Cancel;
			if (this.delegate4_0 != null)
			{
				this.delegate4_0(base.DialogResult);
			}
			this.method_0();
			base.Close();
		}

		// Token: 0x06000286 RID: 646 RVA: 0x000038F3 File Offset: 0x00001AF3
		protected void Dispose(bool disposing)
		{
			if (disposing && this.icontainer_0 != null)
			{
				this.icontainer_0.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x04000223 RID: 547
		private List<Point> list_0 = new List<Point>();

		// Token: 0x04000224 RID: 548
		private Class112.Struct6[] struct6_0;

		// Token: 0x04000225 RID: 549
		private int int_0;

		// Token: 0x04000226 RID: 550
		private VertexBuffer vertexBuffer_0;

		// Token: 0x04000227 RID: 551
		private bool bool_0 = true;

		// Token: 0x04000228 RID: 552
		private Delegate4 delegate4_0;

		// Token: 0x04000229 RID: 553
		private Delegate5 delegate5_0;

		// Token: 0x0400022A RID: 554
		private IContainer icontainer_0;
	}
}
