using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ControleDeAcesso.Models;

namespace ControleDeAcesso.Controllers
{
    public class AcessoController : Controller
    {
        private DevMediaEntities db = new DevMediaEntities();

        // GET: Acesso
        public ActionResult Index()
        {
            return View(db.Acesso.ToList());
        }

        // GET: Acesso/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Acesso acesso = db.Acesso.Find(id);
            if (acesso == null)
            {
                return HttpNotFound();
            }
            return View(acesso);
        }

        // GET: Acesso/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Acesso/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_login,email,senha,ativo,perfil,nome,sobrenome")] Acesso acesso)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db.Acesso.Add(acesso);
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("Banco de Dados", "Não foi possível criar o usuário");
                    return View(acesso);
                }

                return RedirectToAction("Index");
            }

            return View(acesso);
        }

        // GET: Acesso/Edit/5
        [Authorize(Roles = "Administrador")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Acesso acesso = db.Acesso.Find(id);
            if (acesso == null)
            {
                return HttpNotFound();
            }
            return View(acesso);
        }

        // POST: Acesso/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Administrador")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_login,email,senha,ativo,perfil,nome,sobrenome")] Acesso acesso)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db.Entry(acesso).State = EntityState.Modified;
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("Banco de Dados", "Não foi possível editar o usuário");
                    return View(acesso);
                }

                return RedirectToAction("Index");
            }
            return View(acesso);
        }

        // GET: Acesso/Delete/5
        [Authorize(Roles = "Administrador")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Acesso acesso = db.Acesso.Find(id);
            if (acesso == null)
            {
                return HttpNotFound();
            }
            return View(acesso);
        }

        // POST: Acesso/Delete/5
        [Authorize(Roles = "Administrador")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Acesso acesso = db.Acesso.Find(id);

            try
            {
                db.Acesso.Remove(acesso);
                db.SaveChanges();            
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Banco de Dados", "Não foi possível deletar o usuário");
                return View(acesso);
            }

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
