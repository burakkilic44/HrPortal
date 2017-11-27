using HrPortal.Data;
using HrPortal.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using ReflectionIT.Mvc.Paging;
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
        private readonly string userName;
        private DbSet<T> entities;
        string errorMessage = string.Empty;

        public Repository(ApplicationDbContext context, IHttpContextAccessor contextAccessor)
        {
            this.context = context;
            this.userName = contextAccessor.HttpContext.User.Identity.Name;
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
        
        public async Task<PagingList<T>> GetPaged(Expression<Func<T, bool>> where, Expression<Func<T, object>> orderby, bool desc, int pageSize, int pageNo, params string[] navigations)
        {
            var qEntities = entities.AsQueryable().AsNoTracking();
            foreach (string nav in navigations)
                qEntities = qEntities.Include(nav);
            if (desc == false) { 
                var qry = qEntities.Where(where).OrderBy(orderby);
                return await PagingList.CreateAsync<T>(qry, pageSize, pageNo);
            } else
            {
                var qry = qEntities.Where(where).OrderByDescending(orderby);
                return await PagingList.CreateAsync<T>(qry, pageSize, pageNo);
            }
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
            entity.CreatedBy = userName;
            entity.UpdateDate = DateTime.Now;
            entity.UpdatedBy = userName;
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
            entity.UpdatedBy = userName;
            // eğer mevcut kaydı oluşturan ile güncelleyen farklı burada izin vermeyebilirsin
            context.Update(entity);
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

        public void Delete(Expression<Func<T, bool>> where)
        {
            var qEntities = entities.AsQueryable().Where(where).ToList();
            var affectedRows = 0;
            foreach (T entity in qEntities)
            {
                entities.Remove(entity);
                affectedRows++;
            }
            if (affectedRows>0) { 
                context.SaveChanges();
            }
        }

        public bool Any(Expression<Func<T, bool>> where)
        {
            return entities.Any(where);
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
        Task<PagingList<T>> GetPaged(Expression<Func<T, bool>> where, Expression<Func<T, object>> orderby, bool desc, int pageSize, int pageNo, params string[] navigations);
        T Get(Expression<Func<T, bool>> where, params string[] navigations);
        T Get(string id, params string[] navigations);
        int Count();
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Delete(Expression<Func<T, bool>> where);
        bool Any(Expression<Func<T, bool>> where);
    }
}
