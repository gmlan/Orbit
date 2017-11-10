using Com.Qualcomm.Qswat.Model.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Com.Qualcomm.Qswat.Model.Common
{
    public class Issue : BaseEntity
    {
        [StringLength(256)]
        public string Title { get; set; }

        public string Description { get; set; }

        public TicketStatus Status { get; set; }

        public SeverityLevel Severity { get; set; }

        [NotMapped]
        public string StatusDesc => Enum.GetName(typeof(TicketStatus), Status);

        [NotMapped]
        public string SeverityDesc => Enum.GetName(typeof(SeverityLevel), Severity);


        public virtual User Assignee { get; set; }

        public int? AssigneeId { get; set; }

        public virtual User CreatedBy { get; set; }

        public int CreatedById { get; set; }

        public DateTime? DueDateUtc { get; set; }

        public DateTime CreateDateTimeUtc { get; set; } = DateTime.UtcNow;

        public DateTime? LastModifiedUtc { get; set; }
    }
}
