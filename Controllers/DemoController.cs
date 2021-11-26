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
    public class DemoController : Controller
    {
        private readonly ApplicationDBContext _context;

        public DemoController(ApplicationDBContext context)
        {
            _context = context;
        }

        // GET: Demo
        public async Task<IActionResult> Index()
        {
            return View(await _context.Demo.ToListAsync());
        }

        // GET: Demo/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var demo = await _context.Demo
                .FirstOrDefaultAsync(m => m.DemoID == id);
            if (demo == null)
            {
                return NotFound();
            }

            return View(demo);
        }

        // GET: Demo/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Demo/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DemoID,DemoName")] Demo demo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(demo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(demo);
        }

        // GET: Demo/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var demo = await _context.Demo.FindAsync(id);
            if (demo == null)
            {
                return NotFound();
            }
            return View(demo);
        }

        // POST: Demo/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("DemoID,DemoName")] Demo demo)
        {
            if (id != demo.DemoID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(demo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DemoExists(demo.DemoID))
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
            return View(demo);
        }

        // GET: Demo/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var demo = await _context.Demo
                .FirstOrDefaultAsync(m => m.DemoID == id);
            if (demo == null)
            {
                return NotFound();
            }

            return View(demo);
        }

        // POST: Demo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var demo = await _context.Demo.FindAsync(id);
            _context.Demo.Remove(demo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DemoExists(string id)
        {
            return _context.Demo.Any(e => e.DemoID == id);
        }
    }
}
