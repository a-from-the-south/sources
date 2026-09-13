using System;
using System.ComponentModel;
using System.Drawing.Design;

namespace ns10
{
	// Token: 0x02000178 RID: 376
	[Editor(typeof(Class169), typeof(UITypeEditor))]
	internal enum Enum27
	{
		// Token: 0x04000C12 RID: 3090
		[Description("Tips are displayed when the mouse hovers over the tool area.")]
		const_0,
		// Token: 0x04000C13 RID: 3091
		[Description("Tips are displayed when F1 is pressed or the dialog box help button is used.")]
		const_1,
		// Token: 0x04000C14 RID: 3092
		[Description("Tips must be displayed manually by calling VisualTipProvider.ShowTip.")]
		const_2
	}
}
