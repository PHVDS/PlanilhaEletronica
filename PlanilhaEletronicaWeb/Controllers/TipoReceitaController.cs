using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PlanilhaEletronicaWeb.Models;
using PlanilhaEletronicaWeb.Models.Classes;

namespace PlanilhaEletronicaWeb.Controllers
{
    public class TipoReceitaController : Controller
    {
        private PlanilhaEletronicaWebContext db = new PlanilhaEletronicaWebContext();

        // GET: TipoReceita
        public ActionResult Index()
        {
            return View(db.TipoReceitas.ToList());
        }

        // GET: TipoReceita/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoReceita tipoReceita = db.TipoReceitas.Find(id);
            if (tipoReceita == null)
            {
                return HttpNotFound();
            }
            return View(tipoReceita);
        }

        // GET: TipoReceita/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipoReceita/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome")] TipoReceita tipoReceita)
        {
            if (ModelState.IsValid)
            {
                db.TipoReceitas.Add(tipoReceita);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipoReceita);
        }

        // GET: TipoReceita/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoReceita tipoReceita = db.TipoReceitas.Find(id);
            if (tipoReceita == null)
            {
                return HttpNotFound();
            }
            return View(tipoReceita);
        }

        // POST: TipoReceita/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome")] TipoReceita tipoReceita)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipoReceita).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipoReceita);
        }

        // GET: TipoReceita/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoReceita tipoReceita = db.TipoReceitas.Find(id);
            if (tipoReceita == null)
            {
                return HttpNotFound();
            }
            return View(tipoReceita);
        }

        // POST: TipoReceita/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TipoReceita tipoReceita = db.TipoReceitas.Find(id);
            db.TipoReceitas.Remove(tipoReceita);
            db.SaveChanges();
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
