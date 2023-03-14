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
    public class NWC_Subscription_FileController : Controller
    {
        private readonly AppDbContext _context;

        public NWC_Subscription_FileController(AppDbContext context)
        {
            _context = context;
        }

        // GET: NWC_Subscription_File
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.NWC_Subscription_Files.Include(n => n.NWC_Rreal_Estate_Types).Include(n => n.NWC_Subscription_File_Subscriber);
            return View(await appDbContext.ToListAsync());
        }

        // GET: NWC_Subscription_File/Details/5
        public async Task<IActionResult> Details(int id)
        {
            if (id == null || _context.NWC_Subscription_Files == null)
            {
                return NotFound();
            }

            var nWC_Subscription_File = await _context.NWC_Subscription_Files
                .Include(n => n.NWC_Rreal_Estate_Types)
                .Include(n => n.NWC_Subscription_File_Subscriber)
                .FirstOrDefaultAsync(m => m.NWC_Subscription_FileID == id);
            if (nWC_Subscription_File == null)
            {
                return NotFound();
            }

            return View(nWC_Subscription_File);
        }

        // GET: NWC_Subscription_File/Create
        public IActionResult Create()
        {
            ViewData["NWC_Rreal_Estate_TypesID"] = new SelectList(_context.NWC_Rreal_Estate_Types, "NWC_Rreal_Estate_TypeID", "NWC_Rreal_Estate_Type_Name");
            ViewData["NWC_Subscription_File_SubscriberID"] = new SelectList(_context.NWC_Subscriber_Files, "NWC_Subscriber_FileId", "NWC_Subscriber_FileId");
            return View();
        }

        // POST: NWC_Subscription_File/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NWC_Subscription_File_SubscriberID,NWC_Rreal_Estate_TypesID,NWC_Subscription_File_Unit_No,NWC_Subscription_File_Is_There_Sanitation,NWC_Subscription_File_Last_Reading_Meter,NWC_Subscription_File_Reasons")] NWC_Subscription_File nWC_Subscription_File)
        {
            ModelState.Remove("NWC_Subscription_FileID");
            if (ModelState.IsValid)
            {
                _context.Add(nWC_Subscription_File);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["NWC_Rreal_Estate_TypesID"] = new SelectList(_context.NWC_Rreal_Estate_Types, "NWC_Rreal_Estate_TypeID", "NWC_Rreal_Estate_Type_Name", nWC_Subscription_File.NWC_Rreal_Estate_TypesID);
            ViewData["NWC_Subscription_File_SubscriberID"] = new SelectList(_context.NWC_Subscriber_Files, "NWC_Subscriber_FileId", "NWC_Subscriber_FileId", nWC_Subscription_File.NWC_Subscription_File_SubscriberID);
            return View(nWC_Subscription_File);
        }

        // GET: NWC_Subscription_File/Edit/5
        public async Task<IActionResult> Edit(char id)
        {
            if (id == null || _context.NWC_Subscription_Files == null)
            {
                return NotFound();
            }

            var nWC_Subscription_File = await _context.NWC_Subscription_Files.FindAsync(id);
            if (nWC_Subscription_File == null)
            {
                return NotFound();
            }
            ViewData["NWC_Rreal_Estate_TypesID"] = new SelectList(_context.NWC_Rreal_Estate_Types, "NWC_Rreal_Estate_TypeID", "NWC_Rreal_Estate_Type_Name", nWC_Subscription_File.NWC_Rreal_Estate_TypesID);
            ViewData["NWC_Subscription_File_SubscriberID"] = new SelectList(_context.NWC_Subscriber_Files, "NWC_Subscriber_FileId", "NWC_Subscriber_FileId", nWC_Subscription_File.NWC_Subscription_File_SubscriberID);
            return View(nWC_Subscription_File);
        }

        // POST: NWC_Subscription_File/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("NWC_Subscription_FileID,NWC_Subscription_File_SubscriberID,NWC_Rreal_Estate_TypesID,NWC_Subscription_File_Unit_No,NWC_Subscription_File_Is_There_Sanitation,NWC_Subscription_File_Last_Reading_Meter,NWC_Subscription_File_Reasons")] NWC_Subscription_File nWC_Subscription_File)
        {
            if (id != nWC_Subscription_File.NWC_Subscription_FileID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nWC_Subscription_File);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NWC_Subscription_FileExists(nWC_Subscription_File.NWC_Subscription_FileID))
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
            ViewData["NWC_Rreal_Estate_TypesID"] = new SelectList(_context.NWC_Rreal_Estate_Types, "NWC_Rreal_Estate_TypeID", "NWC_Rreal_Estate_Type_Name", nWC_Subscription_File.NWC_Rreal_Estate_TypesID);
            ViewData["NWC_Subscription_File_SubscriberID"] = new SelectList(_context.NWC_Subscriber_Files, "NWC_Subscriber_FileId", "NWC_Subscriber_FileId", nWC_Subscription_File.NWC_Subscription_File_SubscriberID);
            return View(nWC_Subscription_File);
        }

        // GET: NWC_Subscription_File/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null || _context.NWC_Subscription_Files == null)
            {
                return NotFound();
            }

            var nWC_Subscription_File = await _context.NWC_Subscription_Files
                .Include(n => n.NWC_Rreal_Estate_Types)
                .Include(n => n.NWC_Subscription_File_Subscriber)
                .FirstOrDefaultAsync(m => m.NWC_Subscription_FileID == id);
            if (nWC_Subscription_File == null)
            {
                return NotFound();
            }

            return View(nWC_Subscription_File);
        }

        // POST: NWC_Subscription_File/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.NWC_Subscription_Files == null)
            {
                return Problem("Entity set 'AppDbContext.NWC_Subscription_Files'  is null.");
            }
            var nWC_Subscription_File = await _context.NWC_Subscription_Files.FindAsync(id);
            if (nWC_Subscription_File != null)
            {
                _context.NWC_Subscription_Files.Remove(nWC_Subscription_File);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NWC_Subscription_FileExists(int id)
        {
          return (_context.NWC_Subscription_Files?.Any(e => e.NWC_Subscription_FileID == id)).GetValueOrDefault();
        }
    }
}
