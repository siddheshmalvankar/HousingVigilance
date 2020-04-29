using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBAccess.HousingVigilance.Domain.Mapping
{
    public class RoleMap : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            //Primary Key
            builder.HasKey(x => x.RoleID);

            //Properties
            builder.Property(x => x.RoleName).IsRequired().HasMaxLength(50).HasColumnName("RoleName");
            builder.Property(x => x.RoleDesc).IsRequired().HasMaxLength(200).HasColumnName("RoleDesc");
            builder.Property(r => r.RowVersion).HasColumnName("RowVersion").IsRowVersion();
            builder.ToTable("Roles");
        }
    }
}
