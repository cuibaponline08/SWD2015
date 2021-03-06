﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace SWD2015.Infrastructure
{
    public interface IRepository<T> where T : class
    {
        void Add(T entity);

        void Update(T entity);

        void Delete(T entity);

        void Delete(Expression<Func<T, bool>> where);

        T GetById(int id);

        T Get(Expression<Func<T, bool>> where);

        IQueryable<T> GetAll();

        IQueryable<T> GetMany(Expression<Func<T, bool>> where);

        T GetDatabaseValues(T entity);
        void Save();
    }
}
