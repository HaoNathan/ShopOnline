﻿using System;
using System.Linq;
using System.Threading.Tasks;
using ShopOnline.Dto;

namespace ShopOnline.IBll
{
    public interface IFirstCategoryManager
    {
        IQueryable<ProductCategoryDto> GetAllCategory();

        Task<int> EditCategory(ProductCategoryDto model);

        Task<int> AddCategory(string categoryName);

        Task< ProductCategoryDto> QueryCategory(Guid id);

        Task<int> EditCategory(Guid id,bool state);

    }
}