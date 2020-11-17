using PlaceMyBet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PlaceMyBet.Controllers
{
    public class ApuestasExamenController : ApiController
    {
        // GET: api/ApuestasExamen
        public IEnumerable<ApuestaExam> GetApuestasExamen(string equipo)
        {
            var repo = new ApuestaRepository();
            //List<Apuesta> apuestas = repo.Retrieve();
            List<ApuestaExam> apuestas = repo.GiveRival(equipo);
            return apuestas;
        }

        // GET: api/ApuestasExamen/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/ApuestasExamen
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/ApuestasExamen/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/ApuestasExamen/5
        public void Delete(int id)
        {
        }
    }
}
