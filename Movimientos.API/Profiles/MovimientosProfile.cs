using AutoMapper;
using Movimientos.API.Models;
using Movimientos.COMMON.Models;

namespace Movimientos.API.Profiles;

public class MovimientosProfile : Profile
{
    public MovimientosProfile()
    {
        CreateMap<ClienteModel, Cliente>();
        CreateMap<CuentaModel, Cuenta>();
        CreateMap<MovimientoModel, Movimiento>();
    }
}