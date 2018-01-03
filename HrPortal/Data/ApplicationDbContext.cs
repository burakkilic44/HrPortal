using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using HrPortal.Models;

namespace HrPortal.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Sector> Sectors{ get; set; }
        public DbSet<Certificate> Certificates { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<EducationInfo> EducationInfos { get; set; }
        public DbSet<Experience> Experiences { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<JobLocation> JobLocations { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<LanguageInfo> LanguageInfos { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Resume> Resumes { get; set; }
        public DbSet<Setting> Settings { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Occupation> Occupations { get; set; }
        public DbSet<JobApplication> JobApplications { get; set; }
        public DbSet<Audit> Audits { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
            builder.Entity<JobLocation>()
           .HasKey(t => new { t.JobId, t.LocationId });

            builder.Entity<JobLocation>()
                .HasOne(pt => pt.Job)
                .WithMany(p => p.JobLocations)
                .HasForeignKey(pt => pt.JobId);

            builder.Entity<JobLocation>()
                .HasOne(pt => pt.Location)
                .WithMany(t => t.JobLocations)
                .HasForeignKey(pt => pt.LocationId).OnDelete(DeleteBehavior.Restrict);


            builder.Entity<LanguageInfo>()
                .HasOne(pt => pt.Resume)
                .WithMany(p => p.LanguageInfos)
                .HasForeignKey(pt => pt.ResumeId);

            builder.Entity<LanguageInfo>()
                .HasOne(pt => pt.Language)
                .WithMany(t => t.LanguageInfos)
                .HasForeignKey(pt => pt.LanguageId).OnDelete(DeleteBehavior.Restrict);


            builder.Entity<JobApplication>()
                .HasOne(pt => pt.Job)
                .WithMany(p => p.JobApplications)
                .HasForeignKey(pt => pt.JobId).OnDelete(DeleteBehavior.Cascade);

            builder.Entity<JobApplication>()
                .HasOne(pt => pt.Resume)
                .WithMany(t => t.JobApplications)
                .HasForeignKey(pt => pt.ResumeId).OnDelete(DeleteBehavior.Cascade);

        }
        public DbSet<HrPortal.Models.ApplicationUser> ApplicationUser { get; set; }

    }
}
