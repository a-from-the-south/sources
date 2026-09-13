using System;
using System.CodeDom.Compiler;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Configuration;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;

namespace Sims3Workshop.Properties
{
	// Token: 0x02000139 RID: 313
	[CompilerGenerated]
	[GeneratedCode("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "11.0.0.0")]
	public sealed partial class Settings : ApplicationSettingsBase
	{
		// Token: 0x17000324 RID: 804
		// (get) Token: 0x06000EC6 RID: 3782 RVA: 0x000B5C2C File Offset: 0x000B3E2C
		public static Settings Default
		{
			get
			{
				return Settings.settings_0;
			}
		}

		// Token: 0x17000325 RID: 805
		// (get) Token: 0x06000EC7 RID: 3783 RVA: 0x000B5C44 File Offset: 0x000B3E44
		// (set) Token: 0x06000EC8 RID: 3784 RVA: 0x00007C18 File Offset: 0x00005E18
		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("White")]
		public Color MesheditorBackgroundColor
		{
			get
			{
				return (Color)this["MesheditorBackgroundColor"];
			}
			set
			{
				this["MesheditorBackgroundColor"] = value;
			}
		}

		// Token: 0x17000326 RID: 806
		// (get) Token: 0x06000EC9 RID: 3785 RVA: 0x000B5C68 File Offset: 0x000B3E68
		// (set) Token: 0x06000ECA RID: 3786 RVA: 0x00007C2D File Offset: 0x00005E2D
		[DefaultSettingValue("")]
		[DebuggerNonUserCode]
		[UserScopedSetting]
		public string CreatorName
		{
			get
			{
				return (string)this["CreatorName"];
			}
			set
			{
				this["CreatorName"] = value;
			}
		}

		// Token: 0x17000327 RID: 807
		// (get) Token: 0x06000ECB RID: 3787 RVA: 0x000B5C8C File Offset: 0x000B3E8C
		// (set) Token: 0x06000ECC RID: 3788 RVA: 0x00007C3D File Offset: 0x00005E3D
		[DebuggerNonUserCode]
		[DefaultSettingValue("")]
		[UserScopedSetting]
		public string CreatorWebsite
		{
			get
			{
				return (string)this["CreatorWebsite"];
			}
			set
			{
				this["CreatorWebsite"] = value;
			}
		}

		// Token: 0x17000328 RID: 808
		// (get) Token: 0x06000ECD RID: 3789 RVA: 0x000B5CB0 File Offset: 0x000B3EB0
		// (set) Token: 0x06000ECE RID: 3790 RVA: 0x00007C4D File Offset: 0x00005E4D
		[DefaultSettingValue("True")]
		[DebuggerNonUserCode]
		[UserScopedSetting]
		public bool AskCreatorInfo
		{
			get
			{
				return (bool)this["AskCreatorInfo"];
			}
			set
			{
				this["AskCreatorInfo"] = value;
			}
		}

		// Token: 0x17000329 RID: 809
		// (get) Token: 0x06000ECF RID: 3791 RVA: 0x000B5CD4 File Offset: 0x000B3ED4
		// (set) Token: 0x06000ED0 RID: 3792 RVA: 0x00007C62 File Offset: 0x00005E62
		[DebuggerNonUserCode]
		[UserScopedSetting]
		[DefaultSettingValue("")]
		public string TSREmail
		{
			get
			{
				return (string)this["TSREmail"];
			}
			set
			{
				this["TSREmail"] = value;
			}
		}

		// Token: 0x1700032A RID: 810
		// (get) Token: 0x06000ED1 RID: 3793 RVA: 0x000B5CF8 File Offset: 0x000B3EF8
		// (set) Token: 0x06000ED2 RID: 3794 RVA: 0x00007C72 File Offset: 0x00005E72
		[DefaultSettingValue("")]
		[DebuggerNonUserCode]
		[UserScopedSetting]
		public string TSRPassword
		{
			get
			{
				return (string)this["TSRPassword"];
			}
			set
			{
				this["TSRPassword"] = value;
			}
		}

		// Token: 0x1700032B RID: 811
		// (get) Token: 0x06000ED3 RID: 3795 RVA: 0x000B5D1C File Offset: 0x000B3F1C
		// (set) Token: 0x06000ED4 RID: 3796 RVA: 0x00007C82 File Offset: 0x00005E82
		[DefaultSettingValue("")]
		[DebuggerNonUserCode]
		[UserScopedSetting]
		public string Sims3InstallationPath
		{
			get
			{
				return (string)this["Sims3InstallationPath"];
			}
			set
			{
				this["Sims3InstallationPath"] = value;
			}
		}

		// Token: 0x1700032C RID: 812
		// (get) Token: 0x06000ED5 RID: 3797 RVA: 0x000B5D40 File Offset: 0x000B3F40
		// (set) Token: 0x06000ED6 RID: 3798 RVA: 0x00007C92 File Offset: 0x00005E92
		[DefaultSettingValue("187, 134, 111")]
		[DebuggerNonUserCode]
		[UserScopedSetting]
		public Color SkinColor
		{
			get
			{
				return (Color)this["SkinColor"];
			}
			set
			{
				this["SkinColor"] = value;
			}
		}

		// Token: 0x1700032D RID: 813
		// (get) Token: 0x06000ED7 RID: 3799 RVA: 0x000B5D64 File Offset: 0x000B3F64
		// (set) Token: 0x06000ED8 RID: 3800 RVA: 0x00007CA7 File Offset: 0x00005EA7
		[DebuggerNonUserCode]
		[DefaultSettingValue("")]
		[UserScopedSetting]
		public string Setting
		{
			get
			{
				return (string)this["Setting"];
			}
			set
			{
				this["Setting"] = value;
			}
		}

		// Token: 0x1700032F RID: 815
		// (get) Token: 0x06000EDB RID: 3803 RVA: 0x000B5DAC File Offset: 0x000B3FAC
		// (set) Token: 0x06000EDC RID: 3804 RVA: 0x00007CC7 File Offset: 0x00005EC7
		[DefaultSettingValue("True")]
		[UserScopedSetting]
		[DebuggerNonUserCode]
		public bool IsFirstRun
		{
			get
			{
				return (bool)this["IsFirstRun"];
			}
			set
			{
				this["IsFirstRun"] = value;
			}
		}

		// Token: 0x17000330 RID: 816
		// (get) Token: 0x06000EDD RID: 3805 RVA: 0x000B5DD0 File Offset: 0x000B3FD0
		// (set) Token: 0x06000EDE RID: 3806 RVA: 0x00007CDC File Offset: 0x00005EDC
		[DefaultSettingValue("False")]
		[UserScopedSetting]
		[DebuggerNonUserCode]
		public bool AllowInternet
		{
			get
			{
				return (bool)this["AllowInternet"];
			}
			set
			{
				this["AllowInternet"] = value;
			}
		}

		// Token: 0x17000331 RID: 817
		// (get) Token: 0x06000EDF RID: 3807 RVA: 0x000B5DF4 File Offset: 0x000B3FF4
		// (set) Token: 0x06000EE0 RID: 3808 RVA: 0x00007CF1 File Offset: 0x00005EF1
		[DebuggerNonUserCode]
		[DefaultSettingValue("True")]
		[UserScopedSetting]
		public bool AskAllowInternet
		{
			get
			{
				return (bool)this["AskAllowInternet"];
			}
			set
			{
				this["AskAllowInternet"] = value;
			}
		}

		// Token: 0x17000332 RID: 818
		// (get) Token: 0x06000EE1 RID: 3809 RVA: 0x000B5E18 File Offset: 0x000B4018
		// (set) Token: 0x06000EE2 RID: 3810 RVA: 0x00007D06 File Offset: 0x00005F06
		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("32, 32, 32")]
		public Color AmbientLighting
		{
			get
			{
				return (Color)this["AmbientLighting"];
			}
			set
			{
				this["AmbientLighting"] = value;
			}
		}

		// Token: 0x17000333 RID: 819
		// (get) Token: 0x06000EE3 RID: 3811 RVA: 0x000B5E3C File Offset: 0x000B403C
		// (set) Token: 0x06000EE4 RID: 3812 RVA: 0x00007D1B File Offset: 0x00005F1B
		[UserScopedSetting]
		[DefaultSettingValue("DarkGreen")]
		[DebuggerNonUserCode]
		public Color GroundColor
		{
			get
			{
				return (Color)this["GroundColor"];
			}
			set
			{
				this["GroundColor"] = value;
			}
		}

		// Token: 0x17000334 RID: 820
		// (get) Token: 0x06000EE5 RID: 3813 RVA: 0x000B5E60 File Offset: 0x000B4060
		// (set) Token: 0x06000EE6 RID: 3814 RVA: 0x00007D30 File Offset: 0x00005F30
		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("0")]
		public float redAdjust
		{
			get
			{
				return (float)this["redAdjust"];
			}
			set
			{
				this["redAdjust"] = value;
			}
		}

