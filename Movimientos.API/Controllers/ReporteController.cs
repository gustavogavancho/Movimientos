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

            List<ReporteModel> reporte = new();

            foreach (var estado in estadoCuenta)
            {
                foreach (var movimiento in estado.Movimientos)
                {
                    reporte.Add(new ReporteModel
                    {
                        Fecha = movimiento.FechaCreacion,
                        Cliente = estado.Cliente.Nombre,
                        NumeroCuenta = estado.NumeroCuenta,
                        Tipo = estado.Tipo,
                        SaldoInicial = movimiento.SaldoInicial,
                        Estado = movimiento.Estado,
                        Movimiento = movimiento.Valor,
                        SaldoDisponible = movimiento.Saldo,
                    });
                }
            }

            return Ok(reporte);
        }
    }
}
