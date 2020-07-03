using System;
using System.Threading.Tasks;
using ShopOnline.Dal;
using ShopOnline.Dto;
using ShopOnline.IBll;
using ShopOnline.IDal;
using ShopOnline.Model;

namespace ShopOnline.Bll
{
    public class ProductAttributesManager:IProductAttributesManager
    {
        private readonly ISizeService _service;

        public ProductAttributesManager(ISizeService service)
        {
            _service = service;
        }

        public async Task<int> AddSize(string sizeName)
        {
            return await _service.AddAsync(new Size()
            {
                SizeName = sizeName
            });
        }

        public async Task<int> AddColor(string colorName)
        {
            IColorService manager = new ColorService();

            return await manager.AddAsync(new Color()
            {
                ColorName = colorName
            });

        }

        public async Task<SizeDto> QuerySize(Guid id, string sizeName="")
        {
            if (sizeName != "")
            {
                var color = await _service.QueryAsync(m => m.SizeName.Equals(sizeName));
                return new SizeDto()
                {
                    Id = color.Id,
                    SizeName = color.SizeName
                };
            }
            else
            {
                var color = await _service.QueryAsync(id);
                return new SizeDto()
                {
                    Id = color.Id,
                    SizeName = color.SizeName
                };
            }
        }

        public async Task<bool> IsExist(string sizeName)
        {
            return await _service.IsExistsAsync(m => m.SizeName == sizeName);
        }

        public async Task<bool> IsExistColor(string colorName)
        {
            IColorService service = new ColorService();
            return await service.IsExistsAsync(m => m.ColorName == colorName);
        }

        public async Task<ColorDto> QueryColor(Guid id,string colorName="")
        {
            IColorService service = new ColorService();
            if (colorName!="")
            {
                var color = await service.QueryAsync(m=>m.ColorName.Equals(colorName));
                return new ColorDto()
                {
                    Id = color.Id,
                    ColorName = color.ColorName
                };
            }
            else
            {
                var color = await service.QueryAsync(id);
                return new ColorDto()
                {
                    Id = color.Id,
                    ColorName = color.ColorName
                };
            }
            
            
        }
    }
}