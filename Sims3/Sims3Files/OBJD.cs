using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using Package.SharedFiles;
using Sims3WorkshopSDK;

namespace Package.Sims3Files
{
	// Token: 0x02000036 RID: 54
	public class OBJD : OBJD
	{
		// Token: 0x170000BF RID: 191
		// (get) Token: 0x06000278 RID: 632 RVA: 0x000042C9 File Offset: 0x000024C9
		// (set) Token: 0x06000279 RID: 633 RVA: 0x000042D1 File Offset: 0x000024D1
		public override List<TGIIndex> TgiIndex { get; set; }

		// Token: 0x170000C0 RID: 192
		// (get) Token: 0x0600027A RID: 634 RVA: 0x000042DA File Offset: 0x000024DA
		// (set) Token: 0x0600027B RID: 635 RVA: 0x000042E2 File Offset: 0x000024E2
		public List<OBJD.Material> Materials { get; private set; }

		// Token: 0x170000C1 RID: 193
		// (get) Token: 0x0600027C RID: 636 RVA: 0x000042EB File Offset: 0x000024EB
		// (set) Token: 0x0600027D RID: 637 RVA: 0x000042F3 File Offset: 0x000024F3
		public List<OBJD.WallMask> WallMasks { get; private set; }

		// Token: 0x170000C2 RID: 194
		// (get) Token: 0x0600027E RID: 638 RVA: 0x000042FC File Offset: 0x000024FC
		// (set) Token: 0x0600027F RID: 639 RVA: 0x00004304 File Offset: 0x00002504
		public OBJD.BuildBuyProductStatusFlags BuildBuyStatus
		{
			get
			{
				return (OBJD.BuildBuyProductStatusFlags)this._buildBuyStatusFlags;
			}
			set
			{
				this._buildBuyStatusFlags = (byte)value;
			}
		}

		// Token: 0x06000280 RID: 640 RVA: 0x0000430D File Offset: 0x0000250D
		public OBJD()
		{
			this.typeId = 832458525U;
		}

		// Token: 0x170000C3 RID: 195
		// (get) Token: 0x06000281 RID: 641 RVA: 0x00004320 File Offset: 0x00002520
		// (set) Token: 0x06000282 RID: 642 RVA: 0x00004328 File Offset: 0x00002528
		public override string DAEFilename { get; set; }

		// Token: 0x170000C4 RID: 196
		// (get) Token: 0x06000283 RID: 643 RVA: 0x00004331 File Offset: 0x00002531
		// (set) Token: 0x06000284 RID: 644 RVA: 0x00004339 File Offset: 0x00002539
		public override long NameGuid { get; set; }

		// Token: 0x170000C5 RID: 197
		// (get) Token: 0x06000285 RID: 645 RVA: 0x00004342 File Offset: 0x00002542
		// (set) Token: 0x06000286 RID: 646 RVA: 0x0000434A File Offset: 0x0000254A
		public override long DescGuid { get; set; }

		// Token: 0x170000C6 RID: 198
		// (get) Token: 0x06000287 RID: 647 RVA: 0x00004353 File Offset: 0x00002553
		// (set) Token: 0x06000288 RID: 648 RVA: 0x0000435B File Offset: 0x0000255B
		public override string CatalogNameEntry { get; set; }

		// Token: 0x170000C7 RID: 199
		// (get) Token: 0x06000289 RID: 649 RVA: 0x00004364 File Offset: 0x00002564
		// (set) Token: 0x0600028A RID: 650 RVA: 0x0000436C File Offset: 0x0000256C
		public override string CatalogDescEntry { get; set; }

		// Token: 0x170000C8 RID: 200
		// (get) Token: 0x0600028B RID: 651 RVA: 0x00004375 File Offset: 0x00002575
		// (set) Token: 0x0600028C RID: 652 RVA: 0x0000437D File Offset: 0x0000257D
		public float Price { get; set; }

		// Token: 0x170000C9 RID: 201
		// (get) Token: 0x0600028D RID: 653 RVA: 0x00004386 File Offset: 0x00002586
		// (set) Token: 0x0600028E RID: 654 RVA: 0x0000438E File Offset: 0x0000258E
		public override long PngIcon { get; set; }

		// Token: 0x170000CA RID: 202
		// (get) Token: 0x0600028F RID: 655 RVA: 0x00004397 File Offset: 0x00002597
		// (set) Token: 0x06000290 RID: 656 RVA: 0x0000439F File Offset: 0x0000259F
		public int ObjkIndex { get; set; }

		// Token: 0x170000CB RID: 203
		// (get) Token: 0x06000291 RID: 657 RVA: 0x000043A8 File Offset: 0x000025A8
		public int WallMaskCount
		{
			get
			{
				return this.WallMasks.Count;
			}
		}

		// Token: 0x170000CC RID: 204
		// (get) Token: 0x06000292 RID: 658 RVA: 0x000043B5 File Offset: 0x000025B5
		// (set) Token: 0x06000293 RID: 659 RVA: 0x000043BD File Offset: 0x000025BD
		public int DiagonalIndex { get; set; }

		// Token: 0x170000CD RID: 205
		// (get) Token: 0x06000294 RID: 660 RVA: 0x000043C6 File Offset: 0x000025C6
		// (set) Token: 0x06000295 RID: 661 RVA: 0x000043CE File Offset: 0x000025CE
		public uint Hash { get; set; }

		// Token: 0x170000CE RID: 206
		// (get) Token: 0x06000296 RID: 662 RVA: 0x000043D7 File Offset: 0x000025D7
		// (set) Token: 0x06000297 RID: 663 RVA: 0x000043DF File Offset: 0x000025DF
		public override uint RoomFlags { get; set; }

		// Token: 0x170000CF RID: 207
		// (get) Token: 0x06000298 RID: 664 RVA: 0x000043E8 File Offset: 0x000025E8
		// (set) Token: 0x06000299 RID: 665 RVA: 0x000043F0 File Offset: 0x000025F0
		public override uint CategoryFlags { get; set; }

		// Token: 0x170000D0 RID: 208
		// (get) Token: 0x0600029A RID: 666 RVA: 0x000043F9 File Offset: 0x000025F9
		// (set) Token: 0x0600029B RID: 667 RVA: 0x00004401 File Offset: 0x00002601
		public override ulong SubCategoryFlags { get; set; }

		// Token: 0x170000D1 RID: 209
		// (get) Token: 0x0600029C RID: 668 RVA: 0x0000440A File Offset: 0x0000260A
		// (set) Token: 0x0600029D RID: 669 RVA: 0x00004412 File Offset: 0x00002612
		public override ulong SubCategoryFlags2 { get; set; }

		// Token: 0x170000D2 RID: 210
		// (get) Token: 0x0600029E RID: 670 RVA: 0x0000441B File Offset: 0x0000261B
		// (set) Token: 0x0600029F RID: 671 RVA: 0x00004423 File Offset: 0x00002623
		public override ulong SubRoomFlags { get; set; }

		// Token: 0x170000D3 RID: 211
		// (get) Token: 0x060002A0 RID: 672 RVA: 0x0000442C File Offset: 0x0000262C
		// (set) Token: 0x060002A1 RID: 673 RVA: 0x00004434 File Offset: 0x00002634
		public override uint BuildCategoryFlags { get; set; }

		// Token: 0x170000D4 RID: 212
		// (get) Token: 0x060002A2 RID: 674 RVA: 0x0000443D File Offset: 0x0000263D
		// (set) Token: 0x060002A3 RID: 675 RVA: 0x00004445 File Offset: 0x00002645
		public int SinkMask { get; set; }

		// Token: 0x170000D5 RID: 213
		// (get) Token: 0x060002A4 RID: 676 RVA: 0x0000444E File Offset: 0x0000264E
		// (set) Token: 0x060002A5 RID: 677 RVA: 0x00004456 File Offset: 0x00002656
		public string MatGroup1 { get; set; }

		// Token: 0x170000D6 RID: 214
		// (get) Token: 0x060002A6 RID: 678 RVA: 0x0000445F File Offset: 0x0000265F
		// (set) Token: 0x060002A7 RID: 679 RVA: 0x00004467 File Offset: 0x00002667
		public string MatGroup2 { get; set; }

		// Token: 0x170000D7 RID: 215
		// (get) Token: 0x060002A8 RID: 680 RVA: 0x00004470 File Offset: 0x00002670
		// (set) Token: 0x060002A9 RID: 681 RVA: 0x00004478 File Offset: 0x00002678
		public override uint Version { get; set; }

		// Token: 0x170000D8 RID: 216
		// (get) Token: 0x060002AA RID: 682 RVA: 0x00004481 File Offset: 0x00002681
		// (set) Token: 0x060002AB RID: 683 RVA: 0x00004489 File Offset: 0x00002689
		public int FallbackOBJD { get; set; }

		// Token: 0x170000D9 RID: 217
		// (get) Token: 0x060002AC RID: 684 RVA: 0x00004492 File Offset: 0x00002692
		// (set) Token: 0x060002AD RID: 685 RVA: 0x0000449A File Offset: 0x0000269A
		public uint CommonBlockVersion { get; set; }

		// Token: 0x170000DA RID: 218
		// (get) Token: 0x060002AE RID: 686 RVA: 0x000044A3 File Offset: 0x000026A3
		// (set) Token: 0x060002AF RID: 687 RVA: 0x000044AB File Offset: 0x000026AB
		private float NicenessMultiplier { get; set; }

		// Token: 0x170000DB RID: 219
		// (get) Token: 0x060002B0 RID: 688 RVA: 0x000044B4 File Offset: 0x000026B4
		// (set) Token: 0x060002B1 RID: 689 RVA: 0x000044BC File Offset: 0x000026BC
		public byte ScriptEnabled { get; set; }

		// Token: 0x170000DC RID: 220
		// (get) Token: 0x060002B2 RID: 690 RVA: 0x000044C5 File Offset: 0x000026C5
		// (set) Token: 0x060002B3 RID: 691 RVA: 0x000044CD File Offset: 0x000026CD
		public byte zeroByte { get; set; }

		// Token: 0x170000DD RID: 221
		// (get) Token: 0x060002B4 RID: 692 RVA: 0x000044D6 File Offset: 0x000026D6
		// (set) Token: 0x060002B5 RID: 693 RVA: 0x000044DE File Offset: 0x000026DE
		public float environmentScore { get; set; }

		// Token: 0x170000DE RID: 222
		// (get) Token: 0x060002B6 RID: 694 RVA: 0x000044E7 File Offset: 0x000026E7
		// (set) Token: 0x060002B7 RID: 695 RVA: 0x000044EF File Offset: 0x000026EF
		public uint firetype { get; set; }

		// Token: 0x170000DF RID: 223
		// (get) Token: 0x060002B8 RID: 696 RVA: 0x000044F8 File Offset: 0x000026F8
		// (set) Token: 0x060002B9 RID: 697 RVA: 0x00004500 File Offset: 0x00002700
		public byte isStealable { get; set; }

		// Token: 0x170000E0 RID: 224
		// (get) Token: 0x060002BA RID: 698 RVA: 0x00004509 File Offset: 0x00002709
		// (set) Token: 0x060002BB RID: 699 RVA: 0x00004511 File Offset: 0x00002711
		public byte isReposessable { get; set; }

		// Token: 0x170000E1 RID: 225
		// (get) Token: 0x060002BC RID: 700 RVA: 0x0000451A File Offset: 0x0000271A
		// (set) Token: 0x060002BD RID: 701 RVA: 0x00004522 File Offset: 0x00002722
		public uint uiSortIndex { get; set; }

