using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using ns1;
using ns13;
using ns14;
using ns16;
using ns17;
using ns18;
using Sims3WorkshopSDK.Interfaces;
using SlimDX;
using SlimDX.Direct3D9;

namespace ns12
{
	// Token: 0x02000012 RID: 18
	internal sealed class EditorToolBox : UserControl
	{
		// Token: 0x14000001 RID: 1
		// (add) Token: 0x06000067 RID: 103 RVA: 0x00014A3C File Offset: 0x00012C3C
		// (remove) Token: 0x06000068 RID: 104 RVA: 0x00014A74 File Offset: 0x00012C74
		public event EditorToolBox.Delegate0 ProjectModelChanged
		{
			add
			{
				EditorToolBox.Delegate0 @delegate = this.delegate0_0;
				EditorToolBox.Delegate0 delegate2;
				do
				{
					delegate2 = @delegate;
					EditorToolBox.Delegate0 value2 = (EditorToolBox.Delegate0)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<EditorToolBox.Delegate0>(ref this.delegate0_0, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			remove
			{
				EditorToolBox.Delegate0 @delegate = this.delegate0_0;
				EditorToolBox.Delegate0 delegate2;
				do
				{
					delegate2 = @delegate;
					EditorToolBox.Delegate0 value2 = (EditorToolBox.Delegate0)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<EditorToolBox.Delegate0>(ref this.delegate0_0, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		// Token: 0x14000002 RID: 2
		// (add) Token: 0x06000069 RID: 105 RVA: 0x00014AAC File Offset: 0x00012CAC
		// (remove) Token: 0x0600006A RID: 106 RVA: 0x00014AE4 File Offset: 0x00012CE4
		public event EditorToolBox.Delegate1 FrameMatricesUpdated
		{
			add
			{
				EditorToolBox.Delegate1 @delegate = this.delegate1_0;
				EditorToolBox.Delegate1 delegate2;
				do
				{
					delegate2 = @delegate;
					EditorToolBox.Delegate1 value2 = (EditorToolBox.Delegate1)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<EditorToolBox.Delegate1>(ref this.delegate1_0, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			remove
			{
				EditorToolBox.Delegate1 @delegate = this.delegate1_0;
				EditorToolBox.Delegate1 delegate2;
				do
				{
					delegate2 = @delegate;
					EditorToolBox.Delegate1 value2 = (EditorToolBox.Delegate1)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<EditorToolBox.Delegate1>(ref this.delegate1_0, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		// Token: 0x0600006B RID: 107 RVA: 0x00014B1C File Offset: 0x00012D1C
		public static EditorToolBox smethod_0()
		{
			if (EditorToolBox.editorToolBox_0 == null)
			{
				EditorToolBox.editorToolBox_0 = new EditorToolBox();
				EditorToolBox.editorToolBox_0.freehandMoveButton.Visible = false;
				EditorToolBox.editorToolBox_0.freehandRotateButton.Visible = false;
			}
			return EditorToolBox.editorToolBox_0;
		}

		// Token: 0x0600006C RID: 108 RVA: 0x00002C2A File Offset: 0x00000E2A
		public void method_0(IProjectModel iprojectModel_0)
		{
			if (this.delegate0_0 != null)
			{
				this.delegate0_0(iprojectModel_0);
			}
		}

		// Token: 0x0600006D RID: 109 RVA: 0x00002C42 File Offset: 0x00000E42
		public void method_1()
		{
			if (this.delegate1_0 != null)
			{
				this.delegate1_0();
			}
		}

		// Token: 0x0600006E RID: 110 RVA: 0x00014B64 File Offset: 0x00012D64
		private void method_2()
		{
			if (base.InvokeRequired)
			{
				EditorToolBox.Delegate1 method = new EditorToolBox.Delegate1(this.method_2);
				base.Invoke(method);
			}
			else
			{
				Class137.smethod_0().vmethod_1();
				Class135.smethod_0().vmethod_1();
				Class134.smethod_0().vmethod_1();
			}
		}

		// Token: 0x0600006F RID: 111 RVA: 0x00014BB0 File Offset: 0x00012DB0
		private void method_3(IProjectModel iprojectModel_0)
		{
			if (base.InvokeRequired)
			{
				EditorToolBox.Delegate0 method = new EditorToolBox.Delegate0(this.method_3);
				base.Invoke(method, new object[]
				{
					iprojectModel_0
				});
			}
			else
			{
				Class137.smethod_0().vmethod_2(iprojectModel_0);
				Class135.smethod_0().vmethod_2(iprojectModel_0);
				Class134.smethod_0().vmethod_2(iprojectModel_0);
			}
		}

		// Token: 0x14000003 RID: 3
		// (add) Token: 0x06000070 RID: 112 RVA: 0x00014C0C File Offset: 0x00012E0C
		// (remove) Token: 0x06000071 RID: 113 RVA: 0x00014C44 File Offset: 0x00012E44
		public event EditorToolBox.Delegate2 OnSelectionChanged
		{
			add
			{
				EditorToolBox.Delegate2 @delegate = this.delegate2_0;
				EditorToolBox.Delegate2 delegate2;
				do
				{
					delegate2 = @delegate;
					EditorToolBox.Delegate2 value2 = (EditorToolBox.Delegate2)Delegate.Combine(delegate2, value);
					@delegate = Interlocked.CompareExchange<EditorToolBox.Delegate2>(ref this.delegate2_0, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
			remove
			{
				EditorToolBox.Delegate2 @delegate = this.delegate2_0;
				EditorToolBox.Delegate2 delegate2;
				do
				{
					delegate2 = @delegate;
					EditorToolBox.Delegate2 value2 = (EditorToolBox.Delegate2)Delegate.Remove(delegate2, value);
					@delegate = Interlocked.CompareExchange<EditorToolBox.Delegate2>(ref this.delegate2_0, value2, delegate2);
				}
				while (@delegate != delegate2);
			}
		}

		// Token: 0x06000072 RID: 114 RVA: 0x00002C59 File Offset: 0x00000E59
		public void method_4()
		{
			if (this.delegate2_0 != null)
			{
				this.delegate2_0();
			}
		}

		// Token: 0x06000073 RID: 115 RVA: 0x00014C7C File Offset: 0x00012E7C
		private EditorToolBox()
		{
			this.InitializeComponent();
			base.Visible = false;
			this.ProjectModelChanged += this.method_3;
			this.FrameMatricesUpdated += this.method_2;
			base.VisibleChanged += this.EditorToolBox_VisibleChanged;
			ToolTip toolTip = new ToolTip();
			toolTip.SetToolTip(this.rectSelectionButton, "Vertex Selection");
			toolTip.SetToolTip(this.boneAssigmentButton, "Bone Assigment");
		}

		// Token: 0x06000074 RID: 116 RVA: 0x00002C70 File Offset: 0x00000E70
		private void EditorToolBox_VisibleChanged(object sender, EventArgs e)
		{
			if (base.Visible && this.ActiveTool == null)
			{
				this.ActiveTool = Class137.smethod_0();
				this.ActiveButton = this.rectSelectionButton;
				this.ActiveButton.Checked = true;
			}
		}

		// Token: 0x1700000A RID: 10
		// (get) Token: 0x06000075 RID: 117 RVA: 0x00014CFC File Offset: 0x00012EFC
		// (set) Token: 0x06000076 RID: 118 RVA: 0x00002CA7 File Offset: 0x00000EA7
		public CheckBox ActiveButton { get; set; }

		// Token: 0x06000077 RID: 119 RVA: 0x00002CB2 File Offset: 0x00000EB2
		public static void smethod_1(bool bool_0)
		{
			Class137.smethod_0().vmethod_0(bool_0);
			Class134.smethod_0().vmethod_0(bool_0);
			Class135.smethod_0().vmethod_0(bool_0);
			Class138.smethod_0().method_1(bool_0);
		}

		// Token: 0x06000078 RID: 120 RVA: 0x00002CE2 File Offset: 0x00000EE2
		public static void smethod_2(Device device_0)
		{
			Class137.smethod_0().vmethod_3(device_0);
			Class135.smethod_0().vmethod_3(device_0);
			Class138.smethod_0().vmethod_3(device_0);
		}

		// Token: 0x06000079 RID: 121 RVA: 0x00002D07 File Offset: 0x00000F07
		private void rectSelectionButton_Click(object sender, EventArgs e)
		{
			this.ActiveButton.Checked = false;
			this.ActiveTool = Class137.smethod_0();
			this.ActiveButton = this.rectSelectionButton;
			this.ActiveButton.Checked = true;
			this.ActiveTool.imethod_4();
		}

		// Token: 0x0600007A RID: 122 RVA: 0x00002D45 File Offset: 0x00000F45
		private void boneAssigmentButton_Click(object sender, EventArgs e)
		{
			this.ActiveButton.Checked = false;
			this.ActiveTool = Class134.smethod_0();
			this.ActiveButton = this.boneAssigmentButton;
			this.ActiveButton.Checked = true;
			this.ActiveTool.imethod_4();
		}

		// Token: 0x0600007B RID: 123 RVA: 0x00002D83 File Offset: 0x00000F83
		private void freehandMoveButton_Click(object sender, EventArgs e)
		{
			this.ActiveButton.Checked = false;
			this.ActiveTool = Class135.smethod_0();
			this.ActiveButton = this.freehandMoveButton;
			this.ActiveButton.Checked = true;
			this.ActiveTool.imethod_4();
		}

		// Token: 0x0600007C RID: 124 RVA: 0x00002DC1 File Offset: 0x00000FC1
		private void freehandRotateButton_Click(object sender, EventArgs e)
		{
			this.ActiveButton.Checked = false;
			this.ActiveTool = Class136.smethod_0();
			this.ActiveButton = this.freehandRotateButton;
			this.ActiveButton.Checked = true;
			this.ActiveTool.imethod_4();
		}

		// Token: 0x0600007D RID: 125 RVA: 0x00014D14 File Offset: 0x00012F14
		private void EditorToolBox_Paint(object sender, PaintEventArgs e)
		{
			Graphics graphics = e.Graphics;
			graphics.DrawLine(Pens.Black, new Point(e.ClipRectangle.Width - 1, 0), new Point(e.ClipRectangle.Width - 1, e.ClipRectangle.Height - 1));
		}

		// Token: 0x1700000B RID: 11
		// (get) Token: 0x0600007E RID: 126 RVA: 0x00014D70 File Offset: 0x00012F70
		// (set) Token: 0x0600007F RID: 127 RVA: 0x00002DFF File Offset: 0x00000FFF
		private EditorToolBox.Interface0 ActiveTool
		{
			get
			{
				return this.interface0_0;
			}
			set
			{
				if (this.interface0_0 != null)
				{
					this.interface0_0.imethod_5();
				}
				this.interface0_0 = value;
				if (this.interface0_0 != null)
				{
					this.interface0_0.imethod_4();
				}
			}
		}

		// Token: 0x06000080 RID: 128 RVA: 0x00002E30 File Offset: 0x00001030
		public void method_5(MeshEditor meshEditor_0, Device device_0, Matrix matrix_0)
		{
			if (this.interface0_0 != null)
			{
				this.interface0_0.imethod_3(meshEditor_0, device_0, matrix_0);
			}
		}

		// Token: 0x06000081 RID: 129 RVA: 0x00014D88 File Offset: 0x00012F88
		public bool method_6(MeshEditor meshEditor_0, Viewport viewport_0, MouseEventArgs mouseEventArgs_0)
		{
			if (this.interface0_0 != null)
			{
				this.interface0_0.imethod_0(meshEditor_0, viewport_0, mouseEventArgs_0);
			}
			return false;
		}

		// Token: 0x06000082 RID: 130 RVA: 0x00014DB4 File Offset: 0x00012FB4
		public bool method_7(MeshEditor meshEditor_0, Viewport viewport_0, MouseEventArgs mouseEventArgs_0)
		{
			if (this.interface0_0 != null)
			{
				this.interface0_0.imethod_1(meshEditor_0, viewport_0, mouseEventArgs_0);
			}
			return false;
		}

		// Token: 0x06000083 RID: 131 RVA: 0x00014DE0 File Offset: 0x00012FE0
		public bool method_8(MeshEditor meshEditor_0, Viewport viewport_0, MouseEventArgs mouseEventArgs_0)
		{
			bool result;
			if (this.interface0_0 != null)
			{
				result = this.interface0_0.imethod_2(meshEditor_0, viewport_0, mouseEventArgs_0);
			}
			else
			{
				result = false;
			}
			return result;
		}

		// Token: 0x06000084 RID: 132 RVA: 0x00002E4A File Offset: 0x0000104A
		protected void Dispose(bool disposing)
		{
			if (disposing && this.icontainer_0 != null)
			{
				this.icontainer_0.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000085 RID: 133 RVA: 0x00014E0C File Offset: 0x0001300C
		private void InitializeComponent()
		{
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(EditorToolBox));
			this.panel1 = new Panel();
			this.freehandRotateButton = new CheckBox();
			this.freehandMoveButton = new CheckBox();
			this.boneAssigmentButton = new CheckBox();
			this.rectSelectionButton = new CheckBox();
			this.Container = new Panel();
			this.panel1.SuspendLayout();
			base.SuspendLayout();
			this.panel1.BackColor = Color.FromArgb(182, 225, 131);
			this.panel1.Controls.Add(this.freehandRotateButton);
			this.panel1.Controls.Add(this.freehandMoveButton);
			this.panel1.Controls.Add(this.boneAssigmentButton);
			this.panel1.Controls.Add(this.rectSelectionButton);
			this.panel1.Dock = DockStyle.Top;
			this.panel1.Location = new Point(4, 4);
			this.panel1.Name = "panel1";
			this.panel1.Padding = new Padding(0, 0, 4, 4);
			this.panel1.Size = new Size(200, 32);
			this.panel1.TabIndex = 0;
			this.freehandRotateButton.Appearance = Appearance.Button;
			this.freehandRotateButton.Dock = DockStyle.Left;
			this.freehandRotateButton.Image = Class143.move1;
			this.freehandRotateButton.Location = new Point(84, 0);
			this.freehandRotateButton.Name = "freehandRotateButton";
			this.freehandRotateButton.Size = new Size(28, 28);
			this.freehandRotateButton.TabIndex = 7;
			this.freehandRotateButton.UseVisualStyleBackColor = true;
			this.freehandRotateButton.Click += this.freehandRotateButton_Click;
			this.freehandMoveButton.Appearance = Appearance.Button;
			this.freehandMoveButton.Dock = DockStyle.Left;
			this.freehandMoveButton.Image = Class143.move1;
			this.freehandMoveButton.Location = new Point(56, 0);
			this.freehandMoveButton.Name = "freehandMoveButton";
			this.freehandMoveButton.Size = new Size(28, 28);
			this.freehandMoveButton.TabIndex = 6;
			this.freehandMoveButton.UseVisualStyleBackColor = true;
			this.freehandMoveButton.Click += this.freehandMoveButton_Click;
			this.boneAssigmentButton.Appearance = Appearance.Button;
			this.boneAssigmentButton.Dock = DockStyle.Left;
			this.boneAssigmentButton.Image = Class143.bone;
			this.boneAssigmentButton.Location = new Point(28, 0);
			this.boneAssigmentButton.Name = "boneAssigmentButton";
			this.boneAssigmentButton.Size = new Size(28, 28);
			this.boneAssigmentButton.TabIndex = 5;
			this.boneAssigmentButton.UseVisualStyleBackColor = true;
			this.boneAssigmentButton.Click += this.boneAssigmentButton_Click;
			this.rectSelectionButton.Appearance = Appearance.Button;
			this.rectSelectionButton.Dock = DockStyle.Left;
			this.rectSelectionButton.Image = (Image)componentResourceManager.GetObject("rectSelectionButton.Image");
			this.rectSelectionButton.Location = new Point(0, 0);
			this.rectSelectionButton.Name = "rectSelectionButton";
			this.rectSelectionButton.Size = new Size(28, 28);
			this.rectSelectionButton.TabIndex = 3;
			this.rectSelectionButton.UseVisualStyleBackColor = true;
			this.rectSelectionButton.Click += this.rectSelectionButton_Click;
			this.Container.BorderStyle = BorderStyle.Fixed3D;
			this.Container.Dock = DockStyle.Fill;
			this.Container.Location = new Point(4, 36);
			this.Container.Name = "Container";
			this.Container.Size = new Size(200, 450);
			this.Container.TabIndex = 2;
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.Font;
			this.BackColor = Color.FromArgb(182, 225, 131);
			base.Controls.Add(this.Container);
			base.Controls.Add(this.panel1);
			base.Name = "EditorToolBox";
			base.Padding = new Padding(4);
			base.Size = new Size(208, 490);
			base.Paint += this.EditorToolBox_Paint;
			this.panel1.ResumeLayout(false);
			base.ResumeLayout(false);
		}

		// Token: 0x040000D4 RID: 212
		private static EditorToolBox editorToolBox_0;

		// Token: 0x040000D5 RID: 213
		private EditorToolBox.Delegate0 delegate0_0;

		// Token: 0x040000D6 RID: 214
		private EditorToolBox.Delegate1 delegate1_0;

		// Token: 0x040000D7 RID: 215
		private EditorToolBox.Delegate2 delegate2_0;

		// Token: 0x040000D8 RID: 216
		private EditorToolBox.Interface0 interface0_0;

		// Token: 0x040000D9 RID: 217
		private IContainer icontainer_0;

		// Token: 0x040000DA RID: 218
		private Panel panel1;

		// Token: 0x040000DB RID: 219
		private CheckBox rectSelectionButton;

		// Token: 0x040000DC RID: 220
		private CheckBox boneAssigmentButton;

		// Token: 0x040000DD RID: 221
		public new Panel Container;

		// Token: 0x040000DE RID: 222
		public CheckBox freehandMoveButton;

		// Token: 0x040000DF RID: 223
		public CheckBox freehandRotateButton;

		// Token: 0x040000E0 RID: 224
		[CompilerGenerated]
		private CheckBox checkBox_0;

		// Token: 0x02000013 RID: 19
		public interface Interface0
		{
			// Token: 0x06000086 RID: 134
			bool imethod_0(MeshEditor meshEditor_0, Viewport viewport_0, MouseEventArgs mouseEventArgs_0);

			// Token: 0x06000087 RID: 135
			bool imethod_1(MeshEditor meshEditor_0, Viewport viewport_0, MouseEventArgs mouseEventArgs_0);

			// Token: 0x06000088 RID: 136
			bool imethod_2(MeshEditor meshEditor_0, Viewport viewport_0, MouseEventArgs mouseEventArgs_0);

			// Token: 0x06000089 RID: 137
			void imethod_3(MeshEditor meshEditor_0, Device device_0, Matrix matrix_0);

			// Token: 0x0600008A RID: 138
			void imethod_4();

			// Token: 0x0600008B RID: 139
			void imethod_5();
		}

		// Token: 0x02000014 RID: 20
		// (Invoke) Token: 0x0600008D RID: 141
		public delegate void Delegate0(IProjectModel projectModel);

		// Token: 0x02000015 RID: 21
		// (Invoke) Token: 0x06000091 RID: 145
		public delegate void Delegate1();

		// Token: 0x02000016 RID: 22
		// (Invoke) Token: 0x06000095 RID: 149
		public delegate void Delegate2();
	}
}
