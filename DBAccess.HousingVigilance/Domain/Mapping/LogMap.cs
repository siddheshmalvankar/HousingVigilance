using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBAccess.HousingVigilance.Domain.Mapping
{
    public class LogMap : IEntityTypeConfiguration<Log>
    {
        public void Configure(EntityTypeBuilder<Log> builder)
        {
            // Primary Key
            builder.HasKey(t => t.LogID);

            // Properties
            builder.Property(t => t.Severity)
                .IsRequired()
                .HasMaxLength(32);

            builder.Property(t => t.Title)
                .IsRequired()
                .HasMaxLength(256);

            builder.Property(t => t.MachineName)
                .IsRequired()
                .HasMaxLength(32);

            builder.Property(t => t.AppDomainName)
                .IsRequired()
                .HasMaxLength(512);

            builder.Property(t => t.ProcessID)
                .IsRequired()
                .HasMaxLength(256);

            builder.Property(t => t.ProcessName)
                .IsRequired()
                .HasMaxLength(512);

            builder.Property(t => t.ThreadName)
                .HasMaxLength(512);

            builder.Property(t => t.Win32ThreadId)
                .HasMaxLength(128);

            builder.Property(t => t.Message)
                .HasMaxLength(1500);

            // Table & Column Mappings
            builder.ToTable("Log");
            builder.Property(t => t.LogID).HasColumnName("LogID");
            builder.Property(t => t.EventID).HasColumnName("EventID");
            builder.Property(t => t.Priority).HasColumnName("Priority");
            builder.Property(t => t.Severity).HasColumnName("Severity");
            builder.Property(t => t.Title).HasColumnName("Title");
            builder.Property(t => t.Timestamp).HasColumnName("Timestamp");
            builder.Property(t => t.MachineName).HasColumnName("MachineName");
            builder.Property(t => t.AppDomainName).HasColumnName("AppDomainName");
            builder.Property(t => t.ProcessID).HasColumnName("ProcessID");
            builder.Property(t => t.ProcessName).HasColumnName("ProcessName");
            builder.Property(t => t.ThreadName).HasColumnName("ThreadName");
            builder.Property(t => t.Win32ThreadId).HasColumnName("Win32ThreadId");
            builder.Property(t => t.Message).HasColumnName("Message");
            builder.Property(t => t.FormattedMessage).HasColumnName("FormattedMessage");
        }
           
    }
}
