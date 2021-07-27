using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StoreSampel.Application.Contracts;
using StoreSampel.Domain.Entities.Types;

namespace StoreSampel.Application.Repository
{
    public class TypeRepository:ITypeRepository
    {
        private readonly IUnitOfWork _uw;

        public TypeRepository(IUnitOfWork uw)
        {
            _uw = uw;
        }
        public async Task<IEnumerable<Type>> GetAllTypes()
        {
            var result = await _uw.BaseRepository<Type>().FindAllAsync();
            return result.ToList();
        }

        public async Task<Type> GetTypeById(int typeId)
        {

            var result = await _uw.BaseRepository<Type>().FindByIdAsync(typeId);
            return result;
        }

        public async Task InsertType(Type type)
        {
            await _uw.BaseRepository<Type>().CreateAsync(type);
        }

        public async Task DeleteType(Type type)
        {
            _uw.BaseRepository<Type>().Delete(type);
        }

        public  async Task DeleteType(int typeId)
        {
            var delete = await GetTypeById(typeId);
            await DeleteType(delete);
        }

        public async Task UpdateType(Type typeId)
        {
            _uw.BaseRepository<Type>().Update(typeId);
        }
        public async Task<IEnumerable<Type>> GetTypeByModelId(int id)
        {
            var model = await _uw.BaseRepository<Type>().FindByConditionAsync(c => c.ModelId == id);
            return model;
        }
    }
}