using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBAccess.HousingVigilance.Domain.Mapping
{
    public class VehicleMap : IEntityTypeConfiguration<Vehicle>
    {
        public void Configure(EntityTypeBuilder<Vehicle> builder)
        {
            //Primary Key
            builder.HasKey(x => x.VehicleID);

            builder.Property(u => u.VehicleID).ValueGeneratedOnAdd();

            //Properties
            builder.Property(x => x.VehicleType).IsRequired().HasMaxLength(1).HasColumnName("VehicleType");
            builder.Property(x => x.VehicleNumber).IsRequired().HasMaxLength(50).HasColumnName("VehicleNumber");
            builder.Property(r => r.RowVersion).HasColumnName("RowVersion").IsRowVersion();

            builder.ToTable("Vehicles");
        }
    }
}
