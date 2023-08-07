using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PW.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace PW.Persistence.Seeds
{
    public static class DbInitializer
    {
        public static void Initialize(IApplicationBuilder app)
        {
            var scope = app.ApplicationServices.CreateScope();
            var context = scope.ServiceProvider.GetService<PWDbContext>();

            if(context == null)
                throw new ArgumentNullException(nameof(context));

            context.Database.Migrate();
        }
    }
}
