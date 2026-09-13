using System;
using System.ComponentModel;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using SlimDX;

namespace ns3
{
	// Token: 0x02000062 RID: 98
	internal sealed partial class TransformationEditor : Form
	{
		// Token: 0x14000011 RID: 17
		// (add) Token: 0x060003C5 RID: 965 RVA: 0x000456F4 File Offset: 0x000438F4
		// (remove) Token: 0x060003C6 RID: 966 RVA: 0x0004572C File Offset: 0x0004392C
		public event TransformationEditor.Delegate7 DoUpdate
		{
			add
			{
				TransformationEditor.Delegate7 @delegate = this.delegate7_0;
				TransformationEditor.Delegate7 delegate2;
				do
				{
					delegate2 = @delegate;
					TransformationEditor.Delegate7 value2 = (TransformationEditor.Delegate7)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<TransformationEditor.Delegate7>(ref this.delegate7_0, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			remove
			{
				TransformationEditor.Delegate7 @delegate = this.delegate7_0;
				TransformationEditor.Delegate7 delegate2;
				do
				{
					delegate2 = @delegate;
					TransformationEditor.Delegate7 value2 = (TransformationEditor.Delegate7)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<TransformationEditor.Delegate7>(ref this.delegate7_0, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		// Token: 0x060003C7 RID: 967 RVA: 0x00045764 File Offset: 0x00043964
		public TransformationEditor(float tx, float ty, float tz, float rx, float ry, float rz, float rw)
		{
			this.InitializeComponent();
			this.tX.Text = tx.ToString();
			this.tY.Text = ty.ToString();
			this.tZ.Text = tz.ToString();
			this.quatX.Text = rx.ToString();
			this.quatY.Text = ry.ToString();
			this.quatZ.Text = rz.ToString();
			this.quatW.Text = rw.ToString();
			this.tx = tx;
			this.ty = ty;
			this.tz = tz;
			this.rx = rx;
			this.ry = ry;
			this.rz = rz;
			this.rw = rw;
		}

		// Token: 0x060003C8 RID: 968 RVA: 0x00004159 File Offset: 0x00002359
		private void TransformationEditor_Load(object sender, EventArgs e)
		{
			this.method_0();
		}

		// Token: 0x060003C9 RID: 969 RVA: 0x00004159 File Offset: 0x00002359
		private void quatW_TextChanged(object sender, EventArgs e)
		{
			this.method_0();
		}

		// Token: 0x060003CA RID: 970 RVA: 0x00045834 File Offset: 0x00043A34
		private void method_0()
		{
			this.float_0 = float.Parse(this.tX.Text);
			this.float_1 = float.Parse(this.tY.Text);
			this.float_2 = float.Parse(this.tZ.Text);
			this.float_3 = float.Parse(this.quatX.Text);
			this.float_4 = float.Parse(this.quatY.Text);
			this.float_3 = float.Parse(this.quatZ.Text);
			this.float_6 = float.Parse(this.quatW.Text);
			Quaternion rotation = new Quaternion(this.float_3, this.float_4, this.float_5, this.float_6);
			Matrix matrix = Matrix.RotationQuaternion(rotation) * Matrix.Translation(this.float_0, this.float_1, this.float_2);
			if (this.delegate7_0 != null)
			{
				this.delegate7_0(matrix);
			}
		}

		// Token: 0x060003CB RID: 971 RVA: 0x00002BF8 File Offset: 0x00000DF8
		private void okButton_Click(object sender, EventArgs e)
		{
			base.DialogResult = DialogResult.OK;
			base.Close();
		}

		// Token: 0x060003CC RID: 972 RVA: 0x00002AC2 File Offset: 0x00000CC2
		private void cancelButton_Click(object sender, EventArgs e)
		{
			base.DialogResult = DialogResult.Cancel;
			base.Close();
		}

		// Token: 0x060003CD RID: 973 RVA: 0x00045934 File Offset: 0x00043B34
		private void button1_Click(object sender, EventArgs e)
		{
			this.tX.Text = "0";
			this.tY.Text = "0";
			this.tZ.Text = "0";
			this.quatX.Text = "0";
			this.quatY.Text = "0";
			this.quatZ.Text = "0";
			this.quatW.Text = "0";
			this.method_0();
		}

		// Token: 0x060003CE RID: 974 RVA: 0x00004163 File Offset: 0x00002363
		protected void Dispose(bool disposing)
		{
			if (disposing && this.icontainer_0 != null)
			{
				this.icontainer_0.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x040003A3 RID: 931
		private TransformationEditor.Delegate7 delegate7_0;

		// Token: 0x040003A4 RID: 932
		public float float_0;

		// Token: 0x040003A5 RID: 933
		public float float_1;

		// Token: 0x040003A6 RID: 934
		public float float_2;

		// Token: 0x040003A7 RID: 935
		public float float_3;

		// Token: 0x040003A8 RID: 936
		public float float_4;

		// Token: 0x040003A9 RID: 937
		public float float_5;

		// Token: 0x040003AA RID: 938
		public float float_6;

		// Token: 0x040003AB RID: 939
		public float tx;

		// Token: 0x040003AC RID: 940
		public float ty;

		// Token: 0x040003AD RID: 941
		public float tz;

		// Token: 0x040003AE RID: 942
		public float rx;

		// Token: 0x040003AF RID: 943
		public float ry;

		// Token: 0x040003B0 RID: 944
		public float rz;

		// Token: 0x040003B1 RID: 945
		public float rw;

		// Token: 0x040003B2 RID: 946
		private IContainer icontainer_0;

		// Token: 0x02000063 RID: 99
		// (Invoke) Token: 0x060003D1 RID: 977
		public delegate void Delegate7(Matrix matrix);
	}
}
