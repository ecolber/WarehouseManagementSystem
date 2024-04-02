using AutoMapper;
using WarehouseMgmt.Application.Models.Categories;
using WarehouseMgmt.Application.Services.Interfaces;
using WarehouseMgmt.Domain.Entities;
using WarehouseMgmt.Domain.Repositories;

namespace WarehouseMgmt.Application.Services
{
    public class CategoryServices : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryServices(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CategoryResponseModel>> GetAll()
        {
            var categoryEntity = await _categoryRepository.GetAllAsync();

            var categoryResponseModel = _mapper.Map<IEnumerable<CategoryResponseModel>>(categoryEntity);

            return categoryResponseModel;
        }

        public async Task<CategoryResponseModel> GetById(int id)
        {
            var categoryEntity = _categoryRepository.GetByIdSync(id);

            var categoryResponseModel = _mapper.Map<CategoryResponseModel>(categoryEntity);

            return categoryResponseModel;
        }

        public async Task Add(CategoryRequestModel entity)
        {
            var categoryEntity = _mapper.Map<CategoryEntity>(entity);
            await _categoryRepository.AddAsync(categoryEntity);
            await _categoryRepository.SaveChangesAsync();
        }

        public async Task Update(CategoryRequestModel entity, int id)
        {
            CategoryEntity categoryEntityFound = await _categoryRepository.GetByIdAsync(id) ?? throw new Exception("La categoria no existe");

            var categoryEntity = _mapper.Map(entity, categoryEntityFound);

            await _categoryRepository.UpdateAsync(categoryEntity);
            await _categoryRepository.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            await _categoryRepository.DeleteAsync(id);
            await _categoryRepository.SaveChangesAsync();
        }
    }
}
