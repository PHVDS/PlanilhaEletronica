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
	public class CategoriaController : Controller
    {
        private PlanilhaEletronicaWebContext db = new PlanilhaEletronicaWebContext();

		// GET: Categoria
		public ActionResult Index(String Pesquisa)
        {
			var categoria = from cat in db.Categorias
							select cat;
							
			if (!String.IsNullOrEmpty(Pesquisa))
			{
				categoria = db.Categorias.Where(cat => 
				cat.Nome.ToUpper().Contains(Pesquisa.ToUpper()) ||
				cat.Nome.Trim().Contains(Pesquisa.Trim()) ||
				cat.Nome.ToLower().Contains(Pesquisa.ToLower()) ||
				cat.Status.ToUpper().Contains(Pesquisa.ToUpper()) ||
				cat.Status.ToLower().Contains(Pesquisa.ToLower()) ||
				cat.Status.Trim().Contains(Pesquisa.Trim()));
			}
            return View(categoria.ToList());
        }
		
        // GET: Categoria/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Categoria categoria = db.Categorias.Find(id);
            if (categoria == null)
            {
                return HttpNotFound();
            }
            return View(categoria);
        }
		
        // GET: Categoria/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Categoria/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome,Status")] Categoria categoria)
        {
            if (ModelState.IsValid)
            {
				var result = db.Categorias.Where(tipoCategoria => 
					tipoCategoria.Nome.ToUpper().Equals(categoria.Nome.ToUpper()) || 
					tipoCategoria.Nome.ToLower().Equals(categoria.Nome.ToLower()) || 
					tipoCategoria.Nome.Trim().Equals(categoria.Nome.Trim()));

				if (result.Count() == 0)
				{
					db.Categorias.Add(categoria);
					ModelState.AddModelError("Nome", "Nome Invalido!");
					db.SaveChanges();
				}
                return RedirectToAction("Index");
            }

            return View(categoria);
        }

        // GET: Categoria/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Categoria categoria = db.Categorias.Find(id);
            if (categoria == null)
            {
                return HttpNotFound();
            }
            return View(categoria);
        }

        // POST: Categoria/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome,Status")] Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                db.Entry(categoria).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(categoria);
        }

        // GET: Categoria/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Categoria categoria = db.Categorias.Find(id);
            if (categoria == null)
            {
                return HttpNotFound();
            }
            return View(categoria);
        }

        // POST: Categoria/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Categoria categoria = db.Categorias.Find(id);
            db.Categorias.Remove(categoria);
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
