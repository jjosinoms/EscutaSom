using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EscutaSom.Models;
using EscutaSom.Data;
using System.Diagnostics;

namespace EscutaSom.Controllers
{
    public class UsuarioController : Controller
    {
        private MeuContext db = new MeuContext();

        //
        // GET: /Usuario/


        public ActionResult Verificacao(string username, string senha)
        {

            var listaUsername = new List<Usuario>();
            var listaSenha = new List<Usuario>();
            var listaUsuario = new List<Usuario>();
            var usuariosCadastrados = new List<Usuario>();

            usuariosCadastrados = db.Usuario.ToList();
            listaSenha = db.Usuario.Where(s => s.Senha == senha).ToList();
            listaUsername = db.Usuario.Where(u => u.Username == username).ToList();

            listaUsuario = db.Usuario.Where(lu => lu.Username == username && lu.Senha == senha).ToList();

            if (username == null && senha == null)
            {
                ViewBag.mensagem = "";
            }
            else
            {

                if (listaUsername.Count() > 0 && listaSenha.Count > 0 && listaUsuario.Count > 0)
                {
                    ViewBag.mensagem = "Olá " + username + "!";
                    ViewBag.todosUsuariosCadastrados = usuariosCadastrados;
                   
                }
                else
                {
                    ViewBag.mensagem = "Desculpe " + username + ", você não está cadastrado!";
                    return View();
                }
            }

            return View();

        }

        public ActionResult Index()
        {
            return View(db.Usuario.ToList());
        }

        //
        // GET: /Usuario/Details/5

        public ActionResult Details(int id = 0)
        {
            Usuario usuario = db.Usuario.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        //
        // GET: /Usuario/Create

        public ActionResult Create()
        {

            return View();
        }

        //
        // POST: /Usuario/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Usuario usuario)
        {
            if (usuario.Senha == usuario.ConfirmarSenha)
            {
                if (ModelState.IsValid)
                {
                    db.Usuario.Add(usuario);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(usuario);
            }

            return View();
        }

        //
        // GET: /Usuario/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Usuario usuario = db.Usuario.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        //
        // POST: /Usuario/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                db.Entry(usuario).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(usuario);
        }

        //
        // GET: /Usuario/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Usuario usuario = db.Usuario.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        //
        // POST: /Usuario/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Usuario usuario = db.Usuario.Find(id);
            db.Usuario.Remove(usuario);
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