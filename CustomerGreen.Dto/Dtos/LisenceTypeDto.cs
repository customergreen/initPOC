using System;
namespace CustomerGreen.Dto.Dtos

{
    public class LisenceTypeDto : BaseDto
    {
        public string License { get; set; }
        public double Cost { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public bool Active { get; set; }
    }
}