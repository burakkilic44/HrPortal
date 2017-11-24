using HrPortal.Data;
using HrPortal.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HrPortal.Services
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private ApplicationDbContext context;
        private IRepository<Job> jobRepository;
        private IRepository<JobApplication> jobApplicationRepository;
        private IHttpContextAccessor contextAccessor;
        public UnitOfWork(ApplicationDbContext context, IHttpContextAccessor contextAccessor)
        {
            this.context = context;
            this.contextAccessor = contextAccessor;
        }
        public IRepository<Job> JobRepository
        {
            get
            {
                return this.jobRepository ?? new Repository<Job>(context, contextAccessor);
            }
        }

        public IRepository<JobApplication> JobApplicationRepository
        {
            get
            {
                return this.jobApplicationRepository ?? new Repository<JobApplication>(context, contextAccessor);
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }


    public interface IUnitOfWork
    {
        IRepository<Job> JobRepository { get; }
        IRepository<JobApplication> JobApplicationRepository { get; }
        void Dispose();
        void Save();
    }
}
