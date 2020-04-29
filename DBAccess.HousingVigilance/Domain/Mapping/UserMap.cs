using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBAccess.HousingVigilance.Domain.Mapping
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            //Primary Key
            builder.HasKey(x => x.UserID);

            //Properties
            builder.Property(x => x.UserType).IsRequired().HasMaxLength(1).HasColumnName("UserType");
            builder.Property(x => x.FirstName).IsRequired().HasMaxLength(50).HasColumnName("FirstName");
            builder.Property(x => x.MiddleName).HasMaxLength(50).HasColumnName("MiddleName");
            builder.Property(x => x.LastName).IsRequired().HasMaxLength(50).HasColumnName("LastName");
            builder.Property(x => x.AppartmentNumber).IsRequired().HasMaxLength(50).HasColumnName("AppartmentNumber");
            builder.Property(x => x.ContactNumber1).IsRequired().HasMaxLength(50).HasColumnName("ContactNumber1");
            builder.Property(x => x.ContactNumber2).HasMaxLength(50).HasColumnName("ContactNumber2");
            builder.Property(x => x.PrimaryEmail).IsRequired().HasMaxLength(50).HasColumnName("PrimaryEmail");
            builder.Property(r => r.RowVersion).HasColumnName("RowVersion").IsRowVersion();
            builder.ToTable("Users");
        }
    }
}
