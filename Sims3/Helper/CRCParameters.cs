using System;

namespace Package.Helper
{
	// Token: 0x020000DA RID: 218
	public class CRCParameters : HashAlgorithmParameters
	{
		// Token: 0x170003B5 RID: 949
		// (get) Token: 0x06000B7D RID: 2941 RVA: 0x000084B6 File Offset: 0x000066B6
		// (set) Token: 0x06000B7E RID: 2942 RVA: 0x000084BE File Offset: 0x000066BE
		public int Order
		{
			get
			{
				return this.order;
			}
			set
			{
				if (value % 8 != 0 || value < 8 || value > 64)
				{
					throw new ArgumentOutOfRangeException("Order", value, "CRC Order must represent full bytes and be between 8 and 64.");
				}
				this.order = value;
			}
		}

		// Token: 0x170003B6 RID: 950
		// (get) Token: 0x06000B7F RID: 2943 RVA: 0x000084EB File Offset: 0x000066EB
		// (set) Token: 0x06000B80 RID: 2944 RVA: 0x000084F3 File Offset: 0x000066F3
		public long Polynomial
		{
			get
			{
				return this.polynomial;
			}
			set
			{
				this.polynomial = value;
			}
		}

		// Token: 0x170003B7 RID: 951
		// (get) Token: 0x06000B81 RID: 2945 RVA: 0x000084FC File Offset: 0x000066FC
		// (set) Token: 0x06000B82 RID: 2946 RVA: 0x00008504 File Offset: 0x00006704
		public long InitialValue
		{
			get
			{
				return this.initial;
			}
			set
			{
				this.initial = value;
			}
		}

		// Token: 0x170003B8 RID: 952
		// (get) Token: 0x06000B83 RID: 2947 RVA: 0x0000850D File Offset: 0x0000670D
		// (set) Token: 0x06000B84 RID: 2948 RVA: 0x00008515 File Offset: 0x00006715
		public long FinalXORValue
		{
			get
			{
				return this.finalXOR;
			}
			set
			{
				this.finalXOR = value;
			}
		}

		// Token: 0x170003B9 RID: 953
		// (get) Token: 0x06000B85 RID: 2949 RVA: 0x0000851E File Offset: 0x0000671E
		// (set) Token: 0x06000B86 RID: 2950 RVA: 0x00008526 File Offset: 0x00006726
		public bool ReflectInput
		{
			get
			{
				return this.reflectIn;
			}
			set
			{
				this.reflectIn = value;
			}
		}

		// Token: 0x06000B87 RID: 2951 RVA: 0x0000852F File Offset: 0x0000672F
		public CRCParameters(int order, long polynomial, long initial, long finalXOR, bool reflectIn)
		{
			this.Order = order;
			this.Polynomial = polynomial;
			this.InitialValue = initial;
			this.FinalXORValue = finalXOR;
			this.ReflectInput = reflectIn;
		}

		// Token: 0x06000B88 RID: 2952 RVA: 0x00039AFC File Offset: 0x00037CFC
		public override int GetHashCode()
		{
			return string.Concat(new string[]
			{
				this.Polynomial.ToString(),
				":",
				this.Order.ToString(),
				":",
				this.ReflectInput.ToString()
			}).GetHashCode();
		}

		// Token: 0x06000B89 RID: 2953 RVA: 0x00039B5C File Offset: 0x00037D5C
		public static CRCParameters GetParameters(CRCStandard standard)
		{
			CRCParameters result;
			switch (standard)
			{
			case CRCStandard.CRC8:
				result = new CRCParameters(8, 224L, 0L, 0L, false);
				break;
			case CRCStandard.CRC8_REVERSED:
				result = new CRCParameters(8, 7L, 0L, 0L, true);
				break;
			case CRCStandard.CRC16:
				result = new CRCParameters(16, 32773L, 0L, 0L, false);
				break;
			case CRCStandard.CRC16_REVERSED:
				result = new CRCParameters(16, 40961L, 0L, 0L, true);
				break;
			case CRCStandard.CRC16_CCITT:
				result = new CRCParameters(16, 4129L, 65535L, 0L, false);
				break;
			case CRCStandard.CRC16_CCITT_REVERSED:
				result = new CRCParameters(16, 33800L, 0L, 0L, true);
				break;
			case CRCStandard.CRC24:
				result = new CRCParameters(24, 25578747L, 11994318L, 0L, false);
				break;
			case CRCStandard.CRC32:
				result = new CRCParameters(32, 3988292384L, 4294967295L, 4294967295L, false);
				break;
			case CRCStandard.CRC32_REVERSED:
				result = new CRCParameters(32, 79764919L, 4294967295L, 4294967295L, true);
				break;
			case CRCStandard.CRC16_ARC:
				result = new CRCParameters(16, 32773L, 0L, 0L, true);
				break;
			case CRCStandard.CRC16_ZMODEM:
				result = new CRCParameters(16, 4129L, 0L, 0L, false);
				break;
			case CRCStandard.CRC32_JAMCRC:
				result = new CRCParameters(32, 79764919L, 4294967295L, 0L, true);
				break;
			case CRCStandard.CRC32_BZIP2:
				result = new CRCParameters(32, 79764919L, 4294967295L, 4294967295L, false);
				break;
			default:
				result = new CRCParameters(32, 79764919L, 4294967295L, 4294967295L, true);
				break;
			}
			return result;
		}

		// Token: 0x0400057B RID: 1403
		private int order;

		// Token: 0x0400057C RID: 1404
		private long polynomial;

		// Token: 0x0400057D RID: 1405
		private long initial;

		// Token: 0x0400057E RID: 1406
		private long finalXOR;

		// Token: 0x0400057F RID: 1407
		private bool reflectIn;
	}
}
