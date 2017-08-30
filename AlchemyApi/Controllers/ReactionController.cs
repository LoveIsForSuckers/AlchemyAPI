using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AlchemyApi.Models.Alchemy;
using System.Data.Entity;

namespace AlchemyApi.Controllers
{
    public class ReactionController : Controller
    {
        ReagentLibContext db = new ReagentLibContext();
        
        public ActionResult Index()
        {
            return View(db.Reactions.Include(item => item.FirstSourceReagentLibItem).Include(item => item.SecondSourceReagentLibItem).Include(item => item.ResultReagentLibItem).ToList());
        }

        [HttpGet]
        [Authorize]
        public ActionResult Create()
        {
            SelectList reagents = new SelectList(db.Reagents, "Id", "Title");
            ViewBag.Reagents = reagents;
            return View();
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken()]
        public ActionResult Create(ReactionLibItem reaction)
        {
            if (ModelState.IsValid)
            {
                db.Reactions.Add(reaction);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View(reaction);
            }
        }

        [HttpGet]
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
                return HttpNotFound();

            ReactionLibItem reaction = db.Reactions.Find(id);
            if (reaction == null)
                return HttpNotFound();

            SelectList reagents = new SelectList(db.Reagents, "Id", "Title");
            ViewBag.Reagents = reagents;
            return View(reaction);
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken()]
        public ActionResult Edit(ReactionLibItem reaction)
        {
            if (ModelState.IsValid)
            {
                db.Entry(reaction).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View(reaction);
            }
        }

        [HttpGet]
        [Authorize]
        public ActionResult Delete(int id)
        {
            ReactionLibItem item = db.Reactions.Include(r => r.FirstSourceReagentLibItem).Include(r => r.SecondSourceReagentLibItem).Include(r => r.ResultReagentLibItem).SingleOrDefault(x => x.Id == id);
            if (item == null)
                return HttpNotFound();

            return View(item);
        }

        [HttpPost, ActionName("Delete")]
        [Authorize]
        [ValidateAntiForgeryToken()]
        public ActionResult DeleteConfirmed(int id)
        {
            ReactionLibItem item = db.Reactions.Find(id);
            if (item == null)
                return HttpNotFound();

            db.Reactions.Remove(item);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
	}
}