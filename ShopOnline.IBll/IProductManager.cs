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

        Task<int> UpdateProductState(Guid id, bool state);

        Task<int> AddProduct(ProductDto model);

        /// <summary>
        /// 根据主键查询商品
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        Task<ProductDto> QueryProduct(Guid id);
        /// <summary>
        /// 按名称查询
        /// </summary>
        /// <param name="name">商品名</param>
        /// <returns></returns>
         IQueryable<ProductDto> QueryProduct(string name);

        /// <summary>
        /// 按类别名查询商品
        /// </summary>
        /// <param name="index">按哪一种类别进行查询</param>
        /// <param name="categoryName">类别名称</param>
        /// <returns></returns>
        IQueryable<ProductDto> QueryProductByCategory(int index, string categoryName);

        /// <summary>
        /// 按类别名查询商品
        /// </summary>
        /// <param name="categoryName">按哪一种类别进行查询</param>
        /// <returns></returns>
        IQueryable<ProductDto> QueryProductByCategory( string categoryName);

        IQueryable<ProductCategoryDto> GetFirstCategoryList();

        IQueryable<ProductCategoryDto> GetSecondCategoryList();

        IQueryable<ProductCategoryDto> GetThirdCategoryList();

    }
}