using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NBS.Data;
using NBS.Models.DataModels;

namespace NBS.Controllers.AdministrationControllers
{
    public class ReportsController : Controller
    {
        private readonly NBSContext _context;

        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UserManager<ApplicationUser> userManager;

        public ReportsController(NBSContext context, RoleManager<IdentityRole> roleManager,
                                        UserManager<ApplicationUser> userManager)
        {
            _context = context;

            this.roleManager = roleManager;
            this.userManager = userManager;
        }

        // GET: TimeReports
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.TimeReport
                .Include(t => t.Creator)
                .Include(t => t.Employee);
            return View(await applicationDbContext.ToListAsync());
        }
        // GET: TimeReportsSearch

        public async Task<IActionResult> IndexSearch(string searchString, string searchString1, string searchString2)
        {
            var timeReports = from t in _context.TimeReport
                .Include(t => t.Creator)
                .Include(t => t.Employee)

                              select t;
            if (!String.IsNullOrEmpty(searchString))
            {
                timeReports = timeReports
                 .Include(t => t.Creator)
                 .Include(t => t.Employee)
                 .Where(s => s.TimeReportName.Contains(searchString));
            }
            if (!String.IsNullOrEmpty(searchString1))
            {
                timeReports = timeReports
                 .Include(t => t.Creator)
                 .Include(t => t.Employee)
                 .Where(s => s.Employee.FirstName.Contains(searchString1));
            }
            if (!String.IsNullOrEmpty(searchString2))
            {
                timeReports = timeReports
                 .Include(t => t.Creator)
                 .Include(t => t.Employee)
                 .Where(s => s.Employee.LastName.Contains(searchString2));
            }
            return View(await timeReports.ToListAsync());
        }

        // GET: TimeReports/Create
        public IActionResult CreateTimeReport()
        {
            ViewData["ApplicationUserId"] = new SelectList(_context.Users, "Id", "Email");
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "FullName");
            return View();
        }

        // POST: TimeReports/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TimeReportName,Description,DateTimeCreated,DateTimeFrom,DateTimeTo,ApplicationUserId,PersonId")] TimeReport timeReport)
        {
            if (ModelState.IsValid)
            {
                _context.Add(timeReport);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(IndexSearch));
            }
            ViewData["ApplicationUserId"] = new SelectList(_context.Users, "Id", "Email", timeReport.ApplicationUserId);
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "FullName", timeReport.PersonId);
            return View(timeReport);
        }
        // GET: TimeReports/Details/5
        public async Task<IActionResult> DetailsTimeReport(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var timeReport = await _context.TimeReport
                .Include(t => t.Creator)
                .Include(t => t.Employee)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (timeReport == null)
            {
                return NotFound();
            }

            return View(timeReport);
        }

    }
}
