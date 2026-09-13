using System;
using System.Drawing;
using System.Windows.Forms;
using ns17;
using VisualHint.SmartPropertyGrid;

namespace ns7
{
	// Token: 0x0200008D RID: 141
	internal sealed class Class58 : PropertyFeel
	{
		// Token: 0x060005AA RID: 1450 RVA: 0x00004D7C File Offset: 0x00002F7C
		public Class58(VisualHint.SmartPropertyGrid.PropertyGrid grid, bool editable) : base(grid)
		{
			this.editable = editable;
		}

		// Token: 0x060005AB RID: 1451 RVA: 0x0005B57C File Offset: 0x0005977C
		public bool DontShowInPlaceCtrl(PropertyEnumerator propEnum)
		{
			bool result;
			if (propEnum.Property.Value.IsReadOnly(propEnum))
			{
				result = !this.editable;
			}
			else
			{
				result = false;
			}
			return result;
		}

		// Token: 0x060005AC RID: 1452 RVA: 0x0005B5B0 File Offset: 0x000597B0
		public Control ShowControl(Rectangle valueRect, PropertyEnumerator propEnum)
		{
			Control result;
			if (propEnum.Property.Value.IsReadOnly(propEnum) && !this.editable)
			{
				result = null;
			}
			else
			{
				Class59 @class;
				if (this.mInPlaceCtrl == null)
				{
					@class = new Class59(this.editable);
					@class.Text = "Edit";
					@class.Visible = true;
					@class.Parent = this.mParentWnd;
					this.mInPlaceCtrl = @class;
				}
				else
				{
					@class = (Class59)this.mInPlaceCtrl;
				}
				base.NotifyInPlaceControlCreated(propEnum);
				@class.OwnerPropertyEnumerator = propEnum;
				@class.Font = propEnum.Property.Value.Font;
				this.MoveControl(valueRect, propEnum);
				result = base.ShowControl(valueRect, propEnum);
			}
			return result;
		}

		// Token: 0x04000524 RID: 1316
		private bool editable;
	}
}
