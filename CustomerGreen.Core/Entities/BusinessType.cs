using System.Collections.Generic;

namespace CustomerGreen.Core.Entities
{
    public class BusinessType : BaseEntity
    {
        public string Business { get; set; }

        public virtual ICollection<BusinessSubType> SubType { get; set; }

    }
}