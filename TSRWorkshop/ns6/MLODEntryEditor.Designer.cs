namespace ns6
{
	// Token: 0x02000060 RID: 96
	internal sealed partial class MLODEntryEditor : global::System.Windows.Forms.Form
	{
		// Token: 0x060003BC RID: 956 RVA: 0x000441BC File Offset: 0x000423BC
		private void InitializeComponent()
		{
			this.exportButton = new global::System.Windows.Forms.Button();
			this.importButton = new global::System.Windows.Forms.Button();
			this.doneButton = new global::System.Windows.Forms.Button();
			this.cancelButton = new global::System.Windows.Forms.Button();
			base.SuspendLayout();
			this.exportButton.Location = new global::System.Drawing.Point(14, 14);
			this.exportButton.Name = "exportButton";
			this.exportButton.Size = new global::System.Drawing.Size(75, 23);
			this.exportButton.TabIndex = 0;
			this.exportButton.Text = "Export";
			this.exportButton.UseVisualStyleBackColor = true;
			this.exportButton.Click += new global::System.EventHandler(this.exportButton_Click);
			this.importButton.Location = new global::System.Drawing.Point(95, 14);
			this.importButton.Name = "importButton";
			this.importButton.Size = new global::System.Drawing.Size(75, 23);
			this.importButton.TabIndex = 0;
			this.importButton.Text = "Import";
			this.importButton.UseVisualStyleBackColor = true;
			this.importButton.Click += new global::System.EventHandler(this.importButton_Click);
			this.doneButton.Location = new global::System.Drawing.Point(14, 43);
			this.doneButton.Name = "doneButton";
			this.doneButton.Size = new global::System.Drawing.Size(75, 23);
			this.doneButton.TabIndex = 2;
			this.doneButton.Text = "Done";
			this.doneButton.UseVisualStyleBackColor = true;
			this.doneButton.Click += new global::System.EventHandler(this.doneButton_Click);
			this.cancelButton.Location = new global::System.Drawing.Point(95, 43);
			this.cancelButton.Name = "cancelButton";
			this.cancelButton.Size = new global::System.Drawing.Size(75, 23);
			this.cancelButton.TabIndex = 3;
			this.cancelButton.Text = "Cancel";
			this.cancelButton.UseVisualStyleBackColor = true;
			this.cancelButton.Click += new global::System.EventHandler(this.cancelButton_Click);
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new global::System.Drawing.Size(188, 77);
			base.ControlBox = false;
			base.Controls.Add(this.cancelButton);
			base.Controls.Add(this.doneButton);
			base.Controls.Add(this.importButton);
			base.Controls.Add(this.exportButton);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedSingle;
			base.Name = "MLODEntryEditor";
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Import / Export mesh";
			base.ResumeLayout(false);
		}

		// Token: 0x04000383 RID: 899
		private global::System.Windows.Forms.Button exportButton;

		// Token: 0x04000384 RID: 900
		private global::System.Windows.Forms.Button importButton;

		// Token: 0x04000385 RID: 901
		private global::System.Windows.Forms.Button doneButton;

		// Token: 0x04000386 RID: 902
		private global::System.Windows.Forms.Button cancelButton;
	}
}
