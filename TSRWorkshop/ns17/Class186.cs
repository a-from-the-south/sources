using System;
using System.Reflection;
using System.Security.Cryptography;

namespace ns17
{
	// Token: 0x020001A2 RID: 418
	internal sealed class Class186 : IDisposable
	{
		// Token: 0x06001256 RID: 4694 RVA: 0x000C0674 File Offset: 0x000BE874
		public Class186()
		{
			Assembly assembly = Assembly.Load("mscorlib");
			this.type_0 = assembly.GetType("System.Security.Cryptography.DESCryptoServiceProvider");
			this.object_0 = Activator.CreateInstance(this.type_0);
		}

		// Token: 0x06001257 RID: 4695 RVA: 0x000C06B8 File Offset: 0x000BE8B8
		public ICryptoTransform method_0(byte[] byte_0, byte[] byte_1, bool bool_0)
		{
			this.type_0.GetProperty("Key").GetSetMethod().Invoke(this.object_0, new object[]
			{
				byte_0
			});
			this.type_0.GetProperty("IV").GetSetMethod().Invoke(this.object_0, new object[]
			{
				byte_1
			});
			MethodInfo method = this.type_0.GetMethod(bool_0 ? "CreateDecryptor" : "CreateEncryptor", new Type[0]);
			return (ICryptoTransform)method.Invoke(this.object_0, new object[0]);
		}

		// Token: 0x06001258 RID: 4696 RVA: 0x00009A86 File Offset: 0x00007C86
		public void method_1()
		{
			this.type_0.GetMethod("Clear").Invoke(this.object_0, new object[0]);
		}

		// Token: 0x06001259 RID: 4697 RVA: 0x00009AAC File Offset: 0x00007CAC
		public void Dispose()
		{
			this.method_1();
		}

		// Token: 0x04000CAE RID: 3246
		private readonly Type type_0;

		// Token: 0x04000CAF RID: 3247
		private readonly object object_0;
	}
}
