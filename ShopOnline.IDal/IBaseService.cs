using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ShopOnline.Model;

namespace ShopOnline.IDal
{
    /// <summary>
    /// 数据交互层接口类
    /// </summary>
    /// <typeparam name="T">实体类对象</typeparam>
    public interface IBaseService<T> : IDisposable where T : BaseEntity,new()
    {
        /// <summary>
        /// 新增数据
        /// </summary>
        /// <param name="model">需要新增的实体数据</param>
        /// <returns></returns>
        Task<int> AddAsync(T model);

        /// <summary>
        /// 修改数据
        /// </summary>
        /// <param name="model">需要修改的实体数据</param>
        Task<int> EditAsync(T model);

        Task<int> DeleteAsync(T model);

        /// <summary>
        /// 获得某一数据的数量
        /// </summary>
        /// <returns></returns>
        Task<int> GetCountAsync();

        /// <summary>
        /// 查询所有数据
        /// </summary>
        /// <param name="isRemove">是否需要将已移除的数据查出</param>
        IQueryable<T> QueryAllAsync();

        /// <summary>
        /// 查询所有数据按某一条件
        /// </summary>
        /// <param name="lambdaFunc">lambada表达式树(即where条件)</param>
        IQueryable<T> QueryAllAsync(Expression<Func<T, bool>> lambdaFunc);

        /// <summary>
        /// 按条件查询所有数据
        /// </summary>
        /// <param name="isRemove">是否需要将已移除的数据查出</param>
        /// <param name="lambdaFunc">where条件</param>
        Task<T> QueryAsync(Expression<Func<T, bool>> lambdaFunc);

        /// <summary>
        /// 查询单个数据
        /// </summary>
        /// <param name="id">主键ID</param>
        Task<T> QueryAsync(Guid id);

        /// <summary>
        /// 检查某一数据是否存在
        /// </summary>
        /// <param name="lambdaFunc">where条件</param>
        Task<bool> IsExistsAsync(Expression<Func<T, bool>> lambdaFunc);

    }
}
