using PlanilhaEletronicaWeb.Models.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace PlanilhaEletronicaWeb.Models.FluentAPI
{
	public class DespesaMap : EntityTypeConfiguration<Despesa>
	{
		public DespesaMap()
		{
			ToTable("TB_DESPESA");
			HasKey(d => d.IdDespesa).
				Property(d => d.IdDespesa).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

				HasRequired(despesa => despesa.TipoDespesa)
				.WithMany(despesa => despesa.ListaDespesa)
				.HasForeignKey(despesa => despesa.TipoDespesaID);
			
			Property(despesa => despesa.Descricao).HasMaxLength(255).IsRequired().HasColumnType("Varchar");
			Property(despesa => despesa.Caracteristica).IsRequired().HasColumnType("int");
			Property(despesa => despesa.Situacao).IsRequired().HasColumnType("bit");
	
		}
	}
}