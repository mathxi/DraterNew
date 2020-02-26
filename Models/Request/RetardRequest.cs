using DraterNew.Models.Class;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Web;

namespace DraterNew.Models.Request
{
    public class RetardRequest
    {

        /// <summary>
        /// Méthode permettant de recuperer un retard.
        /// </summary>
        /// <param name="idRetard">Id du retard que l'on souhaite recuperer.</param>
        /// <returns>Retourne un retard.</returns>
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
                            retard = new Retard(dataReader.GetInt32(0), dataReader.GetString(1), dataReader.GetString(2), dataReader.GetString(3), dataReader.GetInt32(4));
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

        /// <summary>
        /// Méthode permettant de recuperer un retard.
        /// </summary>
        /// <param name="idRetard">Id du retard que l'on souhaite recuperer.</param>
        /// <returns>Retourne un retard.</returns>
        public static List<Retard> getRetardByEleve(int idEleve)
        {
            List<Retard> retards = new List<Retard>();
            string query = "SELECT * FROM retard where idEleve=@idEleve;";

            // Open connection
            databaseConnexion connection = new databaseConnexion();
            if (connection.OpenConnection() == true)
            {
                // Create Command
                using (MySqlCommand cmd = new MySqlCommand(query, connection.GetConnection()))
                {

                    // shield sql injection
                    cmd.Parameters.AddWithValue("@idEleve", idEleve);

                    // Create a data reader and Execute the command
                    using (MySqlDataReader dataReader = cmd.ExecuteReader())
                    {

                        // Read the data and store them in the list
                        while (dataReader.Read())
                        {
                            Retard retard = new Retard(dataReader.GetInt32(0), dataReader.GetString(1), dataReader.GetString(2), dataReader.GetString(3), dataReader.GetInt32(4));

                            retards.Add(retard);
                        }

                        // close Data Reader
                        dataReader.Close();
                    }

                    // close Connection
                    connection.CloseConnection();
                }

                // return list to be displayed
            }

            return retards;
        }

        /// <summary>
        /// Recupere tout les retards présent dans la base de donnée.
        /// </summary>
        /// <returns>Retourne une liste de retard.</returns>
        public static ObservableCollection<Retard> GetRetards(int idUserConnecte, List<int> tags)
        {
            if(tags != null)
            {
                ObservableCollection<Retard> retards = new ObservableCollection<Retard>();
                StringBuilder sb = new StringBuilder();
                sb.Append("SELECT DISTINCT re.id,re.titre,re.description,re.file, re.idEleve FROM retard re JOIN tags_retard tg_re on re.id=tg_re.idRetard WHERE tg_re.idTags in (");
                foreach (var element in tags)
                {
                    sb.Append(Convert.ToString(element));
                    sb.Append(",");
                }

                sb = sb.Remove(sb.Length - 1, 1);
                sb.Append(")");
                string query = Convert.ToString(sb);
                //string query = "SELECT DISTINCT re.id,re.titre,re.description,re.file, re.idEleve FROM retard re JOIN tags_retard tg_re on re.id=tg_re.idRetard WHERE tg_re.idTags in (@params)";

                // Open connection
                databaseConnexion connection = new databaseConnexion();
                if (connection.OpenConnection() == true)

                {
                    // Create Command
                    using (MySqlCommand cmd = new MySqlCommand(query, connection.GetConnection()))
                    {
                        
                        //cmd.Parameters.AddWithValue("@params", Convert.ToString(parametres));
                        // Create a data reader and Execute the command
                        using (MySqlDataReader dataReader = cmd.ExecuteReader())
                        {
                            // Read the data and store them in the list
                            while (dataReader.Read())
                            {
                                Retard retard = new Retard(dataReader.GetInt32(0), dataReader.GetString(1), dataReader.GetString(2), dataReader.GetString(3), dataReader.GetInt32(4), idUserConnecte);
                                retards.Add(retard);
                            }

                            // close Data Reader
                            dataReader.Close();
                        }

                        // close Connection
                        connection.CloseConnection();

                    }

                    // return list to be displayed
                }

                return retards;
            }
            else
            {
                ObservableCollection<Retard> retards = new ObservableCollection<Retard>();
                string query = "SELECT * from retard order by id desc";

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
                                Retard retard = new Retard(dataReader.GetInt32(0), dataReader.GetString(1), dataReader.GetString(2), dataReader.GetString(3), dataReader.GetInt32(4), idUserConnecte);
                                retards.Add(retard);
                            }

                            // close Data Reader
                            dataReader.Close();
                        }

                        // close Connection
                        connection.CloseConnection();

                    }

