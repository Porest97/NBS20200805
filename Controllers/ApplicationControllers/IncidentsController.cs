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
    public class IncidentsController : Controller
    {
        private readonly NBSContext _context;

        public IncidentsController(NBSContext context)
        {
            _context = context;
        }

        // GET: Incidents
        public async Task<IActionResult> Index()
        {
            var nBSContext = _context.Incident.Include(i => i.Creator).Include(i => i.FEAssigned).Include(i => i.IncidentPriority).Include(i => i.IncidentStatus).Include(i => i.IncidentType).Include(i => i.MtrlList).Include(i => i.PurchaseOrder).Include(i => i.Receiver).Include(i => i.Site);
            return View(await nBSContext.ToListAsync());
        }

        // GET: Incidents/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var incident = await _context.Incident
                .Include(i => i.Creator)
                .Include(i => i.FEAssigned)
                .Include(i => i.IncidentPriority)
                .Include(i => i.IncidentStatus)
                .Include(i => i.IncidentType)
                .Include(i => i.MtrlList)
                .Include(i => i.PurchaseOrder)
                .Include(i => i.Receiver)
                .Include(i => i.Site)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (incident == null)
            {
                return NotFound();
            }

            return View(incident);
        }

        // GET: Incidents/Create
        public IActionResult Create()
        {
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "Id");
            ViewData["PersonId2"] = new SelectList(_context.Person, "Id", "Id");
            ViewData["IncidentPriorityId"] = new SelectList(_context.IncidentPriority, "Id", "Id");
            ViewData["IncidentStatusId"] = new SelectList(_context.IncidentStatus, "Id", "Id");
            ViewData["IncidentTypeId"] = new SelectList(_context.IncidentType, "Id", "Id");
            ViewData["MtrlListId"] = new SelectList(_context.MtrlList, "Id", "Id");
            ViewData["PurchaseOrderId"] = new SelectList(_context.PurchaseOrder, "Id", "Id");
            ViewData["PersonId1"] = new SelectList(_context.Person, "Id", "Id");
            ViewData["SiteId"] = new SelectList(_context.Site, "Id", "Id");
            return View();
        }

        // POST: Incidents/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IncidentPriorityId,IncidentStatusId,IncidentTypeId,IncidentNumber,Created,PersonId,SiteId,Received,PersonId1,FEScheduled,PersonId2,Description,FEEntersSite,FEEExitsSite,Logg,IssueResolved,Resolution,PurchaseOrderId,MtrlListId")] Incident incident)
        {
            if (ModelState.IsValid)
            {
                _context.Add(incident);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "Id", incident.PersonId);
            ViewData["PersonId2"] = new SelectList(_context.Person, "Id", "Id", incident.PersonId2);
            ViewData["IncidentPriorityId"] = new SelectList(_context.IncidentPriority, "Id", "Id", incident.IncidentPriorityId);
            ViewData["IncidentStatusId"] = new SelectList(_context.IncidentStatus, "Id", "Id", incident.IncidentStatusId);
            ViewData["IncidentTypeId"] = new SelectList(_context.IncidentType, "Id", "Id", incident.IncidentTypeId);
            ViewData["MtrlListId"] = new SelectList(_context.MtrlList, "Id", "Id", incident.MtrlListId);
            ViewData["PurchaseOrderId"] = new SelectList(_context.PurchaseOrder, "Id", "Id", incident.PurchaseOrderId);
            ViewData["PersonId1"] = new SelectList(_context.Person, "Id", "Id", incident.PersonId1);
            ViewData["SiteId"] = new SelectList(_context.Site, "Id", "Id", incident.SiteId);
            return View(incident);
        }

        // GET: Incidents/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var incident = await _context.Incident.FindAsync(id);
            if (incident == null)
            {
                return NotFound();
            }
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "Id", incident.PersonId);
            ViewData["PersonId2"] = new SelectList(_context.Person, "Id", "Id", incident.PersonId2);
            ViewData["IncidentPriorityId"] = new SelectList(_context.IncidentPriority, "Id", "Id", incident.IncidentPriorityId);
            ViewData["IncidentStatusId"] = new SelectList(_context.IncidentStatus, "Id", "Id", incident.IncidentStatusId);
            ViewData["IncidentTypeId"] = new SelectList(_context.IncidentType, "Id", "Id", incident.IncidentTypeId);
            ViewData["MtrlListId"] = new SelectList(_context.MtrlList, "Id", "Id", incident.MtrlListId);
            ViewData["PurchaseOrderId"] = new SelectList(_context.PurchaseOrder, "Id", "Id", incident.PurchaseOrderId);
            ViewData["PersonId1"] = new SelectList(_context.Person, "Id", "Id", incident.PersonId1);
            ViewData["SiteId"] = new SelectList(_context.Site, "Id", "Id", incident.SiteId);
            return View(incident);
        }

        // POST: Incidents/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IncidentPriorityId,IncidentStatusId,IncidentTypeId,IncidentNumber,Created,PersonId,SiteId,Received,PersonId1,FEScheduled,PersonId2,Description,FEEntersSite,FEEExitsSite,Logg,IssueResolved,Resolution,PurchaseOrderId,MtrlListId")] Incident incident)
        {
            if (id != incident.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(incident);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IncidentExists(incident.Id))
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
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "Id", incident.PersonId);
            ViewData["PersonId2"] = new SelectList(_context.Person, "Id", "Id", incident.PersonId2);
            ViewData["IncidentPriorityId"] = new SelectList(_context.IncidentPriority, "Id", "Id", incident.IncidentPriorityId);
            ViewData["IncidentStatusId"] = new SelectList(_context.IncidentStatus, "Id", "Id", incident.IncidentStatusId);
            ViewData["IncidentTypeId"] = new SelectList(_context.IncidentType, "Id", "Id", incident.IncidentTypeId);
            ViewData["MtrlListId"] = new SelectList(_context.MtrlList, "Id", "Id", incident.MtrlListId);
            ViewData["PurchaseOrderId"] = new SelectList(_context.PurchaseOrder, "Id", "Id", incident.PurchaseOrderId);
            ViewData["PersonId1"] = new SelectList(_context.Person, "Id", "Id", incident.PersonId1);
            ViewData["SiteId"] = new SelectList(_context.Site, "Id", "Id", incident.SiteId);
            return View(incident);
        }

        // GET: Incidents/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var incident = await _context.Incident
                .Include(i => i.Creator)
                .Include(i => i.FEAssigned)
                .Include(i => i.IncidentPriority)
                .Include(i => i.IncidentStatus)
                .Include(i => i.IncidentType)
                .Include(i => i.MtrlList)
                .Include(i => i.PurchaseOrder)
                .Include(i => i.Receiver)
                .Include(i => i.Site)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (incident == null)
            {
                return NotFound();
            }

            return View(incident);
        }

        // POST: Incidents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var incident = await _context.Incident.FindAsync(id);
            _context.Incident.Remove(incident);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool IncidentExists(int id)
        {
            return _context.Incident.Any(e => e.Id == id);
        }
    }
}
