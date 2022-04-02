namespace Movimientos.COMMON.Exceptions;

public class MovimientoInexistenteExecption : Exception
{
    public MovimientoInexistenteExecption()
    {
    }

    public MovimientoInexistenteExecption(string message) : base(message)
    {
    }

    public MovimientoInexistenteExecption(string message, Exception innerException) : base(message, innerException)
    {
    }
}