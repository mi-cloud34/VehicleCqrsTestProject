using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Contexts
{
    public static class MigrationHelper
    {

        public static  IApplicationBuilder MigratonDatabase(this IApplicationBuilder application)
        {
            using (var scope=application.ApplicationServices.CreateScope())
            {
                using (var context = scope.ServiceProvider.GetRequiredService<BaseDbContext>())
                {
                    context.Database.Migrate();
                }
            }
            return application;
        }
    }
 
}
