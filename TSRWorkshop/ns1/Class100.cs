using System;
using System.Drawing;
using System.Windows.Forms;
using ns17;
using SlimDX;

namespace ns1
{
	// Token: 0x020000EE RID: 238
	internal sealed class Class100
	{
		// Token: 0x1700018B RID: 395
		// (get) Token: 0x060009A1 RID: 2465 RVA: 0x00085070 File Offset: 0x00083270
		public Matrix RotationMatrix
		{
			get
			{
				return this.matrix_0 = Matrix.RotationQuaternion(this.quaternion_1);
			}
		}

		// Token: 0x1700018C RID: 396
		// (get) Token: 0x060009A2 RID: 2466 RVA: 0x00085098 File Offset: 0x00083298
		// (set) Token: 0x060009A3 RID: 2467 RVA: 0x000064F9 File Offset: 0x000046F9
		public Matrix TranslationMatrix
		{
			get
			{
				return this.matrix_1;
			}
			set
			{
				this.matrix_1 = value;
			}
		}

		// Token: 0x1700018D RID: 397
		// (get) Token: 0x060009A4 RID: 2468 RVA: 0x000850B0 File Offset: 0x000832B0
		public Matrix TranslationDeltaMatrix
		{
			get
			{
				return this.matrix_2;
			}
		}

		// Token: 0x1700018E RID: 398
		// (get) Token: 0x060009A5 RID: 2469 RVA: 0x000850C8 File Offset: 0x000832C8
		public bool IsBeingDragged
		{
			get
			{
				return this.bool_0;
			}
		}

		// Token: 0x1700018F RID: 399
		// (get) Token: 0x060009A6 RID: 2470 RVA: 0x000850E0 File Offset: 0x000832E0
		// (set) Token: 0x060009A7 RID: 2471 RVA: 0x00006504 File Offset: 0x00004704
		public Quaternion CurrentQuaternion
		{
			get
			{
				return this.quaternion_1;
			}
			set
			{
				this.quaternion_1 = value;
			}
		}

		// Token: 0x17000190 RID: 400
		// (get) Token: 0x060009A8 RID: 2472 RVA: 0x000850F8 File Offset: 0x000832F8
		// (set) Token: 0x060009A9 RID: 2473 RVA: 0x0000650F File Offset: 0x0000470F
		public Rectangle DragRect
		{
			get
			{
				return this.rectangle_0;
			}
			set
			{
				this.rectangle_0 = value;
			}
		}

		// Token: 0x060009AA RID: 2474 RVA: 0x00085110 File Offset: 0x00083310
		public Class100()
		{
			this.method_0();
			this.vector3_0 = default(Vector3);
			this.vector3_1 = default(Vector3);
			Form activeForm = Form.ActiveForm;
			if (activeForm != null)
			{
				Rectangle clientRectangle = activeForm.ClientRectangle;
				this.method_3(clientRectangle.Width, clientRectangle.Height);
			}
		}

		// Token: 0x060009AB RID: 2475 RVA: 0x00085168 File Offset: 0x00083368
		public void method_0()
		{
			this.quaternion_0 = Quaternion.Identity;
			this.quaternion_1 = Quaternion.Identity;
			this.matrix_0 = Matrix.Identity;
			this.matrix_1 = Matrix.Identity;
			this.matrix_2 = Matrix.Identity;
			this.bool_0 = false;
			this.float_0 = 1f;
			this.float_1 = 1f;
		}

		// Token: 0x060009AC RID: 2476 RVA: 0x000851CC File Offset: 0x000833CC
		public Vector3 method_1(float float_2, float float_3)
		{
			float num = (float_2 - (float)this.int_0 / 2f) / (this.float_0 * (float)this.int_0 / 2f);
			float num2 = -(float_3 - (float)this.int_1 / 2f) / (this.float_0 * (float)this.int_1 / 2f);
			float z = 0f;
			float num3 = num * num + num2 * num2;
			if (num3 > 1f)
			{
				float num4 = 1f / (float)Math.Sqrt((double)num3);
				num *= num4;
				num2 *= num4;
			}
			else
			{
				z = (float)Math.Sqrt((double)(1f - num3));
			}
			return new Vector3(num, num2, z);
		}

		// Token: 0x060009AD RID: 2477 RVA: 0x00085274 File Offset: 0x00083474
		public void method_2(int int_2, int int_3, float float_2)
		{
			this.int_0 = int_2;
			this.int_1 = int_3;
			this.float_0 = float_2;
			this.vector2_0 = new Vector2((float)int_2 / 2f, (float)int_3 / 2f);
			this.rectangle_0 = new Rectangle(0, 0, int_2, int_3);
		}

		// Token: 0x060009AE RID: 2478 RVA: 0x0000651A File Offset: 0x0000471A
		public void method_3(int int_2, int int_3)
		{
			this.method_2(int_2, int_3, 0.9f);
			this.rectangle_0 = new Rectangle(0, 0, int_2, int_3);
		}

		// Token: 0x060009AF RID: 2479 RVA: 0x000852C4 File Offset: 0x000834C4
		public static Quaternion smethod_0(Vector3 vector3_2, Vector3 vector3_3)
		{
			float w = Vector3.Dot(vector3_2, vector3_3);
			Vector3 vector = Vector3.Cross(vector3_2, vector3_3);
			return new Quaternion(vector.X, vector.Y, vector.Z, w);
		}

