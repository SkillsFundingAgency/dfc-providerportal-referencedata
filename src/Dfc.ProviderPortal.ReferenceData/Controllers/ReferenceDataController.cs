using Dfc.ProviderPortal.ReferenceData.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Dfc.ProviderPortal.ReferenceData.Controllers
{
    [Produces("application/json")]
    [Route("api/referencedata")]
    [ApiController]
    public class ReferenceDataController : ControllerBase
    {
        [Route("fe-choices")]
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<FeChoice>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult FeChoicesGetAll()
        {
            return Ok();
        }

        [Route("fe-choices/{ukprn}")]
        [HttpGet]
        [ProducesResponseType(typeof(FeChoice), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult FeChoicesByUKPRN(int UKPRN)
        {
            return Ok();
        }

        [Route("prog-types")]
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ProgType>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult ProgTypesGetAllAsync()
        {
            return Ok();
        }

        [Route("prog-types/{progTypeId}")]
        [HttpGet]
        [ProducesResponseType(typeof(ProgType), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult ProgTypesByProgTypeIdAsync(int progTypeId)
        {
            return Ok();
        }

        [Route("sector-subject-area-tier-1s")]
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<SectorSubjectAreaTier1>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult SectorSubjectAreaTier1sGetAllAsync()
        {
            return Ok();
        }

        [Route("sector-subject-area-tier-1s/{sectorSubjectAreaTier1Id}")]
        [HttpGet]
        [ProducesResponseType(typeof(SectorSubjectAreaTier1), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult SectorSubjectAreaTier1sBySectorSubjectAreaTier1IdAsync(decimal sectorSubjectAreaTier1Id)
        {
            return Ok();
        }

        [Route("sector-subject-area-tier-2s")]
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<SectorSubjectAreaTier2>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult SectorSubjectAreaTier2sGetAllAsync()
        {
            return Ok();
        }

        [Route("sector-subject-area-tier-2s/{sectorSubjectAreaTier2Id}")]
        [HttpGet]
        [ProducesResponseType(typeof(SectorSubjectAreaTier2), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult SectorSubjectAreaTier2sBySectorSubjectAreaTier2IdAsync(decimal sectorSubjectAreaTier2Id)
        {
            return Ok();
        }

        [Route("standard-sector-codes")]
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<StandardSectorCode>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult StandardSectorCodesGetAllAsync()
        {
            return Ok();
        }

        [Route("standard-sector-codes/{standardSectorCodeId}")]
        [HttpGet]
        [ProducesResponseType(typeof(StandardSectorCode), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult StandardSectorCodesByStandardSectorCodeIdAsync(int standardSectorCodeId)
        {
            return Ok();
        }

        [Route("apprenticeship-frameworks")]
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ApprenticeshipFramework>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult ApprenticeshipsFrameworksGetAllAsync()
        {
            return Ok();
        }

        [Route("apprenticeship-frameworks/{frameworkCode}")]
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ApprenticeshipFramework>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult ApprenticeshipsFrameworksByFrameworkCodeAsync(int frameworkCode)
        {
            return Ok();
        }

        [Route("apprenticeship-frameworks/{frameworkCode}/prog-type/{progTypeId}")]
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ApprenticeshipFramework>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult ApprenticeshipsFrameworksByFrameworkCodeAndProgTypeIdAsync(int frameworkCode, int progTypeId)
        {
            return Ok();
        }

        [Route("apprenticeship-frameworks/{frameworkCode}/prog-type/{progTypeId}/pathway-code/{pathwayCode}")]
        [HttpGet]
        [ProducesResponseType(typeof(ApprenticeshipFramework), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult ApprenticeshipsFrameworksByFrameworkCodeAndProgTypeIdAndPathwayCodeAsync(int frameworkCode, int progTypeId, int pathwayCode)
        {
            return Ok();
        }

        [Route("apprenticeship-standards")]
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ApprenticeshipStandard>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult ApprenticeshipsStandardsGetAllAsync()
        {
            return Ok();
        }

        [Route("apprenticeship-standards/{standardCode}")]
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ApprenticeshipStandard>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult ApprenticeshipsStandardsByStandardCodeAsync(int standardCode)
        {
            return Ok();
        }

        [Route("apprenticeship-standards/{standardCode}/version/{version}")]
        [HttpGet]
        [ProducesResponseType(typeof(ApprenticeshipStandard), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult ApprenticeshipStandardByStandardCodeAndVersionAsync(int standardCode, int version)
        {
            return Ok();
        }
    }
}