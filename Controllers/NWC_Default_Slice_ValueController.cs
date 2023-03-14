using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using InvoicesProject.APPDB;
using InvoicesProject.Models;

namespace InvoicesProject.Controllers
{
    public class NWC_Default_Slice_ValueController : Controller
    {
        private readonly AppDbContext _context;

        public NWC_Default_Slice_ValueController(AppDbContext context)
        {
            _context = context;
        }

        // GET: NWC_Default_Slice_Value
        public async Task<IActionResult> Index()
        {
              return _context.NWC_Default_Slice_Values != null ? 
                          View(await _context.NWC_Default_Slice_Values.ToListAsync()) :
                          Problem("Entity set 'AppDbContext.NWC_Default_Slice_Values'  is null.");
        }

        // GET: NWC_Default_Slice_Value/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.NWC_Default_Slice_Values == null)
            {
                return NotFound();
            }

            var nWC_Default_Slice_Value = await _context.NWC_Default_Slice_Values
                .FirstOrDefaultAsync(m => m.NWC_Default_Slice_ValueID == id);
            if (nWC_Default_Slice_Value == null)
            {
                return NotFound();
            }

            return View(nWC_Default_Slice_Value);
        }

        // GET: NWC_Default_Slice_Value/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: NWC_Default_Slice_Value/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NWC_Default_Slice_ValueID,NWC_Default_Slice_Value_Name,NWC_Default_Slice_Value_Condtion,NWC_Default_Slice_Value_Water_Price,NWC_Default_Slice_Value_Sanitation_Price,NWC_Default_Slice_Values_Reason")] NWC_Default_Slice_Value nWC_Default_Slice_Value)
        {
            if (_context.NWC_Default_Slice_Values.Any(x => x.NWC_Default_Slice_ValueID == nWC_Default_Slice_Value.NWC_Default_Slice_ValueID)) {
                ModelState.AddModelError("", "الرمز موجود بالفعل");
            }
            if (ModelState.IsValid)
            {
                _context.Add(nWC_Default_Slice_Value);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(nWC_Default_Slice_Value);
        }

        // GET: NWC_Default_Slice_Value/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.NWC_Default_Slice_Values == null)
            {
                return NotFound();
            }

            var nWC_Default_Slice_Value = await _context.NWC_Default_Slice_Values.FindAsync(id);
            if (nWC_Default_Slice_Value == null)
            {
                return NotFound();
            }
            return View(nWC_Default_Slice_Value);
        }

        // POST: NWC_Default_Slice_Value/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("NWC_Default_Slice_ValueID,NWC_Default_Slice_Value_Name,NWC_Default_Slice_Value_Condtion,NWC_Default_Slice_Value_Water_Price,NWC_Default_Slice_Value_Sanitation_Price,NWC_Default_Slice_Values_Reason")] NWC_Default_Slice_Value nWC_Default_Slice_Value)
        {
            if (_context.NWC_Default_Slice_Values.Any(x => x.NWC_Default_Slice_ValueID == nWC_Default_Slice_Value.NWC_Default_Slice_ValueID)) {
                ModelState.AddModelError("", "الرمز موجود بالفعل");
            }
            if (id != nWC_Default_Slice_Value.NWC_Default_Slice_ValueID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nWC_Default_Slice_Value);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NWC_Default_Slice_ValueExists(nWC_Default_Slice_Value.NWC_Default_Slice_ValueID))
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
            return View(nWC_Default_Slice_Value);
        }

        // GET: NWC_Default_Slice_Value/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.NWC_Default_Slice_Values == null)
            {
                return NotFound();
            }

            var nWC_Default_Slice_Value = await _context.NWC_Default_Slice_Values
                .FirstOrDefaultAsync(m => m.NWC_Default_Slice_ValueID == id);
            if (nWC_Default_Slice_Value == null)
            {
                return NotFound();
            }

            return View(nWC_Default_Slice_Value);
        }

        // POST: NWC_Default_Slice_Value/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.NWC_Default_Slice_Values == null)
            {
                return Problem("Entity set 'AppDbContext.NWC_Default_Slice_Values'  is null.");
            }
            var nWC_Default_Slice_Value = await _context.NWC_Default_Slice_Values.FindAsync(id);
            if (nWC_Default_Slice_Value != null)
            {
                _context.NWC_Default_Slice_Values.Remove(nWC_Default_Slice_Value);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NWC_Default_Slice_ValueExists(string id)
        {
          return (_context.NWC_Default_Slice_Values?.Any(e => e.NWC_Default_Slice_ValueID == id)).GetValueOrDefault();
        }
    }
}
