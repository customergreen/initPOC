using System.Collections.Generic;

namespace CustomerGreen.Dto.Dtos
{
    public class BusinessTypeDto : BaseDto
    {
        public string Business { get; set; }

        public virtual ICollection<BusinessSubTypeDto> SubType { get; set; }

    }
}