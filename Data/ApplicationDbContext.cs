using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using EktivaBankNetApp.Models;

namespace EktivaBankNetApp.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<EktivaBankNetApp.Models.Customer> Customer { get; set; }
        public DbSet<EktivaBankNetApp.Models.Account> Account { get; set; }
    }
}
