using System;
using System.Linq;
using System.Threading.Tasks;
using ShopOnline.Dto;
using ShopOnline.IBll;
using ShopOnline.IDal;
using ShopOnline.Model;

namespace ShopOnline.Bll
{
    public class SecondCategoryManager:ISecondCategoryManager
    {
        private readonly ISecondCategoryService _service;

        public SecondCategoryManager(ISecondCategoryService service)
        {
            _service = service;
        }
        public IQueryable<ProductCategoryDto> GetAllCategory()
        {
            var data = _service.QueryAllAsync(false)
                .Select(m => new ProductCategoryDto()
                {
                    Id = m.Id,
                    CategoryName = m.SecondProductCategoryName,
                    CreateTime = m.CreateTime,
                    UpdateTime = m.UpdateTime,
                    IsRemove = m.IsRemove
                });

            return data;
        }

        public async Task<int> EditCategory(ProductCategoryDto model)
        {
            return await _service.EditAsync(new SecondProductCategory()
            {
                UpdateTime = DateTime.Now,
                SecondProductCategoryName = model.CategoryName
            });
        }

        public async Task<int> AddCategory(string categoryName)
        {
            return await _service.AddAsync(new SecondProductCategory()
            {
                SecondProductCategoryName = categoryName
            });
        }

        public async Task<ProductCategoryDto> QueryCategory(Guid id)
        {
            var category = await _service.QueryAsync(id);
            return new ProductCategoryDto()
            {
                Id = category.Id,
                CreateTime = category.CreateTime,
                CategoryName = category.SecondProductCategoryName,
                IsRemove = category.IsRemove
            };
        }

        public async Task<int> EditCategoryState(Guid id, bool state)
        {
            return await _service.EditAsync(new SecondProductCategory()
            {
                IsRemove = state
            });
        }
    }
}