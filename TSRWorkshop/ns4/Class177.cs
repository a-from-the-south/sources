using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Drawing.Imaging;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using ns12;
using ns6;

namespace ns4
{
	// Token: 0x02000186 RID: 390
	internal sealed class Class177 : UITypeEditor, IMessageFilter
	{
		// Token: 0x060011E1 RID: 4577 RVA: 0x00037B84 File Offset: 0x00035D84
		public bool GetPaintValueSupported(ITypeDescriptorContext context)
		{
			return true;
		}

		// Token: 0x060011E2 RID: 4578 RVA: 0x000BE54C File Offset: 0x000BC74C
		public void PaintValue(PaintValueEventArgs e)
		{
			if (e.Value is Image)
			{
				Rectangle bounds = e.Bounds;
				bounds.Width--;
				bounds.Height--;
				e.Graphics.DrawRectangle(SystemPens.WindowFrame, bounds);
				e.Graphics.DrawImage((Image)e.Value, e.Bounds);
			}
		}

		// Token: 0x060011E3 RID: 4579 RVA: 0x000B6BCC File Offset: 0x000B4DCC
		public UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
		{
			return UITypeEditorEditStyle.Modal;
		}

		// Token: 0x060011E4 RID: 4580 RVA: 0x000BE5BC File Offset: 0x000BC7BC
		public object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
		{
			this.iuiservice_0 = (IUIService)provider.GetService(typeof(IUIService));
			object result;
			try
			{
				UITypeEditor uitypeEditor = (UITypeEditor)TypeDescriptor.GetEditor(typeof(Image), typeof(UITypeEditor));
				if (uitypeEditor.GetType().FullName.StartsWith("Microsoft.VisualStudio"))
				{
					result = this.method_3(uitypeEditor, context, provider, value);
					goto IL_7B;
				}
				result = this.method_0(value);
				goto IL_7B;
			}
			catch (Exception ex)
			{
				this.iuiservice_0.ShowError(ex);
			}
			return value;
			IL_7B:
			return result;
		}

		// Token: 0x060011E5 RID: 4581 RVA: 0x000BE65C File Offset: 0x000BC85C
		protected void Finalize()
		{
			try
			{
				if (this.arrayList_0.Count > 0)
				{
					foreach (object obj in this.arrayList_0)
					{
						string path = (string)obj;
						if (File.Exists(path))
						{
							File.Delete(path);
						}
						if (Directory.Exists(Path.GetDirectoryName(path)))
						{
							Directory.Delete(Path.GetDirectoryName(path));
						}
					}
					this.arrayList_0 = null;
				}
			}
			finally
			{
				base.Finalize();
			}
		}

		// Token: 0x060011E6 RID: 4582 RVA: 0x000BE704 File Offset: 0x000BC904
		private object method_0(object object_0)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();
			openFileDialog.CheckFileExists = true;
			openFileDialog.Filter = "Images (*.bmp;*.emf;*.gif;*.ico;*.jpg;*.png;*.wmf)|*.bmp;*.emf;*.gif;*.ico;*.jpg;*.png;*.wmf|All Files (*.*)|*.*";
			openFileDialog.Multiselect = false;
			openFileDialog.ShowHelp = false;
			openFileDialog.ShowReadOnly = false;
			openFileDialog.Title = "Open Image File";
			if (openFileDialog.ShowDialog(this.iuiservice_0.GetDialogOwnerWindow()) == DialogResult.OK)
			{
				Image image = this.method_1(openFileDialog.FileName);
				if (image != null)
				{
					return image;
				}
			}
			return object_0;
		}

		// Token: 0x060011E7 RID: 4583 RVA: 0x000BE778 File Offset: 0x000BC978
		private Image method_1(string string_0)
		{
			Image result;
			using (FileStream fileStream = new FileStream(string_0, FileMode.Open, FileAccess.Read, FileShare.Read))
			{
				if (!(Path.GetExtension(string_0) == ".ico"))
				{
					result = this.method_2(fileStream);
					goto IL_9A;
				}
				Class178 @class = new Class178(fileStream);
				if (@class.method_6().Length == 1)
				{
					result = @class.method_3(@class.method_6()[0]);
					goto IL_9A;
				}
				IconFormatDialog iconFormatDialog = new IconFormatDialog();
				iconFormatDialog.x7d8d2ed69d304345 = @class;
				iconFormatDialog.ShowDialog(this.iuiservice_0.GetDialogOwnerWindow());
				if (iconFormatDialog.DialogResult == DialogResult.OK)
				{
					result = @class.method_3(iconFormatDialog.x88ff53b73da867e0);
					goto IL_9A;
				}
			}
			return null;
			IL_9A:
			return result;
		}

		// Token: 0x060011E8 RID: 4584 RVA: 0x000BE838 File Offset: 0x000BCA38
		private Image method_2(Stream stream_0)
		{
			byte[] buffer = new byte[(uint)stream_0.Length];
			stream_0.Read(buffer, 0, (int)stream_0.Length);
			return Image.FromStream(new MemoryStream(buffer));
		}

