﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace allegroWebApi
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class AllegroChaosBusterDBContext : DbContext
    {
        public AllegroChaosBusterDBContext()
            : base("name=AllegroChaosBusterDBContext")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<CategoryOfMyIncomingPaymentsTable> CategoryOfMyIncomingPaymentsTables { get; set; }
        public virtual DbSet<MyIncomingPaymentsTable> MyIncomingPaymentsTables { get; set; }
        public virtual DbSet<PayTransDatailsTable> PayTransDatailsTables { get; set; }
        public virtual DbSet<SoldItemsTable> SoldItemsTables { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
    }
}
