using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace PlaceMyBet.Models
{
    public class ApuestaRepository
    {
        private MySqlConnection Connect()
        {
            string connString = "Server=127.0.0.1;Port=3306;Database=placemybet;uid=root;pwd=;Convert Zero Datetime=true;SslMode=none";
            MySqlConnection con = new MySqlConnection(connString);
            return con;
        }
        internal List<Apuesta> Retrieve()
        {

            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = "select * from apuestas";

            con.Open();
            MySqlDataReader res = command.ExecuteReader();
            Apuesta a = null;
            List<Apuesta> apuestas = new List<Apuesta>();
            while (res.Read())
            {
                Debug.WriteLine("Recuperado: " + res.GetInt32(0) + " " + res.GetDouble(1) + " " + res.GetString(2) + " " + res.GetDouble(3) + " " + res.GetDouble(4) + " " + res.GetDateTime(5) + " " + res.GetInt32(6) + " " + res.GetString(7));
                a = new Apuesta(res.GetInt32(0), res.GetDouble(1), res.GetString(2), res.GetDouble(3), res.GetDouble(4), res.GetDateTime(5), res.GetInt32(6), res.GetString(7));
                apuestas.Add(a);
            }
            con.Close();
            return apuestas;
        }
    }
}