
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataAccess.HousingVigilance.Domain.Mapping
{
    public class PermissionMap : IEntityTypeConfiguration<Permission>
    {
        public void Configure(EntityTypeBuilder<Permission> builder)
        {
            //Primary Key
            builder.HasKey(x => x.PermissionID);

            //Properties
            builder.Property(x => x.PermissionType).IsRequired().HasMaxLength(1).HasColumnName("PermissionType");
            builder.Property(x => x.PermissionName).IsRequired().HasMaxLength(50).HasColumnName("PermissionName");
            builder.Property(r => r.RowVersion).HasColumnName("RowVersion").IsRowVersion();
            builder.ToTable("Permissions");
           

        }
    }
}
