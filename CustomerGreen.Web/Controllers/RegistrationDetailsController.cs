using AutoMapper;
using CustomerGreen.Core.Entities;
using CustomerGreen.Core.Services;
using CustomerGreen.Dto.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace CustomerGreen.Web.Controllers
{
    [RoutePrefix("api/RegistrationDetails")]
    public class RegistrationDetailsController : ApiController
    {

        private readonly ICountryService _countryService;

        private readonly IRevenueService _revenueService;

        private readonly IPlanService _planService;

        private readonly IBusinessTypeService _businessTypeService;

        // private readonly IBusinessSubTypeService _businessSubTypeService;

        public RegistrationDetailsController(ICountryService countryService, IRevenueService revenueService,
            IPlanService planService, IBusinessTypeService businessTypeService) // , IBusinessSubTypeService businessSubTypeService
        {
            _countryService = countryService;
            _planService = planService;
            _revenueService = revenueService;
            _businessTypeService = businessTypeService;
            // _businessSubTypeService = businessSubTypeService;

        }

        [HttpGet]
        [Route("Get")]
        public async Task<IHttpActionResult> Get()
        {
            List<BusinessType> busType = await _businessTypeService.GetAllAsync();

            List<BusinessTypeDto> busTypeDtos = new List<BusinessTypeDto>();

            Mapper.Map(busType, busTypeDtos);

            //List<BusinessSubType> busSubType = await _businessSubTypeService.GetAllAsync();

            //List<BusinessSubTypeDto> busSubTypeDtos = new List<BusinessSubTypeDto>();

            //Mapper.Map(busSubType, busSubTypeDtos);

            List<Country> country = await _countryService.GetAllAsync();

            List<CountryDto> countryDtos = new List<CountryDto>();

            Mapper.Map(country, countryDtos);

            List<Plan> plan = await _planService.GetAllAsync();

            List<PlanDto> planDtos = new List<PlanDto>();

            Mapper.Map(plan, planDtos);

            List<Revenue> rev = await _revenueService.GetAllAsync();

            List<RevenueDto> revDtos = new List<RevenueDto>();

            Mapper.Map(rev, revDtos);

            return Ok(new { Type = busTypeDtos, Country = countryDtos, Plan = planDtos, Revenue = revDtos });
        }
    }
}
