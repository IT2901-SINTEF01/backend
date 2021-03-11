using System.Collections.Generic;

namespace Backend.utils
{
    public static class NorwayTools
    {
        public static readonly Dictionary<string, int> MunicipalityCodeToIndex = new()
        {
            {"K-3001", 0},
            {"K-3002", 1},
            {"K-3003", 2},
            {"K-3004", 3},
            {"K-3005", 4},
            {"K-3006", 5},
            {"K-3007", 6},
            {"K-3011", 7},
            {"K-3012", 8},
            {"K-3013", 9},
            {"K-3014", 10},
            {"K-3015", 11},
            {"K-3016", 12},
            {"K-3017", 13},
            {"K-3018", 14},
            {"K-3019", 15},
            {"K-3020", 16},
            {"K-3021", 17},
            {"K-3022", 18},
            {"K-3023", 19},
            {"K-3024", 20},
            {"K-3025", 21},
            {"K-3026", 22},
            {"K-3027", 23},
            {"K-3028", 24},
            {"K-3029", 25},
            {"K-3030", 26},
            {"K-3031", 27},
            {"K-3032", 28},
            {"K-3033", 29},
            {"K-3034", 30},
            {"K-3035", 31},
            {"K-3036", 32},
            {"K-3037", 33},
            {"K-3038", 34},
            {"K-3039", 35},
            {"K-3040", 36},
            {"K-3041", 37},
            {"K-3042", 38},
            {"K-3043", 39},
            {"K-3044", 40},
            {"K-3045", 41},
            {"K-3046", 42},
            {"K-3047", 43},
            {"K-3048", 44},
            {"K-3049", 45},
            {"K-3050", 46},
            {"K-3051", 47},
            {"K-3052", 48},
            {"K-3053", 49},
            {"K-3054", 50},
            {"K-0301", 51},
            {"K-3401", 52},
            {"K-3403", 53},
            {"K-3405", 54},
            {"K-3407", 55},
            {"K-3411", 56},
            {"K-3412", 57},
            {"K-3413", 58},
            {"K-3414", 59},
            {"K-3415", 60},
            {"K-3416", 61},
            {"K-3417", 62},
            {"K-3418", 63},
            {"K-3419", 64},
            {"K-3420", 65},
            {"K-3421", 66},
            {"K-3422", 67},
            {"K-3423", 68},
            {"K-3424", 69},
            {"K-3425", 70},
            {"K-3426", 71},
            {"K-3427", 72},
            {"K-3428", 73},
            {"K-3429", 74},
            {"K-3430", 75},
            {"K-3431", 76},
            {"K-3432", 77},
            {"K-3433", 78},
            {"K-3434", 79},
            {"K-3435", 80},
            {"K-3436", 81},
            {"K-3437", 82},
            {"K-3438", 83},
            {"K-3439", 84},
            {"K-3440", 85},
            {"K-3441", 86},
            {"K-3442", 87},
            {"K-3443", 88},
            {"K-3446", 89},
            {"K-3447", 90},
            {"K-3448", 91},
            {"K-3449", 92},
            {"K-3450", 93},
            {"K-3451", 94},
            {"K-3452", 95},
            {"K-3453", 96},
            {"K-3454", 97},
            {"K-3801", 98},
            {"K-3802", 99},
            {"K-3803", 100},
            {"K-3804", 101},
            {"K-3805", 102},
            {"K-3806", 103},
            {"K-3807", 104},
            {"K-3808", 105},
            {"K-3811", 106},
            {"K-3812", 107},
            {"K-3813", 108},
            {"K-3814", 109},
            {"K-3815", 110},
            {"K-3816", 111},
            {"K-3817", 112},
            {"K-3818", 113},
            {"K-3819", 114},
            {"K-3820", 115},
            {"K-3821", 116},
            {"K-3822", 117},
            {"K-3823", 118},
            {"K-3824", 119},
            {"K-3825", 120},
            {"K-4201", 121},
            {"K-4202", 122},
            {"K-4203", 123},
            {"K-4204", 124},
            {"K-4205", 125},
            {"K-4206", 126},
            {"K-4207", 127},
            {"K-4211", 128},
            {"K-4212", 129},
            {"K-4213", 130},
            {"K-4214", 131},
            {"K-4215", 132},
            {"K-4216", 133},
            {"K-4217", 134},
            {"K-4218", 135},
            {"K-4219", 136},
            {"K-4220", 137},
            {"K-4221", 138},
            {"K-4222", 139},
            {"K-4223", 140},
            {"K-4224", 141},
            {"K-4225", 142},
            {"K-4226", 143},
            {"K-4227", 144},
            {"K-4228", 145},
            {"K-1101", 146},
            {"K-1103", 147},
            {"K-1106", 148},
            {"K-1108", 149},
            {"K-1111", 150},
            {"K-1112", 151},
            {"K-1114", 152},
            {"K-1119", 153},
            {"K-1120", 154},
            {"K-1121", 155},
            {"K-1122", 156},
            {"K-1124", 157},
            {"K-1127", 158},
            {"K-1130", 159},
            {"K-1133", 160},
            {"K-1134", 161},
            {"K-1135", 162},
            {"K-1144", 163},
            {"K-1145", 164},
            {"K-1146", 165},
            {"K-1149", 166},
            {"K-1151", 167},
            {"K-1160", 168},
            {"K-4601", 169},
            {"K-4602", 170},
            {"K-4611", 171},
            {"K-4612", 172},
            {"K-4613", 173},
            {"K-4614", 174},
            {"K-4615", 175},
            {"K-4616", 176},
            {"K-4617", 177},
            {"K-4618", 178},
            {"K-4619", 179},
            {"K-4620", 180},
            {"K-4621", 181},
            {"K-4622", 182},
            {"K-4623", 183},
            {"K-4624", 184},
            {"K-4625", 185},
            {"K-4626", 186},
            {"K-4627", 187},
            {"K-4628", 188},
            {"K-4629", 189},
            {"K-4630", 190},
            {"K-4631", 191},
            {"K-4632", 192},
            {"K-4633", 193},
            {"K-4634", 194},
            {"K-4635", 195},
            {"K-4636", 196},
            {"K-4637", 197},
            {"K-4638", 198},
            {"K-4639", 199},
            {"K-4640", 200},
            {"K-4641", 201},
            {"K-4642", 202},
            {"K-4643", 203},
            {"K-4644", 204},
            {"K-4645", 205},
            {"K-4646", 206},
            {"K-4647", 207},
            {"K-4648", 208},
            {"K-4649", 209},
            {"K-4650", 210},
            {"K-4651", 211},
            {"K-1505", 212},
            {"K-1506", 213},
            {"K-1507", 214},
            {"K-1511", 215},
            {"K-1514", 216},
            {"K-1515", 217},
            {"K-1516", 218},
            {"K-1517", 219},
            {"K-1520", 220},
            {"K-1525", 221},
            {"K-1528", 222},
            {"K-1531", 223},
            {"K-1532", 224},
            {"K-1535", 225},
            {"K-1539", 226},
            {"K-1547", 227},
            {"K-1554", 228},
            {"K-1557", 229},
            {"K-1560", 230},
            {"K-1563", 231},
            {"K-1566", 232},
            {"K-1573", 233},
            {"K-1576", 234},
            {"K-1577", 235},
            {"K-1578", 236},
            {"K-1579", 237},
            {"K-5001", 238},
            {"K-5006", 239},
            {"K-5007", 240},
            {"K-5014", 241},
            {"K-5020", 242},
            {"K-5021", 243},
            {"K-5022", 244},
            {"K-5025", 245},
            {"K-5026", 246},
            {"K-5027", 247},
            {"K-5028", 248},
            {"K-5029", 249},
            {"K-5031", 250},
            {"K-5032", 251},
            {"K-5033", 252},
            {"K-5034", 253},
            {"K-5035", 254},
            {"K-5036", 255},
            {"K-5037", 256},
            {"K-5038", 257},
            {"K-5041", 258},
            {"K-5042", 259},
            {"K-5043", 260},
            {"K-5044", 261},
            {"K-5045", 262},
            {"K-5046", 263},
            {"K-5047", 264},
            {"K-5049", 265},
            {"K-5052", 266},
            {"K-5053", 267},
            {"K-5054", 268},
            {"K-5055", 269},
            {"K-5056", 270},
            {"K-5057", 271},
            {"K-5058", 272},
            {"K-5059", 273},
            {"K-5060", 274},
            {"K-5061", 275},
            {"K-1804", 276},
            {"K-1806", 277},
            {"K-1811", 278},
            {"K-1812", 279},
            {"K-1813", 280},
            {"K-1815", 281},
            {"K-1816", 282},
            {"K-1818", 283},
            {"K-1820", 284},
            {"K-1822", 285},
            {"K-1824", 286},
            {"K-1825", 287},
            {"K-1826", 288},
            {"K-1827", 289},
            {"K-1828", 290},
            {"K-1832", 291},
            {"K-1833", 292},
            {"K-1834", 293},
            {"K-1835", 294},
            {"K-1836", 295},
            {"K-1837", 296},
            {"K-1838", 297},
            {"K-1839", 298},
            {"K-1840", 299},
            {"K-1841", 300},
            {"K-1845", 301},
            {"K-1848", 302},
            {"K-1851", 303},
            {"K-1853", 304},
            {"K-1856", 305},
            {"K-1857", 306},
            {"K-1859", 307},
            {"K-1860", 308},
            {"K-1865", 309},
            {"K-1866", 310},
            {"K-1867", 311},
            {"K-1868", 312},
            {"K-1870", 313},
            {"K-1871", 314},
            {"K-1874", 315},
            {"K-1875", 316},
            {"K-5401", 317},
            {"K-5402", 318},
            {"K-5403", 319},
            {"K-5404", 320},
            {"K-5405", 321},
            {"K-5406", 322},
            {"K-5411", 323},
            {"K-5412", 324},
            {"K-5413", 325},
            {"K-5414", 326},
            {"K-5415", 327},
            {"K-5416", 328},
            {"K-5417", 329},
            {"K-5418", 330},
            {"K-5419", 331},
            {"K-5420", 332},
            {"K-5421", 333},
            {"K-5422", 334},
            {"K-5423", 335},
            {"K-5424", 336},
            {"K-5425", 337},
            {"K-5426", 338},
            {"K-5427", 339},
            {"K-5428", 340},
            {"K-5429", 341},
            {"K-5430", 342},
            {"K-5432", 343},
            {"K-5433", 344},
            {"K-5434", 345},
            {"K-5435", 346},
            {"K-5436", 347},
            {"K-5437", 348},
            {"K-5438", 349},
            {"K-5439", 350},
            {"K-5440", 351},
            {"K-5441", 352},
            {"K-5442", 353},
            {"K-5443", 354},
            {"K-5444", 355},
            {"K-21-22", 356},
            {"K-23", 357},
            {"K-Rest", 358}
        };

