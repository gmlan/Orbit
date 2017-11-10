using Com.Qualcomm.Qswat.Model.Common;
using System.Data.Entity.ModelConfiguration;

namespace Com.Qualcomm.Qswat.Data.Mappings.Common
{
    public class UserMapping : EntityTypeConfiguration<User>
    {
        public UserMapping()
        {
            HasKey(m => m.Id);
            Property(m => m.Address.AddressLine1).HasColumnName("AddressLine1");
            Property(m => m.Address.AddressLine2).HasColumnName("AddressLine2");
            Property(m => m.Address.AddressLine3).HasColumnName("AddressLine3");
            Property(m => m.Address.City).HasColumnName("City");
            Property(m => m.Address.State).HasColumnName("State");
            Property(m => m.Address.Country).HasColumnName("Country");
            Property(m => m.Address.PostalCode).HasColumnName("PostalCode");
        }
    }
}
