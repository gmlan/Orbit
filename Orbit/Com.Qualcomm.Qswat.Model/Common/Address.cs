using System.ComponentModel.DataAnnotations;

namespace Com.Qualcomm.Qswat.Model.Common
{
    public class Address
    {
        [Required(AllowEmptyStrings = false)]
        [StringLength(255)]
        public string AddressLine1 { get; set; }

        [StringLength(255)]
        public string AddressLine2 { get; set; }
        [StringLength(255)]
        public string AddressLine3 { get; set; }

        [Required(AllowEmptyStrings = false)]
        [StringLength(32)]
        public string City { get; set; }

        [Required(AllowEmptyStrings = false)]
        [StringLength(32)]
        public string State { get; set; }

        [Required(AllowEmptyStrings = false)]
        [StringLength(32)]
        public string Country { get; set; }

        [Required(AllowEmptyStrings = false)]
        [StringLength(12)]
        public string PostalCode { get; set; }
    }
}
