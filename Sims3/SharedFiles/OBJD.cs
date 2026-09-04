using System;
using System.Collections.Generic;
using System.ComponentModel;
using Sims3WorkshopSDK;

namespace Package.SharedFiles
{
	// Token: 0x020000AB RID: 171
	public abstract class OBJD : DBPFEntry, IObjd
	{
		// Token: 0x170002D3 RID: 723
		// (get) Token: 0x06000878 RID: 2168
		// (set) Token: 0x06000879 RID: 2169
		[TypeConverter(typeof(IntTypeConverter))]
		public abstract uint BuildCategoryFlags { get; set; }

		// Token: 0x170002D4 RID: 724
		// (get) Token: 0x0600087A RID: 2170
		// (set) Token: 0x0600087B RID: 2171
		public abstract string CatalogNameEntry { get; set; }

		// Token: 0x170002D5 RID: 725
		// (get) Token: 0x0600087C RID: 2172
		// (set) Token: 0x0600087D RID: 2173
		public abstract string CatalogDescEntry { get; set; }

		// Token: 0x170002D6 RID: 726
		// (get) Token: 0x0600087E RID: 2174
		// (set) Token: 0x0600087F RID: 2175
		public abstract string DAEFilename { get; set; }

		// Token: 0x170002D7 RID: 727
		// (get) Token: 0x06000880 RID: 2176
		// (set) Token: 0x06000881 RID: 2177
		[TypeConverter(typeof(IntTypeConverter))]
		public abstract long NameGuid { get; set; }

		// Token: 0x170002D8 RID: 728
		// (get) Token: 0x06000882 RID: 2178
		// (set) Token: 0x06000883 RID: 2179
		[TypeConverter(typeof(IntTypeConverter))]
		public abstract long DescGuid { get; set; }

		// Token: 0x170002D9 RID: 729
		// (get) Token: 0x06000884 RID: 2180
		// (set) Token: 0x06000885 RID: 2181
		public abstract List<TGIIndex> TgiIndex { get; set; }

		// Token: 0x170002DA RID: 730
		// (get) Token: 0x06000886 RID: 2182
		// (set) Token: 0x06000887 RID: 2183
		[TypeConverter(typeof(IntTypeConverter))]
		public abstract uint Version { get; set; }

		// Token: 0x170002DB RID: 731
		// (get) Token: 0x06000888 RID: 2184
		// (set) Token: 0x06000889 RID: 2185
		[TypeConverter(typeof(IntTypeConverter))]
		public abstract uint CategoryFlags { get; set; }

		// Token: 0x170002DC RID: 732
		// (get) Token: 0x0600088A RID: 2186
		// (set) Token: 0x0600088B RID: 2187
		[TypeConverter(typeof(IntTypeConverter))]
		public abstract ulong SubRoomFlags { get; set; }

		// Token: 0x170002DD RID: 733
		// (get) Token: 0x0600088C RID: 2188
		// (set) Token: 0x0600088D RID: 2189
		[TypeConverter(typeof(IntTypeConverter))]
		public abstract ulong SubCategoryFlags { get; set; }

		// Token: 0x170002DE RID: 734
		// (get) Token: 0x0600088E RID: 2190
		// (set) Token: 0x0600088F RID: 2191
		[TypeConverter(typeof(IntTypeConverter))]
		public abstract ulong SubCategoryFlags2 { get; set; }

		// Token: 0x170002DF RID: 735
		// (get) Token: 0x06000890 RID: 2192
		// (set) Token: 0x06000891 RID: 2193
		[TypeConverter(typeof(IntTypeConverter))]
		public abstract uint RoomFlags { get; set; }

		// Token: 0x170002E0 RID: 736
		// (get) Token: 0x06000892 RID: 2194
		// (set) Token: 0x06000893 RID: 2195
		[TypeConverter(typeof(IntTypeConverter))]
		public abstract long PngIcon { get; set; }

		// Token: 0x06000894 RID: 2196
		public abstract List<OBJD.Build> GetBuildFlags();

		// Token: 0x06000895 RID: 2197
		public abstract List<OBJD.Room> GetRoomFlags();

		// Token: 0x06000896 RID: 2198
		public abstract List<OBJD.SubRoom> GetSubRoomFlags();

		// Token: 0x06000897 RID: 2199
		public abstract List<OBJD.Category> GetCategoryFlags();

		// Token: 0x06000898 RID: 2200
		public abstract List<OBJD.SubCategory> GetSubCategoryFlags();

		// Token: 0x06000899 RID: 2201
		public abstract List<OBJD.SubCategory2> GetSubCategoryFlags2();

		// Token: 0x0600089A RID: 2202 RVA: 0x00006F21 File Offset: 0x00005121
		public OBJD()
		{
			if (OBJD.ValueLookupTable == null)
			{
				this.SetupValues();
			}
		}

