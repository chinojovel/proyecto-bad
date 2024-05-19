using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SistemaPlanilla.BLL.Servicios.Contrato;
using SistemaPlanilla.DAL.Repositorios.Contrato;
using SistemaPlanilla.DTO;
using SistemaPlanilla.Model;

namespace SistemaPlanilla.BLL.Servicios
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IGenericRepository<Usuario> _usuarioRepositorio;
        private readonly IMapper _mapper;

        public UsuarioService(IGenericRepository<Usuario> usuarioRepositorio, IMapper mapper)
        {
            _usuarioRepositorio = usuarioRepositorio;
            _mapper = mapper;
        }

        public async Task<List<UsuarioDTO>> Listar()
        {
            try
            {
                var queryUsuario = await _usuarioRepositorio.Consultar();
                var listaUsuarios = queryUsuario.Include(f => f.CodEmpleadoNavigation).Include(f => f.CodRolNavigation).ToList();

                return _mapper.Map<List<UsuarioDTO>>(listaUsuarios.ToList());
            }
            catch
            {
                throw;
            }
        }

        public async Task<UsuarioDTO> Crear(UsuarioDTO modelo)
        {
            try
            {
                var usuarioCreado = await _usuarioRepositorio.Crear(_mapper.Map<Usuario>(modelo));

                if (usuarioCreado.Codigo == 0)
                {
                    throw new TaskCanceledException("El usuario no pudo ser creado.");
                }

                return _mapper.Map<UsuarioDTO>(usuarioCreado);
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Editar(UsuarioDTO modelo)
        {
            try
            {
                var usuarioModelo = _mapper.Map<Usuario>(modelo);
                var usuarioEncontrado = await _usuarioRepositorio.Obtener(u => u.Codigo == usuarioModelo.Codigo);

                if (usuarioEncontrado == null)
                {
                    throw new TaskCanceledException("El usuario no existe.");
                }

                usuarioEncontrado.Correo = usuarioModelo.Correo;
                usuarioEncontrado.Contrasena = usuarioModelo.Contrasena;
                usuarioEncontrado.CodEmpleado = usuarioModelo.CodEmpleado;
                usuarioEncontrado.CodRol = usuarioModelo.CodRol;
                usuarioEncontrado.Activo = usuarioModelo.Activo;

                bool response = await _usuarioRepositorio.Editar(usuarioEncontrado);

                if (!response)
                {
                    throw new TaskCanceledException("El usuario no pudo ser editado.");
                }

                return response;
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Eliminar(int id)
        {
            try
            {
                var usuarioEncontrado = await _usuarioRepositorio.Obtener(u => u.Codigo == id);

                if (usuarioEncontrado == null)
                {
                    throw new TaskCanceledException("El usuario no existe.");
                }

                bool response = await _usuarioRepositorio.Eliminar(usuarioEncontrado);

                if (!response)
                {
                    throw new TaskCanceledException("El usuario no pudo ser eliminado.");
                }

                return response;
            }
            catch
            {
                throw;
            }
        }

        public async Task<SesionDTO> ValidarCredenciales(string correo, string contrasena)
        {
            try
            {
                var queryUsuario = await _usuarioRepositorio.Consultar(u => u.Correo == correo && u.Contrasena == contrasena);

                if (queryUsuario.FirstOrDefault() == null)
                {
                    throw new TaskCanceledException("El usuario no existe");
                }

                Usuario devolverUsuario = queryUsuario.Include(rol => rol.CodRolNavigation).First();

                return _mapper.Map<SesionDTO>(devolverUsuario);
            }
            catch
            {
                throw;
            }
        }
    }
}
