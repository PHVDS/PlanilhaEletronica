using PlanilhaEletronicaWeb.Models.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace PlanilhaEletronicaWeb.Models.FluentAPI
{
	public class CategoriaMap : EntityTypeConfiguration<Categoria>
	{
		public CategoriaMap()
		{
			ToTable("TB_CATEGORIA");
			HasKey(ct => ct.Id).Property(ct => ct.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

			Property(ct => ct.Nome).HasMaxLength(255).IsRequired().HasColumnType("VarChar");
			Property(ct => ct.Status).IsRequired().HasColumnType("VarChar");
		}
	}
}