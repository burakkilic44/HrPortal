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
            if (context.Database.EnsureCreated()) { 
                context.Database.Migrate();
            }

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
                var S1 = new Sector() { Name = "Adalet ve Güvenlik", CreateDate=DateTime.Now, UpdateDate=DateTime.Now, CreatedBy="bilisimkariyernet@gmail.com", UpdatedBy= "bilisimkariyernet@gmail.com" };
                context.Add(S1);
                var S2 = new Sector() { Name = "Ağaç İşleri, Kağıt ve Kağıt Ürünleri", CreateDate = DateTime.Now, UpdateDate = DateTime.Now, CreatedBy = "bilisimkariyernet@gmail.com", UpdatedBy = "bilisimkariyernet@gmail.com" };
                context.Add(S2);
                var S3 = new Sector() { Name = "Bilim Teknolojileri", CreateDate = DateTime.Now, UpdateDate = DateTime.Now, CreatedBy = "bilisimkariyernet@gmail.com", UpdatedBy = "bilisimkariyernet@gmail.com"};
                context.Add(S3);
                var S4 = new Sector() { Name = "Cam, Çimento ve Toprak", CreateDate = DateTime.Now, UpdateDate = DateTime.Now, CreatedBy = "bilisimkariyernet@gmail.com", UpdatedBy = "bilisimkariyernet@gmail.com" };
                context.Add(S4);
                var S5 = new Sector() { Name = "Çevre", CreateDate = DateTime.Now, UpdateDate = DateTime.Now, CreatedBy = "bilisimkariyernet@gmail.com", UpdatedBy = "bilisimkariyernet@gmail.com" };
                context.Add(S5);
                var S6 = new Sector() { Name = "Eğitim", CreateDate = DateTime.Now, UpdateDate = DateTime.Now, CreatedBy = "bilisimkariyernet@gmail.com", UpdatedBy = "bilisimkariyernet@gmail.com" };
                context.Add(S6);
                var S7 = new Sector() { Name = "Elektrik ve Elektronik", CreateDate = DateTime.Now, UpdateDate = DateTime.Now, CreatedBy = "bilisimkariyernet@gmail.com", UpdatedBy = "bilisimkariyernet@gmail.com" };
                context.Add(S7);
                var S8 = new Sector() { Name = "Enerji", CreateDate = DateTime.Now, UpdateDate = DateTime.Now, CreatedBy = "bilisimkariyernet@gmail.com", UpdatedBy = "bilisimkariyernet@gmail.com" };
                context.Add(S8);
                var S9 = new Sector() { Name = "Finans", CreateDate = DateTime.Now, UpdateDate = DateTime.Now, CreatedBy = "bilisimkariyernet@gmail.com", UpdatedBy = "bilisimkariyernet@gmail.com" };
                context.Add(S9);
                var S10 = new Sector() { Name = "Gıda", CreateDate = DateTime.Now, UpdateDate = DateTime.Now, CreatedBy = "bilisimkariyernet@gmail.com", UpdatedBy = "bilisimkariyernet@gmail.com" };
                context.Add(S10);
                var S11 = new Sector() { Name = "İnşaat", CreateDate = DateTime.Now, UpdateDate = DateTime.Now, CreatedBy = "bilisimkariyernet@gmail.com", UpdatedBy = "bilisimkariyernet@gmail.com" };
                context.Add(S11);
                var S12 = new Sector() { Name = "İş ve Yönetim", CreateDate = DateTime.Now, UpdateDate = DateTime.Now, CreatedBy = "bilisimkariyernet@gmail.com", UpdatedBy = "bilisimkariyernet@gmail.com" };
                context.Add(S12);
                var S13 = new Sector() { Name = "Kimya, Petrol, Lastik ve Plastik", CreateDate = DateTime.Now, UpdateDate = DateTime.Now, CreatedBy = "bilisimkariyernet@gmail.com", UpdatedBy = "bilisimkariyernet@gmail.com" };
                context.Add(S13);
                var S14 = new Sector() { Name = "Kültür, Sanat ve Tasarım", CreateDate = DateTime.Now, UpdateDate = DateTime.Now, CreatedBy = "bilisimkariyernet@gmail.com", UpdatedBy = "bilisimkariyernet@gmail.com" };
                context.Add(S14);
                var S15 = new Sector() { Name = "Maden", CreateDate = DateTime.Now, UpdateDate = DateTime.Now, CreatedBy = "bilisimkariyernet@gmail.com", UpdatedBy = "bilisimkariyernet@gmail.com" };
                context.Add(S15);
                var S16 = new Sector() { Name = "Medya, İletişim ve Yayıncılık", CreateDate = DateTime.Now, UpdateDate = DateTime.Now, CreatedBy = "bilisimkariyernet@gmail.com", UpdatedBy = "bilisimkariyernet@gmail.com" };
                context.Add(S16);
                var S17 = new Sector() { Name = "Metal", CreateDate = DateTime.Now, UpdateDate = DateTime.Now, CreatedBy = "bilisimkariyernet@gmail.com", UpdatedBy = "bilisimkariyernet@gmail.com" };
                context.Add(S17);
                var S18 = new Sector() { Name = "Otomotiv", CreateDate = DateTime.Now, UpdateDate = DateTime.Now, CreatedBy = "bilisimkariyernet@gmail.com", UpdatedBy = "bilisimkariyernet@gmail.com" };
                context.Add(S18);
                var S19 = new Sector() { Name = "Sağlık ve Sosyal Hizmetler", CreateDate = DateTime.Now, UpdateDate = DateTime.Now, CreatedBy = "bilisimkariyernet@gmail.com", UpdatedBy = "bilisimkariyernet@gmail.com" };
                context.Add(S19);
                var S20 = new Sector() { Name = "Spor ve Rekreasyon", CreateDate = DateTime.Now, UpdateDate = DateTime.Now, CreatedBy = "bilisimkariyernet@gmail.com", UpdatedBy = "bilisimkariyernet@gmail.com" };
                context.Add(S20);
                var S21 = new Sector() { Name = "Tarım, Avcılık ve Balıkçılık", CreateDate = DateTime.Now, UpdateDate = DateTime.Now, CreatedBy = "bilisimkariyernet@gmail.com", UpdatedBy = "bilisimkariyernet@gmail.com" };
                context.Add(S21);
                var S22 = new Sector() { Name = "Tekstil, Hazır Giyim, Deri", CreateDate = DateTime.Now, UpdateDate = DateTime.Now, CreatedBy = "bilisimkariyernet@gmail.com", UpdatedBy = "bilisimkariyernet@gmail.com" };
                context.Add(S22);
                var S23 = new Sector() { Name = "Ticaret(Satış ve Pazarlama)", CreateDate = DateTime.Now, UpdateDate = DateTime.Now, CreatedBy = "bilisimkariyernet@gmail.com", UpdatedBy = "bilisimkariyernet@gmail.com" };
                context.Add(S23);
                var S24 = new Sector() { Name = "Toplumsal ve Kişisel Hizmetler", CreateDate = DateTime.Now, UpdateDate = DateTime.Now, CreatedBy = "bilisimkariyernet@gmail.com", UpdatedBy = "bilisimkariyernet@gmail.com" };
                context.Add(S24);
                var S25 = new Sector() { Name = "Turizm, Konaklama, Yiyecek-İçecek Hizmetleri", CreateDate = DateTime.Now, UpdateDate = DateTime.Now, CreatedBy = "bilisimkariyernet@gmail.com", UpdatedBy = "bilisimkariyernet@gmail.com" };
                context.Add(S25);
                var S26 = new Sector() { Name = "Ulaştırma, Lojistik ve Haberleşme", CreateDate = DateTime.Now, UpdateDate = DateTime.Now, CreatedBy = "bilisimkariyernet@gmail.com", UpdatedBy = "bilisimkariyernet@gmail.com" };
                context.Add(S26);                

                context.SaveChanges();

            }

        }
        private void CreateOccupations()
        {
            if (!context.Occupations.Any())
            {
                var O1 = new Occupation() { Name = "Yönetici(Haberleşme)", CreateDate=DateTime.Now, CreatedBy = "bilisimkariyernet@gmail.com", UpdateDate=DateTime.Now, UpdatedBy="bilisimkariyernet@gmail.com"};
                context.Add(O1);
                var O2 = new Occupation() { Name = "Yönetici-Haberleşme Hizmetleri", CreateDate = DateTime.Now, CreatedBy = "bilisimkariyernet@gmail.com", UpdateDate = DateTime.Now, UpdatedBy = "bilisimkariyernet@gmail.com" };
                context.Add(O2);
                var O3 = new Occupation() { Name = "Yönetici(Bilgi İşlem)", CreateDate = DateTime.Now, CreatedBy = "bilisimkariyernet@gmail.com", UpdateDate = DateTime.Now, UpdatedBy = "bilisimkariyernet@gmail.com" };
                context.Add(O3);
                var O4 = new Occupation() { Name = "Sistem Analisti(Bt)", CreateDate = DateTime.Now, CreatedBy = "bilisimkariyernet@gmail.com", UpdateDate = DateTime.Now, UpdatedBy = "bilisimkariyernet@gmail.com" };
                context.Add(O4);
                var O5 = new Occupation() { Name = "Sistem Çözümleyici", CreateDate = DateTime.Now, CreatedBy = "bilisimkariyernet@gmail.com", UpdateDate = DateTime.Now, UpdatedBy = "bilisimkariyernet@gmail.com" };
                context.Add(O5);
                var O6 = new Occupation() { Name = "Sistem Tasarımcısı(Bt)", CreateDate = DateTime.Now, CreatedBy = "bilisimkariyernet@gmail.com", UpdateDate = DateTime.Now, UpdatedBy = "bilisimkariyernet@gmail.com" };
                context.Add(O6);
                var O7 = new Occupation() { Name = "BT Çözümleri Uzmanı", CreateDate = DateTime.Now, CreatedBy = "bilisimkariyernet@gmail.com", UpdateDate = DateTime.Now, UpdatedBy = "bilisimkariyernet@gmail.com" };
                context.Add(O7);
                var O8 = new Occupation() { Name = "Sistem Geliştirme Uzmanı(Banka)", CreateDate = DateTime.Now, CreatedBy = "bilisimkariyernet@gmail.com", UpdateDate = DateTime.Now, UpdatedBy = "bilisimkariyernet@gmail.com" };
                context.Add(O8);
                var O9 = new Occupation() { Name = "Yönetim Bilişim Sistemleri Uzmanı", CreateDate = DateTime.Now, CreatedBy = "bilisimkariyernet@gmail.com", UpdateDate = DateTime.Now, UpdatedBy = "bilisimkariyernet@gmail.com" };
                context.Add(O9);
                var a = new Occupation() { Name = "Bilişim Sistemleri Mühendisi", CreateDate = DateTime.Now, CreatedBy = "bilisimkariyernet@gmail.com", UpdateDate = DateTime.Now, UpdatedBy = "bilisimkariyernet@gmail.com" };
                context.Add(a);
                var b = new Occupation() { Name = "Sistem Uzmanı", CreateDate = DateTime.Now, CreatedBy = "bilisimkariyernet@gmail.com", UpdateDate = DateTime.Now, UpdatedBy = "bilisimkariyernet@gmail.com" };
                context.Add(b);
                var c= new Occupation() { Name = "Bt İş Analisti", CreateDate = DateTime.Now, CreatedBy = "bilisimkariyernet@gmail.com", UpdateDate = DateTime.Now, UpdatedBy = "bilisimkariyernet@gmail.com" };
                context.Add(c);
                var d = new Occupation() { Name = "Yazılım Mühendisi", CreateDate = DateTime.Now, CreatedBy = "bilisimkariyernet@gmail.com", UpdateDate = DateTime.Now, UpdatedBy = "bilisimkariyernet@gmail.com" };
                context.Add(d);
                var e = new Occupation() { Name = "Bilgisayar Mühendisi", CreateDate = DateTime.Now, CreatedBy = "bilisimkariyernet@gmail.com", UpdateDate = DateTime.Now, UpdatedBy = "bilisimkariyernet@gmail.com" };
                context.Add(e);
                var f = new Occupation() { Name = "Program Analisti", CreateDate = DateTime.Now, CreatedBy = "bilisimkariyernet@gmail.com", UpdateDate = DateTime.Now, UpdatedBy = "bilisimkariyernet@gmail.com" };
                context.Add(f);
                var g = new Occupation() { Name = "Yazılım Tasarımcısı", CreateDate = DateTime.Now, CreatedBy = "bilisimkariyernet@gmail.com", UpdateDate = DateTime.Now, UpdatedBy = "bilisimkariyernet@gmail.com" };
                context.Add(g);
                var h = new Occupation() { Name = "Yazılım Geliştiricisi", CreateDate = DateTime.Now, CreatedBy = "bilisimkariyernet@gmail.com", UpdateDate = DateTime.Now, UpdatedBy = "bilisimkariyernet@gmail.com" };
                context.Add(h);
                var i = new Occupation() { Name = "Web Tasarım Uzmanı(Bilgisayar)", CreateDate = DateTime.Now, CreatedBy = "bilisimkariyernet@gmail.com", UpdateDate = DateTime.Now, UpdatedBy = "bilisimkariyernet@gmail.com" };
                context.Add(i);
                var j = new Occupation() { Name = "Web Tasarımcısı", CreateDate = DateTime.Now, CreatedBy = "bilisimkariyernet@gmail.com", UpdateDate = DateTime.Now, UpdatedBy = "bilisimkariyernet@gmail.com" };
                context.Add(j);
                var k = new Occupation() { Name = "Animasyon Programcısı", CreateDate = DateTime.Now, CreatedBy = "bilisimkariyernet@gmail.com", UpdateDate = DateTime.Now, UpdatedBy = "bilisimkariyernet@gmail.com" };
                context.Add(k);
                var l = new Occupation() { Name = "Bilgisayar Oyunları Programcısı", CreateDate = DateTime.Now, CreatedBy = "bilisimkariyernet@gmail.com", UpdateDate = DateTime.Now, UpdatedBy = "bilisimkariyernet@gmail.com" };
                context.Add(l);
                var m = new Occupation() { Name = "İnternet Geliştiricisi", CreateDate = DateTime.Now, CreatedBy = "bilisimkariyernet@gmail.com", UpdateDate = DateTime.Now, UpdatedBy = "bilisimkariyernet@gmail.com" };
                context.Add(m);
                var n = new Occupation() { Name = "Çoklu Ortam Programcısı", CreateDate = DateTime.Now, CreatedBy = "bilisimkariyernet@gmail.com", UpdateDate = DateTime.Now, UpdatedBy = "bilisimkariyernet@gmail.com" };
                context.Add(n);
                var o = new Occupation() { Name = "Web Sitesi Geliştiricisi", CreateDate = DateTime.Now, CreatedBy = "bilisimkariyernet@gmail.com", UpdateDate = DateTime.Now, UpdatedBy = "bilisimkariyernet@gmail.com" };
                context.Add(o);
                var p = new Occupation() { Name = "Bilgisayar Programcısı", CreateDate = DateTime.Now, CreatedBy = "bilisimkariyernet@gmail.com", UpdateDate = DateTime.Now, UpdatedBy = "bilisimkariyernet@gmail.com" };
                context.Add(p);
                var r = new Occupation() { Name = "Sistem Programcısı", CreateDate = DateTime.Now, CreatedBy = "bilisimkariyernet@gmail.com", UpdateDate = DateTime.Now, UpdatedBy = "bilisimkariyernet@gmail.com" };
                context.Add(r);
                var s = new Occupation() { Name = "Uygulama Programcısı", CreateDate = DateTime.Now, CreatedBy = "bilisimkariyernet@gmail.com", UpdateDate = DateTime.Now, UpdatedBy = "bilisimkariyernet@gmail.com" };
                context.Add(s);
                var t = new Occupation() { Name = "Mikrodenetleyici Programcısı", CreateDate = DateTime.Now, CreatedBy = "bilisimkariyernet@gmail.com", UpdateDate = DateTime.Now, UpdatedBy = "bilisimkariyernet@gmail.com" };
                context.Add(t);
                var u = new Occupation() { Name = "Bilgi İşlem Destek Uzmanı", CreateDate = DateTime.Now, CreatedBy = "bilisimkariyernet@gmail.com", UpdateDate = DateTime.Now, UpdatedBy = "bilisimkariyernet@gmail.com" };
                context.Add(u);
                var v = new Occupation() { Name = "Mikroişlem Tasarımcısı", CreateDate = DateTime.Now, CreatedBy = "bilisimkariyernet@gmail.com", UpdateDate = DateTime.Now, UpdatedBy = "bilisimkariyernet@gmail.com" };
                context.Add(v);
                var y = new Occupation() { Name = "Sistem Değerlendirmecisi", CreateDate = DateTime.Now, CreatedBy = "bilisimkariyernet@gmail.com", UpdateDate = DateTime.Now, UpdatedBy = "bilisimkariyernet@gmail.com" };
                context.Add(y);
                var z = new Occupation() { Name = "Kalite Güvence Analisti(Bilgisayar)", CreateDate = DateTime.Now, CreatedBy = "bilisimkariyernet@gmail.com", UpdateDate = DateTime.Now, UpdatedBy = "bilisimkariyernet@gmail.com" };
                context.Add(z);
                var aa = new Occupation() { Name = "Yazılım Test Edicisi", CreateDate = DateTime.Now, CreatedBy = "bilisimkariyernet@gmail.com", UpdateDate = DateTime.Now, UpdatedBy = "bilisimkariyernet@gmail.com" };
                context.Add(aa);
                var bb = new Occupation() { Name = "Sistem Test Edicisi", CreateDate = DateTime.Now, CreatedBy = "bilisimkariyernet@gmail.com", UpdateDate = DateTime.Now, UpdatedBy = "bilisimkariyernet@gmail.com" };
                context.Add(bb);
                var cc = new Occupation() { Name = "Veri Tabanı Yöneticisi", CreateDate = DateTime.Now, CreatedBy = "bilisimkariyernet@gmail.com", UpdateDate = DateTime.Now, UpdatedBy = "bilisimkariyernet@gmail.com" };
                context.Add(cc);
                var dd = new Occupation() { Name = "Veri Tabanı Analisti", CreateDate = DateTime.Now, CreatedBy = "bilisimkariyernet@gmail.com", UpdateDate = DateTime.Now, UpdatedBy = "bilisimkariyernet@gmail.com" };
                context.Add(dd);
                var ee = new Occupation() { Name = "Veri Yöneticisi", CreateDate = DateTime.Now, CreatedBy = "bilisimkariyernet@gmail.com", UpdateDate = DateTime.Now, UpdatedBy = "bilisimkariyernet@gmail.com" };
                context.Add(ee);
                var ff = new Occupation() { Name = "Veri Tabanı Mimarı", CreateDate = DateTime.Now, CreatedBy = "bilisimkariyernet@gmail.com", UpdateDate = DateTime.Now, UpdatedBy = "bilisimkariyernet@gmail.com" };
                context.Add(ff);
                var gg = new Occupation() { Name = "Bilgisayar Ağı Yöneticisi", CreateDate = DateTime.Now, CreatedBy = "bilisimkariyernet@gmail.com", UpdateDate = DateTime.Now, UpdatedBy = "bilisimkariyernet@gmail.com" };
                context.Add(gg);
                var hh = new Occupation() { Name = "Bilgisayar Sistemleri Yöneticisi", CreateDate = DateTime.Now, CreatedBy = "bilisimkariyernet@gmail.com", UpdateDate = DateTime.Now, UpdatedBy = "bilisimkariyernet@gmail.com" };
                context.Add(hh);
                var ii = new Occupation() { Name = "Ağ Teknolojileri Uzmanı", CreateDate = DateTime.Now, CreatedBy = "bilisimkariyernet@gmail.com", UpdateDate = DateTime.Now, UpdatedBy = "bilisimkariyernet@gmail.com" };
                context.Add(ii);
                var jj = new Occupation() { Name = "İletişim Analisti(Bilgisayar)", CreateDate = DateTime.Now, CreatedBy = "bilisimkariyernet@gmail.com", UpdateDate = DateTime.Now, UpdatedBy = "bilisimkariyernet@gmail.com" };
                context.Add(jj);
                var kk = new Occupation() { Name = "Bilgisayar Ağı Analisti", CreateDate = DateTime.Now, CreatedBy = "bilisimkariyernet@gmail.com", UpdateDate = DateTime.Now, UpdatedBy = "bilisimkariyernet@gmail.com" };
                context.Add(kk);
                var ll = new Occupation() { Name = "Bilgi Güvenlik Denetmeni", CreateDate = DateTime.Now, CreatedBy = "bilisimkariyernet@gmail.com", UpdateDate = DateTime.Now, UpdatedBy = "bilisimkariyernet@gmail.com" };
                context.Add(ll);
                var mm = new Occupation() { Name = "Enformasyon Teknolojileri Uzmanı", CreateDate = DateTime.Now, CreatedBy = "bilisimkariyernet@gmail.com", UpdateDate = DateTime.Now, UpdatedBy = "bilisimkariyernet@gmail.com" };
                context.Add(mm);
                var nn = new Occupation() { Name = "Dijital Adli Tıp Uzmanı", CreateDate = DateTime.Now, CreatedBy = "bilisimkariyernet@gmail.com", UpdateDate = DateTime.Now, UpdatedBy = "bilisimkariyernet@gmail.com" };
                context.Add(nn);
                var oo = new Occupation() { Name = "Güvenlik Uzmanı(BİT)", CreateDate = DateTime.Now, CreatedBy = "bilisimkariyernet@gmail.com", UpdateDate = DateTime.Now, UpdatedBy = "bilisimkariyernet@gmail.com" };
                context.Add(oo);
                var pp = new Occupation() { Name = "Diğer Bilgisayar Makinesi Operatörleri", CreateDate = DateTime.Now, CreatedBy = "bilisimkariyernet@gmail.com", UpdateDate = DateTime.Now, UpdatedBy = "bilisimkariyernet@gmail.com" };
                context.Add(pp);
                var rr = new Occupation() { Name = "Elektronik Bilgisayar Operatörü", CreateDate = DateTime.Now, CreatedBy = "bilisimkariyernet@gmail.com", UpdateDate = DateTime.Now, UpdatedBy = "bilisimkariyernet@gmail.com" };
                context.Add(rr);
                var ss = new Occupation() { Name = "Bilişim Uzmanı", CreateDate = DateTime.Now, CreatedBy = "bilisimkariyernet@gmail.com", UpdateDate = DateTime.Now, UpdatedBy = "bilisimkariyernet@gmail.com" };
                context.Add(ss);
                var tt = new Occupation() { Name = "Bilgisayar Operatörlüğü Teknikeri", CreateDate = DateTime.Now, CreatedBy = "bilisimkariyernet@gmail.com", UpdateDate = DateTime.Now, UpdatedBy = "bilisimkariyernet@gmail.com" };
                context.Add(tt);
                var uu = new Occupation() { Name = "Bilgi İşlem Donanım Görevlisi(Banka)", CreateDate = DateTime.Now, CreatedBy = "bilisimkariyernet@gmail.com", UpdateDate = DateTime.Now, UpdatedBy = "bilisimkariyernet@gmail.com" };
                context.Add(uu);
                var vv = new Occupation() { Name = "Bilgisayar Operatörü", CreateDate = DateTime.Now, CreatedBy = "bilisimkariyernet@gmail.com", UpdateDate = DateTime.Now, UpdatedBy = "bilisimkariyernet@gmail.com" };
                context.Add(vv);
                var yy = new Occupation() { Name = "Bilgisayar Teknolojisi Teknikeri", CreateDate = DateTime.Now, CreatedBy = "bilisimkariyernet@gmail.com", UpdateDate = DateTime.Now, UpdatedBy = "bilisimkariyernet@gmail.com" };
                context.Add(yy);
                var zz = new Occupation() { Name = "Sistem İşletme Sorumlusu", CreateDate = DateTime.Now, CreatedBy = "bilisimkariyernet@gmail.com", UpdateDate = DateTime.Now, UpdatedBy = "bilisimkariyernet@gmail.com" };
                context.Add(zz);
                var aaa = new Occupation() { Name = "Sistem İşletmeni", CreateDate = DateTime.Now, CreatedBy = "bilisimkariyernet@gmail.com", UpdateDate = DateTime.Now, UpdatedBy = "bilisimkariyernet@gmail.com" };
                context.Add(aaa);
                var bbb = new Occupation() { Name = "Bilgisayar Teknolojisi Ve Programlama Teknikeri", CreateDate = DateTime.Now, CreatedBy = "bilisimkariyernet@gmail.com", UpdateDate = DateTime.Now, UpdatedBy = "bilisimkariyernet@gmail.com" };
                context.Add(bbb);
                var ccc = new Occupation() { Name = "Bilgisayar Yazılım Teknisyeni", CreateDate = DateTime.Now, CreatedBy = "bilisimkariyernet@gmail.com", UpdateDate = DateTime.Now, UpdatedBy = "bilisimkariyernet@gmail.com" };
                context.Add(ccc);
                var ddd = new Occupation() { Name = "Bilgisayar Teknisyeni", CreateDate = DateTime.Now, CreatedBy = "bilisimkariyernet@gmail.com", UpdateDate = DateTime.Now, UpdatedBy = "bilisimkariyernet@gmail.com" };
                context.Add(ddd);
                var eee = new Occupation() { Name = "Bilgisayar Program Teknisyeni", CreateDate = DateTime.Now, CreatedBy = "bilisimkariyernet@gmail.com", UpdateDate = DateTime.Now, UpdatedBy = "bilisimkariyernet@gmail.com" };
                context.Add(eee);
                var fff = new Occupation() { Name = "Veri Tabanı Programcısı", CreateDate = DateTime.Now, CreatedBy = "bilisimkariyernet@gmail.com", UpdateDate = DateTime.Now, UpdatedBy = "bilisimkariyernet@gmail.com" };
                context.Add(fff);
                var ggg = new Occupation() { Name = "Yazılım Destek Uzmanı", CreateDate = DateTime.Now, CreatedBy = "bilisimkariyernet@gmail.com", UpdateDate = DateTime.Now, UpdatedBy = "bilisimkariyernet@gmail.com" };
                context.Add(ggg);
                var hhh = new Occupation() { Name = "Bilişim Teknolojileri Teknisyeni", CreateDate = DateTime.Now, CreatedBy = "bilisimkariyernet@gmail.com", UpdateDate = DateTime.Now, UpdatedBy = "bilisimkariyernet@gmail.com" };
                context.Add(hhh);
                var iii = new Occupation() { Name = "Bilgisayar Teknik Serviçisi/Bilgisayar Donanım Teknisyeni", CreateDate = DateTime.Now, CreatedBy = "bilisimkariyernet@gmail.com", UpdateDate = DateTime.Now, UpdatedBy = "bilisimkariyernet@gmail.com" };
                context.Add(iii);
                var jjj = new Occupation() { Name = "Bilgisayar Donanım/Teknolojisi Teknikeri", CreateDate = DateTime.Now, CreatedBy = "bilisimkariyernet@gmail.com", UpdateDate = DateTime.Now, UpdatedBy = "bilisimkariyernet@gmail.com" };
                context.Add(jjj);
                var kkk = new Occupation() { Name = "Ağ Teknolojileri Elemanı", CreateDate = DateTime.Now, CreatedBy = "bilisimkariyernet@gmail.com", UpdateDate = DateTime.Now, UpdatedBy = "bilisimkariyernet@gmail.com" };
                context.Add(kkk);
                var lll = new Occupation() { Name = "Bilgi İşlem Destek Elemanı", CreateDate = DateTime.Now, CreatedBy = "bilisimkariyernet@gmail.com", UpdateDate = DateTime.Now, UpdatedBy = "bilisimkariyernet@gmail.com" };
                context.Add(lll);
                var mmm = new Occupation() { Name = "Bilgi İşlem Destek Sorumlusu", CreateDate = DateTime.Now, CreatedBy = "bilisimkariyernet@gmail.com", UpdateDate = DateTime.Now, UpdatedBy = "bilisimkariyernet@gmail.com" };
                context.Add(mmm);
                var nnn = new Occupation() { Name = "Ağ İşletmeni(Bilişim Teknolojisi)", CreateDate = DateTime.Now, CreatedBy = "bilisimkariyernet@gmail.com", UpdateDate = DateTime.Now, UpdatedBy = "bilisimkariyernet@gmail.com" };
                context.Add(nnn);
                var ooo = new Occupation() { Name = "E-Ticaret Meslek Elemanı", CreateDate = DateTime.Now, CreatedBy = "bilisimkariyernet@gmail.com", UpdateDate = DateTime.Now, UpdatedBy = "bilisimkariyernet@gmail.com" };
                context.Add(ooo);
                var ppp = new Occupation() { Name = "Web Sitesi Teknisyeni", CreateDate = DateTime.Now, CreatedBy = "bilisimkariyernet@gmail.com", UpdateDate = DateTime.Now, UpdatedBy = "bilisimkariyernet@gmail.com" };
                context.Add(ppp);
                var rrr = new Occupation() { Name = "Web Sitesi Yöneticisi", CreateDate = DateTime.Now, CreatedBy = "bilisimkariyernet@gmail.com", UpdateDate = DateTime.Now, UpdatedBy = "bilisimkariyernet@gmail.com" };
                context.Add(rrr);
                var sss = new Occupation() { Name = "Web Sitesi Sorumlusu", CreateDate = DateTime.Now, CreatedBy = "bilisimkariyernet@gmail.com", UpdateDate = DateTime.Now, UpdatedBy = "bilisimkariyernet@gmail.com" };
                context.Add(sss);
                var ttt = new Occupation() { Name = "Bilgisayar İşletmeni", CreateDate = DateTime.Now, CreatedBy = "bilisimkariyernet@gmail.com", UpdateDate = DateTime.Now, UpdatedBy = "bilisimkariyernet@gmail.com" };
                context.Add(ttt);
                var uuu = new Occupation() { Name = "Diğer Kart Ve Şerit Delme Makinesi Operatörleri", CreateDate = DateTime.Now, CreatedBy = "bilisimkariyernet@gmail.com", UpdateDate = DateTime.Now, UpdatedBy = "bilisimkariyernet@gmail.com" };
                context.Add(uuu);
                var vvv = new Occupation() { Name = "Kart Delme Makinesi Operatörü", CreateDate = DateTime.Now, CreatedBy = "bilisimkariyernet@gmail.com", UpdateDate = DateTime.Now, UpdatedBy = "bilisimkariyernet@gmail.com" };
                context.Add(vvv);
                var yyy = new Occupation() { Name = "Kart Ve Şerit Delme Makinesi Operatörü", CreateDate = DateTime.Now, CreatedBy = "bilisimkariyernet@gmail.com", UpdateDate = DateTime.Now, UpdatedBy = "bilisimkariyernet@gmail.com" };
                context.Add(yyy);
                var zzz = new Occupation() { Name = "Veri Giriş Kontrol İşletmeni", CreateDate = DateTime.Now, CreatedBy = "bilisimkariyernet@gmail.com", UpdateDate = DateTime.Now, UpdatedBy = "bilisimkariyernet@gmail.com" };
                context.Add(zzz);
                var aaaa = new Occupation() { Name = "Bilgisayar Operatörü(Çizim Programları)", CreateDate = DateTime.Now, CreatedBy = "bilisimkariyernet@gmail.com", UpdateDate = DateTime.Now, UpdatedBy = "bilisimkariyernet@gmail.com" };
                context.Add(aaaa);
                var bbbb = new Occupation() { Name = "Barkodcu", CreateDate = DateTime.Now, CreatedBy = "bilisimkariyernet@gmail.com", UpdateDate = DateTime.Now, UpdatedBy = "bilisimkariyernet@gmail.com" };
                context.Add(bbbb);
                var cccc = new Occupation() { Name = "Bilgisayar Operatörü(Resim Düzenleme Programları)", CreateDate = DateTime.Now, CreatedBy = "bilisimkariyernet@gmail.com", UpdateDate = DateTime.Now, UpdatedBy = "bilisimkariyernet@gmail.com" };
                context.Add(cccc);
                var dddd = new Occupation() { Name = "Bilgisayar Bilgi Yönetim Elemanı", CreateDate = DateTime.Now, CreatedBy = "bilisimkariyernet@gmail.com", UpdateDate = DateTime.Now, UpdatedBy = "bilisimkariyernet@gmail.com" };
                context.Add(dddd);
                var eeee = new Occupation() { Name = "Bilgisayar Bakım Ve Onarımcısı", CreateDate = DateTime.Now, CreatedBy = "bilisimkariyernet@gmail.com", UpdateDate = DateTime.Now, UpdatedBy = "bilisimkariyernet@gmail.com" };
                context.Add(eeee);
                var ffff = new Occupation() { Name = "Bilgisayar Ağ Sistemleri Ve Yönlendirme Elemanı", CreateDate = DateTime.Now, CreatedBy = "bilisimkariyernet@gmail.com", UpdateDate = DateTime.Now, UpdatedBy = "bilisimkariyernet@gmail.com" };
                context.Add(ffff);
                var gggg = new Occupation() { Name = "Bilgisayar Ağ Temelleri Elemanı", CreateDate = DateTime.Now, CreatedBy = "bilisimkariyernet@gmail.com", UpdateDate = DateTime.Now, UpdatedBy = "bilisimkariyernet@gmail.com" };
                context.Add(gggg);
                var hhhh = new Occupation() { Name = "Bilgisayar Ağ Veri Tabanı Elemanı", CreateDate = DateTime.Now, CreatedBy = "bilisimkariyernet@gmail.com", UpdateDate = DateTime.Now, UpdatedBy = "bilisimkariyernet@gmail.com" };
                context.Add(hhhh);
                var iiii = new Occupation() { Name = "Haberleşme Tesisatı Bakım Ve Onarımcısı", CreateDate = DateTime.Now, CreatedBy = "bilisimkariyernet@gmail.com", UpdateDate = DateTime.Now, UpdatedBy = "bilisimkariyernet@gmail.com" };
                context.Add(iiii);
                var jjjj = new Occupation() { Name = "Görsel Programlama Elemanı", CreateDate = DateTime.Now, CreatedBy = "bilisimkariyernet@gmail.com", UpdateDate = DateTime.Now, UpdatedBy = "bilisimkariyernet@gmail.com" };
                context.Add(jjjj);
                var kkkk = new Occupation() { Name = "Yazılım Proje Yönetici(Özel Sektör)", CreateDate = DateTime.Now, CreatedBy = "bilisimkariyernet@gmail.com", UpdateDate = DateTime.Now, UpdatedBy = "bilisimkariyernet@gmail.com" };
                context.Add(kkkk);
                var llll = new Occupation() { Name = "Matematik-Bilgisayar Uzmanı", CreateDate = DateTime.Now, CreatedBy = "bilisimkariyernet@gmail.com", UpdateDate = DateTime.Now, UpdatedBy = "bilisimkariyernet@gmail.com" };
                context.Add(llll);
                var mmmm = new Occupation() { Name = "Elektrik Ve Elektronik Mühendisi", CreateDate = DateTime.Now, CreatedBy = "bilisimkariyernet@gmail.com", UpdateDate = DateTime.Now, UpdatedBy = "bilisimkariyernet@gmail.com" };
                context.Add(mmmm);
                var nnnn = new Occupation() { Name = "Endüstri Mühendisi", CreateDate = DateTime.Now, CreatedBy = "bilisimkariyernet@gmail.com", UpdateDate = DateTime.Now, UpdatedBy = "bilisimkariyernet@gmail.com" };
                context.Add(nnnn);
                var oooo = new Occupation() { Name = "Kontrol Mühendisi/Kontrol Ve Otomasyon Mühendisi", CreateDate = DateTime.Now, CreatedBy = "bilisimkariyernet@gmail.com", UpdateDate = DateTime.Now, UpdatedBy = "bilisimkariyernet@gmail.com" };
                context.Add(oooo);
                var pppp = new Occupation() { Name = "Elektrik Mühendisi", CreateDate = DateTime.Now, CreatedBy = "bilisimkariyernet@gmail.com", UpdateDate = DateTime.Now, UpdatedBy = "bilisimkariyernet@gmail.com" };
                context.Add(pppp);
                var rrrr = new Occupation() { Name = "Elektronik Mühendisi(Genel)", CreateDate = DateTime.Now, CreatedBy = "bilisimkariyernet@gmail.com", UpdateDate = DateTime.Now, UpdatedBy = "bilisimkariyernet@gmail.com" };
                context.Add(rrrr);
                var ssss = new Occupation() { Name = "Telekominikasyon Mühendisi", CreateDate = DateTime.Now, CreatedBy = "bilisimkariyernet@gmail.com", UpdateDate = DateTime.Now, UpdatedBy = "bilisimkariyernet@gmail.com" };
                context.Add(ssss);
                var tttt = new Occupation() { Name = "Elektronik Ve Haberleşme Mühendisi", CreateDate = DateTime.Now, CreatedBy = "bilisimkariyernet@gmail.com", UpdateDate = DateTime.Now, UpdatedBy = "bilisimkariyernet@gmail.com" };
                context.Add(tttt);
                var uuuu = new Occupation() { Name = "Web Tasarımcısı", CreateDate = DateTime.Now, CreatedBy = "bilisimkariyernet@gmail.com", UpdateDate = DateTime.Now, UpdatedBy = "bilisimkariyernet@gmail.com" };
                context.Add(uuuu);
                var vvvv = new Occupation() { Name = "Grafik Animasyoncusu", CreateDate = DateTime.Now, CreatedBy = "bilisimkariyernet@gmail.com", UpdateDate = DateTime.Now, UpdatedBy = "bilisimkariyernet@gmail.com" };
                context.Add(vvvv);
                var yyyy = new Occupation() { Name = "Çoklu Ortam (Multimedya) Tasarımcısı", CreateDate = DateTime.Now, CreatedBy = "bilisimkariyernet@gmail.com", UpdateDate = DateTime.Now, UpdatedBy = "bilisimkariyernet@gmail.com" };
                context.Add(yyyy);
                var zzzz = new Occupation() { Name = "Bilgi Ve Belge Yönetimi Öğretim Üyesi", CreateDate = DateTime.Now, CreatedBy = "bilisimkariyernet@gmail.com", UpdateDate = DateTime.Now, UpdatedBy = "bilisimkariyernet@gmail.com" };
                context.Add(zzzz);
                var aaaaa = new Occupation() { Name = "Bilgisayar Bilimleri Öğretim Üyesi", CreateDate = DateTime.Now, CreatedBy = "bilisimkariyernet@gmail.com", UpdateDate = DateTime.Now, UpdatedBy = "bilisimkariyernet@gmail.com" };
                context.Add(aaaaa);
                var bbbbb = new Occupation() { Name = "Bilgisayar Destekli Tasarım Öğretim Üyesi", CreateDate = DateTime.Now, CreatedBy = "bilisimkariyernet@gmail.com", UpdateDate = DateTime.Now, UpdatedBy = "bilisimkariyernet@gmail.com" };
                context.Add(bbbbb);
                var ccccc = new Occupation() { Name = "Bilgisayar Donanımı Eğitimi Öğretim Üyesi", CreateDate = DateTime.Now, CreatedBy = "bilisimkariyernet@gmail.com", UpdateDate = DateTime.Now, UpdatedBy = "bilisimkariyernet@gmail.com" };
                context.Add(ccccc);
                var ddddd = new Occupation() { Name = "Bilgisayar Donanımı Öğretim Üyesi", CreateDate = DateTime.Now, CreatedBy = "bilisimkariyernet@gmail.com", UpdateDate = DateTime.Now, UpdatedBy = "bilisimkariyernet@gmail.com" };
                context.Add(ddddd);
                var eeeee = new Occupation() { Name = "Bilgisayar Kontrol-Kumanda Sistemleri Eğitimi Öğretim Üyesi", CreateDate = DateTime.Now, CreatedBy = "bilisimkariyernet@gmail.com", UpdateDate = DateTime.Now, UpdatedBy = "bilisimkariyernet@gmail.com" };
                context.Add(eeeee);
                var fffff = new Occupation() { Name = "Bilgisayar Mühendisliği Öğretim Üyesi", CreateDate = DateTime.Now, CreatedBy = "bilisimkariyernet@gmail.com", UpdateDate = DateTime.Now, UpdatedBy = "bilisimkariyernet@gmail.com" };
                context.Add(fffff);
                var ggggg = new Occupation() { Name = "Bilgisayar Yazılımı Eğitimi Öğretim Üyesi", CreateDate = DateTime.Now, CreatedBy = "bilisimkariyernet@gmail.com", UpdateDate = DateTime.Now, UpdatedBy = "bilisimkariyernet@gmail.com" };
                context.Add(ggggg);
                var hhhhh = new Occupation() { Name = "Bilgisayar Yazılımı Öğretim Üyesi", CreateDate = DateTime.Now, CreatedBy = "bilisimkariyernet@gmail.com", UpdateDate = DateTime.Now, UpdatedBy = "bilisimkariyernet@gmail.com" };
                context.Add(hhhhh);
                var iiiii = new Occupation() { Name = "Bilgisayarlı Eğitim Teknolojisi Öğretim Üyesi", CreateDate = DateTime.Now, CreatedBy = "bilisimkariyernet@gmail.com", UpdateDate = DateTime.Now, UpdatedBy = "bilisimkariyernet@gmail.com" };
                context.Add(iiiii);
                var jjjjj = new Occupation() { Name = "Elektrik Elektronik Ve Telekominikasyon Öğretim Üyesi", CreateDate = DateTime.Now, CreatedBy = "bilisimkariyernet@gmail.com", UpdateDate = DateTime.Now, UpdatedBy = "bilisimkariyernet@gmail.com" };
                context.Add(jjjjj);
                var kkkkk = new Occupation() { Name = "Elektrik-Elektronik Mühendisliği Öğretim Üyesi", CreateDate = DateTime.Now, CreatedBy = "bilisimkariyernet@gmail.com", UpdateDate = DateTime.Now, UpdatedBy = "bilisimkariyernet@gmail.com" };
                context.Add(kkkkk);
                var lllll = new Occupation() { Name = "Elektronik Öğretim Üyesi", CreateDate = DateTime.Now, CreatedBy = "bilisimkariyernet@gmail.com", UpdateDate = DateTime.Now, UpdatedBy = "bilisimkariyernet@gmail.com" };
                context.Add(lllll);
                var mmmmm = new Occupation() { Name = "Elektronik Ve Haberleşme Mühendisliği Öğretim Üyesi", CreateDate = DateTime.Now, CreatedBy = "bilisimkariyernet@gmail.com", UpdateDate = DateTime.Now, UpdatedBy = "bilisimkariyernet@gmail.com" };
                context.Add(mmmmm);
                var nnnnn = new Occupation() { Name = "Bilgisayar Öğretmeni-Ortaöğretim", CreateDate = DateTime.Now, CreatedBy = "bilisimkariyernet@gmail.com", UpdateDate = DateTime.Now, UpdatedBy = "bilisimkariyernet@gmail.com" };
                context.Add(nnnnn);
                var ooooo = new Occupation() { Name = "Elektronik/Telekominikasyon Öğretmeni", CreateDate = DateTime.Now, CreatedBy = "bilisimkariyernet@gmail.com", UpdateDate = DateTime.Now, UpdatedBy = "bilisimkariyernet@gmail.com" };
                context.Add(ooooo);
                var ppppp = new Occupation() { Name = "Elektronik Öğretmeni-Ortaöğretim", CreateDate = DateTime.Now, CreatedBy = "bilisimkariyernet@gmail.com", UpdateDate = DateTime.Now, UpdatedBy = "bilisimkariyernet@gmail.com" };
                context.Add(ppppp);
                var rrrrr = new Occupation() { Name = "Endüstriyel Elektronik Öğretmeni-Ortaöğretim", CreateDate = DateTime.Now, CreatedBy = "bilisimkariyernet@gmail.com", UpdateDate = DateTime.Now, UpdatedBy = "bilisimkariyernet@gmail.com" };
                context.Add(rrrrr);
                var sssss = new Occupation() { Name = "Endüstriyel Teknoloji Öğretmeni", CreateDate = DateTime.Now, CreatedBy = "bilisimkariyernet@gmail.com", UpdateDate = DateTime.Now, UpdatedBy = "bilisimkariyernet@gmail.com" };
                context.Add(sssss);
                var ttttt = new Occupation() { Name = "Kontrol Öğretmeni(Kontrol Sistemleri Ve Otomasyon)", CreateDate = DateTime.Now, CreatedBy = "bilisimkariyernet@gmail.com", UpdateDate = DateTime.Now, UpdatedBy = "bilisimkariyernet@gmail.com" };
                context.Add(ttttt);
                var uuuuu = new Occupation() { Name = "Mekatronik Öğretmeni", CreateDate = DateTime.Now, CreatedBy = "bilisimkariyernet@gmail.com", UpdateDate = DateTime.Now, UpdatedBy = "bilisimkariyernet@gmail.com" };
                context.Add(uuuuu);
                var vvvvv = new Occupation() { Name = "Mikro Teknoloji Öğretmeni-Ortaöğretim", CreateDate = DateTime.Now, CreatedBy = "bilisimkariyernet@gmail.com", UpdateDate = DateTime.Now, UpdatedBy = "bilisimkariyernet@gmail.com" };
                context.Add(vvvvv);
                var yyyyy = new Occupation() { Name = "Okul Bilişim Teknolojileri Formatör Öğretmeni", CreateDate = DateTime.Now, CreatedBy = "bilisimkariyernet@gmail.com", UpdateDate = DateTime.Now, UpdatedBy = "bilisimkariyernet@gmail.com" };
                context.Add(yyyyy);
                var zzzzz = new Occupation() { Name = "Telekominikasyon Öğretmeni-Ortaöğretim", CreateDate = DateTime.Now, CreatedBy = "bilisimkariyernet@gmail.com", UpdateDate = DateTime.Now, UpdatedBy = "bilisimkariyernet@gmail.com" };
                context.Add(zzzzz);
                var w = new Occupation() { Name = "Bilişim Teknolojileri Öğretmeni", CreateDate = DateTime.Now, CreatedBy = "bilisimkariyernet@gmail.com", UpdateDate = DateTime.Now, UpdatedBy = "bilisimkariyernet@gmail.com" };
                context.Add(w);
                var ww = new Occupation() { Name = "Endüstriyel Otomasyon Teknolojileri Öğretmeni", CreateDate = DateTime.Now, CreatedBy = "bilisimkariyernet@gmail.com", UpdateDate = DateTime.Now, UpdatedBy = "bilisimkariyernet@gmail.com" };
                context.Add(ww);
                var www = new Occupation() { Name = "Bilgisayar Eğiticisi", CreateDate = DateTime.Now, CreatedBy = "bilisimkariyernet@gmail.com", UpdateDate = DateTime.Now, UpdatedBy = "bilisimkariyernet@gmail.com" };
                context.Add(www);
                var wwww = new Occupation() { Name = "Bilgi Teknolojileri Danışmanı", CreateDate = DateTime.Now, CreatedBy = "bilisimkariyernet@gmail.com", UpdateDate = DateTime.Now, UpdatedBy = "bilisimkariyernet@gmail.com" };
                context.Add(wwww);
                var wwwww = new Occupation() { Name = "İş Analisti", CreateDate = DateTime.Now, CreatedBy = "bilisimkariyernet@gmail.com", UpdateDate = DateTime.Now, UpdatedBy = "bilisimkariyernet@gmail.com" };
                context.Add(wwwww);
                var aaaaaa = new Occupation() { Name = "CNC Programcısı", CreateDate = DateTime.Now, CreatedBy = "bilisimkariyernet@gmail.com", UpdateDate = DateTime.Now, UpdatedBy = "bilisimkariyernet@gmail.com" };
                context.Add(aaaaaa);
                var bbbbbb = new Occupation() { Name = "CNC Programcısı Yardımcısı", CreateDate = DateTime.Now, CreatedBy = "bilisimkariyernet@gmail.com", UpdateDate = DateTime.Now, UpdatedBy = "bilisimkariyernet@gmail.com" };
                context.Add(bbbbbb);
                var cccccc = new Occupation() { Name = "Bilgisayarlı Muhasebe Elemanı", CreateDate = DateTime.Now, CreatedBy = "bilisimkariyernet@gmail.com", UpdateDate = DateTime.Now, UpdatedBy = "bilisimkariyernet@gmail.com" };
                context.Add(cccccc);           

                context.SaveChanges();

            }

        }

    }
}