using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using People.Models.ViewModels;
using People.Models.ValueTypes;
using People.Models.InputModels;

namespace People.Models.Services.Application
{

    public class PersonService : IPersonService
    {
        private List<PersonViewModel> _peopleList;

        public PersonService()
        {
            _peopleList = GeneratePeopleList();
        }

        private List<PersonViewModel> GeneratePeopleList()
        {
            var peopleList = new List<PersonViewModel>();
            var rand = new Random();
            int currentId = 1;

            var names = new List<string> { "Luca", "Marco", "Giulia", "Anna", "Paolo" };
            var surnames = new List<string> { "Rossi", "Bianchi", "Verdi", "Neri", "Gialli" };

            for (int i = 1; i <= 20; i++)
            {
                var garageList = new List<Auto>();
                for (int y = 0; y < 3; y++)
                {
                    int val = rand.Next(100, 900);
                    garageList.Add(new Auto(
                        $"DW{val}TJ",
                        "BMW",
                        "X4",
                        "NERA"
                    ));
                }

                var name = names[rand.Next(names.Count)];
                var surname = surnames[rand.Next(surnames.Count)];

                var person = new PersonViewModel
                {
                    Id = currentId,
                    Name = name,
                    Surname = surname,
                    Age = rand.Next(18, 90),
                    Garage = garageList
                };
                peopleList.Add(person);
                currentId++; // Incrementa l'ID per la prossima persona
            }
            return peopleList;
        }

        public List<PersonViewModel> GetPeople()
        {
            return _peopleList;
        }

        public PersonDetailViewModel GetPerson(int id)
        {
            var person = _peopleList.FirstOrDefault(p => p.Id == id);
            if (person == null)
            {
                return null; // O gestire diversamente se la persona non viene trovata
            }

            var rand = new Random();
            var bio = GenerateRandomBio(rand, person.Name, person.Surname);

            var personDetail = new PersonDetailViewModel
            {
                Id = person.Id,
                Name = person.Name,
                Surname = person.Surname,
                Age = person.Age,
                Garage = person.Garage,
                Bio = bio
            };

            return personDetail;
        }

        private string GenerateRandomBio(Random rand, string name, string surname)
        {
            var bios = new List<string>
            {
                $"Ciao sono {name} {surname}. Mi piace viaggiare e scoprire nuovi posti.",
                $"Ciao sono {name} {surname}. Amo la cucina e cucinare nuovi piatti.",
                $"Ciao sono {name} {surname}. Sono un appassionato di lettura e libri.",
                $"Ciao sono {name} {surname}. Mi piace fare sport e tenermi in forma.",
                $"Ciao sono {name} {surname}. Amo la musica e suonare la chitarra.",
                $"Ciao sono {name} {surname}. Mi piace passare il tempo con la mia famiglia e amici."
            };

            int index = rand.Next(bios.Count);
            return bios[index];
        }

        public PersonDetailViewModel CreatePerson(PersonCreateInputModel input){
            throw new NotImplementedException();
        }

         public PersonDetailViewModel UpdatePerson(PersonUpdateInputModel input) {
               throw new NotImplementedException();
         }

         public void DeletePerson(int id){
            throw new NotImplementedException();
        }


        
    }

    
}