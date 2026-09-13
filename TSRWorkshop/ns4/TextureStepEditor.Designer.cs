namespace ns4
{
	// Token: 0x020000EA RID: 234
	internal sealed partial class TextureStepEditor : global::System.Windows.Forms.Form
	{
		// Token: 0x06000993 RID: 2451 RVA: 0x0008421C File Offset: 0x0008241C
		private void InitializeComponent()
		{
			this.panelButtons = new global::System.Windows.Forms.Panel();
			this.cancelBtn = new global::System.Windows.Forms.Button();
			this.doneBtn = new global::System.Windows.Forms.Button();
			this.panelMain = new global::System.Windows.Forms.Panel();
			this.panelSelectAndGrid = new global::System.Windows.Forms.Panel();
			this.panelGrid = new global::System.Windows.Forms.Panel();
			this.stepsGrid = new global::VisualHint.SmartPropertyGrid.PropertyGrid();
			this.panelSelect = new global::System.Windows.Forms.Panel();
			this.destinations = new global::System.Windows.Forms.ComboBox();
			this.panelPreviewandVariables = new global::System.Windows.Forms.Panel();
			this.panelVariables = new global::System.Windows.Forms.Panel();
			this.variables = new global::VisualHint.SmartPropertyGrid.PropertyGrid();
			this.panelPreview = new global::System.Windows.Forms.Panel();
			this.pictureBox1 = new global::System.Windows.Forms.PictureBox();
			this.panelButtons.SuspendLayout();
			this.panelMain.SuspendLayout();
			this.panelSelectAndGrid.SuspendLayout();
			this.panelGrid.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.stepsGrid).BeginInit();
			this.panelSelect.SuspendLayout();
			this.panelPreviewandVariables.SuspendLayout();
			this.panelVariables.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.variables).BeginInit();
			this.panelPreview.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox1).BeginInit();
			base.SuspendLayout();
			this.panelButtons.Controls.Add(this.cancelBtn);
			this.panelButtons.Controls.Add(this.doneBtn);
			this.panelButtons.Dock = global::System.Windows.Forms.DockStyle.Bottom;
			this.panelButtons.Location = new global::System.Drawing.Point(0, 472);
			this.panelButtons.Name = "panelButtons";
			this.panelButtons.Size = new global::System.Drawing.Size(475, 50);
			this.panelButtons.TabIndex = 4;
			this.cancelBtn.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Right);
			this.cancelBtn.DialogResult = global::System.Windows.Forms.DialogResult.Cancel;
			this.cancelBtn.Location = new global::System.Drawing.Point(388, 15);
			this.cancelBtn.Name = "cancelBtn";
			this.cancelBtn.Size = new global::System.Drawing.Size(75, 23);
			this.cancelBtn.TabIndex = 1;
			this.cancelBtn.Text = "Cancel";
			this.cancelBtn.UseVisualStyleBackColor = true;
			this.doneBtn.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left);
			this.doneBtn.Location = new global::System.Drawing.Point(9, 15);
			this.doneBtn.Name = "doneBtn";
			this.doneBtn.Size = new global::System.Drawing.Size(75, 23);
			this.doneBtn.TabIndex = 0;
			this.doneBtn.Text = "Done";
			this.doneBtn.UseVisualStyleBackColor = true;
			this.doneBtn.Click += new global::System.EventHandler(this.doneBtn_Click);
			this.panelMain.Controls.Add(this.panelSelectAndGrid);
			this.panelMain.Controls.Add(this.panelPreviewandVariables);
			this.panelMain.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.panelMain.Location = new global::System.Drawing.Point(0, 0);
			this.panelMain.Name = "panelMain";
			this.panelMain.Size = new global::System.Drawing.Size(475, 472);
			this.panelMain.TabIndex = 5;
			this.panelSelectAndGrid.Controls.Add(this.panelGrid);
			this.panelSelectAndGrid.Controls.Add(this.panelSelect);
			this.panelSelectAndGrid.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.panelSelectAndGrid.Location = new global::System.Drawing.Point(0, 0);
			this.panelSelectAndGrid.Name = "panelSelectAndGrid";
			this.panelSelectAndGrid.Size = new global::System.Drawing.Size(196, 472);
			this.panelSelectAndGrid.TabIndex = 1;
			this.panelGrid.Controls.Add(this.stepsGrid);
			this.panelGrid.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.panelGrid.Location = new global::System.Drawing.Point(0, 34);
			this.panelGrid.Name = "panelGrid";
			this.panelGrid.Padding = new global::System.Windows.Forms.Padding(9, 0, 9, 0);
			this.panelGrid.Size = new global::System.Drawing.Size(196, 438);
			this.panelGrid.TabIndex = 1;
			this.stepsGrid.BorderStyle = global::System.Windows.Forms.BorderStyle.None;
			this.stepsGrid.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.stepsGrid.Location = new global::System.Drawing.Point(9, 0);
			this.stepsGrid.Name = "stepsGrid";
			this.stepsGrid.PropertyLabelBackColor = global::System.Drawing.SystemColors.Window;
			this.stepsGrid.PropertyValueBackColor = global::System.Drawing.SystemColors.Window;
			this.stepsGrid.Size = new global::System.Drawing.Size(178, 438);
			this.stepsGrid.TabIndex = 0;
			this.stepsGrid.Text = "propertyGrid1";
			this.stepsGrid.Click += new global::System.EventHandler(this.stepsGrid_Click);
			this.stepsGrid.PropertyChanged += new global::VisualHint.SmartPropertyGrid.PropertyGrid.PropertyChangedEventHandler(this.stepsGrid_PropertyChanged);
			this.panelSelect.Controls.Add(this.destinations);
			this.panelSelect.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.panelSelect.Location = new global::System.Drawing.Point(0, 0);
			this.panelSelect.Name = "panelSelect";
			this.panelSelect.Size = new global::System.Drawing.Size(196, 34);
			this.panelSelect.TabIndex = 0;
			this.destinations.FormattingEnabled = true;
			this.destinations.Location = new global::System.Drawing.Point(9, 7);
			this.destinations.Name = "destinations";
			this.destinations.Size = new global::System.Drawing.Size(178, 21);
			this.destinations.TabIndex = 0;
			this.destinations.SelectedIndexChanged += new global::System.EventHandler(this.destinations_SelectedIndexChanged);
			this.panelPreviewandVariables.Controls.Add(this.panelVariables);
			this.panelPreviewandVariables.Controls.Add(this.panelPreview);
			this.panelPreviewandVariables.Dock = global::System.Windows.Forms.DockStyle.Right;
			this.panelPreviewandVariables.Location = new global::System.Drawing.Point(196, 0);
			this.panelPreviewandVariables.Name = "panelPreviewandVariables";
			this.panelPreviewandVariables.Size = new global::System.Drawing.Size(279, 472);
			this.panelPreviewandVariables.TabIndex = 0;
			this.panelVariables.Controls.Add(this.variables);
			this.panelVariables.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.panelVariables.Location = new global::System.Drawing.Point(0, 278);
			this.panelVariables.Name = "panelVariables";
			this.panelVariables.Padding = new global::System.Windows.Forms.Padding(9, 0, 11, 0);
			this.panelVariables.Size = new global::System.Drawing.Size(279, 194);
			this.panelVariables.TabIndex = 2;
			this.variables.BorderStyle = global::System.Windows.Forms.BorderStyle.None;
			this.variables.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.variables.Location = new global::System.Drawing.Point(9, 0);
			this.variables.Name = "variables";
			this.variables.PropertyLabelBackColor = global::System.Drawing.SystemColors.Window;
			this.variables.PropertyValueBackColor = global::System.Drawing.SystemColors.Window;
			this.variables.Size = new global::System.Drawing.Size(259, 194);
			this.variables.TabIndex = 0;
			this.variables.Text = "propertyGrid1";
			this.variables.PropertyChanged += new global::VisualHint.SmartPropertyGrid.PropertyGrid.PropertyChangedEventHandler(this.variables_PropertyChanged);
			this.panelPreview.Controls.Add(this.pictureBox1);
			this.panelPreview.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.panelPreview.Location = new global::System.Drawing.Point(0, 0);
			this.panelPreview.Name = "panelPreview";
			this.panelPreview.Size = new global::System.Drawing.Size(279, 278);
			this.panelPreview.TabIndex = 1;
			this.pictureBox1.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Right);
			this.pictureBox1.BackColor = global::System.Drawing.Color.Transparent;
			this.pictureBox1.BorderStyle = global::System.Windows.Forms.BorderStyle.FixedSingle;
			this.pictureBox1.Location = new global::System.Drawing.Point(11, 12);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new global::System.Drawing.Size(256, 256);
			this.pictureBox1.SizeMode = global::System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pictureBox1.TabIndex = 0;
			this.pictureBox1.TabStop = false;
			base.AcceptButton = this.doneBtn;
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.CancelButton = this.cancelBtn;
			base.ClientSize = new global::System.Drawing.Size(475, 522);
			base.Controls.Add(this.panelMain);
			base.Controls.Add(this.panelButtons);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.SizableToolWindow;
			base.Name = "TextureStepEditor";
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "TextureStepEditor";
			this.panelButtons.ResumeLayout(false);
			this.panelMain.ResumeLayout(false);
			this.panelSelectAndGrid.ResumeLayout(false);
			this.panelGrid.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.stepsGrid).EndInit();
			this.panelSelect.ResumeLayout(false);
			this.panelPreviewandVariables.ResumeLayout(false);
			this.panelVariables.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.variables).EndInit();
			this.panelPreview.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox1).EndInit();
			base.ResumeLayout(false);
		}

		// Token: 0x040007B4 RID: 1972
		private global::System.Windows.Forms.Panel panelButtons;

		// Token: 0x040007B5 RID: 1973
		private global::System.Windows.Forms.Button cancelBtn;

		// Token: 0x040007B6 RID: 1974
		private global::System.Windows.Forms.Button doneBtn;

		// Token: 0x040007B7 RID: 1975
		private global::System.Windows.Forms.Panel panelMain;

		// Token: 0x040007B8 RID: 1976
		private global::System.Windows.Forms.Panel panelPreviewandVariables;

		// Token: 0x040007B9 RID: 1977
		private global::System.Windows.Forms.Panel panelSelectAndGrid;

		// Token: 0x040007BA RID: 1978
		private global::System.Windows.Forms.Panel panelVariables;

		// Token: 0x040007BB RID: 1979
		private global::VisualHint.SmartPropertyGrid.PropertyGrid variables;

		// Token: 0x040007BC RID: 1980
		private global::System.Windows.Forms.Panel panelPreview;

		// Token: 0x040007BD RID: 1981
		private global::System.Windows.Forms.PictureBox pictureBox1;

		// Token: 0x040007BE RID: 1982
		private global::System.Windows.Forms.Panel panelGrid;

		// Token: 0x040007BF RID: 1983
		private global::VisualHint.SmartPropertyGrid.PropertyGrid stepsGrid;

		// Token: 0x040007C0 RID: 1984
		private global::System.Windows.Forms.Panel panelSelect;

		// Token: 0x040007C1 RID: 1985
		private global::System.Windows.Forms.ComboBox destinations;
	}
}
