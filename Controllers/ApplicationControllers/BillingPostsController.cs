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

        // GET: BillingPosts/Details/5
        public async Task<IActionResult> Details(int? id)
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

        // GET: BillingPosts/Create
        public IActionResult Create()
        {
            ViewData["BPStatusId"] = new SelectList(_context.BPStatus, "Id", "BPStatusName");
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "FullName");
            return View();
        }

        // POST: BillingPosts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Customer,Incident,Started,Ended,Hours,Price,Total,Outlay,PersonId,Notes,WLNumber,PONumber,BPStatusId")] BillingPost billingPost)
        {
            if (ModelState.IsValid)
            {
                _context.Add(billingPost);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BPStatusId"] = new SelectList(_context.BPStatus, "Id", "BPStatusName", billingPost.BPStatusId);
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "FullName", billingPost.PersonId);
            return View(billingPost);
        }

        // GET: BillingPosts/Edit/5
        public async Task<IActionResult> Edit(int? id)
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
            ViewData["BPStatusId"] = new SelectList(_context.BPStatus, "Id", "BPStatusName", billingPost.BPStatusId);
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "FullName", billingPost.PersonId);
            return View(billingPost);
        }

        // POST: BillingPosts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Customer,Incident,Started,Ended,Hours,Price,Total,Outlay,PersonId,Notes,WLNumber,PONumber,BPStatusId")] BillingPost billingPost)
        {
            if (id != billingPost.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
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
                return RedirectToAction(nameof(Index));
            }
            ViewData["BPStatusId"] = new SelectList(_context.BPStatus, "Id", "BPStatusName", billingPost.BPStatusId);
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "FullName", billingPost.PersonId);
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
            return RedirectToAction(nameof(Index));
        }

        private bool BillingPostExists(int id)
        {
            return _context.BillingPost.Any(e => e.Id == id);
        }
    }
}
