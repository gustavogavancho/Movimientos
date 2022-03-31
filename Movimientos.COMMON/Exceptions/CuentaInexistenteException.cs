namespace Movimientos.COMMON.Exceptions;

public class CuentaInexistenteException : Exception
{
    public Guid GuidCuenta { get; set; }

    public CuentaInexistenteException(Guid guidCuenta)
    {
        GuidCuenta = guidCuenta;
    }

    public CuentaInexistenteException(Guid guidCuenta, string message) : base(message)
    {
        GuidCuenta = guidCuenta;
    }

    public CuentaInexistenteException(Guid guidCuenta, string message, Exception innerException) : base(message, innerException)
    {
        GuidCuenta = guidCuenta;
    }
}