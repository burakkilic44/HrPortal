using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HrPortal.Data;
using HrPortal.Models;
using Microsoft.AspNetCore.Authorization;

namespace HrPortal.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class LanguagesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LanguagesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin/Languages
        public async Task<IActionResult> Index()
        {
            return View(await _context.Languages.ToListAsync());
        }

        // GET: Admin/Languages/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var language = await _context.Languages
                .SingleOrDefaultAsync(m => m.Id == id);
            if (language == null)
            {
                return NotFound();
            }

            return View(language);
        }

        // GET: Admin/Languages/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Languages/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Id,CreateDate,CreateBy,UpdateDate,UpdatedBy")] Language language)
        {
            if (ModelState.IsValid)
            {
                _context.Add(language);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(language);
        }

        // GET: Admin/Languages/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var language = await _context.Languages.SingleOrDefaultAsync(m => m.Id == id);
            if (language == null)
            {
                return NotFound();
            }
            return View(language);
        }

        // POST: Admin/Languages/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Name,Id,CreateDate,CreateBy,UpdateDate,UpdatedBy")] Language language)
        {
            if (id != language.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(language);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LanguageExists(language.Id))
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
            return View(language);
        }

        // GET: Admin/Languages/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var language = await _context.Languages
                .SingleOrDefaultAsync(m => m.Id == id);
            if (language == null)
            {
                return NotFound();
            }

            return View(language);
        }

        // POST: Admin/Languages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var language = await _context.Languages.SingleOrDefaultAsync(m => m.Id == id);
            _context.Languages.Remove(language);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LanguageExists(string id)
        {
            return _context.Languages.Any(e => e.Id == id);
        }
    }
}
