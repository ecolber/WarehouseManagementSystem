using WarehouseMgmt.Application.Models.ProductsTypes;

namespace WarehouseMgmt.Application.Services.Interfaces
{
    public interface IProductTypeService
    {
        Task<IEnumerable<ProductTypeResponseModel>> GetAll();
        Task<ProductTypeResponseModel> GetById(int id);
        Task Add(ProductTypeRequestModel entity);
        Task Update(ProductTypeRequestModel entity, int id);
        Task Delete(int id);
    }
}
