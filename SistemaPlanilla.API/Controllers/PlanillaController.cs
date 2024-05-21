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
    public class PlanillaController : ControllerBase
    {
        private readonly IPlanillaService _planillaServicio;

        public PlanillaController(IPlanillaService planillaServicio)
        {
            _planillaServicio = planillaServicio;
        }

        [HttpGet]
        [Route("Lista")]
        public async Task<IActionResult> Lista()
        {
            var rsp = new Response<List<PlanillaDTO>>();

            try
            {
                rsp.status = true;
                rsp.value = await _planillaServicio.Listar();
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
        public async Task<IActionResult> Guardar(PlanillaDTO planilla)
        {
            var rsp = new Response<PlanillaDTO>();

            try
            {
                rsp.status = true;
                rsp.value = await _planillaServicio.Crear(planilla);
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
        public async Task<IActionResult> Editar(PlanillaDTO planilla)
        {
            var rsp = new Response<bool>();

            try
            {
                rsp.status = true;
                rsp.value = await _planillaServicio.Editar(planilla);
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
        public async Task<IActionResult> Eliminar(PlanillaDTO planilla)
        {
            var rsp = new Response<bool>();

            try
            {
                rsp.status = true;
                rsp.value = await _planillaServicio.Eliminar(planilla.Codigo);
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
