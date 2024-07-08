using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using People.Models.ViewModels;
using People.Models.InputModels;

namespace People.Models.Services.Application
{
    public interface IPersonService
    {
        List<PersonViewModel> GetPeople();

        PersonDetailViewModel GetPerson(int id);

        // Nuovo metodo per creare una persona
        PersonDetailViewModel CreatePerson(PersonCreateInputModel input);

        // Nuovo metodo per aggiornare una persona
        PersonDetailViewModel UpdatePerson(PersonUpdateInputModel input);

        // Nuovo metodo per eliminare una persona
        void DeletePerson(int id);

        
    }
}