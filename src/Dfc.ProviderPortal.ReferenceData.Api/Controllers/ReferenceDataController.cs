using Dfc.ProviderPortal.ReferenceData.Interfaces;
using Dfc.ProviderPortal.ReferenceData.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace Dfc.ProviderPortal.ReferenceData.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/referencedata")]
    [ApiController]
    public class ReferenceDataController : ControllerBase
    {
        private readonly IFeChoiceService _feChoiceService;
        private readonly IProgTypeService _progTypeService;
        private readonly ISectorSubjectAreaTier1Service _sectorSubjectAreaTier1Service;
        private readonly ISectorSubjectAreaTier2Service _sectorSubjectAreaTier2Service;
        private readonly IStandardSectorCodeService _standardSectorCodeService;
        private readonly IApprenticeshipFrameworkService _apprenticeshipFrameworkService;
        private readonly IApprenticeshipStandardService _apprenticeshipStandardService;

        public ReferenceDataController(
            IFeChoiceService feChoiceService,
            IProgTypeService progTypeService,
            ISectorSubjectAreaTier1Service sectorSubjectAreaTier1Service,
            ISectorSubjectAreaTier2Service sectorSubjectAreaTier2Service,
            IStandardSectorCodeService standardSectorCodeService,
            IApprenticeshipFrameworkService apprenticeshipFrameworkService,
            IApprenticeshipStandardService apprenticeshipStandardService)
        {
            _feChoiceService = feChoiceService;
            _progTypeService = progTypeService;
            _sectorSubjectAreaTier1Service = sectorSubjectAreaTier1Service;
            _sectorSubjectAreaTier2Service = sectorSubjectAreaTier2Service;
            _standardSectorCodeService = standardSectorCodeService;
            _apprenticeshipFrameworkService = apprenticeshipFrameworkService;
            _apprenticeshipStandardService = apprenticeshipStandardService;
        }

        [Route("fe-choices")]
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<FeChoice>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<FeChoice>>> FeChoicesGetAllAsync([Required]string code)
        {
            try
            {
                var result = await _feChoiceService.GetAllAsync();
                if (result == null) return new NotFoundResult();

                return Ok(result);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [Route("fe-choices/{upin}")]
        [HttpGet]
        [ProducesResponseType(typeof(FeChoice), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<FeChoice>> FeChoicesByUpinAsync(int upin, [Required]string code)
        {
            try
            {
                var result = await _feChoiceService.GetByUpinAsync(upin);
                if (result == null) return new NotFoundResult();

                return Ok(result);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [Route("prog-types")]
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ProgType>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<ProgType>>> ProgTypesGetAllAsync([Required]string code)
        {
            try
            {
                var result = await _progTypeService.GetAllAsync();
                if (result == null) return new NotFoundResult();

                return Ok(result);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [Route("prog-types/{progTypeId}")]
        [HttpGet]
        [ProducesResponseType(typeof(ProgType), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ProgType>> ProgTypesByProgTypeIdAsync(int progTypeId, [Required]string code)
        {
            try
            {
                var result = await _progTypeService.GetByProgTypeIdAsync(progTypeId);
                if (result == null) return new NotFoundResult();

                return Ok(result);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [Route("sector-subject-area-tier-1s")]
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<SectorSubjectAreaTier1>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<SectorSubjectAreaTier1>>> SectorSubjectAreaTier1sGetAllAsync([Required]string code)
        {
            try
            {
                var result = await _sectorSubjectAreaTier1Service.GetAllAsync();
                if (result == null) return new NotFoundResult();

                return Ok(result);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [Route("sector-subject-area-tier-1s/{sectorSubjectAreaTier1Id}")]
        [HttpGet]
        [ProducesResponseType(typeof(SectorSubjectAreaTier1), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<SectorSubjectAreaTier1>> SectorSubjectAreaTier1sBySectorSubjectAreaTier1IdAsync(decimal sectorSubjectAreaTier1Id, [Required]string code)
        {
            try
            {
                var result = await _sectorSubjectAreaTier1Service.GetBySectorSubjectAreaTier1IdAsync(sectorSubjectAreaTier1Id);
                if (result == null) return new NotFoundResult();

                return Ok(result);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [Route("sector-subject-area-tier-2s")]
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<SectorSubjectAreaTier2>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<SectorSubjectAreaTier2>>> SectorSubjectAreaTier2sGetAllAsync([Required]string code)
        {
            try
            {
                var result = await _sectorSubjectAreaTier2Service.GetAllAsync();
                if (result == null) return new NotFoundResult();

                return Ok(result);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [Route("sector-subject-area-tier-2s/{sectorSubjectAreaTier2Id}")]
        [HttpGet]
        [ProducesResponseType(typeof(SectorSubjectAreaTier2), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<SectorSubjectAreaTier2>> SectorSubjectAreaTier2sBySectorSubjectAreaTier2IdAsync(decimal sectorSubjectAreaTier2Id, [Required]string code)
        {
            try
            {
                var result = await _sectorSubjectAreaTier2Service.GetBySectorSubjectAreaTier2IdAsync(sectorSubjectAreaTier2Id);
                if (result == null) return new NotFoundResult();

                return Ok(result);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [Route("standard-sector-codes")]
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<StandardSectorCode>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<StandardSectorCode>>> StandardSectorCodesGetAllAsync([Required]string code)
        {
            try
            {
                var result = await _standardSectorCodeService.GetAllAsync();
                if (result == null) return new NotFoundResult();

                return Ok(result);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [Route("standard-sector-codes/{standardSectorCodeId}")]
        [HttpGet]
        [ProducesResponseType(typeof(StandardSectorCode), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<StandardSectorCode>> StandardSectorCodesByStandardSectorCodeIdAsync(int standardSectorCodeId, [Required]string code)
        {
            try
            {
                var result = await _standardSectorCodeService.GetByStandardSectorCodeIdAsync(standardSectorCodeId);
                if (result == null) return new NotFoundResult();

                return Ok(result);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [Route("apprenticeship-frameworks")]
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ApprenticeshipFramework>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<ApprenticeshipFramework>>> ApprenticeshipsFrameworksGetAllAsync([Required]string code)
        {
            try
            {
                var result = await _apprenticeshipFrameworkService.GetAllAsync();
                if (result == null) return new NotFoundResult();

                return Ok(result);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [Route("apprenticeship-frameworks/{frameworkCode}")]
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ApprenticeshipFramework>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<ApprenticeshipFramework>>> ApprenticeshipsFrameworksByFrameworkCodeAsync(int frameworkCode, [Required]string code)
        {
            try
            {
                var result = await _apprenticeshipFrameworkService.GetApprenticeshipFrameworkByFrameworkCodeAsync(frameworkCode);
                if (result == null) return new NotFoundResult();

                return Ok(result);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [Route("apprenticeship-frameworks/{frameworkCode}/prog-type/{progtypeId}")]
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ApprenticeshipFramework>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<ApprenticeshipFramework>>> ApprenticeshipsFrameworksByFrameworkCodeAndProgTypeIdAsync(int frameworkCode, int progTypeId, [Required]string code)
        {
            try
            {
                var result = await _apprenticeshipFrameworkService.GetApprenticeshipFrameworkByFrameworkCodeAndProgTypeIdAsync(frameworkCode, progTypeId);
                if (result == null) return new NotFoundResult();

                return Ok(result);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [Route("apprenticeship-frameworks/{frameworkCode}/prog-type/{progtypeId}/pathway-code/{pathwayCode}")]
        [HttpGet]
        [ProducesResponseType(typeof(ApprenticeshipFramework), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApprenticeshipFramework>> ApprenticeshipsFrameworksByFrameworkCodeAndProgTypeIdAndPathwayCodeAsync(int frameworkCode, int progTypeId, int pathwayCode, [Required]string code)
        {
            try
            {
                var result = await _apprenticeshipFrameworkService.GetApprenticeshipFrameworkByFrameworkCodeAndProgTypeIdAndPathwayCodeAsync(frameworkCode, progTypeId, pathwayCode);
                if (result == null) return new NotFoundResult();

                return Ok(result);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [Route("apprenticeship-standards")]
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ApprenticeshipStandard>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<ApprenticeshipStandard>>> ApprenticeshipsStandardsGetAllAsync([Required]string code)
        {
            try
            {
                var result = await _apprenticeshipStandardService.GetAllAsync();
                if (result == null) return new NotFoundResult();

                return Ok(result);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [Route("apprenticeship-standards/{standardCode}")]
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ApprenticeshipStandard>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<ApprenticeshipStandard>>> ApprenticeshipsStandardsByStandardCodeAsync(int standardCode, [Required]string code)
        {
            try
            {
                var result = await _apprenticeshipStandardService.GetApprenticeshipStandardByStandardCodeAsync(standardCode);
                if (result == null) return new NotFoundResult();

                return Ok(result);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [Route("apprenticeship-standards/{standardCode}/version/{version}")]
        [HttpGet]
        [ProducesResponseType(typeof(ApprenticeshipStandard), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApprenticeshipStandard>> ApprenticeshipStandardByStandardCodeAndVersionAsync(int standardCode, int version, [Required]string code)
        {
            try
            {
                var result = await _apprenticeshipStandardService.GetApprenticeshipStandardByStandardCodeAndVersionAsync(standardCode, version);
                if (result == null) return new NotFoundResult();

                return Ok(result);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}