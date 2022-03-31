using Microsoft.AspNetCore.Mvc;
using Movimientos.API.Models;
using Movimientos.DAL.EFCore.Repository.Interfaces;

namespace Movimientos.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ReporteController : ControllerBase
    {
        private readonly ICuentaRepository _cuentaRepository;

        public ReporteController(ICuentaRepository cuentaRepository)
        {
            _cuentaRepository = cuentaRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetCliente(Guid clienteId, DateTime fechaInicio, DateTime fechaFin)
        {
            var estadoCuenta = await _cuentaRepository.GetEstadoCuenta(clienteId, fechaInicio, fechaFin);

            return Ok(estadoCuenta);
        }
    }
}
