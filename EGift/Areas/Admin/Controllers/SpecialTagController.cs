using EGift.Data;
using EGift.Models;
using Microsoft.AspNetCore.Mvc;

namespace EGift.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SpecialTagController : Controller
    {
        private ApplicationDbContext _db;
        public SpecialTagController(ApplicationDbContext db)
        {
            _db = db;
        }
        //Index get action method
        public IActionResult Index()
        {
            return View(_db.SpecialTags.ToList());
        }

        //Create get action method
        public ActionResult Create()
        {
            return View();
        }
        //Create post action method
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SpecialTag specialTag)
        {
            if(ModelState.IsValid) 
            {
                _db.SpecialTags.Add(specialTag);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(specialTag);
        }
        //Edit get action method
        public ActionResult Edit(int? id)
        {
            if(id== null)
            { 
                return NotFound();
            }
            var specialTag = _db.SpecialTags.Find(id);
            if(specialTag==null) 
            {
                return NotFound();
            }
            return View(specialTag);
        }
        //Edit post action method
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(SpecialTag specialTag)
        {
            if (ModelState.IsValid)
            {
                _db.Update(specialTag);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(specialTag);
        }
        //Details get action method
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var specialTag = _db.SpecialTags.Find(id);
            if (specialTag == null)
            {
                return NotFound();
            }
            return View(specialTag);
        }
        //Details post action method
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Details(SpecialTag specialTag) 
        {
            return RedirectToAction(nameof(Index));
        }
        //Delete get action method
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var specialTag = _db.SpecialTags.Find(id);
            if (specialTag == null)
            {
                return NotFound();
            }
            return View(specialTag);
        }
        //Delete post action method
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int? id, SpecialTag specialTag)
        {
            if(id == null)
            { 
                return NotFound();
            }
            if(id!=specialTag.Id)
            {
                return NotFound();
            }
            var specialTags = _db.SpecialTags.Find(id);
            if(specialTags == null)
            { 
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                _db.Remove(specialTags);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(specialTags);
        }




    }
}
