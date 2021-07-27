using System.Threading.Tasks;
using StoreSampel.Persistence.Context;

namespace StoreSampel.Application.Contracts
{
    public interface IUnitOfWork
    {
        IBaseRepository<TEntity> BaseRepository<TEntity>() where TEntity : class;
        StoreSampelContext _Context { get; }
        IBrandRepository BrandRepository { get; }
        IModelRepository ModelRepository { get; }
         ITypeRepository TypeRepository { get;  }
        Task Commit();
    }
}