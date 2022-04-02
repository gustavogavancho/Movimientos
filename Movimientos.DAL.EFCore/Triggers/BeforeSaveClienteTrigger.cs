using EntityFrameworkCore.Triggered;
using Movimientos.COMMON.Models;

namespace Movimientos.DAL.EFCore.Triggers;

public class BeforeSaveClienteTrigger : IBeforeSaveTrigger<Cliente>
{
    private readonly MovimientosDbContext _context;
    
    public BeforeSaveClienteTrigger(MovimientosDbContext context)
    {
        _context = context;
    }

    public Task BeforeSave(ITriggerContext<Cliente> context, CancellationToken cancellationToken)
    {
        if (context.ChangeType == ChangeType.Added)
        {
            context.Entity.Contraseña = BCrypt.Net.BCrypt.HashPassword(context.Entity.Contraseña);
        }

        return Task.CompletedTask;
    }
}