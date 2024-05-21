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
    public class SubUnidadController : ControllerBase
    {
        private readonly ISubUnidadService _subUnidadServicio;

        public SubUnidadController(ISubUnidadService subUnidadServicio)
        {
            _subUnidadServicio = subUnidadServicio;
        }

        [HttpGet]
        [Route("Lista")]
        public async Task<IActionResult> Lista()
        {
            var rsp = new Response<List<SubUnidadDTO>>();

            try
            {
                rsp.status = true;
                rsp.value = await _subUnidadServicio.Listar();
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
        public async Task<IActionResult> Guardar(SubUnidadDTO subUnidad)
        {
            var rsp = new Response<SubUnidadDTO>();

            try
            {
                rsp.status = true;
                rsp.value = await _subUnidadServicio.Crear(subUnidad);
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
        public async Task<IActionResult> Editar(SubUnidadDTO subUnidad)
        {
            var rsp = new Response<bool>();

            try
            {
                rsp.status = true;
                rsp.value = await _subUnidadServicio.Editar(subUnidad);
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
        public async Task<IActionResult> Eliminar(SubUnidadDTO subUnidad)
        {
            var rsp = new Response<bool>();

            try
            {
                rsp.status = true;
                rsp.value = await _subUnidadServicio.Eliminar(subUnidad.Codigo);
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