		// Token: 0x0600089B RID: 2203 RVA: 0x00027224 File Offset: 0x00025424
		private void SetupValues()
		{
			OBJD.ValueLookupTable = new Dictionary<ushort, Dictionary<ushort, string>>();
			for (ushort num = 0; num < 65535; num += 1)
			{
				OBJD.ValueLookupTable.Add(num, new Dictionary<ushort, string>());
			}
			OBJD.ValueLookupTable[64].Add(64, "Optimism");
			OBJD.ValueLookupTable[65].Add(65, "Red");
			OBJD.ValueLookupTable[66].Add(66, "Gothic");
			OBJD.ValueLookupTable[67].Add(67, "Halloween");
			OBJD.ValueLookupTable[65].Add(68, "Blue");
			OBJD.ValueLookupTable[65].Add(69, "Green");
			OBJD.ValueLookupTable[66].Add(70, "Rocker");
			OBJD.ValueLookupTable[68].Add(71, "YoungAdult");
			OBJD.ValueLookupTable[68].Add(72, "Elder");
			OBJD.ValueLookupTable[69].Add(73, "African");
			OBJD.ValueLookupTable[69].Add(74, "MiddleEastern");
			OBJD.ValueLookupTable[69].Add(75, "Asian");
			OBJD.ValueLookupTable[69].Add(76, "Caucasian");
			OBJD.ValueLookupTable[70].Add(77, "Everyday");
			OBJD.ValueLookupTable[70].Add(78, "Formal");
			OBJD.ValueLookupTable[70].Add(79, "Swim");
			OBJD.ValueLookupTable[70].Add(80, "Athletic");
			OBJD.ValueLookupTable[70].Add(81, "Sleep");
			OBJD.ValueLookupTable[70].Add(82, "Bathing");
			OBJD.ValueLookupTable[70].Add(83, "Party");
			OBJD.ValueLookupTable[68].Add(84, "Adult");
			OBJD.ValueLookupTable[68].Add(85, "Child");
			OBJD.ValueLookupTable[71].Add(86, "Athletic");
			OBJD.ValueLookupTable[71].Add(87, "Cooking");
			OBJD.ValueLookupTable[69].Add(88, "SouthAsian");
			OBJD.ValueLookupTable[69].Add(89, "NorthAmerican");
			OBJD.ValueLookupTable[65].Add(90, "DarkBrown");
			OBJD.ValueLookupTable[65].Add(91, "Brown");
			OBJD.ValueLookupTable[65].Add(92, "Gray");
			OBJD.ValueLookupTable[65].Add(93, "Black");
			OBJD.ValueLookupTable[75].Add(94, "Blonde");
			OBJD.ValueLookupTable[65].Add(95, "Orange");
			OBJD.ValueLookupTable[75].Add(96, "Platinum");
			OBJD.ValueLookupTable[65].Add(97, "Amber");
			OBJD.ValueLookupTable[65].Add(98, "Aqua");
			OBJD.ValueLookupTable[65].Add(99, "HazelBlue");
			OBJD.ValueLookupTable[65].Add(100, "HazelGreen");
			OBJD.ValueLookupTable[65].Add(101, "LightBlue");
			OBJD.ValueLookupTable[65].Add(102, "LightBrown");
			OBJD.ValueLookupTable[65].Add(103, "LightGreen");
			OBJD.ValueLookupTable[65].Add(104, "Yellow");
			OBJD.ValueLookupTable[65].Add(105, "White");
			OBJD.ValueLookupTable[65].Add(106, "Pink");
			OBJD.ValueLookupTable[65].Add(107, "Purple");
			OBJD.ValueLookupTable[65].Add(108, "Burgundy");
			OBJD.ValueLookupTable[65].Add(109, "Cream");
			OBJD.ValueLookupTable[66].Add(110, "Casual");
			OBJD.ValueLookupTable[66].Add(111, "Sporty");
			OBJD.ValueLookupTable[66].Add(112, "Dressy");
			OBJD.ValueLookupTable[66].Add(113, "SuperCasual");
			OBJD.ValueLookupTable[72].Add(114, "Amber");
			OBJD.ValueLookupTable[72].Add(115, "Aqua");
			OBJD.ValueLookupTable[72].Add(116, "Black");
			OBJD.ValueLookupTable[72].Add(117, "Blue");
			OBJD.ValueLookupTable[72].Add(118, "Brown");
			OBJD.ValueLookupTable[72].Add(119, "DarkBrown");
			OBJD.ValueLookupTable[72].Add(120, "Gray");
			OBJD.ValueLookupTable[72].Add(121, "Green");
			OBJD.ValueLookupTable[72].Add(122, "HazelBlue");
			OBJD.ValueLookupTable[72].Add(123, "HazelGreen");
			OBJD.ValueLookupTable[72].Add(124, "LightBlue");
			OBJD.ValueLookupTable[72].Add(125, "LightBrown");
			OBJD.ValueLookupTable[72].Add(126, "LightGreen");
			OBJD.ValueLookupTable[74].Add(127, "Nude");
			OBJD.ValueLookupTable[73].Add(128, "Rocker");
			OBJD.ValueLookupTable[73].Add(129, "Fashionista");
			OBJD.ValueLookupTable[73].Add(130, "Boho");
			OBJD.ValueLookupTable[75].Add(131, "Black");
			OBJD.ValueLookupTable[75].Add(132, "Brown");
			OBJD.ValueLookupTable[75].Add(133, "DarkBrown");
			OBJD.ValueLookupTable[75].Add(134, "Gray");
			OBJD.ValueLookupTable[75].Add(135, "Orange");
			OBJD.ValueLookupTable[75].Add(136, "Red");
			OBJD.ValueLookupTable[71].Add(137, "Bartending");
			OBJD.ValueLookupTable[76].Add(140, "Dark");
			OBJD.ValueLookupTable[76].Add(141, "Jewel");
			OBJD.ValueLookupTable[76].Add(145, "Bold");
			OBJD.ValueLookupTable[76].Add(146, "Pastel");
			OBJD.ValueLookupTable[73].Add(148, "Mom");
			OBJD.ValueLookupTable[77].Add(149, "Short");
			OBJD.ValueLookupTable[77].Add(150, "Medium");
			OBJD.ValueLookupTable[77].Add(151, "Long");
			OBJD.ValueLookupTable[82].Add(152, "Pants");
			OBJD.ValueLookupTable[82].Add(153, "Skirt");
			OBJD.ValueLookupTable[82].Add(154, "Shorts");
			OBJD.ValueLookupTable[81].Add(155, "Blouse");
			OBJD.ValueLookupTable[81].Add(156, "Vest");
			OBJD.ValueLookupTable[86].Add(161, "TV");
			OBJD.ValueLookupTable[86].Add(162, "Computer");
			OBJD.ValueLookupTable[86].Add(163, "Audio");
			OBJD.ValueLookupTable[86].Add(164, "Sporting");
			OBJD.ValueLookupTable[86].Add(165, "HobbySkill");
			OBJD.ValueLookupTable[86].Add(166, "Party");
			OBJD.ValueLookupTable[86].Add(167, "KidFurniture");
			OBJD.ValueLookupTable[86].Add(168, "KidToy");
			OBJD.ValueLookupTable[86].Add(169, "Alarm");
			OBJD.ValueLookupTable[86].Add(170, "Phone");
			OBJD.ValueLookupTable[86].Add(171, "Clock");
			OBJD.ValueLookupTable[86].Add(172, "Videogame");
			OBJD.ValueLookupTable[86].Add(173, "IndoorActivity");
			OBJD.ValueLookupTable[86].Add(174, "KidActivity");
			OBJD.ValueLookupTable[86].Add(175, "OutdoorActivity");
			OBJD.ValueLookupTable[86].Add(176, "Bar");
			OBJD.ValueLookupTable[86].Add(177, "MiscElectronics");
			OBJD.ValueLookupTable[86].Add(178, "MiscEntertainment");
			OBJD.ValueLookupTable[86].Add(179, "MiscKids");
			OBJD.ValueLookupTable[87].Add(180, "Sink");
			OBJD.ValueLookupTable[87].Add(181, "Toilet");
			OBJD.ValueLookupTable[87].Add(182, "SinkFreestanding");
			OBJD.ValueLookupTable[87].Add(183, "Shower");
			OBJD.ValueLookupTable[87].Add(184, "Tub");
			OBJD.ValueLookupTable[87].Add(185, "LargeAppliance");
			OBJD.ValueLookupTable[87].Add(186, "SmallAppliance");
			OBJD.ValueLookupTable[87].Add(187, "Stove");
			OBJD.ValueLookupTable[87].Add(188, "Disposable");
			OBJD.ValueLookupTable[87].Add(189, "Refrigerator");
			OBJD.ValueLookupTable[87].Add(190, "OutdoorCooking");
			OBJD.ValueLookupTable[87].Add(191, "MiscSmallAppliance");
			OBJD.ValueLookupTable[87].Add(192, "MiscPlumbing");
			OBJD.ValueLookupTable[87].Add(193, "MiscAppliance");
			OBJD.ValueLookupTable[88].Add(194, "BathroomAccent");
			OBJD.ValueLookupTable[88].Add(195, "LawnOrnament");
			OBJD.ValueLookupTable[88].Add(196, "KidDecoration");
			OBJD.ValueLookupTable[88].Add(197, "WindowTreatment");
			OBJD.ValueLookupTable[88].Add(198, "Rug");
			OBJD.ValueLookupTable[88].Add(199, "FountainDecoration");
			OBJD.ValueLookupTable[88].Add(200, "Sculpture");
			OBJD.ValueLookupTable[88].Add(201, "WallDecoration");
			OBJD.ValueLookupTable[88].Add(202, "Plant");
			OBJD.ValueLookupTable[88].Add(203, "TableLamp");
			OBJD.ValueLookupTable[88].Add(204, "FloorLamp");
			OBJD.ValueLookupTable[88].Add(205, "CeilingLight");
			OBJD.ValueLookupTable[88].Add(206, "OutdoorLight");
			OBJD.ValueLookupTable[88].Add(207, "Mirror");
			OBJD.ValueLookupTable[88].Add(208, "MiscLight");
			OBJD.ValueLookupTable[88].Add(209, "MiscDecoration");
			OBJD.ValueLookupTable[89].Add(210, "Counter");
			OBJD.ValueLookupTable[89].Add(211, "Cabinet");
			OBJD.ValueLookupTable[89].Add(212, "DiningTable");
			OBJD.ValueLookupTable[89].Add(213, "EndTable");
			OBJD.ValueLookupTable[89].Add(214, "CoffeeTable");
			OBJD.ValueLookupTable[89].Add(215, "Desk");
			OBJD.ValueLookupTable[89].Add(216, "Display");
			OBJD.ValueLookupTable[89].Add(217, "DiningChair");
			OBJD.ValueLookupTable[89].Add(218, "Sofa");
			OBJD.ValueLookupTable[89].Add(219, "LoveSeat");
			OBJD.ValueLookupTable[89].Add(220, "OutdoorChair");
			OBJD.ValueLookupTable[89].Add(221, "LivingChair");
			OBJD.ValueLookupTable[89].Add(222, "DeskChair");
			OBJD.ValueLookupTable[89].Add(223, "OutdoorSeating");
			OBJD.ValueLookupTable[89].Add(224, "Barstool");
			OBJD.ValueLookupTable[89].Add(225, "Bed");
			OBJD.ValueLookupTable[89].Add(226, "Bookshelf");
			OBJD.ValueLookupTable[89].Add(227, "Dresser");
			OBJD.ValueLookupTable[89].Add(228, "MiscSurface");
			OBJD.ValueLookupTable[89].Add(229, "MiscComfort");
			OBJD.ValueLookupTable[89].Add(230, "MiscStorage");
			OBJD.ValueLookupTable[89].Add(1261, "BuyCat_Shareable");
			OBJD.ValueLookupTable[88].Add(231, "FountainEmitter");
			OBJD.ValueLookupTable[97].Add(232, "Block");
			OBJD.ValueLookupTable[97].Add(233, "Block");
			OBJD.ValueLookupTable[66].Add(237, "GenSummer");
			OBJD.ValueLookupTable[66].Add(238, "GenCitySleek");
			OBJD.ValueLookupTable[66].Add(239, "Classics");
			OBJD.ValueLookupTable[66].Add(240, "GenContemporaryBasic");
			OBJD.ValueLookupTable[66].Add(241, "GenContemporaryDesigner");
			OBJD.ValueLookupTable[66].Add(242, "GenGoth");
			OBJD.ValueLookupTable[66].Add(243, "GenOutdoorExplorer");
			OBJD.ValueLookupTable[66].Add(244, "GenPartyTrendy");
			OBJD.ValueLookupTable[66].Add(245, "GenPolished");
			OBJD.ValueLookupTable[66].Add(246, "GenPreppy");
			OBJD.ValueLookupTable[66].Add(247, "GenRomantic");
			OBJD.ValueLookupTable[66].Add(248, "FormalModern");
			OBJD.ValueLookupTable[66].Add(249, "FormalTrendy");
			OBJD.ValueLookupTable[66].Add(250, "KidsBasic");
			OBJD.ValueLookupTable[66].Add(251, "KidsDesigner");
			OBJD.ValueLookupTable[66].Add(252, "SleepContemporaryBasic");
			OBJD.ValueLookupTable[66].Add(253, "UnderwearBasic");
			OBJD.ValueLookupTable[66].Add(254, "UnderwearDesigner");
			OBJD.ValueLookupTable[66].Add(255, "Athletic");
			OBJD.ValueLookupTable[65].Add(256, "Silver");
			OBJD.ValueLookupTable[65].Add(257, "Gold");
			OBJD.ValueLookupTable[65].Add(258, "Magenta");
			OBJD.ValueLookupTable[65].Add(259, "Teal");
			OBJD.ValueLookupTable[65].Add(260, "Turquoise");
			OBJD.ValueLookupTable[65].Add(261, "BlueNavy");
			OBJD.ValueLookupTable[91].Add(262, "Maid");
			OBJD.ValueLookupTable[70].Add(263, "Career");
			OBJD.ValueLookupTable[93].Add(270, "LivingRoom");
			OBJD.ValueLookupTable[93].Add(271, "Bathroom");
			OBJD.ValueLookupTable[93].Add(272, "Bedroom");
			OBJD.ValueLookupTable[93].Add(273, "DiningRoom");
			OBJD.ValueLookupTable[93].Add(274, "Kitchen");
			OBJD.ValueLookupTable[93].Add(275, "Outdoor");
			OBJD.ValueLookupTable[93].Add(276, "Study");
			OBJD.ValueLookupTable[76].Add(280, "EarthTones");
			OBJD.ValueLookupTable[76].Add(282, "GrayscaleDark");
			OBJD.ValueLookupTable[76].Add(283, "GrayscaleLight");
			OBJD.ValueLookupTable[76].Add(285, "Spring");
			OBJD.ValueLookupTable[76].Add(286, "Summer");
			OBJD.ValueLookupTable[76].Add(287, "Winter");
			OBJD.ValueLookupTable[76].Add(288, "GothRockPunk");
			OBJD.ValueLookupTable[66].Add(289, "GothRockPunk");
			OBJD.ValueLookupTable[68].Add(291, "Teen");
			OBJD.ValueLookupTable[65].Add(292, "BlueLight");
			OBJD.ValueLookupTable[65].Add(293, "BrownLight");
			OBJD.ValueLookupTable[65].Add(294, "Beige");
			OBJD.ValueLookupTable[81].Add(295, "Jacket");
			OBJD.ValueLookupTable[81].Add(296, "ShirtTee");
			OBJD.ValueLookupTable[81].Add(297, "Sweater");
			OBJD.ValueLookupTable[94].Add(298, "Carpet");
			OBJD.ValueLookupTable[94].Add(299, "Tile");
			OBJD.ValueLookupTable[94].Add(300, "Wood");
			OBJD.ValueLookupTable[94].Add(301, "Stone");
			OBJD.ValueLookupTable[94].Add(302, "Masonry");
			OBJD.ValueLookupTable[94].Add(303, "Linoleum");
			OBJD.ValueLookupTable[94].Add(304, "Metal");
			OBJD.ValueLookupTable[94].Add(305, "Misc");
			OBJD.ValueLookupTable[94].Add(306, "Outdoor");
			OBJD.ValueLookupTable[94].Add(307, "Grass");
			OBJD.ValueLookupTable[94].Add(308, "Flowers");
			OBJD.ValueLookupTable[94].Add(309, "DirtSand");
			OBJD.ValueLookupTable[88].Add(310, "WallLight");
			OBJD.ValueLookupTable[65].Add(311, "GreenNavy");
			OBJD.ValueLookupTable[69].Add(312, "Latin");
			OBJD.ValueLookupTable[77].Add(313, "Straight");
			OBJD.ValueLookupTable[77].Add(314, "Curly");
			OBJD.ValueLookupTable[77].Add(315, "Wavy");
			OBJD.ValueLookupTable[91].Add(316, "GrimReaper");
			OBJD.ValueLookupTable[64].Add(317, "Angry");
			OBJD.ValueLookupTable[64].Add(318, "Bored");
			OBJD.ValueLookupTable[64].Add(319, "Confident");
			OBJD.ValueLookupTable[64].Add(320, "Cranky");
			OBJD.ValueLookupTable[64].Add(321, "Depressed");
			OBJD.ValueLookupTable[64].Add(322, "Drunk");
			OBJD.ValueLookupTable[64].Add(323, "Embarrassed");
			OBJD.ValueLookupTable[64].Add(324, "Energized");
			OBJD.ValueLookupTable[64].Add(325, "Flirty");
			OBJD.ValueLookupTable[64].Add(326, "Focused");
			OBJD.ValueLookupTable[64].Add(327, "Tense");
			OBJD.ValueLookupTable[64].Add(328, "Happy");
			OBJD.ValueLookupTable[64].Add(329, "Imaginative");
			OBJD.ValueLookupTable[64].Add(330, "Uncomfortable");
			OBJD.ValueLookupTable[64].Add(331, "Fine");
			OBJD.ValueLookupTable[64].Add(332, "Playful");
			OBJD.ValueLookupTable[64].Add(333, "Sad");
			OBJD.ValueLookupTable[64].Add(334, "Sloshed");
			OBJD.ValueLookupTable[70].Add(335, "Situation");
			OBJD.ValueLookupTable[71].Add(336, "Creative");
			OBJD.ValueLookupTable[71].Add(337, "Mental");
			OBJD.ValueLookupTable[71].Add(338, "Physical");
			OBJD.ValueLookupTable[71].Add(339, "Social");
			OBJD.ValueLookupTable[91].Add(341, "Mailman");
			OBJD.ValueLookupTable[81].Add(360, "Tanktop");
			OBJD.ValueLookupTable[91].Add(366, "GrimReaperHelper");
			OBJD.ValueLookupTable[79].Add(371, "Brim");
			OBJD.ValueLookupTable[79].Add(372, "Brimless");
			OBJD.ValueLookupTable[79].Add(373, "Cap");
			OBJD.ValueLookupTable[83].Add(374, "Jumpsuits");
			OBJD.ValueLookupTable[83].Add(375, "Longdress");
			OBJD.ValueLookupTable[83].Add(376, "Shortdress");
			OBJD.ValueLookupTable[83].Add(377, "Suits");
			OBJD.ValueLookupTable[78].Add(378, "Beard");
			OBJD.ValueLookupTable[78].Add(379, "Goatee");
			OBJD.ValueLookupTable[78].Add(380, "Mustache");
			OBJD.ValueLookupTable[82].Add(381, "Leggings");
			OBJD.ValueLookupTable[82].Add(382, "Jeans");
			OBJD.ValueLookupTable[84].Add(383, "Booties");
			OBJD.ValueLookupTable[84].Add(384, "Boots");
			OBJD.ValueLookupTable[84].Add(385, "Flats");
			OBJD.ValueLookupTable[84].Add(386, "Heels");
			OBJD.ValueLookupTable[84].Add(387, "LaceUpAdult");
			OBJD.ValueLookupTable[84].Add(388, "LaceUpChildren");
			OBJD.ValueLookupTable[84].Add(389, "Loafers");
			OBJD.ValueLookupTable[84].Add(390, "Sandals");
			OBJD.ValueLookupTable[84].Add(391, "Slippers");
			OBJD.ValueLookupTable[84].Add(392, "Sneakers");
			OBJD.ValueLookupTable[84].Add(393, "Wedges");
			OBJD.ValueLookupTable[81].Add(395, "ButtonUps");
			OBJD.ValueLookupTable[93].Add(407, "Misc");
			OBJD.ValueLookupTable[95].Add(408, "Paint");
			OBJD.ValueLookupTable[95].Add(409, "Wallpaper");
			OBJD.ValueLookupTable[95].Add(410, "Tile");
			OBJD.ValueLookupTable[95].Add(411, "Paneling");
			OBJD.ValueLookupTable[95].Add(412, "Masonry");
			OBJD.ValueLookupTable[95].Add(413, "RockAndStone");
			OBJD.ValueLookupTable[95].Add(414, "Siding");
			OBJD.ValueLookupTable[95].Add(415, "Misc");
			OBJD.ValueLookupTable[72].Add(421, "Hazel");
			OBJD.ValueLookupTable[72].Add(422, "Honey");
			OBJD.ValueLookupTable[72].Add(423, "Golden");
			OBJD.ValueLookupTable[71].Add(445, "Musical");
			OBJD.ValueLookupTable[71].Add(448, "All");
			OBJD.ValueLookupTable[86].Add(456, "Basketball");
			OBJD.ValueLookupTable[86].Add(457, "Chess");
			OBJD.ValueLookupTable[86].Add(458, "MonkeyBars");
			OBJD.ValueLookupTable[93].Add(468, "Empty");
			OBJD.ValueLookupTable[96].Add(531, "Leather");
			OBJD.ValueLookupTable[96].Add(532, "Cotton");
			OBJD.ValueLookupTable[66].Add(534, "InReview");
			OBJD.ValueLookupTable[97].Add(535, "Door");
			OBJD.ValueLookupTable[97].Add(536, "Window");
			OBJD.ValueLookupTable[97].Add(537, "Gate");
			OBJD.ValueLookupTable[97].Add(538, "Column");
			OBJD.ValueLookupTable[97].Add(539, "RoofAttachment");
			OBJD.ValueLookupTable[97].Add(540, "Roof");
			OBJD.ValueLookupTable[97].Add(541, "FloorPattern");
			OBJD.ValueLookupTable[97].Add(542, "WallPattern");
			OBJD.ValueLookupTable[97].Add(543, "RoofPattern");
			OBJD.ValueLookupTable[97].Add(544, "Fence");
			OBJD.ValueLookupTable[97].Add(545, "Spandrel");
			OBJD.ValueLookupTable[97].Add(546, "Stair");
			OBJD.ValueLookupTable[97].Add(547, "Railing");
			OBJD.ValueLookupTable[97].Add(548, "Block");
			OBJD.ValueLookupTable[97].Add(549, "Style");
			OBJD.ValueLookupTable[97].Add(550, "Frieze");
			OBJD.ValueLookupTable[97].Add(551, "RoofTrim");
			OBJD.ValueLookupTable[97].Add(552, "Foundation");
			OBJD.ValueLookupTable[97].Add(554, "FloorTrim");
			OBJD.ValueLookupTable[97].Add(555, "WallAttachment");
			OBJD.ValueLookupTable[97].Add(556, "Flower");
			OBJD.ValueLookupTable[97].Add(557, "Shrub");
			OBJD.ValueLookupTable[97].Add(558, "Tree");
			OBJD.ValueLookupTable[97].Add(559, "Rug");
			OBJD.ValueLookupTable[97].Add(560, "Rock");
			OBJD.ValueLookupTable[97].Add(561, "Arch");
			OBJD.ValueLookupTable[96].Add(584, "Synthetic");
			OBJD.ValueLookupTable[96].Add(585, "Silk");
			OBJD.ValueLookupTable[96].Add(586, "Wool");
			OBJD.ValueLookupTable[96].Add(587, "Denim");
			OBJD.ValueLookupTable[98].Add(590, "Animal");
			OBJD.ValueLookupTable[91].Add(607, "OfficeWorker");
			OBJD.ValueLookupTable[91].Add(608, "Suit");
			OBJD.ValueLookupTable[91].Add(609, "Tuxedo");
			OBJD.ValueLookupTable[91].Add(610, "SuperTuxedo");
			OBJD.ValueLookupTable[91].Add(611, "Villain");
			OBJD.ValueLookupTable[91].Add(612, "TactialTurtleneck");
			OBJD.ValueLookupTable[91].Add(613, "MaintainenceWorker");
			OBJD.ValueLookupTable[91].Add(614, "AstronautSuit");
			OBJD.ValueLookupTable[91].Add(615, "SpaceRanger");
			OBJD.ValueLookupTable[91].Add(616, "Smuggler");
			OBJD.ValueLookupTable[91].Add(617, "Suit");
			OBJD.ValueLookupTable[91].Add(618, "ConcertOutfit");
			OBJD.ValueLookupTable[91].Add(619, "Cook");
			OBJD.ValueLookupTable[91].Add(620, "Chef");
			OBJD.ValueLookupTable[91].Add(621, "Bartender");
			OBJD.ValueLookupTable[91].Add(622, "CrimeLordHat");
			OBJD.ValueLookupTable[91].Add(623, "CrimeBoss");
			OBJD.ValueLookupTable[91].Add(624, "Hacker");
			OBJD.ValueLookupTable[91].Add(625, "ElbowPatchJacket");
			OBJD.ValueLookupTable[91].Add(626, "InvestigativeJournalist");
			OBJD.ValueLookupTable[91].Add(627, "BlackTurtleneck");
			OBJD.ValueLookupTable[91].Add(628, "ProGamer");
			OBJD.ValueLookupTable[91].Add(629, "Painter");
			OBJD.ValueLookupTable[91].Add(630, "Parts");
			OBJD.ValueLookupTable[91].Add(631, "Parts");
			OBJD.ValueLookupTable[91].Add(632, "Party");
			OBJD.ValueLookupTable[91].Add(633, "Parts");
			OBJD.ValueLookupTable[91].Add(634, "Parts");
			OBJD.ValueLookupTable[91].Add(635, "Parts");
			OBJD.ValueLookupTable[91].Add(636, "MaidDEPRECATED");
			OBJD.ValueLookupTable[91].Add(637, "PizzaDelivery");
			OBJD.ValueLookupTable[71].Add(641, "Child");
			OBJD.ValueLookupTable[71].Add(652, "FitnessOrProgramming");
			OBJD.ValueLookupTable[97].Add(653, "Block");
			OBJD.ValueLookupTable[91].Add(659, "Oracle");
			OBJD.ValueLookupTable[99].Add(662, "Short");
			OBJD.ValueLookupTable[100].Add(663, "Wavy");
			OBJD.ValueLookupTable[99].Add(664, "Long");
			OBJD.ValueLookupTable[71].Add(675, "VideoGaming");
			OBJD.ValueLookupTable[71].Add(676, "Charisma");
			OBJD.ValueLookupTable[71].Add(677, "Logic");
			OBJD.ValueLookupTable[71].Add(678, "RocketScience");
			OBJD.ValueLookupTable[71].Add(679, "Writing");
			OBJD.ValueLookupTable[91].Add(680, "Clown");
			OBJD.ValueLookupTable[91].Add(681, "HotDog");
			OBJD.ValueLookupTable[91].Add(682, "BlackAndWhiteParty");
			OBJD.ValueLookupTable[101].Add(753, "Emotional");
			OBJD.ValueLookupTable[101].Add(754, "Hobbies");
			OBJD.ValueLookupTable[101].Add(755, "Lifestyle");
			OBJD.ValueLookupTable[101].Add(756, "Social");
			OBJD.ValueLookupTable[91].Add(760, "Teenager");
			OBJD.ValueLookupTable[102].Add(761, "Red");
			OBJD.ValueLookupTable[102].Add(762, "Yellow");
			OBJD.ValueLookupTable[102].Add(763, "Olive");
			OBJD.ValueLookupTable[103].Add(767, "CASPart");
			OBJD.ValueLookupTable[97].Add(782, "Post");
			OBJD.ValueLookupTable[88].Add(785, "Fireplace");
			OBJD.ValueLookupTable[97].Add(787, "Buy");
			OBJD.ValueLookupTable[99].Add(820, "Medium");
			OBJD.ValueLookupTable[100].Add(821, "Curly");
			OBJD.ValueLookupTable[100].Add(822, "Straight");
			OBJD.ValueLookupTable[88].Add(823, "Clutter");
			OBJD.ValueLookupTable[88].Add(824, "WallSculpture");
			OBJD.ValueLookupTable[93].Add(864, "Kids");
			OBJD.ValueLookupTable[91].Add(867, "MasterFisherman");
			OBJD.ValueLookupTable[91].Add(868, "MasterGardener");
			OBJD.ValueLookupTable[104].Add(872, "Dirt");
			OBJD.ValueLookupTable[104].Add(873, "Grass");
			OBJD.ValueLookupTable[104].Add(874, "Stone");
			OBJD.ValueLookupTable[104].Add(875, "Misc");
			OBJD.ValueLookupTable[91].Add(883, "FastFood");
			OBJD.ValueLookupTable[91].Add(884, "Barista");
			OBJD.ValueLookupTable[91].Add(885, "ManualLabor");
			OBJD.ValueLookupTable[91].Add(886, "Retail");
			OBJD.ValueLookupTable[91].Add(887, "Babysitter");
			OBJD.ValueLookupTable[75].Add(896, "Auburn");
			OBJD.ValueLookupTable[75].Add(897, "BlackSaltAndPepper");
			OBJD.ValueLookupTable[75].Add(898, "BrownSaltAndPepper");
			OBJD.ValueLookupTable[75].Add(899, "DarkBlue");
			OBJD.ValueLookupTable[75].Add(900, "DirtyBlond");
			OBJD.ValueLookupTable[75].Add(901, "Green");
			OBJD.ValueLookupTable[75].Add(902, "HotPink");
			OBJD.ValueLookupTable[75].Add(903, "PurplePastel");
			OBJD.ValueLookupTable[75].Add(904, "Turquoise");
			OBJD.ValueLookupTable[75].Add(905, "White");
			OBJD.ValueLookupTable[97].Add(906, "RoofDiagonal");
			OBJD.ValueLookupTable[87].Add(913, "StoveHood");
			OBJD.ValueLookupTable[89].Add(914, "BedDouble");
			OBJD.ValueLookupTable[97].Add(915, "GateDouble");
			OBJD.ValueLookupTable[89].Add(916, "OutdoorBench");
			OBJD.ValueLookupTable[89].Add(917, "OutdoorTable");
			OBJD.ValueLookupTable[97].Add(918, "DoorDouble");
			OBJD.ValueLookupTable[97].Add(919, "RoofChimney");
			OBJD.ValueLookupTable[87].Add(920, "SinkCounter");
			OBJD.ValueLookupTable[96].Add(932, "Metal");
			OBJD.ValueLookupTable[96].Add(933, "Silver");
			OBJD.ValueLookupTable[71].Add(935, "GuitarorComedy");
			OBJD.ValueLookupTable[71].Add(936, "ViolinorGuitar");
			OBJD.ValueLookupTable[81].Add(941, "Sweatshirt");
			OBJD.ValueLookupTable[81].Add(942, "SuitJacket");
			OBJD.ValueLookupTable[81].Add(943, "Polo");
			OBJD.ValueLookupTable[81].Add(944, "Brassiere");
			OBJD.ValueLookupTable[82].Add(945, "Cropped");
			OBJD.ValueLookupTable[82].Add(946, "Underwear");
			OBJD.ValueLookupTable[83].Add(947, "Outerwear");
			OBJD.ValueLookupTable[83].Add(948, "Costume");
			OBJD.ValueLookupTable[83].Add(949, "Robe");
			OBJD.ValueLookupTable[83].Add(950, "Lingerie");
			OBJD.ValueLookupTable[83].Add(951, "Apron");
			OBJD.ValueLookupTable[83].Add(952, "Overall");
			OBJD.ValueLookupTable[83].Add(953, "Set");
			OBJD.ValueLookupTable[89].Add(962, "DiningTableShort");
			OBJD.ValueLookupTable[89].Add(963, "DiningTableLong");
			OBJD.ValueLookupTable[88].Add(964, "MirrorWall");
			OBJD.ValueLookupTable[88].Add(965, "MirrorFreestanding");
			OBJD.ValueLookupTable[87].Add(966, "CoffeeMaker");
			OBJD.ValueLookupTable[87].Add(967, "Microwave");
			OBJD.ValueLookupTable[86].Add(968, "CreativeActivity");
			OBJD.ValueLookupTable[86].Add(969, "KnowledgeActivity");
			OBJD.ValueLookupTable[86].Add(970, "ActiveActivity");
			OBJD.ValueLookupTable[89].Add(971, "BedSingle");
			OBJD.ValueLookupTable[87].Add(972, "DisposalIndoor");
			OBJD.ValueLookupTable[87].Add(973, "DisposalOutdoor");
			OBJD.ValueLookupTable[97].Add(974, "DoorSingle");
			OBJD.ValueLookupTable[97].Add(975, "RoofAttachmentMisc");
			OBJD.ValueLookupTable[97].Add(976, "GateSingle");
			OBJD.ValueLookupTable[97].Add(977, "RoofOrthogonal");
			OBJD.ValueLookupTable[88].Add(978, "CurtainBlind");
			OBJD.ValueLookupTable[88].Add(979, "Awning");
			OBJD.ValueLookupTable[97].Add(981, "WeddingArch");
			OBJD.ValueLookupTable[66].Add(985, "Country");
			OBJD.ValueLookupTable[66].Add(986, "Hipster");
			OBJD.ValueLookupTable[82].Add(1040, "Underwear");
			OBJD.ValueLookupTable[105].Add(1054, "Bushy");
			OBJD.ValueLookupTable[105].Add(1055, "Thin");
			OBJD.ValueLookupTable[105].Add(1056, "Sparse");
			OBJD.ValueLookupTable[105].Add(1057, "Medium");
			OBJD.ValueLookupTable[106].Add(1058, "Straight");
			OBJD.ValueLookupTable[106].Add(1059, "Curved");
			OBJD.ValueLookupTable[106].Add(1060, "Arched");
			OBJD.ValueLookupTable[97].Add(1062, "Block");
			OBJD.ValueLookupTable[97].Add(1063, "Block");
			OBJD.ValueLookupTable[97].Add(1064, "Block");
			OBJD.ValueLookupTable[97].Add(1065, "Shrub");
			OBJD.ValueLookupTable[97].Add(1066, "Shrub");
			OBJD.ValueLookupTable[97].Add(1067, "Flower");
			OBJD.ValueLookupTable[97].Add(1068, "Flower");
			OBJD.ValueLookupTable[97].Add(1069, "Flower");
			OBJD.ValueLookupTable[97].Add(1070, "Block");
			OBJD.ValueLookupTable[89].Add(1071, "PostcardBoard");
			OBJD.ValueLookupTable[89].Add(1072, "ElementDisplay");
		}

