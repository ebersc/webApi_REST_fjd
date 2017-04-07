using System.Collections.Generic;
using System.Web.Http;
using FJD_REST.DLL;
using FJD_REST.Models;

namespace FJD_REST.Controllers
{
    public class LoginController : ApiController
    {
        Conexao con = new Conexao();
        LoginDLL lo = new LoginDLL();
        Login login = new Login();

        // GET: api/Login

        public IEnumerable<Login> Get()
        {
            return lo.DadosLogin();
        }

        // GET: api/Login/5
        public bool Get(string ra, string senha)
        {
            login.RA = ra;
            login.SENHA = senha;
            return lo.BuscaLogin(login);
        }

        // POST: api/Login
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Login/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Login/5
        public void Delete(int id)
        {
        }
    }
}