		// Token: 0x170000E2 RID: 226
		// (get) Token: 0x060002BE RID: 702 RVA: 0x0000452B File Offset: 0x0000272B
		// (set) Token: 0x060002BF RID: 703 RVA: 0x00004533 File Offset: 0x00002733
		private uint NumLevels { get; set; }

		// Token: 0x170000E3 RID: 227
		// (get) Token: 0x060002C0 RID: 704 RVA: 0x0000453C File Offset: 0x0000273C
		// (set) Token: 0x060002C1 RID: 705 RVA: 0x00004544 File Offset: 0x00002744
		public OBJD.ObjectTypeFlags ObjectType
		{
			get
			{
				return (OBJD.ObjectTypeFlags)this._ObjectTypeFlags;
			}
			set
			{
				this._ObjectTypeFlags = (uint)value;
			}
		}

		// Token: 0x170000E4 RID: 228
		// (get) Token: 0x060002C2 RID: 706 RVA: 0x0000454D File Offset: 0x0000274D
		// (set) Token: 0x060002C3 RID: 707 RVA: 0x00004555 File Offset: 0x00002755
		public OBJD.ObjectTypeFlags2 ObjectType2
		{
			get
			{
				return (OBJD.ObjectTypeFlags2)this._ObjectTypeFlags2;
			}
			set
			{
				this._ObjectTypeFlags2 = (uint)value;
			}
		}

		// Token: 0x170000E5 RID: 229
		// (get) Token: 0x060002C4 RID: 708 RVA: 0x0000455E File Offset: 0x0000275E
		// (set) Token: 0x060002C5 RID: 709 RVA: 0x00004566 File Offset: 0x00002766
		public OBJD.WallPlacementFlags WallPlacement
		{
			get
			{
				return (OBJD.WallPlacementFlags)this._WallPlacementFlags;
			}
			set
			{
				this._WallPlacementFlags = (uint)value;
			}
		}

		// Token: 0x170000E6 RID: 230
		// (get) Token: 0x060002C6 RID: 710 RVA: 0x0000456F File Offset: 0x0000276F
		// (set) Token: 0x060002C7 RID: 711 RVA: 0x00004577 File Offset: 0x00002777
		public OBJD.MovementFlags Movement
		{
			get
			{
				return (OBJD.MovementFlags)this._MovementFlags;
			}
			set
			{
				this._MovementFlags = (uint)value;
			}
		}

		// Token: 0x170000E7 RID: 231
		// (get) Token: 0x060002C8 RID: 712 RVA: 0x00004580 File Offset: 0x00002780
		// (set) Token: 0x060002C9 RID: 713 RVA: 0x00004588 File Offset: 0x00002788
		public OBJD.SlotPlacementFlags SlotsFlags
		{
			get
			{
				return (OBJD.SlotPlacementFlags)this._SlotPlacementFlags;
			}
			set
			{
				this._SlotPlacementFlags = (uint)value;
			}
		}

		// Token: 0x170000E8 RID: 232
		// (get) Token: 0x060002CA RID: 714 RVA: 0x00004591 File Offset: 0x00002791
		// (set) Token: 0x060002CB RID: 715 RVA: 0x00004599 File Offset: 0x00002799
		public byte isPlaceableOnRoof { get; set; }

		// Token: 0x170000E9 RID: 233
		// (get) Token: 0x060002CC RID: 716 RVA: 0x000045A2 File Offset: 0x000027A2
		// (set) Token: 0x060002CD RID: 717 RVA: 0x000045AA File Offset: 0x000027AA
		public byte isVisibleInWorldbuilder { get; set; }

		// Token: 0x170000EA RID: 234
		// (get) Token: 0x060002CE RID: 718 RVA: 0x000045B3 File Offset: 0x000027B3
		// (set) Token: 0x060002CF RID: 719 RVA: 0x000045BB File Offset: 0x000027BB
		public int FloorMaskIndex { get; set; }

		// Token: 0x170000EB RID: 235
		// (get) Token: 0x060002D0 RID: 720 RVA: 0x000045C4 File Offset: 0x000027C4
		// (set) Token: 0x060002D1 RID: 721 RVA: 0x000045CC File Offset: 0x000027CC
		public uint FloorCutoutLevelOffset { get; set; }

		// Token: 0x170000EC RID: 236
		// (get) Token: 0x060002D2 RID: 722 RVA: 0x000045D5 File Offset: 0x000027D5
		// (set) Token: 0x060002D3 RID: 723 RVA: 0x000045DD File Offset: 0x000027DD
		public float FloorCutoutBoundsLength { get; set; }

		// Token: 0x170000ED RID: 237
		// (get) Token: 0x060002D4 RID: 724 RVA: 0x000045E6 File Offset: 0x000027E6
		// (set) Token: 0x060002D5 RID: 725 RVA: 0x000045EE File Offset: 0x000027EE
		public float FloorCutoutBoundsWidth { get; set; }

		// Token: 0x170000EE RID: 238
		// (get) Token: 0x060002D6 RID: 726 RVA: 0x000045F7 File Offset: 0x000027F7
		// (set) Token: 0x060002D7 RID: 727 RVA: 0x000045FF File Offset: 0x000027FF
		public float FloorCutoutOffsetX { get; set; }

		// Token: 0x170000EF RID: 239
		// (get) Token: 0x060002D8 RID: 728 RVA: 0x00004608 File Offset: 0x00002808
		// (set) Token: 0x060002D9 RID: 729 RVA: 0x00004610 File Offset: 0x00002810
		public float FloorCutoutOffsetY { get; set; }

		// Token: 0x170000F0 RID: 240
		// (get) Token: 0x060002DA RID: 730 RVA: 0x00004619 File Offset: 0x00002819
		// (set) Token: 0x060002DB RID: 731 RVA: 0x00004621 File Offset: 0x00002821
		public int LevelBelowIndex { get; set; }

		// Token: 0x170000F1 RID: 241
		// (get) Token: 0x060002DC RID: 732 RVA: 0x0000462A File Offset: 0x0000282A
		// (set) Token: 0x060002DD RID: 733 RVA: 0x00004632 File Offset: 0x00002832
		public int ProxyIndex { get; set; }

		// Token: 0x170000F2 RID: 242
		// (get) Token: 0x060002DE RID: 734 RVA: 0x0000463B File Offset: 0x0000283B
		// (set) Token: 0x060002DF RID: 735 RVA: 0x00004643 File Offset: 0x00002843
		private List<uint> BuildableShellDisplayStates { get; set; }

		// Token: 0x170000F3 RID: 243
		// (get) Token: 0x060002E0 RID: 736 RVA: 0x0000464C File Offset: 0x0000284C
		// (set) Token: 0x060002E1 RID: 737 RVA: 0x00004654 File Offset: 0x00002854
		public int BluePrintIndex { get; set; }

		// Token: 0x170000F4 RID: 244
		// (get) Token: 0x060002E2 RID: 738 RVA: 0x0000465D File Offset: 0x0000285D
		// (set) Token: 0x060002E3 RID: 739 RVA: 0x00004665 File Offset: 0x00002865
		public int BluePrintIconIndex { get; set; }

		// Token: 0x170000F5 RID: 245
		// (get) Token: 0x060002E4 RID: 740 RVA: 0x0000466E File Offset: 0x0000286E
		// (set) Token: 0x060002E5 RID: 741 RVA: 0x00004676 File Offset: 0x00002876
		public float BluePrintIconOffsetMinX { get; set; }

		// Token: 0x170000F6 RID: 246
		// (get) Token: 0x060002E6 RID: 742 RVA: 0x0000467F File Offset: 0x0000287F
		// (set) Token: 0x060002E7 RID: 743 RVA: 0x00004687 File Offset: 0x00002887
		public float BluePrintIconOffsetMinZ { get; set; }

		// Token: 0x170000F7 RID: 247
		// (get) Token: 0x060002E8 RID: 744 RVA: 0x00004690 File Offset: 0x00002890
		// (set) Token: 0x060002E9 RID: 745 RVA: 0x00004698 File Offset: 0x00002898
		public float BluePrintIconOffsetMaxX { get; set; }

		// Token: 0x170000F8 RID: 248
		// (get) Token: 0x060002EA RID: 746 RVA: 0x000046A1 File Offset: 0x000028A1
		// (set) Token: 0x060002EB RID: 747 RVA: 0x000046A9 File Offset: 0x000028A9
		public float BluePrintIconOffsetMaxZ { get; set; }

		// Token: 0x170000F9 RID: 249
		// (get) Token: 0x060002EC RID: 748 RVA: 0x000046B2 File Offset: 0x000028B2
		// (set) Token: 0x060002ED RID: 749 RVA: 0x000046BA File Offset: 0x000028BA
		public int ModularArchEndEastModel { get; set; }

		// Token: 0x170000FA RID: 250
		// (get) Token: 0x060002EE RID: 750 RVA: 0x000046C3 File Offset: 0x000028C3
		// (set) Token: 0x060002EF RID: 751 RVA: 0x000046CB File Offset: 0x000028CB
		public int ModularArchEndWestModel { get; set; }

		// Token: 0x170000FB RID: 251
		// (get) Token: 0x060002F0 RID: 752 RVA: 0x000046D4 File Offset: 0x000028D4
		// (set) Token: 0x060002F1 RID: 753 RVA: 0x000046DC File Offset: 0x000028DC
		public int ModularArchConnectingModel { get; set; }

		// Token: 0x170000FC RID: 252
		// (get) Token: 0x060002F2 RID: 754 RVA: 0x000046E5 File Offset: 0x000028E5
		// (set) Token: 0x060002F3 RID: 755 RVA: 0x000046ED File Offset: 0x000028ED
		public int ModularArchSingleModel { get; set; }

		// Token: 0x170000FD RID: 253
		// (get) Token: 0x060002F4 RID: 756 RVA: 0x000046F6 File Offset: 0x000028F6
		// (set) Token: 0x060002F5 RID: 757 RVA: 0x000046FE File Offset: 0x000028FE
		public List<object> topicsAndRating { get; set; }

		// Token: 0x170000FE RID: 254
		// (get) Token: 0x060002F6 RID: 758 RVA: 0x00004707 File Offset: 0x00002907
		// (set) Token: 0x060002F7 RID: 759 RVA: 0x0000470F File Offset: 0x0000290F
		public uint moodletGiven { get; set; }

		// Token: 0x170000FF RID: 255
		// (get) Token: 0x060002F8 RID: 760 RVA: 0x00004718 File Offset: 0x00002918
		// (set) Token: 0x060002F9 RID: 761 RVA: 0x00004720 File Offset: 0x00002920
		public uint moodletScore { get; set; }

		// Token: 0x060002FA RID: 762 RVA: 0x0001551C File Offset: 0x0001371C
		public override List<OBJD.Build> GetBuildFlags()
		{
			List<OBJD.Build> list = new List<OBJD.Build>();
			foreach (object obj in Enum.GetValues(typeof(OBJD.Build)))
			{
				OBJD.Build build = (OBJD.Build)obj;
				if ((this.BuildCategoryFlags & (uint)build) != 0U)
				{
					list.Add(build);
				}
			}
			return list;
		}

		// Token: 0x060002FB RID: 763 RVA: 0x00015590 File Offset: 0x00013790
		public override List<OBJD.Room> GetRoomFlags()
		{
			List<OBJD.Room> list = new List<OBJD.Room>();
			foreach (object obj in Enum.GetValues(typeof(OBJD.Room)))
			{
				OBJD.Room room = (OBJD.Room)obj;
				if ((this.RoomFlags & (uint)room) != 0U)
				{
					list.Add(room);
				}
			}
			return list;
		}

