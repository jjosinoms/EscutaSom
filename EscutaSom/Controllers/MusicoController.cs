using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EscutaSom.Models;
using EscutaSom.Data;

namespace EscutaSom.Controllers
{
    public class MusicoController : Controller
    {
        private MeuContext db = new MeuContext();

        //
        // GET: /Musico/

        public ActionResult Index()
        {
            return View(db.Musicos.ToList());
        }

        //
        // GET: /Musico/Details/5

        public ActionResult Details(int id = 0)
        {
            Musico musico = db.Musicos.Find(id);
            if (musico == null)
            {
                return HttpNotFound();
            }
            return View(musico);
        }

        //
        // GET: /Musico/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Musico/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Musico musico)
        {
            if (ModelState.IsValid)
            {
                db.Musicos.Add(musico);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(musico);
        }

        //
        // GET: /Musico/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Musico musico = db.Musicos.Find(id);
            if (musico == null)
            {
                return HttpNotFound();
            }
            return View(musico);
        }

        //
        // POST: /Musico/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Musico musico)
        {
            if (ModelState.IsValid)
            {
                db.Entry(musico).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(musico);
        }

        //
        // GET: /Musico/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Musico musico = db.Musicos.Find(id);
            if (musico == null)
            {
                return HttpNotFound();
            }
            return View(musico);
        }

        //
        // POST: /Musico/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Musico musico = db.Musicos.Find(id);
            db.Musicos.Remove(musico);
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