using FluentValidation;
using PlanilhaEletronicaWeb.Models.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace PlanilhaEletronicaWeb.Models.Validator
{
	public class ClienteValidator : AbstractValidator<Cliente>
	{
		public ClienteValidator()
		{
			RuleFor(cliente => cliente.Email).EmailAddress().WithMessage("E-mail inválido!");
			RuleFor(cliente => cliente.Email).Equal(cliente => cliente.ComfirmacaoEmail).WithMessage("Os e-mails precisam ser iguais!");
			RuleFor(cliente => cliente.DataAniversario).Must(ValidarData).WithMessage("Data inválida");
		}

		private bool ValidarData(DateTime date)
		{
			string expressao = @"^(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d$";

			Regex rg = new Regex(expressao);
			return rg.IsMatch(date.ToString("dd/MM/yyyy"));
		}
	}
}