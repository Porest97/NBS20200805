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
    public class SallaryController : Controller
    {

        private readonly NBSContext _context;

        public SallaryController(NBSContext context)
        {
            _context = context;
        }

        // GET:  IndexSearchTBPostsPaid - search
        public async Task<IActionResult> IndexSearchTBPostsPaid
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


        // GET:  IndexSearchTBPTransactions - Search for Balance in a SallaryAccount
        public async Task<IActionResult> IndexSearchTBPTransactions (string searchString)
        {
            var tBPTransactions = from t in _context.TBPTransaction
                .Include(t => t.SallaryAccount)                

                                select t;

            if (!String.IsNullOrEmpty(searchString))
            {
                tBPTransactions = tBPTransactions
                .Include(t => t.SallaryAccount)                
                .Where(s => s.SallaryAccount.AccountName.Contains(searchString));

            }            
           
            return View(await tBPTransactions.ToListAsync());
        }



        // GET: CreateTBPTransaction
        public IActionResult CreateTBPTransaction()
        {
            ViewData["SallaryAccountId"] = new SelectList(_context.SallaryAccount, "Id", "AccountName");
            return View();
        }

        // POST: CreateTBPTransaction
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateTBPTransaction([Bind("Id,SallaryAccountId,Description,TransactionAmount,TransactionDate,Hours,Price")] TBPTransaction tBPTransaction)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tBPTransaction);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(IndexSearchTBPTransactions));
            }
            ViewData["SallaryAccountId"] = new SelectList(_context.SallaryAccount, "Id", "AccountName", tBPTransaction.SallaryAccountId);
            return View(tBPTransaction);
        }

        // GET:  SallaryAccountBalance196409181135PO - Search for Balance in a SallaryAccount
        public async Task<IActionResult> SallaryAccountBalance196409181135PO (string searchString)
        {
            var tBPTransactions = from t in _context.TBPTransaction
                .Include(t => t.SallaryAccount).Where(t => t.SallaryAccountId == 1)

                                  select t;

            //if (!String.IsNullOrEmpty(searchString))
            //{
            //    tBPTransactions = tBPTransactions
            //    .Include(t => t.SallaryAccount).Where(t => t.SallaryAccountId == 1)
            //    .Where(s => s.SallaryAccount.AccountName.Contains(searchString));

            //}

            return View(await tBPTransactions.ToListAsync());
        }


        public IActionResult IndexSearchSallaries()
        {
            return View();
        }

    }
}
