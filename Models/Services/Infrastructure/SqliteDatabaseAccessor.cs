using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using Microsoft.Data.Sqlite;

namespace People.Models.Services.Infrastructure
{
    public class SqliteDatabaseAccessor : IDatabaseAccessor
    {
        public DataSet Query(string query)
        {
            using (var conn = new SqliteConnection("Data Source=Data/MyPersons.db"))
            {
                conn.Open();
                using (var cmd = new SqliteCommand(query, conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        var dataSet = new DataSet();
                        dataSet.EnforceConstraints = false;
                        do{
                            var dataTable = new DataTable();
                            dataSet.Tables.Add(dataTable);
                            dataTable.Load(reader);
                        } while (!reader.IsClosed);//la proprietà IsClosed mi permette di controlare se tutti i dati sono stati letti o meno da db
                        
                        return dataSet;

                    }
                }
                //conn.Dispose();
            }

        }
    }
}