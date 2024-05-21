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
    public class DepartamentoController : ControllerBase
    {
        private readonly IDepartamentoService _departamentoServicio;

        public DepartamentoController(IDepartamentoService departamentoServicio)
        {
            _departamentoServicio = departamentoServicio;
        }

        [HttpGet]
        [Route("Lista")]
        public async Task<IActionResult> Lista()
        {
            var rsp = new Response<List<DepartamentoDTO>>();

            try
            {
                rsp.status = true;
                rsp.value = await _departamentoServicio.Listar();
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
        public async Task<IActionResult> Guardar(DepartamentoDTO departamento)
        {
            var rsp = new Response<DepartamentoDTO>();

            try
            {
                rsp.status = true;
                rsp.value = await _departamentoServicio.Crear(departamento);
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
        public async Task<IActionResult> Editar(DepartamentoDTO departamento)
        {
            var rsp = new Response<bool>();

            try
            {
                rsp.status = true;
                rsp.value = await _departamentoServicio.Editar(departamento);
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
        public async Task<IActionResult> Eliminar(DepartamentoDTO departamento)
        {
            var rsp = new Response<bool>();

            try
            {
                rsp.status = true;
                rsp.value = await _departamentoServicio.Eliminar(departamento.Codigo);
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
