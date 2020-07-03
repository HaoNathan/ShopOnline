using System;
using System.Threading.Tasks;
using ShopOnline.Dto;

namespace ShopOnline.IBll
{
    public interface IProductAttributesManager
    {
        Task<int> AddSize(string sizeName);
        Task<int> AddColor(string colorName);
        Task<ColorDto> QueryColor(Guid id,string name="");
        Task<SizeDto> QuerySize(Guid id,string name="");
        Task<bool> IsExist(string sizeName);
        Task<bool> IsExistColor(string colorName);

    }
}