        public static readonly Dictionary<string, string> MunicipalityCodeToMunicipalityName = new()
        {
            {"K-3001", "Halden"},
            {"K-3002", "Moss"},
            {"K-3003", "Sarpsborg"},
            {"K-3004", "Fredrikstad"},
            {"K-3005", "Drammen"},
            {"K-3006", "Kongsberg"},
            {"K-3007", "Ringerike"},
            {"K-3011", "Hvaler"},
            {"K-3012", "Aremark"},
            {"K-3013", "Marker"},
            {"K-3014", "Indre Østfold"},
            {"K-3015", "Skiptvet"},
            {"K-3016", "Rakkestad"},
            {"K-3017", "Råde"},
            {"K-3018", "Våler (Viken)"},
            {"K-3019", "Vestby"},
            {"K-3020", "Nordre Follo"},
            {"K-3021", "Ås"},
            {"K-3022", "Frogn"},
            {"K-3023", "Nesodden"},
            {"K-3024", "Bærum"},
            {"K-3025", "Asker"},
            {"K-3026", "Aurskog-Høland"},
            {"K-3027", "Rælingen"},
            {"K-3028", "Enebakk"},
            {"K-3029", "Lørenskog"},
            {"K-3030", "Lillestrøm"},
            {"K-3031", "Nittedal"},
            {"K-3032", "Gjerdrum"},
            {"K-3033", "Ullensaker"},
            {"K-3034", "Nes"},
            {"K-3035", "Eidsvoll"},
            {"K-3036", "Nannestad"},
            {"K-3037", "Hurdal"},
            {"K-3038", "Hole"},
            {"K-3039", "Flå"},
            {"K-3040", "Nesbyen"},
            {"K-3041", "Gol"},
            {"K-3042", "Hemsedal"},
            {"K-3043", "Ål"},
            {"K-3044", "Hol"},
            {"K-3045", "Sigdal"},
            {"K-3046", "Krødsherad"},
            {"K-3047", "Modum"},
            {"K-3048", "Øvre Eiker"},
            {"K-3049", "Lier"},
            {"K-3050", "Flesberg"},
            {"K-3051", "Rollag"},
            {"K-3052", "Nore og Uvdal"},
            {"K-3053", "Jevnaker"},
            {"K-3054", "Lunner"},
            {"K-0301", "Oslo"},
            {"K-3401", "Kongsvinger"},
            {"K-3403", "Hamar"},
            {"K-3405", "Lillehammer"},
            {"K-3407", "Gjøvik"},
            {"K-3411", "Ringsaker"},
            {"K-3412", "Løten"},
            {"K-3413", "Stange"},
            {"K-3414", "Nord-Odal"},
            {"K-3415", "Sør-Odal"},
            {"K-3416", "Eidskog"},
            {"K-3417", "Grue"},
            {"K-3418", "Åsnes"},
            {"K-3419", "Våler (Innlandet)"},
            {"K-3420", "Elverum"},
            {"K-3421", "Trysil"},
            {"K-3422", "Åmot"},
            {"K-3423", "Stor-Elvdal"},
            {"K-3424", "Rendalen"},
            {"K-3425", "Engerdal"},
            {"K-3426", "Tolga"},
            {"K-3427", "Tynset"},
            {"K-3428", "Alvdal"},
            {"K-3429", "Folldal"},
            {"K-3430", "Os"},
            {"K-3431", "Dovre"},
            {"K-3432", "Lesja"},
            {"K-3433", "Skjåk"},
            {"K-3434", "Lom"},
            {"K-3435", "Vågå"},
            {"K-3436", "Nord-Fron"},
            {"K-3437", "Sel"},
            {"K-3438", "Sør-Fron"},
            {"K-3439", "Ringebu"},
            {"K-3440", "Øyer"},
            {"K-3441", "Gausdal"},
            {"K-3442", "Østre Toten"},
            {"K-3443", "Vestre Toten"},
            {"K-3446", "Gran"},
            {"K-3447", "Søndre Land"},
            {"K-3448", "Nordre Land"},
            {"K-3449", "Sør-Aurdal"},
            {"K-3450", "Etnedal"},
            {"K-3451", "Nord-Aurdal"},
            {"K-3452", "Vestre Slidre"},
            {"K-3453", "Øystre Slidre"},
            {"K-3454", "Vang"},
            {"K-3801", "Horten"},
            {"K-3802", "Holmestrand"},
            {"K-3803", "Tønsberg"},
            {"K-3804", "Sandefjord"},
            {"K-3805", "Larvik"},
            {"K-3806", "Porsgrunn"},
            {"K-3807", "Skien"},
            {"K-3808", "Notodden"},
            {"K-3811", "Færder"},
            {"K-3812", "Siljan"},
            {"K-3813", "Bamble"},
            {"K-3814", "Kragerø"},
            {"K-3815", "Drangedal"},
            {"K-3816", "Nome"},
            {"K-3817", "Midt-Telemark"},
            {"K-3818", "Tinn"},
            {"K-3819", "Hjartdal"},
            {"K-3820", "Seljord"},
            {"K-3821", "Kviteseid"},
            {"K-3822", "Nissedal"},
            {"K-3823", "Fyresdal"},
            {"K-3824", "Tokke"},
            {"K-3825", "Vinje"},
            {"K-4201", "Risør"},
            {"K-4202", "Grimstad"},
            {"K-4203", "Arendal"},
            {"K-4204", "Kristiansand"},
            {"K-4205", "Lindesnes"},
            {"K-4206", "Farsund"},
            {"K-4207", "Flekkefjord"},
            {"K-4211", "Gjerstad"},
            {"K-4212", "Vegårshei"},
            {"K-4213", "Tvedestrand"},
            {"K-4214", "Froland"},
            {"K-4215", "Lillesand"},
            {"K-4216", "Birkenes"},
            {"K-4217", "Åmli"},
            {"K-4218", "Iveland"},
            {"K-4219", "Evje og Hornnes"},
            {"K-4220", "Bygland"},
            {"K-4221", "Valle"},
            {"K-4222", "Bykle"},
            {"K-4223", "Vennesla"},
            {"K-4224", "Åseral"},
            {"K-4225", "Lyngdal"},
            {"K-4226", "Hægebostad"},
            {"K-4227", "Kvinesdal"},
            {"K-4228", "Sirdal"},
            {"K-1101", "Eigersund"},
            {"K-1103", "Stavanger"},
            {"K-1106", "Haugesund"},
            {"K-1108", "Sandnes"},
            {"K-1111", "Sokndal"},
            {"K-1112", "Lund"},
            {"K-1114", "Bjerkreim"},
            {"K-1119", "Hå"},
            {"K-1120", "Klepp"},
            {"K-1121", "Time"},
            {"K-1122", "Gjesdal"},
            {"K-1124", "Sola"},
            {"K-1127", "Randaberg"},
            {"K-1130", "Strand"},
            {"K-1133", "Hjelmeland"},
            {"K-1134", "Suldal"},
            {"K-1135", "Sauda"},
            {"K-1144", "Kvitsøy"},
            {"K-1145", "Bokn"},
            {"K-1146", "Tysvær"},
            {"K-1149", "Karmøy"},
            {"K-1151", "Utsira"},
            {"K-1160", "Vindafjord"},
            {"K-4601", "Bergen"},
            {"K-4602", "Kinn"},
            {"K-4611", "Etne"},
            {"K-4612", "Sveio"},
            {"K-4613", "Bømlo"},
            {"K-4614", "Stord"},
            {"K-4615", "Fitjar"},
            {"K-4616", "Tysnes"},
            {"K-4617", "Kvinnherad"},
            {"K-4618", "Ullensvang"},
            {"K-4619", "Eidfjord"},
            {"K-4620", "Ulvik"},
            {"K-4621", "Voss"},
            {"K-4622", "Kvam"},
            {"K-4623", "Samnanger"},
            {"K-4624", "Bjørnafjorden"},
            {"K-4625", "Austevoll"},
            {"K-4626", "Øygarden"},
            {"K-4627", "Askøy"},
            {"K-4628", "Vaksdal"},
            {"K-4629", "Modalen"},
            {"K-4630", "Osterøy"},
            {"K-4631", "Alver"},
            {"K-4632", "Austrheim"},
            {"K-4633", "Fedje"},
            {"K-4634", "Masfjorden"},
            {"K-4635", "Gulen"},
            {"K-4636", "Solund"},
            {"K-4637", "Hyllestad"},
            {"K-4638", "Høyanger"},
            {"K-4639", "Vik"},
            {"K-4640", "Sogndal"},
            {"K-4641", "Aurland"},
            {"K-4642", "Lærdal"},
            {"K-4643", "Årdal"},
            {"K-4644", "Luster"},
            {"K-4645", "Askvoll"},
            {"K-4646", "Fjaler"},
            {"K-4647", "Sunnfjord"},
            {"K-4648", "Bremanger"},
            {"K-4649", "Stad"},
            {"K-4650", "Gloppen"},
            {"K-4651", "Stryn"},
            {"K-1505", "Kristiansund"},
            {"K-1506", "Molde"},
            {"K-1507", "Ålesund"},
            {"K-1511", "Vanylven"},
            {"K-1514", "Sande"},
            {"K-1515", "Herøy (Møre og Romsdal)"},
            {"K-1516", "Ulstein"},
            {"K-1517", "Hareid"},
            {"K-1520", "Ørsta"},
            {"K-1525", "Stranda"},
            {"K-1528", "Sykkylven"},
            {"K-1531", "Sula"},
            {"K-1532", "Giske"},
            {"K-1535", "Vestnes"},
            {"K-1539", "Rauma"},
            {"K-1547", "Aukra"},
            {"K-1554", "Averøy"},
            {"K-1557", "Gjemnes"},
            {"K-1560", "Tingvoll"},
            {"K-1563", "Sunndal"},
            {"K-1566", "Surnadal"},
            {"K-1573", "Smøla"},
            {"K-1576", "Aure"},
            {"K-1577", "Volda"},
            {"K-1578", "Fjord"},
            {"K-1579", "Hustadvika"},
            {"K-5001", "Trondheim"},
            {"K-5006", "Steinkjer"},
            {"K-5007", "Namsos"},
            {"K-5014", "Frøya"},
            {"K-5020", "Osen"},
            {"K-5021", "Oppdal"},
            {"K-5022", "Rennebu"},
            {"K-5025", "Røros"},
            {"K-5026", "Holtålen"},
            {"K-5027", "Midtre Gauldal"},
            {"K-5028", "Melhus"},
            {"K-5029", "Skaun"},
            {"K-5031", "Malvik"},
            {"K-5032", "Selbu"},
            {"K-5033", "Tydal"},
            {"K-5034", "Meråker"},
            {"K-5035", "Stjørdal"},
            {"K-5036", "Frosta"},
            {"K-5037", "Levanger"},
            {"K-5038", "Verdal"},
            {"K-5041", "Snåase - Snåsa"},
            {"K-5042", "Lierne"},
            {"K-5043", "Raarvihke - Røyrvik"},
            {"K-5044", "Namsskogan"},
            {"K-5045", "Grong"},
            {"K-5046", "Høylandet"},
            {"K-5047", "Overhalla"},
            {"K-5049", "Flatanger"},
            {"K-5052", "Leka"},
            {"K-5053", "Inderøy"},
            {"K-5054", "Indre Fosen"},
            {"K-5055", "Heim"},
            {"K-5056", "Hitra"},
            {"K-5057", "Ørland"},
            {"K-5058", "Åfjord"},
            {"K-5059", "Orkland"},
            {"K-5060", "Nærøysund"},
            {"K-5061", "Rindal"},
            {"K-1804", "Bodø"},
            {"K-1806", "Narvik"},
            {"K-1811", "Bindal"},
            {"K-1812", "Sømna"},
            {"K-1813", "Brønnøy"},
            {"K-1815", "Vega"},
            {"K-1816", "Vevelstad"},
            {"K-1818", "Herøy (Nordland)"},
            {"K-1820", "Alstahaug"},
            {"K-1822", "Leirfjord"},
            {"K-1824", "Vefsn"},
            {"K-1825", "Grane"},
            {"K-1826", "Hattfjelldal"},
            {"K-1827", "Dønna"},
            {"K-1828", "Nesna"},
            {"K-1832", "Hemnes"},
            {"K-1833", "Rana"},
            {"K-1834", "Lurøy"},
            {"K-1835", "Træna"},
            {"K-1836", "Rødøy"},
            {"K-1837", "Meløy"},
            {"K-1838", "Gildeskål"},
            {"K-1839", "Beiarn"},
            {"K-1840", "Saltdal"},
            {"K-1841", "Fauske - Fuosko"},
            {"K-1845", "Sørfold"},
            {"K-1848", "Steigen"},
            {"K-1851", "Lødingen"},
            {"K-1853", "Evenes"},
            {"K-1856", "Røst"},
            {"K-1857", "Værøy"},
            {"K-1859", "Flakstad"},
            {"K-1860", "Vestvågøy"},
            {"K-1865", "Vågan"},
            {"K-1866", "Hadsel"},
            {"K-1867", "Bø"},
            {"K-1868", "Øksnes"},
            {"K-1870", "Sortland - Suortá"},
            {"K-1871", "Andøy"},
            {"K-1874", "Moskenes"},
            {"K-1875", "Hamarøy"},
            {"K-5401", "Tromsø"},
            {"K-5402", "Harstad"},
            {"K-5403", "Alta"},
            {"K-5404", "Vardø"},
            {"K-5405", "Vadsø"},
            {"K-5406", "Hammerfest"},
            {"K-5411", "Kvæfjord"},
            {"K-5412", "Tjeldsund"},
            {"K-5413", "Ibestad"},
            {"K-5414", "Gratangen"},
            {"K-5415", "Loabák - Lavangen"},
            {"K-5416", "Bardu"},
            {"K-5417", "Salangen"},
            {"K-5418", "Målselv"},
            {"K-5419", "Sørreisa"},
            {"K-5420", "Dyrøy"},
            {"K-5421", "Senja"},
            {"K-5422", "Balsfjord"},
            {"K-5423", "Karlsøy"},
            {"K-5424", "Lyngen"},
            {"K-5425", "Storfjord - Omasvuotna - Omasvuono"},
            {"K-5426", "Gáivuotna - Kåfjord - Kaivuono"},
            {"K-5427", "Skjervøy"},
            {"K-5428", "Nordreisa"},
            {"K-5429", "Kvænangen"},
            {"K-5430", "Guovdageaidnu - Kautokeino"},
            {"K-5432", "Loppa"},
            {"K-5433", "Hasvik"},
            {"K-5434", "Måsøy"},
            {"K-5435", "Nordkapp"},
            {"K-5436", "Porsanger - Porsángu - Porsanki "},
            {"K-5437", "Kárásjohka - Karasjok"},
            {"K-5438", "Lebesby"},
            {"K-5439", "Gamvik"},
            {"K-5440", "Berlevåg"},
            {"K-5441", "Deatnu - Tana"},
            {"K-5442", "Unjárga - Nesseby"},
            {"K-5443", "Båtsfjord"},
            {"K-5444", "Sør-Varanger"},
            {"K-21-22", "Svalbard og Jan Mayen"},
            {"K-23", "Kontinentalsokkelen"},
            {"K-Rest", "Delte kommuner og uoppgitt"}
        };

