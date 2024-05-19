using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SistemaPlanilla.DTO;

namespace SistemaPlanilla.BLL.Servicios.Contrato
{
    public interface IUsuarioService
    {
        Task<List<UsuarioDTO>> Listar();

        Task<UsuarioDTO> Crear(UsuarioDTO modelo);

        Task<bool> Editar(UsuarioDTO modelo);

        Task<bool> Eliminar(int id);

        Task<SesionDTO> ValidarCredenciales(string correo, string contrasena);
    }
}
