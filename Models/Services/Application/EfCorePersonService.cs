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
        
        //Deve recuperare tutti le persone presenti nella tabella Persons del db
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
            dbContext.Add(person);
            dbContext.SaveChanges();

            return PersonDetailViewModel.FromEntity(person);

        }

        // Nuovo metodo per aggiornare una persona
        public PersonDetailViewModel UpdatePerson(PersonUpdateInputModel input){
            return null;
        }

        // Nuovo metodo per eliminare una persona
        public void DeletePerson(int id){
            
        }
    }
}