using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using InvoicesProject.APPDB;
using InvoicesProject.Models;
using InvoicesProject.ViewModel;

namespace InvoicesProject.Controllers {
    public class NWC_InvoiceController : Controller {
        private readonly AppDbContext _context;

        public NWC_InvoiceController(AppDbContext context) {
            _context = context;
        }

        // GET: NWC_Invoice
        public async Task<IActionResult> Index() {
            var appDbContext = _context.NWC_Invoices.Include(n => n.NWC_Invoices_Subscriber_file).Include(n => n.NWC_Subscription);
            return View(await appDbContext.ToListAsync());
        }
        public ActionResult PrintAllInvoices() {
            var appDbContext = _context.NWC_Invoices.Include(n => n.NWC_Invoices_Subscriber_file).Include(n => n.NWC_Subscription);
            var report = new Rotativa.AspNetCore.ViewAsPdf("Index",appDbContext);
            return report;
        }

        // GET: NWC_Invoice/Details/5
        public async Task<IActionResult> Details(int id) {
            if (id == null || _context.NWC_Invoices == null) {
                return NotFound();
            }

            var nWC_Invoice = await _context.NWC_Invoices
                .Include(n => n.NWC_Invoices_Subscriber_file)
                .Include(n => n.NWC_Subscription)
                .FirstOrDefaultAsync(m => m.NWC_InvoiceID == id);
            if (nWC_Invoice == null) {
                return NotFound();
            }

            return View(nWC_Invoice);
        }

        // GET: NWC_Invoice/Create
        public IActionResult Create() {
            NWC_Invoice nwcinvoice = new();
            ViewData["NWC_Subscriber_FileID"] = new SelectList(_context.NWC_Subscriber_Files, "NWC_Subscriber_FileId", "NWC_Subscriber_FileId");
            ViewData["NWC_Subscription_FileID"] = new SelectList(_context.NWC_Subscription_Files, "NWC_Subscription_FileID", "NWC_Subscription_FileID");
            return View(nwcinvoice);
        }

        // POST: NWC_Invoice/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NWC_Invoice_Year,NWC_Rreal_Estate_TypeID,NWC_Subscription_FileID,NWC_Subscriber_FileID,NWC_Invoice_Date,NWC_Invoice_From,NWC_Invoice_To,NWC_Invoice_Previous_Consumption_Amount,NWC_Invoice_Current_Consumption_Amount,NWC_Invoice_Amount_Consumption,NWC_Invoice_Service_Fee,NWC_Invoice_Tax_Rate,NWC_Invoice_Is_There_Sanitation,NWC_Invoice_Consumption_Value,NWC_Invoice_Wastewater_Consumption_Value,NWC_Invoice_Total_Invoice,NWC_Invoice_Tax_Value,NWC_Invoice_Total_Bill,NWC_Invoice_Total_Reasons")] NWC_Invoice nWC_Invoice) {
            ModelState.Remove("NWC_InvoiceID");
            if (ModelState.IsValid) {
                _context.Add(nWC_Invoice);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["NWC_Subscriber_FileID"] = new SelectList(_context.NWC_Subscriber_Files, "NWC_Subscriber_FileId", "NWC_Subscriber_FileId", nWC_Invoice.NWC_Subscriber_FileID);
            ViewData["NWC_Subscription_FileID"] = new SelectList(_context.NWC_Subscription_Files, "NWC_Subscription_FileID", "NWC_Subscription_FileID", nWC_Invoice.NWC_Subscription_FileID);
            return View(nWC_Invoice);
        }

        // GET: NWC_Invoice/Edit/5
        public async Task<IActionResult> Edit(int id) {
            if (id == null || _context.NWC_Invoices == null) {
                return NotFound();
            }

            var nWC_Invoice = await _context.NWC_Invoices.FindAsync(id);
            if (nWC_Invoice == null) {
                return NotFound();
            }
            ViewData["NWC_Subscriber_FileID"] = new SelectList(_context.NWC_Subscriber_Files, "NWC_Subscriber_FileId", "NWC_Subscriber_FileId", nWC_Invoice.NWC_Subscriber_FileID);
            ViewData["NWC_Subscription_FileID"] = new SelectList(_context.NWC_Subscription_Files, "NWC_Subscription_FileID", "NWC_Subscription_FileID", nWC_Invoice.NWC_Subscription_FileID);
            return View(nWC_Invoice);
        }