		// Token: 0x060009B0 RID: 2480 RVA: 0x0000653A File Offset: 0x0000473A
		public void method_4(int int_2, int int_3)
		{
			this.bool_0 = true;
			this.quaternion_0 = this.quaternion_1;
			this.vector3_0 = this.method_1((float)int_2, (float)int_3);
		}

		// Token: 0x060009B1 RID: 2481 RVA: 0x00006561 File Offset: 0x00004761
		public void method_5(int int_2, int int_3)
		{
			if (this.bool_0)
			{
				this.vector3_1 = this.method_1((float)int_2, (float)int_3);
				this.quaternion_1 = this.quaternion_0 * Class100.smethod_0(this.vector3_0, this.vector3_1);
			}
		}

		// Token: 0x060009B2 RID: 2482 RVA: 0x0000659F File Offset: 0x0000479F
		public void method_6()
		{
			this.bool_0 = false;
		}

		// Token: 0x060009B3 RID: 2483 RVA: 0x00085300 File Offset: 0x00083500
		public bool method_7(IntPtr intptr_0, Class101.Enum15 enum15_0, IntPtr intptr_1, IntPtr intptr_2)
		{
			int num = (int)Class101.smethod_0((uint)intptr_2.ToInt32());
			int num2 = (int)Class101.smethod_1((uint)intptr_2.ToInt32());
			bool result;
			if (!this.rectangle_0.Contains(num, num2))
			{
				result = false;
			}
			else
			{
				num -= this.rectangle_0.Left;
				num2 -= this.rectangle_0.Top;
				switch (enum15_0)
				{
				case Class101.Enum15.const_18:
				{
					short num3 = Class101.smethod_0((uint)intptr_1.ToInt32());
					bool flag = (num3 & 1) != 0;
					bool flag2 = (num3 & 2) != 0;
					bool flag3 = (num3 & 16) != 0;
					if (flag)
					{
						this.method_5(num, num2);
					}
					else if (flag2 || flag3)
					{
						this.method_8(num, num2);
					}
					result = true;
					break;
				}
				case Class101.Enum15.const_19:
				case Class101.Enum15.const_21:
					Class101.SetCapture(intptr_0);
					this.method_4(num, num2);
					result = true;
					break;
				case Class101.Enum15.const_20:
					Class101.ReleaseCapture();
					this.method_6();
					result = true;
					break;
				case Class101.Enum15.const_22:
				case Class101.Enum15.const_24:
				case Class101.Enum15.const_25:
				case Class101.Enum15.const_27:
					Class101.SetCapture(intptr_0);
					this.point_0 = new Point(num, num2);
					result = true;
					break;
				case Class101.Enum15.const_23:
				case Class101.Enum15.const_26:
					Class101.ReleaseCapture();
					result = true;
					break;
				default:
					result = false;
					break;
				}
			}
			return result;
		}

		// Token: 0x060009B4 RID: 2484 RVA: 0x00085438 File Offset: 0x00083638
		public void method_8(int int_2, int int_3)
		{
			float num = (float)(this.point_0.X - int_2) * this.float_1 / (float)this.int_0;
			float num2 = (float)(this.point_0.Y - int_3) * this.float_1 / (float)this.int_1;
			this.matrix_2 = Matrix.Translation(2f * num, 2f * -num2, 0f);
			this.matrix_1 *= this.matrix_2;
			this.point_0 = new Point(int_2, int_3);
		}

		// Token: 0x060009B5 RID: 2485 RVA: 0x000854C8 File Offset: 0x000836C8
		public void method_9(int int_2, int int_3)
		{
			float num = (float)(-(float)(this.point_0.X - int_2)) * this.float_1 / (float)this.int_0;
			float num2 = (float)(-(float)(this.point_0.Y - int_3)) * this.float_1 / (float)this.int_1;
			this.matrix_2 = Matrix.Translation(0f, 0f, 5f * num2);
			this.matrix_1 *= this.matrix_2;
			this.point_0 = new Point(int_2, int_3);
		}

		// Token: 0x060009B6 RID: 2486 RVA: 0x000065AA File Offset: 0x000047AA
		public void method_10(int int_2, int int_3)
		{
			this.point_0 = new Point(int_2, int_3);
		}

		// Token: 0x040007C8 RID: 1992
		protected Matrix matrix_0;

		// Token: 0x040007C9 RID: 1993
		protected Matrix matrix_1;

		// Token: 0x040007CA RID: 1994
		protected Matrix matrix_2;

		// Token: 0x040007CB RID: 1995
		protected int int_0;

		// Token: 0x040007CC RID: 1996
		protected int int_1;

		// Token: 0x040007CD RID: 1997
		protected Vector2 vector2_0;

		// Token: 0x040007CE RID: 1998
		protected float float_0;

		// Token: 0x040007CF RID: 1999
		protected float float_1;

		// Token: 0x040007D0 RID: 2000
		protected Quaternion quaternion_0;

		// Token: 0x040007D1 RID: 2001
		protected Quaternion quaternion_1;

		// Token: 0x040007D2 RID: 2002
		protected bool bool_0;

		// Token: 0x040007D3 RID: 2003
		protected Rectangle rectangle_0;

		// Token: 0x040007D4 RID: 2004
		protected Point point_0;

		// Token: 0x040007D5 RID: 2005
		protected Vector3 vector3_0;

		// Token: 0x040007D6 RID: 2006
		protected Vector3 vector3_1;
	}
}
