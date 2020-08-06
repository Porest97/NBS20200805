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
            var nBSContext = _context.Incident
                .Include(i => i.Creator)
                .Include(i => i.FEAssigned)
                .Include(i => i.IncidentPriority)
                .Include(i => i.IncidentStatus)
                .Include(i => i.IncidentType)
                .Include(i => i.MtrlList)
                .Include(i => i.PurchaseOrder)
                .Include(i => i.Receiver)
                .Include(i => i.Site);
            return View(await nBSContext.ToListAsync());
        }

        // GET: Incidents - search
        public async Task<IActionResult> IndexSearch
            (string searchString, string searchString1,
            string searchString2, string searchString3,
            string searchString4, string searchString5,
            string searchString6, string searchString7)
        {
            var incidents = from i in _context.Incident
                .Include(i => i.Creator)
                .Include(i => i.FEAssigned)
                .Include(i => i.IncidentPriority)
                .Include(i => i.IncidentStatus)
                .Include(i => i.IncidentType)
                .Include(i => i.PurchaseOrder)
                .Include(i => i.Receiver)
                .Include(i => i.Site)
                .Include(i => i.MtrlList)

                            select i;

            if (!String.IsNullOrEmpty(searchString))
            {
                incidents = incidents
                .Include(i => i.Creator)
                .Include(i => i.FEAssigned)
                .Include(i => i.IncidentPriority)
                .Include(i => i.IncidentStatus)
                .Include(i => i.IncidentType)
                .Include(i => i.PurchaseOrder)
                .Include(i => i.Receiver)
                .Include(i => i.Site)
                .Include(i => i.MtrlList)
                .Where(s => s.IncidentNumber.Contains(searchString));

            }
            if (!String.IsNullOrEmpty(searchString1))
            {
                incidents = incidents
                .Include(i => i.Creator)
                .Include(i => i.FEAssigned)
                .Include(i => i.IncidentPriority)
                .Include(i => i.IncidentStatus)
                .Include(i => i.IncidentType)
                .Include(i => i.PurchaseOrder)
                .Include(i => i.Receiver)
                .Include(i => i.Site)
                .Include(i => i.MtrlList)
                .Where(s => s.Site.SiteNumber.Contains(searchString1));
            }
            if (!String.IsNullOrEmpty(searchString2))
            {
                incidents = incidents
                .Include(i => i.Creator)
                .Include(i => i.FEAssigned)
                .Include(i => i.IncidentPriority)
                .Include(i => i.IncidentStatus)
                .Include(i => i.IncidentType)
                .Include(i => i.PurchaseOrder)
                .Include(i => i.Receiver)
                .Include(i => i.Site)
                .Include(i => i.MtrlList)
                .Where(s => s.Description.Contains(searchString2));
            }
            if (!String.IsNullOrEmpty(searchString3))
            {
                incidents = incidents
                .Include(i => i.Creator)
                .Include(i => i.FEAssigned)
                .Include(i => i.IncidentPriority)
                .Include(i => i.IncidentStatus)
                .Include(i => i.IncidentType)
                .Include(i => i.PurchaseOrder)
                .Include(i => i.Receiver)
                .Include(i => i.Site)
                .Include(i => i.MtrlList)
                .Where(s => s.IncidentStatus.IncidentStatusName.Contains(searchString3));
            }
            if (!String.IsNullOrEmpty(searchString4))
            {
                incidents = incidents
                .Include(i => i.Creator)
                .Include(i => i.FEAssigned)
                .Include(i => i.IncidentPriority)
                .Include(i => i.IncidentStatus)
                .Include(i => i.IncidentType)
                .Include(i => i.PurchaseOrder)
                .Include(i => i.Receiver)
                .Include(i => i.Site)
                .Include(i => i.MtrlList)
                .Where(s => s.IncidentPriority.IncidentPriorityName.Contains(searchString4));

            }
            if (!String.IsNullOrEmpty(searchString5))
            {
                incidents = incidents
                .Include(i => i.Creator)
                .Include(i => i.FEAssigned)
                .Include(i => i.IncidentPriority)
                .Include(i => i.IncidentStatus)
                .Include(i => i.IncidentType)
                .Include(i => i.PurchaseOrder)
                .Include(i => i.Receiver)
                .Include(i => i.Site)
                .Include(i => i.MtrlList)
                .Where(s => s.IncidentType.IncidentTypeName.Contains(searchString5));
            }
            if (!String.IsNullOrEmpty(searchString6))
            {
                incidents = incidents
                .Include(i => i.Creator)
                .Include(i => i.FEAssigned)
                .Include(i => i.IncidentPriority)
                .Include(i => i.IncidentStatus)
                .Include(i => i.IncidentType)
                .Include(i => i.PurchaseOrder)
                .Include(i => i.Receiver)
                .Include(i => i.Site)
                .Include(i => i.MtrlList)
                .Where(s => s.PurchaseOrder.PONumber.Contains(searchString6));
            }
            if (!String.IsNullOrEmpty(searchString7))
            {
                incidents = incidents
                .Include(i => i.Creator)
                .Include(i => i.FEAssigned)
                .Include(i => i.IncidentPriority)
                .Include(i => i.IncidentStatus)
                .Include(i => i.IncidentType)
                .Include(i => i.PurchaseOrder)
                .Include(i => i.Receiver)
                .Include(i => i.Site)
                .Include(i => i.MtrlList)
                .Where(s => s.Creator.FirstName.Contains(searchString7));
            }

            return View(await incidents.ToListAsync());
        }

        // GET: Incidents/DetailsPrint/5
        public async Task<IActionResult> DetailsPrint(int? id)
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
                .Include(i => i.PurchaseOrder)
                .Include(i => i.Receiver)
                .Include(i => i.Site)
                .Include(i => i.Site).Include(i => i.MtrlList)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (incident == null)
            {
                return NotFound();
            }

            return View(incident);
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
            ViewData["MtrlListId"] = new SelectList(_context.Set<MtrlList>(), "Id", "Description");
            ViewData["PersonId"] = new SelectList(_context.Set<Person>(), "Id", "FullName");
            ViewData["PersonId2"] = new SelectList(_context.Set<Person>(), "Id", "FullName");
            ViewData["IncidentPriorityId"] = new SelectList(_context.Set<IncidentPriority>(), "Id", "IncidentPriorityName");
            ViewData["IncidentStatusId"] = new SelectList(_context.Set<IncidentStatus>(), "Id", "IncidentStatusName");
            ViewData["IncidentTypeId"] = new SelectList(_context.Set<IncidentType>(), "Id", "IncidentTypeName");
            ViewData["PurchaseOrderId"] = new SelectList(_context.Set<PurchaseOrder>(), "Id", "PONumber");
            ViewData["PersonId1"] = new SelectList(_context.Set<Person>(), "Id", "FullName");
            ViewData["SiteId"] = new SelectList(_context.Set<Site>(), "Id", "NoSite");
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
                return RedirectToAction(nameof(IndexSearch));
            }
            ViewData["MtrlListId"] = new SelectList(_context.Set<MtrlList>(), "Id", "Description", incident.MtrlListId);
            ViewData["PersonId"] = new SelectList(_context.Set<Person>(), "Id", "FullName", incident.PersonId);
            ViewData["PersonId2"] = new SelectList(_context.Set<Person>(), "Id", "FullName", incident.PersonId2);
            ViewData["IncidentPriorityId"] = new SelectList(_context.Set<IncidentPriority>(), "Id", "IncidentPriorityName", incident.IncidentPriorityId);
            ViewData["IncidentStatusId"] = new SelectList(_context.Set<IncidentStatus>(), "Id", "IncidentStatusName", incident.IncidentStatusId);
            ViewData["IncidentTypeId"] = new SelectList(_context.Set<IncidentType>(), "Id", "IncidentTypeName", incident.IncidentTypeId);
            ViewData["PurchaseOrderId"] = new SelectList(_context.Set<PurchaseOrder>(), "Id", "PONumber", incident.PurchaseOrderId);
            ViewData["PersonId1"] = new SelectList(_context.Set<Person>(), "Id", "FullName", incident.PersonId1);
            ViewData["SiteId"] = new SelectList(_context.Set<Site>(), "Id", "NoSite", incident.SiteId);
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
            ViewData["MtrlListId"] = new SelectList(_context.Set<MtrlList>(), "Id", "Description", incident.MtrlListId);
            ViewData["PersonId"] = new SelectList(_context.Set<Person>(), "Id", "FullName", incident.PersonId);
            ViewData["PersonId2"] = new SelectList(_context.Set<Person>(), "Id", "FullName", incident.PersonId2);
            ViewData["IncidentPriorityId"] = new SelectList(_context.Set<IncidentPriority>(), "Id", "IncidentPriorityName", incident.IncidentPriorityId);
            ViewData["IncidentStatusId"] = new SelectList(_context.Set<IncidentStatus>(), "Id", "IncidentStatusName", incident.IncidentStatusId);
            ViewData["IncidentTypeId"] = new SelectList(_context.Set<IncidentType>(), "Id", "IncidentTypeName", incident.IncidentTypeId);
            ViewData["PurchaseOrderId"] = new SelectList(_context.Set<PurchaseOrder>(), "Id", "PONumber", incident.PurchaseOrderId);
            ViewData["PersonId1"] = new SelectList(_context.Set<Person>(), "Id", "FullName", incident.PersonId1);
            ViewData["SiteId"] = new SelectList(_context.Set<Site>(), "Id", "NoSite", incident.SiteId);
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
                return RedirectToAction(nameof(IndexSearch));
            }
            ViewData["MtrlListId"] = new SelectList(_context.Set<MtrlList>(), "Id", "Description", incident.MtrlListId);
            ViewData["PersonId"] = new SelectList(_context.Set<Person>(), "Id", "FullName", incident.PersonId);
            ViewData["PersonId2"] = new SelectList(_context.Set<Person>(), "Id", "FullName", incident.PersonId2);
            ViewData["IncidentPriorityId"] = new SelectList(_context.Set<IncidentPriority>(), "Id", "IncidentPriorityName", incident.IncidentPriorityId);
            ViewData["IncidentStatusId"] = new SelectList(_context.Set<IncidentStatus>(), "Id", "IncidentStatusName", incident.IncidentStatusId);
            ViewData["IncidentTypeId"] = new SelectList(_context.Set<IncidentType>(), "Id", "IncidentTypeName", incident.IncidentTypeId);
            ViewData["PurchaseOrderId"] = new SelectList(_context.Set<PurchaseOrder>(), "Id", "PONumber", incident.PurchaseOrderId);
            ViewData["PersonId1"] = new SelectList(_context.Set<Person>(), "Id", "FullName", incident.PersonId1);
            ViewData["SiteId"] = new SelectList(_context.Set<Site>(), "Id", "NoSite", incident.SiteId);
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
            return RedirectToAction(nameof(IndexSearch));
        }

        private bool IncidentExists(int id)
        {
            return _context.Incident.Any(e => e.Id == id);
        }
    }
}
