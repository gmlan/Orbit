using Com.Qualcomm.Qswat.Model.Common;
using System.Data.Entity.ModelConfiguration;

namespace Com.Qualcomm.Qswat.Data.Mappings.Common
{
    public class IssueMapping : EntityTypeConfiguration<Issue>
    {
        public IssueMapping()
        {
            HasKey(m => m.Id);
            HasRequired(m => m.CreatedBy)
                .WithMany(m => m.Issues)
                .HasForeignKey(m => m.CreatedById)
                .WillCascadeOnDelete(false);

        }
    }
}
