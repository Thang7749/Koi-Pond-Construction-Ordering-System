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
    public class TaiKhoanKhachHangsController : Controller
    {
        private readonly KoiPondDbContext _context;

        public TaiKhoanKhachHangsController(KoiPondDbContext context)
        {
            _context = context;
        }

        // GET: TaiKhoanKhachHangs
        public async Task<IActionResult> Index()
        {
            var koiPondDbContext = _context.TaiKhoanKhachHangs.Include(t => t.KhachHang);
            return View(await koiPondDbContext.ToListAsync());
        }

        // GET: TaiKhoanKhachHangs/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taiKhoanKhachHang = await _context.TaiKhoanKhachHangs
                .Include(t => t.KhachHang)
                .FirstOrDefaultAsync(m => m.TaiKhoanId == id);
            if (taiKhoanKhachHang == null)
            {
                return NotFound();
            }

            return View(taiKhoanKhachHang);
        }

        // GET: TaiKhoanKhachHangs/Create
        public IActionResult Create()
        {
            ViewData["KhachHangId"] = new SelectList(_context.KhachHangs, "KhachHangId", "KhachHangId");
            return View();
        }

        // POST: TaiKhoanKhachHangs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TaiKhoanId,KhachHangId,TenDangNhap,MatKhau,NgayTao,TrangThai")] TaiKhoanKhachHang taiKhoanKhachHang)
        {
            if (ModelState.IsValid)
            {
                _context.Add(taiKhoanKhachHang);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["KhachHangId"] = new SelectList(_context.KhachHangs, "KhachHangId", "KhachHangId", taiKhoanKhachHang.KhachHangId);
            return View(taiKhoanKhachHang);
        }

        // GET: TaiKhoanKhachHangs/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taiKhoanKhachHang = await _context.TaiKhoanKhachHangs.FindAsync(id);
            if (taiKhoanKhachHang == null)
            {
                return NotFound();
            }
            ViewData["KhachHangId"] = new SelectList(_context.KhachHangs, "KhachHangId", "KhachHangId", taiKhoanKhachHang.KhachHangId);
            return View(taiKhoanKhachHang);
        }

        // POST: TaiKhoanKhachHangs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("TaiKhoanId,KhachHangId,TenDangNhap,MatKhau,NgayTao,TrangThai")] TaiKhoanKhachHang taiKhoanKhachHang)
        {
            if (id != taiKhoanKhachHang.TaiKhoanId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(taiKhoanKhachHang);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TaiKhoanKhachHangExists(taiKhoanKhachHang.TaiKhoanId))
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
            ViewData["KhachHangId"] = new SelectList(_context.KhachHangs, "KhachHangId", "KhachHangId", taiKhoanKhachHang.KhachHangId);
            return View(taiKhoanKhachHang);
        }

        // GET: TaiKhoanKhachHangs/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taiKhoanKhachHang = await _context.TaiKhoanKhachHangs
                .Include(t => t.KhachHang)
                .FirstOrDefaultAsync(m => m.TaiKhoanId == id);
            if (taiKhoanKhachHang == null)
            {
                return NotFound();
            }

            return View(taiKhoanKhachHang);
        }

        // POST: TaiKhoanKhachHangs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var taiKhoanKhachHang = await _context.TaiKhoanKhachHangs.FindAsync(id);
            if (taiKhoanKhachHang != null)
            {
                _context.TaiKhoanKhachHangs.Remove(taiKhoanKhachHang);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TaiKhoanKhachHangExists(string id)
        {
            return _context.TaiKhoanKhachHangs.Any(e => e.TaiKhoanId == id);
        }
    }
}
