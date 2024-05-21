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
    public class DptoUnidadController : ControllerBase
    {
        private readonly IDptoUnidadService _dptoUnidadServicio;

        public DptoUnidadController(IDptoUnidadService dptoUnidadServicio)
        {
            _dptoUnidadServicio = dptoUnidadServicio;
        }

        [HttpGet]
        [Route("Lista")]
        public async Task<IActionResult> Lista()
        {
            var rsp = new Response<List<DptoUnidadDTO>>();

            try
            {
                rsp.status = true;
                rsp.value = await _dptoUnidadServicio.Listar();
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
        public async Task<IActionResult> Guardar(DptoUnidadDTO dptoUnidad)
        {
            var rsp = new Response<DptoUnidadDTO>();

            try
            {
                rsp.status = true;
                rsp.value = await _dptoUnidadServicio.Crear(dptoUnidad);
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
        public async Task<IActionResult> Editar(DptoUnidadDTO dptoUnidad)
        {
            var rsp = new Response<bool>();

            try
            {
                rsp.status = true;
                rsp.value = await _dptoUnidadServicio.Editar(dptoUnidad);
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
        public async Task<IActionResult> Eliminar(DptoUnidadDTO dptoUnidad)
        {
            var rsp = new Response<bool>();

            try
            {
                rsp.status = true;
                rsp.value = await _dptoUnidadServicio.Eliminar(dptoUnidad.Codigo);
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
