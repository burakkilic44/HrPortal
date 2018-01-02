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
                
                 var M2 = new Location() { Name = "İstanbul (Avrupa)", CreateDate = DateTime.Now, UpdateDate = DateTime.Now, CreatedBy = "bilisimkariyernet@gmail.com", UpdatedBy = "bilisimkariyernet@gmail.com" };
                context.Add(M2);
                var M3 = new Location() { Name = "İstanbul (Asya)", CreateDate = DateTime.Now, UpdateDate = DateTime.Now, CreatedBy = "bilisimkariyernet@gmail.com", UpdatedBy = "bilisimkariyernet@gmail.com" };
                context.Add(M3);
                var M4 = new Location() { Name = "Adana", CreateDate = DateTime.Now, UpdateDate = DateTime.Now, CreatedBy = "bilisimkariyernet@gmail.com", UpdatedBy = "bilisimkariyernet@gmail.com", };
                context.Add(M4);
                var M5 = new Location() { Name = "Adıyaman", CreateDate = DateTime.Now, UpdateDate = DateTime.Now, CreatedBy = "bilisimkariyernet@gmail.com", UpdatedBy = "bilisimkariyernet@gmail.com" };
                context.Add(M5);
                var M6 = new Location() { Name = "Afyon", CreateDate = DateTime.Now, UpdateDate = DateTime.Now, CreatedBy = "bilisimkariyernet@gmail.com", UpdatedBy = "bilisimkariyernet@gmail.com" };
                context.Add(M6);
                var M7 = new Location() { Name = "Ağrı", CreateDate = DateTime.Now, UpdateDate = DateTime.Now, CreatedBy = "bilisimkariyernet@gmail.com", UpdatedBy = "bilisimkariyernet@gmail.com", };
                context.Add(M7);
                var M8 = new Location() { Name = "Amasya", CreateDate = DateTime.Now, UpdateDate = DateTime.Now, CreatedBy = "bilisimkariyernet@gmail.com", UpdatedBy = "bilisimkariyernet@gmail.com" };
                context.Add(M8);
                var M9 = new Location() { Name = "Ankara", CreateDate = DateTime.Now, UpdateDate = DateTime.Now, CreatedBy = "bilisimkariyernet@gmail.com", UpdatedBy = "bilisimkariyernet@gmail.com" };
                context.Add(M9);
                var M10 = new Location() { Name = "Antalya", CreateDate = DateTime.Now, UpdateDate = DateTime.Now, CreatedBy = "bilisimkariyernet@gmail.com", UpdatedBy = "bilisimkariyernet@gmail.com", };
                context.Add(M10);
                var M11 = new Location() { Name = "Artvin", CreateDate = DateTime.Now, UpdateDate = DateTime.Now, CreatedBy = "bilisimkariyernet@gmail.com", UpdatedBy = "bilisimkariyernet@gmail.com" };
                context.Add(M11);
                var M12 = new Location() { Name = "Aydın", CreateDate = DateTime.Now, UpdateDate = DateTime.Now, CreatedBy = "bilisimkariyernet@gmail.com", UpdatedBy = "bilisimkariyernet@gmail.com" };
                context.Add(M12);
                var M13 = new Location() { Name = "Balıkesir", CreateDate = DateTime.Now, UpdateDate = DateTime.Now, CreatedBy = "bilisimkariyernet@gmail.com", UpdatedBy = "bilisimkariyernet@gmail.com", };
                context.Add(M13);
                var M14 = new Location() { Name = "Bilecik", CreateDate = DateTime.Now, UpdateDate = DateTime.Now, CreatedBy = "bilisimkariyernet@gmail.com", UpdatedBy = "bilisimkariyernet@gmail.com" };
                context.Add(M14);
                var M15 = new Location() { Name = "Bingöl", CreateDate = DateTime.Now, UpdateDate = DateTime.Now, CreatedBy = "bilisimkariyernet@gmail.com", UpdatedBy = "bilisimkariyernet@gmail.com" };
                context.Add(M15);
                var M16 = new Location() { Name = "Bitlis", CreateDate = DateTime.Now, UpdateDate = DateTime.Now, CreatedBy = "bilisimkariyernet@gmail.com", UpdatedBy = "bilisimkariyernet@gmail.com", };
                context.Add(M6);
                var M17 = new Location() { Name = "Bolu", CreateDate = DateTime.Now, UpdateDate = DateTime.Now, CreatedBy = "bilisimkariyernet@gmail.com", UpdatedBy = "bilisimkariyernet@gmail.com" };
                context.Add(M17);
                var M18 = new Location() { Name = "Burdur", CreateDate = DateTime.Now, UpdateDate = DateTime.Now, CreatedBy = "bilisimkariyernet@gmail.com", UpdatedBy = "bilisimkariyernet@gmail.com" };
                context.Add(M18);
                var M19 = new Location() { Name = "Bursa", CreateDate = DateTime.Now, UpdateDate = DateTime.Now, CreatedBy = "bilisimkariyernet@gmail.com", UpdatedBy = "bilisimkariyernet@gmail.com", };
                context.Add(M19);
                var M20 = new Location() { Name = "Çanakkale", CreateDate = DateTime.Now, UpdateDate = DateTime.Now, CreatedBy = "bilisimkariyernet@gmail.com", UpdatedBy = "bilisimkariyernet@gmail.com" };
                context.Add(M20);
                var M21 = new Location() { Name = "Çankırı", CreateDate = DateTime.Now, UpdateDate = DateTime.Now, CreatedBy = "bilisimkariyernet@gmail.com", UpdatedBy = "bilisimkariyernet@gmail.com" };
                context.Add(M21);
                var M22 = new Location() { Name = "Çorum", CreateDate = DateTime.Now, UpdateDate = DateTime.Now, CreatedBy = "bilisimkariyernet@gmail.com", UpdatedBy = "bilisimkariyernet@gmail.com", };
                context.Add(M22);
                var M23 = new Location() { Name = "Denizli", CreateDate = DateTime.Now, UpdateDate = DateTime.Now, CreatedBy = "bilisimkariyernet@gmail.com", UpdatedBy = "bilisimkariyernet@gmail.com" };
                context.Add(M23);
                var M24 = new Location() { Name = "Diyarbakır", CreateDate = DateTime.Now, UpdateDate = DateTime.Now, CreatedBy = "bilisimkariyernet@gmail.com", UpdatedBy = "bilisimkariyernet@gmail.com" };
                context.Add(M24);
                var M25 = new Location() { Name = "Edirne", CreateDate = DateTime.Now, UpdateDate = DateTime.Now, CreatedBy = "bilisimkariyernet@gmail.com", UpdatedBy = "bilisimkariyernet@gmail.com" };
                context.Add(M25);
                var M26 = new Location() { Name = "Elazığ", CreateDate = DateTime.Now, UpdateDate = DateTime.Now, CreatedBy = "bilisimkariyernet@gmail.com", UpdatedBy = "bilisimkariyernet@gmail.com", };
                context.Add(M26);
                var M27 = new Location() { Name = "Erzincan", CreateDate = DateTime.Now, UpdateDate = DateTime.Now, CreatedBy = "bilisimkariyernet@gmail.com", UpdatedBy = "bilisimkariyernet@gmail.com" };
                context.Add(M27);
                var M28 = new Location() { Name = "Erzurum", CreateDate = DateTime.Now, UpdateDate = DateTime.Now, CreatedBy = "bilisimkariyernet@gmail.com", UpdatedBy = "bilisimkariyernet@gmail.com" };
                context.Add(M28);
                var M29 = new Location() { Name = "Eskişehir", CreateDate = DateTime.Now, UpdateDate = DateTime.Now, CreatedBy = "bilisimkariyernet@gmail.com", UpdatedBy = "bilisimkariyernet@gmail.com", };
                context.Add(M29);
                var M30 = new Location() { Name = "Gaziantep", CreateDate = DateTime.Now, UpdateDate = DateTime.Now, CreatedBy = "bilisimkariyernet@gmail.com", UpdatedBy = "bilisimkariyernet@gmail.com" };
                context.Add(M30);
                var M31 = new Location() { Name = "Giresun", CreateDate = DateTime.Now, UpdateDate = DateTime.Now, CreatedBy = "bilisimkariyernet@gmail.com", UpdatedBy = "bilisimkariyernet@gmail.com" };
                context.Add(M31);
                var M32 = new Location() { Name = "Gümüşhane", CreateDate = DateTime.Now, UpdateDate = DateTime.Now, CreatedBy = "bilisimkariyernet@gmail.com", UpdatedBy = "bilisimkariyernet@gmail.com" };
                context.Add(M32);
                var M33 = new Location() { Name = "Hakkari", CreateDate = DateTime.Now, UpdateDate = DateTime.Now, CreatedBy = "bilisimkariyernet@gmail.com", UpdatedBy = "bilisimkariyernet@gmail.com", };
                context.Add(M33);
                var M34 = new Location() { Name = "Hatay", CreateDate = DateTime.Now, UpdateDate = DateTime.Now, CreatedBy = "bilisimkariyernet@gmail.com", UpdatedBy = "bilisimkariyernet@gmail.com" };
                context.Add(M34);
                var M35 = new Location() { Name = "Isparta", CreateDate = DateTime.Now, UpdateDate = DateTime.Now, CreatedBy = "bilisimkariyernet@gmail.com", UpdatedBy = "bilisimkariyernet@gmail.com" };
                context.Add(M35);
                var M36 = new Location() { Name = "İçel", CreateDate = DateTime.Now, UpdateDate = DateTime.Now, CreatedBy = "bilisimkariyernet@gmail.com", UpdatedBy = "bilisimkariyernet@gmail.com", };
                context.Add(M36);
                var M37 = new Location() { Name = "İzmir", CreateDate = DateTime.Now, UpdateDate = DateTime.Now, CreatedBy = "bilisimkariyernet@gmail.com", UpdatedBy = "bilisimkariyernet@gmail.com" };
                context.Add(M37);
                var M38 = new Location() { Name = "Kars", CreateDate = DateTime.Now, UpdateDate = DateTime.Now, CreatedBy = "bilisimkariyernet@gmail.com", UpdatedBy = "bilisimkariyernet@gmail.com" };
                context.Add(M38);
                var M39 = new Location() { Name = "Kastamonu", CreateDate = DateTime.Now, UpdateDate = DateTime.Now, CreatedBy = "bilisimkariyernet@gmail.com", UpdatedBy = "bilisimkariyernet@gmail.com" };
                context.Add(M39);
                var M40 = new Location() { Name = "Kayseri", CreateDate = DateTime.Now, UpdateDate = DateTime.Now, CreatedBy = "bilisimkariyernet@gmail.com", UpdatedBy = "bilisimkariyernet@gmail.com", };
                context.Add(M40);
                var M41 = new Location() { Name = "Kırklareli", CreateDate = DateTime.Now, UpdateDate = DateTime.Now, CreatedBy = "bilisimkariyernet@gmail.com", UpdatedBy = "bilisimkariyernet@gmail.com" };
                context.Add(M41);
                var M42 = new Location() { Name = "Kırşehir", CreateDate = DateTime.Now, UpdateDate = DateTime.Now, CreatedBy = "bilisimkariyernet@gmail.com", UpdatedBy = "bilisimkariyernet@gmail.com" };
                context.Add(M42);
                var M43 = new Location() { Name = "Kocaeli", CreateDate = DateTime.Now, UpdateDate = DateTime.Now, CreatedBy = "bilisimkariyernet@gmail.com", UpdatedBy = "bilisimkariyernet@gmail.com", };
                context.Add(M43);
                var M44 = new Location() { Name = "Konya", CreateDate = DateTime.Now, UpdateDate = DateTime.Now, CreatedBy = "bilisimkariyernet@gmail.com", UpdatedBy = "bilisimkariyernet@gmail.com" };
                context.Add(M44);
                var M45 = new Location() { Name = "Kütahya", CreateDate = DateTime.Now, UpdateDate = DateTime.Now, CreatedBy = "bilisimkariyernet@gmail.com", UpdatedBy = "bilisimkariyernet@gmail.com" };
                context.Add(M45);
                var M46 = new Location() { Name = "Malatya", CreateDate = DateTime.Now, UpdateDate = DateTime.Now, CreatedBy = "bilisimkariyernet@gmail.com", UpdatedBy = "bilisimkariyernet@gmail.com" };
                context.Add(M46);
                var M47 = new Location() { Name = "Manisa", CreateDate = DateTime.Now, UpdateDate = DateTime.Now, CreatedBy = "bilisimkariyernet@gmail.com", UpdatedBy = "bilisimkariyernet@gmail.com", };
                context.Add(M47);
                var M48 = new Location() { Name = "Kahramanmaraş", CreateDate = DateTime.Now, UpdateDate = DateTime.Now, CreatedBy = "bilisimkariyernet@gmail.com", UpdatedBy = "bilisimkariyernet@gmail.com" };
                context.Add(M48);
                var M49 = new Location() { Name = "Mardin", CreateDate = DateTime.Now, UpdateDate = DateTime.Now, CreatedBy = "bilisimkariyernet@gmail.com", UpdatedBy = "bilisimkariyernet@gmail.com" };
                context.Add(M49);
                var M50 = new Location() { Name = "Muğla", CreateDate = DateTime.Now, UpdateDate = DateTime.Now, CreatedBy = "bilisimkariyernet@gmail.com", UpdatedBy = "bilisimkariyernet@gmail.com", };
                context.Add(M50);
                var M51 = new Location() { Name = "Muş", CreateDate = DateTime.Now, UpdateDate = DateTime.Now, CreatedBy = "bilisimkariyernet@gmail.com", UpdatedBy = "bilisimkariyernet@gmail.com" };
                context.Add(M51);
                var M52 = new Location() { Name = "Nevşehir", CreateDate = DateTime.Now, UpdateDate = DateTime.Now, CreatedBy = "bilisimkariyernet@gmail.com", UpdatedBy = "bilisimkariyernet@gmail.com" };
                context.Add(M52);
                var M53 = new Location() { Name = "Niğde", CreateDate = DateTime.Now, UpdateDate = DateTime.Now, CreatedBy = "bilisimkariyernet@gmail.com", UpdatedBy = "bilisimkariyernet@gmail.com", };
                context.Add(M53);
                var M54 = new Location() { Name = "Ordu", CreateDate = DateTime.Now, UpdateDate = DateTime.Now, CreatedBy = "bilisimkariyernet@gmail.com", UpdatedBy = "bilisimkariyernet@gmail.com" };
                context.Add(M54);
                var M55 = new Location() { Name = "Rize", CreateDate = DateTime.Now, UpdateDate = DateTime.Now, CreatedBy = "bilisimkariyernet@gmail.com", UpdatedBy = "bilisimkariyernet@gmail.com" };
                context.Add(M55);
                var M56 = new Location() { Name = "Sakarya", CreateDate = DateTime.Now, UpdateDate = DateTime.Now, CreatedBy = "bilisimkariyernet@gmail.com", UpdatedBy = "bilisimkariyernet@gmail.com", };
                context.Add(M56);
                var M57 = new Location() { Name = "Siirt", CreateDate = DateTime.Now, UpdateDate = DateTime.Now, CreatedBy = "bilisimkariyernet@gmail.com", UpdatedBy = "bilisimkariyernet@gmail.com" };
                context.Add(M57);
                var M58 = new Location() { Name = "Sinop", CreateDate = DateTime.Now, UpdateDate = DateTime.Now, CreatedBy = "bilisimkariyernet@gmail.com", UpdatedBy = "bilisimkariyernet@gmail.com" };
                context.Add(M58);
                var M59 = new Location() { Name = "Sivas", CreateDate = DateTime.Now, UpdateDate = DateTime.Now, CreatedBy = "bilisimkariyernet@gmail.com", UpdatedBy = "bilisimkariyernet@gmail.com", };
                context.Add(M59);
                var M60 = new Location() { Name = "Tekirdağ", CreateDate = DateTime.Now, UpdateDate = DateTime.Now, CreatedBy = "bilisimkariyernet@gmail.com", UpdatedBy = "bilisimkariyernet@gmail.com" };
                context.Add(M60);
                var M61 = new Location() { Name = "Tokat", CreateDate = DateTime.Now, UpdateDate = DateTime.Now, CreatedBy = "bilisimkariyernet@gmail.com", UpdatedBy = "bilisimkariyernet@gmail.com" };
                context.Add(M61);
                var M62 = new Location() { Name = "Trabzon", CreateDate = DateTime.Now, UpdateDate = DateTime.Now, CreatedBy = "bilisimkariyernet@gmail.com", UpdatedBy = "bilisimkariyernet@gmail.com", };
                context.Add(M62);
                var M63 = new Location() { Name = "Tunceli", CreateDate = DateTime.Now, UpdateDate = DateTime.Now, CreatedBy = "bilisimkariyernet@gmail.com", UpdatedBy = "bilisimkariyernet@gmail.com" };
                context.Add(M63);
                var M64 = new Location() { Name = "Şanlıurfa", CreateDate = DateTime.Now, UpdateDate = DateTime.Now, CreatedBy = "bilisimkariyernet@gmail.com", UpdatedBy = "bilisimkariyernet@gmail.com" };
                context.Add(M64);
                var M65 = new Location() { Name = "Uşak", CreateDate = DateTime.Now, UpdateDate = DateTime.Now, CreatedBy = "bilisimkariyernet@gmail.com", UpdatedBy = "bilisimkariyernet@gmail.com", };
                context.Add(M65);
                var M66 = new Location() { Name = "Van", CreateDate = DateTime.Now, UpdateDate = DateTime.Now, CreatedBy = "bilisimkariyernet@gmail.com", UpdatedBy = "bilisimkariyernet@gmail.com" };
                context.Add(M66);
                var M67 = new Location() { Name = "Yozgat", CreateDate = DateTime.Now, UpdateDate = DateTime.Now, CreatedBy = "bilisimkariyernet@gmail.com", UpdatedBy = "bilisimkariyernet@gmail.com" };
                context.Add(M67);
                var M68 = new Location() { Name = "Zonguldak", CreateDate = DateTime.Now, UpdateDate = DateTime.Now, CreatedBy = "bilisimkariyernet@gmail.com", UpdatedBy = "bilisimkariyernet@gmail.com", };
                context.Add(M68);
                var M69 = new Location() { Name = "Aksaray", CreateDate = DateTime.Now, UpdateDate = DateTime.Now, CreatedBy = "bilisimkariyernet@gmail.com", UpdatedBy = "bilisimkariyernet@gmail.com" };
                context.Add(M69);
                var M70 = new Location() { Name = "Bayburt", CreateDate = DateTime.Now, UpdateDate = DateTime.Now, CreatedBy = "bilisimkariyernet@gmail.com", UpdatedBy = "bilisimkariyernet@gmail.com" };
                context.Add(M70);
                var M71 = new Location() { Name = "Karaman", CreateDate = DateTime.Now, UpdateDate = DateTime.Now, CreatedBy = "bilisimkariyernet@gmail.com", UpdatedBy = "bilisimkariyernet@gmail.com" };
                context.Add(M71);
                var M72 = new Location() { Name = "Kırıkkale", CreateDate = DateTime.Now, UpdateDate = DateTime.Now, CreatedBy = "bilisimkariyernet@gmail.com", UpdatedBy = "bilisimkariyernet@gmail.com" };
                context.Add(M72);
                var M73 = new Location() { Name = "Batman", CreateDate = DateTime.Now, UpdateDate = DateTime.Now, CreatedBy = "bilisimkariyernet@gmail.com", UpdatedBy = "bilisimkariyernet@gmail.com" };
                context.Add(M73);
                var M74 = new Location() { Name = "Şırnak", CreateDate = DateTime.Now, UpdateDate = DateTime.Now, CreatedBy = "bilisimkariyernet@gmail.com", UpdatedBy = "bilisimkariyernet@gmail.com" };
                context.Add(M74);
                var M75 = new Location() { Name = "Bartın", CreateDate = DateTime.Now, UpdateDate = DateTime.Now, CreatedBy = "bilisimkariyernet@gmail.com", UpdatedBy = "bilisimkariyernet@gmail.com" };
                context.Add(M75);
                var M76 = new Location() { Name = "Ardahan", CreateDate = DateTime.Now, UpdateDate = DateTime.Now, CreatedBy = "bilisimkariyernet@gmail.com", UpdatedBy = "bilisimkariyernet@gmail.com" };
                context.Add(M76);
                var M77 = new Location() { Name = "Iğdır", CreateDate = DateTime.Now, UpdateDate = DateTime.Now, CreatedBy = "bilisimkariyernet@gmail.com", UpdatedBy = "bilisimkariyernet@gmail.com" };
                context.Add(M77);
                var M78 = new Location() { Name = "Yalova", CreateDate = DateTime.Now, UpdateDate = DateTime.Now, CreatedBy = "bilisimkariyernet@gmail.com", UpdatedBy = "bilisimkariyernet@gmail.com" };
                context.Add(M78);
                var M79 = new Location() { Name = "Karabük", CreateDate = DateTime.Now, UpdateDate = DateTime.Now, CreatedBy = "bilisimkariyernet@gmail.com", UpdatedBy = "bilisimkariyernet@gmail.com" };
                context.Add(M79);
                var M80 = new Location() { Name = "Kilis", CreateDate = DateTime.Now, UpdateDate = DateTime.Now, CreatedBy = "bilisimkariyernet@gmail.com", UpdatedBy = "bilisimkariyernet@gmail.com" };
                context.Add(M80);
                var M81 = new Location() { Name = "Osmaniye", CreateDate = DateTime.Now, UpdateDate = DateTime.Now, CreatedBy = "bilisimkariyernet@gmail.com", UpdatedBy = "bilisimkariyernet@gmail.com" };
                context.Add(M81);
                var M82 = new Location() { Name = "Düzce", CreateDate = DateTime.Now, UpdateDate = DateTime.Now, CreatedBy = "bilisimkariyernet@gmail.com", UpdatedBy = "bilisimkariyernet@gmail.com" };
                context.Add(M82);




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