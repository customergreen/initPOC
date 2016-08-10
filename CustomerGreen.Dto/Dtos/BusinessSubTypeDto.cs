using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace CustomerGreen.Dto.Dtos
{
    public class BusinessSubTypeDto : BaseDto
    {
        [JsonIgnore]
        [IgnoreDataMember]
        public BusinessTypeDto BusinessType { get; set; }
        public string SubType { get; set; }
    }
}