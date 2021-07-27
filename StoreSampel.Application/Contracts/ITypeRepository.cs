using System.Collections.Generic;
using System.Threading.Tasks;
using StoreSampel.Domain.Entities.Types;

namespace StoreSampel.Application.Contracts
{
    public interface ITypeRepository
    {
        Task<IEnumerable<Type>> GetAllTypes();
        Task<Type> GetTypeById(int typeId);
        Task InsertType(Type type);
        Task DeleteType(Type type);
        Task DeleteType(int typeId);
        Task UpdateType(Type typeId);
        Task<IEnumerable<Type>> GetTypeByModelId(int id);
    }
}