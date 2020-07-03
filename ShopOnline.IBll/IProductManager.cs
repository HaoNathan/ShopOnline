using System;
using System.Linq;
using System.Threading.Tasks;
using ShopOnline.Dto;

namespace ShopOnline.IBll
{
    public interface IProductManager
    {
        IQueryable<ProductDto> GetAllProducts();

        Task<int> EditProduct(ProductDto model);

        Task<int> AddProduct(ProductDto model);

        Task<ProductDto> QueryProduct(Guid id);

        IQueryable<ProductCategoryDto> GetFirstCategoryList();

        IQueryable<ProductCategoryDto> GetSecondCategoryList();

        IQueryable<ProductCategoryDto> GetThirdCategoryList();

    }
}