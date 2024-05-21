using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using SistemaPlanilla.BLL.Servicios.Contrato;
using SistemaPlanilla.DTO;
using SistemaPlanilla.API.Utilidad;
using SistemaPlanilla.Model;

namespace SistemaPlanilla.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadoController : ControllerBase
    {
        private readonly IEmpleadoService _empleadoServicio;

        public EmpleadoController(IEmpleadoService empleadoServicio)
        {
            _empleadoServicio = empleadoServicio;
        }

        [HttpGet]
        [Route("Lista")]
        public async Task<IActionResult> Lista()
        {
            var rsp = new Response<List<EmpleadoDTO>>();

            try
            {
                rsp.status = true;
                rsp.value = await _empleadoServicio.Listar();
                rsp.msg = "Success";
            }
            catch (Exception ex)
            {
                rsp.status = false;
                rsp.msg = ex.Message;
            }

            return Ok(rsp);
        }

        [HttpPost]
        [Route("Guardar")]
        public async Task<IActionResult> Guardar(EmpleadoDTO empleado)
        {
            var rsp = new Response<EmpleadoDTO>();

            try
            {
                rsp.status = true;
                rsp.value = await _empleadoServicio.Crear(empleado);
                rsp.msg = "Success";
            }
            catch (Exception ex)
            {
                rsp.status = false;
                rsp.msg = ex.Message;
            }

            return Ok(rsp);
        }

        [HttpPut]
        [Route("Editar")]
        public async Task<IActionResult> Editar(EmpleadoDTO empleado)
        {
            var rsp = new Response<bool>();

            try
            {
                rsp.status = true;
                rsp.value = await _empleadoServicio.Editar(empleado);
                rsp.msg = "Success";
            }
            catch (Exception ex)
            {
                rsp.status = false;
                rsp.msg = ex.Message;
            }

            return Ok(rsp);
        }

        [HttpDelete]
        [Route("Eliminar")]
        public async Task<IActionResult> Eliminar(EmpleadoDTO empleado)
        {
            var rsp = new Response<bool>();

            try
            {
                rsp.status = true;
                rsp.value = await _empleadoServicio.Eliminar(empleado.Codigo);
                rsp.msg = "Success";
            }
            catch (Exception ex)
            {
                rsp.status = false;
                rsp.msg = ex.Message;
            }

            return Ok(rsp);
        }
    }
}