        // POST: NWC_Invoice/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("NWC_InvoiceID,NWC_Invoice_Year,NWC_Rreal_Estate_TypeID,NWC_Subscription_FileID,NWC_Subscriber_FileID,NWC_Invoice_Date,NWC_Invoice_From,NWC_Invoice_To,NWC_Invoice_Previous_Consumption_Amount,NWC_Invoice_Current_Consumption_Amount,NWC_Invoice_Amount_Consumption,NWC_Invoice_Service_Fee,NWC_Invoice_Tax_Rate,NWC_Invoice_Is_There_Sanitation,NWC_Invoice_Consumption_Value,NWC_Invoice_Wastewater_Consumption_Value,NWC_Invoice_Total_Invoice,NWC_Invoice_Tax_Value,NWC_Invoice_Total_Bill,NWC_Invoice_Total_Reasons")] NWC_Invoice nWC_Invoice) {
            if (id != nWC_Invoice.NWC_InvoiceID) {
                return NotFound();
            }

            if (ModelState.IsValid) {
                try {
                    _context.Update(nWC_Invoice);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException) {
                    if (!NWC_InvoiceExists(nWC_Invoice.NWC_InvoiceID)) {
                        return NotFound();
                    }
                    else {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["NWC_Subscriber_FileID"] = new SelectList(_context.NWC_Subscriber_Files, "NWC_Subscriber_FileId", "NWC_Subscriber_FileId", nWC_Invoice.NWC_Subscriber_FileID);
            ViewData["NWC_Subscription_FileID"] = new SelectList(_context.NWC_Subscription_Files, "NWC_Subscription_FileID", "NWC_Subscription_FileID", nWC_Invoice.NWC_Subscription_FileID);
            return View(nWC_Invoice);
        }

        // GET: NWC_Invoice/Delete/5
        public async Task<IActionResult> Delete(int id) {
            if (id == null || _context.NWC_Invoices == null) {
                return NotFound();
            }

            var nWC_Invoice = await _context.NWC_Invoices
                .Include(n => n.NWC_Invoices_Subscriber_file)
                .Include(n => n.NWC_Subscription)
                .FirstOrDefaultAsync(m => m.NWC_InvoiceID == id);
            if (nWC_Invoice == null) {
                return NotFound();
            }

            return View(nWC_Invoice);
        }

        // POST: NWC_Invoice/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id) {
            if (_context.NWC_Invoices == null) {
                return Problem("Entity set 'AppDbContext.NWC_Invoices'  is null.");
            }
            var nWC_Invoice = await _context.NWC_Invoices.FindAsync(id);
            if (nWC_Invoice != null) {
                _context.NWC_Invoices.Remove(nWC_Invoice);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NWC_InvoiceExists(int id) {
            return (_context.NWC_Invoices?.Any(e => e.NWC_InvoiceID == id)).GetValueOrDefault();
        }
        [HttpPost]
        public ActionResult GetIdentity(string NWC_Subscription_FileID) {
            var subscriptiononly = _context.NWC_Subscription_Files.Where(x => x.NWC_Subscription_FileID.ToString() == NWC_Subscription_FileID).FirstOrDefault();
            if (subscriptiononly != null) {
                var subscriperid = subscriptiononly.NWC_Subscription_File_SubscriberID;
                var realstateidid = subscriptiononly.NWC_Rreal_Estate_TypesID;
                var subscriper = _context.NWC_Subscriber_Files.Where(x => x.NWC_Subscriber_FileId == subscriperid).FirstOrDefault();
                var realstate = _context.NWC_Rreal_Estate_Types.Where(x => x.NWC_Rreal_Estate_TypeID == realstateidid).FirstOrDefault();
                InvoiceVM subscription = new() {
                    NWC_Subscriber_FileID = subscriper.NWC_Subscriber_FileId,
                    NWC_Invoice_Is_There_Sanitation = subscriptiononly.NWC_Subscription_File_Is_There_Sanitation,
                    NWC_Subscriber_File_Name = subscriper.NWC_Subscriber_File_Name,
                    NWC_Invoice_Previous_Consumption_Amount = subscriptiononly.NWC_Subscription_File_Last_Reading_Meter,
                    NWC_Subscription_File_Unit_No = subscriptiononly.NWC_Subscription_File_Unit_No,
                    
                };

                return Json(subscription);
            }
            return Json(null);
        }

        [HttpPost]
        public ActionResult CalculateBill(string subscriptionid,
            string Current_Consumption_Amount,
            string Service_Fee,
            string Tax_Rate,
            string Is_There_Sanitation,
            string NWC_Invoice_Previous_Consumption_Amount) 
        {
            InvoiceVM viewmodel=new InvoiceVM();
            var subscriptiononly = _context.NWC_Subscription_Files.Where(x => x.NWC_Subscription_FileID.ToString() == subscriptionid).FirstOrDefault();
            if(subscriptiononly != null)
            {
                var unitno = subscriptiononly.NWC_Subscription_File_Unit_No;

                    var x=Convert.ToInt32(Current_Consumption_Amount);
                    viewmodel.NWC_Invoice_Amount_Consumption = Convert.ToInt32(Current_Consumption_Amount) - Convert.ToInt32(NWC_Invoice_Previous_Consumption_Amount);
                    var amount = viewmodel.NWC_Invoice_Amount_Consumption;
                    if (subscriptiononly.NWC_Subscription_File_Unit_No <=0) 
                    {
                        viewmodel.NWC_Invoice_Total_Bill = 0;
                        viewmodel.NWC_Invoice_Total_Invoice = Convert.ToDecimal(Service_Fee) + (Convert.ToDecimal(Service_Fee) * Convert.ToDecimal(Tax_Rate));
                        viewmodel.NWC_Invoice_Tax_Value = (Convert.ToDecimal(Service_Fee) * Convert.ToDecimal(Tax_Rate));
                    }
                    else if (amount / (15m * subscriptiononly.NWC_Subscription_File_Unit_No ) <= 1)
                    {
                        if (Is_There_Sanitation == "true") 
                        {var slice= _context.NWC_Default_Slice_Values.FirstOrDefault(x => x.NWC_Default_Slice_Value_Condtion == 15);
                            viewmodel.NWC_Invoice_Total_Bill = 1.5m*amount*slice.NWC_Default_Slice_Value_Water_Price;
                            viewmodel.NWC_Invoice_Total_Invoice = viewmodel.NWC_Invoice_Total_Bill + (Convert.ToDecimal(Tax_Rate) + 1) * Convert.ToDecimal(Service_Fee);
                            viewmodel.NWC_Invoice_Wastewater_Consumption_Value=0.5m*amount * slice.NWC_Default_Slice_Value_Water_Price;
                            viewmodel.NWC_Invoice_Consumption_Value=amount* slice.NWC_Default_Slice_Value_Water_Price;
                        }
                        else 
                        {
                            var slice = _context.NWC_Default_Slice_Values.FirstOrDefault(x => x.NWC_Default_Slice_Value_Condtion == 15);
                            viewmodel.NWC_Invoice_Total_Bill = amount * slice.NWC_Default_Slice_Value_Water_Price;
                            viewmodel.NWC_Invoice_Total_Invoice = viewmodel.NWC_Invoice_Total_Bill + (Convert.ToDecimal(Tax_Rate)+1) * Convert.ToDecimal(Service_Fee);
                            viewmodel.NWC_Invoice_Consumption_Value = amount * slice.NWC_Default_Slice_Value_Water_Price;
                        }
                    }
                    else if(amount / (15m * subscriptiononly.NWC_Subscription_File_Unit_No) <= 2) 
                    {
                        if (Is_There_Sanitation == "true") {
                            var slice1 = _context.NWC_Default_Slice_Values.FirstOrDefault(x => x.NWC_Default_Slice_Value_Condtion == 15);
                            var slice2 = _context.NWC_Default_Slice_Values.FirstOrDefault(x => x.NWC_Default_Slice_Value_Condtion == 30);
                            viewmodel.NWC_Invoice_Total_Bill = 1.5m *((15*unitno)* slice1.NWC_Default_Slice_Value_Water_Price
                                                               +
                                                               (amount-15*unitno)*slice2.NWC_Default_Slice_Value_Water_Price);
                            viewmodel.NWC_Invoice_Total_Invoice = viewmodel.NWC_Invoice_Total_Bill+(Convert.ToDecimal(Tax_Rate) + 1) * Convert.ToDecimal(Service_Fee);
                            viewmodel.NWC_Invoice_Wastewater_Consumption_Value = viewmodel.NWC_Invoice_Total_Bill * (1/3m);
                            viewmodel.NWC_Invoice_Consumption_Value = viewmodel.NWC_Invoice_Total_Bill - viewmodel.NWC_Invoice_Wastewater_Consumption_Value;
                        }
                        else {
                            var slice1 = _context.NWC_Default_Slice_Values.FirstOrDefault(x => x.NWC_Default_Slice_Value_Condtion == 15);
                            var slice2 = _context.NWC_Default_Slice_Values.FirstOrDefault(x => x.NWC_Default_Slice_Value_Condtion == 30);
                            viewmodel.NWC_Invoice_Total_Bill = ((15 * unitno) * slice1.NWC_Default_Slice_Value_Water_Price
                                                               +
                                                               (amount - 15 * unitno) * slice2.NWC_Default_Slice_Value_Water_Price);
                            viewmodel.NWC_Invoice_Total_Invoice = viewmodel.NWC_Invoice_Total_Bill + (Convert.ToDecimal(Tax_Rate) + 1) * Convert.ToDecimal(Service_Fee);
                            viewmodel.NWC_Invoice_Consumption_Value = viewmodel.NWC_Invoice_Total_Bill ;
                        }
                    }
                    else if (amount / (15m * subscriptiononly.NWC_Subscription_File_Unit_No) <= 3) {
                        if (Is_There_Sanitation == "true") {
                            var slice1 = _context.NWC_Default_Slice_Values.FirstOrDefault(x => x.NWC_Default_Slice_Value_Condtion == 15);
                            var slice2 = _context.NWC_Default_Slice_Values.FirstOrDefault(x => x.NWC_Default_Slice_Value_Condtion == 30);
                            var slice3 = _context.NWC_Default_Slice_Values.FirstOrDefault(x => x.NWC_Default_Slice_Value_Condtion == 45);
                            viewmodel.NWC_Invoice_Total_Bill = 1.5m * ((15 * unitno) * slice1.NWC_Default_Slice_Value_Water_Price
                                                               +
                                                               (15 * unitno) * slice2.NWC_Default_Slice_Value_Water_Price 
                                                               +(amount-15*unitno)*slice3.NWC_Default_Slice_Value_Water_Price);
                            viewmodel.NWC_Invoice_Total_Invoice = viewmodel.NWC_Invoice_Total_Bill + (Convert.ToDecimal(Tax_Rate) + 1) * Convert.ToDecimal(Service_Fee);
                            viewmodel.NWC_Invoice_Wastewater_Consumption_Value = viewmodel.NWC_Invoice_Total_Bill * (1 / 3m);
                            viewmodel.NWC_Invoice_Consumption_Value = viewmodel.NWC_Invoice_Total_Bill - viewmodel.NWC_Invoice_Wastewater_Consumption_Value;
                        }
                        else {
                            var slice1 = _context.NWC_Default_Slice_Values.FirstOrDefault(x => x.NWC_Default_Slice_Value_Condtion == 15);
                            var slice2 = _context.NWC_Default_Slice_Values.FirstOrDefault(x => x.NWC_Default_Slice_Value_Condtion == 30);
                            var slice3 = _context.NWC_Default_Slice_Values.FirstOrDefault(x => x.NWC_Default_Slice_Value_Condtion == 45);
                            viewmodel.NWC_Invoice_Total_Bill = ((15 * unitno) * slice1.NWC_Default_Slice_Value_Water_Price
                                                               +
                                                               (15 * unitno) * slice2.NWC_Default_Slice_Value_Water_Price
                                                               + (amount - 15*unitno) * slice3.NWC_Default_Slice_Value_Water_Price);
                            viewmodel.NWC_Invoice_Total_Invoice = viewmodel.NWC_Invoice_Total_Bill + (Convert.ToDecimal(Tax_Rate) + 1) * Convert.ToDecimal(Service_Fee);
                            viewmodel.NWC_Invoice_Consumption_Value = viewmodel.NWC_Invoice_Total_Bill;
                        }
                    }
                    else if (amount / (15m * subscriptiononly.NWC_Subscription_File_Unit_No) <= 4) {
                        if (Is_There_Sanitation == "true") {
                            var slice1 = _context.NWC_Default_Slice_Values.FirstOrDefault(x => x.NWC_Default_Slice_Value_Condtion == 15);
                            var slice2 = _context.NWC_Default_Slice_Values.FirstOrDefault(x => x.NWC_Default_Slice_Value_Condtion == 30);
                            var slice3 = _context.NWC_Default_Slice_Values.FirstOrDefault(x => x.NWC_Default_Slice_Value_Condtion == 45);
                            var slice4 = _context.NWC_Default_Slice_Values.FirstOrDefault(x => x.NWC_Default_Slice_Value_Condtion == 60);
                            viewmodel.NWC_Invoice_Total_Bill = 1.5m * ((15 * unitno) * slice1.NWC_Default_Slice_Value_Water_Price
                                                               +
                                                               (15 * unitno) * slice2.NWC_Default_Slice_Value_Water_Price
                                                               + (15 * unitno) * slice3.NWC_Default_Slice_Value_Water_Price
                                                               +(amount-15*unitno)*slice4.NWC_Default_Slice_Value_Water_Price);
                            viewmodel.NWC_Invoice_Total_Invoice = viewmodel.NWC_Invoice_Total_Bill + (Convert.ToDecimal(Tax_Rate) + 1) * Convert.ToDecimal(Service_Fee);
                            viewmodel.NWC_Invoice_Wastewater_Consumption_Value = viewmodel.NWC_Invoice_Total_Bill * (1 / 3m);
                            viewmodel.NWC_Invoice_Consumption_Value = viewmodel.NWC_Invoice_Total_Bill - viewmodel.NWC_Invoice_Wastewater_Consumption_Value;
                        }
                        else {
                            var slice1 = _context.NWC_Default_Slice_Values.FirstOrDefault(x => x.NWC_Default_Slice_Value_Condtion == 15);
                            var slice2 = _context.NWC_Default_Slice_Values.FirstOrDefault(x => x.NWC_Default_Slice_Value_Condtion == 30);
                            var slice3 = _context.NWC_Default_Slice_Values.FirstOrDefault(x => x.NWC_Default_Slice_Value_Condtion == 45);
                            var slice4 = _context.NWC_Default_Slice_Values.FirstOrDefault(x => x.NWC_Default_Slice_Value_Condtion == 60);
                            viewmodel.NWC_Invoice_Total_Bill =  ((15 * unitno) * slice1.NWC_Default_Slice_Value_Water_Price
                                                               +
                                                               (15 * unitno) * slice2.NWC_Default_Slice_Value_Water_Price
                                                               + (15 * unitno) * slice3.NWC_Default_Slice_Value_Water_Price
                                                               + (amount - 15*unitno) * slice4.NWC_Default_Slice_Value_Water_Price);
                            viewmodel.NWC_Invoice_Total_Invoice = viewmodel.NWC_Invoice_Total_Bill + (Convert.ToDecimal(Tax_Rate) + 1) * Convert.ToDecimal(Service_Fee);
                            viewmodel.NWC_Invoice_Consumption_Value = viewmodel.NWC_Invoice_Total_Bill;
                        }
                    }
                    else {
                        if (Is_There_Sanitation == "true") {
                            var slice1 = _context.NWC_Default_Slice_Values.FirstOrDefault(x => x.NWC_Default_Slice_Value_Condtion == 15);
                            var slice2 = _context.NWC_Default_Slice_Values.FirstOrDefault(x => x.NWC_Default_Slice_Value_Condtion == 30);
                            var slice3 = _context.NWC_Default_Slice_Values.FirstOrDefault(x => x.NWC_Default_Slice_Value_Condtion == 45);
                            var slice4 = _context.NWC_Default_Slice_Values.FirstOrDefault(x => x.NWC_Default_Slice_Value_Condtion == 60);
                            var slice5 = _context.NWC_Default_Slice_Values.FirstOrDefault(x => x.NWC_Default_Slice_Value_Condtion>60);
                            viewmodel.NWC_Invoice_Total_Bill = 1.5m * ((15*unitno) * slice1.NWC_Default_Slice_Value_Water_Price
                                                               +
                                                               (15 * unitno) * slice2.NWC_Default_Slice_Value_Water_Price
                                                               + (15 * unitno) * slice3.NWC_Default_Slice_Value_Water_Price
                                                               + (15 * unitno) * slice4.NWC_Default_Slice_Value_Water_Price
                                                               +(amount - 15*unitno) * slice5.NWC_Default_Slice_Value_Water_Price);
                            viewmodel.NWC_Invoice_Total_Invoice = viewmodel.NWC_Invoice_Total_Bill + (Convert.ToDecimal(Tax_Rate) + 1) * Convert.ToDecimal(Service_Fee);
                            viewmodel.NWC_Invoice_Wastewater_Consumption_Value = viewmodel.NWC_Invoice_Total_Bill * (1 / 3m);
                            viewmodel.NWC_Invoice_Consumption_Value = viewmodel.NWC_Invoice_Total_Bill - viewmodel.NWC_Invoice_Wastewater_Consumption_Value;
                        }
                        else {
                            var slice1 = _context.NWC_Default_Slice_Values.FirstOrDefault(x => x.NWC_Default_Slice_Value_Condtion == 15);
                            var slice2 = _context.NWC_Default_Slice_Values.FirstOrDefault(x => x.NWC_Default_Slice_Value_Condtion == 30);
                            var slice3 = _context.NWC_Default_Slice_Values.FirstOrDefault(x => x.NWC_Default_Slice_Value_Condtion == 45);
                            var slice4 = _context.NWC_Default_Slice_Values.FirstOrDefault(x => x.NWC_Default_Slice_Value_Condtion == 60);
                            var slice5 = _context.NWC_Default_Slice_Values.FirstOrDefault(x => x.NWC_Default_Slice_Value_Condtion > 60);
                            viewmodel.NWC_Invoice_Total_Bill = ((15*unitno) * slice1.NWC_Default_Slice_Value_Water_Price
                                                               +
                                                               (15 * unitno) * slice2.NWC_Default_Slice_Value_Water_Price
                                                               + (15 * unitno) * slice3.NWC_Default_Slice_Value_Water_Price
                                                               + (15 * unitno) * slice4.NWC_Default_Slice_Value_Water_Price
                                                               + (amount - 15*unitno) * slice5.NWC_Default_Slice_Value_Water_Price);
                            viewmodel.NWC_Invoice_Total_Invoice = viewmodel.NWC_Invoice_Total_Bill + (Convert.ToDecimal(Tax_Rate) + 1) * Convert.ToDecimal(Service_Fee);
                            viewmodel.NWC_Invoice_Consumption_Value = viewmodel.NWC_Invoice_Total_Bill;
                        }
                    }

                viewmodel.NWC_Invoice_Tax_Value = Convert.ToDecimal(Tax_Rate) * Convert.ToDecimal(Service_Fee);
                return Json(viewmodel);

            }

            return Json(null);
        }
       
    }
}
