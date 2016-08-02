using AutoMapper;
using CustomerGreen.Core.Entities;
using CustomerGreen.Core.Services;
using CustomerGreen.Dto.Dtos;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Threading.Tasks;
using System.Web.Http;

namespace CustomerGreen.Web.Controllers
{
    [Authorize]
    [RoutePrefix("api/licenseTypes")]
    public class LicenseTypesController : ApiController
    {
        private readonly ILicenseTypeService _licenseTypeService;

        public LicenseTypesController(ILicenseTypeService licenseTypeService)
        {
            _licenseTypeService = licenseTypeService;
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetlicenseTypes()
        {
            var licenseTypes = await _licenseTypeService.GetAllAsync();

            var licenseTypesDtos = new List<LicenseTypeDto>();

            Mapper.Map(licenseTypes, licenseTypesDtos);
            
            return Ok(licenseTypesDtos);
        }

        [Route("ById/{id:int}")]
        public async Task<IHttpActionResult> GetlicenseType(int id)
        {
            var licenseType = await _licenseTypeService.GetByIdAsync(id);
            if (licenseType == null)
            {
                return NotFound();
            }

            var licenseTypeDto = new ContactDto();

            Mapper.Map(licenseType, licenseTypeDto);

            return Ok(licenseTypeDto);
        }

        [HttpPut]
        public async Task<IHttpActionResult> PutlicenseType(int id, LicenseTypeDto licenseTypeDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != licenseTypeDto.Id)
            {
                return BadRequest();
            }

            try
            {
                licenseTypeDto.Id = id;

                var licenseType = await _licenseTypeService.GetByIdAsync(id);

                Mapper.Map(licenseTypeDto, licenseType);

                await _licenseTypeService.UpdateAsync(licenseType);
              
                return Ok(licenseTypeDto);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!licenseTypeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
        }

        [HttpPost]
        public async Task<IHttpActionResult> PostlicenseType(LicenseTypeDto licenseTypeDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var licenseType = new LicenseType();
            
            Mapper.Map(licenseTypeDto, licenseType);

            licenseType = await _licenseTypeService.AddAsync(licenseType);
            licenseTypeDto.Id = licenseType.Id;

            return CreatedAtRoute("ApiRoute", new { id = licenseTypeDto.Id }, licenseTypeDto);
        }

        [HttpDelete]
        public async Task<IHttpActionResult> DeletelicenseType(int id)
        {
            var licenseType = await _licenseTypeService.GetByIdAsync(id);
            if (licenseType == null)
            {
                return NotFound();
            }

            await _licenseTypeService.DeleteAsync(licenseType);

            return Ok(licenseType);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _licenseTypeService.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool licenseTypeExists(int id)
        {
            return _licenseTypeService.GetByIdAsync(id) != null;
        }
    }
}