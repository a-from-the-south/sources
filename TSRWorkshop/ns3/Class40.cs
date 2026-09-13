using System;
using System.Collections;
using System.Windows.Forms;
using ns5;

namespace ns3
{
	// Token: 0x0200004A RID: 74
	internal sealed class Class40 : IComparer
	{
		// Token: 0x060002EA RID: 746 RVA: 0x00037F20 File Offset: 0x00036120
		public int Compare(object x, object y)
		{
			Class39 @class = (x as TreeNode).Tag as Class39;
			Class39 class2 = (y as TreeNode).Tag as Class39;
			int result;
			if (@class.All == 0)
			{
				result = 1;
			}
			else
			{
				result = (int)(@class.BuildMask - class2.BuildMask);
			}
			return result;
		}
	}
}
