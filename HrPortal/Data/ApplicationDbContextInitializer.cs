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
            CreateLocations();
            CreateSectors();
            CreateOccupations();
        }
        private void CreateRoles()
        {
            string[] roles = { "Admin", "Employer", "Candidate" };
            string[] stamp = { "Admin", "Employer", "Candidate" };

            for (int i = 0; i < roles.Count(); i++)
            {
                var role = new IdentityRole { Id = Guid.NewGuid().ToString(), Name = roles[i], NormalizedName = roles[i], ConcurrencyStamp = stamp[i] };
                var task1 = Task.Run(() => roleManager.CreateAsync(role));
                task1.Wait();
            }
        }
        private void CreateDefaultUsers()
        {
            var user = new ApplicationUser { Id = Guid.NewGuid().ToString(), UserName = "bilisimkariyernet@gmail.com", Email = "bilisimkariyernet@gmail.com", EmailConfirmed = true, NormalizedEmail = "BILISIMKARIYERNET@GMAIL.COM", NormalizedUserName = "BILISIMKARIYERNET@GMAIL.COM", IsEmployer = true};
            var task1 = Task.Run(() => userManager.CreateAsync(user, "Hr123+"));
            task1.Wait();
            var task2 = Task.Run(() => userManager.AddToRoleAsync(user, "Employer"));
            task2.Wait();
            var user2 = new ApplicationUser { Id = Guid.NewGuid().ToString(), UserName = "cvhavuzu@bilisimkariyer.net", Email = "cvhavuzu@bilisimkariyer.net", EmailConfirmed = true, NormalizedEmail = "CVHAVUZU@BILISIMKARIYER.NET", NormalizedUserName = "CVHAVUZU@BILISIMKARIYER.NET"};
            var task3 = Task.Run(() => userManager.CreateAsync(user2, "Hr123+"));
            task3.Wait();
            var task4 = Task.Run(() => userManager.AddToRoleAsync(user2, "Admin"));
            task4.Wait();
            var user3 = new ApplicationUser { Id = Guid.NewGuid().ToString(), UserName = "muslumkiliceee@gmail.com", Email = "muslumkiliceee@gmail.com", EmailConfirmed = true, NormalizedEmail = "MUSLUMKILICEEE@GMAIL.COM", NormalizedUserName = "MUSLUMKILICEEE@GMAIL.COM" };
            var task5 = Task.Run(() => userManager.CreateAsync(user3, "Hr123+"));
            task5.Wait();
            var task6 = Task.Run(() => userManager.AddToRoleAsync(user3, "Candidate"));
            task6.Wait();



        }

        private void CreateSettings()
        {
            if (!context.Settings.Any())
            {
                var setting = new Setting() { FooterText = "Alt yazı", Address="Adres", Email="cvhavuzu@bilisimkariyer.net", HowItWorks="Nasıl Çalışır?", Facebook="facebook", About = "Hakkımızda", CreateDate=DateTime.Now, CreatedBy="username", UpdateDate=DateTime.Now, CustomHtml="<!-- Author: Bilişim Eğitim Merkezi -->", MapLat="1",MapLng="1", Help="Yardım metni", MetaDescription="Bilişim CV Havuzu", MetaTitle = "Bilişim Kariyer İK", Phone="0542", UpdatedBy="username", PrivacyPolicy="Gizlilik", MembershipAgreement="Üyelik Sözleşmesi Metni"};
                context.Add(setting);
                context.SaveChanges();
            }
        }
        private void CreateLanguages()
        {
            if (!context.Languages.Any())
            {
                var l1 = new Language() { Name = "Türkçe", CreateDate = DateTime.Now, UpdateDate = DateTime.Now, CreatedBy = "bilisimkariyernet@gmail.com", UpdatedBy = "bilisimkariyernet@gmail.com" };
                context.Add(l1);

                var l2 = new Language() { Name = "İngilizce",CreateDate = DateTime.Now, UpdateDate = DateTime.Now, CreatedBy = "bilisimkariyernet@gmail.com", UpdatedBy = "bilisimkariyernet@gmail.com" };
                context.Add(l2);
                var l3 = new Language() { Name = "Almanca", CreateDate = DateTime.Now, UpdateDate = DateTime.Now, CreatedBy = "bilisimkariyernet@gmail.com", UpdatedBy = "bilisimkariyernet@gmail.com", };
                context.Add(l3);
                context.SaveChanges();

            }
        }
        private void CreateLocations()
        {
            if (!context.Locations.Any())
            {
                var M1 = new Location() { Name="İstanbul", CreateDate = DateTime.Now, UpdateDate = DateTime.Now, CreatedBy = "bilisimkariyernet@gmail.com", UpdatedBy = "bilisimkariyernet@gmail.com", };
                context.Add(M1);
                 var M2 = new Location() { Name = "Ankara", CreateDate = DateTime.Now, UpdateDate = DateTime.Now, CreatedBy = "bilisimkariyernet@gmail.com", UpdatedBy = "bilisimkariyernet@gmail.com" };
                context.Add(M2);
                var M3 = new Location() { Name = "İzmir", CreateDate = DateTime.Now, UpdateDate = DateTime.Now, CreatedBy = "bilisimkariyernet@gmail.com", UpdatedBy = "bilisimkariyernet@gmail.com" };
                context.Add(M3);
                
              

                context.SaveChanges();

            }

       }

        private void CreateSectors()
        {
            if (!context.Sectors.Any())
            {
                var S1 = new Sector() { Name = "Bilişim", CreateDate=DateTime.Now, UpdateDate=DateTime.Now, CreatedBy="bilisimkariyernet@gmail.com", UpdatedBy= "bilisimkariyernet@gmail.com" };
                context.Add(S1);
                var S2 = new Sector() { Name = "Yazılım", CreateDate = DateTime.Now, UpdateDate = DateTime.Now, CreatedBy = "bilisimkariyernet@gmail.com", UpdatedBy = "bilisimkariyernet@gmail.com" };
                context.Add(S2);
                var S3 = new Sector() { Name = "Otomasyon", CreateDate = DateTime.Now, UpdateDate = DateTime.Now, CreatedBy = "bilisimkariyernet@gmail.com", UpdatedBy = "bilisimkariyernet@gmail.com"};
                context.Add(S3);

                context.SaveChanges();

            }

        }
        private void CreateOccupations()
        {
            if (!context.Occupations.Any())
            {
                var O1 = new Occupation() { Name = "***Elektrik Elektronik Mühendisi***", CreateDate=DateTime.Now, CreatedBy = "bilisimkariyernet@gmail.com", UpdateDate=DateTime.Now, UpdatedBy="bilisimkariyernet@gmail.com"};
                context.Add(O1);
                var O2 = new Occupation() { Name = "Bilgisayar Mühendisi (2 Yıllık)", CreateDate = DateTime.Now, CreatedBy = "bilisimkariyernet@gmail.com", UpdateDate = DateTime.Now, UpdatedBy = "bilisimkariyernet@gmail.com" };
                context.Add(O2);
                var O3 = new Occupation() { Name = "Bilgisayar Programcısı", CreateDate = DateTime.Now, CreatedBy = "bilisimkariyernet@gmail.com", UpdateDate = DateTime.Now, UpdatedBy = "bilisimkariyernet@gmail.com" };
                context.Add(O3);

                context.SaveChanges();

            }

        }

    }
}