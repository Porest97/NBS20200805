using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NBS.Data;
using NBS.Models.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NBS.Controllers.ApplicationControllers
{
    public class SupportController : Controller
    {
        private readonly NBSContext _context;

        public SupportController(NBSContext context)
        {
            _context = context;
        }

        public IActionResult Support()
        {
            return View();
        }

        // GET: SupportRequests
        public async Task<IActionResult> ListSupportRequests()
        {
            var nBSContext = _context.SupportRequests
                .Include(sr => sr.RequestPrio)
                .Include(sr => sr.RequestStatus)
                .Include(sr => sr.RequestType);
            return View(await nBSContext.ToListAsync());
        }

        // GET: SupportRequests/Create
        public IActionResult CreateSupportRequest()
        {
            ViewData["RequestPrioId"] = new SelectList(_context.RequestPrios, "Id", "RequestPrioName");
            ViewData["RequestStatusId"] = new SelectList(_context.RequestStatuses, "Id", "RequestStatusName");
            ViewData["RequestTypeId"] = new SelectList(_context.RequestTypes, "Id", "RequestTypeName");            
            return View();
        }

        // POST: Bills/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateSupportRequest([Bind("Id,ClientCompany,ClientContact,ClientEmail," +
            "ClientPhoneNumber,ClientSite,SiteNumber,SiteName,SiteArea,RequestTypeId,RequestStatusId," +
            "RequestPrioId,DateTimePosted,RequestDescription")] SupportRequest supportRequest)
        {
            if (ModelState.IsValid)
            {
                _context.Add(supportRequest);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(ListSupportRequests));
            }
            ViewData["RequestPrioId"] = new SelectList(_context.RequestPrios, "Id", "RequestPrioName");
            ViewData["RequestStatusId"] = new SelectList(_context.RequestStatuses, "Id", "RequestStatusName");
            ViewData["RequestTypeId"] = new SelectList(_context.RequestTypes, "Id", "RequestTypeName");
            return View(supportRequest);
            
        }


    }
}
