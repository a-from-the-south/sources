using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using ns13;
using ns16;
using ns17;
using ns18;

namespace ns19
{
	// Token: 0x02000160 RID: 352
	internal sealed class Class162 : UITypeEditor
	{
		// Token: 0x060010BB RID: 4283 RVA: 0x000BA2A8 File Offset: 0x000B84A8
		public UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
		{
			return UITypeEditorEditStyle.DropDown;
		}

		// Token: 0x060010BC RID: 4284 RVA: 0x000BA2BC File Offset: 0x000B84BC
		public object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
		{
			this.iwindowsFormsEditorService_0 = (provider.GetService(typeof(IWindowsFormsEditorService)) as IWindowsFormsEditorService);
			Class161 @class = value as Class161;
			Control control = new Control();
			if (@class.method_9())
			{
				this.class163_0 = @class.Provider.Renderer.method_9(@class);
				this.class163_0.method_0(8, 8);
				this.class161_0 = @class;
				control.Size = this.class163_0.method_2() + new Size(16, 16);
				control.Paint += this.method_0;
				control.MouseDown += this.method_1;
			}
			else
			{
				control.Size = new Size(144, 28);
				control.Paint += this.method_2;
			}
			this.iwindowsFormsEditorService_0.DropDownControl(control);
			return value;
		}

		// Token: 0x060010BD RID: 4285 RVA: 0x000BA3A0 File Offset: 0x000B85A0
		private void method_0(object sender, PaintEventArgs e)
		{
			this.class164_0.method_0(e.Graphics, e.ClipRectangle);
			this.class164_0.xbc626ed723e04991.Clear(Color.White);
			this.class161_0.Provider.Renderer.method_12(new PaintEventArgs(this.class164_0.xbc626ed723e04991, e.ClipRectangle), this.class161_0, this.class163_0);
			this.class164_0.method_3();
		}

		// Token: 0x060010BE RID: 4286 RVA: 0x00008DC1 File Offset: 0x00006FC1
		private void method_1(object sender, MouseEventArgs e)
		{
			this.iwindowsFormsEditorService_0.CloseDropDown();
		}

		// Token: 0x060010BF RID: 4287 RVA: 0x000BA420 File Offset: 0x000B8620
		private void method_2(object sender, PaintEventArgs e)
		{
			this.class164_0.method_0(e.Graphics, e.ClipRectangle);
			this.class164_0.xbc626ed723e04991.Clear(SystemColors.Control);
			using (Font font = new Font("Tahoma", 8f))
			{
				Class148.smethod_0(this.class164_0.xbc626ed723e04991, "No VisualTip will be displayed\r\nfor this component.", font, SystemColors.ControlText, SystemColors.Control, (sender as Control).ClientRectangle, Enum25.const_7);
			}
			this.class164_0.method_3();
		}

		// Token: 0x04000B9F RID: 2975
		private Class161 class161_0;

		// Token: 0x04000BA0 RID: 2976
		private Class163 class163_0;

		// Token: 0x04000BA1 RID: 2977
		private IWindowsFormsEditorService iwindowsFormsEditorService_0;

		// Token: 0x04000BA2 RID: 2978
		private Class164 class164_0 = new Class164();
	}
}
