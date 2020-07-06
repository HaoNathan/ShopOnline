using System.Threading.Tasks;
using ShopOnline.Dal;
using ShopOnline.IBll;
using ShopOnline.IDal;

namespace ShopOnline.Bll
{
    public class StatisticsManager:IStatisticsManager
    {
        public async Task<int> GetProductCount()
        {
            IProductService service=new ProductService();
            return await service.GetCountAsync();
        }
    }
}