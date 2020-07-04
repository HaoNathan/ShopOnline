using System.Threading.Tasks;

namespace ShopOnline.IBll
{
    public interface IShoppingCartManager
    {
        Task<int> AddShoppingCart();
        Task<int> UpdateShoppingCart();
        Task<int> QueryShoppingCart();

    }
}