namespace Movimientos.COMMON.Exceptions;

public class LimiteRetiroDiarioException : Exception
{
    public decimal ValorRetirar { get; set; }
    public decimal ValorTotalRetirado { get; set; }

    public LimiteRetiroDiarioException(decimal valorRetirar, decimal valorTotalRetirado)
    {
        ValorRetirar = valorRetirar;
        ValorTotalRetirado = valorTotalRetirado;
    }

    public LimiteRetiroDiarioException(decimal valorRetirar, decimal valorTotalRetirado, string message) : base(message)
    {
        ValorRetirar = valorRetirar;
        ValorTotalRetirado = valorTotalRetirado;
    }

    public LimiteRetiroDiarioException(decimal valorRetirar, decimal valorTotalRetirado, string message, Exception innerException) : base(message, innerException)
    {
        ValorRetirar = valorRetirar;
        ValorTotalRetirado = valorTotalRetirado;
    }
}