namespace ns11
{
	// Token: 0x02000010 RID: 16
	internal sealed partial class StblEditor : global::System.Windows.Forms.Form
	{
		// Token: 0x06000059 RID: 89 RVA: 0x00012E20 File Offset: 0x00011020
		private void InitializeComponent()
		{
			global::System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle = new global::System.Windows.Forms.DataGridViewCellStyle();
			global::System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new global::System.Windows.Forms.DataGridViewCellStyle();
			this.label1 = new global::System.Windows.Forms.Label();
			this.textStr = new global::System.Windows.Forms.TextBox();
			this.label2 = new global::System.Windows.Forms.Label();
			this.strings = new global::System.Windows.Forms.DataGridView();
			this.Lang = new global::System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Translation = new global::System.Windows.Forms.DataGridViewTextBoxColumn();
			this.btnSave = new global::System.Windows.Forms.Button();
			this.btnCancel = new global::System.Windows.Forms.Button();
			this.panel1 = new global::System.Windows.Forms.Panel();
			this.copy = new global::System.Windows.Forms.Button();
			((global::System.ComponentModel.ISupportInitialize)this.strings).BeginInit();
			this.panel1.SuspendLayout();
			base.SuspendLayout();
			this.label1.AutoSize = true;
			this.label1.Location = new global::System.Drawing.Point(13, 13);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(70, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Original string";
			this.textStr.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
			this.textStr.Location = new global::System.Drawing.Point(16, 29);
			this.textStr.MaxLength = 256;
			this.textStr.Multiline = true;
			this.textStr.Name = "textStr";
			this.textStr.Size = new global::System.Drawing.Size(206, 49);
			this.textStr.TabIndex = 1;
			this.label2.AutoSize = true;
			this.label2.Location = new global::System.Drawing.Point(15, 91);
			this.label2.Name = "label2";
			this.label2.Size = new global::System.Drawing.Size(64, 13);
			this.label2.TabIndex = 2;
			this.label2.Text = "Translations";
			this.strings.AllowUserToAddRows = false;
			this.strings.AllowUserToDeleteRows = false;
			this.strings.ColumnHeadersHeightSizeMode = global::System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.strings.Columns.AddRange(new global::System.Windows.Forms.DataGridViewColumn[]
			{
				this.Lang,
				this.Translation
			});
			this.strings.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.strings.EditMode = global::System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
			this.strings.Location = new global::System.Drawing.Point(0, 0);
			this.strings.MultiSelect = false;
			this.strings.Name = "strings";
			this.strings.RowHeadersVisible = false;
			this.strings.SelectionMode = global::System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
			this.strings.Size = new global::System.Drawing.Size(285, 528);
			this.strings.TabIndex = 3;
			this.Lang.AutoSizeMode = global::System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
			dataGridViewCellStyle.Alignment = global::System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
			this.Lang.DefaultCellStyle = dataGridViewCellStyle;
			this.Lang.FillWeight = 30f;
			this.Lang.HeaderText = "Language";
			this.Lang.Name = "Lang";
			this.Lang.ReadOnly = true;
			this.Lang.SortMode = global::System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			this.Lang.Width = 94;
			this.Translation.AutoSizeMode = global::System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			dataGridViewCellStyle2.Alignment = global::System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
			this.Translation.DefaultCellStyle = dataGridViewCellStyle2;
			this.Translation.FillWeight = 70f;
			this.Translation.HeaderText = "Translation";
			this.Translation.MaxInputLength = 256;
			this.Translation.Name = "Translation";
			this.Translation.SortMode = global::System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			this.btnSave.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Right);
			this.btnSave.Location = new global::System.Drawing.Point(228, 641);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new global::System.Drawing.Size(75, 23);
			this.btnSave.TabIndex = 4;
			this.btnSave.Text = "Save";
			this.btnSave.UseVisualStyleBackColor = true;
			this.btnSave.Click += new global::System.EventHandler(this.btnSave_Click);
			this.btnCancel.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Right);
			this.btnCancel.DialogResult = global::System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new global::System.Drawing.Point(147, 641);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new global::System.Drawing.Size(75, 23);
			this.btnCancel.TabIndex = 5;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.panel1.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
			this.panel1.Controls.Add(this.strings);
			this.panel1.Location = new global::System.Drawing.Point(18, 107);
			this.panel1.Name = "panel1";
			this.panel1.Size = new global::System.Drawing.Size(285, 528);
			this.panel1.TabIndex = 6;
			this.copy.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Right);
			this.copy.Location = new global::System.Drawing.Point(228, 29);
			this.copy.Name = "copy";
			this.copy.Size = new global::System.Drawing.Size(75, 23);
			this.copy.TabIndex = 7;
			this.copy.Text = "Copy to all";
			this.copy.UseVisualStyleBackColor = true;
			this.copy.Click += new global::System.EventHandler(this.copy_Click);
			base.AcceptButton = this.btnSave;
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.CancelButton = this.btnCancel;
			base.ClientSize = new global::System.Drawing.Size(321, 674);
			base.Controls.Add(this.copy);
			base.Controls.Add(this.panel1);
			base.Controls.Add(this.btnCancel);
			base.Controls.Add(this.btnSave);
			base.Controls.Add(this.label2);
			base.Controls.Add(this.textStr);
			base.Controls.Add(this.label1);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.SizableToolWindow;
			this.MinimumSize = new global::System.Drawing.Size(207, 267);
			base.Name = "StblEditor";
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Localized String Editor";
			((global::System.ComponentModel.ISupportInitialize)this.strings).EndInit();
			this.panel1.ResumeLayout(false);
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x040000B7 RID: 183
		private global::System.Windows.Forms.Label label1;

		// Token: 0x040000B8 RID: 184
		private global::System.Windows.Forms.TextBox textStr;

		// Token: 0x040000B9 RID: 185
		private global::System.Windows.Forms.Label label2;

		// Token: 0x040000BA RID: 186
		private global::System.Windows.Forms.DataGridView strings;

		// Token: 0x040000BB RID: 187
		private global::System.Windows.Forms.Button btnSave;

		// Token: 0x040000BC RID: 188
		private global::System.Windows.Forms.Button btnCancel;

		// Token: 0x040000BD RID: 189
		private global::System.Windows.Forms.Panel panel1;

		// Token: 0x040000BE RID: 190
		private global::System.Windows.Forms.DataGridViewTextBoxColumn Lang;

		// Token: 0x040000BF RID: 191
		private global::System.Windows.Forms.DataGridViewTextBoxColumn Translation;

		// Token: 0x040000C0 RID: 192
		private global::System.Windows.Forms.Button copy;
	}
}