                    // return list to be displayed
                }

                return retards;
            }
            
        }


        /// <summary>
        /// Méthode permettant de recuperer un retard.
        /// </summary>
        /// <param name="idRetard">Id du retard que l'on souhaite recuperer.</param>
        /// <returns>Retourne un retard.</returns>
        public static Retard getLastRetard(Retard retardrecup)
        {
            Retard retard = null;
            string query = "SELECT * FROM `retard` WHERE titre = @titre and description = @description order BY titre DESC LIMIT 1 ;";

            // Open connection
            databaseConnexion connection = new databaseConnexion();
            if (connection.OpenConnection() == true)
            {
                // Create Command
                using (MySqlCommand cmd = new MySqlCommand(query, connection.GetConnection()))
                {

                    // shield sql injection
                    cmd.Parameters.AddWithValue("@titre", retardrecup.titre);
                    cmd.Parameters.AddWithValue("@description", retardrecup.description);

                    // Create a data reader and Execute the command
                    using (MySqlDataReader dataReader = cmd.ExecuteReader())
                    {

                        // Read the data and store them in the list
                        while (dataReader.Read())
                        {
                            retard = new Retard(dataReader.GetInt32(0), dataReader.GetString(1), dataReader.GetString(2), dataReader.GetString(3), dataReader.GetInt32(4));
                        }

                        // close Data Reader
                        dataReader.Close();
                    }

                    // close Connection
                    connection.CloseConnection();
                }

                // return list to be displayed
            }
            
                return retard;
            }


        /// <summary>
        /// Méthode permettant la mise a jour d'un retard.
        /// </summary>
        /// <param name="retard">Retard que l'on souhaite mettre a jour.</param>
        public static void Update(Retard retard)
        {

            string query = "Update retard set titre = @titre , description = @description , file = @file WHERE id = @id";

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
        /// Méthode permettant la création d'un retard.
        /// </summary>
        /// <param name="retard">Eleve que l'on souhaite créer dans la base.</param>
        public static void Create(Retard retard)
        {

            string query = "INSERT INTO Retard (id, titre, description, file, idEleve) VALUES (null, @titre, @description, @file, @idEleve)";

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
                    cmd.Parameters.AddWithValue("idEleve", retard.eleve.id);
                    
                    // close Connection

                    int result = cmd.ExecuteNonQuery();
                    connection.CloseConnection();

                }
            }
        }

        /// <summary>
        /// Supprime le retard passé en paramètre dans la base de donnée.
        /// </summary>
        /// <param name="id">L'id du retard que l'on souhaite supprimer.</param>
        public static void Delete(int id, int idEleve)
        {
            string query = "DELETE FROM retard WHERE id = @id and idEleve = @idEleve";
            // Open connection
            databaseConnexion connection = new databaseConnexion();
            if (connection.OpenConnection() == true)
            {
                // Create Command
                using (MySqlCommand cmd = new MySqlCommand(query, connection.GetConnection()))
                {
                    // shield sql injection
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@idEleve", idEleve);
                    

                    // close Connection

                    int result = cmd.ExecuteNonQuery();
                    connection.CloseConnection();
                }
            }
        }
        /// <summary>
        /// Méthode permettant de recuperer un retard.
        /// </summary>
        /// <param name="idRetard">Id du retard que l'on souhaite recuperer.</param>
        /// <returns>Retourne un retard.</returns>
        public static List<TopXRetard> GetTopX(int idEleve, int limite)
        {
            List<TopXRetard> liste = new List<TopXRetard>();
            
            string query = "SELECT *,((select count(valeur) from vote where idRetard=retardP.id AND valeur=1 )-(select count(valeur) as 'positive value' from vote where idRetard = retardP.id AND valeur = -1 )) as 'FinalValue' FROM retard retardP order by((select count(valeur) from vote where idRetard= retardP.id AND valeur = 1)-(select count(valeur) as 'positive value' from vote where idRetard = retardP.id AND valeur = -1 )) desc LIMIT @limite";

            // Open connection
            databaseConnexion connection = new databaseConnexion();
            if (connection.OpenConnection() == true)
            {
                // Create Command
                using (MySqlCommand cmd = new MySqlCommand(query, connection.GetConnection()))
                {
                    cmd.Parameters.AddWithValue("@limite", limite);
                    // Create a data reader and Execute the command
                    using (MySqlDataReader dataReader = cmd.ExecuteReader())
                    {
                        
                        // Read the data and store them in the list
                        while (dataReader.Read())
                        {
                            TopXRetard retard = new TopXRetard(dataReader.GetInt32(0), dataReader.GetString(1), dataReader.GetString(2), dataReader.GetString(3), dataReader.GetInt32(4),idEleve ,dataReader.GetInt32(5));
                            liste.Add(retard);
                        }

                        // close Data Reader
                        dataReader.Close();
                    }

                    // close Connection
                    connection.CloseConnection();
                }

                // return list to be displayed
            }

            return liste;
        }

    }

}


