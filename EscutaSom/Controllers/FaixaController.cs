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
    public class FaixaController : Controller
    {
        private MeuContext db = new MeuContext();

        //
        // GET: /Faixa/

        public ActionResult Index()
        {
            return View(db.Faixas.ToList());
        }

        //
        // GET: /Faixa/Details/5

        public ActionResult Details(int id = 0)
        {
            Faixa faixa = db.Faixas.Find(id);
            if (faixa == null)
            {
                return HttpNotFound();
            }
            return View(faixa);
        }

        //
        // GET: /Faixa/Create

        public ActionResult Create()
        {

            var listaAlbum = new List<Album>();
            listaAlbum = db.Albuns.ToList();

            ViewBag.listaAlbum = listaAlbum;

            return View();
        }

        //
        // POST: /Faixa/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Faixa faixa)
        {
            if (ModelState.IsValid)
            {
                db.Faixas.Add(faixa);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(faixa);
        }

        //
        // GET: /Faixa/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Faixa faixa = db.Faixas.Find(id);
            if (faixa == null)
            {
                return HttpNotFound();
            }
            return View(faixa);
        }

        //
        // POST: /Faixa/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Faixa faixa)
        {
            if (ModelState.IsValid)
            {
                db.Entry(faixa).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(faixa);
        }

        //
        // GET: /Faixa/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Faixa faixa = db.Faixas.Find(id);
            if (faixa == null)
            {
                return HttpNotFound();
            }
            return View(faixa);
        }

        //
        // POST: /Faixa/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Faixa faixa = db.Faixas.Find(id);
            db.Faixas.Remove(faixa);
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