using System;
using System.Collections;
using System.Windows.Forms;
using ns7;

namespace ns3
{
	// Token: 0x02000047 RID: 71
	internal sealed class Class37 : IComparer
	{
		// Token: 0x060002CD RID: 717 RVA: 0x00037AE0 File Offset: 0x00035CE0
		public int Compare(object x, object y)
		{
			Class36 @class = (x as TreeNode).Tag as Class36;
			Class36 class2 = (y as TreeNode).Tag as Class36;
			int result;
			if (@class != null && class2 != null)
			{
				result = (int)(@class.AgeMask - class2.AgeMask + (@class.CategoryMask - class2.CategoryMask));
			}
			else
			{
				result = 0;
			}
			return result;
		}
	}
}
