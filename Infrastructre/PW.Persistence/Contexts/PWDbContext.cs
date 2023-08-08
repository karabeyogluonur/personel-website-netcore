using Microsoft.EntityFrameworkCore;
using PW.Domain.Entities.Membership;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PW.Persistence.Contexts
{
    public class PWDbContext : DbContext
    {
        public PWDbContext(DbContextOptions options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(PWDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }

        DbSet<User> Users { get; set; }
    }
}
