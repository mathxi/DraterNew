using DraterNew.Models.Class;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DraterNew.Models.Request
{
    public class Tags_RetardRequest
    {
        /// <summary>
        /// Méthode permettant la création d'une classe.
        /// </summary>
        /// <param name="classe">Classe que l'on souhaite créer dans la base.</param>
        public static void Create(Retards_Tags tagRetard)
        {
            string query = "INSERT INTO tags_retard (id, idRetard, idTags) VALUES (null, @idRetard, @idTags)";

            // Open connection
            databaseConnexion connection = new databaseConnexion();
            if (connection.OpenConnection() == true)
            {
                // Create Command
                using (MySqlCommand cmd = new MySqlCommand(query, connection.GetConnection()))
                {
                    // shield sql injection
                    cmd.Parameters.AddWithValue("@idRetard", tagRetard.Id_Retard);
                    cmd.Parameters.AddWithValue("@idTags", tagRetard.Id_Tags);
                    // close Connection

                    int result = cmd.ExecuteNonQuery();
                    connection.CloseConnection();
                }
            }
        }
    }
}