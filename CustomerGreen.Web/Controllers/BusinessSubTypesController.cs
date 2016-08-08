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
    //[Authorize]
    [RoutePrefix("api/businessSubTypes")]
    public class BusinessSubTypesController : ApiController
    {
        private readonly IBusinessSubTypeService _businessSubTypeService;

        public BusinessSubTypesController(IBusinessSubTypeService businessSubTypeService)
        {
            _businessSubTypeService = businessSubTypeService;
        }

        [HttpGet]
        [Route("GetBusinessSubTypes")]
        public async Task<IHttpActionResult> GetBusinessSubTypes()
        {
            var businessSubTypes = await _businessSubTypeService.GetAllAsync();

            var businessSubTypesDtos = new List<BusinessSubTypeDto>();

            Mapper.Map(businessSubTypes, businessSubTypesDtos);

            return Ok(businessSubTypesDtos);
        }

        [Route("ById/{id:int}")]
        public async Task<IHttpActionResult> GetBusinessSubType(int id)
        {
            var businessSubType = await _businessSubTypeService.GetByIdAsync(id);
            if (businessSubType == null)
            {
                return NotFound();
            }

            var businessSubTypeDto = new ContactDto();

            Mapper.Map(businessSubType, businessSubTypeDto);

            return Ok(businessSubTypeDto);
        }

        [HttpPut]
        public async Task<IHttpActionResult> PutbusinessSubType(int id, BusinessSubTypeDto businessSubTypeDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != businessSubTypeDto.Id)
            {
                return BadRequest();
            }

            try
            {
                businessSubTypeDto.Id = id;

                var businessSubType = await _businessSubTypeService.GetByIdAsync(id);

                Mapper.Map(businessSubTypeDto, businessSubType);

                await _businessSubTypeService.UpdateAsync(businessSubType);

                return Ok(businessSubTypeDto);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!businessSubTypeExists(id))
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
        public async Task<IHttpActionResult> PostbusinessSubType(BusinessSubTypeDto businessSubTypeDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var businessSubType = new BusinessSubType();

            Mapper.Map(businessSubTypeDto, businessSubType);

            businessSubType = await _businessSubTypeService.AddAsync(businessSubType);
            businessSubTypeDto.Id = businessSubType.Id;

            return CreatedAtRoute("ApiRoute", new { id = businessSubTypeDto.Id }, businessSubTypeDto);
        }

        [HttpDelete]
        public async Task<IHttpActionResult> DeletebusinessSubType(int id)
        {
            var businessSubType = await _businessSubTypeService.GetByIdAsync(id);
            if (businessSubType == null)
            {
                return NotFound();
            }

            await _businessSubTypeService.DeleteAsync(businessSubType);

            return Ok(businessSubType);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _businessSubTypeService.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool businessSubTypeExists(int id)
        {
            return _businessSubTypeService.GetByIdAsync(id) != null;
        }
    }
}