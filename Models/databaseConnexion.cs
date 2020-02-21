using MySql.Data.MySqlClient;
using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DraterNew.Models
{
    class databaseConnexion
    {
        private MySqlConnection connection;

        // Constructeur
        public databaseConnexion()
        {
            this.InitConnexion();
        }

        // Méthode pour initialiser la connexion
        private void InitConnexion()
        {
            // Création de la chaîne de connexion
            try
            {
                this.connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["localmysql"].ConnectionString);
            }
            catch (InvalidCastException e)
            {
                Console.WriteLine(e);
            }




        }

        //open connection to database
        public bool OpenConnection()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                switch (ex.Number)
                {
                    case 0:
                        Console.WriteLine(ex);
                        break;

                    case 1045:
                        Console.WriteLine(ex);
                        break;
                }
                return false;
            }
        }

        //Close connection
        public bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex);
                return false;
            }
        }

        public MySqlConnection GetConnection()
        {
            return connection;
        }

    }
}
