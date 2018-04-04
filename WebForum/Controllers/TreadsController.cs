using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebForum.Models;

namespace WebForum.Controllers
{
    public class TreadsController : Controller
    {
        private readonly WebForumContext _context;

        public TreadsController(WebForumContext context)
        {
            _context = context;
        }

        // GET: Treads
        public async Task<IActionResult> Index()
        {
            return View(await _context.Tread.ToListAsync());
        }

        // GET: Treads/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tread = await _context.Tread
                .SingleOrDefaultAsync(m => m.ID == id);
            if (tread == null)
            {
                return NotFound();
            }

            return View(tread);
        }

        // GET: Treads/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Treads/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Title,Author,Text")] Tread tread)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tread);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tread);
        }

        // GET: Treads/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tread = await _context.Tread.SingleOrDefaultAsync(m => m.ID == id);
            if (tread == null)
            {
                return NotFound();
            }
            return View(tread);
        }

        // POST: Treads/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Title,Author,Text")] Tread tread)
        {
            if (id != tread.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tread);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TreadExists(tread.ID))
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
            return View(tread);
        }

        // GET: Treads/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tread = await _context.Tread
                .SingleOrDefaultAsync(m => m.ID == id);
            if (tread == null)
            {
                return NotFound();
            }

            return View(tread);
        }

        // POST: Treads/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tread = await _context.Tread.SingleOrDefaultAsync(m => m.ID == id);
            _context.Tread.Remove(tread);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TreadExists(int id)
        {
            return _context.Tread.Any(e => e.ID == id);
        }
    }
}
