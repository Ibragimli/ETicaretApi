﻿using ETicaretApi.Application.Repositories;
using ETicaretApi.Domain.Entities.Common;
using ETicaretApi.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ETicaretApi.Persistence.Repositories
{
    public class ReadRepository<T> : IReadRepository<T> where T : BaseEntity
    {
        private readonly DataContext _context;
        public ReadRepository(DataContext dbContext)
        {
            _context = dbContext;
        }
        public DbSet<T> Table => _context.Set<T>();

        public IQueryable<T> GetAll(bool tracking = true)
        {
            var query = Table.AsQueryable();
            if (!tracking)
                query = query.AsNoTracking();
            return query;
        }

        public async Task<bool> IsExistAsync(int id, bool tracking = true)
        {
            var query = Table.AsQueryable();
            if (!tracking)
                query = query.AsNoTracking();
            return await query.AnyAsync(data => data.Id == id);

        }
        public async Task<T> GetByIdAsync(int id, bool tracking = true)
        {
            var query = Table.AsQueryable();
            if (!tracking)
                query = query.AsNoTracking();
            return await query.FirstOrDefaultAsync(data => data.Id == id);
            //=> await Table.FirstOrDefaultAsync(data => data.Id == id);
            //=> await Table.FindAsync(id);
        }


        public async Task<T> GetSingleAsync(Expression<Func<T, bool>> method, bool tracking = true)
        {
            var query = Table.AsQueryable();
            if (!tracking)
                query = query.AsNoTracking();
            return await query.FirstOrDefaultAsync(method);
        }
        //=> await Table.FirstOrDefaultAsync(method);
        public IQueryable<T> GetWhere(Expression<Func<T, bool>> method, bool tracking = true)
        //=> Table.Where(method);
        {
            var query = Table.Where(method);
            if (!tracking)
                query = query.AsNoTracking();
            return query;
        }

    }
}
