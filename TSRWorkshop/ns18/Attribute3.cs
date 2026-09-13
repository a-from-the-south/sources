using System;

namespace ns18
{
	// Token: 0x02000175 RID: 373
	[AttributeUsage(AttributeTargets.Property)]
	internal sealed class Attribute3 : Attribute
	{
		// Token: 0x06001187 RID: 4487 RVA: 0x00009509 File Offset: 0x00007709
		public Attribute3(Type providerType) : this(providerType.FullName)
		{
		}

		// Token: 0x06001188 RID: 4488 RVA: 0x00009517 File Offset: 0x00007717
		public Attribute3(string providerTypeName)
		{
			this.providerTypeName = providerTypeName;
		}

		// Token: 0x170003D4 RID: 980
		// (get) Token: 0x06001189 RID: 4489 RVA: 0x000BCA80 File Offset: 0x000BAC80
		public Type ProviderType
		{
			get
			{
				Type result;
				if (this.providerTypeName != null && this.providerTypeName.Length != 0)
				{
					result = Type.GetType(this.providerTypeName);
				}
				else
				{
					result = null;
				}
				return result;
			}
		}

		// Token: 0x04000C0A RID: 3082
		private string providerTypeName;
	}
}
