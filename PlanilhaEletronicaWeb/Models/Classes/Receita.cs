using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace PlanilhaEletronicaWeb.Models.Classes
{
	public class Receita
	{
		public int Id { get; set; }
		public float Valor { get; set; }
		public DateTime DataRecebimento { get; set; }
		public String Descricao { get; set; }
		public String Observacao { get; set; }
		public bool Situacao { get; set; }
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

		public int NumeroParcelas { get; set; }
	}
}