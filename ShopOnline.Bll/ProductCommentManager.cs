using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ShopOnline.Dto;
using ShopOnline.IBll;

namespace ShopOnline.Bll
{
    public class ProductCommentManager:IProductCommentManager
    {
        public async Task<int> AddComment()
        {
            throw new NotImplementedException();
        }

        public async Task<ProductCommentDto> QueryComment()
        {
            throw new NotImplementedException();
        }

        public IQueryable<ProductCommentDto> QueryAllComment()
        {
            throw new NotImplementedException();
        }

        public IQueryable<ProductCommentDto> QueryAllComment(Expression<Func<string, bool>> lambdaFunc)
        {
            throw new NotImplementedException();
        }
    }
}