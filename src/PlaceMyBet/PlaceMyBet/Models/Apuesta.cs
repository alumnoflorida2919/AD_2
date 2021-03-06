﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlaceMyBet.Models
{
    public class Apuesta
    {
        public Apuesta(int id_apuesta, double mercadoOverUnder, string tipoOverUnder, double cuota, double dineroApostado, DateTime fecha, int mercado_id_mercado, string usuario_Email)
        {
            this.id_apuesta = id_apuesta;
            MercadoOverUnder = mercadoOverUnder;
            TipoOverUnder = tipoOverUnder;
            Cuota = cuota;
            DineroApostado = dineroApostado;
            this.fecha = fecha;
            Mercado_id_mercado = mercado_id_mercado;
            Usuario_Email = usuario_Email;
        }

        public int id_apuesta { get; set; }
        public double MercadoOverUnder { get; set; }
        public string TipoOverUnder { get; set; }
        public double Cuota { get; set; }
        public double DineroApostado { get; set; }
        public DateTime fecha { get; set; }
        public int Mercado_id_mercado { get; set; }
        public string Usuario_Email { get; set; }
    }
}