using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Web;

namespace PlaceMyBet.Models
{
    public class EventoRepository
    {
        private MySqlConnection Connect()
        {
            string connString = "Server=127.0.0.1;Port=3306;Database=placemybet;uid=root;pwd=;Convert Zero Datetime=true;SslMode=none";
            MySqlConnection con = new MySqlConnection(connString);
            return con;
        }
        internal List<Evento> Retrieve() //internal es como un public pero un poco mas restrictivo
        {
            MySqlConnection con=Connect();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = "select * from Eventos";

            try
            {

                con.Open();
                MySqlDataReader res = command.ExecuteReader();
                Evento e = null;
                List<Evento> eventos = new List<Evento>(); 
                while (res.Read())

                {
                    Debug.WriteLine("Recuperado:" + res.GetInt32(0) + " " + res.GetString(1) + " " + res.GetString(2) + " " + res.GetDateTime(3));
                    e = new Evento(res.GetInt32(0), res.GetString(1), res.GetString(2), res.GetDateTime(3));
                    eventos.Add(e);
                }
                con.Close();
                return eventos;
            }
            catch(MySqlException e)
            {
                Debug.WriteLine("Se ha producido un error de conexion");
                return null;
            }
        }
        internal List<EventoDTO> RetrieveDTO() //internal es como un public pero un poco mas restrictivo
        {
            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = "select * from Eventos";

            try
            {

                con.Open();
                MySqlDataReader res = command.ExecuteReader();
                EventoDTO e = null;
                List<EventoDTO> eventos = new List<EventoDTO>();
                while (res.Read())

                {
                    Debug.WriteLine("Recuperado:" + res.GetInt32(0) + " " + res.GetString(1) + " " + res.GetString(2) + " " + res.GetDateTime(3));
                    e = new EventoDTO(res.GetString(1), res.GetString(2), res.GetDateTime(3));
                    eventos.Add(e);
                }
                con.Close();
                return eventos;
            }
            catch (MySqlException e)
            {
                Debug.WriteLine("Se ha producido un error de conexion");
                return null;
            }
        }
        internal void save(EventoNew e)
        {
            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();
            /// para que aunque introduzcas puntos no te transforme el sql en comas
            CultureInfo culInfo = new System.Globalization.CultureInfo("es-ES");
            culInfo.NumberFormat.NumberDecimalSeparator = ".";
            culInfo.NumberFormat.CurrencyDecimalSeparator = ".";
            culInfo.NumberFormat.PercentDecimalSeparator = ".";
            culInfo.NumberFormat.CurrencyDecimalSeparator = ".";
            System.Threading.Thread.CurrentThread.CurrentCulture = culInfo;
            ///Creo el metodo para ingresar la fecha de ahora
            DateTime time = DateTime.Now;
            string timeNow;
            timeNow = time.ToString("yyyy-MM-dd HH:mm tt");

            
            
            command.CommandText="INSERT INTO eventos (EquipoLocal, EquipoVisitante, Fecha) VALUES ('" + e.EquipoLocal + "','"+e.EquipoVisitante + "','" + timeNow + "');";
            Debug.WriteLine("comando" + command.CommandText);            
            try
            {
                con.Open();
                command.ExecuteNonQuery();
                        

                con.Close();
            }
            catch(MySqlException ex)
            {
                Debug.WriteLine("Se ha producido un error de conexion");
            }

            command.CommandText = "INSERT INTO mercados (OverUnder, CuotaOver, CuotaUnder, DineroApostadoOver, DineroApostadoUnder, Eventos_Identificador_evento) VALUES ('" + e.TipoMercado + "','" + CuotaOver(100) + "','" + CuotaUnder(100) + "','" + 100 + "','" + 100 + "','" + EventoIdevento(e) + "');";
            //Me quedo aqui, queria hacer los metodos para sacar los datos
            Debug.WriteLine("comando" + command.CommandText);
            try
            {
                con.Open();
                command.ExecuteNonQuery();


                con.Close();
            }
            catch (MySqlException ex)
            {
                Debug.WriteLine("Se ha producido un error de conexion");
            }


        }
    }
    }
}