		// Token: 0x060002FC RID: 764 RVA: 0x00015604 File Offset: 0x00013804
		public override List<OBJD.SubRoom> GetSubRoomFlags()
		{
			List<OBJD.SubRoom> list = new List<OBJD.SubRoom>();
			foreach (object obj in Enum.GetValues(typeof(OBJD.SubRoom)))
			{
				OBJD.SubRoom subRoom = (OBJD.SubRoom)obj;
				if ((this.SubRoomFlags & (ulong)subRoom) != 0UL)
				{
					list.Add(subRoom);
				}
			}
			return list;
		}

		// Token: 0x060002FD RID: 765 RVA: 0x00015678 File Offset: 0x00013878
		public override List<OBJD.Category> GetCategoryFlags()
		{
			List<OBJD.Category> list = new List<OBJD.Category>();
			foreach (object obj in Enum.GetValues(typeof(OBJD.Category)))
			{
				OBJD.Category category = (OBJD.Category)obj;
				if ((this.CategoryFlags & (uint)category) != 0U)
				{
					list.Add(category);
				}
			}
			return list;
		}

		// Token: 0x060002FE RID: 766 RVA: 0x000156EC File Offset: 0x000138EC
		public override List<OBJD.SubCategory> GetSubCategoryFlags()
		{
			List<OBJD.SubCategory> list = new List<OBJD.SubCategory>();
			foreach (object obj in Enum.GetValues(typeof(OBJD.SubCategory)))
			{
				OBJD.SubCategory subCategory = (OBJD.SubCategory)obj;
				if ((this.SubCategoryFlags & (ulong)subCategory) != 0UL)
				{
					list.Add(subCategory);
				}
			}
			return list;
		}

		// Token: 0x060002FF RID: 767 RVA: 0x00015760 File Offset: 0x00013960
		public override List<OBJD.SubCategory2> GetSubCategoryFlags2()
		{
			List<OBJD.SubCategory2> list = new List<OBJD.SubCategory2>();
			foreach (object obj in Enum.GetValues(typeof(OBJD.SubCategory2)))
			{
				OBJD.SubCategory2 subCategory = (OBJD.SubCategory2)obj;
				if ((this.SubCategoryFlags2 & (ulong)subCategory) != 0UL)
				{
					list.Add(subCategory);
				}
			}
			return list;
		}

		// Token: 0x17000100 RID: 256
		// (get) Token: 0x06000300 RID: 768 RVA: 0x00004729 File Offset: 0x00002929
		// (set) Token: 0x06000301 RID: 769 RVA: 0x0000473C File Offset: 0x0000293C
		public TGIIndex OBJK
		{
			get
			{
				return this.TgiIndex[this.ObjkIndex];
			}
			set
			{
				this.TgiIndex[this.ObjkIndex] = value;
			}
		}

		// Token: 0x06000302 RID: 770 RVA: 0x000157D4 File Offset: 0x000139D4
		public override int ReplaceReferences(ResKey from, ResKey to)
		{
			int num = 0;
			foreach (TGIIndex tgiindex in this.TgiIndex)
			{
				if (tgiindex.Equals(from))
				{
					tgiindex.SetFromResKey(to);
					num++;
				}
			}
			foreach (OBJD.Material material in this.Materials)
			{
				num += material.ReplaceReferences(from, to);
			}
			return num;
		}

		// Token: 0x06000303 RID: 771 RVA: 0x00015884 File Offset: 0x00013A84
		public override List<ResKey> GetAllReferences()
		{
			List<ResKey> list = new List<ResKey>();
			foreach (TGIIndex item in this.TgiIndex)
			{
				list.Add(item);
			}
			list.Add(this.OBJK);
			foreach (OBJD.Material material in this.Materials)
			{
				list.AddRange(material.GetAllReferences());
			}
			return list;
		}

		// Token: 0x06000304 RID: 772 RVA: 0x00015938 File Offset: 0x00013B38
		public override void UnSerialize()
		{
			this.topicsAndRating = new List<object>();
			this.BuildableShellDisplayStates = new List<uint>();
			this.Materials = new List<OBJD.Material>();
			this.TgiIndex = new List<TGIIndex>();
			this.WallMasks = new List<OBJD.WallMask>();
			MemoryStream memoryStream = new MemoryStream(this.data);
			BinaryReader binaryReader = new BinaryReader(memoryStream);
			BinaryReader binaryReader2 = new BinaryReader(memoryStream, Encoding.BigEndianUnicode);
			this.Version = binaryReader.ReadUInt32();
			binaryReader.ReadUInt32();
			binaryReader.ReadUInt32();
			uint num = binaryReader.ReadUInt32();
			int num2 = 0;
			while ((long)num2 < (long)((ulong)num))
			{
				OBJD.Material material = new OBJD.Material();
				material.Unserialize(binaryReader);
				this.Materials.Add(material);
				num2++;
			}
			if (this.Version >= 22U)
			{
				this.DAEFilename = binaryReader2.ReadString();
			}
			this.CommonBlockVersion = binaryReader.ReadUInt32();
			this.NameGuid = binaryReader.ReadInt64();
			this.DescGuid = binaryReader.ReadInt64();
			this.CatalogNameEntry = binaryReader2.ReadString();
			this.CatalogDescEntry = binaryReader2.ReadString();
			this.Price = binaryReader.ReadSingle();
			this.NicenessMultiplier = binaryReader.ReadSingle();
			this.zero = binaryReader.ReadBytes(4);
			this._buildBuyStatusFlags = binaryReader.ReadByte();
			this.PngIcon = binaryReader.ReadInt64();
			this.zeroByte = binaryReader.ReadByte();
			this.environmentScore = binaryReader.ReadSingle();
			this.firetype = binaryReader.ReadUInt32();
			this.isStealable = binaryReader.ReadByte();
			this.isReposessable = binaryReader.ReadByte();
			this.uiSortIndex = binaryReader.ReadUInt32();
			if (this.CommonBlockVersion >= 13U)
			{
				this.isPlaceableOnRoof = binaryReader.ReadByte();
				if (this.CommonBlockVersion >= 14U)
				{
					this.isVisibleInWorldbuilder = binaryReader.ReadByte();
				}
				if (this.CommonBlockVersion >= 15U)
				{
					this._hashedProductName = binaryReader.ReadInt32();
				}
			}
			this.ObjkIndex = binaryReader.ReadInt32();
			this._ObjectTypeFlags = binaryReader.ReadUInt32();
			if (this.Version >= 26U)
			{
				this._ObjectTypeFlags2 = binaryReader.ReadUInt32();
			}
			this._WallPlacementFlags = binaryReader.ReadUInt32();
			this._MovementFlags = binaryReader.ReadUInt32();
			this.NumWallCutoutTilesPerLevel = binaryReader.ReadUInt32();
			this.NumLevels = binaryReader.ReadUInt32();
			this._wallmaskCount = (int)binaryReader.ReadByte();
			for (int i = 0; i < this._wallmaskCount; i++)
			{
				OBJD.WallMask wallMask = new OBJD.WallMask();
				wallMask.F1 = binaryReader.ReadSingle();
				wallMask.F2 = binaryReader.ReadSingle();
				wallMask.F3 = binaryReader.ReadSingle();
				wallMask.F4 = binaryReader.ReadSingle();
				wallMask.I1 = binaryReader.ReadUInt32();
				wallMask.DdsIndex = binaryReader.ReadInt32();
				this.WallMasks.Add(wallMask);
			}
			this.ScriptEnabled = binaryReader.ReadByte();
			this.DiagonalIndex = binaryReader.ReadInt32();
			this.Hash = binaryReader.ReadUInt32();
			this.RoomFlags = binaryReader.ReadUInt32();
			this.CategoryFlags = binaryReader.ReadUInt32();
			this.SubCategoryFlags = binaryReader.ReadUInt64();
			if (this.Version >= 28U)
			{
				this.SubCategoryFlags2 = binaryReader.ReadUInt64();
			}
			this.SubRoomFlags = binaryReader.ReadUInt64();
			this.BuildCategoryFlags = binaryReader.ReadUInt32();
			this.SinkMask = binaryReader.ReadInt32();
			if (this.Version >= 23U)
			{
				this.FloorMaskIndex = binaryReader.ReadInt32();
				this.FloorCutoutLevelOffset = binaryReader.ReadUInt32();
				this.FloorCutoutBoundsLength = binaryReader.ReadSingle();
				if (this.Version >= 32U)
				{
					this.FloorCutoutBoundsWidth = binaryReader.ReadSingle();
					if (this.Version >= 33U)
					{
						this.FloorCutoutOffsetX = binaryReader.ReadSingle();
						this.FloorCutoutOffsetX = binaryReader.ReadSingle();
					}
				}
				if (this.Version >= 24U)
				{
					uint num3 = binaryReader.ReadUInt32();
					int num4 = 0;
					while ((long)num4 < (long)((ulong)num3))
					{
						this.BuildableShellDisplayStates.Add(binaryReader.ReadUInt32());
						num4++;
					}
					if (this.Version >= 25U)
					{
						this.LevelBelowIndex = binaryReader.ReadInt32();
						if (this.Version >= 27U)
						{
							this.ProxyIndex = binaryReader.ReadInt32();
							if (this.Version >= 29U)
							{
								this.BluePrintIndex = binaryReader.ReadInt32();
								if (this.Version >= 30U)
								{
									this.BluePrintIconIndex = binaryReader.ReadInt32();
									if (this.Version >= 31U)
									{
										this.BluePrintIconOffsetMinX = binaryReader.ReadSingle();
										this.BluePrintIconOffsetMinZ = binaryReader.ReadSingle();
										this.BluePrintIconOffsetMaxX = binaryReader.ReadSingle();
										this.BluePrintIconOffsetMaxZ = binaryReader.ReadSingle();
									}
								}
							}
						}
					}
				}
			}
			this._SlotPlacementFlags = binaryReader.ReadUInt32();
			this.MatGroup1 = PackageUtil.ReadString(binaryReader, (int)binaryReader.ReadByte());
			this.MatGroup2 = PackageUtil.ReadString(binaryReader, (int)binaryReader.ReadByte());
			this.moodletGiven = binaryReader.ReadUInt32();
			this.moodletScore = binaryReader.ReadUInt32();
			int num5 = binaryReader.ReadInt32();
			for (int j = 0; j < num5; j++)
			{
				uint num6 = binaryReader.ReadUInt32();
				uint num7 = binaryReader.ReadUInt32();
				this.topicsAndRating.Add(new uint[]
				{
					num6,
					num7
				});
			}
			this.FallbackOBJD = binaryReader.ReadInt32();
			if (this.Version >= 34U)
			{
				this.ModularArchEndEastModel = binaryReader.ReadInt32();
				this.ModularArchEndWestModel = binaryReader.ReadInt32();
				this.ModularArchConnectingModel = binaryReader.ReadInt32();
				this.ModularArchSingleModel = binaryReader.ReadInt32();
			}
			uint num8 = binaryReader.ReadUInt32();
			int num9 = 0;
			while ((long)num9 < (long)((ulong)num8))
			{
				TGIIndex tgiindex = new TGIIndex();
				tgiindex.UnSerialize(binaryReader);
				this.TgiIndex.Add(tgiindex);
				num9++;
			}
			memoryStream.Dispose();
			binaryReader.Close();
		}

