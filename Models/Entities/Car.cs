using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace People.Models.Entities
{
    public class Car
    {
        // public int Id { get; set; }
        public int PersonId { get; set; }
        public string Targa { get; set; }
        public string Marca { get; set; }
        public string Modello { get; set; }
        public string Colore { get; set; }

        public Person Person { get; set; }//oggetto che rappresenta la relazione molti a uno tra car e person

        public Car(string targa)
        {
            if (string.IsNullOrEmpty(targa))
            {
                throw new ArgumentException("Una macchina deve avere una targa");
            }
            Targa = targa;
        }
    }
}