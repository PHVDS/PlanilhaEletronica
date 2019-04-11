using PlanilhaEletronicaWeb.Models.Classes;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PlanilhaEletronicaWeb.Models
{
	public class PlanilhaDBInitializer : DropCreateDatabaseIfModelChanges<PlanilhaEletronicaWebContext>
	{
		protected override void Seed(PlanilhaEletronicaWebContext context)
		{
			using (var dbTransaction = context.Database.BeginTransaction())
			{
				try
				{
					IList<TipoDespesa> tipoDespesa = new List<TipoDespesa>();

					tipoDespesa.Add(new TipoDespesa() { Despesa = "Cerveja", Situacao = true, Caracteristica = "Investimento" });
					tipoDespesa.Add(new TipoDespesa() { Despesa = "Carro", Situacao = true, Caracteristica = "Investimento" });

					context.TipoDespesas.AddRange(tipoDespesa);
					context.SaveChanges();

					#region Despesas
					List<Despesa> despesas = new List<Despesa>();
					
					despesas.Add(new Despesa() { Descricao = "Cerveja Importada", Situacao = true, Valor = 500, TipoDespesaID = 1, Caracteristica = Despesa.CaracteristicaDespesa.Variavel });

					context.Despesas.AddRange(despesas);
					context.SaveChanges();
					#endregion

					#region  Tipo Receitas
					IList<TipoReceita> tipoReceitas = new List<TipoReceita>();
					tipoReceitas.Add(new TipoReceita() { Nome = "Salário" });
					tipoReceitas.Add(new TipoReceita() { Nome = "Restituição IR" });
					tipoReceitas.Add(new TipoReceita() { Nome = "Indenização" });
					tipoReceitas.Add(new TipoReceita() { Nome = "Transferência entre Contas" });

					context.TipoReceitas.AddRange(tipoReceitas);
					context.SaveChanges();
					#endregion

				}
				catch (Exception e)
				{
					dbTransaction.Rollback();
					throw;
				}
				finally
				{
					dbTransaction.Commit();
				}
			}
			base.Seed(context);
		}
	}
}