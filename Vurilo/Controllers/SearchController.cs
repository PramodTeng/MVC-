using Microsoft.AspNetCore.Mvc;
using Vurilo.Data;
using Vurilo.Models;

namespace Vurilo.Controllers
{
    public class SearchController : Controller
    {
        private readonly ApplicationDbContext _db;

        public SearchController(ApplicationDbContext db)
        {
            _db = db;
        }
    
        public IActionResult Index()
        {

            IEnumerable<Search> objCategoryList = _db.Browse;
            return View(objCategoryList);
        }
        //GET CREATE
        public IActionResult Create()
        {

           
            return View();
        }
        //POST CREATE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Search obj)
        {   if(obj.Categories == obj.Sub_Category.ToString())
            {
                ModelState.AddModelError("Sub_Category", "The Sub Categories Cannot Exactly match the Categories");
            }
            if (ModelState.IsValid)
            {

                _db.Browse.Add(obj);
                _db.SaveChanges();
                TempData["Success"] = "New Data Created Successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }


        //GET EDIT
        public IActionResult Edit(int? VideoLength)
        {
            if(VideoLength == null )
            {
                return NotFound();
            }
            var searchFromDb = _db.Browse.Find(VideoLength);
          //  var searchFromFirst = _  db.Browse.FirstOrDefault(u=>u.VideoLength == VideoLength);
          //  var searchFromSingle = _db.Browse.SingleOrDefault(u => u.VideoLength == VideoLength);

            if (searchFromDb == null)
            {
                return NotFound();
            }
            return View(searchFromDb);

        }
        //POST EDIT
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Search obj)
        {
            if (obj.Categories == obj.Sub_Category.ToString())
            {
                ModelState.AddModelError("Sub_Category", "The Sub Categories Cannot Exactly match the Categories");
            }
            if (ModelState.IsValid)
            {

                _db.Browse.Update(obj);
                _db.SaveChanges();
                TempData["Success"] = "Data Updated Successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }
        //GET DELETE
        public IActionResult Delete(int? VideoLength)
        {
            if (VideoLength == null)
            {
                return NotFound();
            }
            var searchFromDb = _db.Browse.Find(VideoLength);
            //  var searchFromFirst = _  db.Browse.FirstOrDefault(u=>u.VideoLength == VideoLength);
            //  var searchFromSingle = _db.Browse.SingleOrDefault(u => u.VideoLength == VideoLength);

            if (searchFromDb == null)
            {
                return NotFound();
            }
            return View(searchFromDb);

        }
        //POST Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? VideoLength)
        {
            var obj = _db.Browse.Find(VideoLength);
           
           if(obj == null)
            {
                return NotFound();
            }

                _db.Browse.Remove(obj);
                _db.SaveChanges();
            TempData["Success"] = "Data Deleted Successfully";
            return RedirectToAction("Index");
            }
  
   


    }
}
