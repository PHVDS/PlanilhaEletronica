using FluentValidation;
using PlanilhaEletronicaWeb.Models.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlanilhaEletronicaWeb.Models.Validator
{
	public class TipoReceitaValidator : AbstractValidator<TipoReceita>
	{
		PlanilhaEletronicaWebContext db = null;

		public TipoReceitaValidator()
		{
			this.db = new PlanilhaEletronicaWebContext();
			RuleFor(tipoReceita => tipoReceita.Nome).MaximumLength(255).WithMessage("Máximo de 255 caracteres");
			RuleFor(tipoReceita => tipoReceita.Nome).Must(UniqueName).WithMessage("Tipo de Receita Cadastrada");
		}

		private bool UniqueName(String nome)
		{
			var result = this.db.TipoReceitas
								 .Where(x => x.Nome.ToLower() == nome.ToLower())
								 .Count();

			return result == 0;
		}
	}
}