using PlanilhaEletronicaWeb.Models.FluentAPI;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PlanilhaEletronicaWeb.Models
{
    public class PlanilhaEletronicaWebContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public PlanilhaEletronicaWebContext() : base("name=PlanilhaEletronicaWebContext")
        {
        }

		public DbSet<Classes.Cliente> Clientes { get; set; }
		public DbSet<Classes.Categoria> Categorias { get; set; }
		public DbSet<Classes.TipoDespesa> TipoDespesas { get; set; }
		public DbSet<Classes.Despesa> Despesas { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Configurations.Add(new TipoDespesaMap());
			modelBuilder.Configurations.Add(new DespesaMap());
			modelBuilder.Configurations.Add(new ClienteMap());
			modelBuilder.Configurations.Add(new CategoriaMap());
			base.OnModelCreating(modelBuilder);
		}

		public System.Data.Entity.DbSet<PlanilhaEletronicaWeb.Models.Classes.Receita> Receitas { get; set; }

		public System.Data.Entity.DbSet<PlanilhaEletronicaWeb.Models.Classes.TipoReceita> TipoReceitas { get; set; }
	}
}
