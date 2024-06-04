using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SistemaPlanilla.DAL.DBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SistemaPlanilla.DAL.Repositorios.Contrato;
using SistemaPlanilla.DAL.Repositorios;

using SistemaPlanilla.Utility;

using SistemaPlanilla.BLL.Servicios.Contrato;
using SistemaPlanilla.BLL.Servicios;

namespace SistemaPlanilla.IOC
{
    public static class Dependencia
    {
        public static void InyectarDependencias (this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<Gp09planillasContext> (options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("cadenaLocalSQL"));
            });

            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IRolRepository, RolRepository>();

            services.AddAutoMapper(typeof(AutoMapperProfile));

            services.AddScoped<IAreaService, AreaService>();
            services.AddScoped<ICentroCostoService, CentroCostoService>();
            services.AddScoped<IDepartamentoService, DepartamentoService>();
            services.AddScoped<IDptoUnidadService, DptoUnidadService>();
            services.AddScoped<IEmpleadoService, EmpleadoService>();
            services.AddScoped<IEmpresaService, EmpresaService>();
            services.AddScoped<IEstadoCivilService, EstadoCivilService>();
            services.AddScoped<IMunicipioService, MunicipioService>();
            services.AddScoped<IPaisService, PaisService>();
            services.AddScoped<IPermisoService, PermisoService>();
            services.AddScoped<IPlanillaService, PlanillaService>();
            services.AddScoped<IProfesionOficioService, ProfesionOficioService>();
            services.AddScoped<IPuestoService, PuestoService>();
            services.AddScoped<IRolService, RolService>();
            services.AddScoped<IPermisoRolService, PermisoRolService>();
            services.AddScoped<ISexoService, SexoService>();
            services.AddScoped<ISubUnidadService, SubUnidadService>();
            services.AddScoped<IUsuarioService, UsuarioService>();
        }
    }
}
