using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.HousingVigilance.Domain.Mapping
{
    public class UserLoginMap : IEntityTypeConfiguration<UserLogin>
    {
        public void Configure(EntityTypeBuilder<UserLogin> builder)
        {
            //Primary Key
            builder.HasKey(x => x.UserLoginID);
            builder.HasAlternateKey(x => x.UserName);
            //Properties          
            builder.Property(r => r.RowVersion).HasColumnName("RowVersion").IsRowVersion();
            builder.Property(r => r.UserName).IsRequired().HasColumnName("UserName").HasMaxLength(50);
            builder.Property(r => r.PasswordHash).IsRequired().HasColumnName("PasswordHash").HasMaxLength(50);
       

            builder.ToTable("ApplicationUsers");
        }

    }
}
