using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using People.Models.ViewModels;
using People.Models.InputModels;
using People.Models.Services.Infrastructure;
using People.Models.Entities;


namespace People.Models.Services.Application
{
    public class EfCorePersonService : IPersonService

    {
        //tramite questo oggetto eseguiremo le operazioni CRUD per le Persons e le Auto
        private readonly MyPersonDbContext dbContext;

        public EfCorePersonService(MyPersonDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        
        //Deve recuperare tutte le persone presenti nella tabella Persons del db
        //SELECT * FROM Persons
        public List<PersonViewModel> GetPeople()
        {
            List<PersonViewModel> persons = dbContext.Persons.Select(person =>
            new PersonViewModel
            {
                Id = person.Id,
                Name = person.Name,
                Surname = person.Surname,
                Age = person.Age,
            }).ToList(); //dopo che ha recuperarto tutte le righe della tabella inserirsci tutto nella lista Persons

            return persons;
        }

         //Deve recuperare il dettaglio della singola Persona nel db
        public PersonDetailViewModel GetPerson(int id){
            PersonDetailViewModel viewModel = dbContext.Persons
            .Where(person => person.Id == id)
            .Select(person => new PersonDetailViewModel
            {
                Id = person.Id,
                Name = person.Name,
                Surname = person.Surname,
                Age = person.Age,
                Bio = person.Bio,
                Cars = person.Cars.Select(auto => new AutoViewModel
                {
                    Targa = auto.Targa,
                    Marca = auto.Marca,
                    Modello = auto.Modello,
                    Colore = auto.Colore
                }).ToList()
            }).Single();
            
            return viewModel;
        }

        // Nuovo metodo per creare una persona
        public PersonDetailViewModel CreatePerson(PersonCreateInputModel input)
        {
            string name = input.Name;
            string surname = input.Surname;
            var person = new Person(name,surname);
            dbContext.Add(person); //tramite il metodo Add eseguo una INSERT INTO nella tabella Persons aggiugengo il nuovo oggetto Person
            dbContext.SaveChanges(); //tramite il metodo SaveChanges() eseguo l' INSERT INTO 

            return PersonDetailViewModel.FromEntity(person);

        }

        // Nuovo metodo per aggiornare una persona
        public PersonDetailViewModel UpdatePerson(PersonUpdateInputModel input){
        
            // Trovo la persona da aggiornare
            var personToUpdate = dbContext.Persons.Where(person => person.Id == input.Id).FirstOrDefault();

            if (personToUpdate != null)
            {
                // Aggiorno le proprietà della persona
                personToUpdate.Name = input.Name;
                personToUpdate.Surname = input.Surname;
                personToUpdate.Age = input.Age;
                personToUpdate.Bio = input.Bio;

                // Salvo i cambiamenti
                dbContext.SaveChanges();

                // Restituisco il modello di dettaglio aggiornato
                return PersonDetailViewModel.FromEntity(personToUpdate);
            }
            else
            {
                // Se la persona non esiste lancio un'eccezione
                throw new Exception("La persona da aggiornare non è stata trovata!");
            }

        } 


        // Nuovo metodo per eliminare una persona
        public void DeletePerson(int id){
            
             // Trovo la persona da eliminare
            var personToDelete = dbContext.Persons.Where(person => person.Id == id).FirstOrDefault();

            if (personToDelete != null)
            {
                // Rimuovo la persona
                dbContext.Persons.Remove(personToDelete);
                // Salvo la modifica nel Db
                dbContext.SaveChanges();
            }
            else 
            {
                //Se la persona non esiste lancio un'eccezione
                throw new Exception("La persona da eliminare non è stata trovata!");
            }
        }

        

    }
}
