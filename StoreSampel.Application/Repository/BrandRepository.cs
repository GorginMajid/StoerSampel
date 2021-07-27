using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StoreSampel.Application.Contracts;
using StoreSampel.Domain.Entities.Brands;

namespace StoreSampel.Application.Repository
{
    public class BrandRepository:IBrandRepository
    {
        private readonly IUnitOfWork _uw;

        public BrandRepository(IUnitOfWork uw)
        {
            _uw = uw;
        }
        public async Task<IEnumerable<Brand>> GetAllBrands()
        {
        var result=await _uw.BaseRepository<Brand>().FindAllAsync();
        return result.ToList();
        }

        public async Task<Brand> GetBrandById(long BrandId)
        {
            var result =await _uw.BaseRepository<Brand>().FindByIdAsync(BrandId);
            return result;
        }

        public async Task InsertBrand(Brand brand)
        {
            await  _uw.BaseRepository<Brand>().CreateAsync(brand);
        }

        public  async Task DeleteBrand(Brand Brand)
        {
            _uw.BaseRepository<Brand>().Delete(Brand);
        }

        public async Task DeleteBrand(long BrandId)
        {
            var delete = await GetBrandById(BrandId);
           await DeleteBrand(delete);
        }

        public async Task UpdateBrand(Brand brand)
        {
            _uw.BaseRepository<Brand>().Update(brand);
        }
    }
}