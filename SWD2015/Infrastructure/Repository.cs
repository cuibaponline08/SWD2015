using SWD2015.Infrastructure;
using SWD2015.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Linq.Expressions;
using System.Data.Entity.Infrastructure;

namespace SWD2015.Infrastructure
{
    public class Repository<T>:IRepository<T> where T : class
    {
        private DB_9DFD26_SWD2015Entities _dataContext;
        private IDbSet<T> _dbset;

        public Repository()
        {
            this._dataContext = new DB_9DFD26_SWD2015Entities();
            _dbset = _dataContext.Set<T>();
        }

        public Repository(DB_9DFD26_SWD2015Entities dataContext)
        {
            this._dataContext = dataContext;
            _dbset = _dataContext.Set<T>();
        }

        public void Add(T entity)
        {
            _dbset.Add(entity);
        }

        public void Update(T entity)
        {
            _dbset.Attach(entity);
            _dataContext.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(T entity)
        {
            _dbset.Remove(entity);
        }

        public T GetById(int id)
        {
            return _dbset.Find(id);
        }

        public IQueryable<T> GetAll()
        {
            return _dbset.AsQueryable();
        }


        public void Delete(Expression<Func<T, bool>> where)
        {
            IQueryable<T> objects = _dbset.Where<T>(where).AsQueryable();
            foreach (T obj in objects)
            {
                _dbset.Remove(obj);
            }
        }

        public T Get(Expression<Func<T, bool>> where)
        {
             return _dbset.Where(where).FirstOrDefault();
        }

        public IQueryable<T> GetMany(Expression<Func<T, bool>> where)
        {
            return _dbset.Where(where);
        }

        public void Save()
        {
            _dataContext.SaveChanges();
        }


        public T GetDatabaseValues(T entity)
        {
            var result = _dataContext.Entry(entity).GetDatabaseValues();
            return entity;
        }
    }
}