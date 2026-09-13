using System;

namespace ns3
{
	// Token: 0x0200015E RID: 350
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct)]
	internal sealed class Attribute2 : Attribute
	{
		// Token: 0x0600106E RID: 4206 RVA: 0x000089E2 File Offset: 0x00006BE2
		public Attribute2(string friendlyName)
		{
			this.friendlyName = friendlyName;
		}

		// Token: 0x17000399 RID: 921
		// (get) Token: 0x0600106F RID: 4207 RVA: 0x000B9A90 File Offset: 0x000B7C90
		public string FriendlyName
		{
			get
			{
				return this.friendlyName;
			}
		}

		// Token: 0x06001070 RID: 4208 RVA: 0x000B9AA8 File Offset: 0x000B7CA8
		public static string smethod_0(Type type_0)
		{
			object[] customAttributes = type_0.GetCustomAttributes(typeof(Attribute2), false);
			string fullName;
			if (customAttributes != null && customAttributes.Length != 0)
			{
				fullName = (customAttributes[0] as Attribute2).FriendlyName;
			}
			else
			{
				fullName = type_0.FullName;
			}
			return fullName;
		}

		// Token: 0x04000B97 RID: 2967
		private string friendlyName;
	}
}
