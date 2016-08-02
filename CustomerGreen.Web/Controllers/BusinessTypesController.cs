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
    [RoutePrefix("api/BusinessTypes")]
    public class BusinessTypesController : ApiController
    {
        private readonly IBusinessTypeService _businessTypeService;

        public BusinessTypesController(IBusinessTypeService businessTypeService)
        {
            _businessTypeService = businessTypeService;
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetBusinessTypes()
        {
            var businessTypes = await _businessTypeService.GetAllAsync();

            var businessTypesDtos = new List<BusinessTypeDto>();

            Mapper.Map(businessTypes, businessTypesDtos);
            
            return Ok(businessTypesDtos);
        }

        [Route("ById/{id:int}")]
        public async Task<IHttpActionResult> GetBusinessType(int id)
        {
            var businessType = await _businessTypeService.GetByIdAsync(id);
            if (businessType == null)
            {
                return NotFound();
            }

            var businessTypeDto = new ContactDto();

            Mapper.Map(businessType, businessTypeDto);

            return Ok(businessTypeDto);
        }

        [HttpPut]
        public async Task<IHttpActionResult> PutBusinessType(int id, BusinessTypeDto businessTypeDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != businessTypeDto.Id)
            {
                return BadRequest();
            }

            try
            {
                businessTypeDto.Id = id;

                var businessType = await _businessTypeService.GetByIdAsync(id);

                Mapper.Map(businessTypeDto, businessType);

                await _businessTypeService.UpdateAsync(businessType);
              
                return Ok(businessTypeDto);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BusinessTypeExists(id))
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
        public async Task<IHttpActionResult> PostBusinessType(BusinessTypeDto businessTypeDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var businessType = new BusinessType();
            
            Mapper.Map(businessTypeDto, businessType);

            businessType = await _businessTypeService.AddAsync(businessType);
            businessTypeDto.Id = businessType.Id;

            return CreatedAtRoute("ApiRoute", new { id = businessTypeDto.Id }, businessTypeDto);
        }

        [HttpDelete]
        public async Task<IHttpActionResult> DeleteBusinessType(int id)
        {
            var businessType = await _businessTypeService.GetByIdAsync(id);
            if (businessType == null)
            {
                return NotFound();
            }

            await _businessTypeService.DeleteAsync(businessType);

            return Ok(businessType);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _businessTypeService.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BusinessTypeExists(int id)
        {
            return _businessTypeService.GetByIdAsync(id) != null;
        }
    }
}