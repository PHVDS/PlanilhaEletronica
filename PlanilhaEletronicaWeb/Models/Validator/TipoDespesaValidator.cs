using FluentValidation;
using PlanilhaEletronicaWeb.Models.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlanilhaEletronicaWeb.Models.Validator
{
	public class TipoDespesaValidator : AbstractValidator<TipoDespesa>
	{
		PlanilhaEletronicaWebContext db = null;

		public TipoDespesaValidator()
		{
			this.db = new PlanilhaEletronicaWebContext();
			RuleFor(tipo => tipo.Despesa).MaximumLength(25).WithMessage("Máximo de 25 caracteres");
			RuleFor(tipo => tipo.Despesa).Must((tipo, nome) => { return UniqueName(tipo.IdTipoDespesa, tipo.Despesa); }).WithMessage("Tipo de Despesa Cadastrada.");
		}

		private bool UniqueName(int id, String nome)
		{

			int count = 0;
			string nomeTipo = String.Empty;
			nome = nome.Trim().ToLower();
			if (id == 0)
			{
				// Se ID = 0, inserção
				count = this.db.TipoDespesas
								  .Where(x => x.Despesa.Trim().ToLower() == nome && x.Situacao == true).Count();

				return count == 0;
			}
			else if (!String.IsNullOrEmpty(nome))
			{
				// Atualização....
				var result = this.db.TipoDespesas
								 .Where(x => x.IdTipoDespesa != id && x.Despesa.Trim().ToLower() == nome && x.Situacao == true)
								 .Select(x => new { nome = x.Despesa });

				count = result.Count();
				// Se resultado = NULL, trocou para um nome que não existe => OK
				// Se resultado igual a algum nome, há um TipoDespesa já cadastrado
				nomeTipo = result.FirstOrDefault() == null ? String.Empty : result.FirstOrDefault().nome.Trim().ToLower();

				return count == 0 || (count == 1 && !nomeTipo.Equals(nome));
			}
			else
			{
				// deletando... não precisa validar
				return true;
			}
		}
	}
}