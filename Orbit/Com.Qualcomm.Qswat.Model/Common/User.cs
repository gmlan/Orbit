using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Com.Qualcomm.Qswat.Model.Common
{
    public class User : BaseEntity
    {
        [StringLength(32)]
        public string FirstName { get; set; }

        [StringLength(32)]
        public string LastName { get; set; }


        /// <summary>
        /// Use Email as the registed account
        /// </summary>
        [StringLength(64)]
        [EmailAddress]
        public string Email { get; set; }

        [StringLength(12)]
        [Phone]
        public string Phone { get; set; }

        [Required(AllowEmptyStrings = false)]
        [StringLength(32)]
        public string PasswordHash { get; set; }

        public Address Address { get; set; }

        public virtual ICollection<Issue> Issues { get; set; } = new List<Issue>();
    }
}
