using System;

namespace Cadastro.Models
{
    public class ErrorViewModel
    {
        public string RequestId { get; set; }
        public string Mensagem { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
        

    }
}
