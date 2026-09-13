using System;
using System.ComponentModel;
using System.Drawing.Design;
using ns10;

namespace ns20
{
	// Token: 0x0200016E RID: 366
	[Editor(typeof(Class169), typeof(UITypeEditor))]
	internal enum Enum24
	{
		// Token: 0x04000BDF RID: 3039
		[Description("Tips are animated when it is supported by the operating system and window animation is enabled.")]
		const_0,
		// Token: 0x04000BE0 RID: 3040
		[Description("Tips are not animated.")]
		const_1,
		// Token: 0x04000BE1 RID: 3041
		[Description("Tips are always animated if it is supported by the operating system.")]
		const_2
	}
}