		// Token: 0x06000305 RID: 773 RVA: 0x00015EB4 File Offset: 0x000140B4
		public int AddTgi(List<TGIIndex> tgiIndex, TGIIndex newtgi)
		{
			int result;
			if (tgiIndex.Contains(newtgi))
			{
				result = tgiIndex.IndexOf(newtgi);
			}
			else
			{
				tgiIndex.Add(newtgi);
				result = tgiIndex.IndexOf(newtgi);
			}
			return result;
		}

		// Token: 0x06000306 RID: 774 RVA: 0x00015EE8 File Offset: 0x000140E8
		public override byte[] Serialize()
		{
			List<TGIIndex> tgiIndex = new List<TGIIndex>();
			foreach (OBJD.Material material in this.Materials)
			{
				foreach (TGIIndex tgiindex in material.TGIIndex)
				{
					TGIIndex newtgi = new TGIIndex(tgiindex.AsString());
					this.AddTgi(tgiIndex, newtgi);
				}
			}
			foreach (OBJD.WallMask wallMask in this.WallMasks)
			{
				wallMask.DdsIndex = this.AddTgi(tgiIndex, this.TgiIndex[wallMask.DdsIndex]);
			}
			if (this.Version >= 23U)
			{
				this.FloorMaskIndex = this.AddTgi(tgiIndex, this.TgiIndex[this.FloorMaskIndex]);
				if (this.Version >= 25U)
				{
					this.LevelBelowIndex = this.AddTgi(tgiIndex, this.TgiIndex[this.LevelBelowIndex]);
					if (this.Version >= 27U)
					{
						this.ProxyIndex = this.AddTgi(tgiIndex, this.TgiIndex[this.ProxyIndex]);
						if (this.Version >= 29U)
						{
							this.BluePrintIndex = this.AddTgi(tgiIndex, this.TgiIndex[this.BluePrintIndex]);
							if (this.Version >= 30U)
							{
								this.BluePrintIconIndex = this.AddTgi(tgiIndex, this.TgiIndex[this.BluePrintIconIndex]);
							}
						}
					}
				}
			}
			this.ObjkIndex = this.AddTgi(tgiIndex, this.TgiIndex[this.ObjkIndex]);
			this.DiagonalIndex = this.AddTgi(tgiIndex, this.TgiIndex[this.DiagonalIndex]);
			this.SinkMask = this.AddTgi(tgiIndex, this.TgiIndex[this.SinkMask]);
			this.FallbackOBJD = this.AddTgi(tgiIndex, this.TgiIndex[this.FallbackOBJD]);
			this.TgiIndex = tgiIndex;
			MemoryStream memoryStream = new MemoryStream();
			BinaryWriter binaryWriter = new BinaryWriter(memoryStream, Encoding.BigEndianUnicode);
			MemoryStream memoryStream2 = new MemoryStream();
			BinaryWriter binaryWriter2 = new BinaryWriter(memoryStream2, Encoding.BigEndianUnicode);
			binaryWriter2.Write(this.TgiIndex.Count);
			foreach (TGIIndex tgiindex2 in this.TgiIndex)
			{
				tgiindex2.Serialize(binaryWriter2);
			}
			MemoryStream memoryStream3 = new MemoryStream();
			BinaryWriter binaryWriter3 = new BinaryWriter(memoryStream3, Encoding.BigEndianUnicode);
			binaryWriter3.Write(this.Materials.Count);
			foreach (OBJD.Material material2 in this.Materials)
			{
				material2.Serialize(binaryWriter3);
			}
			if (this.Version >= 22U)
			{
				binaryWriter3.Write(this.DAEFilename);
			}
			binaryWriter3.Write(this.CommonBlockVersion);
			binaryWriter3.Write(this.NameGuid);
			binaryWriter3.Write(this.DescGuid);
			binaryWriter3.Write(this.CatalogNameEntry);
			binaryWriter3.Write(this.CatalogDescEntry);
			binaryWriter3.Write(this.Price);
			binaryWriter3.Write(this.NicenessMultiplier);
			binaryWriter3.Write(this.zero);
			binaryWriter3.Write(this._buildBuyStatusFlags);
			binaryWriter3.Write(this.PngIcon);
			binaryWriter3.Write(this.zeroByte);
			binaryWriter3.Write(this.environmentScore);
			binaryWriter3.Write(this.firetype);
			binaryWriter3.Write(this.isStealable);
			binaryWriter3.Write(this.isReposessable);
			binaryWriter3.Write(this.uiSortIndex);
			if (this.CommonBlockVersion >= 13U)
			{
				binaryWriter3.Write(this.isPlaceableOnRoof);
				if (this.CommonBlockVersion >= 14U)
				{
					binaryWriter3.Write(this.isVisibleInWorldbuilder);
				}
				if (this.CommonBlockVersion >= 15U)
				{
					binaryWriter3.Write(this._hashedProductName);
				}
			}
			binaryWriter3.Write(this.ObjkIndex);
			binaryWriter3.Write(this._ObjectTypeFlags);
			if (this.Version >= 26U)
			{
				binaryWriter3.Write(this._ObjectTypeFlags2);
			}
			binaryWriter3.Write(this._WallPlacementFlags);
			binaryWriter3.Write(this._MovementFlags);
			binaryWriter3.Write(this.NumWallCutoutTilesPerLevel);
			binaryWriter3.Write(this.NumLevels);
			binaryWriter3.Write((byte)this.WallMaskCount);
			foreach (OBJD.WallMask wallMask2 in this.WallMasks)
			{
				binaryWriter3.Write(wallMask2.F1);
				binaryWriter3.Write(wallMask2.F2);
				binaryWriter3.Write(wallMask2.F3);
				binaryWriter3.Write(wallMask2.F4);
				binaryWriter3.Write(wallMask2.I1);
				binaryWriter3.Write(wallMask2.DdsIndex);
			}
			binaryWriter3.Write(this.ScriptEnabled);
			binaryWriter3.Write(this.DiagonalIndex);
			binaryWriter3.Write(this.Hash);
			binaryWriter3.Write(this.RoomFlags);
			binaryWriter3.Write(this.CategoryFlags);
			binaryWriter3.Write(this.SubCategoryFlags);
			if (this.Version >= 28U)
			{
				binaryWriter3.Write(this.SubCategoryFlags2);
			}
			binaryWriter3.Write(this.SubRoomFlags);
			binaryWriter3.Write(this.BuildCategoryFlags);
			binaryWriter3.Write(this.SinkMask);
			if (this.Version >= 23U)
			{
				binaryWriter3.Write(this.FloorMaskIndex);
				binaryWriter3.Write(this.FloorCutoutLevelOffset);
				binaryWriter3.Write(this.FloorCutoutBoundsLength);
				if (this.Version >= 32U)
				{
					binaryWriter3.Write(this.FloorCutoutBoundsWidth);
					if (this.Version >= 33U)
					{
						binaryWriter3.Write(this.FloorCutoutOffsetX);
						binaryWriter3.Write(this.FloorCutoutOffsetY);
					}
				}
				if (this.Version >= 24U)
				{
					binaryWriter3.Write((uint)this.BuildableShellDisplayStates.Count);
					foreach (uint value in this.BuildableShellDisplayStates)
					{
						binaryWriter3.Write(value);
					}
					if (this.Version >= 25U)
					{
						binaryWriter3.Write(this.LevelBelowIndex);
						if (this.Version >= 27U)
						{
							binaryWriter3.Write(this.ProxyIndex);
							if (this.Version >= 29U)
							{
								binaryWriter3.Write(this.BluePrintIndex);
								if (this.Version >= 30U)
								{
									binaryWriter3.Write(this.BluePrintIconIndex);
									if (this.Version >= 31U)
									{
										binaryWriter3.Write(this.BluePrintIconOffsetMinX);
										binaryWriter3.Write(this.BluePrintIconOffsetMinZ);
										binaryWriter3.Write(this.BluePrintIconOffsetMaxX);
										binaryWriter3.Write(this.BluePrintIconOffsetMaxZ);
									}
								}
							}
						}
					}
				}
			}
			binaryWriter3.Write(this._SlotPlacementFlags);
			binaryWriter3.Write((byte)this.MatGroup1.Length);
			for (int i = 0; i < this.MatGroup1.Length; i++)
			{
				binaryWriter3.Write((byte)this.MatGroup1[i]);
			}
			binaryWriter3.Write((byte)this.MatGroup2.Length);
			for (int j = 0; j < this.MatGroup2.Length; j++)
			{
				binaryWriter3.Write((byte)this.MatGroup2[j]);
			}
			binaryWriter3.Write(this.moodletGiven);
			binaryWriter3.Write(this.moodletScore);
			binaryWriter3.Write(this.topicsAndRating.Count);
			foreach (object obj in this.topicsAndRating)
			{
				uint[] array = (uint[])obj;
				binaryWriter3.Write(array[0]);
				binaryWriter3.Write(array[1]);
			}
			binaryWriter3.Write(this.FallbackOBJD);
			if (this.Version >= 34U)
			{
				binaryWriter3.Write(this.ModularArchEndEastModel);
				binaryWriter3.Write(this.ModularArchEndWestModel);
				binaryWriter3.Write(this.ModularArchConnectingModel);
				binaryWriter3.Write(this.ModularArchSingleModel);
			}
			binaryWriter.Write(this.Version);
			binaryWriter.Write((int)binaryWriter3.BaseStream.Position + 4);
			binaryWriter.Write((int)memoryStream2.Position);
			binaryWriter.Write(memoryStream3.ToArray());
			binaryWriter.Write(memoryStream2.ToArray());
			byte[] result = memoryStream.ToArray();
			memoryStream3.Dispose();
			memoryStream2.Dispose();
			binaryWriter2.Close();
			binaryWriter3.Close();
			memoryStream.Dispose();
			binaryWriter.Close();
			return result;
		}

		// Token: 0x06000307 RID: 775 RVA: 0x00004750 File Offset: 0x00002950
		public override string ToString()
		{
			return "OBJD " + this.DAEFilename + " " + base.ToString();
		}

		// Token: 0x04000154 RID: 340
		private int _wallmaskCount;

		// Token: 0x04000164 RID: 356
		private byte[] zero;

		// Token: 0x04000165 RID: 357
		private byte _buildBuyStatusFlags;

		// Token: 0x0400016D RID: 365
		private uint _SlotPlacementFlags;

		// Token: 0x0400016E RID: 366
		private uint _ObjectTypeFlags;

		// Token: 0x0400016F RID: 367
		private uint _ObjectTypeFlags2;

		// Token: 0x04000170 RID: 368
		private uint _WallPlacementFlags;

		// Token: 0x04000171 RID: 369
		private uint _MovementFlags;

		// Token: 0x04000172 RID: 370
		public uint NumWallCutoutTilesPerLevel;

		// Token: 0x04000176 RID: 374
		private int _hashedProductName;

		// Token: 0x02000106 RID: 262
		public class WallMask
		{
			// Token: 0x17000412 RID: 1042
			// (get) Token: 0x06000CE8 RID: 3304 RVA: 0x0000912D File Offset: 0x0000732D
			// (set) Token: 0x06000CE9 RID: 3305 RVA: 0x00009135 File Offset: 0x00007335
			public float F1 { get; set; }

			// Token: 0x17000413 RID: 1043
			// (get) Token: 0x06000CEA RID: 3306 RVA: 0x0000913E File Offset: 0x0000733E
			// (set) Token: 0x06000CEB RID: 3307 RVA: 0x00009146 File Offset: 0x00007346
			public float F2 { get; set; }

