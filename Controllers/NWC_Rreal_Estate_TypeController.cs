
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using InvoicesProject.APPDB;
using InvoicesProject.Models;

namespace InvoicesProject.Controllers
{
    public class NWC_Rreal_Estate_TypeController : Controller
    {
        private readonly AppDbContext _context;

        public NWC_Rreal_Estate_TypeController(AppDbContext context)
        {
            _context = context;
        }

        // GET: NWC_Rreal_Estate_Type
        public async Task<IActionResult> Index()
        {
              return _context.NWC_Rreal_Estate_Types != null ? 
                          View(await _context.NWC_Rreal_Estate_Types.ToListAsync()) :
                          Problem("Entity set 'AppDbContext.NWC_Rreal_Estate_Types'  is null.");
        }

        // GET: NWC_Rreal_Estate_Type/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.NWC_Rreal_Estate_Types == null)
            {
                return NotFound();
            }

            var nWC_Rreal_Estate_Type = await _context.NWC_Rreal_Estate_Types
                .FirstOrDefaultAsync(m => m.NWC_Rreal_Estate_TypeID == id);
            if (nWC_Rreal_Estate_Type == null)
            {
                return NotFound();
            }

            return View(nWC_Rreal_Estate_Type);
        }

        // GET: NWC_Rreal_Estate_Type/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: NWC_Rreal_Estate_Type/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NWC_Rreal_Estate_TypeID,NWC_Rreal_Estate_Type_Name,NWC_Rreal_Estate_Type_Reasons")] NWC_Rreal_Estate_Type nWC_Rreal_Estate_Type)
        {
            //ModelState.Remove("NWC_Rreal_Estate_TypeID");
            if (_context.NWC_Rreal_Estate_Types.Any(x => x.NWC_Rreal_Estate_TypeID == nWC_Rreal_Estate_Type.NWC_Rreal_Estate_TypeID)) {
                ModelState.AddModelError("", "الرمز موجود بالفعل");
            }
            if (ModelState.IsValid)
            {
               
                _context.Add(nWC_Rreal_Estate_Type);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(nWC_Rreal_Estate_Type);
        }

        // GET: NWC_Rreal_Estate_Type/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.NWC_Rreal_Estate_Types == null)
            {
                return NotFound();
            }

            var nWC_Rreal_Estate_Type = await _context.NWC_Rreal_Estate_Types.FindAsync(id);
            if (nWC_Rreal_Estate_Type == null)
            {
                return NotFound();
            }
            return View(nWC_Rreal_Estate_Type);
        }

        // POST: NWC_Rreal_Estate_Type/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("NWC_Rreal_Estate_TypeID,NWC_Rreal_Estate_Type_Name,NWC_Rreal_Estate_Type_Reasons")] NWC_Rreal_Estate_Type nWC_Rreal_Estate_Type)
        {
            ModelState.Remove("NWC_Rreal_Estate_TypeID");
            if (_context.NWC_Rreal_Estate_Types.Any(x => x.NWC_Rreal_Estate_TypeID == nWC_Rreal_Estate_Type.NWC_Rreal_Estate_TypeID)) {
                ModelState.AddModelError("", "الرمز موجود بالفعل");
            }
                if (id != nWC_Rreal_Estate_Type.NWC_Rreal_Estate_TypeID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nWC_Rreal_Estate_Type);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NWC_Rreal_Estate_TypeExists(nWC_Rreal_Estate_Type.NWC_Rreal_Estate_TypeID))
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
            return View(nWC_Rreal_Estate_Type);
        }

        // GET: NWC_Rreal_Estate_Type/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.NWC_Rreal_Estate_Types == null)
            {
                return NotFound();
            }

            var nWC_Rreal_Estate_Type = await _context.NWC_Rreal_Estate_Types
                .FirstOrDefaultAsync(m => m.NWC_Rreal_Estate_TypeID == id);
            if (nWC_Rreal_Estate_Type == null)
            {
                return NotFound();
            }

            return View(nWC_Rreal_Estate_Type);
        }

        // POST: NWC_Rreal_Estate_Type/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.NWC_Rreal_Estate_Types == null)
            {
                return Problem("Entity set 'AppDbContext.NWC_Rreal_Estate_Types'  is null.");
            }
            var nWC_Rreal_Estate_Type = await _context.NWC_Rreal_Estate_Types.FindAsync(id);
            if (nWC_Rreal_Estate_Type != null)
            {
                _context.NWC_Rreal_Estate_Types.Remove(nWC_Rreal_Estate_Type);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NWC_Rreal_Estate_TypeExists(string id)
        {
          return (_context.NWC_Rreal_Estate_Types?.Any(e => e.NWC_Rreal_Estate_TypeID == id)).GetValueOrDefault();
        }
    }
}
