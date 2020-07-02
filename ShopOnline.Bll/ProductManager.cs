using System;
using System.Linq;
using System.Threading.Tasks;
using ShopOnline.Dto;
using ShopOnline.IBll;
using ShopOnline.IDal;

namespace ShopOnline.Bll
{
    public class ProductManager:IProductManager
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
    }
}