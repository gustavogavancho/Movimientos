using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Movimientos.API.Models;
using Movimientos.COMMON.Models;
using Movimientos.DAL.EFCore.Repository.Interfaces;

namespace Movimientos.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CuentaController : ControllerBase
    {
        private readonly ICuentaRepository _cuentaRepository;
        private readonly IMapper _mapper;

        public CuentaController(ICuentaRepository cuentaRepository, 
            IMapper mapper)
        {
            _cuentaRepository = cuentaRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetCuenta()
        {
            return Ok(await _cuentaRepository.GetAll());
        }

        [HttpPost]
        public async Task<IActionResult> AddCuenta([FromBody] CuentaModel cuenta)
        {
            if (cuenta == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var _mappedCuenta = _mapper.Map<Cuenta>(cuenta);
            var createdCuenta = await _cuentaRepository.Create(_mappedCuenta);

            return Created("cuenta", createdCuenta);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCuenta([FromBody] CuentaModel cuenta)
        {
            if (cuenta == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var _mappedCuenta = _mapper.Map<Cuenta>(cuenta);
            var cuentaToUpdate = await _cuentaRepository.Update(cuenta.Id, _mappedCuenta);

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