		// Token: 0x0400041B RID: 1051
		public static readonly Dictionary<OBJD.Build, string> BuildLabels = new Dictionary<OBJD.Build, string>
		{
			{
				OBJD.Build.Arch,
				"Arched Doors"
			},
			{
				OBJD.Build.Column,
				"Columns"
			},
			{
				OBJD.Build.RabbitHole,
				"Community"
			},
			{
				OBJD.Build.Door,
				"Doors"
			},
			{
				OBJD.Build.Gate,
				"Gates"
			},
			{
				OBJD.Build.Fireplace,
				"Fireplaces"
			},
			{
				OBJD.Build.Flower,
				"Groundcover"
			},
			{
				OBJD.Build.Shrub,
				"Plants"
			},
			{
				OBJD.Build.Rock,
				"Rocks"
			},
			{
				OBJD.Build.Rug,
				"Rugs"
			},
			{
				OBJD.Build.Tree,
				"Trees"
			},
			{
				OBJD.Build.Window,
				"Windows"
			},
			{
				OBJD.Build.BluePrint,
				"Blueprint"
			},
			{
				OBJD.Build.ResortObjects,
				"Resort Objects"
			},
			{
				OBJD.Build.ModularArch,
				"Modular Arch"
			}
		};

		// Token: 0x0400041C RID: 1052
		public static readonly Dictionary<OBJD.Room, string> RoomLabels = new Dictionary<OBJD.Room, string>
		{
			{
				OBJD.Room.Bathroom,
				"Bathroom"
			},
			{
				OBJD.Room.BedRoom,
				"Bedroom"
			},
			{
				OBJD.Room.CommunityLot,
				"Community Lot"
			},
			{
				OBJD.Room.DiningRoom,
				"Dining Room"
			},
			{
				OBJD.Room.KidsRoom,
				"Kid Bedroom"
			},
			{
				OBJD.Room.Kitchen,
				"Kitchen"
			},
			{
				OBJD.Room.LivingRoom,
				"Livingroom"
			},
			{
				OBJD.Room.Outdoor,
				"Outdoors"
			},
			{
				OBJD.Room.Pool,
				"Pool"
			},
			{
				OBJD.Room.Study,
				"Study"
			},
			{
				OBJD.Room.ResidentialLot,
				"Residential Lot"
			},
			{
				OBJD.Room.ResortArcade,
				"Resort Arcade"
			},
			{
				OBJD.Room.ResortArtGallery,
				"Resort Art Gallery"
			},
			{
				OBJD.Room.ResortDanceHall,
				"Resort Dance Hall"
			},
			{
				OBJD.Room.ResortGym,
				"Resort Gym"
			},
			{
				OBJD.Room.ResortLobby,
				"Resort Lobby"
			},
			{
				OBJD.Room.ResortOutdoorPartyArea,
				"Resort Outdoor Party"
			},
			{
				OBJD.Room.ResortPoolArea,
				"Resort Pool Area"
			},
			{
				OBJD.Room.ResortRestaurant,
				"Resort Restaurant"
			},
			{
				OBJD.Room.ResortSpa,
				"Resort Spa"
			},
			{
				OBJD.Room.ResortTikiLounge,
				"Resort Tiki Lounge"
			}
		};

