using System;

namespace Package.Sims3Files
{
	// Token: 0x0200001F RID: 31
	public enum PartitionFlags : uint
	{
		// Token: 0x040000C4 RID: 196
		MayChangeSurface = 1U,
		// Token: 0x040000C5 RID: 197
		MayAttachObjects,
		// Token: 0x040000C6 RID: 198
		MayCutAway = 4U,
		// Token: 0x040000C7 RID: 199
		RequiresFlatBottom = 8U,
		// Token: 0x040000C8 RID: 200
		RequiresFlatTop = 16U,
		// Token: 0x040000C9 RID: 201
		Submersible = 32U,
		// Token: 0x040000CA RID: 202
		MayPlaceDiagonally = 64U,
		// Token: 0x040000CB RID: 203
		BlocksLocomotion = 128U,
		// Token: 0x040000CC RID: 204
		BlocksPlacement = 256U,
		// Token: 0x040000CD RID: 205
		BearsLoad = 512U,
		// Token: 0x040000CE RID: 206
		BlocksLight = 1024U,
		// Token: 0x040000CF RID: 207
		ShouldRender = 2048U,
		// Token: 0x040000D0 RID: 208
		RequiresSupportUnderneath = 4096U,
		// Token: 0x040000D1 RID: 209
		LitIndoors = 8192U,
		// Token: 0x040000D2 RID: 210
		LitOutdoors = 16384U,
		// Token: 0x040000D3 RID: 211
		AOMapped = 32768U,
		// Token: 0x040000D4 RID: 212
		MayCutAwayBelowGround = 65536U
	}
}
