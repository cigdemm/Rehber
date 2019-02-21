using Rehber.Entities.Entities;
using Rehber.Entities.Mapping;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rehber.Entities.Contex
{
  public class RehberDbContext :DbContext
    {
        public RehberDbContext() :base ("RehberConnectionstring")
        {

        }
        public DbSet<Kisi> Kisi { get; set; }
        public DbSet<Adres> Adres { get; set; }


        //Salih için
        //Entityconfiguration

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new KisiMapping());
            modelBuilder.Configurations.Add(new AdresMapping());
        }



    }
}
