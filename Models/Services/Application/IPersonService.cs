using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using People.Models.ViewModels;

namespace People.Models.Services.Application
{
    public interface IPersonService
    {
        List<PersonViewModel> GetPeople();

        PersonDetailViewModel GetPerson(int id);
    }
}