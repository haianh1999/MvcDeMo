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
    public class ChidoansController : Controller
    {
        private readonly ApplicationDBContext _context;

        public ChidoansController(ApplicationDBContext context)
        {
            _context = context;
        }

        // GET: Chidoans
        public async Task<IActionResult> Index()
        {
            return View(await _context.Chidoan.ToListAsync());
        }

        // GET: Chidoans/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chidoan = await _context.Chidoan
                .FirstOrDefaultAsync(m => m.cdid == id);
            if (chidoan == null)
            {
                return NotFound();
            }

            return View(chidoan);
        }

        // GET: Chidoans/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Chidoans/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("cdid,tenchidoan")] Chidoan chidoan)
        {
            if (ModelState.IsValid)
            {
                _context.Add(chidoan);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(chidoan);
        }

        // GET: Chidoans/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chidoan = await _context.Chidoan.FindAsync(id);
            if (chidoan == null)
            {
                return NotFound();
            }
            return View(chidoan);
        }

        // POST: Chidoans/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("cdid,tenchidoan")] Chidoan chidoan)
        {
            if (id != chidoan.cdid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(chidoan);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ChidoanExists(chidoan.cdid))
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
            return View(chidoan);
        }

        // GET: Chidoans/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chidoan = await _context.Chidoan
                .FirstOrDefaultAsync(m => m.cdid == id);
            if (chidoan == null)
            {
                return NotFound();
            }

            return View(chidoan);
        }

        // POST: Chidoans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var chidoan = await _context.Chidoan.FindAsync(id);
            _context.Chidoan.Remove(chidoan);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ChidoanExists(string id)
        {
            return _context.Chidoan.Any(e => e.cdid == id);
        }
    }
}
