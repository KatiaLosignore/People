using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using People.Models.Services.Infrastructure;
using People.Models.ViewModels;


namespace People.Models.Services.Application
{
    public class AdoNetPersonService : IPersonService
    {
        //Questo servizio applicativo utilizza l'interfaccia IDatabaseAccessor per accedere al database
        private readonly IDatabaseAccessor db;

        public AdoNetPersonService(IDatabaseAccessor db){
            this.db = db;
        }

        //metodo che recupera la lista di tutti i corsi presenti nel database
        public List<PersonViewModel> GetPeople()
        {
            //query che verrà eseguita nel database
            FormattableString query = $"SELECT Id, Name, Surname, Age FROM Persons";
            //un oggetto di tipo DataSet è un insieme di oggetti di tipo DataTable
            DataSet dataSet = db.Query(query); 

            //Un dataTable è una tabella in cui vengono memorizzati i dati recuperati da una SELECT nel db
            //dato che in un dataSet possono esserci più tabelle, con l'indice accedo all'i-esima tabella
            var dataTable = dataSet.Tables[0];
            var personList = new List<PersonViewModel>();
            //scorro l'oggetto DataTable riga per riga tramite la proprietà Rows
            //per ogni riga (oggetto DataRow) leggi i dati e crea l'oggetto CourseViewModel
            foreach(DataRow personRow in dataTable.Rows){
                var person = PersonViewModel.FromDataRow(personRow);
                personList.Add(person);
            }
            return personList;
        }


        public PersonDetailViewModel GetPerson(int id)
        {
            // throw new NotImplementedException();

            //In un'unica variabile string io inserisco tutte le query che devono essere eseguite
            FormattableString query = $@"SELECT Id, Name, Surname, Age, Bio FROM Persons WHERE Id ={id} 
            ; SELECT Targa, Marca, Modello, Colore FROM Auto WHERE PersonId ={id}";

            //in questo dataSet ci saranno due tabelle: la prima con i dati del corso e la seconda con i dati delle lezioni del corso
            DataSet dataSet = db.Query(query);
            var personDataTable = dataSet.Tables[0];//accedo dal dataSet alla prima tabella cioè a quella che è stata restituita dall'esecuzione dell aprima query
            if(personDataTable.Rows.Count != 1){//sto controllando se la tabella ha recuperato esattamente un dato/corso
                throw new InvalidOperationException($"Persona con id = {id} non trovata!");
            }
            var personRow = personDataTable.Rows[0];//accedo alla prima riga della tabella
            var personDetailViewModel = PersonDetailViewModel.FromDataRow(personRow);
            
            
            var autoDataTable = dataSet.Tables[1];//accedo dal dataSet alla seconda tabella cioè a quella che è stata restituita dall'esecuzione della seconda query
            foreach(DataRow autoRow in autoDataTable.Rows){
                var auto = AutoViewModel.FromDataRow(autoRow);
                personDetailViewModel.Cars.Add(auto);
            }

            return personDetailViewModel;
        }

    }
}