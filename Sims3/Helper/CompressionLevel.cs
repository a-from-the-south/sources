using System;

namespace Package.Helper
{
	// Token: 0x020000D5 RID: 213
	public class CompressionLevel
	{
		// Token: 0x06000B62 RID: 2914 RVA: 0x0000844A File Offset: 0x0000664A
		public CompressionLevel(int blockInterval, int searchLength, int prequeueLength, int queueLength, int sameValToTrack, int bruteForceLength)
		{
			this.BlockInterval = blockInterval;
			this.SearchLength = searchLength;
			this.PrequeueLength = prequeueLength;
			this.QueueLength = queueLength;
			this.SameValToTrack = sameValToTrack;
			this.BruteForceLength = bruteForceLength;
		}

		// Token: 0x06000B63 RID: 2915 RVA: 0x000382F0 File Offset: 0x000364F0
		public CompressionLevel(int blockInterval, int searchLength, int sameValToTrack, int bruteForceLength)
		{
			this.BlockInterval = blockInterval;
			this.SearchLength = searchLength;
			this.PrequeueLength = this.SearchLength / this.BlockInterval;
			this.QueueLength = 131000 / this.BlockInterval - this.PrequeueLength;
			this.SameValToTrack = sameValToTrack;
			this.BruteForceLength = bruteForceLength;
		}

		// Token: 0x0400056C RID: 1388
		public static readonly CompressionLevel Max = new CompressionLevel(1, 1, 10, 64);

		// Token: 0x0400056D RID: 1389
		public readonly int BlockInterval;

		// Token: 0x0400056E RID: 1390
		public readonly int SearchLength;

		// Token: 0x0400056F RID: 1391
		public readonly int PrequeueLength;

		// Token: 0x04000570 RID: 1392
		public readonly int QueueLength;

		// Token: 0x04000571 RID: 1393
		public readonly int SameValToTrack;

		// Token: 0x04000572 RID: 1394
		public readonly int BruteForceLength;
	}
}
