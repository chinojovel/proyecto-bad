using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SistemaPlanilla.DAL.DBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaPlanilla.IOC
{
    public static class Dependencia
    {
        public static void InyectarDependencias (this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<Gp09planillasContext> (options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("cadenaRemotaSQL"));
            });
        }
    }
}
