using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using PlanilhaEletronicaWeb.Models;
using PlanilhaEletronicaWeb.Models.Classes;

namespace PlanilhaEletronicaWeb.Controllers
{
    public class ReceitaController : Controller
    {
        private PlanilhaEletronicaWebContext db = new PlanilhaEletronicaWebContext();

        // GET: Receita
        public ActionResult Index()
        {
			var receitas = db.Receitas.Include(r => r.TipoReceita);
			return View(receitas.ToList());
        }

        // GET: Receita/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Receita receita = db.Receitas.Find(id);
            if (receita == null)
            {
                return HttpNotFound();
            }
            return View(receita);
        }

        // GET: Receita/Create
        public ActionResult Create()
        {
			ViewBag.IdTipoReceita = new SelectList(db.TipoReceitas, "Id", "Nome");
			return View();
        }

        // POST: Receita/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Valor,DataRecebimento,Descricao,Observacao,Situacao,FormaRecebimento,Parcela,IdTipoReceita")] Receita receita)
        {
            if (ModelState.IsValid)
            {
                db.Receitas.Add(receita);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
			ViewBag.IdTipoReceita = new SelectList(db.TipoReceitas, "Id", "Nome", receita.IdTipoReceita);
			return View(receita);
        }

        // GET: Receita/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Receita receita = db.Receitas.Find(id);
            if (receita == null)
            {
                return HttpNotFound();
            }
			ViewBag.IdTipoReceita = new SelectList(db.TipoReceitas, "Id", "Nome", receita.IdTipoReceita);
			return View(receita);
        }

        // POST: Receita/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Valor,DataRecebimento,Descricao,Observacao,Situacao,FormaRecebimento,Parcela,IdTipoReceita")] Receita receita)
        {
            if (ModelState.IsValid)
            {
                db.Entry(receita).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
			ViewBag.IdTipoReceita = new SelectList(db.TipoReceitas, "Id", "Nome", receita.IdTipoReceita);
			return View(receita);
        }

        // GET: Receita/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Receita receita = db.Receitas.Find(id);
            if (receita == null)
            {
                return HttpNotFound();
            }
            return View(receita);
        }

        // POST: Receita/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Receita receita = db.Receitas.Find(id);
			db.Entry(receita).State = EntityState.Modified;
			//db.Receitas.Remove(receita);
			receita.Situacao = false;
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
