using PlanilhaEletronicaWeb.Models.Validator;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PlanilhaEletronicaWeb.Models.Classes
{
	public class Despesa
	{
		public int IdDespesa { get; set; }
		public String Descricao { get; set; }
		[DefaultValue(0)]
		public CaracteristicaDespesa Caracteristica { get; set; }
		public Boolean Situacao { get; set; }
		public float Valor { get; set; }

		public int TipoDespesaID { get; set; }
		public virtual TipoDespesa TipoDespesa { get; set; }
		
		public enum CaracteristicaDespesa
		{
			Fixa = 0,
			Variavel = 1
		}
		
		
		public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
		{
			var validator = new DespesaValidator();
			var result = validator.Validate(this);
			return result.Errors.Select(erro => new ValidationResult(erro.ErrorMessage, new[] { erro.PropertyName }));
		}
		
	}
}