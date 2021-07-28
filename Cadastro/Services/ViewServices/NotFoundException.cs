using System;
namespace Cadastro.Services.ViewServices
{
    public class NotFoundException : ApplicationException
    {
        public NotFoundException(string mensagem) : base(mensagem)
        {
        }
    }
}
