﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SamsungTest1.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class hyperiondg_samsung_sales_forceEntities : DbContext
    {
        public hyperiondg_samsung_sales_forceEntities()
            : base("name=hyperiondg_samsung_sales_forceEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<banner> banner { get; set; }
        public virtual DbSet<cliente> cliente { get; set; }
        public virtual DbSet<equipo> equipo { get; set; }
        public virtual DbSet<plantelcel> plantelcel { get; set; }
        public virtual DbSet<vendedor> vendedor { get; set; }
        public virtual DbSet<usuario> usuario { get; set; }
        public virtual DbSet<samsung_vendedores> samsung_vendedores { get; set; }
        public virtual DbSet<samsung_cliente> samsung_cliente { get; set; }
    }
}
