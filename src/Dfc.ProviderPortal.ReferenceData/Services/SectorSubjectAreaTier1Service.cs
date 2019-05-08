using Dfc.ProviderPortal.Packages;
using Dfc.ProviderPortal.ReferenceData.Interfaces;
using Dfc.ProviderPortal.ReferenceData.Models;
using Dfc.ProviderPortal.ReferenceData.Settings;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dfc.ProviderPortal.ReferenceData.Services
{
    public class SectorSubjectAreaTier1Service : ISectorSubjectAreaTier1Service
    {
        private const string STUB_JSON_DATA = "[{\"Id\":\"B67443DA-8002-4D26-8E10-725EED5E618B\",\"SectorSubjectAreaTier1Id\":-2.00,\"SectorSubjectAreaTier1Desc\":\"Not Applicable\",\"SectorSubjectAreaTier1Desc2\":\"Not App\",\"EffectiveFrom\":\"2012-08-01T00:00:00\",\"CreatedDateTimeUtc\":\"2016-02-08T10:57:23.923\",\"ModifiedDateTimeUtc\":\"2019-03-08T21:01:28.440\"},{\"Id\":\"77DE34A3-C6BC-4845-A990-CD6CC1E68CED\",\"SectorSubjectAreaTier1Id\":-1.00,\"SectorSubjectAreaTier1Desc\":\"Unknown\",\"SectorSubjectAreaTier1Desc2\":\"Unknown\",\"EffectiveFrom\":\"2012-08-01T00:00:00\",\"CreatedDateTimeUtc\":\"2016-02-08T10:57:23.923\",\"ModifiedDateTimeUtc\":\"2019-03-08T21:01:28.440\"},{\"Id\":\"ED8532B2-F4EF-4F07-AFA3-FA534543FBBD\",\"SectorSubjectAreaTier1Id\":1.00,\"SectorSubjectAreaTier1Desc\":\"Health, Public Services and Care\",\"SectorSubjectAreaTier1Desc2\":\"Hlth, Pub Svces & Care\",\"EffectiveFrom\":\"2004-01-01T00:00:00\",\"CreatedDateTimeUtc\":\"2016-02-08T10:57:23.923\",\"ModifiedDateTimeUtc\":\"2019-03-08T21:01:28.440\"},{\"Id\":\"AE05BFAC-CE88-4F16-BFFB-8331C3715093\",\"SectorSubjectAreaTier1Id\":2.00,\"SectorSubjectAreaTier1Desc\":\"Science and Mathematics\",\"SectorSubjectAreaTier1Desc2\":\"Sci and Maths\",\"EffectiveFrom\":\"2004-01-01T00:00:00\",\"CreatedDateTimeUtc\":\"2016-02-08T10:57:23.923\",\"ModifiedDateTimeUtc\":\"2019-03-08T21:01:28.440\"},{\"Id\":\"9E81ECF6-3A8A-4989-9AA2-FCA1E8034DE9\",\"SectorSubjectAreaTier1Id\":3.00,\"SectorSubjectAreaTier1Desc\":\"Agriculture, Horticulture and Animal Care\",\"SectorSubjectAreaTier1Desc2\":\"Agric, Hortic & Anim Care\",\"EffectiveFrom\":\"2004-01-01T00:00:00\",\"CreatedDateTimeUtc\":\"2016-02-08T10:57:23.923\",\"ModifiedDateTimeUtc\":\"2019-03-08T21:01:28.440\"},{\"Id\":\"2478A425-94E0-41B5-901D-9058D35999D1\",\"SectorSubjectAreaTier1Id\":4.00,\"SectorSubjectAreaTier1Desc\":\"Engineering and Manufacturing Technologies\",\"SectorSubjectAreaTier1Desc2\":\"Engin & Manuf Tech\",\"EffectiveFrom\":\"2004-01-01T00:00:00\",\"CreatedDateTimeUtc\":\"2016-02-08T10:57:23.923\",\"ModifiedDateTimeUtc\":\"2019-03-08T21:01:28.440\"},{\"Id\":\"1C136440-30C8-4FCA-BEE3-A1EAA9D3EEF7\",\"SectorSubjectAreaTier1Id\":5.00,\"SectorSubjectAreaTier1Desc\":\"Construction, Planning and the Built Environment\",\"SectorSubjectAreaTier1Desc2\":\"Const, Plan & Built Envir\",\"EffectiveFrom\":\"2004-01-01T00:00:00\",\"CreatedDateTimeUtc\":\"2016-02-08T10:57:23.923\",\"ModifiedDateTimeUtc\":\"2019-03-08T21:01:28.440\"},{\"Id\":\"2CBB3E42-B1CC-48A5-B1D6-5DCAA9317F7E\",\"SectorSubjectAreaTier1Id\":6.00,\"SectorSubjectAreaTier1Desc\":\"Information and Communication Technology\",\"SectorSubjectAreaTier1Desc2\":\"Info & Comm Tech\",\"EffectiveFrom\":\"2004-01-01T00:00:00\",\"CreatedDateTimeUtc\":\"2016-02-08T10:57:23.923\",\"ModifiedDateTimeUtc\":\"2019-03-08T21:01:28.440\"},{\"Id\":\"8B84056D-3F3C-4583-B49E-648E16DC046E\",\"SectorSubjectAreaTier1Id\":7.00,\"SectorSubjectAreaTier1Desc\":\"Retail and Commercial Enterprise\",\"SectorSubjectAreaTier1Desc2\":\"Retail & Comm Enerp\",\"EffectiveFrom\":\"2004-01-01T00:00:00\",\"CreatedDateTimeUtc\":\"2016-02-08T10:57:23.923\",\"ModifiedDateTimeUtc\":\"2019-03-08T21:01:28.440\"},{\"Id\":\"700CE891-C93E-41E2-9EF0-F2A477CBE144\",\"SectorSubjectAreaTier1Id\":8.00,\"SectorSubjectAreaTier1Desc\":\"Leisure, Travel and Tourism\",\"SectorSubjectAreaTier1Desc2\":\"Leis, Travel & Tour\",\"EffectiveFrom\":\"2004-01-01T00:00:00\",\"CreatedDateTimeUtc\":\"2016-02-08T10:57:23.923\",\"ModifiedDateTimeUtc\":\"2019-03-08T21:01:28.440\"},{\"Id\":\"2AF9BFDA-E06D-41BC-AA3F-CCCF6904CAEE\",\"SectorSubjectAreaTier1Id\":9.00,\"SectorSubjectAreaTier1Desc\":\"Arts, Media and Publishing\",\"SectorSubjectAreaTier1Desc2\":\"Art, Media & Pub\",\"EffectiveFrom\":\"2004-01-01T00:00:00\",\"CreatedDateTimeUtc\":\"2016-02-08T10:57:23.923\",\"ModifiedDateTimeUtc\":\"2019-03-08T21:01:28.440\"},{\"Id\":\"25A71E5B-4473-43EF-AA98-106E4D3F8763\",\"SectorSubjectAreaTier1Id\":10.00,\"SectorSubjectAreaTier1Desc\":\"History, Philosophy and Theology\",\"SectorSubjectAreaTier1Desc2\":\"Hist, Phil & Theol\",\"EffectiveFrom\":\"2004-01-01T00:00:00\",\"CreatedDateTimeUtc\":\"2016-02-08T10:57:23.923\",\"ModifiedDateTimeUtc\":\"2019-03-08T21:01:28.440\"},{\"Id\":\"007B6BBA-17A8-4764-A737-D30B2D021B0D\",\"SectorSubjectAreaTier1Id\":11.00,\"SectorSubjectAreaTier1Desc\":\"Social Sciences\",\"SectorSubjectAreaTier1Desc2\":\"Soc Sciences\",\"EffectiveFrom\":\"2004-01-01T00:00:00\",\"CreatedDateTimeUtc\":\"2016-02-08T10:57:23.923\",\"ModifiedDateTimeUtc\":\"2019-03-08T21:01:28.440\"},{\"Id\":\"41D9D75F-3770-49B1-BCF8-6E5AA8D95965\",\"SectorSubjectAreaTier1Id\":12.00,\"SectorSubjectAreaTier1Desc\":\"Languages, Literature and Culture\",\"SectorSubjectAreaTier1Desc2\":\"Lang, Lit & Cult\",\"EffectiveFrom\":\"2004-01-01T00:00:00\",\"CreatedDateTimeUtc\":\"2016-02-08T10:57:23.923\",\"ModifiedDateTimeUtc\":\"2019-03-08T21:01:28.440\"},{\"Id\":\"651E19AE-0622-4E39-BA6F-760328AAE7E7\",\"SectorSubjectAreaTier1Id\":13.00,\"SectorSubjectAreaTier1Desc\":\"Education and Training\",\"SectorSubjectAreaTier1Desc2\":\"Educ & Train\",\"EffectiveFrom\":\"2004-01-01T00:00:00\",\"CreatedDateTimeUtc\":\"2016-02-08T10:57:23.923\",\"ModifiedDateTimeUtc\":\"2019-03-08T21:01:28.440\"},{\"Id\":\"06CEA24C-4C6E-4CDB-B990-C8D61FB5DF70\",\"SectorSubjectAreaTier1Id\":14.00,\"SectorSubjectAreaTier1Desc\":\"Preparation for Life and Work\",\"SectorSubjectAreaTier1Desc2\":\"Prep for Life & Work\",\"EffectiveFrom\":\"2004-01-01T00:00:00\",\"CreatedDateTimeUtc\":\"2016-02-08T10:57:23.923\",\"ModifiedDateTimeUtc\":\"2019-03-08T21:01:28.440\"},{\"Id\":\"2F9252D0-E11F-4BB5-AA52-9CB27E70F99A\",\"SectorSubjectAreaTier1Id\":15.00,\"SectorSubjectAreaTier1Desc\":\"Business, Administration and Law\",\"SectorSubjectAreaTier1Desc2\":\"Bus, Admin & Law\",\"EffectiveFrom\":\"2004-01-01T00:00:00\",\"CreatedDateTimeUtc\":\"2016-02-08T10:57:23.923\",\"ModifiedDateTimeUtc\":\"2019-03-08T21:01:28.440\"}]";

        private readonly ICosmosDbHelper _cosmosDbHelper;
        private readonly ICosmosDbSettings _cosmosDbSettings;
        private readonly ICosmosDbCollectionSettings _cosmosDbCollectionSettings;

        public SectorSubjectAreaTier1Service(
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

        public Task<IEnumerable<SectorSubjectAreaTier1>> GetAllAsync()
        {
            var results = JsonConvert.DeserializeObject<IEnumerable<SectorSubjectAreaTier1>>(STUB_JSON_DATA);
            return Task.FromResult(results);
        }

        public Task<SectorSubjectAreaTier1> GetBySectorSubjectAreaTier1IdAsync(decimal sectorSubjectAreaTier1Id)
        {
            var results = JsonConvert.DeserializeObject<IEnumerable<SectorSubjectAreaTier1>>(STUB_JSON_DATA);
            var found = results.FirstOrDefault(x => x.SectorSubjectAreaTier1Id == sectorSubjectAreaTier1Id);
            return Task.FromResult(found);
        }
    }
}