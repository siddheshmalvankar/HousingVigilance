using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBAccess.HousingVigilance.Domain.Mapping
{
    public class GateEntryMap : IEntityTypeConfiguration<GateEntry>
    {
        public void Configure(EntityTypeBuilder<GateEntry> builder)
        {
            //Primary Key
            builder.HasKey(x => x.GeteID);

            //Properties          
            builder.Property(r => r.RowVersion).HasColumnName("RowVersion").IsRowVersion();

            builder.ToTable("GateEntries");
        }
    }
}
