using DraterNew.Models.Class;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;

namespace DraterNew.Models.Request
{
    public class TagsRequest
    {
        public static ObservableCollection<Tags> GetTags()
        {
            ObservableCollection<Tags> tags = new ObservableCollection<Tags>();
            string query = "SELECT * FROM `tags`";

            // Open connection
            databaseConnexion connection = new databaseConnexion();
            if (connection.OpenConnection() == true)

            {
                // Create Command
                using (MySqlCommand cmd = new MySqlCommand(query, connection.GetConnection()))
                {

                    // Create a data reader and Execute the command
                    using (MySqlDataReader dataReader = cmd.ExecuteReader())
                    {
                        // Read the data and store them in the list
                        while (dataReader.Read())
                        {
                            Tags tag = new Tags();

                            tag.Id = dataReader.GetInt64(0);
                            tag.Libelle = dataReader.GetString(1);
                           
                            tags.Add(tag);
                        }

                        // close Data Reader
                        dataReader.Close();
                    }

                    // close Connection
                    connection.CloseConnection();

                }

                // return list to be displayed
            }

            return tags;
        }

        /// <summary>
        /// Méthode permettant la création d'un tag.
        /// </summary>
        /// <param name="tags">tag que l'on souhaite créer dans la base.</param>
        public static void Create(Tags tags)
        {

            string query = "INSERT INTO tags (id, libelle) VALUES (null, @libelle)";

            // Open connection
            databaseConnexion connection = new databaseConnexion();
            if (connection.OpenConnection() == true)
            {
                // Create Command
                using (MySqlCommand cmd = new MySqlCommand(query, connection.GetConnection()))
                {

                    // shield sql injection
                    cmd.Parameters.AddWithValue("@libelle", tags.Libelle);

                    // close Connection

                    int result = cmd.ExecuteNonQuery();
                    connection.CloseConnection();

                }
            }
        }
    }
}
