﻿using System.Linq.Expressions;

namespace BlogCRUD.Repository
{
    public interface IGenericRepository<T> where T : class
    {
        IQueryable<T> GetAll();

        IQueryable<T> Where(Expression<Func<T, bool>> predicate);
        ValueTask<T?> GetByIdAsync(int id);
        ValueTask AddAsync(T entity);


        void Update(T entity);
        void Delete(T entity);


    }
}