		// Token: 0x0400041D RID: 1053
		public static readonly Dictionary<OBJD.SubRoom, string> SubRoomLabels = new Dictionary<OBJD.SubRoom, string>
		{
			{
				OBJD.SubRoom.Accents,
				"Accents"
			},
			{
				OBJD.SubRoom.Alarms,
				"Alarms"
			},
			{
				OBJD.SubRoom.Audio,
				"Audio"
			},
			{
				OBJD.SubRoom.Bars,
				"Bars"
			},
			{
				OBJD.SubRoom.BarStools,
				"Barstools"
			},
			{
				OBJD.SubRoom.Beds,
				"Beds"
			},
			{
				OBJD.SubRoom.Bookshelves,
				"Bookshelves"
			},
			{
				OBJD.SubRoom.Cabinets,
				"Cabinets"
			},
			{
				OBJD.SubRoom.CeilingLights,
				"Ceiling Lights"
			},
			{
				OBJD.SubRoom.Clocks,
				"Clocks"
			},
			{
				OBJD.SubRoom.CoffeeTables,
				"Coffee Tables"
			},
			{
				OBJD.SubRoom.Computers,
				"Computers"
			},
			{
				OBJD.SubRoom.Counters,
				"Counters"
			},
			{
				OBJD.SubRoom.Default,
				"Default"
			},
			{
				OBJD.SubRoom.Desks,
				"Desks"
			},
			{
				OBJD.SubRoom.DiningChairs,
				"Dining Chairs"
			},
			{
				OBJD.SubRoom.DiningTables,
				"Dining Tables"
			},
			{
				OBJD.SubRoom.Dishwashers,
				"Dishwashers"
			},
			{
				OBJD.SubRoom.Dressers,
				"Dressers"
			},
			{
				OBJD.SubRoom.EatingOut,
				"Eating Out"
			},
			{
				OBJD.SubRoom.EndTables,
				"End Tables"
			},
			{
				OBJD.SubRoom.FloorLamps,
				"Floor Lamps"
			},
			{
				OBJD.SubRoom.Refrigerators,
				"Refrigerators"
			},
			{
				OBJD.SubRoom.Furniture,
				"Furniture"
			},
			{
				OBJD.SubRoom.HobbiesAndSkills,
				"Hobbies and Skills"
			},
			{
				OBJD.SubRoom.IndoorActivities,
				"Indoor Activities"
			},
			{
				OBJD.SubRoom.KidsDecor,
				"Kids Decor"
			},
			{
				OBJD.SubRoom.LawnOrnaments,
				"Lawn Decor"
			},
			{
				OBJD.SubRoom.LivingChairs,
				"Living Chairs"
			},
			{
				OBJD.SubRoom.Mirrors,
				"Mirrors"
			},
			{
				OBJD.SubRoom.MiscellaneousDecor,
				"Misc Decor"
			},
			{
				OBJD.SubRoom.OfficeChairs,
				"Office Chairs"
			},
			{
				OBJD.SubRoom.OutdoorActivities,
				"Outdoor Activities"
			},
			{
				OBJD.SubRoom.OutdoorLights,
				"Outdoor Lights"
			},
			{
				OBJD.SubRoom.OutdoorSeating,
				"Outdoor Seating"
			},
			{
				OBJD.SubRoom.Phones,
				"Phones"
			},
			{
				OBJD.SubRoom.Plants,
				"Plants"
			},
			{
				OBJD.SubRoom.Rugs,
				"Rugs"
			},
			{
				OBJD.SubRoom.Showers,
				"Showers"
			},
			{
				OBJD.SubRoom.Sinks,
				"Sinks"
			},
			{
				OBJD.SubRoom.SmallAppliances,
				"Small Appliances"
			},
			{
				OBJD.SubRoom.SmokeAlarms,
				"Smoke Alarm"
			},
			{
				OBJD.SubRoom.SofasAndLoveseats,
				"Sofas"
			},
			{
				OBJD.SubRoom.Stoves,
				"Stoves"
			},
			{
				OBJD.SubRoom.TableLamps,
				"Table Lamps"
			},
			{
				OBJD.SubRoom.Toilets,
				"Toilets"
			},
			{
				OBJD.SubRoom.Toys,
				"Toys"
			},
			{
				OBJD.SubRoom.Transportation,
				"Transport"
			},
			{
				OBJD.SubRoom.Disposal,
				"Trash"
			},
			{
				OBJD.SubRoom.Tubs,
				"Tubs"
			},
			{
				OBJD.SubRoom.TVs,
				"TVs"
			},
			{
				OBJD.SubRoom.PaintingsAndPostersForGrownUps,
				"Wall Art Adult"
			},
			{
				OBJD.SubRoom.PaintingsAndPostersForKids,
				"Wall Art Kids"
			},
			{
				OBJD.SubRoom.WallLamps,
				"Wall Lamps"
			},
			{
				OBJD.SubRoom.VideoGames,
				"Video Games"
			},
			{
				OBJD.SubRoom.CurtainsAndBlinds,
				"Window Decor"
			}
		};

