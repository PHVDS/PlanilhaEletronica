using FluentValidation;
using PlanilhaEletronicaWeb.Models.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace PlanilhaEletronicaWeb.Models.Validator
{
	public class ReceitaValidator : AbstractValidator<Receita>
	{
		PlanilhaEletronicaWebContext db = null;

		public ReceitaValidator()
		{
			this.db = new PlanilhaEletronicaWebContext();
			RuleFor(receita => receita.Descricao).NotEmpty().WithMessage("Preencha este campo!");
			RuleFor(receita => receita.Valor).GreaterThan(0).WithMessage("Despesa precisa ser maior que zero!");
			RuleFor(receita => receita.DataRecebimento).Must(DataValida).WithMessage("Data com formato errado!");
			RuleFor(receita => receita.Descricao).Length(25).WithMessage("Máximo de 25 caracteres!");
			RuleFor(receita => receita.Parcela)
				.Must(p => p.FormaReceita == ParcelaReceita.TipoParcela.Unica && (int)p.NumeroParcelas == 1).WithMessage("Receita não parcelada!");

			RuleFor(receita => receita.Parcela)
				.Must(p => p.FormaReceita == ParcelaReceita.TipoParcela.Dividido && (int)p.NumeroParcelas > 1).WithMessage("Pelo menos 2 parcelas");
		}

		private bool DataValida(DateTime data)
		{
			string expressao = @"^(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d$";

			Regex rg = new Regex(expressao);
			return rg.IsMatch(data.ToString("dd/MM/yyyy"));
		}
	}
}