		// Token: 0x17000335 RID: 821
		// (get) Token: 0x06000EE7 RID: 3815 RVA: 0x000B5E84 File Offset: 0x000B4084
		// (set) Token: 0x06000EE8 RID: 3816 RVA: 0x00007D45 File Offset: 0x00005F45
		[DebuggerNonUserCode]
		[UserScopedSetting]
		[DefaultSettingValue("0")]
		public float greenAdjust
		{
			get
			{
				return (float)this["greenAdjust"];
			}
			set
			{
				this["greenAdjust"] = value;
			}
		}

		// Token: 0x17000336 RID: 822
		// (get) Token: 0x06000EE9 RID: 3817 RVA: 0x000B5EA8 File Offset: 0x000B40A8
		// (set) Token: 0x06000EEA RID: 3818 RVA: 0x00007D5A File Offset: 0x00005F5A
		[DebuggerNonUserCode]
		[UserScopedSetting]
		[DefaultSettingValue("0")]
		public float blueAdjust
		{
			get
			{
				return (float)this["blueAdjust"];
			}
			set
			{
				this["blueAdjust"] = value;
			}
		}

		// Token: 0x17000337 RID: 823
		// (get) Token: 0x06000EEB RID: 3819 RVA: 0x000B5ECC File Offset: 0x000B40CC
		// (set) Token: 0x06000EEC RID: 3820 RVA: 0x00007D6F File Offset: 0x00005F6F
		[UserScopedSetting]
		[DefaultSettingValue("")]
		[DebuggerNonUserCode]
		public string Sims3WorldAdventuresGamePath
		{
			get
			{
				return (string)this["Sims3WorldAdventuresGamePath"];
			}
			set
			{
				this["Sims3WorldAdventuresGamePath"] = value;
			}
		}

