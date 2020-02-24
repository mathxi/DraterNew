using DraterNew.Models.Class;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DraterNew.Models.Request
{
    public class ClasseRequest
    {
        public static Classe GetClasse(long Id)
        {
            Classe classe = new Classe();
            string query = "SELECT * FROM Classe where Id=@id;";


            // Open connection
            databaseConnexion connection = new databaseConnexion();
            if (connection.OpenConnection() == true)
            {
                // Create Command
                MySqlCommand cmd = new MySqlCommand(query, connection.GetConnection());

                // shield sql injection
                cmd.Parameters.AddWithValue("@id", Id);

                // Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();

                // Read the data and store them in the list
                while (dataReader.Read())
                {
                    classe.id = dataReader.GetInt32(0);
                    classe.libelle = dataReader.GetString(1);
                    classe.promo = dataReader.GetDateTime(2);
                }

                // close Data Reader
                dataReader.Close();

                // close Connection
                connection.CloseConnection();


                // return list to be displayed
            }
           
            return classe;
            
        }

        public static List<Classe> GetAllClasses()
        {
            List<Classe> Listclasse = new List<Classe>();
            string query = "SELECT * FROM Classe;";


            // Open connection
            databaseConnexion connection = new databaseConnexion();
            if (connection.OpenConnection() == true)
            {
                // Create Command
                MySqlCommand cmd = new MySqlCommand(query, connection.GetConnection());

                // shield sql injection

                // Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();

                // Read the data and store them in the list
                while (dataReader.Read())
                {
                    Classe classe = new Classe();
                    classe.id = dataReader.GetInt32(0);
                    classe.libelle = dataReader.GetString(1);
                    classe.promo = dataReader.GetDateTime(2);
                    Listclasse.Add(classe);
                }

                // close Data Reader
                dataReader.Close();

                // close Connection
                connection.CloseConnection();


                // return list to be displayed
            }

            return Listclasse;

        }
    }
}