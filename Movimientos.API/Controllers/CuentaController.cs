using Microsoft.AspNetCore.Mvc;
using Movimientos.BIZ.Repository.Interfaces;
using Movimientos.COMMON.Models;

namespace Movimientos.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CuentaController : ControllerBase
    {
        private readonly ICuentaRepository _cuentaRepository;

        public CuentaController(ICuentaRepository cuentaRepository)
        {
            _cuentaRepository = cuentaRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetCuenta()
        {
            return Ok(await _cuentaRepository.GetAll());
        }

        [HttpPost]
        public async Task<IActionResult> AddCuenta([FromBody] Cuenta cuenta)
        {
            if (cuenta == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var createdCuenta = await _cuentaRepository.Create(cuenta);

            return Created("cuenta", createdCuenta);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCuenta([FromBody] Cuenta cuenta)
        {
            if (cuenta == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var cuentaToUpdate = await _cuentaRepository.Update(cuenta.Id, cuenta);

            if (cuentaToUpdate == null)
                return NotFound();

            return Ok(cuentaToUpdate);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCuenta(Guid id)
        {
            if (id == Guid.Empty)
                return BadRequest();

            var cuentaToDelete = await _cuentaRepository.Delete(id);

            if (cuentaToDelete is false)
                return NotFound();

            return Ok(cuentaToDelete);
        }
    }
}