		// Token: 0x17000338 RID: 824
		// (get) Token: 0x06000EED RID: 3821 RVA: 0x000B5EF0 File Offset: 0x000B40F0
		// (set) Token: 0x06000EEE RID: 3822 RVA: 0x00007D7F File Offset: 0x00005F7F
		[DefaultSettingValue("White")]
		[UserScopedSetting]
		[DebuggerNonUserCode]
		public Color GridColor
		{
			get
			{
				return (Color)this["GridColor"];
			}
			set
			{
				this["GridColor"] = value;
			}
		}

		// Token: 0x17000339 RID: 825
		// (get) Token: 0x06000EEF RID: 3823 RVA: 0x000B5F14 File Offset: 0x000B4114
		// (set) Token: 0x06000EF0 RID: 3824 RVA: 0x00007D94 File Offset: 0x00005F94
		[DefaultSettingValue("")]
		[UserScopedSetting]
		[DebuggerNonUserCode]
		public string Sims3HelsGamePath
		{
			get
			{
				return (string)this["Sims3HelsGamePath"];
			}
			set
			{
				this["Sims3HelsGamePath"] = value;
			}
		}

		// Token: 0x1700033A RID: 826
		// (get) Token: 0x06000EF1 RID: 3825 RVA: 0x000B5F38 File Offset: 0x000B4138
		// (set) Token: 0x06000EF2 RID: 3826 RVA: 0x00007DA4 File Offset: 0x00005FA4
		[DefaultSettingValue("")]
		[UserScopedSetting]
		[DebuggerNonUserCode]
		public string Sims3AmbitiationGamePath
		{
			get
			{
				return (string)this["Sims3AmbitiationGamePath"];
			}
			set
			{
				this["Sims3AmbitiationGamePath"] = value;
			}
		}

		// Token: 0x1700033B RID: 827
		// (get) Token: 0x06000EF3 RID: 3827 RVA: 0x000B5F5C File Offset: 0x000B415C
		// (set) Token: 0x06000EF4 RID: 3828 RVA: 0x00007DB4 File Offset: 0x00005FB4
		[DefaultSettingValue("")]
		[DebuggerNonUserCode]
		[UserScopedSetting]
		public string Sims3FastLaneGamePath
		{
			get
			{
				return (string)this["Sims3FastLaneGamePath"];
			}
			set
			{
				this["Sims3FastLaneGamePath"] = value;
			}
		}

		// Token: 0x1700033C RID: 828
		// (get) Token: 0x06000EF5 RID: 3829 RVA: 0x000B5F80 File Offset: 0x000B4180
		// (set) Token: 0x06000EF6 RID: 3830 RVA: 0x00007DC4 File Offset: 0x00005FC4
		[DefaultSettingValue("")]
		[UserScopedSetting]
		[DebuggerNonUserCode]
		public string Sims3LateNightGamePath
		{
			get
			{
				return (string)this["Sims3LateNightGamePath"];
			}
			set
			{
				this["Sims3LateNightGamePath"] = value;
			}
		}

