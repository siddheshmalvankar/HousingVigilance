using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.HousingVigilance.Domain
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {           
            modelBuilder.Entity<Role>().HasData(
                new Role { RoleID = 1, RoleName = "Admin", RoleDesc = "Admin User", CreatedBy = 1 },
                new Role { RoleID = 2, RoleName = "User", RoleDesc = "Normal User", CreatedBy = 1 },
                new Role { RoleID = 3, RoleName = "Security", RoleDesc = "Security Access for the App", CreatedBy = 1 }
            );

            modelBuilder.Entity<Permission>().HasData(
               new Permission
               {
                   PermissionID = 1,
                   PermissionType = 'R',
                   PermissionName = "Read",
                   RoleID = 1,
                   CreatedBy = 1
               },
               new Permission
               {
                   PermissionID = 2,
                   PermissionType = 'W',
                   PermissionName = "Write",
                   RoleID = 1,
                   CreatedBy = 1

               },               
               new Permission
               {
                   PermissionID = 3,
                   PermissionType = 'R',
                   PermissionName = "Read",
                   RoleID = 2,
                   CreatedBy = 1

               },
                new Permission
                {
                    PermissionID = 4,
                    PermissionType = 'W',
                    PermissionName = "Write",
                    RoleID = 2,
                    CreatedBy = 1

                },
                new Permission
                {
                    PermissionID = 5,
                    PermissionType = 'R',
                    PermissionName = "Read",
                    RoleID = 3,
                    CreatedBy = 1

                }

           );

        }
    }
}
