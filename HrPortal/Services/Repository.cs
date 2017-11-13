using HrPortal.Data;
using HrPortal.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace HrPortal.Services
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly ApplicationDbContext context;
        private DbSet<T> entities;
        string errorMessage = string.Empty;

        public Repository(ApplicationDbContext context)
        {
            this.context = context;
            entities = context.Set<T>();
        }
        public IEnumerable<T> GetAll(params string[] navigations)
        {
            var qEntities = entities.AsQueryable();
            foreach (string nav in navigations)
                qEntities = qEntities.Include(nav);
            return qEntities.ToList();
        }

        public IEnumerable<T> GetMany(Expression<Func<T, bool>> where, params string[] navigations)
        {
            var qEntities = entities.AsQueryable();
            foreach (string nav in navigations)
                qEntities = qEntities.Include(nav);
            return qEntities.Where(where).ToList();
        }
        public T Get(string id, params string[] navigations)
        {
            var qEntities = entities.AsQueryable();
            foreach (string nav in navigations)
                qEntities = qEntities.Include(nav);
            return qEntities.FirstOrDefault(s => s.Id == id);
        }
        public T Get(Expression<Func<T, bool>> where, params string[] navigations)
        {
            var qEntities = entities.AsQueryable();
            foreach (string nav in navigations)
                qEntities = qEntities.Include(nav);
            return qEntities.Where(where).FirstOrDefault();
        }
        public void Insert(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entity.CreateDate = DateTime.Now;
            entity.UpdateDate = DateTime.Now;
            entities.Add(entity);
            context.SaveChanges();
        }

        public void Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entity.UpdateDate = DateTime.Now;
            context.SaveChanges();
        }

        public void Delete(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Remove(entity);
            context.SaveChanges();
        }

        public int Count()
        {
            return entities.Count();
        }
    }
    public interface IRepository<T> where T : BaseEntity
    {
        IEnumerable<T> GetAll(params string[] navigations);
        IEnumerable<T> GetMany(Expression<Func<T, bool>> where, params string[] navigations);
        T Get(Expression<Func<T, bool>> where, params string[] navigations);
        T Get(string id, params string[] navigations);
        int Count();
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
