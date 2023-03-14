
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using InvoicesProject.APPDB;
using InvoicesProject.Models;

namespace InvoicesProject.Controllers
{
    public class NWC_Subscriber_FileController : Controller
    {
        private readonly AppDbContext _context;

        public NWC_Subscriber_FileController(AppDbContext context)
        {
            _context = context;
        }

        // GET: NWC_Subscriber_File
        public async Task<IActionResult> Index()
        {
              return _context.NWC_Subscriber_Files != null ? 
                          View(await _context.NWC_Subscriber_Files.ToListAsync()) :
                          Problem("Entity set 'AppDbContext.NWC_Subscriber_Files'  is null.");
        }

        // GET: NWC_Subscriber_File/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.NWC_Subscriber_Files == null)
            {
                return NotFound();
            }

            var nWC_Subscriber_File = await _context.NWC_Subscriber_Files
                .FirstOrDefaultAsync(m => m.NWC_Subscriber_FileId == id);
            if (nWC_Subscriber_File == null)
            {
                return NotFound();
            }

            return View(nWC_Subscriber_File);
        }

        // GET: NWC_Subscriber_File/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: NWC_Subscriber_File/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NWC_Subscriber_FileId,NWC_Subscriber_File_Name,NWC_Subscriber_File_City,NWC_Subscriber_File_Area,NWC_Subscriber_File_Mobile,NWC_Subscriber_File_Reasons")] NWC_Subscriber_File nWC_Subscriber_File)
        {
            if (_context.NWC_Subscriber_Files.Any(x => x.NWC_Subscriber_FileId == nWC_Subscriber_File.NWC_Subscriber_FileId)) {
                ModelState.AddModelError("", "الهوية موجودة بالفعل");
            }
            if (ModelState.IsValid)
            {
                _context.Add(nWC_Subscriber_File);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            
            return View(nWC_Subscriber_File);
        }

        // GET: NWC_Subscriber_File/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.NWC_Subscriber_Files == null)
            {
                return NotFound();
            }

            var nWC_Subscriber_File = await _context.NWC_Subscriber_Files.FindAsync(id);
            if (nWC_Subscriber_File == null)
            {
                return NotFound();
            }
            return View(nWC_Subscriber_File);
        }

        // POST: NWC_Subscriber_File/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("NWC_Subscriber_FileId,NWC_Subscriber_File_Name,NWC_Subscriber_File_City,NWC_Subscriber_File_Area,NWC_Subscriber_File_Mobile,NWC_Subscriber_File_Reasons")] NWC_Subscriber_File nWC_Subscriber_File)
        {
            if (id != nWC_Subscriber_File.NWC_Subscriber_FileId)
            {
                return NotFound();
            }
            if (_context.NWC_Subscriber_Files.Any(x => x.NWC_Subscriber_FileId == nWC_Subscriber_File.NWC_Subscriber_FileId)) {
                ModelState.AddModelError("", "الهوية موجودة بالفعل");
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nWC_Subscriber_File);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NWC_Subscriber_FileExists(nWC_Subscriber_File.NWC_Subscriber_FileId))
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
            return View(nWC_Subscriber_File);
        }

        // GET: NWC_Subscriber_File/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.NWC_Subscriber_Files == null)
            {
                return NotFound();
            }

            var nWC_Subscriber_File = await _context.NWC_Subscriber_Files
                .FirstOrDefaultAsync(m => m.NWC_Subscriber_FileId == id);
            if (nWC_Subscriber_File == null)
            {
                return NotFound();
            }

            return View(nWC_Subscriber_File);
        }

        // POST: NWC_Subscriber_File/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.NWC_Subscriber_Files == null)
            {
                return Problem("Entity set 'AppDbContext.NWC_Subscriber_Files'  is null.");
            }
            var nWC_Subscriber_File = await _context.NWC_Subscriber_Files.FindAsync(id);
            if (nWC_Subscriber_File != null)
            {
                _context.NWC_Subscriber_Files.Remove(nWC_Subscriber_File);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NWC_Subscriber_FileExists(string id)
        {
          return (_context.NWC_Subscriber_Files?.Any(e => e.NWC_Subscriber_FileId == id)).GetValueOrDefault();
        }
    }
}
