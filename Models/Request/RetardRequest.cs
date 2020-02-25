using DraterNew.Models.Class;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;

namespace DraterNew.Models.Request
{
    public class RetardRequest
    {

        /// <summary>
        /// Méthode permettant de recuperer un retard
        /// </summary>
        /// <param name="idRetard">Id du retard que l'on souhaite recuperer</param>
        /// <returns></returns>
        public static Retard getRetard(int idRetard)
        {
            Retard retard;
            string query = "SELECT * FROM retard where id=@idRetard;";


            // Open connection
            databaseConnexion connection = new databaseConnexion();
            if (connection.OpenConnection() == true)
            {
                // Create Command
                using (MySqlCommand cmd = new MySqlCommand(query, connection.GetConnection()))
                {

                    // shield sql injection
                    cmd.Parameters.AddWithValue("@idRetard", idRetard);

                    // Create a data reader and Execute the command
                    using (MySqlDataReader dataReader = cmd.ExecuteReader())
                    {

                        // Read the data and store them in the list
                        while (dataReader.Read())
                        {
                            retard = new Retard(dataReader.GetInt32(0), dataReader.GetString(1), dataReader.GetString(2), dataReader.GetString(3));
                            return retard;
                        }

                        // close Data Reader
                        dataReader.Close();
                    }

                    // close Connection
                    connection.CloseConnection();
                }

                // return list to be displayed
            }

            return null;
        }

        /*
        public static void updatePlane(Model.Class.Plane plane)
        {
            string query = "UPDATE plane SET places_business=@places_business ,places_premium=@places_premium , places_eco=@places_eco , type=@type WHERE id=@id";


            //Open connection
            Model.ConnectionDatabase connection = new ConnectionDatabase();
            if (connection.OpenConnection() == true)

            {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, connection.GetConnection());


                cmd.Parameters.AddWithValue("@id", plane.Id);
                cmd.Parameters.AddWithValue("@places_business", plane.Places_business);
                cmd.Parameters.AddWithValue("@places_premium", plane.Places_premium);
                cmd.Parameters.AddWithValue("@places_eco", plane.Places_eco);
                cmd.Parameters.AddWithValue("@type", plane.Type);
                //Create a data reader and Execute the command
                cmd.ExecuteNonQuery();


                //close Connection
                connection.CloseConnection();




            }
        }

        public static bool insertPlane(Model.Class.Plane plane)
        {
            string query = "insert into plane (places_business,places_premium,places_eco,type) values (@places_business,@places_premium,@places_eco,@type)";


            //Open connection
            Model.ConnectionDatabase connection = new ConnectionDatabase();
            if (connection.OpenConnection() == true)

            {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, connection.GetConnection());


                cmd.Parameters.AddWithValue("@id", plane.Id);
                cmd.Parameters.AddWithValue("@places_business", plane.Places_business);
                cmd.Parameters.AddWithValue("@places_premium", plane.Places_premium);
                cmd.Parameters.AddWithValue("@places_eco", plane.Places_eco);
                cmd.Parameters.AddWithValue("@type", plane.Type);

                cmd.ExecuteNonQuery();


                //close Connection
                connection.CloseConnection();

            }
            return true;
        }






        */
        /// <summary>
        /// Recupere tout les retards présent dans la base de donnée
        /// </summary>
        /// <returns></returns>
        public static ObservableCollection<Retard> GetRetards()
        {
            ObservableCollection<Retard> retards = new ObservableCollection<Retard>();
            string query = "SELECT * FROM  retard;";


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
                            Retard retard = new Retard(dataReader.GetInt32(0), dataReader.GetString(1), dataReader.GetString(2), dataReader.GetString(3));
                            retards.Add(retard);
                        }

                        // close Data Reader
                        dataReader.Close();
                    }

                    // close Connection
                    connection.CloseConnection();

                }
                // return list to be displayed
                return retards;
            }
            else
            {
                return retards;
            }

        }

        /// <summary>
        /// Méthode permettant la mise a jour d'un retard
        /// </summary>
        /// <param name="retard">Retard que l'on souhaite mettre a jour</param>
        public static void Update(Retard retard)
        {

            string query = "Update retard set titre = @titre , description = @description , file = @file WHERE Id = @id";


            // Open connection
            databaseConnexion connection = new databaseConnexion();
            if (connection.OpenConnection() == true)
            {
                // Create Command
                using (MySqlCommand cmd = new MySqlCommand(query, connection.GetConnection()))
                {

                    // shield sql injection
                    cmd.Parameters.AddWithValue("@id", retard.id);
                    cmd.Parameters.AddWithValue("@titre", retard.titre);
                    cmd.Parameters.AddWithValue("@description", retard.description);
                    cmd.Parameters.AddWithValue("@file", retard.file);
                    // close Connection

                    int result = cmd.ExecuteNonQuery();
                    connection.CloseConnection();

                }
            }
        }

        /// <summary>
        /// Méthode permettant la création d'un retard
        /// </summary>
        /// <param name="retard">Eleve que l'on souhaite créer dans la base</param>
        public static void Create(Retard retard)
        {

            string query = "INSERT INTO Retard (id, titre, description, file) VALUES (null, @titre, @description, @file)";

            // Open connection
            databaseConnexion connection = new databaseConnexion();
            if (connection.OpenConnection() == true)
            {
                // Create Command
                using (MySqlCommand cmd = new MySqlCommand(query, connection.GetConnection()))
                {

                    // shield sql injection
                    cmd.Parameters.AddWithValue("@titre", retard.titre);
                    cmd.Parameters.AddWithValue("@description", retard.description);
                    cmd.Parameters.AddWithValue("@file", retard.file);
                    // close Connection

                    int result = cmd.ExecuteNonQuery();
                    connection.CloseConnection();

                }
            }
        }

        /// <summary>
        /// Supprime le retard passé en paramètre dans la base de donnée
        /// </summary>
        /// <param name="id">L'id du retard que l'on souhaite supprimer</param>
        public static void Delete(int id)
        {
            string query = "DELETE FROM retard WHERE id = @id";
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
