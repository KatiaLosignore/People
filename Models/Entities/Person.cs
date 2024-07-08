using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace People.Models.Entities
{
    public partial class Person
    {
         public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public string Bio { get; set; }
        public ICollection<Car> Cars { get; set; }//proprietà che rappresenta la relazione 1 a molti tra Person e Car

        //Costruttore con campi obbligatori titolo e autore
        public Person(string name, string surname)
        {
            //controllo se i campi titolo e autore non sono vuoti
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Il Nome non può essere vuoto");
            }
            if (string.IsNullOrWhiteSpace(surname))
            {
                throw new ArgumentException("Il Cognome non può essere vuoto");
            }
            Name = name;
            Surname = surname;
            Cars = new HashSet<Car>();

            Age = 0;
            Bio = "La mia biografia...";
        }


        
    }
}