			// Token: 0x17000414 RID: 1044
			// (get) Token: 0x06000CEC RID: 3308 RVA: 0x0000914F File Offset: 0x0000734F
			// (set) Token: 0x06000CED RID: 3309 RVA: 0x00009157 File Offset: 0x00007357
			public float F3 { get; set; }

			// Token: 0x17000415 RID: 1045
			// (get) Token: 0x06000CEE RID: 3310 RVA: 0x00009160 File Offset: 0x00007360
			// (set) Token: 0x06000CEF RID: 3311 RVA: 0x00009168 File Offset: 0x00007368
			public float F4 { get; set; }

			// Token: 0x17000416 RID: 1046
			// (get) Token: 0x06000CF0 RID: 3312 RVA: 0x00009171 File Offset: 0x00007371
			// (set) Token: 0x06000CF1 RID: 3313 RVA: 0x00009179 File Offset: 0x00007379
			public uint I1 { get; set; }

			// Token: 0x17000417 RID: 1047
			// (get) Token: 0x06000CF2 RID: 3314 RVA: 0x00009182 File Offset: 0x00007382
			// (set) Token: 0x06000CF3 RID: 3315 RVA: 0x0000918A File Offset: 0x0000738A
			public int DdsIndex { get; set; }
		}

		// Token: 0x02000107 RID: 263
		public enum VariableNameIndex : byte
		{
			// Token: 0x04000638 RID: 1592
			FileName = 1,
			// Token: 0x04000639 RID: 1593
			X,
			// Token: 0x0400063A RID: 1594
			minus1,
			// Token: 0x0400063B RID: 1595
			assetRoot,
			// Token: 0x0400063C RID: 1596
			daeFileName,
			// Token: 0x0400063D RID: 1597
			daeFilePath,
			// Token: 0x0400063E RID: 1598
			Color,
			// Token: 0x0400063F RID: 1599
			ObjectRgbMask,
			// Token: 0x04000640 RID: 1600
			rgbmask,
			// Token: 0x04000641 RID: 1601
			specmap,
			// Token: 0x04000642 RID: 1602
			BackgroundImage,
			// Token: 0x04000643 RID: 1603
			HSVShiftBg,
			// Token: 0x04000644 RID: 1604
			HBg,
			// Token: 0x04000645 RID: 1605
			VBg,
			// Token: 0x04000646 RID: 1606
			SBg,
			// Token: 0x04000647 RID: 1607
			BaseHBg,
			// Token: 0x04000648 RID: 1608
			BaseVBg,
			// Token: 0x04000649 RID: 1609
			BaseSBg,
			// Token: 0x0400064A RID: 1610
			Mask,
			// Token: 0x0400064B RID: 1611
			Multiplier,
			// Token: 0x0400064C RID: 1612
			DirtLayer,
			// Token: 0x0400064D RID: 1613
			OneXMultiplier,
			// Token: 0x0400064E RID: 1614
			Specular,
			// Token: 0x0400064F RID: 1615
			Overlay,
			// Token: 0x04000650 RID: 1616
			Face,
			// Token: 0x04000651 RID: 1617
			partType,
			// Token: 0x04000652 RID: 1618
			gender,
			// Token: 0x04000653 RID: 1619
			bodyType,
			// Token: 0x04000654 RID: 1620
			age,
			// Token: 0x04000655 RID: 1621
			A,
			// Token: 0x04000656 RID: 1622
			M,
			// Token: 0x04000657 RID: 1623
			StencilA,
			// Token: 0x04000658 RID: 1624
			StencilB,
			// Token: 0x04000659 RID: 1625
			StencilC,
			// Token: 0x0400065A RID: 1626
			StencilD,
			// Token: 0x0400065B RID: 1627
			StencilAEnabled,
			// Token: 0x0400065C RID: 1628
			StencilBEnabled,
			// Token: 0x0400065D RID: 1629
			StencilCEnabled,
			// Token: 0x0400065E RID: 1630
			StencilDEnabled,
			// Token: 0x0400065F RID: 1631
			StencilATiling,
			// Token: 0x04000660 RID: 1632
			StencilBTiling,
			// Token: 0x04000661 RID: 1633
			StencilCTiling,
			// Token: 0x04000662 RID: 1634
			StencilDTiling,
			// Token: 0x04000663 RID: 1635
			StencilARotation,
			// Token: 0x04000664 RID: 1636
			StencilBRotation,
			// Token: 0x04000665 RID: 1637
			StencilCRotation,
			// Token: 0x04000666 RID: 1638
			StencilDRotation,
			// Token: 0x04000667 RID: 1639
			PatternA,
			// Token: 0x04000668 RID: 1640
			PatternB,
			// Token: 0x04000669 RID: 1641
			PatternC,
			// Token: 0x0400066A RID: 1642
			PatternAEnabled,
			// Token: 0x0400066B RID: 1643
			PatternBEnabled,
			// Token: 0x0400066C RID: 1644
			PatternCEnabled,
			// Token: 0x0400066D RID: 1645
			PatternALinked,
			// Token: 0x0400066E RID: 1646
			PatternBLinked,
			// Token: 0x0400066F RID: 1647
			PatternCLinked,
			// Token: 0x04000670 RID: 1648
			PatternARotation,
			// Token: 0x04000671 RID: 1649
			PatternBRotation,
			// Token: 0x04000672 RID: 1650
			PatternCRotation,
			// Token: 0x04000673 RID: 1651
			PatternATiling,
			// Token: 0x04000674 RID: 1652
			PatternBTiling,
			// Token: 0x04000675 RID: 1653
			PatternCTiling,
			// Token: 0x04000676 RID: 1654
			End = 64,
			// Token: 0x04000677 RID: 1655
			MaskWidth,
			// Token: 0x04000678 RID: 1656
			MaskHeight,
			// Token: 0x04000679 RID: 1657
			ObjectRgbaMask,
			// Token: 0x0400067A RID: 1658
			RndColors,
			// Token: 0x0400067B RID: 1659
			FlatColor,
			// Token: 0x0400067C RID: 1660
			Alpha,
			// Token: 0x0400067D RID: 1661
			Color0,
			// Token: 0x0400067E RID: 1662
			Color1,
			// Token: 0x0400067F RID: 1663
			Color2,
			// Token: 0x04000680 RID: 1664
			Color3,
			// Token: 0x04000681 RID: 1665
			Color4,
			// Token: 0x04000682 RID: 1666
			Channel1,
			// Token: 0x04000683 RID: 1667
			Channel2,
			// Token: 0x04000684 RID: 1668
			Channel3,
			// Token: 0x04000685 RID: 1669
			PatternD,
			// Token: 0x04000686 RID: 1670
			PatternDTiling,
			// Token: 0x04000687 RID: 1671
			PatternDEnabled,
			// Token: 0x04000688 RID: 1672
			PatternDLinked,
			// Token: 0x04000689 RID: 1673
			PatternDRotation,
			// Token: 0x0400068A RID: 1674
			HSVShift1,
			// Token: 0x0400068B RID: 1675
			HSVShift2,
			// Token: 0x0400068C RID: 1676
			HSVShift3,
			// Token: 0x0400068D RID: 1677
			Channel1Enabled,
			// Token: 0x0400068E RID: 1678
			Channel2Enabled,
			// Token: 0x0400068F RID: 1679
			Channel3Enabled,
			// Token: 0x04000690 RID: 1680
			BaseH1,
			// Token: 0x04000691 RID: 1681
			BaseV1,
			// Token: 0x04000692 RID: 1682
			BaseS1,
			// Token: 0x04000693 RID: 1683
			BaseH2,
			// Token: 0x04000694 RID: 1684
			BaseV2,
			// Token: 0x04000695 RID: 1685
			BaseS2,
			// Token: 0x04000696 RID: 1686
			BaseH3,
			// Token: 0x04000697 RID: 1687
			BaseV3,
			// Token: 0x04000698 RID: 1688
			BaseS3,
			// Token: 0x04000699 RID: 1689
			H1,
			// Token: 0x0400069A RID: 1690
			S1,
			// Token: 0x0400069B RID: 1691
			V1,
			// Token: 0x0400069C RID: 1692
			H2,
			// Token: 0x0400069D RID: 1693
			S2,
			// Token: 0x0400069E RID: 1694
			V2,
			// Token: 0x0400069F RID: 1695
			H3,
			// Token: 0x040006A0 RID: 1696
			V3,
			// Token: 0x040006A1 RID: 1697
			S3,
			// Token: 0x040006A2 RID: 1698
			istrue,
			// Token: 0x040006A3 RID: 1699
			Rgba,
			// Token: 0x040006A4 RID: 1700
			defaultFlatColor,
			// Token: 0x040006A5 RID: 1701
			solidColor_1
		}

		// Token: 0x02000108 RID: 264
		public class Material
		{
			// Token: 0x17000418 RID: 1048
			// (get) Token: 0x06000CF5 RID: 3317 RVA: 0x00009193 File Offset: 0x00007393
			// (set) Token: 0x06000CF6 RID: 3318 RVA: 0x0000919B File Offset: 0x0000739B
			public uint MaterialIndex { get; set; }

			// Token: 0x17000419 RID: 1049
			// (get) Token: 0x06000CF7 RID: 3319 RVA: 0x000091A4 File Offset: 0x000073A4
			// (set) Token: 0x06000CF8 RID: 3320 RVA: 0x000091AC File Offset: 0x000073AC
			public uint CategoryFlags { get; set; }

			// Token: 0x1700041A RID: 1050
			// (get) Token: 0x06000CF9 RID: 3321 RVA: 0x000091B5 File Offset: 0x000073B5
			// (set) Token: 0x06000CFA RID: 3322 RVA: 0x000091BD File Offset: 0x000073BD
			public bool IsFloorOrWall { get; set; }

			// Token: 0x06000CFB RID: 3323 RVA: 0x000091C6 File Offset: 0x000073C6
			public Material()
			{
				this.type = 1;
				this.unk = 66;
				this._materialBlocks = new List<OBJD.Material.MaterialBlock>();
				this._tgiIndex = new List<TGIIndex>();
			}

			// Token: 0x06000CFC RID: 3324 RVA: 0x000091F3 File Offset: 0x000073F3
			public Material(uint unk)
			{
				this.type = 1;
				this.unk = 66;
				this._materialBlocks = new List<OBJD.Material.MaterialBlock>();
				this._tgiIndex = new List<TGIIndex>();
				this.MaterialIndex = unk;
			}

			// Token: 0x06000CFD RID: 3325 RVA: 0x0003DFA8 File Offset: 0x0003C1A8
			public int AddTGI(TGIIndex idx)
			{
				for (int i = 0; i < this._tgiIndex.Count; i++)
				{
					if (this._tgiIndex[i].Equals(idx))
					{
						return i;
					}
				}
				this._tgiIndex.Add(idx);
				return this._tgiIndex.Count - 1;
			}

			// Token: 0x06000CFE RID: 3326 RVA: 0x0003DFFC File Offset: 0x0003C1FC
			public OBJD.Material.MaterialBlock AddBlock()
			{
				OBJD.Material.MaterialBlock materialBlock = new OBJD.Material.MaterialBlock();
				this._materialBlocks.Add(materialBlock);
				return materialBlock;
			}

			// Token: 0x1700041B RID: 1051
			// (get) Token: 0x06000CFF RID: 3327 RVA: 0x00009227 File Offset: 0x00007427
			public List<OBJD.Material.MaterialBlock> Blocks
			{
				get
				{
					return this._materialBlocks;
				}
			}

