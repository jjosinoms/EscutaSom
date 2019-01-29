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
    public class InstrumentoController : Controller
    {
        private MeuContext db = new MeuContext();

        //
        // GET: /Instrumento/

        public ActionResult Index()
        {
            return View(db.Instrumentos.ToList());
        }

        //
        // GET: /Instrumento/Details/5

        public ActionResult Details(int id = 0)
        {
            Instrumento instrumento = db.Instrumentos.Find(id);
            if (instrumento == null)
            {
                return HttpNotFound();
            }
            return View(instrumento);
        }

        //
        // GET: /Instrumento/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Instrumento/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Instrumento instrumento)
        {
            if (ModelState.IsValid)
            {
                db.Instrumentos.Add(instrumento);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(instrumento);
        }

        //
        // GET: /Instrumento/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Instrumento instrumento = db.Instrumentos.Find(id);
            if (instrumento == null)
            {
                return HttpNotFound();
            }
            return View(instrumento);
        }

        //
        // POST: /Instrumento/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Instrumento instrumento)
        {
            if (ModelState.IsValid)
            {
                db.Entry(instrumento).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(instrumento);
        }

        //
        // GET: /Instrumento/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Instrumento instrumento = db.Instrumentos.Find(id);
            if (instrumento == null)
            {
                return HttpNotFound();
            }
            return View(instrumento);
        }

        //
        // POST: /Instrumento/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Instrumento instrumento = db.Instrumentos.Find(id);
            db.Instrumentos.Remove(instrumento);
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