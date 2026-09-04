using System;
using System.Collections.Generic;
using System.ComponentModel;
using Sims3WorkshopSDK;

namespace Package.SharedFiles
{
	// Token: 0x020000AA RID: 170
	public interface IObjd
	{
		// Token: 0x170002C5 RID: 709
		// (get) Token: 0x06000856 RID: 2134
		// (set) Token: 0x06000857 RID: 2135
		[TypeConverter(typeof(IntTypeConverter))]
		uint BuildCategoryFlags { get; set; }

		// Token: 0x170002C6 RID: 710
		// (get) Token: 0x06000858 RID: 2136
		// (set) Token: 0x06000859 RID: 2137
		string CatalogNameEntry { get; set; }

		// Token: 0x170002C7 RID: 711
		// (get) Token: 0x0600085A RID: 2138
		// (set) Token: 0x0600085B RID: 2139
		string CatalogDescEntry { get; set; }

		// Token: 0x170002C8 RID: 712
		// (get) Token: 0x0600085C RID: 2140
		// (set) Token: 0x0600085D RID: 2141
		string DAEFilename { get; set; }

		// Token: 0x170002C9 RID: 713
		// (get) Token: 0x0600085E RID: 2142
		// (set) Token: 0x0600085F RID: 2143
		[TypeConverter(typeof(IntTypeConverter))]
		long NameGuid { get; set; }

		// Token: 0x170002CA RID: 714
		// (get) Token: 0x06000860 RID: 2144
		// (set) Token: 0x06000861 RID: 2145
		[TypeConverter(typeof(IntTypeConverter))]
		long DescGuid { get; set; }

		// Token: 0x170002CB RID: 715
		// (get) Token: 0x06000862 RID: 2146
		// (set) Token: 0x06000863 RID: 2147
		List<TGIIndex> TgiIndex { get; set; }

		// Token: 0x170002CC RID: 716
		// (get) Token: 0x06000864 RID: 2148
		// (set) Token: 0x06000865 RID: 2149
		[TypeConverter(typeof(IntTypeConverter))]
		uint Version { get; set; }

		// Token: 0x170002CD RID: 717
		// (get) Token: 0x06000866 RID: 2150
		// (set) Token: 0x06000867 RID: 2151
		[TypeConverter(typeof(IntTypeConverter))]
		uint CategoryFlags { get; set; }

		// Token: 0x170002CE RID: 718
		// (get) Token: 0x06000868 RID: 2152
		// (set) Token: 0x06000869 RID: 2153
		[TypeConverter(typeof(IntTypeConverter))]
		ulong SubRoomFlags { get; set; }

		// Token: 0x170002CF RID: 719
		// (get) Token: 0x0600086A RID: 2154
		// (set) Token: 0x0600086B RID: 2155
		[TypeConverter(typeof(IntTypeConverter))]
		ulong SubCategoryFlags { get; set; }

		// Token: 0x170002D0 RID: 720
		// (get) Token: 0x0600086C RID: 2156
		// (set) Token: 0x0600086D RID: 2157
		[TypeConverter(typeof(IntTypeConverter))]
		ulong SubCategoryFlags2 { get; set; }

		// Token: 0x170002D1 RID: 721
		// (get) Token: 0x0600086E RID: 2158
		// (set) Token: 0x0600086F RID: 2159
		[TypeConverter(typeof(IntTypeConverter))]
		uint RoomFlags { get; set; }

		// Token: 0x170002D2 RID: 722
		// (get) Token: 0x06000870 RID: 2160
		// (set) Token: 0x06000871 RID: 2161
		[TypeConverter(typeof(IntTypeConverter))]
		long PngIcon { get; set; }

		// Token: 0x06000872 RID: 2162
		List<OBJD.Build> GetBuildFlags();

		// Token: 0x06000873 RID: 2163
		List<OBJD.Room> GetRoomFlags();

		// Token: 0x06000874 RID: 2164
		List<OBJD.SubRoom> GetSubRoomFlags();

		// Token: 0x06000875 RID: 2165
		List<OBJD.Category> GetCategoryFlags();

		// Token: 0x06000876 RID: 2166
		List<OBJD.SubCategory> GetSubCategoryFlags();

		// Token: 0x06000877 RID: 2167
		List<OBJD.SubCategory2> GetSubCategoryFlags2();
	}
}
