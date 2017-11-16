using HrPortal.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HrPortal.Data
{
    public class ApplicationDbContextInitializer
    {
        private ApplicationDbContext context;
        private RoleManager<IdentityRole> roleManager;
        private UserManager<ApplicationUser> userManager;
        public ApplicationDbContextInitializer(ApplicationDbContext context, RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager)
        {
            this.context = context;
            this.roleManager = roleManager;
            this.userManager = userManager;
        }

        public void Seed()
        {
            
            context.Database.Migrate();
           

            CreateRoles();
            CreateDefaultUsers();
            CreateSettings();
            CreateLanguages();
            //CreateLocations();
            //CreateSectors();
            //CreateOccupations();
        }
        private void CreateRoles()
        {
            string[] roles = { "Admin", "Employer", "Candidate"};
            string[] stamp = { "Admin", "Employer", "Candidate"};

            for (int i = 0; i < roles.Count(); i++)
            {
                var role = new IdentityRole { Id = Guid.NewGuid().ToString(), Name = roles[i], NormalizedName = roles[i], ConcurrencyStamp = stamp[i] };
                var task1 = Task.Run(() => roleManager.CreateAsync(role));
                task1.Wait();
            }
        }
        private void CreateDefaultUsers()
        {
            var user = new ApplicationUser { Id = Guid.NewGuid().ToString(), UserName = "bilisimkariyernet@gmail.com", Email = "bilisimkariyernet@gmail.com", EmailConfirmed = true, NormalizedEmail = "BILISIMKARIYERNET@GMAIL.COM", NormalizedUserName = "BILISIMKARIYERNET@GMAIL.COM" };
            var task1 = Task.Run(() => userManager.CreateAsync(user, "Hr123+"));
            task1.Wait();
            var task2 = Task.Run(() => userManager.AddToRoleAsync(user, "Admin"));
            task2.Wait();
        }

        private void CreateSettings()
        {
            if (!context.Settings.Any())
            {
                var setting = new Setting() { About = "Hakkımızda" };
                context.Add(setting);
                context.SaveChanges();
            }
        }
        private void CreateLanguages()
        {
            if (!context.Languages.Any())
            {
                var l1 = new Language() { Name = "Türkçe" };
                context.Add(l1);

                var l2 = new Language() { Name = "İngilizce" };
                context.Add(l2);

                context.SaveChanges();

            }
        }

    }
}
