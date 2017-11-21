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
    public class SkillsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SkillsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin/Skills
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Skills.Include(s => s.Resume);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Admin/Skills/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var skill = await _context.Skills
                .Include(s => s.Resume)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (skill == null)
            {
                return NotFound();
            }

            return View(skill);
        }

        // GET: Admin/Skills/Create
        public IActionResult Create()
        {
            ViewData["ResumeId"] = new SelectList(_context.Resumes, "Id", "Id");
            return View();
        }

        // POST: Admin/Skills/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Level,ResumeId,Id,CreateDate,CreateBy,UpdateDate,UpdatedBy")] Skill skill)
        {
            if (ModelState.IsValid)
            {
                _context.Add(skill);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ResumeId"] = new SelectList(_context.Resumes, "Id", "Id", skill.ResumeId);
            return View(skill);
        }

        // GET: Admin/Skills/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var skill = await _context.Skills.SingleOrDefaultAsync(m => m.Id == id);
            if (skill == null)
            {
                return NotFound();
            }
            ViewData["ResumeId"] = new SelectList(_context.Resumes, "Id", "Id", skill.ResumeId);
            return View(skill);
        }

        // POST: Admin/Skills/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Name,Level,ResumeId,Id,CreateDate,CreateBy,UpdateDate,UpdatedBy")] Skill skill)
        {
            if (id != skill.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(skill);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SkillExists(skill.Id))
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
            ViewData["ResumeId"] = new SelectList(_context.Resumes, "Id", "Id", skill.ResumeId);
            return View(skill);
        }

        // GET: Admin/Skills/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var skill = await _context.Skills
                .Include(s => s.Resume)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (skill == null)
            {
                return NotFound();
            }

            return View(skill);
        }

        // POST: Admin/Skills/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var skill = await _context.Skills.SingleOrDefaultAsync(m => m.Id == id);
            _context.Skills.Remove(skill);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SkillExists(string id)
        {
            return _context.Skills.Any(e => e.Id == id);
        }
    }
}