		// Token: 0x0400041E RID: 1054
		public static readonly Dictionary<OBJD.Category, string> CategoryLabels = new Dictionary<OBJD.Category, string>
		{
			{
				OBJD.Category.Appliances,
				"Appliances"
			},
			{
				OBJD.Category.Kids,
				"Kids"
			},
			{
				OBJD.Category.Comfort,
				"Comfort"
			},
			{
				(OBJD.Category)2147483648U,
				"Default"
			},
			{
				OBJD.Category.Debug,
				"Debug"
			},
			{
				OBJD.Category.Decor,
				"Decor"
			},
			{
				OBJD.Category.Electronics,
				"Electronics"
			},
			{
				OBJD.Category.Entertainment,
				"Entertainment"
			},
			{
				OBJD.Category.Lighting,
				"Lighting"
			},
			{
				OBJD.Category.Plumbing,
				"Plumbing"
			},
			{
				OBJD.Category.Storage,
				"Storage"
			},
			{
				OBJD.Category.Surfaces,
				"Surfaces"
			},
			{
				OBJD.Category.Vehicles,
				"Vehicles"
			},
			{
				OBJD.Category.Pets,
				"Pets"
			},
			{
				OBJD.Category.Normal,
				"Normal"
			},
			{
				OBJD.Category.Showstage,
				"Showstage"
			},
			{
				OBJD.Category.Resort,
				"Resort"
			}
		};

		// Token: 0x0400041F RID: 1055
		public static readonly Dictionary<OBJD.SubCategory2, string> SubCategoryLabels2 = new Dictionary<OBJD.SubCategory2, string>
		{
			{
				OBJD.SubCategory2.FXAndLights,
				"FX And Lights"
			},
			{
				OBJD.SubCategory2.MiscellaneousShowStage,
				"Misc Showstage"
			},
			{
				OBJD.SubCategory2.Props,
				"Properties"
			},
			{
				OBJD.SubCategory2.UnderwaterObjects,
				"Underwater Objects"
			},
			{
				OBJD.SubCategory2.ResortMisc,
				"Misc Resort"
			},
			{
				OBJD.SubCategory2.Boats,
				"Boats"
			}
		};

		// Token: 0x04000420 RID: 1056
		public static readonly Dictionary<OBJD.SubCategory, string> SubCategoryLabels = new Dictionary<OBJD.SubCategory, string>
		{
			{
				OBJD.SubCategory.Audio,
				"Audio"
			},
			{
				OBJD.SubCategory.Beds,
				"Beds"
			},
			{
				OBJD.SubCategory.Bicycles,
				"Bicycles"
			},
			{
				OBJD.SubCategory.Bookshelves,
				"Bookshelves"
			},
			{
				OBJD.SubCategory.Cabinets,
				"Cabinets"
			},
			{
				OBJD.SubCategory.Cars,
				"Cars"
			},
			{
				OBJD.SubCategory.CeilingLights,
				"Ceiling Lights"
			},
			{
				OBJD.SubCategory.CoffeeTables,
				"Coffee Tables"
			},
			{
				OBJD.SubCategory.Computers,
				"Computers"
			},
			{
				OBJD.SubCategory.Counters,
				"Counters"
			},
			{
				OBJD.SubCategory.Default,
				"Default"
			},
			{
				OBJD.SubCategory.Desks,
				"Desks"
			},
			{
				OBJD.SubCategory.DiningChairs,
				"Dining Chairs"
			},
			{
				OBJD.SubCategory.DiningTables,
				"Dining Tables"
			},
			{
				OBJD.SubCategory.Dressers,
				"Dressers"
			},
			{
				OBJD.SubCategory.EndTables,
				"End Tables"
			},
			{
				OBJD.SubCategory.FloorLamps,
				"Floor Lamps"
			},
			{
				OBJD.SubCategory.Furniture,
				"Furniture"
			},
			{
				OBJD.SubCategory.HobbiesAndSkills,
				"Hobbies and Skills"
			},
			{
				OBJD.SubCategory.LargeAppliances,
				"Large Appliances"
			},
			{
				OBJD.SubCategory.LivingChairs,
				"Livingroom Chairs"
			},
			{
				OBJD.SubCategory.LoungeChairs,
				"Lounge Chairs"
			},
			{
				OBJD.SubCategory.Mirrors,
				"Mirrors"
			},
			{
				OBJD.SubCategory.MiscellaneousAppliances,
				"Miscellaneous Appliances"
			},
			{
				OBJD.SubCategory.MiscellaneousComfort,
				"Miscellaneous Comfort"
			},
			{
				OBJD.SubCategory.MiscellaneousDecor,
				"Miscellaneous Decor"
			},
			{
				OBJD.SubCategory.MiscellaneousElectronics,
				"Miscellaneous Electronics"
			},
			{
				OBJD.SubCategory.MiscellaneousEntertainment,
				"Miscellaneous Entertainment"
			},
			{
				OBJD.SubCategory.MiscellaneousKids,
				"Miscellaneous Kids"
			},
			{
				OBJD.SubCategory.MiscellaneousLighting,
				"Miscellaneous Lightning"
			},
			{
				OBJD.SubCategory.MiscellaneousPlumbing,
				"Miscellaneous Plumbing"
			},
			{
				OBJD.SubCategory.MiscellaneousStorage,
				"Miscellaneous Storage"
			},
			{
				OBJD.SubCategory.MiscellaneousSurfaces,
				"Miscellaneous Surfaces"
			},
			{
				OBJD.SubCategory.MiscellaneousVehicles,
				"Miscellaneous Vehicles"
			},
			{
				OBJD.SubCategory.OutdoorLights,
				"Outdoor Lights"
			},
			{
				OBJD.SubCategory.Parties,
				"Parties"
			},
			{
				OBJD.SubCategory.Plants,
				"Plants"
			},
			{
				OBJD.SubCategory.Rugs,
				"Rugs"
			},
			{
				OBJD.SubCategory.ShowersAndTubs,
				"Shower and Tubs"
			},
			{
				OBJD.SubCategory.Sinks,
				"Sinks"
			},
			{
				OBJD.SubCategory.SmallAppliances,
				"Small Appliances"
			},
			{
				OBJD.SubCategory.SofasAndLoveseats,
				"Sofas and loveseats"
			},
			{
				OBJD.SubCategory.SportingGoods,
				"Sporting goods"
			},
			{
				OBJD.SubCategory.TableLamps,
				"Table Lamps"
			},
			{
				OBJD.SubCategory.Toilets,
				"Toilets"
			},
			{
				OBJD.SubCategory.Toys,
				"Toys"
			},
			{
				OBJD.SubCategory.TVs,
				"TVs"
			},
			{
				OBJD.SubCategory.PaintingsAndPosters,
				"Paintings and posters"
			},
			{
				OBJD.SubCategory.WallLamps,
				"Wall Lamps"
			},
			{
				OBJD.SubCategory.CurtainsAndBlinds,
				"Curtains and blinds"
			},
			{
				OBJD.SubCategory.Miscellaneous,
				"Miscellaneous"
			},
			{
				OBJD.SubCategory.All,
				"All"
			},
			{
				OBJD.SubCategory.Cats,
				"Cats"
			},
			{
				OBJD.SubCategory.Dogs,
				"Dogs"
			},
			{
				OBJD.SubCategory.Horses,
				"Horses"
			},
			{
				OBJD.SubCategory.Sculptures,
				"Sculptures"
			}
		};

