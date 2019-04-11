using PlanilhaEletronicaWeb.Models;
using PlanilhaEletronicaWeb.Models.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PlanilhaEletronicaWeb.Controllers
{
    public class ListaReceitaController : Controller
    {
		private PlanilhaEletronicaWebContext db = new PlanilhaEletronicaWebContext();

        // GET: ListaReceita
        public ActionResult Index(string idTipoReceita, string Filtrar)
        {
			if (String.IsNullOrEmpty(idTipoReceita))
			{
				idTipoReceita = "0";
			}
			int IdReceita = int.Parse(idTipoReceita);
			var query = from tr in db.Receitas
						where tr.IdTipoReceita == IdReceita
						select new { tr.IdTipoReceita, tr.Situacao };

			var tipoReceita = new List<Receita>();

			if (Filtrar != null)
			{
				foreach (var item in query)
				{
					Receita listReceita = new Receita();
					listReceita.IdTipoReceita = item.IdTipoReceita;
					listReceita.Situacao = item.Situacao;
					tipoReceita.Add(listReceita);
				}
			}
			ViewBag.IdTipoReceita = new SelectList(db.Receitas, "IdTipoReceita", "IdTipoReceita");
			ViewBag.Situacao = new SelectList(db.Receitas, "Situacao", "Situacao");

			ViewBag.Lista = tipoReceita.ToList();
			return View();
        }
    }
}