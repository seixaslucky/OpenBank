using Microsoft.EntityFrameworkCore;
using OpenBank.Domain.Entities;
using OpenBank.Domain.Interfaces;
using OpenBank.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OpenBank.Infra.Data.Repository
{
    public class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {
        protected readonly MyContext _context;
        private DbSet<T> _dataset;

        public BaseRepository(MyContext context)
        {
            _context = context;
            _dataset = _context.Set<T>();
        }

        public async Task<T> InsertAsync(T obj)
        {
            try
            {
                if (obj.Id == Guid.Empty)
                {
                    obj.Id = Guid.NewGuid();
                }
                obj.CreatedAt = DateTime.UtcNow;
                _dataset.Add(obj);
                await _context.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                throw ex;
            }

            return obj;
        }

        public async Task<bool> RemoveAsync(Guid id)
        {
            try
            {
                var result = await _dataset.SingleOrDefaultAsync(t => t.Id == id);
                if(result == null)
                {
                    return false;
                }
                _dataset.Remove(result);
                await _context.SaveChangesAsync();
                return true;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<T> SelectAsync(Guid id)
        {
            try
            {
                return await _dataset.SingleOrDefaultAsync(t => t.Id == id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<T>> SelectAsync()
        {
            try
            {
                return await _dataset.ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<T> UpdateAsync(T obj)
        {
            try
            {
                var result = await _dataset.SingleOrDefaultAsync(t => t.Id == obj.Id);
                if(result == null)
                {
                    return null;
                }
                obj.CreatedAt = result.CreatedAt;

                _context.Entry(result).CurrentValues.SetValues(obj);
                await _context.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj;
        }

        public async Task<bool> ExistAsync(Guid id)
        {
            return await _dataset.AnyAsync(t => t.Id == id);
        }
    }
}
