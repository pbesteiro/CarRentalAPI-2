using CarRentalCore.Interfaces;
using Microsoft.EntityFrameworkCore;
using RentalCarCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CarRentalInfrestructure
{
    public class BaseDataAcces<T>: IBaseDataAcces<T> where T : BaseEntity
    {
        private readonly RentalContext _context = null;
        protected DbSet<T> _entities;
        public BaseDataAcces(RentalContext context)
        {
            _context = context;
            _entities = _context.Set<T>();
        }


        public async Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>> filter = null,params string[] including)
        {
            var query = _entities.AsQueryable();

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (including != null)
                including.ToList().ForEach(include =>
                {
                    if (!string.IsNullOrEmpty(include))
                        query = query.Include(include);
                });
            return await query.ToListAsync();
        }

        public async Task<T> Get(int id, params string[] including)
        {
            var query = _entities.AsQueryable();
            if (including != null)
                including.ToList().ForEach(include =>
                {
                    if (!string.IsNullOrEmpty(include))
                        query = query.Include(include);
                });
            return await query.FirstOrDefaultAsync(e=> e.Id==id);
        }

        public void Update(T entity)
        {
            _entities.Update(entity);
        }

        public async Task<T> Add(T entity)
        {
            await _entities.AddAsync(entity);
           
            return entity;
        }

        public void Delete(T entity)
        {
            entity.Active = false;
            _entities.Update(entity);
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Save()
        {
            _context.SaveChanges();
        }

    }
}
