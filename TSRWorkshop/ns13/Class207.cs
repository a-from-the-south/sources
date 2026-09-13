using System;
using System.Collections.Generic;
using System.Diagnostics;
using SmartAssembly.SmartExceptionsCore;

namespace ns13
{
	// Token: 0x020001D7 RID: 471
	internal sealed class Class207
	{
		// Token: 0x0600132B RID: 4907 RVA: 0x0000A0F4 File Offset: 0x000082F4
		public static void smethod_0(Exception exception_0)
		{
			Class207.smethod_11(exception_0, new object[0]);
		}

		// Token: 0x0600132C RID: 4908 RVA: 0x000C6568 File Offset: 0x000C4768
		public static void smethod_1(Exception exception_0, object object_0)
		{
			Class207.smethod_11(exception_0, new object[]
			{
				object_0
			});
		}

		// Token: 0x0600132D RID: 4909 RVA: 0x000C6588 File Offset: 0x000C4788
		public static void smethod_2(Exception exception_0, object object_0, object object_1)
		{
			Class207.smethod_11(exception_0, new object[]
			{
				object_0,
				object_1
			});
		}

		// Token: 0x0600132E RID: 4910 RVA: 0x000C65AC File Offset: 0x000C47AC
		public static void smethod_3(Exception exception_0, object object_0, object object_1, object object_2)
		{
			Class207.smethod_11(exception_0, new object[]
			{
				object_0,
				object_1,
				object_2
			});
		}

		// Token: 0x0600132F RID: 4911 RVA: 0x000C65D4 File Offset: 0x000C47D4
		public static void smethod_4(Exception exception_0, object object_0, object object_1, object object_2, object object_3)
		{
			Class207.smethod_11(exception_0, new object[]
			{
				object_0,
				object_1,
				object_2,
				object_3
			});
		}

		// Token: 0x06001330 RID: 4912 RVA: 0x000C6600 File Offset: 0x000C4800
		public static void smethod_5(Exception exception_0, object object_0, object object_1, object object_2, object object_3, object object_4)
		{
			Class207.smethod_11(exception_0, new object[]
			{
				object_0,
				object_1,
				object_2,
				object_3,
				object_4
			});
		}

		// Token: 0x06001331 RID: 4913 RVA: 0x000C6634 File Offset: 0x000C4834
		public static void smethod_6(Exception exception_0, object object_0, object object_1, object object_2, object object_3, object object_4, object object_5)
		{
			Class207.smethod_11(exception_0, new object[]
			{
				object_0,
				object_1,
				object_2,
				object_3,
				object_4,
				object_5
			});
		}

		// Token: 0x06001332 RID: 4914 RVA: 0x000C666C File Offset: 0x000C486C
		public static void smethod_7(Exception exception_0, object object_0, object object_1, object object_2, object object_3, object object_4, object object_5, object object_6)
		{
			Class207.smethod_11(exception_0, new object[]
			{
				object_0,
				object_1,
				object_2,
				object_3,
				object_4,
				object_5,
				object_6
			});
		}

		// Token: 0x06001333 RID: 4915 RVA: 0x000C66A8 File Offset: 0x000C48A8
		public static void smethod_8(Exception exception_0, object object_0, object object_1, object object_2, object object_3, object object_4, object object_5, object object_6, object object_7)
		{
			Class207.smethod_11(exception_0, new object[]
			{
				object_0,
				object_1,
				object_2,
				object_3,
				object_4,
				object_5,
				object_6,
				object_7
			});
		}

		// Token: 0x06001334 RID: 4916 RVA: 0x000C66E8 File Offset: 0x000C48E8
		public static void smethod_9(Exception exception_0, object object_0, object object_1, object object_2, object object_3, object object_4, object object_5, object object_6, object object_7, object object_8)
		{
			Class207.smethod_11(exception_0, new object[]
			{
				object_0,
				object_1,
				object_2,
				object_3,
				object_4,
				object_5,
				object_6,
				object_7,
				object_8
			});
		}

		// Token: 0x06001335 RID: 4917 RVA: 0x000C6730 File Offset: 0x000C4930
		public static void smethod_10(Exception exception_0, object object_0, object object_1, object object_2, object object_3, object object_4, object object_5, object object_6, object object_7, object object_8, object object_9)
		{
			Class207.smethod_11(exception_0, new object[]
			{
				object_0,
				object_1,
				object_2,
				object_3,
				object_4,
				object_5,
				object_6,
				object_7,
				object_8,
				object_9
			});
		}

		// Token: 0x06001336 RID: 4918 RVA: 0x000C677C File Offset: 0x000C497C
		public static void smethod_11(Exception exception_0, object[] object_0)
		{
			int methodID = -1;
			int ilOffset = -1;
			int num = 0;
			StackTrace stackTrace = new StackTrace(exception_0);
			try
			{
				if (exception_0.StackTrace != null)
				{
					string[] array = exception_0.StackTrace.Split(new char[]
					{
						'\r',
						'\n'
					});
					foreach (string text in array)
					{
						if (text.Length > 0)
						{
							num++;
						}
					}
				}
			}
			catch
			{
				num = -1;
			}
			try
			{
				if (stackTrace.FrameCount > 0)
				{
					StackFrame frame = stackTrace.GetFrame(stackTrace.FrameCount - 1);
					methodID = (frame.GetMethod().MetadataToken & 16777215) - 1;
					ilOffset = frame.GetILOffset();
				}
			}
			catch
			{
			}
			try
			{
				SmartStackFrame value = new SmartStackFrame(methodID, object_0, ilOffset, num);
				LinkedList<object> linkedList;
				if (!exception_0.Data.Contains("SmartStackFrames"))
				{
					linkedList = new LinkedList<object>();
					exception_0.Data["SmartStackFrames"] = linkedList;
				}
				else
				{
					linkedList = (LinkedList<object>)exception_0.Data["SmartStackFrames"];
				}
				linkedList.AddLast(value);
			}
			catch
			{
			}
		}

		// Token: 0x04000D8F RID: 3471
		public const string string_0 = "SmartStackFrames";
	}
}