		// Token: 0x04000421 RID: 1057
		public static Dictionary<ushort, Dictionary<ushort, string>> ValueLookupTable;

		// Token: 0x0200018B RID: 395
		public enum FlagCategory
		{
			// Token: 0x04000B0E RID: 2830
			Mood = 64,
			// Token: 0x04000B0F RID: 2831
			Color,
			// Token: 0x04000B10 RID: 2832
			Style,
			// Token: 0x04000B11 RID: 2833
			Theme,
			// Token: 0x04000B12 RID: 2834
			AgeAppropriate,
			// Token: 0x04000B13 RID: 2835
			Archetype,
			// Token: 0x04000B14 RID: 2836
			OutfitCategory,
			// Token: 0x04000B15 RID: 2837
			Skill,
			// Token: 0x04000B16 RID: 2838
			EyeColor,
			// Token: 0x04000B17 RID: 2839
			Persona,
			// Token: 0x04000B18 RID: 2840
			Special,
			// Token: 0x04000B19 RID: 2841
			HairColor,
			// Token: 0x04000B1A RID: 2842
			ColorPalette,
			// Token: 0x04000B1B RID: 2843
			Hair,
			// Token: 0x04000B1C RID: 2844
			FacialHair,
			// Token: 0x04000B1D RID: 2845
			Hat,
			// Token: 0x04000B1E RID: 2846
			FaceMakeup,
			// Token: 0x04000B1F RID: 2847
			Top,
			// Token: 0x04000B20 RID: 2848
			Bottom,
			// Token: 0x04000B21 RID: 2849
			Body,
			// Token: 0x04000B22 RID: 2850
			Shoes,
			// Token: 0x04000B23 RID: 2851
			BottomAccessory,
			// Token: 0x04000B24 RID: 2852
			BuyCatEE,
			// Token: 0x04000B25 RID: 2853
			BuyCatPA,
			// Token: 0x04000B26 RID: 2854
			BuyCatLD,
			// Token: 0x04000B27 RID: 2855
			BuyCatSS,
			// Token: 0x04000B28 RID: 2856
			BuyCatVO,
			// Token: 0x04000B29 RID: 2857
			Uniform,
			// Token: 0x04000B2A RID: 2858
			Accessories,
			// Token: 0x04000B2B RID: 2859
			BuyCatMAG,
			// Token: 0x04000B2C RID: 2860
			FloorPattern,
			// Token: 0x04000B2D RID: 2861
			WallPattern,
			// Token: 0x04000B2E RID: 2862
			Fabric,
			// Token: 0x04000B2F RID: 2863
			Build,
			// Token: 0x04000B30 RID: 2864
			Pattern,
			// Token: 0x04000B31 RID: 2865
			HairLength,
			// Token: 0x04000B32 RID: 2866
			HairTexture,
			// Token: 0x04000B33 RID: 2867
			TraitGroup,
			// Token: 0x04000B34 RID: 2868
			SkinHue,
			// Token: 0x04000B35 RID: 2869
			Reward,
			// Token: 0x04000B36 RID: 2870
			TerrainPaint,
			// Token: 0x04000B37 RID: 2871
			EyebrowThickness,
			// Token: 0x04000B38 RID: 2872
			EyebrowShape
		}

		// Token: 0x0200018C RID: 396
		[Flags]
		public enum BuildBuyProductStatusFlags : byte
		{
			// Token: 0x04000B3A RID: 2874
			DebugProduct = 16,
			// Token: 0x04000B3B RID: 2875
			ObjProductMadeUsingNewEntryScheme = 64,
			// Token: 0x04000B3C RID: 2876
			ProductForTesting = 2,
			// Token: 0x04000B3D RID: 2877
			ProductInDevelopment = 4,
			// Token: 0x04000B3E RID: 2878
			ProductionProduct = 32,
			// Token: 0x04000B3F RID: 2879
			ShippingProduct = 8,
			// Token: 0x04000B40 RID: 2880
			ShowInCatalog = 1
		}

		// Token: 0x0200018D RID: 397
		[Flags]
		public enum Category : uint
		{
			// Token: 0x04000B42 RID: 2882
			Appliances = 2U,
			// Token: 0x04000B43 RID: 2883
			Comfort = 2048U,
			// Token: 0x04000B44 RID: 2884
			Debug = 1073741824U,
			// Token: 0x04000B45 RID: 2885
			Decor = 128U,
			// Token: 0x04000B46 RID: 2886
			Default = 2147483648U,
			// Token: 0x04000B47 RID: 2887
			Electronics = 4U,
			// Token: 0x04000B48 RID: 2888
			Entertainment = 8U,
			// Token: 0x04000B49 RID: 2889
			Kids = 256U,
			// Token: 0x04000B4A RID: 2890
			Lighting = 32U,
			// Token: 0x04000B4B RID: 2891
			Normal = 1073741823U,
			// Token: 0x04000B4C RID: 2892
			Pets = 16384U,
			// Token: 0x04000B4D RID: 2893
			Plumbing = 64U,
			// Token: 0x04000B4E RID: 2894
			Storage = 512U,
			// Token: 0x04000B4F RID: 2895
			Surfaces = 4096U,
			// Token: 0x04000B50 RID: 2896
			Vehicles = 8192U,
			// Token: 0x04000B51 RID: 2897
			Showstage = 32768U,
			// Token: 0x04000B52 RID: 2898
			Resort = 65536U
		}

		// Token: 0x0200018E RID: 398
		[Flags]
		public enum SubCategory2 : ulong
		{
			// Token: 0x04000B54 RID: 2900
			FXAndLights = 2UL,
			// Token: 0x04000B55 RID: 2901
			Props = 4UL,
			// Token: 0x04000B56 RID: 2902
			MiscellaneousShowStage = 8UL,
			// Token: 0x04000B57 RID: 2903
			UnderwaterObjects = 16UL,
			// Token: 0x04000B58 RID: 2904
			ResortMisc = 32UL,
			// Token: 0x04000B59 RID: 2905
			Boats = 64UL
		}

		// Token: 0x0200018F RID: 399
		[Flags]
		public enum SubCategory : ulong
		{
			// Token: 0x04000B5B RID: 2907
			All = 18446744073709551615UL,
			// Token: 0x04000B5C RID: 2908
			Audio = 1024UL,
			// Token: 0x04000B5D RID: 2909
			Beds = 4398046511104UL,
			// Token: 0x04000B5E RID: 2910
			Bicycles = 4503599627370496UL,
			// Token: 0x04000B5F RID: 2911
			Bookshelves = 34359738368UL,
			// Token: 0x04000B60 RID: 2912
			Cabinets = 9007199254740992UL,
			// Token: 0x04000B61 RID: 2913
			Cars = 2251799813685248UL,
			// Token: 0x04000B62 RID: 2914
			Cats = 4611686018427387904UL,
			// Token: 0x04000B63 RID: 2915
			CeilingLights = 524288UL,
			// Token: 0x04000B64 RID: 2916
			CoffeeTables = 17592186044416UL,
			// Token: 0x04000B65 RID: 2917
			Computers = 2048UL,
			// Token: 0x04000B66 RID: 2918
			Counters = 35184372088832UL,
			// Token: 0x04000B67 RID: 2919
			CurtainsAndBlinds = 18014398509481984UL,
			// Token: 0x04000B68 RID: 2920
			Debug = 8796093022208UL,
			// Token: 0x04000B69 RID: 2921
			Default = 9223372036854775808UL,
			// Token: 0x04000B6A RID: 2922
			Desks = 70368744177664UL,
			// Token: 0x04000B6B RID: 2923
			DiningChairs = 274877906944UL,
			// Token: 0x04000B6C RID: 2924
			DiningTables = 281474976710656UL,
			// Token: 0x04000B6D RID: 2925
			Displays = 68719476736UL,
			// Token: 0x04000B6E RID: 2926
			Dogs = 8589934592UL,
			// Token: 0x04000B6F RID: 2927
			Dressers = 137438953472UL,
			// Token: 0x04000B70 RID: 2928
			EndTables = 140737488355328UL,
			// Token: 0x04000B71 RID: 2929
			FishSpawners = 32UL,
			// Token: 0x04000B72 RID: 2930
			FloorLamps = 1048576UL,
			// Token: 0x04000B73 RID: 2931
			Furniture = 562949953421312UL,
			// Token: 0x04000B74 RID: 2932
			HobbiesAndSkills = 4096UL,
			// Token: 0x04000B75 RID: 2933
			Horses = 32768UL,
			// Token: 0x04000B76 RID: 2934
			InsectSpawners = 65536UL,
			// Token: 0x04000B77 RID: 2935
			LargeAppliances = 8UL,
			// Token: 0x04000B78 RID: 2936
			LivingChairs = 16384UL,
			// Token: 0x04000B79 RID: 2937
			LoungeChairs = 16777216UL,
			// Token: 0x04000B7A RID: 2938
			Mirrors = 4294967296UL,
			// Token: 0x04000B7B RID: 2939
			Miscellaneous = 2269815311975055618UL,
			// Token: 0x04000B7C RID: 2940
			MiscellaneousAppliances = 2UL,
			// Token: 0x04000B7D RID: 2941
			MiscellaneousComfort = 1099511627776UL,
			// Token: 0x04000B7E RID: 2942
			MiscellaneousDecor = 268435456UL,
			// Token: 0x04000B7F RID: 2943
			MiscellaneousElectronics = 256UL,
			// Token: 0x04000B80 RID: 2944
			MiscellaneousEntertainment = 262144UL,
			// Token: 0x04000B81 RID: 2945
			MiscellaneousKids = 36028797018963968UL,
			// Token: 0x04000B82 RID: 2946
			MiscellaneousLighting = 72057594037927936UL,
			// Token: 0x04000B83 RID: 2947
			MiscellaneousPlumbing = 144115188075855872UL,
			// Token: 0x04000B84 RID: 2948
			MiscellaneousStorage = 288230376151711744UL,
			// Token: 0x04000B85 RID: 2949
			MiscellaneousSurfaces = 576460752303423488UL,
			// Token: 0x04000B86 RID: 2950
			MiscellaneousVehicles = 1152921504606846976UL,
			// Token: 0x04000B87 RID: 2951
			MiscObjects = 17179869184UL,
			// Token: 0x04000B88 RID: 2952
			OutdoorLights = 8388608UL,
			// Token: 0x04000B89 RID: 2953
			PaintingsAndPosters = 1073741824UL,
			// Token: 0x04000B8A RID: 2954
			Parties = 131072UL,
			// Token: 0x04000B8B RID: 2955
			Plants = 2147483648UL,
			// Token: 0x04000B8C RID: 2956
			PlantsAndSeedSpawners = 64UL,
			// Token: 0x04000B8D RID: 2957
			RockGemMetalSpawners = 512UL,
			// Token: 0x04000B8E RID: 2958
			RoofDecorations = 2199023255552UL,
			// Token: 0x04000B8F RID: 2959
			Rugs = 2305843009213693952UL,
			// Token: 0x04000B90 RID: 2960
			Sculptures = 536870912UL,
			// Token: 0x04000B91 RID: 2961
			ShowersAndTubs = 134217728UL,
			// Token: 0x04000B92 RID: 2962
			Sinks = 33554432UL,
			// Token: 0x04000B93 RID: 2963
			SmallAppliances = 4UL,
			// Token: 0x04000B94 RID: 2964
			SofasAndLoveseats = 549755813888UL,
			// Token: 0x04000B95 RID: 2965
			SportingGoods = 8192UL,
			// Token: 0x04000B96 RID: 2966
			TableLamps = 2097152UL,
			// Token: 0x04000B97 RID: 2967
			Toilets = 67108864UL,
			// Token: 0x04000B98 RID: 2968
			TombObjects = 16UL,
			// Token: 0x04000B99 RID: 2969
			Toys = 1125899906842624UL,
			// Token: 0x04000B9A RID: 2970
			TVs = 128UL,
			// Token: 0x04000B9B RID: 2971
			WallLamps = 4194304UL
		}

