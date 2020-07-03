using System;
using System.Linq;
using System.Threading.Tasks;
using ShopOnline.Dto;

namespace ShopOnline.IBll
{
    public interface ISecondCategoryManager
    {
        IQueryable<ProductCategoryDto> GetAllCategory();

        Task<int> EditCategory(ProductCategoryDto model);

        Task<int> AddCategory(string categoryName);

        Task<ProductCategoryDto> QueryCategory(Guid id);

        Task<int> EditCategoryState(Guid id, bool state);
    }
}