using Movimientos.BIZ.Services.Interfaces;
using Movimientos.COMMON.Exceptions;
using Movimientos.COMMON.Models;
using Movimientos.DAL.EFCore.Repository.Interfaces;

namespace Movimientos.BIZ.Services;

public class MovimientoService : IMovimientoService
{
    private readonly IMovimientoRepository _movimientoRepository;
    private readonly ICuentaRepository _cuentaRepository;

    public MovimientoService(IMovimientoRepository movimientoRepository,
        ICuentaRepository cuentaRepository)
    {
        _movimientoRepository = movimientoRepository;
        _cuentaRepository = cuentaRepository;
    }

    public async Task<Movimiento> CreateMovimiento(Movimiento entity)
    {
        entity.Id = Guid.NewGuid();
        var sumaRetiroDiario = await _movimientoRepository.SumaRetiroDiario(entity.CuentaId);
        if (entity.Valor < 0 && sumaRetiroDiario - entity.Valor > 1000)
            throw new LimiteRetiroDiarioException(entity.Valor, sumaRetiroDiario);

        var cuentaAsociada = await _cuentaRepository.Get(entity.CuentaId);
        if (cuentaAsociada is null)
            throw new CuentaInexistenteException();

        if (cuentaAsociada.Tipo != entity.Tipo)
            throw new TipoCuentaIncorrectaException(entity.Tipo);

        if (entity.Valor < 0 && cuentaAsociada.Saldo < -entity.Valor)
            throw new SaldoInsuficienteException(entity.Valor, cuentaAsociada.Saldo);
        else
        {
            entity.Saldo = cuentaAsociada.Saldo = cuentaAsociada.Saldo + entity.Valor;
            await _cuentaRepository.Attach(cuentaAsociada);
        }

        Movimiento createdResult = await _movimientoRepository.Create(entity);

        return createdResult;
    }

    public async Task<Movimiento> UpdateMovimiento(Movimiento entity)
    {
        var movimientoAnterior = await _movimientoRepository.Get(entity.Id);

        var sumaRetiroDiario = await _movimientoRepository.SumaRetiroDiario(entity.CuentaId);
        if (sumaRetiroDiario - movimientoAnterior.Valor + entity.Valor < -1000)
            throw new LimiteRetiroDiarioException(entity.Valor, sumaRetiroDiario);

        var cuentaAsociada = await _cuentaRepository.Get(entity.CuentaId);
        if (cuentaAsociada is null)
            throw new CuentaInexistenteException();

        if (cuentaAsociada.Saldo + movimientoAnterior.Valor < entity.Valor)
            throw new SaldoInsuficienteException(entity.Valor, cuentaAsociada.Saldo);
        else
        {
            entity.Saldo = cuentaAsociada.Saldo = cuentaAsociada.Saldo + entity.Valor + movimientoAnterior.Valor;
            await _cuentaRepository.Attach(cuentaAsociada);
        }

        Movimiento createdResult = await _movimientoRepository.Update(entity.Id, entity);

        return createdResult;
    }

    public async Task<bool> DeleteMovimiento(Guid id)
    {
        Movimiento entity = await _movimientoRepository.Get(id);

        if (entity is null)
            throw new MovimientoInexistenteExecption();

        Cuenta cuenta = await _cuentaRepository.Get(entity.CuentaId);

        if (cuenta is null)
            throw new CuentaInexistenteException();

        cuenta.Saldo -= entity.Valor;
        await _cuentaRepository.Attach(cuenta);
        
        var success = await _movimientoRepository.Delete(id);

        return success;
    }
}