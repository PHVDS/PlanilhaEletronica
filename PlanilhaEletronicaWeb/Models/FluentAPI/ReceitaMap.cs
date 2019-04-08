using PlanilhaEletronicaWeb.Models.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace PlanilhaEletronicaWeb.Models.FluentAPI
{
	public class ReceitaMap : EntityTypeConfiguration<Receita>
	{
		public ReceitaMap()
		{
			ToTable("TB_RECEITA");
			HasKey(receita => receita.Id).
					Property(receita => receita.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
			
			//one-to-many com apenas um lado mapeado
			HasRequired<TipoReceita>(receita => receita.TipoReceita)
				.WithMany()
				.HasForeignKey(r => r.IdTipoReceita);


			Property(receita => receita.Descricao).HasMaxLength(255).IsRequired().HasColumnType("Varchar");
			Property(receita => receita.Valor).IsRequired().HasColumnType("float");
			Property(receita => receita.Parcela.FormaReceita).IsRequired().HasColumnType("int").HasColumnName("TipoRecebimento");
			Property(receita => receita.Parcela.NumeroParcelas).IsRequired().HasColumnType("int").HasColumnName("NumeroParcelas");
		}
	}
}