			// Token: 0x1700041C RID: 1052
			// (get) Token: 0x06000D00 RID: 3328 RVA: 0x0000922F File Offset: 0x0000742F
			public List<TGIIndex> TGIIndex
			{
				get
				{
					return this._tgiIndex;
				}
			}

			// Token: 0x06000D01 RID: 3329 RVA: 0x0003E01C File Offset: 0x0003C21C
			public OBJD.Material.ComplateVariable GetComplateVariable(string variableName)
			{
				foreach (OBJD.Material.MaterialBlock materialBlock in this._materialBlocks)
				{
					OBJD.Material.ComplateVariable variable = materialBlock.GetVariable(variableName);
					if (variable != null)
					{
						return variable;
					}
				}
				return null;
			}

			// Token: 0x06000D02 RID: 3330 RVA: 0x0003E07C File Offset: 0x0003C27C
			public int ReplaceReferences(ResKey from, ResKey to)
			{
				int num = 0;
				foreach (TGIIndex tgiindex in this.TGIIndex)
				{
					if (tgiindex.Equals(from))
					{
						tgiindex.SetFromResKey(to);
						num++;
					}
				}
				foreach (OBJD.Material.MaterialBlock materialBlock in this.Blocks)
				{
					foreach (OBJD.Material.MaterialBlock materialBlock2 in materialBlock.Patterns)
					{
						foreach (OBJD.Material.ComplateVariable complateVariable in materialBlock2.Variables)
						{
							if (complateVariable.ValueTypeCode == 1)
							{
								string value = complateVariable.GetValue();
								string b = from.AsString();
								string value2 = to.AsString();
								if (value == b)
								{
									complateVariable.SetValue(1, value2);
									num++;
								}
							}
						}
					}
					foreach (OBJD.Material.ComplateVariable complateVariable2 in materialBlock.Variables)
					{
						if (complateVariable2.ValueTypeCode == 1)
						{
							string value3 = complateVariable2.GetValue();
							string b2 = from.AsString();
							string value4 = to.AsString();
							if (value3 == b2)
							{
								complateVariable2.SetValue(1, value4);
								num++;
							}
						}
					}
				}
				return num;
			}

			// Token: 0x06000D03 RID: 3331 RVA: 0x0003E288 File Offset: 0x0003C488
			public List<ResKey> GetAllReferences()
			{
				List<ResKey> list = new List<ResKey>();
				foreach (TGIIndex item in this.TGIIndex)
				{
					list.Add(item);
				}
				return list;
			}

			// Token: 0x06000D04 RID: 3332 RVA: 0x0003E2E4 File Offset: 0x0003C4E4
			public void Serialize(BinaryWriter w)
			{
				MemoryStream memoryStream = new MemoryStream();
				BinaryWriter binaryWriter = new BinaryWriter(memoryStream);
				binaryWriter.Write(this._tgiIndex.Count);
				foreach (TGIIndex tgiindex in this._tgiIndex)
				{
					tgiindex.Serialize(binaryWriter);
				}
				MemoryStream memoryStream2 = new MemoryStream();
				BinaryWriter binaryWriter2 = new BinaryWriter(memoryStream2);
				foreach (OBJD.Material.MaterialBlock materialBlock in this._materialBlocks)
				{
					materialBlock.Serialize(binaryWriter2);
				}
				w.Write(this.type);
				if (this.type != 1)
				{
					w.Write(this.unk_);
				}
				w.Write((int)(10L + memoryStream2.Position + memoryStream.Position));
				w.Write(this.unk);
				int value = (int)(memoryStream2.Position + 4L);
				w.Write(value);
				int value2 = (int)memoryStream.Position;
				w.Write(value2);
				w.Write(memoryStream2.ToArray());
				w.Write(memoryStream.ToArray());
				w.Write(this.MaterialIndex);
				if (this.IsFloorOrWall)
				{
					w.Write(this.CategoryFlags);
					w.Write(this.UInt2);
					w.Write(this.UInt3);
				}
				memoryStream.Dispose();
				memoryStream2.Dispose();
				binaryWriter.Close();
				binaryWriter2.Close();
			}

			// Token: 0x06000D05 RID: 3333 RVA: 0x0003E484 File Offset: 0x0003C684
			public void Unserialize(BinaryReader r)
			{
				this.type = r.ReadByte();
				if (this.type != 1)
				{
					this.unk_ = r.ReadUInt32();
				}
				this.offset = r.ReadUInt32();
				this.unk = r.ReadUInt16();
				r.ReadUInt32();
				r.ReadUInt32();
				OBJD.Material.MaterialBlock materialBlock = new OBJD.Material.MaterialBlock();
				materialBlock.Unserialize(r);
				this._materialBlocks.Add(materialBlock);
				uint num = r.ReadUInt32();
				int num2 = 0;
				while ((long)num2 < (long)((ulong)num))
				{
					TGIIndex tgiindex = new TGIIndex();
					tgiindex.UnSerialize(r);
					this._tgiIndex.Add(tgiindex);
					num2++;
				}
				this.MaterialIndex = r.ReadUInt32();
				if (this.IsFloorOrWall)
				{
					this.CategoryFlags = r.ReadUInt32();
					this.UInt2 = r.ReadUInt32();
					this.UInt3 = r.ReadUInt32();
				}
			}

			// Token: 0x06000D06 RID: 3334 RVA: 0x0003E558 File Offset: 0x0003C758
			public OBJD.Material Clone()
			{
				MemoryStream memoryStream = new MemoryStream();
				BinaryWriter binaryWriter = new BinaryWriter(memoryStream);
				this.Serialize(binaryWriter);
				memoryStream.Position = 0L;
				OBJD.Material material = new OBJD.Material();
				material.IsFloorOrWall = this.IsFloorOrWall;
				BinaryReader binaryReader = new BinaryReader(memoryStream);
				material.Unserialize(binaryReader);
				binaryReader.Close();
				binaryWriter.Close();
				memoryStream.Dispose();
				return material;
			}

			// Token: 0x040006A6 RID: 1702
			public static readonly Dictionary<OBJD.VariableNameIndex, string> VariableStringTable = new Dictionary<OBJD.VariableNameIndex, string>
			{
				{
					(OBJD.VariableNameIndex)0,
					""
				},
				{
					OBJD.VariableNameIndex.FileName,
					"filename"
				},
				{
					OBJD.VariableNameIndex.X,
					"X:"
				},
				{
					OBJD.VariableNameIndex.minus1,
					"-1"
				},
				{
					OBJD.VariableNameIndex.assetRoot,
					"assetRoot"
				},
				{
					OBJD.VariableNameIndex.daeFileName,
					"daeFileName"
				},
				{
					OBJD.VariableNameIndex.daeFilePath,
					"daeFilePath"
				},
				{
					OBJD.VariableNameIndex.Color,
					"Color"
				},
				{
					OBJD.VariableNameIndex.ObjectRgbMask,
					"ObjectRgbMask"
				},
				{
					OBJD.VariableNameIndex.rgbmask,
					"rgbmask"
				},
				{
					OBJD.VariableNameIndex.specmap,
					"specmap"
				},
				{
					OBJD.VariableNameIndex.BackgroundImage,
					"Background Image"
				},
				{
					OBJD.VariableNameIndex.HSVShiftBg,
					"HSVShift Bg"
				},
				{
					OBJD.VariableNameIndex.HBg,
					"H Bg"
				},
				{
					OBJD.VariableNameIndex.VBg,
					"V Bg"
				},
				{
					OBJD.VariableNameIndex.SBg,
					"S Bg"
				},
				{
					OBJD.VariableNameIndex.BaseHBg,
					"Base H Bg"
				},
				{
					OBJD.VariableNameIndex.BaseVBg,
					"Base V Bg"
				},
				{
					OBJD.VariableNameIndex.BaseSBg,
					"Base S Bg"
				},
				{
					OBJD.VariableNameIndex.Mask,
					"Mask"
				},
				{
					OBJD.VariableNameIndex.Multiplier,
					"Multiplier"
				},
				{
					OBJD.VariableNameIndex.DirtLayer,
					"DirtLayer"
				},
				{
					OBJD.VariableNameIndex.OneXMultiplier,
					"1XMultiplier"
				},
				{
					OBJD.VariableNameIndex.Specular,
					"Specular"
				},
				{
					OBJD.VariableNameIndex.Overlay,
					"Overlay"
				},
				{
					OBJD.VariableNameIndex.Face,
					"Face"
				},
				{
					OBJD.VariableNameIndex.partType,
					"partType"
				},
				{
					OBJD.VariableNameIndex.gender,
					"gender"
				},
				{
					OBJD.VariableNameIndex.bodyType,
					"bodyType"
				},
				{
					OBJD.VariableNameIndex.age,
					"age"
				},
				{
					OBJD.VariableNameIndex.A,
					"A"
				},
				{
					OBJD.VariableNameIndex.M,
					"M"
				},
				{
					OBJD.VariableNameIndex.StencilA,
					"Stencil A"
				},
				{
					OBJD.VariableNameIndex.StencilB,
					"Stencil B"
				},
				{
					OBJD.VariableNameIndex.StencilC,
					"Stencil C"
				},
				{
					OBJD.VariableNameIndex.StencilD,
					"Stencil D"
				},
				{
					OBJD.VariableNameIndex.StencilAEnabled,
					"Stencil A Enabled"
				},
				{
					OBJD.VariableNameIndex.StencilBEnabled,
					"Stencil B Enabled"
				},
				{
					OBJD.VariableNameIndex.StencilCEnabled,
					"Stencil C Enabled"
				},
				{
					OBJD.VariableNameIndex.StencilDEnabled,
					"Stencil D Enabled"
				},
				{
					OBJD.VariableNameIndex.StencilATiling,
					"Stencil A Tiling"
				},
				{
					OBJD.VariableNameIndex.StencilBTiling,
					"Stencil B Tiling"
				},
				{
					OBJD.VariableNameIndex.StencilCTiling,
					"Stencil C Tiling"
				},
				{
					OBJD.VariableNameIndex.StencilDTiling,
					"Stencil D Tiling"
				},
				{
					OBJD.VariableNameIndex.StencilARotation,
					"Stencil A Rotation"
				},
				{
					OBJD.VariableNameIndex.StencilBRotation,
					"Stencil B Rotation"
				},
				{
					OBJD.VariableNameIndex.StencilCRotation,
					"Stencil C Rotation"
				},
				{
					OBJD.VariableNameIndex.StencilDRotation,
					"Stencil D Rotation"
				},
				{
					OBJD.VariableNameIndex.PatternA,
					"Pattern A"
				},
				{
					OBJD.VariableNameIndex.PatternB,
					"Pattern B"
				},
				{
					OBJD.VariableNameIndex.PatternC,
					"Pattern C"
				},
				{
					OBJD.VariableNameIndex.PatternAEnabled,
					"Pattern A Enabled"
				},
				{
					OBJD.VariableNameIndex.PatternBEnabled,
					"Pattern B Enabled"
				},
				{
					OBJD.VariableNameIndex.PatternCEnabled,
					"Pattern C Enabled"
				},
				{
					OBJD.VariableNameIndex.PatternALinked,
					"Pattern A Linked"
				},
				{
					OBJD.VariableNameIndex.PatternBLinked,
					"Pattern B Linked"
				},
				{
					OBJD.VariableNameIndex.PatternCLinked,
					"Pattern C Linked"
				},
				{
					OBJD.VariableNameIndex.PatternARotation,
					"Pattern A Rotation"
				},
				{
					OBJD.VariableNameIndex.PatternBRotation,
					"Pattern B Rotation"
				},
				{
					OBJD.VariableNameIndex.PatternCRotation,
					"Pattern C Rotation"
				},
				{
					OBJD.VariableNameIndex.PatternATiling,
					"Pattern A Tiling"
				},
				{
					OBJD.VariableNameIndex.PatternBTiling,
					"Pattern B Tiling"
				},
				{
					OBJD.VariableNameIndex.PatternCTiling,
					"Pattern C Tiling"
				},
				{
					OBJD.VariableNameIndex.End,
					"Empty"
				},
				{
					OBJD.VariableNameIndex.MaskWidth,
					"MaskWidth"
				},
				{
					OBJD.VariableNameIndex.MaskHeight,
					"MaskHeight"
				},
				{
					OBJD.VariableNameIndex.ObjectRgbaMask,
					"ObjectRgbaMask"
				},
				{
					OBJD.VariableNameIndex.RndColors,
					"RndColors"
				},
				{
					OBJD.VariableNameIndex.FlatColor,
					"FlatColor"
				},
				{
					OBJD.VariableNameIndex.Alpha,
					"Alpha"
				},
				{
					OBJD.VariableNameIndex.Color0,
					"Color 0"
				},
				{
					OBJD.VariableNameIndex.Color1,
					"Color 1"
				},
				{
					OBJD.VariableNameIndex.Color2,
					"Color 2"
				},
				{
					OBJD.VariableNameIndex.Color3,
					"Color 3"
				},
				{
					OBJD.VariableNameIndex.Color4,
					"Color 4"
				},
				{
					OBJD.VariableNameIndex.Channel1,
					"Channel 1"
				},
				{
					OBJD.VariableNameIndex.Channel2,
					"Channel 2"
				},
				{
					OBJD.VariableNameIndex.Channel3,
					"Channel 3"
				},
				{
					OBJD.VariableNameIndex.PatternD,
					"Pattern D"
				},
				{
					OBJD.VariableNameIndex.PatternDTiling,
					"Pattern D Tiling"
				},
				{
					OBJD.VariableNameIndex.PatternDEnabled,
					"Pattern D Enabled"
				},
				{
					OBJD.VariableNameIndex.PatternDLinked,
					"Pattern D Linked"
				},
				{
					OBJD.VariableNameIndex.PatternDRotation,
					"Pattern D Rotation"
				},
				{
					OBJD.VariableNameIndex.HSVShift1,
					"HSVShift 1"
				},
				{
					OBJD.VariableNameIndex.HSVShift2,
					"HSVShift 2"
				},
				{
					OBJD.VariableNameIndex.HSVShift3,
					"HSVShift 3"
				},
				{
					OBJD.VariableNameIndex.Channel1Enabled,
					"Channel 1 Enabled"
				},
				{
					OBJD.VariableNameIndex.Channel2Enabled,
					"Channel 2 Enabled"
				},
				{
					OBJD.VariableNameIndex.Channel3Enabled,
					"Channel 3 Enabled"
				},
				{
					OBJD.VariableNameIndex.BaseH1,
					"Base H 1"
				},
				{
					OBJD.VariableNameIndex.BaseV1,
					"Base V 1"
				},
				{
					OBJD.VariableNameIndex.BaseS1,
					"Base S 1"
				},
				{
					OBJD.VariableNameIndex.BaseH2,
					"Base H 2"
				},
				{
					OBJD.VariableNameIndex.BaseV2,
					"Base V 2"
				},
				{
					OBJD.VariableNameIndex.BaseS2,
					"Base S 2"
				},
				{
					OBJD.VariableNameIndex.BaseH3,
					"Base H 3"
				},
				{
					OBJD.VariableNameIndex.BaseV3,
					"Base V 3"
				},
				{
					OBJD.VariableNameIndex.BaseS3,
					"Base S 3"
				},
				{
					OBJD.VariableNameIndex.H1,
					"H 1"
				},
				{
					OBJD.VariableNameIndex.S1,
					"S 1"
				},
				{
					OBJD.VariableNameIndex.V1,
					"V 1"
				},
				{
					OBJD.VariableNameIndex.H2,
					"H 2"
				},
				{
					OBJD.VariableNameIndex.S2,
					"S 2"
				},
				{
					OBJD.VariableNameIndex.V2,
					"V 2"
				},
				{
					OBJD.VariableNameIndex.H3,
					"H 3"
				},
				{
					OBJD.VariableNameIndex.V3,
					"V 3"
				},
				{
					OBJD.VariableNameIndex.S3,
					"S 3"
				},
				{
					OBJD.VariableNameIndex.istrue,
					"true"
				},
				{
					OBJD.VariableNameIndex.Rgba,
					"1,0,0,0"
				},
				{
					OBJD.VariableNameIndex.defaultFlatColor,
					"defaultFlatColor"
				},
				{
					OBJD.VariableNameIndex.solidColor_1,
					"solidColor_1"
				}
			};

