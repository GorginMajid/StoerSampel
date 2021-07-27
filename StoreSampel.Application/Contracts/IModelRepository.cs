using System.Collections.Generic;
using System.Threading.Tasks;
using StoreSampel.Domain.Entities.Models;

namespace StoreSampel.Application.Contracts
{
    public interface IModelRepository
    {
        Task<IEnumerable<Model>> GetAllModels();
        Task<Model> GetModelById(int modelId);
        Task InsertModel(Model model);
        Task DeleteModel(Model model);
        Task DeleteModel(int model);
        Task UpdateModel(Model modelId);
        Task<IEnumerable<Model>> GetModelByBrnadId(int id);
    }
}