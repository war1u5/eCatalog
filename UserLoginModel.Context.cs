﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace eCatalog
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class eCatalogEntities1 : DbContext
    {
        public eCatalogEntities1()
            : base("name=UserLoginModel")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<GrupeStudiu> GrupeStudius { get; set; }
        public virtual DbSet<Materii> Materiis { get; set; }
        public virtual DbSet<NoteStudenti> NoteStudentis { get; set; }
        public virtual DbSet<Profesori> Profesoris { get; set; }
        public virtual DbSet<ProfesoriMaterii> ProfesoriMateriis { get; set; }
        public virtual DbSet<Studenti> Studentis { get; set; }
    }
}