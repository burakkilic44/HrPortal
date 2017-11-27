using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HrPortal.Data;
using HrPortal.Models;

namespace HrPortal.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AuditsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AuditsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin/Audits
        public async Task<IActionResult> Index()
        {
            return View(await _context.Audits.ToListAsync());
        }

        // GET: Admin/Audits/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var audit = await _context.Audits
                .SingleOrDefaultAsync(m => m.Id == id);
            if (audit == null)
            {
                return NotFound();
            }

            return View(audit);
        }

        // GET: Admin/Audits/Create
        public IActionResult Create()
        {
            var audit = new Audit() { CreateDate = DateTime.Now, CreatedBy = User.Identity.Name, UpdateDate = DateTime.Now, UpdatedBy = User.Identity.Name };

            return View(audit);
        }

        // POST: Admin/Audits/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EntityId,Area,Controller,Action,Url,OldValue,NewValue,Ip,UserAgent,UserName,Id,CreateDate,CreatedBy,UpdateDate,UpdatedBy")] Audit audit)
        {
            if (ModelState.IsValid)
            {
                audit.CreatedBy = User.Identity.Name;
                audit.CreateDate = DateTime.Now;
                audit.UpdatedBy = User.Identity.Name;
                audit.UpdateDate = DateTime.Now;
                _context.Add(audit);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(audit);
        }

        // GET: Admin/Audits/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var audit = await _context.Audits.SingleOrDefaultAsync(m => m.Id == id);
            if (audit == null)
            {
                return NotFound();
            }
            return View(audit);
        }

        // POST: Admin/Audits/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("EntityId,Area,Controller,Action,Url,OldValue,NewValue,Ip,UserAgent,UserName,Id,CreateDate,CreatedBy,UpdateDate,UpdatedBy")] Audit audit)
        {
            if (id != audit.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    audit.UpdateDate = DateTime.Now;
                    audit.UpdatedBy = User.Identity.Name;
                    _context.Update(audit);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AuditExists(audit.Id))
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
            return View(audit);
        }

        // GET: Admin/Audits/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var audit = await _context.Audits
                .SingleOrDefaultAsync(m => m.Id == id);
            if (audit == null)
            {
                return NotFound();
            }

            return View(audit);
        }

        // POST: Admin/Audits/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var audit = await _context.Audits.SingleOrDefaultAsync(m => m.Id == id);
            _context.Audits.Remove(audit);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AuditExists(string id)
        {
            return _context.Audits.Any(e => e.Id == id);
        }
    }
}
