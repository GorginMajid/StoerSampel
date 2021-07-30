using System.Threading.Tasks;
using StoreSampel.Application.Contracts;
using StoreSampel.Application.Repository;
using StoreSampel.Persistence.Context;

namespace StoreSampel.Application.UnitOfWork
{
    public class UnitOfWork:IUnitOfWork
    {
        public StoreSampelContext _Context { get; }
        private IBrandRepository _brandRepository;
        private IModelRepository _modelRepository;
        private ITypeRepository _typeRepository;
        private IOrderRepository _orderRepository;
        public UnitOfWork(StoreSampelContext context)
        {
            _Context = context;
          
        }
        public IBaseRepository<TEntity> BaseRepository<TEntity>() where TEntity : class
        {
            IBaseRepository<TEntity> repository = new BaseRepository<TEntity, StoreSampelContext>(_Context);
            return repository;
        }
        public IBrandRepository BrandRepository
        {
            get
            {
                if (_brandRepository == null)
                    _brandRepository = new BrandRepository(this);

                return _brandRepository;
            }
        }
        public IModelRepository ModelRepository
        {
            get
            {
                if (_modelRepository == null)
                    _modelRepository = new ModelRepository(this);

                return _modelRepository;
            }
        }

        public IOrderRepository OrderRepository
        {
            get
            {
                if (_orderRepository == null)
                    _orderRepository = new OrderRepository(this);

                return _orderRepository;
            }
        }

        public ITypeRepository TypeRepository
        {
            get
            {
                if (_typeRepository == null)
                    _typeRepository = new TypeRepository(this);

                return _typeRepository;
            }
        }
        public  async Task Commit()
        {
            await _Context.SaveChangesAsync();
        }
    }
}