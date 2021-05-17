using Microsoft.AspNetCore.Http;
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
    public class ProjectsController : Controller
    {
        private readonly NBSContext _context;

        public ProjectsController(NBSContext context)
        {
            _context = context;
        }

        ////List Projects
        //public async Task<IActionResult> ListProjects()
        //{
        //    var proLabContext = _context.Projects.Include(p => p.Status);
        //    return View(await proLabContext.ToListAsync());
        //}

        //List ProjectPosts
        public async Task<IActionResult> ListProjectPosts()
        {
            var proLabContext = _context.ProjectPosts.Include(p => p.Status);
            return View(await proLabContext.ToListAsync());
        }

        // GET: ProjectPosts/Add
        public IActionResult AddProjectPost()
        {
            ViewData["ProjectPostStatusId"] = new SelectList(_context.Set<ProjectPostStatus>(), "Id", "ProjectPostStatusName");
            return View();
        }

        // POST: ProjectPosts/Add
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddProjectPost([Bind("Id,DateTimePosted,DateTimeChanged,ProjectPostDescription," +
            "DateTimePlaned,DateTimeStarted,DateTimeDone,HourPrice,TimeEstimate,TotalCostEstimate,TimeActual,MtrCostActual,LabourCostActual,TotalCostActual,ProjectPostStatusId,ShiftDescription")] ProjectPost projectPost)
        {
            if (ModelState.IsValid)
            {
                var pROLabContext = _context.ProjectPosts
                    .Include(p => p.Status);
                projectPost.TotalCostEstimate = (projectPost.TimeEstimate * projectPost.HourPrice) + projectPost.MtrCostActual;
                projectPost.TotalCostActual = (projectPost.TimeActual * projectPost.HourPrice) + projectPost.MtrCostActual;
                projectPost.LabourCostActual = projectPost.HourPrice * projectPost.TimeActual;
                _context.Add(projectPost);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(ListProjectPosts));
            }
            ViewData["ProjectPostStatusId"] = new SelectList(_context.Set<ProjectPostStatus>(), "Id", "ProjectPostStatusName", projectPost.ProjectPostStatusId);
            return View(projectPost);
        }

        // GET: ProjectPostDetails/Id
        public async Task<IActionResult> DetailsProjectPost(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var projectPost = await _context.ProjectPosts
                .Include(p => p.Status)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (projectPost == null)
            {
                return NotFound();
            }

            return View(projectPost);
        }

        // GET: ProjectPostEdit/Id
        public async Task<IActionResult> EditProjectPost(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var projectPost = await _context.ProjectPosts.FindAsync(id);
            if (projectPost == null)
            {
                return NotFound();
            }
            ViewData["ProjectPostStatusId"] = new SelectList(_context.Set<ProjectPostStatus>(), "Id", "ProjectPostStatusName", projectPost.ProjectPostStatusId);
            return View(projectPost);
        }

        // POST: ProjectPostEdit/Id
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditProjectPost(int id, [Bind("Id,DateTimePosted,DateTimeChanged,ProjectPostDescription," +
            "DateTimePlaned,DateTimeStarted,DateTimeDone,HourPrice,TimeEstimate,TotalCostEstimate,TimeActual,MtrCostActual,LabourCostActual,TotalCostActual,ProjectPostStatusId,ShiftDescription")] ProjectPost projectPost)
        {
            if (id != projectPost.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var pROLabContext = _context.ProjectPosts
                    .Include(p => p.Status);
                    projectPost.TotalCostEstimate = (projectPost.TimeEstimate * projectPost.HourPrice) + projectPost.MtrCostActual;
                    projectPost.TotalCostActual = (projectPost.TimeActual * projectPost.HourPrice) + projectPost.MtrCostActual;
                    projectPost.LabourCostActual = projectPost.HourPrice * projectPost.TimeActual;
                    _context.Update(projectPost);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProjectPostExists(projectPost.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(ListProjectPosts));
            }
            ViewData["ProjectPostStatusId"] = new SelectList(_context.Set<ProjectPostStatus>(), "Id", "ProjectPostStatusName", projectPost.ProjectPostStatusId);
            return View(projectPost);
        }

        //AddShiftDescription

        public async Task<IActionResult> AddShiftDescription(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var projectPost = await _context.ProjectPosts.FindAsync(id);
            if (projectPost == null)
            {
                return NotFound();
            }
            ViewData["ProjectPostStatusId"] = new SelectList(_context.Set<ProjectPostStatus>(), "Id", "ProjectPostStatusName", projectPost.ProjectPostStatusId);
            return View(projectPost);
        }

        // POST: ProjectPostEdit/Id
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddShiftDescription(int id, [Bind("Id,DateTimePosted,DateTimeChanged,ProjectPostDescription," +
            "DateTimePlaned,DateTimeStarted,DateTimeDone,HourPrice,TimeEstimate,TotalCostEstimate,TimeActual,MtrCostActual,LabourCostActual,TotalCostActual,ProjectPostStatusId,ShiftDescription")] ProjectPost projectPost)
        {
            if (id != projectPost.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var pROLabContext = _context.ProjectPosts
                    .Include(p => p.Status);
                    projectPost.TotalCostEstimate = (projectPost.TimeEstimate * projectPost.HourPrice) + projectPost.MtrCostActual;
                    projectPost.TotalCostActual = (projectPost.TimeActual * projectPost.HourPrice) + projectPost.MtrCostActual;
                    projectPost.LabourCostActual = projectPost.HourPrice * projectPost.TimeActual;
                    _context.Update(projectPost);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProjectPostExists(projectPost.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(ListProjectPosts));
            }
            ViewData["ProjectPostStatusId"] = new SelectList(_context.Set<ProjectPostStatus>(), "Id", "ProjectPostStatusName", projectPost.ProjectPostStatusId);
            return View(projectPost);
        }

        // GET: ProjectPostDelete/Id
        public async Task<IActionResult> DeleteProjectPost(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var projectPost = await _context.ProjectPosts
                .Include(p => p.Status)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (projectPost == null)
            {
                return NotFound();
            }

            return View(projectPost);
        }

        // POST: ProjectPostDelete/Id
        [HttpPost, ActionName("DeleteProjectPost")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var projectPost = await _context.ProjectPosts.FindAsync(id);
            _context.ProjectPosts.Remove(projectPost);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(ListProjectPosts));
        }

        private bool ProjectPostExists(int id)
        {
            return _context.ProjectPosts.Any(e => e.Id == id);
        }



    }
}
