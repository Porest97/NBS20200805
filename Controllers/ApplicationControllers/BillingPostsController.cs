using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NBS.Data;
using NBS.Models.DataModels;

namespace NBS.Controllers.ApplicationControllers
{
    public class BillingPostsController : Controller
    {
        private readonly NBSContext _context;

        public BillingPostsController(NBSContext context)
        {
            _context = context;
        }

        // GET: BillingPosts
        public async Task<IActionResult> Index()
        {
            var nBSContext = _context.BillingPost
                .Include(b => b.BPStatus)
                .Include(b => b.Employee);
            return View(await nBSContext.ToListAsync());
        }

        // GET: BillingPost/Details/Id
        public async Task<IActionResult> DetailsBillingPost(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var billingPost = await _context.BillingPost
                .Include(b => b.BPStatus)
                .Include(b => b.Employee)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (billingPost == null)
            {
                return NotFound();
            }

            return View(billingPost);
        }

        /// <summary>
        /// BillingPosts => Is a post that We use for billing customers
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// 
        // GET: BillingPosts/CreateBillingPost        
        public IActionResult CreateBillingPost()
        {
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "FullName");
            ViewData["BPStatusId"] = new SelectList(_context.BPStatus, "Id", "BPStatusName");
            return View();
        }

        // POST: BillingPost/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateBillingPost([Bind("Id,Customer,Incident,Started,Ended,Hours,Price,Total,Outlay,PersonId,Notes,WLNumber,BPStatusId,PONumber")] BillingPost billingPost)
        {
            if (ModelState.IsValid)
            {
                var nBSContext = _context.BillingPost
                 .Include(t => t.BPStatus)
                 .Include(t => t.Employee);
                billingPost.Total = (billingPost.Hours * billingPost.Price) + billingPost.Outlay;

                _context.Add(billingPost);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(ListBillingPosts));
            }

            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "FullName", billingPost.PersonId);
            ViewData["BPStatusId"] = new SelectList(_context.BPStatus, "Id", "BPStatusName");
            return View(billingPost);
        }

        // GET: ListBillingPosts - search
        public async Task<IActionResult> ListBillingPosts
        (string searchString, string searchString1, string searchString2, string searchString3, string searchString4, string searchString5)
        {
            var billingPosts = from t in _context.BillingPost
                .Include(t => t.Employee)
                .Include(t => t.BPStatus).Where(t => t.BPStatusId < 10)

                               select t;

            if (!String.IsNullOrEmpty(searchString))
            {
                billingPosts = billingPosts
                .Include(t => t.Employee)
                .Include(t => t.BPStatus).Where(t => t.BPStatusId < 10)
                .Where(s => s.PONumber.Contains(searchString));

            }
            if (!String.IsNullOrEmpty(searchString1))
            {
                billingPosts = billingPosts
                .Include(t => t.Employee)
                .Include(t => t.BPStatus).Where(t => t.BPStatusId < 10)
                .Where(s => s.Employee.LastName.Contains(searchString1));

            }
            if (!String.IsNullOrEmpty(searchString2))
            {
                billingPosts = billingPosts
                .Include(t => t.Employee)
                .Include(t => t.BPStatus).Where(t => t.BPStatusId < 10)
                .Where(s => s.Incident.Contains(searchString2));

            }
            if (!String.IsNullOrEmpty(searchString3))
            {
                billingPosts = billingPosts
                .Include(t => t.Employee)
                .Include(t => t.BPStatus).Where(t => t.BPStatusId < 10)
                .Where(s => s.Ended.ToString().Contains(searchString3));

            }
            if (!String.IsNullOrEmpty(searchString4))
            {
                billingPosts = billingPosts
                .Include(t => t.Employee)
                .Include(t => t.BPStatus).Where(t => t.BPStatusId < 10)
                .Where(s => s.BPStatus.BPStatusName.Contains(searchString4));

            }
            if (!String.IsNullOrEmpty(searchString5))
            {
                billingPosts = billingPosts
                .Include(t => t.Employee)
                .Include(t => t.BPStatus).Where(t => t.BPStatusId < 10)
                .Where(s => s.Customer.Contains(searchString5));

            }
            return View(await billingPosts.ToListAsync());
        }

        // GET: BillingPost/EditBillingPost
        public async Task<IActionResult> EditBillingPost(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var billingPost = await _context.BillingPost.FindAsync(id);
            if (billingPost == null)
            {
                return NotFound();
            }

            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "FullName", billingPost.PersonId);
            ViewData["BPStatusId"] = new SelectList(_context.BPStatus, "Id", "BPStatusName", billingPost.BPStatusId);
            return View(billingPost);
        }

        // POST: BillingPost/EditStatus        
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditBillingPost(int id, [Bind("Id,Customer,Incident,Started,Ended,Hours,Price,Total,Outlay,PersonId,Notes,WLNumber,BPStatusId,PONumber")] BillingPost billingPost)
        {
            if (id != billingPost.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var nBSContext = _context.BillingPost
                 .Include(t => t.BPStatus)
                 .Include(t => t.Employee);
                    billingPost.Total = (billingPost.Hours * billingPost.Price) + billingPost.Outlay;

                    _context.Update(billingPost);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BillingPostExists(billingPost.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(ListBillingPosts));
            }
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "FullName", billingPost.PersonId);
            ViewData["BPStatusId"] = new SelectList(_context.BPStatus, "Id", "BPStatusName", billingPost.BPStatusId);
            return View(billingPost);
        }
        // POST: TimBanksPost/EditStatus        
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditBillingPostStatus(int id, [Bind("Id,Customer,Incident,Started,Ended,Hours,Price,Total,Outlay,PersonId,Notes,WLNumber,BPStatusId,PONumber")] BillingPost billingPost)
        {
            if (id != billingPost.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var nBSContext = _context.BillingPost
                 .Include(t => t.BPStatus)
                 .Include(t => t.Employee);
                    billingPost.Total = (billingPost.Hours * billingPost.Price) + billingPost.Outlay;

                    _context.Update(billingPost);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BillingPostExists(billingPost.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(ListBillingPosts));
            }
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "FullName", billingPost.PersonId);
            ViewData["BPStatusId"] = new SelectList(_context.BPStatus, "Id", "BPStatusName", billingPost.BPStatusId);
            return View(billingPost);
        }

        // GET: BillingPost/EditBillingPostEmployee
        public async Task<IActionResult> EditBillingPostEmployee(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var billingPost = await _context.BillingPost.FindAsync(id);
            if (billingPost == null)
            {
                return NotFound();
            }

            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "FullName", billingPost.PersonId);
            ViewData["BPStatusId"] = new SelectList(_context.BPStatus, "Id", "BPStatusName", billingPost.BPStatusId);
            return View(billingPost);
        }

        // POST: BillingPost/EditBillingPostEmployee       
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditBillingPostEmployee(int id, [Bind("Id,Customer,Incident,Started,Ended,Hours,Price,Total,Outlay,PersonId,Notes,WLNumber,BPStatusId,PONumber")] BillingPost billingPost)
        {
            if (id != billingPost.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var nBSContext = _context.BillingPost
                 .Include(t => t.BPStatus)
                 .Include(t => t.Employee);
                    billingPost.Total = (billingPost.Hours * billingPost.Price) + billingPost.Outlay;

                    _context.Update(billingPost);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BillingPostExists(billingPost.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(ListBillingPosts));
            }
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "FullName", billingPost.PersonId);
            ViewData["BPStatusId"] = new SelectList(_context.BPStatus, "Id", "BPStatusName", billingPost.BPStatusId);
            return View(billingPost);
        }

        // GET: BillingPosts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var billingPost = await _context.BillingPost
                .Include(b => b.BPStatus)
                .Include(b => b.Employee)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (billingPost == null)
            {
                return NotFound();
            }

            return View(billingPost);
        }

        // POST: BillingPosts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var billingPost = await _context.BillingPost.FindAsync(id);
            _context.BillingPost.Remove(billingPost);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(ListBillingPosts));
        }

        private bool BillingPostExists(int id)
        {
            return _context.BillingPost.Any(e => e.Id == id);
        }
    }
}
