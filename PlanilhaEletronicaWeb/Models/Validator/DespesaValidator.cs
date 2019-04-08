using FluentValidation;
using PlanilhaEletronicaWeb.Models.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlanilhaEletronicaWeb.Models.Validator
{
	public class DespesaValidator : AbstractValidator<Despesa>
	{
		PlanilhaEletronicaWebContext db = null;

		public DespesaValidator()
		{
			this.db = new PlanilhaEletronicaWebContext();
			RuleFor(despesa => despesa.Descricao).NotEmpty().WithMessage("Preencha o campo Descrição.");
			RuleFor(despesa => despesa.Caracteristica).NotEmpty().WithMessage("Preencha o campo Caracteristica.");
			RuleFor(despesa => despesa.Valor).NotEmpty().WithMessage("Preencha o campo Valor.");
			RuleFor(despesa => despesa.TipoDespesaID).Must(NotExistsTipoDespesa).WithMessage("Tipo de Despesa não existe.");
		}

		private bool UniqueName(String nome)
		{
			var result = this.db.TipoDespesas
								 .Where(x => x.Despesa.ToLower() == nome.ToLower())
								 .Count();

			return result == 0;
		}

		/// <summary>
		/// Método que valida se existe um tipo de despesa
		/// </summary>
		/// <param name="tipoDespesaId">Id único de uma despesa</param>
		/// <returns></returns>
		private bool NotExistsTipoDespesa(int tipoDespesaId)
		{
			var result = this.db.TipoDespesas
								 .Where(x => x.IdTipoDespesa == tipoDespesaId)
								 .Count();

			return result > 0;
		}
	}
}