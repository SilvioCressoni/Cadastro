using System;
namespace Cadastro.Models
{
    public class Cadastrado
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }

        public Cadastrado(int id, string nome, string email)
        {
            Id = id;
            Nome = nome;
            Email = email;
        }

        public Cadastrado()
        {
        }
    }
}
