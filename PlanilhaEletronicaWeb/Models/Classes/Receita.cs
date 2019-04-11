using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PlanilhaEletronicaWeb.Models.Classes
{
	public class Receita
	{
		public int Id { get; set; }
		public float Valor { get; set; }
		[DisplayFormat(ApplyFormatInEditMode = true)]
		[Display(Name = "Data de Recebimento")]
		public DateTime DataRecebimento { get; set; }
		public String Descricao { get; set; }
		public String Observacao { get; set; }
		public bool Situacao { get; set; }
		[Display(Name = "Forma de Recebimento")]
		public MeioRecebimento FormaRecebimento { get; set; }
		public ParcelaReceita Parcela { get; set; }

		public int IdTipoReceita { get; set; }
		public TipoReceita TipoReceita { get; set; }

		public enum MeioRecebimento
		{
			Cheque = 1, Dinheiro, Cartao, Transferencia
		}

		public Receita()
		{
			this.Situacao = true;
		}
	}

	public class ParcelaReceita
	{
		public TipoParcela FormaReceita { get; set; }

		public enum TipoParcela
		{
			[Description("Única")]
			Unica,
			[Description("Parcelada")]
			Dividido
		}

		[Display(Name = "Parcelas")]
		public int NumeroParcelas { get; set; }
	}
}