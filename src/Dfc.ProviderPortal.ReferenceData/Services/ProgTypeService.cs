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
    public class ProgTypeService : IProgTypeService
    {
        private const string STUB_JSON_DATA = "[{\"Id\":\"DDBCAA6E-A79E-4D38-97E7-F20DFB0DD755\",\"ProgTypeId\":-2,\"ProgTypeDesc\":\"Not Applicable\",\"ProgTypeDesc2\":\"Not App\",\"EffectiveFrom\":\"2008-08-01T00:00:00\",\"CreatedDateTimeUtc\":\"2016-02-08T10:57:23.970\",\"ModifiedDateTimeUtc\":\"2019-03-08T21:01:28.450\"},{\"Id\":\"FC596E2A-CE7E-4327-B655-02B77E01A77B\",\"ProgTypeId\":-1,\"ProgTypeDesc\":\"Unknown\",\"ProgTypeDesc2\":\"Unknown\",\"EffectiveFrom\":\"2001-08-01T00:00:00\",\"EffectiveTo\":\"2013-07-31T00:00:00\",\"CreatedDateTimeUtc\":\"2016-02-08T10:57:23.970\",\"ModifiedDateTimeUtc\":\"2019-03-08T21:01:28.450\"},{\"Id\":\"A576FD30-95B8-447B-AB5E-AAE2169C574F\",\"ProgTypeId\":1,\"ProgTypeDesc\":\"Life Skills\",\"ProgTypeDesc2\":\"Life Skills\",\"EffectiveFrom\":\"2001-08-01T00:00:00\",\"EffectiveTo\":\"2013-07-31T00:00:00\",\"CreatedDateTimeUtc\":\"2016-02-08T10:57:23.970\",\"ModifiedDateTimeUtc\":\"2019-03-08T21:01:28.450\"},{\"Id\":\"63159978-E930-4F8D-AAA1-B4DE9D2F7E7F\",\"ProgTypeId\":2,\"ProgTypeDesc\":\"Advanced Apprenticeship (Level 3)\",\"ProgTypeDesc2\":\"Adv App Lvl 3\",\"EffectiveFrom\":\"2008-08-01T00:00:00\",\"CreatedDateTimeUtc\":\"2016-02-08T10:57:23.970\",\"ModifiedDateTimeUtc\":\"2019-03-08T21:01:28.450\"},{\"Id\":\"E05E9A80-FA85-40FC-ADBC-B5BC789F7616\",\"ProgTypeId\":3,\"ProgTypeDesc\":\"Intermediate Apprenticeship (Level 2)\",\"ProgTypeDesc2\":\"Int App Lvl 2\",\"EffectiveFrom\":\"2008-08-01T00:00:00\",\"CreatedDateTimeUtc\":\"2016-02-08T10:57:23.970\",\"ModifiedDateTimeUtc\":\"2019-03-08T21:01:28.450\"},{\"Id\":\"FAC0DC63-3749-41EE-A7FB-726A2DC07B99\",\"ProgTypeId\":4,\"ProgTypeDesc\":\"NVQ Level 1 (19 and over only)\",\"ProgTypeDesc2\":\"NVQ 1\",\"EffectiveFrom\":\"2001-08-01T00:00:00\",\"EffectiveTo\":\"2013-07-31T00:00:00\",\"CreatedDateTimeUtc\":\"2016-02-08T10:57:23.970\",\"ModifiedDateTimeUtc\":\"2019-03-08T21:01:28.450\"},{\"Id\":\"88FF9581-BF44-4A09-BA65-A68EDF12CAF7\",\"ProgTypeId\":5,\"ProgTypeDesc\":\"NVQ Level 2\",\"ProgTypeDesc2\":\"NVQ 2\",\"EffectiveFrom\":\"2001-08-01T00:00:00\",\"EffectiveTo\":\"2013-07-31T00:00:00\",\"CreatedDateTimeUtc\":\"2016-02-08T10:57:23.970\",\"ModifiedDateTimeUtc\":\"2019-03-08T21:01:28.450\"},{\"Id\":\"68ACBF9E-5AEE-4C23-89BA-3623638789D0\",\"ProgTypeId\":6,\"ProgTypeDesc\":\"NVQ Level 3\",\"ProgTypeDesc2\":\"NVQ 3\",\"EffectiveFrom\":\"2001-08-01T00:00:00\",\"EffectiveTo\":\"2013-07-31T00:00:00\",\"CreatedDateTimeUtc\":\"2016-02-08T10:57:23.970\",\"ModifiedDateTimeUtc\":\"2019-03-08T21:01:28.450\"},{\"Id\":\"A11B22BA-4C75-4B80-A827-1AFE385FA05D\",\"ProgTypeId\":7,\"ProgTypeDesc\":\"NVQ Level 4\",\"ProgTypeDesc2\":\"NVQ 4\",\"EffectiveFrom\":\"2001-08-01T00:00:00\",\"EffectiveTo\":\"2013-07-31T00:00:00\",\"CreatedDateTimeUtc\":\"2016-02-08T10:57:23.970\",\"ModifiedDateTimeUtc\":\"2019-03-08T21:01:28.450\"},{\"Id\":\"DCE989E0-035D-4953-823B-2AC636E06A72\",\"ProgTypeId\":8,\"ProgTypeDesc\":\"Preparatory Learning\",\"ProgTypeDesc2\":\"Prep Lrn\",\"EffectiveFrom\":\"2001-08-01T00:00:00\",\"EffectiveTo\":\"2013-07-31T00:00:00\",\"CreatedDateTimeUtc\":\"2016-02-08T10:57:23.970\",\"ModifiedDateTimeUtc\":\"2019-03-08T21:01:28.450\"},{\"Id\":\"5C4DD067-F006-4F08-ADB5-BFAC742593C8\",\"ProgTypeId\":9,\"ProgTypeDesc\":\"Entry to Employment (E2E)\",\"ProgTypeDesc2\":\"E2E\",\"EffectiveFrom\":\"2001-08-01T00:00:00\",\"EffectiveTo\":\"2013-07-31T00:00:00\",\"CreatedDateTimeUtc\":\"2016-02-08T10:57:23.970\",\"ModifiedDateTimeUtc\":\"2019-03-08T21:01:28.450\"},{\"Id\":\"4A92ADA7-6261-4CAD-A7A8-1B6B2DB7AE9E\",\"ProgTypeId\":10,\"ProgTypeDesc\":\"Higher Level Apprenticeship\",\"ProgTypeDesc2\":\"HL App\",\"EffectiveFrom\":\"2008-08-01T00:00:00\",\"CreatedDateTimeUtc\":\"2016-02-08T10:57:23.970\",\"ModifiedDateTimeUtc\":\"2019-03-08T21:01:28.450\"},{\"Id\":\"0209B001-3F89-44DC-B1CC-1AE99D06026A\",\"ProgTypeId\":11,\"ProgTypeDesc\":\"Progression Pathway to a Level 2 Apprenticeship Framework\",\"ProgTypeDesc2\":\"Prg Pth L2 App\",\"EffectiveFrom\":\"2008-08-01T00:00:00\",\"EffectiveTo\":\"2013-07-31T00:00:00\",\"CreatedDateTimeUtc\":\"2016-02-08T10:57:23.970\",\"ModifiedDateTimeUtc\":\"2019-03-08T21:01:28.450\"},{\"Id\":\"2B0B4BA5-EF89-4736-A90C-6D9056CE21D0\",\"ProgTypeId\":12,\"ProgTypeDesc\":\"Progression Pathway to a first full Level 2 (In The QCF)\",\"ProgTypeDesc2\":\"Prg Pth 1st Full L2\",\"EffectiveFrom\":\"2008-08-01T00:00:00\",\"EffectiveTo\":\"2013-07-31T00:00:00\",\"CreatedDateTimeUtc\":\"2016-02-08T10:57:23.970\",\"ModifiedDateTimeUtc\":\"2019-03-08T21:01:28.450\"},{\"Id\":\"96655833-8DEE-4C6E-BB7C-2A456B413B71\",\"ProgTypeId\":13,\"ProgTypeDesc\":\"Progression Pathway to independent living or supported employment\",\"ProgTypeDesc2\":\"Prg Pth Indep Lvg\",\"EffectiveFrom\":\"2008-08-01T00:00:00\",\"EffectiveTo\":\"2013-07-31T00:00:00\",\"CreatedDateTimeUtc\":\"2016-02-08T10:57:23.970\",\"ModifiedDateTimeUtc\":\"2019-03-08T21:01:28.450\"},{\"Id\":\"E1B7430C-3C98-4A4B-AAEB-36CDF65D268E\",\"ProgTypeId\":14,\"ProgTypeDesc\":\"Progression Pathway to a Foundation (Level 1) Diploma or GCSEs\",\"ProgTypeDesc2\":\"Prg Pth F Dip GCSE\",\"EffectiveFrom\":\"2008-08-01T00:00:00\",\"EffectiveTo\":\"2013-07-31T00:00:00\",\"CreatedDateTimeUtc\":\"2016-02-08T10:57:23.970\",\"ModifiedDateTimeUtc\":\"2019-03-08T21:01:28.450\"},{\"Id\":\"FB9474E8-EC5D-47FA-AC23-610A4EC58D04\",\"ProgTypeId\":15,\"ProgTypeDesc\":\"Diploma Level 1 (Foundation)\",\"ProgTypeDesc2\":\"Dip L1 Found\",\"EffectiveFrom\":\"2008-08-01T00:00:00\",\"CreatedDateTimeUtc\":\"2016-02-08T10:57:23.970\",\"ModifiedDateTimeUtc\":\"2019-03-08T21:01:28.450\"},{\"Id\":\"5D5DBD2D-9DE5-457D-BE98-E8522BA0F9A1\",\"ProgTypeId\":16,\"ProgTypeDesc\":\"Diploma Level 2 (Higher)\",\"ProgTypeDesc2\":\"Dip L2 High\",\"EffectiveFrom\":\"2008-08-01T00:00:00\",\"CreatedDateTimeUtc\":\"2016-02-08T10:57:23.970\",\"ModifiedDateTimeUtc\":\"2019-03-08T21:01:28.450\"},{\"Id\":\"37213404-D959-41F3-B542-74779BDD34A6\",\"ProgTypeId\":17,\"ProgTypeDesc\":\"Diploma Level 3 (Progression)\",\"ProgTypeDesc2\":\"Dip L3 Prog\",\"EffectiveFrom\":\"2008-08-01T00:00:00\",\"CreatedDateTimeUtc\":\"2016-02-08T10:57:23.970\",\"ModifiedDateTimeUtc\":\"2019-03-08T21:01:28.450\"},{\"Id\":\"9646322B-4F5A-42E1-8DF3-FEF34CF6C528\",\"ProgTypeId\":18,\"ProgTypeDesc\":\"Diploma Level 3 (Advanced)\",\"ProgTypeDesc2\":\"Dip L4 Adv\",\"EffectiveFrom\":\"2008-08-01T00:00:00\",\"CreatedDateTimeUtc\":\"2016-02-08T10:57:23.970\",\"ModifiedDateTimeUtc\":\"2019-03-08T21:01:28.450\"},{\"Id\":\"45BF3A8F-0FA7-4AFE-AF53-DD044CB76277\",\"ProgTypeId\":19,\"ProgTypeDesc\":\"Foundation Learning Programme\",\"ProgTypeDesc2\":\"Found Lrng Prog\",\"EffectiveFrom\":\"2010-05-20T00:00:00\",\"EffectiveTo\":\"2013-07-31T00:00:00\",\"CreatedDateTimeUtc\":\"2016-02-08T10:57:23.970\",\"ModifiedDateTimeUtc\":\"2019-03-08T21:01:28.450\"},{\"Id\":\"31C728CC-9A8F-400F-9D4E-D2580EE7B3A1\",\"ProgTypeId\":20,\"ProgTypeDesc\":\"Higher Apprenticeship (Level 4)\",\"ProgTypeDesc2\":\"Hgh App Lvl 4\",\"EffectiveFrom\":\"2011-08-01T00:00:00\",\"CreatedDateTimeUtc\":\"2016-02-08T10:57:23.970\",\"ModifiedDateTimeUtc\":\"2019-03-08T21:01:28.450\"},{\"Id\":\"EEDC711A-2A19-4928-BFCC-09B15ECA4414\",\"ProgTypeId\":21,\"ProgTypeDesc\":\"Higher Apprenticeship (Level 5)\",\"ProgTypeDesc2\":\"Hgh App Lvl 5\",\"EffectiveFrom\":\"2011-08-01T00:00:00\",\"CreatedDateTimeUtc\":\"2016-02-08T10:57:23.970\",\"ModifiedDateTimeUtc\":\"2019-03-08T21:01:28.450\"},{\"Id\":\"46BB9576-10FB-4ACC-8944-8ABDB93CCB85\",\"ProgTypeId\":22,\"ProgTypeDesc\":\"Higher Apprenticeship (Level 6)\",\"ProgTypeDesc2\":\"Hgh App Lvl 6\",\"EffectiveFrom\":\"2013-08-01T00:00:00\",\"CreatedDateTimeUtc\":\"2016-02-08T10:57:23.970\",\"ModifiedDateTimeUtc\":\"2019-03-08T21:01:28.450\"},{\"Id\":\"8F7050DB-4B79-4106-A795-68F554E3DD19\",\"ProgTypeId\":23,\"ProgTypeDesc\":\"Higher Apprenticeship (Level 7+)\",\"ProgTypeDesc2\":\"Hgh App Lvl 7+\",\"EffectiveFrom\":\"2013-08-01T00:00:00\",\"CreatedDateTimeUtc\":\"2016-02-08T10:57:23.970\",\"ModifiedDateTimeUtc\":\"2019-03-08T21:01:28.450\"},{\"Id\":\"03CE4AA1-83B8-4D9C-ABEC-E7423C5B6D5C\",\"ProgTypeId\":24,\"ProgTypeDesc\":\"Traineeship\",\"ProgTypeDesc2\":\"Traineeship\",\"EffectiveFrom\":\"2014-08-01T00:00:00\",\"CreatedDateTimeUtc\":\"2016-02-08T10:57:23.970\",\"ModifiedDateTimeUtc\":\"2019-03-08T21:01:28.450\"},{\"Id\":\"FA2BBFA8-D9B2-4D61-86E8-59050B53BB26\",\"ProgTypeId\":25,\"ProgTypeDesc\":\"Apprenticeship Standard\",\"ProgTypeDesc2\":\"Apprenticeship Standard\",\"EffectiveFrom\":\"2015-08-01T00:00:00\",\"CreatedDateTimeUtc\":\"2016-05-06T10:22:45.193\",\"ModifiedDateTimeUtc\":\"2019-03-08T21:01:28.450\"},{\"Id\":\"B48A66D7-4A41-42A6-AF07-55BDDA2D4CAB\",\"ProgTypeId\":99,\"ProgTypeDesc\":\"None Of The Above\",\"ProgTypeDesc2\":\"None\",\"EffectiveFrom\":\"2008-08-01T00:00:00\",\"CreatedDateTimeUtc\":\"2016-02-08T10:57:23.970\",\"ModifiedDateTimeUtc\":\"2019-03-08T21:01:28.450\"}]";

        private readonly ICosmosDbHelper _cosmosDbHelper;
        private readonly ICosmosDbSettings _cosmosDbSettings;
        private readonly ICosmosDbCollectionSettings _cosmosDbCollectionSettings;

        public ProgTypeService(
            ICosmosDbHelper cosmosDbHelper,
            IOptions<CosmosDbSettings> cosmosDbSettings,
            IOptions<CosmosDbCollectionSettings> cosmosDbCollectionSettings) : this(cosmosDbHelper, cosmosDbSettings.Value, cosmosDbCollectionSettings.Value)
        {
            Throw.IfNull(cosmosDbHelper, nameof(cosmosDbHelper));
            Throw.IfNull(cosmosDbSettings, nameof(cosmosDbSettings));
            Throw.IfNull(cosmosDbCollectionSettings, nameof(cosmosDbCollectionSettings));
        }

        public ProgTypeService(
            ICosmosDbHelper cosmosDbHelper,
            CosmosDbSettings cosmosDbSettings,
            CosmosDbCollectionSettings cosmosDbCollectionSettings)
        {
            Throw.IfNull(cosmosDbHelper, nameof(cosmosDbHelper));
            Throw.IfNull(cosmosDbSettings, nameof(cosmosDbSettings));
            Throw.IfNull(cosmosDbCollectionSettings, nameof(cosmosDbCollectionSettings));

            _cosmosDbHelper = cosmosDbHelper;
            _cosmosDbSettings = cosmosDbSettings;
            _cosmosDbCollectionSettings = cosmosDbCollectionSettings;
        }

        public Task<IEnumerable<ProgType>> GetAllAsync()
        {
            var uri = UriFactory.CreateDocumentCollectionUri(_cosmosDbSettings.DatabaseId, _cosmosDbCollectionSettings.ProgTypesCollectionId);
            var sql = $"SELECT * FROM c";
            var options = new FeedOptions { EnableCrossPartitionQuery = true, MaxItemCount = -1 };
            var client = _cosmosDbHelper.GetClient();
            var results = client.CreateDocumentQuery<ProgType>(uri, sql, options).AsEnumerable();
            return Task.FromResult(results);
        }

        public Task<ProgType> GetByProgTypeIdAsync(int progTypeId)
        {
            var uri = UriFactory.CreateDocumentCollectionUri(_cosmosDbSettings.DatabaseId, _cosmosDbCollectionSettings.ProgTypesCollectionId);
            var sql = $"SELECT * FROM c WHERE c.ProgTypeId = {progTypeId}";
            var options = new FeedOptions { EnableCrossPartitionQuery = true, MaxItemCount = -1 };
            var client = _cosmosDbHelper.GetClient();
            var results = client.CreateDocumentQuery<ProgType>(uri, sql, options).AsEnumerable().FirstOrDefault();
            return Task.FromResult(results);
        }
    }
}