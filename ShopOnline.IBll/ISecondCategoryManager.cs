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

        IQueryable<ProductCategoryDto> QueryCategory(Guid id);
    }
}