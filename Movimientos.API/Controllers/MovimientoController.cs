using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Movimientos.API.Models;
using Movimientos.BIZ.Services.Interfaces;
using Movimientos.COMMON.Exceptions;
using Movimientos.COMMON.Models;
using Movimientos.DAL.EFCore.Repository.Interfaces;

namespace Movimientos.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MovimientoController : ControllerBase
    {
        private readonly IMovimientoRepository _movimientoRepository;
        private readonly IMovimientoService _movimientoService;
        private readonly IMapper _mapper;

        public MovimientoController(IMovimientoRepository movimientoRepository,
            IMovimientoService movimientoService,
            IMapper mapper)
        {
            _movimientoRepository = movimientoRepository;
            _movimientoService = movimientoService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetMovimiento()
        {
            return Ok(await _movimientoRepository.GetAll());
        }

        [HttpPost]
        public async Task<IActionResult> AddMovimiento([FromBody] MovimientoModel movimiento)
        {
            try
            {
                if (movimiento == null)
                    return BadRequest();

                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var _mappedMovimiento = _mapper.Map<Movimiento>(movimiento);
                var createdMovimiento = await _movimientoService.CreateMovimiento(_mappedMovimiento);

                return Created("movimiento", createdMovimiento);
            }
            catch (LimiteRetiroDiarioException lrdEx)
            {
                return BadRequest($"Limite diario superado. Actualmente has retirado {lrdEx.ValorTotalRetirado}, no puedes retirar el monto de {lrdEx.ValorRetirar}, debido a que el límite de retiro diario es S/ 1000.00.");
            }
            catch (CuentaInexistenteException)
            {
                return BadRequest("Cuenta asociada inexistente, por favor ingrese un Guid de cuenta existente.");
            }
            catch (TipoCuentaIncorrectaException tpiEx) 
            {
                return BadRequest($"Tipo de cuenta \"{tpiEx.Tipo}\" incorrecta");
            }
            catch(SaldoInsuficienteException)
            {
                return BadRequest("Saldo no disponible.");
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateMovimiento([FromBody] MovimientoModel movimiento)
        {
            try
            {
                if (movimiento == null)
                    return BadRequest();

                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var _mappedMovimiento = _mapper.Map<Movimiento>(movimiento);
                var movimientoToUpdate = await _movimientoService.UpdateMovimiento(_mappedMovimiento);

                if (movimientoToUpdate == null)
                    return NotFound();

                return Ok(movimientoToUpdate);
            }
            catch (LimiteRetiroDiarioException lrdEx)
            {
                return BadRequest($"Limite diario superado. Actualmente has retirado {lrdEx.ValorTotalRetirado}, no puedes retirar el monto de {lrdEx.ValorRetirar}, debido a que el límite de retiro diario es S/ 1000.00.");
            }
            catch (CuentaInexistenteException)
            {
                return BadRequest("Cuenta asociada inexistente, por favor ingrese un Guid de cuenta existente.");
            }
            catch (SaldoInsuficienteException)
            {
                return BadRequest("Saldo no disponible.");
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMovimiento(Guid id)
        {
            try
            {
                if (id == Guid.Empty)
                    return BadRequest();

                var movimientoToDelete = await _movimientoService.DeleteMovimiento(id);

                if (movimientoToDelete is false)
                    return NotFound();

                return Ok(movimientoToDelete);
            }
            catch(MovimientoInexistenteExecption)
            {
                return BadRequest("Movimiento asociado inexistente, por favor ingrese un Guid de movimiento existente.");
            }
            catch (CuentaInexistenteException)
            {
                return BadRequest("Cuenta asociada inexistente, por favor ingrese un Guid de cuenta existente.");
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }
    }
}
