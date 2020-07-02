using System;
using System.Linq;
using System.Threading.Tasks;
using ShopOnline.Dto;

namespace ShopOnline.IBll
{
    public interface IThirdCategoryManager
    {
        /// <summary>
        /// 查询全部一级分类
        /// </summary>
        /// <returns></returns>
        IQueryable<ProductCategoryDto> GetAllCategory();

        /// <summary>
        /// 修改操作
        /// </summary>
        /// <param name="model">实体对象</param>
        /// <returns></returns>
        Task<int> EditCategory(ProductCategoryDto model);

        /// <summary>
        /// 单个查询
        /// </summary>
        /// <param name="id">主键id</param>
        /// <returns></returns>
        IQueryable<ProductCategoryDto> QueryCategory(Guid id);
    }
}