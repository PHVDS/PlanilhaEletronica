using PlanilhaEletronicaWeb.Models.Validator;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace PlanilhaEletronicaWeb.Models.Classes
{
	public class TipoReceita : IValidatableObject
	{
		public int Id { get; set; }
		public String Nome { get; set; }

		IEnumerable<ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
		{
			var validator = new TipoReceitaValidator();
			var result = validator.Validate(this);
			return result.Errors.Select(erro => new ValidationResult(erro.ErrorMessage, new[] { erro.PropertyName }));
		}
	}
}