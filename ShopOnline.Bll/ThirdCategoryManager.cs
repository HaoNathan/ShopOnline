using System;
using System.Linq;
using System.Security.AccessControl;
using System.Threading.Tasks;
using ShopOnline.Dto;
using ShopOnline.IBll;
using ShopOnline.IDal;
using ShopOnline.Model;

namespace ShopOnline.Bll
{
    public class ThirdCategoryManager:IThirdCategoryManager
    {
        private readonly IThirdCategoryService _service;

        public ThirdCategoryManager(IThirdCategoryService service)
        {
            _service = service;
        }
        public IQueryable<ProductCategoryDto> GetAllCategory()
        {
            var data = _service.QueryAllAsync()
                .Select(m => new ProductCategoryDto()
                {
                    Id = m.Id,
                    CategoryName = m.ThirdProductCategoryName,
                    CreateTime = m.CreateTime,
                    UpdateTime = m.UpdateTime,
                    IsRemove = m.IsRemove
                });

            return data;
        }

        public async Task<int> EditCategory(ProductCategoryDto model)
        {
            return await _service.EditAsync(new ThirdProductCategory()
            {
                UpdateTime = DateTime.Now,
                ThirdProductCategoryName = model.CategoryName
            });
        }

        public async Task<int> AddCategory(string categoryName)
        {
            return await _service.AddAsync(new ThirdProductCategory()
            {
                ThirdProductCategoryName = categoryName
            });
        }

        public async Task<ProductCategoryDto> QueryCategory(Guid id)
        {
            var category = await _service.QueryAsync(id);
            return new ProductCategoryDto()
            {
                Id = category.Id,
                CreateTime = category.CreateTime,
                CategoryName = category.ThirdProductCategoryName,
                IsRemove = category.IsRemove
            };
        }

        public async Task<int> EditCategoryState(Guid id, bool state)
        {
            var category = await _service.QueryAsync(id);
            category.IsRemove = state;
            return await _service.EditAsync(category);
        }
    }
}