		// Token: 0x02000190 RID: 400
		[Flags]
		public enum MovementFlags : uint
		{
			// Token: 0x04000B9D RID: 2973
			StaysAfterEvict = 2U,
			// Token: 0x04000B9E RID: 2974
			HandToolCannotMoveIt = 4U,
			// Token: 0x04000B9F RID: 2975
			HandToolCannotDeleteIt = 8U,
			// Token: 0x04000BA0 RID: 2976
			HandToolCannotDuplicateIt = 16U,
			// Token: 0x04000BA1 RID: 2977
			HandToolCanDuplicateWhenHiddenInCatalog = 32U,
			// Token: 0x04000BA2 RID: 2978
			HandToolSkipRecursivePickupTests = 64U,
			// Token: 0x04000BA3 RID: 2979
			GhostsCannotFloatThrough = 128U
		}

		// Token: 0x02000191 RID: 401
		[Flags]
		public enum WallPlacementFlags : uint
		{
			// Token: 0x04000BA5 RID: 2981
			WF00To11Diag = 32U,
			// Token: 0x04000BA6 RID: 2982
			WF01To10Diag = 16U,
			// Token: 0x04000BA7 RID: 2983
			WFAnywhere = 0U,
			// Token: 0x04000BA8 RID: 2984
			WFApplyCutoutDiagonalShift = 65536U,
			// Token: 0x04000BA9 RID: 2985
			WFCanBeMovedUpDownOnWall = 131072U,
			// Token: 0x04000BAA RID: 2986
			WFCannotBeMovedUpDownOnWall = 262144U,
			// Token: 0x04000BAB RID: 2987
			WFFlagsApplyToFences = 4096U,
			// Token: 0x04000BAC RID: 2988
			WFIntersectsObjectsOffWall = 32768U,
			// Token: 0x04000BAD RID: 2989
			WFMaxX = 4U,
			// Token: 0x04000BAE RID: 2990
			WFMaxZ = 8U,
			// Token: 0x04000BAF RID: 2991
			WFMinX = 1U,
			// Token: 0x04000BB0 RID: 2992
			WFMinZ = 2U,
			// Token: 0x04000BB1 RID: 2993
			WFNot00To11Diag = 2048U,
			// Token: 0x04000BB2 RID: 2994
			WFNot01To10Diag = 1024U,
			// Token: 0x04000BB3 RID: 2995
			WFNotMaxX = 256U,
			// Token: 0x04000BB4 RID: 2996
			WFNotMaxZ = 512U,
			// Token: 0x04000BB5 RID: 2997
			WFNotMinX = 64U,
			// Token: 0x04000BB6 RID: 2998
			WFNotMinZ = 128U,
			// Token: 0x04000BB7 RID: 2999
			WFNotRequiredMask = 4032U,
			// Token: 0x04000BB8 RID: 3000
			WFOnWall = 16384U,
			// Token: 0x04000BB9 RID: 3001
			WFProhibitsFenceArch = 8192U,
			// Token: 0x04000BBA RID: 3002
			WFRequiredMask = 63U
		}

		// Token: 0x02000192 RID: 402
		[Flags]
		public enum ObjectTypeFlags2 : uint
		{
			// Token: 0x04000BBC RID: 3004
			SpiralStaircase = 1U,
			// Token: 0x04000BBD RID: 3005
			CantBePlacedOnDeckOrFoundation = 2U,
			// Token: 0x04000BBE RID: 3006
			PetCannotSitUnder = 4U,
			// Token: 0x04000BBF RID: 3007
			PetsCannotJumpOn = 8U,
			// Token: 0x04000BC0 RID: 3008
			LargeAnimalsCannotUse = 16U,
			// Token: 0x04000BC1 RID: 3009
			MustFaceCardinalDirection = 32U,
			// Token: 0x04000BC2 RID: 3010
			IsRug = 64U,
			// Token: 0x04000BC3 RID: 3011
			IsGiftable = 128U,
			// Token: 0x04000BC4 RID: 3012
			ForceVisibleInSnowXRay = 256U,
			// Token: 0x04000BC5 RID: 3013
			DisableVisibleInSnowXRay = 512U,
			// Token: 0x04000BC6 RID: 3014
			ForceVisibleInBlueprint = 1024U,
			// Token: 0x04000BC7 RID: 3015
			NotVisibleInBlueprint = 2048U,
			// Token: 0x04000BC8 RID: 3016
			BlockSnowUnderObjects = 4096U
		}

		// Token: 0x02000193 RID: 403
		[Flags]
		public enum ObjectTypeFlags : uint
		{
			// Token: 0x04000BCA RID: 3018
			AutomaticallyBuyAnotherAfterPlacing = 2U,
			// Token: 0x04000BCB RID: 3019
			HidesFloorOnPlacement = 4U,
			// Token: 0x04000BCC RID: 3020
			IsDoor = 8U,
			// Token: 0x04000BCD RID: 3021
			IsWindow = 16U,
			// Token: 0x04000BCE RID: 3022
			IsGate = 32U,
			// Token: 0x04000BCF RID: 3023
			HideWhenWallDown = 64U,
			// Token: 0x04000BD0 RID: 3024
			RabbitHole = 128U,
			// Token: 0x04000BD1 RID: 3025
			IsDiagonal = 256U,
			// Token: 0x04000BD2 RID: 3026
			ForceToFullGrid = 512U,
			// Token: 0x04000BD3 RID: 3027
			RequireFloorAboveIfOutside = 1024U,
			// Token: 0x04000BD4 RID: 3028
			IsFireplace = 2048U,
			// Token: 0x04000BD5 RID: 3029
			IsChimney = 4096U,
			// Token: 0x04000BD6 RID: 3030
			IsFlora = 8192U,
			// Token: 0x04000BD7 RID: 3031
			IsColumn = 16384U,
			// Token: 0x04000BD8 RID: 3032
			TakeParentAlongWhenPicked = 32768U,
			// Token: 0x04000BD9 RID: 3033
			LiveDraggingEnabled = 65536U,
			// Token: 0x04000BDA RID: 3034
			AllowOnSlope = 131072U,
			// Token: 0x04000BDB RID: 3035
			LargeObject = 262144U,
			// Token: 0x04000BDC RID: 3036
			FloatsOnWater = 524288U,
			// Token: 0x04000BDD RID: 3037
			IsGarageDoor = 1048576U,
			// Token: 0x04000BDE RID: 3038
			IsMailbox = 2097152U,
			// Token: 0x04000BDF RID: 3039
			IgnorePatternSound = 4194304U,
			// Token: 0x04000BE0 RID: 3040
			IsRoadBridge = 8388608U,
			// Token: 0x04000BE1 RID: 3041
			AllowWallObjectOnGround = 16777216U,
			// Token: 0x04000BE2 RID: 3042
			HasFloorCutout = 33554432U,
			// Token: 0x04000BE3 RID: 3043
			BuildableShell = 67108864U,
			// Token: 0x04000BE4 RID: 3044
			ElevationFromCeiling = 83886080U,
			// Token: 0x04000BE5 RID: 3045
			CanDepressTerrain = 268435456U,
			// Token: 0x04000BE6 RID: 3046
			IgnorePlatformElevation = 536870912U,
			// Token: 0x04000BE7 RID: 3047
			CantBePlacedOnPlatform = 1073741824U,
			// Token: 0x04000BE8 RID: 3048
			IsShellDoor = 2147483648U
		}

