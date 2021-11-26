using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVCDEMO.Data;
using MVCDEMO.Models;

namespace MvcDeMo.Controllers
{
    public class DoanviensController : Controller
    {
        private readonly ApplicationDBContext _context;

        public DoanviensController(ApplicationDBContext context)
        {
            _context = context;
        }

        // GET: Doanviens
        public async Task<IActionResult> Index()
        {
            return View(await _context.Doanvien.ToListAsync());
        }

        // GET: Doanviens/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var doanvien = await _context.Doanvien
                .FirstOrDefaultAsync(m => m.id == id);
            if (doanvien == null)
            {
                return NotFound();
            }

            return View(doanvien);
        }

        // GET: Doanviens/Create
        public IActionResult Create()
        {
            ViewData["cdid"] = new SelectList(_context.Chidoan, "cdid", "cdid");
            return View();
        }

        // POST: Doanviens/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,fullname,cdid")] Doanvien doanvien)
        {
            if (ModelState.IsValid)
            {
                _context.Add(doanvien);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["cdid"] = new SelectList(_context.Chidoan, "cdid", "cdid");
            return View(doanvien);
        }

        // GET: Doanviens/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var doanvien = await _context.Doanvien.FindAsync(id);
            if (doanvien == null)
            {
                return NotFound();
            }
            ViewData["cdid"] = new SelectList(_context.Chidoan, "cdid", "cdid");
            return View(doanvien);
        }

        // POST: Doanviens/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("id,fullname,cdid")] Doanvien doanvien)
        {
            if (id != doanvien.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(doanvien);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DoanvienExists(doanvien.id))
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
            ViewData["cdid"] = new SelectList(_context.Chidoan, "cdid", "cdid");
            return View(doanvien);
        }

        // GET: Doanviens/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var doanvien = await _context.Doanvien
                .FirstOrDefaultAsync(m => m.id == id);
            if (doanvien == null)
            {
                return NotFound();
            }

            return View(doanvien);
        }

        // POST: Doanviens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var doanvien = await _context.Doanvien.FindAsync(id);
            _context.Doanvien.Remove(doanvien);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DoanvienExists(string id)
        {
            return _context.Doanvien.Any(e => e.id == id);
        }
    }
}
