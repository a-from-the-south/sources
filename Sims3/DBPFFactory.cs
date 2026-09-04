using System;
using Package.ImageResource;
using Package.SharedFiles;
using Package.SimCity;
using Package.Sims2Files;
using Package.Sims3Files;
using Package.Sims4Files;
using Sims3WorkshopSDK;

namespace Package
{
	// Token: 0x02000008 RID: 8
	public class DBPFFactory
	{
		// Token: 0x0600007C RID: 124 RVA: 0x0000D8EC File Offset: 0x0000BAEC
		public static bool IsImage(DBPFType typeId)
		{
			if (typeId <= 796721156)
			{
				if (typeId <= 95532326)
				{
					if (typeId <= 92316367)
					{
						if (typeId - 92316340 <= 2 || typeId - 92316365 <= 2)
						{
							return true;
						}
					}
					else if (typeId - 92920900 <= 2 || typeId - 95516312 <= 2 || typeId - 95532324 <= 2)
					{
						return true;
					}
				}
				else if (typeId <= 643032010)
				{
					if (typeId == 382531400 || typeId - 643032008 <= 2)
					{
						return true;
					}
				}
				else if (typeId - 759334128 <= 2 || typeId - 779470692 <= 2 || typeId == 796721156)
				{
					return true;
				}
			}
			else if (typeId <= 1575607202)
			{
				if (typeId <= 1009419847)
				{
					if (typeId == 796721159 || typeId == 1009419847)
					{
						return true;
					}
				}
				else if (typeId == 1047906150 || typeId == 1065771754 || typeId - 1575607200 <= 2)
				{
					return true;
				}
			}
			else if (typeId <= -666665017)
			{
				if (typeId - 1651466444 <= 2 || typeId - 1802339197 <= 2 || typeId == -666665017)
				{
					return true;
				}
			}
			else
			{
				if (typeId == -510873886 || typeId == -497766813)
				{
					return true;
				}
				if (typeId == -51726757)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x0600007D RID: 125 RVA: 0x0000DA2C File Offset: 0x0000BC2C
		public static bool IsXML(DBPFType typeId)
		{
			if (typeId <= 53690476)
			{
				if (typeId <= 39622070)
				{
					if (typeId == 39620774 || typeId == 39622070)
					{
						return true;
					}
				}
				else if (typeId == 39769844 || typeId == 53690476)
				{
					return true;
				}
			}
			else if (typeId <= 72016144)
			{
				if (typeId == 62078431 || typeId == 72016144)
				{
					return true;
				}
			}
			else
			{
				if (typeId == 1944665835)
				{
					return true;
				}
				if (typeId == -723911707)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x0600007E RID: 126 RVA: 0x00003314 File Offset: 0x00001514
		public static DBPFEntry GetInstance(uint typeId)
		{
			return DBPFFactory.GetInstance(typeId, 3);
		}

		// Token: 0x0600007F RID: 127 RVA: 0x0000DA9C File Offset: 0x0000BC9C
		public static DBPFEntry GetInstance(uint typeId, GameVersion gameVersion)
		{
			if (gameVersion == 4)
			{
				if (typeId <= 1659456824U)
				{
					if (typeId <= 799971390U)
					{
						if (typeId <= 305839257U)
						{
							if (typeId <= 55242443U)
							{
								if (typeId == 20281636U)
								{
									return new ObjectInfo();
								}
								if (typeId != 55242443U)
								{
									goto IL_305;
								}
								return new Package.Sims4Files.CASP();
							}
							else
							{
								if (typeId == 68746794U)
								{
									return new CFEN();
								}
								if (typeId == 123169303U)
								{
									return new MLCO();
								}
								if (typeId != 305839257U)
								{
									goto IL_305;
								}
								return new CustomizableResource();
							}
						}
						else if (typeId <= 493744591U)
						{
							if (typeId == 471658999U)
							{
								return new CRAL();
							}
							if (typeId != 493744591U)
							{
								goto IL_305;
							}
							return new CCOL();
						}
						else
						{
							if (typeId == 670978917U)
							{
								return new Shader();
							}
							if (typeId == 734023391U)
							{
								return new DXT5LRLE(typeId);
							}
							if (typeId != 799971390U)
							{
								goto IL_305;
							}
							return new CFND();
						}
					}
					else if (typeId <= 1051371644U)
					{
						if (typeId <= 877907861U)
						{
							if (typeId == 832458525U)
							{
								return new Package.Sims4Files.OBJD();
							}
							if (typeId != 877907861U)
							{
								goto IL_305;
							}
							return new DXT5RLE2(typeId);
						}
						else if (typeId != 1003770887U && typeId != 1008398834U)
						{
							if (typeId != 1051371644U)
							{
								goto IL_305;
							}
							return new LDNB();
						}
					}
					else if (typeId <= 1445430612U)
					{
						if (typeId == 1415235194U)
						{
							return new SimData();
						}
						if (typeId != 1445430612U)
						{
							goto IL_305;
						}
					}
					else if (typeId != 1529359685U)
					{
						if (typeId == 1612179606U)
						{
							return new SOMEIMAGE();
						}
						if (typeId != 1659456824U)
						{
							goto IL_305;
						}
						return new CombinedTuning();
					}
				}
				else if (typeId <= 2887187436U)
				{
					if (typeId <= 2626836499U)
					{
						if (typeId <= 2177505808U)
						{
							if (typeId == 1992095756U)
							{
								return new Trim();
							}
							if (typeId != 2177505808U)
							{
								goto IL_305;
							}
							return new MTBL();
						}
						else
						{
							if (typeId == 2227319321U)
							{
								return new CXTR();
							}
							if (typeId == 2585840924U)
							{
								return new CSTR();
							}
							if (typeId != 2626836499U)
							{
								goto IL_305;
							}
						}
					}
					else if (typeId <= 2673671952U)
					{
						if (typeId == 2635774068U)
						{
							return new CaspResource(typeId);
						}
						if (typeId != 2673671952U)
						{
							goto IL_305;
						}
						return new StyleResource();
					}
					else
					{
						if (typeId == 2690089244U)
						{
							return new CFRZ();
						}
						if (typeId == 2782919923U)
						{
							return new CPLT();
						}
						if (typeId != 2887187436U)
						{
							goto IL_305;
						}
						return new Package.Sims4Files.VisualProxy();
					}
				}
				else if (typeId <= 3321263678U)
				{
					if (typeId <= 3036111561U)
					{
						if (typeId == 2956008719U)
						{
							return new CRTR();
						}
						if (typeId != 3036111561U)
						{
							goto IL_305;
						}
						return new CFLOOR();
					}
					else
					{
						if (typeId == 3129306232U)
						{
							return new DXT5RLES(typeId);
						}
						if (typeId == 3235601127U)
						{
							return new OBJDDef();
						}
						if (typeId != 3321263678U)
						{
							goto IL_305;
						}
						return new SimModifier();
					}
				}
				else if (typeId <= 3678658665U)
				{
					if (typeId != 3449676359U)
					{
						if (typeId == 3589339425U)
						{
							return new Package.Sims4Files.CWALL();
						}
						if (typeId != 3678658665U)
						{
							goto IL_305;
						}
						return new DeformMap();
					}
				}
				else
				{
					if (typeId == 3936561885U)
					{
						return new SomeTS4File();
					}
					if (typeId == 3955994988U)
					{
						return new CTPT();
					}
					if (typeId != 4058889606U)
					{
						goto IL_305;
					}
					return new CROOF();
				}
				return new JPEG(typeId);
			}
			IL_305:
			if (typeId <= 686726456U)
			{
				if (typeId <= 62178845U)
				{
					if (typeId > 39622070U)
					{
						if (typeId <= 54137909U)
						{
							if (typeId <= 47570707U)
							{
								if (typeId == 39769844U)
								{
									return new XML_MB_2(typeId);
								}
								if (typeId == 42082293U)
								{
									goto IL_A16;
								}
								if (typeId != 47570707U)
								{
									goto IL_A33;
								}
								return new JAZZ();
							}
							else
							{
								if (typeId == 47985727U)
								{
									return new OBJK();
								}
								if (typeId == 53690476U)
								{
									return new Preset();
								}
								if (typeId != 54137909U)
								{
									goto IL_A33;
								}
							}
						}
						else if (typeId <= 55867754U)
						{
							if (typeId != 54635721U)
							{
								if (typeId == 55242443U)
								{
									return new Package.Sims3Files.CASP();
								}
								if (typeId != 55867754U)
								{
									goto IL_A33;
								}
								return new SKINTONE();
							}
						}
						else if (typeId <= 56144010U)
						{
							if (typeId == 55959718U)
							{
								return new BOND(typeId);
							}
							if (typeId != 56144010U)
							{
								goto IL_A33;
							}
							goto IL_609;
						}
						else
						{
							if (typeId == 62078431U)
							{
								return new ObjXML();
							}
							if (typeId != 62178845U)
							{
								goto IL_A33;
							}
							return new LightResource();
						}
						return new TXTC(typeId);
					}
					if (typeId <= 23462796U)
					{
						if (typeId <= 11720834U)
						{
							if (typeId == 11431015U)
							{
								return new BONE();
							}
							if (typeId == 11645188U)
							{
								return new _00b1b104();
							}
							if (typeId != 11720834U)
							{
								goto IL_A33;
							}
							goto IL_91D;
						}
						else
						{
							if (typeId == 11883242U)
							{
								return new SpeedTree();
							}
							if (typeId == 22681673U)
							{
								return new Geometry(typeId);
							}
							if (typeId != 23462796U)
							{
								goto IL_A33;
							}
							return new NameMap();
						}
					}
					else if (typeId <= 30478132U)
					{
						if (typeId == 23466547U)
						{
							return new MODLModel(typeId);
						}
						if (typeId == 30467933U)
						{
							return new MATDResource();
						}
						if (typeId != 30478132U)
						{
							goto IL_A33;
						}
						return new MLODModel(typeId);
					}
					else
					{
						if (typeId == 33659250U)
						{
							return new MODLModel(typeId);
						}
						if (typeId != 39620774U && typeId != 39622070U)
						{
							goto IL_A33;
						}
						return new XML(typeId);
					}
				}
				else if (typeId <= 95516314U)
				{
					if (typeId <= 80052483U)
					{
						if (typeId <= 68746794U)
						{
							if (typeId == 64407769U)
							{
								goto IL_A16;
							}
							if (typeId == 64504770U)
							{
								return new CCACHE();
							}
							if (typeId != 68746794U)
							{
								goto IL_A33;
							}
							return new FENCE();
						}
						else
						{
							if (typeId == 72016144U)
							{
								return new XML_MB();
							}
							if (typeId == 77374669U)
							{
								return new STAIRS();
							}
							if (typeId != 80052483U)
							{
								goto IL_A33;
							}
							return new RAILING();
						}
					}
					else if (typeId <= 83086337U)
					{
						if (typeId == 81276304U)
						{
							return new PossibleFileIndex();
						}
						if (typeId == 82660274U)
						{
							return new TerrainPaint();
						}
						if (typeId != 83086337U)
						{
							goto IL_A33;
						}
						return new FirePlace();
					}
					else if (typeId <= 92316367U)
					{
						if (typeId - 92316340U > 2U && typeId - 92316365U > 2U)
						{
							goto IL_A33;
						}
						goto IL_A3A;
					}
					else
					{
						if (typeId - 92920900U > 2U && typeId - 95516312U > 2U)
						{
							goto IL_A33;
						}
						goto IL_A3A;
					}
				}
				else if (typeId <= 201803117U)
				{
					if (typeId <= 108833297U)
					{
						if (typeId - 95532324U <= 2U)
						{
							goto IL_A3A;
						}
						if (typeId != 103580164U)
						{
							if (typeId != 108833297U)
							{
								goto IL_A33;
							}
							return new BGEO();
						}
					}
					else
					{
						if (typeId == 121612807U)
						{
							goto IL_A16;
						}
						if (typeId == 137167721U)
						{
							return new Set();
						}
						if (typeId != 201803117U)
						{
							goto IL_A33;
						}
						return new COLL();
					}
				}
				else if (typeId <= 382531400U)
				{
					if (typeId == 201803423U)
					{
						return new COLO();
					}
					if (typeId == 216588355U)
					{
						goto IL_A16;
					}
					if (typeId != 382531400U)
					{
						goto IL_A33;
					}
					goto IL_A3A;
				}
				else if (typeId <= 570775514U)
				{
					if (typeId == 474621804U)
					{
						return new TXTR();
					}
					if (typeId != 570775514U)
					{
						goto IL_A33;
					}
					return new STBL();
				}
				else
				{
					if (typeId - 643032008U <= 2U)
					{
						goto IL_A3A;
					}
					if (typeId != 686726456U)
					{
						goto IL_A33;
					}
					goto IL_A16;
				}
				IL_609:
				return new FPRT(typeId);
			}
			if (typeId <= 1987244229U)
			{
				if (typeId <= 1065771754U)
				{
					if (typeId <= 832458525U)
					{
						if (typeId <= 793667611U)
						{
							if (typeId - 759334128U <= 2U || typeId - 779470692U <= 2U)
							{
								goto IL_A3A;
							}
							if (typeId != 793667611U)
							{
								goto IL_A33;
							}
							return new RW4();
						}
						else
						{
							if (typeId == 796721156U)
							{
								goto IL_A3A;
							}
							if (typeId == 796721159U)
							{
								return new GIF(typeId);
							}
							if (typeId != 832458525U)
							{
								goto IL_A33;
							}
							return new Package.Sims3Files.OBJD();
						}
					}
					else if (typeId <= 1003770887U)
					{
						if (typeId == 875487299U)
						{
							goto IL_A16;
						}
						if (typeId == 887432316U)
						{
							return new Test();
						}
						if (typeId != 1003770887U)
						{
							goto IL_A33;
						}
					}
					else if (typeId <= 1009419847U)
					{
						if (typeId != 1008398834U)
						{
							if (typeId != 1009419847U)
							{
								goto IL_A33;
							}
							goto IL_A3A;
						}
					}
					else
					{
						if (typeId == 1047906150U)
						{
							goto IL_A3A;
						}
						if (typeId != 1065771754U)
						{
							goto IL_A33;
						}
					}
				}
				else if (typeId <= 1611636385U)
				{
					if (typeId <= 1445430612U)
					{
						if (typeId == 1230596472U)
						{
							return new TXMT();
						}
						if (typeId == 1365025997U)
						{
							return new WALL();
						}
						if (typeId != 1445430612U)
						{
							goto IL_A33;
						}
					}
					else if (typeId != 1529359685U)
					{
						if (typeId - 1575607200U <= 2U)
						{
							goto IL_A3A;
						}
						if (typeId != 1611636385U)
						{
							goto IL_A33;
						}
						goto IL_A16;
					}
				}
				else if (typeId <= 1797309683U)
				{
					if (typeId - 1651466444U <= 2U)
					{
						goto IL_A3A;
					}
					if (typeId == 1791033619U)
					{
						goto IL_A16;
					}
					if (typeId != 1797309683U)
					{
						goto IL_A33;
					}
					return new Clip();
				}
				else if (typeId <= 1936229617U)
				{
					if (typeId - 1802339197U <= 2U)
					{
						goto IL_A3A;
					}
					if (typeId != 1936229617U)
					{
						goto IL_A33;
					}
					return new Package.Sims3Files.VisualProxy();
				}
				else
				{
					if (typeId == 1944665835U)
					{
						return new PackageDescriptor();
					}
					if (typeId != 1987244229U)
					{
						goto IL_A33;
					}
					return new DCCache();
				}
			}
			else if (typeId <= 3449676359U)
			{
				if (typeId <= 2626836499U)
				{
					if (typeId <= 2393838558U)
					{
						if (typeId == 2026859765U)
						{
							goto IL_A16;
						}
						if (typeId == 2074313612U)
						{
							return new GMND();
						}
						if (typeId != 2393838558U)
						{
							goto IL_A33;
						}
						return new RIG();
					}
					else
					{
						if (typeId == 2393838559U)
						{
							return new RIGRAW();
						}
						if (typeId == 2438063804U)
						{
							return new CWST();
						}
						if (typeId != 2626836499U)
						{
							goto IL_A33;
						}
					}
				}
				else if (typeId <= 3066607264U)
				{
					if (typeId == 2890892935U)
					{
						return new GMDC();
					}
					if (typeId == 2895650412U)
					{
						goto IL_A16;
					}
					if (typeId != 3066607264U)
					{
						goto IL_A33;
					}
					goto IL_91D;
				}
				else if (typeId <= 3219205114U)
				{
					if (typeId == 3116961756U)
					{
						goto IL_A16;
					}
					if (typeId != 3219205114U)
					{
						goto IL_A33;
					}
					return new TSRModel();
				}
				else
				{
					if (typeId == 3277250409U)
					{
						goto IL_A16;
					}
					if (typeId != 3449676359U)
					{
						goto IL_A33;
					}
				}
			}
			else if (typeId <= 3784093410U)
			{
				if (typeId <= 3548561239U)
				{
					if (typeId == 3482995406U)
					{
						return new MDLR();
					}
					if (typeId == 3540272417U)
					{
						return new RSLTResource();
					}
					if (typeId != 3548561239U)
					{
						goto IL_A33;
					}
					return new FTPTResource();
				}
				else
				{
					if (typeId == 3571055589U)
					{
						return new PatternList();
					}
					if (typeId != 3628302279U && typeId != 3784093410U)
					{
						goto IL_A33;
					}
					goto IL_A3A;
				}
			}
			else if (typeId <= 4043265432U)
			{
				if (typeId == 3797200483U)
				{
					goto IL_A3A;
				}
				if (typeId == 3843672371U)
				{
					return new CRES();
				}
				if (typeId != 4043265432U)
				{
					goto IL_A33;
				}
				return new Text();
			}
			else if (typeId <= 4156796392U)
			{
				if (typeId == 4058889606U)
				{
					return new ROOF();
				}
				if (typeId != 4156796392U)
				{
					goto IL_A33;
				}
				goto IL_A16;
			}
			else
			{
				if (typeId == 4235112951U)
				{
					return new SHPE();
				}
				if (typeId != 4243240539U)
				{
					goto IL_A33;
				}
				goto IL_A3A;
			}
			return new JPEG(typeId);
			IL_91D:
			return new DDS(typeId);
			IL_A16:
			return new SCRIPT(typeId);
			IL_A33:
			return new UnknownDBPFEntry(typeId);
			IL_A3A:
			return new PNG(typeId);
		}
	}
}
