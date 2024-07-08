using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using People.Models.Entities;
using People.Models.Services.Infrastructure;

namespace People.Models.ViewModels
{
    public class PersonDetailViewModel : PersonViewModel
    {
        public string Bio { get; set; }

        public List<AutoViewModel> Cars { get; set; }


        public static PersonDetailViewModel FromDataRow(DataRow personRow)
        {

           var personDetailViewModel = new PersonDetailViewModel 
           {
                // Name = Convert.ToString(personRow["Name"]),
                // Surname = Convert.ToString(personRow["Surname"]),
                // Age = Convert.ToInt32(personRow["Age"]),
                // Bio = Convert.ToString(personRow["Bio"]),
                // Id = Convert.ToInt32(personRow["Id"]),

                Name = personRow.IsNull("Name") ? string.Empty : Convert.ToString(personRow["Name"]),
                Surname = personRow.IsNull("Surname") ? string.Empty : Convert.ToString(personRow["Surname"]),
                Age = personRow.IsNull("Age") ? 0 : Convert.ToInt32(personRow["Age"]),
                Bio = personRow.IsNull("Bio") ? string.Empty : Convert.ToString(personRow["Bio"]),
                Id = personRow.IsNull("Id") ? 0 : Convert.ToInt32(personRow["Id"]),

                Cars = new List<AutoViewModel>()
            };
            
            return personDetailViewModel;
        }

        public static new PersonDetailViewModel FromEntity(Person person) {

            return new PersonDetailViewModel {
                Id = person.Id,
                Name = person.Name,
                Surname = person.Surname,
                Age = person.Age,
                Bio = person.Bio,
                Cars = person.Cars
                                .Select(car => AutoViewModel.FromEntity(car))
                                .ToList()

            };
        }

    }
}