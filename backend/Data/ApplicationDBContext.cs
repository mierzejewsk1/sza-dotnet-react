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
        public ApplicationDBContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            
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
            
            builder.Entity<IdentityRole>().HasData(roles);
        }
    }
}