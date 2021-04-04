using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NBS.Data;
using NBS.Models.DataModels;

namespace NBS.Controllers.ApplicationControllers
{
    public class AccountingController : Controller
    {

        private readonly NBSContext _context;

        public AccountingController(NBSContext context)
        {
            _context = context;
        }

        // GET: WLogs
        public async Task<IActionResult> IndexWLogs()
        {
            var nBSContext = _context.WLog
                .Include(w => w.Employee)
                .Include(w => w.Incident)
                .Include(w => w.WLogStatus);
            return View(await nBSContext.ToListAsync());
        }

        // GET: WLogs - search
        public async Task<IActionResult> IndexSearchWLogsCompleted
            (string searchString, string searchString1,
            string searchString2, string searchString3,
            string searchString4, string searchString5)
        {
            var wLogs = from w in _context.WLog
                .Include(w => w.Employee)
                .Include(w => w.Incident)
                .Include(w => w.WLogStatus)

                        select w;

            if (!String.IsNullOrEmpty(searchString))
            {
                wLogs = wLogs
                .Include(w => w.Employee)
                .Include(w => w.Incident)
                .Include(w => w.WLogStatus)
                .Where(s => s.Employee.FirstName.Contains(searchString));

            }
            if (!String.IsNullOrEmpty(searchString1))
            {
                wLogs = wLogs
                .Include(w => w.Employee)
                .Include(w => w.Incident)
                .Include(w => w.WLogStatus)
                .Where(s => s.Employee.LastName.Contains(searchString1));
            }
            if (!String.IsNullOrEmpty(searchString2))
            {
                wLogs = wLogs
                .Include(w => w.Employee)
                .Include(w => w.Incident)
                .Include(w => w.WLogStatus)
                .Where(s => s.Incident.IncidentNumber.Contains(searchString2));
            }
            if (!String.IsNullOrEmpty(searchString3))
            {
                wLogs = wLogs
               .Include(w => w.Employee)
               .Include(w => w.Incident)
               .Include(w => w.WLogStatus)
               .Where(s => s.WLogStatus.WLogStatusName.Contains(searchString3));
            }
            if (!String.IsNullOrEmpty(searchString4))
            {
                wLogs = wLogs
               .Include(w => w.Employee)
               .Include(w => w.Incident)
               .Include(w => w.WLogStatus)
               .Where(s => s.DateTimeFrom.ToString().Contains(searchString4));

            }
            if (!String.IsNullOrEmpty(searchString5))
            {
                wLogs = wLogs
               .Include(w => w.Employee)
               .Include(w => w.Incident)
               .Include(w => w.WLogStatus)
               .Where(s => s.DateTimeTo.ToString().Contains(searchString5));
            }
            return View(await wLogs.ToListAsync());
        }

        // GET: TimBanksPosts - search
        public async Task<IActionResult> IndexSearchTimBanksPosts
        (string searchString, string searchString1, string searchString2, string searchString3, string searchString4, string searchString5)
        {
            var timBanksPosts = from t in _context.TimBanksPost
                .Include(t => t.Employee)                
                .Include(t => t.TBPStatus).Where(t => t.TBPStatusId < 4)

                                select t;

            if (!String.IsNullOrEmpty(searchString))
            {
                timBanksPosts = timBanksPosts
                .Include(t => t.Employee)
                .Include(t => t.TBPStatus).Where(t => t.TBPStatusId < 4)
                .Where(s => s.Employee.FirstName.Contains(searchString));

            }
            if (!String.IsNullOrEmpty(searchString1))
            {
                timBanksPosts = timBanksPosts
                .Include(t => t.Employee)
                .Include(t => t.TBPStatus).Where(t => t.TBPStatusId < 4)
                .Where(s => s.Employee.LastName.Contains(searchString1));

            }
            if (!String.IsNullOrEmpty(searchString2))
            {
                timBanksPosts = timBanksPosts
                .Include(t => t.Employee)
                .Include(t => t.TBPStatus).Where(t=>t.TBPStatusId < 4)
                .Where(s => s.Started.ToString().Contains(searchString2));

            }
            if (!String.IsNullOrEmpty(searchString3))
            {
                timBanksPosts = timBanksPosts
                .Include(t => t.Employee)
                .Include(t => t.TBPStatus).Where(t => t.TBPStatusId < 4)
                .Where(s => s.Ended.ToString().Contains(searchString3));

            }
            if (!String.IsNullOrEmpty(searchString4))
            {
                timBanksPosts = timBanksPosts
                .Include(t => t.Employee)
                .Include(t => t.TBPStatus).Where(t => t.TBPStatusId < 4)
                .Where(s => s.TBPStatus.TBPStatusName.Contains(searchString4));

            }
            if (!String.IsNullOrEmpty(searchString5))
            {
                timBanksPosts = timBanksPosts
                .Include(t => t.Employee)
                .Include(t => t.TBPStatus).Where(t => t.TBPStatusId < 4)
                .Where(s => s.Customer.Contains(searchString5));

            }
            return View(await timBanksPosts.ToListAsync());
        }

