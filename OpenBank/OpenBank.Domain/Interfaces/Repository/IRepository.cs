﻿using OpenBank.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using System.Linq.Expressions;
namespace OpenBank.Domain.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<T> InsertAsync(T obj);
        Task<T> UpdateAsync(T obj);
        Task<bool> RemoveAsync(Guid id);
        Task<bool> ExistAsync(Guid id);
        Task<T> SelectAsync(Guid id);
        Task<IEnumerable<T>> SelectAsync();
        Task<IEnumerable<T>> Find(Expression<Func<T, bool>> predicate, string includeProperties = null);
    }
}
