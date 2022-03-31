using Microsoft.AspNetCore.Mvc;
using Movimientos.BIZ.Repository.Interfaces;
using Movimientos.COMMON.Exceptions;
using Movimientos.COMMON.Models;

namespace Movimientos.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MovimientoController : ControllerBase
    {
        private readonly IMovimientoRepository _movimientoRepository;

        public MovimientoController(IMovimientoRepository movimientoRepository)
        {
            _movimientoRepository = movimientoRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetMovimiento()
        {
            return Ok(await _movimientoRepository.GetAll());
        }

        [HttpPost]
        public async Task<IActionResult> AddMovimiento([FromBody] Movimiento movimiento)
        {
            try
            {
                if (movimiento == null)
                    return BadRequest();

                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var createdMovimiento = await _movimientoRepository.CreateMovimiento(movimiento);

                return Created("movimiento", createdMovimiento);
            }
            catch (LimiteRetiroDiarioException lrdEx) 
            {
                return BadRequest($"Limite diario superado. Actualmente has retirado {lrdEx.ValorTotalRetirado}, no puedes retirar el monto de {lrdEx.ValorRetirar}, debido a que el límite de retiro diario es S/ 1000.00");
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateMovimiento([FromBody] Movimiento movimiento)
        {
            if (movimiento == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var movimientoToUpdate = await _movimientoRepository.Update(movimiento.Id, movimiento);

            if (movimientoToUpdate == null)
                return NotFound();

            return Ok(movimientoToUpdate);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMovimiento(Guid id)
        {
            if (id == Guid.Empty)
                return BadRequest();

            var movimientoToDelete = await _movimientoRepository.Delete(id);

            if (movimientoToDelete is false)
                return NotFound();

            return Ok(movimientoToDelete);
        }
    }
}
