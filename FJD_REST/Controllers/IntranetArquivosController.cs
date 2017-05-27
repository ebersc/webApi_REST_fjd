using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FJD_REST.Models;
using FJD_REST.DLL;

namespace FJD_REST.Controllers
{
    public class IntranetArquivosController : ApiController
    {
        IntranetArquivosDLL arq = new IntranetArquivosDLL();

        // GET: api/IntranetArquivos/RA
        public IEnumerable<Intranet_Arquivos> Get(string RA)
        {
            return arq.Arquivos(RA);
        }

        // GET: api/IntranetArquivos/5
       /* public string Get(int id)
        {
            return "value";
        }*/

        // POST: api/IntranetArquivos
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/IntranetArquivos/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/IntranetArquivos/5
        public void Delete(int id)
        {
        }
    }
}
