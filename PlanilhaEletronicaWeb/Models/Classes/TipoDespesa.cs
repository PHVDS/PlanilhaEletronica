using PlanilhaEletronicaWeb.Models.Validator;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace PlanilhaEletronicaWeb.Models.Classes
{
	public class TipoDespesa : IValidatableObject
	{
		public int IdTipoDespesa { get; set; }
		public string Despesa { get; set; }
		public Boolean Situacao { get; set; }
		public string Caracteristica { get; set; }
		
		public virtual ICollection<Despesa> ListaDespesa { get; set; }

		public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
		{
			var validator = new TipoDespesaValidator();
			var result = validator.Validate(this);
			return result.Errors
				.Select(erro =>
				new ValidationResult(erro.ErrorMessage, new[] { erro.PropertyName }));
		}
	}
}