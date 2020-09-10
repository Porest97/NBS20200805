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
    public class AgendaController : Controller
    {
        private readonly NBSContext _context;

        public AgendaController(NBSContext context)
        {
            _context = context;
        }

        // GET: AgendaPosts - search
        public async Task<IActionResult> IndexSearchAgendaPosts(string searchString, string searchString1)
        {
            var agendaPosts = from a in _context.AgendaPost
                .Include(a => a.Creator)               

                         select a;

            if (!String.IsNullOrEmpty(searchString))
            {
                agendaPosts = agendaPosts
                .Include(a => a.Creator)                
                .Where(s => s.Creator.UserName.Contains(searchString));

            }
            if (!String.IsNullOrEmpty(searchString1))
            {
                agendaPosts = agendaPosts
                .Include(a => a.Creator)
                .Where(s => s.DateAndTime.ToString().Contains(searchString1));
            }
            return View(await agendaPosts.ToListAsync());
        }


        // GET: AgendaPost/Details/5
        public async Task<IActionResult> DetailsAgendaPost(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var agendaPost = await _context.AgendaPost
                .Include(a => a.Creator)                
                .FirstOrDefaultAsync(m => m.Id == id);
            if (agendaPost == null)
            {
                return NotFound();
            }

            return View(agendaPost);
        }

        // GET: AgendaPost/Create
        public IActionResult CreateAgendaPost()
        {
            ViewData["ApplicationUserId"] = new SelectList(_context.Users, "Id", "UserName");            
            return View();
        }

        // POST: AgendaPost/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateAgendaPost([Bind("Id,ApplicationUserId,DateAndTime,Description")] AgendaPost agendaPost)
        {
            if (ModelState.IsValid)
            {
                var nBSContext = _context.AgendaPost
                 .Include(t => t.Creator);
                

                _context.Add(agendaPost);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(IndexSearchAgendaPosts));
            }
            ViewData["ApplicationUserId"] = new SelectList(_context.Users, "Id", "UserName", agendaPost.ApplicationUserId);            
            return View(agendaPost);
        }
                

        // GET: AgendaPost/Edit/5
        public async Task<IActionResult> EditAgendaPost(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var agendaPost = await _context.AgendaPost.FindAsync(id);            
            if (agendaPost == null)
            {
                return NotFound();
            }
            ViewData["ApplicationUserId"] = new SelectList(_context.Users, "Id", "UserName", agendaPost.ApplicationUserId);           
            return View(agendaPost);
        }

        // POST: AgendaPost/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditAgendaPost(int id, [Bind("Id,ApplicationUserId,DateAndTime,Description")] AgendaPost agendaPost)
        {
            if (id != agendaPost.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var nBSContext = _context.AgendaPost
                     .Include(t => t.Creator);                 
                    

                    _context.Update(agendaPost);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AgendaPostExists(agendaPost.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(IndexSearchAgendaPosts));
            }
            ViewData["ApplicationUserId"] = new SelectList(_context.Users, "Id", "UserName", agendaPost.ApplicationUserId);           
            return View(agendaPost);
        }

        // GET: AgendaController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AgendaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        private bool AgendaPostExists(int id)
        {
            return _context.AgendaPost.Any(e => e.Id == id);
        }
    }
}
