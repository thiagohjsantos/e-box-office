﻿using EBoxOffice.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EBoxOffice.Domain.Interfaces
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetCategories();
        Task<Category> GetById(int? id);
        Task<Category> Create(Category category);
        Task<Category> Update(Category category);
        Task<Category> Remove(Category category);
    }
}