			// Token: 0x040006A7 RID: 1703
			private List<TGIIndex> _tgiIndex;

			// Token: 0x040006A8 RID: 1704
			private List<OBJD.Material.MaterialBlock> _materialBlocks;

			// Token: 0x040006A9 RID: 1705
			private byte type;

			// Token: 0x040006AA RID: 1706
			private uint unk_;

			// Token: 0x040006AC RID: 1708
			private uint offset;

			// Token: 0x040006AD RID: 1709
			private ushort unk;

			// Token: 0x040006AF RID: 1711
			public uint UInt2;

			// Token: 0x040006B0 RID: 1712
			public uint UInt3;

			// Token: 0x020001D2 RID: 466
			public class ComplateVariable
			{
				// Token: 0x17000586 RID: 1414
				// (get) Token: 0x06001148 RID: 4424 RVA: 0x0000BBB7 File Offset: 0x00009DB7
				// (set) Token: 0x06001149 RID: 4425 RVA: 0x0000BBBF File Offset: 0x00009DBF
				public string VariableName { get; set; }

				// Token: 0x17000587 RID: 1415
				// (get) Token: 0x0600114A RID: 4426 RVA: 0x0000BBC8 File Offset: 0x00009DC8
				// (set) Token: 0x0600114B RID: 4427 RVA: 0x0000BBD0 File Offset: 0x00009DD0
				public byte ValueTypeCode { get; set; }

				// Token: 0x0600114D RID: 4429 RVA: 0x00046D40 File Offset: 0x00044F40
				public string GetValue()
				{
					switch (this.ValueTypeCode)
					{
					case 1:
						return this._strValue;
					case 2:
						return string.Concat(new string[]
						{
							((float)this._colorValue[2] / 255f).ToString(CultureInfo.InvariantCulture.NumberFormat),
							",",
							((float)this._colorValue[1] / 255f).ToString(CultureInfo.InvariantCulture.NumberFormat),
							",",
							((float)this._colorValue[0] / 255f).ToString(CultureInfo.InvariantCulture.NumberFormat),
							",",
							((float)this._colorValue[3] / 255f).ToString(CultureInfo.InvariantCulture.NumberFormat)
						});
					case 3:
						return this._tgiIndexValue.ToString();
					case 4:
						return this._floatValues[0].ToString(CultureInfo.InvariantCulture.NumberFormat);
					case 5:
						return this._floatValues[0].ToString(CultureInfo.InvariantCulture.NumberFormat) + "," + this._floatValues[1].ToString(CultureInfo.InvariantCulture.NumberFormat);
					case 6:
						return string.Concat(new string[]
						{
							this._floatValues[0].ToString(CultureInfo.InvariantCulture.NumberFormat),
							",",
							this._floatValues[1].ToString(CultureInfo.InvariantCulture.NumberFormat),
							",",
							this._floatValues[2].ToString(CultureInfo.InvariantCulture.NumberFormat)
						});
					case 7:
						if (this._boolValue != 0)
						{
							return "True";
						}
						return "False";
					default:
						return "";
					}
				}

				// Token: 0x0600114E RID: 4430 RVA: 0x00046F30 File Offset: 0x00045130
				public void SetValue(byte typeCode, string value)
				{
					this.ValueTypeCode = typeCode;
					switch (typeCode)
					{
					case 1:
						this._strValue = value;
						return;
					case 2:
					{
						string[] array = value.Split(new char[]
						{
							','
						});
						this._colorValue = new byte[4];
						this._colorValue[2] = (byte)(float.Parse(array[0], CultureInfo.InvariantCulture.NumberFormat) * 255f);
						this._colorValue[1] = (byte)(float.Parse(array[1], CultureInfo.InvariantCulture.NumberFormat) * 255f);
						this._colorValue[0] = (byte)(float.Parse(array[2], CultureInfo.InvariantCulture.NumberFormat) * 255f);
						this._colorValue[3] = (byte)(float.Parse(array[3], CultureInfo.InvariantCulture.NumberFormat) * 255f);
						return;
					}
					case 3:
						this._tgiIndexValue = Convert.ToByte(value, 10);
						return;
					case 4:
					case 5:
					case 6:
					{
						int num = (int)(typeCode - 3);
						this._floatValues = new float[num];
						string[] array2 = value.Split(new char[]
						{
							','
						});
						for (int i = 0; i < num; i++)
						{
							this._floatValues[i] = float.Parse(array2[i], CultureInfo.InvariantCulture.NumberFormat);
						}
						return;
					}
					case 7:
						this._boolValue = ((value == "False") ? 0 : 1);
						return;
					default:
						return;
					}
				}

				// Token: 0x0600114F RID: 4431 RVA: 0x0000BBD9 File Offset: 0x00009DD9
				public override string ToString()
				{
					return this.VariableName + " = " + this.GetValue();
				}

				// Token: 0x06001150 RID: 4432 RVA: 0x00047084 File Offset: 0x00045284
				public void Serialize(BinaryWriter w)
				{
					if (OBJD.Material.VariableStringTable.ContainsValue(this.VariableName))
					{
						byte b = 0;
						foreach (OBJD.VariableNameIndex variableNameIndex in OBJD.Material.VariableStringTable.Keys)
						{
							if (OBJD.Material.VariableStringTable[variableNameIndex].Equals(this.VariableName))
							{
								b = (byte)variableNameIndex;
							}
						}
						if (b >= 64)
						{
							w.Write(64);
							byte value = b - 64;
							w.Write(value);
						}
						else
						{
							w.Write(b);
						}
					}
					else
					{
						byte value2 = (byte)(128 | this.VariableName.Length);
						if (this.VariableName.Length > 63)
						{
							value2 = 192;
						}
						w.Write(value2);
						if (this.VariableName.Length > 63)
						{
							w.Write((byte)this.VariableName.Length);
						}
						for (int i = 0; i < this.VariableName.Length; i++)
						{
							w.Write((byte)this.VariableName[i]);
						}
					}
					w.Write(this.ValueTypeCode);
					switch (this.ValueTypeCode)
					{
					case 1:
					{
						if (!OBJD.Material.VariableStringTable.ContainsValue(this._strValue))
						{
							byte value3 = (byte)(128 | this._strValue.Length);
							if (this._strValue.Length > 63)
							{
								value3 = 192;
							}
							w.Write(value3);
							if (this._strValue.Length > 63)
							{
								w.Write((byte)this._strValue.Length);
							}
							for (int j = 0; j < this._strValue.Length; j++)
							{
								w.Write((byte)this._strValue[j]);
							}
							return;
						}
						byte b2 = 0;
						foreach (OBJD.VariableNameIndex variableNameIndex2 in OBJD.Material.VariableStringTable.Keys)
						{
							if (OBJD.Material.VariableStringTable[variableNameIndex2].Equals(this._strValue))
							{
								b2 = (byte)variableNameIndex2;
							}
						}
						if (b2 >= 64)
						{
							w.Write(64);
							byte value4 = b2 - 64;
							w.Write(value4);
							return;
						}
						w.Write(b2);
						return;
					}
					case 2:
						w.Write(this._colorValue);
						return;
					case 3:
						w.Write(this._tgiIndexValue);
						return;
					case 4:
						w.Write(this._floatValues[0]);
						return;
					case 5:
						w.Write(this._floatValues[0]);
						w.Write(this._floatValues[1]);
						return;
					case 6:
						w.Write(this._floatValues[0]);
						w.Write(this._floatValues[1]);
						w.Write(this._floatValues[2]);
						return;
					case 7:
						w.Write(this._boolValue);
						return;
					default:
						return;
					}
				}

