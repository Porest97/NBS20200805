using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using NBS.Data;
using NBS.ImageUpload.Models;

namespace NBS.ImageUpload.Controllers
{
    public class ImageController : Controller
    {
        private readonly NBSContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;

        public ImageController(NBSContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            this._hostEnvironment = hostEnvironment;
        }

        // GET: NABLogs
        public async Task<IActionResult> Index()
        {
            var nBSContext = _context.Images
                .Include(n => n.Incident);

            return View(await nBSContext.ToListAsync());
        }
        // GET: Incidents - search
        public async Task<IActionResult> IndexSearch
            (string searchString)
        {
            var images = from i in _context.Images
                .Include(n => n.Incident)               

                          select i;

            if (!String.IsNullOrEmpty(searchString))
            {
                images = images
                .Include(n => n.Incident)                
                .Where(s => s.Incident.IncidentNumber.Contains(searchString));
            }           
            return View(await images.ToListAsync());
        }

        //// GET: Image
        //public async Task<IActionResult> Index()
        //{
        //    var nBSContext = _context.Images
        //        .Include(i => i.Incident);

        //    return View(await _context.Images.ToListAsync());
        //}

        // GET: Image/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var imageModel = await _context.Images
                .Include(n => n.Incident)
                .FirstOrDefaultAsync(m => m.ImageId == id);
            if (imageModel == null)
            {
                return NotFound();
            }
            
            return View(imageModel);
        }

        // GET: Image/Create
        public IActionResult Create()
        {
            ViewData["IncidentId"] = new SelectList(_context.Incident, "Id", "IncidentNumber");
            return View();
        }

        // POST: Image/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ImageId,Title,ImageFile,IncidentId")] ImageModel imageModel)
        {
            if (ModelState.IsValid)
            {
                var nBSContext = _context.Images
                    .Include(i => i.Incident);

                //Save image to wwwwroot/Image !
                string wwwwRootPath = _hostEnvironment.WebRootPath;
                string fileName = Path.GetFileNameWithoutExtension(imageModel.ImageFile.FileName);
                string extension = Path.GetExtension(imageModel.ImageFile.FileName);
                imageModel.ImageName=fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                string path = Path.Combine(wwwwRootPath + "/Image/", fileName);
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    await imageModel.ImageFile.CopyToAsync(fileStream);
                }
                //Insert record !
                _context.Add(imageModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(IndexSearch));
            }
            return View(imageModel);
        }

        // GET: Image/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var imageModel = await _context.Images.FindAsync(id);
            if (imageModel == null)
            {
                return NotFound();
            }
            ViewData["IncidentId"] = new SelectList(_context.Incident, "Id", "IncidentNumber", imageModel.IncidentId);
            return View(imageModel);
        }

        // POST: Image/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ImageId,Title,ImageName,IncidentId")] ImageModel imageModel)
        {
            if (id != imageModel.ImageId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(imageModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ImageModelExists(imageModel.ImageId))
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
            return View(imageModel);
        }

        // GET: Image/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var imageModel = await _context.Images
                .FirstOrDefaultAsync(m => m.ImageId == id);
            if (imageModel == null)
            {
                return NotFound();
            }
            ViewData["IncidentId"] = new SelectList(_context.Incident, "Id", "IncidentNumber", imageModel.IncidentId);
            return View(imageModel);
        }

        // POST: Image/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var imageModel = await _context.Images.FindAsync(id);

            //Delete image from wwwwroot/Image/ !

            var imagePath = Path.Combine(_hostEnvironment.WebRootPath, "image", imageModel.ImageName);
            if (System.IO.File.Exists(imagePath))
                System.IO.File.Delete(imagePath);
            //Deletes the reccourd !
            _context.Images.Remove(imageModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(IndexSearch));
        }

        private bool ImageModelExists(int id)
        {
            return _context.Images.Any(e => e.ImageId == id);
        }
    }
}
