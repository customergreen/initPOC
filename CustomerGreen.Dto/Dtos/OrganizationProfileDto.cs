namespace CustomerGreen.Dto.Dtos
{
    public class OrganizationProfileDto : BaseDto
    {        
        public string OrgKey { get; set; }        
        public string CompanyName { get; set; }        
        public string Phone { get; set; }
        public string Mobile { get; set; }
        public string BusinessTypeId { get; set; }
        public string BusinessSubTypeId { get; set; }
        public string LisenceTypeId { get; set; }
        public string ContactEmail { get; set; }        
        public string StrategicEmail { get; set; }        
        public string TacticalEmail { get; set; }       
        public string About { get; set; }
        public string Website { get; set; }        
        public string Country { get; set; }
        public string Street1 { get; set; }
        public string Street2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }                
        public bool IsActive { get; set; }
        public byte[] Logo { get; set; }
    }
}