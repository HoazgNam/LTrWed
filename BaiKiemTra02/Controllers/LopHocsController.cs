using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BaiKiemTra02.Data;
using BaiKiemTra02.Models;

namespace BaiKiemTra02.Controllers
{
    public class LopHocsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LopHocsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: LopHocs
        public async Task<IActionResult> Index()
        {
              return _context.LopHoc != null ? 
                          View(await _context.LopHoc.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.LopHoc'  is null.");
        }

       
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.LopHoc == null)
            {
                return NotFound();
            }

            var lopHoc = await _context.LopHoc
                .FirstOrDefaultAsync(m => m.Id == id);
            if (lopHoc == null)
            {
                return NotFound();
            }

            return View(lopHoc);
        }

        
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TenLopHoc,NamNhapHoc,NamRaTruong,SoLuongSinhVien")] LopHoc lopHoc)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lopHoc);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(lopHoc);
        }


        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.LopHoc == null)
            {
                return NotFound();
            }

            var lopHoc = await _context.LopHoc.FindAsync(id);
            if (lopHoc == null)
            {
                return NotFound();
            }
            return View(lopHoc);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TenLopHoc,NamNhapHoc,NamRaTruong,SoLuongSinhVien")] LopHoc lopHoc)
        {
            if (id != lopHoc.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lopHoc);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LopHocExists(lopHoc.Id))
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
            return View(lopHoc);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.LopHoc == null)
            {
                return NotFound();
            }

            var lopHoc = await _context.LopHoc
                .FirstOrDefaultAsync(m => m.Id == id);
            if (lopHoc == null)
            {
                return NotFound();
            }

            return View(lopHoc);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.LopHoc == null)
            {
                return Problem("Entity set 'ApplicationDbContext.LopHoc'  is null.");
            }
            var lopHoc = await _context.LopHoc.FindAsync(id);
            if (lopHoc != null)
            {
                _context.LopHoc.Remove(lopHoc);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LopHocExists(int id)
        {
          return (_context.LopHoc?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
