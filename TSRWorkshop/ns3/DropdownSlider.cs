using System;
using System.ComponentModel;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace ns3
{
	// Token: 0x02000072 RID: 114
	internal sealed class DropdownSlider : UserControl
	{
		// Token: 0x14000015 RID: 21
		// (add) Token: 0x06000461 RID: 1121 RVA: 0x0004A3F0 File Offset: 0x000485F0
		// (remove) Token: 0x06000462 RID: 1122 RVA: 0x0004A428 File Offset: 0x00048628
		public event DropdownSlider.Delegate12 ValueChanged
		{
			add
			{
				DropdownSlider.Delegate12 @delegate = this.delegate12_0;
				DropdownSlider.Delegate12 delegate2;
				do
				{
					delegate2 = @delegate;
					DropdownSlider.Delegate12 value2 = (DropdownSlider.Delegate12)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<DropdownSlider.Delegate12>(ref this.delegate12_0, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			remove
			{
				DropdownSlider.Delegate12 @delegate = this.delegate12_0;
				DropdownSlider.Delegate12 delegate2;
				do
				{
					delegate2 = @delegate;
					DropdownSlider.Delegate12 value2 = (DropdownSlider.Delegate12)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<DropdownSlider.Delegate12>(ref this.delegate12_0, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		// Token: 0x14000016 RID: 22
		// (add) Token: 0x06000463 RID: 1123 RVA: 0x0004A460 File Offset: 0x00048660
		// (remove) Token: 0x06000464 RID: 1124 RVA: 0x0004A498 File Offset: 0x00048698
		public event DropdownSlider.Delegate11 CloseMe
		{
			add
			{
				DropdownSlider.Delegate11 @delegate = this.delegate11_0;
				DropdownSlider.Delegate11 delegate2;
				do
				{
					delegate2 = @delegate;
					DropdownSlider.Delegate11 value2 = (DropdownSlider.Delegate11)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<DropdownSlider.Delegate11>(ref this.delegate11_0, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			remove
			{
				DropdownSlider.Delegate11 @delegate = this.delegate11_0;
				DropdownSlider.Delegate11 delegate2;
				do
				{
					delegate2 = @delegate;
					DropdownSlider.Delegate11 value2 = (DropdownSlider.Delegate11)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<DropdownSlider.Delegate11>(ref this.delegate11_0, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		// Token: 0x06000465 RID: 1125 RVA: 0x0000462A File Offset: 0x0000282A
		public DropdownSlider()
		{
			this.InitializeComponent();
		}

		// Token: 0x06000466 RID: 1126 RVA: 0x0000463A File Offset: 0x0000283A
		public void method_0(int int_0)
		{
			this.trackBar.Minimum = int_0;
		}

		// Token: 0x06000467 RID: 1127 RVA: 0x0000464A File Offset: 0x0000284A
		public void method_1(int int_0)
		{
			this.trackBar.Maximum = int_0;
		}

		// Token: 0x06000468 RID: 1128 RVA: 0x0000465A File Offset: 0x0000285A
		public void method_2(int int_0)
		{
			this.trackBar.Value = int_0;
		}

		// Token: 0x06000469 RID: 1129 RVA: 0x0004A4D0 File Offset: 0x000486D0
		public int method_3()
		{
			return this.trackBar.Value;
		}

		// Token: 0x0600046A RID: 1130 RVA: 0x0000466A File Offset: 0x0000286A
		private void trackBar_ValueChanged(object sender, EventArgs e)
		{
			if (this.delegate12_0 != null)
			{
				this.delegate12_0(this.trackBar, new DropdownSlider.EventArgs0(this.trackBar.Value));
			}
		}

		// Token: 0x0600046B RID: 1131 RVA: 0x00004697 File Offset: 0x00002897
		private void trackBar_MouseUp(object sender, MouseEventArgs e)
		{
			if (this.delegate11_0 != null)
			{
				this.delegate11_0();
			}
		}

		// Token: 0x0600046C RID: 1132 RVA: 0x000046AE File Offset: 0x000028AE
		protected void Dispose(bool disposing)
		{
			if (disposing && this.icontainer_0 != null)
			{
				this.icontainer_0.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x0600046D RID: 1133 RVA: 0x0004A4EC File Offset: 0x000486EC
		private void InitializeComponent()
		{
			this.trackBar = new TrackBar();
			((ISupportInitialize)this.trackBar).BeginInit();
			base.SuspendLayout();
			this.trackBar.Dock = DockStyle.Fill;
			this.trackBar.Location = new Point(8, 8);
			this.trackBar.Maximum = 100;
			this.trackBar.Name = "trackBar";
			this.trackBar.Size = new Size(150, 22);
			this.trackBar.TabIndex = 0;
			this.trackBar.TickStyle = TickStyle.None;
			this.trackBar.ValueChanged += this.trackBar_ValueChanged;
			this.trackBar.MouseUp += this.trackBar_MouseUp;
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.Font;
			base.Controls.Add(this.trackBar);
			base.Name = "DropdownSlider";
			base.Padding = new Padding(8);
			base.Size = new Size(166, 38);
			((ISupportInitialize)this.trackBar).EndInit();
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x0400041A RID: 1050
		private DropdownSlider.Delegate12 delegate12_0;

		// Token: 0x0400041B RID: 1051
		private DropdownSlider.Delegate11 delegate11_0;

		// Token: 0x0400041C RID: 1052
		private IContainer icontainer_0;

		// Token: 0x0400041D RID: 1053
		private TrackBar trackBar;

		// Token: 0x02000073 RID: 115
		public sealed class EventArgs0 : EventArgs
		{
			// Token: 0x0600046E RID: 1134 RVA: 0x000046CF File Offset: 0x000028CF
			public EventArgs0(int value)
			{
				this.value = value;
			}

			// Token: 0x0400041E RID: 1054
			public int value;
		}

		// Token: 0x02000074 RID: 116
		// (Invoke) Token: 0x06000470 RID: 1136
		public delegate void Delegate11();

		// Token: 0x02000075 RID: 117
		// (Invoke) Token: 0x06000474 RID: 1140
		public delegate void Delegate12(object sender, DropdownSlider.EventArgs0 e);
	}
}
