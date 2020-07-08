using System;
using System.Linq;
using System.Threading.Tasks;
using ShopOnline.Dto;
using ShopOnline.Model;

namespace ShopOnline.IBll
{
    public interface IUserDistributionManager
    {
        /// <summary>
        /// 添加收件人信息
        /// </summary>
        /// <returns></returns>
        Task<int> AddUserDistribution(UserDistributionDto model);

        /// <summary>
        /// 查询收件人信息
        /// </summary>
        /// <returns></returns>
        Task<UserDistributionDto> QueryUserDistribution(Guid id);

        /// <summary>
        /// 修改收件人信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<int> UpdateUserDistribution(UserDistributionDto model);
    }
}