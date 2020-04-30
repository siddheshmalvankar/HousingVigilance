using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DBAccess.HousingVigilance.Domain.Mapping
{
    public class BrowserCapabilityMap : IEntityTypeConfiguration<BrowserCapability>
    {
        public void Configure(EntityTypeBuilder<BrowserCapability> builder)
        {
            // Primary Key
            builder.HasKey(t => t.BrowserCapabilityID);

            // Properties
            // Table & Column Mappings
            builder.ToTable("BrowserCapability");
            builder.Property(t => t.BrowserCapabilityID).HasColumnName("BrowserCapabilityID");
            builder.Property(t => t.BrowserType).HasColumnName("BrowserType");
            builder.Property(t => t.BrowserName).HasColumnName("BrowserName");
            builder.Property(t => t.BrowserVersion).HasColumnName("BrowserVersion");
            builder.Property(t => t.BrowserMajorVersion).HasColumnName("BrowserMajorVersion");
            builder.Property(t => t.BrowserMinorVersion).HasColumnName("BrowserMinorVersion");
            builder.Property(t => t.Platform).HasColumnName("Platform");
            builder.Property(t => t.IsBeta).HasColumnName("IsBeta");
            builder.Property(t => t.IsCrawler).HasColumnName("IsCrawler");
            builder.Property(t => t.IsAOL).HasColumnName("IsAOL");
            builder.Property(t => t.IsWin16).HasColumnName("IsWin16");
            builder.Property(t => t.IsWin32).HasColumnName("IsWin32");
            builder.Property(t => t.BrowserSupportFrames).HasColumnName("BrowserSupportFrames");
            builder.Property(t => t.BrowserSupportTables).HasColumnName("BrowserSupportTables");
            builder.Property(t => t.BrowserSupportCookies).HasColumnName("BrowserSupportCookies");
            builder.Property(t => t.BrowserSupportVBScript).HasColumnName("BrowserSupportVBScript");
            builder.Property(t => t.BrowserJavaScriptVersion).HasColumnName("BrowserJavaScriptVersion");
            builder.Property(t => t.BrowserSupportJavaApplets).HasColumnName("BrowserSupportJavaApplets");
            builder.Property(t => t.BrowserSupportActiveXControls).HasColumnName("BrowserSupportActiveXControls");
            builder.Property(t => t.ApplicationUserID).HasColumnName("ApplicationUserID");
            builder.Property(t => t.IPAddress).HasColumnName("IPAddress");
            builder.Property(t => t.UserLanguages).HasColumnName("UserLanguages");
            builder.Property(t => t.AddedDate).HasColumnName("AddedDate");
        }
    }
}
