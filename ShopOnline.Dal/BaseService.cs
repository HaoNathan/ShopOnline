﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ShopOnline.IDal;
using ShopOnline.Model;

namespace ShopOnline.Dal
{
    public class BaseService<T>:IBaseService<T> where T:BaseEntity, new()
    {
        private readonly CSContext _db;

        public BaseService(CSContext db)
        {
            _db = db;
        }

        /// <summary>
        /// 释放上下文(dbContext)
        /// </summary>
        public void Dispose()
        {
            _db.Dispose();
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="model">实体对象</param>
        /// <returns></returns>
        public async Task<int> AddAsync(T model)
        {
            _db.Entry(model).State = EntityState.Added;
            return await _db.SaveChangesAsync();
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<int> EditAsync(T model)
        {
            _db.Entry(model).State = EntityState.Modified;
            return await _db.SaveChangesAsync();
        }

        public async Task<int> DeleteAsync(T model)
        {
            _db.Entry(model).State = EntityState.Deleted;
            return await _db.SaveChangesAsync();
        }

        public IQueryable<T> QueryAllAsync()
        {
            return _db.Set<T>().AsNoTracking().Where(m=>!m.IsRemove);
        }

        public IQueryable<T> QueryAllAsync(Expression<Func<T, bool>> lambdaFunc)
        {
            return  _db.Set<T>().Where(lambdaFunc);
        }

        public async Task<T> QueryAsync(Expression<Func<T, bool>> lambdaFunc)
        {
            return await _db.Set<T>().Where(lambdaFunc).FirstOrDefaultAsync();
        }

        public async Task<T> QueryAsync(Guid id)
        {
            return await _db.Set<T>().Where(m=>m.Id==id).FirstOrDefaultAsync();
        }

        public async Task<bool> IsExistsAsync(Expression<Func<T, bool>> lambdaFunc)
        {
            return await _db.Set<T>().AnyAsync(lambdaFunc);
        }

        public async Task<bool> IsExistsAsync(Guid id)
        {
            return await _db.Set<T>().AnyAsync(m => m.Id == id);
        }

        public async Task<int> GetCountsAsync(Expression<Func<T, bool>> lambdaFunc)
        {
            return await _db.Set<T>().Where(lambdaFunc).CountAsync();
        }

        public IQueryable<T> QueryByPage(int pageSize, int pageIndex, Expression<Func<T, bool>> lambdaFunc)
        {
            return _db.Set<T>().Where(lambdaFunc).Skip(pageIndex * pageSize).Take(pageSize);
        }
    }
}