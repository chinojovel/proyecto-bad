using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Linq.Expressions;
using SistemaPlanilla.Model;

namespace SistemaPlanilla.DAL.Repositorios.Contrato
{
    public interface IRolRepository : IGenericRepository<Rol>
    {
        Task<Rol> Registrar(Rol modelo);
    }
}
