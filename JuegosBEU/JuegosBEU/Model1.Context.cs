﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace JuegosBEU
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class DeliveryJWEntities : DbContext
    {
        public DeliveryJWEntities()
            : base("name=DeliveryJWEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Banco> Banco { get; set; }
        public virtual DbSet<CabeceraPedido> CabeceraPedido { get; set; }
        public virtual DbSet<DetallePago> DetallePago { get; set; }
        public virtual DbSet<DetallePedido> DetallePedido { get; set; }
        public virtual DbSet<Juego> Juego { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }
    }
}