        // GET: TimBanksPostsPaid - search
        public async Task<IActionResult> IndexSearchTimBanksPostsPaid
        (string searchString, string searchString1, string searchString2, string searchString3, string searchString4, string searchString5)
        {
            var timBanksPosts = from t in _context.TimBanksPost
                .Include(t => t.Employee)
                .Include(t => t.TBPStatus).Where(t => t.TBPStatusId == 4)

                                select t;

            if (!String.IsNullOrEmpty(searchString))
            {
                timBanksPosts = timBanksPosts
                .Include(t => t.Employee)
                .Include(t => t.TBPStatus).Where(t => t.TBPStatusId == 4)
                .Where(s => s.Employee.FirstName.Contains(searchString));

            }
            if (!String.IsNullOrEmpty(searchString1))
            {
                timBanksPosts = timBanksPosts
                .Include(t => t.Employee)
                .Include(t => t.TBPStatus).Where(t => t.TBPStatusId == 4)
                .Where(s => s.Employee.LastName.Contains(searchString1));

            }
            if (!String.IsNullOrEmpty(searchString2))
            {
                timBanksPosts = timBanksPosts
                .Include(t => t.Employee)
                .Include(t => t.TBPStatus).Where(t => t.TBPStatusId == 4)
                .Where(s => s.Started.ToString().Contains(searchString2));

            }
            if (!String.IsNullOrEmpty(searchString3))
            {
                timBanksPosts = timBanksPosts
                .Include(t => t.Employee)
                .Include(t => t.TBPStatus).Where(t => t.TBPStatusId == 4)
                .Where(s => s.Ended.ToString().Contains(searchString3));

            }
            if (!String.IsNullOrEmpty(searchString4))
            {
                timBanksPosts = timBanksPosts
                .Include(t => t.Employee)
                .Include(t => t.TBPStatus).Where(t => t.TBPStatusId == 4)
                .Where(s => s.TBPStatus.TBPStatusName.Contains(searchString4));

            }
            if (!String.IsNullOrEmpty(searchString5))
            {
                timBanksPosts = timBanksPosts
                .Include(t => t.Employee)
                .Include(t => t.TBPStatus).Where(t => t.TBPStatusId == 4)
                .Where(s => s.Customer.Contains(searchString5));

            }
            return View(await timBanksPosts.ToListAsync());
        }

        

        // GET: TimBanksPosts/CreateTimBanksPost        
        public IActionResult CreateTimBanksPost()
        {            
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "FullName");
            ViewData["TBPStatusId"] = new SelectList(_context.TBPStatus, "Id", "TBPStatusName");
            return View();
        }

