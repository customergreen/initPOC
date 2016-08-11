namespace CustomerGreen.Dto.Dtos
{
    public class CountryDto : BaseDto
    {
        public CountryDto()
        {

        }

        public string Name { get; set; }
    }

    public class RevenueDto : BaseDto
    {
        public RevenueDto()
        {

        }
        public string Annual { get; set; }
    }

    public class PlanDto : BaseDto
    {
        public PlanDto()
        {

        }
        public string Usage { get; set; }
    }
}
