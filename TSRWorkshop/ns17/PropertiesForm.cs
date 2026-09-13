using System;
using System.ComponentModel;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using ns13;
using VisualHint.SmartPropertyGrid;

namespace ns17
{
	// Token: 0x0200013A RID: 314
	internal sealed class PropertiesForm : UserControl
	{
		// Token: 0x1400002F RID: 47
		// (add) Token: 0x06000F67 RID: 3943 RVA: 0x000B673C File Offset: 0x000B493C
		// (remove) Token: 0x06000F68 RID: 3944 RVA: 0x000B6774 File Offset: 0x000B4974
		public event PropertiesForm.Delegate29 MeshPropertyChanged
		{
			add
			{
				PropertiesForm.Delegate29 @delegate = this.delegate29_0;
				PropertiesForm.Delegate29 delegate2;
				do
				{
					delegate2 = @delegate;
					PropertiesForm.Delegate29 value2 = (PropertiesForm.Delegate29)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<PropertiesForm.Delegate29>(ref this.delegate29_0, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			remove
			{
				PropertiesForm.Delegate29 @delegate = this.delegate29_0;
				PropertiesForm.Delegate29 delegate2;
				do
				{
					delegate2 = @delegate;
					PropertiesForm.Delegate29 value2 = (PropertiesForm.Delegate29)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<PropertiesForm.Delegate29>(ref this.delegate29_0, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		// Token: 0x06000F69 RID: 3945 RVA: 0x000081C7 File Offset: 0x000063C7
		public PropertiesForm()
		{
			this.InitializeComponent();
		}

		// Token: 0x17000373 RID: 883
		// (get) Token: 0x06000F6A RID: 3946 RVA: 0x000B67AC File Offset: 0x000B49AC
		// (set) Token: 0x06000F6B RID: 3947 RVA: 0x000081D7 File Offset: 0x000063D7
		public VisualHint.SmartPropertyGrid.PropertyGrid PropertyGrid
		{
			get
			{
				return this.propertyGrid1;
			}
			set
			{
				this.propertyGrid1 = value;
			}
		}

		// Token: 0x17000374 RID: 884
		// (get) Token: 0x06000F6C RID: 3948 RVA: 0x000B67C4 File Offset: 0x000B49C4
		// (set) Token: 0x06000F6D RID: 3949 RVA: 0x000081E2 File Offset: 0x000063E2
		public object SelectedObject
		{
			get
			{
				return this.propertyGrid1.SelectedObject;
			}
			set
			{
				this.propertyGrid1.SelectedObject = value;
			}
		}

		// Token: 0x06000F6E RID: 3950 RVA: 0x000081F2 File Offset: 0x000063F2
		private void method_0(object sender, PropertyValueChangedEventArgs e)
		{
			if (this.delegate29_0 != null)
			{
				this.delegate29_0(new PropertiesForm.EventArgs4(this.propertyGrid1.SelectedObject));
			}
		}

		// Token: 0x06000F6F RID: 3951 RVA: 0x00008219 File Offset: 0x00006419
		protected void Dispose(bool disposing)
		{
			if (disposing && this.icontainer_0 != null)
			{
				this.icontainer_0.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000F70 RID: 3952 RVA: 0x000B67E0 File Offset: 0x000B49E0
		private void InitializeComponent()
		{
			this.icontainer_0 = new Container();
			this.contextMenuStrip1 = new ContextMenuStrip(this.icontainer_0);
			this.moveUpMenuItem = new ToolStripMenuItem();
			this.moveDownMenuItem = new ToolStripMenuItem();
			this.deleteToolStripMenuItem = new ToolStripMenuItem();
			this.panel2 = new Panel();
			this.panel3 = new Panel();
			this.propertyGrid1 = new Class57();
			this.contextMenuStrip1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.panel3.SuspendLayout();
			((ISupportInitialize)this.propertyGrid1).BeginInit();
			base.SuspendLayout();
			this.contextMenuStrip1.Items.AddRange(new ToolStripItem[]
			{
				this.moveUpMenuItem,
				this.moveDownMenuItem,
				this.deleteToolStripMenuItem
			});
			this.contextMenuStrip1.Name = "contextMenuStrip1";
			this.contextMenuStrip1.Size = new Size(139, 70);
			this.moveUpMenuItem.Name = "moveUpMenuItem";
			this.moveUpMenuItem.Size = new Size(138, 22);
			this.moveUpMenuItem.Text = "Move Up";
			this.moveDownMenuItem.Name = "moveDownMenuItem";
			this.moveDownMenuItem.Size = new Size(138, 22);
			this.moveDownMenuItem.Text = "Move Down";
			this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
			this.deleteToolStripMenuItem.Size = new Size(138, 22);
			this.deleteToolStripMenuItem.Text = "Delete";
			this.panel2.Controls.Add(this.panel3);
			this.panel2.Dock = DockStyle.Fill;
			this.panel2.Location = new Point(0, 0);
			this.panel2.Name = "panel2";
			this.panel2.Size = new Size(267, 379);
			this.panel2.TabIndex = 3;
			this.panel3.Controls.Add(this.propertyGrid1);
			this.panel3.Dock = DockStyle.Fill;
			this.panel3.Location = new Point(0, 0);
			this.panel3.Name = "panel3";
			this.panel3.Size = new Size(267, 379);
			this.panel3.TabIndex = 2;
			this.propertyGrid1.BorderStyle = BorderStyle.None;
			this.propertyGrid1.CommentsHeight = 70;
			this.propertyGrid1.CommentsVisibility = true;
			this.propertyGrid1.Dock = DockStyle.Fill;
			this.propertyGrid1.Location = new Point(0, 0);
			this.propertyGrid1.Name = "propertyGrid1";
			this.propertyGrid1.NavigationKeyMode = VisualHint.SmartPropertyGrid.PropertyGrid.NavigationKeyModes.TabKey;
			this.propertyGrid1.PropertyLabelBackColor = SystemColors.Window;
			this.propertyGrid1.PropertyValueBackColor = SystemColors.Window;
			this.propertyGrid1.ShowDefaultValues = true;
			this.propertyGrid1.Size = new Size(267, 379);
			this.propertyGrid1.TabIndex = 0;
			this.propertyGrid1.Text = "myPropertyGrid1";
			this.propertyGrid1.ToolTipMode = VisualHint.SmartPropertyGrid.PropertyGrid.ToolTipModes.ToolTipsOnLabels;
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.Font;
			base.Controls.Add(this.panel2);
			this.MinimumSize = new Size(8, 200);
			base.Name = "PropertiesForm";
			base.Size = new Size(267, 379);
			this.contextMenuStrip1.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.panel3.ResumeLayout(false);
			((ISupportInitialize)this.propertyGrid1).EndInit();
			base.ResumeLayout(false);
		}

		// Token: 0x04000B13 RID: 2835
		private PropertiesForm.Delegate29 delegate29_0;

		// Token: 0x04000B14 RID: 2836
		private IContainer icontainer_0;

		// Token: 0x04000B15 RID: 2837
		private ContextMenuStrip contextMenuStrip1;

		// Token: 0x04000B16 RID: 2838
		private ToolStripMenuItem deleteToolStripMenuItem;

		// Token: 0x04000B17 RID: 2839
		private Panel panel2;

		// Token: 0x04000B18 RID: 2840
		private Panel panel3;

		// Token: 0x04000B19 RID: 2841
		private ToolStripMenuItem moveUpMenuItem;

		// Token: 0x04000B1A RID: 2842
		private ToolStripMenuItem moveDownMenuItem;

		// Token: 0x04000B1B RID: 2843
		private VisualHint.SmartPropertyGrid.PropertyGrid propertyGrid1;

		// Token: 0x0200013B RID: 315
		public sealed class EventArgs4 : EventArgs
		{
			// Token: 0x06000F71 RID: 3953 RVA: 0x0000823A File Offset: 0x0000643A
			public EventArgs4(object item)
			{
				this.item = item;
			}

			// Token: 0x17000375 RID: 885
			// (get) Token: 0x06000F72 RID: 3954 RVA: 0x000B6BB4 File Offset: 0x000B4DB4
			public object Items
			{
				get
				{
					return this.item;
				}
			}

			// Token: 0x04000B1C RID: 2844
			public object item;
		}

		// Token: 0x0200013C RID: 316
		// (Invoke) Token: 0x06000F74 RID: 3956
		public delegate void Delegate29(PropertiesForm.EventArgs4 e);
	}
}
