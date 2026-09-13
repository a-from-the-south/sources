using System;
using System.ComponentModel;
using System.Drawing.Design;
using ns10;

namespace ns1
{
	// Token: 0x02000177 RID: 375
	[Editor(typeof(Class169), typeof(UITypeEditor))]
	internal enum Enum26
	{
		// Token: 0x04000C0E RID: 3086
		[Description("A soft shadow is displayed when it is supported by the operating system and window shadows are enabled.")]
		const_0,
		// Token: 0x04000C0F RID: 3087
		[Description("No soft shadows are displayed.")]
		const_1,
		// Token: 0x04000C10 RID: 3088
		[Description("A soft shadow is always displayed when it is supported by the operating system.")]
		const_2
	}
}
