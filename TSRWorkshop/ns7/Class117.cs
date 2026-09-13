using System;
using SlimDX;

namespace ns7
{
	// Token: 0x0200010B RID: 267
	internal sealed class Class117
	{
		// Token: 0x06000B66 RID: 2918 RVA: 0x00092370 File Offset: 0x00090570
		public static bool smethod_0(Vector3 vector3_0, Vector3 vector3_1, Vector3 vector3_2, Vector3 vector3_3)
		{
			Vector3 left = Vector3.Cross(vector3_3 - vector3_2, vector3_0 - vector3_2);
			Vector3 right = Vector3.Cross(vector3_3 - vector3_2, vector3_1 - vector3_2);
			float num = Vector3.Dot(left, right);
			bool result;
			if (num >= 0f)
			{
				result = true;
			}
			else
			{
				result = false;
			}
			return result;
		}

		// Token: 0x06000B67 RID: 2919 RVA: 0x000923C0 File Offset: 0x000905C0
		public static bool smethod_1(Vector3 vector3_0, Vector3 vector3_1, Vector3 vector3_2, Vector3 vector3_3)
		{
			bool result;
			if (Class117.smethod_0(vector3_0, vector3_1, vector3_2, vector3_3) && Class117.smethod_0(vector3_0, vector3_2, vector3_1, vector3_3) && Class117.smethod_0(vector3_0, vector3_3, vector3_1, vector3_2))
			{
				result = true;
			}
			else
			{
				result = false;
			}
			return result;
		}

		// Token: 0x06000B68 RID: 2920 RVA: 0x000923F8 File Offset: 0x000905F8
		public static bool smethod_2(Vector4 vector4_0, Vector2 vector2_0, Vector2 vector2_1, Vector2 vector2_2)
		{
			Class117.float_6 = vector4_0.X;
			Class117.float_7 = vector4_0.Z;
			Class117.float_8 = vector4_0.Y;
			Class117.float_9 = vector4_0.W;
			Class117.float_0 = vector2_0.X;
			Class117.float_1 = vector2_0.Y;
			Class117.float_2 = vector2_1.X;
			Class117.float_3 = vector2_1.Y;
			Class117.float_4 = vector2_2.X;
			Class117.float_5 = vector2_2.Y;
			bool result;
			if (!Class117.smethod_3(Class117.float_0, Class117.float_1, Class117.float_2, Class117.float_3) && !Class117.smethod_3(Class117.float_2, Class117.float_3, Class117.float_4, Class117.float_5))
			{
				result = Class117.smethod_3(Class117.float_4, Class117.float_5, Class117.float_0, Class117.float_1);
			}
			else
			{
				result = true;
			}
			return result;
		}

		// Token: 0x06000B69 RID: 2921 RVA: 0x000924D4 File Offset: 0x000906D4
		public static bool smethod_3(float float_16, float float_17, float float_18, float float_19)
		{
			Class117.float_14 = (float_19 - float_17) / (float_18 - float_16);
			Class117.float_15 = float_17 - Class117.float_14 * float_16;
			Class117.float_10 = 0f;
			Class117.float_11 = 0f;
			if (Class117.float_14 > 0f)
			{
				Class117.float_10 = Class117.float_14 * Class117.float_6 + Class117.float_15;
				Class117.float_11 = Class117.float_14 * Class117.float_7 + Class117.float_15;
			}
			else
			{
				Class117.float_10 = Class117.float_14 * Class117.float_7 + Class117.float_15;
				Class117.float_11 = Class117.float_14 * Class117.float_6 + Class117.float_15;
			}
			if (float_17 < float_19)
			{
				Class117.float_12 = float_17;
				Class117.float_13 = float_19;
			}
			else
			{
				Class117.float_12 = float_19;
				Class117.float_13 = float_17;
			}
			float num = (Class117.float_10 > Class117.float_12) ? Class117.float_10 : Class117.float_12;
			float num2 = (Class117.float_11 < Class117.float_13) ? Class117.float_11 : Class117.float_13;
			bool result;
			if (num < num2)
			{
				if (num2 >= Class117.float_8)
				{
					result = (num <= Class117.float_9);
				}
				else
				{
					result = false;
				}
			}
			else
			{
				result = false;
			}
			return result;
		}

