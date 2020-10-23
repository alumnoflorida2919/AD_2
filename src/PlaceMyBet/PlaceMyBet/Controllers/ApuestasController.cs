﻿using PlaceMyBet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PlaceMyBet.Controllers
{
    public class ApuestasController : ApiController
    {
        // GET: api/Apuestas
        public IEnumerable<ApuestaDTO> Get()
        {
            var repo = new ApuestaRepository();
            //List<Apuesta> apuestas = repo.Retrieve();
            List<ApuestaDTO> apuestas = repo.RetrieveDTO();
            return apuestas;
        }
        /// <summary>
        /// Metodo para filtrar apuestas a traves de Email y Tipo
        /// </summary>        
        // GET: api/Apuestas?Email=Email&tipo=tipo
        public IEnumerable<ApuestaFilter> GetApuesta(string email, string tipo)
        {
            var repo = new ApuestaRepository();
            //List<Apuesta> apuestas = repo.Retrieve();
            List<ApuestaFilter> apuestas = repo.GiveApuesta(email,tipo);
            return apuestas;
        }
        /// <summary>
        /// Metodo para filtrar a traves de Mercado_id_mercado y Email
        /// </summary>
        // GET: api/Apuestas?Mercado_id_mercado=Mercado_id_mercado&Email=Email
        public IEnumerable<ApuestaFilter2> GetApuesta2(int mercado,string email)
        {
            var repo = new ApuestaRepository();
            //List<Apuesta> apuestas = repo.Retrieve();
            List<ApuestaFilter2> apuestas = repo.GiveApuesta2(mercado,email);
            return apuestas;
        }

        // GET: api/Apuestas/5
        public Apuesta Get(int id)
        {
            /*var repo = new ApuestaRepository();
            Apuesta a = repo.Retrieve();*/
            return null;
        }
        [Authorize]
        // POST: api/Apuestas
        public void Post([FromBody]Apuesta apuesta)
        {
            var repo = new ApuestaRepository();
            repo.Save(apuesta);            
        }

        // PUT: api/Apuestas/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Apuestas/5
        public void Delete(int id)
        {
        }
    }
}
