using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Movimientos.BIZ.Repository.Interfaces;
using Movimientos.COMMON.Models;
using Movimientos.DAL.EFCore;

namespace Movimientos.BIZ.Repository;

public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseEntity
{
    private readonly MovimientosDbContext _context;

    public GenericRepository(MovimientosDbContext context)
    {
        _context = context;
    }

    public async Task<TEntity> Create(TEntity entity)
    {
        entity.Id = Guid.NewGuid();
        EntityEntry<TEntity> createdResult = await _context.Set<TEntity>().AddAsync(entity);
        await _context.SaveChangesAsync();

        return createdResult.Entity;
    }

    public async Task<bool> Delete(Guid id)
    {
        TEntity entity = await _context.Set<TEntity>().FirstOrDefaultAsync((e) => e.Id == id);
        _context.Set<TEntity>().Remove(entity);
        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<TEntity> Get(Guid id)
    {
        TEntity entity = await _context.Set<TEntity>().FirstOrDefaultAsync((e) => e.Id == id);

        return entity;
    }

    public async Task<IEnumerable<TEntity>> GetAll()
    {
        IEnumerable<TEntity> entities = await _context.Set<TEntity>().ToListAsync();

        return entities;
    }

    public async Task<TEntity> Update(Guid id, TEntity entity)
    {
        entity.Id = id;
        _context.Set<TEntity>().Update(entity);
        await _context.SaveChangesAsync();

        return entity;
    }
}