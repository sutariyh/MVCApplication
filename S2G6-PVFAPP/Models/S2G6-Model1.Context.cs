﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace S2G6_PVFAPP.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class Entities : DbContext
    {
        public Entities()
            : base("name=Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Does_Business_In> Does_Business_In { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Has_Skill> Has_Skill { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Order_Line> Order_Line { get; set; }
        public virtual DbSet<Produced_In> Produced_In { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Product_Line> Product_Line { get; set; }
        public virtual DbSet<Raw_Material> Raw_Material { get; set; }
        public virtual DbSet<Salesperson> Salespersons { get; set; }
        public virtual DbSet<Skill> Skills { get; set; }
        public virtual DbSet<Supply> Supplies { get; set; }
        public virtual DbSet<Territory> Territories { get; set; }
        public virtual DbSet<Us> Uses { get; set; }
        public virtual DbSet<Vendor> Vendors { get; set; }
        public virtual DbSet<Work_Center> Work_Center { get; set; }
        public virtual DbSet<Works_In> Works_In { get; set; }
    }
}