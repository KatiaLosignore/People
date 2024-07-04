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
                Name = Convert.ToString(personRow["Name"]),
                Surname = Convert.ToString(personRow["Surname"]),
                Age = Convert.ToInt32(personRow["Age"]),
                Id = Convert.ToInt32(personRow["Id"])
            };
            return personViewModel;
        }

    }
}