using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace CustomerGreen.Core.Entities
{
    public class BusinessSubType : BaseEntity
    {
        [JsonIgnore]
        [IgnoreDataMember]
        public BusinessType BusinessType { get; set; }
        public string SubType { get; set; }
    }
}