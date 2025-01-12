﻿using WarehouseMgmt.Application.Models.Categories;

namespace WarehouseMgmt.Application.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryResponseModel>> GetAll();
        Task<CategoryResponseModel> GetById(int id);
        Task Add(CategoryRequestModel entity);
        Task Update(CategoryRequestModel entity, int id);
        Task Delete(int id);
    }
}