		// Token: 0x06000B6A RID: 2922 RVA: 0x000925E8 File Offset: 0x000907E8
		public static bool smethod_4(Vector2[] vector2_0, Vector2[] vector2_1)
		{
			bool result = false;
			Class117.Class118[] array = new Class117.Class118[3];
			Class117.Class118[] array2 = new Class117.Class118[4];
			array[0] = new Class117.Class118(vector2_0[0], vector2_0[1]);
			array[1] = new Class117.Class118(vector2_0[1], vector2_0[2]);
			array[2] = new Class117.Class118(vector2_0[2], vector2_0[0]);
			array2[0] = new Class117.Class118(vector2_1[0], vector2_1[1]);
			array2[1] = new Class117.Class118(vector2_1[1], vector2_1[2]);
			array2[2] = new Class117.Class118(vector2_1[2], vector2_1[3]);
			array2[3] = new Class117.Class118(vector2_1[3], vector2_1[0]);
			for (int i = 0; i < 4; i++)
			{
				Class117.Class118 @class = array2[i];
				for (int j = 0; j < 3; j++)
				{
					Class117.Class118 class118_ = array[j];
					Vector2 vector = default(Vector2);
					Class117.Enum19 @enum = @class.method_0(class118_, out vector);
					if (@enum == Class117.Enum19.const_3)
					{
						result = true;
					}
				}
			}
			return result;
		}

		// Token: 0x06000B6B RID: 2923 RVA: 0x00092730 File Offset: 0x00090930
		public static int smethod_5(Vector3 vector3_0, Vector3[] vector3_1)
		{
			Vector3 vector = vector3_1[2] - vector3_1[0];
			Vector3 vector2 = vector3_1[1] - vector3_1[0];
			Vector3 right = vector3_0 - vector3_1[0];
			double num = (double)Vector3.Dot(vector, vector);
			double num2 = (double)Vector3.Dot(vector, vector2);
			double num3 = (double)Vector3.Dot(vector, right);
			double num4 = (double)Vector3.Dot(vector2, vector2);
			double num5 = (double)Vector3.Dot(vector2, right);
			double num6 = 1.0 / (num * num4 - num2 * num2);
			double num7 = (num4 * num3 - num2 * num5) * num6;
			double num8 = (num * num5 - num2 * num3) * num6;
			int result;
			if (num7 > 0.0 && num8 > 0.0 && num7 + num8 < 1.0)
			{
				result = 3;
			}
			else
			{
				if (num7 != 0.0 && num8 != 0.0)
				{
					if (num7 + num8 != 1.0)
					{
						return 0;
					}
				}
				result = 1;
			}
			return result;
		}

		// Token: 0x06000B6C RID: 2924 RVA: 0x0009285C File Offset: 0x00090A5C
		public static bool smethod_6(Vector3[] vector3_0, Vector3[] vector3_1)
		{
			int num = 0;
			int num2 = 0;
			int i = 0;
			while (i < 3)
			{
				num += Class117.smethod_5(vector3_0[i], vector3_1);
				bool result;
				if (num <= 2)
				{
					num2 += Class117.smethod_5(vector3_1[i], vector3_0);
					if (num2 <= 2)
					{
						i++;
						continue;
					}
					result = true;
				}
				else
				{
					result = true;
				}
				return result;
			}
			return false;
		}

		// Token: 0x06000B6D RID: 2925 RVA: 0x000928B8 File Offset: 0x00090AB8
		public static bool smethod_7(Vector3[] vector3_0, Vector3[] vector3_1)
		{
			for (int i = 0; i < 3; i++)
			{
				Vector3 vector = vector3_0[i];
				Vector3 vector2;
				if (i != 2)
				{
					vector2 = vector3_0[i + 1];
				}
				else
				{
					vector2 = vector3_0[0];
				}
				for (int j = 0; j < 3; j++)
				{
					Vector3 vector3 = vector3_1[j];
					Vector3 vector4;
					if (j != 2)
					{
						vector4 = vector3_1[j + 1];
					}
					else
					{
						vector4 = vector3_1[0];
					}
					double num = (double)((vector2.Z - vector.Y) * (vector4.X - vector3.X) - (vector2.X - vector.X) * (vector4.Y - vector3.Y));
					if (num != 0.0)
					{
						double num2 = (double)((vector3.Y - vector.Y) * (vector4.X - vector3.X) + (vector.X - vector3.X) * (vector4.Y - vector3.Y)) / num;
						if (num2 > 0.0 && num2 < 1.0)
						{
							double num3 = (double)((vector4.Y - vector3.Y) * (vector2.X - vector.X) - (vector4.X - vector3.X) * (vector2.Y - vector.Y));
							if (num3 != 0.0)
							{
								double num4 = (double)((vector.Y - vector3.Y) * (vector2.X - vector.X) + (vector3.X - vector.X) * (vector2.Y - vector.Y)) / num3;
								if (num4 > 0.0 && num4 < 1.0)
								{
									return true;
								}
							}
						}
					}
				}
			}
			return false;
		}

		// Token: 0x06000B6E RID: 2926 RVA: 0x00092AC8 File Offset: 0x00090CC8
		public static bool smethod_8(Vector3[] vector3_0, Vector3[] vector3_1)
		{
			bool result;
			if (Class117.smethod_7(vector3_0, vector3_1))
			{
				result = true;
			}
			else if (Class117.smethod_6(vector3_0, vector3_1))
			{
				result = true;
			}
			else
			{
				result = false;
			}
			return result;
		}

