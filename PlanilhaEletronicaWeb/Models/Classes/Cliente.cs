using PlanilhaEletronicaWeb.Models.Validator;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PlanilhaEletronicaWeb.Models.Classes
{
	public class Cliente : IValidatableObject
	{
		public int Id { get; set; }
		public String Nome { get; set; }

		[Display(Name = "Aniversário")]
		//[DataType(DataType.Date)]
		[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
		public DateTime DataAniversario { get; set; }

		//[Required(ErrorMessage = "O email é obrigatório")]
		//[RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", 
		//ErrorMessage = "E-mail inválido.")]
		public String Email { get; set; }

		//[Required(ErrorMessage = "Confirmação de email é obrigatório")]
		//[Compare("Email", ErrorMessage = "Confirmação de email são diferentes.")]
		[Display(Name ="Confirmar Email")]
		public String ComfirmacaoEmail { get; set; }

		public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
		{
			var validator = new ClienteValidator();
			var result = validator.Validate(this);
			return result.Errors.Select(erro => new ValidationResult(erro.ErrorMessage, new[] { erro.PropertyName }));
		}
	}
}