using DraterNew.Models.Class;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DraterNew.Models.Request
{
    public class EleveRequest 
    {

        public static Eleve GetEleveByPseudoAndMDP(string pseudo, string mdp)
        {
            Eleve eleve = null;
            string query = "SELECT * FROM Eleve where pseudo=@pseudo and mdp=@mdp;";


            // Open connection
            databaseConnexion connection = new databaseConnexion();
            if (connection.OpenConnection() == true)
            {
                // Create Command
                MySqlCommand cmd = new MySqlCommand(query, connection.GetConnection());

                // shield sql injection
                cmd.Parameters.AddWithValue("@pseudo", pseudo);
                cmd.Parameters.AddWithValue("@mdp", mdp);

                // Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();

                // Read the data and store them in the list
                while (dataReader.Read())
                {
                    eleve = new Eleve(dataReader.GetInt32(0), dataReader.GetString(1), dataReader.GetString(2), dataReader.GetString(3),dataReader.GetInt64(4), dataReader.GetString(5));
                }

                // close Data Reader
                dataReader.Close();

                // close Connection
                connection.CloseConnection();

                // return list to be displayed
               
            }
           
                return eleve;
            
        }

        public static void Create([Bind(Include = "id,titre,description,IdClasse,Photo_Profile")] Eleve eleve)
        {

            string query = "INSERT INTO eleve (Id, pseudo, mail, mdp, IdClasse, Photo_Profile) VALUES (null, @pseudo, @mail, @mdp, @idClasse, @photo)";


            // Open connection
            databaseConnexion connection = new databaseConnexion();
            if (connection.OpenConnection() == true)
            {
                // Create Command
                MySqlCommand cmd = new MySqlCommand(query, connection.GetConnection());

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

    }
