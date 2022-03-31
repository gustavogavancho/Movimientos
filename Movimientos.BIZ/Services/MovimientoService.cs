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
        if (sumaRetiroDiario + entity.Valor < -1000)
            throw new LimiteRetiroDiarioException(entity.Valor, sumaRetiroDiario);

        var cuentaAsociada = await _cuentaRepository.Get(entity.CuentaId);
        if (cuentaAsociada is null)
            throw new CuentaInexistenteException(entity.CuentaId);

        if (cuentaAsociada.SaldoInicial < entity.Valor)
            throw new SaldoInsuficienteException(entity.Valor, cuentaAsociada.SaldoInicial);
        else
        {
            cuentaAsociada.SaldoInicial = cuentaAsociada.SaldoInicial + entity.Valor;
            await _cuentaRepository.Attach(cuentaAsociada);
        }

        Movimiento createdResult = await _movimientoRepository.Create(entity);

        return createdResult;
    }
}