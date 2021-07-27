using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StoreSampel.Application.Contracts;
using StoreSampel.Domain.Entities.Models;

namespace StoreSampel.Application.Repository
{
    public class ModelRepository:IModelRepository
    {
        private readonly IUnitOfWork _uw;

        public ModelRepository(IUnitOfWork uw)
        {
            _uw = uw;
        }
        public  async Task<IEnumerable<Model>> GetAllModels()
        {
            var result = await _uw.BaseRepository<Model>().FindAllAsync();
            return result.ToList();
        }

        public async Task<Model> GetModelById(int modelId)
        {
            var result =await _uw.BaseRepository<Model>().FindByIdAsync(modelId);
            return result;
        }

        public async Task InsertModel(Model model)
        {
            await _uw.BaseRepository<Model>().CreateAsync(model);
        }

        public async Task DeleteModel(Model model)
        {
            _uw.BaseRepository<Model>().Delete(model);
        }

        public async Task DeleteModel(int ModelId)
        {
            var delete = await GetModelById(ModelId);
            await DeleteModel(delete);
        }

        public async Task UpdateModel(Model model)
        {
            _uw.BaseRepository<Model>().Update(model);
        }


        public  async Task<IEnumerable<Model>> GetModelByBrnadId(int id)
        {
            var model = await _uw.BaseRepository<Model>().FindByConditionAsync(c => c.BrandId == id);
            return model;
        }
    }
}