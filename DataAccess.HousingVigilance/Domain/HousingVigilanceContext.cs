using DataAccess.HousingVigilance.Domain.Mapping;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.HousingVigilance.Domain
{
    public class HousingVigilanceContext : DbContext
    {
     
        public HousingVigilanceContext(DbContextOptions options) :base(options)
        {
           
        }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<QR> QRCodes { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }

        public DbSet<GateEntry> GateEntries { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PermissionMap());
            modelBuilder.ApplyConfiguration(new QRMap());
            modelBuilder.ApplyConfiguration(new RoleMap());
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new VehicleMap());
            modelBuilder.ApplyConfiguration(new GateEntryMap());
            modelBuilder.Seed();
        }
    }
}
