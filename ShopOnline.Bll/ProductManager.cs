using System;
using System.Linq;
using System.Threading.Tasks;
using ShopOnline.Dal;
using ShopOnline.Dto;
using ShopOnline.IBll;
using ShopOnline.IDal;
using ShopOnline.Model;

namespace ShopOnline.Bll
{
    public class ProductManager : IProductManager
    {
        private IProductService _service;

        public ProductManager(IProductService service)
        {
            _service = service;
        }

        public IQueryable<ProductDto> GetAllProducts()
        {
            return _service.QueryAllAsync(false).Select(m => new ProductDto()
            {
                Id = m.Id,
                ColorName = m.Color.ColorName,
                SizeName = m.Size.SizeName,
                FirstProductCategoryName = m.FirstProductCategory.FirstProductCategoryName,
                SecondProductCategoryName = m.SecondProductCategory.SecondProductCategoryName,
                ThirdProductCategoryName = m.ThirdProductCategory.ThirdProductCategoryName,
                CreateTime = m.CreateTime,
                ProductCost = m.ProductCost,
                ProductPrice = m.ProductPrice,
                ProductImagePath = m.ProductImagePath,
                IsRemove = m.IsRemove,
                GS1Id = m.GS1Id,
                ProductName = m.ProductName,
                ProductDescription = m.ProductDescription,
                ProductNumber = m.ProductNumber
            });
        }

        public async Task<int> EditProduct(ProductDto model)
        {
            var product = await _service.QueryAsync(model.Id);
            product.ProductName = model.ProductName;
            product.ProductCost = model.ProductCost;
            product.ProductPrice = model.ProductPrice;
            product.ProductDescription = model.ProductDescription;
            product.ProductImagePath = model.ProductImagePath;
            product.FirstProductCategoryId = model.FirstProductCategoryId;
            product.SecondProductCategoryId = model.SecondProductCategoryId;
            product.ThirdProductCategoryId = model.ThirdProductCategoryId;
            product.SizeId = model.SizeId;
            product.ColorId = model.ColorId;
            product.ProductNumber = model.ProductNumber;
            product.GS1Id = model.GS1Id;

            return await _service.EditAsync(product);
        }

        public async Task<int> AddProduct(ProductDto model)
        {
            return await _service.AddAsync(new Product()
            {
                ProductName = model.ProductName,
                ProductCost = model.ProductCost,
                ProductPrice = model.ProductPrice,
                ProductDescription = model.ProductDescription,
                ProductImagePath = model.ProductImagePath,
                FirstProductCategoryId = model.FirstProductCategoryId,
                SecondProductCategoryId = model.SecondProductCategoryId,
                ThirdProductCategoryId = model.ThirdProductCategoryId,
                SizeId = model.SizeId,
                ColorId = model.ColorId,
                ProductNumber = model.ProductNumber,
                GS1Id = model.GS1Id
            });
        }

        public async Task<ProductDto> QueryProduct(Guid id)
        {
            var product = await _service.QueryAsync(id);
            IColorService service=new ColorService();
            ISizeService service2=new SizeService();

            

            var productDto = new ProductDto()
            {
                Id = product.Id,
                ProductName = product.ProductName,
                ProductCost = product.ProductCost,
                ProductPrice = product.ProductPrice,
                ProductDescription = product.ProductDescription,
                ProductImagePath = product.ProductImagePath,
                FirstProductCategoryId = product.FirstProductCategoryId,
                SecondProductCategoryId = product.SecondProductCategoryId,
                ThirdProductCategoryId = product.ThirdProductCategoryId,
                SizeId = product.SizeId,
                ColorId = product.ColorId,
                ProductNumber = product.ProductNumber,
                GS1Id = product.GS1Id
            };

            var color =await service.QueryAsync(m => m.Id.Equals(productDto.ColorId));
            var size =await service2.QueryAsync(m=>m.Id.Equals(productDto.SizeId));
            productDto.ColorName = color.ColorName;
            productDto.SizeName = size.SizeName;

            return productDto;
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