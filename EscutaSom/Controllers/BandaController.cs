using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EscutaSom.Models;
using EscutaSom.Data;
using EscutaSom.ViewModel;
using System.Media;
using System.Net;
using System.IO;

namespace EscutaSom.Controllers
{
    public class BandaController : Controller
    {
        private MeuContext db = new MeuContext();


        //public void procuraMusica(int id)
        //{
        //    string pageContent = null;
        //    HttpWebRequest myReq = (HttpWebRequest)WebRequest.Create("http://youtube.com");
        //    HttpWebResponse myres = (HttpWebResponse)myReq.GetResponse();

        //    using (StreamReader sr = new StreamReader(myres.GetResponseStream()))
        //    {
        //        pageContent = sr.ReadToEnd();
        //    }

        //    if (pageContent.Contains("YourSearchWord"))
        //    {
        //        //Found It
        //    }
        //}

        public ActionResult listaFaixas(int id)
        {
            var listaFaixas = db.Faixas.Where(f => f.Id == id).ToList();
            ViewBag.listaFaixas = listaFaixas;

            return View();
        }

        public ActionResult listaAlbuns(int id)
        {
            
            var listaAlbuns = db.Albuns.Where(i => i.Id_Banda == id).ToList();

            

            if (listaAlbuns == null)
            {
                return HttpNotFound();
            }

            return View(listaAlbuns);
        }

        //
        // GET: /Banda/

        public ActionResult Index()
        {
            return View(db.Bandas.ToList());
        }

        //
        // GET: /Banda/Details/5

        public ActionResult Details(int id = 0)
        {
            Banda banda = db.Bandas.Find(id);
            if (banda == null)
            {
                return HttpNotFound();
            }
            return View(banda);
        }

        //
        // GET: /Banda/Create

        public ActionResult Create()
        {
            
            var listaGravadora = new List<Gravadora>();
            listaGravadora = db.Gravadoras.ToList();

            ViewBag.listaGravadora = listaGravadora;

            return View();
        }

        //
        // POST: /Banda/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Banda banda)
        {
            if (ModelState.IsValid)
            {
                db.Bandas.Add(banda);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(banda);
        }

        //
        // GET: /Banda/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Banda banda = db.Bandas.Find(id);
            if (banda == null)
            {
                return HttpNotFound();
            }
            return View(banda);
        }

        //
        // POST: /Banda/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Banda banda)
        {
            if (ModelState.IsValid)
            {
                db.Entry(banda).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(banda);
        }

        //
        // GET: /Banda/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Banda banda = db.Bandas.Find(id);
            if (banda == null)
            {
                return HttpNotFound();
            }
            return View(banda);
        }

        //
        // POST: /Banda/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Banda banda = db.Bandas.Find(id);
            db.Bandas.Remove(banda);
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