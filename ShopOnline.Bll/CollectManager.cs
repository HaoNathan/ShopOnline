using System.Linq;
using System.Threading.Tasks;
using ShopOnline.Dto;
using ShopOnline.IBll;
using ShopOnline.IDal;

namespace ShopOnline.Bll
{
    public class CollectManager:ICollectManager
    {
        private readonly ICollectService _service;

        public CollectManager(ICollectService service)
        {
            _service = service;
        }


        public async Task<int> AddCollect()
        {
            throw new System.NotImplementedException();
        }

        public async Task<int> UpdateCollect()
        {
            throw new System.NotImplementedException();
        }

        public async Task<CollectDto> QueryCollect()
        {
            throw new System.NotImplementedException();
        }

        public IQueryable<CollectDto> QueryAllCollect()
        {
            throw new System.NotImplementedException();
        }
    }
}