using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FJD_REST.DLL;
using FJD_REST.Models;

namespace FJD_REST.Controllers
{
    public class HistoricoController : ApiController
    {
        Historico bll = new Historico();
        HistoricoDLL dll = new HistoricoDLL();

        // GET: api/Historico/ra
        public IEnumerable<Historico> Get(string ra)
        {
            bll.Ra = ra;
            return dll.Boletim(bll);
        }

        // GET: api/Historico/
        public string Get()
        {
            return "value";
        }

        // POST: api/Historico
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Historico/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Historico/5
        public void Delete(int id)
        {
        }
    }
}
