using System;
using System.IO;
using System.Reflection;
using System.Security.Cryptography;

namespace ns16
{
	// Token: 0x020001A1 RID: 417
	internal sealed class Class185 : IDisposable
	{
		// Token: 0x06001252 RID: 4690 RVA: 0x000C055C File Offset: 0x000BE75C
		public Class185()
		{
			try
			{
				Assembly assembly = Assembly.Load("System.Core, Version=2.0.5.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e");
				this.type_0 = assembly.GetType("System.Security.Cryptography.AesManaged");
			}
			catch (FileNotFoundException)
			{
				Assembly assembly = Assembly.Load("mscorlib");
				this.type_0 = assembly.GetType("System.Security.Cryptography.RijndaelManaged");
			}
			this.object_0 = Activator.CreateInstance(this.type_0);
		}

		// Token: 0x06001253 RID: 4691 RVA: 0x000C05D0 File Offset: 0x000BE7D0
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

		// Token: 0x06001254 RID: 4692 RVA: 0x00009A56 File Offset: 0x00007C56
		public void method_1()
		{
			this.type_0.GetMethod("Clear").Invoke(this.object_0, new object[0]);
		}

		// Token: 0x06001255 RID: 4693 RVA: 0x00009A7C File Offset: 0x00007C7C
		public void Dispose()
		{
			this.method_1();
		}

		// Token: 0x04000CAC RID: 3244
		private readonly Type type_0;

		// Token: 0x04000CAD RID: 3245
		private readonly object object_0;
	}
}
