using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using StoreSampel.Domain.Entities.Brands;

namespace StoreSampel.Application.Contracts
{
    public interface IBrandRepository
    {
        Task<IEnumerable<Brand>> GetAllBrands();
        Task<Brand> GetBrandById(long BrandId);
        Task InsertBrand(Brand brand);
        Task DeleteBrand(Brand Brand);
        Task DeleteBrand(long BrandId);
        Task UpdateBrand(Brand brand);
    }
}