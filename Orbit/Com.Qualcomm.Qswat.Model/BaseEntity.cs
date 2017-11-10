using System.ComponentModel.DataAnnotations;

namespace Com.Qualcomm.Qswat.Model
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// if this record is deleted (virtual delete)
        /// </summary>
        public bool Deleted { get; set; }
    }
}