				// Token: 0x06001151 RID: 4433 RVA: 0x00047384 File Offset: 0x00045584
				public void Unserialize(BinaryReader r)
				{
					byte b = r.ReadByte();
					if ((b & 128) == 128)
					{
						int length = (int)(((b & 64) == 64) ? r.ReadByte() : (b & 63));
						this.VariableName = PackageUtil.ReadString(r, length);
					}
					else
					{
						if ((b & 64) == 64)
						{
							byte b2 = r.ReadByte();
							try
							{
								this.VariableName = OBJD.Material.VariableStringTable[(OBJD.VariableNameIndex)(b2 | 64)].ToString();
								goto IL_99;
							}
							catch (Exception)
							{
								this.VariableName = "unknown variable";
								goto IL_99;
							}
						}
						try
						{
							this.VariableName = OBJD.Material.VariableStringTable[(OBJD.VariableNameIndex)b].ToString();
						}
						catch (Exception)
						{
							this.VariableName = "unknown variable";
						}
					}
					IL_99:
					this.ValueTypeCode = r.ReadByte();
					switch (this.ValueTypeCode)
					{
					case 1:
					{
						byte b3 = r.ReadByte();
						if ((b3 & 128) == 128)
						{
							int length2 = (int)(((b3 & 64) == 64) ? r.ReadByte() : (b3 & 63));
							this._strValue = PackageUtil.ReadString(r, length2);
							return;
						}
						if ((b3 & 64) == 64)
						{
							byte b4 = r.ReadByte();
							try
							{
								this._strValue = OBJD.Material.VariableStringTable[(OBJD.VariableNameIndex)(b4 | 64)].ToString();
								return;
							}
							catch (Exception)
							{
								this.VariableName = "unknown variable";
								return;
							}
						}
						try
						{
							this._strValue = OBJD.Material.VariableStringTable[(OBJD.VariableNameIndex)b3].ToString();
							return;
						}
						catch (Exception)
						{
							this.VariableName = "unknown variable";
							return;
						}
						break;
					}
					case 2:
						break;
					case 3:
						this._tgiIndexValue = r.ReadByte();
						return;
					case 4:
						this._floatValues = new float[1];
						this._floatValues[0] = r.ReadSingle();
						return;
					case 5:
						this._floatValues = new float[2];
						this._floatValues[0] = r.ReadSingle();
						this._floatValues[1] = r.ReadSingle();
						return;
					case 6:
						this._floatValues = new float[3];
						this._floatValues[0] = r.ReadSingle();
						this._floatValues[1] = r.ReadSingle();
						this._floatValues[2] = r.ReadSingle();
						return;
					case 7:
						this._boolValue = r.ReadByte();
						return;
					default:
						return;
					}
					this._colorValue = r.ReadBytes(4);
				}

				// Token: 0x0400157B RID: 5499
				private string _strValue;

				// Token: 0x0400157C RID: 5500
				private byte _boolValue;

				// Token: 0x0400157D RID: 5501
				private float[] _floatValues;

				// Token: 0x0400157E RID: 5502
				private byte _tgiIndexValue;

				// Token: 0x0400157F RID: 5503
				private byte[] _colorValue;
			}

			// Token: 0x020001D3 RID: 467
			public class MaterialBlock
			{
				// Token: 0x17000588 RID: 1416
				// (get) Token: 0x06001152 RID: 4434 RVA: 0x0000BBF1 File Offset: 0x00009DF1
				// (set) Token: 0x06001153 RID: 4435 RVA: 0x0000BBF9 File Offset: 0x00009DF9
				public byte XMLIndex { get; set; }

				// Token: 0x06001154 RID: 4436 RVA: 0x0000BC02 File Offset: 0x00009E02
				public MaterialBlock()
				{
					this.Ref1Name = "";
					this.Ref2Name = "";
					this.Variables = new List<OBJD.Material.ComplateVariable>();
					this.Patterns = new List<OBJD.Material.MaterialBlock>();
				}

				// Token: 0x06001155 RID: 4437 RVA: 0x000475E4 File Offset: 0x000457E4
				public OBJD.Material.MaterialBlock AddPattern()
				{
					OBJD.Material.MaterialBlock materialBlock = new OBJD.Material.MaterialBlock();
					this.Patterns.Add(materialBlock);
					return materialBlock;
				}

				// Token: 0x06001156 RID: 4438 RVA: 0x00047604 File Offset: 0x00045804
				public OBJD.Material.ComplateVariable AddVariable(byte typeCode, string variableName, string value)
				{
					OBJD.Material.ComplateVariable complateVariable = new OBJD.Material.ComplateVariable();
					complateVariable.VariableName = variableName;
					complateVariable.SetValue(typeCode, value);
					this.Variables.Add(complateVariable);
					return complateVariable;
				}

				// Token: 0x06001157 RID: 4439 RVA: 0x00047634 File Offset: 0x00045834
				public OBJD.Material.ComplateVariable GetVariable(string variableName)
				{
					foreach (OBJD.Material.ComplateVariable complateVariable in this.Variables)
					{
						if (complateVariable.VariableName.ToLower().Equals(variableName.ToLower()))
						{
							return complateVariable;
						}
					}
					return null;
				}

				// Token: 0x06001158 RID: 4440 RVA: 0x000476A0 File Offset: 0x000458A0
				public void Serialize(BinaryWriter w)
				{
					w.Write(this.XMLIndex);
					if (OBJD.Material.VariableStringTable.ContainsValue(this.Ref1Name))
					{
						byte b = 0;
						foreach (OBJD.VariableNameIndex variableNameIndex in OBJD.Material.VariableStringTable.Keys)
						{
							if (OBJD.Material.VariableStringTable[variableNameIndex].Equals(this.Ref1Name))
							{
								b = (byte)variableNameIndex;
							}
						}
						if (b >= 64)
						{
							w.Write(64);
							byte value = b - 64;
							w.Write(value);
						}
						else
						{
							w.Write(b);
						}
					}
					else
					{
						byte value2 = (byte)(128 | this.Ref1Name.Length);
						if (this.Ref1Name.Length > 63)
						{
							value2 = 192;
						}
						w.Write(value2);
						if (this.Ref1Name.Length > 63)
						{
							w.Write((byte)this.Ref1Name.Length);
						}
						for (int i = 0; i < this.Ref1Name.Length; i++)
						{
							w.Write((byte)this.Ref1Name[i]);
						}
					}
					if (OBJD.Material.VariableStringTable.ContainsValue(this.Ref2Name))
					{
						byte b2 = 0;
						foreach (OBJD.VariableNameIndex variableNameIndex2 in OBJD.Material.VariableStringTable.Keys)
						{
							if (OBJD.Material.VariableStringTable[variableNameIndex2].Equals(this.Ref2Name))
							{
								b2 = (byte)variableNameIndex2;
							}
						}
						if (b2 >= 64)
						{
							w.Write(64);
							byte value3 = b2 - 64;
							w.Write(value3);
						}
						else
						{
							w.Write(b2);
						}
					}
					else
					{
						byte value4 = (byte)(128 | this.Ref2Name.Length);
						if (this.Ref2Name.Length > 63)
						{
							value4 = 192;
						}
						w.Write(value4);
						if (this.Ref2Name.Length > 63)
						{
							w.Write((byte)this.Ref2Name.Length);
						}
						for (int j = 0; j < this.Ref2Name.Length; j++)
						{
							w.Write((byte)this.Ref2Name[j]);
						}
					}
					w.Write(this.Variables.Count);
					foreach (OBJD.Material.ComplateVariable complateVariable in this.Variables)
					{
						complateVariable.Serialize(w);
						long position = w.BaseStream.Position;
					}
					w.Write(this.Patterns.Count);
					foreach (OBJD.Material.MaterialBlock materialBlock in this.Patterns)
					{
						materialBlock.Serialize(w);
					}
				}

				// Token: 0x06001159 RID: 4441 RVA: 0x000479B0 File Offset: 0x00045BB0
				public void Unserialize(BinaryReader r)
				{
					this.XMLIndex = r.ReadByte();
					byte b = r.ReadByte();
					if ((b & 128) == 128)
					{
						int length = (int)(((b & 64) == 64) ? r.ReadByte() : (b & 63));
						this.Ref1Name = PackageUtil.ReadString(r, length);
					}
					else
					{
						if ((b & 64) == 64)
						{
							try
							{
								this.Ref1Name = OBJD.Material.VariableStringTable[(OBJD.VariableNameIndex)(r.ReadByte() | 64)];
								goto IL_9B;
							}
							catch (Exception)
							{
								this.Ref1Name = "unknown name";
								goto IL_9B;
							}
						}
						try
						{
							this.Ref1Name = OBJD.Material.VariableStringTable[(OBJD.VariableNameIndex)b];
						}
						catch (Exception)
						{
							this.Ref1Name = "unknown name";
						}
					}
					IL_9B:
					byte b2 = r.ReadByte();
					if ((b2 & 128) == 128)
					{
						int length2 = (int)(((b2 & 64) == 64) ? r.ReadByte() : (b2 & 63));
						this.Ref2Name = PackageUtil.ReadString(r, length2);
					}
					else
					{
						if ((b2 & 64) == 64)
						{
							try
							{
								this.Ref2Name = OBJD.Material.VariableStringTable[(OBJD.VariableNameIndex)(r.ReadByte() | 64)];
								goto IL_12A;
							}
							catch (Exception)
							{
								this.Ref2Name = "unknown name";
								goto IL_12A;
							}
						}
						try
						{
							this.Ref2Name = OBJD.Material.VariableStringTable[(OBJD.VariableNameIndex)b2];
						}
						catch (Exception)
						{
							this.Ref2Name = "unknown name";
						}
					}
					IL_12A:
					uint num = r.ReadUInt32();
					int num2 = 0;
					while ((long)num2 < (long)((ulong)num))
					{
						OBJD.Material.ComplateVariable complateVariable = new OBJD.Material.ComplateVariable();
						complateVariable.Unserialize(r);
						this.Variables.Add(complateVariable);
						num2++;
					}
					uint num3 = r.ReadUInt32();
					int num4 = 0;
					while ((long)num4 < (long)((ulong)num3))
					{
						OBJD.Material.MaterialBlock materialBlock = new OBJD.Material.MaterialBlock();
						materialBlock.Unserialize(r);
						this.Patterns.Add(materialBlock);
						num4++;
					}
				}

				// Token: 0x04001580 RID: 5504
				public List<OBJD.Material.ComplateVariable> Variables;

				// Token: 0x04001581 RID: 5505
				public List<OBJD.Material.MaterialBlock> Patterns;

				// Token: 0x04001583 RID: 5507
				public string Ref1Name;

				// Token: 0x04001584 RID: 5508
				public string Ref2Name;
			}
		}
	}
}
