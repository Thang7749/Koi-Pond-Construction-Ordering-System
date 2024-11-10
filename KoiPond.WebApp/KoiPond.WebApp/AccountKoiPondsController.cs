using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using KoiPond.Repositories.Entities;

namespace KoiPond.WebApp
{
    public class AccountKoiPondsController : Controller
    {
        private readonly KoiPond2024DbContext _context;

        public AccountKoiPondsController(KoiPond2024DbContext context)
        {
            _context = context;
        }

        // GET: AccountKoiPonds
        public async Task<IActionResult> Index()
        {
            return View(await _context.AccountKoiPonds.ToListAsync());
        }

        // GET: AccountKoiPonds/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var accountKoiPond = await _context.AccountKoiPonds
                .FirstOrDefaultAsync(m => m.AccountId == id);
            if (accountKoiPond == null)
            {
                return NotFound();
            }

            return View(accountKoiPond);
        }

        // GET: AccountKoiPonds/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AccountKoiPonds/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AccountId")] AccountKoiPond accountKoiPond)
        {
            if (ModelState.IsValid)
            {
                _context.Add(accountKoiPond);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(accountKoiPond);
        }

        // GET: AccountKoiPonds/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var accountKoiPond = await _context.AccountKoiPonds.FindAsync(id);
            if (accountKoiPond == null)
            {
                return NotFound();
            }
            return View(accountKoiPond);
        }

        // POST: AccountKoiPonds/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AccountId")] AccountKoiPond accountKoiPond)
        {
            if (id != accountKoiPond.AccountId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(accountKoiPond);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AccountKoiPondExists(accountKoiPond.AccountId))
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
            return View(accountKoiPond);
        }

        // GET: AccountKoiPonds/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var accountKoiPond = await _context.AccountKoiPonds
                .FirstOrDefaultAsync(m => m.AccountId == id);
            if (accountKoiPond == null)
            {
                return NotFound();
            }

            return View(accountKoiPond);
        }

        // POST: AccountKoiPonds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var accountKoiPond = await _context.AccountKoiPonds.FindAsync(id);
            if (accountKoiPond != null)
            {
                _context.AccountKoiPonds.Remove(accountKoiPond);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AccountKoiPondExists(int id)
        {
            return _context.AccountKoiPonds.Any(e => e.AccountId == id);
        }
    }
}
