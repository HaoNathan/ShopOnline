﻿using System;
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
        Task<int> AddAsync(T model);

        Task<int> EditAsync(T model);

        Task<int> DeleteAsync(T model);

        IQueryable<T> QueryAllAsync(bool isRemove);

        IQueryable<T> QueryAllAsync(Expression<Func<T, bool>> lambdaFunc);

        Task<T> QueryAsync(bool isRemove,Expression<Func<T, bool>> lambdaFunc);

        Task<T> QueryAsync(Guid id);

        Task<bool> IsExistsAsync(Expression<Func<T, bool>> lambdaFunc);

    }
}
