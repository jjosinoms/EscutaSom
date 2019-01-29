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
    public class GravadoraController : Controller
    {
        private MeuContext db = new MeuContext();

        public ActionResult ListaBandas(int id)
        {
            var listaBandas = db.Bandas.Where(i => i.Id_Gravadora == id).ToList();
            if (listaBandas == null)
            {
                return HttpNotFound();
            }

            return View(listaBandas);
        }
        //
        // GET: /Gravadora/

        public ActionResult Index()
        {
            var listaGravadora = db.Gravadoras.ToList();
            return View(listaGravadora);
        }

        //
        // GET: /Gravadora/Details/5

        public ActionResult Details(int id = 0)
        {
            Gravadora gravadora = db.Gravadoras.Find(id);
            if (gravadora == null)
            {
                return HttpNotFound();
            }
            return View(gravadora);
        }

        //
        // GET: /Gravadora/Create

        public ActionResult Create()
        {


            return View();
        }

        //
        // POST: /Gravadora/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Gravadora gravadora)
        {
            if (ModelState.IsValid)
            {
                db.Gravadoras.Add(gravadora);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(gravadora);
        }

        //
        // GET: /Gravadora/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Gravadora gravadora = db.Gravadoras.Find(id);
            if (gravadora == null)
            {
                return HttpNotFound();
            }
            return View(gravadora);
        }

        //
        // POST: /Gravadora/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Gravadora gravadora)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gravadora).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(gravadora);
        }

        //
        // GET: /Gravadora/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Gravadora gravadora = db.Gravadoras.Find(id);
            if (gravadora == null)
            {
                return HttpNotFound();
            }
            return View(gravadora);
        }

        //
        // POST: /Gravadora/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Gravadora gravadora = db.Gravadoras.Find(id);
            db.Gravadoras.Remove(gravadora);
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