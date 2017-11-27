using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HrPortal.Data;
using HrPortal.Models;
using Microsoft.AspNetCore.Identity;

namespace HrPortal.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UsersController : Controller
    {
        private readonly ApplicationDbContext _context;

        private UserManager<ApplicationUser> userManager;
        private RoleManager<IdentityRole> roleManager;

        public UsersController(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        public IActionResult Index()
        {
            var users = userManager.Users.ToList();
            return View(users);
        }


        // GET: Admin/Users/Edit/5
        public IActionResult Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var users = ViewBag.ApplicationUser.SingleOrDefaultAsync();
            if (users == null)
            {
                return NotFound();
            }
            
            return View(users);
        }

        // POST: Admin/Users/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(string id, [Bind("FirstName,LastName,Photo,OccupationId,LocationId,IsEmployer,CompanyName,IsApproved,ApproveDate,IsActive,CreateDate,UpdateDate,Id,UserName,NormalizedUserName,Email,NormalizedEmail,EmailConfirmed,PasswordHash,SecurityStamp,ConcurrencyStamp,PhoneNumber,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEnd,LockoutEnabled,AccessFailedCount")] ApplicationUser users)
        {
            if (id != users.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    ViewBag.Update(users);
                    ViewBag.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ApplicationUserExists(users.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }         
            return View(users);
        }

        // GET: Admin/Users/Delete/5
        public IActionResult Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var users =ViewBag.ApplicationUser             
                .SingleOrDefaultAsync();
            if (users == null)
            {
                return NotFound();
            }

            return View(users);
        }

        // POST: Admin/Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var applicationUser = await _context.ApplicationUser.SingleOrDefaultAsync(m => m.Id == id);
            _context.ApplicationUser.Remove(applicationUser);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ApplicationUserExists(string id)
        {
            return _context.ApplicationUser.Any(e => e.Id == id);
        }
    }
}
