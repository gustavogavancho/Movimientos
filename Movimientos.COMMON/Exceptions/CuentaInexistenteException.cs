namespace Movimientos.COMMON.Exceptions;

public class CuentaInexistenteException : Exception
{
    public CuentaInexistenteException()
    {
    }

    public CuentaInexistenteException(string message) : base(message)
    {
    }

    public CuentaInexistenteException(string message, Exception innerException) : base(message, innerException)
    {
    }
}