using MultiTenantProject.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MultiTenantProject.Data
{
    public interface IRepository<T> where T : BaseEntity
    {
        IQueryable<T> Query();
        Task AddAsync(T entity);
        Task<T?> GetByIdAsync(int id);
        Task SaveChangesAsync();
    }
}