		// Token: 0x1700033D RID: 829
		// (get) Token: 0x06000EF7 RID: 3831 RVA: 0x000B5FA4 File Offset: 0x000B41A4
		// (set) Token: 0x06000EF8 RID: 3832 RVA: 0x00007DD4 File Offset: 0x00005FD4
		[UserScopedSetting]
		[DefaultSettingValue("")]
		[DebuggerNonUserCode]
		public string Recent1
		{
			get
			{
				return (string)this["Recent1"];
			}
			set
			{
				this["Recent1"] = value;
			}
		}

		// Token: 0x1700033E RID: 830
		// (get) Token: 0x06000EF9 RID: 3833 RVA: 0x000B5FC8 File Offset: 0x000B41C8
		// (set) Token: 0x06000EFA RID: 3834 RVA: 0x00007DE4 File Offset: 0x00005FE4
		[UserScopedSetting]
		[DefaultSettingValue("")]
		[DebuggerNonUserCode]
		public string Recent2
		{
			get
			{
				return (string)this["Recent2"];
			}
			set
			{
				this["Recent2"] = value;
			}
		}

		// Token: 0x1700033F RID: 831
		// (get) Token: 0x06000EFB RID: 3835 RVA: 0x000B5FEC File Offset: 0x000B41EC
		// (set) Token: 0x06000EFC RID: 3836 RVA: 0x00007DF4 File Offset: 0x00005FF4
		[DebuggerNonUserCode]
		[UserScopedSetting]
		[DefaultSettingValue("")]
		public string Recent3
		{
			get
			{
				return (string)this["Recent3"];
			}
			set
			{
				this["Recent3"] = value;
			}
		}

		// Token: 0x17000340 RID: 832
		// (get) Token: 0x06000EFD RID: 3837 RVA: 0x000B6010 File Offset: 0x000B4210
		// (set) Token: 0x06000EFE RID: 3838 RVA: 0x00007E04 File Offset: 0x00006004
		[DefaultSettingValue("")]
		[UserScopedSetting]
		[DebuggerNonUserCode]
		public string Recent4
		{
			get
			{
				return (string)this["Recent4"];
			}
			set
			{
				this["Recent4"] = value;
			}
		}

		// Token: 0x17000341 RID: 833
		// (get) Token: 0x06000EFF RID: 3839 RVA: 0x000B6034 File Offset: 0x000B4234
		// (set) Token: 0x06000F00 RID: 3840 RVA: 0x00007E14 File Offset: 0x00006014
		[DefaultSettingValue("")]
		[UserScopedSetting]
		[DebuggerNonUserCode]
		public string Recent5
		{
			get
			{
				return (string)this["Recent5"];
			}
			set
			{
				this["Recent5"] = value;
			}
		}

