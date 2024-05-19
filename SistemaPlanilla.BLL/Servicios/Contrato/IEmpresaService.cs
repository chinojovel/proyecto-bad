using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SistemaPlanilla.DTO;

namespace SistemaPlanilla.BLL.Servicios.Contrato
{
    public interface IEmpresaService
    {
        Task<List<EmpresaDTO>> Listar();

        Task<EmpresaDTO> Crear(EmpresaDTO modelo);

        Task<bool> Editar(EmpresaDTO modelo);

        Task<bool> Eliminar(int id);
    }
}
