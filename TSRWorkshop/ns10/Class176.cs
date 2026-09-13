using System;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using ns0;

namespace ns10
{
	// Token: 0x02000183 RID: 387
	internal sealed class Class176 : Interface14
	{
		// Token: 0x060011CE RID: 4558 RVA: 0x000097B3 File Offset: 0x000079B3
		public Class176(object target)
		{
			this.target = target;
		}

		// Token: 0x060011CF RID: 4559 RVA: 0x000BD9F8 File Offset: 0x000BBBF8
		private static MethodInfo smethod_0(object object_0, string string_0, params Type[] type_0)
		{
			return object_0.GetType().GetMethod(string_0, BindingFlags.Instance | BindingFlags.Public, null, type_0, null);
		}

		// Token: 0x060011D0 RID: 4560 RVA: 0x000BDA1C File Offset: 0x000BBC1C
		public static bool smethod_1(object object_0)
		{
			MethodInfo methodInfo = Class176.smethod_0(object_0, "GetChildAtPoint", new Type[]
			{
				typeof(Control),
				typeof(int),
				typeof(int)
			});
			MethodInfo methodInfo2 = Class176.smethod_0(object_0, "GetParent", new Type[]
			{
				typeof(object)
			});
			MethodInfo methodInfo3 = Class176.smethod_0(object_0, "GetChildTypes", Type.EmptyTypes);
			bool result;
			if (methodInfo != null && methodInfo2 != null && methodInfo3 != null)
			{
				result = (methodInfo3.ReturnType == typeof(Type[]));
			}
			else
			{
				result = false;
			}
			return result;
		}

		// Token: 0x060011D1 RID: 4561 RVA: 0x000BDABC File Offset: 0x000BBCBC
		public object imethod_0(Control control_0, int int_0, int int_1)
		{
			return Class176.smethod_0(this.target, "GetChildAtPoint", new Type[]
			{
				typeof(Control),
				typeof(int),
				typeof(int)
			}).Invoke(this.target, new object[]
			{
				control_0,
				int_0,
				int_1
			});
		}

		// Token: 0x060011D2 RID: 4562 RVA: 0x000BDB38 File Offset: 0x000BBD38
		public object imethod_1(object object_0)
		{
			return Class176.smethod_0(this.target, "GetParent", new Type[]
			{
				typeof(object)
			}).Invoke(this.target, new object[]
			{
				object_0
			});
		}

		// Token: 0x060011D3 RID: 4563 RVA: 0x000BDB88 File Offset: 0x000BBD88
		public Type[] imethod_2()
		{
			return (Type[])Class176.smethod_0(this.target, "GetChildTypes", Type.EmptyTypes).Invoke(this.target, null);
		}

		// Token: 0x060011D4 RID: 4564 RVA: 0x000BDBC0 File Offset: 0x000BBDC0
		public Rectangle imethod_3(object object_0)
		{
			MethodInfo methodInfo = Class176.smethod_0(this.target, "GetBounds", new Type[]
			{
				typeof(object)
			});
			Rectangle result;
			if (methodInfo != null)
			{
				result = (Rectangle)methodInfo.Invoke(this.target, new object[]
				{
					object_0
				});
			}
			else
			{
				result = Rectangle.Empty;
			}
			return result;
		}

		// Token: 0x04000C59 RID: 3161
		private object target;
	}
}
