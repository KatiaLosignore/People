using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Data;
using People.Models.Entities;


namespace People.Models.ViewModels
{
    public class AutoViewModel
    {
        [Key] // la Targa è la chiave primaria
        public string Targa { get; set; }

        public string Marca { get; set; }

        public string Modello { get; set; }

        public string Colore { get; set; }


        public static AutoViewModel FromDataRow(DataRow dataRow)
        {
            var autoViewModel = new AutoViewModel
            {
                Targa = Convert.ToString(dataRow["Targa"]),
                Marca = Convert.ToString(dataRow["Marca"]),
                Modello = Convert.ToString(dataRow["Modello"]),
                Colore = Convert.ToString(dataRow["Colore"]),
            };
            return autoViewModel;
        }

        public static AutoViewModel FromEntity(Car car)
        {
            return new AutoViewModel
            {
                Targa = car.Targa,
                Marca = car.Marca,
                Modello = car.Modello,
                Colore = car.Colore
            };
        }

    }

}