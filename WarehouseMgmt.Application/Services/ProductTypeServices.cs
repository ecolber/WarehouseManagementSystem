using AutoMapper;
using WarehouseMgmt.Application.Models.Products;
using WarehouseMgmt.Application.Models.ProductsTypes;
using WarehouseMgmt.Application.Services.Interfaces;
using WarehouseMgmt.Domain.Entities;
using WarehouseMgmt.Domain.Repositories;

namespace WarehouseMgmt.Application.Services
{
    public class ProductTypeServices : IProductTypeService
    {
        private readonly IProductTypeRepository _productTypeRepository;
        private readonly IMapper _mapper;

        public ProductTypeServices(IProductTypeRepository productTypeRepository, IMapper mapper)
        {
            _productTypeRepository = productTypeRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductTypeResponseModel>> GetAll()
        {
            var productTypeEntity = await _productTypeRepository.GetAllAsync();

            var productTypeResponseModel = _mapper.Map<IEnumerable<ProductTypeResponseModel>>(productTypeEntity);

            return productTypeResponseModel;
        }

        public async Task<ProductTypeResponseModel> GetById(int id)
        {
            var productTypeEntity = _productTypeRepository.GetByIdSync(id);

            var productTypeResponseModel = _mapper.Map<ProductTypeResponseModel>(productTypeEntity);

            return productTypeResponseModel;
        }

        public async Task Add(ProductTypeRequestModel entity)
        {
            var productTypeEntity = _mapper.Map<ProductTypeEntity>(entity);
            await _productTypeRepository.AddAsync(productTypeEntity);
            await _productTypeRepository.SaveChangesAsync();
        }

        public async Task Update(ProductTypeRequestModel entity, int id)
        {
            ProductTypeEntity productTypeEntityFound = await _productTypeRepository.GetByIdAsync(id) ?? throw new Exception("El tipo de producto no existe");

            var productTypeEntity = _mapper.Map(entity, productTypeEntityFound);

            await _productTypeRepository.UpdateAsync(productTypeEntity);
            await _productTypeRepository.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            await _productTypeRepository.DeleteAsync(id);
            await _productTypeRepository.SaveChangesAsync();
        }
    }
}
