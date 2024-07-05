using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using People.Models.ValueTypes;

namespace People.Models.ViewModels
{
    public class PersonViewModel
    {
        public int Id{get;set;} 
        public string Name{get;set;}
        public string Surname{get;set;}
        public int Age{get;set;}

        public List<Auto> Garage{get;set;}


        public static PersonViewModel FromDataRow(DataRow personRow)
        {
           var personViewModel = new PersonViewModel {
                // Name = Convert.ToString(personRow["Name"]),
                // Surname = Convert.ToString(personRow["Surname"]),
                // Age = Convert.ToInt32(personRow["Age"]),
                // Id = Convert.ToInt32(personRow["Id"])

                Name = personRow.IsNull("Name") ? string.Empty : Convert.ToString(personRow["Name"]),
                Surname = personRow.IsNull("Surname") ? string.Empty : Convert.ToString(personRow["Surname"]),
                Age = personRow.IsNull("Age") ? 0 : Convert.ToInt32(personRow["Age"]),
                Id = personRow.IsNull("Id") ? 0 : Convert.ToInt32(personRow["Id"])
            };
            return personViewModel;
        }

    }
}