using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using SlimDX;

namespace ns20
{
	// Token: 0x020000E2 RID: 226
	internal sealed partial class PositionToMatrix : Form
	{
		// Token: 0x06000949 RID: 2377 RVA: 0x00080800 File Offset: 0x0007EA00
		public PositionToMatrix(float[] matrixData)
		{
			this.float_0 = new float[12];
			matrixData.CopyTo(this.float_0, 0);
			float num = 0f * matrixData[0] + 0f * matrixData[1] + 0f * matrixData[2] + matrixData[3];
			float num2 = 0f * matrixData[4] + 0f * matrixData[5] + 0f * matrixData[6] + matrixData[7];
			float num3 = 0f * matrixData[8] + 0f * matrixData[9] + 0f * matrixData[10] + matrixData[11];
			this.InitializeComponent();
			this.xValue.Text = num.ToString();
			this.yValue.Text = num2.ToString();
			this.zValue.Text = num3.ToString();
			this.rotX.Text = "0";
			this.rotY.Text = "0";
			this.rotZ.Text = "0";
			this.rotW.Text = "0";
		}

		// Token: 0x0600094A RID: 2378 RVA: 0x00080914 File Offset: 0x0007EB14
		private void okButton_Click(object sender, EventArgs e)
		{
			try
			{
				Matrix.RotationQuaternion(new Quaternion(float.Parse(this.rotX.Text), float.Parse(this.rotY.Text), float.Parse(this.rotZ.Text), float.Parse(this.rotW.Text))) * Matrix.Translation(float.Parse(this.xValue.Text), float.Parse(this.yValue.Text), float.Parse(this.zValue.Text));
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
				return;
			}
			this.float_0[3] = float.Parse(this.xValue.Text);
			this.float_0[7] = float.Parse(this.yValue.Text);
			this.float_0[11] = float.Parse(this.zValue.Text);
			base.DialogResult = DialogResult.OK;
			base.Close();
		}

		// Token: 0x0600094B RID: 2379 RVA: 0x00002AC2 File Offset: 0x00000CC2
		private void cancelButton_Click(object sender, EventArgs e)
		{
			base.DialogResult = DialogResult.Cancel;
			base.Close();
		}

		// Token: 0x0600094C RID: 2380 RVA: 0x00002A71 File Offset: 0x00000C71
		private void label5_Click(object sender, EventArgs e)
		{
		}

		// Token: 0x0600094D RID: 2381 RVA: 0x00002A71 File Offset: 0x00000C71
		private void rotZ_TextChanged(object sender, EventArgs e)
		{
		}

		// Token: 0x0600094E RID: 2382 RVA: 0x00002A71 File Offset: 0x00000C71
		private void label4_Click(object sender, EventArgs e)
		{
		}

		// Token: 0x0600094F RID: 2383 RVA: 0x000062B1 File Offset: 0x000044B1
		protected void Dispose(bool disposing)
		{
			if (disposing && this.icontainer_0 != null)
			{
				this.icontainer_0.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x04000768 RID: 1896
		public float[] float_0;

		// Token: 0x04000769 RID: 1897
		private IContainer icontainer_0;
	}
}
