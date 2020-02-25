﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DraterNew.Models.Class;
using MySql.Data.MySqlClient;

namespace DraterNew.Models.Request
{
    public class VoteRequest
    {
        public static List<Vote> getVoteByRetard(long Id)
        {
            List<Vote> votes = new List<Vote>();
            string query = "SELECT * FROM vote where idRetard=@id;";


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


                // get the new vote list
                while (dataReader.Read())
                {
                    Vote vote = new Vote();
                    vote.id = dataReader.GetInt32(0);
                    vote.idEleve = dataReader.GetInt32(1);
                    vote.idRetard = dataReader.GetInt32(2);
                    vote.dateVote = dataReader.GetDateTime(3);
                    vote.valeur = dataReader.GetBoolean(4);
                    votes.Add(vote);
                }

                // close Data Reader
                dataReader.Close();

                // close Connection
                connection.CloseConnection();


                // return list to be displayed
            }

            return votes;

        }
        public static List<Vote> upVote(long idRetard, long idEleve)
        {

            List<Vote> votes = new List<Vote>();
            string query = "INSERT INTO vote (idEleve,idRetard,valeur) VALUES  (@idEleve, @idRetard,@value)";
            string query2 = "SELECT * FROM vote where idRetard=@id;";

            // Open connection
            databaseConnexion connection = new databaseConnexion();
            if (connection.OpenConnection() == true)
            {
                // Create Command
                using (MySqlCommand cmd = new MySqlCommand(query, connection.GetConnection()))
                {

                    cmd.Parameters.AddWithValue("@idRetard", idRetard);
                    cmd.Parameters.AddWithValue("@idEleve", idEleve);
                    cmd.Parameters.AddWithValue("@value", 1);
                    int result = cmd.ExecuteNonQuery();


                    // close Connection


                }


                // Create a data reader and Execute the command
                using (MySqlCommand cmd = new MySqlCommand(query2, connection.GetConnection()))
                {
                    cmd.Parameters.AddWithValue("@id", idRetard);
                    MySqlDataReader dataReader = cmd.ExecuteReader();

                    // Read the data and store them in the list
                    while (dataReader.Read())
                    {
                        Vote vote = new Vote();
                        vote.id = dataReader.GetInt32(0);
                        vote.idEleve = dataReader.GetInt32(1);
                        vote.idRetard = dataReader.GetInt32(2);
                        vote.dateVote = dataReader.GetDateTime(3);
                        vote.valeur = dataReader.GetBoolean(4);
                        votes.Add(vote);
                    }
                }


                connection.CloseConnection();
            }

            return votes;

        }
    }
}