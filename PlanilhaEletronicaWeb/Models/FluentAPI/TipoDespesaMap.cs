using PlanilhaEletronicaWeb.Models.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace PlanilhaEletronicaWeb.Models.FluentAPI
{
	public class TipoDespesaMap : EntityTypeConfiguration<TipoDespesa>
	{
		public TipoDespesaMap()
		{
			ToTable("TB_TIPO_DESP");
			HasKey(tp => tp.IdTipoDespesa).
				Property(tp => tp.IdTipoDespesa).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
			Property(tp => tp.Despesa).IsRequired().HasMaxLength(255).HasColumnType("Varchar");
			Property(tp => tp.Situacao).IsRequired().HasColumnType("bit");
			Property(tp => tp.Caracteristica).HasMaxLength(100);
			
			

		}
	}
}