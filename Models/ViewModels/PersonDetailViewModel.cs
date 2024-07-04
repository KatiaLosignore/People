using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;

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
                Name = Convert.ToString(personRow["Name"]),
                Surname = Convert.ToString(personRow["Surname"]),
                Age = Convert.ToInt32(personRow["Age"]),
                Bio = Convert.ToString(personRow["Bio"]),
                Id = Convert.ToInt32(personRow["Id"]),
                Cars = new List<AutoViewModel>()
            };
            return personDetailViewModel;
        }

    }
}