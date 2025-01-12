﻿using AutoMapper;
using WarehouseMgmt.Application.Models.Products;
using WarehouseMgmt.Application.Services.Interfaces;
using WarehouseMgmt.Domain.Entities;
using WarehouseMgmt.Domain.Repositories;

namespace WarehouseMgmt.Application.Services
{
    public class ProductServices : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public ProductServices(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductResponseModel>> GetAll()
        {
            var productEntity = await _productRepository.GetAllAsync();

            var productResponseModel = _mapper.Map<IEnumerable<ProductResponseModel>>(productEntity);


            return productResponseModel;
        }

        public async Task<ProductResponseModel> GetById(int id)
        {
            var productEntity = _productRepository.GetByIdSync(id);

            var productResponseModel = _mapper.Map<ProductResponseModel>(productEntity);

            return productResponseModel;
        }

        public async Task Add(ProductRequestModel entity)
        {
            var productEntity = _mapper.Map<ProductEntity>(entity);
            await _productRepository.AddAsync(productEntity);
            await _productRepository.SaveChangesAsync();
        }

        public async Task Update(ProductRequestModel entity, int id)
        {
            ProductEntity productEntityFound = await _productRepository.GetByIdAsync(id) ?? throw new Exception("El producto no existe");

            var productEntity = _mapper.Map(entity, productEntityFound);

            await _productRepository.UpdateAsync(productEntity);
            await _productRepository.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            await _productRepository.DeleteAsync(id);
            await _productRepository.SaveChangesAsync();
        }
    }
}
