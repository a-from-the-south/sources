using System;
using System.Drawing;
using System.Windows.Forms;
using ns13;
using VisualHint.SmartPropertyGrid;

namespace ns1
{
	// Token: 0x02000004 RID: 4
	internal class Class0 : VisualHint.SmartPropertyGrid.PropertyGrid
	{
		// Token: 0x0600000C RID: 12 RVA: 0x00002919 File Offset: 0x00000B19
		public Class0()
		{
			base.BorderStyle = BorderStyle.None;
		}

		// Token: 0x0600000D RID: 13 RVA: 0x0000B910 File Offset: 0x00009B10
		protected override void OnCreateControl()
		{
			Class66 @class = new Class66();
			base.DrawingManager = VisualHint.SmartPropertyGrid.PropertyGrid.DrawManagers.CustomDrawManager;
			base.DrawManager = @class;
			base.GridColor = Color.FromArgb(199, 221, 167);
			base.SelectedBackColor = Color.FromArgb(74, 88, 43);
			@class.SubCategoryBkgColor1 = Color.FromArgb(233, 246, 219);
			@class.CategoryBkgColor1 = Color.FromArgb(199, 221, 167);
			@class.CategoryBkgColor2 = @class.CategoryBkgColor1;
			@class.SubCategoryBkgColor2 = @class.SubCategoryBkgColor1;
			@class.UseBoldFontForCategories = true;
			base.OnCreateControl();
		}
	}
}
