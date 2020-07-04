using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ShopOnline.Dto;

namespace ShopOnline.IBll
{
    public interface IProductCommentManager
    {
        Task<int> AddComment(ProductCommentDto model);
        Task<ProductCommentDto> QueryComment(Guid id);
        IQueryable<ProductCommentDto> QueryAllComment();
        IQueryable<ProductCommentDto> QueryAllComment(Expression<Func<string,bool>>lambdaFunc);

    }
}