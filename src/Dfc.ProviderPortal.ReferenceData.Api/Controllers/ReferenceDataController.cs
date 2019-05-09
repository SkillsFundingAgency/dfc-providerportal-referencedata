using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dfc.ProviderPortal.ReferenceData.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Dfc.ProviderPortal.ReferenceData.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/referencedata")]
    [ApiController]
    public class ReferenceDataController : ControllerBase
    {
        [Route("fe-choices")]
        [HttpGet]
        public ActionResult<IEnumerable<FeChoice>> FeChoicesGetAll()
        {
            return new FeChoice[] { };
        }

        [Route("fe-choices/{upin}")]
        [HttpGet]
        public ActionResult<FeChoice> FeChoicesByUpin(int upin)
        {
            return new FeChoice();
        }

        [Route("prog-types")]
        [HttpGet]
        public ActionResult<IEnumerable<ProgType>> ProgTypesGetAll()
        {
            return new ProgType[] { };
        }

        [Route("prog-types/{progTypeId}")]
        [HttpGet]
        public ActionResult<ProgType> ProgTypesByProgTypeId(int progTypeId)
        {
            return new ProgType();
        }

        [Route("sector-subject-area-tier-1s")]
        [HttpGet]
        public ActionResult<IEnumerable<SectorSubjectAreaTier1>> SectorSubjectAreaTier1sGetAll()
        {
            return new SectorSubjectAreaTier1[] { };
        }

        [Route("sector-subject-area-tier-1s/{sectorSubjectAreaTier1Id}")]
        [HttpGet]
        public ActionResult<SectorSubjectAreaTier1> SectorSubjectAreaTier1sBySectorSubjectAreaTier1Id(decimal sectorSubjectAreaTier1Id)
        {
            return new SectorSubjectAreaTier1();
        }

        [Route("sector-subject-area-tier-2s")]
        [HttpGet]
        public ActionResult<IEnumerable<SectorSubjectAreaTier2>> SectorSubjectAreaTier2sGetAll()
        {
            return new SectorSubjectAreaTier2[] { };
        }

        [Route("sector-subject-area-tier-2s/{sectorSubjectAreaTier2Id}")]
        [HttpGet]
        public ActionResult<SectorSubjectAreaTier2> SectorSubjectAreaTier2sBySectorSubjectAreaTier2Id(decimal sectorSubjectAreaTier2Id)
        {
            return new SectorSubjectAreaTier2();
        }

        [Route("standard-sector-codes")]
        [HttpGet]
        public ActionResult<IEnumerable<StandardSectorCode>> StandardSectorCodesGetAll()
        {
            return new StandardSectorCode[] { };
        }

        [Route("standard-sector-codes/{standardSectorCodeId}")]
        [HttpGet]
        public ActionResult<StandardSectorCode> StandardSectorCodesByStandardSectorCodeId(int standardSectorCodeId)
        {
            return new StandardSectorCode();
        }

        [Route("apprenticeship-frameworks")]
        [HttpGet]
        public ActionResult<IEnumerable<ApprenticeshipFramework>> ApprenticeshipsFrameworksGetAll()
        {
            return new ApprenticeshipFramework[] { };
        }

        [Route("apprenticeship-frameworks/{frameworkCode}")]
        [HttpGet]
        public ActionResult<IEnumerable<ApprenticeshipFramework>> ApprenticeshipsFrameworksByFrameworkCode(int frameworkCode)
        {
            return new ApprenticeshipFramework[] { };
        }

        [Route("aapprenticeship-frameworks/{frameworkCode}/prog-type/{progtypeId}")]
        [HttpGet]
        public ActionResult<IEnumerable<ApprenticeshipFramework>> ApprenticeshipsFrameworksByFrameworkCodeAndProgTypeId(int frameworkCode, int progTypeId)
        {
            return new ApprenticeshipFramework[] { };
        }

        [Route("aapprenticeship-frameworks/{frameworkCode}/prog-type/{progtypeId}/pathway-code/{pathwayCode}")]
        [HttpGet]
        public ActionResult<ApprenticeshipFramework> ApprenticeshipsFrameworksByFrameworkCodeAndProgTypeIdAndPathwayCode(int frameworkCode, int progTypeId, int pathwayCode)
        {
            return new ApprenticeshipFramework();
        }

        [Route("apprenticeship-standards")]
        [HttpGet]
        public ActionResult<IEnumerable<ApprenticeshipStandard>> ApprenticeshipsStandardsGetAll()
        {
            return new ApprenticeshipStandard[] { };
        }

        [Route("apprenticeship-standards/{standardCode}")]
        [HttpGet]
        public ActionResult<IEnumerable<ApprenticeshipStandard>> ApprenticeshipsStandardsByStandardCode(int standardCode)
        {
            return new ApprenticeshipStandard[] { };
        }

        [Route("apprenticeship-standards/{standardCode}/version/{version}")]
        [HttpGet]
        public ActionResult<ApprenticeshipStandard> ApprenticeshipStandardByStandardCodeAndVersion(int standardCode, int version)
        {
            return new ApprenticeshipStandard();
        }
    }
}