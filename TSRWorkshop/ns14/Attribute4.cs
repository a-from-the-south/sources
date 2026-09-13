using System;
using System.Drawing;
using System.Reflection;

namespace ns14
{
	// Token: 0x02000176 RID: 374
	[AttributeUsage(AttributeTargets.Field)]
	internal sealed class Attribute4 : Attribute
	{
		// Token: 0x0600118A RID: 4490 RVA: 0x00009528 File Offset: 0x00007728
		public Attribute4(Type providerType, string propertyName) : this(providerType.FullName, propertyName)
		{
		}

		// Token: 0x0600118B RID: 4491 RVA: 0x00009537 File Offset: 0x00007737
		public Attribute4(string providerTypeName, string propertyName)
		{
			this.providerTypeName = providerTypeName;
			this.propertyName = propertyName;
		}

		// Token: 0x170003D5 RID: 981
		// (get) Token: 0x0600118C RID: 4492 RVA: 0x000BCAB8 File Offset: 0x000BACB8
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

		// Token: 0x170003D6 RID: 982
		// (get) Token: 0x0600118D RID: 4493 RVA: 0x000BCAF0 File Offset: 0x000BACF0
		public string PropertyName
		{
			get
			{
				return this.propertyName;
			}
		}

		// Token: 0x0600118E RID: 4494 RVA: 0x000BCB08 File Offset: 0x000BAD08
		public Image method_0()
		{
			PropertyInfo property = this.ProviderType.GetProperty(this.PropertyName);
			Image result;
			if (property != null)
			{
				result = (property.GetValue(null, null) as Image);
			}
			else
			{
				result = null;
			}
			return result;
		}

		// Token: 0x04000C0B RID: 3083
		private string providerTypeName;

		// Token: 0x04000C0C RID: 3084
		private string propertyName;
	}
}
