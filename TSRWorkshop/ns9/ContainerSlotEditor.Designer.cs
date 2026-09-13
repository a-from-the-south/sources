namespace ns9
{
	// Token: 0x02000008 RID: 8
	internal sealed partial class ContainerSlotEditor : global::System.Windows.Forms.Form
	{
		// Token: 0x0600002F RID: 47 RVA: 0x0000D250 File Offset: 0x0000B450
		private void InitializeComponent()
		{
			global::System.Windows.Forms.ListViewItem listViewItem = new global::System.Windows.Forms.ListViewItem("None");
			global::System.Windows.Forms.ListViewItem listViewItem2 = new global::System.Windows.Forms.ListViewItem("Small");
			global::System.Windows.Forms.ListViewItem listViewItem3 = new global::System.Windows.Forms.ListViewItem("Medium");
			global::System.Windows.Forms.ListViewItem listViewItem4 = new global::System.Windows.Forms.ListViewItem("Large");
			global::System.Windows.Forms.ListViewItem listViewItem5 = new global::System.Windows.Forms.ListViewItem("Sim");
			global::System.Windows.Forms.ListViewItem listViewItem6 = new global::System.Windows.Forms.ListViewItem("Chair");
			global::System.Windows.Forms.ListViewItem listViewItem7 = new global::System.Windows.Forms.ListViewItem("Countersink");
			global::System.Windows.Forms.ListViewItem listViewItem8 = new global::System.Windows.Forms.ListViewItem("Endtable");
			global::System.Windows.Forms.ListViewItem listViewItem9 = new global::System.Windows.Forms.ListViewItem("Stool");
			global::System.Windows.Forms.ListViewItem listViewItem10 = new global::System.Windows.Forms.ListViewItem("Counter appliance");
			global::System.Windows.Forms.ListViewItem listViewItem11 = new global::System.Windows.Forms.ListViewItem("Functional");
			global::System.Windows.Forms.ListViewItem listViewItem12 = new global::System.Windows.Forms.ListViewItem("Decorative");
			global::System.Windows.Forms.ListViewItem listViewItem13 = new global::System.Windows.Forms.ListViewItem("Upgrade");
			global::System.Windows.Forms.ListViewItem listViewItem14 = new global::System.Windows.Forms.ListViewItem("Vertical");
			global::System.Windows.Forms.ListViewItem listViewItem15 = new global::System.Windows.Forms.ListViewItem("PlacementOnly");
			global::System.Windows.Forms.ListViewItem listViewItem16 = new global::System.Windows.Forms.ListViewItem("CardinalRotation");
			global::System.Windows.Forms.ListViewItem listViewItem17 = new global::System.Windows.Forms.ListViewItem("FullRotation");
			global::System.Windows.Forms.ListViewItem listViewItem18 = new global::System.Windows.Forms.ListViewItem("AlwaysUp");
			this.canelButton = new global::System.Windows.Forms.Button();
			this.okButton = new global::System.Windows.Forms.Button();
			this.groupBox1 = new global::System.Windows.Forms.GroupBox();
			this.t11 = new global::System.Windows.Forms.TextBox();
			this.t10 = new global::System.Windows.Forms.TextBox();
			this.t9 = new global::System.Windows.Forms.TextBox();
			this.t8 = new global::System.Windows.Forms.TextBox();
			this.t7 = new global::System.Windows.Forms.TextBox();
			this.t6 = new global::System.Windows.Forms.TextBox();
			this.t5 = new global::System.Windows.Forms.TextBox();
			this.t4 = new global::System.Windows.Forms.TextBox();
			this.t3 = new global::System.Windows.Forms.TextBox();
			this.t2 = new global::System.Windows.Forms.TextBox();
			this.t1 = new global::System.Windows.Forms.TextBox();
			this.t0 = new global::System.Windows.Forms.TextBox();
			this.groupBox2 = new global::System.Windows.Forms.GroupBox();
			this.label6 = new global::System.Windows.Forms.Label();
			this.listView1 = new global::System.Windows.Forms.ListView();
			this.columnHeader_0 = new global::System.Windows.Forms.ColumnHeader();
			this.label5 = new global::System.Windows.Forms.Label();
			this.label4 = new global::System.Windows.Forms.Label();
			this.textBox2 = new global::System.Windows.Forms.TextBox();
			this.label3 = new global::System.Windows.Forms.Label();
			this.boneHash = new global::System.Windows.Forms.TextBox();
			this.label2 = new global::System.Windows.Forms.Label();
			this.nameHash = new global::System.Windows.Forms.TextBox();
			this.label1 = new global::System.Windows.Forms.Label();
			this.comboBox1 = new global::System.Windows.Forms.ComboBox();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			base.SuspendLayout();
			this.canelButton.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Right);
			this.canelButton.Location = new global::System.Drawing.Point(336, 442);
			this.canelButton.Name = "canelButton";
			this.canelButton.Size = new global::System.Drawing.Size(75, 23);
			this.canelButton.TabIndex = 18;
			this.canelButton.Text = "Cancel";
			this.canelButton.UseVisualStyleBackColor = true;
			this.canelButton.Click += new global::System.EventHandler(this.canelButton_Click);
			this.okButton.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Right);
			this.okButton.Location = new global::System.Drawing.Point(255, 442);
			this.okButton.Name = "okButton";
			this.okButton.Size = new global::System.Drawing.Size(75, 23);
			this.okButton.TabIndex = 19;
			this.okButton.Text = "OK";
			this.okButton.UseVisualStyleBackColor = true;
			this.okButton.Click += new global::System.EventHandler(this.okButton_Click);
			this.groupBox1.Controls.Add(this.t11);
			this.groupBox1.Controls.Add(this.t10);
			this.groupBox1.Controls.Add(this.t9);
			this.groupBox1.Controls.Add(this.t8);
			this.groupBox1.Controls.Add(this.t7);
			this.groupBox1.Controls.Add(this.t6);
			this.groupBox1.Controls.Add(this.t5);
			this.groupBox1.Controls.Add(this.t4);
			this.groupBox1.Controls.Add(this.t3);
			this.groupBox1.Controls.Add(this.t2);
			this.groupBox1.Controls.Add(this.t1);
			this.groupBox1.Controls.Add(this.t0);
			this.groupBox1.Location = new global::System.Drawing.Point(11, 284);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new global::System.Drawing.Size(399, 152);
			this.groupBox1.TabIndex = 31;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Transformation";
			this.t11.Location = new global::System.Drawing.Point(268, 119);
			this.t11.Name = "t11";
			this.t11.Size = new global::System.Drawing.Size(116, 20);
			this.t11.TabIndex = 42;
			this.t10.Location = new global::System.Drawing.Point(268, 87);
			this.t10.Name = "t10";
			this.t10.Size = new global::System.Drawing.Size(116, 20);
			this.t10.TabIndex = 41;
			this.t9.Location = new global::System.Drawing.Point(268, 55);
			this.t9.Name = "t9";
			this.t9.Size = new global::System.Drawing.Size(116, 20);
			this.t9.TabIndex = 40;
			this.t8.Location = new global::System.Drawing.Point(268, 23);
			this.t8.Name = "t8";
			this.t8.Size = new global::System.Drawing.Size(116, 20);
			this.t8.TabIndex = 39;
			this.t7.AcceptsReturn = true;
			this.t7.Location = new global::System.Drawing.Point(141, 119);
			this.t7.Name = "t7";
			this.t7.Size = new global::System.Drawing.Size(116, 20);
			this.t7.TabIndex = 38;
			this.t6.Location = new global::System.Drawing.Point(141, 87);
			this.t6.Name = "t6";
			this.t6.Size = new global::System.Drawing.Size(116, 20);
			this.t6.TabIndex = 37;
			this.t5.Location = new global::System.Drawing.Point(141, 55);
			this.t5.Name = "t5";
			this.t5.Size = new global::System.Drawing.Size(116, 20);
			this.t5.TabIndex = 36;
			this.t4.Location = new global::System.Drawing.Point(141, 23);
			this.t4.Name = "t4";
			this.t4.Size = new global::System.Drawing.Size(116, 20);
			this.t4.TabIndex = 35;
			this.t3.Location = new global::System.Drawing.Point(16, 119);
			this.t3.Name = "t3";
			this.t3.Size = new global::System.Drawing.Size(116, 20);
			this.t3.TabIndex = 34;
			this.t2.Location = new global::System.Drawing.Point(16, 87);
			this.t2.Name = "t2";
			this.t2.Size = new global::System.Drawing.Size(116, 20);
			this.t2.TabIndex = 33;
			this.t1.Location = new global::System.Drawing.Point(16, 55);
			this.t1.Name = "t1";
			this.t1.Size = new global::System.Drawing.Size(116, 20);
			this.t1.TabIndex = 32;
			this.t0.Location = new global::System.Drawing.Point(16, 23);
			this.t0.Name = "t0";
			this.t0.Size = new global::System.Drawing.Size(116, 20);
			this.t0.TabIndex = 31;
			this.groupBox2.Controls.Add(this.comboBox1);
			this.groupBox2.Controls.Add(this.label6);
			this.groupBox2.Controls.Add(this.listView1);
			this.groupBox2.Controls.Add(this.label5);
			this.groupBox2.Controls.Add(this.label4);
			this.groupBox2.Controls.Add(this.textBox2);
			this.groupBox2.Controls.Add(this.label3);
			this.groupBox2.Controls.Add(this.boneHash);
			this.groupBox2.Controls.Add(this.label2);
			this.groupBox2.Controls.Add(this.nameHash);
			this.groupBox2.Controls.Add(this.label1);
			this.groupBox2.Location = new global::System.Drawing.Point(12, 15);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new global::System.Drawing.Size(398, 263);
			this.groupBox2.TabIndex = 32;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Settings";
			this.label6.AutoSize = true;
			this.label6.Location = new global::System.Drawing.Point(13, 107);
			this.label6.Name = "label6";
			this.label6.Size = new global::System.Drawing.Size(96, 13);
			this.label6.TabIndex = 44;
			this.label6.Text = "( - name of bone - )";
			this.listView1.CheckBoxes = true;
			this.listView1.Columns.AddRange(new global::System.Windows.Forms.ColumnHeader[]
			{
				this.columnHeader_0
			});
			listViewItem.StateImageIndex = 0;
			listViewItem.Tag = "0x1";
			listViewItem2.StateImageIndex = 0;
			listViewItem2.Tag = "0x8";
			listViewItem3.StateImageIndex = 0;
			listViewItem3.Tag = "0x10";
			listViewItem4.StateImageIndex = 0;
			listViewItem4.Tag = "0x20";
			listViewItem5.StateImageIndex = 0;
			listViewItem5.Tag = "0x100";
			listViewItem6.StateImageIndex = 0;
			listViewItem6.Tag = "0x200";
			listViewItem7.StateImageIndex = 0;
			listViewItem7.Tag = "0x400";
			listViewItem8.StateImageIndex = 0;
			listViewItem8.Tag = "0x800";
			listViewItem9.StateImageIndex = 0;
			listViewItem9.Tag = "0x1000";
			listViewItem10.StateImageIndex = 0;
			listViewItem10.Tag = "0x2000";
			listViewItem11.StateImageIndex = 0;
			listViewItem11.Tag = "0x40000";
			listViewItem12.StateImageIndex = 0;
			listViewItem12.Tag = "0x80000";
			listViewItem13.StateImageIndex = 0;
			listViewItem13.Tag = "0x01000000";
			listViewItem14.StateImageIndex = 0;
			listViewItem14.Tag = "0x02000000";
			listViewItem15.StateImageIndex = 0;
			listViewItem15.Tag = "0x04000000";
			listViewItem16.StateImageIndex = 0;
			listViewItem16.Tag = "0x10000000";
			listViewItem17.StateImageIndex = 0;
			listViewItem17.Tag = "0x20000000";
			listViewItem18.StateImageIndex = 0;
			listViewItem18.Tag = "0x40000000";
			this.listView1.Items.AddRange(new global::System.Windows.Forms.ListViewItem[]
			{
				listViewItem,
				listViewItem2,
				listViewItem3,
				listViewItem4,
				listViewItem5,
				listViewItem6,
				listViewItem7,
				listViewItem8,
				listViewItem9,
				listViewItem10,
				listViewItem11,
				listViewItem12,
				listViewItem13,
				listViewItem14,
				listViewItem15,
				listViewItem16,
				listViewItem17,
				listViewItem18
			});
			this.listView1.Location = new global::System.Drawing.Point(15, 146);
			this.listView1.Name = "listView1";
			this.listView1.ShowGroups = false;
			this.listView1.Size = new global::System.Drawing.Size(367, 103);
			this.listView1.TabIndex = 43;
			this.listView1.UseCompatibleStateImageBehavior = false;
			this.listView1.View = global::System.Windows.Forms.View.Details;
			this.columnHeader_0.Width = 345;
			this.label5.AutoSize = true;
			this.label5.Location = new global::System.Drawing.Point(137, 63);
			this.label5.Name = "label5";
			this.label5.Size = new global::System.Drawing.Size(88, 13);
			this.label5.TabIndex = 15;
			this.label5.Text = "New bone name:";
			this.label4.AutoSize = true;
			this.label4.Location = new global::System.Drawing.Point(137, 24);
			this.label4.Name = "label4";
			this.label4.Size = new global::System.Drawing.Size(61, 13);
			this.label4.TabIndex = 14;
			this.label4.Text = "New name:";
			this.textBox2.Location = new global::System.Drawing.Point(140, 80);
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new global::System.Drawing.Size(242, 20);
			this.textBox2.TabIndex = 13;
			this.textBox2.TextChanged += new global::System.EventHandler(this.textBox2_TextChanged);
			this.label3.AutoSize = true;
			this.label3.Location = new global::System.Drawing.Point(13, 130);
			this.label3.Name = "label3";
			this.label3.Size = new global::System.Drawing.Size(85, 13);
			this.label3.TabIndex = 10;
			this.label3.Text = "Placement flags:";
			this.boneHash.Location = new global::System.Drawing.Point(15, 80);
			this.boneHash.Name = "boneHash";
			this.boneHash.Size = new global::System.Drawing.Size(116, 20);
			this.boneHash.TabIndex = 9;
			this.label2.AutoSize = true;
			this.label2.Location = new global::System.Drawing.Point(13, 64);
			this.label2.Name = "label2";
			this.label2.Size = new global::System.Drawing.Size(61, 13);
			this.label2.TabIndex = 8;
			this.label2.Text = "Bone hash:";
			this.nameHash.Location = new global::System.Drawing.Point(15, 40);
			this.nameHash.Name = "nameHash";
			this.nameHash.Size = new global::System.Drawing.Size(116, 20);
			this.nameHash.TabIndex = 7;
			this.label1.AutoSize = true;
			this.label1.Location = new global::System.Drawing.Point(13, 24);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(64, 13);
			this.label1.TabIndex = 6;
			this.label1.Text = "Name hash:";
			this.comboBox1.AllowDrop = true;
			this.comboBox1.AutoCompleteCustomSource.AddRange(new string[]
			{
				"ContainmentSlot_0 ",
				"ContainmentSlot_1 ",
				"ContainmentSlot_10",
				"ContainmentSlot_11",
				"ContainmentSlot_12",
				"ContainmentSlot_13",
				"ContainmentSlot_14",
				"ContainmentSlot_15",
				"ContainmentSlot_16",
				"ContainmentSlot_17",
				"ContainmentSlot_18",
				"ContainmentSlot_19",
				"ContainmentSlot_2 ",
				"ContainmentSlot_20",
				"ContainmentSlot_21",
				"ContainmentSlot_22",
				"ContainmentSlot_23",
				"ContainmentSlot_3 ",
				"ContainmentSlot_4 ",
				"ContainmentSlot_41",
				"ContainmentSlot_42",
				"ContainmentSlot_43",
				"ContainmentSlot_5 ",
				"ContainmentSlot_6 ",
				"ContainmentSlot_62",
				"ContainmentSlot_7 ",
				"ContainmentSlot_8 ",
				"ContainmentSlot_9 ",
				"ContainmentSlot_Sentinel",
				"DecorativeSlot_12",
				"FXJoint_0",
				"FXJoint_1",
				"FXJoint_2",
				"FXJoint_3",
				"FXJoint_4",
				"FXJoint_5",
				"FXJoint_6",
				"FXJoint_7",
				"FXJoint_8",
				"FXJoint_9",
				"FXJoint_SandsOfUnderstanding",
				"FXJoint_Science_0",
				"FXJoint_Science_1",
				"FXJoint_Science_2",
				"FXJoint_Science_3",
				"FXJoint_Sentinel",
				"IKTarget_0",
				"IKTarget_1",
				"IKTarget_2",
				"IKTarget_3",
				"IKTarget_4",
				"IKTarget_5",
				"IKTarget_6",
				"IKTarget_7",
				"IKTarget_8",
				"IKTarget_9",
				"IKTarget_Sentinel",
				"None",
				"PlacementSlot_E",
				"PlacementSlot_N",
				"PlacementSlot_S",
				"PlacementSlot_Sentinel",
				"PlacementSlot_W",
				"RoutingSlot_0",
				"RoutingSlot_1",
				"RoutingSlot_10",
				"RoutingSlot_11",
				"RoutingSlot_12",
				"RoutingSlot_13",
				"RoutingSlot_14",
				"RoutingSlot_15",
				"RoutingSlot_16",
				"RoutingSlot_17",
				"RoutingSlot_18",
				"RoutingSlot_19",
				"RoutingSlot_2",
				"RoutingSlot_20",
				"RoutingSlot_21",
				"RoutingSlot_22",
				"RoutingSlot_23",
				"RoutingSlot_24",
				"RoutingSlot_25",
				"RoutingSlot_26",
				"RoutingSlot_27",
				"RoutingSlot_28",
				"RoutingSlot_29",
				"RoutingSlot_3",
				"RoutingSlot_4",
				"RoutingSlot_5",
				"RoutingSlot_6",
				"RoutingSlot_7",
				"RoutingSlot_8",
				"RoutingSlot_9",
				"RoutingSlot_Sentinel",
				"RoutingSlotBase",
				"RoutingSlotChildBase",
				"RoutingSlotCorner",
				"TransformBone",
				"ContainmentSlotCenterBase",
				"ContainmentSlotCenterCorner",
				"ContainmentSlotFoodPrepBase",
				"ContainmentSlotFoodPrepCorner",
				"PlateCommon",
				"PlateCorner",
				"LaptopCommon",
				"LaptopCorner",
				"StoolCommon",
				"StoolCorner",
				"RoutingSlotBase",
				"RoutingSlotChildBase",
				"RoutingSlotCorner",
				"RoutingSlotChildCorner",
				"RoutingSlotSink",
				"PlacementSlotNorth",
				"PlacementSlotSouth",
				"PlacementSlotEast",
				"PlacementSlotWest",
				"ApplianceSlot",
				"PlacementSlotCabinet",
				"PlacementSlotCounter",
				"DecoBase0",
				"DecoBase1",
				"DecoBase2",
				"DecoCommon0",
				"DecoCorner0",
				"DecoCorner1",
				"DecoCorner2",
				"DecoCorner3",
				"ContainmentSlotSinkBase",
				"FireplaceToolSlot"
			});
			this.comboBox1.AutoCompleteMode = global::System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.comboBox1.AutoCompleteSource = global::System.Windows.Forms.AutoCompleteSource.CustomSource;
			this.comboBox1.FormattingEnabled = true;
			this.comboBox1.Location = new global::System.Drawing.Point(140, 40);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new global::System.Drawing.Size(242, 21);
			this.comboBox1.TabIndex = 45;
			this.comboBox1.TextUpdate += new global::System.EventHandler(this.comboBox1_TextUpdate);
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new global::System.Drawing.Size(422, 471);
			base.Controls.Add(this.groupBox2);
			base.Controls.Add(this.groupBox1);
			base.Controls.Add(this.okButton);
			base.Controls.Add(this.canelButton);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			base.Name = "ContainerSlotEditor";
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Slot Editor";
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			base.ResumeLayout(false);
		}

		// Token: 0x04000032 RID: 50
		private global::System.Windows.Forms.Button canelButton;

		// Token: 0x04000033 RID: 51
		private global::System.Windows.Forms.Button okButton;

		// Token: 0x04000034 RID: 52
		private global::System.Windows.Forms.GroupBox groupBox1;

		// Token: 0x04000035 RID: 53
		private global::System.Windows.Forms.TextBox t11;

		// Token: 0x04000036 RID: 54
		private global::System.Windows.Forms.TextBox t10;

		// Token: 0x04000037 RID: 55
		private global::System.Windows.Forms.TextBox t9;

		// Token: 0x04000038 RID: 56
		private global::System.Windows.Forms.TextBox t8;

		// Token: 0x04000039 RID: 57
		private global::System.Windows.Forms.TextBox t7;

		// Token: 0x0400003A RID: 58
		private global::System.Windows.Forms.TextBox t6;

		// Token: 0x0400003B RID: 59
		private global::System.Windows.Forms.TextBox t5;

		// Token: 0x0400003C RID: 60
		private global::System.Windows.Forms.TextBox t4;

		// Token: 0x0400003D RID: 61
		private global::System.Windows.Forms.TextBox t3;

		// Token: 0x0400003E RID: 62
		private global::System.Windows.Forms.TextBox t2;

		// Token: 0x0400003F RID: 63
		private global::System.Windows.Forms.TextBox t1;

		// Token: 0x04000040 RID: 64
		private global::System.Windows.Forms.TextBox t0;

		// Token: 0x04000041 RID: 65
		private global::System.Windows.Forms.GroupBox groupBox2;

		// Token: 0x04000042 RID: 66
		private global::System.Windows.Forms.Label label3;

		// Token: 0x04000043 RID: 67
		private global::System.Windows.Forms.TextBox boneHash;

		// Token: 0x04000044 RID: 68
		private global::System.Windows.Forms.Label label2;

		// Token: 0x04000045 RID: 69
		private global::System.Windows.Forms.TextBox nameHash;

		// Token: 0x04000046 RID: 70
		private global::System.Windows.Forms.Label label1;

		// Token: 0x04000047 RID: 71
		private global::System.Windows.Forms.Label label5;

		// Token: 0x04000048 RID: 72
		private global::System.Windows.Forms.Label label4;

		// Token: 0x04000049 RID: 73
		private global::System.Windows.Forms.TextBox textBox2;

		// Token: 0x0400004A RID: 74
		private global::System.Windows.Forms.ListView listView1;

		// Token: 0x0400004B RID: 75
		private global::System.Windows.Forms.ColumnHeader columnHeader_0;

		// Token: 0x0400004C RID: 76
		private global::System.Windows.Forms.Label label6;

		// Token: 0x0400004D RID: 77
		private global::System.Windows.Forms.ComboBox comboBox1;
	}
}
