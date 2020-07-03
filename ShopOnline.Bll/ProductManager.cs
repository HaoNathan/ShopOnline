using System;
using System.Linq;
using System.Threading.Tasks;
using ShopOnline.Dal;
using ShopOnline.Dto;
using ShopOnline.IBll;
using ShopOnline.IDal;

namespace ShopOnline.Bll
{
    public class ProductManager : IProductManager
    {
        public IQueryable<ProductDto> GetAllProducts()
        {
            throw new NotImplementedException();
        }

        public async Task<int> EditProduct(ProductDto model)
        {
            throw new NotImplementedException();
        }

        public async Task<int> AddProduct(ProductDto model)
        {
            throw new NotImplementedException();
        }

        public async Task<ProductDto> QueryProduct(Guid id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<ProductCategoryDto> GetFirstCategoryList()
        {
            IFirstCategoryService service = new FirstCategoryService();
            return service.QueryAllAsync(true).Select(m => new ProductCategoryDto()
            {
                Id = m.Id,
                CategoryName = m.FirstProductCategoryName
            });

        }

        public IQueryable<ProductCategoryDto> GetSecondCategoryList()
        {
            ISecondCategoryService service = new SecondCategoryService();

            return service.QueryAllAsync(true).Select(m => new ProductCategoryDto()
            {
                Id = m.Id,
                CategoryName = m.SecondProductCategoryName
            });
        }

        public IQueryable<ProductCategoryDto> GetThirdCategoryList()
        {
            IThirdCategoryService service = new ThirdCategoryService();

            return service.QueryAllAsync(true).Select(m => new ProductCategoryDto()
            {
                Id = m.Id,
                CategoryName = m.ThirdProductCategoryName
            });

        }
    }
}