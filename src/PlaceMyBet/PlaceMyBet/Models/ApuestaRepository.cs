using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Diagnostics;
using System.Globalization;
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
        internal List<ApuestaDTO> RetrieveDTO()
        {

            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = "select * from apuestas";

            con.Open();
            MySqlDataReader res = command.ExecuteReader();
            ApuestaDTO a = null;
            List<ApuestaDTO> apuestas = new List<ApuestaDTO>();
            while (res.Read())
            {
                Debug.WriteLine("Recuperado: " + res.GetInt32(0) + " " + res.GetDouble(1) + " " + res.GetString(2) + " " + res.GetDouble(3) + " " + res.GetDouble(4) + " " + res.GetDateTime(5) + " " + res.GetInt32(6) + " " + res.GetString(7));
                a = new ApuestaDTO(res.GetString(7),res.GetDouble(1), res.GetDouble(3),res.GetString(2), res.GetDouble(4), res.GetDateTime(5));
                apuestas.Add(a);
            }
            con.Close();
            return apuestas;
        }
        internal void Save(Apuesta a)
        {
            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();
            // para que aunque introduzcas puntos no te transforme el sql en comas
            CultureInfo culInfo = new System.Globalization.CultureInfo("es-ES");
            culInfo.NumberFormat.NumberDecimalSeparator = ".";
            culInfo.NumberFormat.CurrencyDecimalSeparator = ".";
            culInfo.NumberFormat.PercentDecimalSeparator = ".";
            culInfo.NumberFormat.CurrencyDecimalSeparator = ".";
            System.Threading.Thread.CurrentThread.CurrentCulture = culInfo;
            //
            command.CommandText = "INSERT INTO apuestas (MercadoOverUnder, TipoOverUnder, Cuota, DineroApostado, Fecha, Mercado_id_mercado, Usuario_Email) VALUES ('" + a.MercadoOverUnder + "','" + a.TipoOverUnder + "'," + datoCuota(a.MercadoOverUnder, a.TipoOverUnder) + ",'" + a.DineroApostado + "','" + a.fecha + "','" + a.Mercado_id_mercado + "','" + a.Usuario_Email + "');";
            Debug.WriteLine("comando" + command.CommandText);
            

            try
            {
                con.Open();
                command.ExecuteNonQuery();

                con.Close();
            }
            catch(MySqlException e)
            {
                Debug.WriteLine("se ha producido un error de conexion");
            }
        }

        private string datoCuota(double mercado, string tipo)
        {
            if (tipo == "over")
            {
                return string.Format("(select CuotaOver from mercados where OverUnder like '{0}';)", mercado);
            }
            

            else if(tipo=="under")
            {
                return string.Format("(select CuotaUnder from mercados where OverUnder like '{0}')", mercado);
            }
            else
            {
                return "Error";
            }
        }
    }
}