using Movimientos.COMMON.Enums;

namespace Movimientos.COMMON.Exceptions;

public class TipoCuentaIncorrectaException : Exception
{
    public Tipo Tipo { get; set; }

    public TipoCuentaIncorrectaException(Tipo tipo)
    {
        Tipo = tipo;
    }

    public TipoCuentaIncorrectaException(Tipo tipo, string message) : base(message)
    {
        Tipo = tipo;
    }

    public TipoCuentaIncorrectaException(Tipo tipo, string message, Exception innerException) : base(message, innerException)
    {
        Tipo = tipo;
    }
}