using System;
using System.Linq;
using System.Threading.Tasks;
using ShopOnline.Dto;

namespace ShopOnline.IBll
{
    public interface IFirstCategoryManager
    {
        /// <summary>
        /// 获取所有一级商品类别
        /// </summary>
        /// <returns></returns>
        IQueryable<ProductCategoryDto> GetAllCategory();

        /// <summary>
        /// 修改商品类别
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<int> EditCategory(ProductCategoryDto model);

        /// <summary>
        /// 添加商品类别
        /// </summary>
        /// <param name="categoryName"></param>
        /// <returns></returns>
        Task<int> AddCategory(string categoryName);

        /// <summary>
        /// 查询某一类别
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task< ProductCategoryDto> QueryCategory(Guid id);

        /// <summary>
        /// 修改类别状态
        /// </summary>
        /// <param name="id">类别Id</param>
        /// <param name="state">状态</param>
        /// <returns></returns>
        Task<int> EditCategoryState(Guid id,bool state);

    }
}