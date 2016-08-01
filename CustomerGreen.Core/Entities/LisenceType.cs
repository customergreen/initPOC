using System;

namespace CustomerGreen.Core.Entities
{
    public class LisenceType: BaseEntity
    {
        public string License { get; set; }
        public double Cost { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public bool Active { get; set; }
    }
}