		// Token: 0x02000194 RID: 404
		[Flags]
		public enum Room : uint
		{
			// Token: 0x04000BEA RID: 3050
			All = 4294967295U,
			// Token: 0x04000BEB RID: 3051
			Default = 2147483648U,
			// Token: 0x04000BEC RID: 3052
			DiningRoom = 4U,
			// Token: 0x04000BED RID: 3053
			LivingRoom = 2U,
			// Token: 0x04000BEE RID: 3054
			Kitchen = 8U,
			// Token: 0x04000BEF RID: 3055
			KidsRoom = 16U,
			// Token: 0x04000BF0 RID: 3056
			Bathroom = 32U,
			// Token: 0x04000BF1 RID: 3057
			BedRoom = 64U,
			// Token: 0x04000BF2 RID: 3058
			Study = 128U,
			// Token: 0x04000BF3 RID: 3059
			Outdoor = 256U,
			// Token: 0x04000BF4 RID: 3060
			CommunityLot = 512U,
			// Token: 0x04000BF5 RID: 3061
			ResidentialLot = 1024U,
			// Token: 0x04000BF6 RID: 3062
			Pool = 2048U,
			// Token: 0x04000BF7 RID: 3063
			Fountain = 4096U,
			// Token: 0x04000BF8 RID: 3064
			ResortLobby = 8192U,
			// Token: 0x04000BF9 RID: 3065
			ResortSpa = 16384U,
			// Token: 0x04000BFA RID: 3066
			ResortGym = 32768U,
			// Token: 0x04000BFB RID: 3067
			ResortRestaurant = 65536U,
			// Token: 0x04000BFC RID: 3068
			ResortTikiLounge = 131072U,
			// Token: 0x04000BFD RID: 3069
			ResortArcade = 262144U,
			// Token: 0x04000BFE RID: 3070
			ResortArtGallery = 524288U,
			// Token: 0x04000BFF RID: 3071
			ResortDanceHall = 1048576U,
			// Token: 0x04000C00 RID: 3072
			ResortOutdoorPartyArea = 2097152U,
			// Token: 0x04000C01 RID: 3073
			ResortPoolArea = 4194304U
		}

		// Token: 0x02000195 RID: 405
		[Flags]
		public enum SubRoom : ulong
		{
			// Token: 0x04000C03 RID: 3075
			Accents = 268435456UL,
			// Token: 0x04000C04 RID: 3076
			Alarms = 32UL,
			// Token: 0x04000C05 RID: 3077
			All = 18446744073709551615UL,
			// Token: 0x04000C06 RID: 3078
			Audio = 1024UL,
			// Token: 0x04000C07 RID: 3079
			Bars = 4503599627370496UL,
			// Token: 0x04000C08 RID: 3080
			BarStools = 8796093022208UL,
			// Token: 0x04000C09 RID: 3081
			Beds = 4398046511104UL,
			// Token: 0x04000C0A RID: 3082
			Bookshelves = 34359738368UL,
			// Token: 0x04000C0B RID: 3083
			Cabinets = 68719476736UL,
			// Token: 0x04000C0C RID: 3084
			CeilingLights = 524288UL,
			// Token: 0x04000C0D RID: 3085
			Clocks = 9007199254740992UL,
			// Token: 0x04000C0E RID: 3086
			CoffeeTables = 17592186044416UL,
			// Token: 0x04000C0F RID: 3087
			Computers = 2048UL,
			// Token: 0x04000C10 RID: 3088
			Counters = 35184372088832UL,
			// Token: 0x04000C11 RID: 3089
			CurtainsAndBlinds = 18014398509481984UL,
			// Token: 0x04000C12 RID: 3090
			Default = 9223372036854775808UL,
			// Token: 0x04000C13 RID: 3091
			Desks = 70368744177664UL,
			// Token: 0x04000C14 RID: 3092
			DiningChairs = 274877906944UL,
			// Token: 0x04000C15 RID: 3093
			DiningTables = 281474976710656UL,
			// Token: 0x04000C16 RID: 3094
			Dishwashers = 2UL,
			// Token: 0x04000C17 RID: 3095
			Disposal = 16UL,
			// Token: 0x04000C18 RID: 3096
			Dressers = 137438953472UL,
			// Token: 0x04000C19 RID: 3097
			EatingOut = 131072UL,
			// Token: 0x04000C1A RID: 3098
			EndTables = 140737488355328UL,
			// Token: 0x04000C1B RID: 3099
			FloorLamps = 1048576UL,
			// Token: 0x04000C1C RID: 3100
			Furniture = 562949953421312UL,
			// Token: 0x04000C1D RID: 3101
			HobbiesAndSkills = 4096UL,
			// Token: 0x04000C1E RID: 3102
			IndoorActivities = 8192UL,
			// Token: 0x04000C1F RID: 3103
			KidsDecor = 36028797018963968UL,
			// Token: 0x04000C20 RID: 3104
			Laundry = 288230376151711744UL,
			// Token: 0x04000C21 RID: 3105
			LawnOrnaments = 536870912UL,
			// Token: 0x04000C22 RID: 3106
			LivingChairs = 16384UL,
			// Token: 0x04000C23 RID: 3107
			Mirrors = 4294967296UL,
			// Token: 0x04000C24 RID: 3108
			MiscellaneousDecor = 72057594037927936UL,
			// Token: 0x04000C25 RID: 3109
			OfficeChairs = 32768UL,
			// Token: 0x04000C26 RID: 3110
			OutdoorActivities = 262144UL,
			// Token: 0x04000C27 RID: 3111
			OutdoorLights = 8388608UL,
			// Token: 0x04000C28 RID: 3112
			OutdoorSeating = 1099511627776UL,
			// Token: 0x04000C29 RID: 3113
			PaintingsAndPostersForGrownUps = 1073741824UL,
			// Token: 0x04000C2A RID: 3114
			PaintingsAndPostersForKids = 17179869184UL,
			// Token: 0x04000C2B RID: 3115
			Pets = 576460752303423488UL,
			// Token: 0x04000C2C RID: 3116
			Phones = 64UL,
			// Token: 0x04000C2D RID: 3117
			Plants = 2147483648UL,
			// Token: 0x04000C2E RID: 3118
			Refrigerators = 8UL,
			// Token: 0x04000C2F RID: 3119
			RoofDecorations = 2199023255552UL,
			// Token: 0x04000C30 RID: 3120
			Rugs = 144115188075855872UL,
			// Token: 0x04000C31 RID: 3121
			Showers = 16777216UL,
			// Token: 0x04000C32 RID: 3122
			Sinks = 33554432UL,
			// Token: 0x04000C33 RID: 3123
			SmallAppliances = 4UL,
			// Token: 0x04000C34 RID: 3124
			SmokeAlarms = 256UL,
			// Token: 0x04000C35 RID: 3125
			SofasAndLoveseats = 549755813888UL,
			// Token: 0x04000C36 RID: 3126
			Stoves = 65536UL,
			// Token: 0x04000C37 RID: 3127
			TableLamps = 2097152UL,
			// Token: 0x04000C38 RID: 3128
			Toilets = 67108864UL,
			// Token: 0x04000C39 RID: 3129
			Toys = 1125899906842624UL,
			// Token: 0x04000C3A RID: 3130
			Transportation = 2251799813685248UL,
			// Token: 0x04000C3B RID: 3131
			Tubs = 134217728UL,
			// Token: 0x04000C3C RID: 3132
			TVs = 128UL,
			// Token: 0x04000C3D RID: 3133
			WallLamps = 4194304UL,
			// Token: 0x04000C3E RID: 3134
			VideoGames = 8589934592UL
		}

		// Token: 0x02000196 RID: 406
		[Flags]
		public enum Build : uint
		{
			// Token: 0x04000C40 RID: 3136
			All = 4294967295U,
			// Token: 0x04000C41 RID: 3137
			Arch = 256U,
			// Token: 0x04000C42 RID: 3138
			Chimney = 128U,
			// Token: 0x04000C43 RID: 3139
			Column = 16U,
			// Token: 0x04000C44 RID: 3140
			Default = 2147483648U,
			// Token: 0x04000C45 RID: 3141
			Door = 2U,
			// Token: 0x04000C46 RID: 3142
			Elevator = 65536U,
			// Token: 0x04000C47 RID: 3143
			Fireplace = 64U,
			// Token: 0x04000C48 RID: 3144
			Flower = 512U,
			// Token: 0x04000C49 RID: 3145
			Gate = 8U,
			// Token: 0x04000C4A RID: 3146
			MiscObject = 32768U,
			// Token: 0x04000C4B RID: 3147
			RabbitHole = 32U,
			// Token: 0x04000C4C RID: 3148
			Rock = 8192U,
			// Token: 0x04000C4D RID: 3149
			Rug = 4096U,
			// Token: 0x04000C4E RID: 3150
			Shell = 16384U,
			// Token: 0x04000C4F RID: 3151
			Shrub = 1024U,
			// Token: 0x04000C50 RID: 3152
			SpiralStairscase = 131072U,
			// Token: 0x04000C51 RID: 3153
			Tree = 2048U,
			// Token: 0x04000C52 RID: 3154
			Window = 4U,
			// Token: 0x04000C53 RID: 3155
			BluePrint = 268435456U,
			// Token: 0x04000C54 RID: 3156
			ResortObjects = 536870912U,
			// Token: 0x04000C55 RID: 3157
			ModularArch = 1073741824U
		}

		// Token: 0x02000197 RID: 407
		[Flags]
		public enum SlotPlacementFlags : uint
		{
			// Token: 0x04000C57 RID: 3159
			None = 1U,
			// Token: 0x04000C58 RID: 3160
			flag_2 = 2U,
			// Token: 0x04000C59 RID: 3161
			flag_4 = 4U,
			// Token: 0x04000C5A RID: 3162
			Small = 8U,
			// Token: 0x04000C5B RID: 3163
			Medium = 16U,
			// Token: 0x04000C5C RID: 3164
			Large = 32U,
			// Token: 0x04000C5D RID: 3165
			flag_40 = 64U,
			// Token: 0x04000C5E RID: 3166
			flag_80 = 128U,
			// Token: 0x04000C5F RID: 3167
			Sim = 256U,
			// Token: 0x04000C60 RID: 3168
			Chair = 512U,
			// Token: 0x04000C61 RID: 3169
			CounterSink = 1024U,
			// Token: 0x04000C62 RID: 3170
			EndTable = 2048U,
			// Token: 0x04000C63 RID: 3171
			Stool = 4096U,
			// Token: 0x04000C64 RID: 3172
			CounterAppliance = 8192U,
			// Token: 0x04000C65 RID: 3173
			flag_4000 = 16384U,
			// Token: 0x04000C66 RID: 3174
			flag_8000 = 32768U,
			// Token: 0x04000C67 RID: 3175
			flag_10000 = 65536U,
			// Token: 0x04000C68 RID: 3176
			flag_20000 = 131072U,
			// Token: 0x04000C69 RID: 3177
			Functional = 262144U,
			// Token: 0x04000C6A RID: 3178
			Decorative = 524288U,
			// Token: 0x04000C6B RID: 3179
			Upgrade = 16777216U,
			// Token: 0x04000C6C RID: 3180
			Vertical = 33554432U,
			// Token: 0x04000C6D RID: 3181
			PlacementOnly = 67108864U,
			// Token: 0x04000C6E RID: 3182
			flag_8000000 = 134217728U,
			// Token: 0x04000C6F RID: 3183
			CardinalRotation = 268435456U,
			// Token: 0x04000C70 RID: 3184
			FullRotation = 536870912U,
			// Token: 0x04000C71 RID: 3185
			AlwaysUp = 1073741824U,
			// Token: 0x04000C72 RID: 3186
			flag_80000000 = 2147483648U
		}
	}
}