		// Token: 0x17000342 RID: 834
		// (get) Token: 0x06000F01 RID: 3841 RVA: 0x000B6058 File Offset: 0x000B4258
		// (set) Token: 0x06000F02 RID: 3842 RVA: 0x00007E24 File Offset: 0x00006024
		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("")]
		public string Recent6
		{
			get
			{
				return (string)this["Recent6"];
			}
			set
			{
				this["Recent6"] = value;
			}
		}

		// Token: 0x17000343 RID: 835
		// (get) Token: 0x06000F03 RID: 3843 RVA: 0x000B607C File Offset: 0x000B427C
		// (set) Token: 0x06000F04 RID: 3844 RVA: 0x00007E34 File Offset: 0x00006034
		[UserScopedSetting]
		[DefaultSettingValue("")]
		[DebuggerNonUserCode]
		public string Recent7
		{
			get
			{
				return (string)this["Recent7"];
			}
			set
			{
				this["Recent7"] = value;
			}
		}

		// Token: 0x17000344 RID: 836
		// (get) Token: 0x06000F05 RID: 3845 RVA: 0x000B60A0 File Offset: 0x000B42A0
		// (set) Token: 0x06000F06 RID: 3846 RVA: 0x00007E44 File Offset: 0x00006044
		[UserScopedSetting]
		[DefaultSettingValue("")]
		[DebuggerNonUserCode]
		public string Recent8
		{
			get
			{
				return (string)this["Recent8"];
			}
			set
			{
				this["Recent8"] = value;
			}
		}

		// Token: 0x17000345 RID: 837
		// (get) Token: 0x06000F07 RID: 3847 RVA: 0x000B60C4 File Offset: 0x000B42C4
		// (set) Token: 0x06000F08 RID: 3848 RVA: 0x00007E54 File Offset: 0x00006054
		[DefaultSettingValue("")]
		[UserScopedSetting]
		[DebuggerNonUserCode]
		public string Recent9
		{
			get
			{
				return (string)this["Recent9"];
			}
			set
			{
				this["Recent9"] = value;
			}
		}

		// Token: 0x17000346 RID: 838
		// (get) Token: 0x06000F09 RID: 3849 RVA: 0x000B60E8 File Offset: 0x000B42E8
		// (set) Token: 0x06000F0A RID: 3850 RVA: 0x00007E64 File Offset: 0x00006064
		[DefaultSettingValue("")]
		[DebuggerNonUserCode]
		[UserScopedSetting]
		public string Recent10
		{
			get
			{
				return (string)this["Recent10"];
			}
			set
			{
				this["Recent10"] = value;
			}
		}

		// Token: 0x17000347 RID: 839
		// (get) Token: 0x06000F0B RID: 3851 RVA: 0x000B610C File Offset: 0x000B430C
		// (set) Token: 0x06000F0C RID: 3852 RVA: 0x00007E74 File Offset: 0x00006074
		[DefaultSettingValue("")]
		[DebuggerNonUserCode]
		[UserScopedSetting]
		public string Sims3OutDoorLifeGamePath
		{
			get
			{
				return (string)this["Sims3OutDoorLifeGamePath"];
			}
			set
			{
				this["Sims3OutDoorLifeGamePath"] = value;
			}
		}

		// Token: 0x17000348 RID: 840
		// (get) Token: 0x06000F0D RID: 3853 RVA: 0x000B6130 File Offset: 0x000B4330
		// (set) Token: 0x06000F0E RID: 3854 RVA: 0x00007E84 File Offset: 0x00006084
		[UserScopedSetting]
		[DefaultSettingValue("0")]
		[DebuggerNonUserCode]
		public int width
		{
			get
			{
				return (int)this["width"];
			}
			set
			{
				this["width"] = value;
			}
		}

		// Token: 0x17000349 RID: 841
		// (get) Token: 0x06000F0F RID: 3855 RVA: 0x000B6154 File Offset: 0x000B4354
		// (set) Token: 0x06000F10 RID: 3856 RVA: 0x00007E99 File Offset: 0x00006099
		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("0")]
		public int height
		{
			get
			{
				return (int)this["height"];
			}
			set
			{
				this["height"] = value;
			}
		}

		// Token: 0x1700034A RID: 842
		// (get) Token: 0x06000F11 RID: 3857 RVA: 0x000B6178 File Offset: 0x000B4378
		// (set) Token: 0x06000F12 RID: 3858 RVA: 0x00007EAE File Offset: 0x000060AE
		[DefaultSettingValue("0")]
		[DebuggerNonUserCode]
		[UserScopedSetting]
		public int ismaximized
		{
			get
			{
				return (int)this["ismaximized"];
			}
			set
			{
				this["ismaximized"] = value;
			}
		}

		// Token: 0x17000351 RID: 849
		// (get) Token: 0x06000F1F RID: 3871 RVA: 0x000B6274 File Offset: 0x000B4474
		// (set) Token: 0x06000F20 RID: 3872 RVA: 0x00007F41 File Offset: 0x00006141
		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("")]
		public string exportFormatMesh
		{
			get
			{
				return (string)this["exportFormatMesh"];
			}
			set
			{
				this["exportFormatMesh"] = value;
			}
		}

		// Token: 0x17000352 RID: 850
		// (get) Token: 0x06000F21 RID: 3873 RVA: 0x000B6298 File Offset: 0x000B4498
		// (set) Token: 0x06000F22 RID: 3874 RVA: 0x00007F51 File Offset: 0x00006151
		[UserScopedSetting]
		[DefaultSettingValue("")]
		[DebuggerNonUserCode]
		public string importFormatMesh
		{
			get
			{
				return (string)this["importFormatMesh"];
			}
			set
			{
				this["importFormatMesh"] = value;
			}
		}

		// Token: 0x17000353 RID: 851
		// (get) Token: 0x06000F23 RID: 3875 RVA: 0x000B62BC File Offset: 0x000B44BC
		// (set) Token: 0x06000F24 RID: 3876 RVA: 0x00007F61 File Offset: 0x00006161
		[DefaultSettingValue("")]
		[UserScopedSetting]
		[DebuggerNonUserCode]
		public string exportFormatImage
		{
			get
			{
				return (string)this["exportFormatImage"];
			}
			set
			{
				this["exportFormatImage"] = value;
			}
		}

		// Token: 0x17000354 RID: 852
		// (get) Token: 0x06000F25 RID: 3877 RVA: 0x000B62E0 File Offset: 0x000B44E0
		// (set) Token: 0x06000F26 RID: 3878 RVA: 0x00007F71 File Offset: 0x00006171
		[UserScopedSetting]
		[DefaultSettingValue("")]
		[DebuggerNonUserCode]
		public string importFormatImage
		{
			get
			{
				return (string)this["importFormatImage"];
			}
			set
			{
				this["importFormatImage"] = value;
			}
		}

		// Token: 0x17000355 RID: 853
		// (get) Token: 0x06000F27 RID: 3879 RVA: 0x000B6304 File Offset: 0x000B4504
		// (set) Token: 0x06000F28 RID: 3880 RVA: 0x00007F81 File Offset: 0x00006181
		[DefaultSettingValue("")]
		[UserScopedSetting]
		[DebuggerNonUserCode]
		public string Sims3GenerationsGamePath
		{
			get
			{
				return (string)this["Sims3GenerationsGamePath"];
			}
			set
			{
				this["Sims3GenerationsGamePath"] = value;
			}
		}

		// Token: 0x17000357 RID: 855
		// (get) Token: 0x06000F2B RID: 3883 RVA: 0x000B634C File Offset: 0x000B454C
		// (set) Token: 0x06000F2C RID: 3884 RVA: 0x00007FA6 File Offset: 0x000061A6
		[DefaultSettingValue("")]
		[UserScopedSetting]
		[DebuggerNonUserCode]
		public string Sims3PetsGamePath
		{
			get
			{
				return (string)this["Sims3PetsGamePath"];
			}
			set
			{
				this["Sims3PetsGamePath"] = value;
			}
		}

		// Token: 0x17000359 RID: 857
		// (get) Token: 0x06000F2F RID: 3887 RVA: 0x000B6394 File Offset: 0x000B4594
		// (set) Token: 0x06000F30 RID: 3888 RVA: 0x00007FCB File Offset: 0x000061CB
		[DebuggerNonUserCode]
		[UserScopedSetting]
		[DefaultSettingValue("")]
		public string Sims3TownLifeGameFolder
		{
			get
			{
				return (string)this["Sims3TownLifeGameFolder"];
			}
			set
			{
				this["Sims3TownLifeGameFolder"] = value;
			}
		}

		// Token: 0x1700035C RID: 860
		// (get) Token: 0x06000F35 RID: 3893 RVA: 0x000B6400 File Offset: 0x000B4600
		// (set) Token: 0x06000F36 RID: 3894 RVA: 0x00008005 File Offset: 0x00006205
		[DebuggerNonUserCode]
		[DefaultSettingValue("")]
		[UserScopedSetting]
		public string Sims3ShowtimeGamePath
		{
			get
			{
				return (string)this["Sims3ShowtimeGamePath"];
			}
			set
			{
				this["Sims3ShowtimeGamePath"] = value;
			}
		}

		// Token: 0x1700035D RID: 861
		// (get) Token: 0x06000F37 RID: 3895 RVA: 0x000B6424 File Offset: 0x000B4624
		// (set) Token: 0x06000F38 RID: 3896 RVA: 0x00008015 File Offset: 0x00006215
		[DefaultSettingValue("")]
		[UserScopedSetting]
		[DebuggerNonUserCode]
		public string Sims3MasterSuiteGameFolder
		{
			get
			{
				return (string)this["Sims3MasterSuiteGameFolder"];
			}
			set
			{
				this["Sims3MasterSuiteGameFolder"] = value;
			}
		}

		// Token: 0x1700035F RID: 863
		// (get) Token: 0x06000F3B RID: 3899 RVA: 0x000B646C File Offset: 0x000B466C
		// (set) Token: 0x06000F3C RID: 3900 RVA: 0x0000803A File Offset: 0x0000623A
		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("")]
		public string Sims3KatyPerryGameFolder
		{
			get
			{
				return (string)this["Sims3KatyPerryGameFolder"];
			}
			set
			{
				this["Sims3KatyPerryGameFolder"] = value;
			}
		}

		// Token: 0x17000361 RID: 865
		// (get) Token: 0x06000F3F RID: 3903 RVA: 0x000B64B4 File Offset: 0x000B46B4
		// (set) Token: 0x06000F40 RID: 3904 RVA: 0x0000805F File Offset: 0x0000625F
		[DebuggerNonUserCode]
		[DefaultSettingValue("")]
		[UserScopedSetting]
		public string Sims3DieselGameFolder
		{
			get
			{
				return (string)this["Sims3DieselGameFolder"];
			}
			set
			{
				this["Sims3DieselGameFolder"] = value;
			}
		}

		// Token: 0x17000363 RID: 867
		// (get) Token: 0x06000F43 RID: 3907 RVA: 0x000B64FC File Offset: 0x000B46FC
		// (set) Token: 0x06000F44 RID: 3908 RVA: 0x00008084 File Offset: 0x00006284
		[DefaultSettingValue("")]
		[UserScopedSetting]
		[DebuggerNonUserCode]
		public string myDocumentsFolder
		{
			get
			{
				return (string)this["myDocumentsFolder"];
			}
			set
			{
				this["myDocumentsFolder"] = value;
			}
		}

		// Token: 0x17000364 RID: 868
		// (get) Token: 0x06000F45 RID: 3909 RVA: 0x000B6520 File Offset: 0x000B4720
		// (set) Token: 0x06000F46 RID: 3910 RVA: 0x00008094 File Offset: 0x00006294
		[UserScopedSetting]
		[DefaultSettingValue("")]
		[DebuggerNonUserCode]
		public string scriptClassEditorDefaultNamespace
		{
			get
			{
				return (string)this["scriptClassEditorDefaultNamespace"];
			}
			set
			{
				this["scriptClassEditorDefaultNamespace"] = value;
			}
		}

		// Token: 0x17000365 RID: 869
		// (get) Token: 0x06000F47 RID: 3911 RVA: 0x000B6544 File Offset: 0x000B4744
		// (set) Token: 0x06000F48 RID: 3912 RVA: 0x000080A4 File Offset: 0x000062A4
		[DebuggerNonUserCode]
		[DefaultSettingValue("")]
		[UserScopedSetting]
		public string Sims3SupernaturalGameFolder
		{
			get
			{
				return (string)this["Sims3SupernaturalGameFolder"];
			}
			set
			{
				this["Sims3SupernaturalGameFolder"] = value;
			}
		}

		// Token: 0x17000366 RID: 870
		// (get) Token: 0x06000F49 RID: 3913 RVA: 0x000B6568 File Offset: 0x000B4768
		// (set) Token: 0x06000F4A RID: 3914 RVA: 0x000080B4 File Offset: 0x000062B4
		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("False")]
		public bool supernaturalEnabled
		{
			get
			{
				return (bool)this["supernaturalEnabled"];
			}
			set
			{
				this["supernaturalEnabled"] = value;
			}
		}

		// Token: 0x17000367 RID: 871
		// (get) Token: 0x06000F4B RID: 3915 RVA: 0x000B658C File Offset: 0x000B478C
		// (set) Token: 0x06000F4C RID: 3916 RVA: 0x000080C9 File Offset: 0x000062C9
		[DefaultSettingValue("")]
		[UserScopedSetting]
		[DebuggerNonUserCode]
		public string Sims3SeasonsGameFolder
		{
			get
			{
				return (string)this["Sims3SeasonsGameFolder"];
			}
			set
			{
				this["Sims3SeasonsGameFolder"] = value;
			}
		}

		// Token: 0x17000368 RID: 872
		// (get) Token: 0x06000F4D RID: 3917 RVA: 0x000B65B0 File Offset: 0x000B47B0
		// (set) Token: 0x06000F4E RID: 3918 RVA: 0x000080D9 File Offset: 0x000062D9
		[DefaultSettingValue("False")]
		[UserScopedSetting]
		[DebuggerNonUserCode]
		public bool seasonsEnabled
		{
			get
			{
				return (bool)this["seasonsEnabled"];
			}
			set
			{
				this["seasonsEnabled"] = value;
			}
		}

		// Token: 0x17000369 RID: 873
		// (get) Token: 0x06000F4F RID: 3919 RVA: 0x000B65D4 File Offset: 0x000B47D4
		// (set) Token: 0x06000F50 RID: 3920 RVA: 0x000080EE File Offset: 0x000062EE
		[DefaultSettingValue("")]
		[UserScopedSetting]
		[DebuggerNonUserCode]
		public string Sims3SeventyGameFolder
		{
			get
			{
				return (string)this["Sims3SeventyGameFolder"];
			}
			set
			{
				this["Sims3SeventyGameFolder"] = value;
			}
		}

		// Token: 0x1700036A RID: 874
		// (get) Token: 0x06000F51 RID: 3921 RVA: 0x000B65F8 File Offset: 0x000B47F8
		// (set) Token: 0x06000F52 RID: 3922 RVA: 0x000080FE File Offset: 0x000062FE
		[UserScopedSetting]
		[DefaultSettingValue("False")]
		[DebuggerNonUserCode]
		public bool seventyEnabled
		{
			get
			{
				return (bool)this["seventyEnabled"];
			}
			set
			{
				this["seventyEnabled"] = value;
			}
		}

		// Token: 0x1700036B RID: 875
		// (get) Token: 0x06000F53 RID: 3923 RVA: 0x000B661C File Offset: 0x000B481C
		// (set) Token: 0x06000F54 RID: 3924 RVA: 0x00008113 File Offset: 0x00006313
		[DefaultSettingValue("")]
		[UserScopedSetting]
		[DebuggerNonUserCode]
		public string Sims3IslandParadiseGameFolder
		{
			get
			{
				return (string)this["Sims3IslandParadiseGameFolder"];
			}
			set
			{
				this["Sims3IslandParadiseGameFolder"] = value;
			}
		}

		// Token: 0x1700036C RID: 876
		// (get) Token: 0x06000F55 RID: 3925 RVA: 0x000B6640 File Offset: 0x000B4840
		// (set) Token: 0x06000F56 RID: 3926 RVA: 0x00008123 File Offset: 0x00006323
		[UserScopedSetting]
		[DefaultSettingValue("")]
		[DebuggerNonUserCode]
		public string Sims3UniversityGameFolder
		{
			get
			{
				return (string)this["Sims3UniversityGameFolder"];
			}
			set
			{
				this["Sims3UniversityGameFolder"] = value;
			}
		}

		// Token: 0x1700036D RID: 877
		// (get) Token: 0x06000F57 RID: 3927 RVA: 0x000B6664 File Offset: 0x000B4864
		// (set) Token: 0x06000F58 RID: 3928 RVA: 0x00008133 File Offset: 0x00006333
		[DefaultSettingValue("False")]
		[UserScopedSetting]
		[DebuggerNonUserCode]
		public bool islandParadiseEnabled
		{
			get
			{
				return (bool)this["islandParadiseEnabled"];
			}
			set
			{
				this["islandParadiseEnabled"] = value;
			}
		}

		// Token: 0x1700036E RID: 878
		// (get) Token: 0x06000F59 RID: 3929 RVA: 0x000B6688 File Offset: 0x000B4888
		// (set) Token: 0x06000F5A RID: 3930 RVA: 0x00008148 File Offset: 0x00006348
		[DefaultSettingValue("False")]
		[UserScopedSetting]
		[DebuggerNonUserCode]
		public bool universityEnabled
		{
			get
			{
				return (bool)this["universityEnabled"];
			}
			set
			{
				this["universityEnabled"] = value;
			}
		}

		// Token: 0x1700036F RID: 879
		// (get) Token: 0x06000F5B RID: 3931 RVA: 0x000B66AC File Offset: 0x000B48AC
		// (set) Token: 0x06000F5C RID: 3932 RVA: 0x0000815D File Offset: 0x0000635D
		[DefaultSettingValue("")]
		[UserScopedSetting]
		[DebuggerNonUserCode]
		public string Sims3IntoTheFutureGameFolder
		{
			get
			{
				return (string)this["Sims3IntoTheFutureGameFolder"];
			}
			set
			{
				this["Sims3IntoTheFutureGameFolder"] = value;
			}
		}

		// Token: 0x17000370 RID: 880
		// (get) Token: 0x06000F5D RID: 3933 RVA: 0x000B66D0 File Offset: 0x000B48D0
		// (set) Token: 0x06000F5E RID: 3934 RVA: 0x0000816D File Offset: 0x0000636D
		[DebuggerNonUserCode]
		[UserScopedSetting]
		[DefaultSettingValue("False")]
		public bool intothefutureEnabled
		{
			get
			{
				return (bool)this["intothefutureEnabled"];
			}
			set
			{
				this["intothefutureEnabled"] = value;
			}
		}

		// Token: 0x17000371 RID: 881
		// (get) Token: 0x06000F5F RID: 3935 RVA: 0x000B66F4 File Offset: 0x000B48F4
		// (set) Token: 0x06000F60 RID: 3936 RVA: 0x00008182 File Offset: 0x00006382
		[UserScopedSetting]
		[DefaultSettingValue("")]
		[DebuggerNonUserCode]
		public string Sims3MovieStuffGameFolder
		{
			get
			{
				return (string)this["Sims3MovieStuffGameFolder"];
			}
			set
			{
				this["Sims3MovieStuffGameFolder"] = value;
			}
		}

		// Token: 0x17000372 RID: 882
		// (get) Token: 0x06000F61 RID: 3937 RVA: 0x000B6718 File Offset: 0x000B4918
		// (set) Token: 0x06000F62 RID: 3938 RVA: 0x00008192 File Offset: 0x00006392
		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("False")]
		public bool moviestuffEnabled
		{
			get
			{
				return (bool)this["moviestuffEnabled"];
			}
			set
			{
				this["moviestuffEnabled"] = value;
			}
		}

		// Token: 0x04000B12 RID: 2834
		private static Settings settings_0 = (Settings)SettingsBase.Synchronized(new Settings());
	}
}
