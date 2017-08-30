using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using AlchemyApi.Models.Alchemy;

namespace AlchemyApi.Controllers
{
    public class ReagentController : Controller
    {
        ReagentLibContext db = new ReagentLibContext();

        public ActionResult Index()
        {
            return View(db.Reagents);
        }

        [HttpGet]
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken()]
        public ActionResult Create(ReagentLibItem item)
        {
            if (ModelState.IsValid)
            {
                db.Reagents.Add(item);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View(item);
            }
        }

        [HttpGet]
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
                return HttpNotFound();

            ReagentLibItem item = db.Reagents.Find(id);

            if (item == null)
                return HttpNotFound();
            else
                return View(item);
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken()]
        public ActionResult Edit(ReagentLibItem item)
        {
            if (ModelState.IsValid)
            { 
                db.Entry(item).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View(item);
            }
        }

        [HttpGet]
        [Authorize]
        public ActionResult Delete(int id)
        {
            ReagentLibItem item = db.Reagents.Include(r => r.FirstSourceReactions).Include(r => r.SecondSourceReactions).Include(r => r.ResultReactions).SingleOrDefault(x => x.Id == id);
            if (item == null)
                return HttpNotFound();

            return View(item);
        }

        [HttpPost, ActionName("Delete")]
        [Authorize]
        [ValidateAntiForgeryToken()]
        public ActionResult DeleteConfirmed(int id)
        {
            ReagentLibItem item = db.Reagents.Include(r => r.FirstSourceReactions).Include(r => r.SecondSourceReactions).Include(r => r.ResultReactions).SingleOrDefault(x => x.Id == id);
            if (item == null)
                return HttpNotFound();

            // TODO: maybe resolve it on sqlserver side? but need to normalize table
            var reactions = new List<ReactionLibItem>();
            reactions.AddRange(item.ResultReactions);
            reactions.AddRange(item.FirstSourceReactions);
            reactions.AddRange(item.SecondSourceReactions);

            db.Reactions.RemoveRange(reactions);
            db.Reagents.Remove(item);
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