        public static readonly Dictionary<string, int> YearToIndex = new()
        {
            {"1986", 0},
            {"1987", 1},
            {"1988", 2},
            {"1989", 3},
            {"1990", 4},
            {"1991", 5},
            {"1992", 6},
            {"1993", 7},
            {"1994", 8},
            {"1995", 9},
            {"1996", 10},
            {"1997", 11},
            {"1998", 12},
            {"1999", 13},
            {"2000", 14},
            {"2001", 15},
            {"2002", 16},
            {"2003", 17},
            {"2004", 18},
            {"2005", 19},
            {"2006", 20},
            {"2007", 21},
            {"2008", 22},
            {"2009", 23},
            {"2010", 24},
            {"2011", 25},
            {"2012", 26},
            {"2013", 27},
            {"2014", 28},
            {"2015", 29},
            {"2016", 30},
            {"2017", 31},
            {"2018", 32},
            {"2019", 33},
            {"2020", 34},
            {"2021", 35}
        };

        public static readonly Dictionary<string, string> YearToYearString = new()
        {
            {"1986", "1986"},
            {"1987", "1987"},
            {"1988", "1988"},
            {"1989", "1989"},
            {"1990", "1990"},
            {"1991", "1991"},
            {"1992", "1992"},
            {"1993", "1993"},
            {"1994", "1994"},
            {"1995", "1995"},
            {"1996", "1996"},
            {"1997", "1997"},
            {"1998", "1998"},
            {"1999", "1999"},
            {"2000", "2000"},
            {"2001", "2001"},
            {"2002", "2002"},
            {"2003", "2003"},
            {"2004", "2004"},
            {"2005", "2005"},
            {"2006", "2006"},
            {"2007", "2007"},
            {"2008", "2008"},
            {"2009", "2009"},
            {"2010", "2010"},
            {"2011", "2011"},
            {"2012", "2012"},
            {"2013", "2013"},
            {"2014", "2014"},
            {"2015", "2015"},
            {"2016", "2016"},
            {"2017", "2017"},
            {"2018", "2018"},
            {"2019", "2019"},
            {"2020", "2020"},
            {"2021", "2021"}
        };
    }
}