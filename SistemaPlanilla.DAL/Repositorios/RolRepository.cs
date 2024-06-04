using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SistemaPlanilla.DAL.Repositorios.Contrato;
using SistemaPlanilla.DAL.DBContext;
using SistemaPlanilla.Model;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Data;

namespace SistemaPlanilla.DAL.Repositorios
{
    public class RolRepository : GenericRepository<Rol>, IRolRepository
    {
        private readonly Gp09planillasContext _dbContext;

        public RolRepository(Gp09planillasContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Rol> Registrar(Rol modelo)
        {
            Rol rolGenerado = new Rol();

            using (var transaction = _dbContext.Database.BeginTransaction())
            {
                try
                {
                    await _dbContext.Rols.AddAsync(modelo);
                    await _dbContext.SaveChangesAsync();

                    foreach (PermisoRol per in modelo.PermisoRols)
                    {
                        Permiso permisoEncontrado = _dbContext.Permisos.Where(p => p.Codigo == per.Codigo).First();

                        PermisoRol registroGenerado = new PermisoRol
                        {
                            CodRol = modelo.Codigo,
                            CodPermiso = permisoEncontrado.Codigo
                        };
                        _dbContext.PermisoRols.Add(registroGenerado);
                        await _dbContext.SaveChangesAsync();
                    }

                    rolGenerado = modelo;

                    transaction.Commit();
                }
                catch
                {
                    transaction.Rollback();
                    throw;
                }

                return rolGenerado;
            }
        }
    }
}
