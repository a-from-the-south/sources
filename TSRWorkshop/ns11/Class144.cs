using System;
using System.ComponentModel;
using System.Drawing.Design;
using ns3;

namespace ns11
{
	// Token: 0x0200013D RID: 317
	internal sealed class Class144 : UITypeEditor
	{
		// Token: 0x06000F77 RID: 3959 RVA: 0x000B6BCC File Offset: 0x000B4DCC
		public UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
		{
			return UITypeEditorEditStyle.Modal;
		}

		// Token: 0x06000F78 RID: 3960 RVA: 0x000B6BE0 File Offset: 0x000B4DE0
		public object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
		{
			this.propertyDescriptor_0 = context.PropertyDescriptor;
			return base.EditValue(context, provider, "");
		}

		// Token: 0x06000F79 RID: 3961 RVA: 0x00002A71 File Offset: 0x00000C71
		private void method_0()
		{
		}

		// Token: 0x06000F7A RID: 3962 RVA: 0x00002A71 File Offset: 0x00000C71
		private void method_1(object sender, DropdownSlider.EventArgs0 e)
		{
		}

		// Token: 0x06000F7B RID: 3963 RVA: 0x00024BE0 File Offset: 0x00022DE0
		public bool GetPaintValueSupported(ITypeDescriptorContext context)
		{
			return false;
		}

		// Token: 0x06000F7C RID: 3964 RVA: 0x000B6C0C File Offset: 0x000B4E0C
		public string ToString()
		{
			return base.ToString();
		}

		// Token: 0x04000B1D RID: 2845
		private PropertyDescriptor propertyDescriptor_0;
	}
}
