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
    public class MessagesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MessagesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin/Messages
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Messages.Include(m => m.FromCompany).Include(m => m.ToCompany).Include(m => m.FromResume).Include(m=>m.ToResume);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Admin/Messages/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var message = await _context.Messages
                .Include(m => m.FromCompany).Include(m => m.ToCompany).Include(m => m.FromResume).Include(m => m.ToResume)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (message == null)
            {
                return NotFound();
            }

            return View(message);
        }

        // GET: Admin/Messages/Create
        public IActionResult Create()
        {
            ViewData["ApplicationUserId"] = new SelectList(_context.Users, "Id", "Id");
            ViewData["CompanyId"] = new SelectList(_context.Companies, "Id", "Id");
            ViewData["ResumeId"] = new SelectList(_context.Resumes, "Id", "Id");
            return View();
        }

        // POST: Admin/Messages/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CompanyId,ApplicationUserId,Subject,Body,IsRead,ReadDate,ResumeId,Id,CreateDate,CreatedBy,UpdateDate,UpdatedBy")] Message message)
        {
            if (ModelState.IsValid)
            {
                _context.Add(message);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ApplicationUserId"] = new SelectList(_context.Users, "Id", "Id");
            ViewData["CompanyId"] = new SelectList(_context.Companies, "Id", "Id");
            ViewData["ResumeId"] = new SelectList(_context.Resumes, "Id", "Id");
            return View(message);
        }

        // GET: Admin/Messages/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var message = await _context.Messages.SingleOrDefaultAsync(m => m.Id == id);
            if (message == null)
            {
                return NotFound();
            }
            ViewData["ApplicationUserId"] = new SelectList(_context.Users, "Id", "Id");
            ViewData["CompanyId"] = new SelectList(_context.Companies, "Id", "Id");
            ViewData["ResumeId"] = new SelectList(_context.Resumes, "Id", "Id");
            return View(message);
        }

        // POST: Admin/Messages/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("CompanyId,ApplicationUserId,Subject,Body,IsRead,ReadDate,ResumeId,Id,CreateDate,CreatedBy,UpdateDate,UpdatedBy")] Message message)
        {
            if (id != message.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(message);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MessageExists(message.Id))
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
            ViewData["ApplicationUserId"] = new SelectList(_context.Users, "Id", "Id");
            ViewData["CompanyId"] = new SelectList(_context.Companies, "Id", "Id");
            ViewData["ResumeId"] = new SelectList(_context.Resumes, "Id", "Id");
            return View(message);
        }

        // GET: Admin/Messages/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var message = await _context.Messages
               .Include(m => m.FromCompany).Include(m => m.ToCompany).Include(m => m.FromResume).Include(m => m.ToResume)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (message == null)
            {
                return NotFound();
            }

            return View(message);
        }

        // POST: Admin/Messages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var message = await _context.Messages.SingleOrDefaultAsync(m => m.Id == id);
            _context.Messages.Remove(message);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MessageExists(string id)
        {
            return _context.Messages.Any(e => e.Id == id);
        }
    }
}
