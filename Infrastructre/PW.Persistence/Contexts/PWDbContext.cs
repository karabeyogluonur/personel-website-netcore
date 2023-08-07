using Microsoft.EntityFrameworkCore;
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
    }
}
