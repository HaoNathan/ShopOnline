using System;
using System.Linq;
using System.Threading.Tasks;
using ShopOnline.Dto;

namespace ShopOnline.IBll
{
    public interface IProductManager
    {
        /// <summary>
        /// 获取所有商品
        /// </summary>
        /// <returns></returns>
        IQueryable<ProductDto> GetAllProducts();

        /// <summary>
        /// 修改商品信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<int> EditProduct(ProductDto model);

        /// <summary>
        /// 修改商品状态
        /// </summary>
        /// <param name="id">商品Id</param>
        /// <param name="state">状态</param>
        /// <returns></returns>
        Task<int> UpdateProductState(Guid id, bool state);

        /// <summary>
        /// 添加商品
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
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

        /// <summary>
        /// 按一级类别查询
        /// </summary>
        /// <returns></returns>
        IQueryable<ProductCategoryDto> GetFirstCategoryList();

        /// <summary>
        /// 按二级类别查询
        /// </summary>
        /// <returns></returns>
        IQueryable<ProductCategoryDto> GetSecondCategoryList();

        /// <summary>
        /// 按三级类别查询
        /// </summary>
        /// <returns></returns>
        IQueryable<ProductCategoryDto> GetThirdCategoryList();

    }
}