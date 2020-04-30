using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBAccess.HousingVigilance.Domain.Mapping
{
    public class QRMap : IEntityTypeConfiguration<QR>
    {
        public void Configure(EntityTypeBuilder<QR> builder)
        {
            //Primary Key
            builder.HasKey(x => x.QrID);

            builder.Property(u => u.QrID).ValueGeneratedOnAdd();

            //Properties          
            builder.Property(x => x.QrUniqueId).IsRequired().HasMaxLength(50).HasColumnName("QrUniqueId");
            builder.Property(x => x.QrCode).IsRequired().HasColumnName("QrCode");
            builder.Property(r => r.RowVersion).HasColumnName("RowVersion").IsRowVersion();
            builder.ToTable("QrCodes");

        }
    }
}
