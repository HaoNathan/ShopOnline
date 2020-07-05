using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ShopOnline.Dto;

namespace ShopOnline.IBll
{
    public interface IProductCommentManager
    {
        /// <summary>
        /// 新增评论
        /// </summary>
        Task<int> AddComment(ProductCommentDto model);

        /// <summary>
        /// 按主键查询
        /// </summary>
        Task<ProductCommentDto> QueryComment(Guid id);

        /// <summary>
        /// 查询全部
        /// </summary>
        /// <param name="isRemove">是否需要查询出被移除出的数据</param>
        /// <returns></returns>
        IQueryable<ProductCommentDto> QueryAllComment(bool isRemove);

        /// <summary>
        /// 按商品ID查询出该商品所有评论
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        IQueryable<ProductCommentDto> QueryAllComment(Guid productId);

    }
}