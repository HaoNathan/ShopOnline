using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ShopOnline.Dto;
using ShopOnline.IBll;
using ShopOnline.IDal;
using ShopOnline.Model;

namespace ShopOnline.Bll
{
    public class ProductCommentManager:IProductCommentManager
    {
        private readonly IProductCommentService _service;

        public ProductCommentManager(IProductCommentService service)
        {
            _service = service;
        }

        public async Task<int> AddComment(ProductCommentDto model)
        {
            return await _service.AddAsync(new ProductComment()
            {
                Comment = model.Comment,
                ProductId = model.ProductId,
                UserId = model.UserId
            });
        }

        public async Task<ProductCommentDto> QueryComment(Guid id)
        {
            var comment= await _service.QueryAsync(id);
            return new ProductCommentDto()
            {
                Comment = comment.Comment,
                CreateTime = comment.CreateTime,
                ProductId = comment.ProductId,
                UserId = comment.UserId,
                Oppose = comment.Oppose,
                Praise = comment.Praise
            };
        }

        public IQueryable<ProductCommentDto> QueryAllComment(bool isRemove)
        {
            if (isRemove)
                return _service.QueryAllAsync()
                    .Select(m => new ProductCommentDto()
                {
                    Comment = m.Comment,
                    CreateTime = m.CreateTime,
                    ProductId = m.ProductId,
                    UserId = m.UserId,
                    Oppose = m.Oppose,
                    Praise = m.Praise
                });
            else
                return _service.QueryAllAsync().Where(m => m.IsRemove == false)
                    .Select(m => new ProductCommentDto()
                {
                    Comment = m.Comment,
                    CreateTime = m.CreateTime,
                    ProductId = m.ProductId,
                    UserId = m.UserId,
                    Oppose = m.Oppose,
                    Praise = m.Praise
                });
        }

        public IQueryable<ProductCommentDto> QueryAllComment(Guid productId)
        {
            return _service.QueryAllAsync().Where(m => m.IsRemove == false)
                .Where(m=>m.ProductId.Equals(productId))
                .Select(m => new ProductCommentDto()
            {
                Comment = m.Comment,
                CreateTime = m.CreateTime,
                ProductId = m.ProductId,
                UserId = m.UserId,
                Oppose = m.Oppose,
                Praise = m.Praise
            });
        }
    }
}