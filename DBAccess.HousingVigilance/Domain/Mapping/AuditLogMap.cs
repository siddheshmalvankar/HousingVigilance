using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DBAccess.HousingVigilance.Domain.Mapping
{
    public class AuditLogMap : IEntityTypeConfiguration<AuditLog>
    {
        public void Configure(EntityTypeBuilder<AuditLog> builder)
        {
            //Primary Key
            builder.HasKey(x => x.AuditLogID);

            //Properties          
            builder.Property(t => t.ApplicationName)
               .HasMaxLength(50);

            builder.Property(t => t.EventDescription)
                .HasMaxLength(500);

            builder.Property(t => t.IPAddress)
                .HasMaxLength(50);

            builder.Property(t => t.AuditLogID).HasColumnName("AuditLogID");
            builder.Property(t => t.ApplicationName).HasColumnName("ApplicationName");
            builder.Property(t => t.ActionStatus).HasColumnName("ActionStatus");
            builder.Property(t => t.EventDescription).HasColumnName("EventDescription");
            builder.Property(t => t.IPAddress).HasColumnName("IPAddress");
            builder.Property(t => t.ApplicationUserID).HasColumnName("ApplicationUserID");
            builder.Property(t => t.CreatedDate).HasColumnName("CreatedDate");

            builder.ToTable("AuditLogs");
        }
    }
}
