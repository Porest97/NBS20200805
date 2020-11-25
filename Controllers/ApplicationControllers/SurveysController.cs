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
    public class SurveysController : Controller
    {
        private readonly NBSContext _context;

        public SurveysController(NBSContext context)
        {
            _context = context;
        }

        // GET: Surveys
        public async Task<IActionResult> IndexSiteSurveys()
        {
            var nBSContext = _context.SiteSurvey
                .Include(s => s.Creator)
                .Include(s => s.ImageModel1)
                .Include(s => s.ImageModel10)
                .Include(s => s.ImageModel11)
                .Include(s => s.ImageModel12)
                .Include(s => s.ImageModel13)
                .Include(s => s.ImageModel14)
                .Include(s => s.ImageModel15)
                .Include(s => s.ImageModel16)
                .Include(s => s.ImageModel17)
                .Include(s => s.ImageModel18)
                .Include(s => s.ImageModel19)
                .Include(s => s.ImageModel2)
                .Include(s => s.ImageModel20)
                .Include(s => s.ImageModel21)
                .Include(s => s.ImageModel22)
                .Include(s => s.ImageModel23)
                .Include(s => s.ImageModel24)
                .Include(s => s.ImageModel25)
                .Include(s => s.ImageModel3)
                .Include(s => s.ImageModel4)
                .Include(s => s.ImageModel5)
                .Include(s => s.ImageModel6)
                .Include(s => s.ImageModel7)
                .Include(s => s.ImageModel8)
                .Include(s => s.ImageModel9)
                .Include(s => s.Incident)
                .Include(s => s.SiteSurveyStatus);
            return View(await nBSContext.ToListAsync());
        }       

        // GET: SiteSurveys - search
        public async Task<IActionResult> IndexSearchSiteSurveys(string searchString, string searchString1,
            string searchString2, string searchString3)
        {
            var siteSurveys = from s in _context.SiteSurvey
                .Include(a => a.Creator)
                .Include(s => s.Incident)
                .Include(s => s.Incident.Site)
                .Include(s => s.SiteSurveyStatus)

                              select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                siteSurveys = siteSurveys
                .Include(a => a.Creator)
                .Include(s => s.Incident)
                .Include(s => s.SiteSurveyStatus)
                .Where(s => s.Creator.LastName.Contains(searchString));

            }
            if (!String.IsNullOrEmpty(searchString1))
            {
                siteSurveys = siteSurveys
                 .Include(a => a.Creator)
                 .Include(s => s.Incident)
                 .Include(s => s.SiteSurveyStatus)
                 .Where(s => s.Incident.IncidentNumber.Contains(searchString1));
            }
            if (!String.IsNullOrEmpty(searchString2))
            {
                siteSurveys = siteSurveys
                 .Include(a => a.Creator)
                 .Include(s => s.Incident)
                 .Include(s => s.Incident.Site)
                 .Include(s => s.SiteSurveyStatus)
                 .Where(s => s.SiteSurveyStatus.SiteSurveyStatusName.Contains(searchString2));
            }
            if (!String.IsNullOrEmpty(searchString3))
            {
                siteSurveys = siteSurveys
                 .Include(a => a.Creator)
                 .Include(s => s.Incident)
                 .Include(s => s.SiteSurveyStatus)
                 .Where(s => s.Incident.Site.SiteNumber.Contains(searchString3));
            }
            return View(await siteSurveys.ToListAsync());
        }

        // GET: Surveys/Details/5
        public async Task<IActionResult> DetailsSiteSurvey(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var siteSurvey = await _context.SiteSurvey
                .Include(s => s.Creator)
                .Include(s => s.ImageModel1)
                .Include(s => s.ImageModel10)
                .Include(s => s.ImageModel11)
                .Include(s => s.ImageModel12)
                .Include(s => s.ImageModel13)
                .Include(s => s.ImageModel14)
                .Include(s => s.ImageModel15)
                .Include(s => s.ImageModel16)
                .Include(s => s.ImageModel17)
                .Include(s => s.ImageModel18)
                .Include(s => s.ImageModel19)
                .Include(s => s.ImageModel2)
                .Include(s => s.ImageModel20)
                .Include(s => s.ImageModel21)
                .Include(s => s.ImageModel22)
                .Include(s => s.ImageModel23)
                .Include(s => s.ImageModel24)
                .Include(s => s.ImageModel25)
                .Include(s => s.ImageModel3)
                .Include(s => s.ImageModel4)
                .Include(s => s.ImageModel5)
                .Include(s => s.ImageModel6)
                .Include(s => s.ImageModel7)
                .Include(s => s.ImageModel8)
                .Include(s => s.ImageModel9)
                .Include(s => s.Incident)
                .Include(s => s.SiteSurveyStatus)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (siteSurvey == null)
            {
                return NotFound();
            }

            return View(siteSurvey);
        }

        // GET: Surveys/Create
        public IActionResult CreateSiteSurvey()
        {
            ViewData["ApplicationUserId"] = new SelectList(_context.Users, "Id", "FullName");
            ViewData["ImageModelId"] = new SelectList(_context.Images, "ImageId", "Title");
            ViewData["ImageModelId9"] = new SelectList(_context.Images, "ImageId", "Title");
            ViewData["ImageModelId10"] = new SelectList(_context.Images, "ImageId", "Title");
            ViewData["ImageModelId11"] = new SelectList(_context.Images, "ImageId", "Title");
            ViewData["ImageModelId12"] = new SelectList(_context.Images, "ImageId", "Title");
            ViewData["ImageModelId13"] = new SelectList(_context.Images, "ImageId", "Title");
            ViewData["ImageModelId14"] = new SelectList(_context.Images, "ImageId", "Title");
            ViewData["ImageModelId15"] = new SelectList(_context.Images, "ImageId", "Title");
            ViewData["ImageModelId16"] = new SelectList(_context.Images, "ImageId", "Title");
            ViewData["ImageModelId17"] = new SelectList(_context.Images, "ImageId", "Title");
            ViewData["ImageModelId18"] = new SelectList(_context.Images, "ImageId", "Title");
            ViewData["ImageModelId1"] = new SelectList(_context.Images, "ImageId", "Title");
            ViewData["ImageModelId19"] = new SelectList(_context.Images, "ImageId", "Title");
            ViewData["ImageModelId20"] = new SelectList(_context.Images, "ImageId", "Title");
            ViewData["ImageModelId21"] = new SelectList(_context.Images, "ImageId", "Title");
            ViewData["ImageModelId22"] = new SelectList(_context.Images, "ImageId", "Title");
            ViewData["ImageModelId23"] = new SelectList(_context.Images, "ImageId", "Title");
            ViewData["ImageModelId24"] = new SelectList(_context.Images, "ImageId", "Title");
            ViewData["ImageModelId2"] = new SelectList(_context.Images, "ImageId", "Title");
            ViewData["ImageModelId3"] = new SelectList(_context.Images, "ImageId", "Title");
            ViewData["ImageModelId4"] = new SelectList(_context.Images, "ImageId", "Title");
            ViewData["ImageModelId5"] = new SelectList(_context.Images, "ImageId", "Title");
            ViewData["ImageModelId6"] = new SelectList(_context.Images, "ImageId", "Title");
            ViewData["ImageModelId7"] = new SelectList(_context.Images, "ImageId", "Title");
            ViewData["ImageModelId8"] = new SelectList(_context.Images, "ImageId", "Title");
            ViewData["IncidentId"] = new SelectList(_context.Incident, "Id", "IncidentNumber");
            ViewData["SiteSurveyStatusId"] = new SelectList(_context.Set<SiteSurveyStatus>(), "Id", "SiteSurveyStatusName");
            return View();
        }

        // POST: Surveys/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateSiteSurvey([Bind("Id,SiteSurveyNumber,Description,Scheduled,Started,Ended,Created,ApplicationUserId,IncidentId,FloorOneDescription,ImageModelId,ImageModelId1,ImageModelId2,ImageModelId3,ImageModelId4,FloorTwoDescription,ImageModelId5,ImageModelId6,ImageModelId7,ImageModelId8,ImageModelId9,FloorThreeDescription,ImageModelId10,ImageModelId11,ImageModelId12,ImageModelId13,ImageModelId14,FloorFourDescription,ImageModelId15,ImageModelId16,ImageModelId17,ImageModelId18,ImageModelId19,FloorFiveDescription,ImageModelId20,ImageModelId21,ImageModelId22,ImageModelId23,ImageModelId24,SiteSurveyStatusId")] SiteSurvey siteSurvey)
        {
            if (ModelState.IsValid)
            {
                _context.Add(siteSurvey);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(IndexSearchSiteSurveys));
            }
            ViewData["ApplicationUserId"] = new SelectList(_context.Users, "Id", "FullName", siteSurvey.ApplicationUserId);
            ViewData["ImageModelId"] = new SelectList(_context.Images, "ImageId", "Title", siteSurvey.ImageModelId);
            ViewData["ImageModelId9"] = new SelectList(_context.Images, "ImageId", "Title", siteSurvey.ImageModelId9);
            ViewData["ImageModelId10"] = new SelectList(_context.Images, "ImageId", "Title", siteSurvey.ImageModelId10);
            ViewData["ImageModelId11"] = new SelectList(_context.Images, "ImageId", "Title", siteSurvey.ImageModelId11);
            ViewData["ImageModelId12"] = new SelectList(_context.Images, "ImageId", "Title", siteSurvey.ImageModelId12);
            ViewData["ImageModelId13"] = new SelectList(_context.Images, "ImageId", "Title", siteSurvey.ImageModelId13);
            ViewData["ImageModelId14"] = new SelectList(_context.Images, "ImageId", "Title", siteSurvey.ImageModelId14);
            ViewData["ImageModelId15"] = new SelectList(_context.Images, "ImageId", "Title", siteSurvey.ImageModelId15);
            ViewData["ImageModelId16"] = new SelectList(_context.Images, "ImageId", "Title", siteSurvey.ImageModelId16);
            ViewData["ImageModelId17"] = new SelectList(_context.Images, "ImageId", "Title", siteSurvey.ImageModelId17);
            ViewData["ImageModelId18"] = new SelectList(_context.Images, "ImageId", "Title", siteSurvey.ImageModelId18);
            ViewData["ImageModelId1"] = new SelectList(_context.Images, "ImageId", "Title", siteSurvey.ImageModelId1);
            ViewData["ImageModelId19"] = new SelectList(_context.Images, "ImageId", "Title", siteSurvey.ImageModelId19);
            ViewData["ImageModelId20"] = new SelectList(_context.Images, "ImageId", "Title", siteSurvey.ImageModelId20);
            ViewData["ImageModelId21"] = new SelectList(_context.Images, "ImageId", "Title", siteSurvey.ImageModelId21);
            ViewData["ImageModelId22"] = new SelectList(_context.Images, "ImageId", "Title", siteSurvey.ImageModelId22);
            ViewData["ImageModelId23"] = new SelectList(_context.Images, "ImageId", "Title", siteSurvey.ImageModelId23);
            ViewData["ImageModelId24"] = new SelectList(_context.Images, "ImageId", "Title", siteSurvey.ImageModelId24);
            ViewData["ImageModelId2"] = new SelectList(_context.Images, "ImageId", "Title", siteSurvey.ImageModelId2);
            ViewData["ImageModelId3"] = new SelectList(_context.Images, "ImageId", "Title", siteSurvey.ImageModelId3);
            ViewData["ImageModelId4"] = new SelectList(_context.Images, "ImageId", "Title", siteSurvey.ImageModelId4);
            ViewData["ImageModelId5"] = new SelectList(_context.Images, "ImageId", "Title", siteSurvey.ImageModelId5);
            ViewData["ImageModelId6"] = new SelectList(_context.Images, "ImageId", "Title", siteSurvey.ImageModelId6);
            ViewData["ImageModelId7"] = new SelectList(_context.Images, "ImageId", "Title", siteSurvey.ImageModelId7);
            ViewData["ImageModelId8"] = new SelectList(_context.Images, "ImageId", "Title", siteSurvey.ImageModelId8);
            ViewData["IncidentId"] = new SelectList(_context.Incident, "Id", "IncidentNumber", siteSurvey.IncidentId);
            ViewData["SiteSurveyStatusId"] = new SelectList(_context.Set<SiteSurveyStatus>(), "Id", "SiteSurveyStatusName", siteSurvey.SiteSurveyStatusId);
            return View(siteSurvey);
        }

        // GET: Surveys/Edit/5
        public async Task<IActionResult> EditSiteSurvey(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var siteSurvey = await _context.SiteSurvey.FindAsync(id);
            if (siteSurvey == null)
            {
                return NotFound();
            }
            ViewData["ApplicationUserId"] = new SelectList(_context.Users, "Id", "FullName", siteSurvey.ApplicationUserId);
            ViewData["ImageModelId"] = new SelectList(_context.Images, "ImageId", "Title", siteSurvey.ImageModelId);
            ViewData["ImageModelId9"] = new SelectList(_context.Images, "ImageId", "Title", siteSurvey.ImageModelId9);
            ViewData["ImageModelId10"] = new SelectList(_context.Images, "ImageId", "Title", siteSurvey.ImageModelId10);
            ViewData["ImageModelId11"] = new SelectList(_context.Images, "ImageId", "Title", siteSurvey.ImageModelId11);
            ViewData["ImageModelId12"] = new SelectList(_context.Images, "ImageId", "Title", siteSurvey.ImageModelId12);
            ViewData["ImageModelId13"] = new SelectList(_context.Images, "ImageId", "Title", siteSurvey.ImageModelId13);
            ViewData["ImageModelId14"] = new SelectList(_context.Images, "ImageId", "Title", siteSurvey.ImageModelId14);
            ViewData["ImageModelId15"] = new SelectList(_context.Images, "ImageId", "Title", siteSurvey.ImageModelId15);
            ViewData["ImageModelId16"] = new SelectList(_context.Images, "ImageId", "Title", siteSurvey.ImageModelId16);
            ViewData["ImageModelId17"] = new SelectList(_context.Images, "ImageId", "Title", siteSurvey.ImageModelId17);
            ViewData["ImageModelId18"] = new SelectList(_context.Images, "ImageId", "Title", siteSurvey.ImageModelId18);
            ViewData["ImageModelId1"] = new SelectList(_context.Images, "ImageId", "Title", siteSurvey.ImageModelId1);
            ViewData["ImageModelId19"] = new SelectList(_context.Images, "ImageId", "Title", siteSurvey.ImageModelId19);
            ViewData["ImageModelId20"] = new SelectList(_context.Images, "ImageId", "Title", siteSurvey.ImageModelId20);
            ViewData["ImageModelId21"] = new SelectList(_context.Images, "ImageId", "Title", siteSurvey.ImageModelId21);
            ViewData["ImageModelId22"] = new SelectList(_context.Images, "ImageId", "Title", siteSurvey.ImageModelId22);
            ViewData["ImageModelId23"] = new SelectList(_context.Images, "ImageId", "Title", siteSurvey.ImageModelId23);
            ViewData["ImageModelId24"] = new SelectList(_context.Images, "ImageId", "Title", siteSurvey.ImageModelId24);
            ViewData["ImageModelId2"] = new SelectList(_context.Images, "ImageId", "Title", siteSurvey.ImageModelId2);
            ViewData["ImageModelId3"] = new SelectList(_context.Images, "ImageId", "Title", siteSurvey.ImageModelId3);
            ViewData["ImageModelId4"] = new SelectList(_context.Images, "ImageId", "Title", siteSurvey.ImageModelId4);
            ViewData["ImageModelId5"] = new SelectList(_context.Images, "ImageId", "Title", siteSurvey.ImageModelId5);
            ViewData["ImageModelId6"] = new SelectList(_context.Images, "ImageId", "Title", siteSurvey.ImageModelId6);
            ViewData["ImageModelId7"] = new SelectList(_context.Images, "ImageId", "Title", siteSurvey.ImageModelId7);
            ViewData["ImageModelId8"] = new SelectList(_context.Images, "ImageId", "Title", siteSurvey.ImageModelId8);
            ViewData["IncidentId"] = new SelectList(_context.Incident, "Id", "IncidentNumber", siteSurvey.IncidentId);
            ViewData["SiteSurveyStatusId"] = new SelectList(_context.Set<SiteSurveyStatus>(), "Id", "SiteSurveyStatusName", siteSurvey.SiteSurveyStatusId);
            return View(siteSurvey);
        }

        // POST: Surveys/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditSiteSurvey(int id, [Bind("Id,SiteSurveyNumber,Description,Scheduled,Started,Ended,Created,ApplicationUserId,IncidentId,FloorOneDescription,ImageModelId,ImageModelId1,ImageModelId2,ImageModelId3,ImageModelId4,FloorTwoDescription,ImageModelId5,ImageModelId6,ImageModelId7,ImageModelId8,ImageModelId9,FloorThreeDescription,ImageModelId10,ImageModelId11,ImageModelId12,ImageModelId13,ImageModelId14,FloorFourDescription,ImageModelId15,ImageModelId16,ImageModelId17,ImageModelId18,ImageModelId19,FloorFiveDescription,ImageModelId20,ImageModelId21,ImageModelId22,ImageModelId23,ImageModelId24,SiteSurveyStatusId")] SiteSurvey siteSurvey)
        {
            if (id != siteSurvey.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(siteSurvey);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SiteSurveyExists(siteSurvey.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(IndexSearchSiteSurveys));
            }
            ViewData["ApplicationUserId"] = new SelectList(_context.Users, "Id", "FullName", siteSurvey.ApplicationUserId);
            ViewData["ImageModelId"] = new SelectList(_context.Images, "ImageId", "Title", siteSurvey.ImageModelId);
            ViewData["ImageModelId9"] = new SelectList(_context.Images, "ImageId", "Title", siteSurvey.ImageModelId9);
            ViewData["ImageModelId10"] = new SelectList(_context.Images, "ImageId", "Title", siteSurvey.ImageModelId10);
            ViewData["ImageModelId11"] = new SelectList(_context.Images, "ImageId", "Title", siteSurvey.ImageModelId11);
            ViewData["ImageModelId12"] = new SelectList(_context.Images, "ImageId", "Title", siteSurvey.ImageModelId12);
            ViewData["ImageModelId13"] = new SelectList(_context.Images, "ImageId", "Title", siteSurvey.ImageModelId13);
            ViewData["ImageModelId14"] = new SelectList(_context.Images, "ImageId", "Title", siteSurvey.ImageModelId14);
            ViewData["ImageModelId15"] = new SelectList(_context.Images, "ImageId", "Title", siteSurvey.ImageModelId15);
            ViewData["ImageModelId16"] = new SelectList(_context.Images, "ImageId", "Title", siteSurvey.ImageModelId16);
            ViewData["ImageModelId17"] = new SelectList(_context.Images, "ImageId", "Title", siteSurvey.ImageModelId17);
            ViewData["ImageModelId18"] = new SelectList(_context.Images, "ImageId", "Title", siteSurvey.ImageModelId18);
            ViewData["ImageModelId1"] = new SelectList(_context.Images, "ImageId", "Title", siteSurvey.ImageModelId1);
            ViewData["ImageModelId19"] = new SelectList(_context.Images, "ImageId", "Title", siteSurvey.ImageModelId19);
            ViewData["ImageModelId20"] = new SelectList(_context.Images, "ImageId", "Title", siteSurvey.ImageModelId20);
            ViewData["ImageModelId21"] = new SelectList(_context.Images, "ImageId", "Title", siteSurvey.ImageModelId21);
            ViewData["ImageModelId22"] = new SelectList(_context.Images, "ImageId", "Title", siteSurvey.ImageModelId22);
            ViewData["ImageModelId23"] = new SelectList(_context.Images, "ImageId", "Title", siteSurvey.ImageModelId23);
            ViewData["ImageModelId24"] = new SelectList(_context.Images, "ImageId", "Title", siteSurvey.ImageModelId24);
            ViewData["ImageModelId2"] = new SelectList(_context.Images, "ImageId", "Title", siteSurvey.ImageModelId2);
            ViewData["ImageModelId3"] = new SelectList(_context.Images, "ImageId", "Title", siteSurvey.ImageModelId3);
            ViewData["ImageModelId4"] = new SelectList(_context.Images, "ImageId", "Title", siteSurvey.ImageModelId4);
            ViewData["ImageModelId5"] = new SelectList(_context.Images, "ImageId", "Title", siteSurvey.ImageModelId5);
            ViewData["ImageModelId6"] = new SelectList(_context.Images, "ImageId", "Title", siteSurvey.ImageModelId6);
            ViewData["ImageModelId7"] = new SelectList(_context.Images, "ImageId", "Title", siteSurvey.ImageModelId7);
            ViewData["ImageModelId8"] = new SelectList(_context.Images, "ImageId", "Title", siteSurvey.ImageModelId8);
            ViewData["IncidentId"] = new SelectList(_context.Incident, "Id", "IncidentNumber", siteSurvey.IncidentId);
            ViewData["SiteSurveyStatusId"] = new SelectList(_context.Set<SiteSurveyStatus>(), "Id", "SiteSurveyStatusName", siteSurvey.SiteSurveyStatusId);
            return View(siteSurvey);
        }

        // GET: Surveys/Delete/5
        public async Task<IActionResult> DeleteSiteSurvey(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var siteSurvey = await _context.SiteSurvey
                .Include(s => s.Creator)
                .Include(s => s.ImageModel1)
                .Include(s => s.ImageModel10)
                .Include(s => s.ImageModel11)
                .Include(s => s.ImageModel12)
                .Include(s => s.ImageModel13)
                .Include(s => s.ImageModel14)
                .Include(s => s.ImageModel15)
                .Include(s => s.ImageModel16)
                .Include(s => s.ImageModel17)
                .Include(s => s.ImageModel18)
                .Include(s => s.ImageModel19)
                .Include(s => s.ImageModel2)
                .Include(s => s.ImageModel20)
                .Include(s => s.ImageModel21)
                .Include(s => s.ImageModel22)
                .Include(s => s.ImageModel23)
                .Include(s => s.ImageModel24)
                .Include(s => s.ImageModel25)
                .Include(s => s.ImageModel3)
                .Include(s => s.ImageModel4)
                .Include(s => s.ImageModel5)
                .Include(s => s.ImageModel6)
                .Include(s => s.ImageModel7)
                .Include(s => s.ImageModel8)
                .Include(s => s.ImageModel9)
                .Include(s => s.Incident)
                .Include(s => s.SiteSurveyStatus)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (siteSurvey == null)
            {
                return NotFound();
            }

            return View(siteSurvey);
        }

        // POST: Surveys/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var siteSurvey = await _context.SiteSurvey.FindAsync(id);
            _context.SiteSurvey.Remove(siteSurvey);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(IndexSearchSiteSurveys));
        }

        private bool SiteSurveyExists(int id)
        {
            return _context.SiteSurvey.Any(e => e.Id == id);
        }
    }
}
