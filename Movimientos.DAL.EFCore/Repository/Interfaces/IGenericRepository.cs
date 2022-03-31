using Movimientos.COMMON.Models;

namespace Movimientos.DAL.EFCore.Repository.Interfaces;

public interface IGenericRepository<TEntity> where TEntity : BaseEntity
{
    Task<IEnumerable<TEntity>> GetAll();
    Task<TEntity> Get(Guid id);
    Task<TEntity> Create(TEntity entity);
    Task<TEntity> Update(Guid id, TEntity entity);
    Task<TEntity> Attach(TEntity entity);
    Task<bool> Delete(Guid id);
}