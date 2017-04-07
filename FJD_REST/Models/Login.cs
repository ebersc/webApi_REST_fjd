namespace FJD_REST.Models
{
    public class Login
    {
        public string RA { get; set; }

        public string SENHA { get; set; }

        public override string ToString()
        {
            return RA + ", " + SENHA;
        }
    }
}