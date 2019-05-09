﻿using Dfc.ProviderPortal.Packages;
using Dfc.ProviderPortal.ReferenceData.Interfaces;
using Dfc.ProviderPortal.ReferenceData.Models;
using Dfc.ProviderPortal.ReferenceData.Settings;
using Microsoft.Azure.Documents.Client;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dfc.ProviderPortal.ReferenceData.Services
{
    public class StandardSectorCodeService : IStandardSectorCodeService
    {
        private const string STUB_JSON_DATA = "[{\"Id\":\"619824B6-DA55-4425-9511-3AB984C52C7D\",\"StandardSectorCodeId\":\"1\",\"StandardSectorCodeDesc\":\"Actuarial \",\"StandardSectorCodeDesc2\":\"Actuarial \",\"EffectiveFrom\":\"2014-08-01T00:00:00\",\"CreatedDateTimeUtc\":\"2016-02-08T10:57:25.163\",\"ModifiedDateTimeUtc\":\"2019-03-08T21:01:29.977\"},{\"Id\":\"2ACD840F-AAB4-4B1D-AD2E-12ABD1951ECB\",\"StandardSectorCodeId\":\"10\",\"StandardSectorCodeDesc\":\"Horticulture\",\"StandardSectorCodeDesc2\":\"Horticulture\",\"EffectiveFrom\":\"2015-03-26T00:00:00\",\"CreatedDateTimeUtc\":\"2016-02-08T10:57:25.163\",\"ModifiedDateTimeUtc\":\"2019-03-08T21:01:29.977\"},{\"Id\":\"800D0D03-54F3-4172-A624-F572FBA987B4\",\"StandardSectorCodeId\":\"11\",\"StandardSectorCodeDesc\":\"Newspaper and Broadcast Media\",\"StandardSectorCodeDesc2\":\"Newspaper and Broadcast Media\",\"EffectiveFrom\":\"2015-03-26T00:00:00\",\"CreatedDateTimeUtc\":\"2016-02-08T10:57:25.163\",\"ModifiedDateTimeUtc\":\"2019-03-08T21:01:29.977\"},{\"Id\":\"8C1EFAB4-A2CA-4891-9B57-CC09911E954E\",\"StandardSectorCodeId\":\"12\",\"StandardSectorCodeDesc\":\"Property Services\",\"StandardSectorCodeDesc2\":\"Property Services\",\"EffectiveFrom\":\"2015-03-26T00:00:00\",\"CreatedDateTimeUtc\":\"2016-02-08T10:57:25.163\",\"ModifiedDateTimeUtc\":\"2019-03-08T21:01:29.977\"},{\"Id\":\"4E6BA3CD-9588-4946-B255-E8DAC2829E4F\",\"StandardSectorCodeId\":\"13\",\"StandardSectorCodeDesc\":\"Rail Design\",\"StandardSectorCodeDesc2\":\"Rail Design\",\"EffectiveFrom\":\"2015-03-26T00:00:00\",\"CreatedDateTimeUtc\":\"2016-02-08T10:57:25.163\",\"ModifiedDateTimeUtc\":\"2019-03-08T21:01:29.977\"},{\"Id\":\"52740F46-3000-42E9-A141-3FE380831575\",\"StandardSectorCodeId\":\"14\",\"StandardSectorCodeDesc\":\"Maritime\",\"StandardSectorCodeDesc2\":\"Maritime\",\"EffectiveFrom\":\"2015-08-01T00:00:00\",\"CreatedDateTimeUtc\":\"2016-02-08T10:57:25.163\",\"ModifiedDateTimeUtc\":\"2019-03-08T21:01:29.977\"},{\"Id\":\"E6631BE4-071F-41A5-AC5C-3EA20FB096CD\",\"StandardSectorCodeId\":\"15\",\"StandardSectorCodeDesc\":\"Nuclear\",\"StandardSectorCodeDesc2\":\"Nuclear\",\"EffectiveFrom\":\"2015-08-01T00:00:00\",\"CreatedDateTimeUtc\":\"2016-02-08T10:57:25.163\",\"ModifiedDateTimeUtc\":\"2019-03-08T21:01:29.977\"},{\"Id\":\"03290ED2-2461-4929-AF28-2019EF3E3E18\",\"StandardSectorCodeId\":\"16\",\"StandardSectorCodeDesc\":\"Public Service\",\"StandardSectorCodeDesc2\":\"Public Service\",\"EffectiveFrom\":\"2015-08-01T00:00:00\",\"CreatedDateTimeUtc\":\"2016-02-08T10:57:25.163\",\"ModifiedDateTimeUtc\":\"2019-03-08T21:01:29.977\"},{\"Id\":\"0575B2B0-453A-4A09-A08E-8FED407C1FF9\",\"StandardSectorCodeId\":\"17\",\"StandardSectorCodeDesc\":\"Conveyancing\",\"StandardSectorCodeDesc2\":\"Conveyancing\",\"EffectiveFrom\":\"2015-08-01T00:00:00\",\"CreatedDateTimeUtc\":\"2016-02-08T10:57:25.163\",\"ModifiedDateTimeUtc\":\"2019-03-08T21:01:29.977\"},{\"Id\":\"CA0FC14C-2FAF-4CA1-97DD-2401DAE24101\",\"StandardSectorCodeId\":\"18\",\"StandardSectorCodeDesc\":\"Law\",\"StandardSectorCodeDesc2\":\"Law\",\"EffectiveFrom\":\"2015-08-01T00:00:00\",\"CreatedDateTimeUtc\":\"2016-02-08T10:57:25.163\",\"ModifiedDateTimeUtc\":\"2019-03-08T21:01:29.977\"},{\"Id\":\"CC46B3A6-1C46-4884-810D-7D4A472A4716\",\"StandardSectorCodeId\":\"19\",\"StandardSectorCodeDesc\":\"Electrotechnical\",\"StandardSectorCodeDesc2\":\"Electrotechnical\",\"EffectiveFrom\":\"2015-08-01T00:00:00\",\"CreatedDateTimeUtc\":\"2016-02-08T10:57:25.163\",\"ModifiedDateTimeUtc\":\"2019-03-08T21:01:29.977\"},{\"Id\":\"7B35A4DB-2437-4E3B-AE79-E2A54A1ECCAA\",\"StandardSectorCodeId\":\"2\",\"StandardSectorCodeDesc\":\"Aerospace\",\"StandardSectorCodeDesc2\":\"Aerospace\",\"EffectiveFrom\":\"2014-08-01T00:00:00\",\"CreatedDateTimeUtc\":\"2016-02-08T10:57:25.163\",\"ModifiedDateTimeUtc\":\"2019-03-08T21:01:29.977\"},{\"Id\":\"44ADBA61-771D-4283-BBBD-E0BFA103CB96\",\"StandardSectorCodeId\":\"20\",\"StandardSectorCodeDesc\":\"Refrigeration Air Conditioning and Heat Pump\",\"StandardSectorCodeDesc2\":\"Refrigeration Air Conditioning and Heat Pump\",\"EffectiveFrom\":\"2015-08-01T00:00:00\",\"CreatedDateTimeUtc\":\"2016-02-08T10:57:25.163\",\"ModifiedDateTimeUtc\":\"2019-03-08T21:01:29.977\"},{\"Id\":\"2878154D-2A60-4341-BE9A-B881447F0AB2\",\"StandardSectorCodeId\":\"21\",\"StandardSectorCodeDesc\":\"Surveying\",\"StandardSectorCodeDesc2\":\"Surveying\",\"EffectiveFrom\":\"2015-08-01T00:00:00\",\"CreatedDateTimeUtc\":\"2016-02-08T10:57:25.163\",\"ModifiedDateTimeUtc\":\"2019-03-08T21:01:29.977\"},{\"Id\":\"36992CBD-28B0-4D06-8D87-DC0B2EF054BC\",\"StandardSectorCodeId\":\"22\",\"StandardSectorCodeDesc\":\"Defence\",\"StandardSectorCodeDesc2\":\"Defence\",\"EffectiveFrom\":\"2015-08-01T00:00:00\",\"CreatedDateTimeUtc\":\"2016-02-08T10:57:25.163\",\"ModifiedDateTimeUtc\":\"2019-03-08T21:01:29.977\"},{\"Id\":\"2626815B-691E-486C-8491-51573707CBD7\",\"StandardSectorCodeId\":\"23\",\"StandardSectorCodeDesc\":\"Butchery\",\"StandardSectorCodeDesc2\":\"Butchery\",\"EffectiveFrom\":\"2015-08-01T00:00:00\",\"CreatedDateTimeUtc\":\"2016-02-08T10:57:25.163\",\"ModifiedDateTimeUtc\":\"2019-03-08T21:01:29.977\"},{\"Id\":\"E9CD0162-E8A1-45CD-842B-5C30522E5F88\",\"StandardSectorCodeId\":\"24\",\"StandardSectorCodeDesc\":\"Leadership and Management\",\"StandardSectorCodeDesc2\":\"Leadership and Management\",\"EffectiveFrom\":\"2015-08-01T00:00:00\",\"CreatedDateTimeUtc\":\"2016-02-08T10:57:25.163\",\"ModifiedDateTimeUtc\":\"2019-03-08T21:01:29.977\"},{\"Id\":\"95F7B2A8-C2E3-42F9-B3B0-2C28261FC72B\",\"StandardSectorCodeId\":\"25\",\"StandardSectorCodeDesc\":\"Adult Care\",\"StandardSectorCodeDesc2\":\"Adult Care\",\"EffectiveFrom\":\"2015-08-01T00:00:00\",\"CreatedDateTimeUtc\":\"2016-02-08T10:57:25.163\",\"ModifiedDateTimeUtc\":\"2019-03-08T21:01:29.977\"},{\"Id\":\"2DECA3D7-C46D-4D79-9A63-119EBE1E9333\",\"StandardSectorCodeId\":\"26\",\"StandardSectorCodeDesc\":\"Aviation\",\"StandardSectorCodeDesc2\":\"Aviation\",\"EffectiveFrom\":\"2015-08-01T00:00:00\",\"CreatedDateTimeUtc\":\"2016-02-08T10:57:25.163\",\"ModifiedDateTimeUtc\":\"2019-03-08T21:01:29.977\"},{\"Id\":\"1C69CF21-0C68-4F93-A66C-7D6D274D91DE\",\"StandardSectorCodeId\":\"27\",\"StandardSectorCodeDesc\":\"Insurance\",\"StandardSectorCodeDesc2\":\"Insurance\",\"EffectiveFrom\":\"2015-08-01T00:00:00\",\"CreatedDateTimeUtc\":\"2016-02-08T10:57:25.163\",\"ModifiedDateTimeUtc\":\"2019-03-08T21:01:29.977\"},{\"Id\":\"A8644947-920A-4509-AB33-75F077A8BA60\",\"StandardSectorCodeId\":\"28\",\"StandardSectorCodeDesc\":\"Papermaking\",\"StandardSectorCodeDesc2\":\"Papermaking\",\"EffectiveFrom\":\"2015-08-01T00:00:00\",\"CreatedDateTimeUtc\":\"2016-02-08T10:57:25.163\",\"ModifiedDateTimeUtc\":\"2019-03-08T21:01:29.977\"},{\"Id\":\"2152BCCC-EE33-47E5-B8DA-5426AA068B55\",\"StandardSectorCodeId\":\"29\",\"StandardSectorCodeDesc\":\"Public Sector\",\"StandardSectorCodeDesc2\":\"Public Sector\",\"EffectiveFrom\":\"2015-08-01T00:00:00\",\"CreatedDateTimeUtc\":\"2016-02-08T10:57:25.163\",\"ModifiedDateTimeUtc\":\"2019-03-08T21:01:29.977\"},{\"Id\":\"34B47FA0-213C-4616-8E3A-7A5347CAA53C\",\"StandardSectorCodeId\":\"3\",\"StandardSectorCodeDesc\":\"Automotive\",\"StandardSectorCodeDesc2\":\"Automotive\",\"EffectiveFrom\":\"2014-08-01T00:00:00\",\"CreatedDateTimeUtc\":\"2016-02-08T10:57:25.163\",\"ModifiedDateTimeUtc\":\"2019-03-08T21:01:29.977\"},{\"Id\":\"EFCDF4DF-FEBA-4A84-9755-9B6C1BFDD510\",\"StandardSectorCodeId\":\"30\",\"StandardSectorCodeDesc\":\"Rail Engineering\",\"StandardSectorCodeDesc2\":\"Rail Engineering\",\"EffectiveFrom\":\"2015-08-01T00:00:00\",\"CreatedDateTimeUtc\":\"2016-02-08T10:57:25.163\",\"ModifiedDateTimeUtc\":\"2019-03-08T21:01:29.977\"},{\"Id\":\"D4A7F228-3D40-4D24-AD18-9971E6080267\",\"StandardSectorCodeId\":\"31\",\"StandardSectorCodeDesc\":\"Retail\",\"StandardSectorCodeDesc2\":\"Retail\",\"EffectiveFrom\":\"2015-08-01T00:00:00\",\"CreatedDateTimeUtc\":\"2016-02-08T10:57:25.163\",\"ModifiedDateTimeUtc\":\"2019-03-08T21:01:29.977\"},{\"Id\":\"93BF3431-A34B-4734-B68B-B405A8F22BE2\",\"StandardSectorCodeId\":\"32\",\"StandardSectorCodeDesc\":\"TV Production and Broadcasting\",\"StandardSectorCodeDesc2\":\"TV Production and Broadcasting\",\"EffectiveFrom\":\"2015-08-01T00:00:00\",\"CreatedDateTimeUtc\":\"2016-02-08T10:57:25.163\",\"ModifiedDateTimeUtc\":\"2019-03-08T21:01:29.977\"},{\"Id\":\"4A527B1E-E555-4E03-B41C-31D973BA0AFF\",\"StandardSectorCodeId\":\"33\",\"StandardSectorCodeDesc\":\"Visual Effects\",\"StandardSectorCodeDesc2\":\"Visual Effects\",\"EffectiveFrom\":\"2015-08-01T00:00:00\",\"CreatedDateTimeUtc\":\"2016-02-08T10:57:25.163\",\"ModifiedDateTimeUtc\":\"2019-03-08T21:01:29.977\"},{\"Id\":\"BAC58892-C27B-450A-A4BD-6A960C38DA0F\",\"StandardSectorCodeId\":\"34\",\"StandardSectorCodeDesc\":\"Welding\",\"StandardSectorCodeDesc2\":\"Welding\",\"EffectiveFrom\":\"2015-08-01T00:00:00\",\"CreatedDateTimeUtc\":\"2016-02-08T10:57:25.163\",\"ModifiedDateTimeUtc\":\"2019-03-08T21:01:29.977\"},{\"Id\":\"12FF233B-9916-458E-B529-62DA77C8AB8D\",\"StandardSectorCodeId\":\"35\",\"StandardSectorCodeDesc\":\"Automotive Retail\",\"StandardSectorCodeDesc2\":\"Automotive Retail\",\"EffectiveFrom\":\"2015-08-01T00:00:00\",\"CreatedDateTimeUtc\":\"2016-02-08T10:57:25.163\",\"ModifiedDateTimeUtc\":\"2019-03-08T21:01:29.977\"},{\"Id\":\"ADEB7328-CC1F-4F87-9D31-1BE784BB7B82\",\"StandardSectorCodeId\":\"36\",\"StandardSectorCodeDesc\":\"Housing\",\"StandardSectorCodeDesc2\":\"Housing\",\"EffectiveFrom\":\"2015-08-01T00:00:00\",\"CreatedDateTimeUtc\":\"2016-02-08T10:57:25.163\",\"ModifiedDateTimeUtc\":\"2019-03-08T21:01:29.977\"},{\"Id\":\"EF99CC46-C8E6-4E5D-A34F-BE3B008CD5BA\",\"StandardSectorCodeId\":\"37\",\"StandardSectorCodeDesc\":\"Non-destructive Testing\",\"StandardSectorCodeDesc2\":\"Non-destructive Testing\",\"EffectiveFrom\":\"2015-08-01T00:00:00\",\"CreatedDateTimeUtc\":\"2016-02-08T10:57:25.163\",\"ModifiedDateTimeUtc\":\"2019-03-08T21:01:29.977\"},{\"Id\":\"2EDD32AA-BDE8-4FE2-9C77-52476E7D011F\",\"StandardSectorCodeId\":\"38\",\"StandardSectorCodeDesc\":\"Energy Management\",\"StandardSectorCodeDesc2\":\"Energy Management\",\"EffectiveFrom\":\"2015-08-01T00:00:00\",\"CreatedDateTimeUtc\":\"2016-02-08T10:57:25.163\",\"ModifiedDateTimeUtc\":\"2019-03-08T21:01:29.977\"},{\"Id\":\"AAC40FCA-832C-43A9-A8D7-66685351DF02\",\"StandardSectorCodeId\":\"39\",\"StandardSectorCodeDesc\":\"Land-based Engineering Standards\",\"StandardSectorCodeDesc2\":\"Land-based Engineering Standards\",\"EffectiveFrom\":\"2015-08-01T00:00:00\",\"CreatedDateTimeUtc\":\"2016-02-08T10:57:25.163\",\"ModifiedDateTimeUtc\":\"2019-03-08T21:01:29.977\"},{\"Id\":\"68444B0A-0936-4A68-8684-0E9FAB4DC7A7\",\"StandardSectorCodeId\":\"4\",\"StandardSectorCodeDesc\":\"Life and Industrial Sciences\",\"StandardSectorCodeDesc2\":\"Life and Industrial Sciences\",\"EffectiveFrom\":\"2014-08-01T00:00:00\",\"CreatedDateTimeUtc\":\"2016-02-08T10:57:25.163\",\"ModifiedDateTimeUtc\":\"2019-03-08T21:01:29.977\"},{\"Id\":\"A72463E4-7CB2-49E4-A76B-D3AA939CB551\",\"StandardSectorCodeId\":\"40\",\"StandardSectorCodeDesc\":\"Live Events\",\"StandardSectorCodeDesc2\":\"Live Events\",\"EffectiveFrom\":\"2015-08-01T00:00:00\",\"CreatedDateTimeUtc\":\"2016-02-08T10:57:25.163\",\"ModifiedDateTimeUtc\":\"2019-03-08T21:01:29.977\"},{\"Id\":\"15B10AAF-EE9C-4BA7-AEB0-BB58E14CD442\",\"StandardSectorCodeId\":\"41\",\"StandardSectorCodeDesc\":\"Bespoke Tailoring\",\"StandardSectorCodeDesc2\":\"Bespoke Tailoring\",\"EffectiveFrom\":\"2015-08-01T00:00:00\",\"CreatedDateTimeUtc\":\"2016-02-29T17:04:30.577\",\"ModifiedDateTimeUtc\":\"2019-03-08T21:01:29.977\"},{\"Id\":\"CFAA509F-0D04-46B3-9AD7-74C545F5A848\",\"StandardSectorCodeId\":\"42\",\"StandardSectorCodeDesc\":\"Boatbuilding\",\"StandardSectorCodeDesc2\":\"Boatbuilding\",\"EffectiveFrom\":\"2015-08-01T00:00:00\",\"CreatedDateTimeUtc\":\"2016-04-15T10:12:43.010\",\"ModifiedDateTimeUtc\":\"2019-03-08T21:01:29.977\"},{\"Id\":\"2290EACF-58ED-45C9-AE04-0E3821052B58\",\"StandardSectorCodeId\":\"43\",\"StandardSectorCodeDesc\":\"Management Consultancy\",\"StandardSectorCodeDesc2\":\"Management Consultancy\",\"EffectiveFrom\":\"2015-08-01T00:00:00\",\"CreatedDateTimeUtc\":\"2016-04-15T10:12:43.010\",\"ModifiedDateTimeUtc\":\"2019-03-08T21:01:29.977\"},{\"Id\":\"F2A9C65B-4EA2-41AB-B3BC-D0A637F85B95\",\"StandardSectorCodeId\":\"44\",\"StandardSectorCodeDesc\":\"Hospitality\",\"StandardSectorCodeDesc2\":\"Hospitality\",\"EffectiveFrom\":\"2015-08-01T00:00:00\",\"CreatedDateTimeUtc\":\"2016-05-10T15:16:26.650\",\"ModifiedDateTimeUtc\":\"2019-03-08T21:01:29.977\"},{\"Id\":\"93D6EE4C-0C0A-45DC-9FDC-A733D5E7E7A5\",\"StandardSectorCodeId\":\"45\",\"StandardSectorCodeDesc\":\"Engineering, Design and Draughting\",\"StandardSectorCodeDesc2\":\"Engineering, Design and Draughting\",\"EffectiveFrom\":\"2015-08-01T00:00:00\",\"CreatedDateTimeUtc\":\"2016-05-10T15:16:26.650\",\"ModifiedDateTimeUtc\":\"2019-03-08T21:01:29.977\"},{\"Id\":\"9AE3913A-D8B8-4E97-8DFE-BBD319E7ED12\",\"StandardSectorCodeId\":\"46\",\"StandardSectorCodeDesc\":\"Healthcare\",\"StandardSectorCodeDesc2\":\"Healthcare\",\"EffectiveFrom\":\"2015-08-01T00:00:00\",\"CreatedDateTimeUtc\":\"2016-05-26T08:31:20.747\",\"ModifiedDateTimeUtc\":\"2019-03-08T21:01:29.977\"},{\"Id\":\"BFD4786B-B83D-4F7A-BD48-A701A73C1DA4\",\"StandardSectorCodeId\":\"47\",\"StandardSectorCodeDesc\":\"Advanced Manufacturing\",\"StandardSectorCodeDesc2\":\"Advanced Manufacturing\",\"EffectiveFrom\":\"2015-08-01T00:00:00\",\"CreatedDateTimeUtc\":\"2016-05-26T08:31:20.747\",\"ModifiedDateTimeUtc\":\"2019-03-08T21:01:29.977\"},{\"Id\":\"4DE7AE5E-C699-45F0-9744-3F7007E3910C\",\"StandardSectorCodeId\":\"48\",\"StandardSectorCodeDesc\":\"Transport\",\"StandardSectorCodeDesc2\":\"Transport\",\"EffectiveFrom\":\"2015-08-01T00:00:00\",\"CreatedDateTimeUtc\":\"2016-05-26T08:31:20.747\",\"ModifiedDateTimeUtc\":\"2019-03-08T21:01:29.977\"},{\"Id\":\"0483C924-FF3B-4117-BB88-978EA8B123F9\",\"StandardSectorCodeId\":\"49\",\"StandardSectorCodeDesc\":\"HM Armed Forces\",\"StandardSectorCodeDesc2\":\"HM Armed Forces\",\"EffectiveFrom\":\"2015-08-01T00:00:00\",\"CreatedDateTimeUtc\":\"2016-06-28T15:43:22.427\",\"ModifiedDateTimeUtc\":\"2019-03-08T21:01:29.977\"},{\"Id\":\"3327125F-B238-4D52-8EC4-A65D0BABA2BF\",\"StandardSectorCodeId\":\"5\",\"StandardSectorCodeDesc\":\"Food and Drink\",\"StandardSectorCodeDesc2\":\"Food and Drink\",\"EffectiveFrom\":\"2014-08-01T00:00:00\",\"CreatedDateTimeUtc\":\"2016-02-08T10:57:25.163\",\"ModifiedDateTimeUtc\":\"2019-03-08T21:01:29.977\"},{\"Id\":\"692BC875-72EA-45DA-AB05-04C4C177D610\",\"StandardSectorCodeId\":\"50\",\"StandardSectorCodeDesc\":\"Airworthiness\",\"StandardSectorCodeDesc2\":\"Airworthiness\",\"EffectiveFrom\":\"2015-08-01T00:00:00\",\"CreatedDateTimeUtc\":\"2016-06-28T15:43:22.427\",\"ModifiedDateTimeUtc\":\"2019-03-08T21:01:29.977\"},{\"Id\":\"D16CF9FC-BA9E-45E5-800B-0D147931449B\",\"StandardSectorCodeId\":\"51\",\"StandardSectorCodeDesc\":\"Logistics and supply chain\",\"StandardSectorCodeDesc2\":\"Logistics and supply chain\",\"EffectiveFrom\":\"2015-08-01T00:00:00\",\"CreatedDateTimeUtc\":\"2016-07-13T14:35:46.740\",\"ModifiedDateTimeUtc\":\"2019-03-08T21:01:29.977\"},{\"Id\":\"82084FB1-1B7C-4F46-AFAB-122CAE5715C7\",\"StandardSectorCodeId\":\"52\",\"StandardSectorCodeDesc\":\"Accountancy\",\"StandardSectorCodeDesc2\":\"Accountancy\",\"EffectiveFrom\":\"2015-08-01T00:00:00\",\"CreatedDateTimeUtc\":\"2016-08-22T14:32:53.953\",\"ModifiedDateTimeUtc\":\"2019-03-08T21:01:29.977\"},{\"Id\":\"905CAFFF-68E3-48BC-99AD-A98DA1C4CAF5\",\"StandardSectorCodeId\":\"53\",\"StandardSectorCodeDesc\":\"Travel\",\"StandardSectorCodeDesc2\":\"Travel\",\"EffectiveFrom\":\"2015-08-01T00:00:00\",\"CreatedDateTimeUtc\":\"2016-08-22T14:32:53.953\",\"ModifiedDateTimeUtc\":\"2019-03-08T21:01:29.977\"},{\"Id\":\"B74D5241-9878-4B78-8AFB-C5115AFDF90F\",\"StandardSectorCodeId\":\"54\",\"StandardSectorCodeDesc\":\"Customer Service\",\"StandardSectorCodeDesc2\":\"Customer Service\",\"EffectiveFrom\":\"2015-08-01T00:00:00\",\"CreatedDateTimeUtc\":\"2016-08-22T14:32:53.953\",\"ModifiedDateTimeUtc\":\"2019-03-08T21:01:29.977\"},{\"Id\":\"38DFCCD9-3D8A-4807-ABBD-2A29865FD98C\",\"StandardSectorCodeId\":\"55\",\"StandardSectorCodeDesc\":\"Construction\",\"StandardSectorCodeDesc2\":\"Construction\",\"EffectiveFrom\":\"2016-08-01T00:00:00\",\"CreatedDateTimeUtc\":\"2016-08-22T14:32:53.953\",\"ModifiedDateTimeUtc\":\"2019-03-08T21:01:29.977\"},{\"Id\":\"632BED03-9221-4C1B-8FEE-2F23B5B87C5C\",\"StandardSectorCodeId\":\"56\",\"StandardSectorCodeDesc\":\"Fire Emergency and Security Systems\",\"StandardSectorCodeDesc2\":\"Fire Emergency and Security Systems\",\"EffectiveFrom\":\"2016-08-01T00:00:00\",\"CreatedDateTimeUtc\":\"2016-08-22T14:32:53.953\",\"ModifiedDateTimeUtc\":\"2019-03-08T21:01:29.977\"},{\"Id\":\"48AF105A-0395-4FF2-9188-354C2AB910B4\",\"StandardSectorCodeId\":\"57\",\"StandardSectorCodeDesc\":\"Project Management\",\"StandardSectorCodeDesc2\":\"Project Management\",\"EffectiveFrom\":\"2016-08-01T00:00:00\",\"CreatedDateTimeUtc\":\"2016-08-22T14:32:53.953\",\"ModifiedDateTimeUtc\":\"2019-03-08T21:01:29.977\"},{\"Id\":\"D0B7FFDB-C58F-49F0-9897-57C862DC7EB3\",\"StandardSectorCodeId\":\"58\",\"StandardSectorCodeDesc\":\"Bus, Coach and HGV\",\"StandardSectorCodeDesc2\":\"Bus, Coach and HGV\",\"EffectiveFrom\":\"2016-08-01T00:00:00\",\"CreatedDateTimeUtc\":\"2016-09-28T12:48:11.813\",\"ModifiedDateTimeUtc\":\"2019-03-08T21:01:29.977\"},{\"Id\":\"F42DAD3F-8427-4C7D-B476-F028A5254346\",\"StandardSectorCodeId\":\"59\",\"StandardSectorCodeDesc\":\"Furniture\",\"StandardSectorCodeDesc2\":\"Furniture\",\"EffectiveFrom\":\"2016-08-01T00:00:00\",\"CreatedDateTimeUtc\":\"2016-09-28T12:48:11.813\",\"ModifiedDateTimeUtc\":\"2019-03-08T21:01:29.977\"},{\"Id\":\"1CE0BC2D-97D5-42E4-A442-32CCBE1EA6CC\",\"StandardSectorCodeId\":\"6\",\"StandardSectorCodeDesc\":\"Dental Health\",\"StandardSectorCodeDesc2\":\"Dental Health\",\"EffectiveFrom\":\"2014-08-01T00:00:00\",\"CreatedDateTimeUtc\":\"2016-02-08T10:57:25.163\",\"ModifiedDateTimeUtc\":\"2019-03-08T21:01:29.977\"},{\"Id\":\"BDADADF0-F0F7-44AD-8A42-4D116364D399\",\"StandardSectorCodeId\":\"60\",\"StandardSectorCodeDesc\":\"Groundsmanship\",\"StandardSectorCodeDesc2\":\"Groundsmanship\",\"EffectiveFrom\":\"2016-08-01T00:00:00\",\"CreatedDateTimeUtc\":\"2016-09-28T12:48:11.813\",\"ModifiedDateTimeUtc\":\"2019-03-08T21:01:29.977\"},{\"Id\":\"BEEDD78E-F880-4910-B093-0558C36351A2\",\"StandardSectorCodeId\":\"61\",\"StandardSectorCodeDesc\":\"Event Management\",\"StandardSectorCodeDesc2\":\"Event Management\",\"EffectiveFrom\":\"2016-08-01T00:00:00\",\"CreatedDateTimeUtc\":\"2016-12-02T09:48:28.747\",\"ModifiedDateTimeUtc\":\"2019-03-08T21:01:29.977\"},{\"Id\":\"6D26AE16-BA0F-4D4C-814B-1D551C0A204A\",\"StandardSectorCodeId\":\"62\",\"StandardSectorCodeDesc\":\"Ambulance\",\"StandardSectorCodeDesc2\":\"Ambulance\",\"EffectiveFrom\":\"2016-08-01T00:00:00\",\"CreatedDateTimeUtc\":\"2017-01-09T16:46:01.917\",\"ModifiedDateTimeUtc\":\"2019-03-08T21:01:29.977\"},{\"Id\":\"CE4FE52C-A51D-46CA-BD5B-B0A3B9333505\",\"StandardSectorCodeId\":\"63\",\"StandardSectorCodeDesc\":\"Hair and Beauty\",\"StandardSectorCodeDesc2\":\"Hair and Beauty\",\"EffectiveFrom\":\"2016-08-01T00:00:00\",\"CreatedDateTimeUtc\":\"2017-01-12T09:01:51.220\",\"ModifiedDateTimeUtc\":\"2019-03-08T21:01:29.977\"},{\"Id\":\"8A95FB9B-4BC7-46A2-AC8B-350A601D0531\",\"StandardSectorCodeId\":\"64\",\"StandardSectorCodeDesc\":\"Craft\",\"StandardSectorCodeDesc2\":\"Craft\",\"EffectiveFrom\":\"2016-08-01T00:00:00\",\"CreatedDateTimeUtc\":\"2017-01-12T09:01:51.220\",\"ModifiedDateTimeUtc\":\"2019-03-08T21:01:29.977\"},{\"Id\":\"AE60FEEA-955E-433A-B0E3-06F229F045B4\",\"StandardSectorCodeId\":\"65\",\"StandardSectorCodeDesc\":\"Composites\",\"StandardSectorCodeDesc2\":\"Composites\",\"EffectiveFrom\":\"2016-08-01T00:00:00\",\"CreatedDateTimeUtc\":\"2017-02-16T09:02:07.210\",\"ModifiedDateTimeUtc\":\"2019-03-08T21:01:29.977\"},{\"Id\":\"2ABDB1EB-165A-4BBC-9355-9F86018803C0\",\"StandardSectorCodeId\":\"66\",\"StandardSectorCodeDesc\":\"Facilities Management\",\"StandardSectorCodeDesc2\":\"Facilities Management\",\"EffectiveFrom\":\"2016-08-01T00:00:00\",\"CreatedDateTimeUtc\":\"2017-03-10T08:48:56.090\",\"ModifiedDateTimeUtc\":\"2019-03-08T21:01:29.977\"},{\"Id\":\"93BF6598-0D22-430C-A176-30DAF03F4436\",\"StandardSectorCodeId\":\"67\",\"StandardSectorCodeDesc\":\"Building Services Engineering\",\"StandardSectorCodeDesc2\":\"Building Services Engineering\",\"EffectiveFrom\":\"2016-08-01T00:00:00\",\"CreatedDateTimeUtc\":\"2017-04-12T07:11:05.710\",\"ModifiedDateTimeUtc\":\"2019-03-08T21:01:29.977\"},{\"Id\":\"98966104-4A3F-4BB3-8C8F-06545ABFC277\",\"StandardSectorCodeId\":\"68\",\"StandardSectorCodeDesc\":\"Engineering\",\"StandardSectorCodeDesc2\":\"Engineering\",\"EffectiveFrom\":\"2016-08-01T00:00:00\",\"CreatedDateTimeUtc\":\"2017-04-12T07:11:05.710\",\"ModifiedDateTimeUtc\":\"2019-03-08T21:01:29.977\"},{\"Id\":\"D01B815B-A4F1-462B-9E33-2B11330F14CA\",\"StandardSectorCodeId\":\"69\",\"StandardSectorCodeDesc\":\"Nursing\",\"StandardSectorCodeDesc2\":\"Nursing\",\"EffectiveFrom\":\"2016-08-01T00:00:00\",\"CreatedDateTimeUtc\":\"2017-05-22T07:40:14.010\",\"ModifiedDateTimeUtc\":\"2019-03-08T21:01:29.977\"},{\"Id\":\"792DDC3B-9905-4F51-B2DC-F6C663FEDD3D\",\"StandardSectorCodeId\":\"7\",\"StandardSectorCodeDesc\":\"Digital Industries\",\"StandardSectorCodeDesc2\":\"Digital Industries\",\"EffectiveFrom\":\"2014-08-01T00:00:00\",\"CreatedDateTimeUtc\":\"2016-02-08T10:57:25.163\",\"ModifiedDateTimeUtc\":\"2019-03-08T21:01:29.977\"},{\"Id\":\"CBF5A70A-7867-4140-AA67-9954FF2893D2\",\"StandardSectorCodeId\":\"70\",\"StandardSectorCodeDesc\":\"Creative and Design\",\"StandardSectorCodeDesc2\":\"Creative and Design\",\"EffectiveFrom\":\"2017-05-01T00:00:00\",\"CreatedDateTimeUtc\":\"2017-06-09T14:36:17.073\",\"ModifiedDateTimeUtc\":\"2019-03-08T21:01:29.977\"},{\"Id\":\"ECDCA316-B4ED-47F0-B33C-310A586FF13E\",\"StandardSectorCodeId\":\"71\",\"StandardSectorCodeDesc\":\"Engineering and Manufacturing\",\"StandardSectorCodeDesc2\":\"Engineering and Manufacturing\",\"EffectiveFrom\":\"2017-05-01T00:00:00\",\"CreatedDateTimeUtc\":\"2017-06-09T14:36:17.073\",\"ModifiedDateTimeUtc\":\"2019-03-08T21:01:29.977\"},{\"Id\":\"F4A2980A-43C5-4C19-9815-513F8C687548\",\"StandardSectorCodeId\":\"72\",\"StandardSectorCodeDesc\":\"Health and Science\",\"StandardSectorCodeDesc2\":\"Health and Science\",\"EffectiveFrom\":\"2017-06-01T00:00:00\",\"CreatedDateTimeUtc\":\"2017-06-21T20:02:06.003\",\"ModifiedDateTimeUtc\":\"2019-03-08T21:01:29.977\"},{\"Id\":\"C2E6AD39-7A00-40A8-B039-1237CACFEAB1\",\"StandardSectorCodeId\":\"73\",\"StandardSectorCodeDesc\":\"Agriculture, Environmental and Animal Care\",\"StandardSectorCodeDesc2\":\"Agriculture, Environmental and Animal Care\",\"EffectiveFrom\":\"2017-06-01T00:00:00\",\"CreatedDateTimeUtc\":\"2017-07-10T20:02:36.453\",\"ModifiedDateTimeUtc\":\"2019-03-08T21:01:29.977\"},{\"Id\":\"D9A9A2A1-EC83-4FCA-8152-A7F162E90DF6\",\"StandardSectorCodeId\":\"74\",\"StandardSectorCodeDesc\":\"Sales, Marketing and Procurement\",\"StandardSectorCodeDesc2\":\"Sales, Marketing and Procurement\",\"EffectiveFrom\":\"2017-08-01T00:00:00\",\"CreatedDateTimeUtc\":\"2017-09-15T20:01:48.167\",\"ModifiedDateTimeUtc\":\"2019-03-08T21:01:29.977\"},{\"Id\":\"CA89F9C0-4411-4515-AD37-0318E95FC7EF\",\"StandardSectorCodeId\":\"75\",\"StandardSectorCodeDesc\":\"Business\",\"StandardSectorCodeDesc2\":\"Business\",\"EffectiveFrom\":\"2017-09-18T00:00:00\",\"CreatedDateTimeUtc\":\"2017-09-21T20:01:16.770\",\"ModifiedDateTimeUtc\":\"2019-03-08T21:01:29.977\"},{\"Id\":\"EC710152-C414-4CB8-8068-B861404B59DF\",\"StandardSectorCodeId\":\"8\",\"StandardSectorCodeDesc\":\"Energy and Utilities\",\"StandardSectorCodeDesc2\":\"Energy and Utilities\",\"EffectiveFrom\":\"2015-03-18T00:00:00\",\"CreatedDateTimeUtc\":\"2016-02-08T10:57:25.163\",\"ModifiedDateTimeUtc\":\"2019-03-08T21:01:29.977\"},{\"Id\":\"DC5ECBCE-77D0-4765-AF17-43B7EC293BF4\",\"StandardSectorCodeId\":\"9\",\"StandardSectorCodeDesc\":\"Financial Services\",\"StandardSectorCodeDesc2\":\"Financial Services\",\"EffectiveFrom\":\"2015-03-26T00:00:00\",\"CreatedDateTimeUtc\":\"2016-02-08T10:57:25.163\",\"ModifiedDateTimeUtc\":\"2019-03-08T21:01:29.977\"}]";

        private readonly ICosmosDbHelper _cosmosDbHelper;
        private readonly ICosmosDbSettings _cosmosDbSettings;
        private readonly ICosmosDbCollectionSettings _cosmosDbCollectionSettings;

        public StandardSectorCodeService(
            ICosmosDbHelper cosmosDbHelper,
            IOptions<CosmosDbSettings> cosmosDbSettings,
            IOptions<CosmosDbCollectionSettings> cosmosDbCollectionSettings)
        {
            Throw.IfNull(cosmosDbHelper, nameof(cosmosDbHelper));
            Throw.IfNull(cosmosDbSettings, nameof(cosmosDbSettings));
            Throw.IfNull(cosmosDbCollectionSettings, nameof(cosmosDbCollectionSettings));

            _cosmosDbHelper = cosmosDbHelper;
            _cosmosDbSettings = cosmosDbSettings.Value;
            _cosmosDbCollectionSettings = cosmosDbCollectionSettings.Value;
        }

        public Task<IEnumerable<StandardSectorCode>> GetAllAsync()
        {
            var uri = UriFactory.CreateDocumentCollectionUri(_cosmosDbSettings.DatabaseId, _cosmosDbCollectionSettings.StandardSectorCodesCollectionId);
            var sql = $"SELECT * FROM c";
            var options = new FeedOptions { EnableCrossPartitionQuery = true, MaxItemCount = -1 };
            var client = _cosmosDbHelper.GetClient();
            var results = client.CreateDocumentQuery<StandardSectorCode>(uri, sql, options).AsEnumerable();
            return Task.FromResult(results);
        }

        public Task<StandardSectorCode> GetByStandardSectorCodeIdAsync(int standardSectorCodeId)
        {
            var uri = UriFactory.CreateDocumentCollectionUri(_cosmosDbSettings.DatabaseId, _cosmosDbCollectionSettings.StandardSectorCodesCollectionId);
            var sql = $"SELECT * FROM c WHERE c.StandardSectorCodeId = {standardSectorCodeId}";
            var options = new FeedOptions { EnableCrossPartitionQuery = true, MaxItemCount = -1 };
            var client = _cosmosDbHelper.GetClient();
            var results = client.CreateDocumentQuery<StandardSectorCode>(uri, sql, options).FirstOrDefault();
            return Task.FromResult(results);
        }
    }
}