        // POST: TimeLogs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateTimBanksPost([Bind("Id,Customer,Incident,Started,Ended,Hours,Price,Total,Outlay,PersonId,Notes,WLNumber,TBPStatusId")] TimBanksPost timBanksPost)
        {
            if (ModelState.IsValid)
            {
                var nBSContext = _context.TimBanksPost
                 .Include(t => t.TBPStatus)
                 .Include(t => t.Employee);                 
                timBanksPost.Total = (timBanksPost.Hours * timBanksPost.Price) + timBanksPost.Outlay;

                _context.Add(timBanksPost);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(IndexSearchTimBanksPosts));
            }
            
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "FullName", timBanksPost.PersonId);
            ViewData["TBPStatusId"] = new SelectList(_context.TBPStatus, "Id", "TBPStatusName");
            return View(timBanksPost);
        }

        // GET: TimBanksPost/EditTimBanksPostStatus
        public async Task<IActionResult> EditTimBanksPostStatus(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var timBanksPost = await _context.TimBanksPost.FindAsync(id);
            if (timBanksPost == null)
            {
                return NotFound();
            }
            
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "FullName", timBanksPost.PersonId);            
            ViewData["TBPStatusId"] = new SelectList(_context.TBPStatus, "Id", "TBPStatusName", timBanksPost.TBPStatusId);            
            return View(timBanksPost);
        }

        // POST: TimBanksPost/EditStatus        
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditTimBanksPostStatus(int id, [Bind("Id, Customer, Incident, Started, Ended, Hours, Price, Total, Outlay, PersonId, Notes, WLNumber, TBPStatusId")] TimBanksPost timBanksPost)
        {
            if (id != timBanksPost.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var nBSContext = _context.TimBanksPost
                 .Include(t => t.TBPStatus)
                 .Include(t => t.Employee);
                    timBanksPost.Total = (timBanksPost.Hours * timBanksPost.Price) + timBanksPost.Outlay;

                    _context.Update(timBanksPost);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TimBanksPostExists(timBanksPost.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(IndexSearchTimBanksPosts));
            }
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "FullName", timBanksPost.PersonId);
            ViewData["TBPStatusId"] = new SelectList(_context.TBPStatus, "Id", "TBPStatusName", timBanksPost.TBPStatusId);
            return View(timBanksPost);
        }

        // GET: TimBanksPost/EditTimBanksPost
        public async Task<IActionResult> EditTimBanksPost(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var timBanksPost = await _context.TimBanksPost.FindAsync(id);
            if (timBanksPost == null)
            {
                return NotFound();
            }

            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "FullName", timBanksPost.PersonId);
            ViewData["TBPStatusId"] = new SelectList(_context.TBPStatus, "Id", "TBPStatusName", timBanksPost.TBPStatusId);
            return View(timBanksPost);
        }

        // POST: TimBanksPost/EditStatus        
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditTimBanksPost(int id, [Bind("Id, Customer, Incident, Started, Ended, Hours, Price, Total, Outlay, PersonId, Notes, WLNumber, TBPStatusId")] TimBanksPost timBanksPost)
        {
            if (id != timBanksPost.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var nBSContext = _context.TimBanksPost
                 .Include(t => t.TBPStatus)
                 .Include(t => t.Employee);
                    timBanksPost.Total = (timBanksPost.Hours * timBanksPost.Price) + timBanksPost.Outlay;

                    _context.Update(timBanksPost);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TimBanksPostExists(timBanksPost.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(IndexSearchTimBanksPosts));
            }
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "FullName", timBanksPost.PersonId);
            ViewData["TBPStatusId"] = new SelectList(_context.TBPStatus, "Id", "TBPStatusName", timBanksPost.TBPStatusId);
            return View(timBanksPost);
        }

        

        /// <summary>
        /// BillingPosts => Is a post that We use for billing customers
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// 
        // GET: BillingPosts/CreateBillingPost        
        public IActionResult CreateBillingPost ()
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
                return RedirectToAction(nameof(IndexSearchBillingPosts));
            }

            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "FullName", billingPost.PersonId);
            ViewData["BPStatusId"] = new SelectList(_context.BPStatus, "Id", "BPStatusName");
            return View(billingPost);
        }

        // GET: BillingPosts - search
        public async Task<IActionResult> IndexSearchBillingPosts
        (string searchString, string searchString1, string searchString2, string searchString3, string searchString4, string searchString5)
        {
            var billingPosts = from t in _context.BillingPost
                .Include(t => t.Employee)
                .Include(t => t.BPStatus).Where(t => t.BPStatusId < 3)

                                select t;

            if (!String.IsNullOrEmpty(searchString))
            {
                billingPosts = billingPosts
                .Include(t => t.Employee)
                .Include(t => t.BPStatus).Where(t => t.BPStatusId < 3)
                .Where(s => s.PONumber.Contains(searchString));

            }
            if (!String.IsNullOrEmpty(searchString1))
            {
                billingPosts = billingPosts
                .Include(t => t.Employee)
                .Include(t => t.BPStatus).Where(t => t.BPStatusId < 3)
                .Where(s => s.Employee.LastName.Contains(searchString1));

            }
            if (!String.IsNullOrEmpty(searchString2))
            {
                billingPosts = billingPosts
                .Include(t => t.Employee)
                .Include(t => t.BPStatus).Where(t => t.BPStatusId < 3)
                .Where(s => s.Incident.Contains(searchString2));

            }
            if (!String.IsNullOrEmpty(searchString3))
            {
                billingPosts = billingPosts
                .Include(t => t.Employee)
                .Include(t => t.BPStatus).Where(t => t.BPStatusId < 3)
                .Where(s => s.Ended.ToString().Contains(searchString3));

            }
            if (!String.IsNullOrEmpty(searchString4))
            {
                billingPosts = billingPosts
                .Include(t => t.Employee)
                .Include(t => t.BPStatus).Where(t => t.BPStatusId < 3)
                .Where(s => s.BPStatus.BPStatusName.Contains(searchString4));

            }
            if (!String.IsNullOrEmpty(searchString5))
            {
                billingPosts = billingPosts
                .Include(t => t.Employee)
                .Include(t => t.BPStatus).Where(t => t.BPStatusId < 3)
                .Where(s => s.Customer.Contains(searchString5));

            }
            return View(await billingPosts.ToListAsync());
        }
        // GET: IndexSearchBillingPostsReported - Search
        public async Task<IActionResult> IndexSearchBillingPostsReported
        (string searchString, string searchString1, string searchString2, string searchString3, string searchString4, string searchString5)
        {
            var billingPosts = from t in _context.BillingPost
                .Include(t => t.Employee)
                .Include(t => t.BPStatus).Where(t => t.BPStatusId == 3)

                               select t;

            if (!String.IsNullOrEmpty(searchString))
            {
                billingPosts = billingPosts
                .Include(t => t.Employee)
                .Include(t => t.BPStatus).Where(t => t.BPStatusId == 3)
                .Where(s => s.PONumber.Contains(searchString));

            }
            if (!String.IsNullOrEmpty(searchString1))
            {
                billingPosts = billingPosts
                .Include(t => t.Employee)
                .Include(t => t.BPStatus).Where(t => t.BPStatusId == 3)
                .Where(s => s.Employee.LastName.Contains(searchString1));

            }
            if (!String.IsNullOrEmpty(searchString2))
            {
                billingPosts = billingPosts
                .Include(t => t.Employee)
                .Include(t => t.BPStatus).Where(t => t.BPStatusId == 3)
                .Where(s => s.Started.ToString().Contains(searchString2));

            }
            if (!String.IsNullOrEmpty(searchString3))
            {
                billingPosts = billingPosts
                .Include(t => t.Employee)
                .Include(t => t.BPStatus).Where(t => t.BPStatusId == 3)
                .Where(s => s.Ended.ToString().Contains(searchString3));

            }
            if (!String.IsNullOrEmpty(searchString4))
            {
                billingPosts = billingPosts
                .Include(t => t.Employee)
                .Include(t => t.BPStatus).Where(t => t.BPStatusId == 3)
                .Where(s => s.BPStatus.BPStatusName.Contains(searchString4));

            }
            if (!String.IsNullOrEmpty(searchString5))
            {
                billingPosts = billingPosts
                .Include(t => t.Employee)
                .Include(t => t.BPStatus).Where(t => t.BPStatusId == 3)
                .Where(s => s.Customer.Contains(searchString5));

            }
            return View(await billingPosts.ToListAsync());
        }

        // GET: BillingPostsReportedProjekt - Search
        public async Task<IActionResult> BillingPostsReportedProjekt
        (string searchString, string searchString1, string searchString2, string searchString3, string searchString4, string searchString5)
        {
            var billingPosts = from t in _context.BillingPost
                .Include(t => t.Employee)
                .Include(t => t.BPStatus).Where(t => t.BPStatusId == 7)

                               select t;

            if (!String.IsNullOrEmpty(searchString))
            {
                billingPosts = billingPosts
                .Include(t => t.Employee)
                .Include(t => t.BPStatus).Where(t => t.BPStatusId == 7)
                .Where(s => s.PONumber.Contains(searchString));

            }
            if (!String.IsNullOrEmpty(searchString1))
            {
                billingPosts = billingPosts
                .Include(t => t.Employee)
                .Include(t => t.BPStatus).Where(t => t.BPStatusId == 7)
                .Where(s => s.Employee.LastName.Contains(searchString1));

            }
            if (!String.IsNullOrEmpty(searchString2))
            {
                billingPosts = billingPosts
                .Include(t => t.Employee)
                .Include(t => t.BPStatus).Where(t => t.BPStatusId == 7)
                .Where(s => s.Started.ToString().Contains(searchString2));

            }
            if (!String.IsNullOrEmpty(searchString3))
            {
                billingPosts = billingPosts
                .Include(t => t.Employee)
                .Include(t => t.BPStatus).Where(t => t.BPStatusId == 7)
                .Where(s => s.Ended.ToString().Contains(searchString3));

            }
            if (!String.IsNullOrEmpty(searchString4))
            {
                billingPosts = billingPosts
                .Include(t => t.Employee)
                .Include(t => t.BPStatus).Where(t => t.BPStatusId == 7)
                .Where(s => s.BPStatus.BPStatusName.Contains(searchString4));

            }
            if (!String.IsNullOrEmpty(searchString5))
            {
                billingPosts = billingPosts
                .Include(t => t.Employee)
                .Include(t => t.BPStatus).Where(t => t.BPStatusId == 7)
                .Where(s => s.Incident.Contains(searchString5));

            }
            return View(await billingPosts.ToListAsync());
        }

        // GET: BillingPostsBilled - search
        public async Task<IActionResult> IndexSearchBillingPostsBilled
        (string searchString, string searchString1, string searchString2, string searchString3, string searchString4, string searchString5)
        {
            var billingPosts = from t in _context.BillingPost
                .Include(t => t.Employee)
                .Include(t => t.BPStatus).Where(t => t.BPStatusId == 4)

                               select t;

            if (!String.IsNullOrEmpty(searchString))
            {
                billingPosts = billingPosts
                .Include(t => t.Employee)
                .Include(t => t.BPStatus).Where(t => t.BPStatusId == 4)
                .Where(s => s.PONumber.Contains(searchString));

            }
            if (!String.IsNullOrEmpty(searchString1))
            {
                billingPosts = billingPosts
                .Include(t => t.Employee)
                .Include(t => t.BPStatus).Where(t => t.BPStatusId == 4)
                .Where(s => s.Employee.LastName.Contains(searchString1));

            }
            if (!String.IsNullOrEmpty(searchString2))
            {
                billingPosts = billingPosts
                .Include(t => t.Employee)
                .Include(t => t.BPStatus).Where(t => t.BPStatusId == 4)
                .Where(s => s.Started.ToString().Contains(searchString2));

            }
            if (!String.IsNullOrEmpty(searchString3))
            {
                billingPosts = billingPosts
                .Include(t => t.Employee)
                .Include(t => t.BPStatus).Where(t => t.BPStatusId == 4)
                .Where(s => s.Ended.ToString().Contains(searchString3));

            }
            if (!String.IsNullOrEmpty(searchString4))
            {
                billingPosts = billingPosts
                .Include(t => t.Employee)
                .Include(t => t.BPStatus).Where(t => t.BPStatusId == 4)
                .Where(s => s.BPStatus.BPStatusName.Contains(searchString4));

            }
            if (!String.IsNullOrEmpty(searchString5))
            {
                billingPosts = billingPosts
                .Include(t => t.Employee)
                .Include(t => t.BPStatus).Where(t => t.BPStatusId == 4)
                .Where(s => s.Customer.Contains(searchString5));

            }
            return View(await billingPosts.ToListAsync());
        }

        // GET: BillingPostsBilledProjekt - search
        public async Task<IActionResult> BillingPostsBilledProjekt
        (string searchString, string searchString1, string searchString2, string searchString3, string searchString4, string searchString5)
        {
            var billingPosts = from t in _context.BillingPost
                .Include(t => t.Employee)
                .Include(t => t.BPStatus).Where(t => t.BPStatusId == 8)

                               select t;

            if (!String.IsNullOrEmpty(searchString))
            {
                billingPosts = billingPosts
                .Include(t => t.Employee)
                .Include(t => t.BPStatus).Where(t => t.BPStatusId == 8)
                .Where(s => s.PONumber.Contains(searchString));

            }
            if (!String.IsNullOrEmpty(searchString1))
            {
                billingPosts = billingPosts
                .Include(t => t.Employee)
                .Include(t => t.BPStatus).Where(t => t.BPStatusId == 8)
                .Where(s => s.Employee.LastName.Contains(searchString1));

            }
            if (!String.IsNullOrEmpty(searchString2))
            {
                billingPosts = billingPosts
                .Include(t => t.Employee)
                .Include(t => t.BPStatus).Where(t => t.BPStatusId == 8)
                .Where(s => s.Started.ToString().Contains(searchString2));

            }
            if (!String.IsNullOrEmpty(searchString3))
            {
                billingPosts = billingPosts
                .Include(t => t.Employee)
                .Include(t => t.BPStatus).Where(t => t.BPStatusId == 8)
                .Where(s => s.Ended.ToString().Contains(searchString3));

            }
            if (!String.IsNullOrEmpty(searchString4))
            {
                billingPosts = billingPosts
                .Include(t => t.Employee)
                .Include(t => t.BPStatus).Where(t => t.BPStatusId == 8)
                .Where(s => s.BPStatus.BPStatusName.Contains(searchString4));

            }
            if (!String.IsNullOrEmpty(searchString5))
            {
                billingPosts = billingPosts
                .Include(t => t.Employee)
                .Include(t => t.BPStatus).Where(t => t.BPStatusId == 8)
                .Where(s => s.Incident.Contains(searchString5));

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

        // POST: BillingPost/EditBillingPost       
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
                return RedirectToAction(nameof(IndexSearchBillingPosts));
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

        // POST: BillingPost/EditBillingpostEmployee    
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
                return RedirectToAction(nameof(IndexSearchBillingPosts));
            }
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "FullName", billingPost.PersonId);
            ViewData["BPStatusId"] = new SelectList(_context.BPStatus, "Id", "BPStatusName", billingPost.BPStatusId);
            return View(billingPost);
        }

        // GET: EditBillingPostReported
        public async Task<IActionResult> EditBillingPostReported(int? id)
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

        // POST: EditBillingPostReported       
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditBillingPostReported(int id,[Bind("Id,Customer,Incident,Started,Ended,Hours,Price,Total,Outlay,PersonId,Notes,WLNumber,BPStatusId,PONumber")] BillingPost billingPost)
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
                return RedirectToAction(nameof(IndexSearchBillingPostsReported));
            }
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "FullName", billingPost.PersonId);
            ViewData["BPStatusId"] = new SelectList(_context.BPStatus, "Id", "BPStatusName", billingPost.BPStatusId);
            return View(billingPost);
        }

        // GET: BillingPost/EditBillingPostStatus
        public async Task<IActionResult> EditBillingPostStatus(int? id)
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

        // POST: EditBillingPostStatus        
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
                return RedirectToAction(nameof(IndexSearchBillingPosts));
            }
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "FullName", billingPost.PersonId);
            ViewData["BPStatusId"] = new SelectList(_context.BPStatus, "Id", "BPStatusName", billingPost.BPStatusId);
            return View(billingPost);
        }

        // GET: BillingPost/EditBillingPostStatusReported
        public async Task<IActionResult> EditBillingPostStatusReported(int? id)
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

        // POST: EditBillingPostStatusReported       
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditBillingPostStatusReported(int id, [Bind("Id, Customer, Incident, Started, Ended, Hours, Price, Total, Outlay, PersonId, Notes, WLNumber, BPStatusId, PONumber")] BillingPost billingPost)
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
                return RedirectToAction(nameof(IndexSearchBillingPostsReported));
            }
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "FullName", billingPost.PersonId);
            ViewData["BPStatusId"] = new SelectList(_context.BPStatus, "Id", "BPStatusName", billingPost.BPStatusId);
            return View(billingPost);
        }

        private bool TimBanksPostExists(int id)
        {
            return _context.TimBanksPost.Any(e => e.Id == id);
        }

        private bool BillingPostExists(int id)
        {
            return _context.BillingPost.Any(e => e.Id == id);
        }

    }
}
