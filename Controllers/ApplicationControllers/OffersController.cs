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
    public class OffersController : Controller
    {
        private readonly NBSContext _context;

        public OffersController(NBSContext context)
        {
            _context = context;
        }

        // GET: Offers
        public async Task<IActionResult> Index()
        {
            var nBSContext = _context.Offer.Include(o => o.Employee).Include(o => o.Incident).Include(o => o.OfferStatus).Include(o => o.Site);
            return View(await nBSContext.ToListAsync());
        }

        // GET: Offers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var offer = await _context.Offer
                .Include(o => o.Employee)
                .Include(o => o.Incident)
                .Include(o => o.OfferStatus)
                .Include(o => o.Site)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (offer == null)
            {
                return NotFound();
            }

            return View(offer);
        }

        // GET: Offers/Create
        public IActionResult Create()
        {
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "Id");
            ViewData["IncidentId"] = new SelectList(_context.Incident, "Id", "Id");
            ViewData["OfferStatusId"] = new SelectList(_context.OfferStatus, "Id", "Id");
            ViewData["SiteId"] = new SelectList(_context.Site, "Id", "Id");
            return View();
        }

        // POST: Offers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,OfferIdenifyer,DateTimeOffered,OfferStatusId,PersonId,SiteId,IncidentId,DateTimeScheduledStart,DateTimeScheduledEnd,HoursOnSite,PricePerHour,KostHours,KostMtrl,Riskfaktor,TotalOfferAmount,File")] Offer offer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(offer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "Id", offer.PersonId);
            ViewData["IncidentId"] = new SelectList(_context.Incident, "Id", "Id", offer.IncidentId);
            ViewData["OfferStatusId"] = new SelectList(_context.OfferStatus, "Id", "Id", offer.OfferStatusId);
            ViewData["SiteId"] = new SelectList(_context.Site, "Id", "Id", offer.SiteId);
            return View(offer);
        }

        // GET: Offers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var offer = await _context.Offer.FindAsync(id);
            if (offer == null)
            {
                return NotFound();
            }
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "Id", offer.PersonId);
            ViewData["IncidentId"] = new SelectList(_context.Incident, "Id", "Id", offer.IncidentId);
            ViewData["OfferStatusId"] = new SelectList(_context.OfferStatus, "Id", "Id", offer.OfferStatusId);
            ViewData["SiteId"] = new SelectList(_context.Site, "Id", "Id", offer.SiteId);
            return View(offer);
        }

        // POST: Offers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,OfferIdenifyer,DateTimeOffered,OfferStatusId,PersonId,SiteId,IncidentId,DateTimeScheduledStart,DateTimeScheduledEnd,HoursOnSite,PricePerHour,KostHours,KostMtrl,Riskfaktor,TotalOfferAmount,File")] Offer offer)
        {
            if (id != offer.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(offer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OfferExists(offer.Id))
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
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "Id", offer.PersonId);
            ViewData["IncidentId"] = new SelectList(_context.Incident, "Id", "Id", offer.IncidentId);
            ViewData["OfferStatusId"] = new SelectList(_context.OfferStatus, "Id", "Id", offer.OfferStatusId);
            ViewData["SiteId"] = new SelectList(_context.Site, "Id", "Id", offer.SiteId);
            return View(offer);
        }

        // GET: Offers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var offer = await _context.Offer
                .Include(o => o.Employee)
                .Include(o => o.Incident)
                .Include(o => o.OfferStatus)
                .Include(o => o.Site)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (offer == null)
            {
                return NotFound();
            }

            return View(offer);
        }

        // POST: Offers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var offer = await _context.Offer.FindAsync(id);
            _context.Offer.Remove(offer);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OfferExists(int id)
        {
            return _context.Offer.Any(e => e.Id == id);
        }
    }
}
