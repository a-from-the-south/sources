using System;
using System.Collections.Generic;
using System.IO;

namespace Package.SharedFiles
{
	// Token: 0x020000A9 RID: 169
	public abstract class CASP : DBPFEntry, ICasp
	{
		// Token: 0x170002BF RID: 703
		// (get) Token: 0x06000841 RID: 2113
		// (set) Token: 0x06000842 RID: 2114
		public abstract uint ageFlags { get; set; }

		// Token: 0x170002C0 RID: 704
		// (get) Token: 0x06000843 RID: 2115
		// (set) Token: 0x06000844 RID: 2116
		public abstract uint clothingCategoryFlags { get; set; }

		// Token: 0x170002C1 RID: 705
		// (get) Token: 0x06000845 RID: 2117
		// (set) Token: 0x06000846 RID: 2118
		public abstract uint typeFlags { get; set; }

		// Token: 0x170002C2 RID: 706
		// (get) Token: 0x06000847 RID: 2119
		// (set) Token: 0x06000848 RID: 2120
		public abstract uint version { get; set; }

		// Token: 0x170002C3 RID: 707
		// (get) Token: 0x06000849 RID: 2121
		// (set) Token: 0x0600084A RID: 2122
		public abstract string str1 { get; set; }

		// Token: 0x0600084B RID: 2123
		public abstract List<CASP.AgeGender> GetAges();

		// Token: 0x0600084C RID: 2124
		public abstract List<CASP.AgeGender> GetGendres();

		// Token: 0x0600084D RID: 2125
		public abstract List<CASP.Species> GetSpecies();

		// Token: 0x0600084E RID: 2126
		public abstract List<CASP.Type> GetTypes();

		// Token: 0x0600084F RID: 2127
		public abstract List<uint> GetCategories();

		// Token: 0x06000850 RID: 2128 RVA: 0x00003C7E File Offset: 0x00001E7E
		public CASP()
		{
		}

		// Token: 0x170002C4 RID: 708
		// (get) Token: 0x06000851 RID: 2129 RVA: 0x00006F0E File Offset: 0x0000510E
		public static Dictionary<ushort, Dictionary<uint, string>> ValueLookupTable
		{
			get
			{
				if (CASP.lookupTable == null)
				{
					CASP.SetupValues();
				}
				return CASP.lookupTable;
			}
		}

		// Token: 0x06000852 RID: 2130 RVA: 0x00026A58 File Offset: 0x00024C58
		public static List<KeyValuePair<CASP.Sims4Flag.FlagValue, string>> GetBuildFlags()
		{
			if (CASP._buildFlags != null)
			{
				return CASP._buildFlags;
			}
			CASP._buildFlags = new List<KeyValuePair<CASP.Sims4Flag.FlagValue, string>>();
			foreach (object obj in Enum.GetValues(typeof(CASP.Sims4Flag.FlagValue)))
			{
				string name = Enum.GetName(typeof(CASP.Sims4Flag.FlagValue), obj);
				if (name.StartsWith("Build_"))
				{
					KeyValuePair<CASP.Sims4Flag.FlagValue, string> item = new KeyValuePair<CASP.Sims4Flag.FlagValue, string>((CASP.Sims4Flag.FlagValue)obj, name);
					CASP._buildFlags.Add(item);
				}
			}
			return CASP._buildFlags;
		}

		// Token: 0x06000853 RID: 2131 RVA: 0x00026B08 File Offset: 0x00024D08
		public static List<KeyValuePair<CASP.Sims4Flag.FlagValue, string>> GetRoomFlags()
		{
			if (CASP._roomFlags != null)
			{
				return CASP._roomFlags;
			}
			CASP._roomFlags = new List<KeyValuePair<CASP.Sims4Flag.FlagValue, string>>();
			foreach (object obj in Enum.GetValues(typeof(CASP.Sims4Flag.FlagValue)))
			{
				string name = Enum.GetName(typeof(CASP.Sims4Flag.FlagValue), obj);
				if (name.StartsWith("BuyCatMAG_"))
				{
					KeyValuePair<CASP.Sims4Flag.FlagValue, string> item = new KeyValuePair<CASP.Sims4Flag.FlagValue, string>((CASP.Sims4Flag.FlagValue)obj, name);
					CASP._roomFlags.Add(item);
				}
			}
			return CASP._roomFlags;
		}

		// Token: 0x06000854 RID: 2132 RVA: 0x00026BB8 File Offset: 0x00024DB8
		private static void SetupValues()
		{
			CASP.lookupTable = new Dictionary<ushort, Dictionary<uint, string>>();
			Dictionary<ushort, Dictionary<uint, string>> dictionary = new Dictionary<ushort, Dictionary<uint, string>>();
			foreach (object obj in Enum.GetValues(typeof(CASP.Sims4Flag.FlagValue)))
			{
				string name = Enum.GetName(typeof(CASP.Sims4Flag.FlagValue), obj);
				foreach (object obj2 in Enum.GetValues(typeof(CASP.Sims4Flag.FlagCategory)))
				{
					string name2 = Enum.GetName(typeof(CASP.Sims4Flag.FlagCategory), obj2);
					if (name.StartsWith(name2 + "_"))
					{
						try
						{
							if (!dictionary.ContainsKey((ushort)obj2))
							{
								dictionary.Add((ushort)obj2, new Dictionary<uint, string>());
							}
							dictionary[(ushort)obj2].Add((uint)obj, name.Replace(name2 + "_", ""));
						}
						catch (Exception)
						{
						}
					}
				}
			}
			List<object[]> list = new List<object[]>();
			foreach (ushort num in dictionary.Keys)
			{
				string name3 = Enum.GetName(typeof(CASP.Sims4Flag.FlagCategory), num);
				list.Add(new object[]
				{
					name3,
					num
				});
			}
			list.Sort(delegate(object[] a, object[] b)
			{
				string text = (string)a[0];
				string text2 = (string)b[0];
				return text.ToLower().CompareTo(text2.ToLower());
			});
			foreach (object[] array in list)
			{
				ushort key = (ushort)array[1];
				List<KeyValuePair<uint, string>> list2 = new List<KeyValuePair<uint, string>>();
				Dictionary<uint, string> dictionary2 = new Dictionary<uint, string>();
				foreach (KeyValuePair<uint, string> item in dictionary[key])
				{
					list2.Add(item);
				}
				list2.Sort((KeyValuePair<uint, string> a, KeyValuePair<uint, string> b) => a.Value.ToLower().CompareTo(b.Value.ToLower()));
				foreach (KeyValuePair<uint, string> keyValuePair in list2)
				{
					dictionary2.Add(keyValuePair.Key, keyValuePair.Value);
				}
				CASP.lookupTable.Add(key, dictionary2);
			}
		}

		// Token: 0x04000413 RID: 1043
		public static readonly Dictionary<CASP.AgeGender, string> AgeGenderLabels = new Dictionary<CASP.AgeGender, string>
		{
			{
				CASP.AgeGender.Baby,
				"Baby"
			},
			{
				CASP.AgeGender.Toddler,
				"Toddler"
			},
			{
				CASP.AgeGender.Child,
				"Child"
			},
			{
				CASP.AgeGender.Teen,
				"Teen"
			},
			{
				CASP.AgeGender.YoungAdult,
				"Young Adult"
			},
			{
				CASP.AgeGender.Adult,
				"Adult"
			},
			{
				CASP.AgeGender.Elder,
				"Elder"
			},
			{
				CASP.AgeGender.Male,
				"Male"
			},
			{
				CASP.AgeGender.Female,
				"Female"
			}
		};

		// Token: 0x04000414 RID: 1044
		public static readonly Dictionary<CASP.Species, string> SpeciesLabels = new Dictionary<CASP.Species, string>
		{
			{
				CASP.Species.Cat,
				"Cat"
			},
			{
				CASP.Species.Deer,
				"Deer"
			},
			{
				CASP.Species.Dog,
				"Dog"
			},
			{
				CASP.Species.Horse,
				"Horse"
			},
			{
				CASP.Species.Human,
				"Human"
			},
			{
				CASP.Species.LargeBird,
				"Large bird"
			},
			{
				CASP.Species.LittleDog,
				"Little dog"
			},
			{
				CASP.Species.Raccoon,
				"Raccoon"
			},
			{
				CASP.Species.SimLeadingHorse,
				"Sim leading horse"
			},
			{
				CASP.Species.SimWalkingDog,
				"Sim walking dog"
			},
			{
				CASP.Species.SimWalkingLittleDog,
				"Sim walking little dog"
			}
		};

		// Token: 0x04000415 RID: 1045
		public static readonly Dictionary<CASP.ClothingCategory, string> CategoryLabels = new Dictionary<CASP.ClothingCategory, string>
		{
			{
				CASP.ClothingCategory.None,
				"None"
			},
			{
				CASP.ClothingCategory.Naked,
				"Naked"
			},
			{
				CASP.ClothingCategory.Everyday,
				"Everyday"
			},
			{
				CASP.ClothingCategory.Formalwear,
				"Formal"
			},
			{
				CASP.ClothingCategory.Sleepwear,
				"Sleepwear"
			},
			{
				CASP.ClothingCategory.Swimwear,
				"Swimwear"
			},
			{
				CASP.ClothingCategory.Athletic,
				"Athletic"
			},
			{
				CASP.ClothingCategory.Singed,
				"Singed?"
			},
			{
				CASP.ClothingCategory.Career,
				"Career"
			},
			{
				CASP.ClothingCategory.IsHat,
				"Is Hat"
			},
			{
				CASP.ClothingCategory.Bridle,
				"Bridle"
			},
			{
				CASP.ClothingCategory.ChildImagination,
				"Child Imagination"
			},
			{
				CASP.ClothingCategory.Jumping,
				"Jumping"
			},
			{
				CASP.ClothingCategory.MartialArts,
				"Martial Arts"
			},
			{
				CASP.ClothingCategory.FireFighting,
				"Firefighting"
			},
			{
				CASP.ClothingCategory.Outerwear,
				"Outerwear"
			},
			{
				CASP.ClothingCategory.Racing,
				"Racing"
			},
			{
				CASP.ClothingCategory.Supernatural,
				"Supernatural"
			},
			{
				CASP.ClothingCategory.Makeover,
				"Unknown"
			}
		};

		// Token: 0x04000416 RID: 1046
		public static readonly Dictionary<CASP.Sims4ClothingCategory, string> Sims4CategoryLabels = new Dictionary<CASP.Sims4ClothingCategory, string>
		{
			{
				CASP.Sims4ClothingCategory.Sims4Accessories,
				"Accessories"
			},
			{
				CASP.Sims4ClothingCategory.Sims4Body,
				"Body"
			},
			{
				CASP.Sims4ClothingCategory.Sims4Bottom,
				"Bottom"
			},
			{
				CASP.Sims4ClothingCategory.Sims4FacialHair,
				"Facial Hair"
			},
			{
				CASP.Sims4ClothingCategory.Sims4Hair,
				"Hair"
			},
			{
				CASP.Sims4ClothingCategory.Sims4Hats,
				"Hats"
			},
			{
				CASP.Sims4ClothingCategory.Sims4Makeup,
				"Makeup"
			},
			{
				CASP.Sims4ClothingCategory.Sims4Shoes,
				"Shoes"
			},
			{
				CASP.Sims4ClothingCategory.Sims4Tattoos,
				"Tattoos"
			},
			{
				CASP.Sims4ClothingCategory.Sims4Top,
				"Top"
			},
			{
				CASP.Sims4ClothingCategory.Sims4Unknown,
				"Unknown"
			}
		};

		// Token: 0x04000417 RID: 1047
		public static readonly Dictionary<CASP.Type, string> TypeLabels = new Dictionary<CASP.Type, string>
		{
			{
				CASP.Type.Hair,
				"Hair"
			},
			{
				CASP.Type.Scalp,
				"Scalp"
			},
			{
				CASP.Type.Face,
				"Beard"
			},
			{
				CASP.Type.Body,
				"Clothing"
			},
			{
				CASP.Type.Accessory,
				"Accessory"
			}
		};

		// Token: 0x04000418 RID: 1048
		public static Dictionary<ushort, Dictionary<uint, string>> lookupTable;

		// Token: 0x04000419 RID: 1049
		private static List<KeyValuePair<CASP.Sims4Flag.FlagValue, string>> _buildFlags;

		// Token: 0x0400041A RID: 1050
		private static List<KeyValuePair<CASP.Sims4Flag.FlagValue, string>> _roomFlags;

		// Token: 0x02000181 RID: 385
		[Flags]
		public enum ClothingCategory : uint
		{
			// Token: 0x040009E5 RID: 2533
			All = 4294967295U,
			// Token: 0x040009E6 RID: 2534
			Athletic = 32U,
			// Token: 0x040009E7 RID: 2535
			Bridle = 16384U,
			// Token: 0x040009E8 RID: 2536
			Career = 256U,
			// Token: 0x040009E9 RID: 2537
			CategoryMask = 2047U,
			// Token: 0x040009EA RID: 2538
			ChildImagination = 65536U,
			// Token: 0x040009EB RID: 2539
			Everyday = 2U,
			// Token: 0x040009EC RID: 2540
			FireFighting = 512U,
			// Token: 0x040009ED RID: 2541
			Formalwear = 4U,
			// Token: 0x040009EE RID: 2542
			Jumping = 8192U,
			// Token: 0x040009EF RID: 2543
			Makeover = 1024U,
			// Token: 0x040009F0 RID: 2544
			Massage = 32768U,
			// Token: 0x040009F1 RID: 2545
			MartialArts = 128U,
			// Token: 0x040009F2 RID: 2546
			Naked = 1U,
			// Token: 0x040009F3 RID: 2547
			None = 0U,
			// Token: 0x040009F4 RID: 2548
			Outerwear = 262144U,
			// Token: 0x040009F5 RID: 2549
			Racing = 4096U,
			// Token: 0x040009F6 RID: 2550
			Singed = 64U,
			// Token: 0x040009F7 RID: 2551
			SkinnyDippingTowel = 2048U,
			// Token: 0x040009F8 RID: 2552
			Sleepwear = 8U,
			// Token: 0x040009F9 RID: 2553
			Supernatural = 524288U,
			// Token: 0x040009FA RID: 2554
			Swimwear = 16U,
			// Token: 0x040009FB RID: 2555
			IsHat = 4194304U,
			// Token: 0x040009FC RID: 2556
			IsHiddenInCAS = 16777216U,
			// Token: 0x040009FD RID: 2557
			IsRevealing = 8388608U,
			// Token: 0x040009FE RID: 2558
			ValidForMaternity = 1048576U,
			// Token: 0x040009FF RID: 2559
			ValidForRandom = 2097152U
		}

		// Token: 0x02000182 RID: 386
		[Flags]
		public enum Sims4ClothingCategory : uint
		{
			// Token: 0x04000A01 RID: 2561
			None = 0U,
			// Token: 0x04000A02 RID: 2562
			Sims4Top = 1U,
			// Token: 0x04000A03 RID: 2563
			Sims4Bottom = 2U,
			// Token: 0x04000A04 RID: 2564
			Sims4Body = 4U,
			// Token: 0x04000A05 RID: 2565
			Sims4Hair = 8U,
			// Token: 0x04000A06 RID: 2566
			Sims4FacialHair = 16U,
			// Token: 0x04000A07 RID: 2567
			Sims4Makeup = 32U,
			// Token: 0x04000A08 RID: 2568
			Sims4Accessories = 64U,
			// Token: 0x04000A09 RID: 2569
			Sims4Hats = 128U,
			// Token: 0x04000A0A RID: 2570
			Sims4Shoes = 256U,
			// Token: 0x04000A0B RID: 2571
			Sims4Tattoos = 512U,
			// Token: 0x04000A0C RID: 2572
			Sims4Unknown = 1024U
		}

		// Token: 0x02000183 RID: 387
		[Flags]
		public enum AgeGender : uint
		{
			// Token: 0x04000A0E RID: 2574
			None = 0U,
			// Token: 0x04000A0F RID: 2575
			AgeMask = 127U,
			// Token: 0x04000A10 RID: 2576
			Baby = 1U,
			// Token: 0x04000A11 RID: 2577
			Toddler = 2U,
			// Token: 0x04000A12 RID: 2578
			Child = 4U,
			// Token: 0x04000A13 RID: 2579
			Teen = 8U,
			// Token: 0x04000A14 RID: 2580
			YoungAdult = 16U,
			// Token: 0x04000A15 RID: 2581
			Adult = 32U,
			// Token: 0x04000A16 RID: 2582
			Elder = 64U,
			// Token: 0x04000A17 RID: 2583
			GenderMask = 12288U,
			// Token: 0x04000A18 RID: 2584
			Male = 4096U,
			// Token: 0x04000A19 RID: 2585
			Female = 8192U,
			// Token: 0x04000A1A RID: 2586
			SpeciesMask = 52992U,
			// Token: 0x04000A1B RID: 2587
			Human = 256U,
			// Token: 0x04000A1C RID: 2588
			Horse = 512U,
			// Token: 0x04000A1D RID: 2589
			Cat = 768U,
			// Token: 0x04000A1E RID: 2590
			Dog = 1024U,
			// Token: 0x04000A1F RID: 2591
			LittleDog = 1280U,
			// Token: 0x04000A20 RID: 2592
			Deer = 1536U,
			// Token: 0x04000A21 RID: 2593
			Raccoon = 1792U,
			// Token: 0x04000A22 RID: 2594
			SimWalkingDog = 2304U,
			// Token: 0x04000A23 RID: 2595
			LargeBird = 2048U,
			// Token: 0x04000A24 RID: 2596
			SimWalkingLittleDog = 2560U,
			// Token: 0x04000A25 RID: 2597
			SimLeadingHorse = 2816U,
			// Token: 0x04000A26 RID: 2598
			HandednessMask = 3145728U,
			// Token: 0x04000A27 RID: 2599
			LeftHanded = 1048576U,
			// Token: 0x04000A28 RID: 2600
			RightHanded = 2097152U
		}

		// Token: 0x02000184 RID: 388
		[Flags]
		public enum Species : uint
		{
			// Token: 0x04000A2A RID: 2602
			SpeciesMask = 52992U,
			// Token: 0x04000A2B RID: 2603
			Human = 256U,
			// Token: 0x04000A2C RID: 2604
			Horse = 512U,
			// Token: 0x04000A2D RID: 2605
			Cat = 768U,
			// Token: 0x04000A2E RID: 2606
			Dog = 1024U,
			// Token: 0x04000A2F RID: 2607
			LittleDog = 1280U,
			// Token: 0x04000A30 RID: 2608
			Deer = 1536U,
			// Token: 0x04000A31 RID: 2609
			Raccoon = 1792U,
			// Token: 0x04000A32 RID: 2610
			SimWalkingDog = 2304U,
			// Token: 0x04000A33 RID: 2611
			LargeBird = 2048U,
			// Token: 0x04000A34 RID: 2612
			SimWalkingLittleDog = 2560U,
			// Token: 0x04000A35 RID: 2613
			SimLeadingHorse = 2816U
		}

		// Token: 0x02000185 RID: 389
		[Flags]
		public enum Type : uint
		{
			// Token: 0x04000A37 RID: 2615
			BodyAccessory = 32U,
			// Token: 0x04000A38 RID: 2616
			Accessory = 16U,
			// Token: 0x04000A39 RID: 2617
			Atlas = 31U,
			// Token: 0x04000A3A RID: 2618
			Body = 8U,
			// Token: 0x04000A3B RID: 2619
			Face = 4U,
			// Token: 0x04000A3C RID: 2620
			Hair = 1U,
			// Token: 0x04000A3D RID: 2621
			Mask = 31U,
			// Token: 0x04000A3E RID: 2622
			None = 0U,
			// Token: 0x04000A3F RID: 2623
			Scalp = 2U,
			// Token: 0x04000A40 RID: 2624
			Uncategorized = 1024U
		}

		// Token: 0x02000186 RID: 390
		[Flags]
		public enum ClothingType : uint
		{
			// Token: 0x04000A42 RID: 2626
			Accessories = 8U,
			// Token: 0x04000A43 RID: 2627
			AgeWeathering = 29U,
			// Token: 0x04000A44 RID: 2628
			Armband = 32U,
			// Token: 0x04000A45 RID: 2629
			BasePeltLayer = 54U,
			// Token: 0x04000A46 RID: 2630
			Beard = 16U,
			// Token: 0x04000A47 RID: 2631
			BirthMark = 38U,
			// Token: 0x04000A48 RID: 2632
			Blush = 20U,
			// Token: 0x04000A49 RID: 2633
			BodyHairCalves = 45U,
			// Token: 0x04000A4A RID: 2634
			BodyHairFeet = 46U,
			// Token: 0x04000A4B RID: 2635
			BodyHairForearms = 44U,
			// Token: 0x04000A4C RID: 2636
			BodyHairFullBack = 43U,
			// Token: 0x04000A4D RID: 2637
			BodyHairLowerBack = 41U,
			// Token: 0x04000A4E RID: 2638
			BodyHairStomach = 40U,
			// Token: 0x04000A4F RID: 2639
			BodyHairUpperBack = 42U,
			// Token: 0x04000A50 RID: 2640
			BodyHairUpperChest = 39U,
			// Token: 0x04000A51 RID: 2641
			Bracelet = 13U,
			// Token: 0x04000A52 RID: 2642
			CostumeMakeup = 21U,
			// Token: 0x04000A53 RID: 2643
			Dental = 35U,
			// Token: 0x04000A54 RID: 2644
			Earrings = 11U,
			// Token: 0x04000A55 RID: 2645
			Eyebrows = 22U,
			// Token: 0x04000A56 RID: 2646
			EyeColor = 23U,
			// Token: 0x04000A57 RID: 2647
			EyeLiner = 19U,
			// Token: 0x04000A58 RID: 2648
			EyeShadow = 18U,
			// Token: 0x04000A59 RID: 2649
			Face = 3U,
			// Token: 0x04000A5A RID: 2650
			FirstAccessories = 8U,
			// Token: 0x04000A5B RID: 2651
			FirstFace = 17U,
			// Token: 0x04000A5C RID: 2652
			Freckles = 28U,
			// Token: 0x04000A5D RID: 2653
			FullBody = 4U,
			// Token: 0x04000A5E RID: 2654
			Glasses = 12U,
			// Token: 0x04000A5F RID: 2655
			Gloves = 24U,
			// Token: 0x04000A60 RID: 2656
			Hair = 1U,
			// Token: 0x04000A61 RID: 2657
			Last = 60U,
			// Token: 0x04000A62 RID: 2658
			LeftEarring = 30U,
			// Token: 0x04000A63 RID: 2659
			LeftGarter = 36U,
			// Token: 0x04000A64 RID: 2660
			Lipstick = 17U,
			// Token: 0x04000A65 RID: 2661
			LowerBody = 6U,
			// Token: 0x04000A66 RID: 2662
			Mascara = 26U,
			// Token: 0x04000A67 RID: 2663
			Moles = 27U,
			// Token: 0x04000A68 RID: 2664
			Necklace = 9U,
			// Token: 0x04000A69 RID: 2665
			None = 0U,
			// Token: 0x04000A6A RID: 2666
			NoseRing = 10U,
			// Token: 0x04000A6B RID: 2667
			PeltLayer = 53U,
			// Token: 0x04000A6C RID: 2668
			PetBeard = 59U,
			// Token: 0x04000A6D RID: 2669
			PetBlanket = 57U,
			// Token: 0x04000A6E RID: 2670
			PetBody = 47U,
			// Token: 0x04000A6F RID: 2671
			PetBreastCollar = 58U,
			// Token: 0x04000A70 RID: 2672
			PetBridle = 51U,
			// Token: 0x04000A71 RID: 2673
			PetCollar = 51U,
			// Token: 0x04000A72 RID: 2674
			PetEars = 49U,
			// Token: 0x04000A73 RID: 2675
			PetHooves = 55U,
			// Token: 0x04000A74 RID: 2676
			PetHorn = 56U,
			// Token: 0x04000A75 RID: 2677
			PetMane = 50U,
			// Token: 0x04000A76 RID: 2678
			PetSaddle = 52U,
			// Token: 0x04000A77 RID: 2679
			PetTail = 48U,
			// Token: 0x04000A78 RID: 2680
			RightEarring = 31U,
			// Token: 0x04000A79 RID: 2681
			RightGarter = 37U,
			// Token: 0x04000A7A RID: 2682
			Ring = 14U,
			// Token: 0x04000A7B RID: 2683
			Scalp = 2U,
			// Token: 0x04000A7C RID: 2684
			Shoes = 7U,
			// Token: 0x04000A7D RID: 2685
			Socks = 25U,
			// Token: 0x04000A7E RID: 2686
			Tattoo = 33U,
			// Token: 0x04000A7F RID: 2687
			TattooTemplate = 34U,
			// Token: 0x04000A80 RID: 2688
			UpperBody = 5U,
			// Token: 0x04000A81 RID: 2689
			WeddingRing = 15U
		}

		// Token: 0x02000187 RID: 391
		[Flags]
		public enum ExcludePartFlag : ulong
		{
			// Token: 0x04000A83 RID: 2691
			BODYTYPE_NONE = 0UL,
			// Token: 0x04000A84 RID: 2692
			BODYTYPE_HAT = 2UL,
			// Token: 0x04000A85 RID: 2693
			BODYTYPE_HAIR = 4UL,
			// Token: 0x04000A86 RID: 2694
			BODYTYPE_HEAD = 8UL,
			// Token: 0x04000A87 RID: 2695
			BODYTYPE_FACE = 16UL,
			// Token: 0x04000A88 RID: 2696
			BODYTYPE_FULLBODY = 32UL,
			// Token: 0x04000A89 RID: 2697
			BODYTYPE_UPPERBODY = 64UL,
			// Token: 0x04000A8A RID: 2698
			BODYTYPE_LOWERBODY = 128UL,
			// Token: 0x04000A8B RID: 2699
			BODYTYPE_SHOES = 256UL,
			// Token: 0x04000A8C RID: 2700
			BODYTYPE_ACCESSORIES = 512UL,
			// Token: 0x04000A8D RID: 2701
			BODYTYPE_EARRINGS = 1024UL,
			// Token: 0x04000A8E RID: 2702
			BODYTYPE_GLASSES = 2048UL,
			// Token: 0x04000A8F RID: 2703
			BODYTYPE_NECKLACE = 4096UL,
			// Token: 0x04000A90 RID: 2704
			BODYTYPE_GLOVES = 8192UL,
			// Token: 0x04000A91 RID: 2705
			BODYTYPE_WRISTLEFT = 16384UL,
			// Token: 0x04000A92 RID: 2706
			BODYTYPE_WRISTRIGHT = 32768UL,
			// Token: 0x04000A93 RID: 2707
			BODYTYPE_LIPRINGLEFT = 65536UL,
			// Token: 0x04000A94 RID: 2708
			BODYTYPE_LIPRINGRIGHT = 131072UL,
			// Token: 0x04000A95 RID: 2709
			BODYTYPE_NOSERINGLEFT = 262144UL,
			// Token: 0x04000A96 RID: 2710
			BODYTYPE_NOSERINGRIGHT = 524288UL,
			// Token: 0x04000A97 RID: 2711
			BODYTYPE_BROWRINGLEFT = 1048576UL,
			// Token: 0x04000A98 RID: 2712
			BODYTYPE_BROWRINGRIGHT = 2097152UL,
			// Token: 0x04000A99 RID: 2713
			BODYTYPE_INDEXFINGERLEFT = 4194304UL,
			// Token: 0x04000A9A RID: 2714
			BODYTYPE_INDEXFINGERRIGHT = 8388608UL,
			// Token: 0x04000A9B RID: 2715
			BODYTYPE_RINGFINGERLEFT = 16777216UL,
			// Token: 0x04000A9C RID: 2716
			BODYTYPE_RINGFINGERRIGHT = 33554432UL,
			// Token: 0x04000A9D RID: 2717
			BODYTYPE_MIDDLEFINGERLEFT = 67108864UL,
			// Token: 0x04000A9E RID: 2718
			BODYTYPE_MIDDLEFINGERRIGHT = 134217728UL,
			// Token: 0x04000A9F RID: 2719
			BODYTYPE_FACIALHAIR = 268435456UL,
			// Token: 0x04000AA0 RID: 2720
			BODYTYPE_LIPSTICK = 536870912UL,
			// Token: 0x04000AA1 RID: 2721
			BODYTYPE_EYESHADOW = 1073741824UL,
			// Token: 0x04000AA2 RID: 2722
			BODYTYPE_EYELINER = 2147483648UL,
			// Token: 0x04000AA3 RID: 2723
			BODYTYPE_BLUSH = 4294967296UL,
			// Token: 0x04000AA4 RID: 2724
			BODYTYPE_FACEPAINT = 8589934592UL,
			// Token: 0x04000AA5 RID: 2725
			BODYTYPE_EYEBROWS = 17179869184UL,
			// Token: 0x04000AA6 RID: 2726
			BODYTYPE_EYECOLOR = 34359738368UL,
			// Token: 0x04000AA7 RID: 2727
			BODYTYPE_SOCKS = 68719476736UL,
			// Token: 0x04000AA8 RID: 2728
			BODYTYPE_MASCARA = 137438953472UL,
			// Token: 0x04000AA9 RID: 2729
			BODYTYPE_SKINDETAIL_CREASEFOREHEAD = 274877906944UL,
			// Token: 0x04000AAA RID: 2730
			BODYTYPE_SKINDETAIL_FRECKLES = 549755813888UL,
			// Token: 0x04000AAB RID: 2731
			BODYTYPE_SKINDETAIL_DIMPLELEFT = 1099511627776UL,
			// Token: 0x04000AAC RID: 2732
			BODYTYPE_SKINDETAIL_DIMPLERIGHT = 2199023255552UL,
			// Token: 0x04000AAD RID: 2733
			BODYTYPE_TIGHTS = 4398046511104UL,
			// Token: 0x04000AAE RID: 2734
			BODYTYPE_SKINDETAIL_MOLELIPLEFT = 8796093022208UL,
			// Token: 0x04000AAF RID: 2735
			BODYTYPE_SKINDETAIL_MOLELIPRIGHT = 17592186044416UL,
			// Token: 0x04000AB0 RID: 2736
			BODYTYPE_TATTOO_ARMLOWERLEFT = 35184372088832UL,
			// Token: 0x04000AB1 RID: 2737
			BODYTYPE_TATTOO_ARMUPPERLEFT = 70368744177664UL,
			// Token: 0x04000AB2 RID: 2738
			BODYTYPE_TATTOO_ARMLOWERRIGHT = 140737488355328UL,
			// Token: 0x04000AB3 RID: 2739
			BODYTYPE_TATTOO_ARMUPPERRIGHT = 281474976710656UL,
			// Token: 0x04000AB4 RID: 2740
			BODYTYPE_TATTOO_LEGLEFT = 562949953421312UL,
			// Token: 0x04000AB5 RID: 2741
			BODYTYPE_TATTOO_LEGRIGHT = 1125899906842624UL,
			// Token: 0x04000AB6 RID: 2742
			BODYTYPE_TATTOO_TORSOBACKLOWER = 2251799813685248UL,
			// Token: 0x04000AB7 RID: 2743
			BODYTYPE_TATTOO_TORSOBACKUPPER = 4503599627370496UL,
			// Token: 0x04000AB8 RID: 2744
			BODYTYPE_TATTOO_TORSOFRONTLOWER = 9007199254740992UL,
			// Token: 0x04000AB9 RID: 2745
			BODYTYPE_TATTOO_TORSOFRONTUPPER = 18014398509481984UL,
			// Token: 0x04000ABA RID: 2746
			BODYTYPE_SKINDETAIL_MOLECHEEKLEFT = 36028797018963968UL,
			// Token: 0x04000ABB RID: 2747
			BODYTYPE_SKINDETAIL_MOLECHEEKRIGHT = 72057594037927936UL,
			// Token: 0x04000ABC RID: 2748
			BODYTYPE_SKINDETAIL_CREASEMOUTH = 144115188075855872UL
		}

		// Token: 0x02000188 RID: 392
		public enum BodyType : ulong
		{
			// Token: 0x04000ABE RID: 2750
			None,
			// Token: 0x04000ABF RID: 2751
			Hat,
			// Token: 0x04000AC0 RID: 2752
			Hair,
			// Token: 0x04000AC1 RID: 2753
			Head,
			// Token: 0x04000AC2 RID: 2754
			Face,
			// Token: 0x04000AC3 RID: 2755
			FullBody,
			// Token: 0x04000AC4 RID: 2756
			UpperBody,
			// Token: 0x04000AC5 RID: 2757
			LowerBody,
			// Token: 0x04000AC6 RID: 2758
			Shoes,
			// Token: 0x04000AC7 RID: 2759
			Accessories,
			// Token: 0x04000AC8 RID: 2760
			Earrings,
			// Token: 0x04000AC9 RID: 2761
			Glasses,
			// Token: 0x04000ACA RID: 2762
			Necklace,
			// Token: 0x04000ACB RID: 2763
			Gloves,
			// Token: 0x04000ACC RID: 2764
			WristLeft,
			// Token: 0x04000ACD RID: 2765
			WristRight,
			// Token: 0x04000ACE RID: 2766
			LipRingLeft,
			// Token: 0x04000ACF RID: 2767
			LipRingRight,
			// Token: 0x04000AD0 RID: 2768
			NoseRingLeft,
			// Token: 0x04000AD1 RID: 2769
			NoseRingRight,
			// Token: 0x04000AD2 RID: 2770
			BrowRingLeft,
			// Token: 0x04000AD3 RID: 2771
			BrowRingRight,
			// Token: 0x04000AD4 RID: 2772
			IndexFingerLeft,
			// Token: 0x04000AD5 RID: 2773
			IndexFingerRight,
			// Token: 0x04000AD6 RID: 2774
			RingFingerLeft,
			// Token: 0x04000AD7 RID: 2775
			RingFingerRight,
			// Token: 0x04000AD8 RID: 2776
			MiddleFingerLeft,
			// Token: 0x04000AD9 RID: 2777
			MiddleFingerRight,
			// Token: 0x04000ADA RID: 2778
			FacialHair,
			// Token: 0x04000ADB RID: 2779
			Lipstick,
			// Token: 0x04000ADC RID: 2780
			Eyeshadow,
			// Token: 0x04000ADD RID: 2781
			Eyeliner,
			// Token: 0x04000ADE RID: 2782
			Blush,
			// Token: 0x04000ADF RID: 2783
			Facepaint,
			// Token: 0x04000AE0 RID: 2784
			Eyebrows,
			// Token: 0x04000AE1 RID: 2785
			Eyecolor,
			// Token: 0x04000AE2 RID: 2786
			Socks,
			// Token: 0x04000AE3 RID: 2787
			MaskDetail,
			// Token: 0x04000AE4 RID: 2788
			SkinDetailCreaseForehead,
			// Token: 0x04000AE5 RID: 2789
			SkinDetailFreckles,
			// Token: 0x04000AE6 RID: 2790
			SkinDetailDimpleLeft,
			// Token: 0x04000AE7 RID: 2791
			SkinDetailDimpleRight,
			// Token: 0x04000AE8 RID: 2792
			Tights,
			// Token: 0x04000AE9 RID: 2793
			SkinDetailMoleLipLeft,
			// Token: 0x04000AEA RID: 2794
			SkinDetailMoleLipRight,
			// Token: 0x04000AEB RID: 2795
			TattooArmLowerLeft,
			// Token: 0x04000AEC RID: 2796
			TattooArmUpperLeft,
			// Token: 0x04000AED RID: 2797
			TattooArmLowerRight,
			// Token: 0x04000AEE RID: 2798
			TattooArmUpperRight,
			// Token: 0x04000AEF RID: 2799
			TattooLegLeft,
			// Token: 0x04000AF0 RID: 2800
			TattooLegRight,
			// Token: 0x04000AF1 RID: 2801
			TattooTorsoBackLower,
			// Token: 0x04000AF2 RID: 2802
			TattooTorsoBackUpper,
			// Token: 0x04000AF3 RID: 2803
			TattooTorsoFrontLower,
			// Token: 0x04000AF4 RID: 2804
			TattooTorsoFrontUpper,
			// Token: 0x04000AF5 RID: 2805
			SkinDetailMoleCheekLeft,
			// Token: 0x04000AF6 RID: 2806
			SkinDetailMoleCheekRight,
			// Token: 0x04000AF7 RID: 2807
			SkinDetailCreaseMouth,
			// Token: 0x04000AF8 RID: 2808
			SkinOverlay,
			// Token: 0x04000AF9 RID: 2809
			FurBody,
			// Token: 0x04000AFA RID: 2810
			Ears,
			// Token: 0x04000AFB RID: 2811
			Tail,
			// Token: 0x04000AFC RID: 2812
			SkinDetailNoseColor,
			// Token: 0x04000AFD RID: 2813
			EyecolorSecondary,
			// Token: 0x04000AFE RID: 2814
			OccultBrow,
			// Token: 0x04000AFF RID: 2815
			OccultEyeSocket,
			// Token: 0x04000B00 RID: 2816
			OccultEyeLid,
			// Token: 0x04000B01 RID: 2817
			OccultMouth,
			// Token: 0x04000B02 RID: 2818
			OccultLeftCheek,
			// Token: 0x04000B03 RID: 2819
			OccultRightCheek,
			// Token: 0x04000B04 RID: 2820
			OccultNeckScar,
			// Token: 0x04000B05 RID: 2821
			ForearmScar,
			// Token: 0x04000B06 RID: 2822
			Acne
		}

		// Token: 0x02000189 RID: 393
		public class Sims4Flag
		{
			// Token: 0x06000F30 RID: 3888 RVA: 0x0000A862 File Offset: 0x00008A62
			public Sims4Flag(uint parentVersion)
			{
				this.parentVersion = parentVersion;
			}

			// Token: 0x170004B6 RID: 1206
			// (get) Token: 0x06000F31 RID: 3889 RVA: 0x0000A871 File Offset: 0x00008A71
			// (set) Token: 0x06000F32 RID: 3890 RVA: 0x0000A879 File Offset: 0x00008A79
			public CASP.Sims4Flag.FlagValue Value { get; set; }

			// Token: 0x170004B7 RID: 1207
			// (get) Token: 0x06000F33 RID: 3891 RVA: 0x0000A882 File Offset: 0x00008A82
			// (set) Token: 0x06000F34 RID: 3892 RVA: 0x0000A88A File Offset: 0x00008A8A
			public CASP.Sims4Flag.FlagCategory Category { get; set; }

			// Token: 0x06000F35 RID: 3893 RVA: 0x0000A893 File Offset: 0x00008A93
			public void UnSerialize(BinaryReader r)
			{
				this.Category = (CASP.Sims4Flag.FlagCategory)r.ReadUInt16();
				this.Value = (CASP.Sims4Flag.FlagValue)((this.parentVersion >= 37U) ? r.ReadUInt32() : ((uint)r.ReadUInt16()));
			}

			// Token: 0x06000F36 RID: 3894 RVA: 0x0000A8BF File Offset: 0x00008ABF
			public void Serialize(BinaryWriter w)
			{
				w.Write((ushort)this.Category);
				if (this.parentVersion >= 37U)
				{
					w.Write((uint)this.Value);
					return;
				}
				w.Write((ushort)this.Value);
			}

			// Token: 0x06000F37 RID: 3895 RVA: 0x000434E8 File Offset: 0x000416E8
			public override string ToString()
			{
				return this.Category.ToString() + ", " + this.Value.ToString();
			}

			// Token: 0x04000B07 RID: 2823
			private uint parentVersion;

			// Token: 0x020001D9 RID: 473
			public enum FlagCategory : ushort
			{
				// Token: 0x040015D0 RID: 5584
				Func = 1,
				// Token: 0x040015D1 RID: 5585
				BuyCat,
				// Token: 0x040015D2 RID: 5586
				BuyCat_Venue,
				// Token: 0x040015D3 RID: 5587
				BuyCat_Collection,
				// Token: 0x040015D4 RID: 5588
				Accessories = 92,
				// Token: 0x040015D5 RID: 5589
				AgeAppropriate = 68,
				// Token: 0x040015D6 RID: 5590
				AppearanceModifier = 126,
				// Token: 0x040015D7 RID: 5591
				Archetype = 69,
				// Token: 0x040015D8 RID: 5592
				Bottom = 82,
				// Token: 0x040015D9 RID: 5593
				BottomAccessory = 85,
				// Token: 0x040015DA RID: 5594
				Breed = 117,
				// Token: 0x040015DB RID: 5595
				BreedGroup = 121,
				// Token: 0x040015DC RID: 5596
				Build = 97,
				// Token: 0x040015DD RID: 5597
				BuyCatEE = 86,
				// Token: 0x040015DE RID: 5598
				BuyCatLD = 88,
				// Token: 0x040015DF RID: 5599
				BuyCatMAG = 93,
				// Token: 0x040015E0 RID: 5600
				BuyCatPA = 87,
				// Token: 0x040015E1 RID: 5601
				BuyCatSS = 89,
				// Token: 0x040015E2 RID: 5602
				BuyCatVO,
				// Token: 0x040015E3 RID: 5603
				CoatPattern = 124,
				// Token: 0x040015E4 RID: 5604
				Color = 65,
				// Token: 0x040015E5 RID: 5605
				ColorPalette = 76,
				// Token: 0x040015E6 RID: 5606
				DogSize = 120,
				// Token: 0x040015E7 RID: 5607
				Ears = 116,
				// Token: 0x040015E8 RID: 5608
				Ensemble = 107,
				// Token: 0x040015E9 RID: 5609
				EyebrowShape = 106,
				// Token: 0x040015EA RID: 5610
				EyebrowThickness = 105,
				// Token: 0x040015EB RID: 5611
				EyeColor = 72,
				// Token: 0x040015EC RID: 5612
				Fabric = 96,
				// Token: 0x040015ED RID: 5613
				FaceDetail = 113,
				// Token: 0x040015EE RID: 5614
				FaceMakeup = 80,
				// Token: 0x040015EF RID: 5615
				FacialHair = 78,
				// Token: 0x040015F0 RID: 5616
				FloorPattern = 94,
				// Token: 0x040015F1 RID: 5617
				FullBody = 83,
				// Token: 0x040015F2 RID: 5618
				Fur = 119,
				// Token: 0x040015F3 RID: 5619
				FurLength = 125,
				// Token: 0x040015F4 RID: 5620
				GenderAppropriate = 111,
				// Token: 0x040015F5 RID: 5621
				Hair = 77,
				// Token: 0x040015F6 RID: 5622
				HairColor = 75,
				// Token: 0x040015F7 RID: 5623
				HairLength = 99,
				// Token: 0x040015F8 RID: 5624
				HairTexture,
				// Token: 0x040015F9 RID: 5625
				Hat = 79,
				// Token: 0x040015FA RID: 5626
				Mood = 64,
				// Token: 0x040015FB RID: 5627
				None = 0,
				// Token: 0x040015FC RID: 5628
				NoseColor = 122,
				// Token: 0x040015FD RID: 5629
				NudePart = 112,
				// Token: 0x040015FE RID: 5630
				Occult = 109,
				// Token: 0x040015FF RID: 5631
				OutfitCategory = 70,
				// Token: 0x04001600 RID: 5632
				Pattern = 98,
				// Token: 0x04001601 RID: 5633
				Persona = 73,
				// Token: 0x04001602 RID: 5634
				Reward = 103,
				// Token: 0x04001603 RID: 5635
				Shoes = 84,
				// Token: 0x04001604 RID: 5636
				Skill = 71,
				// Token: 0x04001605 RID: 5637
				SkinHue = 102,
				// Token: 0x04001606 RID: 5638
				SkintoneBlend = 110,
				// Token: 0x04001607 RID: 5639
				SkintoneType = 108,
				// Token: 0x04001608 RID: 5640
				Special = 74,
				// Token: 0x04001609 RID: 5641
				Style = 66,
				// Token: 0x0400160A RID: 5642
				Tail = 118,
				// Token: 0x0400160B RID: 5643
				TerrainPaint = 104,
				// Token: 0x0400160C RID: 5644
				Theme = 67,
				// Token: 0x0400160D RID: 5645
				Top = 81,
				// Token: 0x0400160E RID: 5646
				TraitGroup = 101,
				// Token: 0x0400160F RID: 5647
				Uniform = 91,
				// Token: 0x04001610 RID: 5648
				WallPattern = 95,
				// Token: 0x04001611 RID: 5649
				VampireArchetype = 114,
				// Token: 0x04001612 RID: 5650
				WorldLog = 123
			}

			// Token: 0x020001DA RID: 474
			public enum FlagValue : uint
			{
				// Token: 0x04001614 RID: 5652
				AgeAppropriate_Adult = 84U,
				// Token: 0x04001615 RID: 5653
				AgeAppropriate_Child,
				// Token: 0x04001616 RID: 5654
				AgeAppropriate_Elder = 72U,
				// Token: 0x04001617 RID: 5655
				AgeAppropriate_Teen = 291U,
				// Token: 0x04001618 RID: 5656
				AgeAppropriate_Toddler = 1657U,
				// Token: 0x04001619 RID: 5657
				AgeAppropriate_YoungAdult = 71U,
				// Token: 0x0400161A RID: 5658
				AppearanceModifier_HairMakeupChair_HairStyle = 61494U,
				// Token: 0x0400161B RID: 5659
				AppearanceModifier_HairMakeUpChair_MakeUp = 61609U,
				// Token: 0x0400161C RID: 5660
				Appropriateness_Bartending = 406U,
				// Token: 0x0400161D RID: 5661
				Appropriateness_Bathing = 402U,
				// Token: 0x0400161E RID: 5662
				Appropriateness_Cake = 605U,
				// Token: 0x0400161F RID: 5663
				Appropriateness_CallToMeal = 1170U,
				// Token: 0x04001620 RID: 5664
				Appropriateness_Cleaning = 404U,
				// Token: 0x04001621 RID: 5665
				Appropriateness_Computer = 1373U,
				// Token: 0x04001622 RID: 5666
				Appropriateness_Cooking = 405U,
				// Token: 0x04001623 RID: 5667
				Appropriateness_Dancing = 603U,
				// Token: 0x04001624 RID: 5668
				Appropriateness_Eating,
				// Token: 0x04001625 RID: 5669
				Appropriateness_FrontDesk = 12413U,
				// Token: 0x04001626 RID: 5670
				Appropriateness_GrabSnack = 939U,
				// Token: 0x04001627 RID: 5671
				Appropriateness_Guest = 367U,
				// Token: 0x04001628 RID: 5672
				Appropriateness_HiredWorker,
				// Token: 0x04001629 RID: 5673
				Appropriateness_Host = 370U,
				// Token: 0x0400162A RID: 5674
				Appropriateness_NotDuringWork = 1274U,
				// Token: 0x0400162B RID: 5675
				Appropriateness_NotDuringWork_Lunch,
				// Token: 0x0400162C RID: 5676
				Appropriateness_Phone = 1594U,
				// Token: 0x0400162D RID: 5677
				Appropriateness_PhoneGame = 1626U,
				// Token: 0x0400162E RID: 5678
				Appropriateness_Playing = 1539U,
				// Token: 0x0400162F RID: 5679
				Appropriateness_PlayInstrument = 2156U,
				// Token: 0x04001630 RID: 5680
				Appropriateness_ReadBooks = 1276U,
				// Token: 0x04001631 RID: 5681
				Appropriateness_ServiceNPC = 369U,
				// Token: 0x04001632 RID: 5682
				Appropriateness_Shower = 352U,
				// Token: 0x04001633 RID: 5683
				Appropriateness_Singing = 55385U,
				// Token: 0x04001634 RID: 5684
				Appropriateness_Sleeping = 403U,
				// Token: 0x04001635 RID: 5685
				Appropriateness_SnowShoveling = 69706U,
				// Token: 0x04001636 RID: 5686
				Appropriateness_SocialPicker = 1645U,
				// Token: 0x04001637 RID: 5687
				Appropriateness_Stereo = 530U,
				// Token: 0x04001638 RID: 5688
				Appropriateness_Tip = 2155U,
				// Token: 0x04001639 RID: 5689
				Appropriateness_Touching = 1526U,
				// Token: 0x0400163A RID: 5690
				Appropriateness_Trash = 12423U,
				// Token: 0x0400163B RID: 5691
				Appropriateness_TV_Watching = 1273U,
				// Token: 0x0400163C RID: 5692
				Appropriateness_View = 12428U,
				// Token: 0x0400163D RID: 5693
				Appropriateness_Visitor = 1497U,
				// Token: 0x0400163E RID: 5694
				Appropriateness_Work_Scientist = 12297U,
				// Token: 0x0400163F RID: 5695
				Appropriateness_Workout = 1277U,
				// Token: 0x04001640 RID: 5696
				Archetype_African = 73U,
				// Token: 0x04001641 RID: 5697
				Archetype_Asian = 75U,
				// Token: 0x04001642 RID: 5698
				Archetype_Caucasian,
				// Token: 0x04001643 RID: 5699
				Archetype_Island = 2206U,
				// Token: 0x04001644 RID: 5700
				Archetype_Latin = 312U,
				// Token: 0x04001645 RID: 5701
				Archetype_MiddleEastern = 74U,
				// Token: 0x04001646 RID: 5702
				Archetype_NorthAmerican = 89U,
				// Token: 0x04001647 RID: 5703
				Archetype_SouthAsian = 88U,
				// Token: 0x04001648 RID: 5704
				AtPo_Beach = 2194U,
				// Token: 0x04001649 RID: 5705
				AtPo_Beach_Walkby = 2204U,
				// Token: 0x0400164A RID: 5706
				AtPo_Blossom_Guru = 55386U,
				// Token: 0x0400164B RID: 5707
				AtPo_Busker = 1571U,
				// Token: 0x0400164C RID: 5708
				AtPo_Dynamic_SpawnPoint = 1915U,
				// Token: 0x0400164D RID: 5709
				AtPo_Fireworks = 55399U,
				// Token: 0x0400164E RID: 5710
				AtPo_FleaMarket_Vendor = 55334U,
				// Token: 0x0400164F RID: 5711
				AtPo_GoForWalk = 1916U,
				// Token: 0x04001650 RID: 5712
				AtPo_GoForWalk_Long = 57394U,
				// Token: 0x04001651 RID: 5713
				AtPo_GoForWalk_Long_02 = 57432U,
				// Token: 0x04001652 RID: 5714
				AtPo_GoForWalk_Long_03,
				// Token: 0x04001653 RID: 5715
				AtPo_GoForWalk_Med_02 = 57436U,
				// Token: 0x04001654 RID: 5716
				AtPo_GoForWalk_Med_03,
				// Token: 0x04001655 RID: 5717
				AtPo_GoForWalk_Medium = 57393U,
				// Token: 0x04001656 RID: 5718
				AtPo_GoForWalk_Short = 57389U,
				// Token: 0x04001657 RID: 5719
				AtPo_GoForWalk_Short_02 = 57434U,
				// Token: 0x04001658 RID: 5720
				AtPo_GoForWalk_Short_03,
				// Token: 0x04001659 RID: 5721
				AtPo_Guitar = 2158U,
				// Token: 0x0400165A RID: 5722
				AtPo_MagicDueling = 2222U,
				// Token: 0x0400165B RID: 5723
				AtPo_Protester = 1582U,
				// Token: 0x0400165C RID: 5724
				AtPo_Tourist = 1570U,
				// Token: 0x0400165D RID: 5725
				AtPo_UniversityQuad = 2230U,
				// Token: 0x0400165E RID: 5726
				Bottom_Bikini = 1235U,
				// Token: 0x0400165F RID: 5727
				Bottom_Cropped = 945U,
				// Token: 0x04001660 RID: 5728
				Bottom_Jeans = 382U,
				// Token: 0x04001661 RID: 5729
				Bottom_Leggings = 381U,
				// Token: 0x04001662 RID: 5730
				Bottom_Pants = 152U,
				// Token: 0x04001663 RID: 5731
				Bottom_Shorts = 154U,
				// Token: 0x04001664 RID: 5732
				Bottom_Skirt = 153U,
				// Token: 0x04001665 RID: 5733
				Bottom_Swimshort = 1238U,
				// Token: 0x04001666 RID: 5734
				Bottom_Swimwear = 1544U,
				// Token: 0x04001667 RID: 5735
				Bottom_Underwear = 1543U,
				// Token: 0x04001668 RID: 5736
				Bottom_Underwear_Female = 946U,
				// Token: 0x04001669 RID: 5737
				Bottom_Underwear_Male = 1040U,
				// Token: 0x0400166A RID: 5738
				Breed_Cat_Abyssinian = 1830U,
				// Token: 0x0400166B RID: 5739
				Breed_Cat_American_Bobtail,
				// Token: 0x0400166C RID: 5740
				Breed_Cat_American_Longhair = 1931U,
				// Token: 0x0400166D RID: 5741
				Breed_Cat_American_Shorthair = 1833U,
				// Token: 0x0400166E RID: 5742
				Breed_Cat_American_Wirehair,
				// Token: 0x0400166F RID: 5743
				Breed_Cat_Balinese,
				// Token: 0x04001670 RID: 5744
				Breed_Cat_Bengal,
				// Token: 0x04001671 RID: 5745
				Breed_Cat_Birman,
				// Token: 0x04001672 RID: 5746
				Breed_Cat_Black_Cat,
				// Token: 0x04001673 RID: 5747
				Breed_Cat_Bombay,
				// Token: 0x04001674 RID: 5748
				Breed_Cat_British_Longhair,
				// Token: 0x04001675 RID: 5749
				Breed_Cat_British_Shorthair,
				// Token: 0x04001676 RID: 5750
				Breed_Cat_Burmese,
				// Token: 0x04001677 RID: 5751
				Breed_Cat_Calico,
				// Token: 0x04001678 RID: 5752
				Breed_Cat_Chartreux,
				// Token: 0x04001679 RID: 5753
				Breed_Cat_Colorpoint_Shorthair,
				// Token: 0x0400167A RID: 5754
				Breed_Cat_CornishRex = 1832U,
				// Token: 0x0400167B RID: 5755
				Breed_Cat_Devon_Rex = 1846U,
				// Token: 0x0400167C RID: 5756
				Breed_Cat_Egyptian_Mau,
				// Token: 0x0400167D RID: 5757
				Breed_Cat_German_Rex,
				// Token: 0x0400167E RID: 5758
				Breed_Cat_Havana_Brown,
				// Token: 0x0400167F RID: 5759
				Breed_Cat_Himalyan,
				// Token: 0x04001680 RID: 5760
				Breed_Cat_Japanese_Bobtail,
				// Token: 0x04001681 RID: 5761
				Breed_Cat_Javanese,
				// Token: 0x04001682 RID: 5762
				Breed_Cat_Korat,
				// Token: 0x04001683 RID: 5763
				Breed_Cat_Kurilian_Bobtail,
				// Token: 0x04001684 RID: 5764
				Breed_Cat_LaPerm,
				// Token: 0x04001685 RID: 5765
				Breed_Cat_Lyoki = 1975U,
				// Token: 0x04001686 RID: 5766
				Breed_Cat_Maine_Coon = 1856U,
				// Token: 0x04001687 RID: 5767
				Breed_Cat_Manx,
				// Token: 0x04001688 RID: 5768
				Breed_Cat_Mixed = 1926U,
				// Token: 0x04001689 RID: 5769
				Breed_Cat_Norwegian_Forest = 1858U,
				// Token: 0x0400168A RID: 5770
				Breed_Cat_Ocicat,
				// Token: 0x0400168B RID: 5771
				Breed_Cat_Oriental,
				// Token: 0x0400168C RID: 5772
				Breed_Cat_Oriental_Shorthair,
				// Token: 0x0400168D RID: 5773
				Breed_Cat_Persian,
				// Token: 0x0400168E RID: 5774
				Breed_Cat_Raccoon = 1974U,
				// Token: 0x0400168F RID: 5775
				Breed_Cat_Ragdoll = 1863U,
				// Token: 0x04001690 RID: 5776
				Breed_Cat_Russian_Blue,
				// Token: 0x04001691 RID: 5777
				Breed_Cat_Savannah,
				// Token: 0x04001692 RID: 5778
				Breed_Cat_Scottish_Fold,
				// Token: 0x04001693 RID: 5779
				Breed_Cat_Shorthair_Tabby,
				// Token: 0x04001694 RID: 5780
				Breed_Cat_Siamese,
				// Token: 0x04001695 RID: 5781
				Breed_Cat_Siberian,
				// Token: 0x04001696 RID: 5782
				Breed_Cat_Singapura,
				// Token: 0x04001697 RID: 5783
				Breed_Cat_Somali,
				// Token: 0x04001698 RID: 5784
				Breed_Cat_Sphynx = 1886U,
				// Token: 0x04001699 RID: 5785
				Breed_Cat_Tonkinese = 1872U,
				// Token: 0x0400169A RID: 5786
				Breed_Cat_Turkish_Angora,
				// Token: 0x0400169B RID: 5787
				Breed_Cat_Tuxedo_Cat,
				// Token: 0x0400169C RID: 5788
				Breed_LargeDog_Afghan_Hound = 1814U,
				// Token: 0x0400169D RID: 5789
				Breed_LargeDog_Airedale_Terrier = 1745U,
				// Token: 0x0400169E RID: 5790
				Breed_LargeDog_Akita,
				// Token: 0x0400169F RID: 5791
				Breed_LargeDog_Alaskan_Malamute,
				// Token: 0x040016A0 RID: 5792
				Breed_LargeDog_American_Eskimo,
				// Token: 0x040016A1 RID: 5793
				Breed_LargeDog_American_Foxhound = 1797U,
				// Token: 0x040016A2 RID: 5794
				Breed_LargeDog_Australian_Cattle_Dog = 1750U,
				// Token: 0x040016A3 RID: 5795
				Breed_LargeDog_AustralianShepherd = 1735U,
				// Token: 0x040016A4 RID: 5796
				Breed_LargeDog_Bedlington_Terrier = 1950U,
				// Token: 0x040016A5 RID: 5797
				Breed_LargeDog_Bernese_Mountain_Dog = 1751U,
				// Token: 0x040016A6 RID: 5798
				Breed_LargeDog_Black_And_Tan_Coonhound = 1798U,
				// Token: 0x040016A7 RID: 5799
				Breed_LargeDog_Black_Russian_Terrier = 1961U,
				// Token: 0x040016A8 RID: 5800
				Breed_LargeDog_Bloodhound = 1753U,
				// Token: 0x040016A9 RID: 5801
				Breed_LargeDog_Bluetick_Coonhound = 1796U,
				// Token: 0x040016AA RID: 5802
				Breed_LargeDog_BorderCollie = 1736U,
				// Token: 0x040016AB RID: 5803
				Breed_LargeDog_Borzoi = 1826U,
				// Token: 0x040016AC RID: 5804
				Breed_LargeDog_Boxer = 1755U,
				// Token: 0x040016AD RID: 5805
				Breed_LargeDog_Brittany = 1816U,
				// Token: 0x040016AE RID: 5806
				Breed_LargeDog_Bullmastiff = 1951U,
				// Token: 0x040016AF RID: 5807
				Breed_LargeDog_Canaan,
				// Token: 0x040016B0 RID: 5808
				Breed_LargeDog_Chesapeake_Bay_Retriever = 1795U,
				// Token: 0x040016B1 RID: 5809
				Breed_LargeDog_Chow_Chow = 1759U,
				// Token: 0x040016B2 RID: 5810
				Breed_LargeDog_ChowLabMix = 1953U,
				// Token: 0x040016B3 RID: 5811
				Breed_LargeDog_Collie = 1740U,
				// Token: 0x040016B4 RID: 5812
				Breed_LargeDog_Curly_Coated_Retriever = 1794U,
				// Token: 0x040016B5 RID: 5813
				Breed_LargeDog_Dalmatian = 1741U,
				// Token: 0x040016B6 RID: 5814
				Breed_LargeDog_Dingo = 1954U,
				// Token: 0x040016B7 RID: 5815
				Breed_LargeDog_Doberman = 1742U,
				// Token: 0x040016B8 RID: 5816
				Breed_LargeDog_Doberman_Pinscher = 1761U,
				// Token: 0x040016B9 RID: 5817
				Breed_LargeDog_English_Foxhound = 1821U,
				// Token: 0x040016BA RID: 5818
				Breed_LargeDog_English_Setter = 1819U,
				// Token: 0x040016BB RID: 5819
				Breed_LargeDog_English_Springer_Spaniel = 1762U,
				// Token: 0x040016BC RID: 5820
				Breed_LargeDog_Field_Spaniel = 1801U,
				// Token: 0x040016BD RID: 5821
				Breed_LargeDog_GermanPointer = 1737U,
				// Token: 0x040016BE RID: 5822
				Breed_LargeDog_GermanShepherd = 1743U,
				// Token: 0x040016BF RID: 5823
				Breed_LargeDog_Giant_Schnauzer = 1792U,
				// Token: 0x040016C0 RID: 5824
				Breed_LargeDog_Golden_Doodle = 1800U,
				// Token: 0x040016C1 RID: 5825
				Breed_LargeDog_GoldenRetriever = 1731U,
				// Token: 0x040016C2 RID: 5826
				Breed_LargeDog_Great_Pyranees = 1955U,
				// Token: 0x040016C3 RID: 5827
				Breed_LargeDog_GreatDane = 1734U,
				// Token: 0x040016C4 RID: 5828
				Breed_LargeDog_Greyhound = 1764U,
				// Token: 0x040016C5 RID: 5829
				Breed_LargeDog_Husky = 1744U,
				// Token: 0x040016C6 RID: 5830
				Breed_LargeDog_Ibizan = 1738U,
				// Token: 0x040016C7 RID: 5831
				Breed_LargeDog_Irish_Red_And_White_Setter = 1802U,
				// Token: 0x040016C8 RID: 5832
				Breed_LargeDog_Irish_Setter,
				// Token: 0x040016C9 RID: 5833
				Breed_LargeDog_Irish_Terrier = 1828U,
				// Token: 0x040016CA RID: 5834
				Breed_LargeDog_Irish_Wolfhound = 1827U,
				// Token: 0x040016CB RID: 5835
				Breed_LargeDog_Keeshond = 1767U,
				// Token: 0x040016CC RID: 5836
				Breed_LargeDog_Kerry_Blue_Terrier = 1956U,
				// Token: 0x040016CD RID: 5837
				Breed_LargeDog_Labradoodle,
				// Token: 0x040016CE RID: 5838
				Breed_LargeDog_Labrador_Retriever = 1768U,
				// Token: 0x040016CF RID: 5839
				Breed_LargeDog_Mastiff = 1804U,
				// Token: 0x040016D0 RID: 5840
				Breed_LargeDog_Mixed = 1928U,
				// Token: 0x040016D1 RID: 5841
				Breed_LargeDog_Newfoundland = 1769U,
				// Token: 0x040016D2 RID: 5842
				Breed_LargeDog_Norsk_Elk_Shepherd = 1958U,
				// Token: 0x040016D3 RID: 5843
				Breed_LargeDog_Old_English_Sheepdog = 1771U,
				// Token: 0x040016D4 RID: 5844
				Breed_LargeDog_Otterhound,
				// Token: 0x040016D5 RID: 5845
				Breed_LargeDog_Pharaoh_Hound = 1774U,
				// Token: 0x040016D6 RID: 5846
				Breed_LargeDog_Pitbull = 1749U,
				// Token: 0x040016D7 RID: 5847
				Breed_LargeDog_Pointer = 1775U,
				// Token: 0x040016D8 RID: 5848
				Breed_LargeDog_Polish_Lowland_Sheepdog = 1807U,
				// Token: 0x040016D9 RID: 5849
				Breed_LargeDog_Poodle = 1777U,
				// Token: 0x040016DA RID: 5850
				Breed_LargeDog_Portuguese_Water_Dog = 1791U,
				// Token: 0x040016DB RID: 5851
				Breed_LargeDog_Redbone_Coonhound = 1810U,
				// Token: 0x040016DC RID: 5852
				Breed_LargeDog_Rhodesian_Ridgeback = 1815U,
				// Token: 0x040016DD RID: 5853
				Breed_LargeDog_Rottweiler = 1779U,
				// Token: 0x040016DE RID: 5854
				Breed_LargeDog_Saint_Bernard,
				// Token: 0x040016DF RID: 5855
				Breed_LargeDog_Samoyed,
				// Token: 0x040016E0 RID: 5856
				Breed_LargeDog_Schnauzer = 1732U,
				// Token: 0x040016E1 RID: 5857
				Breed_LargeDog_Shar_Pei = 1959U,
				// Token: 0x040016E2 RID: 5858
				Breed_LargeDog_Siberian_Husky = 1812U,
				// Token: 0x040016E3 RID: 5859
				Breed_LargeDog_Tibetan_Mastiff = 1960U,
				// Token: 0x040016E4 RID: 5860
				Breed_LargeDog_Weimaraner = 1788U,
				// Token: 0x040016E5 RID: 5861
				Breed_LargeDog_Welsh_Springer_Spaniel = 1808U,
				// Token: 0x040016E6 RID: 5862
				Breed_LargeDog_Wheatens_Terrier = 1962U,
				// Token: 0x040016E7 RID: 5863
				Breed_LargeDog_Vizsla = 1809U,
				// Token: 0x040016E8 RID: 5864
				Breed_None = 1733U,
				// Token: 0x040016E9 RID: 5865
				Breed_SmallDog_Basenji = 1817U,
				// Token: 0x040016EA RID: 5866
				Breed_SmallDog_Beagle = 1739U,
				// Token: 0x040016EB RID: 5867
				Breed_SmallDog_Bichon_Frise = 1752U,
				// Token: 0x040016EC RID: 5868
				Breed_SmallDog_Bocker = 1963U,
				// Token: 0x040016ED RID: 5869
				Breed_SmallDog_Boston_Terrier = 1754U,
				// Token: 0x040016EE RID: 5870
				Breed_SmallDog_Bull_Terrier = 1829U,
				// Token: 0x040016EF RID: 5871
				Breed_SmallDog_Bulldog = 1756U,
				// Token: 0x040016F0 RID: 5872
				Breed_SmallDog_Cardigan_Welsh_Corgi = 1964U,
				// Token: 0x040016F1 RID: 5873
				Breed_SmallDog_Cavalier_King_Charles_Spaniel = 1757U,
				// Token: 0x040016F2 RID: 5874
				Breed_SmallDog_Chihuahua,
				// Token: 0x040016F3 RID: 5875
				Breed_SmallDog_Chocker_Spaniel = 1760U,
				// Token: 0x040016F4 RID: 5876
				Breed_SmallDog_Cockapoo = 1965U,
				// Token: 0x040016F5 RID: 5877
				Breed_SmallDog_Daschund,
				// Token: 0x040016F6 RID: 5878
				Breed_SmallDog_English_Cocker_Spaniel = 1818U,
				// Token: 0x040016F7 RID: 5879
				Breed_SmallDog_English_Toy_Spaniel = 1967U,
				// Token: 0x040016F8 RID: 5880
				Breed_SmallDog_Fox,
				// Token: 0x040016F9 RID: 5881
				Breed_SmallDog_French_Bulldog = 1763U,
				// Token: 0x040016FA RID: 5882
				Breed_SmallDog_Havanese = 1793U,
				// Token: 0x040016FB RID: 5883
				Breed_SmallDog_Icelandic_Sheep_Dog = 1993U,
				// Token: 0x040016FC RID: 5884
				Breed_SmallDog_Italian_Greyhound = 1825U,
				// Token: 0x040016FD RID: 5885
				Breed_SmallDog_Jack_Russel_Terrier = 1766U,
				// Token: 0x040016FE RID: 5886
				Breed_SmallDog_Lhasa_Apso = 1823U,
				// Token: 0x040016FF RID: 5887
				Breed_SmallDog_Maltese = 1943U,
				// Token: 0x04001700 RID: 5888
				Breed_SmallDog_Miniature_Pinscher = 1805U,
				// Token: 0x04001701 RID: 5889
				Breed_SmallDog_Miniature_Poodle = 1969U,
				// Token: 0x04001702 RID: 5890
				Breed_SmallDog_Miniature_Schnauzer = 1806U,
				// Token: 0x04001703 RID: 5891
				Breed_SmallDog_Mixed = 1927U,
				// Token: 0x04001704 RID: 5892
				Breed_SmallDog_Norweigian_Buhund = 1992U,
				// Token: 0x04001705 RID: 5893
				Breed_SmallDog_Papillon = 1773U,
				// Token: 0x04001706 RID: 5894
				Breed_SmallDog_Parson_Russel_Terrier = 1970U,
				// Token: 0x04001707 RID: 5895
				Breed_SmallDog_Pekingese = 1770U,
				// Token: 0x04001708 RID: 5896
				Breed_SmallDog_Pembroke_Welsh_Corgi = 1971U,
				// Token: 0x04001709 RID: 5897
				Breed_SmallDog_Pomeranian = 1776U,
				// Token: 0x0400170A RID: 5898
				Breed_SmallDog_Pug = 1778U,
				// Token: 0x0400170B RID: 5899
				Breed_SmallDog_Puggle = 1820U,
				// Token: 0x0400170C RID: 5900
				Breed_SmallDog_Schipperke = 1782U,
				// Token: 0x0400170D RID: 5901
				Breed_SmallDog_Schnoodle = 1972U,
				// Token: 0x0400170E RID: 5902
				Breed_SmallDog_Scottish_Terrier = 1783U,
				// Token: 0x0400170F RID: 5903
				Breed_SmallDog_Shetland_Sheepdog = 1811U,
				// Token: 0x04001710 RID: 5904
				Breed_SmallDog_Shiba_Inu = 1784U,
				// Token: 0x04001711 RID: 5905
				Breed_SmallDog_Shih_Tzu,
				// Token: 0x04001712 RID: 5906
				Breed_SmallDog_Silky_Terrier = 1973U,
				// Token: 0x04001713 RID: 5907
				Breed_SmallDog_Smooth_Fox_Terrier = 1813U,
				// Token: 0x04001714 RID: 5908
				Breed_SmallDog_Spitz = 1991U,
				// Token: 0x04001715 RID: 5909
				Breed_SmallDog_Staffordshire_Bull_Terrier = 1824U,
				// Token: 0x04001716 RID: 5910
				Breed_SmallDog_Standard_Schnauzer = 1786U,
				// Token: 0x04001717 RID: 5911
				Breed_SmallDog_Toy_Fox_Terrier,
				// Token: 0x04001718 RID: 5912
				Breed_SmallDog_West_Highland_White_Terrier = 1822U,
				// Token: 0x04001719 RID: 5913
				Breed_SmallDog_Whippet = 1799U,
				// Token: 0x0400171A RID: 5914
				Breed_SmallDog_Wire_Fox_Terrier = 1789U,
				// Token: 0x0400171B RID: 5915
				Breed_SmallDog_Yorkshire_Terrier,
				// Token: 0x0400171C RID: 5916
				BreedGroup_Herding = 1893U,
				// Token: 0x0400171D RID: 5917
				BreedGroup_Hound,
				// Token: 0x0400171E RID: 5918
				BreedGroup_NonSporting = 1911U,
				// Token: 0x0400171F RID: 5919
				BreedGroup_Sporting = 1895U,
				// Token: 0x04001720 RID: 5920
				BreedGroup_Terrier,
				// Token: 0x04001721 RID: 5921
				BreedGroup_Toy,
				// Token: 0x04001722 RID: 5922
				BreedGroup_Working,
				// Token: 0x04001723 RID: 5923
				Buff_AppearanceModifier_MakeUp = 2154U,
				// Token: 0x04001724 RID: 5924
				Buff_Business_CustomerStarRating = 1551U,
				// Token: 0x04001725 RID: 5925
				Buff_Business_EmployeeTraining = 1548U,
				// Token: 0x04001726 RID: 5926
				Buff_Cauldron_Potion_MakeGlowy_Failure_VFX = 49168U,
				// Token: 0x04001727 RID: 5927
				Buff_DayNightTracking = 1678U,
				// Token: 0x04001728 RID: 5928
				Buff_HumanoidRobot_MoodVFX = 65653U,
				// Token: 0x04001729 RID: 5929
				Buff_MysticalRelic_Curse = 45079U,
				// Token: 0x0400172A RID: 5930
				Buff_OwnableRestaurant_Customer = 2150U,
				// Token: 0x0400172B RID: 5931
				Buff_PossessedBuffs = 47139U,
				// Token: 0x0400172C RID: 5932
				Buff_PossessedBuffs_NoAnimate = 47148U,
				// Token: 0x0400172D RID: 5933
				Buff_Spells_CastingSpell = 49157U,
				// Token: 0x0400172E RID: 5934
				Buff_Temperature = 2481U,
				// Token: 0x0400172F RID: 5935
				Buff_VampireSunlight = 40989U,
				// Token: 0x04001730 RID: 5936
				Buff_Weather = 59431U,
				// Token: 0x04001731 RID: 5937
				Build_Arch = 561U,
				// Token: 0x04001732 RID: 5938
				Build_BBGameplayEffect_Columns_BillsDecrease = 2419U,
				// Token: 0x04001733 RID: 5939
				Build_BBGameplayEffect_Columns_BillsIncrease,
				// Token: 0x04001734 RID: 5940
				Build_BBGameplayEffect_Columns_EcoFootprint_Minus1 = 2413U,
				// Token: 0x04001735 RID: 5941
				Build_BBGameplayEffect_Columns_EcoFootprint_Minus2,
				// Token: 0x04001736 RID: 5942
				Build_BBGameplayEffect_Columns_EcoFootprint_Plus1 = 2411U,
				// Token: 0x04001737 RID: 5943
				Build_BBGameplayEffect_Columns_EcoFootprint_Plus2,
				// Token: 0x04001738 RID: 5944
				Build_BBGameplayEffect_Columns_EnvironmentScore_Minus1 = 2417U,
				// Token: 0x04001739 RID: 5945
				Build_BBGameplayEffect_Columns_EnvironmentScore_Minus2,
				// Token: 0x0400173A RID: 5946
				Build_BBGameplayEffect_Columns_EnvironmentScore_Plus1 = 2415U,
				// Token: 0x0400173B RID: 5947
				Build_BBGameplayEffect_Columns_EnvironmentScore_Plus2,
				// Token: 0x0400173C RID: 5948
				Build_BBGameplayEffect_Fences_BillsDecrease = 2409U,
				// Token: 0x0400173D RID: 5949
				Build_BBGameplayEffect_Fences_BillsIncrease,
				// Token: 0x0400173E RID: 5950
				Build_BBGameplayEffect_Fences_EcoFootprint_Minus1 = 2403U,
				// Token: 0x0400173F RID: 5951
				Build_BBGameplayEffect_Fences_EcoFootprint_Minus2,
				// Token: 0x04001740 RID: 5952
				Build_BBGameplayEffect_Fences_EcoFootprint_Plus1 = 2401U,
				// Token: 0x04001741 RID: 5953
				Build_BBGameplayEffect_Fences_EcoFootprint_Plus2,
				// Token: 0x04001742 RID: 5954
				Build_BBGameplayEffect_Fences_EnvironmentScore_Minus1 = 2407U,
				// Token: 0x04001743 RID: 5955
				Build_BBGameplayEffect_Fences_EnvironmentScore_Minus2,
				// Token: 0x04001744 RID: 5956
				Build_BBGameplayEffect_Fences_EnvironmentScore_Plus1 = 2405U,
				// Token: 0x04001745 RID: 5957
				Build_BBGameplayEffect_Fences_EnvironmentScore_Plus2,
				// Token: 0x04001746 RID: 5958
				Build_BBGameplayEffect_FloorPattern_DecreaseBills = 2329U,
				// Token: 0x04001747 RID: 5959
				Build_BBGameplayEffect_FloorPattern_EcoFootprint_Minus1 = 2308U,
				// Token: 0x04001748 RID: 5960
				Build_BBGameplayEffect_FloorPattern_EcoFootprint_Minus2,
				// Token: 0x04001749 RID: 5961
				Build_BBGameplayEffect_FloorPattern_EcoFootprint_Plus1 = 2306U,
				// Token: 0x0400174A RID: 5962
				Build_BBGameplayEffect_FloorPattern_EcoFootprint_Plus2,
				// Token: 0x0400174B RID: 5963
				Build_BBGameplayEffect_FloorPattern_EnvironmentScore_Minus1 = 2296U,
				// Token: 0x0400174C RID: 5964
				Build_BBGameplayEffect_FloorPattern_EnvironmentScore_Minus2,
				// Token: 0x0400174D RID: 5965
				Build_BBGameplayEffect_FloorPattern_EnvironmentScore_Plus1 = 2294U,
				// Token: 0x0400174E RID: 5966
				Build_BBGameplayEffect_FloorPattern_EnvironmentScore_Plus2,
				// Token: 0x0400174F RID: 5967
				Build_BBGameplayEffect_FloorPattern_IncreaseBills = 2328U,
				// Token: 0x04001750 RID: 5968
				Build_BBGameplayEffect_Object_DecreaseBills = 2327U,
				// Token: 0x04001751 RID: 5969
				Build_BBGameplayEffect_Object_EcoFootprint_Minus1 = 2300U,
				// Token: 0x04001752 RID: 5970
				Build_BBGameplayEffect_Object_EcoFootprint_Minus2,
				// Token: 0x04001753 RID: 5971
				Build_BBGameplayEffect_Object_EcoFootprint_Plus1 = 2298U,
				// Token: 0x04001754 RID: 5972
				Build_BBGameplayEffect_Object_EcoFootprint_Plus2,
				// Token: 0x04001755 RID: 5973
				Build_BBGameplayEffect_Object_EcoFootprint_PlusPark = 2444U,
				// Token: 0x04001756 RID: 5974
				Build_BBGameplayEffect_Object_EnvironmentScore_Minus1 = 2288U,
				// Token: 0x04001757 RID: 5975
				Build_BBGameplayEffect_Object_EnvironmentScore_Minus2,
				// Token: 0x04001758 RID: 5976
				Build_BBGameplayEffect_Object_EnvironmentScore_Plus1 = 2286U,
				// Token: 0x04001759 RID: 5977
				Build_BBGameplayEffect_Object_EnvironmentScore_Plus2,
				// Token: 0x0400175A RID: 5978
				Build_BBGameplayEffect_Object_IncreaseBills = 2326U,
				// Token: 0x0400175B RID: 5979
				Build_BBGameplayEffect_Object_PowerConsumer = 2314U,
				// Token: 0x0400175C RID: 5980
				Build_BBGameplayEffect_Object_PowerProducer = 2316U,
				// Token: 0x0400175D RID: 5981
				Build_BBGameplayEffect_Object_WaterConsumer = 2315U,
				// Token: 0x0400175E RID: 5982
				Build_BBGameplayEffect_Object_WaterProducer = 2317U,
				// Token: 0x0400175F RID: 5983
				Build_BBGameplayEffect_PoolSurface_PowerConsumer = 2322U,
				// Token: 0x04001760 RID: 5984
				Build_BBGameplayEffect_PoolSurface_PowerProducer = 2324U,
				// Token: 0x04001761 RID: 5985
				Build_BBGameplayEffect_PoolSurface_WaterConsumer = 2323U,
				// Token: 0x04001762 RID: 5986
				Build_BBGameplayEffect_PoolSurface_WaterProducer = 2325U,
				// Token: 0x04001763 RID: 5987
				Build_BBGameplayEffect_RoofMaterial_DecreaseBills = 2333U,
				// Token: 0x04001764 RID: 5988
				Build_BBGameplayEffect_RoofMaterial_EcoFootprint_Minus1 = 2312U,
				// Token: 0x04001765 RID: 5989
				Build_BBGameplayEffect_RoofMaterial_EcoFootprint_Minus2,
				// Token: 0x04001766 RID: 5990
				Build_BBGameplayEffect_RoofMaterial_EcoFootprint_Plus1 = 2310U,
				// Token: 0x04001767 RID: 5991
				Build_BBGameplayEffect_RoofMaterial_EcoFootprint_Plus2,
				// Token: 0x04001768 RID: 5992
				Build_BBGameplayEffect_RoofMaterial_EnvironmentScore_Minus1 = 2319U,
				// Token: 0x04001769 RID: 5993
				Build_BBGameplayEffect_RoofMaterial_EnvironmentScore_Plus1 = 2318U,
				// Token: 0x0400176A RID: 5994
				Build_BBGameplayEffect_RoofMaterial_IncreaseBills = 2332U,
				// Token: 0x0400176B RID: 5995
				Build_BBGameplayEffect_RoofMaterial_PowerProducer = 2320U,
				// Token: 0x0400176C RID: 5996
				Build_BBGameplayEffect_RoofMaterial_WaterProducer,
				// Token: 0x0400176D RID: 5997
				Build_BBGameplayEffect_WallPattern_DecreaseBills = 2331U,
				// Token: 0x0400176E RID: 5998
				Build_BBGameplayEffect_WallPattern_EcoFootprint_Minus1 = 2304U,
				// Token: 0x0400176F RID: 5999
				Build_BBGameplayEffect_WallPattern_EcoFootprint_Minus2,
				// Token: 0x04001770 RID: 6000
				Build_BBGameplayEffect_WallPattern_EcoFootprint_Plus1 = 2302U,
				// Token: 0x04001771 RID: 6001
				Build_BBGameplayEffect_WallPattern_EcoFootprint_Plus2,
				// Token: 0x04001772 RID: 6002
				Build_BBGameplayEffect_WallPattern_EnvironmentScore_Minus1 = 2292U,
				// Token: 0x04001773 RID: 6003
				Build_BBGameplayEffect_WallPattern_EnvironmentScore_Minus2,
				// Token: 0x04001774 RID: 6004
				Build_BBGameplayEffect_WallPattern_EnvironmentScore_Plus1 = 2290U,
				// Token: 0x04001775 RID: 6005
				Build_BBGameplayEffect_WallPattern_EnvironmentScore_Plus2,
				// Token: 0x04001776 RID: 6006
				Build_BBGameplayEffect_WallPattern_IncreaseBills = 2330U,
				// Token: 0x04001777 RID: 6007
				Build_Block = 548U,
				// Token: 0x04001778 RID: 6008
				Build_Block_Basement = 242U,
				// Token: 0x04001779 RID: 6009
				Build_Block_Deck = 1062U,
				// Token: 0x0400177A RID: 6010
				Build_Block_Diagonal = 1070U,
				// Token: 0x0400177B RID: 6011
				Build_Block_Fountain = 232U,
				// Token: 0x0400177C RID: 6012
				Build_Block_FountainTool,
				// Token: 0x0400177D RID: 6013
				Build_Block_NoWalls = 1064U,
				// Token: 0x0400177E RID: 6014
				Build_Block_Platform = 2491U,
				// Token: 0x0400177F RID: 6015
				Build_Block_PlatformTool,
				// Token: 0x04001780 RID: 6016
				Build_Block_Pool = 1226U,
				// Token: 0x04001781 RID: 6017
				Build_Block_PoolTool,
				// Token: 0x04001782 RID: 6018
				Build_Block_WallTool = 653U,
				// Token: 0x04001783 RID: 6019
				Build_Block_WithWalls = 1063U,
				// Token: 0x04001784 RID: 6020
				Build_Buy_Autonomy_Marker_Attractor = 1638U,
				// Token: 0x04001785 RID: 6021
				Build_Buy_NoAutonomy_Lights = 1637U,
				// Token: 0x04001786 RID: 6022
				Build_Buy_NoAutonomy_Plants = 1636U,
				// Token: 0x04001787 RID: 6023
				Build_Buy_NoAutonomy_Rugs = 1639U,
				// Token: 0x04001788 RID: 6024
				Build_Buy_NoAutonomy_Sculptures = 1634U,
				// Token: 0x04001789 RID: 6025
				Build_Buy_World_Objects = 787U,
				// Token: 0x0400178A RID: 6026
				Build_Column = 538U,
				// Token: 0x0400178B RID: 6027
				Build_Door = 535U,
				// Token: 0x0400178C RID: 6028
				Build_DoorDouble = 918U,
				// Token: 0x0400178D RID: 6029
				Build_DoorSingle = 974U,
				// Token: 0x0400178E RID: 6030
				Build_Elevator = 1611U,
				// Token: 0x0400178F RID: 6031
				Build_Fence = 544U,
				// Token: 0x04001790 RID: 6032
				Build_FloorPattern = 541U,
				// Token: 0x04001791 RID: 6033
				Build_FloorTrim = 554U,
				// Token: 0x04001792 RID: 6034
				Build_Flower = 556U,
				// Token: 0x04001793 RID: 6035
				Build_Flower_Bush = 1068U,
				// Token: 0x04001794 RID: 6036
				Build_Flower_GroundCover = 1067U,
				// Token: 0x04001795 RID: 6037
				Build_Flower_Misc = 1069U,
				// Token: 0x04001796 RID: 6038
				Build_Foundation = 552U,
				// Token: 0x04001797 RID: 6039
				Build_FountainTrim = 1081U,
				// Token: 0x04001798 RID: 6040
				Build_Frieze = 550U,
				// Token: 0x04001799 RID: 6041
				Build_Gate = 537U,
				// Token: 0x0400179A RID: 6042
				Build_GateDouble = 915U,
				// Token: 0x0400179B RID: 6043
				Build_GateSingle = 976U,
				// Token: 0x0400179C RID: 6044
				Build_Generic = 1596U,
				// Token: 0x0400179D RID: 6045
				Build_HalfWall = 1441U,
				// Token: 0x0400179E RID: 6046
				Build_HalfWallTrim,
				// Token: 0x0400179F RID: 6047
				Build_IsShellBuilding = 1574U,
				// Token: 0x040017A0 RID: 6048
				Build_Ladder = 2425U,
				// Token: 0x040017A1 RID: 6049
				Build_PlatformTrim = 2483U,
				// Token: 0x040017A2 RID: 6050
				Build_PoolStyles = 251U,
				// Token: 0x040017A3 RID: 6051
				Build_PoolTrim = 250U,
				// Token: 0x040017A4 RID: 6052
				Build_Post = 782U,
				// Token: 0x040017A5 RID: 6053
				Build_Railing = 547U,
				// Token: 0x040017A6 RID: 6054
				Build_Rock = 560U,
				// Token: 0x040017A7 RID: 6055
				Build_Roof = 540U,
				// Token: 0x040017A8 RID: 6056
				Build_RoofAttachment = 539U,
				// Token: 0x040017A9 RID: 6057
				Build_RoofAttachmentMisc = 975U,
				// Token: 0x040017AA RID: 6058
				Build_RoofChimney = 919U,
				// Token: 0x040017AB RID: 6059
				Build_RoofDiagonal = 906U,
				// Token: 0x040017AC RID: 6060
				Build_RoofOrthogonal = 977U,
				// Token: 0x040017AD RID: 6061
				Build_RoofPattern = 543U,
				// Token: 0x040017AE RID: 6062
				Build_RoofTrim = 551U,
				// Token: 0x040017AF RID: 6063
				Build_Rug = 559U,
				// Token: 0x040017B0 RID: 6064
				Build_Shrub = 557U,
				// Token: 0x040017B1 RID: 6065
				Build_Shrub_Bush = 1065U,
				// Token: 0x040017B2 RID: 6066
				Build_Shrub_Cactus,
				// Token: 0x040017B3 RID: 6067
				Build_Spandrel = 545U,
				// Token: 0x040017B4 RID: 6068
				Build_Stair,
				// Token: 0x040017B5 RID: 6069
				Build_Style = 549U,
				// Token: 0x040017B6 RID: 6070
				Build_StyleBasics = 2537U,
				// Token: 0x040017B7 RID: 6071
				Build_StyleBoho = 2534U,
				// Token: 0x040017B8 RID: 6072
				Build_StyleContemporary,
				// Token: 0x040017B9 RID: 6073
				Build_StyleCosmoluxe,
				// Token: 0x040017BA RID: 6074
				Build_StyleDoubleGallery = 2539U,
				// Token: 0x040017BB RID: 6075
				Build_StyleFrenchCountry,
				// Token: 0x040017BC RID: 6076
				Build_StyleGarden = 2549U,
				// Token: 0x040017BD RID: 6077
				Build_StyleGothicFarmhouse = 2541U,
				// Token: 0x040017BE RID: 6078
				Build_StyleIsland = 2548U,
				// Token: 0x040017BF RID: 6079
				Build_StyleMidCentury = 2555U,
				// Token: 0x040017C0 RID: 6080
				Build_StyleMission = 2542U,
				// Token: 0x040017C1 RID: 6081
				Build_StyleModern,
				// Token: 0x040017C2 RID: 6082
				Build_StylePatio = 2538U,
				// Token: 0x040017C3 RID: 6083
				Build_StyleQueenAnne = 2544U,
				// Token: 0x040017C4 RID: 6084
				Build_StyleScandinavianContemporary = 2550U,
				// Token: 0x040017C5 RID: 6085
				Build_StyleShotgun = 2545U,
				// Token: 0x040017C6 RID: 6086
				Build_StyleSuburbanContempo,
				// Token: 0x040017C7 RID: 6087
				Build_StyleTudor,
				// Token: 0x040017C8 RID: 6088
				Build_Tree = 558U,
				// Token: 0x040017C9 RID: 6089
				Build_WallAttachment = 555U,
				// Token: 0x040017CA RID: 6090
				Build_WallPattern = 542U,
				// Token: 0x040017CB RID: 6091
				Build_WeddingArch = 981U,
				// Token: 0x040017CC RID: 6092
				Build_Window = 536U,
				// Token: 0x040017CD RID: 6093
				BuyCat_CleanPower = 67591U,
				// Token: 0x040017CE RID: 6094
				BuyCat_Collection_Alien = 1044U,
				// Token: 0x040017CF RID: 6095
				BuyCat_Collection_ALL = 1053U,
				// Token: 0x040017D0 RID: 6096
				BuyCat_Collection_Capsule = 69729U,
				// Token: 0x040017D1 RID: 6097
				BuyCat_Collection_CityPoster = 55378U,
				// Token: 0x040017D2 RID: 6098
				BuyCat_Collection_Crystal = 1041U,
				// Token: 0x040017D3 RID: 6099
				BuyCat_Collection_Element,
				// Token: 0x040017D4 RID: 6100
				BuyCat_Collection_Fish = 1051U,
				// Token: 0x040017D5 RID: 6101
				BuyCat_Collection_Fossil = 1043U,
				// Token: 0x040017D6 RID: 6102
				BuyCat_Collection_Frog = 1052U,
				// Token: 0x040017D7 RID: 6103
				BuyCat_Collection_Gachapon = 69728U,
				// Token: 0x040017D8 RID: 6104
				BuyCat_Collection_Gardening = 1159U,
				// Token: 0x040017D9 RID: 6105
				BuyCat_Collection_Metal = 1045U,
				// Token: 0x040017DA RID: 6106
				BuyCat_Collection_MySim,
				// Token: 0x040017DB RID: 6107
				BuyCat_Collection_Postcard = 1049U,
				// Token: 0x040017DC RID: 6108
				BuyCat_Collection_Slide = 1048U,
				// Token: 0x040017DD RID: 6109
				BuyCat_Collection_Snowglobe = 55377U,
				// Token: 0x040017DE RID: 6110
				BuyCat_Collection_SpacePrint = 1047U,
				// Token: 0x040017DF RID: 6111
				BuyCat_Collection_SpaceRock = 1050U,
				// Token: 0x040017E0 RID: 6112
				BuyCat_Collection_Treasure = 2043U,
				// Token: 0x040017E1 RID: 6113
				BuyCat_Columns = 429U,
				// Token: 0x040017E2 RID: 6114
				BuyCat_Community = 1352U,
				// Token: 0x040017E3 RID: 6115
				BuyCat_Easel = 440U,
				// Token: 0x040017E4 RID: 6116
				BuyCat_Holiday_All = 2084U,
				// Token: 0x040017E5 RID: 6117
				BuyCat_Holiday_Decor_All,
				// Token: 0x040017E6 RID: 6118
				BuyCat_Instrument = 441U,
				// Token: 0x040017E7 RID: 6119
				BuyCat_LotReq_Elevator = 55374U,
				// Token: 0x040017E8 RID: 6120
				BuyCat_LotReq_Elevator_BG = 2240U,
				// Token: 0x040017E9 RID: 6121
				BuyCat_LotReq_Mailbox = 55375U,
				// Token: 0x040017EA RID: 6122
				BuyCat_LotReq_Mailbox_BG = 2241U,
				// Token: 0x040017EB RID: 6123
				BuyCat_LotReq_TrashChute = 55376U,
				// Token: 0x040017EC RID: 6124
				BuyCat_LotReq_TrashChute_BG = 2242U,
				// Token: 0x040017ED RID: 6125
				BuyCat_OTG_Appliances = 2380U,
				// Token: 0x040017EE RID: 6126
				BuyCat_OTG_Crafting,
				// Token: 0x040017EF RID: 6127
				BuyCat_OTG_Lighting,
				// Token: 0x040017F0 RID: 6128
				BuyCat_OTG_Misc,
				// Token: 0x040017F1 RID: 6129
				BuyCat_OTG_OutdoorActivities,
				// Token: 0x040017F2 RID: 6130
				BuyCat_OTG_Plumbing,
				// Token: 0x040017F3 RID: 6131
				BuyCat_Painting = 446U,
				// Token: 0x040017F4 RID: 6132
				BuyCat_Shareable = 1261U,
				// Token: 0x040017F5 RID: 6133
				BuyCat_SpanrelsFriezesTrim = 430U,
				// Token: 0x040017F6 RID: 6134
				BuyCat_Venue_ArtsCenter = 1604U,
				// Token: 0x040017F7 RID: 6135
				BuyCat_Venue_ArtsCommons = 2273U,
				// Token: 0x040017F8 RID: 6136
				BuyCat_Venue_Bar = 1353U,
				// Token: 0x040017F9 RID: 6137
				BuyCat_Venue_Beach = 2199U,
				// Token: 0x040017FA RID: 6138
				BuyCat_Venue_Bluffs = 24612U,
				// Token: 0x040017FB RID: 6139
				BuyCat_Venue_Cafe = 24578U,
				// Token: 0x040017FC RID: 6140
				BuyCat_Venue_Chalet = 24611U,
				// Token: 0x040017FD RID: 6141
				BuyCat_Venue_Club = 1354U,
				// Token: 0x040017FE RID: 6142
				BuyCat_Venue_CommunitySpace_Default = 2438U,
				// Token: 0x040017FF RID: 6143
				BuyCat_Venue_CommunitySpace_Garden = 2440U,
				// Token: 0x04001800 RID: 6144
				BuyCat_Venue_CommunitySpace_MakerSpace = 2439U,
				// Token: 0x04001801 RID: 6145
				BuyCat_Venue_CommunitySpace_Marketplace = 2441U,
				// Token: 0x04001802 RID: 6146
				BuyCat_Venue_DoctorClinic = 1362U,
				// Token: 0x04001803 RID: 6147
				BuyCat_Venue_ForestPark = 1355U,
				// Token: 0x04001804 RID: 6148
				BuyCat_Venue_Gym,
				// Token: 0x04001805 RID: 6149
				BuyCat_Venue_Karaoke = 1579U,
				// Token: 0x04001806 RID: 6150
				BuyCat_Venue_Library = 1357U,
				// Token: 0x04001807 RID: 6151
				BuyCat_Venue_Lounge,
				// Token: 0x04001808 RID: 6152
				BuyCat_Venue_Museum,
				// Token: 0x04001809 RID: 6153
				BuyCat_Venue_Onsen = 69662U,
				// Token: 0x0400180A RID: 6154
				BuyCat_Venue_Park = 1360U,
				// Token: 0x0400180B RID: 6155
				BuyCat_Venue_Penthouse = 55373U,
				// Token: 0x0400180C RID: 6156
				BuyCat_Venue_Penthouse_BG = 2239U,
				// Token: 0x0400180D RID: 6157
				BuyCat_Venue_PoliceStation = 1363U,
				// Token: 0x0400180E RID: 6158
				BuyCat_Venue_Pool = 1459U,
				// Token: 0x0400180F RID: 6159
				BuyCat_Venue_RelaxationCenter = 18436U,
				// Token: 0x04001810 RID: 6160
				BuyCat_Venue_Restaurant = 26625U,
				// Token: 0x04001811 RID: 6161
				BuyCat_Venue_Retail = 1361U,
				// Token: 0x04001812 RID: 6162
				BuyCat_Venue_Ruins = 24613U,
				// Token: 0x04001813 RID: 6163
				BuyCat_Venue_ScienceCommons = 2272U,
				// Token: 0x04001814 RID: 6164
				BuyCat_Venue_ScientistLab = 1364U,
				// Token: 0x04001815 RID: 6165
				BuyCat_Venue_StarGarden = 1580U,
				// Token: 0x04001816 RID: 6166
				BuyCat_Venue_UniversityHousing = 2229U,
				// Token: 0x04001817 RID: 6167
				BuyCat_Venue_Vet = 57401U,
				// Token: 0x04001818 RID: 6168
				BuyCat_Windows = 428U,
				// Token: 0x04001819 RID: 6169
				BuyCatEE_ActiveActivity = 970U,
				// Token: 0x0400181A RID: 6170
				BuyCatEE_Alarm = 169U,
				// Token: 0x0400181B RID: 6171
				BuyCatEE_Audio = 163U,
				// Token: 0x0400181C RID: 6172
				BuyCatEE_Bar = 176U,
				// Token: 0x0400181D RID: 6173
				BuyCatEE_Basketball = 456U,
				// Token: 0x0400181E RID: 6174
				BuyCatEE_Chess_Table,
				// Token: 0x0400181F RID: 6175
				BuyCatEE_Clock = 171U,
				// Token: 0x04001820 RID: 6176
				BuyCatEE_Computer = 162U,
				// Token: 0x04001821 RID: 6177
				BuyCatEE_CreativeActivity = 968U,
				// Token: 0x04001822 RID: 6178
				BuyCatEE_Gardening = 2075U,
				// Token: 0x04001823 RID: 6179
				BuyCatEE_HobbySkill = 165U,
				// Token: 0x04001824 RID: 6180
				BuyCatEE_IndoorActivity = 173U,
				// Token: 0x04001825 RID: 6181
				BuyCatEE_KidActivity,
				// Token: 0x04001826 RID: 6182
				BuyCatEE_KidFurniture = 167U,
				// Token: 0x04001827 RID: 6183
				BuyCatEE_KidToy,
				// Token: 0x04001828 RID: 6184
				BuyCatEE_KnowledgeActivity = 969U,
				// Token: 0x04001829 RID: 6185
				BuyCatEE_MiscElectronics = 177U,
				// Token: 0x0400182A RID: 6186
				BuyCatEE_MiscEntertainment,
				// Token: 0x0400182B RID: 6187
				BuyCatEE_MiscKids,
				// Token: 0x0400182C RID: 6188
				BuyCatEE_MonkeyBars = 458U,
				// Token: 0x0400182D RID: 6189
				BuyCatEE_OutdoorActivity = 175U,
				// Token: 0x0400182E RID: 6190
				BuyCatEE_Party = 166U,
				// Token: 0x0400182F RID: 6191
				BuyCatEE_PetActivityToys = 2014U,
				// Token: 0x04001830 RID: 6192
				BuyCatEE_PetMisc = 1948U,
				// Token: 0x04001831 RID: 6193
				BuyCatEE_PetToys = 1944U,
				// Token: 0x04001832 RID: 6194
				BuyCatEE_PetVet = 1947U,
				// Token: 0x04001833 RID: 6195
				BuyCatEE_Toddlers = 172U,
				// Token: 0x04001834 RID: 6196
				BuyCatEE_Transportation = 2237U,
				// Token: 0x04001835 RID: 6197
				BuyCatEE_TV = 161U,
				// Token: 0x04001836 RID: 6198
				BuyCatEE_TVSets = 164U,
				// Token: 0x04001837 RID: 6199
				BuyCatEE_TVStand = 1122U,
				// Token: 0x04001838 RID: 6200
				BuyCatEE_VideoGameConsole = 55356U,
				// Token: 0x04001839 RID: 6201
				BuyCatLD_Awning = 979U,
				// Token: 0x0400183A RID: 6202
				BuyCatLD_BathroomAccent = 194U,
				// Token: 0x0400183B RID: 6203
				BuyCatLD_CeilingDecoration = 2188U,
				// Token: 0x0400183C RID: 6204
				BuyCatLD_CeilingLight = 205U,
				// Token: 0x0400183D RID: 6205
				BuyCatLD_Clutter = 823U,
				// Token: 0x0400183E RID: 6206
				BuyCatLD_CurtainBlind = 978U,
				// Token: 0x0400183F RID: 6207
				BuyCatLD_Fireplace = 785U,
				// Token: 0x04001840 RID: 6208
				BuyCatLD_FloorLamp = 204U,
				// Token: 0x04001841 RID: 6209
				BuyCatLD_FountainDecoration = 199U,
				// Token: 0x04001842 RID: 6210
				BuyCatLD_FountainEmitter = 231U,
				// Token: 0x04001843 RID: 6211
				BuyCatLD_FountainObjects = 252U,
				// Token: 0x04001844 RID: 6212
				BuyCatLD_KidDecoration = 196U,
				// Token: 0x04001845 RID: 6213
				BuyCatLD_LawnOrnament = 195U,
				// Token: 0x04001846 RID: 6214
				BuyCatLD_Mirror = 207U,
				// Token: 0x04001847 RID: 6215
				BuyCatLD_MirrorFreestanding = 965U,
				// Token: 0x04001848 RID: 6216
				BuyCatLD_MirrorWall = 964U,
				// Token: 0x04001849 RID: 6217
				BuyCatLD_MiscDecoration = 209U,
				// Token: 0x0400184A RID: 6218
				BuyCatLD_MiscLight = 208U,
				// Token: 0x0400184B RID: 6219
				BuyCatLD_NightLight = 1718U,
				// Token: 0x0400184C RID: 6220
				BuyCatLD_OutdoorLight = 206U,
				// Token: 0x0400184D RID: 6221
				BuyCatLD_Plant = 202U,
				// Token: 0x0400184E RID: 6222
				BuyCatLD_PoolDecorations = 1246U,
				// Token: 0x0400184F RID: 6223
				BuyCatLD_PoolObjects = 1228U,
				// Token: 0x04001850 RID: 6224
				BuyCatLD_PoolObjectsInventoryable = 2211U,
				// Token: 0x04001851 RID: 6225
				BuyCatLD_Rug = 198U,
				// Token: 0x04001852 RID: 6226
				BuyCatLD_RugManaged = 1496U,
				// Token: 0x04001853 RID: 6227
				BuyCatLD_Sculpture = 200U,
				// Token: 0x04001854 RID: 6228
				BuyCatLD_TableLamp = 203U,
				// Token: 0x04001855 RID: 6229
				BuyCatLD_WallDecoration = 201U,
				// Token: 0x04001856 RID: 6230
				BuyCatLD_WallLight = 310U,
				// Token: 0x04001857 RID: 6231
				BuyCatLD_WallSculpture = 824U,
				// Token: 0x04001858 RID: 6232
				BuyCatLD_WindowTreatment = 197U,
				// Token: 0x04001859 RID: 6233
				BuyCatMAG_Bathroom = 271U,
				// Token: 0x0400185A RID: 6234
				BuyCatMAG_Bedroom,
				// Token: 0x0400185B RID: 6235
				BuyCatMAG_Career = 468U,
				// Token: 0x0400185C RID: 6236
				BuyCatMAG_DiningRoom = 273U,
				// Token: 0x0400185D RID: 6237
				BuyCatMAG_Kids = 864U,
				// Token: 0x0400185E RID: 6238
				BuyCatMAG_Kitchen = 274U,
				// Token: 0x0400185F RID: 6239
				BuyCatMAG_LivingRoom = 270U,
				// Token: 0x04001860 RID: 6240
				BuyCatMAG_Misc = 407U,
				// Token: 0x04001861 RID: 6241
				BuyCatMAG_Outdoor = 275U,
				// Token: 0x04001862 RID: 6242
				BuyCatMAG_Study,
				// Token: 0x04001863 RID: 6243
				BuyCatPA_CoffeeMaker = 966U,
				// Token: 0x04001864 RID: 6244
				BuyCatPA_Disposable = 188U,
				// Token: 0x04001865 RID: 6245
				BuyCatPA_DisposalIndoor = 972U,
				// Token: 0x04001866 RID: 6246
				BuyCatPA_DisposalOutdoor,
				// Token: 0x04001867 RID: 6247
				BuyCatPA_LargeAppliance = 185U,
				// Token: 0x04001868 RID: 6248
				BuyCatPA_LitterBox = 1978U,
				// Token: 0x04001869 RID: 6249
				BuyCatPA_Microwave = 967U,
				// Token: 0x0400186A RID: 6250
				BuyCatPA_MiscAppliance = 193U,
				// Token: 0x0400186B RID: 6251
				BuyCatPA_MiscPlumbing = 192U,
				// Token: 0x0400186C RID: 6252
				BuyCatPA_MiscSmallAppliance = 191U,
				// Token: 0x0400186D RID: 6253
				BuyCatPA_OutdoorCooking = 190U,
				// Token: 0x0400186E RID: 6254
				BuyCatPA_PetCare = 1945U,
				// Token: 0x0400186F RID: 6255
				BuyCatPA_PetFood = 1976U,
				// Token: 0x04001870 RID: 6256
				BuyCatPA_PublicRestroom = 2042U,
				// Token: 0x04001871 RID: 6257
				BuyCatPA_Refrigerator = 189U,
				// Token: 0x04001872 RID: 6258
				BuyCatPA_Shower = 183U,
				// Token: 0x04001873 RID: 6259
				BuyCatPA_Sink = 180U,
				// Token: 0x04001874 RID: 6260
				BuyCatPA_SinkCounter = 920U,
				// Token: 0x04001875 RID: 6261
				BuyCatPA_SinkFreestanding = 182U,
				// Token: 0x04001876 RID: 6262
				BuyCatPA_SmallAppliance = 186U,
				// Token: 0x04001877 RID: 6263
				BuyCatPA_Stove,
				// Token: 0x04001878 RID: 6264
				BuyCatPA_StoveHood = 913U,
				// Token: 0x04001879 RID: 6265
				BuyCatPA_Toilet = 181U,
				// Token: 0x0400187A RID: 6266
				BuyCatPA_Tub = 184U,
				// Token: 0x0400187B RID: 6267
				BuyCatSS_AccentTable = 1123U,
				// Token: 0x0400187C RID: 6268
				BuyCatSS_Barstool = 224U,
				// Token: 0x0400187D RID: 6269
				BuyCatSS_Bed,
				// Token: 0x0400187E RID: 6270
				BuyCatSS_BedDouble = 914U,
				// Token: 0x0400187F RID: 6271
				BuyCatSS_BedSingle = 971U,
				// Token: 0x04001880 RID: 6272
				BuyCatSS_Bookshelf = 226U,
				// Token: 0x04001881 RID: 6273
				BuyCatSS_BunkBed = 2526U,
				// Token: 0x04001882 RID: 6274
				BuyCatSS_Cabinet = 211U,
				// Token: 0x04001883 RID: 6275
				BuyCatSS_CoffeeTable = 214U,
				// Token: 0x04001884 RID: 6276
				BuyCatSS_Counter = 210U,
				// Token: 0x04001885 RID: 6277
				BuyCatSS_Desk = 215U,
				// Token: 0x04001886 RID: 6278
				BuyCatSS_DeskChair = 222U,
				// Token: 0x04001887 RID: 6279
				BuyCatSS_DiningChair = 217U,
				// Token: 0x04001888 RID: 6280
				BuyCatSS_DiningTable = 212U,
				// Token: 0x04001889 RID: 6281
				BuyCatSS_DiningTableLong = 963U,
				// Token: 0x0400188A RID: 6282
				BuyCatSS_DiningTableShort = 962U,
				// Token: 0x0400188B RID: 6283
				BuyCatSS_Display = 216U,
				// Token: 0x0400188C RID: 6284
				BuyCatSS_Dresser = 227U,
				// Token: 0x0400188D RID: 6285
				BuyCatSS_Dresser_Clothes = 2553U,
				// Token: 0x0400188E RID: 6286
				BuyCatSS_ElementDisplay = 1072U,
				// Token: 0x0400188F RID: 6287
				BuyCatSS_EndTable = 213U,
				// Token: 0x04001890 RID: 6288
				BuyCatSS_HallwayTable = 1126U,
				// Token: 0x04001891 RID: 6289
				BuyCatSS_LivingChair = 221U,
				// Token: 0x04001892 RID: 6290
				BuyCatSS_LoveSeat = 219U,
				// Token: 0x04001893 RID: 6291
				BuyCatSS_MiscComfort = 229U,
				// Token: 0x04001894 RID: 6292
				BuyCatSS_MiscStorage,
				// Token: 0x04001895 RID: 6293
				BuyCatSS_MiscSurface = 228U,
				// Token: 0x04001896 RID: 6294
				BuyCatSS_ModularShelving = 2527U,
				// Token: 0x04001897 RID: 6295
				BuyCatSS_OutdoorBench = 916U,
				// Token: 0x04001898 RID: 6296
				BuyCatSS_OutdoorChair = 220U,
				// Token: 0x04001899 RID: 6297
				BuyCatSS_OutdoorSeating = 223U,
				// Token: 0x0400189A RID: 6298
				BuyCatSS_OutdoorTable = 917U,
				// Token: 0x0400189B RID: 6299
				BuyCatSS_PetBed = 1977U,
				// Token: 0x0400189C RID: 6300
				BuyCatSS_PetFurniture = 1946U,
				// Token: 0x0400189D RID: 6301
				BuyCatSS_PostcardBoard = 1071U,
				// Token: 0x0400189E RID: 6302
				BuyCatSS_ScratchingPost = 1979U,
				// Token: 0x0400189F RID: 6303
				BuyCatSS_Sofa = 218U,
				// Token: 0x040018A0 RID: 6304
				BuyTag_DisablePlacementOutline = 43017U,
				// Token: 0x040018A1 RID: 6305
				BuyTag_NotAutoCounterAppliance = 2274U,
				// Token: 0x040018A2 RID: 6306
				BuyTag_ShowIfWallsCutaway = 1492U,
				// Token: 0x040018A3 RID: 6307
				CAS_Story_Add_Career = 2213U,
				// Token: 0x040018A4 RID: 6308
				CAS_Story_Add_Funds = 2212U,
				// Token: 0x040018A5 RID: 6309
				CAS_Story_Add_Occult = 2215U,
				// Token: 0x040018A6 RID: 6310
				CAS_Story_Add_Skill = 2214U,
				// Token: 0x040018A7 RID: 6311
				CoatPattern_Bicolor = 2004U,
				// Token: 0x040018A8 RID: 6312
				CoatPattern_Brindle = 1995U,
				// Token: 0x040018A9 RID: 6313
				CoatPattern_Calico = 2006U,
				// Token: 0x040018AA RID: 6314
				CoatPattern_Colorpoint = 2019U,
				// Token: 0x040018AB RID: 6315
				CoatPattern_Fantasy = 2009U,
				// Token: 0x040018AC RID: 6316
				CoatPattern_Harlequin = 2022U,
				// Token: 0x040018AD RID: 6317
				CoatPattern_Mask = 2001U,
				// Token: 0x040018AE RID: 6318
				CoatPattern_Merle = 1999U,
				// Token: 0x040018AF RID: 6319
				CoatPattern_Rosette = 2008U,
				// Token: 0x040018B0 RID: 6320
				CoatPattern_Sable = 1996U,
				// Token: 0x040018B1 RID: 6321
				CoatPattern_Saddle = 2000U,
				// Token: 0x040018B2 RID: 6322
				CoatPattern_Solid = 1994U,
				// Token: 0x040018B3 RID: 6323
				CoatPattern_Speckled = 1998U,
				// Token: 0x040018B4 RID: 6324
				CoatPattern_Spotted = 1997U,
				// Token: 0x040018B5 RID: 6325
				CoatPattern_Striped = 2003U,
				// Token: 0x040018B6 RID: 6326
				CoatPattern_Tabby = 2002U,
				// Token: 0x040018B7 RID: 6327
				CoatPattern_Tipped = 2007U,
				// Token: 0x040018B8 RID: 6328
				CoatPattern_Tortoiseshell = 2005U,
				// Token: 0x040018B9 RID: 6329
				CoatPattern_TriColor = 2021U,
				// Token: 0x040018BA RID: 6330
				Color_Black = 93U,
				// Token: 0x040018BB RID: 6331
				Color_Blue = 68U,
				// Token: 0x040018BC RID: 6332
				Color_Brown = 91U,
				// Token: 0x040018BD RID: 6333
				Color_BrownLight = 293U,
				// Token: 0x040018BE RID: 6334
				Color_DarkBrown = 90U,
				// Token: 0x040018BF RID: 6335
				Color_Gray = 92U,
				// Token: 0x040018C0 RID: 6336
				Color_Green = 69U,
				// Token: 0x040018C1 RID: 6337
				Color_Orange = 95U,
				// Token: 0x040018C2 RID: 6338
				Color_Pink = 106U,
				// Token: 0x040018C3 RID: 6339
				Color_Purple,
				// Token: 0x040018C4 RID: 6340
				Color_Red = 65U,
				// Token: 0x040018C5 RID: 6341
				Color_White = 105U,
				// Token: 0x040018C6 RID: 6342
				Color_Yellow = 104U,
				// Token: 0x040018C7 RID: 6343
				ColorPalette_EarthTones = 280U,
				// Token: 0x040018C8 RID: 6344
				ColorPalette_GothRockPunk = 288U,
				// Token: 0x040018C9 RID: 6345
				ColorPalette_GrayscaleDark = 282U,
				// Token: 0x040018CA RID: 6346
				ColorPalette_GrayscaleLight,
				// Token: 0x040018CB RID: 6347
				ColorPalette_Jewel = 141U,
				// Token: 0x040018CC RID: 6348
				ColorPalette_Spring = 285U,
				// Token: 0x040018CD RID: 6349
				ColorPalette_Summer,
				// Token: 0x040018CE RID: 6350
				ColorPalette_Winter,
				// Token: 0x040018CF RID: 6351
				Crafting_Gardening = 424U,
				// Token: 0x040018D0 RID: 6352
				Crafting_Song = 447U,
				// Token: 0x040018D1 RID: 6353
				DogSize_Large = 1892U,
				// Token: 0x040018D2 RID: 6354
				DogSize_Small = 1891U,
				// Token: 0x040018D3 RID: 6355
				Drink_Alcoholic = 264U,
				// Token: 0x040018D4 RID: 6356
				Drink_Any = 269U,
				// Token: 0x040018D5 RID: 6357
				Drink_Crafted = 351U,
				// Token: 0x040018D6 RID: 6358
				Drink_Crafted_Coffee_Tea = 459U,
				// Token: 0x040018D7 RID: 6359
				Drink_Fizzy = 18451U,
				// Token: 0x040018D8 RID: 6360
				Drink_Kava = 63538U,
				// Token: 0x040018D9 RID: 6361
				Drink_NonAlcoholic = 265U,
				// Token: 0x040018DA RID: 6362
				Drink_Serum = 12290U,
				// Token: 0x040018DB RID: 6363
				Drink_SpaceEnergy = 691U,
				// Token: 0x040018DC RID: 6364
				Drink_Toddler = 1661U,
				// Token: 0x040018DD RID: 6365
				Drinks_Any = 159U,
				// Token: 0x040018DE RID: 6366
				Drinks_Bar_Alcoholic = 157U,
				// Token: 0x040018DF RID: 6367
				Drinks_Bar_Any = 160U,
				// Token: 0x040018E0 RID: 6368
				Drinks_Bar_NonAlcoholic = 158U,
				// Token: 0x040018E1 RID: 6369
				DuplicateAffordance_Counter = 57450U,
				// Token: 0x040018E2 RID: 6370
				DuplicateAffordance_MagicHQ_BeAmazed = 49184U,
				// Token: 0x040018E3 RID: 6371
				DuplicateAffordance_MagicHQ_BrowseBooks,
				// Token: 0x040018E4 RID: 6372
				DuplicateAffordance_Mirror = 2172U,
				// Token: 0x040018E5 RID: 6373
				DuplicateAffordance_Read = 1173U,
				// Token: 0x040018E6 RID: 6374
				DuplicateAffordance_Scratch = 57449U,
				// Token: 0x040018E7 RID: 6375
				DuplicateAffordance_Sink = 2096U,
				// Token: 0x040018E8 RID: 6376
				DuplicateAffordance_ToysPickUp = 1697U,
				// Token: 0x040018E9 RID: 6377
				DuplicateAffordance_ToysPlayWith = 1696U,
				// Token: 0x040018EA RID: 6378
				DuplicateAffordance_TraitInteractions = 1174U,
				// Token: 0x040018EB RID: 6379
				DuplicateAffordance_View,
				// Token: 0x040018EC RID: 6380
				Ears_Down = 57347U,
				// Token: 0x040018ED RID: 6381
				Ears_Up,
				// Token: 0x040018EE RID: 6382
				Ensemble_FinOrangeRed = 63537U,
				// Token: 0x040018EF RID: 6383
				Ensemble_FinPastel = 63535U,
				// Token: 0x040018F0 RID: 6384
				Ensemble_FinTealPurple,
				// Token: 0x040018F1 RID: 6385
				Ensemble_SwimBandeauBlack = 1257U,
				// Token: 0x040018F2 RID: 6386
				Ensemble_SwimBandeauBlue,
				// Token: 0x040018F3 RID: 6387
				Ensemble_SwimBandeauCoral = 1251U,
				// Token: 0x040018F4 RID: 6388
				Ensemble_SwimBandeauYellow = 1254U,
				// Token: 0x040018F5 RID: 6389
				Ensemble_SwimHalterBlack = 1239U,
				// Token: 0x040018F6 RID: 6390
				Ensemble_SwimHalterLime = 1255U,
				// Token: 0x040018F7 RID: 6391
				Ensemble_SwimHalterRed = 1252U,
				// Token: 0x040018F8 RID: 6392
				Ensemble_SwimHalterWhite = 1256U,
				// Token: 0x040018F9 RID: 6393
				Ensemble_SwimMetalBrown = 1259U,
				// Token: 0x040018FA RID: 6394
				Ensemble_SwimMetalGreen,
				// Token: 0x040018FB RID: 6395
				Ensemble_SwimMetalPink = 1250U,
				// Token: 0x040018FC RID: 6396
				Ensemble_SwimMetalTeal = 1253U,
				// Token: 0x040018FD RID: 6397
				EyebrowShape_Arched = 1060U,
				// Token: 0x040018FE RID: 6398
				EyebrowShape_Curved = 1059U,
				// Token: 0x040018FF RID: 6399
				EyebrowShape_Straight = 1058U,
				// Token: 0x04001900 RID: 6400
				EyebrowThickness_Bald = 12393U,
				// Token: 0x04001901 RID: 6401
				EyebrowThickness_Bushy = 1054U,
				// Token: 0x04001902 RID: 6402
				EyebrowThickness_Medium = 1057U,
				// Token: 0x04001903 RID: 6403
				EyebrowThickness_Sparse = 1056U,
				// Token: 0x04001904 RID: 6404
				EyebrowThickness_Thin = 1055U,
				// Token: 0x04001905 RID: 6405
				EyeColor_Alien = 12392U,
				// Token: 0x04001906 RID: 6406
				EyeColor_Amber = 114U,
				// Token: 0x04001907 RID: 6407
				EyeColor_Aqua,
				// Token: 0x04001908 RID: 6408
				EyeColor_Black,
				// Token: 0x04001909 RID: 6409
				EyeColor_Blue,
				// Token: 0x0400190A RID: 6410
				EyeColor_BlueGray = 1884U,
				// Token: 0x0400190B RID: 6411
				EyeColor_Brown = 118U,
				// Token: 0x0400190C RID: 6412
				EyeColor_DarkBrown,
				// Token: 0x0400190D RID: 6413
				EyeColor_Golden = 423U,
				// Token: 0x0400190E RID: 6414
				EyeColor_Gray = 120U,
				// Token: 0x0400190F RID: 6415
				EyeColor_Green,
				// Token: 0x04001910 RID: 6416
				EyeColor_Hazel = 421U,
				// Token: 0x04001911 RID: 6417
				EyeColor_HazelBlue = 122U,
				// Token: 0x04001912 RID: 6418
				EyeColor_HazelGreen,
				// Token: 0x04001913 RID: 6419
				EyeColor_Honey = 422U,
				// Token: 0x04001914 RID: 6420
				EyeColor_LightBlue = 124U,
				// Token: 0x04001915 RID: 6421
				EyeColor_LightBrown,
				// Token: 0x04001916 RID: 6422
				EyeColor_LightGreen,
				// Token: 0x04001917 RID: 6423
				EyeColor_LightYellow = 1880U,
				// Token: 0x04001918 RID: 6424
				EyeColor_VampireBlack = 40988U,
				// Token: 0x04001919 RID: 6425
				EyeColor_VampireBlueBlack = 40980U,
				// Token: 0x0400191A RID: 6426
				EyeColor_VampireGreen,
				// Token: 0x0400191B RID: 6427
				EyeColor_VampireIceBlue,
				// Token: 0x0400191C RID: 6428
				EyeColor_VampirePurple,
				// Token: 0x0400191D RID: 6429
				EyeColor_VampireRed,
				// Token: 0x0400191E RID: 6430
				EyeColor_VampireRedBlack,
				// Token: 0x0400191F RID: 6431
				EyeColor_VampireWhite,
				// Token: 0x04001920 RID: 6432
				EyeColor_VampireYellow,
				// Token: 0x04001921 RID: 6433
				EyeColor_Yellow = 1879U,
				// Token: 0x04001922 RID: 6434
				EyeColor_YellowGreen = 1885U,
				// Token: 0x04001923 RID: 6435
				Fabric_Cotton = 532U,
				// Token: 0x04001924 RID: 6436
				Fabric_Denim = 587U,
				// Token: 0x04001925 RID: 6437
				Fabric_Leather = 531U,
				// Token: 0x04001926 RID: 6438
				Fabric_Metal = 932U,
				// Token: 0x04001927 RID: 6439
				Fabric_Silk = 585U,
				// Token: 0x04001928 RID: 6440
				Fabric_Silver = 933U,
				// Token: 0x04001929 RID: 6441
				Fabric_Synthetic = 584U,
				// Token: 0x0400192A RID: 6442
				Fabric_Wool = 586U,
				// Token: 0x0400192B RID: 6443
				FaceDetail_FrecklesNose = 1651U,
				// Token: 0x0400192C RID: 6444
				FaceDetail_FrecklesSpread = 1650U,
				// Token: 0x0400192D RID: 6445
				FaceDetail_TeethBuck = 1647U,
				// Token: 0x0400192E RID: 6446
				FaceDetail_TeethGap = 1649U,
				// Token: 0x0400192F RID: 6447
				FaceDetail_TeethSnaggle = 1648U,
				// Token: 0x04001930 RID: 6448
				FaceDetail_TeethStraight = 1652U,
				// Token: 0x04001931 RID: 6449
				FacialHair_Beard = 378U,
				// Token: 0x04001932 RID: 6450
				FacialHair_Goatee,
				// Token: 0x04001933 RID: 6451
				FacialHair_Mustache,
				// Token: 0x04001934 RID: 6452
				Fire_Flammable_AutoAdded = 1925U,
				// Token: 0x04001935 RID: 6453
				FloorPattern_Carpet = 298U,
				// Token: 0x04001936 RID: 6454
				FloorPattern_DirtSand = 309U,
				// Token: 0x04001937 RID: 6455
				FloorPattern_Flowers = 308U,
				// Token: 0x04001938 RID: 6456
				FloorPattern_Grass = 307U,
				// Token: 0x04001939 RID: 6457
				FloorPattern_Linoleum = 303U,
				// Token: 0x0400193A RID: 6458
				FloorPattern_Masonry = 302U,
				// Token: 0x0400193B RID: 6459
				FloorPattern_Metal = 304U,
				// Token: 0x0400193C RID: 6460
				FloorPattern_Misc,
				// Token: 0x0400193D RID: 6461
				FloorPattern_Outdoor,
				// Token: 0x0400193E RID: 6462
				FloorPattern_Stone = 301U,
				// Token: 0x0400193F RID: 6463
				FloorPattern_Tile = 299U,
				// Token: 0x04001940 RID: 6464
				FloorPattern_Wood,
				// Token: 0x04001941 RID: 6465
				Food_Any = 268U,
				// Token: 0x04001942 RID: 6466
				Food_Aromatic = 1614U,
				// Token: 0x04001943 RID: 6467
				Food_Batuu = 51240U,
				// Token: 0x04001944 RID: 6468
				Food_BeachBum = 2203U,
				// Token: 0x04001945 RID: 6469
				Food_Burrito = 1602U,
				// Token: 0x04001946 RID: 6470
				Food_CafeteriaStation_Pranked = 65551U,
				// Token: 0x04001947 RID: 6471
				Food_Campfire = 10263U,
				// Token: 0x04001948 RID: 6472
				Food_Chopsticks = 55379U,
				// Token: 0x04001949 RID: 6473
				Food_Dessert = 359U,
				// Token: 0x0400194A RID: 6474
				Food_Dish_Bowl = 1980U,
				// Token: 0x0400194B RID: 6475
				Food_Dish_Plate,
				// Token: 0x0400194C RID: 6476
				Food_Dish_ShortFood = 1988U,
				// Token: 0x0400194D RID: 6477
				Food_Dish_TallFood = 1987U,
				// Token: 0x0400194E RID: 6478
				Food_EatWithToddlerSized = 1675U,
				// Token: 0x0400194F RID: 6479
				Food_EatWithUtensil = 1674U,
				// Token: 0x04001950 RID: 6480
				Food_FoodBlob_Applesauce_LightBrown = 1687U,
				// Token: 0x04001951 RID: 6481
				Food_FoodBlob_FruitSalad_RedYellowBlue,
				// Token: 0x04001952 RID: 6482
				Food_FoodBlob_MacCheese_YellowSpotty,
				// Token: 0x04001953 RID: 6483
				Food_FoodBlob_Minestrone_ReddishBrown,
				// Token: 0x04001954 RID: 6484
				Food_FoodBlob_Oatmeal_LightBrownSpotty,
				// Token: 0x04001955 RID: 6485
				Food_FoodBlob_Peas_Green = 1693U,
				// Token: 0x04001956 RID: 6486
				Food_FoodBlob_Yogurt_PinkWhitish = 1692U,
				// Token: 0x04001957 RID: 6487
				Food_Fridge = 348U,
				// Token: 0x04001958 RID: 6488
				Food_GourmetMeal = 2511U,
				// Token: 0x04001959 RID: 6489
				Food_GrandMeal_ep05 = 2083U,
				// Token: 0x0400195A RID: 6490
				Food_GrilledCheese = 1499U,
				// Token: 0x0400195B RID: 6491
				Food_HasFish = 2201U,
				// Token: 0x0400195C RID: 6492
				Food_HasMeat = 1572U,
				// Token: 0x0400195D RID: 6493
				Food_HasMeatSubstitute,
				// Token: 0x0400195E RID: 6494
				Food_Healthy = 2494U,
				// Token: 0x0400195F RID: 6495
				Food_HealthyMeal = 69668U,
				// Token: 0x04001960 RID: 6496
				Food_ICO = 1984U,
				// Token: 0x04001961 RID: 6497
				Food_Island = 63511U,
				// Token: 0x04001962 RID: 6498
				Food_Jungle = 45089U,
				// Token: 0x04001963 RID: 6499
				Food_Junk = 2495U,
				// Token: 0x04001964 RID: 6500
				Food_Junk_SugarAdded = 69705U,
				// Token: 0x04001965 RID: 6501
				Food_KaluaPork = 63512U,
				// Token: 0x04001966 RID: 6502
				Food_Meal_Breakfast = 1728U,
				// Token: 0x04001967 RID: 6503
				Food_Meal_Dinner = 1730U,
				// Token: 0x04001968 RID: 6504
				Food_Meal_Lunch = 1729U,
				// Token: 0x04001969 RID: 6505
				Food_Multi = 347U,
				// Token: 0x0400196A RID: 6506
				Food_PickyEater_Dislike = 1717U,
				// Token: 0x0400196B RID: 6507
				Food_PickyEaterA_Like = 1712U,
				// Token: 0x0400196C RID: 6508
				Food_PickyEaterB_Like,
				// Token: 0x0400196D RID: 6509
				Food_PickyEaterC_Like,
				// Token: 0x0400196E RID: 6510
				Food_PickyEaterD_Like,
				// Token: 0x0400196F RID: 6511
				Food_PickyEaterE_Like,
				// Token: 0x04001970 RID: 6512
				Food_Prepared = 759U,
				// Token: 0x04001971 RID: 6513
				Food_QuickMeal = 2236U,
				// Token: 0x04001972 RID: 6514
				Food_SackLunch = 43025U,
				// Token: 0x04001973 RID: 6515
				Food_Single = 1686U,
				// Token: 0x04001974 RID: 6516
				Food_Snack = 651U,
				// Token: 0x04001975 RID: 6517
				Food_Spicy = 1603U,
				// Token: 0x04001976 RID: 6518
				Food_ToddlerDislike = 1659U,
				// Token: 0x04001977 RID: 6519
				Food_ToddlerLike,
				// Token: 0x04001978 RID: 6520
				FullBody_Apron = 951U,
				// Token: 0x04001979 RID: 6521
				FullBody_Costume = 948U,
				// Token: 0x0400197A RID: 6522
				FullBody_Jumpsuits = 374U,
				// Token: 0x0400197B RID: 6523
				FullBody_Lingerie = 950U,
				// Token: 0x0400197C RID: 6524
				FullBody_Longdress = 375U,
				// Token: 0x0400197D RID: 6525
				FullBody_Outerwear = 947U,
				// Token: 0x0400197E RID: 6526
				FullBody_Overall = 952U,
				// Token: 0x0400197F RID: 6527
				FullBody_Robe = 949U,
				// Token: 0x04001980 RID: 6528
				FullBody_Shortdress = 376U,
				// Token: 0x04001981 RID: 6529
				FullBody_Suits,
				// Token: 0x04001982 RID: 6530
				FullBody_Swimsuit = 1237U,
				// Token: 0x04001983 RID: 6531
				Func_AccursedObject = 86019U,
				// Token: 0x04001984 RID: 6532
				Func_AccursedObject_RewardDoll = 86026U,
				// Token: 0x04001985 RID: 6533
				Func_AccursedObject_RewardTendril,
				// Token: 0x04001986 RID: 6534
				Func_AcidMudPuddle = 67625U,
				// Token: 0x04001987 RID: 6535
				Func_ActivityTable = 688U,
				// Token: 0x04001988 RID: 6536
				Func_ActivityTable_Drawing = 934U,
				// Token: 0x04001989 RID: 6537
				Func_ActorCareer_CellDoor = 61496U,
				// Token: 0x0400198A RID: 6538
				Func_ActorCareer_Fridge = 61495U,
				// Token: 0x0400198B RID: 6539
				Func_ActorCareer_HospitalExamBed = 61497U,
				// Token: 0x0400198C RID: 6540
				Func_ActorCareer_Movie_Medieval_StageProp = 61647U,
				// Token: 0x0400198D RID: 6541
				Func_ActorCareer_Movie_Pirate_StageProp = 61625U,
				// Token: 0x0400198E RID: 6542
				Func_ActorCareer_Movie_SuperHero_StageProp = 61627U,
				// Token: 0x0400198F RID: 6543
				Func_ActorCareer_Pedestal = 61498U,
				// Token: 0x04001990 RID: 6544
				Func_ActorCareer_PirateWheel,
				// Token: 0x04001991 RID: 6545
				Func_ActorCareer_StageMarkLarge,
				// Token: 0x04001992 RID: 6546
				Func_ActorCareer_StageObject_All = 61611U,
				// Token: 0x04001993 RID: 6547
				Func_ActorCareer_StageObject_Campfire = 61633U,
				// Token: 0x04001994 RID: 6548
				Func_ActorCareer_StudioDoor_Private = 61641U,
				// Token: 0x04001995 RID: 6549
				Func_ActorCareer_TVHigh_Apocalypse_StageProp = 61626U,
				// Token: 0x04001996 RID: 6550
				Func_AdventureGear = 69710U,
				// Token: 0x04001997 RID: 6551
				Func_Air = 1284U,
				// Token: 0x04001998 RID: 6552
				Func_Alert = 1392U,
				// Token: 0x04001999 RID: 6553
				Func_Alien = 12397U,
				// Token: 0x0400199A RID: 6554
				Func_Alien_Portal = 12436U,
				// Token: 0x0400199B RID: 6555
				Func_Alien_SatelliteDish = 12370U,
				// Token: 0x0400199C RID: 6556
				Func_Ambrosia = 1989U,
				// Token: 0x0400199D RID: 6557
				Func_AmbrosiaTreat = 57399U,
				// Token: 0x0400199E RID: 6558
				Func_Animal = 506U,
				// Token: 0x0400199F RID: 6559
				Func_Anniversary = 1366U,
				// Token: 0x040019A0 RID: 6560
				Func_Anniversary_21 = 2519U,
				// Token: 0x040019A1 RID: 6561
				Func_ApartmentProblem = 55333U,
				// Token: 0x040019A2 RID: 6562
				Func_Apparition = 1195U,
				// Token: 0x040019A3 RID: 6563
				Func_Aquarium = 1109U,
				// Token: 0x040019A4 RID: 6564
				Func_Arcade = 24605U,
				// Token: 0x040019A5 RID: 6565
				Func_Archaeology_CanBeStudied = 45112U,
				// Token: 0x040019A6 RID: 6566
				Func_Archaeology_CanBeStudied_BG = 2051U,
				// Token: 0x040019A7 RID: 6567
				Func_ArchaeologyItem_Med = 45073U,
				// Token: 0x040019A8 RID: 6568
				Func_ArchaeologyItem_Small,
				// Token: 0x040019A9 RID: 6569
				Func_ArchaeologyTable = 45072U,
				// Token: 0x040019AA RID: 6570
				Func_Art = 484U,
				// Token: 0x040019AB RID: 6571
				Func_Art_Sculpture = 2209U,
				// Token: 0x040019AC RID: 6572
				Func_ArtsUniversityShell = 65548U,
				// Token: 0x040019AD RID: 6573
				Func_ArtsUniversityShell_Shell1 = 65560U,
				// Token: 0x040019AE RID: 6574
				Func_ArtsUniversityShell_Shell2,
				// Token: 0x040019AF RID: 6575
				Func_AshPile = 1465U,
				// Token: 0x040019B0 RID: 6576
				Func_Astronaut = 1131U,
				// Token: 0x040019B1 RID: 6577
				Func_Athletic = 476U,
				// Token: 0x040019B2 RID: 6578
				Func_AtmosphericCondenser = 67616U,
				// Token: 0x040019B3 RID: 6579
				Func_Atom = 1394U,
				// Token: 0x040019B4 RID: 6580
				Func_Aural_UseTerrainTypes = 2525U,
				// Token: 0x040019B5 RID: 6581
				Func_Author = 1119U,
				// Token: 0x040019B6 RID: 6582
				Func_AutographedObject = 61614U,
				// Token: 0x040019B7 RID: 6583
				Func_AutonomyArea_Marker = 2186U,
				// Token: 0x040019B8 RID: 6584
				Func_AutoPetFeeder = 57396U,
				// Token: 0x040019B9 RID: 6585
				Func_Awning = 1155U,
				// Token: 0x040019BA RID: 6586
				Func_Baby = 744U,
				// Token: 0x040019BB RID: 6587
				Func_BabyYoda = 2280U,
				// Token: 0x040019BC RID: 6588
				Func_Badge = 1421U,
				// Token: 0x040019BD RID: 6589
				Func_Bait_Crystal = 983U,
				// Token: 0x040019BE RID: 6590
				Func_Bait_Element = 982U,
				// Token: 0x040019BF RID: 6591
				Func_Bait_FreshFlower = 827U,
				// Token: 0x040019C0 RID: 6592
				Func_Bait_FreshFruit = 825U,
				// Token: 0x040019C1 RID: 6593
				Func_Bait_Frog = 788U,
				// Token: 0x040019C2 RID: 6594
				Func_Bait_MedFish = 829U,
				// Token: 0x040019C3 RID: 6595
				Func_Bait_Metal = 984U,
				// Token: 0x040019C4 RID: 6596
				Func_Bait_Organic = 789U,
				// Token: 0x040019C5 RID: 6597
				Func_Bait_PlasmaFruit = 40972U,
				// Token: 0x040019C6 RID: 6598
				Func_Bait_RottenFlower = 828U,
				// Token: 0x040019C7 RID: 6599
				Func_Bait_RottenFruit = 826U,
				// Token: 0x040019C8 RID: 6600
				Func_Bait_SmallFish = 796U,
				// Token: 0x040019C9 RID: 6601
				Func_Bait_Trash = 830U,
				// Token: 0x040019CA RID: 6602
				Func_Bake = 1385U,
				// Token: 0x040019CB RID: 6603
				Func_Baking = 1387U,
				// Token: 0x040019CC RID: 6604
				Func_Ball = 528U,
				// Token: 0x040019CD RID: 6605
				Func_Banquet = 8218U,
				// Token: 0x040019CE RID: 6606
				Func_BanquetTable = 8213U,
				// Token: 0x040019CF RID: 6607
				Func_Bar = 498U,
				// Token: 0x040019D0 RID: 6608
				Func_Barbecue = 1079U,
				// Token: 0x040019D1 RID: 6609
				Func_BarGlobe = 36865U,
				// Token: 0x040019D2 RID: 6610
				Func_Barrel = 12378U,
				// Token: 0x040019D3 RID: 6611
				Func_Baseboard = 1084U,
				// Token: 0x040019D4 RID: 6612
				Func_Basin = 1110U,
				// Token: 0x040019D5 RID: 6613
				Func_Basket = 527U,
				// Token: 0x040019D6 RID: 6614
				Func_Basketball = 55404U,
				// Token: 0x040019D7 RID: 6615
				Func_Basketball_Hoop = 55402U,
				// Token: 0x040019D8 RID: 6616
				Func_Bat = 1220U,
				// Token: 0x040019D9 RID: 6617
				Func_Bath = 1022U,
				// Token: 0x040019DA RID: 6618
				Func_Bathroom,
				// Token: 0x040019DB RID: 6619
				Func_Bathtub = 990U,
				// Token: 0x040019DC RID: 6620
				Func_BattleStation = 32770U,
				// Token: 0x040019DD RID: 6621
				Func_Batuu_Antiquities = 51230U,
				// Token: 0x040019DE RID: 6622
				Func_Batuu_Binoculars = 51238U,
				// Token: 0x040019DF RID: 6623
				Func_Batuu_Blaster = 51233U,
				// Token: 0x040019E0 RID: 6624
				Func_Batuu_Comm_Link,
				// Token: 0x040019E1 RID: 6625
				Func_Batuu_ControlPanel = 51239U,
				// Token: 0x040019E2 RID: 6626
				Func_Batuu_ControlPanel_FO = 51250U,
				// Token: 0x040019E3 RID: 6627
				Func_Batuu_ControlPanel_FO_CommsTower = 51244U,
				// Token: 0x040019E4 RID: 6628
				Func_Batuu_ControlPanel_MainStrip = 51257U,
				// Token: 0x040019E5 RID: 6629
				Func_Batuu_ControlPanel_Resistance = 51256U,
				// Token: 0x040019E6 RID: 6630
				Func_Batuu_Data_Spike = 51235U,
				// Token: 0x040019E7 RID: 6631
				Func_Batuu_FakeID,
				// Token: 0x040019E8 RID: 6632
				Func_Batuu_Mission_RS8_RescuePrepObj = 51245U,
				// Token: 0x040019E9 RID: 6633
				Func_Batuu_Mission_Valuable = 51242U,
				// Token: 0x040019EA RID: 6634
				Func_Batuu_Porg = 51271U,
				// Token: 0x040019EB RID: 6635
				Func_Batuu_Shell = 51249U,
				// Token: 0x040019EC RID: 6636
				Func_Batuu_Shell_DockingBay = 51247U,
				// Token: 0x040019ED RID: 6637
				Func_Batuu_Shell_Dwelling,
				// Token: 0x040019EE RID: 6638
				Func_Batuu_SupplyCrate = 51206U,
				// Token: 0x040019EF RID: 6639
				Func_Batuu_SupplyCrate_BlackSpire = 51268U,
				// Token: 0x040019F0 RID: 6640
				Func_Batuu_SupplyCrate_FO = 51267U,
				// Token: 0x040019F1 RID: 6641
				Func_Batuu_SupplyCrate_Resistance = 51266U,
				// Token: 0x040019F2 RID: 6642
				Func_Batuu_Thermal_Detonator = 51237U,
				// Token: 0x040019F3 RID: 6643
				Func_BBQ = 1078U,
				// Token: 0x040019F4 RID: 6644
				Func_BeachCave = 63534U,
				// Token: 0x040019F5 RID: 6645
				Func_Beam = 1427U,
				// Token: 0x040019F6 RID: 6646
				Func_Bear = 508U,
				// Token: 0x040019F7 RID: 6647
				Func_Beast = 1216U,
				// Token: 0x040019F8 RID: 6648
				Func_Bed = 777U,
				// Token: 0x040019F9 RID: 6649
				Func_Bed_Kid = 888U,
				// Token: 0x040019FA RID: 6650
				Func_Bed_Valid_MonsterUnder_Target = 1542U,
				// Token: 0x040019FB RID: 6651
				Func_BedsideTable = 1009U,
				// Token: 0x040019FC RID: 6652
				Func_Beebox = 59449U,
				// Token: 0x040019FD RID: 6653
				Func_BeeSwarm = 59452U,
				// Token: 0x040019FE RID: 6654
				Func_Bench = 494U,
				// Token: 0x040019FF RID: 6655
				Func_Beverage = 500U,
				// Token: 0x04001A00 RID: 6656
				Func_BG_PipeOrgan = 1709U,
				// Token: 0x04001A01 RID: 6657
				Func_BG_YogaMat,
				// Token: 0x04001A02 RID: 6658
				Func_Bike = 2278U,
				// Token: 0x04001A03 RID: 6659
				Func_Bin = 925U,
				// Token: 0x04001A04 RID: 6660
				Func_BioFuel = 2336U,
				// Token: 0x04001A05 RID: 6661
				Func_BirdFeeder = 34820U,
				// Token: 0x04001A06 RID: 6662
				Func_BizzareIdol = 86030U,
				// Token: 0x04001A07 RID: 6663
				Func_Bladder = 995U,
				// Token: 0x04001A08 RID: 6664
				Func_Blinds = 1153U,
				// Token: 0x04001A09 RID: 6665
				Func_Blob = 512U,
				// Token: 0x04001A0A RID: 6666
				Func_BlockConstructionTable = 43029U,
				// Token: 0x04001A0B RID: 6667
				Func_Bone = 1210U,
				// Token: 0x04001A0C RID: 6668
				Func_Bonfire = 2190U,
				// Token: 0x04001A0D RID: 6669
				Func_Bony = 1211U,
				// Token: 0x04001A0E RID: 6670
				Func_Book = 893U,
				// Token: 0x04001A0F RID: 6671
				Func_Book_BookOfLife = 1177U,
				// Token: 0x04001A10 RID: 6672
				Func_Book_Homework = 1080U,
				// Token: 0x04001A11 RID: 6673
				Func_Book_MagicTome = 49153U,
				// Token: 0x04001A12 RID: 6674
				Func_Book_PlayerCreated = 656U,
				// Token: 0x04001A13 RID: 6675
				Func_Bookcase = 1389U,
				// Token: 0x04001A14 RID: 6676
				Func_Boombox = 991U,
				// Token: 0x04001A15 RID: 6677
				Func_Booth = 26629U,
				// Token: 0x04001A16 RID: 6678
				Func_Booth_Banquette = 26641U,
				// Token: 0x04001A17 RID: 6679
				Func_Booth_Corner = 26636U,
				// Token: 0x04001A18 RID: 6680
				Func_Bottle = 1160U,
				// Token: 0x04001A19 RID: 6681
				Func_Bowl = 1222U,
				// Token: 0x04001A1A RID: 6682
				Func_Bowling = 38925U,
				// Token: 0x04001A1B RID: 6683
				Func_BowlingLane = 38913U,
				// Token: 0x04001A1C RID: 6684
				Func_BowlingLane_BG = 1720U,
				// Token: 0x04001A1D RID: 6685
				Func_Box = 579U,
				// Token: 0x04001A1E RID: 6686
				Func_BoxOfDecorations = 59408U,
				// Token: 0x04001A1F RID: 6687
				Func_Brewer = 1882U,
				// Token: 0x04001A20 RID: 6688
				Func_Brick = 1086U,
				// Token: 0x04001A21 RID: 6689
				Func_Briefcase = 55407U,
				// Token: 0x04001A22 RID: 6690
				Func_BubbleBlower = 55310U,
				// Token: 0x04001A23 RID: 6691
				Func_Bucket = 1291U,
				// Token: 0x04001A24 RID: 6692
				Func_Buffet = 8217U,
				// Token: 0x04001A25 RID: 6693
				Func_Bush = 1163U,
				// Token: 0x04001A26 RID: 6694
				Func_Business = 1323U,
				// Token: 0x04001A27 RID: 6695
				Func_Business_Light = 1545U,
				// Token: 0x04001A28 RID: 6696
				Func_Cabinet = 1409U,
				// Token: 0x04001A29 RID: 6697
				Func_CafeteriaStation = 65550U,
				// Token: 0x04001A2A RID: 6698
				Func_Cage = 1431U,
				// Token: 0x04001A2B RID: 6699
				Func_Cake = 1391U,
				// Token: 0x04001A2C RID: 6700
				Func_Calendar = 1395U,
				// Token: 0x04001A2D RID: 6701
				Func_Camera_Normal = 12342U,
				// Token: 0x04001A2E RID: 6702
				Func_Camera_Outstanding,
				// Token: 0x04001A2F RID: 6703
				Func_Camera_Poor = 12341U,
				// Token: 0x04001A30 RID: 6704
				Func_Camera_Pro = 79875U,
				// Token: 0x04001A31 RID: 6705
				Func_Camera_Slot_Tripod = 2221U,
				// Token: 0x04001A32 RID: 6706
				Func_Camera_Tripod = 79873U,
				// Token: 0x04001A33 RID: 6707
				Func_Camera_Tripod_Anchor_Mark = 79877U,
				// Token: 0x04001A34 RID: 6708
				Func_Cameras = 1381U,
				// Token: 0x04001A35 RID: 6709
				Func_Campfire = 10246U,
				// Token: 0x04001A36 RID: 6710
				Func_Camping = 10245U,
				// Token: 0x04001A37 RID: 6711
				Func_CanBeVacuumed = 94213U,
				// Token: 0x04001A38 RID: 6712
				Func_CanBeVacuumed_Gross,
				// Token: 0x04001A39 RID: 6713
				Func_CanBeVacuumed_Handheld = 94224U,
				// Token: 0x04001A3A RID: 6714
				Func_Candle = 1207U,
				// Token: 0x04001A3B RID: 6715
				Func_CandleMakingStation = 67628U,
				// Token: 0x04001A3C RID: 6716
				Func_Candles = 1328U,
				// Token: 0x04001A3D RID: 6717
				Func_Candy_Skull = 1554U,
				// Token: 0x04001A3E RID: 6718
				Func_Candy_Skull_01,
				// Token: 0x04001A3F RID: 6719
				Func_Candy_Skull_02,
				// Token: 0x04001A40 RID: 6720
				Func_Candy_Skull_03,
				// Token: 0x04001A41 RID: 6721
				Func_Candy_Skull_04,
				// Token: 0x04001A42 RID: 6722
				Func_Candy_Skull_05,
				// Token: 0x04001A43 RID: 6723
				Func_Candy_Skull_06,
				// Token: 0x04001A44 RID: 6724
				Func_Candy_Skull_07,
				// Token: 0x04001A45 RID: 6725
				Func_Candy_Skull_08,
				// Token: 0x04001A46 RID: 6726
				Func_Candy_Skull_09,
				// Token: 0x04001A47 RID: 6727
				Func_Candy_Skull_10,
				// Token: 0x04001A48 RID: 6728
				Func_CandyBowl = 2117U,
				// Token: 0x04001A49 RID: 6729
				Func_Cans = 1297U,
				// Token: 0x04001A4A RID: 6730
				Func_CantRepo = 2276U,
				// Token: 0x04001A4B RID: 6731
				Func_Canvas = 573U,
				// Token: 0x04001A4C RID: 6732
				Func_CardGame = 922U,
				// Token: 0x04001A4D RID: 6733
				Func_Cards = 1316U,
				// Token: 0x04001A4E RID: 6734
				Func_CardTable = 988U,
				// Token: 0x04001A4F RID: 6735
				Func_Carpenter = 492U,
				// Token: 0x04001A50 RID: 6736
				Func_Carpet = 1161U,
				// Token: 0x04001A51 RID: 6737
				Func_Cart = 1402U,
				// Token: 0x04001A52 RID: 6738
				Func_CarvedPumpkin = 22529U,
				// Token: 0x04001A53 RID: 6739
				Func_CarvingStation = 22540U,
				// Token: 0x04001A54 RID: 6740
				Func_Case = 1411U,
				// Token: 0x04001A55 RID: 6741
				Func_CatCondo = 57383U,
				// Token: 0x04001A56 RID: 6742
				Func_CatWand = 57429U,
				// Token: 0x04001A57 RID: 6743
				Func_CatWand_Rainbow = 57453U,
				// Token: 0x04001A58 RID: 6744
				Func_Cauldron = 49155U,
				// Token: 0x04001A59 RID: 6745
				Func_Cauldron_Potion,
				// Token: 0x04001A5A RID: 6746
				Func_CelebrityFanTargetable = 61475U,
				// Token: 0x04001A5B RID: 6747
				Func_CelebrityTile_Original = 61636U,
				// Token: 0x04001A5C RID: 6748
				Func_Cell = 1378U,
				// Token: 0x04001A5D RID: 6749
				Func_Cemetery = 1200U,
				// Token: 0x04001A5E RID: 6750
				Func_Chair = 1303U,
				// Token: 0x04001A5F RID: 6751
				Func_Chair_DebateShowdown_Audience = 65592U,
				// Token: 0x04001A60 RID: 6752
				Func_Chair_DebateShowdown_Judge,
				// Token: 0x04001A61 RID: 6753
				Func_Chalkboard = 1426U,
				// Token: 0x04001A62 RID: 6754
				Func_ChangeClothes = 1448U,
				// Token: 0x04001A63 RID: 6755
				Func_Charisma = 1099U,
				// Token: 0x04001A64 RID: 6756
				Func_Chef = 1115U,
				// Token: 0x04001A65 RID: 6757
				Func_ChefStation = 26627U,
				// Token: 0x04001A66 RID: 6758
				Func_ChemAnalyzer = 12361U,
				// Token: 0x04001A67 RID: 6759
				func_ChemLab = 12360U,
				// Token: 0x04001A68 RID: 6760
				Func_Chess = 485U,
				// Token: 0x04001A69 RID: 6761
				Func_Child = 1136U,
				// Token: 0x04001A6A RID: 6762
				Func_ChildViolin = 1176U,
				// Token: 0x04001A6B RID: 6763
				Func_Chimney = 1164U,
				// Token: 0x04001A6C RID: 6764
				Func_Christmas = 1327U,
				// Token: 0x04001A6D RID: 6765
				Func_Clay = 511U,
				// Token: 0x04001A6E RID: 6766
				Func_ClimbingRoute = 69692U,
				// Token: 0x04001A6F RID: 6767
				Func_ClimbingRoute_Large = 69701U,
				// Token: 0x04001A70 RID: 6768
				Func_ClimbingRoute_Medium = 69700U,
				// Token: 0x04001A71 RID: 6769
				Func_ClimbingRoute_Small = 69699U,
				// Token: 0x04001A72 RID: 6770
				Func_ClobbersSnowFootprints = 2114U,
				// Token: 0x04001A73 RID: 6771
				Func_CloneNormalMin = 12344U,
				// Token: 0x04001A74 RID: 6772
				Func_Closet = 1139U,
				// Token: 0x04001A75 RID: 6773
				Func_Clothes = 1162U,
				// Token: 0x04001A76 RID: 6774
				Func_Clubs = 24593U,
				// Token: 0x04001A77 RID: 6775
				Func_Clue = 12371U,
				// Token: 0x04001A78 RID: 6776
				Func_CoatRack = 1500U,
				// Token: 0x04001A79 RID: 6777
				Func_Cobweb = 1193U,
				// Token: 0x04001A7A RID: 6778
				Func_CoconutPlant = 63518U,
				// Token: 0x04001A7B RID: 6779
				Func_Coffee = 525U,
				// Token: 0x04001A7C RID: 6780
				Func_CoffeeCart = 65603U,
				// Token: 0x04001A7D RID: 6781
				Func_CoffeeMaker = 1167U,
				// Token: 0x04001A7E RID: 6782
				Func_Coffin = 40970U,
				// Token: 0x04001A7F RID: 6783
				Func_CollectArtifact = 45075U,
				// Token: 0x04001A80 RID: 6784
				Func_CollectArtifact_Fake,
				// Token: 0x04001A81 RID: 6785
				Func_CollectArtifact_Genuine = 45092U,
				// Token: 0x04001A82 RID: 6786
				Func_CollectArtifact_Knife = 45098U,
				// Token: 0x04001A83 RID: 6787
				Func_CollectArtifact_Mail = 45077U,
				// Token: 0x04001A84 RID: 6788
				Func_CollectArtifact_Mail_Fake = 45093U,
				// Token: 0x04001A85 RID: 6789
				Func_CollectArtifact_Mask = 45099U,
				// Token: 0x04001A86 RID: 6790
				Func_CollectArtifact_Skull,
				// Token: 0x04001A87 RID: 6791
				Func_CollectArtifact_Statue,
				// Token: 0x04001A88 RID: 6792
				Func_CollectArtifact_Vase = 45097U,
				// Token: 0x04001A89 RID: 6793
				Func_Collection_Monsters = 32771U,
				// Token: 0x04001A8A RID: 6794
				Func_Collection_Spawner = 12425U,
				// Token: 0x04001A8B RID: 6795
				Func_ColorFromSand = 2200U,
				// Token: 0x04001A8C RID: 6796
				Func_Comedy = 1130U,
				// Token: 0x04001A8D RID: 6797
				Func_ComedyRoutine = 589U,
				// Token: 0x04001A8E RID: 6798
				Func_ComedyRoutine_Long = 594U,
				// Token: 0x04001A8F RID: 6799
				Func_ComedyRoutine_Medium = 593U,
				// Token: 0x04001A90 RID: 6800
				Func_ComedyRoutine_Short = 592U,
				// Token: 0x04001A91 RID: 6801
				Func_CommunityBoard_BG = 2284U,
				// Token: 0x04001A92 RID: 6802
				Func_Computer = 514U,
				// Token: 0x04001A93 RID: 6803
				Func_ComputerGlasses = 65655U,
				// Token: 0x04001A94 RID: 6804
				Func_Concept_EcoInvention = 67612U,
				// Token: 0x04001A95 RID: 6805
				Func_Concept_Municipal = 67611U,
				// Token: 0x04001A96 RID: 6806
				Func_Concrete = 1092U,
				// Token: 0x04001A97 RID: 6807
				Func_Cook = 524U,
				// Token: 0x04001A98 RID: 6808
				Func_Cooking = 1102U,
				// Token: 0x04001A99 RID: 6809
				Func_Cooler = 10243U,
				// Token: 0x04001A9A RID: 6810
				Func_CorporateWorker_ApologyGift = 69742U,
				// Token: 0x04001A9B RID: 6811
				Func_Cot = 1287U,
				// Token: 0x04001A9C RID: 6812
				Func_Couch = 989U,
				// Token: 0x04001A9D RID: 6813
				Func_Counter = 1525U,
				// Token: 0x04001A9E RID: 6814
				Func_Cowplant = 1375U,
				// Token: 0x04001A9F RID: 6815
				Func_Craft = 513U,
				// Token: 0x04001AA0 RID: 6816
				Func_CraftedCandle = 67622U,
				// Token: 0x04001AA1 RID: 6817
				Func_CraftSalesTable = 55365U,
				// Token: 0x04001AA2 RID: 6818
				Func_CraftSalesTable_JungleSupplies_Fun = 2047U,
				// Token: 0x04001AA3 RID: 6819
				Func_CraftSalesTable_JungleSupplies_Furniture = 2046U,
				// Token: 0x04001AA4 RID: 6820
				Func_CraftSalesTable_JungleSupplies_Pet = 2048U,
				// Token: 0x04001AA5 RID: 6821
				Func_CraftSalesTable_JungleSupplies_Supplies = 2045U,
				// Token: 0x04001AA6 RID: 6822
				Func_CraftSalesTable_Painting = 2387U,
				// Token: 0x04001AA7 RID: 6823
				Func_CraftSalesTable_RequiredObject_BG = 2285U,
				// Token: 0x04001AA8 RID: 6824
				Func_CraftSalesTable_SecretItems_Collectibles = 2050U,
				// Token: 0x04001AA9 RID: 6825
				Func_CraftSalesTable_SecretItems_Supplies = 2049U,
				// Token: 0x04001AAA RID: 6826
				Func_CraftSalesTable_Table = 2386U,
				// Token: 0x04001AAB RID: 6827
				Func_Crate = 12379U,
				// Token: 0x04001AAC RID: 6828
				Func_Crates = 1401U,
				// Token: 0x04001AAD RID: 6829
				Func_Crates_Routable = 57385U,
				// Token: 0x04001AAE RID: 6830
				Func_Creativity = 24597U,
				// Token: 0x04001AAF RID: 6831
				Func_Crib = 745U,
				// Token: 0x04001AB0 RID: 6832
				Func_CrimeMap = 12372U,
				// Token: 0x04001AB1 RID: 6833
				Func_Criminal = 1113U,
				// Token: 0x04001AB2 RID: 6834
				Func_Crypt = 1201U,
				// Token: 0x04001AB3 RID: 6835
				Func_CrystalBall = 1184U,
				// Token: 0x04001AB4 RID: 6836
				Func_Cube = 502U,
				// Token: 0x04001AB5 RID: 6837
				Func_Culinary = 1114U,
				// Token: 0x04001AB6 RID: 6838
				Func_CullingPortal = 1546U,
				// Token: 0x04001AB7 RID: 6839
				Func_Cup = 1302U,
				// Token: 0x04001AB8 RID: 6840
				Func_Cupboard = 1012U,
				// Token: 0x04001AB9 RID: 6841
				Func_CupcakeMachine = 1376U,
				// Token: 0x04001ABA RID: 6842
				Func_Curtain = 1014U,
				// Token: 0x04001ABB RID: 6843
				Func_Dancefloor = 1455U,
				// Token: 0x04001ABC RID: 6844
				Func_Dancing = 24601U,
				// Token: 0x04001ABD RID: 6845
				Func_Dartboard = 24609U,
				// Token: 0x04001ABE RID: 6846
				Func_DayoftheDead = 1565U,
				// Token: 0x04001ABF RID: 6847
				Func_Death = 575U,
				// Token: 0x04001AC0 RID: 6848
				Func_Decal = 1151U,
				// Token: 0x04001AC1 RID: 6849
				Func_Dectective = 12327U,
				// Token: 0x04001AC2 RID: 6850
				Func_DenizenPond = 2157U,
				// Token: 0x04001AC3 RID: 6851
				Func_Dessert = 1386U,
				// Token: 0x04001AC4 RID: 6852
				Func_Detective_ChiefChair = 12435U,
				// Token: 0x04001AC5 RID: 6853
				Func_Detective_Clue_AddToMap = 12318U,
				// Token: 0x04001AC6 RID: 6854
				Func_Detective_Clue_Chemical = 12296U,
				// Token: 0x04001AC7 RID: 6855
				Func_Detective_Clue_Database = 12326U,
				// Token: 0x04001AC8 RID: 6856
				Func_Detective_Clue_Picture = 12312U,
				// Token: 0x04001AC9 RID: 6857
				Func_Detective_Clue_Sample,
				// Token: 0x04001ACA RID: 6858
				Func_DewCollector = 67615U,
				// Token: 0x04001ACB RID: 6859
				Func_DewCollector_HighQuality = 67646U,
				// Token: 0x04001ACC RID: 6860
				Func_DiaDeLosMuertos = 1566U,
				// Token: 0x04001ACD RID: 6861
				Func_DigitalFrame = 2216U,
				// Token: 0x04001ACE RID: 6862
				Func_Dining = 1124U,
				// Token: 0x04001ACF RID: 6863
				Func_DiningChair = 1006U,
				// Token: 0x04001AD0 RID: 6864
				Func_DiningHutch = 1125U,
				// Token: 0x04001AD1 RID: 6865
				Func_Dinosaur = 509U,
				// Token: 0x04001AD2 RID: 6866
				Func_Diploma = 1415U,
				// Token: 0x04001AD3 RID: 6867
				Func_DirectorChair = 61463U,
				// Token: 0x04001AD4 RID: 6868
				Func_DisableAutoShape = 2551U,
				// Token: 0x04001AD5 RID: 6869
				Func_DisableInLotThumbnails = 2100U,
				// Token: 0x04001AD6 RID: 6870
				Func_Dishwasher = 1451U,
				// Token: 0x04001AD7 RID: 6871
				Func_Dispenser = 1419U,
				// Token: 0x04001AD8 RID: 6872
				Func_Divider = 1033U,
				// Token: 0x04001AD9 RID: 6873
				Func_DJBooth = 1456U,
				// Token: 0x04001ADA RID: 6874
				Func_DJing = 24600U,
				// Token: 0x04001ADB RID: 6875
				Func_Doctor = 12328U,
				// Token: 0x04001ADC RID: 6876
				Func_Doctor_item_Sample = 12330U,
				// Token: 0x04001ADD RID: 6877
				Func_Doctor_object_ExamBed = 12329U,
				// Token: 0x04001ADE RID: 6878
				Func_Doctor_object_MedicalTreadmill = 12348U,
				// Token: 0x04001ADF RID: 6879
				Func_Doctor_object_SurgeryTable = 12333U,
				// Token: 0x04001AE0 RID: 6880
				Func_Doctor_object_XrayMachine = 12332U,
				// Token: 0x04001AE1 RID: 6881
				Func_DoctorPlayset = 43030U,
				// Token: 0x04001AE2 RID: 6882
				Func_DoesntSpawnFire = 1494U,
				// Token: 0x04001AE3 RID: 6883
				Func_Doll = 580U,
				// Token: 0x04001AE4 RID: 6884
				Func_Dollhouse = 666U,
				// Token: 0x04001AE5 RID: 6885
				Func_DollyCamera = 61462U,
				// Token: 0x04001AE6 RID: 6886
				Func_Dolphin_Albino = 63492U,
				// Token: 0x04001AE7 RID: 6887
				Func_Dolphin_Merfolk,
				// Token: 0x04001AE8 RID: 6888
				Func_Dolphin_Standard = 63491U,
				// Token: 0x04001AE9 RID: 6889
				Func_DolphinSpawner = 63494U,
				// Token: 0x04001AEA RID: 6890
				Func_DontWakeLlama = 24608U,
				// Token: 0x04001AEB RID: 6891
				Func_DoubleBed = 778U,
				// Token: 0x04001AEC RID: 6892
				Func_Dragon = 510U,
				// Token: 0x04001AED RID: 6893
				Func_DrawingPosted = 43011U,
				// Token: 0x04001AEE RID: 6894
				Func_DrawSomething = 1003U,
				// Token: 0x04001AEF RID: 6895
				Func_Drink = 499U,
				// Token: 0x04001AF0 RID: 6896
				Func_DrinkTray = 1552U,
				// Token: 0x04001AF1 RID: 6897
				Func_Droid_Personality_Chip = 51211U,
				// Token: 0x04001AF2 RID: 6898
				Func_Droid_Personality_Chip_FirstOrder = 51213U,
				// Token: 0x04001AF3 RID: 6899
				Func_Droid_Personality_Chip_FirstOrder_2 = 51252U,
				// Token: 0x04001AF4 RID: 6900
				Func_Droid_Personality_Chip_Resistance = 51212U,
				// Token: 0x04001AF5 RID: 6901
				Func_Droid_Personality_Chip_Resistance_2 = 51251U,
				// Token: 0x04001AF6 RID: 6902
				Func_Droid_Personality_Chip_Scoundrel = 51214U,
				// Token: 0x04001AF7 RID: 6903
				Func_Droid_Personality_Chip_Scoundrel_2 = 51253U,
				// Token: 0x04001AF8 RID: 6904
				Func_DroidBB = 51219U,
				// Token: 0x04001AF9 RID: 6905
				Func_DroidR,
				// Token: 0x04001AFA RID: 6906
				Func_DropsLeaves_EP10Maple_Green = 2513U,
				// Token: 0x04001AFB RID: 6907
				Func_DropsLeaves_EP10Maple_Red,
				// Token: 0x04001AFC RID: 6908
				Func_DropsLeaves_Large = 2063U,
				// Token: 0x04001AFD RID: 6909
				Func_DropsLeaves_Medium = 2062U,
				// Token: 0x04001AFE RID: 6910
				Func_DropsLeaves_Small = 2056U,
				// Token: 0x04001AFF RID: 6911
				Func_DropsLeaves_XLarge = 2064U,
				// Token: 0x04001B00 RID: 6912
				Func_Duct = 1428U,
				// Token: 0x04001B01 RID: 6913
				Func_Dumpster = 67605U,
				// Token: 0x04001B02 RID: 6914
				Func_Dumpster_Deal_Appliance = 2446U,
				// Token: 0x04001B03 RID: 6915
				Func_Dumpster_Deal_BurntAndScratched = 2445U,
				// Token: 0x04001B04 RID: 6916
				Func_Dumpster_Deal_Collectible = 2454U,
				// Token: 0x04001B05 RID: 6917
				Func_Dumpster_Deal_Craftable,
				// Token: 0x04001B06 RID: 6918
				Func_Dumpster_Deal_Miscellaneous = 2448U,
				// Token: 0x04001B07 RID: 6919
				Func_Dumpster_Deal_Plumbing = 2447U,
				// Token: 0x04001B08 RID: 6920
				Func_Dumpster_Deal_UpgradePart = 2456U,
				// Token: 0x04001B09 RID: 6921
				Func_Dumpster_HighPriceDrop = 67610U,
				// Token: 0x04001B0A RID: 6922
				Func_Dumpster_Insect = 67645U,
				// Token: 0x04001B0B RID: 6923
				Func_Dumpster_LowPriceDrop = 67609U,
				// Token: 0x04001B0C RID: 6924
				Func_Dumpster_Meal_Food = 2452U,
				// Token: 0x04001B0D RID: 6925
				Func_Dumpster_Meal_Ingredient = 2451U,
				// Token: 0x04001B0E RID: 6926
				Func_Dumpster_Meal_Insect = 2453U,
				// Token: 0x04001B0F RID: 6927
				Func_Dumpster_UniqueDrop = 67608U,
				// Token: 0x04001B10 RID: 6928
				Func_DustBunny = 94216U,
				// Token: 0x04001B11 RID: 6929
				Func_DustFriend = 94215U,
				// Token: 0x04001B12 RID: 6930
				Func_DustPile = 94209U,
				// Token: 0x04001B13 RID: 6931
				Func_EarBuds = 1725U,
				// Token: 0x04001B14 RID: 6932
				Func_Easel = 482U,
				// Token: 0x04001B15 RID: 6933
				Func_EasterEgg = 2082U,
				// Token: 0x04001B16 RID: 6934
				Func_eco_ecofriendy_appliances = 2375U,
				// Token: 0x04001B17 RID: 6935
				Func_eco_green_gardening = 2374U,
				// Token: 0x04001B18 RID: 6936
				Func_eco_neighborhood_utility = 2372U,
				// Token: 0x04001B19 RID: 6937
				Func_eco_upcycling_initiative,
				// Token: 0x04001B1A RID: 6938
				Func_EcoFootprint_ObjectState = 2376U,
				// Token: 0x04001B1B RID: 6939
				Func_EcoFootprint_SunRay = 67588U,
				// Token: 0x04001B1C RID: 6940
				Func_Energy = 997U,
				// Token: 0x04001B1D RID: 6941
				Func_Entertainer = 1129U,
				// Token: 0x04001B1E RID: 6942
				Func_EP01_AlienTransmute_Compatible = 12369U,
				// Token: 0x04001B1F RID: 6943
				Func_EP01_Serum_AgeAway = 12422U,
				// Token: 0x04001B20 RID: 6944
				Func_EP01_Serum_AlienAura = 12421U,
				// Token: 0x04001B21 RID: 6945
				Func_EP01_Serum_Embiggen = 12416U,
				// Token: 0x04001B22 RID: 6946
				Func_EP01_Serum_FixersLuck = 12419U,
				// Token: 0x04001B23 RID: 6947
				Func_EP01_Serum_GhostGoo = 12417U,
				// Token: 0x04001B24 RID: 6948
				Func_EP01_Serum_NeedFixer = 12354U,
				// Token: 0x04001B25 RID: 6949
				Func_EP01_Serum_OxStrength = 12418U,
				// Token: 0x04001B26 RID: 6950
				Func_EP01_Serum_ReapersFriend = 12420U,
				// Token: 0x04001B27 RID: 6951
				Func_EP01_Serum_RedHot = 12414U,
				// Token: 0x04001B28 RID: 6952
				Func_EP01_Serum_RosePerfume = 12352U,
				// Token: 0x04001B29 RID: 6953
				Func_EP01_Serum_Slimify = 12415U,
				// Token: 0x04001B2A RID: 6954
				Func_EP01_Serum_Smart = 12356U,
				// Token: 0x04001B2B RID: 6955
				Func_EP01_Serum_SnakeOil = 12353U,
				// Token: 0x04001B2C RID: 6956
				Func_EP01_Serum_SparkDrive = 12355U,
				// Token: 0x04001B2D RID: 6957
				Func_EP01_Serum_SyntheticFood = 12351U,
				// Token: 0x04001B2E RID: 6958
				Func_EP10FestivalFood = 69732U,
				// Token: 0x04001B2F RID: 6959
				Func_EP1Collectible_BG = 2038U,
				// Token: 0x04001B30 RID: 6960
				Func_eSportGamer = 1134U,
				// Token: 0x04001B31 RID: 6961
				Func_EspressoBar = 1452U,
				// Token: 0x04001B32 RID: 6962
				Func_EspressoGrinder = 1454U,
				// Token: 0x04001B33 RID: 6963
				Func_EspressoMachine = 1453U,
				// Token: 0x04001B34 RID: 6964
				Func_Etagere = 1035U,
				// Token: 0x04001B35 RID: 6965
				Func_Excercise = 473U,
				// Token: 0x04001B36 RID: 6966
				Func_Exit = 1416U,
				// Token: 0x04001B37 RID: 6967
				Func_ExperimentalFood = 26631U,
				// Token: 0x04001B38 RID: 6968
				Func_Extinguisher = 1417U,
				// Token: 0x04001B39 RID: 6969
				Func_FabricatedItem = 67587U,
				// Token: 0x04001B3A RID: 6970
				Func_FabricationDye = 67590U,
				// Token: 0x04001B3B RID: 6971
				Func_FabricationDyeCommon = 67637U,
				// Token: 0x04001B3C RID: 6972
				Func_Fabricator = 67586U,
				// Token: 0x04001B3D RID: 6973
				Func_Face = 1214U,
				// Token: 0x04001B3E RID: 6974
				Func_FamilyBulletinBoard = 43016U,
				// Token: 0x04001B3F RID: 6975
				Func_Fan = 1414U,
				// Token: 0x04001B40 RID: 6976
				Func_FashionStudioSearch = 2220U,
				// Token: 0x04001B41 RID: 6977
				Func_Faucet = 1138U,
				// Token: 0x04001B42 RID: 6978
				Func_Favorite_Chopstick_ClassicWood = 69741U,
				// Token: 0x04001B43 RID: 6979
				Func_Favorite_Chopstick_Plastic = 69687U,
				// Token: 0x04001B44 RID: 6980
				Func_Favorite_Chopstick_Steel,
				// Token: 0x04001B45 RID: 6981
				Func_Favorite_Chopstick_Wood = 69686U,
				// Token: 0x04001B46 RID: 6982
				Func_Favorite_Chopsticks = 69685U,
				// Token: 0x04001B47 RID: 6983
				Func_Festival_Autonomy_Area_Marker = 1575U,
				// Token: 0x04001B48 RID: 6984
				Func_Festival_AutonomyArea_Marker = 55297U,
				// Token: 0x04001B49 RID: 6985
				Func_Festival_Blossom_TeaFountain = 55388U,
				// Token: 0x04001B4A RID: 6986
				Func_Festival_CurryContest = 55369U,
				// Token: 0x04001B4B RID: 6987
				Func_Festival_Fireworks_DarkSide = 55366U,
				// Token: 0x04001B4C RID: 6988
				Func_Festival_Fireworks_LightSide,
				// Token: 0x04001B4D RID: 6989
				Func_Festival_FleaMarketObjects = 55392U,
				// Token: 0x04001B4E RID: 6990
				Func_Festival_Lamp_TeaFountains = 55387U,
				// Token: 0x04001B4F RID: 6991
				Func_Festival_Tea_DarkTea = 55345U,
				// Token: 0x04001B50 RID: 6992
				Func_Festival_Tea_LightTea,
				// Token: 0x04001B51 RID: 6993
				Func_Festival_Tea_Sakura,
				// Token: 0x04001B52 RID: 6994
				Func_Fetchable = 1875U,
				// Token: 0x04001B53 RID: 6995
				Func_Figurine = 1157U,
				// Token: 0x04001B54 RID: 6996
				Func_Fileholder = 1425U,
				// Token: 0x04001B55 RID: 6997
				Func_FilthFiend = 94217U,
				// Token: 0x04001B56 RID: 6998
				Func_Fire = 1305U,
				// Token: 0x04001B57 RID: 6999
				Func_FireAlarm = 1165U,
				// Token: 0x04001B58 RID: 7000
				Func_FirePit = 1306U,
				// Token: 0x04001B59 RID: 7001
				Func_Fireplace_Magic = 49183U,
				// Token: 0x04001B5A RID: 7002
				Func_Fireworks = 1578U,
				// Token: 0x04001B5B RID: 7003
				Func_FireworksArtsCrafts = 1588U,
				// Token: 0x04001B5C RID: 7004
				Func_FireworksBlossom = 1583U,
				// Token: 0x04001B5D RID: 7005
				Func_FireworksFood = 1586U,
				// Token: 0x04001B5E RID: 7006
				Func_FireworksLamp = 1585U,
				// Token: 0x04001B5F RID: 7007
				Func_FireworksLogic = 1584U,
				// Token: 0x04001B60 RID: 7008
				Func_FireworksMusic = 1587U,
				// Token: 0x04001B61 RID: 7009
				Func_FireworksSparkler = 1590U,
				// Token: 0x04001B62 RID: 7010
				Func_FireworksSparklerBlossom = 55408U,
				// Token: 0x04001B63 RID: 7011
				Func_FireworksSparklerFood,
				// Token: 0x04001B64 RID: 7012
				Func_FireworksSparklerLamp,
				// Token: 0x04001B65 RID: 7013
				Func_FireworksSparklerLogic,
				// Token: 0x04001B66 RID: 7014
				Func_FireworksSparklerWedding,
				// Token: 0x04001B67 RID: 7015
				Func_FireworksWedding = 1589U,
				// Token: 0x04001B68 RID: 7016
				Func_Fish = 992U,
				// Token: 0x04001B69 RID: 7017
				Func_Fish_Endangered = 63503U,
				// Token: 0x04001B6A RID: 7018
				Func_Fish_Fishbowl = 869U,
				// Token: 0x04001B6B RID: 7019
				Func_Fish_Invasive = 2195U,
				// Token: 0x04001B6C RID: 7020
				Func_FishingLocation_Any = 2164U,
				// Token: 0x04001B6D RID: 7021
				Func_FishingLocation_Hole = 937U,
				// Token: 0x04001B6E RID: 7022
				Func_FishingLocation_Spot,
				// Token: 0x04001B6F RID: 7023
				Func_FishingSpot_Bay = 63528U,
				// Token: 0x04001B70 RID: 7024
				Func_FishingSpot_Common = 2193U,
				// Token: 0x04001B71 RID: 7025
				Func_FishingSpot_Rare = 2192U,
				// Token: 0x04001B72 RID: 7026
				Func_FishingSpot_Tropical = 63526U,
				// Token: 0x04001B73 RID: 7027
				Func_FishingSpot_Uncommon = 2191U,
				// Token: 0x04001B74 RID: 7028
				Func_Fitness = 474U,
				// Token: 0x04001B75 RID: 7029
				Func_Flag = 1403U,
				// Token: 0x04001B76 RID: 7030
				Func_Flagstone = 1094U,
				// Token: 0x04001B77 RID: 7031
				Func_Flower = 1314U,
				// Token: 0x04001B78 RID: 7032
				Func_FlowerArrangement = 59457U,
				// Token: 0x04001B79 RID: 7033
				Func_Flowers_10 = 59490U,
				// Token: 0x04001B7A RID: 7034
				Func_Flowers_3 = 59483U,
				// Token: 0x04001B7B RID: 7035
				Func_Flowers_4,
				// Token: 0x04001B7C RID: 7036
				Func_Flowers_5,
				// Token: 0x04001B7D RID: 7037
				Func_Flowers_6,
				// Token: 0x04001B7E RID: 7038
				Func_Flowers_7,
				// Token: 0x04001B7F RID: 7039
				Func_Flowers_8,
				// Token: 0x04001B80 RID: 7040
				Func_Flowers_9,
				// Token: 0x04001B81 RID: 7041
				Func_Flowers_BopBeg = 2106U,
				// Token: 0x04001B82 RID: 7042
				Func_Flowers_ChrySnap = 2104U,
				// Token: 0x04001B83 RID: 7043
				Func_Flowers_DaiBlu = 2102U,
				// Token: 0x04001B84 RID: 7044
				Func_Flowers_LilyDeath = 2107U,
				// Token: 0x04001B85 RID: 7045
				Func_Flowers_RosDah = 2103U,
				// Token: 0x04001B86 RID: 7046
				Func_Flowers_Scent = 2090U,
				// Token: 0x04001B87 RID: 7047
				Func_Flowers_ScentRare,
				// Token: 0x04001B88 RID: 7048
				Func_Flowers_SnoCroc = 2101U,
				// Token: 0x04001B89 RID: 7049
				Func_Flowers_TulChri = 2105U,
				// Token: 0x04001B8A RID: 7050
				Func_Folders = 1412U,
				// Token: 0x04001B8B RID: 7051
				Func_Folding = 1304U,
				// Token: 0x04001B8C RID: 7052
				Func_Food = 520U,
				// Token: 0x04001B8D RID: 7053
				Func_Food_PetEdible = 2030U,
				// Token: 0x04001B8E RID: 7054
				Func_FoodPlatter = 26643U,
				// Token: 0x04001B8F RID: 7055
				Func_FoosballTable = 24591U,
				// Token: 0x04001B90 RID: 7056
				Func_Fortune = 1180U,
				// Token: 0x04001B91 RID: 7057
				Func_FortuneTelling = 8200U,
				// Token: 0x04001B92 RID: 7058
				Func_Fossil_Brushed = 2044U,
				// Token: 0x04001B93 RID: 7059
				Func_FossilRock = 2037U,
				// Token: 0x04001B94 RID: 7060
				Func_Fountain = 8216U,
				// Token: 0x04001B95 RID: 7061
				Func_FreeLanceMaker_CarvedCandles = 67599U,
				// Token: 0x04001B96 RID: 7062
				Func_FreeLanceMaker_Couch = 67596U,
				// Token: 0x04001B97 RID: 7063
				Func_FreeLanceMaker_CraftedCandles = 67601U,
				// Token: 0x04001B98 RID: 7064
				Func_FreeLanceMaker_FineWallDecor,
				// Token: 0x04001B99 RID: 7065
				Func_FreeLanceMaker_FloorLights = 67598U,
				// Token: 0x04001B9A RID: 7066
				Func_FreeLanceMaker_JarCandles = 67595U,
				// Token: 0x04001B9B RID: 7067
				Func_FreeLanceMaker_KidsBed = 67600U,
				// Token: 0x04001B9C RID: 7068
				Func_FreeLanceMaker_Kombucha = 67597U,
				// Token: 0x04001B9D RID: 7069
				Func_FreeLanceMaker_Rugs = 67593U,
				// Token: 0x04001B9E RID: 7070
				Func_FreeLanceMaker_ToFizz,
				// Token: 0x04001B9F RID: 7071
				Func_Freelancer_Canvas_Character_Design = 2177U,
				// Token: 0x04001BA0 RID: 7072
				Func_Freelancer_Canvas_Environment_Design,
				// Token: 0x04001BA1 RID: 7073
				Func_Freelancer_Canvas_Icon = 2183U,
				// Token: 0x04001BA2 RID: 7074
				Func_Freelancer_Canvas_Illustrative,
				// Token: 0x04001BA3 RID: 7075
				Func_Freelancer_Canvas_Logo = 2182U,
				// Token: 0x04001BA4 RID: 7076
				Func_Freelancer_Canvas_Portrait = 2179U,
				// Token: 0x04001BA5 RID: 7077
				Func_Freelancer_Canvas_Recreated_Art = 2181U,
				// Token: 0x04001BA6 RID: 7078
				Func_Freelancer_Canvas_Reference = 2185U,
				// Token: 0x04001BA7 RID: 7079
				Func_Freelancer_Canvas_Splash_Art = 2180U,
				// Token: 0x04001BA8 RID: 7080
				Func_Fridge = 1002U,
				// Token: 0x04001BA9 RID: 7081
				Func_Fridge_Mini = 2233U,
				// Token: 0x04001BAA RID: 7082
				Func_FrontDesk = 12331U,
				// Token: 0x04001BAB RID: 7083
				Func_Frosty = 1337U,
				// Token: 0x04001BAC RID: 7084
				Func_FruitCake = 1445U,
				// Token: 0x04001BAD RID: 7085
				Func_FruitPunchFountain = 8214U,
				// Token: 0x04001BAE RID: 7086
				Func_FryingPan = 2449U,
				// Token: 0x04001BAF RID: 7087
				Func_Fun = 999U,
				// Token: 0x04001BB0 RID: 7088
				Func_Future = 503U,
				// Token: 0x04001BB1 RID: 7089
				Func_Game = 481U,
				// Token: 0x04001BB2 RID: 7090
				Func_Gaming = 1075U,
				// Token: 0x04001BB3 RID: 7091
				Func_Garbage = 924U,
				// Token: 0x04001BB4 RID: 7092
				Func_Garden = 1150U,
				// Token: 0x04001BB5 RID: 7093
				Func_Garden_Flower = 59447U,
				// Token: 0x04001BB6 RID: 7094
				Func_Garden_Garlic = 40971U,
				// Token: 0x04001BB7 RID: 7095
				Func_Garden_Ghost_Destroy = 2176U,
				// Token: 0x04001BB8 RID: 7096
				Func_Garden_PlasmaTree = 40973U,
				// Token: 0x04001BB9 RID: 7097
				Func_Gardening = 1107U,
				// Token: 0x04001BBA RID: 7098
				Func_Gardening_Fertilizer_Bad = 862U,
				// Token: 0x04001BBB RID: 7099
				Func_Gardening_Fertilizer_High = 859U,
				// Token: 0x04001BBC RID: 7100
				Func_Gardening_Fertilizer_Low = 861U,
				// Token: 0x04001BBD RID: 7101
				Func_Gardening_Fertilizer_Max = 870U,
				// Token: 0x04001BBE RID: 7102
				Func_Gardening_Fertilizer_Med = 860U,
				// Token: 0x04001BBF RID: 7103
				Func_Gardening_ForbiddenFruit = 1708U,
				// Token: 0x04001BC0 RID: 7104
				Func_Gardening_Graftable = 2092U,
				// Token: 0x04001BC1 RID: 7105
				Func_Gardening_Growfruit = 1502U,
				// Token: 0x04001BC2 RID: 7106
				Func_Gardening_MoneyTree = 59482U,
				// Token: 0x04001BC3 RID: 7107
				Func_Gardening_Seed_Common = 831U,
				// Token: 0x04001BC4 RID: 7108
				Func_Gardening_Seed_Rare = 833U,
				// Token: 0x04001BC5 RID: 7109
				Func_Gardening_Seed_Uncommon = 832U,
				// Token: 0x04001BC6 RID: 7110
				Func_Gardening_Seeds = 1029U,
				// Token: 0x04001BC7 RID: 7111
				Func_Gardening_Sprinkler = 59437U,
				// Token: 0x04001BC8 RID: 7112
				Func_Gardening_Toxic = 10254U,
				// Token: 0x04001BC9 RID: 7113
				Func_Gardening_Wild = 1272U,
				// Token: 0x04001BCA RID: 7114
				Func_GardeningFlowers = 59463U,
				// Token: 0x04001BCB RID: 7115
				Func_GardeningSkillPlant = 1721U,
				// Token: 0x04001BCC RID: 7116
				Func_Garland = 1334U,
				// Token: 0x04001BCD RID: 7117
				Func_Garlic = 40962U,
				// Token: 0x04001BCE RID: 7118
				Func_Gate = 1390U,
				// Token: 0x04001BCF RID: 7119
				Func_GetsDirty = 2516U,
				// Token: 0x04001BD0 RID: 7120
				Func_Ghost = 1190U,
				// Token: 0x04001BD1 RID: 7121
				Func_GiveGift_NotGiftable = 2160U,
				// Token: 0x04001BD2 RID: 7122
				Func_GiveGiftReward = 2088U,
				// Token: 0x04001BD3 RID: 7123
				Func_Glass = 1432U,
				// Token: 0x04001BD4 RID: 7124
				Func_Gnome = 1365U,
				// Token: 0x04001BD5 RID: 7125
				Func_GnomeKickReward = 2087U,
				// Token: 0x04001BD6 RID: 7126
				Func_GoDancingObject_Visibility = 24587U,
				// Token: 0x04001BD7 RID: 7127
				Func_GoForWalk_DogInteractions = 57395U,
				// Token: 0x04001BD8 RID: 7128
				Func_Gondola_Bottom = 69654U,
				// Token: 0x04001BD9 RID: 7129
				Func_Gondola_Top = 69653U,
				// Token: 0x04001BDA RID: 7130
				Func_GourmetCooking = 1104U,
				// Token: 0x04001BDB RID: 7131
				Func_Graffiti = 55403U,
				// Token: 0x04001BDC RID: 7132
				Func_GrandMeal = 2095U,
				// Token: 0x04001BDD RID: 7133
				Func_Grass = 1093U,
				// Token: 0x04001BDE RID: 7134
				Func_Grave = 1198U,
				// Token: 0x04001BDF RID: 7135
				Func_Gravestone = 1203U,
				// Token: 0x04001BE0 RID: 7136
				Func_GreenScreen = 61465U,
				// Token: 0x04001BE1 RID: 7137
				Func_Grill_Recipe = 1247U,
				// Token: 0x04001BE2 RID: 7138
				Func_Guitar = 565U,
				// Token: 0x04001BE3 RID: 7139
				Func_Gym = 562U,
				// Token: 0x04001BE4 RID: 7140
				Func_Gypsy = 1183U,
				// Token: 0x04001BE5 RID: 7141
				Func_Habitat = 77826U,
				// Token: 0x04001BE6 RID: 7142
				Func_HairMakeUpChair = 61442U,
				// Token: 0x04001BE7 RID: 7143
				Func_HairPile = 57411U,
				// Token: 0x04001BE8 RID: 7144
				Func_Halloween = 1179U,
				// Token: 0x04001BE9 RID: 7145
				Func_Hamper = 75783U,
				// Token: 0x04001BEA RID: 7146
				Func_Hamster = 77828U,
				// Token: 0x04001BEB RID: 7147
				Func_Hand = 1209U,
				// Token: 0x04001BEC RID: 7148
				Func_Handiness = 1100U,
				// Token: 0x04001BED RID: 7149
				Func_Hanukkah = 1329U,
				// Token: 0x04001BEE RID: 7150
				Func_Hardwood = 1095U,
				// Token: 0x04001BEF RID: 7151
				Func_Harvestable = 2126U,
				// Token: 0x04001BF0 RID: 7152
				Func_Harvestable_Rare = 2072U,
				// Token: 0x04001BF1 RID: 7153
				Func_Harvestable_SuperRare = 2074U,
				// Token: 0x04001BF2 RID: 7154
				Func_Harvestable_Uncommon = 2073U,
				// Token: 0x04001BF3 RID: 7155
				Func_Haunted = 1223U,
				// Token: 0x04001BF4 RID: 7156
				Func_HauntedPainting = 86028U,
				// Token: 0x04001BF5 RID: 7157
				Func_Head = 1213U,
				// Token: 0x04001BF6 RID: 7158
				Func_Health = 475U,
				// Token: 0x04001BF7 RID: 7159
				Func_Heart = 1369U,
				// Token: 0x04001BF8 RID: 7160
				Func_HeatLamp = 14338U,
				// Token: 0x04001BF9 RID: 7161
				Func_HeatLamp_BG = 1520U,
				// Token: 0x04001BFA RID: 7162
				Func_Hedgehog = 77829U,
				// Token: 0x04001BFB RID: 7163
				Func_Herbalism = 10249U,
				// Token: 0x04001BFC RID: 7164
				Func_HerbalismIngredient = 10251U,
				// Token: 0x04001BFD RID: 7165
				Func_HerbalismIngredient_Chamomile = 10271U,
				// Token: 0x04001BFE RID: 7166
				Func_HerbalismIngredient_Elderberry,
				// Token: 0x04001BFF RID: 7167
				Func_HerbalismIngredient_Fireleaf,
				// Token: 0x04001C00 RID: 7168
				Func_HerbalismIngredient_Huckleberry,
				// Token: 0x04001C01 RID: 7169
				Func_HerbalismIngredient_MorelMushroom,
				// Token: 0x04001C02 RID: 7170
				Func_HerbalismPlant = 10250U,
				// Token: 0x04001C03 RID: 7171
				Func_HerbalismPotion = 10255U,
				// Token: 0x04001C04 RID: 7172
				Func_Hideable = 1914U,
				// Token: 0x04001C05 RID: 7173
				Func_HighChair = 1654U,
				// Token: 0x04001C06 RID: 7174
				Func_HighChairDrink = 1695U,
				// Token: 0x04001C07 RID: 7175
				Func_HighChairFood = 1694U,
				// Token: 0x04001C08 RID: 7176
				Func_HoildayTree_Ornaments = 59411U,
				// Token: 0x04001C09 RID: 7177
				Func_Holiday = 1326U,
				// Token: 0x04001C0A RID: 7178
				Func_Holiday_Candle = 2128U,
				// Token: 0x04001C0B RID: 7179
				Func_Holiday_DecoObjects = 2098U,
				// Token: 0x04001C0C RID: 7180
				Func_Holiday_FestiveLighting = 2129U,
				// Token: 0x04001C0D RID: 7181
				Func_HolidayCandle = 59478U,
				// Token: 0x04001C0E RID: 7182
				Func_HolidayGnome_Group01 = 2121U,
				// Token: 0x04001C0F RID: 7183
				Func_HolidayGnome_Group02,
				// Token: 0x04001C10 RID: 7184
				Func_HolidayGnome_Group03,
				// Token: 0x04001C11 RID: 7185
				Func_HolidayGnome_Group04,
				// Token: 0x04001C12 RID: 7186
				Func_HolidayTradition_Baking_Recipe = 2116U,
				// Token: 0x04001C13 RID: 7187
				Func_HolidayTradition_Bonfire = 2109U,
				// Token: 0x04001C14 RID: 7188
				Func_HolidayTradition_Deco_BeRomantic = 2108U,
				// Token: 0x04001C15 RID: 7189
				Func_HolidayTradition_HaveDecorations = 2110U,
				// Token: 0x04001C16 RID: 7190
				Func_HolidayTradition_OpenPresents,
				// Token: 0x04001C17 RID: 7191
				Func_HolidayTradition_Party,
				// Token: 0x04001C18 RID: 7192
				Func_HolidayTree = 59409U,
				// Token: 0x04001C19 RID: 7193
				Func_HolidayTree_Garland = 59412U,
				// Token: 0x04001C1A RID: 7194
				Func_HolidayTree_Skirt,
				// Token: 0x04001C1B RID: 7195
				Func_HolidayTree_Topper,
				// Token: 0x04001C1C RID: 7196
				Func_Holotable = 51223U,
				// Token: 0x04001C1D RID: 7197
				Func_Holotable_FirstOrder_Purchase = 51207U,
				// Token: 0x04001C1E RID: 7198
				Func_Holotable_Resistance_Purchase,
				// Token: 0x04001C1F RID: 7199
				Func_Honey = 59450U,
				// Token: 0x04001C20 RID: 7200
				Func_Hood = 1168U,
				// Token: 0x04001C21 RID: 7201
				Func_Hoop = 553U,
				// Token: 0x04001C22 RID: 7202
				Func_Hospital = 1377U,
				// Token: 0x04001C23 RID: 7203
				Func_HostStation = 26628U,
				// Token: 0x04001C24 RID: 7204
				Func_HotSauce = 1300U,
				// Token: 0x04001C25 RID: 7205
				Func_HotSprings = 69675U,
				// Token: 0x04001C26 RID: 7206
				Func_HotTub = 1444U,
				// Token: 0x04001C27 RID: 7207
				Func_House = 1224U,
				// Token: 0x04001C28 RID: 7208
				Func_HouseholdInventoryObjectProxy = 2388U,
				// Token: 0x04001C29 RID: 7209
				Func_Hunger = 996U,
				// Token: 0x04001C2A RID: 7210
				Func_Hutch = 1030U,
				// Token: 0x04001C2B RID: 7211
				Func_Hydraulic = 1429U,
				// Token: 0x04001C2C RID: 7212
				Func_Hygiene = 998U,
				// Token: 0x04001C2D RID: 7213
				Func_IceChest = 1249U,
				// Token: 0x04001C2E RID: 7214
				Func_IceCream = 20486U,
				// Token: 0x04001C2F RID: 7215
				Func_IceCreamBowl = 20483U,
				// Token: 0x04001C30 RID: 7216
				Func_IceCreamCarton = 20482U,
				// Token: 0x04001C31 RID: 7217
				Func_IceCreamCone = 20484U,
				// Token: 0x04001C32 RID: 7218
				Func_IceCreamMachine = 20481U,
				// Token: 0x04001C33 RID: 7219
				Func_IceCreamMilkShake = 20485U,
				// Token: 0x04001C34 RID: 7220
				Func_ImportantItems = 2283U,
				// Token: 0x04001C35 RID: 7221
				Func_Incense = 18442U,
				// Token: 0x04001C36 RID: 7222
				Func_InfectedPlant = 47129U,
				// Token: 0x04001C37 RID: 7223
				Func_Inflatable = 1286U,
				// Token: 0x04001C38 RID: 7224
				Func_InfoBoard = 69714U,
				// Token: 0x04001C39 RID: 7225
				Func_Ingredient = 523U,
				// Token: 0x04001C3A RID: 7226
				Func_Ingredient_ArtisanHerbBread = 12302U,
				// Token: 0x04001C3B RID: 7227
				Func_Ingredient_Beetle = 10253U,
				// Token: 0x04001C3C RID: 7228
				Func_Ingredient_CowplantEssence = 12373U,
				// Token: 0x04001C3D RID: 7229
				Func_Ingredient_Crawdad = 10241U,
				// Token: 0x04001C3E RID: 7230
				Func_Ingredient_Crystal = 1345U,
				// Token: 0x04001C3F RID: 7231
				Func_Ingredient_Crystal_Alien = 12386U,
				// Token: 0x04001C40 RID: 7232
				Func_Ingredient_Crystal_Common = 1349U,
				// Token: 0x04001C41 RID: 7233
				Func_Ingredient_Crystal_Rare = 1351U,
				// Token: 0x04001C42 RID: 7234
				Func_Ingredient_Crystal_Uncommon = 1350U,
				// Token: 0x04001C43 RID: 7235
				Func_Ingredient_ExoticFruitPie = 12305U,
				// Token: 0x04001C44 RID: 7236
				Func_Ingredient_ExoticFruitTart = 12301U,
				// Token: 0x04001C45 RID: 7237
				Func_Ingredient_Fish = 817U,
				// Token: 0x04001C46 RID: 7238
				Func_Ingredient_Fish_Pufferfish = 55335U,
				// Token: 0x04001C47 RID: 7239
				Func_Ingredient_FishPie = 12303U,
				// Token: 0x04001C48 RID: 7240
				Func_Ingredient_FizzyJuice = 67631U,
				// Token: 0x04001C49 RID: 7241
				Func_Ingredient_FizzyJuice_EP09 = 2429U,
				// Token: 0x04001C4A RID: 7242
				Func_Ingredient_Fruit = 795U,
				// Token: 0x04001C4B RID: 7243
				Func_Ingredient_Fruitcake_Set1 = 12307U,
				// Token: 0x04001C4C RID: 7244
				Func_Ingredient_Fruitcake_Set2,
				// Token: 0x04001C4D RID: 7245
				Func_Ingredient_FruitMuffins = 12298U,
				// Token: 0x04001C4E RID: 7246
				Func_Ingredient_FruitScones,
				// Token: 0x04001C4F RID: 7247
				Func_Ingredient_Grimbucha_EP09 = 2432U,
				// Token: 0x04001C50 RID: 7248
				Func_Ingredient_Herb = 816U,
				// Token: 0x04001C51 RID: 7249
				Func_Ingredient_InfectedSpore = 47142U,
				// Token: 0x04001C52 RID: 7250
				Func_Ingredient_Insect = 1242U,
				// Token: 0x04001C53 RID: 7251
				Func_Ingredient_JellyFilledDoughnuts = 12306U,
				// Token: 0x04001C54 RID: 7252
				Func_Ingredient_Kombucha = 67632U,
				// Token: 0x04001C55 RID: 7253
				Func_Ingredient_Kombucha_EP09 = 2430U,
				// Token: 0x04001C56 RID: 7254
				Func_Ingredient_Locust = 10242U,
				// Token: 0x04001C57 RID: 7255
				Func_Ingredient_Metal = 1344U,
				// Token: 0x04001C58 RID: 7256
				Func_Ingredient_Metal_Alien = 12387U,
				// Token: 0x04001C59 RID: 7257
				Func_Ingredient_Metal_Common = 1346U,
				// Token: 0x04001C5A RID: 7258
				Func_Ingredient_Metal_Rare = 1348U,
				// Token: 0x04001C5B RID: 7259
				Func_Ingredient_Metal_Uncommon = 1347U,
				// Token: 0x04001C5C RID: 7260
				Func_Ingredient_Mushroom = 1243U,
				// Token: 0x04001C5D RID: 7261
				Func_Ingredient_Plant_Alien = 12388U,
				// Token: 0x04001C5E RID: 7262
				Func_Ingredient_RainbowGelatinCake_Set1 = 12309U,
				// Token: 0x04001C5F RID: 7263
				Func_Ingredient_RainbowGelatinCake_Set2,
				// Token: 0x04001C60 RID: 7264
				Func_Ingredient_RoseQuartz = 12364U,
				// Token: 0x04001C61 RID: 7265
				Func_Ingredient_Seltzer = 67633U,
				// Token: 0x04001C62 RID: 7266
				Func_Ingredient_StandardFruitPie = 12304U,
				// Token: 0x04001C63 RID: 7267
				Func_Ingredient_StandardFruitTart = 12300U,
				// Token: 0x04001C64 RID: 7268
				Func_Ingredient_Suspicious = 67634U,
				// Token: 0x04001C65 RID: 7269
				Func_Ingredient_Suspicious_EP09 = 2431U,
				// Token: 0x04001C66 RID: 7270
				Func_Ingredient_WaxBlock = 67636U,
				// Token: 0x04001C67 RID: 7271
				Func_Ingredient_Veggie = 815U,
				// Token: 0x04001C68 RID: 7272
				Func_Insane_TalkToObjects = 1929U,
				// Token: 0x04001C69 RID: 7273
				Func_InsectFarm = 67592U,
				// Token: 0x04001C6A RID: 7274
				Func_Instrument = 570U,
				// Token: 0x04001C6B RID: 7275
				Func_Instruments = 1413U,
				// Token: 0x04001C6C RID: 7276
				Func_InteractiveBush = 24588U,
				// Token: 0x04001C6D RID: 7277
				Func_InteractiveBush_BG = 2070U,
				// Token: 0x04001C6E RID: 7278
				Func_InteractiveCloset = 24589U,
				// Token: 0x04001C6F RID: 7279
				Func_InteriorDecorator_GigObject_Weird = 53253U,
				// Token: 0x04001C70 RID: 7280
				Func_InteriorDecorator_New = 53251U,
				// Token: 0x04001C71 RID: 7281
				Func_InventionConstructor = 12394U,
				// Token: 0x04001C72 RID: 7282
				Func_Investigation_Dossier = 47165U,
				// Token: 0x04001C73 RID: 7283
				Func_Investigation_HazmatSuit = 47147U,
				// Token: 0x04001C74 RID: 7284
				Func_Investigation_JunkPile = 47126U,
				// Token: 0x04001C75 RID: 7285
				Func_Investigation_Keycard = 47164U,
				// Token: 0x04001C76 RID: 7286
				Func_Investigation_SealDoor_Floor = 47136U,
				// Token: 0x04001C77 RID: 7287
				Func_Investigation_SealedDoor_Hallway = 47138U,
				// Token: 0x04001C78 RID: 7288
				Func_Investigation_SealedDoor_MotherPlant = 47137U,
				// Token: 0x04001C79 RID: 7289
				Func_Investigation_SporeFilter = 47146U,
				// Token: 0x04001C7A RID: 7290
				Func_Investigation_SporeSample = 47135U,
				// Token: 0x04001C7B RID: 7291
				Func_InvestigationEvidence = 47106U,
				// Token: 0x04001C7C RID: 7292
				Func_Invisible = 1219U,
				// Token: 0x04001C7D RID: 7293
				Func_IslandCanoe = 63501U,
				// Token: 0x04001C7E RID: 7294
				Func_IslandCanoe_BeachVenue = 2198U,
				// Token: 0x04001C7F RID: 7295
				Func_IslandSpirit = 63497U,
				// Token: 0x04001C80 RID: 7296
				Func_IslandSpirit_Inactive,
				// Token: 0x04001C81 RID: 7297
				Func_Item_Batuu = 2464U,
				// Token: 0x04001C82 RID: 7298
				Func_Jackolantern = 1206U,
				// Token: 0x04001C83 RID: 7299
				Func_Jail = 1379U,
				// Token: 0x04001C84 RID: 7300
				Func_Jig = 1342U,
				// Token: 0x04001C85 RID: 7301
				Func_Journal = 43009U,
				// Token: 0x04001C86 RID: 7302
				Func_Journal_BaseGame = 1724U,
				// Token: 0x04001C87 RID: 7303
				Func_Journalist = 1118U,
				// Token: 0x04001C88 RID: 7304
				Func_JuiceFizzer = 67629U,
				// Token: 0x04001C89 RID: 7305
				Func_JuiceFizzingProduct = 67635U,
				// Token: 0x04001C8A RID: 7306
				Func_JuiceKeg = 65539U,
				// Token: 0x04001C8B RID: 7307
				Func_JuiceKeg_Confident = 65543U,
				// Token: 0x04001C8C RID: 7308
				Func_JuiceKeg_Flirty = 65542U,
				// Token: 0x04001C8D RID: 7309
				Func_JuiceKeg_Happy = 65544U,
				// Token: 0x04001C8E RID: 7310
				Func_JuiceKeg_Playful,
				// Token: 0x04001C8F RID: 7311
				Func_JumpStand = 24604U,
				// Token: 0x04001C90 RID: 7312
				Func_Jungle = 563U,
				// Token: 0x04001C91 RID: 7313
				Func_JungleGym = 1034U,
				// Token: 0x04001C92 RID: 7314
				Func_KaraokeMachine = 1581U,
				// Token: 0x04001C93 RID: 7315
				Func_Kerosene = 1282U,
				// Token: 0x04001C94 RID: 7316
				Func_Ketchup = 1298U,
				// Token: 0x04001C95 RID: 7317
				Func_Kettle = 1221U,
				// Token: 0x04001C96 RID: 7318
				Func_Kid = 1091U,
				// Token: 0x04001C97 RID: 7319
				Func_KiddiePool = 59462U,
				// Token: 0x04001C98 RID: 7320
				Func_KidsTent = 2554U,
				// Token: 0x04001C99 RID: 7321
				Func_Knife = 1140U,
				// Token: 0x04001C9A RID: 7322
				Func_Knitting = 83992U,
				// Token: 0x04001C9B RID: 7323
				Func_Knitting_BabyOnesie = 83983U,
				// Token: 0x04001C9C RID: 7324
				Func_Knitting_Beanie = 83973U,
				// Token: 0x04001C9D RID: 7325
				Func_Knitting_ChildSweater = 83988U,
				// Token: 0x04001C9E RID: 7326
				Func_Knitting_Clothing = 83993U,
				// Token: 0x04001C9F RID: 7327
				Func_Knitting_Decoration = 83979U,
				// Token: 0x04001CA0 RID: 7328
				Func_Knitting_Furnishing = 83975U,
				// Token: 0x04001CA1 RID: 7329
				Func_Knitting_Gifted = 83990U,
				// Token: 0x04001CA2 RID: 7330
				Func_Knitting_Grim = 83987U,
				// Token: 0x04001CA3 RID: 7331
				Func_Knitting_Onesie = 83980U,
				// Token: 0x04001CA4 RID: 7332
				Func_Knitting_Pouffe = 83978U,
				// Token: 0x04001CA5 RID: 7333
				Func_Knitting_Rug = 83976U,
				// Token: 0x04001CA6 RID: 7334
				Func_Knitting_Socks = 83974U,
				// Token: 0x04001CA7 RID: 7335
				Func_Knitting_Sweater = 83977U,
				// Token: 0x04001CA8 RID: 7336
				Func_Knitting_SweaterScarf = 83981U,
				// Token: 0x04001CA9 RID: 7337
				Func_Knitting_Toy,
				// Token: 0x04001CAA RID: 7338
				Func_Knitting_WIP = 2463U,
				// Token: 0x04001CAB RID: 7339
				Func_Knives = 1141U,
				// Token: 0x04001CAC RID: 7340
				Func_Knowledge = 24595U,
				// Token: 0x04001CAD RID: 7341
				Func_Kwanzaa = 1330U,
				// Token: 0x04001CAE RID: 7342
				Func_Lab = 1400U,
				// Token: 0x04001CAF RID: 7343
				Func_LabDoor = 47105U,
				// Token: 0x04001CB0 RID: 7344
				Func_Ladder = 1230U,
				// Token: 0x04001CB1 RID: 7345
				Func_Lamp = 1283U,
				// Token: 0x04001CB2 RID: 7346
				Func_LampPost = 1293U,
				// Token: 0x04001CB3 RID: 7347
				Func_Landfill_DumpableAppliance = 67607U,
				// Token: 0x04001CB4 RID: 7348
				Func_Lantern = 1205U,
				// Token: 0x04001CB5 RID: 7349
				Func_Laptop = 515U,
				// Token: 0x04001CB6 RID: 7350
				Func_Laser = 1396U,
				// Token: 0x04001CB7 RID: 7351
				Func_LaserLight = 24577U,
				// Token: 0x04001CB8 RID: 7352
				Func_Laundry_ClothesLine = 75781U,
				// Token: 0x04001CB9 RID: 7353
				Func_Laundry_Dryer = 75779U,
				// Token: 0x04001CBA RID: 7354
				Func_Laundry_Hamper = 2033U,
				// Token: 0x04001CBB RID: 7355
				Func_Laundry_Hero_Object = 2032U,
				// Token: 0x04001CBC RID: 7356
				Func_Laundry_Pile = 75777U,
				// Token: 0x04001CBD RID: 7357
				Func_Laundry_SearchTerm = 75782U,
				// Token: 0x04001CBE RID: 7358
				Func_Laundry_WashingMachine = 75778U,
				// Token: 0x04001CBF RID: 7359
				Func_Laundry_WashTub = 75780U,
				// Token: 0x04001CC0 RID: 7360
				Func_LavaRock = 63499U,
				// Token: 0x04001CC1 RID: 7361
				Func_LeafPile = 59432U,
				// Token: 0x04001CC2 RID: 7362
				Func_Lectern = 55405U,
				// Token: 0x04001CC3 RID: 7363
				Func_Lifestyles_Electronics = 2493U,
				// Token: 0x04001CC4 RID: 7364
				Func_Lifestyles_TechBook = 2505U,
				// Token: 0x04001CC5 RID: 7365
				Func_Lifestyles_TechSchoolProject,
				// Token: 0x04001CC6 RID: 7366
				Func_Light_CandleWithAutoLights = 1446U,
				// Token: 0x04001CC7 RID: 7367
				Func_Light_NoAuto_Lights = 1325U,
				// Token: 0x04001CC8 RID: 7368
				Func_Light_NonElectric = 1374U,
				// Token: 0x04001CC9 RID: 7369
				Func_Lighting_NotStageLights = 61467U,
				// Token: 0x04001CCA RID: 7370
				Func_Lightning_CanStrike = 2076U,
				// Token: 0x04001CCB RID: 7371
				Func_Lightning_Cleanup = 59491U,
				// Token: 0x04001CCC RID: 7372
				Func_Lightning_Object = 59440U,
				// Token: 0x04001CCD RID: 7373
				Func_Lights = 1338U,
				// Token: 0x04001CCE RID: 7374
				Func_Lightsaber_Crystal = 51203U,
				// Token: 0x04001CCF RID: 7375
				Func_Lightsaber_Hilt,
				// Token: 0x04001CD0 RID: 7376
				Func_Linoleum = 1097U,
				// Token: 0x04001CD1 RID: 7377
				Func_ListeningDevice_Bug = 47145U,
				// Token: 0x04001CD2 RID: 7378
				Func_LitterBox = 57355U,
				// Token: 0x04001CD3 RID: 7379
				Func_LitterBox_HighTech = 57360U,
				// Token: 0x04001CD4 RID: 7380
				Func_LiveDragAllowedWithChildren = 1722U,
				// Token: 0x04001CD5 RID: 7381
				Func_LivingChair = 1005U,
				// Token: 0x04001CD6 RID: 7382
				Func_Locator_BeachPortal = 2187U,
				// Token: 0x04001CD7 RID: 7383
				Func_Locator_TerrainWalkstylePortal = 2482U,
				// Token: 0x04001CD8 RID: 7384
				Func_Log = 1307U,
				// Token: 0x04001CD9 RID: 7385
				Func_Logic = 1098U,
				// Token: 0x04001CDA RID: 7386
				Func_Lotus = 1288U,
				// Token: 0x04001CDB RID: 7387
				Func_LoungeEvent_AwardTrophy = 61632U,
				// Token: 0x04001CDC RID: 7388
				Func_Machine = 578U,
				// Token: 0x04001CDD RID: 7389
				Func_Magazine = 1405U,
				// Token: 0x04001CDE RID: 7390
				Func_Magic_Broom = 49169U,
				// Token: 0x04001CDF RID: 7391
				Func_MagicBean = 1701U,
				// Token: 0x04001CE0 RID: 7392
				Func_MagicBean_AngryRed,
				// Token: 0x04001CE1 RID: 7393
				Func_MagicBean_ConfidentLightBlue = 1707U,
				// Token: 0x04001CE2 RID: 7394
				Func_MagicBean_FlirtyPink = 1705U,
				// Token: 0x04001CE3 RID: 7395
				Func_MagicBean_PlayfulGreen = 1703U,
				// Token: 0x04001CE4 RID: 7396
				Func_MagicBean_SadNavyBlue = 1706U,
				// Token: 0x04001CE5 RID: 7397
				Func_MagicBean_UncomfortableOrange = 1704U,
				// Token: 0x04001CE6 RID: 7398
				Func_MagicPortal_DuelingtoHQ = 49159U,
				// Token: 0x04001CE7 RID: 7399
				Func_MagicPortal_HQtoDueling,
				// Token: 0x04001CE8 RID: 7400
				Func_MagicPortal_HQtoMarket,
				// Token: 0x04001CE9 RID: 7401
				Func_MagicPortal_HQtoVista,
				// Token: 0x04001CEA RID: 7402
				Func_MagicPortal_MarkettoHQ,
				// Token: 0x04001CEB RID: 7403
				Func_MagicPortal_VistatoHQ,
				// Token: 0x04001CEC RID: 7404
				Func_MahiMahi = 63509U,
				// Token: 0x04001CED RID: 7405
				Func_Mailbox = 954U,
				// Token: 0x04001CEE RID: 7406
				Func_MailboxWall = 2168U,
				// Token: 0x04001CEF RID: 7407
				Func_MakeupTable = 36868U,
				// Token: 0x04001CF0 RID: 7408
				Func_Mannequin = 1322U,
				// Token: 0x04001CF1 RID: 7409
				Func_Mansion = 1225U,
				// Token: 0x04001CF2 RID: 7410
				Func_Map = 1312U,
				// Token: 0x04001CF3 RID: 7411
				Func_MarketStall = 55298U,
				// Token: 0x04001CF4 RID: 7412
				Func_MarketStalls = 1932U,
				// Token: 0x04001CF5 RID: 7413
				Func_MarketStalls_Dockyard_Pets = 57410U,
				// Token: 0x04001CF6 RID: 7414
				Func_MarketStalls_PurchaseFood = 2378U,
				// Token: 0x04001CF7 RID: 7415
				Func_Marketstalls_PurchaseNonFood,
				// Token: 0x04001CF8 RID: 7416
				Func_MarketStalls_Seafood = 1936U,
				// Token: 0x04001CF9 RID: 7417
				Func_MarketStalls_Seasonal_Fall = 59404U,
				// Token: 0x04001CFA RID: 7418
				Func_MarketStalls_Seasonal_Spring = 59403U,
				// Token: 0x04001CFB RID: 7419
				Func_MarketStalls_Seasonal_Summer = 59402U,
				// Token: 0x04001CFC RID: 7420
				Func_MarketStalls_Seasonal_Winter = 59405U,
				// Token: 0x04001CFD RID: 7421
				Func_MarketStalls_SquareSnacks = 57405U,
				// Token: 0x04001CFE RID: 7422
				Func_MarketStalls_SquareSnacks_Pets,
				// Token: 0x04001CFF RID: 7423
				Func_Mascot = 1295U,
				// Token: 0x04001D00 RID: 7424
				Func_Masonry = 1096U,
				// Token: 0x04001D01 RID: 7425
				Func_Massage = 18454U,
				// Token: 0x04001D02 RID: 7426
				Func_MassageChair = 18440U,
				// Token: 0x04001D03 RID: 7427
				Func_MassageTable = 18434U,
				// Token: 0x04001D04 RID: 7428
				Func_Mattress = 1285U,
				// Token: 0x04001D05 RID: 7429
				Func_Meal = 521U,
				// Token: 0x04001D06 RID: 7430
				Func_Meatwall = 67648U,
				// Token: 0x04001D07 RID: 7431
				Func_MechSuit_Body = 65639U,
				// Token: 0x04001D08 RID: 7432
				Func_MechSuit_Head,
				// Token: 0x04001D09 RID: 7433
				Func_Meditation = 18452U,
				// Token: 0x04001D0A RID: 7434
				Func_MeditationStool = 18438U,
				// Token: 0x04001D0B RID: 7435
				Func_Medium = 1188U,
				// Token: 0x04001D0C RID: 7436
				Func_Megaphone = 55406U,
				// Token: 0x04001D0D RID: 7437
				Func_Mental = 24599U,
				// Token: 0x04001D0E RID: 7438
				Func_MerchVendingMachine = 2508U,
				// Token: 0x04001D0F RID: 7439
				Func_Mess = 43031U,
				// Token: 0x04001D10 RID: 7440
				Func_Metal = 1090U,
				// Token: 0x04001D11 RID: 7441
				Func_Microphone = 488U,
				// Token: 0x04001D12 RID: 7442
				Func_Microscope = 857U,
				// Token: 0x04001D13 RID: 7443
				Func_Microwave = 526U,
				// Token: 0x04001D14 RID: 7444
				Func_MilitaryCareer_Medal = 47143U,
				// Token: 0x04001D15 RID: 7445
				Func_MiniBots = 65582U,
				// Token: 0x04001D16 RID: 7446
				Func_Minibots_Party = 65641U,
				// Token: 0x04001D17 RID: 7447
				Func_Minibots_Worker = 2275U,
				// Token: 0x04001D18 RID: 7448
				Func_Mirror_NoVanity = 2165U,
				// Token: 0x04001D19 RID: 7449
				Func_Mixologist = 1116U,
				// Token: 0x04001D1A RID: 7450
				Func_Mixology = 1103U,
				// Token: 0x04001D1B RID: 7451
				Func_Model = 1158U,
				// Token: 0x04001D1C RID: 7452
				Func_Monkey = 564U,
				// Token: 0x04001D1D RID: 7453
				Func_MonkeyBars = 1001U,
				// Token: 0x04001D1E RID: 7454
				Func_Monster = 1217U,
				// Token: 0x04001D1F RID: 7455
				Func_MotherPlant = 47131U,
				// Token: 0x04001D20 RID: 7456
				Func_Motherplant_Pit = 47144U,
				// Token: 0x04001D21 RID: 7457
				Func_Motion = 480U,
				// Token: 0x04001D22 RID: 7458
				Func_MotionGamingRig = 1016U,
				// Token: 0x04001D23 RID: 7459
				Func_Motor = 24598U,
				// Token: 0x04001D24 RID: 7460
				Func_Movie = 1498U,
				// Token: 0x04001D25 RID: 7461
				Func_Mudbath = 18456U,
				// Token: 0x04001D26 RID: 7462
				Func_MudPuddle = 59406U,
				// Token: 0x04001D27 RID: 7463
				Func_Mug = 1301U,
				// Token: 0x04001D28 RID: 7464
				Func_Mural = 55371U,
				// Token: 0x04001D29 RID: 7465
				Func_Music = 491U,
				// Token: 0x04001D2A RID: 7466
				Func_MusicDisc = 61470U,
				// Token: 0x04001D2B RID: 7467
				Func_Musician = 1083U,
				// Token: 0x04001D2C RID: 7468
				Func_MusicProductionStation = 61469U,
				// Token: 0x04001D2D RID: 7469
				Func_Mustard = 1299U,
				// Token: 0x04001D2E RID: 7470
				Func_MysticalRelic_Bottom = 45067U,
				// Token: 0x04001D2F RID: 7471
				Func_MysticalRelic_Crystal,
				// Token: 0x04001D30 RID: 7472
				Func_MysticalRelic_Fused = 45078U,
				// Token: 0x04001D31 RID: 7473
				Func_MysticalRelic_Top = 45066U,
				// Token: 0x04001D32 RID: 7474
				Func_MysticalRelic_Unbreakable = 45111U,
				// Token: 0x04001D33 RID: 7475
				Func_Nectar = 1527U,
				// Token: 0x04001D34 RID: 7476
				Func_Neon = 12400U,
				// Token: 0x04001D35 RID: 7477
				Func_NestingBlocks = 1662U,
				// Token: 0x04001D36 RID: 7478
				Func_NeverReceivesSnow = 2069U,
				// Token: 0x04001D37 RID: 7479
				Func_NoCleanUpFromInventory = 2210U,
				// Token: 0x04001D38 RID: 7480
				Func_NonBarJuiceEnthusiastQuirk = 2144U,
				// Token: 0x04001D39 RID: 7481
				Func_Object_Upgrade_Part = 780U,
				// Token: 0x04001D3A RID: 7482
				Func_Observatory = 572U,
				// Token: 0x04001D3B RID: 7483
				Func_OffTheGrid = 2219U,
				// Token: 0x04001D3C RID: 7484
				Func_OffTheGrid_Toggle_UtilityUsage = 2427U,
				// Token: 0x04001D3D RID: 7485
				Func_Oracle = 1185U,
				// Token: 0x04001D3E RID: 7486
				Func_Orrery = 12429U,
				// Token: 0x04001D3F RID: 7487
				Func_Ottoman = 1007U,
				// Token: 0x04001D40 RID: 7488
				Func_Outdoor = 1430U,
				// Token: 0x04001D41 RID: 7489
				Func_OutdoorChair = 1004U,
				// Token: 0x04001D42 RID: 7490
				Func_OutdoorPlant = 1013U,
				// Token: 0x04001D43 RID: 7491
				Func_Outdoors = 1280U,
				// Token: 0x04001D44 RID: 7492
				Func_Oven = 748U,
				// Token: 0x04001D45 RID: 7493
				Func_Paint = 483U,
				// Token: 0x04001D46 RID: 7494
				Func_Painter = 1120U,
				// Token: 0x04001D47 RID: 7495
				Func_Painting = 894U,
				// Token: 0x04001D48 RID: 7496
				Func_PaintingHaunted = 2515U,
				// Token: 0x04001D49 RID: 7497
				Func_Pans = 1296U,
				// Token: 0x04001D4A RID: 7498
				Func_Paper = 1418U,
				// Token: 0x04001D4B RID: 7499
				Func_PaperPosted = 43010U,
				// Token: 0x04001D4C RID: 7500
				Func_ParkFountain = 30721U,
				// Token: 0x04001D4D RID: 7501
				Func_Party = 529U,
				// Token: 0x04001D4E RID: 7502
				Func_PathObstacleJungle_01_entrance = 45060U,
				// Token: 0x04001D4F RID: 7503
				Func_PathObstacleJungle_01_exit,
				// Token: 0x04001D50 RID: 7504
				Func_PathObstacleJungle_02_entrance,
				// Token: 0x04001D51 RID: 7505
				Func_PathObstacleJungle_02_exit,
				// Token: 0x04001D52 RID: 7506
				Func_PathObstacleJungle_03_entrance = 45080U,
				// Token: 0x04001D53 RID: 7507
				Func_PathObstacleJungle_03_exit,
				// Token: 0x04001D54 RID: 7508
				Func_PathObstacleJungle_04_entrance,
				// Token: 0x04001D55 RID: 7509
				Func_PathObstacleJungle_04_exit,
				// Token: 0x04001D56 RID: 7510
				Func_PathObstacleJungle_05_entrance,
				// Token: 0x04001D57 RID: 7511
				Func_PathObstacleJungle_05_exit,
				// Token: 0x04001D58 RID: 7512
				Func_PathObstacleJungle_06_entrance,
				// Token: 0x04001D59 RID: 7513
				Func_PathObstacleJungle_06_exit,
				// Token: 0x04001D5A RID: 7514
				Func_PathObstacleJungle_Pool_entrance = 45095U,
				// Token: 0x04001D5B RID: 7515
				Func_PathObstacleJungle_Pool_exit,
				// Token: 0x04001D5C RID: 7516
				Func_PathObstacleJungle_temple_entrance = 45064U,
				// Token: 0x04001D5D RID: 7517
				Func_PathObstacleJungle_temple_exit,
				// Token: 0x04001D5E RID: 7518
				Func_PatioFurniture = 1011U,
				// Token: 0x04001D5F RID: 7519
				Func_Pedestal = 1399U,
				// Token: 0x04001D60 RID: 7520
				Func_PerformanceSpace = 55299U,
				// Token: 0x04001D61 RID: 7521
				Func_Pet_Bush = 57445U,
				// Token: 0x04001D62 RID: 7522
				Func_Pet_DirtMound = 57448U,
				// Token: 0x04001D63 RID: 7523
				Func_Pet_DogToy = 57454U,
				// Token: 0x04001D64 RID: 7524
				Func_Pet_Fishpile = 57446U,
				// Token: 0x04001D65 RID: 7525
				Func_Pet_Gift = 57444U,
				// Token: 0x04001D66 RID: 7526
				Func_Pet_HideNoFade = 2031U,
				// Token: 0x04001D67 RID: 7527
				Func_Pet_Minor_Cage = 77825U,
				// Token: 0x04001D68 RID: 7528
				Func_Pet_Minor_Cage_BG = 2052U,
				// Token: 0x04001D69 RID: 7529
				Func_Pet_NoRouteUnder = 2028U,
				// Token: 0x04001D6A RID: 7530
				Func_Pet_Poop = 57361U,
				// Token: 0x04001D6B RID: 7531
				Func_Pet_Poop_NoClean = 57455U,
				// Token: 0x04001D6C RID: 7532
				Func_Pet_Seaweed = 57447U,
				// Token: 0x04001D6D RID: 7533
				Func_Pet_Vacuum = 2518U,
				// Token: 0x04001D6E RID: 7534
				Func_PetBall = 57412U,
				// Token: 0x04001D6F RID: 7535
				Func_PetBed = 57386U,
				// Token: 0x04001D70 RID: 7536
				Func_PetBowl = 1876U,
				// Token: 0x04001D71 RID: 7537
				Func_PetCatnip = 57421U,
				// Token: 0x04001D72 RID: 7538
				Func_PetCrate = 57388U,
				// Token: 0x04001D73 RID: 7539
				Func_PetFearSounds_BG = 2171U,
				// Token: 0x04001D74 RID: 7540
				Func_PetFiller = 57380U,
				// Token: 0x04001D75 RID: 7541
				Func_PetFillerThree = 57382U,
				// Token: 0x04001D76 RID: 7542
				Func_PetFillerTwo = 57381U,
				// Token: 0x04001D77 RID: 7543
				Func_PetFood = 57379U,
				// Token: 0x04001D78 RID: 7544
				Func_PetObstacleCourse = 57415U,
				// Token: 0x04001D79 RID: 7545
				Func_PetObstacleCourse_Hoop,
				// Token: 0x04001D7A RID: 7546
				Func_PetObstacleCourse_Platform = 57418U,
				// Token: 0x04001D7B RID: 7547
				Func_PetObstacleCourse_Ramp = 57417U,
				// Token: 0x04001D7C RID: 7548
				Func_PetObstacleCourse_Tunnel = 57420U,
				// Token: 0x04001D7D RID: 7549
				Func_PetObstacleCourse_WeavingFlags = 57419U,
				// Token: 0x04001D7E RID: 7550
				Func_PetRecipe = 57404U,
				// Token: 0x04001D7F RID: 7551
				Func_PetRecipe_Food = 1930U,
				// Token: 0x04001D80 RID: 7552
				Func_PetScratchableFurniture = 1878U,
				// Token: 0x04001D81 RID: 7553
				Func_PetSqueakyBall = 57413U,
				// Token: 0x04001D82 RID: 7554
				Func_PetToy = 1877U,
				// Token: 0x04001D83 RID: 7555
				Func_PetToy_New = 57440U,
				// Token: 0x04001D84 RID: 7556
				Func_PetToy_SmartTraitCarry = 57456U,
				// Token: 0x04001D85 RID: 7557
				Func_PetToyBox = 57376U,
				// Token: 0x04001D86 RID: 7558
				Func_PetTreat = 57426U,
				// Token: 0x04001D87 RID: 7559
				Func_PetTreat_Edible = 57431U,
				// Token: 0x04001D88 RID: 7560
				Func_PetTreat_Edible_Child = 57438U,
				// Token: 0x04001D89 RID: 7561
				Func_PetTreat_Edible_Elder,
				// Token: 0x04001D8A RID: 7562
				Func_Phantom = 1194U,
				// Token: 0x04001D8B RID: 7563
				Func_Photo = 1382U,
				// Token: 0x04001D8C RID: 7564
				Func_Photo_Collage = 79874U,
				// Token: 0x04001D8D RID: 7565
				Func_Photography = 1383U,
				// Token: 0x04001D8E RID: 7566
				Func_PhotographyDissallow = 1438U,
				// Token: 0x04001D8F RID: 7567
				Func_PhotoStudio = 1941U,
				// Token: 0x04001D90 RID: 7568
				Func_PhotoStudioSearch = 2218U,
				// Token: 0x04001D91 RID: 7569
				Func_Piano = 566U,
				// Token: 0x04001D92 RID: 7570
				Func_Picnic = 1317U,
				// Token: 0x04001D93 RID: 7571
				Func_PicnicTable = 1248U,
				// Token: 0x04001D94 RID: 7572
				Func_Pillar = 1010U,
				// Token: 0x04001D95 RID: 7573
				Func_Pipe = 1410U,
				// Token: 0x04001D96 RID: 7574
				Func_PipeOrgan = 40963U,
				// Token: 0x04001D97 RID: 7575
				Func_Pirate = 501U,
				// Token: 0x04001D98 RID: 7576
				Func_PitBBQ = 63527U,
				// Token: 0x04001D99 RID: 7577
				Func_PlacematDrawing = 26639U,
				// Token: 0x04001D9A RID: 7578
				Func_PlacematFormal = 1711U,
				// Token: 0x04001D9B RID: 7579
				Func_PlanterBox = 1149U,
				// Token: 0x04001D9C RID: 7580
				Func_Plaque = 1420U,
				// Token: 0x04001D9D RID: 7581
				Func_Play = 1142U,
				// Token: 0x04001D9E RID: 7582
				Func_Plush = 1021U,
				// Token: 0x04001D9F RID: 7583
				Func_Podium = 1577U,
				// Token: 0x04001DA0 RID: 7584
				Func_PodiumPair = 65591U,
				// Token: 0x04001DA1 RID: 7585
				Func_PodiumPair_DebateShowdown = 65594U,
				// Token: 0x04001DA2 RID: 7586
				Func_Pole = 1404U,
				// Token: 0x04001DA3 RID: 7587
				Func_Police = 12398U,
				// Token: 0x04001DA4 RID: 7588
				Func_Pool = 1233U,
				// Token: 0x04001DA5 RID: 7589
				Func_PoolLadder = 1240U,
				// Token: 0x04001DA6 RID: 7590
				Func_PoolLight = 1234U,
				// Token: 0x04001DA7 RID: 7591
				Func_Popcorn = 28674U,
				// Token: 0x04001DA8 RID: 7592
				Func_Popcorn_Buttered = 28678U,
				// Token: 0x04001DA9 RID: 7593
				Func_Popcorn_Caramel = 28676U,
				// Token: 0x04001DAA RID: 7594
				Func_Popcorn_Chedder = 28675U,
				// Token: 0x04001DAB RID: 7595
				Func_Popcorn_Kettle = 28677U,
				// Token: 0x04001DAC RID: 7596
				Func_PopcornPopper = 28673U,
				// Token: 0x04001DAD RID: 7597
				Func_PortableBar = 24602U,
				// Token: 0x04001DAE RID: 7598
				Func_PortableKeyboard = 1627U,
				// Token: 0x04001DAF RID: 7599
				Func_Portal = 1435U,
				// Token: 0x04001DB0 RID: 7600
				Func_Portrait = 1422U,
				// Token: 0x04001DB1 RID: 7601
				Func_Poster = 895U,
				// Token: 0x04001DB2 RID: 7602
				Func_Pot = 1144U,
				// Token: 0x04001DB3 RID: 7603
				Func_Potion = 993U,
				// Token: 0x04001DB4 RID: 7604
				Func_Potty = 1664U,
				// Token: 0x04001DB5 RID: 7605
				Func_PowerGenerator = 67617U,
				// Token: 0x04001DB6 RID: 7606
				Func_PregenerateDefaultMatGeoStateThumbnailOnly = 2170U,
				// Token: 0x04001DB7 RID: 7607
				Func_PresentPile = 59410U,
				// Token: 0x04001DB8 RID: 7608
				Func_PresentPile_Large = 59416U,
				// Token: 0x04001DB9 RID: 7609
				Func_PresentPile_Small = 59415U,
				// Token: 0x04001DBA RID: 7610
				Func_Prevent_Recycling = 2442U,
				// Token: 0x04001DBB RID: 7611
				Func_Prison = 1380U,
				// Token: 0x04001DBC RID: 7612
				Func_Privacy_ObeyAppropriate = 61640U,
				// Token: 0x04001DBD RID: 7613
				Func_Programming = 1101U,
				// Token: 0x04001DBE RID: 7614
				Func_Propane = 1281U,
				// Token: 0x04001DBF RID: 7615
				Func_Psychic = 1186U,
				// Token: 0x04001DC0 RID: 7616
				Func_PublicBathroom = 1340U,
				// Token: 0x04001DC1 RID: 7617
				Func_Puddle = 567U,
				// Token: 0x04001DC2 RID: 7618
				Func_Pumpkin = 1204U,
				// Token: 0x04001DC3 RID: 7619
				Func_Punching = 477U,
				// Token: 0x04001DC4 RID: 7620
				Func_PuppetTheater = 32769U,
				// Token: 0x04001DC5 RID: 7621
				Func_Purchase_Beach = 63506U,
				// Token: 0x04001DC6 RID: 7622
				Func_Purchase_BeachAccessories = 63532U,
				// Token: 0x04001DC7 RID: 7623
				Func_Purchase_BeachFishing = 63529U,
				// Token: 0x04001DC8 RID: 7624
				Func_Purchase_BeachFruits = 63533U,
				// Token: 0x04001DC9 RID: 7625
				Func_Purchase_BeachLeisure = 63530U,
				// Token: 0x04001DCA RID: 7626
				Func_Purchase_BeachVehicles,
				// Token: 0x04001DCB RID: 7627
				Func_Purchase_Vacation_Fun = 2503U,
				// Token: 0x04001DCC RID: 7628
				Func_Purchase_Vacation_Furniture = 2500U,
				// Token: 0x04001DCD RID: 7629
				Func_Purchase_Vacation_Misc = 2504U,
				// Token: 0x04001DCE RID: 7630
				Func_Purchase_Vacation_Supplies = 2502U,
				// Token: 0x04001DCF RID: 7631
				Func_Purchase_Vacation_Tents = 2501U,
				// Token: 0x04001DD0 RID: 7632
				Func_PurchasePicker_Category_Book_Emotional = 1037U,
				// Token: 0x04001DD1 RID: 7633
				Func_PurchasePicker_Category_Book_Skill = 1036U,
				// Token: 0x04001DD2 RID: 7634
				Func_Quadcopter = 65624U,
				// Token: 0x04001DD3 RID: 7635
				Func_Rack = 1146U,
				// Token: 0x04001DD4 RID: 7636
				Func_Range = 1169U,
				// Token: 0x04001DD5 RID: 7637
				Func_RangerStation = 1341U,
				// Token: 0x04001DD6 RID: 7638
				Func_RangerStation_Catagory_Fun = 1889U,
				// Token: 0x04001DD7 RID: 7639
				Func_RangerStation_Catagory_Furniture = 1888U,
				// Token: 0x04001DD8 RID: 7640
				Func_RangerStation_Catagory_Ingredient = 1890U,
				// Token: 0x04001DD9 RID: 7641
				Func_RangerStation_Catagory_Supplies = 1887U,
				// Token: 0x04001DDA RID: 7642
				Func_RangerStation_Category_Pet = 2012U,
				// Token: 0x04001DDB RID: 7643
				Func_RangerStation_Fun = 10269U,
				// Token: 0x04001DDC RID: 7644
				Func_RangerStation_Furniture = 10268U,
				// Token: 0x04001DDD RID: 7645
				Func_RangerStation_Ingredient = 10270U,
				// Token: 0x04001DDE RID: 7646
				Func_RangerStation_Supplies = 10267U,
				// Token: 0x04001DDF RID: 7647
				Func_Rat = 77830U,
				// Token: 0x04001DE0 RID: 7648
				Func_Reaper = 576U,
				// Token: 0x04001DE1 RID: 7649
				Func_RebatePlant = 2205U,
				// Token: 0x04001DE2 RID: 7650
				Func_Recipe = 522U,
				// Token: 0x04001DE3 RID: 7651
				Func_Recipe_Baking_CupcakeFactory = 12377U,
				// Token: 0x04001DE4 RID: 7652
				Func_Recipe_Baking_Oven = 12376U,
				// Token: 0x04001DE5 RID: 7653
				Func_Recliner = 1111U,
				// Token: 0x04001DE6 RID: 7654
				Func_Recording = 47149U,
				// Token: 0x04001DE7 RID: 7655
				Func_Recycler = 67585U,
				// Token: 0x04001DE8 RID: 7656
				Func_Refrigerator = 519U,
				// Token: 0x04001DE9 RID: 7657
				Func_RegisteredVampireLair = 2271U,
				// Token: 0x04001DEA RID: 7658
				Func_Registers = 12395U,
				// Token: 0x04001DEB RID: 7659
				Func_Relaxation = 18457U,
				// Token: 0x04001DEC RID: 7660
				Func_RepairBurnt = 67644U,
				// Token: 0x04001DED RID: 7661
				Func_RepairBurnt_VariableHeight = 67643U,
				// Token: 0x04001DEE RID: 7662
				Func_RepairBurnt_VariableHeight_BG = 2435U,
				// Token: 0x04001DEF RID: 7663
				Func_RequiresOceanLot = 63519U,
				// Token: 0x04001DF0 RID: 7664
				Func_ResearchMachine = 65631U,
				// Token: 0x04001DF1 RID: 7665
				Func_Restaurant_Not_A_Table = 26649U,
				// Token: 0x04001DF2 RID: 7666
				Func_Retail = 1321U,
				// Token: 0x04001DF3 RID: 7667
				Func_Retail_NeonLight = 12365U,
				// Token: 0x04001DF4 RID: 7668
				Func_Retail_NPC_ItemForSale = 12384U,
				// Token: 0x04001DF5 RID: 7669
				Func_RetailFridge = 12431U,
				// Token: 0x04001DF6 RID: 7670
				Func_RetailPedestal = 12383U,
				// Token: 0x04001DF7 RID: 7671
				Func_RetailRegister = 12311U,
				// Token: 0x04001DF8 RID: 7672
				Func_Reward = 1121U,
				// Token: 0x04001DF9 RID: 7673
				Func_ReviewProduct_Beauty = 61557U,
				// Token: 0x04001DFA RID: 7674
				Func_ReviewProduct_Gadget = 61559U,
				// Token: 0x04001DFB RID: 7675
				Func_ReviewProduct_Tech = 61558U,
				// Token: 0x04001DFC RID: 7676
				Func_Rig = 1015U,
				// Token: 0x04001DFD RID: 7677
				Func_RoboticArm = 2281U,
				// Token: 0x04001DFE RID: 7678
				Func_RoboticsTable = 65565U,
				// Token: 0x04001DFF RID: 7679
				Func_RobotVacuum = 1982U,
				// Token: 0x04001E00 RID: 7680
				Func_RobotVacuum_CleanDefault = 57422U,
				// Token: 0x04001E01 RID: 7681
				Func_RobotVacuum_CleanUpgrade,
				// Token: 0x04001E02 RID: 7682
				Func_RobotVacuum_Mess_DefaultClean = 2010U,
				// Token: 0x04001E03 RID: 7683
				Func_RobotVacuum_Mess_UpgradedClean,
				// Token: 0x04001E04 RID: 7684
				Func_RobotVacuumBase = 1983U,
				// Token: 0x04001E05 RID: 7685
				Func_Rock = 1318U,
				// Token: 0x04001E06 RID: 7686
				Func_RockClimbingWall = 71681U,
				// Token: 0x04001E07 RID: 7687
				Func_Rocket = 495U,
				// Token: 0x04001E08 RID: 7688
				Func_RocketScience = 1105U,
				// Token: 0x04001E09 RID: 7689
				Func_RockingChair = 2462U,
				// Token: 0x04001E0A RID: 7690
				Func_RockingChair_ArmChair = 83986U,
				// Token: 0x04001E0B RID: 7691
				Func_RockWall = 71682U,
				// Token: 0x04001E0C RID: 7692
				Func_Roommate_Absent = 2263U,
				// Token: 0x04001E0D RID: 7693
				Func_Roommate_Art = 2259U,
				// Token: 0x04001E0E RID: 7694
				Func_Roommate_Baking = 2257U,
				// Token: 0x04001E0F RID: 7695
				Func_Roommate_BathroomHog = 2262U,
				// Token: 0x04001E10 RID: 7696
				Func_Roommate_BigCloset = 2264U,
				// Token: 0x04001E11 RID: 7697
				Func_Roommate_Breaker = 2256U,
				// Token: 0x04001E12 RID: 7698
				Func_Roommate_CantStopTheBeat = 2255U,
				// Token: 0x04001E13 RID: 7699
				Func_Roommate_Cheerleader = 2248U,
				// Token: 0x04001E14 RID: 7700
				Func_Roommate_ClingySocialite = 2251U,
				// Token: 0x04001E15 RID: 7701
				Func_Roommate_Computer = 2260U,
				// Token: 0x04001E16 RID: 7702
				Func_Roommate_CouchPotato = 2252U,
				// Token: 0x04001E17 RID: 7703
				Func_Roommate_EmoLoner = 2254U,
				// Token: 0x04001E18 RID: 7704
				Func_Roommate_Fitness = 2261U,
				// Token: 0x04001E19 RID: 7705
				Func_Roommate_Fixer = 2250U,
				// Token: 0x04001E1A RID: 7706
				Func_Roommate_LateOnRent = 2267U,
				// Token: 0x04001E1B RID: 7707
				Func_Roommate_Mealmaker = 2249U,
				// Token: 0x04001E1C RID: 7708
				Func_Roommate_Music = 2258U,
				// Token: 0x04001E1D RID: 7709
				Func_Roommate_PartyPlanner = 2253U,
				// Token: 0x04001E1E RID: 7710
				Func_Roommate_Prankster = 2266U,
				// Token: 0x04001E1F RID: 7711
				Func_Roommate_PublicAffectionDisplayer = 2265U,
				// Token: 0x04001E20 RID: 7712
				Func_Roommate_Superneat = 2247U,
				// Token: 0x04001E21 RID: 7713
				Func_Rubbish = 923U,
				// Token: 0x04001E22 RID: 7714
				Func_Rug = 2020U,
				// Token: 0x04001E23 RID: 7715
				Func_Rustic = 1320U,
				// Token: 0x04001E24 RID: 7716
				Func_Sabacc_ChipPile = 51254U,
				// Token: 0x04001E25 RID: 7717
				Func_SacredCandle = 86020U,
				// Token: 0x04001E26 RID: 7718
				Func_Sale = 1406U,
				// Token: 0x04001E27 RID: 7719
				Func_Saline,
				// Token: 0x04001E28 RID: 7720
				Func_SaucePot = 2450U,
				// Token: 0x04001E29 RID: 7721
				Func_Saucer = 1393U,
				// Token: 0x04001E2A RID: 7722
				Func_Sauna = 18455U,
				// Token: 0x04001E2B RID: 7723
				Func_Sawhorse = 1408U,
				// Token: 0x04001E2C RID: 7724
				Func_Scarecrow = 59459U,
				// Token: 0x04001E2D RID: 7725
				Func_ScentFlower_HighSkill = 59470U,
				// Token: 0x04001E2E RID: 7726
				Func_ScentFlower_LowSkill = 59469U,
				// Token: 0x04001E2F RID: 7727
				Func_SchoolProjectBox_Child = 43013U,
				// Token: 0x04001E30 RID: 7728
				Func_SchoolProjectBox_Teen,
				// Token: 0x04001E31 RID: 7729
				Func_Science = 1019U,
				// Token: 0x04001E32 RID: 7730
				Func_ScienceTable = 858U,
				// Token: 0x04001E33 RID: 7731
				Func_ScienceUniversityShell = 65549U,
				// Token: 0x04001E34 RID: 7732
				Func_ScienceUniversityShell_Shell1 = 65562U,
				// Token: 0x04001E35 RID: 7733
				Func_ScienceUniversityShell_Shell2,
				// Token: 0x04001E36 RID: 7734
				Func_Scientist = 12396U,
				// Token: 0x04001E37 RID: 7735
				Func_Scratched_All = 57369U,
				// Token: 0x04001E38 RID: 7736
				Func_Scratched_Low = 57368U,
				// Token: 0x04001E39 RID: 7737
				Func_ScratchingPost = 57384U,
				// Token: 0x04001E3A RID: 7738
				Func_Screen = 1031U,
				// Token: 0x04001E3B RID: 7739
				Func_Scythe = 574U,
				// Token: 0x04001E3C RID: 7740
				Func_Seance = 1189U,
				// Token: 0x04001E3D RID: 7741
				Func_SeanceCircle = 86018U,
				// Token: 0x04001E3E RID: 7742
				Func_SeanceTable = 86017U,
				// Token: 0x04001E3F RID: 7743
				Func_Seashell = 63508U,
				// Token: 0x04001E40 RID: 7744
				Func_Seasonal = 59445U,
				// Token: 0x04001E41 RID: 7745
				Func_SecretAgent = 1127U,
				// Token: 0x04001E42 RID: 7746
				Func_SecretSociety_Garden = 65569U,
				// Token: 0x04001E43 RID: 7747
				Func_Sectional_Sofa_Chaise = 53249U,
				// Token: 0x04001E44 RID: 7748
				Func_SectionalSofa_Piece = 2558U,
				// Token: 0x04001E45 RID: 7749
				Func_SectionalSofa_Whole = 2557U,
				// Token: 0x04001E46 RID: 7750
				Func_Seer = 1187U,
				// Token: 0x04001E47 RID: 7751
				Func_Shades = 1154U,
				// Token: 0x04001E48 RID: 7752
				Func_Sheet = 1290U,
				// Token: 0x04001E49 RID: 7753
				Func_Shelf = 1148U,
				// Token: 0x04001E4A RID: 7754
				Func_ShellInteractive = 2245U,
				// Token: 0x04001E4B RID: 7755
				Func_Ship = 496U,
				// Token: 0x04001E4C RID: 7756
				Func_Shoes_search = 2556U,
				// Token: 0x04001E4D RID: 7757
				Func_Shower = 1315U,
				// Token: 0x04001E4E RID: 7758
				Func_ShowerTub = 1663U,
				// Token: 0x04001E4F RID: 7759
				Func_Shuttle = 1397U,
				// Token: 0x04001E50 RID: 7760
				Func_Sign = 1027U,
				// Token: 0x04001E51 RID: 7761
				Func_SimRay = 1278U,
				// Token: 0x04001E52 RID: 7762
				Func_SimRay_NotValid_TransformResult = 12433U,
				// Token: 0x04001E53 RID: 7763
				Func_SimRay_NotValid_TransformResult_BG = 1528U,
				// Token: 0x04001E54 RID: 7764
				Func_SimRay_Transform_AlienVisitor_Allow = 12362U,
				// Token: 0x04001E55 RID: 7765
				Func_Sing = 489U,
				// Token: 0x04001E56 RID: 7766
				Func_SingleBed = 779U,
				// Token: 0x04001E57 RID: 7767
				Func_Sink = 1313U,
				// Token: 0x04001E58 RID: 7768
				Func_Sit = 1434U,
				// Token: 0x04001E59 RID: 7769
				Func_SitLounge = 2196U,
				// Token: 0x04001E5A RID: 7770
				Func_SitLoungeFloat = 2202U,
				// Token: 0x04001E5B RID: 7771
				Func_SkatingRink = 59407U,
				// Token: 0x04001E5C RID: 7772
				Func_SkatingRink_IceNatural = 59399U,
				// Token: 0x04001E5D RID: 7773
				Func_SkatingRink_IceRink = 59398U,
				// Token: 0x04001E5E RID: 7774
				Func_SkatingRink_Large = 59436U,
				// Token: 0x04001E5F RID: 7775
				Func_SkatingRink_RollerRink = 59400U,
				// Token: 0x04001E60 RID: 7776
				Func_SkatingRink_Seasonal = 59448U,
				// Token: 0x04001E61 RID: 7777
				Func_SkatingRink_Small = 59435U,
				// Token: 0x04001E62 RID: 7778
				Func_Skeleton = 1208U,
				// Token: 0x04001E63 RID: 7779
				Func_Sketchpad = 2159U,
				// Token: 0x04001E64 RID: 7780
				Func_Skills = 1384U,
				// Token: 0x04001E65 RID: 7781
				Func_Skull = 1212U,
				// Token: 0x04001E66 RID: 7782
				Func_Sleep = 1143U,
				// Token: 0x04001E67 RID: 7783
				Func_SleepingPod = 61624U,
				// Token: 0x04001E68 RID: 7784
				Func_SlideLawn = 34818U,
				// Token: 0x04001E69 RID: 7785
				Func_SlipplySlide = 34817U,
				// Token: 0x04001E6A RID: 7786
				Func_SmartHub = 2174U,
				// Token: 0x04001E6B RID: 7787
				Func_SnobArtAssess = 2133U,
				// Token: 0x04001E6C RID: 7788
				Func_SnobArtAssess_NoReserve,
				// Token: 0x04001E6D RID: 7789
				Func_Snow = 1333U,
				// Token: 0x04001E6E RID: 7790
				Func_Snowangel = 2484U,
				// Token: 0x04001E6F RID: 7791
				Func_Snowdrift,
				// Token: 0x04001E70 RID: 7792
				Func_Snowman = 1336U,
				// Token: 0x04001E71 RID: 7793
				Func_Snowpal = 2486U,
				// Token: 0x04001E72 RID: 7794
				Func_SnowSportsSlope_BunnySlope = 69646U,
				// Token: 0x04001E73 RID: 7795
				Func_SnowSportsSlope_EasySlope,
				// Token: 0x04001E74 RID: 7796
				Func_SnowSportsSlope_ExpertSlope = 69649U,
				// Token: 0x04001E75 RID: 7797
				Func_SnowSportsSlope_ExtremeSlope,
				// Token: 0x04001E76 RID: 7798
				Func_SnowSportsSlope_IntermediateSlope = 69648U,
				// Token: 0x04001E77 RID: 7799
				Func_SnowSportsSlope_Skis = 69643U,
				// Token: 0x04001E78 RID: 7800
				Func_SnowSportsSlope_Skis_Adult = 69715U,
				// Token: 0x04001E79 RID: 7801
				Func_SnowSportsSlope_Skis_Adult_Rentable = 69717U,
				// Token: 0x04001E7A RID: 7802
				Func_SnowSportsSlope_Skis_Child = 69676U,
				// Token: 0x04001E7B RID: 7803
				Func_SnowSportsSlope_Skis_Child_Rentable = 69719U,
				// Token: 0x04001E7C RID: 7804
				Func_SnowSportsSlope_Skis_Rented = 69678U,
				// Token: 0x04001E7D RID: 7805
				Func_SnowSportsSlope_Sled = 69645U,
				// Token: 0x04001E7E RID: 7806
				Func_SnowSportsSlope_Snowboard = 69644U,
				// Token: 0x04001E7F RID: 7807
				Func_SnowSportsSlope_Snowboard_Adult = 69716U,
				// Token: 0x04001E80 RID: 7808
				Func_SnowSportsSlope_Snowboard_Adult_Rentable = 69718U,
				// Token: 0x04001E81 RID: 7809
				Func_SnowSportsSlope_Snowboard_Child = 69677U,
				// Token: 0x04001E82 RID: 7810
				Func_SnowSportsSlope_Snowboard_Child_Rentable = 69720U,
				// Token: 0x04001E83 RID: 7811
				Func_SnowSportsSlope_Snowboard_Rented = 69679U,
				// Token: 0x04001E84 RID: 7812
				Func_Soap = 1423U,
				// Token: 0x04001E85 RID: 7813
				Func_SoccerBall = 65540U,
				// Token: 0x04001E86 RID: 7814
				Func_Social = 1000U,
				// Token: 0x04001E87 RID: 7815
				Func_SolarPanel = 67613U,
				// Token: 0x04001E88 RID: 7816
				Func_Sound = 517U,
				// Token: 0x04001E89 RID: 7817
				Func_Space = 497U,
				// Token: 0x04001E8A RID: 7818
				Func_SpaceRanger = 1132U,
				// Token: 0x04001E8B RID: 7819
				Func_Spaceship = 994U,
				// Token: 0x04001E8C RID: 7820
				Func_Spawner = 59453U,
				// Token: 0x04001E8D RID: 7821
				Func_Specter = 86022U,
				// Token: 0x04001E8E RID: 7822
				Func_SpecterJar_Friendly,
				// Token: 0x04001E8F RID: 7823
				Func_SpecterJar_Mean,
				// Token: 0x04001E90 RID: 7824
				Func_SpecterJar_Mysterious,
				// Token: 0x04001E91 RID: 7825
				Func_Spells_Duplicate = 49165U,
				// Token: 0x04001E92 RID: 7826
				Func_Spells_Duplicate_BG = 2268U,
				// Token: 0x04001E93 RID: 7827
				Func_Spells_Steal = 49167U,
				// Token: 0x04001E94 RID: 7828
				Func_Spells_Steal_BG = 2436U,
				// Token: 0x04001E95 RID: 7829
				Func_Spider = 1192U,
				// Token: 0x04001E96 RID: 7830
				Func_Spirit = 1197U,
				// Token: 0x04001E97 RID: 7831
				Func_Spook = 1196U,
				// Token: 0x04001E98 RID: 7832
				Func_Spooky = 1178U,
				// Token: 0x04001E99 RID: 7833
				Func_SportsArena_Arts = 65607U,
				// Token: 0x04001E9A RID: 7834
				Func_SportsArena_Science,
				// Token: 0x04001E9B RID: 7835
				Func_Sprinkler = 1061U,
				// Token: 0x04001E9C RID: 7836
				Func_Sprinkler_Floor = 2099U,
				// Token: 0x04001E9D RID: 7837
				Func_SPTable = 1182U,
				// Token: 0x04001E9E RID: 7838
				Func_StageGate_Actors = 61464U,
				// Token: 0x04001E9F RID: 7839
				Func_StageLight_All = 61461U,
				// Token: 0x04001EA0 RID: 7840
				Func_StageMarkDuo_SwordFight = 61623U,
				// Token: 0x04001EA1 RID: 7841
				Func_StageMarkDuo1_1 = 61443U,
				// Token: 0x04001EA2 RID: 7842
				Func_StageMarkDuo1_2,
				// Token: 0x04001EA3 RID: 7843
				Func_StageMarkDuo1_3,
				// Token: 0x04001EA4 RID: 7844
				Func_StageMarkDuo2_1 = 61481U,
				// Token: 0x04001EA5 RID: 7845
				Func_StageMarkDuo2_2,
				// Token: 0x04001EA6 RID: 7846
				Func_StageMarkDuo2_3,
				// Token: 0x04001EA7 RID: 7847
				Func_StageMarkDuo3_1,
				// Token: 0x04001EA8 RID: 7848
				Func_StageMarkDuo3_2,
				// Token: 0x04001EA9 RID: 7849
				Func_StageMarkDuo3_3,
				// Token: 0x04001EAA RID: 7850
				Func_StageMarkSolo_Death = 61622U,
				// Token: 0x04001EAB RID: 7851
				Func_StageMarkSolo1_1 = 61446U,
				// Token: 0x04001EAC RID: 7852
				Func_StageMarkSolo1_2,
				// Token: 0x04001EAD RID: 7853
				Func_StageMarkSolo1_3,
				// Token: 0x04001EAE RID: 7854
				Func_StageMarkSolo2_1 = 61487U,
				// Token: 0x04001EAF RID: 7855
				Func_StageMarkSolo2_2,
				// Token: 0x04001EB0 RID: 7856
				Func_StageMarkSolo2_3,
				// Token: 0x04001EB1 RID: 7857
				Func_StageMarkSolo3_1,
				// Token: 0x04001EB2 RID: 7858
				Func_StageMarkSolo3_2,
				// Token: 0x04001EB3 RID: 7859
				Func_StageMarkSolo3_3,
				// Token: 0x04001EB4 RID: 7860
				Func_Stalls_CurioShop_Objects = 47107U,
				// Token: 0x04001EB5 RID: 7861
				Func_Stalls_Produce_CurryChili = 55342U,
				// Token: 0x04001EB6 RID: 7862
				Func_Stalls_Produce_Grocery = 55341U,
				// Token: 0x04001EB7 RID: 7863
				Func_Stalls_Produce_Saffron = 55343U,
				// Token: 0x04001EB8 RID: 7864
				Func_Stalls_Produce_Wasabi,
				// Token: 0x04001EB9 RID: 7865
				Func_Stalls_Schwag_Festival_AllStalls = 55349U,
				// Token: 0x04001EBA RID: 7866
				Func_Stalls_Schwag_Festival_Blossom = 55336U,
				// Token: 0x04001EBB RID: 7867
				Func_Stalls_Schwag_Festival_FleaMarket,
				// Token: 0x04001EBC RID: 7868
				Func_Stalls_Schwag_Festival_Food,
				// Token: 0x04001EBD RID: 7869
				Func_Stalls_Schwag_Festival_Lamp,
				// Token: 0x04001EBE RID: 7870
				Func_Stalls_Schwag_Festival_Logic,
				// Token: 0x04001EBF RID: 7871
				Func_Stand = 1166U,
				// Token: 0x04001EC0 RID: 7872
				Func_StandingLamp = 1137U,
				// Token: 0x04001EC1 RID: 7873
				Func_Statue = 1156U,
				// Token: 0x04001EC2 RID: 7874
				Func_SteamFissure = 24585U,
				// Token: 0x04001EC3 RID: 7875
				Func_SteamRoom = 18444U,
				// Token: 0x04001EC4 RID: 7876
				Func_SteamVent = 63500U,
				// Token: 0x04001EC5 RID: 7877
				Func_Steps = 1077U,
				// Token: 0x04001EC6 RID: 7878
				Func_Stereo = 516U,
				// Token: 0x04001EC7 RID: 7879
				Func_Stereo_Public = 2135U,
				// Token: 0x04001EC8 RID: 7880
				Func_Sticker = 1152U,
				// Token: 0x04001EC9 RID: 7881
				Func_Stone = 1089U,
				// Token: 0x04001ECA RID: 7882
				Func_Stool = 1008U,
				// Token: 0x04001ECB RID: 7883
				Func_Store = 12424U,
				// Token: 0x04001ECC RID: 7884
				Func_Strategy = 487U,
				// Token: 0x04001ECD RID: 7885
				Func_Striped = 1388U,
				// Token: 0x04001ECE RID: 7886
				Func_Stuffed = 504U,
				// Token: 0x04001ECF RID: 7887
				Func_StuffedAnimal = 1020U,
				// Token: 0x04001ED0 RID: 7888
				Func_Stump = 1308U,
				// Token: 0x04001ED1 RID: 7889
				Func_Styleboard = 2130U,
				// Token: 0x04001ED2 RID: 7890
				Func_SugarSkull = 1567U,
				// Token: 0x04001ED3 RID: 7891
				Func_Sunflower = 1398U,
				// Token: 0x04001ED4 RID: 7892
				Func_Supplies = 1294U,
				// Token: 0x04001ED5 RID: 7893
				Func_Swim = 1231U,
				// Token: 0x04001ED6 RID: 7894
				Func_SwimmingPool,
				// Token: 0x04001ED7 RID: 7895
				Func_SwingSet = 2125U,
				// Token: 0x04001ED8 RID: 7896
				Func_SwingSetBG = 2120U,
				// Token: 0x04001ED9 RID: 7897
				Func_Swipe_Basic = 2136U,
				// Token: 0x04001EDA RID: 7898
				Func_Swipe_HighSkill = 2138U,
				// Token: 0x04001EDB RID: 7899
				Func_Swipe_MedSkill = 2137U,
				// Token: 0x04001EDC RID: 7900
				Func_SwipeHouseholdInventory_Basic = 2139U,
				// Token: 0x04001EDD RID: 7901
				Func_SwipeHouseholdInventory_HighSkill = 2141U,
				// Token: 0x04001EDE RID: 7902
				Func_SwipeHouseholdInventory_MedSkill = 2140U,
				// Token: 0x04001EDF RID: 7903
				Func_Sync_ShoeRemoval_Rule = 69667U,
				// Token: 0x04001EE0 RID: 7904
				Func_Syrums = 12430U,
				// Token: 0x04001EE1 RID: 7905
				Func_System = 518U,
				// Token: 0x04001EE2 RID: 7906
				Func_SystemSpawned_DustFriend = 2522U,
				// Token: 0x04001EE3 RID: 7907
				Func_SystemSpawned_DustPile,
				// Token: 0x04001EE4 RID: 7908
				Func_SystemSpawned_Specter,
				// Token: 0x04001EE5 RID: 7909
				Func_Table = 486U,
				// Token: 0x04001EE6 RID: 7910
				Func_Table_Low = 2507U,
				// Token: 0x04001EE7 RID: 7911
				Func_TableCloth = 1335U,
				// Token: 0x04001EE8 RID: 7912
				Func_TableDiningBar = 1538U,
				// Token: 0x04001EE9 RID: 7913
				Func_TableDiningUmbrella = 1547U,
				// Token: 0x04001EEA RID: 7914
				Func_Tablet = 1108U,
				// Token: 0x04001EEB RID: 7915
				Func_Tank = 1433U,
				// Token: 0x04001EEC RID: 7916
				Func_Tarp = 1289U,
				// Token: 0x04001EED RID: 7917
				Func_Tea = 577U,
				// Token: 0x04001EEE RID: 7918
				Func_TechGuru = 1133U,
				// Token: 0x04001EEF RID: 7919
				Func_Teddy = 1073U,
				// Token: 0x04001EF0 RID: 7920
				Func_TeddyBear,
				// Token: 0x04001EF1 RID: 7921
				Func_Telescope = 571U,
				// Token: 0x04001EF2 RID: 7922
				Func_Television = 470U,
				// Token: 0x04001EF3 RID: 7923
				Func_Teller = 1181U,
				// Token: 0x04001EF4 RID: 7924
				Func_Temp_CraftSalesTable_CreatedObjects = 55370U,
				// Token: 0x04001EF5 RID: 7925
				Func_Temp_CraftSalesTable_CreatedObjects_BG = 2040U,
				// Token: 0x04001EF6 RID: 7926
				Func_Temperature_Cooler = 2060U,
				// Token: 0x04001EF7 RID: 7927
				Func_Temperature_Heater = 2059U,
				// Token: 0x04001EF8 RID: 7928
				Func_Temple_Chest = 45091U,
				// Token: 0x04001EF9 RID: 7929
				Func_Temple_Gate = 45057U,
				// Token: 0x04001EFA RID: 7930
				Func_Temple_Trap,
				// Token: 0x04001EFB RID: 7931
				Func_Tent = 2478U,
				// Token: 0x04001EFC RID: 7932
				Func_TermPresentation_ClassA = 65649U,
				// Token: 0x04001EFD RID: 7933
				Func_TermPresentation_ClassB,
				// Token: 0x04001EFE RID: 7934
				Func_TermPresentation_ClassC,
				// Token: 0x04001EFF RID: 7935
				Func_TermPresentation_ClassD,
				// Token: 0x04001F00 RID: 7936
				Func_Terracotta = 1087U,
				// Token: 0x04001F01 RID: 7937
				Func_Terrarium = 77827U,
				// Token: 0x04001F02 RID: 7938
				Func_Thermostat = 59456U,
				// Token: 0x04001F03 RID: 7939
				Func_Throwing_Mud = 59428U,
				// Token: 0x04001F04 RID: 7940
				Func_Throwing_Snowballs = 2487U,
				// Token: 0x04001F05 RID: 7941
				Func_Throwing_WaterBalloons = 59427U,
				// Token: 0x04001F06 RID: 7942
				Func_Tile = 1088U,
				// Token: 0x04001F07 RID: 7943
				Func_Toddler = 1685U,
				// Token: 0x04001F08 RID: 7944
				Func_Toddler_Bed = 1658U,
				// Token: 0x04001F09 RID: 7945
				Func_Toddler_GymObject_BallPit = 73731U,
				// Token: 0x04001F0A RID: 7946
				Func_Toddler_GymObject_Full = 1727U,
				// Token: 0x04001F0B RID: 7947
				Func_Toddler_GymObject_Slide = 1726U,
				// Token: 0x04001F0C RID: 7948
				Func_Toddler_GymObject_Slide_Climber = 73730U,
				// Token: 0x04001F0D RID: 7949
				Func_Toddler_GymObject_Tunnels = 73732U,
				// Token: 0x04001F0E RID: 7950
				Func_Toddler_JungleGymObject = 73729U,
				// Token: 0x04001F0F RID: 7951
				Func_ToddlerBallPit = 73734U,
				// Token: 0x04001F10 RID: 7952
				Func_ToddlerBookcase = 1666U,
				// Token: 0x04001F11 RID: 7953
				Func_ToddlerSeating = 1676U,
				// Token: 0x04001F12 RID: 7954
				Func_ToddlerSlide = 73733U,
				// Token: 0x04001F13 RID: 7955
				Func_ToddlerToybox = 1665U,
				// Token: 0x04001F14 RID: 7956
				Func_Toilet = 1881U,
				// Token: 0x04001F15 RID: 7957
				Func_Toilet_Talking = 55311U,
				// Token: 0x04001F16 RID: 7958
				Func_Tomb = 1202U,
				// Token: 0x04001F17 RID: 7959
				Func_Tombstone = 1199U,
				// Token: 0x04001F18 RID: 7960
				Func_Towel = 1147U,
				// Token: 0x04001F19 RID: 7961
				Func_Toy = 505U,
				// Token: 0x04001F1A RID: 7962
				Func_Toybox = 1018U,
				// Token: 0x04001F1B RID: 7963
				Func_ToyBox_ToysToCleanUp = 533U,
				// Token: 0x04001F1C RID: 7964
				Func_ToyboxPurchase = 1646U,
				// Token: 0x04001F1D RID: 7965
				Func_ToyRobot = 65625U,
				// Token: 0x04001F1E RID: 7966
				Func_Trash = 581U,
				// Token: 0x04001F1F RID: 7967
				Func_TrashCan = 891U,
				// Token: 0x04001F20 RID: 7968
				Func_Trashcan_HiTech = 2443U,
				// Token: 0x04001F21 RID: 7969
				Func_TrashCan_Indoor = 2349U,
				// Token: 0x04001F22 RID: 7970
				Func_TrashCan_Outdoor = 892U,
				// Token: 0x04001F23 RID: 7971
				Func_TrashPile = 568U,
				// Token: 0x04001F24 RID: 7972
				Func_TrashPile_Compostable = 2335U,
				// Token: 0x04001F25 RID: 7973
				Func_TrashPile_Recyclable = 2334U,
				// Token: 0x04001F26 RID: 7974
				Func_Treadmill = 478U,
				// Token: 0x04001F27 RID: 7975
				Func_Treasure = 63510U,
				// Token: 0x04001F28 RID: 7976
				Func_Treasure_Chest = 45113U,
				// Token: 0x04001F29 RID: 7977
				Func_Tree = 1332U,
				// Token: 0x04001F2A RID: 7978
				Func_Trend_Celebrity = 61638U,
				// Token: 0x04001F2B RID: 7979
				Func_Trend_ProductReview_Beauty = 61547U,
				// Token: 0x04001F2C RID: 7980
				Func_Trend_ProductReview_Tech,
				// Token: 0x04001F2D RID: 7981
				Func_Trend_ProductReview_Toy,
				// Token: 0x04001F2E RID: 7982
				Func_Trend_Skill_Acting = 61635U,
				// Token: 0x04001F2F RID: 7983
				Func_Trend_Skill_Archaeology = 61501U,
				// Token: 0x04001F30 RID: 7984
				Func_Trend_Skill_Baking,
				// Token: 0x04001F31 RID: 7985
				Func_Trend_Skill_Bowling,
				// Token: 0x04001F32 RID: 7986
				Func_Trend_Skill_Charisma,
				// Token: 0x04001F33 RID: 7987
				Func_Trend_Skill_Comedy,
				// Token: 0x04001F34 RID: 7988
				Func_Trend_Skill_CookingGourmet,
				// Token: 0x04001F35 RID: 7989
				Func_Trend_Skill_CookingHomestyle,
				// Token: 0x04001F36 RID: 7990
				Func_Trend_Skill_Dancing,
				// Token: 0x04001F37 RID: 7991
				Func_Trend_Skill_DJMixing,
				// Token: 0x04001F38 RID: 7992
				Func_Trend_Skill_Fishing,
				// Token: 0x04001F39 RID: 7993
				Func_Trend_Skill_Fitness,
				// Token: 0x04001F3A RID: 7994
				Func_Trend_Skill_FlowerArranging,
				// Token: 0x04001F3B RID: 7995
				Func_Trend_Skill_Gardening,
				// Token: 0x04001F3C RID: 7996
				Func_Trend_Skill_Guitar,
				// Token: 0x04001F3D RID: 7997
				Func_Trend_Skill_Handiness,
				// Token: 0x04001F3E RID: 7998
				Func_Trend_Skill_Herbalism,
				// Token: 0x04001F3F RID: 7999
				Func_Trend_Skill_JuiceFizzing = 67619U,
				// Token: 0x04001F40 RID: 8000
				Func_Trend_Skill_Knit = 2460U,
				// Token: 0x04001F41 RID: 8001
				Func_Trend_Skill_Knitting = 83970U,
				// Token: 0x04001F42 RID: 8002
				Func_Trend_Skill_LocalCulture = 61517U,
				// Token: 0x04001F43 RID: 8003
				Func_Trend_Skill_Logic,
				// Token: 0x04001F44 RID: 8004
				Func_Trend_Skill_MediaProduction = 61630U,
				// Token: 0x04001F45 RID: 8005
				Func_Trend_Skill_Mischief = 61519U,
				// Token: 0x04001F46 RID: 8006
				Func_Trend_Skill_Mixology,
				// Token: 0x04001F47 RID: 8007
				Func_Trend_Skill_Painting,
				// Token: 0x04001F48 RID: 8008
				Func_Trend_Skill_Parenting,
				// Token: 0x04001F49 RID: 8009
				Func_Trend_Skill_PetTraining,
				// Token: 0x04001F4A RID: 8010
				Func_Trend_Skill_Photography,
				// Token: 0x04001F4B RID: 8011
				Func_Trend_Skill_Piano,
				// Token: 0x04001F4C RID: 8012
				Func_Trend_Skill_PipeOrgan,
				// Token: 0x04001F4D RID: 8013
				Func_Trend_Skill_Programming,
				// Token: 0x04001F4E RID: 8014
				Func_Trend_Skill_Robotics = 65632U,
				// Token: 0x04001F4F RID: 8015
				Func_Trend_Skill_RocketScience = 61631U,
				// Token: 0x04001F50 RID: 8016
				Func_Trend_Skill_Singing = 61528U,
				// Token: 0x04001F51 RID: 8017
				Func_Trend_Skill_VampireLore,
				// Token: 0x04001F52 RID: 8018
				Func_Trend_Skill_Wellness = 61533U,
				// Token: 0x04001F53 RID: 8019
				Func_Trend_Skill_Veterinarian = 61530U,
				// Token: 0x04001F54 RID: 8020
				Func_Trend_Skill_VideoGaming,
				// Token: 0x04001F55 RID: 8021
				Func_Trend_Skill_Violin,
				// Token: 0x04001F56 RID: 8022
				Func_Trend_Skill_Writing = 61534U,
				// Token: 0x04001F57 RID: 8023
				Func_Trend_Tips_Beauty = 61545U,
				// Token: 0x04001F58 RID: 8024
				Func_Trend_Tips_Fashion,
				// Token: 0x04001F59 RID: 8025
				Func_Trend_ToddlerChild = 61550U,
				// Token: 0x04001F5A RID: 8026
				Func_Trend_Travel,
				// Token: 0x04001F5B RID: 8027
				Func_Trend_Vlog_Angry = 61535U,
				// Token: 0x04001F5C RID: 8028
				Func_Trend_Vlog_Confident,
				// Token: 0x04001F5D RID: 8029
				Func_Trend_Vlog_Dazed,
				// Token: 0x04001F5E RID: 8030
				Func_Trend_Vlog_Embarrassed,
				// Token: 0x04001F5F RID: 8031
				Func_Trend_Vlog_Energized,
				// Token: 0x04001F60 RID: 8032
				Func_Trend_Vlog_Flirty,
				// Token: 0x04001F61 RID: 8033
				Func_Trend_Vlog_Focused = 61610U,
				// Token: 0x04001F62 RID: 8034
				Func_Trend_Vlog_Happy = 61541U,
				// Token: 0x04001F63 RID: 8035
				Func_Trend_Vlog_Inspired,
				// Token: 0x04001F64 RID: 8036
				Func_Trend_Vlog_Playful,
				// Token: 0x04001F65 RID: 8037
				Func_Trend_Vlog_Sad,
				// Token: 0x04001F66 RID: 8038
				Func_Triangle = 1424U,
				// Token: 0x04001F67 RID: 8039
				Func_Trim = 1135U,
				// Token: 0x04001F68 RID: 8040
				Func_Trunk = 1292U,
				// Token: 0x04001F69 RID: 8041
				Func_Turtle = 1241U,
				// Token: 0x04001F6A RID: 8042
				Func_TV = 471U,
				// Token: 0x04001F6B RID: 8043
				Func_Twist = 8215U,
				// Token: 0x04001F6C RID: 8044
				Func_TVStandSearch = 2243U,
				// Token: 0x04001F6D RID: 8045
				Func_Umbrella = 59430U,
				// Token: 0x04001F6E RID: 8046
				Func_Umbrella_Adult = 59443U,
				// Token: 0x04001F6F RID: 8047
				Func_Umbrella_Child,
				// Token: 0x04001F70 RID: 8048
				Func_UmbrellaRack = 59441U,
				// Token: 0x04001F71 RID: 8049
				Func_UmbrellaTable = 1553U,
				// Token: 0x04001F72 RID: 8050
				Func_UmbrellaUser = 2118U,
				// Token: 0x04001F73 RID: 8051
				Func_Unbreakable_Object = 1172U,
				// Token: 0x04001F74 RID: 8052
				Func_Unicorn = 507U,
				// Token: 0x04001F75 RID: 8053
				Func_University_Text_Book = 2235U,
				// Token: 0x04001F76 RID: 8054
				Func_UniversityHousing_Bed = 65626U,
				// Token: 0x04001F77 RID: 8055
				Func_UniversityKiosk_Academic = 65575U,
				// Token: 0x04001F78 RID: 8056
				Func_UniversityKiosk_DecoSurface = 65574U,
				// Token: 0x04001F79 RID: 8057
				Func_UniversityKiosk_DecoWall = 65573U,
				// Token: 0x04001F7A RID: 8058
				Func_UniversityKiosk_DecoWall_ST = 65615U,
				// Token: 0x04001F7B RID: 8059
				Func_UniversityKiosk_Item = 65564U,
				// Token: 0x04001F7C RID: 8060
				Func_UniversityKiosk_Item_ST = 65614U,
				// Token: 0x04001F7D RID: 8061
				Func_Unused_USE_ME = 2175U,
				// Token: 0x04001F7E RID: 8062
				Func_Unused_USE_ME2 = 2228U,
				// Token: 0x04001F7F RID: 8063
				Func_Urn = 1076U,
				// Token: 0x04001F80 RID: 8064
				Func_Urnstone = 814U,
				// Token: 0x04001F81 RID: 8065
				Func_UseSlottingSoundOverride = 2552U,
				// Token: 0x04001F82 RID: 8066
				Func_VacuumCleaner = 94210U,
				// Token: 0x04001F83 RID: 8067
				Func_VacuumCleaner_Handheld,
				// Token: 0x04001F84 RID: 8068
				Func_VacuumCleaner_High = 94218U,
				// Token: 0x04001F85 RID: 8069
				Func_VacuumCleaner_Low = 94226U,
				// Token: 0x04001F86 RID: 8070
				Func_VacuumCleaner_Med = 94219U,
				// Token: 0x04001F87 RID: 8071
				Func_VacuumCleaner_Upright = 94212U,
				// Token: 0x04001F88 RID: 8072
				Func_VacuumHeight_Floor = 94220U,
				// Token: 0x04001F89 RID: 8073
				Func_VacuumHeight_High = 94223U,
				// Token: 0x04001F8A RID: 8074
				Func_VacuumHeight_Low = 94221U,
				// Token: 0x04001F8B RID: 8075
				Func_VacuumHeight_Medium,
				// Token: 0x04001F8C RID: 8076
				Func_Wainscoting = 1085U,
				// Token: 0x04001F8D RID: 8077
				Func_WaiterStation = 26626U,
				// Token: 0x04001F8E RID: 8078
				Func_ValentinesDay = 1370U,
				// Token: 0x04001F8F RID: 8079
				Func_Wall_TestLoS = 2029U,
				// Token: 0x04001F90 RID: 8080
				Func_WallLamp = 1112U,
				// Token: 0x04001F91 RID: 8081
				Func_VampireTome = 40961U,
				// Token: 0x04001F92 RID: 8082
				Func_VampireTome_Set1 = 40974U,
				// Token: 0x04001F93 RID: 8083
				Func_VampireTome_Set2,
				// Token: 0x04001F94 RID: 8084
				Func_VampireTome_Set3,
				// Token: 0x04001F95 RID: 8085
				Func_VampireTome_Ultimate,
				// Token: 0x04001F96 RID: 8086
				Func_Wands = 49173U,
				// Token: 0x04001F97 RID: 8087
				Func_VanityTable = 36866U,
				// Token: 0x04001F98 RID: 8088
				Func_WardrobePedestal = 61441U,
				// Token: 0x04001F99 RID: 8089
				Func_WarmingRack = 12375U,
				// Token: 0x04001F9A RID: 8090
				Func_Vase = 1145U,
				// Token: 0x04001F9B RID: 8091
				Func_WaterScooter = 63490U,
				// Token: 0x04001F9C RID: 8092
				Func_WaterScooter_BeachVenue = 2197U,
				// Token: 0x04001F9D RID: 8093
				Func_VaultDoor = 61472U,
				// Token: 0x04001F9E RID: 8094
				Func_VaultSafe = 61471U,
				// Token: 0x04001F9F RID: 8095
				Func_WaxBlock = 67630U,
				// Token: 0x04001FA0 RID: 8096
				Func_Web = 1191U,
				// Token: 0x04001FA1 RID: 8097
				Func_Vehicle = 2226U,
				// Token: 0x04001FA2 RID: 8098
				Func_Vehicle_Bike,
				// Token: 0x04001FA3 RID: 8099
				Func_Vehicle_Land = 2231U,
				// Token: 0x04001FA4 RID: 8100
				Func_Vehicle_Water,
				// Token: 0x04001FA5 RID: 8101
				Func_Wellness = 18453U,
				// Token: 0x04001FA6 RID: 8102
				Func_VendingMachine_ColdDrinkAndSnack_Energy_EP10 = 69672U,
				// Token: 0x04001FA7 RID: 8103
				Func_VendingMachine_ColdDrinkAndSnack_Food_EP10 = 69671U,
				// Token: 0x04001FA8 RID: 8104
				Func_VendingMachine_ColdDrinkAndSnack_Fruit_EP10 = 69673U,
				// Token: 0x04001FA9 RID: 8105
				Func_VendingMachine_HotFoodAndDrink_Energy_EP10 = 69670U,
				// Token: 0x04001FAA RID: 8106
				Func_VendingMachine_HotFoodAndDrink_Food_EP10 = 69669U,
				// Token: 0x04001FAB RID: 8107
				Func_Venue_NotDestroyableByCleanup = 2013U,
				// Token: 0x04001FAC RID: 8108
				Func_Venue_NotUnbrokenByCleanup = 2509U,
				// Token: 0x04001FAD RID: 8109
				Func_Werewolf = 1215U,
				// Token: 0x04001FAE RID: 8110
				Func_VerticalGarden = 67618U,
				// Token: 0x04001FAF RID: 8111
				Func_Vet = 57378U,
				// Token: 0x04001FB0 RID: 8112
				Func_Vet_ExamTable = 57375U,
				// Token: 0x04001FB1 RID: 8113
				Func_Vet_MedicineStation = 57428U,
				// Token: 0x04001FB2 RID: 8114
				Func_Vet_Podium = 57374U,
				// Token: 0x04001FB3 RID: 8115
				Func_Vet_SurgeryStation = 57390U,
				// Token: 0x04001FB4 RID: 8116
				Func_VetVendingMachine = 57430U,
				// Token: 0x04001FB5 RID: 8117
				Func_WFS = 61480U,
				// Token: 0x04001FB6 RID: 8118
				Func_WFS_PreMadeCelebrity = 61612U,
				// Token: 0x04001FB7 RID: 8119
				Func_VFXMachine_ControlDesk = 61479U,
				// Token: 0x04001FB8 RID: 8120
				Func_VFXMachine_Emitter = 61468U,
				// Token: 0x04001FB9 RID: 8121
				Func_Whirlpool_Tub = 882U,
				// Token: 0x04001FBA RID: 8122
				Func_Video_Game = 1644U,
				// Token: 0x04001FBB RID: 8123
				Func_Videogame = 479U,
				// Token: 0x04001FBC RID: 8124
				Func_VideoGameConsoleDisplay = 55368U,
				// Token: 0x04001FBD RID: 8125
				Func_VideoGaming = 24596U,
				// Token: 0x04001FBE RID: 8126
				Func_VideoRecording = 61474U,
				// Token: 0x04001FBF RID: 8127
				Func_VideoRecording_BG = 2189U,
				// Token: 0x04001FC0 RID: 8128
				Func_VideoStation = 61473U,
				// Token: 0x04001FC1 RID: 8129
				Func_Wilderness = 1279U,
				// Token: 0x04001FC2 RID: 8130
				Func_WildlifeEncounter_Deterrent = 69665U,
				// Token: 0x04001FC3 RID: 8131
				Func_WildlifeEncounter_Remedy,
				// Token: 0x04001FC4 RID: 8132
				Func_Villain = 1128U,
				// Token: 0x04001FC5 RID: 8133
				Func_WindChimes = 34819U,
				// Token: 0x04001FC6 RID: 8134
				Func_WindTurbine = 67614U,
				// Token: 0x04001FC7 RID: 8135
				Func_WindTurbine_UpgradedLightningRod = 2437U,
				// Token: 0x04001FC8 RID: 8136
				Func_Violin = 569U,
				// Token: 0x04001FC9 RID: 8137
				Func_ViolinAdult = 1635U,
				// Token: 0x04001FCA RID: 8138
				Func_VIPRope = 61477U,
				// Token: 0x04001FCB RID: 8139
				Func_WishingWell = 30722U,
				// Token: 0x04001FCC RID: 8140
				Func_Witch = 1218U,
				// Token: 0x04001FCD RID: 8141
				Func_Vocal = 490U,
				// Token: 0x04001FCE RID: 8142
				Func_Wood = 1319U,
				// Token: 0x04001FCF RID: 8143
				Func_Voodoo = 582U,
				// Token: 0x04001FD0 RID: 8144
				Func_Woodworking = 1462U,
				// Token: 0x04001FD1 RID: 8145
				Func_Workbench = 493U,
				// Token: 0x04001FD2 RID: 8146
				Func_Workout = 472U,
				// Token: 0x04001FD3 RID: 8147
				Func_WorkoutMachine = 1324U,
				// Token: 0x04001FD4 RID: 8148
				Func_Writer = 1117U,
				// Token: 0x04001FD5 RID: 8149
				Func_Writing = 1106U,
				// Token: 0x04001FD6 RID: 8150
				Func_Xmas = 1331U,
				// Token: 0x04001FD7 RID: 8151
				Func_YarnBasket = 83972U,
				// Token: 0x04001FD8 RID: 8152
				Func_Yarny = 83971U,
				// Token: 0x04001FD9 RID: 8153
				Func_YarnyStatue = 83991U,
				// Token: 0x04001FDA RID: 8154
				Func_yoga = 18458U,
				// Token: 0x04001FDB RID: 8155
				Func_YogaClass_InstructorMat = 18447U,
				// Token: 0x04001FDC RID: 8156
				Func_YogaClass_MemberMat,
				// Token: 0x04001FDD RID: 8157
				Func_YogaClass_MemberTempMat,
				// Token: 0x04001FDE RID: 8158
				Func_YogaMat = 18433U,
				// Token: 0x04001FDF RID: 8159
				Fur_Chow = 57356U,
				// Token: 0x04001FE0 RID: 8160
				Fur_Collie = 57364U,
				// Token: 0x04001FE1 RID: 8161
				Fur_MediumSmooth = 57357U,
				// Token: 0x04001FE2 RID: 8162
				Fur_MediumWiry = 57366U,
				// Token: 0x04001FE3 RID: 8163
				Fur_Poodle = 57358U,
				// Token: 0x04001FE4 RID: 8164
				Fur_Retriever,
				// Token: 0x04001FE5 RID: 8165
				Fur_Spaniel = 57365U,
				// Token: 0x04001FE6 RID: 8166
				FurLength_Hairless = 2018U,
				// Token: 0x04001FE7 RID: 8167
				FurLength_LongHair = 2017U,
				// Token: 0x04001FE8 RID: 8168
				FurLength_ShortHair = 2016U,
				// Token: 0x04001FE9 RID: 8169
				GenderAppropriate_Female = 1530U,
				// Token: 0x04001FEA RID: 8170
				GenderAppropriate_Male = 1529U,
				// Token: 0x04001FEB RID: 8171
				Genre_ActivityTable_Dino = 877U,
				// Token: 0x04001FEC RID: 8172
				Genre_ActivityTable_Family,
				// Token: 0x04001FED RID: 8173
				Genre_ActivityTable_Horse,
				// Token: 0x04001FEE RID: 8174
				Genre_ActivityTable_Shapes,
				// Token: 0x04001FEF RID: 8175
				Genre_ActivityTable_Truck,
				// Token: 0x04001FF0 RID: 8176
				Genre_Book_Biography = 768U,
				// Token: 0x04001FF1 RID: 8177
				Genre_Book_Childrens,
				// Token: 0x04001FF2 RID: 8178
				Genre_Book_Emotion_Confident = 790U,
				// Token: 0x04001FF3 RID: 8179
				Genre_Book_Emotion_Energized,
				// Token: 0x04001FF4 RID: 8180
				Genre_Book_Emotion_Flirty,
				// Token: 0x04001FF5 RID: 8181
				Genre_Book_Emotion_Focused = 1038U,
				// Token: 0x04001FF6 RID: 8182
				Genre_Book_Emotion_Inspired,
				// Token: 0x04001FF7 RID: 8183
				Genre_Book_Emotion_Playful = 793U,
				// Token: 0x04001FF8 RID: 8184
				Genre_Book_Emotion_Sad,
				// Token: 0x04001FF9 RID: 8185
				Genre_Book_Emotional = 980U,
				// Token: 0x04001FFA RID: 8186
				Genre_Book_Fantasy = 770U,
				// Token: 0x04001FFB RID: 8187
				Genre_Book_Magic = 2224U,
				// Token: 0x04001FFC RID: 8188
				Genre_Book_MysteryThriller = 866U,
				// Token: 0x04001FFD RID: 8189
				Genre_Book_NonFiction = 771U,
				// Token: 0x04001FFE RID: 8190
				Genre_Book_Poems,
				// Token: 0x04001FFF RID: 8191
				Genre_Book_Romance,
				// Token: 0x04002000 RID: 8192
				Genre_Book_SciFi,
				// Token: 0x04002001 RID: 8193
				Genre_Book_ScreenPlay,
				// Token: 0x04002002 RID: 8194
				Genre_Book_ShortStories,
				// Token: 0x04002003 RID: 8195
				Genre_Book_Skill = 1032U,
				// Token: 0x04002004 RID: 8196
				Genre_Book_Skill_Acting = 61493U,
				// Token: 0x04002005 RID: 8197
				Genre_Book_Skill_Archaeology = 45069U,
				// Token: 0x04002006 RID: 8198
				Genre_Book_Skill_Bartending = 797U,
				// Token: 0x04002007 RID: 8199
				Genre_Book_Skill_Charisma,
				// Token: 0x04002008 RID: 8200
				Genre_Book_Skill_Comedy,
				// Token: 0x04002009 RID: 8201
				Genre_Book_Skill_Cooking,
				// Token: 0x0400200A RID: 8202
				Genre_Book_Skill_Fabrication = 67621U,
				// Token: 0x0400200B RID: 8203
				Genre_Book_Skill_Fishing = 921U,
				// Token: 0x0400200C RID: 8204
				Genre_Book_Skill_Fitness = 810U,
				// Token: 0x0400200D RID: 8205
				Genre_Book_Skill_Gardening = 801U,
				// Token: 0x0400200E RID: 8206
				Genre_Book_Skill_Gourmet,
				// Token: 0x0400200F RID: 8207
				Genre_Book_Skill_Guitar,
				// Token: 0x04002010 RID: 8208
				Genre_Book_Skill_Hacking,
				// Token: 0x04002011 RID: 8209
				Genre_Book_Skill_Handiness,
				// Token: 0x04002012 RID: 8210
				Genre_Book_Skill_Herbalism = 10256U,
				// Token: 0x04002013 RID: 8211
				Genre_Book_Skill_Logic = 806U,
				// Token: 0x04002014 RID: 8212
				Genre_Book_Skill_Mischief,
				// Token: 0x04002015 RID: 8213
				Genre_Book_Skill_Painting,
				// Token: 0x04002016 RID: 8214
				Genre_Book_Skill_Parenting = 43012U,
				// Token: 0x04002017 RID: 8215
				Genre_Book_Skill_Piano = 809U,
				// Token: 0x04002018 RID: 8216
				Genre_Book_Skill_ResearchDebate = 2246U,
				// Token: 0x04002019 RID: 8217
				Genre_Book_Skill_Robotics = 65623U,
				// Token: 0x0400201A RID: 8218
				Genre_Book_Skill_RocketScience = 811U,
				// Token: 0x0400201B RID: 8219
				Genre_Book_Skill_VideoGaming,
				// Token: 0x0400201C RID: 8220
				Genre_Book_Skill_Violin,
				// Token: 0x0400201D RID: 8221
				Genre_Book_Skill_WooHoo = 865U,
				// Token: 0x0400201E RID: 8222
				Genre_Book_Skill_Writing = 818U,
				// Token: 0x0400201F RID: 8223
				Genre_Book_Supernatural,
				// Token: 0x04002020 RID: 8224
				Genre_Book_Toddler_PictureBook = 1656U,
				// Token: 0x04002021 RID: 8225
				Genre_Book_TravelGuide = 45071U,
				// Token: 0x04002022 RID: 8226
				Genre_Painting_Abstract = 667U,
				// Token: 0x04002023 RID: 8227
				Genre_Painting_Classics = 669U,
				// Token: 0x04002024 RID: 8228
				Genre_Painting_Impressionism,
				// Token: 0x04002025 RID: 8229
				Genre_Painting_Landscape = 10260U,
				// Token: 0x04002026 RID: 8230
				Genre_Painting_Mathematics = 671U,
				// Token: 0x04002027 RID: 8231
				Genre_Painting_PopArt,
				// Token: 0x04002028 RID: 8232
				Genre_Painting_Realism,
				// Token: 0x04002029 RID: 8233
				Genre_Painting_Surrealism,
				// Token: 0x0400202A RID: 8234
				GP09 = 51270U,
				// Token: 0x0400202B RID: 8235
				Group_Photo_X_Actor = 1436U,
				// Token: 0x0400202C RID: 8236
				Group_Photo_Y_Actor,
				// Token: 0x0400202D RID: 8237
				Group_Photo_Z_Actor = 2217U,
				// Token: 0x0400202E RID: 8238
				Hair_Curly = 314U,
				// Token: 0x0400202F RID: 8239
				Hair_Long = 151U,
				// Token: 0x04002030 RID: 8240
				Hair_Medium = 150U,
				// Token: 0x04002031 RID: 8241
				Hair_Short = 149U,
				// Token: 0x04002032 RID: 8242
				Hair_Straight = 313U,
				// Token: 0x04002033 RID: 8243
				Hair_Wavy = 315U,
				// Token: 0x04002034 RID: 8244
				HairColor_Auburn = 896U,
				// Token: 0x04002035 RID: 8245
				HairColor_Black = 131U,
				// Token: 0x04002036 RID: 8246
				HairColor_BlackSaltAndPepper = 897U,
				// Token: 0x04002037 RID: 8247
				HairColor_Blonde = 94U,
				// Token: 0x04002038 RID: 8248
				HairColor_Brown = 132U,
				// Token: 0x04002039 RID: 8249
				HairColor_BrownSaltAndPepper = 898U,
				// Token: 0x0400203A RID: 8250
				HairColor_DarkBlue,
				// Token: 0x0400203B RID: 8251
				HairColor_DarkBrown = 133U,
				// Token: 0x0400203C RID: 8252
				HairColor_DirtyBlond = 900U,
				// Token: 0x0400203D RID: 8253
				HairColor_Gray = 134U,
				// Token: 0x0400203E RID: 8254
				HairColor_Green = 901U,
				// Token: 0x0400203F RID: 8255
				HairColor_HotPink,
				// Token: 0x04002040 RID: 8256
				HairColor_LightBlonde = 2532U,
				// Token: 0x04002041 RID: 8257
				HairColor_LightBrown = 2530U,
				// Token: 0x04002042 RID: 8258
				HairColor_NeutralBlack = 2528U,
				// Token: 0x04002043 RID: 8259
				HairColor_NeutralBlonde = 2531U,
				// Token: 0x04002044 RID: 8260
				HairColor_Orange = 135U,
				// Token: 0x04002045 RID: 8261
				HairColor_Platinum = 96U,
				// Token: 0x04002046 RID: 8262
				HairColor_PurplePastel = 903U,
				// Token: 0x04002047 RID: 8263
				HairColor_Red = 136U,
				// Token: 0x04002048 RID: 8264
				HairColor_Turquoise = 904U,
				// Token: 0x04002049 RID: 8265
				HairColor_WarmBrown = 2529U,
				// Token: 0x0400204A RID: 8266
				HairColor_White = 905U,
				// Token: 0x0400204B RID: 8267
				HairColor_WhiteBlonde = 2533U,
				// Token: 0x0400204C RID: 8268
				HairLength_Long = 664U,
				// Token: 0x0400204D RID: 8269
				HairLength_Medium = 820U,
				// Token: 0x0400204E RID: 8270
				HairLength_Short = 662U,
				// Token: 0x0400204F RID: 8271
				HairLength_Updo = 2173U,
				// Token: 0x04002050 RID: 8272
				HairTexture_Bald = 12391U,
				// Token: 0x04002051 RID: 8273
				HairTexture_Curly = 821U,
				// Token: 0x04002052 RID: 8274
				HairTexture_Straight,
				// Token: 0x04002053 RID: 8275
				HairTexture_Wavy = 663U,
				// Token: 0x04002054 RID: 8276
				Hat_Brim = 371U,
				// Token: 0x04002055 RID: 8277
				Hat_Brimless,
				// Token: 0x04002056 RID: 8278
				Hat_Cap,
				// Token: 0x04002057 RID: 8279
				Hat_PaperBag = 2428U,
				// Token: 0x04002058 RID: 8280
				household_member_1 = 642U,
				// Token: 0x04002059 RID: 8281
				household_member_2,
				// Token: 0x0400205A RID: 8282
				household_member_3,
				// Token: 0x0400205B RID: 8283
				household_member_4,
				// Token: 0x0400205C RID: 8284
				household_member_5,
				// Token: 0x0400205D RID: 8285
				household_member_6,
				// Token: 0x0400205E RID: 8286
				household_member_7,
				// Token: 0x0400205F RID: 8287
				household_member_8,
				// Token: 0x04002060 RID: 8288
				Instrument_Violin = 401U,
				// Token: 0x04002061 RID: 8289
				Interaction_Adoption = 57441U,
				// Token: 0x04002062 RID: 8290
				Interaction_Adventurous_OneShot = 69723U,
				// Token: 0x04002063 RID: 8291
				Interaction_All = 462U,
				// Token: 0x04002064 RID: 8292
				Interaction_Argument = 43015U,
				// Token: 0x04002065 RID: 8293
				Interaction_AskToLeaveLot = 689U,
				// Token: 0x04002066 RID: 8294
				Interaction_BarVenue = 1599U,
				// Token: 0x04002067 RID: 8295
				Interaction_Basketball_Play = 2127U,
				// Token: 0x04002068 RID: 8296
				Interaction_Bathtub = 2348U,
				// Token: 0x04002069 RID: 8297
				Interaction_Batuu_IgnoreReputation = 51246U,
				// Token: 0x0400206A RID: 8298
				Interaction_BeReadTo = 863U,
				// Token: 0x0400206B RID: 8299
				Interaction_Bonfire = 24590U,
				// Token: 0x0400206C RID: 8300
				Interaction_BrowseResearch = 757U,
				// Token: 0x0400206D RID: 8301
				Interaction_Campfire = 10262U,
				// Token: 0x0400206E RID: 8302
				Interaction_Career_Work_RabbitHole = 2490U,
				// Token: 0x0400206F RID: 8303
				Interaction_Charity = 750U,
				// Token: 0x04002070 RID: 8304
				Interaction_Chat = 342U,
				// Token: 0x04002071 RID: 8305
				Interaction_Clean = 781U,
				// Token: 0x04002072 RID: 8306
				Interaction_ClimbingRoute = 69691U,
				// Token: 0x04002073 RID: 8307
				Interaction_Collect = 1309U,
				// Token: 0x04002074 RID: 8308
				Interaction_ComedyMic = 1613U,
				// Token: 0x04002075 RID: 8309
				Interaction_Computer = 439U,
				// Token: 0x04002076 RID: 8310
				Interaction_Computer_Typing = 1367U,
				// Token: 0x04002077 RID: 8311
				Interaction_Consume = 394U,
				// Token: 0x04002078 RID: 8312
				Interaction_Cook = 358U,
				// Token: 0x04002079 RID: 8313
				Interaction_CurioShop_BrowseBuy = 47134U,
				// Token: 0x0400207A RID: 8314
				Interaction_Death = 425U,
				// Token: 0x0400207B RID: 8315
				Interaction_Doctor_TreatPatient = 12337U,
				// Token: 0x0400207C RID: 8316
				Interaction_Drink = 654U,
				// Token: 0x0400207D RID: 8317
				Interaction_EcoFootprint_Green = 67603U,
				// Token: 0x0400207E RID: 8318
				Interaction_ExamTable_Exam = 57391U,
				// Token: 0x0400207F RID: 8319
				Interaction_ExtremeSports = 69727U,
				// Token: 0x04002080 RID: 8320
				Interaction_FashionBlog = 2131U,
				// Token: 0x04002081 RID: 8321
				Interaction_Festive = 2058U,
				// Token: 0x04002082 RID: 8322
				Interaction_FoosballTable_Play = 24581U,
				// Token: 0x04002083 RID: 8323
				Interaction_Friendly = 431U,
				// Token: 0x04002084 RID: 8324
				Interaction_Funny,
				// Token: 0x04002085 RID: 8325
				Interaction_GameConsole = 55384U,
				// Token: 0x04002086 RID: 8326
				Interaction_GoJogging = 926U,
				// Token: 0x04002087 RID: 8327
				Interaction_GreenUpgraded = 67589U,
				// Token: 0x04002088 RID: 8328
				Interaction_Greeting = 453U,
				// Token: 0x04002089 RID: 8329
				Interaction_Group_Workout = 71683U,
				// Token: 0x0400208A RID: 8330
				Interaction_GroupDanceTogether = 24607U,
				// Token: 0x0400208B RID: 8331
				Interaction_Hack = 435U,
				// Token: 0x0400208C RID: 8332
				Interaction_Hug = 1990U,
				// Token: 0x0400208D RID: 8333
				Interaction_IgnoreGrounding = 43028U,
				// Token: 0x0400208E RID: 8334
				Interaction_Infect_House = 47125U,
				// Token: 0x0400208F RID: 8335
				Interaction_InstrumentListen = 639U,
				// Token: 0x04002090 RID: 8336
				Interaction_IntelligenceResearch = 746U,
				// Token: 0x04002091 RID: 8337
				Interaction_InventionConstructor_Upgrade = 12368U,
				// Token: 0x04002092 RID: 8338
				Interaction_InviteToStay = 417U,
				// Token: 0x04002093 RID: 8339
				Interaction_Joke = 871U,
				// Token: 0x04002094 RID: 8340
				Interaction_JuiceKeg = 2347U,
				// Token: 0x04002095 RID: 8341
				Interaction_KaraokeVenue = 1600U,
				// Token: 0x04002096 RID: 8342
				Interaction_Kiss = 350U,
				// Token: 0x04002097 RID: 8343
				Interaction_Knitting = 83984U,
				// Token: 0x04002098 RID: 8344
				Interaction_Laundry_GenerateNoPile = 2035U,
				// Token: 0x04002099 RID: 8345
				Interaction_Laundry_PutAwayFinishedLaundry = 2034U,
				// Token: 0x0400209A RID: 8346
				Interaction_Leave = 420U,
				// Token: 0x0400209B RID: 8347
				Interaction_LeaveMustRun = 419U,
				// Token: 0x0400209C RID: 8348
				Interaction_Lifestyles_AdrenalineSeeker_DiscourageAutonomy = 69730U,
				// Token: 0x0400209D RID: 8349
				Interaction_Lifestyles_AdrenalineSeeker_FlexibleLength = 69655U,
				// Token: 0x0400209E RID: 8350
				Interaction_Lifestyles_AdrenalineSeeker_Mundane = 69712U,
				// Token: 0x0400209F RID: 8351
				Interaction_Lifestyles_AdrenalineSeeker_OneShot = 69656U,
				// Token: 0x040020A0 RID: 8352
				Interaction_Lifestyles_Electronics = 69651U,
				// Token: 0x040020A1 RID: 8353
				Interaction_Lifestyles_ElectronicsRepair,
				// Token: 0x040020A2 RID: 8354
				Interaction_Lifestyles_Energetic_FlexibleLength = 69634U,
				// Token: 0x040020A3 RID: 8355
				Interaction_Lifestyles_Energetic_OneShot = 69690U,
				// Token: 0x040020A4 RID: 8356
				Interaction_Lifestyles_EnergeticAutonomy = 69737U,
				// Token: 0x040020A5 RID: 8357
				Interaction_Lifestyles_FrequentTraveler_FlexibleLength = 69636U,
				// Token: 0x040020A6 RID: 8358
				Interaction_Lifestyles_FrequentTraveler_OneShot = 69635U,
				// Token: 0x040020A7 RID: 8359
				Interaction_Lifestyles_Indoorsy_FlexibleLength = 69657U,
				// Token: 0x040020A8 RID: 8360
				Interaction_Lifestyles_Indoorsy_OneShot,
				// Token: 0x040020A9 RID: 8361
				Interaction_Lifestyles_IndoorsyAutonomy = 69731U,
				// Token: 0x040020AA RID: 8362
				Interaction_Lifestyles_Outdoorsy_FlexibleLength = 69659U,
				// Token: 0x040020AB RID: 8363
				Interaction_lifestyles_Outdoorsy_OneShot,
				// Token: 0x040020AC RID: 8364
				Interaction_Lifestyles_OutdoorsyAutonomy = 69734U,
				// Token: 0x040020AD RID: 8365
				Interaction_Lifestyles_RomanticMedia = 69713U,
				// Token: 0x040020AE RID: 8366
				Interaction_Lifestyles_Sedentary_FlexibleLength = 69633U,
				// Token: 0x040020AF RID: 8367
				Interaction_Lifestyles_Sedentary_OneShot = 69689U,
				// Token: 0x040020B0 RID: 8368
				Interaction_Lifestyles_SedentaryAutonomy = 69736U,
				// Token: 0x040020B1 RID: 8369
				Interaction_Lifestyles_TechCareer = 69663U,
				// Token: 0x040020B2 RID: 8370
				Interaction_Lifestyles_Techie_FlexibleLength = 69638U,
				// Token: 0x040020B3 RID: 8371
				Interaction_Lifestyles_Techie_OneShot,
				// Token: 0x040020B4 RID: 8372
				Interaction_Lifestyles_TechieAutonomy = 69735U,
				// Token: 0x040020B5 RID: 8373
				Interaction_Lifestyles_Technophobe_FlexibleLength = 69641U,
				// Token: 0x040020B6 RID: 8374
				Interaction_Lifestyles_Technophobe_OneShot = 69640U,
				// Token: 0x040020B7 RID: 8375
				Interaction_Lifestyles_Technophobe_Sabotage = 69704U,
				// Token: 0x040020B8 RID: 8376
				Interaction_ListenMusic = 444U,
				// Token: 0x040020B9 RID: 8377
				Interaction_MakeApp = 683U,
				// Token: 0x040020BA RID: 8378
				Interaction_MakeCoffeeOrTea = 1028U,
				// Token: 0x040020BB RID: 8379
				Interaction_MarketStall_Tend = 55400U,
				// Token: 0x040020BC RID: 8380
				Interaction_MarketStalls_Tend = 1934U,
				// Token: 0x040020BD RID: 8381
				Interaction_MassageTable = 18439U,
				// Token: 0x040020BE RID: 8382
				Interaction_Mean = 433U,
				// Token: 0x040020BF RID: 8383
				Interaction_Mentor = 455U,
				// Token: 0x040020C0 RID: 8384
				Interaction_MentorMusic = 695U,
				// Token: 0x040020C1 RID: 8385
				Interaction_Mischievous = 434U,
				// Token: 0x040020C2 RID: 8386
				Interaction_Mixer = 461U,
				// Token: 0x040020C3 RID: 8387
				Interaction_Nap = 591U,
				// Token: 0x040020C4 RID: 8388
				Interaction_NestingBlocks = 1698U,
				// Token: 0x040020C5 RID: 8389
				Interaction_NoisyElectronics = 1628U,
				// Token: 0x040020C6 RID: 8390
				Interaction_Observatory = 1598U,
				// Token: 0x040020C7 RID: 8391
				Interaction_OldDay_Fine = 67638U,
				// Token: 0x040020C8 RID: 8392
				Interaction_Paint = 694U,
				// Token: 0x040020C9 RID: 8393
				Interaction_PaintByReference = 1372U,
				// Token: 0x040020CA RID: 8394
				Interaction_PaintMural = 55359U,
				// Token: 0x040020CB RID: 8395
				Interaction_ParkVenue = 1601U,
				// Token: 0x040020CC RID: 8396
				Interaction_Party = 2061U,
				// Token: 0x040020CD RID: 8397
				Interaction_PerformComedyRoutine = 469U,
				// Token: 0x040020CE RID: 8398
				Interaction_PetMisbehavior = 57397U,
				// Token: 0x040020CF RID: 8399
				Interaction_Pets_Friendly = 57370U,
				// Token: 0x040020D0 RID: 8400
				Interaction_Pets_Greeting = 57372U,
				// Token: 0x040020D1 RID: 8401
				Interaction_Pets_Mean = 57371U,
				// Token: 0x040020D2 RID: 8402
				Interaction_Pets_SS3Allowed = 2015U,
				// Token: 0x040020D3 RID: 8403
				Interaction_PhotoStudio_TakePicture = 1942U,
				// Token: 0x040020D4 RID: 8404
				Interaction_PlayDJBooth = 1618U,
				// Token: 0x040020D5 RID: 8405
				Interaction_PlayGame = 640U,
				// Token: 0x040020D6 RID: 8406
				Interaction_PlayGuitar = 1615U,
				// Token: 0x040020D7 RID: 8407
				Interaction_PlayGuitarForTips = 1024U,
				// Token: 0x040020D8 RID: 8408
				Interaction_PlayInstrument = 442U,
				// Token: 0x040020D9 RID: 8409
				Interaction_PlayInstrumentForTips,
				// Token: 0x040020DA RID: 8410
				Interaction_PlayInstrumentOrComedyForTips = 606U,
				// Token: 0x040020DB RID: 8411
				Interaction_PlayPiano = 690U,
				// Token: 0x040020DC RID: 8412
				Interaction_PlayPianoforTips = 1025U,
				// Token: 0x040020DD RID: 8413
				Interaction_PlayToy = 1339U,
				// Token: 0x040020DE RID: 8414
				Interaction_PlayVideoGames = 685U,
				// Token: 0x040020DF RID: 8415
				Interaction_PlayViolin = 1616U,
				// Token: 0x040020E0 RID: 8416
				Interaction_PlayViolinForTips = 1026U,
				// Token: 0x040020E1 RID: 8417
				Interaction_PlayWithCat = 57362U,
				// Token: 0x040020E2 RID: 8418
				Interaction_PlayWithDog,
				// Token: 0x040020E3 RID: 8419
				Interaction_Practice_Acting = 61552U,
				// Token: 0x040020E4 RID: 8420
				Interaction_PracticeCoding = 693U,
				// Token: 0x040020E5 RID: 8421
				Interaction_PracticeDebate = 65648U,
				// Token: 0x040020E6 RID: 8422
				Interaction_PracticeWriting = 692U,
				// Token: 0x040020E7 RID: 8423
				Interaction_Prank = 583U,
				// Token: 0x040020E8 RID: 8424
				Interaction_PrankObject = 752U,
				// Token: 0x040020E9 RID: 8425
				Interaction_Programming = 751U,
				// Token: 0x040020EA RID: 8426
				Interaction_PublishBook = 660U,
				// Token: 0x040020EB RID: 8427
				Interaction_ReadtoChild = 931U,
				// Token: 0x040020EC RID: 8428
				Interaction_Repair = 464U,
				// Token: 0x040020ED RID: 8429
				Interaction_Restaurant_WaitToPlaceOrder = 2151U,
				// Token: 0x040020EE RID: 8430
				Interaction_Retail = 12347U,
				// Token: 0x040020EF RID: 8431
				Interaction_Rocket = 465U,
				// Token: 0x040020F0 RID: 8432
				Interaction_Rocketship_Launch = 438U,
				// Token: 0x040020F1 RID: 8433
				Interaction_Rocketship_Upgrade = 437U,
				// Token: 0x040020F2 RID: 8434
				Interaction_RunAway = 57443U,
				// Token: 0x040020F3 RID: 8435
				Interaction_SchoolWork = 43026U,
				// Token: 0x040020F4 RID: 8436
				Interaction_ScienceTable = 786U,
				// Token: 0x040020F5 RID: 8437
				Interaction_Season_Fall = 59420U,
				// Token: 0x040020F6 RID: 8438
				Interaction_Season_Spring = 59418U,
				// Token: 0x040020F7 RID: 8439
				Interaction_Season_Summer,
				// Token: 0x040020F8 RID: 8440
				Interaction_Season_Winter = 59421U,
				// Token: 0x040020F9 RID: 8441
				Interaction_SellArt = 661U,
				// Token: 0x040020FA RID: 8442
				Interaction_Shower = 1447U,
				// Token: 0x040020FB RID: 8443
				Interaction_Showoff = 427U,
				// Token: 0x040020FC RID: 8444
				Interaction_SimTV = 55362U,
				// Token: 0x040020FD RID: 8445
				Interaction_Situation_Photography = 79876U,
				// Token: 0x040020FE RID: 8446
				Interaction_Skating_IceSkating = 59395U,
				// Token: 0x040020FF RID: 8447
				Interaction_Skating_RollerSkating,
				// Token: 0x04002100 RID: 8448
				Interaction_Skating_Routine,
				// Token: 0x04002101 RID: 8449
				Interaction_Skating_Skating = 59394U,
				// Token: 0x04002102 RID: 8450
				Interaction_Skating_Trick = 59401U,
				// Token: 0x04002103 RID: 8451
				Interaction_Sketch = 2132U,
				// Token: 0x04002104 RID: 8452
				Interaction_Skiing = 69726U,
				// Token: 0x04002105 RID: 8453
				Interaction_Skill_Acting = 2340U,
				// Token: 0x04002106 RID: 8454
				Interaction_Skill_Baking = 2346U,
				// Token: 0x04002107 RID: 8455
				Interaction_Skill_Bartending = 835U,
				// Token: 0x04002108 RID: 8456
				Interaction_Skill_Charisma = 837U,
				// Token: 0x04002109 RID: 8457
				Interaction_Skill_Child_Creativity = 853U,
				// Token: 0x0400210A RID: 8458
				Interaction_Skill_Child_Mental,
				// Token: 0x0400210B RID: 8459
				Interaction_Skill_Child_Motor,
				// Token: 0x0400210C RID: 8460
				Interaction_Skill_Child_Social,
				// Token: 0x0400210D RID: 8461
				Interaction_Skill_Comedy = 838U,
				// Token: 0x0400210E RID: 8462
				Interaction_Skill_Dancing = 2343U,
				// Token: 0x0400210F RID: 8463
				Interaction_Skill_DJMixing = 2342U,
				// Token: 0x04002110 RID: 8464
				Interaction_Skill_DogTraining = 57373U,
				// Token: 0x04002111 RID: 8465
				Interaction_Skill_Fabrication = 2434U,
				// Token: 0x04002112 RID: 8466
				Interaction_Skill_Fishing = 839U,
				// Token: 0x04002113 RID: 8467
				Interaction_Skill_Fitness = 836U,
				// Token: 0x04002114 RID: 8468
				Interaction_Skill_FlowerArrangement = 2344U,
				// Token: 0x04002115 RID: 8469
				Interaction_Skill_Gardening = 834U,
				// Token: 0x04002116 RID: 8470
				Interaction_Skill_GourmetCooking = 840U,
				// Token: 0x04002117 RID: 8471
				Interaction_Skill_Guitar,
				// Token: 0x04002118 RID: 8472
				Interaction_Skill_Handiness,
				// Token: 0x04002119 RID: 8473
				Interaction_Skill_Herbalism = 2339U,
				// Token: 0x0400211A RID: 8474
				Interaction_Skill_HomestyleCooking = 843U,
				// Token: 0x0400211B RID: 8475
				Interaction_Skill_JuiceFizzing = 2424U,
				// Token: 0x0400211C RID: 8476
				Interaction_Skill_Knitting = 2461U,
				// Token: 0x0400211D RID: 8477
				Interaction_Skill_Logic = 844U,
				// Token: 0x0400211E RID: 8478
				Interaction_Skill_MediaProduction = 2338U,
				// Token: 0x0400211F RID: 8479
				Interaction_Skill_Mischief = 845U,
				// Token: 0x04002120 RID: 8480
				Interaction_Skill_Painting,
				// Token: 0x04002121 RID: 8481
				Interaction_Skill_Photography = 1938U,
				// Token: 0x04002122 RID: 8482
				Interaction_Skill_Piano = 847U,
				// Token: 0x04002123 RID: 8483
				Interaction_Skill_PipeOrgan = 2341U,
				// Token: 0x04002124 RID: 8484
				Interaction_Skill_Programming = 848U,
				// Token: 0x04002125 RID: 8485
				Interaction_Skill_Robotics = 2345U,
				// Token: 0x04002126 RID: 8486
				Interaction_Skill_RocketScience = 849U,
				// Token: 0x04002127 RID: 8487
				Interaction_Skill_Singing = 55364U,
				// Token: 0x04002128 RID: 8488
				Interaction_Skill_SingingKaraoke = 1617U,
				// Token: 0x04002129 RID: 8489
				Interaction_Skill_Wellness = 18465U,
				// Token: 0x0400212A RID: 8490
				Interaction_Skill_Wellness_BG = 2337U,
				// Token: 0x0400212B RID: 8491
				Interaction_Skill_VideoGaming = 850U,
				// Token: 0x0400212C RID: 8492
				Interaction_Skill_Violin,
				// Token: 0x0400212D RID: 8493
				Interaction_Skill_Writing,
				// Token: 0x0400212E RID: 8494
				Interaction_Sledding = 69725U,
				// Token: 0x0400212F RID: 8495
				Interaction_Sleep = 451U,
				// Token: 0x04002130 RID: 8496
				Interaction_SleepGroup = 2094U,
				// Token: 0x04002131 RID: 8497
				Interaction_SleepNap = 59477U,
				// Token: 0x04002132 RID: 8498
				Interaction_SniffNewObjects = 2093U,
				// Token: 0x04002133 RID: 8499
				Interaction_Snowboarding = 69724U,
				// Token: 0x04002134 RID: 8500
				Interaction_Social_Contagious = 2041U,
				// Token: 0x04002135 RID: 8501
				Interaction_Social_Touching = 2163U,
				// Token: 0x04002136 RID: 8502
				Interaction_SocialAll = 2161U,
				// Token: 0x04002137 RID: 8503
				Interaction_SocialMediaCheckIn = 1619U,
				// Token: 0x04002138 RID: 8504
				Interaction_SocialMediaPersuadeTo = 55319U,
				// Token: 0x04002139 RID: 8505
				Interaction_SocialMixer = 2162U,
				// Token: 0x0400213A RID: 8506
				Interaction_SocialNetwork = 1595U,
				// Token: 0x0400213B RID: 8507
				Interaction_SocialSuper = 454U,
				// Token: 0x0400213C RID: 8508
				Interaction_SprayGraffiti = 55361U,
				// Token: 0x0400213D RID: 8509
				Interaction_StereoDance = 876U,
				// Token: 0x0400213E RID: 8510
				Interaction_StereoListen = 638U,
				// Token: 0x0400213F RID: 8511
				Interaction_StuffedAnimal_Babble = 1723U,
				// Token: 0x04002140 RID: 8512
				Interaction_Super = 460U,
				// Token: 0x04002141 RID: 8513
				Interaction_SurgeryStation_Exam = 57392U,
				// Token: 0x04002142 RID: 8514
				Interaction_Swim = 1591U,
				// Token: 0x04002143 RID: 8515
				Interaction_Take_Pizza = 1640U,
				// Token: 0x04002144 RID: 8516
				Interaction_TakePhoto = 1939U,
				// Token: 0x04002145 RID: 8517
				Interaction_TalkLikeAPirateDay = 2480U,
				// Token: 0x04002146 RID: 8518
				Interaction_TeenCareerRabbitHole = 1719U,
				// Token: 0x04002147 RID: 8519
				Interaction_Telescope = 436U,
				// Token: 0x04002148 RID: 8520
				Interaction_TellStory = 466U,
				// Token: 0x04002149 RID: 8521
				Interaction_Tent_Sleep = 2477U,
				// Token: 0x0400214A RID: 8522
				Interaction_Throwing = 2488U,
				// Token: 0x0400214B RID: 8523
				Interaction_Throwing_Mud = 59425U,
				// Token: 0x0400214C RID: 8524
				Interaction_Throwing_Snowball = 2489U,
				// Token: 0x0400214D RID: 8525
				Interaction_Throwing_WaterBalloon = 59426U,
				// Token: 0x0400214E RID: 8526
				Interaction_Tournament = 749U,
				// Token: 0x0400214F RID: 8527
				Interaction_TransferFireleafRash = 2479U,
				// Token: 0x04002150 RID: 8528
				Interaction_Treadmill = 353U,
				// Token: 0x04002151 RID: 8529
				Interaction_TryForBaby = 452U,
				// Token: 0x04002152 RID: 8530
				Interaction_University_StudyWith = 65609U,
				// Token: 0x04002153 RID: 8531
				Interaction_Upgrade = 658U,
				// Token: 0x04002154 RID: 8532
				Interaction_UpgradeCleanBreak = 2517U,
				// Token: 0x04002155 RID: 8533
				Interaction_UseToilet = 396U,
				// Token: 0x04002156 RID: 8534
				Interaction_Vacuum = 94225U,
				// Token: 0x04002157 RID: 8535
				Interaction_WaitInLine = 2497U,
				// Token: 0x04002158 RID: 8536
				Interaction_WaitstaffIdle = 26634U,
				// Token: 0x04002159 RID: 8537
				Interaction_WatchPerformer = 1597U,
				// Token: 0x0400215A RID: 8538
				Interaction_WatchTV = 450U,
				// Token: 0x0400215B RID: 8539
				Interaction_WatchTV_Cooking = 55320U,
				// Token: 0x0400215C RID: 8540
				Interaction_WatchTV_RomComAct,
				// Token: 0x0400215D RID: 8541
				Interaction_Weather_Rain = 59423U,
				// Token: 0x0400215E RID: 8542
				Interaction_Weather_Snow = 59422U,
				// Token: 0x0400215F RID: 8543
				Interaction_VideoGameLivestream = 1641U,
				// Token: 0x04002160 RID: 8544
				Interaction_VideoGameMoney = 655U,
				// Token: 0x04002161 RID: 8545
				Interaction_VideoGameStreamLetsPlay = 1642U,
				// Token: 0x04002162 RID: 8546
				Interaction_ViewArt = 758U,
				// Token: 0x04002163 RID: 8547
				Interaction_VisitLot = 449U,
				// Token: 0x04002164 RID: 8548
				Interaction_Voodoo = 426U,
				// Token: 0x04002165 RID: 8549
				Interaction_Woodworking = 1612U,
				// Token: 0x04002166 RID: 8550
				Interaction_Workout = 463U,
				// Token: 0x04002167 RID: 8551
				Interaction_WorkoutMachine = 354U,
				// Token: 0x04002168 RID: 8552
				Interaction_WorkoutPushTheLimits = 1171U,
				// Token: 0x04002169 RID: 8553
				Interaction_Write = 55360U,
				// Token: 0x0400216A RID: 8554
				Interaction_WriteArticle = 665U,
				// Token: 0x0400216B RID: 8555
				Interaction_WriteJokes = 696U,
				// Token: 0x0400216C RID: 8556
				Interaction_YogaClassMember = 18461U,
				// Token: 0x0400216D RID: 8557
				Inventory_Books_Fun = 2350U,
				// Token: 0x0400216E RID: 8558
				Inventory_Books_Other = 2352U,
				// Token: 0x0400216F RID: 8559
				Inventory_Books_Skill = 2351U,
				// Token: 0x04002170 RID: 8560
				Inventory_Collectible_Creature = 2353U,
				// Token: 0x04002171 RID: 8561
				Inventory_Collectible_Decoration,
				// Token: 0x04002172 RID: 8562
				Inventory_Collectible_Natural,
				// Token: 0x04002173 RID: 8563
				Inventory_Collectible_Other,
				// Token: 0x04002174 RID: 8564
				Inventory_Consumable_Drink = 2358U,
				// Token: 0x04002175 RID: 8565
				Inventory_Consumable_Food = 2357U,
				// Token: 0x04002176 RID: 8566
				Inventory_Consumable_Other = 2359U,
				// Token: 0x04002177 RID: 8567
				Inventory_Gardening_Other,
				// Token: 0x04002178 RID: 8568
				Inventory_HomeSkill_Decoration = 2362U,
				// Token: 0x04002179 RID: 8569
				Inventory_HomeSkill_Home,
				// Token: 0x0400217A RID: 8570
				Inventory_HomeSkill_LittleOnes,
				// Token: 0x0400217B RID: 8571
				Inventory_HomeSkill_Skill = 2361U,
				// Token: 0x0400217C RID: 8572
				Inventory_Plopsy_All = 2459U,
				// Token: 0x0400217D RID: 8573
				Inventory_Plopsy_Listed = 2457U,
				// Token: 0x0400217E RID: 8574
				Inventory_Plopsy_Pending_Sale,
				// Token: 0x0400217F RID: 8575
				Inventory_Plopsy_Unavailable = 83989U,
				// Token: 0x04002180 RID: 8576
				Inventory_Scraps_Junk = 2371U,
				// Token: 0x04002181 RID: 8577
				Inventory_Scraps_Parts = 2370U,
				// Token: 0x04002182 RID: 8578
				Inventory_SimCrafted_Artwork = 2368U,
				// Token: 0x04002183 RID: 8579
				Inventory_SimCrafted_Other,
				// Token: 0x04002184 RID: 8580
				Inventory_Special_CareerActivity = 2365U,
				// Token: 0x04002185 RID: 8581
				Inventory_Special_Education,
				// Token: 0x04002186 RID: 8582
				Inventory_Special_Story,
				// Token: 0x04002187 RID: 8583
				job_BatuuNPC = 2512U,
				// Token: 0x04002188 RID: 8584
				Job_RestaurantDiner = 2145U,
				// Token: 0x04002189 RID: 8585
				Job_Walkby = 1463U,
				// Token: 0x0400218A RID: 8586
				Job_Venue,
				// Token: 0x0400218B RID: 8587
				Job_VetPatient = 57442U,
				// Token: 0x0400218C RID: 8588
				Lifestyles_Dangerous_Career = 69711U,
				// Token: 0x0400218D RID: 8589
				LIfestyles_HighEnergy_Career = 69683U,
				// Token: 0x0400218E RID: 8590
				Lifestyles_Indoorsy_Career = 69733U,
				// Token: 0x0400218F RID: 8591
				LIfestyles_LowEnergy_Career = 69684U,
				// Token: 0x04002190 RID: 8592
				Lifestyles_Outdoor_Career = 69721U,
				// Token: 0x04002191 RID: 8593
				Mailbox = 346U,
				// Token: 0x04002192 RID: 8594
				Main_Pet_Social = 57349U,
				// Token: 0x04002193 RID: 8595
				Mentor_ActivityTable = 588U,
				// Token: 0x04002194 RID: 8596
				Mentor_Easel = 365U,
				// Token: 0x04002195 RID: 8597
				Mentor_Fitness = 357U,
				// Token: 0x04002196 RID: 8598
				Mentor_Guitar = 361U,
				// Token: 0x04002197 RID: 8599
				Mentor_Mural = 55398U,
				// Token: 0x04002198 RID: 8600
				Mentor_Piano = 362U,
				// Token: 0x04002199 RID: 8601
				Mentor_Repair = 765U,
				// Token: 0x0400219A RID: 8602
				Mentor_Treadmill = 355U,
				// Token: 0x0400219B RID: 8603
				Mentor_Upgrade = 766U,
				// Token: 0x0400219C RID: 8604
				Mentor_Violin = 363U,
				// Token: 0x0400219D RID: 8605
				Mentor_WoodworkingTable = 764U,
				// Token: 0x0400219E RID: 8606
				Mentor_WorkoutMachine = 356U,
				// Token: 0x0400219F RID: 8607
				MicroscopeSlide_Crystal = 344U,
				// Token: 0x040021A0 RID: 8608
				MicroscopeSlide_Fossil = 343U,
				// Token: 0x040021A1 RID: 8609
				MicroscopeSlide_Plant = 345U,
				// Token: 0x040021A2 RID: 8610
				Mood_Angry = 317U,
				// Token: 0x040021A3 RID: 8611
				Mood_Bored,
				// Token: 0x040021A4 RID: 8612
				Mood_Confident,
				// Token: 0x040021A5 RID: 8613
				Mood_Cranky,
				// Token: 0x040021A6 RID: 8614
				Mood_Depressed,
				// Token: 0x040021A7 RID: 8615
				Mood_Drunk,
				// Token: 0x040021A8 RID: 8616
				Mood_Embarrassed,
				// Token: 0x040021A9 RID: 8617
				Mood_Energized,
				// Token: 0x040021AA RID: 8618
				Mood_Fine = 331U,
				// Token: 0x040021AB RID: 8619
				Mood_Flirty = 325U,
				// Token: 0x040021AC RID: 8620
				Mood_Focused,
				// Token: 0x040021AD RID: 8621
				Mood_Happy = 328U,
				// Token: 0x040021AE RID: 8622
				Mood_Imaginative,
				// Token: 0x040021AF RID: 8623
				Mood_Optimism = 64U,
				// Token: 0x040021B0 RID: 8624
				Mood_Playful = 332U,
				// Token: 0x040021B1 RID: 8625
				Mood_Sad,
				// Token: 0x040021B2 RID: 8626
				Mood_Sloshed,
				// Token: 0x040021B3 RID: 8627
				Mood_Tense = 327U,
				// Token: 0x040021B4 RID: 8628
				Mood_Uncomfortable = 330U,
				// Token: 0x040021B5 RID: 8629
				None = 0U,
				// Token: 0x040021B6 RID: 8630
				NoneEP03_PLEASE_REUSE_ME = 24592U,
				// Token: 0x040021B7 RID: 8631
				NoseColor_Black = 1917U,
				// Token: 0x040021B8 RID: 8632
				NoseColor_BlackPink = 1922U,
				// Token: 0x040021B9 RID: 8633
				NoseColor_Brown = 1918U,
				// Token: 0x040021BA RID: 8634
				NoseColor_BrownPink = 1923U,
				// Token: 0x040021BB RID: 8635
				NoseColor_Liver = 1919U,
				// Token: 0x040021BC RID: 8636
				NoseColor_Pink,
				// Token: 0x040021BD RID: 8637
				NoseColor_Tan,
				// Token: 0x040021BE RID: 8638
				NudePart_Always = 1540U,
				// Token: 0x040021BF RID: 8639
				NudePart_MaleWithBreast,
				// Token: 0x040021C0 RID: 8640
				Object_Bar = 349U,
				// Token: 0x040021C1 RID: 8641
				Object_Mural = 55363U,
				// Token: 0x040021C2 RID: 8642
				Occult_Alien = 12319U,
				// Token: 0x040021C3 RID: 8643
				Occult_Human = 1310U,
				// Token: 0x040021C4 RID: 8644
				Occult_Mermaid = 2208U,
				// Token: 0x040021C5 RID: 8645
				Occult_Vampire = 1677U,
				// Token: 0x040021C6 RID: 8646
				Occult_Witch = 2279U,
				// Token: 0x040021C7 RID: 8647
				Outfit_ArtCritic_Level10 = 55393U,
				// Token: 0x040021C8 RID: 8648
				Outfit_ArtsCritic = 55301U,
				// Token: 0x040021C9 RID: 8649
				Outfit_FoodCritic = 55300U,
				// Token: 0x040021CA RID: 8650
				Outfit_FoodCritic_Level10 = 55394U,
				// Token: 0x040021CB RID: 8651
				OutfitCategory_Athletic = 80U,
				// Token: 0x040021CC RID: 8652
				OutfitCategory_Bathing = 82U,
				// Token: 0x040021CD RID: 8653
				OutfitCategory_Batuu = 2470U,
				// Token: 0x040021CE RID: 8654
				OutfitCategory_Career = 263U,
				// Token: 0x040021CF RID: 8655
				OutfitCategory_ColdWeather = 2054U,
				// Token: 0x040021D0 RID: 8656
				OutfitCategory_Everyday = 77U,
				// Token: 0x040021D1 RID: 8657
				OutfitCategory_Formal,
				// Token: 0x040021D2 RID: 8658
				OutfitCategory_HotWeather = 2053U,
				// Token: 0x040021D3 RID: 8659
				OutfitCategory_Party = 83U,
				// Token: 0x040021D4 RID: 8660
				OutfitCategory_RetailUniforms = 1371U,
				// Token: 0x040021D5 RID: 8661
				OutfitCategory_Situation = 335U,
				// Token: 0x040021D6 RID: 8662
				OutfitCategory_Sleep = 81U,
				// Token: 0x040021D7 RID: 8663
				OutfitCategory_Swimwear = 1229U,
				// Token: 0x040021D8 RID: 8664
				OutfitCategory_Unused = 79U,
				// Token: 0x040021D9 RID: 8665
				OutfitCategory_Witch = 8210U,
				// Token: 0x040021DA RID: 8666
				Pattern_Animal = 590U,
				// Token: 0x040021DB RID: 8667
				Pattern_Bicolor = 1905U,
				// Token: 0x040021DC RID: 8668
				Pattern_Brindle = 1902U,
				// Token: 0x040021DD RID: 8669
				Pattern_Calico = 1912U,
				// Token: 0x040021DE RID: 8670
				Pattern_Harlequin = 1909U,
				// Token: 0x040021DF RID: 8671
				Pattern_Merle = 1907U,
				// Token: 0x040021E0 RID: 8672
				Pattern_Sable = 1910U,
				// Token: 0x040021E1 RID: 8673
				Pattern_Saddle = 1903U,
				// Token: 0x040021E2 RID: 8674
				Pattern_Speckled = 1913U,
				// Token: 0x040021E3 RID: 8675
				Pattern_Spotted = 1900U,
				// Token: 0x040021E4 RID: 8676
				Pattern_Striped,
				// Token: 0x040021E5 RID: 8677
				Pattern_Swirled = 1904U,
				// Token: 0x040021E6 RID: 8678
				Pattern_Tabby = 1899U,
				// Token: 0x040021E7 RID: 8679
				Pattern_Tricolor = 1906U,
				// Token: 0x040021E8 RID: 8680
				Pattern_Tuxedo = 1908U,
				// Token: 0x040021E9 RID: 8681
				Persona_Boho = 130U,
				// Token: 0x040021EA RID: 8682
				Persona_Fashionista = 129U,
				// Token: 0x040021EB RID: 8683
				Persona_Mom = 148U,
				// Token: 0x040021EC RID: 8684
				Persona_Rocker = 128U,
				// Token: 0x040021ED RID: 8685
				PortalDisallowance_Mascot = 69745U,
				// Token: 0x040021EE RID: 8686
				PortalDisallowance_Ungreeted = 668U,
				// Token: 0x040021EF RID: 8687
				Posture_Lifestyles_RelaxedSit = 69695U,
				// Token: 0x040021F0 RID: 8688
				Recipe_CandleMakingStation_Candle = 67604U,
				// Token: 0x040021F1 RID: 8689
				Recipe_Category_CakePie = 1536U,
				// Token: 0x040021F2 RID: 8690
				Recipe_Category_Chocolate,
				// Token: 0x040021F3 RID: 8691
				Recipe_Category_Cold = 1533U,
				// Token: 0x040021F4 RID: 8692
				Recipe_Category_Drinks = 1518U,
				// Token: 0x040021F5 RID: 8693
				Recipe_Category_Fizzy = 1531U,
				// Token: 0x040021F6 RID: 8694
				Recipe_Category_Fruit,
				// Token: 0x040021F7 RID: 8695
				Recipe_Category_Grains = 1515U,
				// Token: 0x040021F8 RID: 8696
				Recipe_Category_Hot = 1534U,
				// Token: 0x040021F9 RID: 8697
				Recipe_Category_Meat = 1513U,
				// Token: 0x040021FA RID: 8698
				Recipe_Category_Misc = 1517U,
				// Token: 0x040021FB RID: 8699
				Recipe_Category_Nectar = 1535U,
				// Token: 0x040021FC RID: 8700
				Recipe_Category_Seafood = 1519U,
				// Token: 0x040021FD RID: 8701
				Recipe_Category_Sweets = 1516U,
				// Token: 0x040021FE RID: 8702
				Recipe_Category_Water = 1522U,
				// Token: 0x040021FF RID: 8703
				Recipe_Category_Vegetarian = 1514U,
				// Token: 0x04002200 RID: 8704
				Recipe_Cauldron_Potion = 49154U,
				// Token: 0x04002201 RID: 8705
				Recipe_ChefsChoice_ChildFriendly = 1521U,
				// Token: 0x04002202 RID: 8706
				Recipe_ChildRestricted = 1523U,
				// Token: 0x04002203 RID: 8707
				Recipe_Course_Appetizer = 1507U,
				// Token: 0x04002204 RID: 8708
				Recipe_Course_Dessert = 1509U,
				// Token: 0x04002205 RID: 8709
				Recipe_Course_Drink = 1524U,
				// Token: 0x04002206 RID: 8710
				Recipe_Course_Main = 1508U,
				// Token: 0x04002207 RID: 8711
				Recipe_FlowerArrangement = 59472U,
				// Token: 0x04002208 RID: 8712
				Recipe_Meal_Breakfast = 1510U,
				// Token: 0x04002209 RID: 8713
				Recipe_Meal_Dinner = 1512U,
				// Token: 0x0400220A RID: 8714
				Recipe_Meal_Lunch = 1511U,
				// Token: 0x0400220B RID: 8715
				Recipe_Plopsy_Browser = 83985U,
				// Token: 0x0400220C RID: 8716
				Recipe_Type_Drink = 1506U,
				// Token: 0x0400220D RID: 8717
				Recipe_Type_Drink_Prank = 2423U,
				// Token: 0x0400220E RID: 8718
				Recipe_Type_Food = 1505U,
				// Token: 0x0400220F RID: 8719
				Recipe_Type_PetDrink = 57425U,
				// Token: 0x04002210 RID: 8720
				Recipe_Type_PetFood = 57424U,
				// Token: 0x04002211 RID: 8721
				Region_ActiveCareer = 12437U,
				// Token: 0x04002212 RID: 8722
				Region_Camping = 1245U,
				// Token: 0x04002213 RID: 8723
				Region_Jungle = 45059U,
				// Token: 0x04002214 RID: 8724
				Region_Residential = 1244U,
				// Token: 0x04002215 RID: 8725
				Region_Retail = 12374U,
				// Token: 0x04002216 RID: 8726
				RESERVED_TempBetaFixDoNotUse = 138U,
				// Token: 0x04002217 RID: 8727
				RESERVED_TempBetaFixDoNotUse2,
				// Token: 0x04002218 RID: 8728
				Reserved_TempBetaFixDoNotUse3 = 142U,
				// Token: 0x04002219 RID: 8729
				RESERVED_TempBetaFixDoNotUse4,
				// Token: 0x0400221A RID: 8730
				RESERVED_TempBetaFixDoNotUse5,
				// Token: 0x0400221B RID: 8731
				RESERVED_TempBetaFixDoNotUse6 = 147U,
				// Token: 0x0400221C RID: 8732
				RESERVED_TempBetaFixDoNotUse7 = 281U,
				// Token: 0x0400221D RID: 8733
				RESERVED_TempBetaFixDoNotUse8 = 284U,
				// Token: 0x0400221E RID: 8734
				RESERVED_TempBetaFixDoNotUse9 = 290U,
				// Token: 0x0400221F RID: 8735
				Reward_CASPart = 767U,
				// Token: 0x04002220 RID: 8736
				Role_BakeOneCake = 2277U,
				// Token: 0x04002221 RID: 8737
				Role_Bartender = 277U,
				// Token: 0x04002222 RID: 8738
				Role_Business_Customer = 1924U,
				// Token: 0x04002223 RID: 8739
				Role_Career = 467U,
				// Token: 0x04002224 RID: 8740
				Role_Caterer = 278U,
				// Token: 0x04002225 RID: 8741
				Role_CollegeOrganization_Event = 65583U,
				// Token: 0x04002226 RID: 8742
				Role_Coworker = 12292U,
				// Token: 0x04002227 RID: 8743
				Role_Customer = 2142U,
				// Token: 0x04002228 RID: 8744
				Role_Date = 1439U,
				// Token: 0x04002229 RID: 8745
				Role_Detective = 12294U,
				// Token: 0x0400222A RID: 8746
				Role_Doctor,
				// Token: 0x0400222B RID: 8747
				Role_Entertainer = 650U,
				// Token: 0x0400222C RID: 8748
				Role_FestivalArtsCrafts = 55317U,
				// Token: 0x0400222D RID: 8749
				Role_FestivalBlossom = 55312U,
				// Token: 0x0400222E RID: 8750
				Role_FestivalFleaMarket = 55318U,
				// Token: 0x0400222F RID: 8751
				Role_FestivalFood = 55315U,
				// Token: 0x04002230 RID: 8752
				Role_FestivalLamp = 55313U,
				// Token: 0x04002231 RID: 8753
				Role_FestivalLogic,
				// Token: 0x04002232 RID: 8754
				Role_FestivalMusic = 55316U,
				// Token: 0x04002233 RID: 8755
				Role_FortuneTeller = 8199U,
				// Token: 0x04002234 RID: 8756
				Role_Guest = 266U,
				// Token: 0x04002235 RID: 8757
				Role_Host,
				// Token: 0x04002236 RID: 8758
				Role_HostAtStation = 26635U,
				// Token: 0x04002237 RID: 8759
				Role_Leave = 418U,
				// Token: 0x04002238 RID: 8760
				Role_Maid = 279U,
				// Token: 0x04002239 RID: 8761
				Role_Restaurant_PostPlaceOrder = 2149U,
				// Token: 0x0400223A RID: 8762
				Role_RestaurantDiner = 2147U,
				// Token: 0x0400223B RID: 8763
				Role_RestaurantEat,
				// Token: 0x0400223C RID: 8764
				Role_RestaurantStaff = 26633U,
				// Token: 0x0400223D RID: 8765
				Role_RoommateNPC = 65541U,
				// Token: 0x0400223E RID: 8766
				Role_Scientist = 12293U,
				// Token: 0x0400223F RID: 8767
				Role_Service = 416U,
				// Token: 0x04002240 RID: 8768
				Role_SpaStaff_Bored = 18441U,
				// Token: 0x04002241 RID: 8769
				Role_Vet_Patient = 57400U,
				// Token: 0x04002242 RID: 8770
				Role_VIPRope_Allowed = 2143U,
				// Token: 0x04002243 RID: 8771
				Role_Yoga_PreClass = 18463U,
				// Token: 0x04002244 RID: 8772
				Role_YogaClass_PostClass = 18435U,
				// Token: 0x04002245 RID: 8773
				RoleState_EP01_Patient_Treated = 12434U,
				// Token: 0x04002246 RID: 8774
				Royalty_Apps = 908U,
				// Token: 0x04002247 RID: 8775
				Royalty_Books,
				// Token: 0x04002248 RID: 8776
				Royalty_Games,
				// Token: 0x04002249 RID: 8777
				Royalty_Lyrics = 1629U,
				// Token: 0x0400224A RID: 8778
				Royalty_Paintings = 911U,
				// Token: 0x0400224B RID: 8779
				Royalty_Songs,
				// Token: 0x0400224C RID: 8780
				Shoes_Booties = 383U,
				// Token: 0x0400224D RID: 8781
				Shoes_Boots,
				// Token: 0x0400224E RID: 8782
				Shoes_Flats,
				// Token: 0x0400224F RID: 8783
				Shoes_Heels,
				// Token: 0x04002250 RID: 8784
				Shoes_LaceUpAdult,
				// Token: 0x04002251 RID: 8785
				Shoes_LaceUpChildren,
				// Token: 0x04002252 RID: 8786
				Shoes_Loafers,
				// Token: 0x04002253 RID: 8787
				Shoes_Sandals,
				// Token: 0x04002254 RID: 8788
				Shoes_Slippers,
				// Token: 0x04002255 RID: 8789
				Shoes_Sneakers,
				// Token: 0x04002256 RID: 8790
				Shoes_Wedges,
				// Token: 0x04002257 RID: 8791
				Sickness_CheckUp = 57407U,
				// Token: 0x04002258 RID: 8792
				Sickness_CuredBy_ExamTable = 57451U,
				// Token: 0x04002259 RID: 8793
				Sickness_CuredBy_SurgeryStation,
				// Token: 0x0400225A RID: 8794
				Sickness_Illness = 57408U,
				// Token: 0x0400225B RID: 8795
				Sickness_PetExam = 57403U,
				// Token: 0x0400225C RID: 8796
				Situation_ActiveCareer = 12358U,
				// Token: 0x0400225D RID: 8797
				Situation_ActiveCareer_Scientist = 12427U,
				// Token: 0x0400225E RID: 8798
				situation_ActorCareer_Commercial = 61553U,
				// Token: 0x0400225F RID: 8799
				situation_ActorCareer_Movie = 61556U,
				// Token: 0x04002260 RID: 8800
				Situation_ActorCareer_PrepTask_Acting = 61615U,
				// Token: 0x04002261 RID: 8801
				Situation_ActorCareer_PrepTask_Charisma = 61458U,
				// Token: 0x04002262 RID: 8802
				Situation_ActorCareer_PrepTask_Comedy = 61456U,
				// Token: 0x04002263 RID: 8803
				Situation_ActorCareer_PrepTask_CoStarRel = 61454U,
				// Token: 0x04002264 RID: 8804
				Situation_ActorCareer_PrepTask_DirectoRel,
				// Token: 0x04002265 RID: 8805
				Situation_ActorCareer_PrepTask_Fitness = 61459U,
				// Token: 0x04002266 RID: 8806
				Situation_ActorCareer_PrepTask_Guitar,
				// Token: 0x04002267 RID: 8807
				Situation_ActorCareer_PrepTask_Handiness = 61457U,
				// Token: 0x04002268 RID: 8808
				Situation_ActorCareer_PrepTask_Practice_Action = 61619U,
				// Token: 0x04002269 RID: 8809
				Situation_ActorCareer_PrepTask_Practice_Dramatic,
				// Token: 0x0400226A RID: 8810
				Situation_ActorCareer_PrepTask_Practice_Romantic,
				// Token: 0x0400226B RID: 8811
				Situation_ActorCareer_PrepTask_Research_Flirty = 61616U,
				// Token: 0x0400226C RID: 8812
				Situation_ActorCareer_PrepTask_Research_Funny,
				// Token: 0x0400226D RID: 8813
				Situation_ActorCareer_PrepTask_Research_Mean,
				// Token: 0x0400226E RID: 8814
				situation_ActorCareer_TVHigh = 61555U,
				// Token: 0x0400226F RID: 8815
				situation_ActorCareer_TVLow = 61554U,
				// Token: 0x04002270 RID: 8816
				Situation_ApartmentNeighbor_AnswerDoorComplaint = 55304U,
				// Token: 0x04002271 RID: 8817
				Situation_ApartmentNeighbor_LoudNoises = 55303U,
				// Token: 0x04002272 RID: 8818
				Situation_BasketBaller_A = 55381U,
				// Token: 0x04002273 RID: 8819
				Situation_BasketBaller_B,
				// Token: 0x04002274 RID: 8820
				Situation_Batuu_Arrest = 51231U,
				// Token: 0x04002275 RID: 8821
				Situation_Batuu_FR13_Mission = 51278U,
				// Token: 0x04002276 RID: 8822
				Situation_Batuu_FS2_Mission = 51263U,
				// Token: 0x04002277 RID: 8823
				Situation_Batuu_FS3_Mission,
				// Token: 0x04002278 RID: 8824
				Situation_Batuu_FS4_Criminal = 51255U,
				// Token: 0x04002279 RID: 8825
				Situation_Batuu_FS6_Mission = 51262U,
				// Token: 0x0400227A RID: 8826
				Situation_Batuu_FS7_Mission = 51261U,
				// Token: 0x0400227B RID: 8827
				Situation_Batuu_Inspection = 51232U,
				// Token: 0x0400227C RID: 8828
				Situation_Batuu_Mission_Lightsaber = 51241U,
				// Token: 0x0400227D RID: 8829
				Situation_Batuu_OgasCelebration_Blacklisted = 51243U,
				// Token: 0x0400227E RID: 8830
				Situation_Batuu_RS2_Mission = 51272U,
				// Token: 0x0400227F RID: 8831
				Situation_Batuu_RS4_Mission = 51269U,
				// Token: 0x04002280 RID: 8832
				Situation_Batuu_RS6_Mission = 51273U,
				// Token: 0x04002281 RID: 8833
				Situation_Batuu_RS7_Mission,
				// Token: 0x04002282 RID: 8834
				Situation_Batuu_Sabacc_Opponent_1 = 51258U,
				// Token: 0x04002283 RID: 8835
				Situation_Batuu_Sabacc_Opponent_2,
				// Token: 0x04002284 RID: 8836
				Situation_Batuu_Sabacc_Opponent_3,
				// Token: 0x04002285 RID: 8837
				Situation_Batuu_SR4_Mission = 51275U,
				// Token: 0x04002286 RID: 8838
				Situation_Batuu_SR9_Mission = 51265U,
				// Token: 0x04002287 RID: 8839
				Situation_Batuu_SS8_Mission = 51276U,
				// Token: 0x04002288 RID: 8840
				Situation_Batuu_SS9_Mission,
				// Token: 0x04002289 RID: 8841
				Situation_Bear = 10247U,
				// Token: 0x0400228A RID: 8842
				Situation_Bonfire = 24586U,
				// Token: 0x0400228B RID: 8843
				Situation_Bowling_Group = 38919U,
				// Token: 0x0400228C RID: 8844
				Situation_Bowling_Group_2,
				// Token: 0x0400228D RID: 8845
				Situation_Bowling_Group_3,
				// Token: 0x0400228E RID: 8846
				Situation_Bowling_Group_4,
				// Token: 0x0400228F RID: 8847
				Situation_Busker = 55308U,
				// Token: 0x04002290 RID: 8848
				Situation_Butler = 36867U,
				// Token: 0x04002291 RID: 8849
				Situation_CelebrityFan = 61476U,
				// Token: 0x04002292 RID: 8850
				Situation_CityInvites = 55380U,
				// Token: 0x04002293 RID: 8851
				Situation_CityRepair = 55355U,
				// Token: 0x04002294 RID: 8852
				Situation_Clown = 955U,
				// Token: 0x04002295 RID: 8853
				Situation_ComplaintNoise = 55425U,
				// Token: 0x04002296 RID: 8854
				Situation_CookingInteractions = 1017U,
				// Token: 0x04002297 RID: 8855
				Situation_Criminal = 956U,
				// Token: 0x04002298 RID: 8856
				Situation_DanceTogether = 24606U,
				// Token: 0x04002299 RID: 8857
				Situation_Decorator_Career_Hide_Clients = 53250U,
				// Token: 0x0400229A RID: 8858
				Situation_DJPerformance = 24582U,
				// Token: 0x0400229B RID: 8859
				Situation_Event_NPC = 1501U,
				// Token: 0x0400229C RID: 8860
				Situation_Festival = 55401U,
				// Token: 0x0400229D RID: 8861
				Situation_Festival_Blossom_RomanticCouple = 55390U,
				// Token: 0x0400229E RID: 8862
				Situation_Festival_Logic_RocketShipWoohooers = 55389U,
				// Token: 0x0400229F RID: 8863
				Situation_Firefighter = 2377U,
				// Token: 0x040022A0 RID: 8864
				Situation_FlowerBunny = 59476U,
				// Token: 0x040022A1 RID: 8865
				Situation_ForestGhost = 10259U,
				// Token: 0x040022A2 RID: 8866
				Situation_ForestRanger = 10264U,
				// Token: 0x040022A3 RID: 8867
				Situation_Gardener = 2152U,
				// Token: 0x040022A4 RID: 8868
				Situation_Gnome_Berserk = 59455U,
				// Token: 0x040022A5 RID: 8869
				Situation_Gnome_Normal = 59454U,
				// Token: 0x040022A6 RID: 8870
				Situation_GP07_Walkby_Conspiracist_01 = 47158U,
				// Token: 0x040022A7 RID: 8871
				Situation_GP07_Walkby_Conspiracist_02,
				// Token: 0x040022A8 RID: 8872
				Situation_GP07_Walkby_Conspiracist_03,
				// Token: 0x040022A9 RID: 8873
				Situation_GP07_Walkby_FBI_01,
				// Token: 0x040022AA RID: 8874
				Situation_GP07_Walkby_FBI_02,
				// Token: 0x040022AB RID: 8875
				Situation_GP07_Walkby_FBI_03,
				// Token: 0x040022AC RID: 8876
				Situation_GP07_Walkby_Military_01 = 47150U,
				// Token: 0x040022AD RID: 8877
				Situation_GP07_Walkby_Military_02,
				// Token: 0x040022AE RID: 8878
				Situation_GP07_Walkby_Military_03,
				// Token: 0x040022AF RID: 8879
				Situation_GP07_Walkby_Military_04,
				// Token: 0x040022B0 RID: 8880
				Situation_GP07_Walkby_Scientist_01,
				// Token: 0x040022B1 RID: 8881
				Situation_GP07_Walkby_Scientist_02,
				// Token: 0x040022B2 RID: 8882
				Situation_GP07_Walkby_Scientist_03,
				// Token: 0x040022B3 RID: 8883
				Situation_GP07_Walkby_Scientist_04,
				// Token: 0x040022B4 RID: 8884
				Situation_GrillGroup = 1461U,
				// Token: 0x040022B5 RID: 8885
				Situation_HikingTrail = 69746U,
				// Token: 0x040022B6 RID: 8886
				Situation_HiredNanny = 1550U,
				// Token: 0x040022B7 RID: 8887
				Situation_Holiday = 59460U,
				// Token: 0x040022B8 RID: 8888
				Situation_HomeChef = 26642U,
				// Token: 0x040022B9 RID: 8889
				Situation_HotDog = 958U,
				// Token: 0x040022BA RID: 8890
				Situation_InteriorDecorator_Gig_Dependent = 53252U,
				// Token: 0x040022BB RID: 8891
				Situation_IntriguedNoise = 55426U,
				// Token: 0x040022BC RID: 8892
				Situation_IntriguedSmell,
				// Token: 0x040022BD RID: 8893
				Situation_IslandSpirits = 63496U,
				// Token: 0x040022BE RID: 8894
				Situation_LivesOnStreet_A = 55435U,
				// Token: 0x040022BF RID: 8895
				Situation_LivesOnStreet_B,
				// Token: 0x040022C0 RID: 8896
				Situation_LivesOnStreet_C,
				// Token: 0x040022C1 RID: 8897
				Situation_LivesOnStreet_D,
				// Token: 0x040022C2 RID: 8898
				Situation_Maid = 957U,
				// Token: 0x040022C3 RID: 8899
				Situation_Mailman = 1343U,
				// Token: 0x040022C4 RID: 8900
				Situation_MarketStall_Vendor = 1949U,
				// Token: 0x040022C5 RID: 8901
				Situation_MasterFisherman = 889U,
				// Token: 0x040022C6 RID: 8902
				Situation_MasterGardener,
				// Token: 0x040022C7 RID: 8903
				Situation_MuralPainter = 55383U,
				// Token: 0x040022C8 RID: 8904
				Situation_NightTimeVisit = 1679U,
				// Token: 0x040022C9 RID: 8905
				Situation_PetObstacleCourse = 57427U,
				// Token: 0x040022CA RID: 8906
				Situation_PicnicTable = 1460U,
				// Token: 0x040022CB RID: 8907
				Situation_Pizza = 960U,
				// Token: 0x040022CC RID: 8908
				Situation_PlayerFacing_CanHost = 1643U,
				// Token: 0x040022CD RID: 8909
				Situation_PlayerVisiting_NPC = 1493U,
				// Token: 0x040022CE RID: 8910
				Situation_Possessed = 47124U,
				// Token: 0x040022CF RID: 8911
				Situation_PromoNight = 24594U,
				// Token: 0x040022D0 RID: 8912
				Situation_Reaper = 959U,
				// Token: 0x040022D1 RID: 8913
				Situation_Repairman = 2153U,
				// Token: 0x040022D2 RID: 8914
				Situation_RestaurantDining = 2146U,
				// Token: 0x040022D3 RID: 8915
				Situation_Retail_Customer = 12323U,
				// Token: 0x040022D4 RID: 8916
				Situation_Retail_Employee,
				// Token: 0x040022D5 RID: 8917
				Situation_Ring_Doorbell = 684U,
				// Token: 0x040022D6 RID: 8918
				Situation_RoommateNPC_Potential = 65572U,
				// Token: 0x040022D7 RID: 8919
				Situation_SecretSociety = 65570U,
				// Token: 0x040022D8 RID: 8920
				Situation_SpookyParty = 22541U,
				// Token: 0x040022D9 RID: 8921
				Situation_Squad = 61634U,
				// Token: 0x040022DA RID: 8922
				Situation_Sun_Ray = 67647U,
				// Token: 0x040022DB RID: 8923
				Situation_TragicClown = 1504U,
				// Token: 0x040022DC RID: 8924
				Situation_Tutorial_FTUE = 2167U,
				// Token: 0x040022DD RID: 8925
				Situation_UmbrellaUser = 2119U,
				// Token: 0x040022DE RID: 8926
				Situation_UniversityHousingKickoutBlocker = 65571U,
				// Token: 0x040022DF RID: 8927
				Situation_UniversityRivals_Prank = 65606U,
				// Token: 0x040022E0 RID: 8928
				Situation_WaitInLineTogether = 2496U,
				// Token: 0x040022E1 RID: 8929
				Situation_Walkby_FO_Officer_Spy = 51226U,
				// Token: 0x040022E2 RID: 8930
				Situation_Weather_Rain_Heavy = 2078U,
				// Token: 0x040022E3 RID: 8931
				Situation_Weather_Rain_Light,
				// Token: 0x040022E4 RID: 8932
				Situation_Weather_Rain_Storm = 2077U,
				// Token: 0x040022E5 RID: 8933
				Situation_Weather_Snow_Heavy = 2080U,
				// Token: 0x040022E6 RID: 8934
				Situation_Weather_Snow_Storm,
				// Token: 0x040022E7 RID: 8935
				Situation_Weirdo = 55309U,
				// Token: 0x040022E8 RID: 8936
				Situation_WelcomeWagon = 1457U,
				// Token: 0x040022E9 RID: 8937
				Situation_Venue_Karaoke_Dueters = 55391U,
				// Token: 0x040022EA RID: 8938
				Situation_Vet_PlayerPetOwner = 2498U,
				// Token: 0x040022EB RID: 8939
				Situation_Vet_SickPet,
				// Token: 0x040022EC RID: 8940
				Situation_VIPRope_Bouncer = 61613U,
				// Token: 0x040022ED RID: 8941
				Situation_VisitorNPC_AngrySim = 67606U,
				// Token: 0x040022EE RID: 8942
				Situation_VisitorNPCs = 2282U,
				// Token: 0x040022EF RID: 8943
				Situation_YogaClass = 18462U,
				// Token: 0x040022F0 RID: 8944
				Skill_All = 448U,
				// Token: 0x040022F1 RID: 8945
				Skill_All_Visible = 2097U,
				// Token: 0x040022F2 RID: 8946
				Skill_Archaeology = 45094U,
				// Token: 0x040022F3 RID: 8947
				Skill_Athletic = 86U,
				// Token: 0x040022F4 RID: 8948
				Skill_Bartending = 137U,
				// Token: 0x040022F5 RID: 8949
				Skill_Charisma = 676U,
				// Token: 0x040022F6 RID: 8950
				Skill_Child = 641U,
				// Token: 0x040022F7 RID: 8951
				Skill_ClimbingSkiingSnowboarding = 69698U,
				// Token: 0x040022F8 RID: 8952
				Skill_ComedyOrMischief = 1576U,
				// Token: 0x040022F9 RID: 8953
				Skill_Cooking = 87U,
				// Token: 0x040022FA RID: 8954
				Skill_Creative = 336U,
				// Token: 0x040022FB RID: 8955
				Skill_DogTraining = 57367U,
				// Token: 0x040022FC RID: 8956
				Skill_FitnessOrProgramming = 652U,
				// Token: 0x040022FD RID: 8957
				Skill_FlowerArranging = 59451U,
				// Token: 0x040022FE RID: 8958
				Skill_Gardening = 1605U,
				// Token: 0x040022FF RID: 8959
				Skill_GuitarorComedy = 935U,
				// Token: 0x04002300 RID: 8960
				Skill_Handiness = 1368U,
				// Token: 0x04002301 RID: 8961
				Skill_JuiceFizzing = 67620U,
				// Token: 0x04002302 RID: 8962
				Skill_Knitting = 83969U,
				// Token: 0x04002303 RID: 8963
				Skill_LocalCulture = 45070U,
				// Token: 0x04002304 RID: 8964
				Skill_Logic = 677U,
				// Token: 0x04002305 RID: 8965
				Skill_Mental = 337U,
				// Token: 0x04002306 RID: 8966
				Skill_Musical = 445U,
				// Token: 0x04002307 RID: 8967
				Skill_MusicOrComedy = 55305U,
				// Token: 0x04002308 RID: 8968
				Skill_Painting = 1607U,
				// Token: 0x04002309 RID: 8969
				Skill_Performance = 1630U,
				// Token: 0x0400230A RID: 8970
				Skill_Photography = 1940U,
				// Token: 0x0400230B RID: 8971
				Skill_Photography_BG = 1609U,
				// Token: 0x0400230C RID: 8972
				Skill_Physical = 338U,
				// Token: 0x0400230D RID: 8973
				Skill_PipeOrgan = 40969U,
				// Token: 0x0400230E RID: 8974
				Skill_Programming = 1606U,
				// Token: 0x0400230F RID: 8975
				Skill_Psychic = 8194U,
				// Token: 0x04002310 RID: 8976
				Skill_RockClimbing = 69697U,
				// Token: 0x04002311 RID: 8977
				Skill_RocketScience = 678U,
				// Token: 0x04002312 RID: 8978
				Skill_SchoolTask = 1653U,
				// Token: 0x04002313 RID: 8979
				Skill_Singing = 1633U,
				// Token: 0x04002314 RID: 8980
				Skill_Skating = 59393U,
				// Token: 0x04002315 RID: 8981
				Skill_Skiing = 69637U,
				// Token: 0x04002316 RID: 8982
				Skill_Snowboarding = 69696U,
				// Token: 0x04002317 RID: 8983
				Skill_Social = 339U,
				// Token: 0x04002318 RID: 8984
				Skill_Toddler = 1655U,
				// Token: 0x04002319 RID: 8985
				Skill_Wellness = 18466U,
				// Token: 0x0400231A RID: 8986
				Skill_Wellness_BG = 1608U,
				// Token: 0x0400231B RID: 8987
				Skill_VideoGaming = 675U,
				// Token: 0x0400231C RID: 8988
				Skill_ViolinorGuitar = 936U,
				// Token: 0x0400231D RID: 8989
				Skill_Writing = 679U,
				// Token: 0x0400231E RID: 8990
				SkinHue_Blue = 12382U,
				// Token: 0x0400231F RID: 8991
				SkinHue_BlueSkin = 1449U,
				// Token: 0x04002320 RID: 8992
				SkinHue_Green = 12389U,
				// Token: 0x04002321 RID: 8993
				SkinHue_GreenSkin = 1450U,
				// Token: 0x04002322 RID: 8994
				SkinHue_Olive = 763U,
				// Token: 0x04002323 RID: 8995
				SkinHue_Purple = 12390U,
				// Token: 0x04002324 RID: 8996
				SkinHue_Red = 761U,
				// Token: 0x04002325 RID: 8997
				SkinHue_RedSkin = 1625U,
				// Token: 0x04002326 RID: 8998
				SkinHue_Yellow = 762U,
				// Token: 0x04002327 RID: 8999
				SkintoneBlend_Yes = 1458U,
				// Token: 0x04002328 RID: 9000
				SkintoneType_Fantasy = 12317U,
				// Token: 0x04002329 RID: 9001
				SkintoneType_Natural = 12316U,
				// Token: 0x0400232A RID: 9002
				SkintoneType_Sickness_1 = 12320U,
				// Token: 0x0400232B RID: 9003
				SkintoneType_Sickness_2,
				// Token: 0x0400232C RID: 9004
				SkintoneType_Sickness_3,
				// Token: 0x0400232D RID: 9005
				SkintoneType_Sickness_Green = 12325U,
				// Token: 0x0400232E RID: 9006
				Social_BlackAndWhite = 686U,
				// Token: 0x0400232F RID: 9007
				Social_CostumeParty,
				// Token: 0x04002330 RID: 9008
				Social_Flirty = 340U,
				// Token: 0x04002331 RID: 9009
				Social_WeenieRoast = 10244U,
				// Token: 0x04002332 RID: 9010
				Social_Woohoo = 364U,
				// Token: 0x04002333 RID: 9011
				SP03_PLEASE_REUSE_ME_I_WAS_BLANK_ON_ACCIDENT = 20487U,
				// Token: 0x04002334 RID: 9012
				SP03_PLEASE_REUSE_ME_I_WAS_BLANK_ON_ACCIDENT_2,
				// Token: 0x04002335 RID: 9013
				Spawn_Arrival = 397U,
				// Token: 0x04002336 RID: 9014
				Spawn_ArtsPark = 65622U,
				// Token: 0x04002337 RID: 9015
				Spawn_ArtsQuad = 65619U,
				// Token: 0x04002338 RID: 9016
				Spawn_ArtsUniversityShell = 65546U,
				// Token: 0x04002339 RID: 9017
				Spawn_ArtsUniversityShell_Shell1 = 65556U,
				// Token: 0x0400233A RID: 9018
				Spawn_ArtsUniversityShell_Shell2,
				// Token: 0x0400233B RID: 9019
				Spawn_BattleHelper = 47133U,
				// Token: 0x0400233C RID: 9020
				Spawn_Batuu_Dwelling = 51216U,
				// Token: 0x0400233D RID: 9021
				Spawn_Batuu_FO_Patrol = 51227U,
				// Token: 0x0400233E RID: 9022
				Spawn_Batuu_LTAgnon = 51218U,
				// Token: 0x0400233F RID: 9023
				Spawn_Batuu_RES_Patrol_1 = 51228U,
				// Token: 0x04002340 RID: 9024
				Spawn_Batuu_RES_Patrol_2,
				// Token: 0x04002341 RID: 9025
				Spawn_Batuu_ViMoradi = 51217U,
				// Token: 0x04002342 RID: 9026
				Spawn_Fireplace = 2057U,
				// Token: 0x04002343 RID: 9027
				Spawn_Generic01 = 2465U,
				// Token: 0x04002344 RID: 9028
				Spawn_Generic02,
				// Token: 0x04002345 RID: 9029
				Spawn_Generic03,
				// Token: 0x04002346 RID: 9030
				Spawn_Generic04,
				// Token: 0x04002347 RID: 9031
				Spawn_Generic05,
				// Token: 0x04002348 RID: 9032
				Spawn_Grim_Reaper = 987U,
				// Token: 0x04002349 RID: 9033
				Spawn_Lighthouse = 57409U,
				// Token: 0x0400234A RID: 9034
				Spawn_LighthouseArrival = 1935U,
				// Token: 0x0400234B RID: 9035
				Spawn_MagicPortal = 2223U,
				// Token: 0x0400234C RID: 9036
				Spawn_MagicPortal_Market = 49182U,
				// Token: 0x0400234D RID: 9037
				Spawn_Marketstall_Magic_Broom = 49166U,
				// Token: 0x0400234E RID: 9038
				Spawn_Marketstall_Magic_Potion = 49171U,
				// Token: 0x0400234F RID: 9039
				Spawn_Marketstall_Magic_Wand,
				// Token: 0x04002350 RID: 9040
				Spawn_NightStalker = 49158U,
				// Token: 0x04002351 RID: 9041
				Spawn_PetCrate = 57387U,
				// Token: 0x04002352 RID: 9042
				Spawn_RearWalkby = 400U,
				// Token: 0x04002353 RID: 9043
				Spawn_ScienceQuad = 65620U,
				// Token: 0x04002354 RID: 9044
				Spawn_ScienceUniversityShell = 65547U,
				// Token: 0x04002355 RID: 9045
				Spawn_ScienceUniversityShell_Shell1 = 65558U,
				// Token: 0x04002356 RID: 9046
				Spawn_ScienceUniversityShell_Shell2,
				// Token: 0x04002357 RID: 9047
				Spawn_Seance = 86021U,
				// Token: 0x04002358 RID: 9048
				Spawn_SecretSociety = 65621U,
				// Token: 0x04002359 RID: 9049
				Spawn_ShellArrival = 1933U,
				// Token: 0x0400235A RID: 9050
				Spawn_SkeletonArrival = 2039U,
				// Token: 0x0400235B RID: 9051
				Spawn_SnowSportsSlope_BunnySlope = 69740U,
				// Token: 0x0400235C RID: 9052
				Spawn_Starship = 51215U,
				// Token: 0x0400235D RID: 9053
				Spawn_Walkby = 398U,
				// Token: 0x0400235E RID: 9054
				Spawn_Walkby_SportsShellEP08 = 2234U,
				// Token: 0x0400235F RID: 9055
				Spawn_VisitorArrival = 399U,
				// Token: 0x04002360 RID: 9056
				Spawn_Zombie = 47132U,
				// Token: 0x04002361 RID: 9057
				Special_Nude = 127U,
				// Token: 0x04002362 RID: 9058
				SpecialContent_Anniversary21 = 2521U,
				// Token: 0x04002363 RID: 9059
				Spell_Magic = 49170U,
				// Token: 0x04002364 RID: 9060
				Style_ArtsQuarter = 55330U,
				// Token: 0x04002365 RID: 9061
				Style_Bohemian = 1495U,
				// Token: 0x04002366 RID: 9062
				Style_Business = 1593U,
				// Token: 0x04002367 RID: 9063
				Style_CAS_Branded_Anniversary21 = 2520U,
				// Token: 0x04002368 RID: 9064
				Style_CAS_Branded_MAC = 2433U,
				// Token: 0x04002369 RID: 9065
				Style_Classics = 239U,
				// Token: 0x0400236A RID: 9066
				Style_Country = 985U,
				// Token: 0x0400236B RID: 9067
				Style_FashionDistrict = 55331U,
				// Token: 0x0400236C RID: 9068
				Style_Festival_Blossom = 55348U,
				// Token: 0x0400236D RID: 9069
				Style_Festival_Dark = 1623U,
				// Token: 0x0400236E RID: 9070
				Style_Festival_Food,
				// Token: 0x0400236F RID: 9071
				Style_Festival_Light = 1622U,
				// Token: 0x04002370 RID: 9072
				Style_Festival_Nerd = 1621U,
				// Token: 0x04002371 RID: 9073
				Style_Festival_Romance = 1620U,
				// Token: 0x04002372 RID: 9074
				Style_FormalModern = 248U,
				// Token: 0x04002373 RID: 9075
				Style_FormalTrendy,
				// Token: 0x04002374 RID: 9076
				Style_Frankenstein = 8197U,
				// Token: 0x04002375 RID: 9077
				Style_GenCitySleek = 238U,
				// Token: 0x04002376 RID: 9078
				Style_GenContemporaryBasic = 240U,
				// Token: 0x04002377 RID: 9079
				Style_GenContemporaryDesigner,
				// Token: 0x04002378 RID: 9080
				Style_GenOutdoorExplorer = 243U,
				// Token: 0x04002379 RID: 9081
				Style_GenPartyTrendy,
				// Token: 0x0400237A RID: 9082
				Style_GenPolished,
				// Token: 0x0400237B RID: 9083
				Style_GenPreppy,
				// Token: 0x0400237C RID: 9084
				Style_GenRomantic,
				// Token: 0x0400237D RID: 9085
				Style_GenSummer = 237U,
				// Token: 0x0400237E RID: 9086
				Style_Glamping = 10265U,
				// Token: 0x0400237F RID: 9087
				Style_GothRockPunk = 289U,
				// Token: 0x04002380 RID: 9088
				Style_Hipster = 986U,
				// Token: 0x04002381 RID: 9089
				Style_IslandElemental = 63517U,
				// Token: 0x04002382 RID: 9090
				Style_Islander = 63495U,
				// Token: 0x04002383 RID: 9091
				Style_JapaneseContemporary = 69693U,
				// Token: 0x04002384 RID: 9092
				Style_Jungle = 2036U,
				// Token: 0x04002385 RID: 9093
				Style_Pirate = 8196U,
				// Token: 0x04002386 RID: 9094
				Style_ProfessorNPC_Good = 65597U,
				// Token: 0x04002387 RID: 9095
				Style_ProfessorNPC_Grumpy = 65596U,
				// Token: 0x04002388 RID: 9096
				Style_ProfessorNPC_Hip = 65595U,
				// Token: 0x04002389 RID: 9097
				Style_ProfessorNPC_Smart = 65598U,
				// Token: 0x0400238A RID: 9098
				Style_Seasonal_Fall = 2066U,
				// Token: 0x0400238B RID: 9099
				Style_Seasonal_Spring,
				// Token: 0x0400238C RID: 9100
				Style_Seasonal_Summer,
				// Token: 0x0400238D RID: 9101
				Style_Seasonal_Winter = 2065U,
				// Token: 0x0400238E RID: 9102
				Style_SpiceMarket = 55332U,
				// Token: 0x0400238F RID: 9103
				Style_Street = 1592U,
				// Token: 0x04002390 RID: 9104
				Style_VampireArchetype_Dracula = 1681U,
				// Token: 0x04002391 RID: 9105
				Style_VampireArchetype_Modern,
				// Token: 0x04002392 RID: 9106
				Style_VampireArchetype_Nosferatu = 1680U,
				// Token: 0x04002393 RID: 9107
				Style_VampireArchetype_Punk = 1684U,
				// Token: 0x04002394 RID: 9108
				Style_VampireArchetype_Victorian = 1683U,
				// Token: 0x04002395 RID: 9109
				Style_VampireWalkby_Modern = 40966U,
				// Token: 0x04002396 RID: 9110
				Style_VampireWalkby_Nosferatu = 40964U,
				// Token: 0x04002397 RID: 9111
				Style_VampireWalkby_Punk = 40968U,
				// Token: 0x04002398 RID: 9112
				Style_VampireWalkby_Victorian = 40967U,
				// Token: 0x04002399 RID: 9113
				Style_Witch = 8195U,
				// Token: 0x0400239A RID: 9114
				Tail_Long = 57350U,
				// Token: 0x0400239B RID: 9115
				Tail_Ring,
				// Token: 0x0400239C RID: 9116
				Tail_Saber = 57354U,
				// Token: 0x0400239D RID: 9117
				Tail_Screw = 57352U,
				// Token: 0x0400239E RID: 9118
				Tail_Stub,
				// Token: 0x0400239F RID: 9119
				TerrainManip_All = 2169U,
				// Token: 0x040023A0 RID: 9120
				TerrainPaint_All = 1082U,
				// Token: 0x040023A1 RID: 9121
				TerrainPaint_Dirt = 872U,
				// Token: 0x040023A2 RID: 9122
				TerrainPaint_Grass,
				// Token: 0x040023A3 RID: 9123
				TerrainPaint_Misc = 875U,
				// Token: 0x040023A4 RID: 9124
				TerrainPaint_Stone = 874U,
				// Token: 0x040023A5 RID: 9125
				Tooltip_AmbienceAngry = 732U,
				// Token: 0x040023A6 RID: 9126
				Tooltip_AmbienceBored,
				// Token: 0x040023A7 RID: 9127
				Tooltip_AmbienceConfident,
				// Token: 0x040023A8 RID: 9128
				Tooltip_AmbienceEmbarrassed,
				// Token: 0x040023A9 RID: 9129
				Tooltip_AmbienceEnergized,
				// Token: 0x040023AA RID: 9130
				Tooltip_AmbienceFlirty,
				// Token: 0x040023AB RID: 9131
				Tooltip_AmbienceFocused,
				// Token: 0x040023AC RID: 9132
				Tooltip_AmbienceHappy,
				// Token: 0x040023AD RID: 9133
				Tooltip_AmbienceImaginative,
				// Token: 0x040023AE RID: 9134
				Tooltip_AmbiencePlayful,
				// Token: 0x040023AF RID: 9135
				Tooltip_AmbienceSad,
				// Token: 0x040023B0 RID: 9136
				Tooltip_AmbienceTense,
				// Token: 0x040023B1 RID: 9137
				Tooltip_BillsDecrease = 2396U,
				// Token: 0x040023B2 RID: 9138
				Tooltip_BillsIncrease = 2395U,
				// Token: 0x040023B3 RID: 9139
				Tooltip_ColumnHeightRestricted = 2238U,
				// Token: 0x040023B4 RID: 9140
				Tooltip_CraftingQualityCarpentry = 706U,
				// Token: 0x040023B5 RID: 9141
				Tooltip_CraftingQualityCooking = 703U,
				// Token: 0x040023B6 RID: 9142
				Tooltip_CraftingQualityDrinks,
				// Token: 0x040023B7 RID: 9143
				Tooltip_CraftingQualityPainting,
				// Token: 0x040023B8 RID: 9144
				Tooltip_EcoFootprint_Negative = 67624U,
				// Token: 0x040023B9 RID: 9145
				Tooltip_EcoFootprint_Positive = 67623U,
				// Token: 0x040023BA RID: 9146
				Tooltip_EnvironmentScoreNegative = 2389U,
				// Token: 0x040023BB RID: 9147
				Tooltip_EnvironmentScorePositive,
				// Token: 0x040023BC RID: 9148
				Tooltip_EP09_EcoFootprint_Negative = 2422U,
				// Token: 0x040023BD RID: 9149
				Tooltip_EP09_EcoFootprint_Positive = 2421U,
				// Token: 0x040023BE RID: 9150
				Tooltip_HighFireResistance = 2392U,
				// Token: 0x040023BF RID: 9151
				Tooltip_HighWaterResistance = 2394U,
				// Token: 0x040023C0 RID: 9152
				Tooltip_LowFireResistance = 2391U,
				// Token: 0x040023C1 RID: 9153
				Tooltip_LowWaterResistance = 2393U,
				// Token: 0x040023C2 RID: 9154
				Tooltip_MiscCatsOnly = 2027U,
				// Token: 0x040023C3 RID: 9155
				Tooltip_MiscChildrenOnly = 783U,
				// Token: 0x040023C4 RID: 9156
				Tooltip_MiscComfort,
				// Token: 0x040023C5 RID: 9157
				Tooltip_MiscDogsOnly = 2026U,
				// Token: 0x040023C6 RID: 9158
				Tooltip_MiscPetsOnly = 2025U,
				// Token: 0x040023C7 RID: 9159
				Tooltip_MiscReliablility = 907U,
				// Token: 0x040023C8 RID: 9160
				Tooltip_MiscToddlerOnly = 1667U,
				// Token: 0x040023C9 RID: 9161
				Tooltip_MiscUnbreakable = 731U,
				// Token: 0x040023CA RID: 9162
				Tooltip_MiscUncomfortable = 747U,
				// Token: 0x040023CB RID: 9163
				Tooltip_MiscUncomfortableForAdults = 940U,
				// Token: 0x040023CC RID: 9164
				Tooltip_MoodReliefAngry = 710U,
				// Token: 0x040023CD RID: 9165
				Tooltip_MoodReliefBored,
				// Token: 0x040023CE RID: 9166
				Tooltip_MoodReliefEmbarrassed,
				// Token: 0x040023CF RID: 9167
				Tooltip_MoodReliefSad = 709U,
				// Token: 0x040023D0 RID: 9168
				Tooltip_MoodReliefStress = 707U,
				// Token: 0x040023D1 RID: 9169
				Tooltip_MoodReliefUncomfortable,
				// Token: 0x040023D2 RID: 9170
				Tooltip_MotiveBladder = 701U,
				// Token: 0x040023D3 RID: 9171
				Tooltip_MotiveEnergy = 698U,
				// Token: 0x040023D4 RID: 9172
				Tooltip_MotiveFun,
				// Token: 0x040023D5 RID: 9173
				Tooltip_MotiveHunger = 702U,
				// Token: 0x040023D6 RID: 9174
				Tooltip_MotiveHygiene = 697U,
				// Token: 0x040023D7 RID: 9175
				Tooltip_MotiveSocial = 700U,
				// Token: 0x040023D8 RID: 9176
				Tooltip_OffTheGrid = 2207U,
				// Token: 0x040023D9 RID: 9177
				Tooltip_PowerConsumer = 2398U,
				// Token: 0x040023DA RID: 9178
				Tooltip_PowerProducer = 2397U,
				// Token: 0x040023DB RID: 9179
				Tooltip_SkillActing = 61637U,
				// Token: 0x040023DC RID: 9180
				Tooltip_SkillArchaeology = 45110U,
				// Token: 0x040023DD RID: 9181
				Tooltip_SkillBartending = 717U,
				// Token: 0x040023DE RID: 9182
				Tooltip_SkillCharisma = 729U,
				// Token: 0x040023DF RID: 9183
				Tooltip_SkillComedy = 726U,
				// Token: 0x040023E0 RID: 9184
				Tooltip_SkillCommunication = 1670U,
				// Token: 0x040023E1 RID: 9185
				Tooltip_SkillCooking = 713U,
				// Token: 0x040023E2 RID: 9186
				Tooltip_SkillCreativity = 927U,
				// Token: 0x040023E3 RID: 9187
				Tooltip_SkillDance = 24615U,
				// Token: 0x040023E4 RID: 9188
				Tooltip_SkillDJ = 24614U,
				// Token: 0x040023E5 RID: 9189
				Tooltip_SkillDogTraining = 2023U,
				// Token: 0x040023E6 RID: 9190
				Tooltip_SkillFitness = 716U,
				// Token: 0x040023E7 RID: 9191
				Tooltip_SkillFlowerArranging = 2115U,
				// Token: 0x040023E8 RID: 9192
				Tooltip_SkillGardening = 728U,
				// Token: 0x040023E9 RID: 9193
				Tooltip_SkillGuitar = 727U,
				// Token: 0x040023EA RID: 9194
				Tooltip_SkillHandiness = 719U,
				// Token: 0x040023EB RID: 9195
				Tooltip_SkillImagination = 1669U,
				// Token: 0x040023EC RID: 9196
				Tooltip_SkillLogic = 721U,
				// Token: 0x040023ED RID: 9197
				Tooltip_SkillMental = 928U,
				// Token: 0x040023EE RID: 9198
				Tooltip_SkillMischief = 722U,
				// Token: 0x040023EF RID: 9199
				Tooltip_SkillMotor = 929U,
				// Token: 0x040023F0 RID: 9200
				Tooltip_SkillMovement = 1668U,
				// Token: 0x040023F1 RID: 9201
				Tooltip_SkillPainting = 718U,
				// Token: 0x040023F2 RID: 9202
				Tooltip_SkillPiano = 724U,
				// Token: 0x040023F3 RID: 9203
				Tooltip_SkillPipeOrgan = 40978U,
				// Token: 0x040023F4 RID: 9204
				Tooltip_SkillPotty = 1672U,
				// Token: 0x040023F5 RID: 9205
				Tooltip_SkillProgramming = 715U,
				// Token: 0x040023F6 RID: 9206
				Tooltip_SkillPsychic = 8212U,
				// Token: 0x040023F7 RID: 9207
				Tooltip_SkillResearchDebate = 2269U,
				// Token: 0x040023F8 RID: 9208
				Tooltip_SkillRobotics,
				// Token: 0x040023F9 RID: 9209
				Tooltip_SkillRocketScience = 720U,
				// Token: 0x040023FA RID: 9210
				Tooltip_SkillSinging = 55434U,
				// Token: 0x040023FB RID: 9211
				Tooltip_SkillSocial = 930U,
				// Token: 0x040023FC RID: 9212
				Tooltip_SkillThinking = 1671U,
				// Token: 0x040023FD RID: 9213
				Tooltip_SkillWellness = 18459U,
				// Token: 0x040023FE RID: 9214
				Tooltip_SkillVet = 2024U,
				// Token: 0x040023FF RID: 9215
				Tooltip_SkillVideoGaming = 714U,
				// Token: 0x04002400 RID: 9216
				Tooltip_SkillViolin = 725U,
				// Token: 0x04002401 RID: 9217
				Tooltip_SkillWoohoo = 730U,
				// Token: 0x04002402 RID: 9218
				Tooltip_SkillWriting = 723U,
				// Token: 0x04002403 RID: 9219
				Tooltip_WaterConsumer = 2400U,
				// Token: 0x04002404 RID: 9220
				Tooltip_WaterProducer = 2399U,
				// Token: 0x04002405 RID: 9221
				Top_Bikini = 1236U,
				// Token: 0x04002406 RID: 9222
				Top_Blouse = 155U,
				// Token: 0x04002407 RID: 9223
				Top_Brassiere = 944U,
				// Token: 0x04002408 RID: 9224
				Top_ButtonUps = 395U,
				// Token: 0x04002409 RID: 9225
				Top_Jacket = 295U,
				// Token: 0x0400240A RID: 9226
				Top_Polo = 943U,
				// Token: 0x0400240B RID: 9227
				Top_ShirtTee = 296U,
				// Token: 0x0400240C RID: 9228
				Top_SuitJacket = 942U,
				// Token: 0x0400240D RID: 9229
				Top_Sweater = 297U,
				// Token: 0x0400240E RID: 9230
				Top_Sweatshirt = 941U,
				// Token: 0x0400240F RID: 9231
				Top_Tanktop = 360U,
				// Token: 0x04002410 RID: 9232
				Top_Vest = 156U,
				// Token: 0x04002411 RID: 9233
				TraitAchievement = 235U,
				// Token: 0x04002412 RID: 9234
				TraitAge = 657U,
				// Token: 0x04002413 RID: 9235
				TraitGroup_Emotional = 753U,
				// Token: 0x04002414 RID: 9236
				TraitGroup_Hobbies,
				// Token: 0x04002415 RID: 9237
				TraitGroup_Lifestyle,
				// Token: 0x04002416 RID: 9238
				TraitGroup_Social,
				// Token: 0x04002417 RID: 9239
				TraitPersonality = 234U,
				// Token: 0x04002418 RID: 9240
				TraitWalkstyle = 236U,
				// Token: 0x04002419 RID: 9241
				Uniform_Activist_CrimialJustice = 55413U,
				// Token: 0x0400241A RID: 9242
				Uniform_Activist_EconomicGrowth,
				// Token: 0x0400241B RID: 9243
				Uniform_Activist_Environment,
				// Token: 0x0400241C RID: 9244
				Uniform_Activist_GlobalPeace,
				// Token: 0x0400241D RID: 9245
				Uniform_Activist_TaxReform,
				// Token: 0x0400241E RID: 9246
				Uniform_ActorCareer_Commercial_Hospital_Actor = 61561U,
				// Token: 0x0400241F RID: 9247
				Uniform_ActorCareer_Commercial_Hospital_CoStar,
				// Token: 0x04002420 RID: 9248
				Uniform_ActorCareer_Commercial_HouseNice_Actor = 61564U,
				// Token: 0x04002421 RID: 9249
				Uniform_ActorCareer_Commercial_HouseNice_CoStar,
				// Token: 0x04002422 RID: 9250
				Uniform_ActorCareer_Commercial_Kids_Actor,
				// Token: 0x04002423 RID: 9251
				Uniform_ActorCareer_Commercial_Pirate_Actor = 61560U,
				// Token: 0x04002424 RID: 9252
				Uniform_ActorCareer_Commercial_Western_Actor = 61563U,
				// Token: 0x04002425 RID: 9253
				Uniform_ActorCareer_Movie_City_Actor = 61608U,
				// Token: 0x04002426 RID: 9254
				Uniform_ActorCareer_Movie_City_CoStar = 61452U,
				// Token: 0x04002427 RID: 9255
				Uniform_ActorCareer_Movie_City_LoveInterest = 61451U,
				// Token: 0x04002428 RID: 9256
				Uniform_ActorCareer_Movie_Medieval_Actor = 61594U,
				// Token: 0x04002429 RID: 9257
				Uniform_ActorCareer_Movie_Medieval_LoveInterest = 61596U,
				// Token: 0x0400242A RID: 9258
				Uniform_ActorCareer_Movie_Medieval_Villain = 61595U,
				// Token: 0x0400242B RID: 9259
				Uniform_ActorCareer_Movie_Pirate_Actor = 61591U,
				// Token: 0x0400242C RID: 9260
				Uniform_ActorCareer_Movie_Pirate_LoveInterest = 61593U,
				// Token: 0x0400242D RID: 9261
				Uniform_ActorCareer_Movie_Pirate_Villain = 61592U,
				// Token: 0x0400242E RID: 9262
				Uniform_ActorCareer_Movie_SuperHero_Actor = 61603U,
				// Token: 0x0400242F RID: 9263
				Uniform_ActorCareer_Movie_SuperHero_LoveInterest = 61605U,
				// Token: 0x04002430 RID: 9264
				Uniform_ActorCareer_Movie_SuperHero_Villain = 61604U,
				// Token: 0x04002431 RID: 9265
				Uniform_ActorCareer_Movie_Western_Actor = 61597U,
				// Token: 0x04002432 RID: 9266
				Uniform_ActorCareer_Movie_Western_Alien = 61599U,
				// Token: 0x04002433 RID: 9267
				Uniform_ActorCareer_Movie_Western_Creature = 61598U,
				// Token: 0x04002434 RID: 9268
				Uniform_ActorCareer_Movie_Victorian_Actor = 61600U,
				// Token: 0x04002435 RID: 9269
				Uniform_ActorCareer_Movie_Victorian_CoStar = 61602U,
				// Token: 0x04002436 RID: 9270
				Uniform_ActorCareer_Movie_Victorian_LoveInterest = 61601U,
				// Token: 0x04002437 RID: 9271
				Uniform_ActorCareer_TVHigh_Apocalypse_Actor = 61577U,
				// Token: 0x04002438 RID: 9272
				Uniform_ActorCareer_TVHigh_Apocalypse_CoStar,
				// Token: 0x04002439 RID: 9273
				Uniform_ActorCareer_TVHigh_Apocalypse_Villain,
				// Token: 0x0400243A RID: 9274
				Uniform_ActorCareer_TVHigh_Hospital_Actor,
				// Token: 0x0400243B RID: 9275
				Uniform_ActorCareer_TVHigh_Hospital_CoStar = 61582U,
				// Token: 0x0400243C RID: 9276
				Uniform_ActorCareer_TVHigh_Hospital_LoveInterest = 61581U,
				// Token: 0x0400243D RID: 9277
				Uniform_ActorCareer_TVHigh_Police_Actor = 61588U,
				// Token: 0x0400243E RID: 9278
				Uniform_ActorCareer_TVHigh_Police_CoStar = 61590U,
				// Token: 0x0400243F RID: 9279
				Uniform_ActorCareer_TVHigh_Police_Villain = 61589U,
				// Token: 0x04002440 RID: 9280
				Uniform_ActorCareer_TVHigh_Western_Actor = 61583U,
				// Token: 0x04002441 RID: 9281
				Uniform_ActorCareer_TVHigh_Western_Villain,
				// Token: 0x04002442 RID: 9282
				Uniform_ActorCareer_TVHigh_Victorian_Actor,
				// Token: 0x04002443 RID: 9283
				Uniform_ActorCareer_TVHigh_Victorian_CoStar = 61587U,
				// Token: 0x04002444 RID: 9284
				Uniform_ActorCareer_TVHigh_Victorian_LoveInterest = 61586U,
				// Token: 0x04002445 RID: 9285
				Uniform_ActorCareer_TVLow_HouseLow_Actor = 61574U,
				// Token: 0x04002446 RID: 9286
				Uniform_ActorCareer_TVLow_HouseLow_CoStar,
				// Token: 0x04002447 RID: 9287
				Uniform_ActorCareer_TVLow_HouseNice_Actor = 61570U,
				// Token: 0x04002448 RID: 9288
				Uniform_ActorCareer_TVLow_HouseNice_CoStar,
				// Token: 0x04002449 RID: 9289
				Uniform_ActorCareer_TVLow_Kids_Actor = 61576U,
				// Token: 0x0400244A RID: 9290
				Uniform_ActorCareer_TVLow_Pirate_Actor = 61567U,
				// Token: 0x0400244B RID: 9291
				Uniform_ActorCareer_TVLow_Pirate_CoStar = 61569U,
				// Token: 0x0400244C RID: 9292
				Uniform_ActorCareer_TVLow_Pirate_LoveInterest = 61568U,
				// Token: 0x0400244D RID: 9293
				Uniform_ActorCareer_TVLow_Western_Actor = 61572U,
				// Token: 0x0400244E RID: 9294
				Uniform_ActorCareer_TVLow_Western_CoStar,
				// Token: 0x0400244F RID: 9295
				Uniform_Arrested = 12336U,
				// Token: 0x04002450 RID: 9296
				Uniform_ArtCritic_ShowFormal = 55395U,
				// Token: 0x04002451 RID: 9297
				Uniform_ArtsCenterPainter = 55357U,
				// Token: 0x04002452 RID: 9298
				Uniform_AstronautStatueGold = 55302U,
				// Token: 0x04002453 RID: 9299
				Uniform_AstronautStatueSilver = 55354U,
				// Token: 0x04002454 RID: 9300
				Uniform_AstronautSuit = 614U,
				// Token: 0x04002455 RID: 9301
				Uniform_AthleticCheerleader = 1262U,
				// Token: 0x04002456 RID: 9302
				Uniform_AthleticLifter,
				// Token: 0x04002457 RID: 9303
				Uniform_AthleticMajorLeaguer = 1266U,
				// Token: 0x04002458 RID: 9304
				Uniform_AthleticMascot = 1264U,
				// Token: 0x04002459 RID: 9305
				Uniform_AthleticMinorLeaguer = 1267U,
				// Token: 0x0400245A RID: 9306
				Uniform_AthleticTrackSuit = 1265U,
				// Token: 0x0400245B RID: 9307
				Uniform_Babysitter = 887U,
				// Token: 0x0400245C RID: 9308
				Uniform_BackgroundActor_Costume1 = 61642U,
				// Token: 0x0400245D RID: 9309
				Uniform_BackgroundActor_Costume2,
				// Token: 0x0400245E RID: 9310
				Uniform_BackgroundActor_Costume3,
				// Token: 0x0400245F RID: 9311
				Uniform_BackgroundActor_Costume4,
				// Token: 0x04002460 RID: 9312
				Uniform_BackgroundActor_Costume5,
				// Token: 0x04002461 RID: 9313
				Uniform_Barista = 884U,
				// Token: 0x04002462 RID: 9314
				Uniform_Bartender = 621U,
				// Token: 0x04002463 RID: 9315
				Uniform_Bartender_Jungle = 45090U,
				// Token: 0x04002464 RID: 9316
				Uniform_Batuu_Alien_Abednedo = 2471U,
				// Token: 0x04002465 RID: 9317
				Uniform_Batuu_Alien_Bith,
				// Token: 0x04002466 RID: 9318
				Uniform_Batuu_Alien_Mirialan,
				// Token: 0x04002467 RID: 9319
				Uniform_Batuu_Alien_Twilek,
				// Token: 0x04002468 RID: 9320
				Uniform_Batuu_Alien_Weequay,
				// Token: 0x04002469 RID: 9321
				Uniform_Batuu_Alien_Zabrak,
				// Token: 0x0400246A RID: 9322
				Uniform_Batuu_Bartender = 51225U,
				// Token: 0x0400246B RID: 9323
				Uniform_Batuu_Citizen = 51210U,
				// Token: 0x0400246C RID: 9324
				Uniform_Batuu_FirstOrder_Officer = 51205U,
				// Token: 0x0400246D RID: 9325
				Uniform_Batuu_FirstOrder_Stormtrooper = 51201U,
				// Token: 0x0400246E RID: 9326
				Uniform_Batuu_Pilot_FirstOrder = 51221U,
				// Token: 0x0400246F RID: 9327
				Uniform_Batuu_Pilot_Resistance,
				// Token: 0x04002470 RID: 9328
				Uniform_Batuu_Resistance_Member = 51202U,
				// Token: 0x04002471 RID: 9329
				Uniform_Batuu_Scoundrel_Member = 51209U,
				// Token: 0x04002472 RID: 9330
				Uniform_Batuu_ServiceNPC = 51224U,
				// Token: 0x04002473 RID: 9331
				Uniform_BearSuit = 10258U,
				// Token: 0x04002474 RID: 9332
				Uniform_Beekeeping_Suit = 59466U,
				// Token: 0x04002475 RID: 9333
				Uniform_BigHead = 2244U,
				// Token: 0x04002476 RID: 9334
				Uniform_BikeHelmet = 65618U,
				// Token: 0x04002477 RID: 9335
				Uniform_BlackAndWhiteParty = 682U,
				// Token: 0x04002478 RID: 9336
				Uniform_BlackTurtleneck = 627U,
				// Token: 0x04002479 RID: 9337
				Uniform_Bonehilda = 86029U,
				// Token: 0x0400247A RID: 9338
				Uniform_Bowling_NPC = 38918U,
				// Token: 0x0400247B RID: 9339
				Uniform_Bowling_Team1 = 38914U,
				// Token: 0x0400247C RID: 9340
				Uniform_Bowling_Team2,
				// Token: 0x0400247D RID: 9341
				Uniform_Bowling_Team3,
				// Token: 0x0400247E RID: 9342
				Uniform_Bowling_Team4,
				// Token: 0x0400247F RID: 9343
				Uniform_BowlingGloves = 38924U,
				// Token: 0x04002480 RID: 9344
				Uniform_BowlingShoes = 38923U,
				// Token: 0x04002481 RID: 9345
				Uniform_BusinessCheapSuit = 1269U,
				// Token: 0x04002482 RID: 9346
				Uniform_BusinessDecentSuit,
				// Token: 0x04002483 RID: 9347
				Uniform_BusinessExpensiveSuit,
				// Token: 0x04002484 RID: 9348
				Uniform_BusinessOfficeWorker = 1268U,
				// Token: 0x04002485 RID: 9349
				Uniform_Butler = 36869U,
				// Token: 0x04002486 RID: 9350
				Uniform_CameraOperator = 61450U,
				// Token: 0x04002487 RID: 9351
				Uniform_career_Gardener_Botanist = 59480U,
				// Token: 0x04002488 RID: 9352
				Uniform_career_Gardener_Florist,
				// Token: 0x04002489 RID: 9353
				Uniform_career_Gardener_Main = 59479U,
				// Token: 0x0400248A RID: 9354
				Uniform_Chef = 620U,
				// Token: 0x0400248B RID: 9355
				Uniform_ChildhoodPhase_Bear = 43027U,
				// Token: 0x0400248C RID: 9356
				Uniform_CivicInspector = 67627U,
				// Token: 0x0400248D RID: 9357
				Uniform_CivilDesigner_CivicPlanner = 67641U,
				// Token: 0x0400248E RID: 9358
				Uniform_CivilDesigner_GreenTechnician = 67640U,
				// Token: 0x0400248F RID: 9359
				Uniform_CivilDesigner_Main = 67639U,
				// Token: 0x04002490 RID: 9360
				Uniform_Clown = 680U,
				// Token: 0x04002491 RID: 9361
				Uniform_ConcertOutfit = 618U,
				// Token: 0x04002492 RID: 9362
				Uniform_Conservationist_EnvironmentalManager = 63523U,
				// Token: 0x04002493 RID: 9363
				Uniform_Conservationist_Main = 63522U,
				// Token: 0x04002494 RID: 9364
				Uniform_Conservationist_MarineBiologist = 63524U,
				// Token: 0x04002495 RID: 9365
				Uniform_Conspiracist = 47130U,
				// Token: 0x04002496 RID: 9366
				Uniform_Cook = 619U,
				// Token: 0x04002497 RID: 9367
				Uniform_CorporateWorker_Expert = 69708U,
				// Token: 0x04002498 RID: 9368
				Uniform_CorporateWorker_Main = 69707U,
				// Token: 0x04002499 RID: 9369
				Uniform_CorporateWorker_Supervisor = 69709U,
				// Token: 0x0400249A RID: 9370
				Uniform_Costume_AaylaSecura = 1486U,
				// Token: 0x0400249B RID: 9371
				Uniform_Costume_AlienHunter = 1700U,
				// Token: 0x0400249C RID: 9372
				Uniform_Costume_AnimalHood = 2113U,
				// Token: 0x0400249D RID: 9373
				Uniform_Costume_AnimalHoodie = 59475U,
				// Token: 0x0400249E RID: 9374
				Uniform_Costume_AstronautOrange = 1480U,
				// Token: 0x0400249F RID: 9375
				Uniform_Costume_AstronautWhite = 1466U,
				// Token: 0x040024A0 RID: 9376
				Uniform_Costume_BobaFett = 1475U,
				// Token: 0x040024A1 RID: 9377
				Uniform_Costume_CartoonPlumbers = 1631U,
				// Token: 0x040024A2 RID: 9378
				Uniform_Costume_CheerleaderGreen = 1476U,
				// Token: 0x040024A3 RID: 9379
				Uniform_Costume_ClownPink = 1481U,
				// Token: 0x040024A4 RID: 9380
				Uniform_Costume_ClownYellow = 1467U,
				// Token: 0x040024A5 RID: 9381
				Uniform_Costume_ColorfulAnimals = 1632U,
				// Token: 0x040024A6 RID: 9382
				Uniform_Costume_DarthMaul = 1474U,
				// Token: 0x040024A7 RID: 9383
				Uniform_Costume_DarthVader = 1473U,
				// Token: 0x040024A8 RID: 9384
				Uniform_Costume_Fairy = 22530U,
				// Token: 0x040024A9 RID: 9385
				Uniform_Costume_FairyBlue = 22547U,
				// Token: 0x040024AA RID: 9386
				Uniform_Costume_FairyGreen = 22546U,
				// Token: 0x040024AB RID: 9387
				Uniform_Costume_FairyPurple = 22548U,
				// Token: 0x040024AC RID: 9388
				Uniform_Costume_HolidayHelper = 59473U,
				// Token: 0x040024AD RID: 9389
				Uniform_Costume_HotDogRed = 1468U,
				// Token: 0x040024AE RID: 9390
				Uniform_Costume_Legonaire = 22532U,
				// Token: 0x040024AF RID: 9391
				Uniform_Costume_Leia = 1485U,
				// Token: 0x040024B0 RID: 9392
				Uniform_Costume_Llama = 22531U,
				// Token: 0x040024B1 RID: 9393
				Uniform_Costume_LlamaGirlPurple = 22549U,
				// Token: 0x040024B2 RID: 9394
				Uniform_Costume_LlamaManBlack = 22544U,
				// Token: 0x040024B3 RID: 9395
				Uniform_Costume_LukeSkywalker = 1472U,
				// Token: 0x040024B4 RID: 9396
				Uniform_Costume_MaidBlack = 1483U,
				// Token: 0x040024B5 RID: 9397
				Uniform_Costume_MaidBlue = 1470U,
				// Token: 0x040024B6 RID: 9398
				Uniform_Costume_MailmanBlue = 1479U,
				// Token: 0x040024B7 RID: 9399
				Uniform_Costume_MascotBlueBlack = 1469U,
				// Token: 0x040024B8 RID: 9400
				Uniform_Costume_MascotWhite = 1482U,
				// Token: 0x040024B9 RID: 9401
				Uniform_Costume_Monster = 1699U,
				// Token: 0x040024BA RID: 9402
				Uniform_Costume_Ninja = 22533U,
				// Token: 0x040024BB RID: 9403
				Uniform_Costume_NinjaRed = 22543U,
				// Token: 0x040024BC RID: 9404
				Uniform_Costume_Pirate = 22534U,
				// Token: 0x040024BD RID: 9405
				Uniform_Costume_PirateBrown = 22559U,
				// Token: 0x040024BE RID: 9406
				Uniform_Costume_PirateNavy = 22542U,
				// Token: 0x040024BF RID: 9407
				Uniform_Costume_PirateRed = 22550U,
				// Token: 0x040024C0 RID: 9408
				Uniform_Costume_PirateWhite = 22566U,
				// Token: 0x040024C1 RID: 9409
				Uniform_Costume_PizzaOrange = 1471U,
				// Token: 0x040024C2 RID: 9410
				Uniform_Costume_PizzaRed = 1484U,
				// Token: 0x040024C3 RID: 9411
				Uniform_Costume_Princess = 22537U,
				// Token: 0x040024C4 RID: 9412
				Uniform_Costume_PrincessBlue = 22556U,
				// Token: 0x040024C5 RID: 9413
				Uniform_Costume_PrincessGold,
				// Token: 0x040024C6 RID: 9414
				Uniform_Costume_PrincessPink,
				// Token: 0x040024C7 RID: 9415
				Uniform_Costume_PumpkinBrown = 22564U,
				// Token: 0x040024C8 RID: 9416
				Uniform_Costume_PumpkinMan = 22535U,
				// Token: 0x040024C9 RID: 9417
				Uniform_Costume_PumpkinNavy = 22563U,
				// Token: 0x040024CA RID: 9418
				Uniform_Costume_PumpkinPlum = 22565U,
				// Token: 0x040024CB RID: 9419
				Uniform_Costume_RoboHat = 2225U,
				// Token: 0x040024CC RID: 9420
				Uniform_Costume_SausageGray = 1489U,
				// Token: 0x040024CD RID: 9421
				Uniform_Costume_SchoolGirl = 22538U,
				// Token: 0x040024CE RID: 9422
				Uniform_Costume_Skeleton,
				// Token: 0x040024CF RID: 9423
				Uniform_Costume_SkeletonGreen = 22561U,
				// Token: 0x040024D0 RID: 9424
				Uniform_Costume_SkeletonOrange,
				// Token: 0x040024D1 RID: 9425
				Uniform_Costume_SkeletonWhite = 22560U,
				// Token: 0x040024D2 RID: 9426
				Uniform_Costume_SmugglerBrown = 1488U,
				// Token: 0x040024D3 RID: 9427
				Uniform_Costume_SmugglerTan = 1477U,
				// Token: 0x040024D4 RID: 9428
				Uniform_Costume_SpaceRangerBlack = 1487U,
				// Token: 0x040024D5 RID: 9429
				Uniform_Costume_SpaceRangerBlue = 1478U,
				// Token: 0x040024D6 RID: 9430
				Uniform_Costume_SpartanBrown = 22551U,
				// Token: 0x040024D7 RID: 9431
				Uniform_Costume_SpartanGold = 22545U,
				// Token: 0x040024D8 RID: 9432
				Uniform_Costume_TreeFir = 59474U,
				// Token: 0x040024D9 RID: 9433
				Uniform_Costume_Witch = 22536U,
				// Token: 0x040024DA RID: 9434
				Uniform_Costume_WitchBlack = 22552U,
				// Token: 0x040024DB RID: 9435
				Uniform_Costume_WitchGreen,
				// Token: 0x040024DC RID: 9436
				Uniform_Costume_WitchOrange,
				// Token: 0x040024DD RID: 9437
				Uniform_Costume_Yoda = 1490U,
				// Token: 0x040024DE RID: 9438
				Uniform_Costume_ZombieBlue = 22555U,
				// Token: 0x040024DF RID: 9439
				Uniform_CowboyStatueGold = 55433U,
				// Token: 0x040024E0 RID: 9440
				Uniform_CrimeBoss = 623U,
				// Token: 0x040024E1 RID: 9441
				Uniform_CrimeLordHat = 622U,
				// Token: 0x040024E2 RID: 9442
				Uniform_DayoftheDead_Walkby = 1568U,
				// Token: 0x040024E3 RID: 9443
				Uniform_DayoftheDead_Walkby_Female,
				// Token: 0x040024E4 RID: 9444
				Uniform_Debate_Judge = 65590U,
				// Token: 0x040024E5 RID: 9445
				Uniform_Detective = 12334U,
				// Token: 0x040024E6 RID: 9446
				Uniform_Director = 61449U,
				// Token: 0x040024E7 RID: 9447
				Uniform_Diver = 63515U,
				// Token: 0x040024E8 RID: 9448
				Uniform_DJ_High = 24584U,
				// Token: 0x040024E9 RID: 9449
				Uniform_DJ_Low = 24583U,
				// Token: 0x040024EA RID: 9450
				Uniform_Doctor_high = 12340U,
				// Token: 0x040024EB RID: 9451
				Uniform_Doctor_low = 12339U,
				// Token: 0x040024EC RID: 9452
				Uniform_DramaClub = 61639U,
				// Token: 0x040024ED RID: 9453
				Uniform_EcoInspector = 67626U,
				// Token: 0x040024EE RID: 9454
				Uniform_Education = 65552U,
				// Token: 0x040024EF RID: 9455
				Uniform_Education_Admin,
				// Token: 0x040024F0 RID: 9456
				Uniform_Education_Prof,
				// Token: 0x040024F1 RID: 9457
				Uniform_ElbowPatchJacket = 625U,
				// Token: 0x040024F2 RID: 9458
				Uniform_EP01_Alien = 12385U,
				// Token: 0x040024F3 RID: 9459
				Uniform_EP01_Doctor_mid = 12357U,
				// Token: 0x040024F4 RID: 9460
				Uniform_EP01_PoliceChief = 12426U,
				// Token: 0x040024F5 RID: 9461
				Uniform_EP01_RetailEmployee = 12412U,
				// Token: 0x040024F6 RID: 9462
				Uniform_EP01_Scientist_AlienHunter = 12381U,
				// Token: 0x040024F7 RID: 9463
				Uniform_EP01_Scientist_high = 12349U,
				// Token: 0x040024F8 RID: 9464
				Uniform_EP01_Scientist_low,
				// Token: 0x040024F9 RID: 9465
				Uniform_EP01_Scientist_mid = 12359U,
				// Token: 0x040024FA RID: 9466
				Uniform_EP01_Scientist_veryHigh = 12399U,
				// Token: 0x040024FB RID: 9467
				Uniform_EP01_SuspectBlackHair = 12401U,
				// Token: 0x040024FC RID: 9468
				Uniform_EP01_SuspectBlondeHair = 12367U,
				// Token: 0x040024FD RID: 9469
				Uniform_EP01_SuspectBottomPants = 12408U,
				// Token: 0x040024FE RID: 9470
				Uniform_EP01_SuspectBottomShorts = 12411U,
				// Token: 0x040024FF RID: 9471
				Uniform_EP01_SuspectBottomSkirt = 12409U,
				// Token: 0x04002500 RID: 9472
				Uniform_EP01_SuspectBottomSlacks,
				// Token: 0x04002501 RID: 9473
				Uniform_EP01_SuspectBrownHair = 12402U,
				// Token: 0x04002502 RID: 9474
				Uniform_EP01_SuspectGreyHair = 12432U,
				// Token: 0x04002503 RID: 9475
				Uniform_EP01_SuspectRedHair = 12366U,
				// Token: 0x04002504 RID: 9476
				Uniform_EP01_SuspectTopBlouse = 12406U,
				// Token: 0x04002505 RID: 9477
				Uniform_EP01_SuspectTopJacket = 12404U,
				// Token: 0x04002506 RID: 9478
				Uniform_EP01_SuspectTopLongSleeve,
				// Token: 0x04002507 RID: 9479
				Uniform_EP01_SuspectTopShortSleeve = 12403U,
				// Token: 0x04002508 RID: 9480
				Uniform_EP01_SuspectTopTank = 12407U,
				// Token: 0x04002509 RID: 9481
				Uniform_EP07_Vendor = 63525U,
				// Token: 0x0400250A RID: 9482
				Uniform_ESportsPlayer_Arts = 65601U,
				// Token: 0x0400250B RID: 9483
				Uniform_ESportsPlayer_Science,
				// Token: 0x0400250C RID: 9484
				Uniform_Fairy = 8209U,
				// Token: 0x0400250D RID: 9485
				Uniform_FastFood = 883U,
				// Token: 0x0400250E RID: 9486
				Uniform_FatherWinter = 2071U,
				// Token: 0x0400250F RID: 9487
				Uniform_FatherWinter_Summer = 2086U,
				// Token: 0x04002510 RID: 9488
				Uniform_Festival_Blossom_Shirt = 55350U,
				// Token: 0x04002511 RID: 9489
				Uniform_Festival_Food_CurryContest_Shirt = 55397U,
				// Token: 0x04002512 RID: 9490
				Uniform_Festival_Food_Shirt = 55351U,
				// Token: 0x04002513 RID: 9491
				Uniform_Festival_Lamp_Shirt,
				// Token: 0x04002514 RID: 9492
				Uniform_Festival_LlamaBlue = 55421U,
				// Token: 0x04002515 RID: 9493
				Uniform_Festival_LlamaGold = 55423U,
				// Token: 0x04002516 RID: 9494
				Uniform_Festival_LlamaSilver,
				// Token: 0x04002517 RID: 9495
				Uniform_Festival_LlamaYellow = 55422U,
				// Token: 0x04002518 RID: 9496
				Uniform_Festival_Logic_Shirt = 55353U,
				// Token: 0x04002519 RID: 9497
				Uniform_FestiveSpirit = 2089U,
				// Token: 0x0400251A RID: 9498
				Uniform_Firefighter = 2426U,
				// Token: 0x0400251B RID: 9499
				Uniform_FlowerBunny = 59458U,
				// Token: 0x0400251C RID: 9500
				Uniform_FoodCritic_RestaurantCasual = 55396U,
				// Token: 0x0400251D RID: 9501
				Uniform_ForestRanger = 10266U,
				// Token: 0x0400251E RID: 9502
				Uniform_FortuneTeller = 8198U,
				// Token: 0x0400251F RID: 9503
				Uniform_Frankenstein = 8201U,
				// Token: 0x04002520 RID: 9504
				Uniform_GAMESCOM_ClosetFail = 24579U,
				// Token: 0x04002521 RID: 9505
				Uniform_GAMESCOM_ClosetSucceed,
				// Token: 0x04002522 RID: 9506
				Uniform_GP01cfTankLace = 10291U,
				// Token: 0x04002523 RID: 9507
				Uniform_GP01cuPocketZip = 10288U,
				// Token: 0x04002524 RID: 9508
				Uniform_GP01cuTeeLongShirtPants = 10290U,
				// Token: 0x04002525 RID: 9509
				Uniform_GP01cuTeeLongShirtShorts = 10287U,
				// Token: 0x04002526 RID: 9510
				Uniform_GP01cuVestDown = 10289U,
				// Token: 0x04002527 RID: 9511
				Uniform_GP01Walkbys1 = 10292U,
				// Token: 0x04002528 RID: 9512
				Uniform_GP01Walkbys2,
				// Token: 0x04002529 RID: 9513
				Uniform_GP01Walkbys3,
				// Token: 0x0400252A RID: 9514
				Uniform_GP01Walkbys5 = 10296U,
				// Token: 0x0400252B RID: 9515
				Uniform_GP01Walkbys6,
				// Token: 0x0400252C RID: 9516
				Uniform_GP01Walksbys4 = 10295U,
				// Token: 0x0400252D RID: 9517
				Uniform_GP01yfJacketFleece = 10279U,
				// Token: 0x0400252E RID: 9518
				Uniform_GP01yfLayers = 10276U,
				// Token: 0x0400252F RID: 9519
				Uniform_GP01yfLayersHat,
				// Token: 0x04002530 RID: 9520
				Uniform_GP01yfTeeTied = 10281U,
				// Token: 0x04002531 RID: 9521
				Uniform_GP01yfVestFlannel = 10278U,
				// Token: 0x04002532 RID: 9522
				Uniform_GP01yfVestTee = 10280U,
				// Token: 0x04002533 RID: 9523
				Uniform_GP01ymFingerShirt = 10285U,
				// Token: 0x04002534 RID: 9524
				Uniform_GP01ymTank = 10283U,
				// Token: 0x04002535 RID: 9525
				Uniform_GP01ymThickLayers,
				// Token: 0x04002536 RID: 9526
				Uniform_GP01ymVestCarabiner = 10282U,
				// Token: 0x04002537 RID: 9527
				Uniform_GP01ymVestFleece = 10286U,
				// Token: 0x04002538 RID: 9528
				Uniform_GrimReaper = 316U,
				// Token: 0x04002539 RID: 9529
				Uniform_GrimReaperHelper = 366U,
				// Token: 0x0400253A RID: 9530
				Uniform_Hacker = 624U,
				// Token: 0x0400253B RID: 9531
				Uniform_HairMakeUpChair_Stylist = 61453U,
				// Token: 0x0400253C RID: 9532
				Uniform_HazmatSuit = 47127U,
				// Token: 0x0400253D RID: 9533
				Uniform_HazmatSuit_WithFilter,
				// Token: 0x0400253E RID: 9534
				Uniform_Hermit = 10257U,
				// Token: 0x0400253F RID: 9535
				Uniform_HiredNanny = 1549U,
				// Token: 0x04002540 RID: 9536
				Uniform_HotDog = 681U,
				// Token: 0x04002541 RID: 9537
				Uniform_InvestigativeJournalist = 626U,
				// Token: 0x04002542 RID: 9538
				Uniform_IslandElemental = 63516U,
				// Token: 0x04002543 RID: 9539
				Uniform_IslandLocal = 63513U,
				// Token: 0x04002544 RID: 9540
				Uniform_IslandLocal_FlowerMusic,
				// Token: 0x04002545 RID: 9541
				Uniform_JapaneseTraditional = 69694U,
				// Token: 0x04002546 RID: 9542
				Uniform_Jungle_Vendor1 = 45102U,
				// Token: 0x04002547 RID: 9543
				Uniform_Jungle_Vendor2,
				// Token: 0x04002548 RID: 9544
				Uniform_Jungle_Vendor3,
				// Token: 0x04002549 RID: 9545
				Uniform_KnightSuit = 24610U,
				// Token: 0x0400254A RID: 9546
				Uniform_LawCareer_Judge = 65628U,
				// Token: 0x0400254B RID: 9547
				Uniform_LawCareer_Main = 65627U,
				// Token: 0x0400254C RID: 9548
				Uniform_LawCareer_MainHigh = 65630U,
				// Token: 0x0400254D RID: 9549
				Uniform_LawCareer_PA = 65629U,
				// Token: 0x0400254E RID: 9550
				Uniform_Lifeguard = 63502U,
				// Token: 0x0400254F RID: 9551
				Uniform_LoveGuru = 55358U,
				// Token: 0x04002550 RID: 9552
				Uniform_Maid = 262U,
				// Token: 0x04002551 RID: 9553
				Uniform_MaidDEPRECATED = 636U,
				// Token: 0x04002552 RID: 9554
				Uniform_Mailman = 341U,
				// Token: 0x04002553 RID: 9555
				Uniform_MaintainenceWorker = 613U,
				// Token: 0x04002554 RID: 9556
				Uniform_ManualLabor = 885U,
				// Token: 0x04002555 RID: 9557
				Uniform_Mascot_Alt_Arts = 65588U,
				// Token: 0x04002556 RID: 9558
				Uniform_Mascot_Alt_Science,
				// Token: 0x04002557 RID: 9559
				Uniform_Mascot_Arts = 65586U,
				// Token: 0x04002558 RID: 9560
				Uniform_Mascot_Science,
				// Token: 0x04002559 RID: 9561
				Uniform_MassageTherapist = 18446U,
				// Token: 0x0400255A RID: 9562
				Uniform_MassageTowel = 18450U,
				// Token: 0x0400255B RID: 9563
				Uniform_MasterFisherman = 867U,
				// Token: 0x0400255C RID: 9564
				Uniform_MasterGardener,
				// Token: 0x0400255D RID: 9565
				Uniform_Military_Covert_Headset = 47123U,
				// Token: 0x0400255E RID: 9566
				Uniform_Military_Covert_Suit = 47121U,
				// Token: 0x0400255F RID: 9567
				Uniform_Military_Covert_Sunglasses,
				// Token: 0x04002560 RID: 9568
				Uniform_Military_Main_Level_01 = 47111U,
				// Token: 0x04002561 RID: 9569
				Uniform_Military_Main_Level_02,
				// Token: 0x04002562 RID: 9570
				Uniform_Military_Main_Level_03,
				// Token: 0x04002563 RID: 9571
				Uniform_Military_Main_Level_04,
				// Token: 0x04002564 RID: 9572
				Uniform_Military_Main_Level_05,
				// Token: 0x04002565 RID: 9573
				Uniform_Military_Officer_Level_01,
				// Token: 0x04002566 RID: 9574
				Uniform_Military_Officer_Level_02,
				// Token: 0x04002567 RID: 9575
				Uniform_Military_Officer_Level_03,
				// Token: 0x04002568 RID: 9576
				Uniform_Military_Officer_Level_04,
				// Token: 0x04002569 RID: 9577
				Uniform_Military_Officer_Level_05,
				// Token: 0x0400256A RID: 9578
				Uniform_NInja = 8205U,
				// Token: 0x0400256B RID: 9579
				Uniform_OfficeWorker = 607U,
				// Token: 0x0400256C RID: 9580
				Uniform_OnsenVenueEmployee = 69664U,
				// Token: 0x0400256D RID: 9581
				Uniform_Oracle = 659U,
				// Token: 0x0400256E RID: 9582
				Uniform_Organization_ArtSociety_Member = 65617U,
				// Token: 0x0400256F RID: 9583
				Uniform_Organization_ArtSociety_Model = 65616U,
				// Token: 0x04002570 RID: 9584
				Uniform_Organization_Debate = 65635U,
				// Token: 0x04002571 RID: 9585
				Uniform_Organization_DebateJudge = 65642U,
				// Token: 0x04002572 RID: 9586
				Uniform_Organization_DebateShowdown,
				// Token: 0x04002573 RID: 9587
				Uniform_Organization_DebateShowdownFoxbury = 65654U,
				// Token: 0x04002574 RID: 9588
				Uniform_Organization_Honor = 65636U,
				// Token: 0x04002575 RID: 9589
				Uniform_Organization_Party,
				// Token: 0x04002576 RID: 9590
				Uniform_Organization_Prank,
				// Token: 0x04002577 RID: 9591
				Uniform_Organization_Robotics = 65634U,
				// Token: 0x04002578 RID: 9592
				Uniform_Painter = 629U,
				// Token: 0x04002579 RID: 9593
				Uniform_Paparazzi = 61606U,
				// Token: 0x0400257A RID: 9594
				Uniform_Parts_Bride = 631U,
				// Token: 0x0400257B RID: 9595
				Uniform_Parts_Groom = 630U,
				// Token: 0x0400257C RID: 9596
				Uniform_Parts_Librarian = 633U,
				// Token: 0x0400257D RID: 9597
				Uniform_Parts_OfficeWorker,
				// Token: 0x0400257E RID: 9598
				Uniform_Parts_ParkSleeper,
				// Token: 0x0400257F RID: 9599
				Uniform_PartTime_Fisherman = 63520U,
				// Token: 0x04002580 RID: 9600
				Uniform_Party_PartyHats = 632U,
				// Token: 0x04002581 RID: 9601
				Uniform_Patient = 12338U,
				// Token: 0x04002582 RID: 9602
				Uniform_Pirate = 8203U,
				// Token: 0x04002583 RID: 9603
				Uniform_PizzaDelivery = 637U,
				// Token: 0x04002584 RID: 9604
				Uniform_PoliceOfficer = 12335U,
				// Token: 0x04002585 RID: 9605
				Uniform_Politician_HighLevel = 55418U,
				// Token: 0x04002586 RID: 9606
				Uniform_Politician_LowLevel = 55420U,
				// Token: 0x04002587 RID: 9607
				Uniform_Politician_MediumLevel = 55419U,
				// Token: 0x04002588 RID: 9608
				Uniform_Princess = 8208U,
				// Token: 0x04002589 RID: 9609
				Uniform_Producer = 61628U,
				// Token: 0x0400258A RID: 9610
				Uniform_ProfessorNPC_Good = 65647U,
				// Token: 0x0400258B RID: 9611
				Uniform_ProfessorNPC_Grumpy = 65646U,
				// Token: 0x0400258C RID: 9612
				Uniform_ProfessorNPC_Hip = 65645U,
				// Token: 0x0400258D RID: 9613
				Uniform_ProfessorNPC_Smart = 65644U,
				// Token: 0x0400258E RID: 9614
				Uniform_ProGamer = 628U,
				// Token: 0x0400258F RID: 9615
				Uniform_Pumpkin = 8206U,
				// Token: 0x04002590 RID: 9616
				Uniform_Raccoon = 55372U,
				// Token: 0x04002591 RID: 9617
				Uniform_Reflexologist = 18460U,
				// Token: 0x04002592 RID: 9618
				Uniform_Repair = 1491U,
				// Token: 0x04002593 RID: 9619
				Uniform_RepoPerson = 65633U,
				// Token: 0x04002594 RID: 9620
				Uniform_RestaurantCritic = 26644U,
				// Token: 0x04002595 RID: 9621
				Uniform_Retail = 886U,
				// Token: 0x04002596 RID: 9622
				Uniform_Robe = 18437U,
				// Token: 0x04002597 RID: 9623
				Uniform_RockClimbingGear_Gloves = 69743U,
				// Token: 0x04002598 RID: 9624
				Uniform_RockClimbingGear_Shoes,
				// Token: 0x04002599 RID: 9625
				Uniform_SchoolGirl = 8207U,
				// Token: 0x0400259A RID: 9626
				Uniform_Scout_Basic = 59464U,
				// Token: 0x0400259B RID: 9627
				Uniform_Scout_Expert,
				// Token: 0x0400259C RID: 9628
				Uniform_SecretSociety_Level1 = 65566U,
				// Token: 0x0400259D RID: 9629
				Uniform_SecretSociety_Level2,
				// Token: 0x0400259E RID: 9630
				Uniform_SecretSociety_Level3,
				// Token: 0x0400259F RID: 9631
				Uniform_ShoesOffIndoors = 69703U,
				// Token: 0x040025A0 RID: 9632
				Uniform_Skating_Generic = 59471U,
				// Token: 0x040025A1 RID: 9633
				Uniform_Skating_Ice = 59433U,
				// Token: 0x040025A2 RID: 9634
				Uniform_Skating_Pro = 59442U,
				// Token: 0x040025A3 RID: 9635
				Uniform_Skating_Roller = 59434U,
				// Token: 0x040025A4 RID: 9636
				Uniform_Skeleton = 8204U,
				// Token: 0x040025A5 RID: 9637
				Uniform_Skeleton_GP06 = 45088U,
				// Token: 0x040025A6 RID: 9638
				Uniform_SkiBoots = 69738U,
				// Token: 0x040025A7 RID: 9639
				Uniform_SlippersIndoors = 69702U,
				// Token: 0x040025A8 RID: 9640
				Uniform_Smuggler = 616U,
				// Token: 0x040025A9 RID: 9641
				Uniform_SnowboardBoots = 69739U,
				// Token: 0x040025AA RID: 9642
				Uniform_SnowyVendor = 69722U,
				// Token: 0x040025AB RID: 9643
				Uniform_SoccerPlayer_Arts = 65599U,
				// Token: 0x040025AC RID: 9644
				Uniform_SoccerPlayer_Science,
				// Token: 0x040025AD RID: 9645
				Uniform_SpaceRanger = 615U,
				// Token: 0x040025AE RID: 9646
				Uniform_Spartan = 8211U,
				// Token: 0x040025AF RID: 9647
				Uniform_Spellcaster_Edgy = 49177U,
				// Token: 0x040025B0 RID: 9648
				Uniform_Spellcaster_Fairytale = 49176U,
				// Token: 0x040025B1 RID: 9649
				Uniform_Spellcaster_Sage = 49178U,
				// Token: 0x040025B2 RID: 9650
				Uniform_Spellcaster_Sage_Mischief = 49180U,
				// Token: 0x040025B3 RID: 9651
				Uniform_Spellcaster_Sage_Practical = 49179U,
				// Token: 0x040025B4 RID: 9652
				Uniform_Spellcaster_Sage_Untamed = 49181U,
				// Token: 0x040025B5 RID: 9653
				Uniform_Spellcaster_StreetModern = 49175U,
				// Token: 0x040025B6 RID: 9654
				Uniform_Spellcaster_Vintage = 49174U,
				// Token: 0x040025B7 RID: 9655
				Uniform_SportsFan_Arts = 65604U,
				// Token: 0x040025B8 RID: 9656
				Uniform_SportsFan_Science,
				// Token: 0x040025B9 RID: 9657
				Uniform_Stalls_CurioShop_Hat = 47109U,
				// Token: 0x040025BA RID: 9658
				Uniform_Stalls_CurioShop_Shirt,
				// Token: 0x040025BB RID: 9659
				Uniform_Stalls_CurioShop_Vendor = 47108U,
				// Token: 0x040025BC RID: 9660
				Uniform_Stalls_FoodFestival = 55429U,
				// Token: 0x040025BD RID: 9661
				Uniform_Stalls_Generic = 55428U,
				// Token: 0x040025BE RID: 9662
				Uniform_Stalls_GenericMarketStalls = 1937U,
				// Token: 0x040025BF RID: 9663
				Uniform_Stalls_LampFestival = 55430U,
				// Token: 0x040025C0 RID: 9664
				Uniform_Stalls_NerdFestival = 55432U,
				// Token: 0x040025C1 RID: 9665
				Uniform_Stalls_PetWorld = 1986U,
				// Token: 0x040025C2 RID: 9666
				Uniform_Stalls_RomanceFestival = 55431U,
				// Token: 0x040025C3 RID: 9667
				Uniform_StrangervilleScientist = 47140U,
				// Token: 0x040025C4 RID: 9668
				Uniform_Suit = 608U,
				// Token: 0x040025C5 RID: 9669
				Uniform_Suit_Leisure = 617U,
				// Token: 0x040025C6 RID: 9670
				Uniform_SummitStudent = 69674U,
				// Token: 0x040025C7 RID: 9671
				Uniform_SuperTuxedo = 610U,
				// Token: 0x040025C8 RID: 9672
				Uniform_TactialTurtleneck = 612U,
				// Token: 0x040025C9 RID: 9673
				Uniform_Teenager = 760U,
				// Token: 0x040025CA RID: 9674
				Uniform_Toddler_DiaperOnly = 1673U,
				// Token: 0x040025CB RID: 9675
				Uniform_Tourist = 55306U,
				// Token: 0x040025CC RID: 9676
				Uniform_Tourist_Basegame = 2166U,
				// Token: 0x040025CD RID: 9677
				Uniform_Towel = 1440U,
				// Token: 0x040025CE RID: 9678
				Uniform_TragicClown = 1503U,
				// Token: 0x040025CF RID: 9679
				Uniform_TurtleFanatic = 63521U,
				// Token: 0x040025D0 RID: 9680
				Uniform_Tuxedo = 609U,
				// Token: 0x040025D1 RID: 9681
				Uniform_University_Graduation_Arts = 65610U,
				// Token: 0x040025D2 RID: 9682
				Uniform_University_Graduation_Arts_NoCap,
				// Token: 0x040025D3 RID: 9683
				Uniform_University_Graduation_Science,
				// Token: 0x040025D4 RID: 9684
				Uniform_University_Graduation_Science_NoCap,
				// Token: 0x040025D5 RID: 9685
				Uniform_UniversityKiosk_BottomAH = 65578U,
				// Token: 0x040025D6 RID: 9686
				Uniform_UniversityKiosk_BottomST,
				// Token: 0x040025D7 RID: 9687
				Uniform_UniversityKiosk_HatAH,
				// Token: 0x040025D8 RID: 9688
				Uniform_UniversityKiosk_HatST,
				// Token: 0x040025D9 RID: 9689
				Uniform_UniversityKiosk_TopAH = 65576U,
				// Token: 0x040025DA RID: 9690
				Uniform_UniversityKiosk_TopST,
				// Token: 0x040025DB RID: 9691
				Uniform_UniversityStudent = 65555U,
				// Token: 0x040025DC RID: 9692
				Uniform_UniversityStudent_Arts = 65584U,
				// Token: 0x040025DD RID: 9693
				Uniform_UniversityStudent_Science,
				// Token: 0x040025DE RID: 9694
				Uniform_WardrobePedestal_Stylist = 61466U,
				// Token: 0x040025DF RID: 9695
				Uniform_WasteManager = 67642U,
				// Token: 0x040025E0 RID: 9696
				Uniform_Weirdo = 55307U,
				// Token: 0x040025E1 RID: 9697
				Uniform_VendingMachine_PaperHat = 69681U,
				// Token: 0x040025E2 RID: 9698
				Uniform_VendingMachine_SnowOutfit,
				// Token: 0x040025E3 RID: 9699
				Uniform_VendingMachine_Yukata = 69680U,
				// Token: 0x040025E4 RID: 9700
				Uniform_Vet = 57398U,
				// Token: 0x040025E5 RID: 9701
				Uniform_VFXMachine_Operator = 61629U,
				// Token: 0x040025E6 RID: 9702
				Uniform_Villain = 611U,
				// Token: 0x040025E7 RID: 9703
				Uniform_Windenburg_Barista = 24603U,
				// Token: 0x040025E8 RID: 9704
				Uniform_VIPRope_Bouncer = 61478U,
				// Token: 0x040025E9 RID: 9705
				Uniform_Witch = 8202U,
				// Token: 0x040025EA RID: 9706
				Uniform_YogaInstructor = 18445U,
				// Token: 0x040025EB RID: 9707
				WallPattern_Masonry = 412U,
				// Token: 0x040025EC RID: 9708
				WallPattern_Misc = 415U,
				// Token: 0x040025ED RID: 9709
				WallPattern_Paint = 408U,
				// Token: 0x040025EE RID: 9710
				WallPattern_Paneling = 411U,
				// Token: 0x040025EF RID: 9711
				WallPattern_RockAndStone = 413U,
				// Token: 0x040025F0 RID: 9712
				WallPattern_Siding,
				// Token: 0x040025F1 RID: 9713
				WallPattern_Tile = 410U,
				// Token: 0x040025F2 RID: 9714
				WallPattern_Wallpaper = 409U,
				// Token: 0x040025F3 RID: 9715
				Venue_Object_Bench = 598U,
				// Token: 0x040025F4 RID: 9716
				Venue_Object_Chair = 961U,
				// Token: 0x040025F5 RID: 9717
				Venue_Object_Exercise = 601U,
				// Token: 0x040025F6 RID: 9718
				Venue_Object_Locker = 1443U,
				// Token: 0x040025F7 RID: 9719
				Venue_Object_Microphone = 597U,
				// Token: 0x040025F8 RID: 9720
				Venue_Object_MonkeyBars = 599U,
				// Token: 0x040025F9 RID: 9721
				Venue_Object_OnsenLocker = 69661U,
				// Token: 0x040025FA RID: 9722
				Venue_Object_Painting = 595U,
				// Token: 0x040025FB RID: 9723
				Venue_Object_PatioTable = 602U,
				// Token: 0x040025FC RID: 9724
				Venue_Object_Playground = 600U,
				// Token: 0x040025FD RID: 9725
				Venue_Object_Relaxation = 18443U,
				// Token: 0x040025FE RID: 9726
				Venue_Object_Sculpture = 596U,
				// Token: 0x040025FF RID: 9727
				WorldLog_NotInteractive = 1985U
			}
		}
	}
}
