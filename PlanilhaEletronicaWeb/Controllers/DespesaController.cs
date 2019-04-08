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
    public class DespesaController : Controller
    {
        private PlanilhaEletronicaWebContext db = new PlanilhaEletronicaWebContext();

        // GET: Despesa
        public ActionResult Index()
        {
            var despesas = db.Despesas.Include(d => d.TipoDespesa);
            return View(despesas.ToList());
        }

        // GET: Despesa/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Despesa despesa = db.Despesas.Find(id);
            if (despesa == null)
            {
                return HttpNotFound();
            }
            return View(despesa);
        }

        // GET: Despesa/Create
        public ActionResult Create()
        {
            ViewBag.TipoDespesaID = new SelectList(db.TipoDespesas, "IdTipoDespesa", "Despesa");
            return View();
        }

        // POST: Despesa/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdDespesa,Descricao,Caracteristica,Situacao,Valor,TipoDespesaID")] Despesa despesa)
        {
            if (ModelState.IsValid)
            {
                db.Despesas.Add(despesa);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TipoDespesaID = new SelectList(db.TipoDespesas, "IdTipoDespesa", "Despesa", despesa.TipoDespesaID);
            return View(despesa);
        }

        // GET: Despesa/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Despesa despesa = db.Despesas.Find(id);
            if (despesa == null)
            {
                return HttpNotFound();
            }
            ViewBag.TipoDespesaID = new SelectList(db.TipoDespesas, "IdTipoDespesa", "Despesa", despesa.TipoDespesaID);
            return View(despesa);
        }

        // POST: Despesa/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdDespesa,Descricao,Caracteristica,Situacao,Valor,TipoDespesaID")] Despesa despesa)
        {
            if (ModelState.IsValid)
            {
                db.Entry(despesa).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TipoDespesaID = new SelectList(db.TipoDespesas, "IdTipoDespesa", "Despesa", despesa.TipoDespesaID);
            return View(despesa);
        }

        // GET: Despesa/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Despesa despesa = db.Despesas.Find(id);
            if (despesa == null)
            {
                return HttpNotFound();
            }
            return View(despesa);
        }

        // POST: Despesa/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Despesa despesa = db.Despesas.Find(id);
            db.Despesas.Remove(despesa);
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
