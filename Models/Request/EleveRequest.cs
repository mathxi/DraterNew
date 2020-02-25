using DraterNew.Models.Class;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DraterNew.Models.Request
{
    public class EleveRequest 
    {
        /// <summary>
        /// Méthode permettant la récupération d'un éleve a l'aide de son pseudo ainsi que de son mdp.
        /// </summary>
        /// <param name="pseudo">Pseudo de l'éleve</param>
        /// <param name="mdp">Mot de passe de l'éléve</param>
        /// <returns>Retourne un éléve</returns>
        public static Eleve GetEleveByPseudoAndMDP(string pseudo, string mdp)
        {
            Eleve eleve = null;
            string query = "SELECT * FROM Eleve where pseudo=@pseudo and mdp=@mdp;";

            // Open connection
            databaseConnexion connection = new databaseConnexion();
            if (connection.OpenConnection() == true)
            {
                // Create Command
                using (MySqlCommand cmd = new MySqlCommand(query, connection.GetConnection()))
                {

                    // shield sql injection
                    cmd.Parameters.AddWithValue("@pseudo", pseudo);
                    cmd.Parameters.AddWithValue("@mdp", mdp);

                    // Create a data reader and Execute the command
                    using (MySqlDataReader dataReader = cmd.ExecuteReader())
                    {
                        // Read the data and store them in the list
                        while (dataReader.Read())
                        {
                            eleve = new Eleve(dataReader.GetInt32(0), dataReader.GetString(1), dataReader.GetString(2), dataReader.GetString(3), dataReader.GetInt64(4), dataReader.GetString(5));
                        }

                        // close Data Reader
                        dataReader.Close();
                    }

                    // close Connection
                    connection.CloseConnection();

                    // return list to be displayed
                }
            }

            return eleve;
        }

        /// <summary>
        /// Méthode permettant la récupération d'un éleve a l'aide de son pseudo ainsi que de son mdp.
        /// </summary>
        /// <param name="pseudo">Pseudo de l'éleve</param>
        /// <param name="mdp">Mot de passe de l'éléve</param>
        /// <returns>Retourne un éléve</returns>
        public static ObservableCollection<Eleve> GetEleves()
        {
            ObservableCollection<Eleve> eleves = new ObservableCollection<Eleve>();
            string query = "SELECT * FROM Eleve ";

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
                            Eleve eleve = new Eleve(dataReader.GetInt32(0), dataReader.GetString(1), dataReader.GetString(2), dataReader.GetString(3), dataReader.GetInt64(4), dataReader.GetString(5));
                            eleves.Add(eleve);
                        }

                        // close Data Reader
                        dataReader.Close();
                    }

                    // close Connection
                    connection.CloseConnection();

                    // return list to be displayed
                }
            }

            return eleves;
        }

        
        /// <summary>
        /// Permet de retourner un éleve en fonction de son ID.
        /// </summary>
        /// <param name="id">L'id de l'éleve que l'on souhaite récuperer.</param>
        /// <returns>Retourne un eleve.</returns>
        public static Eleve GetEleveById(long id)
        {
            Eleve eleve = null;
            string query = "SELECT * FROM Eleve where Id = @id;";

            // Open connection
            databaseConnexion connection = new databaseConnexion();
            if (connection.OpenConnection() == true)
            {
                // Create Command
                using (MySqlCommand cmd = new MySqlCommand(query, connection.GetConnection()))
                {

                    // shield sql injection
                    cmd.Parameters.AddWithValue("@id", id);

                    // Create a data reader and Execute the command
                    MySqlDataReader dataReader = cmd.ExecuteReader();

                    // Read the data and store them in the list
                    while (dataReader.Read())
                    {
                        eleve = new Eleve(dataReader.GetInt32(0), dataReader.GetString(1), dataReader.GetString(2), dataReader.GetString(3), dataReader.GetInt64(4), dataReader.GetString(5));
                    }

                    // close Data Reader
                    dataReader.Close();

                    // close Connection
                    connection.CloseConnection();

                    // return list to be displayed
                }
            }

            return eleve;
        }

       

        /// <summary>
        /// Méthode permettant la création d'un éleve.
        /// </summary>
        /// <param name="eleve">Eleve que l'on souhaite créer dans la base.</param>
        public static void Create(Eleve eleve)
        {
            string query = "INSERT INTO eleve (Id, pseudo, mail, mdp, IdClasse, Photo_Profile) VALUES (null, @pseudo, @mail, @mdp, @idClasse, @photo)";

            // Open connection
            databaseConnexion connection = new databaseConnexion();
            if (connection.OpenConnection() == true)
            {
                // Create Command
                using (MySqlCommand cmd = new MySqlCommand(query, connection.GetConnection()))
                {

                    // shield sql injection
                    cmd.Parameters.AddWithValue("@pseudo", eleve.pseudo);
                    cmd.Parameters.AddWithValue("@mail", eleve.mail);
                    cmd.Parameters.AddWithValue("@mdp", eleve.MDP);
                    cmd.Parameters.AddWithValue("@idClasse", eleve.idClasse.id);
                    cmd.Parameters.AddWithValue("@photo", eleve.photo_profile);
                    // close Connection

                    int result = cmd.ExecuteNonQuery();
                    connection.CloseConnection();

                }
            }
        }

        /// <summary>
        /// Méthode permettant la mise a jour d'un éléve.
        /// </summary>
        /// <param name="eleve">Eleve que l'on souhaite mettre a jour.</param>
        public static void Update(Eleve eleve)
        {
            string query = "Update Eleve set pseudo = @pseudo , mail = @mail , mdp = @mdp , IdClasse = @idClasse, Photo_Profile = @photo WHERE Id = @id";

            // Open connection
            databaseConnexion connection = new databaseConnexion();
            if (connection.OpenConnection() == true)
            {
                // Create Command
                using (MySqlCommand cmd = new MySqlCommand(query, connection.GetConnection()))
                {

                    // shield sql injection
                    cmd.Parameters.AddWithValue("@id", eleve.id);
                    cmd.Parameters.AddWithValue("@pseudo", eleve.pseudo);
                    cmd.Parameters.AddWithValue("@mail", eleve.mail);
                    cmd.Parameters.AddWithValue("@mdp", eleve.MDP);
                    cmd.Parameters.AddWithValue("@idClasse", eleve.idClasse.id);
                    cmd.Parameters.AddWithValue("@photo", eleve.photo_profile);
                    // close Connection

                    int result = cmd.ExecuteNonQuery();
                    connection.CloseConnection();
                }
            }
        }

        /// <summary>
        /// Supprime l'éleve passé en paramètre dans la base de donnée.
        /// </summary>
        /// <param name="eleve">L'éleve que l'on souhaite supprimer.</param>
        public static void Delete(int id)
        {
            string query = "DELETE FROM ELEVE WHERE Id = @id";
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
