using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Package.Sims3Files;

namespace ns12
{
	// Token: 0x0200004B RID: 75
	internal sealed partial class ObjdVersionDialog : Form
	{
		// Token: 0x1700006D RID: 109
		// (get) Token: 0x060002EC RID: 748 RVA: 0x00037F6C File Offset: 0x0003616C
		// (set) Token: 0x060002ED RID: 749 RVA: 0x00037F84 File Offset: 0x00036184
		public uint Version
		{
			get
			{
				return this.uint_0;
			}
			set
			{
				this.uint_0 = value;
				foreach (object obj in base.Controls)
				{
					if (obj.GetType() == typeof(CheckBox))
					{
						CheckBox checkBox = obj as CheckBox;
						if (checkBox.Tag != null)
						{
							int num = int.Parse(checkBox.Tag as string);
							if ((long)num < (long)((ulong)this.Version))
							{
								checkBox.Enabled = false;
								checkBox.Checked = true;
							}
							else
							{
								checkBox.Enabled = true;
								checkBox.Checked = ((long)num == (long)((ulong)this.Version));
							}
						}
					}
				}
			}
		}

		// Token: 0x060002EE RID: 750 RVA: 0x00003AEC File Offset: 0x00001CEC
		public ObjdVersionDialog(OBJD objd)
		{
			this.InitializeComponent();
			this.objd = objd;
			this.bool_0 = true;
			this.Version = this.objd.Version;
			this.bool_0 = false;
		}

		// Token: 0x060002EF RID: 751 RVA: 0x00002BF8 File Offset: 0x00000DF8
		private void okButton_Click(object sender, EventArgs e)
		{
			base.DialogResult = DialogResult.OK;
			base.Close();
		}

		// Token: 0x060002F0 RID: 752 RVA: 0x00002AC2 File Offset: 0x00000CC2
		private void cancelButton_Click(object sender, EventArgs e)
		{
			base.DialogResult = DialogResult.Cancel;
			base.Close();
		}

		// Token: 0x060002F1 RID: 753 RVA: 0x00002A71 File Offset: 0x00000C71
		private void ObjdVersionDialog_Load(object sender, EventArgs e)
		{
		}

		// Token: 0x060002F2 RID: 754 RVA: 0x00038044 File Offset: 0x00036244
		private void v022_CheckedChanged(object sender, EventArgs e)
		{
			if (!this.bool_0)
			{
				this.bool_0 = true;
				CheckBox checkBox = sender as CheckBox;
				if (checkBox.Checked)
				{
					this.Version = (uint)int.Parse(checkBox.Tag as string);
				}
				else
				{
					uint num = (uint)int.Parse(checkBox.Tag as string);
					uint num2 = 0U;
					foreach (object obj in base.Controls)
					{
						if (obj.GetType() == typeof(CheckBox))
						{
							CheckBox checkBox2 = obj as CheckBox;
							uint num3 = uint.Parse(checkBox2.Tag as string);
							if (num3 < num)
							{
								num2 = Math.Max(num2, num3);
							}
						}
					}
					this.Version = num2;
				}
				this.bool_0 = false;
			}
		}

		// Token: 0x060002F3 RID: 755 RVA: 0x00003B22 File Offset: 0x00001D22
		protected void Dispose(bool disposing)
		{
			if (disposing && this.icontainer_0 != null)
			{
				this.icontainer_0.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x04000294 RID: 660
		private uint uint_0;

		// Token: 0x04000295 RID: 661
		private OBJD objd;

		// Token: 0x04000296 RID: 662
		private bool bool_0;

		// Token: 0x04000297 RID: 663
		private IContainer icontainer_0;
	}
}
