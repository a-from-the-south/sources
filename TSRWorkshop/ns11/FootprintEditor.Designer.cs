namespace ns11
{
	// Token: 0x0200005E RID: 94
	internal sealed partial class FootprintEditor : global::System.Windows.Forms.Form
	{
		// Token: 0x060003AE RID: 942 RVA: 0x00042BF4 File Offset: 0x00040DF4
		private void InitializeComponent()
		{
			this.cancelButton = new global::System.Windows.Forms.Button();
			this.doneButton = new global::System.Windows.Forms.Button();
			this.groupBox1 = new global::System.Windows.Forms.GroupBox();
			this.label6 = new global::System.Windows.Forms.Label();
			this.label5 = new global::System.Windows.Forms.Label();
			this.label4 = new global::System.Windows.Forms.Label();
			this.label3 = new global::System.Windows.Forms.Label();
			this._minZ = new global::System.Windows.Forms.TextBox();
			this._minX = new global::System.Windows.Forms.TextBox();
			this._maxZ = new global::System.Windows.Forms.TextBox();
			this._maxX = new global::System.Windows.Forms.TextBox();
			this.groupBox2 = new global::System.Windows.Forms.GroupBox();
			this.dataGridView1 = new global::System.Windows.Forms.DataGridView();
			this.groupBox4 = new global::System.Windows.Forms.GroupBox();
			this.FootprintTypeFlagsText = new global::System.Windows.Forms.TextBox();
			this.footprintTypeFlags = new global::System.Windows.Forms.CheckedListBox();
			this.groupBox5 = new global::System.Windows.Forms.GroupBox();
			this.button2 = new global::System.Windows.Forms.Button();
			this.label2 = new global::System.Windows.Forms.Label();
			this.meshCombo = new global::System.Windows.Forms.ComboBox();
			this.predefinedCombo = new global::System.Windows.Forms.ComboBox();
			this.groupBox3 = new global::System.Windows.Forms.GroupBox();
			this.AllowIntersectionFlagsText = new global::System.Windows.Forms.TextBox();
			this.allowIntersectionFlags = new global::System.Windows.Forms.CheckedListBox();
			this.groupBox6 = new global::System.Windows.Forms.GroupBox();
			this.SurfaceTypeFlagsText = new global::System.Windows.Forms.TextBox();
			this.surfaceTypeFlags = new global::System.Windows.Forms.CheckedListBox();
			this.groupBox7 = new global::System.Windows.Forms.GroupBox();
			this.SurfaceAttributeFlagsText = new global::System.Windows.Forms.TextBox();
			this.surfaceAttributeFlags = new global::System.Windows.Forms.CheckedListBox();
			this.groupBox8 = new global::System.Windows.Forms.GroupBox();
			this.elevationOffset = new global::System.Windows.Forms.TextBox();
			this.groupBox9 = new global::System.Windows.Forms.GroupBox();
			this.levelOffset = new global::System.Windows.Forms.TextBox();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.dataGridView1).BeginInit();
			this.groupBox4.SuspendLayout();
			this.groupBox5.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.groupBox6.SuspendLayout();
			this.groupBox7.SuspendLayout();
			this.groupBox8.SuspendLayout();
			this.groupBox9.SuspendLayout();
			base.SuspendLayout();
			this.cancelButton.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Right);
			this.cancelButton.Location = new global::System.Drawing.Point(650, 436);
			this.cancelButton.Name = "cancelButton";
			this.cancelButton.Size = new global::System.Drawing.Size(75, 23);
			this.cancelButton.TabIndex = 6;
			this.cancelButton.Text = "Cancel";
			this.cancelButton.UseVisualStyleBackColor = true;
			this.cancelButton.Click += new global::System.EventHandler(this.cancelButton_Click);
			this.doneButton.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Right);
			this.doneButton.Location = new global::System.Drawing.Point(569, 436);
			this.doneButton.Name = "doneButton";
			this.doneButton.Size = new global::System.Drawing.Size(75, 23);
			this.doneButton.TabIndex = 7;
			this.doneButton.Text = "OK";
			this.doneButton.UseVisualStyleBackColor = true;
			this.doneButton.Click += new global::System.EventHandler(this.doneButton_Click);
			this.groupBox1.Controls.Add(this.label6);
			this.groupBox1.Controls.Add(this.label5);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this._minZ);
			this.groupBox1.Controls.Add(this._minX);
			this.groupBox1.Controls.Add(this._maxZ);
			this.groupBox1.Controls.Add(this._maxX);
			this.groupBox1.Location = new global::System.Drawing.Point(15, 115);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new global::System.Drawing.Size(339, 86);
			this.groupBox1.TabIndex = 8;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Values";
			this.label6.AutoSize = true;
			this.label6.Location = new global::System.Drawing.Point(250, 34);
			this.label6.Name = "label6";
			this.label6.Size = new global::System.Drawing.Size(34, 13);
			this.label6.TabIndex = 10;
			this.label6.Text = "MinZ:";
			this.label5.AutoSize = true;
			this.label5.Location = new global::System.Drawing.Point(171, 34);
			this.label5.Name = "label5";
			this.label5.Size = new global::System.Drawing.Size(34, 13);
			this.label5.TabIndex = 9;
			this.label5.Text = "MinX:";
			this.label4.AutoSize = true;
			this.label4.Location = new global::System.Drawing.Point(92, 34);
			this.label4.Name = "label4";
			this.label4.Size = new global::System.Drawing.Size(37, 13);
			this.label4.TabIndex = 8;
			this.label4.Text = "MaxZ:";
			this.label3.AutoSize = true;
			this.label3.Location = new global::System.Drawing.Point(13, 34);
			this.label3.Name = "label3";
			this.label3.Size = new global::System.Drawing.Size(37, 13);
			this.label3.TabIndex = 7;
			this.label3.Text = "MaxX:";
			this._minZ.Location = new global::System.Drawing.Point(253, 49);
			this._minZ.Name = "_minZ";
			this._minZ.Size = new global::System.Drawing.Size(70, 20);
			this._minZ.TabIndex = 6;
			this._minZ.Leave += new global::System.EventHandler(this._minZ_Leave);
			this._minX.Location = new global::System.Drawing.Point(174, 49);
			this._minX.Name = "_minX";
			this._minX.Size = new global::System.Drawing.Size(70, 20);
			this._minX.TabIndex = 5;
			this._minX.Leave += new global::System.EventHandler(this._minX_Leave);
			this._maxZ.Location = new global::System.Drawing.Point(95, 49);
			this._maxZ.Name = "_maxZ";
			this._maxZ.Size = new global::System.Drawing.Size(70, 20);
			this._maxZ.TabIndex = 4;
			this._maxZ.Leave += new global::System.EventHandler(this._maxZ_Leave);
			this._maxX.Location = new global::System.Drawing.Point(16, 49);
			this._maxX.Name = "_maxX";
			this._maxX.Size = new global::System.Drawing.Size(70, 20);
			this._maxX.TabIndex = 3;
			this._maxX.Leave += new global::System.EventHandler(this._maxX_Leave);
			this.groupBox2.Controls.Add(this.dataGridView1);
			this.groupBox2.Location = new global::System.Drawing.Point(15, 207);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new global::System.Drawing.Size(339, 219);
			this.groupBox2.TabIndex = 11;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Entries";
			this.dataGridView1.ColumnHeadersHeightSizeMode = global::System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.Location = new global::System.Drawing.Point(16, 19);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.Size = new global::System.Drawing.Size(307, 189);
			this.dataGridView1.TabIndex = 0;
			this.groupBox4.Controls.Add(this.FootprintTypeFlagsText);
			this.groupBox4.Controls.Add(this.footprintTypeFlags);
			this.groupBox4.Location = new global::System.Drawing.Point(371, 12);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new global::System.Drawing.Size(170, 172);
			this.groupBox4.TabIndex = 12;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "Footprint Type Flags";
			this.FootprintTypeFlagsText.Location = new global::System.Drawing.Point(11, 137);
			this.FootprintTypeFlagsText.Name = "FootprintTypeFlagsText";
			this.FootprintTypeFlagsText.Size = new global::System.Drawing.Size(146, 20);
			this.FootprintTypeFlagsText.TabIndex = 1;
			this.FootprintTypeFlagsText.Text = "0x0";
			this.FootprintTypeFlagsText.TextChanged += new global::System.EventHandler(this.SurfaceAttributeFlagsText_TextChanged);
			this.footprintTypeFlags.FormattingEnabled = true;
			this.footprintTypeFlags.Items.AddRange(new object[]
			{
				"For Placement",
				"For Pathing",
				"Is Enabled",
				"Is Discouraged",
				"For Shell"
			});
			this.footprintTypeFlags.Location = new global::System.Drawing.Point(11, 21);
			this.footprintTypeFlags.Name = "footprintTypeFlags";
			this.footprintTypeFlags.Size = new global::System.Drawing.Size(146, 109);
			this.footprintTypeFlags.TabIndex = 0;
			this.footprintTypeFlags.MouseUp += new global::System.Windows.Forms.MouseEventHandler(this.surfaceAttributeFlags_MouseUp);
			this.groupBox5.Controls.Add(this.button2);
			this.groupBox5.Controls.Add(this.label2);
			this.groupBox5.Controls.Add(this.meshCombo);
			this.groupBox5.Controls.Add(this.predefinedCombo);
			this.groupBox5.Location = new global::System.Drawing.Point(15, 12);
			this.groupBox5.Name = "groupBox5";
			this.groupBox5.Size = new global::System.Drawing.Size(339, 97);
			this.groupBox5.TabIndex = 12;
			this.groupBox5.TabStop = false;
			this.groupBox5.Text = "Predefined (width x depth):";
			this.button2.Location = new global::System.Drawing.Point(254, 63);
			this.button2.Name = "button2";
			this.button2.Size = new global::System.Drawing.Size(75, 23);
			this.button2.TabIndex = 10;
			this.button2.Text = "Calculate";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new global::System.EventHandler(this.button2_Click);
			this.label2.AutoSize = true;
			this.label2.Location = new global::System.Drawing.Point(8, 49);
			this.label2.Name = "label2";
			this.label2.Size = new global::System.Drawing.Size(61, 13);
			this.label2.TabIndex = 9;
			this.label2.Text = "From mesh:";
			this.meshCombo.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.meshCombo.FormattingEnabled = true;
			this.meshCombo.Location = new global::System.Drawing.Point(11, 64);
			this.meshCombo.Name = "meshCombo";
			this.meshCombo.Size = new global::System.Drawing.Size(237, 21);
			this.meshCombo.TabIndex = 8;
			this.predefinedCombo.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.predefinedCombo.FormattingEnabled = true;
			this.predefinedCombo.Items.AddRange(new object[]
			{
				"1x1",
				"1x2",
				"1x3",
				"2x1",
				"2x2",
				"2x3",
				"3x1",
				"3x2",
				"3x3"
			});
			this.predefinedCombo.Location = new global::System.Drawing.Point(11, 19);
			this.predefinedCombo.Name = "predefinedCombo";
			this.predefinedCombo.Size = new global::System.Drawing.Size(318, 21);
			this.predefinedCombo.TabIndex = 6;
			this.predefinedCombo.SelectedIndexChanged += new global::System.EventHandler(this.predefinedCombo_SelectedIndexChanged);
			this.groupBox3.Controls.Add(this.AllowIntersectionFlagsText);
			this.groupBox3.Controls.Add(this.allowIntersectionFlags);
			this.groupBox3.Location = new global::System.Drawing.Point(553, 12);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new global::System.Drawing.Size(170, 172);
			this.groupBox3.TabIndex = 13;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Allow Intersection Flags";
			this.AllowIntersectionFlagsText.Location = new global::System.Drawing.Point(11, 137);
			this.AllowIntersectionFlagsText.Name = "AllowIntersectionFlagsText";
			this.AllowIntersectionFlagsText.Size = new global::System.Drawing.Size(146, 20);
			this.AllowIntersectionFlagsText.TabIndex = 2;
			this.AllowIntersectionFlagsText.Text = "0x0";
			this.AllowIntersectionFlagsText.TextChanged += new global::System.EventHandler(this.SurfaceAttributeFlagsText_TextChanged);
			this.allowIntersectionFlags.FormattingEnabled = true;
			this.allowIntersectionFlags.Items.AddRange(new object[]
			{
				"Walls",
				"Objects",
				"Sims",
				"Roofs",
				"Fences",
				"Modular Stairs",
				"Objects of same type"
			});
			this.allowIntersectionFlags.Location = new global::System.Drawing.Point(11, 21);
			this.allowIntersectionFlags.Name = "allowIntersectionFlags";
			this.allowIntersectionFlags.Size = new global::System.Drawing.Size(146, 109);
			this.allowIntersectionFlags.TabIndex = 0;
			this.allowIntersectionFlags.MouseUp += new global::System.Windows.Forms.MouseEventHandler(this.surfaceAttributeFlags_MouseUp);
			this.groupBox6.Controls.Add(this.SurfaceTypeFlagsText);
			this.groupBox6.Controls.Add(this.surfaceTypeFlags);
			this.groupBox6.Location = new global::System.Drawing.Point(371, 190);
			this.groupBox6.Name = "groupBox6";
			this.groupBox6.Size = new global::System.Drawing.Size(170, 180);
			this.groupBox6.TabIndex = 14;
			this.groupBox6.TabStop = false;
			this.groupBox6.Text = "Surface Type Flags";
			this.SurfaceTypeFlagsText.Location = new global::System.Drawing.Point(11, 151);
			this.SurfaceTypeFlagsText.Name = "SurfaceTypeFlagsText";
			this.SurfaceTypeFlagsText.Size = new global::System.Drawing.Size(146, 20);
			this.SurfaceTypeFlagsText.TabIndex = 16;
			this.SurfaceTypeFlagsText.Text = "0x0";
			this.SurfaceTypeFlagsText.TextChanged += new global::System.EventHandler(this.SurfaceAttributeFlagsText_TextChanged);
			this.surfaceTypeFlags.FormattingEnabled = true;
			this.surfaceTypeFlags.Items.AddRange(new object[]
			{
				"Terrain",
				"Floor",
				"Pool",
				"Pond",
				"Fance",
				"Any Surface",
				"Air",
				"Roof"
			});
			this.surfaceTypeFlags.Location = new global::System.Drawing.Point(11, 21);
			this.surfaceTypeFlags.Name = "surfaceTypeFlags";
			this.surfaceTypeFlags.Size = new global::System.Drawing.Size(146, 124);
			this.surfaceTypeFlags.TabIndex = 0;
			this.surfaceTypeFlags.MouseUp += new global::System.Windows.Forms.MouseEventHandler(this.surfaceAttributeFlags_MouseUp);
			this.groupBox7.Controls.Add(this.SurfaceAttributeFlagsText);
			this.groupBox7.Controls.Add(this.surfaceAttributeFlags);
			this.groupBox7.Location = new global::System.Drawing.Point(553, 190);
			this.groupBox7.Name = "groupBox7";
			this.groupBox7.Size = new global::System.Drawing.Size(170, 180);
			this.groupBox7.TabIndex = 15;
			this.groupBox7.TabStop = false;
			this.groupBox7.Text = "Surface Attribute Flags";
			this.SurfaceAttributeFlagsText.Location = new global::System.Drawing.Point(11, 151);
			this.SurfaceAttributeFlagsText.Name = "SurfaceAttributeFlagsText";
			this.SurfaceAttributeFlagsText.Size = new global::System.Drawing.Size(146, 20);
			this.SurfaceAttributeFlagsText.TabIndex = 17;
			this.SurfaceAttributeFlagsText.Text = "0x0";
			this.SurfaceAttributeFlagsText.TextChanged += new global::System.EventHandler(this.SurfaceAttributeFlagsText_TextChanged);
			this.surfaceAttributeFlags.FormattingEnabled = true;
			this.surfaceAttributeFlags.Items.AddRange(new object[]
			{
				"Inside",
				"Outside",
				"Slope"
			});
			this.surfaceAttributeFlags.Location = new global::System.Drawing.Point(11, 21);
			this.surfaceAttributeFlags.Name = "surfaceAttributeFlags";
			this.surfaceAttributeFlags.Size = new global::System.Drawing.Size(146, 124);
			this.surfaceAttributeFlags.TabIndex = 0;
			this.surfaceAttributeFlags.MouseUp += new global::System.Windows.Forms.MouseEventHandler(this.surfaceAttributeFlags_MouseUp);
			this.groupBox8.Controls.Add(this.elevationOffset);
			this.groupBox8.Location = new global::System.Drawing.Point(371, 376);
			this.groupBox8.Name = "groupBox8";
			this.groupBox8.Size = new global::System.Drawing.Size(170, 50);
			this.groupBox8.TabIndex = 11;
			this.groupBox8.TabStop = false;
			this.groupBox8.Text = "Elevation offset";
			this.elevationOffset.Location = new global::System.Drawing.Point(11, 19);
			this.elevationOffset.Name = "elevationOffset";
			this.elevationOffset.Size = new global::System.Drawing.Size(146, 20);
			this.elevationOffset.TabIndex = 3;
			this.groupBox9.Controls.Add(this.levelOffset);
			this.groupBox9.Location = new global::System.Drawing.Point(547, 376);
			this.groupBox9.Name = "groupBox9";
			this.groupBox9.Size = new global::System.Drawing.Size(170, 50);
			this.groupBox9.TabIndex = 12;
			this.groupBox9.TabStop = false;
			this.groupBox9.Text = "Level offset";
			this.levelOffset.Location = new global::System.Drawing.Point(11, 19);
			this.levelOffset.Name = "levelOffset";
			this.levelOffset.Size = new global::System.Drawing.Size(146, 20);
			this.levelOffset.TabIndex = 3;
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new global::System.Drawing.Size(735, 467);
			base.Controls.Add(this.groupBox9);
			base.Controls.Add(this.groupBox8);
			base.Controls.Add(this.groupBox7);
			base.Controls.Add(this.groupBox6);
			base.Controls.Add(this.groupBox3);
			base.Controls.Add(this.groupBox5);
			base.Controls.Add(this.groupBox4);
			base.Controls.Add(this.groupBox2);
			base.Controls.Add(this.groupBox1);
			base.Controls.Add(this.doneButton);
			base.Controls.Add(this.cancelButton);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			base.Name = "FootprintEditor";
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Footprint Editor";
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.dataGridView1).EndInit();
			this.groupBox4.ResumeLayout(false);
			this.groupBox4.PerformLayout();
			this.groupBox5.ResumeLayout(false);
			this.groupBox5.PerformLayout();
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			this.groupBox6.ResumeLayout(false);
			this.groupBox6.PerformLayout();
			this.groupBox7.ResumeLayout(false);
			this.groupBox7.PerformLayout();
			this.groupBox8.ResumeLayout(false);
			this.groupBox8.PerformLayout();
			this.groupBox9.ResumeLayout(false);
			this.groupBox9.PerformLayout();
			base.ResumeLayout(false);
		}

		// Token: 0x0400035C RID: 860
		private global::System.Windows.Forms.Button cancelButton;

		// Token: 0x0400035D RID: 861
		private global::System.Windows.Forms.Button doneButton;

		// Token: 0x0400035E RID: 862
		private global::System.Windows.Forms.GroupBox groupBox1;

		// Token: 0x0400035F RID: 863
		private global::System.Windows.Forms.Label label6;

		// Token: 0x04000360 RID: 864
		private global::System.Windows.Forms.Label label5;

		// Token: 0x04000361 RID: 865
		private global::System.Windows.Forms.Label label4;

		// Token: 0x04000362 RID: 866
		private global::System.Windows.Forms.Label label3;

		// Token: 0x04000363 RID: 867
		private global::System.Windows.Forms.TextBox _minZ;

		// Token: 0x04000364 RID: 868
		private global::System.Windows.Forms.TextBox _minX;

		// Token: 0x04000365 RID: 869
		private global::System.Windows.Forms.TextBox _maxZ;

		// Token: 0x04000366 RID: 870
		private global::System.Windows.Forms.TextBox _maxX;

		// Token: 0x04000367 RID: 871
		private global::System.Windows.Forms.GroupBox groupBox2;

		// Token: 0x04000368 RID: 872
		private global::System.Windows.Forms.DataGridView dataGridView1;

		// Token: 0x04000369 RID: 873
		private global::System.Windows.Forms.GroupBox groupBox4;

		// Token: 0x0400036A RID: 874
		private global::System.Windows.Forms.GroupBox groupBox5;

		// Token: 0x0400036B RID: 875
		private global::System.Windows.Forms.Button button2;

		// Token: 0x0400036C RID: 876
		private global::System.Windows.Forms.Label label2;

		// Token: 0x0400036D RID: 877
		private global::System.Windows.Forms.ComboBox meshCombo;

		// Token: 0x0400036E RID: 878
		private global::System.Windows.Forms.ComboBox predefinedCombo;

		// Token: 0x0400036F RID: 879
		private global::System.Windows.Forms.CheckedListBox footprintTypeFlags;

		// Token: 0x04000370 RID: 880
		private global::System.Windows.Forms.GroupBox groupBox3;

		// Token: 0x04000371 RID: 881
		private global::System.Windows.Forms.CheckedListBox allowIntersectionFlags;

		// Token: 0x04000372 RID: 882
		private global::System.Windows.Forms.GroupBox groupBox6;

		// Token: 0x04000373 RID: 883
		private global::System.Windows.Forms.CheckedListBox surfaceTypeFlags;

		// Token: 0x04000374 RID: 884
		private global::System.Windows.Forms.GroupBox groupBox7;

		// Token: 0x04000375 RID: 885
		private global::System.Windows.Forms.CheckedListBox surfaceAttributeFlags;

		// Token: 0x04000376 RID: 886
		private global::System.Windows.Forms.TextBox FootprintTypeFlagsText;

		// Token: 0x04000377 RID: 887
		private global::System.Windows.Forms.TextBox AllowIntersectionFlagsText;

		// Token: 0x04000378 RID: 888
		private global::System.Windows.Forms.TextBox SurfaceTypeFlagsText;

		// Token: 0x04000379 RID: 889
		private global::System.Windows.Forms.TextBox SurfaceAttributeFlagsText;

		// Token: 0x0400037A RID: 890
		private global::System.Windows.Forms.GroupBox groupBox8;

		// Token: 0x0400037B RID: 891
		private global::System.Windows.Forms.TextBox elevationOffset;

		// Token: 0x0400037C RID: 892
		private global::System.Windows.Forms.GroupBox groupBox9;

		// Token: 0x0400037D RID: 893
		private global::System.Windows.Forms.TextBox levelOffset;
	}
}
