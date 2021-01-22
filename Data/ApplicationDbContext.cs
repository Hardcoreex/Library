using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Library.Models;

namespace Library.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Library.Models.Books> Books { get; set; }
        public DbSet<Library.Models.Authors> Authors { get; set; }
        public DbSet<Library.Models.Orders> Orders { get; set; }
        public DbSet<Library.Models.Patrons> Patrons { get; set; }
    }
}
