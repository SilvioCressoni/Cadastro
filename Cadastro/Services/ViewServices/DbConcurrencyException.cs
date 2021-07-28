using System;
namespace Cadastro.Services.ViewServices
{
    public class DbConcurrencyException : ApplicationException
    {
        public DbConcurrencyException(string mensagem) : base(mensagem)
        {
        }
    }
}
