using System;

namespace FJD_REST.Models
{
    public class Secret_Servicos
    {
        public int id { get; set; }

        public string protocolo { get; set; }

        public string ra { get; set; }

        public string servico { get; set; }

        public string texto { get; set; }

        public DateTime data { get; set; }

        public TimeSpan hora { get; set; }

        public string situacao { get; set; }

        public string observacao { get; set; }

        public string usuario { get; set; }

        public DateTime data_fim { get; set; }

        public TimeSpan hora_fim { get; set; }

        public string enviado { get; set; }
    }
}