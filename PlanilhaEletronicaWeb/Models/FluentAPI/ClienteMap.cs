using PlanilhaEletronicaWeb.Models.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace PlanilhaEletronicaWeb.Models.FluentAPI
{
	public class ClienteMap : EntityTypeConfiguration<Cliente>
	{
		#region Cliente
			//public String Nome { get; set; }
			//public DateTime DataAniversario { get; set; }
			//public String Email { get; set; }
			//public String ComfirmacaoEmail { get; set; }
		#endregion
		public ClienteMap()
		{
			ToTable("TB_CLIENTE");

			HasKey(c => c.Id)
				.Property(c => c.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

			Property(c => c.Nome).HasMaxLength(255).IsRequired().HasColumnType("VarChar");
			Property(c => c.DataAniversario).IsRequired().HasColumnType("DateTime");
			Property(c => c.Email).IsRequired().HasColumnType("VarChar");
			//Property(c => c.ComfirmacaoEmail).IsRequired().HasColumnType("VarChar");
			Ignore(c => c.ComfirmacaoEmail);
			
		}
	}
}