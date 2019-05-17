using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;

namespace Dfc.ProviderPortal.ReferenceData.Functions
{
    public static class Swagger
    {
        [FunctionName("Swagger")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "referencedata/swagger.json")] HttpRequest req,
            ILogger log)
        {
            var SWAGGER_JSON = "{\"openapi\":\"3.0.1\",\"info\":{\"title\":\"Apprenticeship Reference Data API\",\"version\":\"v1\"},\"paths\":{\"/api/referencedata/fe-choices\":{\"get\":{\"tags\":[\"Doc\"],\"parameters\":[{\"name\":\"code\",\"in\":\"query\",\"required\":true,\"schema\":{\"type\":\"string\",\"default\":\"\"}}],\"responses\":{\"200\":{\"description\":\"Success\",\"content\":{\"application/json\":{\"schema\":{\"type\":\"array\",\"items\":{\"$ref\":\"#/components/schemas/FeChoice\"}}}}},\"404\":{\"description\":\"Not Found\",\"content\":{\"application/json\":{\"schema\":{\"$ref\":\"#/components/schemas/ProblemDetails\"}}}},\"500\":{\"description\":\"Server Error\"}}}},\"/api/referencedata/fe-choices/{upin}\":{\"get\":{\"tags\":[\"Doc\"],\"parameters\":[{\"name\":\"upin\",\"in\":\"path\",\"required\":true,\"schema\":{\"type\":\"integer\",\"format\":\"int32\"}},{\"name\":\"code\",\"in\":\"query\",\"required\":true,\"schema\":{\"type\":\"string\",\"default\":\"\"}}],\"responses\":{\"200\":{\"description\":\"Success\",\"content\":{\"application/json\":{\"schema\":{\"$ref\":\"#/components/schemas/FeChoice\"}}}},\"400\":{\"description\":\"Bad Request\",\"content\":{\"application/json\":{\"schema\":{\"$ref\":\"#/components/schemas/ProblemDetails\"}}}},\"404\":{\"description\":\"Not Found\",\"content\":{\"application/json\":{\"schema\":{\"$ref\":\"#/components/schemas/ProblemDetails\"}}}},\"500\":{\"description\":\"Server Error\"}}}},\"/api/referencedata/prog-types\":{\"get\":{\"tags\":[\"Doc\"],\"parameters\":[{\"name\":\"code\",\"in\":\"query\",\"required\":true,\"schema\":{\"type\":\"string\",\"default\":\"\"}}],\"responses\":{\"200\":{\"description\":\"Success\",\"content\":{\"application/json\":{\"schema\":{\"type\":\"array\",\"items\":{\"$ref\":\"#/components/schemas/ProgType\"}}}}},\"404\":{\"description\":\"Not Found\",\"content\":{\"application/json\":{\"schema\":{\"$ref\":\"#/components/schemas/ProblemDetails\"}}}},\"500\":{\"description\":\"Server Error\"}}}},\"/api/referencedata/prog-types/{progTypeId}\":{\"get\":{\"tags\":[\"Doc\"],\"parameters\":[{\"name\":\"progTypeId\",\"in\":\"path\",\"required\":true,\"schema\":{\"type\":\"integer\",\"format\":\"int32\"}},{\"name\":\"code\",\"in\":\"query\",\"required\":true,\"schema\":{\"type\":\"string\",\"default\":\"\"}}],\"responses\":{\"200\":{\"description\":\"Success\",\"content\":{\"application/json\":{\"schema\":{\"$ref\":\"#/components/schemas/ProgType\"}}}},\"400\":{\"description\":\"Bad Request\",\"content\":{\"application/json\":{\"schema\":{\"$ref\":\"#/components/schemas/ProblemDetails\"}}}},\"404\":{\"description\":\"Not Found\",\"content\":{\"application/json\":{\"schema\":{\"$ref\":\"#/components/schemas/ProblemDetails\"}}}},\"500\":{\"description\":\"Server Error\"}}}},\"/api/referencedata/sector-subject-area-tier-1s\":{\"get\":{\"tags\":[\"Doc\"],\"parameters\":[{\"name\":\"code\",\"in\":\"query\",\"required\":true,\"schema\":{\"type\":\"string\",\"default\":\"\"}}],\"responses\":{\"200\":{\"description\":\"Success\",\"content\":{\"application/json\":{\"schema\":{\"type\":\"array\",\"items\":{\"$ref\":\"#/components/schemas/SectorSubjectAreaTier1\"}}}}},\"404\":{\"description\":\"Not Found\",\"content\":{\"application/json\":{\"schema\":{\"$ref\":\"#/components/schemas/ProblemDetails\"}}}},\"500\":{\"description\":\"Server Error\"}}}},\"/api/referencedata/sector-subject-area-tier-1s/{sectorSubjectAreaTier1Id}\":{\"get\":{\"tags\":[\"Doc\"],\"parameters\":[{\"name\":\"sectorSubjectAreaTier1Id\",\"in\":\"path\",\"required\":true,\"schema\":{\"type\":\"number\",\"format\":\"double\"}},{\"name\":\"code\",\"in\":\"query\",\"required\":true,\"schema\":{\"type\":\"string\",\"default\":\"\"}}],\"responses\":{\"200\":{\"description\":\"Success\",\"content\":{\"application/json\":{\"schema\":{\"$ref\":\"#/components/schemas/SectorSubjectAreaTier1\"}}}},\"400\":{\"description\":\"Bad Request\",\"content\":{\"application/json\":{\"schema\":{\"$ref\":\"#/components/schemas/ProblemDetails\"}}}},\"404\":{\"description\":\"Not Found\",\"content\":{\"application/json\":{\"schema\":{\"$ref\":\"#/components/schemas/ProblemDetails\"}}}},\"500\":{\"description\":\"Server Error\"}}}},\"/api/referencedata/sector-subject-area-tier-2s\":{\"get\":{\"tags\":[\"Doc\"],\"parameters\":[{\"name\":\"code\",\"in\":\"query\",\"required\":true,\"schema\":{\"type\":\"string\",\"default\":\"\"}}],\"responses\":{\"200\":{\"description\":\"Success\",\"content\":{\"application/json\":{\"schema\":{\"type\":\"array\",\"items\":{\"$ref\":\"#/components/schemas/SectorSubjectAreaTier2\"}}}}},\"404\":{\"description\":\"Not Found\",\"content\":{\"application/json\":{\"schema\":{\"$ref\":\"#/components/schemas/ProblemDetails\"}}}},\"500\":{\"description\":\"Server Error\"}}}},\"/api/referencedata/sector-subject-area-tier-2s/{sectorSubjectAreaTier2Id}\":{\"get\":{\"tags\":[\"Doc\"],\"parameters\":[{\"name\":\"sectorSubjectAreaTier2Id\",\"in\":\"path\",\"required\":true,\"schema\":{\"type\":\"number\",\"format\":\"double\"}},{\"name\":\"code\",\"in\":\"query\",\"required\":true,\"schema\":{\"type\":\"string\",\"default\":\"\"}}],\"responses\":{\"200\":{\"description\":\"Success\",\"content\":{\"application/json\":{\"schema\":{\"$ref\":\"#/components/schemas/SectorSubjectAreaTier2\"}}}},\"400\":{\"description\":\"Bad Request\",\"content\":{\"application/json\":{\"schema\":{\"$ref\":\"#/components/schemas/ProblemDetails\"}}}},\"404\":{\"description\":\"Not Found\",\"content\":{\"application/json\":{\"schema\":{\"$ref\":\"#/components/schemas/ProblemDetails\"}}}},\"500\":{\"description\":\"Server Error\"}}}},\"/api/referencedata/standard-sector-codes\":{\"get\":{\"tags\":[\"Doc\"],\"parameters\":[{\"name\":\"code\",\"in\":\"query\",\"required\":true,\"schema\":{\"type\":\"string\",\"default\":\"\"}}],\"responses\":{\"200\":{\"description\":\"Success\",\"content\":{\"application/json\":{\"schema\":{\"type\":\"array\",\"items\":{\"$ref\":\"#/components/schemas/StandardSectorCode\"}}}}},\"404\":{\"description\":\"Not Found\",\"content\":{\"application/json\":{\"schema\":{\"$ref\":\"#/components/schemas/ProblemDetails\"}}}},\"500\":{\"description\":\"Server Error\"}}}},\"/api/referencedata/standard-sector-codes/{standardSectorCodeId}\":{\"get\":{\"tags\":[\"Doc\"],\"parameters\":[{\"name\":\"standardSectorCodeId\",\"in\":\"path\",\"required\":true,\"schema\":{\"type\":\"integer\",\"format\":\"int32\"}},{\"name\":\"code\",\"in\":\"query\",\"required\":true,\"schema\":{\"type\":\"string\",\"default\":\"\"}}],\"responses\":{\"200\":{\"description\":\"Success\",\"content\":{\"application/json\":{\"schema\":{\"$ref\":\"#/components/schemas/StandardSectorCode\"}}}},\"400\":{\"description\":\"Bad Request\",\"content\":{\"application/json\":{\"schema\":{\"$ref\":\"#/components/schemas/ProblemDetails\"}}}},\"404\":{\"description\":\"Not Found\",\"content\":{\"application/json\":{\"schema\":{\"$ref\":\"#/components/schemas/ProblemDetails\"}}}},\"500\":{\"description\":\"Server Error\"}}}},\"/api/referencedata/apprenticeship-frameworks\":{\"get\":{\"tags\":[\"Doc\"],\"parameters\":[{\"name\":\"code\",\"in\":\"query\",\"required\":true,\"schema\":{\"type\":\"string\",\"default\":\"\"}}],\"responses\":{\"200\":{\"description\":\"Success\",\"content\":{\"application/json\":{\"schema\":{\"type\":\"array\",\"items\":{\"$ref\":\"#/components/schemas/ApprenticeshipFramework\"}}}}},\"404\":{\"description\":\"Not Found\",\"content\":{\"application/json\":{\"schema\":{\"$ref\":\"#/components/schemas/ProblemDetails\"}}}},\"500\":{\"description\":\"Server Error\"}}}},\"/api/referencedata/apprenticeship-frameworks/{frameworkCode}\":{\"get\":{\"tags\":[\"Doc\"],\"parameters\":[{\"name\":\"frameworkCode\",\"in\":\"path\",\"required\":true,\"schema\":{\"type\":\"integer\",\"format\":\"int32\"}},{\"name\":\"code\",\"in\":\"query\",\"required\":true,\"schema\":{\"type\":\"string\",\"default\":\"\"}}],\"responses\":{\"200\":{\"description\":\"Success\",\"content\":{\"application/json\":{\"schema\":{\"type\":\"array\",\"items\":{\"$ref\":\"#/components/schemas/ApprenticeshipFramework\"}}}}},\"400\":{\"description\":\"Bad Request\",\"content\":{\"application/json\":{\"schema\":{\"$ref\":\"#/components/schemas/ProblemDetails\"}}}},\"404\":{\"description\":\"Not Found\",\"content\":{\"application/json\":{\"schema\":{\"$ref\":\"#/components/schemas/ProblemDetails\"}}}},\"500\":{\"description\":\"Server Error\"}}}},\"/api/referencedata/apprenticeship-frameworks/{frameworkCode}/prog-type/{progtypeId}\":{\"get\":{\"tags\":[\"Doc\"],\"parameters\":[{\"name\":\"frameworkCode\",\"in\":\"path\",\"required\":true,\"schema\":{\"type\":\"integer\",\"format\":\"int32\"}},{\"name\":\"progTypeId\",\"in\":\"path\",\"required\":true,\"schema\":{\"type\":\"integer\",\"format\":\"int32\"}},{\"name\":\"code\",\"in\":\"query\",\"required\":true,\"schema\":{\"type\":\"string\",\"default\":\"\"}}],\"responses\":{\"200\":{\"description\":\"Success\",\"content\":{\"application/json\":{\"schema\":{\"type\":\"array\",\"items\":{\"$ref\":\"#/components/schemas/ApprenticeshipFramework\"}}}}},\"400\":{\"description\":\"Bad Request\",\"content\":{\"application/json\":{\"schema\":{\"$ref\":\"#/components/schemas/ProblemDetails\"}}}},\"404\":{\"description\":\"Not Found\",\"content\":{\"application/json\":{\"schema\":{\"$ref\":\"#/components/schemas/ProblemDetails\"}}}},\"500\":{\"description\":\"Server Error\"}}}},\"/api/referencedata/apprenticeship-frameworks/{frameworkCode}/prog-type/{progtypeId}/pathway-code/{pathwayCode}\":{\"get\":{\"tags\":[\"Doc\"],\"parameters\":[{\"name\":\"frameworkCode\",\"in\":\"path\",\"required\":true,\"schema\":{\"type\":\"integer\",\"format\":\"int32\"}},{\"name\":\"progTypeId\",\"in\":\"path\",\"required\":true,\"schema\":{\"type\":\"integer\",\"format\":\"int32\"}},{\"name\":\"pathwayCode\",\"in\":\"path\",\"required\":true,\"schema\":{\"type\":\"integer\",\"format\":\"int32\"}},{\"name\":\"code\",\"in\":\"query\",\"required\":true,\"schema\":{\"type\":\"string\",\"default\":\"\"}}],\"responses\":{\"200\":{\"description\":\"Success\",\"content\":{\"application/json\":{\"schema\":{\"$ref\":\"#/components/schemas/ApprenticeshipFramework\"}}}},\"400\":{\"description\":\"Bad Request\",\"content\":{\"application/json\":{\"schema\":{\"$ref\":\"#/components/schemas/ProblemDetails\"}}}},\"404\":{\"description\":\"Not Found\",\"content\":{\"application/json\":{\"schema\":{\"$ref\":\"#/components/schemas/ProblemDetails\"}}}},\"500\":{\"description\":\"Server Error\"}}}},\"/api/referencedata/apprenticeship-standards\":{\"get\":{\"tags\":[\"Doc\"],\"parameters\":[{\"name\":\"code\",\"in\":\"query\",\"required\":true,\"schema\":{\"type\":\"string\",\"default\":\"\"}}],\"responses\":{\"200\":{\"description\":\"Success\",\"content\":{\"application/json\":{\"schema\":{\"type\":\"array\",\"items\":{\"$ref\":\"#/components/schemas/ApprenticeshipStandard\"}}}}},\"404\":{\"description\":\"Not Found\",\"content\":{\"application/json\":{\"schema\":{\"$ref\":\"#/components/schemas/ProblemDetails\"}}}},\"500\":{\"description\":\"Server Error\"}}}},\"/api/referencedata/apprenticeship-standards/{standardCode}\":{\"get\":{\"tags\":[\"Doc\"],\"parameters\":[{\"name\":\"standardCode\",\"in\":\"path\",\"required\":true,\"schema\":{\"type\":\"integer\",\"format\":\"int32\"}},{\"name\":\"code\",\"in\":\"query\",\"required\":true,\"schema\":{\"type\":\"string\",\"default\":\"\"}}],\"responses\":{\"200\":{\"description\":\"Success\",\"content\":{\"application/json\":{\"schema\":{\"type\":\"array\",\"items\":{\"$ref\":\"#/components/schemas/ApprenticeshipStandard\"}}}}},\"400\":{\"description\":\"Bad Request\",\"content\":{\"application/json\":{\"schema\":{\"$ref\":\"#/components/schemas/ProblemDetails\"}}}},\"404\":{\"description\":\"Not Found\",\"content\":{\"application/json\":{\"schema\":{\"$ref\":\"#/components/schemas/ProblemDetails\"}}}},\"500\":{\"description\":\"Server Error\"}}}},\"/api/referencedata/apprenticeship-standards/{standardCode}/version/{version}\":{\"get\":{\"tags\":[\"Doc\"],\"parameters\":[{\"name\":\"standardCode\",\"in\":\"path\",\"required\":true,\"schema\":{\"type\":\"integer\",\"format\":\"int32\"}},{\"name\":\"version\",\"in\":\"path\",\"required\":true,\"schema\":{\"type\":\"integer\",\"format\":\"int32\"}},{\"name\":\"code\",\"in\":\"query\",\"required\":true,\"schema\":{\"type\":\"string\",\"default\":\"\"}}],\"responses\":{\"200\":{\"description\":\"Success\",\"content\":{\"application/json\":{\"schema\":{\"$ref\":\"#/components/schemas/ApprenticeshipStandard\"}}}},\"400\":{\"description\":\"Bad Request\",\"content\":{\"application/json\":{\"schema\":{\"$ref\":\"#/components/schemas/ProblemDetails\"}}}},\"404\":{\"description\":\"Not Found\",\"content\":{\"application/json\":{\"schema\":{\"$ref\":\"#/components/schemas/ProblemDetails\"}}}},\"500\":{\"description\":\"Server Error\"}}}}},\"components\":{\"schemas\":{\"FeChoice\":{\"type\":\"object\",\"properties\":{\"Id\":{\"type\":\"string\",\"format\":\"uuid\"},\"UPIN\":{\"type\":\"integer\",\"format\":\"int32\"},\"LearnerSatisfaction\":{\"type\":\"number\",\"format\":\"double\"},\"EmployerSatisfaction\":{\"type\":\"number\",\"format\":\"double\"},\"CreatedDateTimeUtc\":{\"type\":\"string\",\"format\":\"date-time\",\"nullable\":true}},\"additionalProperties\":false},\"ProblemDetails\":{\"type\":\"object\",\"properties\":{\"type\":{\"type\":\"string\"},\"title\":{\"type\":\"string\"},\"status\":{\"type\":\"integer\",\"format\":\"int32\",\"nullable\":true},\"detail\":{\"type\":\"string\"},\"instance\":{\"type\":\"string\"}},\"additionalProperties\":{\"type\":\"object\"}},\"ProgType\":{\"type\":\"object\",\"properties\":{\"Id\":{\"type\":\"string\",\"format\":\"uuid\"},\"ProgTypeId\":{\"type\":\"integer\",\"format\":\"int32\"},\"ProgTypeDesc\":{\"type\":\"string\"},\"ProgTypeDesc2\":{\"type\":\"string\"},\"EffectiveFrom\":{\"type\":\"string\",\"format\":\"date-time\",\"nullable\":true},\"EffectiveTo\":{\"type\":\"string\",\"format\":\"date-time\",\"nullable\":true},\"CreatedDateTimeUtc\":{\"type\":\"string\",\"format\":\"date-time\",\"nullable\":true},\"ModifiedDateTimeUtc\":{\"type\":\"string\",\"format\":\"date-time\",\"nullable\":true}},\"additionalProperties\":false},\"SectorSubjectAreaTier1\":{\"type\":\"object\",\"properties\":{\"Id\":{\"type\":\"string\",\"format\":\"uuid\"},\"SectorSubjectAreaTier1Id\":{\"type\":\"number\",\"format\":\"double\"},\"SectorSubjectAreaTier1Desc\":{\"type\":\"string\"},\"SectorSubjectAreaTier1Desc2\":{\"type\":\"string\"},\"EffectiveFrom\":{\"type\":\"string\",\"format\":\"date-time\",\"nullable\":true},\"CreatedDateTimeUtc\":{\"type\":\"string\",\"format\":\"date-time\",\"nullable\":true},\"ModifiedDateTimeUtc\":{\"type\":\"string\",\"format\":\"date-time\",\"nullable\":true}},\"additionalProperties\":false},\"SectorSubjectAreaTier2\":{\"type\":\"object\",\"properties\":{\"Id\":{\"type\":\"string\",\"format\":\"uuid\"},\"SectorSubjectAreaTier2Id\":{\"type\":\"number\",\"format\":\"double\"},\"SectorSubjectAreaTier2Desc\":{\"type\":\"string\"},\"SectorSubjectAreaTier2Desc2\":{\"type\":\"string\"},\"EffectiveFrom\":{\"type\":\"string\",\"format\":\"date-time\",\"nullable\":true},\"CreatedDateTimeUtc\":{\"type\":\"string\",\"format\":\"date-time\",\"nullable\":true},\"ModifiedDateTimeUtc\":{\"type\":\"string\",\"format\":\"date-time\",\"nullable\":true}},\"additionalProperties\":false},\"StandardSectorCode\":{\"type\":\"object\",\"properties\":{\"Id\":{\"type\":\"string\",\"format\":\"uuid\"},\"StandardSectorCodeId\":{\"type\":\"integer\",\"format\":\"int32\"},\"StandardSectorCodeDesc\":{\"type\":\"string\"},\"StandardSectorCodeDesc2\":{\"type\":\"string\"},\"EffectiveFrom\":{\"type\":\"string\",\"format\":\"date-time\",\"nullable\":true},\"EffectiveTo\":{\"type\":\"string\",\"format\":\"date-time\",\"nullable\":true},\"CreatedDateTimeUtc\":{\"type\":\"string\",\"format\":\"date-time\",\"nullable\":true},\"ModifiedDateTimeUtc\":{\"type\":\"string\",\"format\":\"date-time\",\"nullable\":true}},\"additionalProperties\":false},\"ApprenticeshipFramework\":{\"type\":\"object\",\"properties\":{\"Id\":{\"type\":\"string\",\"format\":\"uuid\"},\"FrameworkCode\":{\"type\":\"integer\",\"format\":\"int32\"},\"ProgType\":{\"type\":\"integer\",\"format\":\"int32\"},\"PathwayCode\":{\"type\":\"integer\",\"format\":\"int32\"},\"PathwayName\":{\"type\":\"string\"},\"NasTitle\":{\"type\":\"string\"},\"EffectiveFrom\":{\"type\":\"string\",\"format\":\"date-time\",\"nullable\":true},\"EffectiveTo\":{\"type\":\"string\",\"format\":\"date-time\",\"nullable\":true},\"SectorSubjectAreaTier1\":{\"type\":\"number\",\"format\":\"double\"},\"SectorSubjectAreaTier2\":{\"type\":\"number\",\"format\":\"double\"},\"CreatedDateTiemUtc\":{\"type\":\"string\",\"format\":\"date-time\",\"nullable\":true},\"ModifiedDateTiemUtc\":{\"type\":\"string\",\"format\":\"date-time\",\"nullable\":true},\"RecordStatusId\":{\"type\":\"integer\",\"format\":\"int32\"}},\"additionalProperties\":false},\"ApprenticeshipStandard\":{\"type\":\"object\",\"properties\":{\"Id\":{\"type\":\"string\",\"format\":\"uuid\"},\"StandardCode\":{\"type\":\"integer\",\"format\":\"int32\"},\"Version\":{\"type\":\"integer\",\"format\":\"int32\"},\"StandardName\":{\"type\":\"string\"},\"StandardSectorCode\":{\"type\":\"string\"},\"EffectiveFrom\":{\"type\":\"string\",\"format\":\"date-time\",\"nullable\":true},\"EffectiveTo\":{\"type\":\"string\",\"format\":\"date-time\",\"nullable\":true},\"URLLink\":{\"type\":\"string\"},\"SectorSubjectAreaTier1\":{\"type\":\"number\",\"format\":\"double\"},\"SectorSubjectAreaTier2\":{\"type\":\"number\",\"format\":\"double\"},\"CreatedDateTiemUtc\":{\"type\":\"string\",\"format\":\"date-time\",\"nullable\":true},\"ModifiedDateTiemUtc\":{\"type\":\"string\",\"format\":\"date-time\",\"nullable\":true},\"RecordStatusId\":{\"type\":\"integer\",\"format\":\"int32\"},\"NotionalEndLevel\":{\"type\":\"string\"},\"OtherBodyApprovalRequired\":{\"type\":\"string\"}},\"additionalProperties\":false}}}}";

            var result = JObject.Parse(SWAGGER_JSON);
            result.Add("servers", JToken.FromObject(new object[]
            {
                new
                {
                    url = req
                        .GetDisplayUrl()
                        .Replace(req.Path, string.Empty)
                        .Replace(req.QueryString.Value, string.Empty)
                }
            }));

            return new JsonResult(result);
        }
    }
}