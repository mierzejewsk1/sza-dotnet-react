using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace backend.Data
{
    public class ApplicationDBContext : IdentityDbContext<AppUser>
    {
        public DbSet<Department> Departments { get; set; }
        public DbSet<Major> Majors { get; set; }
        public DbSet<Announcement> Announcements { get; set; }
        public ApplicationDBContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Announcement>()
            .HasOne<AppUser>(u => u.AppUser)
            .WithMany(a => a.Announcements)
            .HasForeignKey(u => u.AppUserId);

            
            List<IdentityRole> roles = new List<IdentityRole> {
                new IdentityRole {
                    Name = "Administrator",
                    NormalizedName = "ADMINISTRATOR"
                },
                new IdentityRole {
                    Name = "Recepcionist",
                    NormalizedName = "RECEPCIONIST"
                },
                new IdentityRole {
                    Name = "Inhabitant",
                    NormalizedName = "INHABITANT"
                },
                new IdentityRole {
                    Name = "Conservator",
                    NormalizedName = "CONSERVATOR"
                }
            };

            List<Department> departments = new List<Department> {
                new Department 
                {
                    DepartmentId = 1,
                    Name = "WIMiI",
                },
                new Department 
                {
                    DepartmentId = 2,
                    Name = "WZ",
                }
            };

            List<Major> majors = new List<Major> {
                new Major 
                {
                    MajorId = 1,
                    Name = "Informatyka",
                    DepartmentId = 1
                },
                new Major 
                {
                    MajorId = 2,
                    Name = "MSiTI",
                    DepartmentId = 1
                },
            };
            
            builder.Entity<IdentityRole>().HasData(roles);
            builder.Entity<Department>().HasData(departments);
            builder.Entity<Major>().HasData(majors);
        }
    }
}