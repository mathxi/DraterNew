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
        /// <summary>
        /// Recupere une classe en fonction de l'id passé en parametre.
        /// </summary>
        /// <param name="Id">l'id de la classe que l'on souhaite recuperer.</param>
        /// <returns>Retourne une classe.</returns>
        public static Classe GetClasse(long Id)
        {
            Classe classe = new Classe();
            string query = "SELECT * FROM Classe where Id=@id;";

            // Open connection
            databaseConnexion connection = new databaseConnexion();
            if (connection.OpenConnection() == true)
            {
                // Create Command
                using (MySqlCommand cmd = new MySqlCommand(query, connection.GetConnection()))
                {
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
                }
            }

            return classe;
        }

        /// <summary>
        /// Recupere toutes les classes présente dans la base de données.
        /// </summary>
        /// <returns>Retourne une liste de classe.</returns>
        public static List<Classe> GetAllClasses()
        {
            List<Classe> Listclasse = new List<Classe>();
            string query = "SELECT * FROM Classe;";

            // Open connection
            databaseConnexion connection = new databaseConnexion();
            if (connection.OpenConnection() == true)
            {
                // Create Command
                using (MySqlCommand cmd = new MySqlCommand(query, connection.GetConnection()))
                {
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
                }
            }
            return Listclasse;
        }

        /// <summary>
        /// Méthode permettant la mise a jour d'une classe.
        /// </summary>
        /// <param name="classe">Classe que l'on souhaite mettre a jour.</param>
        public static void Update(Classe classe)
        {
            string query = "Update Classe set Libelle = @libelle , promo = @promo WHERE Id = @id";

            // Open connection
            databaseConnexion connection = new databaseConnexion();
            if (connection.OpenConnection() == true)
            {
                // Create Command
                using (MySqlCommand cmd = new MySqlCommand(query, connection.GetConnection()))
                {

                    // shield sql injection
                    cmd.Parameters.AddWithValue("@id", classe.id);
                    cmd.Parameters.AddWithValue("@promo", classe.libelle);
                    cmd.Parameters.AddWithValue("@mail", classe.promo);
                    // close Connection

                    int result = cmd.ExecuteNonQuery();
                    connection.CloseConnection();

                }
            }
        }

        /// <summary>
        /// Méthode permettant la création d'une classe.
        /// </summary>
        /// <param name="classe">Classe que l'on souhaite créer dans la base.</param>
        public static void Create(Classe classe)
        {
            string query = "INSERT INTO Eleve (Id, Libelle, promo) VALUES (null, @libelle, @promo)";

            // Open connection
            databaseConnexion connection = new databaseConnexion();
            if (connection.OpenConnection() == true)
            {
                // Create Command
                using (MySqlCommand cmd = new MySqlCommand(query, connection.GetConnection()))
                {
                    // shield sql injection
                    cmd.Parameters.AddWithValue("@promo", classe.libelle);
                    cmd.Parameters.AddWithValue("@mail", classe.promo);
                    // close Connection

                    int result = cmd.ExecuteNonQuery();
                    connection.CloseConnection();
                }
            }
        }

        /// <summary>
        /// Supprime la classe passé en paramètre dans la base de donnée.
        /// </summary>
        /// <param name="id">L'id de la classe que l'on souhaite supprimer.</param>
        public static void Delete(int id)
        {
            string query = "DELETE FROM Classe WHERE Id = @id";
            // Open connection
            databaseConnexion connection = new databaseConnexion();
            if (connection.OpenConnection() == true)
            {
                // Create Command
                using (MySqlCommand cmd = new MySqlCommand(query, connection.GetConnection()))
                {
                    // shield sql injection
                    cmd.Parameters.AddWithValue("@id", id);

                    // close Connection

                    int result = cmd.ExecuteNonQuery();
                    connection.CloseConnection();
                }
            }
        }
    }
}