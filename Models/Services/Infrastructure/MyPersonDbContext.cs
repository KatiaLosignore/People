using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using People.Models.Entities;

namespace People.Models.Services.Infrastructure
{
    public class MyPersonDbContext : DbContext
    {

        public MyPersonDbContext()
        {
        }

         public MyPersonDbContext(DbContextOptions<MyPersonDbContext> options)
            : base(options)
        {
        }

         public virtual DbSet<Person> Persons { get; set; }//oggetto tramite cui potrò eseguire le operazioni CRUD con la tabella Persons del db
        public virtual DbSet<Car> Auto { get; set; }//oggetto tramite cui potrò eseguire le operazioni CRUD con la tabella Auto del db

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            // #warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
            //istruzione che mi connette al database tramite connection string
            optionsBuilder.UseSqlite("Data Source=Data/MyPersons.db");

        }


        //metodo che mi permette di configurare tutte le classi entità con le tabelle del database
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //setto tutti i matching tramite l'oggetto modelBuilder
            modelBuilder.Entity<Person>(entity =>
            {
                entity.ToTable("Persons");//tramite ToTable indico che la classe entità Person mappa la tabella Persons del db
                entity.HasKey(person => person.Id);//tramite HasKey indico che la proprietà Id è la chiave primaria della tabella   


                //codice per inserire la relazione uno a molti tra la lista di Auto nell'entità Person
                //e il singolo oggetto Person nell'entità Car
                entity.HasMany(person => person.Cars)
                .WithOne(car => car.Person)
                .HasForeignKey(car => car.PersonId);//indico che la chiave esterna è il campo PersonId dell'entità Car


                modelBuilder.Entity<Car>(e =>
                {
                    e.ToTable("Auto");//associo l'entità Car alla tabella Auto del db
                    e.HasKey(car => car.Targa);//indicco la chiave primaria di Car


                    //la proprietà Person nella classe Car rappresenta il lato 1
                    e.HasOne(car => car.Person)
                        .WithMany(person => person.Cars)//che si riferisce lato N alla proprietà Cars dell'entità Person
                        .HasForeignKey(car => car.PersonId);
                });
            });
        }

        
    }
}