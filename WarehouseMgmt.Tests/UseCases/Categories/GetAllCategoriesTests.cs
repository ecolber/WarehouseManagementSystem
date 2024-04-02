using Moq;
using AutoMapper;
using WarehouseMgmt.Application.Models.Categories;
using WarehouseMgmt.Application.Services;
using WarehouseMgmt.Domain.Entities;
using WarehouseMgmt.Domain.Repositories;

namespace WarehouseMgmt.Tests.UseCases.Categories
{
    public class GetAllCategoriesTests
    {
        [Fact]
        public async Task GetAll_ShouldReturnAllCategories()
        {
            // Arrange
            var mockCategoryRepository = new Mock<ICategoryRepository>();
            var mockMapper = new Mock<IMapper>();

            var categories = new List<CategoryEntity>
            {
                new CategoryEntity { Id = 1,Description="" },
                new CategoryEntity { Id = 2, Description= "" }
            };

            mockCategoryRepository.Setup(repo => repo.GetAllAsync()).ReturnsAsync(categories);

            var categoryResponseModels = new List<CategoryResponseModel>
            {
                new CategoryResponseModel { Id = 1, Description ="" },
                new CategoryResponseModel { Id = 2, Description ="hdhdg" }
            };

            mockMapper.Setup(mapper => mapper.Map<IEnumerable<CategoryResponseModel>>(categories)).Returns(categoryResponseModels);

            var categoryServices = new CategoryServices(mockCategoryRepository.Object, mockMapper.Object);

            // Act
            var result = await categoryServices.GetAll();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, ((List<CategoryResponseModel>)result).Count); // Assuming you expect two products
        }

        [Fact]
        public async Task Add_ShouldInsertCategory()
        {
            // Arrange
            var mockCategoryRepository = new Mock<ICategoryRepository>();
            var mockMapper = new Mock<IMapper>();

            var categoryRequestModel = new CategoryRequestModel
            {
                
            };

            var categoryEntity = new CategoryEntity
            {
                Id = 1
            };

            mockMapper.Setup(mapper => mapper.Map<CategoryEntity>(categoryRequestModel)).Returns(categoryEntity);

            var categoryServices = new CategoryServices(mockCategoryRepository.Object, mockMapper.Object);

            // Act
            await categoryServices.Add(categoryRequestModel);

            // Assert
            mockCategoryRepository.Verify(repo => repo.AddAsync(categoryEntity), Times.Once);
            mockCategoryRepository.Verify(repo => repo.SaveChangesAsync(), Times.Once);
        }
    }
}

