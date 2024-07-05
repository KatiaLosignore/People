using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace People.Models.InputModels
{
     //classe che rappresenta l'oggetto che verrà popolato dai dati che verranno inseriti nel form presente in create.cshtml
    public class PersonCreateInputModel
    {
        //IMPORTANTE: il nome della proprietà di questa classe deve essere identico al nome che avete assegnato all'attributo asp-for nel campo input del form
        public string Name { get; set; }

        public string Surname { get; set; }

        public int Age {get; set; }

        public string Bio { get; set; }
    }
}