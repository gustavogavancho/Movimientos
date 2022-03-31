using Movimientos.COMMON.Models;

namespace Movimientos.BIZ.Repository.Interfaces;

public interface IGenericRepository<TEntity> where TEntity : BaseEntity
{
    Task<IEnumerable<TEntity>> GetAll();
    Task<TEntity> Get(Guid id);
    Task<TEntity> Create(TEntity entity);
    Task<TEntity> Update(Guid id, TEntity entity);
    Task<bool> Delete(Guid id);
}