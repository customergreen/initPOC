using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomerGreen.Core.Entities
{
    public class BrandLocation : AuditableEntity
    {
        public long BrandId { get; set; }

        [ForeignKey("BrandId")]
        public virtual Brand Brand { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [Display(Name = "Name")]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required(ErrorMessage = "* Phone is required")]
        [Display(Name = "Phone")]
        [RegularExpression(@"^\d{3}\d{3}\d{4}$", ErrorMessage = "Phone Number is not valid")]
        public string Phone { get; set; }
        public string Mobile { get; set; }

        [Display(Name = "Contact Email")]
        [EmailAddress]
        [MaxLength(50)]
        public string ContactEmail { get; set; }

        [Display(Name = "Strategic Email")]
        [EmailAddress]
        [MaxLength(50)]
        public string StrategicEmail { get; set; }

        [Display(Name = "Tactical Email")]
        [EmailAddress]
        [MaxLength(50)]
        public string TacticalEmail { get; set; }

        [Required(ErrorMessage = "Country is required")]
        [Display(Name = "Country")]
        [MaxLength(50)]
        public string Country { get; set; }

        [Required(ErrorMessage = "Address is required")]
        [Display(Name = "Street Address 1")]
        [MaxLength(100)]
        public string Street1 { get; set; }

        [Display(Name = "Street Address 2")]
        [MaxLength(100)]
        public string Street2 { get; set; }

        [Required(ErrorMessage = "City is required")]
        [Display(Name = "City")]
        [MaxLength(50)]
        public string City { get; set; }

        [Required(ErrorMessage = "State is required")]
        [Display(Name = "State")]
        [MaxLength(100)]
        public string State { get; set; }

        [Required(ErrorMessage = "Zip is required")]
        [Display(Name = "Zip")]
        [MaxLength(10)]
        [RegularExpression(@"^\d{3}\s?\d{3}$", ErrorMessage = "Zip code is not valid")]
        public string Zip { get; set; }
        [DefaultValue(true)]
        public bool IsActive { get; set; }
    }
}