		// Token: 0x060011E9 RID: 4585 RVA: 0x000BE874 File Offset: 0x000BCA74
		private object method_3(UITypeEditor uitypeEditor_0, ITypeDescriptorContext itypeDescriptorContext_0, IServiceProvider iserviceProvider_0, object object_0)
		{
			Application.AddMessageFilter(this);
			this.bool_0 = false;
			object result;
			try
			{
				result = uitypeEditor_0.EditValue(itypeDescriptorContext_0, iserviceProvider_0, object_0);
			}
			finally
			{
				Application.RemoveMessageFilter(this);
				this.method_6();
			}
			return result;
		}

		// Token: 0x060011EA RID: 4586 RVA: 0x000BE8C0 File Offset: 0x000BCAC0
		public bool PreFilterMessage(ref Message m)
		{
			try
			{
				if (!this.bool_0)
				{
					Form form = Control.FromHandle(m.HWnd) as Form;
					if (form != null && form.GetType().FullName.StartsWith("Microsoft.VisualStudio.Windows.Forms.ResourcePickerDialog"))
					{
						this.method_5(form);
					}
				}
			}
			catch (Exception ex)
			{
				this.iuiservice_0.ShowError(ex);
			}
			return false;
		}

		// Token: 0x060011EB RID: 4587 RVA: 0x000BE930 File Offset: 0x000BCB30
		private OpenFileDialog method_4(Form form_1)
		{
			PropertyInfo property = form_1.GetType().GetProperty("OpenFileDialog", BindingFlags.Instance | BindingFlags.NonPublic);
			OpenFileDialog result;
			if (property != null)
			{
				result = (property.GetValue(form_1, null) as OpenFileDialog);
			}
			else
			{
				result = null;
			}
			return result;
		}

		// Token: 0x060011EC RID: 4588 RVA: 0x000BE968 File Offset: 0x000BCB68
		private void method_5(Form form_1)
		{
			this.form_0 = form_1;
			this.bool_0 = true;
			OpenFileDialog openFileDialog = this.method_4(this.form_0);
			if (openFileDialog != null)
			{
				openFileDialog.Filter = openFileDialog.Filter.Replace("*.gif", "*.ico;*.gif");
				openFileDialog.FileOk += this.method_7;
			}
		}

		// Token: 0x060011ED RID: 4589 RVA: 0x000BE9C4 File Offset: 0x000BCBC4
		private void method_6()
		{
			if (this.form_0 != null)
			{
				OpenFileDialog openFileDialog = this.method_4(this.form_0);
				if (openFileDialog != null)
				{
					openFileDialog.Filter = openFileDialog.Filter.Replace("*.ico;*.gif", "*.gif");
					openFileDialog.FileOk -= this.method_7;
				}
				this.form_0 = null;
			}
		}

		// Token: 0x060011EE RID: 4590 RVA: 0x000BEA20 File Offset: 0x000BCC20
		private void method_7(object sender, CancelEventArgs e)
		{
			try
			{
				OpenFileDialog openFileDialog = sender as OpenFileDialog;
				string[] fileNames = openFileDialog.FileNames;
				for (int i = 0; i < fileNames.Length; i++)
				{
					string text = fileNames[i];
					if (Path.GetExtension(text) == ".ico")
					{
						Image image = this.method_1(text);
						if (image == null)
						{
							e.Cancel = true;
							return;
						}
						string text2 = this.method_8(Path.GetFileName(text));
						try
						{
							image.Save(text2, ImageFormat.Png);
							this.arrayList_0.Add(text2);
							fileNames[i] = text2;
						}
						catch (Exception ex)
						{
							this.iuiservice_0.ShowError(ex);
							e.Cancel = true;
							return;
						}
					}
				}
				if (this.arrayList_0.Count > 0)
				{
					FieldInfo field = typeof(FileDialog).GetField("fileNames", BindingFlags.Instance | BindingFlags.NonPublic);
					if (field != null)
					{
						field.SetValue(openFileDialog, fileNames);
					}
				}
			}
			catch (Exception ex2)
			{
				this.iuiservice_0.ShowError(ex2.ToString());
			}
		}

		// Token: 0x060011EF RID: 4591 RVA: 0x000BEB2C File Offset: 0x000BCD2C
		private string method_8(string string_0)
		{
			string tempFileName = Path.GetTempFileName();
			File.Delete(tempFileName);
			DirectoryInfo directoryInfo = Directory.CreateDirectory(Path.Combine(Path.GetTempPath(), tempFileName));
			return Path.Combine(directoryInfo.FullName, Path.ChangeExtension(string_0, ".png"));
		}

		// Token: 0x04000C5F RID: 3167
		private IUIService iuiservice_0;

		// Token: 0x04000C60 RID: 3168
		private bool bool_0;

		// Token: 0x04000C61 RID: 3169
		private Form form_0;

		// Token: 0x04000C62 RID: 3170
		private ArrayList arrayList_0 = new ArrayList();
	}
}
