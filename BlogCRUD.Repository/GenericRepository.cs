﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BlogCRUD.Repository
{
    public class GenericRepository<T>:IGenericRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<T> _dbSet;

        public GenericRepository(ApplicationDbContext context)
        {
            _context= context;
            _dbSet = context.Set<T>();

        }
        public  IQueryable<T> GetAll()
        {
            return  _dbSet.AsQueryable().AsNoTracking();
        }

        public ValueTask<T?> GetByIdAsync(int id)
        {
           return  _dbSet.FindAsync(id);
        }

        public async ValueTask AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public void Update(T entity)
        {
            _dbSet.Update(entity);
        }

        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }

        public IQueryable<T> Where(Expression<Func<T, bool>> predicate)
        {
           return _dbSet.Where(predicate).AsNoTracking();
        }
    }
}
