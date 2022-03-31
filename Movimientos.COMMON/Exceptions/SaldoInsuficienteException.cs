namespace Movimientos.COMMON.Exceptions;

public class SaldoInsuficienteException : Exception
{
    public decimal ValorRetirar { get; set; }
    public decimal ValorDisponible { get; set; }

    public SaldoInsuficienteException(decimal valorRetirar, decimal valorDisponible)
    {
        ValorRetirar = valorRetirar;
        ValorDisponible = valorDisponible;
    }

    public SaldoInsuficienteException(decimal valorRetirar, decimal valorDisponible, string message) : base(message)
    {
        ValorRetirar = valorRetirar;
        ValorDisponible = valorDisponible;
    }

    public SaldoInsuficienteException(decimal valorRetirar, decimal valorDisponible, string message, Exception innerException) : base(message, innerException)
    {
        ValorRetirar = valorRetirar;
        ValorDisponible = valorDisponible;
    }
}