		// Token: 0x06000B6F RID: 2927 RVA: 0x00092AF4 File Offset: 0x00090CF4
		public static bool smethod_9(Vector3[] vector3_0, Vector3[] vector3_1, int int_0)
		{
			if (int_0 > 2)
			{
				int num = 0;
				int num2 = 1;
				int num3 = int_0 - 1;
				Vector3[] array = new Vector3[]
				{
					vector3_1[0],
					vector3_1[1],
					vector3_1[int_0 - 1]
				};
				bool[] array2 = new bool[3];
				array2[0] = true;
				array2[1] = true;
				bool[] array3 = array2;
				for (int i = 0; i < int_0 - 2; i++)
				{
					if (Class117.smethod_8(vector3_0, array))
					{
						return true;
					}
					if (i < int_0 - 3)
					{
						if (array3[num])
						{
							num3--;
							array[num] = vector3_1[num3];
							array3[num] = false;
						}
						else
						{
							num2++;
							array[num] = vector3_1[num2];
							array3[num] = true;
						}
						num++;
						if (num == 3)
						{
							num = 0;
						}
					}
				}
			}
			return false;
		}

		// Token: 0x040008F2 RID: 2290
		private static float float_0;

		// Token: 0x040008F3 RID: 2291
		private static float float_1;

		// Token: 0x040008F4 RID: 2292
		private static float float_2;

		// Token: 0x040008F5 RID: 2293
		private static float float_3;

		// Token: 0x040008F6 RID: 2294
		private static float float_4;

		// Token: 0x040008F7 RID: 2295
		private static float float_5;

		// Token: 0x040008F8 RID: 2296
		private static float float_6;

		// Token: 0x040008F9 RID: 2297
		private static float float_7;

		// Token: 0x040008FA RID: 2298
		private static float float_8;

		// Token: 0x040008FB RID: 2299
		private static float float_9;

		// Token: 0x040008FC RID: 2300
		private static float float_10;

		// Token: 0x040008FD RID: 2301
		private static float float_11;

		// Token: 0x040008FE RID: 2302
		private static float float_12;

		// Token: 0x040008FF RID: 2303
		private static float float_13;

		// Token: 0x04000900 RID: 2304
		private static float float_14;

		// Token: 0x04000901 RID: 2305
		private static float float_15;

		// Token: 0x0200010C RID: 268
		public enum Enum19 : uint
		{
			// Token: 0x04000903 RID: 2307
			const_0 = 1U,
			// Token: 0x04000904 RID: 2308
			const_1,
			// Token: 0x04000905 RID: 2309
			const_2,
			// Token: 0x04000906 RID: 2310
			const_3
		}

		// Token: 0x0200010D RID: 269
		public sealed class Class118
		{
			// Token: 0x06000B71 RID: 2929 RVA: 0x00006BE5 File Offset: 0x00004DE5
			public Class118(Vector2 begin, Vector2 end)
			{
				this.begin = begin;
				this.end = end;
			}

			// Token: 0x06000B72 RID: 2930 RVA: 0x00092C04 File Offset: 0x00090E04
			public Class117.Enum19 method_0(Class117.Class118 class118_0, out Vector2 vector2_0)
			{
				vector2_0 = default(Vector2);
				float num = (class118_0.end.Y - class118_0.begin.Y) * (this.end.X - this.begin.X) - (class118_0.end.X - class118_0.begin.X) * (this.end.Y - this.begin.Y);
				float num2 = (class118_0.end.X - class118_0.begin.X) * (this.begin.Y - class118_0.begin.Y) - (class118_0.end.Y - class118_0.begin.Y) * (this.begin.X - class118_0.begin.X);
				float num3 = (this.end.X - this.begin.X) * (this.begin.Y - class118_0.begin.Y) - (this.end.X - this.begin.Y) * (this.begin.X - class118_0.begin.X);
				Class117.Enum19 result;
				if (num == 0f)
				{
					if (num2 == 0f && num3 == 0f)
					{
						result = Class117.Enum19.const_1;
					}
					else
					{
						result = Class117.Enum19.const_0;
					}
				}
				else
				{
					float num4 = num2 / num;
					float num5 = num3 / num;
					if (num4 >= 0f && num4 <= 1f && num5 >= 0f && num5 <= 1f)
					{
						vector2_0.X = this.begin.X + num4 * (this.end.X - this.begin.X);
						vector2_0.Y = this.begin.Y + num4 * (this.end.Y - this.begin.Y);
						result = Class117.Enum19.const_3;
					}
					else
					{
						result = Class117.Enum19.const_2;
					}
				}
				return result;
			}

			// Token: 0x04000907 RID: 2311
			private Vector2 begin;

			// Token: 0x04000908 RID: 2312
			private Vector2 end;
		}
	}
}
